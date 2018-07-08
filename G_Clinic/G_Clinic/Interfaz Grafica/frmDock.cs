using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using G_Clinic.Miscelaneos_y_Recursos;
using System.Drawing.Drawing2D;
using Transitions;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmDock : Form
    {
        bool activo = false;

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public frmDock()
        {
            InitializeComponent();

            this.Location = new Point(((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2), Screen.PrimaryScreen.WorkingArea.Height + this.Height);
            EstableceFoco();
        }

        #region Variables

        int top = 0;

        bool shownComplete = false;

        public bool ShownComplete
        {
            get { return shownComplete; }
            set { shownComplete = value; }
        }

        Graphics oGraphics;

        GraphicsPath oPathDatosPersonales = new GraphicsPath();
        GraphicsPath oPathDatosFamiliares = new GraphicsPath();
        GraphicsPath oPathDatosExamenFisico = new GraphicsPath();
        GraphicsPath oPathDatosAntecedentesGenerales = new GraphicsPath();
        GraphicsPath oPathDatosAntecedentesObstetricos = new GraphicsPath();
        GraphicsPath oPathDatosResultadosExamenes = new GraphicsPath();
        GraphicsPath oPathVideos = new GraphicsPath();
        GraphicsPath oPathImagenes = new GraphicsPath();
        GraphicsPath oPathConsultasAnteriores = new GraphicsPath();
        GraphicsPath oPathEmbarazos = new GraphicsPath();

        GraphicsPath oPathForm = new GraphicsPath();

        int mouseX = 0;
        int mouseY = 0;

        bool shown = false;

        #endregion

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

        private void frmDock_Load(object sender, EventArgs e)
        {
            activo = true;
            Bitmap oBitmap = new Bitmap(this.BackgroundImage);
            SetBitmap(oBitmap);

            top = Screen.PrimaryScreen.WorkingArea.Height - this.Height - Program.oMDI.statusStrip1.Height - 3;
        }

        #endregion

        #region Establece Eventos

        private void EstableceFoco()
        {
            //-------------------------------------------------------------
            oGraphics = pBoxDatosPersonales.CreateGraphics();
            oPathDatosPersonales.AddRectangle(pBoxDatosPersonales.Bounds);
            //-------------------------------------------------------------            
            oGraphics = pBoxDatosFamiliares.CreateGraphics();
            oPathDatosFamiliares.AddRectangle(pBoxDatosFamiliares.Bounds);
            //-------------------------------------------------------------            
            oGraphics = pBoxExamenFisico.CreateGraphics();
            oPathDatosExamenFisico.AddRectangle(pBoxExamenFisico.Bounds);
            //-------------------------------------------------------------            
            oGraphics = pBoxAntecedentesGenerales.CreateGraphics();
            oPathDatosAntecedentesGenerales.AddRectangle(pBoxAntecedentesGenerales.Bounds);
            //-------------------------------------------------------------            
            oGraphics = pBoxAntecedentesObstetricos.CreateGraphics();
            oPathDatosAntecedentesObstetricos.AddRectangle(pBoxAntecedentesObstetricos.Bounds);
            //-------------------------------------------------------------            
            oGraphics = pBoxResultadosExamenes.CreateGraphics();
            oPathDatosResultadosExamenes.AddRectangle(pBoxResultadosExamenes.Bounds);
            //-------------------------------------------------------------
            oGraphics = pBoxVideos.CreateGraphics();
            oPathVideos.AddRectangle(pBoxVideos.Bounds);
            //-------------------------------------------------------------
            oGraphics = pBoxImages.CreateGraphics();
            oPathImagenes.AddRectangle(pBoxImages.Bounds);
            //-------------------------------------------------------------
            oGraphics = pBoxConsultasAnteriores.CreateGraphics();
            oPathConsultasAnteriores.AddRectangle(pBoxConsultasAnteriores.Bounds);
            //-------------------------------------------------------------
            oGraphics = pBoxEmbarazos.CreateGraphics();
            oPathEmbarazos.AddRectangle(pBoxEmbarazos.Bounds);

            oGraphics = this.CreateGraphics();

            Rectangle oRect = this.Bounds;

            oRect.Height = oRect.Height - 16;
            oRect.Width = oRect.Width - 16;
            oRect.X = 8;
            oRect.Y = 8;

            oPathForm.AddRectangle(this.Bounds);//oRect);
        }

        private void RealizaEvento(int oIdentificador)
        {
            //if (oIdentificador == 0)
            //{
            //    Program.oFrmHistoriaClinica = new frmHistoriaClinica();
            //    Program.oFrmHistoriaClinica.Show();
            //}
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawPath(Pens.Pink, oPathDatosPersonales);
            oPathDatosPersonales.Dispose();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (shownComplete == true)
            {
                try
                {
                    mouseX = e.X;
                    mouseY = e.Y;

                    if (oPathDatosPersonales.IsVisible(mouseX, mouseY))
                    {
                        timer1.Start();
                        this.BackgroundImage = DockResources.Datos_Personales;
                    }
                    else if (oPathDatosFamiliares.IsVisible(mouseX, mouseY))
                    {
                        timer1.Start();
                        this.BackgroundImage = DockResources.Datos_Familiares;
                    }
                    else if (oPathDatosExamenFisico.IsVisible(mouseX, mouseY))
                    {
                        timer1.Start();
                        this.BackgroundImage = DockResources.Observaciones_Generales;
                    }
                    else if (oPathDatosAntecedentesGenerales.IsVisible(mouseX, mouseY))
                    {
                        timer1.Start();
                        this.BackgroundImage = DockResources.Antecedentes_Generales;
                    }
                    else if (oPathDatosAntecedentesObstetricos.IsVisible(mouseX, mouseY))
                    {
                        timer1.Start();
                        this.BackgroundImage = DockResources.Antecedentes_Obstétricos_y_Ginecológicos;
                    }
                    else if (oPathDatosResultadosExamenes.IsVisible(mouseX, mouseY))
                    {
                        timer1.Start();
                        this.BackgroundImage = DockResources.Resultados_de_Exámenes;
                    }
                    else if (oPathVideos.IsVisible(mouseX, mouseY))
                    {
                        timer1.Start();
                        this.BackgroundImage = DockResources.Videos_de_Consultas;
                    }
                    else if (oPathImagenes.IsVisible(mouseX, mouseY))
                    {
                        timer1.Start();
                        this.BackgroundImage = DockResources.Imágenes_de_Consultas;
                    }
                    else if (oPathConsultasAnteriores.IsVisible(mouseX, mouseY))
                    {
                        timer1.Start();
                        this.BackgroundImage = DockResources.Historial_de_Consultas;
                    }
                    else if (oPathEmbarazos.IsVisible(mouseX, mouseY))
                    {
                        timer1.Start();
                        this.BackgroundImage = DockResources.Embarazos;
                    }

                    else
                    {
                        shown = false;
                        this.BackgroundImage = DockResources.Dock_Original;

                        if (Program.oFrmDetallePaciente != null)
                            Program.oFrmDetallePaciente.Hide();

                        if (Program.oFrmExamenesConsulta != null)
                            Program.oFrmExamenesConsulta.Hide();

                        timer1.Stop();
                    }

                    Bitmap oBitmap = new Bitmap(this.BackgroundImage);
                    SetBitmap(oBitmap);
                }
                catch { }
            }

            base.OnMouseMove(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            //if (oPathDatosPersonales.IsVisible(mouseX, mouseY))
            //{
            //    RealizaEvento(0);
            //}
        }

        private void frmDock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            {
                int top = Screen.PrimaryScreen.WorkingArea.Height + this.Height;
                e.Cancel = true;

                Transition t = new Transition(new TransitionType_EaseInEaseOut(500));
                t.add(Program.oFrmDock, "Top", top);
                t.run();
            }

            Program.oMDI.Activate();
        }

        public void frmDock_MouseLeave(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer2.Stop();

                if (oPathDatosPersonales.IsVisible(mouseX, mouseY))
                {
                    if (shown == false)
                    {
                        Program.oFrmDetallePaciente.CambiarOpcion(0);
                        Program.oFrmDetallePaciente.Show(this);                        

                        shown = true;
                        //return;
                    }
                }
                
                //else 
                if (oPathDatosFamiliares.IsVisible(mouseX, mouseY))
                {
                    if (shown == false)
                    {
                        Program.oFrmDetallePaciente.CambiarOpcion(1);
                        Program.oFrmDetallePaciente.Show(this);

                        shown = true;
                        //return;
                    }
                }
                
                //else 
                if (oPathDatosExamenFisico.IsVisible(mouseX, mouseY))
                {
                    if (shown == false)
                    {
                        Program.oFrmDetallePaciente.CambiarOpcion(2);
                        Program.oFrmDetallePaciente.Show(this);

                        shown = true;
                        //return;
                    }
                }
                
                //else 
                if (oPathDatosAntecedentesGenerales.IsVisible(mouseX, mouseY))
                {
                    if (shown == false)
                    {
                        Program.oFrmDetallePaciente.CambiarOpcion(3);
                        Program.oFrmDetallePaciente.Show(this);                     

                        shown = true;
                        //return;
                    }
                }
                
                //else                
                if (oPathDatosAntecedentesObstetricos.IsVisible(mouseX, mouseY))
                {
                    if (shown == false)
                    {
                        Program.oFrmDetallePaciente.CambiarOpcion(4);
                        Program.oFrmDetallePaciente.Show(this);                        

                        shown = true;
                        //return;
                    }
                }
                
                if (shown == false)
                    Program.oFrmDetallePaciente.Hide();
                
                if (oPathImagenes.IsVisible(mouseX, mouseY))
                {
                    if (shown == false)
                    {
                        Program.oFrmImagenesConsultas.Show(this);
                        shown = true;
                        //return;
                    }
                }
                else
                {
                    shown = false;
                    Program.oFrmImagenesConsultas.Hide();
                }

                if (oPathVideos.IsVisible(mouseX, mouseY))
                {
                    if (shown == false)
                    {
                        Program.oFrmVideosConsulta.Show(this);
                        shown = true;
                        //return;
                    }
                }
                else
                {
                    shown = false;
                    Program.oFrmVideosConsulta.Hide();
                }

                if (oPathEmbarazos.IsVisible(mouseX, mouseY))
                {
                    if (shown == false)
                    {
                        Program.oFrmEmbarazos.Show(this);
                        shown = true;
                        //return;
                    }
                }
                else
                {
                    shown = false;
                    Program.oFrmEmbarazos.Hide();
                }

                if (oPathDatosResultadosExamenes.IsVisible(mouseX, mouseY))
                {
                    if (shown == false)
                    {
                        Program.oFrmExamenesConsulta.Show(this);
                        shown = true;
                        //return;
                    }
                }
                else
                {
                    shown = false;
                    Program.oFrmExamenesConsulta.Hide();
                }

                if (oPathConsultasAnteriores.IsVisible(mouseX, mouseY))
                {
                    if (shown == false)
                    {
                        if (Program.oFrmHistorialConsultas != null)
                        {
                            Program.oFrmHistorialConsultas.Show(this);
                            shown = true;
                            //return;
                        }
                    }
                }
                else
                {
                    shown = false;

                    if (Program.oFrmHistorialConsultas != null)
                        Program.oFrmHistorialConsultas.Hide();
                }

            }
            catch { }

            timer1.Stop();
        }

        private void frmDock_LocationChanged(object sender, EventArgs e)
        {
            if (Program.oFrmDock != null)
            {
                if (this.Top == top)
                    Program.oFrmDock.ShownComplete = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                this.BackgroundImage = DockResources.Dock_Original;
                Bitmap oBitmap = new Bitmap(this.BackgroundImage);
                SetBitmap(oBitmap);

                int top = Screen.PrimaryScreen.WorkingArea.Height + this.Height;

                Transition t = new Transition(new TransitionType_EaseInEaseOut(500));
                t.add(Program.oFrmDock, "Top", top);
                t.run();

                shownComplete = false;

                if (Program.oFrmDetallePaciente.Activo == true)
                    Program.oFrmDetallePaciente.Hide();
                else if (Program.oFrmExamenesConsulta.Activo == true)
                    Program.oFrmExamenesConsulta.Hide();
                else if (Program.oFrmHistorialConsultas.Activo == true)
                    Program.oFrmHistorialConsultas.Hide();
                else if (Program.oFrmImagenesConsultas.Activo == true)
                    Program.oFrmImagenesConsultas.Hide();
                else if (Program.oFrmVideosConsulta.Activo == true)
                    Program.oFrmVideosConsulta.Hide();

                Program.oMDI.Activate();
            }
            catch { }

            timer2.Stop();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }
    }
}