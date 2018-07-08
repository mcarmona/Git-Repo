using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using G_Clinic.Miscelaneos_y_Recursos;
using G_Clinic.Properties;
using G_Clinic.Interfaz_Grafica;

namespace G_Clinic
{
    public partial class FrmLogin : Form
    {
        public static int cont_intentos = 0;
        public static int Bandera;//Variable creada para que no de error a la hora de validar el usuario cuando se da click al Boton Salir
        public static string Id_Usuario = "";

        SqlConnection SqlCN = null;

        int Contador;

        public int Bandera1
        {
            get { return Bandera; }
            set { Bandera = value; }
        }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private Boolean activo;

        bool Cerrado = true;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void LlenarComboLogins()
        {
            try
            {
                TxtUsuario.Items.Clear();

                string PathXml = crearCarpetaAppdata() + "\\UserInfo.xml";

                if (File.Exists(PathXml.Trim()))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNodeList m_nodelist = null;

                    xmldoc.Load(PathXml.Trim());

                    m_nodelist = xmldoc.SelectNodes("/Logins/User");

                    foreach (XmlNode Nodo in m_nodelist)
                    {
                        TxtUsuario.Items.Add(Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes.Item(0).Value.ToString()));
                    }
                }
            }
            catch { }
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

        private void recordarDatosEnEquipo()
        {
            try
            {
                if (crearCarpetaAppdata().Trim() != "")
                {
                    if (TxtUsuario.Text.Trim() != "")
                    {
                        int nodeCount = 0;
                        XmlDocument xmldoc = new XmlDocument();
                        XmlNode xmlRoot, xmlNode;

                        string PathXml = crearCarpetaAppdata() + "\\UserInfo.xml";

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
                        xmlNode.InnerText = Encrypt_Decrypt.Encriptar(TxtUsuario.Text.Trim());//Agregamos el nombre del usuario deseado

                        xmldoc.Save(PathXml.Trim());
                        checkRecordar.Text = "Dejar de recordar mi" + Environment.NewLine + "usuario";
                        checkRecordar.Checked = true;
                        LlenarComboLogins();
                        TxtContraseña.Focus();
                    }
                    else
                    {
                        checkRecordar.Checked = false;
                        checkRecordar.Text = "Recordar mi usuario";
                    }
                }
                else
                {
                    checkRecordar.Checked = false;
                    checkRecordar.Text = "Recordar mi usuario";
                }
            }
            catch
            {
                MessageBox.Show(this, "Se produjo un error al crear el archivo que contiene la información de los usuarios que desea almacenar en este equipo, por favor intente de nuevo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dejarRecordarDatosEnEquipo()
        {
            try
            {
                string PathXml = crearCarpetaAppdata() + "\\UserInfo.xml";

                if (File.Exists(PathXml.Trim()))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNodeList m_nodelist = null;

                    xmldoc.Load(PathXml.Trim());

                    m_nodelist = xmldoc.SelectNodes("/Logins/User");

                    int cont = 0;
                    foreach (XmlNode Nodo in m_nodelist)
                    {
                        if (Nodo.ChildNodes.Item(0).Value.ToString().Trim() == Encrypt_Decrypt.Encriptar(TxtUsuario.Text.Trim()))
                        {
                            XmlNode parentNode = xmldoc.DocumentElement;
                            XmlNode toDelete = parentNode.ChildNodes.Item(cont);
                            parentNode.RemoveChild(toDelete);
                            xmldoc.Save(PathXml);
                            TxtUsuario.Text = "";
                            checkRecordar.Checked = false;
                            TxtUsuario.Focus();

                            LlenarComboLogins();
                            break;
                        }
                        cont++;
                    }
                }
            }
            catch { }
        }

        private DataSet SQLListas(String pSql, String pnTabla)
        {
            bool IsError = false;
            string ErrorDescripcion = "";
            SqlDataAdapter vDatos = new SqlDataAdapter(pSql, SqlCN);
            DataSet dsTabla = new DataSet();

            // capturar la excepción
            try
            {
                IsError = false;
                vDatos.Fill(dsTabla, pnTabla);

            }

            catch (SqlException errorSql)
            {
                IsError = true;
                ErrorDescripcion = "Error en ejecutarSQL \n";
                ErrorDescripcion += errorSql.Message;
            }
            catch (Exception error)
            {
                IsError = true;
                ErrorDescripcion = "Error en ejecutarConsultaSQL \n";
                ErrorDescripcion += error.Message;
            }

            return dsTabla;
        }

        private void TraerLogo()
        {
            try
            {
                string oAppConnectionString = Settings.Default.GClinicConnectionString.Trim();// ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                SqlConnectionStringBuilder ayudante = new SqlConnectionStringBuilder();
                ayudante.ConnectionString = oAppConnectionString;
                ayudante.UserID = "sa";
                ayudante.Password = "S0ftNet_GClinic_Admin";
                ayudante.DataSource = Settings.Default.Server;

                SqlCN = new SqlConnection(ayudante.ToString());
                SqlCN.Open();

                Image newImage = null;

                StringBuilder Sql = new StringBuilder("");

                Sql.Append("Select logo from Empresas");

                DataSet ds = SQLListas(Sql.ToString(), "Empresas");

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            //Initialize image variable
                            byte[] imageData = (byte[])dr[0];

                            //Read image data into a memory stream
                            using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                            {
                                ms.Write(imageData, 0, imageData.Length);

                                //Set image variable value using memory stream.
                                newImage = Image.FromStream(ms, true);
                            }

                            //set picture
                            if (newImage != null)
                            {
                                pictureBox6.BackgroundImage = newImage;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;//.Stretch;
                            }

                            break;
                        }
                    }
                }
                ds.Dispose();
            }
            catch
            {
            }
            finally
            {
                SqlCN.Close();
                SqlCN.Dispose();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            TraerLogo();
            LlenarComboLogins();

            label5.Visible = false;

            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                label5.Visible = true;
            }

