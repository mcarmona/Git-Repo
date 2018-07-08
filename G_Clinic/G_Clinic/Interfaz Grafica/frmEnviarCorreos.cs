using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Miscelaneos_y_Recursos;
using System.Drawing.Drawing2D;
using Transitions;
using System.Drawing.Imaging;
using System.IO;
using System.Xml;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmEnviarCorreos : Form
    {
        int contador = 0;
        int mouseX = 0;
        int mouseY = 0;

        public frmEnviarCorreos()
        {
            InitializeComponent();
            EstableceFoco();

            this.Left = this.Width * -1;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - 22 - this.Height;
        }

        #region Set Transparent Background

        /// <para>Changes the current bitmap.</para>
        public void SetBitmap(Bitmap bitmap)
        {
            SetBitmap(bitmap, 255);
        }

        /// <para>Changes the current bitmap with a custom opacity level.  Here is where all happens!</para>
        public void SetBitmap(Bitmap bitmap, byte opacity)
        {
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

            // The ideia of this is very simple,
            // 1. Create a compatible DC with screen;
            // 2. Select the bitmap with 32bpp with alpha-channel in the compatible DC;
            // 3. Call the UpdateLayeredWindow.

            IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
            IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));  // grab a GDI handle from this GDI+ bitmap
                oldBitmap = Win32.SelectObject(memDc, hBitmap);

                Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.Point pointSource = new Win32.Point(0, 0);
                Win32.Point topPos = new Win32.Point(Left, Top);
                Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
                blend.BlendOp = Win32.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = opacity;
                blend.AlphaFormat = Win32.AC_SRC_ALPHA;

                Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
            }
            finally
            {
                Win32.ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBitmap);
                    //Windows.DeleteObject(hBitmap); // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from Win32 GDI and it's working fine without any resource leak.
                    Win32.DeleteObject(hBitmap);
                }
                Win32.DeleteDC(memDc);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00080000; // This form has to have the WS_EX_LAYERED extended style
                return cp;
            }
        }

        #endregion

        Graphics oGraphics;
        GraphicsPath oPath = new GraphicsPath();

        private void frmEnviarCorreos_Load(object sender, EventArgs e)
        {
            Bitmap oBitmap = new Bitmap(this.BackgroundImage);
            SetBitmap(oBitmap);

            Transition t = new Transition(new TransitionType_EaseInEaseOut(300));

            int x = 0;

            if (Program.oMDI.panel1.Location.X == 0)
                x = (Program.oMDI.panel1.Width + 5);
            else
                x = 8;

            t.add(this, "Left", x);
            t.run();

            EstableceFoco();
        }

        private void EstableceFoco()
        {
            oGraphics = pictureBox1.CreateGraphics();
            oPath.AddRectangle(pictureBox1.Bounds);
        }

        private string crearCarpetaAppdata()
        {
            try
            {
                string directoryString = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData).ToString() + "\\SoftNet G-Clinic\\Citas";

                if (!Directory.Exists(directoryString))
                    Directory.CreateDirectory(directoryString);//Console.WriteLine("Directory \"{0}\" exists", directoryString);

                return directoryString;
            }
            catch
            {
                return "";
            }
        }

        private void recordarDatosEnEquipo(DateTime pFechaEnvio)
        {
            try
            {
                File.Delete(crearCarpetaAppdata() + "\\SentEmails.xml");

                if (crearCarpetaAppdata().Trim() != "")
                {
                    int nodeCount = 0;
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNode xmlRoot, xmlNode;

                    string PathXml = crearCarpetaAppdata() + "\\SentEmails.xml";

                    if (!File.Exists(PathXml.Trim()))
                    {
                        xmlRoot = xmldoc.CreateElement("SentDate");
                        nodeCount = 0;
                    }
                    else
                    {
                        xmldoc.Load(PathXml.Trim());
                        xmlRoot = xmldoc.SelectSingleNode("/SentDate");
                        nodeCount = xmldoc.ChildNodes.Count;
                    }

                    nodeCount++;

                    xmldoc.AppendChild(xmlRoot);
                    xmlNode = xmldoc.CreateElement("Date");// + nodeCount.ToString());
                    xmlRoot.AppendChild(xmlNode);
                    xmlNode.InnerText = Encrypt_Decrypt.Encriptar(pFechaEnvio.ToLongDateString());//Agregamos el nombre del usuario deseado

                    xmldoc.Save(PathXml.Trim());
                }
            }
            catch
            {
                MessageBox.Show(this, "Se produjo un error al crear el archivo temporal que indica el estado de los correos enviados, si el error persiste contacte a la persona que le da soporte a su empresa.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Está seguro que desea enviar las notificaciones por correo electrónico en este momento?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                FrmWaitSendingEmails oFrmWaitSendingEmails = new FrmWaitSendingEmails();
                oFrmWaitSendingEmails.Show();
                oFrmWaitSendingEmails.Update();
                oFrmWaitSendingEmails.Refresh();
                System.Threading.Thread.Sleep(100);

                frmContraseñaCorreo ofrmContraseñaCorreo = new frmContraseñaCorreo(txtPassword);
                ofrmContraseñaCorreo.ShowDialog(this);

                if (txtPassword.Text.Trim() != "")
                {
                    Program.oMostrarRecordatorios.EnviarNotificacionesCorreo(txtPassword.Text.Trim());

                    oFrmWaitSendingEmails.Close();

                    if (Program.oMostrarRecordatorios.CorreosEnviados == true)
                    {
                        recordarDatosEnEquipo(System.DateTime.Today);
                        this.Close();
                    }
                }
                else
                    MessageBox.Show(this, "Debe establecer una contraseña correcta para realizar estas acciones", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contador++;

            if (contador <= 19)
            {
                if (this.Visible == true)
                {
                    this.Visible = false;
                    Program.oMDI.Activate();
                }
                else
                {
                    this.Visible = true;
                    Program.oMDI.Activate();
                }
            }
            else
            {
                timer1.Enabled = false;
                this.Visible = true;
                Program.oMDI.Activate();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = Properties.Resources.send_mails;
            Bitmap oBitmap = new Bitmap(this.BackgroundImage);
            SetBitmap(oBitmap);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.send_mails_highlighted;
            Bitmap oBitmap = new Bitmap(this.BackgroundImage);
            SetBitmap(oBitmap);

            this.Activate();

            toolTip1.Show("Dé click sobre la imagen para enviar en este momento los recordatorios " + Environment.NewLine +
                          "pendientes por correo eletrónico a los pacientes que tengan habilitada " + Environment.NewLine +
                          "dicha función. " + Environment.NewLine + Environment.NewLine +
                          "Este proceso puede tomar unos minutos, por lo que el sistema  ingresará " + Environment.NewLine +
                          "en un estado de hibernación mientras se envían los correos y le notificará " + Environment.NewLine +
                          "una vez que se hayan enviado los mismos y haya finalizado el proceso...", pictureBox1, 176, -111);//this.Right - 15, Program.oMDI.mdiClientController1.MdiClient.Height - Program.oMDI.statusStrip1.Height));            
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.send_mails;
            Bitmap oBitmap = new Bitmap(this.BackgroundImage);
            SetBitmap(oBitmap);

            toolTip1.Hide(this);
            Program.oMDI.Activate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Visible == true)
            {
                this.BackgroundImage = Properties.Resources.send_mails_highlighted;
                Bitmap oBitmap = new Bitmap(this.BackgroundImage);
                SetBitmap(oBitmap);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(25000);
        }

        private void frmEnviarCorreos_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }

        private void enviarCorreosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Realmente desea cerrar esta opción?. Esta opción se visualizará nuevamente solo si inicia sesión de nuevo", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                notifyIcon1.Visible = false;
                this.Visible = false;
            }
        }
    }
}