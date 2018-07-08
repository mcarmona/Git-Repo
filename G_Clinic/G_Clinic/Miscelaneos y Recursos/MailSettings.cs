using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using G_Clinic.Lógica_Negocios;

namespace G_Clinic.Miscelaneos_y_Recursos
{    
    public partial class MailSettings : UserControl
    {
        bool pHideParent = true;
        public bool HideParent
        {
            set { pHideParent = value; }
            get { return pHideParent; }
        }

        public MailSettings()
        {
            InitializeComponent();
        }

        string pathXML = "";

        private void SaveMailSettings()
        {
            int nodeCount = 0;
            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlRoot, xmlNode;

            if (!File.Exists(pathXML.Trim()))
            {
                xmlRoot = xmldoc.CreateElement("SoftNetMail_Settings");
                nodeCount = 0;
            }
            else
            {
                xmldoc.Load(pathXML.Trim());
                xmlRoot = xmldoc.SelectSingleNode("/SoftNetMail_Settings");
                nodeCount = xmldoc.ChildNodes.Count;
            }

            nodeCount++;

            xmldoc.AppendChild(xmlRoot);
            xmlNode = xmldoc.CreateElement("Port");
            xmlRoot.AppendChild(xmlNode);
            xmlNode.InnerText = Encrypt_Decrypt.Encriptar(TxtPuerto.Text.Trim());

            xmldoc.AppendChild(xmlRoot);
            xmlNode = xmldoc.CreateElement("EnableSSL");
            xmlRoot.AppendChild(xmlNode);

            if (cmbSSL.SelectedIndex == 0)
                xmlNode.InnerText = Encrypt_Decrypt.Encriptar("True");
            else
                xmlNode.InnerText = Encrypt_Decrypt.Encriptar("False");

            xmldoc.AppendChild(xmlRoot);
            xmlNode = xmldoc.CreateElement("ApplicationPwd");
            xmlRoot.AppendChild(xmlNode);
            xmlNode.InnerText = Encrypt_Decrypt.Encriptar(txtContraseñaAplicacion.Text.Trim());

            xmldoc.Save(pathXML.Trim());

            CEmail oCEmail = new CEmail();
            oCEmail.LeeConfiguracionEmail();
        }

        public void HideParentForm()
        {
            if (HideParent == true && this.Parent != null)
                this.Parent.Hide();
            else
                this.Hide();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            pathXML = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\UserInfo");            
            
            try
            {
                string fileName = "\\MailSettings.xml";
                pathXML += fileName;

                File.Delete(pathXML);

                SaveMailSettings();

                HideParentForm();
            }
            catch
            {
                MessageBox.Show(this, "No se puede crear el archivo, por favor vuelva a intentar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        public void ReadSettings()
        {
            try
            {
                cmbSSL.SelectedIndex = 0;

                pathXML = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\UserInfo");

                string fileName = "\\MailSettings.xml";
                pathXML += fileName;

                if (File.Exists(pathXML.Trim()))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNodeList m_nodelist = null;

                    xmldoc.Load(pathXML.Trim());

                    m_nodelist = xmldoc.SelectNodes("/SoftNetMail_Settings/Port");
                    TxtPuerto.Text = Encrypt_Decrypt.Desencriptar(m_nodelist[0].ChildNodes.Item(0).Value.ToString());

                    m_nodelist = xmldoc.SelectNodes("/SoftNetMail_Settings/EnableSSL");
                    cmbSSL.SelectedIndex = cmbSSL.FindStringExact(Encrypt_Decrypt.Desencriptar(m_nodelist[0].ChildNodes.Item(0).Value.ToString()));

                    m_nodelist = xmldoc.SelectNodes("/SoftNetMail_Settings/ApplicationPwd");
                    txtContraseñaAplicacion.Text = Encrypt_Decrypt.Desencriptar(m_nodelist[0].ChildNodes.Item(0).Value.ToString());
                }
                else
                {
                    TxtPuerto.Text = "587";
                    cmbSSL.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private void MailSettings_Load(object sender, EventArgs e)
        {
            ReadSettings();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
