using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using System.Net;
using G_Clinic.Miscelaneos_y_Recursos;
using System.Windows.Forms;
using System.Xml;
using System.IO;
//using RC.Gmail;

namespace G_Clinic.Lógica_Negocios
{
    class CEmail
    {
        CEmpresa oCEmpresa = new CEmpresa();

        #region Lógica

        public bool RecibeNotificaciones(string pNumExpediente)
        {
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select * from Pacientes_Notificar_Correo where num_expediente = " + pNumExpediente.Trim(), "Pacientes_Notificar_Correo");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Dispose();
                    return true;
                }
                else
                {
                    ds.Dispose();
                    return false;
                }
            }
            else
                return false;
        }

        public string CorreosPaciente(string pNumExpediente)
        {
            string emailAddress = "";
            string sql = "Select b.descripcion from Pacientes_Notificar_Correo a, Contactos_Paciente b, Tipo_Contactos c " +
                         "where a.num_expediente = b.num_expediente and b.id_tipo_contacto = c.id_tipo_contacto " +
                         "and c.descripcion = 'Email' and a.num_expediente = " + pNumExpediente.Trim();

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(sql.Trim(), "Pacientes_Notificar_Correo");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)                    
                        emailAddress += dr[0].ToString().Trim() + ";";                    
                }
                ds.Dispose();                    
            }

            if (emailAddress.EndsWith(";"))
                emailAddress = emailAddress.Substring(0, emailAddress.Trim().Length - 1);

            return emailAddress;
        }

        public Dictionary<string, string> ListaPacientesEmail()
        {
            string sqlConsulta = "";
            Dictionary<string, string> oArregloPacientes = new Dictionary<string, string>();

            sqlConsulta = "Select b.descripcion, a.nombre + ' ' + a.apellidos as Nombre from Paciente a, Contactos_Paciente b, Tipo_Contactos c " +
                          "where a.num_expediente = b.num_expediente and b.id_tipo_contacto = c.id_tipo_contacto and c.descripcion = 'Email' and b.descripcion is not null " + 
                          "and b.descripcion <> ''";

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(sqlConsulta.Trim(), "Paciente a, Contactos_Paciente b, Tipo_Contactos c");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (!String.IsNullOrEmpty(dr[0].ToString().Trim()) && !String.IsNullOrEmpty(dr[1].ToString().Trim()))
                        {
                            if (!oArregloPacientes.ContainsKey(dr[0].ToString().Trim()))
                                oArregloPacientes.Add(dr[0].ToString().Trim(), dr[1].ToString().Trim());
                        }
                    }
                }
                ds.Dispose();
            }

            return oArregloPacientes;
        }

        public void GeneraMailNotificacion(string pDe, string pDeContraseña, string pPara, string pAsunto, string pDetalle)
        {
            try
            {
                if (pDeContraseña.Trim() != "" && pDe.Trim() != "")
                {
                    //RC.Gmail.GmailMessage gmailMsg = new RC.Gmail.GmailMessage(pDe.Trim() + "<" + oCEmpresa.NombreEmpresa.Trim() + ">", pDeContraseña.Trim());
                    //gmailMsg.To = pPara.Trim();
                    //gmailMsg.From = pDe.Trim() + "<" + oCEmpresa.NombreEmpresa.Trim()+ ">";
                    //gmailMsg.Subject = pAsunto.Trim();
                    //gmailMsg.Body = pDetalle.Trim();
                    //gmailMsg.Priority = System.Web.Mail.MailPriority.High;

                    //gmailMsg.Send();



                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.gmail.com";//"smtp.mail.yahoo.com"; //"smtp.live.com"; //smtp.gmail.com
                    client.Port = Convert.ToInt32(Program.oSMTPPort);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new NetworkCredential(pDe.Trim(), pDeContraseña.Trim());//"administrador@softnet.com", "manujr123macr3267");//"info@boutiquebaruk.com", "Ligia2347262");
                    client.EnableSsl = Program.oEnableSSL;

                    MailMessage message = new MailMessage();//carmonar83@gmail.com
                    message.Sender = new MailAddress(pDe.Trim(), oCEmpresa.NombreEmpresa.Trim());

                    message.From = new MailAddress(pDe.Trim(), oCEmpresa.NombreEmpresa.Trim());

                    char[] oChar = { ';', ' ' };
                    string[] oCadenaTemp = Metodos_Globales.MetodoSplit(pPara.Trim(), oChar);

                    for (int i = 0; i < oCadenaTemp.Length; )
                    {
                        message.To.Add(oCadenaTemp[i].Trim());
                        i++;
                    }

                    message.Subject = pAsunto.Trim();
                    message.Body = pDetalle.Trim();
                    message.IsBodyHtml = false;
                    message.Priority = MailPriority.High;

                    client.Send(message);
                }
                else
                    MessageBox.Show("El mensaje no podrá ser enviado hasta que se proporcione la contraseña del correo electrónico indicado en la sección \"De:\" de esta pantalla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.Trim());
            }
        }

        public bool VerificaCorreosEnviados()
        {
            DateTime oFecha = new DateTime();
            string PathXml = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\Citas") + "\\SentEmails.xml";

            if (File.Exists(PathXml.Trim()))
            {
                XmlDocument xmldoc = new XmlDocument();
                XmlNodeList m_nodelist = null;

                xmldoc.Load(PathXml.Trim());

                m_nodelist = xmldoc.SelectNodes("/SentDate/Date");

                foreach (XmlNode Nodo in m_nodelist)
                    oFecha = Convert.ToDateTime(Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes.Item(0).Value.ToString()));
                
                if (oFecha.Date == System.DateTime.Today.Date)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        #endregion

        public void LeeConfiguracionEmail()
        {
            string pathXML = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\UserInfo");

            string fileName = "\\MailSettings.xml";
            pathXML += fileName;
            
            try
            {
                if (File.Exists(pathXML.Trim()))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNodeList m_nodelist = null;

                    xmldoc.Load(pathXML.Trim());

                    m_nodelist = xmldoc.SelectNodes("/SoftNetMail_Settings/Port");                    
                    Program.oSMTPPort = Encrypt_Decrypt.Desencriptar(m_nodelist[0].ChildNodes.Item(0).Value.ToString());

                    m_nodelist = xmldoc.SelectNodes("/SoftNetMail_Settings/EnableSSL");
                    Program.oEnableSSL = Convert.ToBoolean(Encrypt_Decrypt.Desencriptar(m_nodelist[0].ChildNodes.Item(0).Value.ToString()));
                }
                else
                {
                    Program.oSMTPPort = "587";
                    Program.oEnableSSL = false;
                }
            }
            catch { }
        }
    }
}