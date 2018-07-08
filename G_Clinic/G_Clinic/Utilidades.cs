using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using G_Clinic.Miscelaneos_y_Recursos;
using System.IO;
using System.Xml;

namespace G_Clinic
{
    public static class Utilidades
    {
        public static string FormatoLegibleDeFuente(Font font)
        {
            return font.Style == FontStyle.Regular ? font.FontFamily.Name + "; " + font.Size.ToString() + "pt" : font.FontFamily.Name + "; " + font.Size.ToString() + "pt; style=" + font.Style.ToString();
        }

        private static void EstableceFuenteSegunControl(Control.ControlCollection controls, Font font, FormType formType)
        {
            foreach (Control control in controls)
            {
                try
                {
                    if (control.HasChildren)
                    {
                        EstableceFuenteSegunControl(control.Controls, font, formType);
                    }
                    else
                    {
                        switch (formType)
                        {
                            case FormType.Mantenimiento:
                                if (control.GetType() == typeof(TextBox))
                                {
                                    control.Font = font;
                                }
                                break;
                            case FormType.DetalleDeConsulta:
                                if (control.GetType() == typeof(ExtendedRichTextBox.RichTextBoxPrintCtrl))
                                {
                                    control.Font = font;
                                }
                                break;
                            case FormType.ExamenesYGabinete:
                                if (control.GetType() == typeof(ListView))
                                {
                                    control.Font = font;
                                }
                                break;
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        private static void EstableceFuenteSegunFormulario(Form form, Font font, FormType formType)
        {
            foreach (Control control in form.Controls)
            {
                try
                {
                    if (control.HasChildren)
                    {
                        EstableceFuenteSegunControl(control.Controls, font, formType);
                    }
                    else
                    {
                        switch (formType)
                        {
                            case FormType.Mantenimiento:
                                if (control.GetType() == typeof(TextBox))
                                {
                                    control.Font = font;
                                }
                                break;
                            case FormType.DetalleDeConsulta:
                                if (control.GetType() == typeof(ExtendedRichTextBox.RichTextBoxPrintCtrl))
                                {
                                    control.Font = font;
                                }
                                break;
                            case FormType.ExamenesYGabinete:
                                if (control.GetType() == typeof(ListView))
                                {
                                    control.Font = font;
                                }
                                break;
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        public static void EstablecerFuentesEnFormulario(Form form, FormType formType)
        {
            switch (formType)
            {
                case FormType.Mantenimiento:
                    EstableceFuenteSegunFormulario(form, ApplicationSettings.FuenteMantenimientos, formType);
                    break;
                case FormType.DetalleDeConsulta:
                    EstableceFuenteSegunFormulario(form, ApplicationSettings.FuenteDeDetalleConsultas, formType);
                    break;
                case FormType.ExamenesYGabinete:
                    EstableceFuenteSegunFormulario(form, ApplicationSettings.FuenteDeResultadoExamenesYGabinete, formType);
                    break;
                default:
                    break;
            }
        }

        public static string LeerContraseñaAplicacionEmail()
        {
            string contraseñaAplicacion = String.Empty;
            try
            {
                string pathXML = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\UserInfo");

                string fileName = "\\MailSettings.xml";
                pathXML += fileName;

                if (File.Exists(pathXML.Trim()))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNodeList m_nodelist = null;

                    xmldoc.Load(pathXML.Trim());

                    m_nodelist = xmldoc.SelectNodes("/SoftNetMail_Settings/ApplicationPwd");
                    contraseñaAplicacion = Encrypt_Decrypt.Desencriptar(m_nodelist[0].ChildNodes.Item(0).Value.ToString());
                }
            }
            catch (Exception ex)
            {

            }

            return contraseñaAplicacion;
        }
    }
}