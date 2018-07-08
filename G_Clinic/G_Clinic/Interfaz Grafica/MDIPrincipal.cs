using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Interfaz_Grafica;
using G_Clinic.Lógica_Negocios;
using System.IO;
using System.Xml;
using G_Clinic.Miscelaneos_y_Recursos;
using Transitions;

namespace G_Clinic
{
    public partial class MDIPrincipal : Form
    {
        public MDIPrincipal()
        {
            InitializeComponent();

            //Program.ofrmMenuPrincipal = new frmMenuPrincipal();
            //Program.ofrmMenuPrincipal.Show(this);

            crearCarpetaAppdata();
            RecordarOpciones_BarraHistorialClinico();
        }

        #region Variables

        public static bool BloquearBarra = false;
        public static string MACAdress = "";
        public static string Id_Empresa = "";
        public static bool MenusBloqueados = false;
        public static string RolUsuario = "";

        public bool autoHide = false;
        public bool estatico = false;

        TimeSpan horaEnviarRecordatorios = new TimeSpan();

        public static bool emailsSent = false;

        CEmail oCEmail = new CEmail();

        #endregion

        CValoresDefault oCValoresDefault = new CValoresDefault();

        public int vScroll_HistoriaClinica = 0;

        public bool VerificarEmpresasIngresadas()
        {
            bool Respuesta = false;
            MenusBloqueados = false;

            try
            {
                DataSet ds2 = Program.oPersistencia.ejecutarSQLListas("Select * from Empresas", "Empresas");

                if (ds2.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(this, "No puede continuar hasta haber incluído los datos de su empresa en el sistema por lo que el sistema se bloqueará y no podrá realizar ninguna acción sobre el mismo, excepto en el \"Asistente de inclusión de Empresas\" ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    foreach (ToolStripMenuItem menu in Program.oMDI.menuStrip1.Items)
                    {
                        for (int i = 0; i < menu.DropDownItems.Count; i++)
                        {
                            if (menu.DropDownItems[i].Name != "Detalle_Empresa" && menu.DropDownItems[i].Name != "Salir")
                            {
                                menu.DropDownItems[i].Enabled = false;
                            }
                            else
                                menu.DropDownItems[i].Enabled = true;
                        }
                    }

                    //Program.oMDI.BtnBloquear.Enabled = false;
                    //Program.oMDI.BtnCerrarSesion.Enabled = false;
                    //Program.oMDI.BtnRecordatorios.Enabled = false;
                    //Program.oMDI.BtnVentas.Enabled = false;
                    //Program.oMDI.pictureBox3.Enabled = false;

                    BloquearBarra = true;
                    ds2.Dispose();
                    Program.oMDI.toolStripStatusLabel4.Text = "   Asignación de equipo pendiente";
                    Respuesta = false;
                }
                else
                    Respuesta = true;

                return Respuesta;
            }
            catch
            {
                return false;
            }
        }

        public void MDIPrincipal_Load(object sender, EventArgs e)
        {
            Program.oFrmOrb = new frmOrb();

            toolStripStatusLabel1.Text = "No hay ningún usuario activo en este momento";

            //Cuando el form se carga debe mostrar la venta de conexión con la base de datos
            FrmLogin oLogin = new FrmLogin();
            // Mostrarlo de forma Moda
            oLogin.ShowDialog();

            Program.oFrmWait = new FrmWait();
            Program.oFrmWait.Show();
            Application.DoEvents();

            if (FrmLogin.Bandera == 0)//Valida que la razón de cerrar el login haya sido por un click en el botón de cerrar y no porque entrara con éxito al sistema
            {
                if (Convert.ToInt32(oLogin.Bandera1.ToString()) == 0)
                {
                    if (VerificarEmpresasIngresadas() == true)
                    {
                        oCValoresDefault.EstableceValoresDefault();

                        LeerOpcionesBarra_HistorialClinico();

                        oCEmail.LeeConfiguracionEmail();

                        Program.oFrmDock = new frmDock();
                        
                        Program.oFrmDetallePaciente = new frmDetallePaciente();
                        Program.oFrmVideosConsulta = new frmVideosConsulta();
                        Program.oFrmImagenesConsultas = new frmImagenesConsultas();
                        Program.oFrmHistorialConsultas = new frmHistorialConsultas();
                        Program.oFrmEmbarazos = new frmEmbarazos();
                        Program.ofrmPrescriptionPad = new frmPrescriptionPad();
                        Program.ofrmPrescriptionPad.frmPrescriptionPad_Load(sender, e);

                        new Seguridad().DesactivarMenu(this.menuStrip1);

                        //cargar la seguridad, habilita lo que le interesa
                        new Seguridad().SeguridadMenu(this.menuStrip1);

                        btnEpicrisis.Enabled = true;

                        toolStripStatusLabel1.Text = "Usuario Activo: " + Program.oUsuario.ToString().Trim();

                        Program.oCLogs.UserName = Program.oUsuario.Trim();

                        //timer1.Interval = 1800000;
                        //timer1.Start();

                        Program.oCEmpresa.LeeDatosEmpresa();

                        this.Text = Program.oCEmpresa.NombreEmpresa;
                        Id_Empresa = Program.oCEmpresa.IdEmpresa;

                        StringBuilder sql = new StringBuilder();
                        sql.Append("select nombre, id_empresa from Empresas");

                        DataSet ds = Program.oPersistencia.ejecutarSQLListas(sql.ToString(), "Empresas a, EmpresasXEquipo b");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                this.Text = dr[0].ToString().Trim() + " - SoftNet Business Solutions";
                                Program.oMDI.toolStripStatusLabel4.Text = dr[0].ToString().Trim();//"Equipo asignado a: " + dr[0].ToString().Trim();
                                Id_Empresa = dr[1].ToString().Trim();
                            }
                        }
                        ds.Dispose();

                        #region Extrae Rol del Usuario Actual

                        string Consulta = "sp_helpuser '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(Program.oUsuario.Trim()) + "'";

                        DataSet ds3 = Program.oPersistencia.ejecutarSQLListas(Consulta.Trim(), "db");

                        if (ds3 != null)
                        {
                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr3 in ds3.Tables[0].Rows)
                                {
                                    RolUsuario = dr3[1].ToString().Trim();
                                }
                                ds3.Dispose();
                            }
                        }
                        ds3.Dispose();

                        //try
                        //{
                        //    Program.ofrmRecordatoriosInicio = new FrmRecordatoriosInicio();
                        //    Program.ofrmRecordatoriosInicio.Show(Program.oMDI);
                        //}
                        //catch { }

                        #endregion

                        if (RolUsuario != "Administrador")
                        {                            
                            btnEpicrisis.Enabled = false;

                            Program.oMostrarRecordatorios.MuestraRecordatoriosAltaPrioridad();//Muestra los recordatorios de alta prioridad que continúan activos
                            Program.oMostrarRecordatorios.DeterminarRecordatoriosDelDiaActual();//Determina los recordatorios para la fecha actual

                            if (MostrarRecordatorios.oIdCita.Count > 0)// || oCEmail.VerificaCorreosEnviados() == false)
                            {
                                horaEnviarRecordatorios = Program.oCCitas.DeterminaHoraEnviarCorreos();

                                double totalMinutos = ((TimeSpan)(horaEnviarRecordatorios - System.DateTime.Now.TimeOfDay)).TotalMilliseconds;

                                if (totalMinutos <= 0)
                                    timer3.Interval = 1000;
                                else
                                    timer3.Interval = (int)totalMinutos;
                             
                                if (timer3.Enabled == false)
                                    timer3.Enabled = true;
                            }

                            if (timer2.Enabled == false)
                                timer2.Enabled = true;
                        }
                        else
                        {
                            timer2.Enabled = false;
                            timer3.Enabled = false;
                        }
                    }
                }
            }

            Program.oFrmWait.Close();
            try
            {
                this.mdiClientController1.MdiClient.MouseMove += new MouseEventHandler(MdiClient_MouseMove);
            }
            catch { }
        }

        public void MdiClient_MouseMove(object sender, MouseEventArgs e)
        {
            if (autoHide == true)
            {
                if (e.Location.X <= 5 && panel1.Left != 0)
                {
                    Transition t = new Transition(new TransitionType_EaseInEaseOut(150));
                    t.add(this.panel1, "Left", 0);
                    panel1.Height = mdiClientController1.MdiClient.ClientSize.Height;

                    t.run();

                    if (Program.oFrmHistoriaClinica != null)
                    {
                        if (Program.oFrmHistoriaClinica.Abierto == true)
                        {
                            if (Program.oMDI.BarraPacientes.Visible == true)
                                Program.oMDI.BarraPacientes.BringToFront();
                        }
                    }
                }
            }
        }

        private void Empleados_Click(object sender, EventArgs e)
        {
            FrmMantEmpleados oFrmMantEmpleados = new FrmMantEmpleados();
            oFrmMantEmpleados.Show(this);
        }

        private void Tipo_Contactos_Click(object sender, EventArgs e)
        {
            frmMantenimientosBasicos ofrmMantenimientosBasicos = new frmMantenimientosBasicos();
            ofrmMantenimientosBasicos.ShowDialog(this);
        }

        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Está seguro que desea Cambiar de Usuario?. Los módulos de \"Historia Clínica\" y \"Detalle de Consultas\" se cerrarán si se encuentran abiertos por motivos de la seguridad establecida para los usuarios.", "Cerrar Sesión", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (Program.oFrmHistoriaClinica != null)
                {
                    if (Program.oFrmHistoriaClinica.Abierto == true)
                        Program.oFrmHistoriaClinica.Close();
                }

                if (Program.oFrmConsultas != null)
                {
                    if (Program.oFrmConsultas.Activo == true)
                        Program.oFrmConsultas.Close();
                }

                Program.oPersistencia.conexion.Dispose();
                Program.oPersistencia.conexion.Close();

                Persistencia oPersistencia = new Persistencia("", "", "");

                MDIPrincipal_Load(sender, e);
            }
        }

        private void Detalle_Empresa_Click(object sender, EventArgs e)
        {
            FrmMiEmpresa oFrmMiEmpresa = new FrmMiEmpresa();
            oFrmMiEmpresa.ShowDialog(this);
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CrearRolesSQL_Click(object sender, EventArgs e)
        {
            FrmSeguridad oFrmSeguridad = new FrmSeguridad();
            oFrmSeguridad.ShowDialog();
        }

        private void toolStripMenuItem2_MouseHover(object sender, EventArgs e)
        {
            //toolStripMenuItem2.Image = Resources.softnet_orb_highlighted_upper_rhalf;
        }

        private void toolStripMenuItem2_MouseLeave(object sender, EventArgs e)
        {
            //toolStripMenuItem2.Image = Resources.softnet_orb_normal_upper_half;
        }

        private void MDIPrincipal_Deactivate(object sender, EventArgs e)
        {
            if (Program.oFrmHistoriaClinica != null)
            {
                if (Program.oFrmHistoriaClinica.Abierto == true)
                    vScroll_HistoriaClinica = Program.oFrmHistoriaClinica.VerticalScroll.Value;
            }
        }

        private void MDIPrincipal_Activated(object sender, EventArgs e)
        {
            if (Program.oFrmHistoriaClinica != null)
            {
                if (Program.oFrmHistoriaClinica.Abierto == true)
                {
                    Program.oFrmHistoriaClinica.VerticalScroll.Value = vScroll_HistoriaClinica;
                    Program.oFrmHistoriaClinica.AutoScrollPosition = new Point(0, vScroll_HistoriaClinica);
                }
            }
        }

        #region Historia Clínica

        public void historiaClínicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.oFrmHistoriaClinica == null)
            {
                panelSoftOptions.Visible = false;

                Program.oFrmHistoriaClinica = new frmHistoriaClinica();
                Program.oFrmHistoriaClinica.Show();
            }
            else
            {
                if (Program.oFrmHistoriaClinica.Abierto == true)
                {
                    MessageBox.Show(this, "El módulo de Historia Clínica del sistema ya se encuentra abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    panelSoftOptions.Visible = false;

                    Program.oFrmHistoriaClinica = new frmHistoriaClinica();
                    Program.oFrmHistoriaClinica.Show();
                }
            }
        }

        /// <summary>
        /// Establece la cadena que contendrá los parámetros por medio de los cuales se realizará la consulta del paciente correspondiente
        /// Dichos parámetros se establecen de acuerdo al tag que contengan los controles correspondientes
        /// </summary>
        /// <param name="oControl">Recibe el control del cual se extraerá el valor del "Tag" correspondiente y de esta forma
        /// se irá concatenando la cadena que contiene los parámetros para la sentencia</param>
        public void CadenaFiltrado(ToolStripTextBox oControl)
        {
            if (String.IsNullOrEmpty(Program.oFrmHistoriaClinica.sqlWhere))
                Program.oFrmHistoriaClinica.sqlWhere += oControl.Tag.ToString().Trim() + ",";
            else
                Program.oFrmHistoriaClinica.sqlWhere += oControl.Tag.ToString().Trim() + ",";

            if (Program.oFrmHistoriaClinica.sqlWhere.Trim().CompareTo("Where") == 0)
            {
                Program.oFrmHistoriaClinica.sqlWhere = "";
            }
        }

        /// <summary>
        /// Establece los campos por los cuales se filtrará dependiendo si hay valores o no en los mismos
        /// </summary>
        public void FiltrarPaciente()
        {
            Program.oFrmHistoriaClinica.sqlWhere = "";

            #region Establece en NULL los valores en la clase de Pacientes

            Program.oCPacientes.NumExpediente = 0;
            Program.oCPacientes.TipoCedula = null;
            Program.oCPacientes.Apellidos = null;
            Program.oCPacientes.FechaNacimiento = DateTime.MinValue;
            Program.oCPacientes.Sexo = null;
            Program.oCPacientes.EstadoCivil = null;
            Program.oCPacientes.Ocupacion = null;

            #endregion

            //Omitimos el espacio inicial ya que para eso utilizamos el .Trim()
            if (txtNombrePaciente.Text.Trim() != "" && txtNombrePaciente.Text.Trim() != "Ingrese el nombre del paciente...")
            {
                CadenaFiltrado(txtNombrePaciente);

                //El proc "sp_S_Pacientes_Param" posee una validación para este campo, si se envía la palabra "Global - " se realizará la búsqueda en donde coincida el nombre o apellido del paciente.
                //Previamente se filtraba solo por el nombre, ahora por ambos pero sólo desde este campo
                Program.oCPacientes.Nombre = "Global - " + txtNombrePaciente.Text.Trim();
            }
            else
                Program.oCPacientes.Nombre = null;

            if (txtCedulaPaciente.Text.Trim() != "" && txtCedulaPaciente.Text.Trim() != "Ingrese la cédula del paciente...")
            {
                CadenaFiltrado(txtCedulaPaciente);
                Program.oCPacientes.Cedula = txtCedulaPaciente.Text.Trim();
            }
            else
                Program.oCPacientes.Cedula = null;
        }

        private void tobConsultarPaciente_Click(object sender, EventArgs e)
        {
            FiltrarPaciente();

            //Se iguala a false para que la búsqueda se realice por medio de los parámetros enviados desde aquí...
            Program.oFrmHistoriaClinica.consultaLocal = false;

            //Se inicializa para que se refresquen los datos ejecutar una nueva consulta que devolverá nuevos resultados
            Program.oFrmHistoriaClinica.indiceFilaSeleccionada = -1;

            if (Program.oFrmHistoriaClinica.sqlWhere != "")
                Program.oFrmHistoriaClinica.tobEjecutarConsulta_Click(sender, e);

            if (Program.oFrmHistoriaClinica.Grid1.RowCount > 0)
            {
                if (Program.OcultarLuegoConsulta == 1)
                    BarraPacientes.Hide();
            }
            else
                txtCedulaPaciente.Focus();
        }

        private void txtCedulaPaciente_Click(object sender, EventArgs e)
        {
            txtCedulaPaciente.SelectAll();
        }

        private void txtCedulaPaciente_Enter(object sender, EventArgs e)
        {
            txtCedulaPaciente.SelectAll();
        }

        private void txtNombrePaciente_Enter(object sender, EventArgs e)
        {
            txtNombrePaciente.SelectAll();
        }

        private void txtNombrePaciente_Click(object sender, EventArgs e)
        {
            txtNombrePaciente.SelectAll();
        }

        private void txtCedulaPaciente_TextChanged(object sender, EventArgs e)
        {
            if (txtCedulaPaciente.Text.Trim() == "")
            {
                txtCedulaPaciente.Text = " Ingrese la cédula del paciente...";
                txtCedulaPaciente.SelectAll();
            }
        }

        private void txtNombrePaciente_TextChanged(object sender, EventArgs e)
        {
            if (txtNombrePaciente.Text.Trim() == "")
            {
                txtNombrePaciente.Text = " Ingrese el nombre del paciente...";
                txtNombrePaciente.SelectAll();
            }
        }

        private void BarraPacientes_VisibleChanged(object sender, EventArgs e)
        {
            if (BarraPacientes.Visible == true)
                txtCedulaPaciente.Focus();
        }

        private void txtCedulaPaciente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EventArgs e2 = new EventArgs();
                tobConsultarPaciente_Click(sender, e2);
            }
        }

        private void txtNombrePaciente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EventArgs e2 = new EventArgs();
                tobConsultarPaciente_Click(sender, e2);
            }
        }

        private void tobCerrarExpediente_Click(object sender, EventArgs e)
        {
            Program.oFrmHistoriaClinica.tobCerrar_Click(sender, e);
        }

        private string crearCarpetaAppdata()
        {
            try
            {
                string directoryString = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData).ToString() + "\\SoftNet G-Clinic\\MenuOptions";

                if (!Directory.Exists(directoryString))
                    Directory.CreateDirectory(directoryString);

                return directoryString;
            }
            catch
            {
                return "";
            }
        }

        private void RecordarOpciones_BarraHistorialClinico()
        {
            try
            {
                if (!File.Exists(crearCarpetaAppdata() + "\\MenuOptions_HistorialClinico.xml"))
                {
                    int nodeCount = 0;
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNode xmlRoot, xmlNode;

                    string PathXML = crearCarpetaAppdata() + "\\MenuOptions_HistorialClinico.xml";

                    if (!File.Exists(PathXML.Trim()))
                    {
                        xmlRoot = xmldoc.CreateElement("MenuOptions");
                        nodeCount = 0;
                    }
                    else
                    {
                        xmldoc.Load(PathXML.Trim());
                        xmlRoot = xmldoc.SelectSingleNode("/MenuOptions");
                        nodeCount = xmldoc.ChildNodes.Count;
                    }

                    nodeCount++;

                    xmldoc.AppendChild(xmlRoot);

                    xmlNode = xmldoc.CreateElement("ShowAtStartup");
                    xmlRoot.AppendChild(xmlNode);
                    xmlNode.InnerText = Encrypt_Decrypt.Encriptar("0");//Agregamos el valor cero que será el valor por defecto = NoMostrarInicio

                    xmlNode = xmldoc.CreateElement("CloseAfterSelect");
                    xmlRoot.AppendChild(xmlNode);
                    xmlNode.InnerText = Encrypt_Decrypt.Encriptar("0");//Agregamos el valor cero que será el valor por defecto = NoMostrarInicio

                    xmlNode = xmldoc.CreateElement("ShowAlways");
                    xmlRoot.AppendChild(xmlNode);
                    xmlNode.InnerText = Encrypt_Decrypt.Encriptar("0");//Agregamos el valor cero que será el valor por defecto = NoMostrarInicio

                    xmldoc.Save(PathXML.Trim());
                }
            }
            catch
            {
                MessageBox.Show(this, "Se produjo un error al crear el archivo que contiene la información de los usuarios que desea almacenar en este equipo, por favor intente de nuevo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tobCerrar_Click(object sender, EventArgs e)
        {
            BarraPacientes.Hide();
        }

        private void tobDatosPersonales_Click(object sender, EventArgs e)
        {
            Program.oFrmHistoriaClinica.VerticalScroll.Value = 0;
            Program.oFrmHistoriaClinica.AutoScrollPosition = new Point(0, 0);
        }

        private void tobDatosFamiliares_Click(object sender, EventArgs e)
        {
            Program.oFrmHistoriaClinica.VerticalScroll.Value = Program.oFrmHistoriaClinica.lblMark1.Location.Y;
            Program.oFrmHistoriaClinica.AutoScrollPosition = new Point(0, Program.oFrmHistoriaClinica.lblMark1.Location.Y);
        }

        private void tobExamenFisico_Click(object sender, EventArgs e)
        {
            Program.oFrmHistoriaClinica.VerticalScroll.Value = Program.oFrmHistoriaClinica.lblMark2.Location.Y;
            Program.oFrmHistoriaClinica.AutoScrollPosition = new Point(0, Program.oFrmHistoriaClinica.lblMark2.Location.Y);
        }

        private void tobAntecedentesGenerales_Click(object sender, EventArgs e)
        {
            Program.oFrmHistoriaClinica.VerticalScroll.Value = Program.oFrmHistoriaClinica.lblMark3.Location.Y;
            Program.oFrmHistoriaClinica.AutoScrollPosition = new Point(0, Program.oFrmHistoriaClinica.lblMark3.Location.Y);
        }

        private void tobAntecedentesObstetGinec_Click(object sender, EventArgs e)
        {
            Program.oFrmHistoriaClinica.VerticalScroll.Value = Program.oFrmHistoriaClinica.lblMark4.Location.Y;
            Program.oFrmHistoriaClinica.AutoScrollPosition = new Point(0, Program.oFrmHistoriaClinica.lblMark4.Location.Y);
        }

        private void tobSalirHistoriaClinica_Click(object sender, EventArgs e)
        {
            Program.oFrmHistoriaClinica.tobSalir_Click(sender, e);
        }

        private void tobOpcionesHistoriaClinica_Click(object sender, EventArgs e)
        {
            Point oPoint = new Point();
            oPoint.X = Program.oMDI.Width - (tobCerrar.Width * 2 + toolStripSeparator13.Width);
            oPoint.Y = Program.oMDI.BarraPacientes.Bottom - Program.oMDI.BarraPacientes.Height - OpcionesBarraHistoriaClinica.Height + 18;

            if (Program.MostraBarraInicio == 1)
                mostrarSiempreQueInicieElHistorialClínicoToolStripMenuItem.Checked = true;
            else
                mostrarSiempreQueInicieElHistorialClínicoToolStripMenuItem.Checked = false;

            if (Program.OcultarLuegoConsulta == 1)
                ocultarLuegoDeRealizarLaConsultaDeseadaToolStripMenuItem.Checked = true;
            else
                ocultarLuegoDeRealizarLaConsultaDeseadaToolStripMenuItem.Checked = false;

            if (Program.MostrarBarraSiempre == 1)
                mantenerSiempreVisibleToolStripMenuItem.Checked = true;
            else
                mantenerSiempreVisibleToolStripMenuItem.Checked = false;

            OpcionesBarraHistoriaClinica.Show(oPoint);
        }

        private void LeerOpcionesBarra_HistorialClinico()
        {
            string PathXml = crearCarpetaAppdata() + "\\MenuOptions_HistorialClinico.xml";

            if (File.Exists(PathXml.Trim()))
            {
                XmlDocument xmldoc = new XmlDocument();
                XmlNodeList m_nodelist = null;
                XmlNode xmlRoot, xmlNode;

                xmldoc.Load(PathXml.Trim());

                XmlNode parentNode = xmldoc.DocumentElement;
                xmlRoot = xmldoc.SelectSingleNode("/MenuOptions");

                m_nodelist = parentNode.ChildNodes;//xmldoc.SelectNodes("/MenuOptions/ShowAtStartup");

                int cont = 0;
                foreach (XmlNode Nodo in m_nodelist)
                {
                    if (Nodo.Name == "ShowAtStartup")
                        Program.MostraBarraInicio = Convert.ToInt32(Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes[0].InnerText));
                    else if (Nodo.Name == "CloseAfterSelect")
                        Program.OcultarLuegoConsulta = Convert.ToInt32(Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes[0].InnerText));
                    else if (Nodo.Name == "ShowAlways")
                        Program.MostrarBarraSiempre = Convert.ToInt32(Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes[0].InnerText));
                }
            }
        }

        private void ModificarDatos_OpcionesBarra_HistorialClinico(string pNodo, string Valor)
        {
            try
            {
                string PathXml = crearCarpetaAppdata() + "\\MenuOptions_HistorialClinico.xml";

                if (File.Exists(PathXml.Trim()))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNodeList m_nodelist = null;
                    XmlNode xmlRoot, xmlNode;

                    xmldoc.Load(PathXml.Trim());
                    xmlRoot = xmldoc.SelectSingleNode("/MenuOptions");

                    m_nodelist = xmldoc.SelectNodes("/MenuOptions/" + pNodo);

                    foreach (XmlNode Nodo in m_nodelist)
                    {
                        Nodo.InnerText = Encrypt_Decrypt.Encriptar(Valor);
                        xmldoc.Save(PathXml);

                        break;
                    }
                }
            }
            catch { }
        }

        private void mostrarSiempreQueInicieElHistorialClínicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.MostraBarraInicio.ToString() == "0")
            {
                ModificarDatos_OpcionesBarra_HistorialClinico("ShowAtStartup", "1");
                Program.MostraBarraInicio = 1;
            }
            else
            {
                ModificarDatos_OpcionesBarra_HistorialClinico("ShowAtStartup", "0");
                Program.MostraBarraInicio = 0;
            }
        }

        private void ocultarLuegoDeRealizarLaConsultaDeseadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.OcultarLuegoConsulta.ToString() == "0")
            {
                ModificarDatos_OpcionesBarra_HistorialClinico("CloseAfterSelect", "1");
                Program.OcultarLuegoConsulta = 1;
            }
            else
            {
                ModificarDatos_OpcionesBarra_HistorialClinico("CloseAfterSelect", "0");
                Program.OcultarLuegoConsulta = 0;
            }
        }

        private void mantenerSiempreVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.MostrarBarraSiempre.ToString() == "0")
            {
                ModificarDatos_OpcionesBarra_HistorialClinico("ShowAlways", "1");
                Program.MostrarBarraSiempre = 1;
            }
            else
            {
                ModificarDatos_OpcionesBarra_HistorialClinico("ShowAlways", "0");
                Program.MostrarBarraSiempre = 0;
            }
        }

        #endregion

        private void Métodos_Anticonceptivos_Click(object sender, EventArgs e)
        {
            frmMetodosAnticonceptivos ofrmMetodosAnticonceptivos = new frmMetodosAnticonceptivos();
            ofrmMetodosAnticonceptivos.ShowDialog(this);
        }

        private void Consultas_Click(object sender, EventArgs e)
        {
            if (Program.oFrmConsultas == null)
            {
                panelSoftOptions.Visible = false;

                Program.oFrmConsultas = new frmConsultas();
                Program.oFrmConsultas.Show();
            }
            else
            {
                if (Program.oFrmConsultas.Activo == true)
                {
                    MessageBox.Show(this, "El módulo de consultas del sistema ya se encuentra abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    panelSoftOptions.Visible = false;

                    Program.oFrmConsultas = new frmConsultas();
                    Program.oFrmConsultas.Show();
                }
            }
        }

        private void Categorias_Empleado_Click(object sender, EventArgs e)
        {
            frmCategoriasEmpleado ofrmCategoriasEmpleado = new frmCategoriasEmpleado();
            ofrmCategoriasEmpleado.ShowDialog(this);
        }

        private void Gabinete_Click(object sender, EventArgs e)
        {
            frmGabinete oFrmGabinete = new frmGabinete();
            oFrmGabinete.ShowDialog();
        }

        private void Examenes_de_Laboratorio_Click(object sender, EventArgs e)
        {
            frmExamenesLaboratorio ofrmExamenesLaboratorio = new frmExamenesLaboratorio();
            ofrmExamenesLaboratorio.ShowDialog(this);
        }

        private void statusStrip1_MouseEnter(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void MDIPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "¿Está seguro que desea salir del sistema?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.oFrmConsultas != null)
            {
                if (Program.oFrmConsultas.Activo == true)
                {
                    if (Program.oFrmConsultas.TxtNumExpediente.Text.Trim() != String.Empty)
                    {
                        int top = 0;
                        top = Screen.PrimaryScreen.WorkingArea.Height - Program.oFrmDock.Height - Program.oMDI.statusStrip1.Height;

                        if (Program.oFrmDock.Activo == false)
                            Program.oFrmDock.Show(this);
                        else
                            Program.oFrmDock.Show();

                        Transition t = new Transition(new TransitionType_EaseInEaseOut(500));
                        t.add(Program.oFrmDock, "Top", top);
                        t.run();

                        Program.oFrmDock.ShownComplete = true;
                    }
                }
            }

            timer1.Stop();
        }

        private void statusStrip1_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void tobDetalleConsulta_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
            t.add(Program.oFrmConsultas.panelOpciones, "Left", 0);
            t.run();
        }

        private void tobDiagnostico_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
            t.add(Program.oFrmConsultas.panelOpciones, "Left", -480);
            t.run();
        }

        private void tobTratamiento_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
            t.add(Program.oFrmConsultas.panelOpciones, "Left", -960);
            t.run();
        }

        private void tobExamenes_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
            t.add(Program.oFrmConsultas.panelOpciones, "Left", -1443);
            t.run();
        }

        private void tobGabinete_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
            t.add(Program.oFrmConsultas.panelOpciones, "Left", -1924);
            t.run();
        }

        private void tobImagenes_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
            t.add(Program.oFrmConsultas.panelOpciones, "Left", -2408);
            t.run();
        }

        private void tobVideos_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
            t.add(Program.oFrmConsultas.panelOpciones, "Left", -2889);
            t.run();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (RolUsuario.Trim() != "")
            {
                if (RolUsuario.Trim() != "Administrador")
                    Program.oMostrarRecordatorios.MuestraRecordatoriosDiaActual();
                else
                    timer2.Stop();
            }
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            Program.ofrmCalendario = new frmCalendario();
            Program.ofrmCalendario.Show(this);
        }

        private void imagenCambianteLabel1_Click(object sender, EventArgs e)
        {
            frmVideo ofrmVideoPlayer = new frmVideo();
            ofrmVideoPlayer.Show(this);
        }

        private void MenusPorRolesSQL_Click(object sender, EventArgs e)
        {
            FrmMenusXRol oFrmMenusXRol = new FrmMenusXRol();
            oFrmMenusXRol.ShowDialog();
        }

        private void CambiarContraseñaUsuario_Click(object sender, EventArgs e)
        {
            Program.oFrmCambiarContraseñaUsuario = new FrmCambiarContraseñaUsuario();
            Program.oFrmCambiarContraseñaUsuario.ShowDialog();
        }

        private void RespaldoBaseDatosSQL_Click(object sender, EventArgs e)
        {
            FrmRespaldo oFrmRespaldo = new FrmRespaldo();
            oFrmRespaldo.ShowDialog();
        }

        private void tobAutoHide_Click(object sender, EventArgs e)
        {
            if (autoHide == false)
            {
                tobAutoHide.Image = Properties.Resources.Tack_Pro_2;
                autoHide = true;
                panel1.Dock = DockStyle.None;

                Transition t = new Transition(new TransitionType_EaseInEaseOut(150));
                t.add(this.panel1, "Left", -211);
                panel1.Height = mdiClientController1.MdiClient.ClientSize.Height;
                t.run();

                tobAutoHide.ToolTipText = "Siempre Visible";
            }
            else
            {
                autoHide = false;

                panel1.Dock = DockStyle.Left;

                Transition t = new Transition(new TransitionType_EaseInEaseOut(150));
                t.add(this.panel1, "Left", 0);
                panel1.Height = mdiClientController1.MdiClient.ClientSize.Height;
                t.run();

                tobAutoHide.ToolTipText = "Ocultar automáticamente";
                tobAutoHide.Image = Properties.Resources.Tack_Pro_3;
            }

            if (Program.oFrmHistoriaClinica != null)
            {
                if (Program.oFrmHistoriaClinica.Abierto == true)
                {
                    Program.oFrmHistoriaClinica.ContainerPanelLocation();
                    Program.oFrmHistoriaClinica.CalculaPosicionBarra();
                }
            }

            if (Program.oFrmConsultas != null)
            {
                if (Program.oFrmConsultas.Activo == true)
                    Program.oFrmConsultas.ContainerPanelLocation();
            }
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            estatico = false;
            timerAutoHide.Start();
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            estatico = true;
            timerAutoHide.Stop();
        }

        private void panelOpcionesHistoriaClinica_MouseEnter(object sender, EventArgs e)
        {
            estatico = true;
            timerAutoHide.Stop();
        }

        private void btnDetalle_MouseEnter(object sender, EventArgs e)
        {
            estatico = true;
            timerAutoHide.Stop();
        }

        private void btnDatosPersonales_MouseEnter(object sender, EventArgs e)
        {
            estatico = true;
            timerAutoHide.Stop();
        }

        private void btnDatosPersonales_MouseLeave(object sender, EventArgs e)
        {
            estatico = false;
            timerAutoHide.Start();
        }

        private void btnVideos_MouseLeave(object sender, EventArgs e)
        {
            estatico = false;
            timerAutoHide.Start();
        }

        private void timerAutoHide_Tick(object sender, EventArgs e)
        {
            timerAutoHide.Stop();

            if (autoHide == true)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(150));
                t.add(this.panel1, "Left", -211);
                t.run();

                if (Program.oFrmHistoriaClinica != null)
                {
                    if (Program.oFrmHistoriaClinica.Abierto == true)
                        Program.oMDI.BarraPacientes.Size = new Size(this.ClientSize.Width - SystemInformation.VerticalScrollBarWidth, Program.oMDI.BarraPacientes.Height);
                }
            }
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            estatico = false;
            timerAutoHide.Start();
        }

        private void panelOpcionesHistoriaClinica_MouseLeave(object sender, EventArgs e)
        {
            estatico = false;
            timerAutoHide.Start();
        }

        private void panel1_LocationChanged(object sender, EventArgs e)
        {
            panel1.Update();
        }

        private void Permisos_Especiales_De_Usuario_Click(object sender, EventArgs e)
        {
            frmPermisosEspeciales oFrmPermisosEspeciales = new frmPermisosEspeciales();
            oFrmPermisosEspeciales.ShowDialog();
        }

        private void MDIPrincipal_Move(object sender, EventArgs e)
        {
            if (Program.oFrmOrb != null)
                Program.oFrmOrb.OrbLocation();
        }

        private void btnEpicrisis_Click(object sender, EventArgs e)
        {
            Program.oFrmEpicrisis = new frmEpicrisis();
            Program.oFrmEpicrisis.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                frmConsultasPaciente ofrmcon = new frmConsultasPaciente();
                ofrmcon.Show(this);
            //}
            //catch { }
        }
         
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Program.oFrmHistoriaClinica.tobNuevo_Click(sender, e);
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            frmEmail ofrmEmail = new frmEmail();
            ofrmEmail.Show(this);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = false;

            if (oCEmail.VerificaCorreosEnviados() == false)
            {
                frmEnviarCorreos ofrmEnviarCorreos = new frmEnviarCorreos();
                ofrmEnviarCorreos.Show(this);
            }
        }

        private void Resultados_De_Examenes_Click(object sender, EventArgs e)
        {
            frmResultadosExamenesConsulta ofrmResultadosExamenesConsulta = new frmResultadosExamenesConsulta();
            ofrmResultadosExamenesConsulta.ShowDialog(this);
        }

        private void btnConsultasAntiguas_Click(object sender, EventArgs e)
        {
            Program.oFrmHistoriaClinica.VerticalScroll.Value = Program.oFrmHistoriaClinica.lblMark5.Location.Y;
            Program.oFrmHistoriaClinica.AutoScrollPosition = new Point(0, Program.oFrmHistoriaClinica.lblMark5.Location.Y);
        }

        private void Registro_Actividades_Click(object sender, EventArgs e)
        {
            frmActivityLogReport ofrmActivityLogReport = new frmActivityLogReport();
            ofrmActivityLogReport.ShowDialog(this);
        }

        private void Fuentes_Del_Sistema_Click(object sender, EventArgs e)
        {
            frmFuentesDelSistema ofrmFuentesDelSistema = new frmFuentesDelSistema();
            ofrmFuentesDelSistema.ShowDialog(this);
        }
    }
}