using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using G_Clinic.Lógica_Negocios;
using G_Clinic.Miscelaneos_y_Recursos;
using System.Collections;
using System.Net.Mail;
using System.Net;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmEmail : Form
    {
        public frmEmail()
        {
            InitializeComponent();

            try
            {
                VistaConstants.SetWindowTheme(lstContactos.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstContactos.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);

                VistaConstants.SetWindowTheme(lstAttachments.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstAttachments.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
            }
            catch { }

            SetStyles();

            this.Region = Shape.RoundedRegion(this.Size, 10, Shape.Corner.None);
        }

        CEmail oCEmail = new CEmail();

        Dictionary<string, string> oArreglo = new Dictionary<string, string>();
        ArrayList oArregladoSeleccionados = new ArrayList();

        bool addingItems = false;
        //#region Métodos propios de diseño de interfaz

        private void SetStyles()
        {
            //Makes sure the form repaints when it was resized
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        //protected override void OnPaintBackground(PaintEventArgs pevent)
        //{
        //    try
        //    {
        //        // Getting the graphics object
        //        Graphics g = pevent.Graphics;

        //        // Creating the rectangle for the gradient
        //        System.Drawing.Rectangle rBackground = new System.Drawing.Rectangle(0, 0, this.Width, (this.Height) / 2);

        //        // Creating the lineargradient
        //        // Creating the lineargradient
        //        System.Drawing.Drawing2D.LinearGradientBrush bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground, Color.LightSteelBlue, System.Drawing.Color.White, 91);
        //        // Draw the gradient onto the form
        //        g.FillRectangle(bBackground, rBackground);

        //        // Disposing of the resources held by the brush
        //        bBackground.Dispose();

        //        // Getting the graphics object
        //        Graphics g3 = pevent.Graphics;

        //        // Creating the rectangle for the gradient
        //        System.Drawing.Rectangle rBackground3 = new System.Drawing.Rectangle(0, (this.Height) / 2, this.Width, (this.Height) / 2);

        //        // Creating the lineargradient
        //        System.Drawing.Drawing2D.LinearGradientBrush bBackground3 = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground3, System.Drawing.Color.White, Color.LightSteelBlue, 91);

        //        // Draw the gradient onto the form
        //        g.FillRectangle(bBackground3, rBackground3);

        //        // Disposing of the resources held by the brush
        //        bBackground3.Dispose();
        //    }
        //    catch { }
        //}

        ///// <summary>
        ///// Sobreescribimos el método CreateParams para minimizar el parpadeo del form
        ///// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

        //#endregion

        private void LlenaListaCorreos()
        {
            try
            {

            toolStripStatusLabel2.Text = "Cargando lista de pacientes...";
            lstContactos.Items.Clear();

            addingItems = true;
            int index = 0;
            foreach (KeyValuePair<string, string> oCadena in oArreglo)
            {
                Application.DoEvents();

                lstContactos.Items.Add("");
                lstContactos.Items[index].SubItems.Add(oCadena.Key.Trim());
                lstContactos.Items[index].SubItems.Add(oCadena.Value.Trim());
                lstContactos.Items[index].Tag = index.ToString();

                index++;
            }
            addingItems = false;
            toolStripStatusLabel2.Text = "";
            }
            catch (Exception)
            {             
            }
        }

        private void BloquearCampos()
        {
            txtPara.Enabled = false;
            txtAsunto.Enabled = false;
            lstAttachments.Enabled = false;
            editor1.Enabled = false;
            txtBuscarPaciente.Enabled = false;
            txtPassword.Enabled = false;
            lstContactos.Enabled = false;

            tobSendMail.Enabled = false;

            toolStripStatusLabel1.Text = "";

            tobCancelar.Enabled = false;
        }

        private void DesbloquearCampos()
        {
            txtPara.Enabled = true;
            txtAsunto.Enabled = true;
            lstAttachments.Enabled = true;
            editor1.Enabled = true;
            txtBuscarPaciente.Enabled = true;
            txtPassword.Enabled = true;
            lstContactos.Enabled = true;
            tobSendMail.Enabled = true;

            tobCancelar.Enabled = true;
        }

        private void LimpiarCampos()
        {
            txtPara.Text = "";
            txtAsunto.Text = "";
            lstAttachments.Items.Clear();
            editor1.BodyText = "";
            
            txtPassword.Text = "";

            if (txtBuscarPaciente.Text.Trim() != "Ingrese el nombre de la persona deseada...")
                txtBuscarPaciente.Text = "Ingrese el nombre de la persona deseada...";
        }

        private void CreaArchivoTempCorreoEmpresa()
        {
            try
            {
                string PathXml = crearCarpetaAppdata() + "\\UserMailInfo.xml";

                if (!File.Exists(PathXml.Trim()))
                {
                    if (crearCarpetaAppdata().Trim() != "")
                    {
                        int nodeCount = 0;
                        XmlDocument xmldoc = new XmlDocument();
                        XmlNode xmlRoot, xmlNode;

                        if (!File.Exists(PathXml.Trim()))
                        {
                            xmlRoot = xmldoc.CreateElement("Logins");
                            nodeCount = 0;
                        }
                        else
                        {
                            xmldoc.Load(PathXml.Trim());
                            xmlRoot = xmldoc.SelectSingleNode("/Logins");
                            nodeCount = xmldoc.ChildNodes.Count;
                        }

                        nodeCount++;

                        xmldoc.AppendChild(xmlRoot);
                        xmlNode = xmldoc.CreateElement("User");// + nodeCount.ToString());
                        xmlRoot.AppendChild(xmlNode);
                        xmlNode.InnerText = Encrypt_Decrypt.Encriptar(Program.oCEmpresa.Email.Trim());//Agregamos el correo de la empresa

                        xmldoc.Save(PathXml.Trim());
                    }
                }
            }
            catch
            {
                MessageBox.Show(this, "Se produjo un error al crear el archivo que contiene la información de los usuarios que desea almacenar en este equipo, por favor intente de nuevo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmEmail_Load(object sender, EventArgs e)
        {
            BloquearCampos();
            oArreglo = oCEmail.ListaPacientesEmail();
            LlenaListaCorreos();

            if (Program.oCEmpresa.Email.Trim() != "")
                CreaArchivoTempCorreoEmpresa();
            else
                MessageBox.Show(this, "Recuerde que debe ingresar el correo electrónico de la empresa para que esta función sea más eficiente. Recuerde que debe de ser del dominio de GMail", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            LlenarComboLogins();

            if (cmbEmisor.Items.Count > 0)
                cmbEmisor.SelectedIndex = 0;
         }

        private void tobSendMail_Click(object sender, EventArgs e)
        {
            FrmWaitSendingEmails oFrmWaitSendingEmails = new FrmWaitSendingEmails();

            try
            {
                if (editor1.BodyHtml != null)
                {
                    string contraseñaAplicacion = Utilidades.LeerContraseñaAplicacionEmail();

                    if (String.IsNullOrEmpty(contraseñaAplicacion))
                    {
                        frmContraseñaCorreo ofrmContraseñaCorreo = new frmContraseñaCorreo(txtPassword);
                        ofrmContraseñaCorreo.ShowDialog(this);
                    }
                    else
                        txtPassword.Text = contraseñaAplicacion;

                    if (txtPassword.Text.Trim() != "" && cmbEmisor.Text.Trim() != "")
                    {
                        oFrmWaitSendingEmails.Show();
                        oFrmWaitSendingEmails.Update();
                        oFrmWaitSendingEmails.Refresh();
                        System.Threading.Thread.Sleep(100);

                        SmtpClient client = new SmtpClient();                        
                        client.Host = "smtp.gmail.com";//"smtp.mail.yahoo.com"; //"smtp.live.com"; //smtp.gmail.com
                        client.Port = Convert.ToInt32(Program.oSMTPPort);
                        client.EnableSsl = Program.oEnableSSL;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(cmbEmisor.Text.Trim(), txtPassword.Text.Trim());//"administrador@softnet.com", "manujr123macr3267");//"info@boutiquebaruk.com", "Ligia2347262");

                        MailMessage message = new MailMessage();//carmonar83@gmail.com
                        message.Sender = new MailAddress(cmbEmisor.Text.Trim(), Program.oCEmpresa.NombreEmpresa.Trim());

                        message.From = new MailAddress(cmbEmisor.Text.Trim(), Program.oCEmpresa.NombreEmpresa.Trim());

                        char[] oChar = { ';', ' ' };
                        string[] oCadenaTemp = Metodos_Globales.MetodoSplit(txtPara.Text.Trim(), oChar);

                        for (int i = 0; i < oCadenaTemp.Length; )
                        {
                            message.To.Add(oCadenaTemp[i].Trim());
                            i++;
                        }

                        message.Subject = txtAsunto.Text.Trim();
                        message.Body = editor1.BodyHtml;
                        message.IsBodyHtml = true;
                        //message.Priority = MailPriority.High;

                        foreach (ListViewItem oItem in lstAttachments.Items)
                        {
                            if (oItem.Checked == true)
                            {
                                Attachment at = new Attachment(oItem.Text.Trim());
                                message.Attachments.Add(at);
                            }
                        }

                        client.Send(message);

                        MessageBox.Show("El mensaje fue enviado correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        oFrmWaitSendingEmails.Close();

                        BloquearCampos();
                        LimpiarCampos();
                        tobNewMail.Enabled = true;
                    }
                    else
                        MessageBox.Show(this, "El mensaje no podrá ser enviado hasta que se proporcione la contraseña del correo electrónico indicado en la sección \"De:\" de esta pantalla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                    MessageBox.Show(this, "El cuerpo del mensaje no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception exc)
            {
                oFrmWaitSendingEmails.Close();
                MessageBox.Show(exc.Message.Trim());
            }
            finally
            {
                oFrmWaitSendingEmails.Dispose();
            }
        }

        private void lstContactos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addingItems == false)
            {
                try
                {
                    if (lstContactos.SelectedItems.Count > 0)
                    {
                        if (lstContactos.SelectedItems[0].Checked == false)
                            lstContactos.SelectedItems[0].Checked = true;
                        else
                            lstContactos.SelectedItems[0].Checked = false;
                    }
                }
                catch { }
            }
        }

        private void lstContactos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                if (addingItems == false)
                {
                    if (e.Item.Checked == true)
                    {
                        if (!txtPara.Text.Contains(e.Item.SubItems[1].Text.Trim()))
                        {
                            txtPara.Text += "; " + e.Item.SubItems[1].Text.Trim();
                            oArregladoSeleccionados.Add(e.Item.Tag.ToString());
                        }
                    }
                    else
                    {
                        int index = 0;

                        index = txtPara.Text.Trim().IndexOf("; " + e.Item.SubItems[1].Text.Trim());

                        if (index != -1)
                            txtPara.Text = txtPara.Text.Trim().Remove(index, e.Item.SubItems[1].Text.Trim().Length + 2);
                        else
                        {
                            index = txtPara.Text.Trim().IndexOf(e.Item.SubItems[1].Text.Trim());

                            if (index != -1)
                            {
                                if (txtPara.Text.Trim() == e.Item.SubItems[1].Text.Trim())
                                    txtPara.Text = txtPara.Text.Trim().Remove(index, e.Item.SubItems[1].Text.Trim().Length);
                                else
                                    txtPara.Text = txtPara.Text.Trim().Remove(index, e.Item.SubItems[1].Text.Trim().Length + 2);
                            }
                        }
                        int index2 = oArregladoSeleccionados.IndexOf(e.Item.Tag.ToString().Trim());
                        oArregladoSeleccionados.RemoveAt(index2);
                    }

                    if (txtPara.Text.Trim() == "")
                        txtPara.Text = String.Empty;

                    if (txtPara.Text.StartsWith("; ") || txtPara.Text.Trim().StartsWith(" "))
                        txtPara.Text = txtPara.Text.Trim().Substring(1, txtPara.Text.Trim().Length - 1);
                }
            }
            catch { }
        }

        private void tobAdjuntar_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);

            foreach (string oAttachment in openFileDialog1.FileNames)
                lstAttachments.Items.Add(oAttachment.Trim());

            foreach (ListViewItem oItem in lstAttachments.Items)
            {
                if (oItem.Checked == false)
                    oItem.Checked = true;
            }

            lstAttachments.Columns[0].Width = lstAttachments.Width - SystemInformation.VerticalScrollBarWidth - 5;
        }

        private string crearCarpetaAppdata()
        {
            try
            {
                string directoryString = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData).ToString() + "\\SoftNet G-Clinic\\UserInfo";

                if (!Directory.Exists(directoryString))
                    Directory.CreateDirectory(directoryString);//Console.WriteLine("Directory \"{0}\" exists", directoryString);

                return directoryString;
            }
            catch
            {
                return "";
            }
        }

        private void LlenarComboLogins()
        {
            try
            {
                cmbEmisor.Items.Clear();

                string PathXml = crearCarpetaAppdata() + "\\UserMailInfo.xml";

                if (File.Exists(PathXml.Trim()))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNodeList m_nodelist = null;

                    xmldoc.Load(PathXml.Trim());

                    m_nodelist = xmldoc.SelectNodes("/Logins/User");

                    foreach (XmlNode Nodo in m_nodelist)
                    {
                        cmbEmisor.Items.Add(Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes.Item(0).Value.ToString()));
                    }
                }
            }
            catch { }
        }

        private void recordarDatosEnEquipo()
        {
            try
            {
                if (crearCarpetaAppdata().Trim() != "")
                {
                    if (cmbEmisor.Text.Trim() != "")
                    {
                        int nodeCount = 0;
                        XmlDocument xmldoc = new XmlDocument();
                        XmlNode xmlRoot, xmlNode;

                        string PathXml = crearCarpetaAppdata() + "\\UserMailInfo.xml";

                        if (!File.Exists(PathXml.Trim()))
                        {
                            xmlRoot = xmldoc.CreateElement("Logins");
                            nodeCount = 0;
                        }
                        else
                        {
                            xmldoc.Load(PathXml.Trim());
                            xmlRoot = xmldoc.SelectSingleNode("/Logins");
                            nodeCount = xmldoc.ChildNodes.Count;
                        }

                        nodeCount++;

                        xmldoc.AppendChild(xmlRoot);
                        xmlNode = xmldoc.CreateElement("User");// + nodeCount.ToString());
                        xmlRoot.AppendChild(xmlNode);
                        xmlNode.InnerText = Encrypt_Decrypt.Encriptar(cmbEmisor.Text.Trim());//Agregamos el nombre del usuario deseado

                        xmldoc.Save(PathXml.Trim());

                        LlenarComboLogins();
                    }
                }
            }
            catch
            {
                MessageBox.Show(this, "Se produjo un error al crear el archivo que contiene la información de los usuarios que desea almacenar en este equipo, por favor intente de nuevo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tobGuardarEmisor_Click(object sender, EventArgs e)
        {
            recordarDatosEnEquipo();
        }

        private void dejarRecordarDatosEnEquipo()
        {
            try
            {
                string PathXml = crearCarpetaAppdata() + "\\UserMailInfo.xml";

                if (File.Exists(PathXml.Trim()))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNodeList m_nodelist = null;

                    xmldoc.Load(PathXml.Trim());

                    m_nodelist = xmldoc.SelectNodes("/Logins/User");

                    int cont = 0;
                    foreach (XmlNode Nodo in m_nodelist)
                    {
                        if (Nodo.ChildNodes.Item(0).Value.ToString().Trim() == Encrypt_Decrypt.Encriptar(cmbEmisor.Text.Trim()))
                        {
                            XmlNode parentNode = xmldoc.DocumentElement;
                            XmlNode toDelete = parentNode.ChildNodes.Item(cont);
                            parentNode.RemoveChild(toDelete);
                            xmldoc.Save(PathXml);

                            LlenarComboLogins();
                            break;
                        }
                        cont++;
                    }
                }
            }
            catch { }
        }

        private void tobEliminarEmisor_Click(object sender, EventArgs e)
        {
            if (cmbEmisor.Text.Trim() != "")
                dejarRecordarDatosEnEquipo();
        }

        private void SeleccionaItems()
        {
            if (oArregladoSeleccionados.Count > 0)
            {
                foreach (ListViewItem oItem in lstContactos.Items)
                {
                    if (oArregladoSeleccionados.Contains(oItem.Tag.ToString().Trim()))
                        oItem.Checked = true;
                }
            }
        }

        private void txtBuscarPaciente_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarPaciente.Text.Trim() != "Ingrese el nombre de la persona deseada...")
            {
                if (txtBuscarPaciente.Text.Trim() != "")
                {
                    foreach (ListViewItem oItem in lstContactos.Items)
                    {
                        try
                        {
                            if (oItem.SubItems[2] != null)
                            {
                                if (!oItem.SubItems[2].Text.Trim().ToLower().Contains(txtBuscarPaciente.Text.Trim().ToLower()))
                                    oItem.Remove();
                            }
                        }
                        catch (Exception ex)
                        {

                            //throw;
                        }
                    }
                }
                else
                {
                    LlenaListaCorreos();
                    SeleccionaItems();
                }
            }
        }

        private void tobBuscarPaciente_Click(object sender, EventArgs e)
        {
            if (txtPara.Enabled == true)
            {
                txtBuscarPaciente.Enabled = true;
                txtBuscarPaciente.Visible = true;

                toolStripButton1.Visible = true;
                lstContactos.Size = new Size(326, 445);
                lstContactos.Location = new Point(9, 72);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            txtBuscarPaciente.Text = "Ingrese el nombre de la persona deseada...";
            toolStripButton1.Visible = false;
            lstContactos.Size = new Size(326, 473);
            lstContactos.Location = new Point(9, 43);
        }

        private void txtBuscarPaciente_Click(object sender, EventArgs e)
        {
            txtBuscarPaciente.SelectAll();
            toolStripStatusLabel1.Text = "Ingrese el nombre del paciente que desea buscar para enviar el correo";
        }

        private void rdSeleccionarVarios_CheckedChanged(object sender, EventArgs e)
        {
            lstContactos.Enabled = true;
            LlenaListaCorreos();
            oArregladoSeleccionados.Clear();
        }

        private void rdSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (lstContactos.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lstContactos.Items)
                    oItem.Checked = true;

                lstContactos.Enabled = false;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void imagenCambiantePictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Realmente desea salir de SoftNet Mail?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Close();
                Program.oMDI.Activate();
            }
        }

        private void btnGmail_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.gmail.com");
        }

        private void tobNewMail_Click(object sender, EventArgs e)
        {
            tobNewMail.Enabled = false;
            DesbloquearCampos();
            LimpiarCampos();

            LlenaListaCorreos();
        }

        private void txtPara_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione los correos deseados de la lista disponible en pantalla o ingrese la dirección deseada";
        }

        private void cmbEmisor_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese o seleccione el emisor del correo electrónico (debe pertenecer a GMail)";
        }

        private void txtAsunto_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese el asunto o motivo del correo electrónico por enviar";
        }

        private void editor1_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese el cuerpo del mensaje con el detalle y formato deseado";
        }

        private void tobCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Realmente desea cancelar el correo en progreso?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                BloquearCampos();
                LimpiarCampos();
                tobNewMail.Enabled = true;
            }
        }
    }
}