            TxtUsuario.Focus();
            this.pictureBox1.Region = Shape.RoundedRegion(pictureBox1.Size, 1, Shape.Corner.None);
            this.pictureBox6.Region = Shape.RoundedRegion(pictureBox6.Size, 1, Shape.Corner.None);

            Program.oFrmIntro.Visible = false;
            Program.oMDI.Opacity = 1;
            Program.oFrmOrb.Show(Program.oMDI);
        }

        private void BtnEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                //Cerrado = false;
                Id_Usuario = "";

                Bandera = 0;

                if (cont_intentos > 2)
                {
                    MessageBox.Show(this, "Superó el número de intentos para ingresar al sistema", "Error al Ingresar al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Bandera = 1;
                    this.Close();
                    Application.ExitThread();
                }

                Program.oPersistencia = new Persistencia(this.TxtUsuario.Text, this.TxtContraseña.Text, "");

                if (Program.oPersistencia.estado() == false)
                {
                    MessageBox.Show(this, "Su usuario y/o contraseña son incorrectos. Verifique los datos para continuar", "Error al Ingresar al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    cont_intentos += 1;
                    this.TxtUsuario.Focus();
                }
                else
                {
                    DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_helpuser '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(TxtUsuario.Text.Trim()) + "'", "db");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                        Id_Usuario = dr[5].ToString().Trim();
                    ds.Dispose();

                    if (TxtUsuario.Text.Trim() != "admin" && TxtContraseña.Text != "admin_punto_venta_adminlogin_1029384756")
                    {
                        if (new Seguridad().VerificarEstadoUsuario(Id_Usuario.Trim()) == false)
                        {
                            MessageBox.Show(this, "El empleado al que está asignado este usuario se encuentra como inactivo, o este usuario no ha sido asignado a ningún empleado por lo que no puede proseguir, solicite a un Administrador del Sistema que modifique su estado ya en el Mantenimiento de Empleados o asigne este usuario a un empleado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Program.oPersistencia.conexion.Dispose();
                            Program.oPersistencia.conexion.Close();
                            cont_intentos += 1;
                            FrmLogin_Load(sender, e);
                        }
                        else
                        {
                            Cerrado = false;
                            Program.oUsuario = this.TxtUsuario.Text;
                            Program.oIdUsuario = Id_Usuario.Trim();
                            Program.coClaveUsuario = this.TxtContraseña.Text;
                            this.Close();
                            Dispose();
                        }
                    }
                    else
                    {
                        Seguridad.Id_Emp = "";
                        Cerrado = false;
                        Program.oUsuario = this.TxtUsuario.Text;
                        Program.oIdUsuario = Id_Usuario.Trim();
                        Program.coClaveUsuario = this.TxtContraseña.Text;
                        MessageBox.Show(this, "Este usuario no posee permisos para realizar algunos tipos de acciones ya que este usuario no puede ser asignado a ningún empleado, lo cual es necesario para el correcto funcionamiento del sistema. A medida que avance en su desempeño con el sistema el mismo le notificará cuales acciones podrá o no realizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                        Dispose();
                    }
                }
            }
            catch { }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Bandera = 1;
            this.Close();
            Application.ExitThread();

        }

        private void FrmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                label5.Visible = true;
                //                pictureBox2.Visible = true;
            }
            else
            {
                label5.Visible = false;
                //                pictureBox2.Visible = false;
            }

            if (e.KeyCode == Keys.Enter)
            {
                BtnEntrada_Click(sender, e);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Activated(object sender, EventArgs e)
        {
            if (activo == false)
            {
                activo = true;
            }
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Cerrado == true)
                button2_Click(sender, e);
        }

        private void FrmLogin_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cerrado = false;
            Bandera = 1;
            this.Close();
            Application.ExitThread();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (FrmManual.Abierto == false)
            //{
            //    Program.oFrmManual = new FrmManual();
            //    Program.oFrmManual.Show();

            //    Program.oFrmManual.treeView1.SelectedNode = Program.oFrmManual.treeView1.Nodes[1].Nodes[0].Nodes[0];
            //    FrmManual.oArreglo.Add("1/0/0");
            //    FrmManual.oArreglo2.Add("");
            //    FrmManual.contador++;
            //}
            //else
            //{
            //    //Esto permite que el form abierto su muestre sobre el form modal
            //    Program.oFrmManual.Hide();
            //    Program.oFrmManual.Enabled = false;
            //    Program.oFrmManual.Enabled = true;
            //    Program.oFrmManual.Show(Program.oMDI);
            //    Program.oFrmManual.WindowState = FormWindowState.Maximized;

            //    Program.oFrmManual.treeView1.SelectedNode = Program.oFrmManual.treeView1.Nodes[1].Nodes[0].Nodes[0];
            //    FrmManual.oArreglo.Add("1/0/0");
            //    FrmManual.oArreglo2.Add("");
            //    FrmManual.contador++;
            //}
        }

        private void checkRecordar_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkRecordar_Click(object sender, EventArgs e)
        {
            if (checkRecordar.Text == "Recordar mi usuario")
            {
                recordarDatosEnEquipo();
            }
            else if (checkRecordar.Text.Contains("Dejar de recordar"))
            {
                dejarRecordarDatosEnEquipo();
            }
        }

        private void TxtUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PathXml = crearCarpetaAppdata() + "\\UserInfo.xml";

            if (File.Exists(PathXml.Trim()))
            {
                XmlDocument xmldoc = new XmlDocument();
                XmlNodeList m_nodelist = null;

                xmldoc.Load(PathXml.Trim());

                m_nodelist = xmldoc.SelectNodes("/Logins/User");

                foreach (XmlNode Nodo in m_nodelist)
                {
                    if (Nodo.ChildNodes.Item(0).Value.ToString().Trim() == Encrypt_Decrypt.Encriptar(TxtUsuario.Text.Trim()))
                    {
                        checkRecordar.Checked = true;
                        checkRecordar.Text = "Dejar de recordar mi " + Environment.NewLine + "usuario";
                        break;
                    }
                    else
                    {
                        checkRecordar.Checked = false;
                        checkRecordar.Text = "Recordar mi usuario";
                    }
                }
            }
        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtUsuario.Items.Count > 0)
                {
                    if (TxtUsuario.Text.Trim() != "")
                    {
                        for (int a = 0; a < TxtUsuario.Items.Count; a++)
                        {
                            if (TxtUsuario.Text.ToLower().Trim() == TxtUsuario.GetItemText(TxtUsuario.Items[a]).ToLower().Trim())
                            {
                                string PathXml = crearCarpetaAppdata() + "\\UserInfo.xml";

                                if (File.Exists(PathXml.Trim()))
                                {
                                    XmlDocument xmldoc = new XmlDocument();
                                    XmlNodeList m_nodelist = null;

                                    xmldoc.Load(PathXml.Trim());

                                    m_nodelist = xmldoc.SelectNodes("/Logins/User");

                                    foreach (XmlNode Nodo in m_nodelist)
                                    {
                                        if (Nodo.ChildNodes.Item(0).Value.ToString().Trim() == TxtUsuario.Text.Trim())
                                        {
                                            checkRecordar.Checked = true;
                                            checkRecordar.Text = "Dejar de recordar mi" + Environment.NewLine + "usuario";
                                            break;
                                        }
                                        else
                                        {
                                            checkRecordar.Checked = false;
                                            checkRecordar.Text = "Recordar mi usuario";
                                        }
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                checkRecordar.Checked = false;
                                checkRecordar.Text = "Recordar mi usuario";
                            }
                        }
                    }
                    else
                    {
                        checkRecordar.Checked = false;
                        checkRecordar.Text = "Recordar mi usuario";
                    }
                }
            }
            catch { }
        }

        private void imagenCambiantePictureBox1_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void pBoxServer_Click(object sender, EventArgs e)
        {
            frmServer ofrmServer = new frmServer();            
            ofrmServer.ShowDialog(this);
        }

    }
}