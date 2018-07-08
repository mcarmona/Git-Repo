using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Transitions;
using G_Clinic.Lógica_Negocios;
using G_Clinic.Miscelaneos_y_Recursos;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing.Drawing2D;
using System.IO;
using System.Xml;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmConsultas : Form
    {
        #region Variables e instancias

        bool activo = false;

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        string path = "";
        
        int fila = 0;
        /// <summary> 
        ///El auxFila se establece cuando después de guardar en proceso de modificación de la consulta
        ///se encuentra que hay al menos 1 fila existente, la cual debería de ser la o una de las que está
        ///siendo modificada, por lo que al recargar los datos no debería irse a la primera consulta, sino 
        ///a la actual (recien modificada)
        /// </summary>
        int auxFila = 0;
        /// <summary>
        /// Variable para determinar el total de filas que se encontraron luego de una consulta, al realizar una nueva
        /// consulta se establece a su valor original que es CERO
        /// </summary>
        int totalFilas = 0;

        bool primeraVez = false;

        public bool nuevo = false;
        public bool modificar = false;

        DataRow drGlobal = null;
        DataTable dt;
        SqlDataReader sqlDR = null;

        DateTime fechaConsulta = new DateTime();

        ArrayList oArregloDiagnosticos = new ArrayList();

        CGabinete oCGabinete = new CGabinete();
        CCategoriasGabinete oCCategoriasGabinete = new CCategoriasGabinete();
        CGabineteCategoria oCGabineteCategoria = new CGabineteCategoria();

        ArrayList nombreCategoria = new ArrayList();
        ArrayList idCategoria = new ArrayList();

        ArrayList oIdDetalleGabinete = new ArrayList();
        ArrayList oDetalleGabinete = new ArrayList();

        ArrayList nombreCategoriaExamenes = new ArrayList();
        ArrayList idCategoriaExamenes = new ArrayList();

        ArrayList oIdDetalleExamenes = new ArrayList();
        ArrayList oDetalleExamenes = new ArrayList();

        ArrayList oIdExamenes = new ArrayList();

        int currentNode = -1;
        int nodeImageIndex = -1;

        int currentNodeExamenes = -1;
        int nodeImageIndexExamenes = -1;

        int mouseX = 0;
        int mouseY = 0;

        int numImage = 0;
        PictureBox oPict = null;

        PictureBox auxPBox = null;
        string direccImage = "";

        Graphics oGraphics;
        GraphicsPath oGraphicsPath = new GraphicsPath();

        ArrayList oArregloBytesImagenes = new ArrayList();

        /// <summary>
        /// Determina cual opcióon se eligió ingresar, si la FPP o la FUR en las consultas con embarazo
        /// </summary>
        int opcionElegida = 0;

        DateTime oFechaIniEmbarazo = new DateTime();

        object[] oObject = null;
        ArrayList oArray = new ArrayList();

        public void ContainerPanelLocation()
        {
            int x = 0;
            x = (this.ClientSize.Width - panel1.Width) / 2;

            if (this.VerticalScroll.Visible == true)
                panel1.Location = new Point(x - 12, this.panel1.Location.Y);
            else
                panel1.Location = new Point(x, this.panel1.Location.Y);
        }

        public frmConsultas()
        {
            InitializeComponent();
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.Mantenimiento);
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.DetalleDeConsulta);

            this.SetStyles();

            this.MdiParent = Program.oMDI;
            this.Dock = DockStyle.Fill;
            this.BringToFront();
            this.Size = new Size((Program.oMDI.ClientRectangle.Width - Program.oMDI.panel1.Width), Parent.Height);

            panel2.Top = this.Size.Height;
        }

        CDetalleConsulta oCDetalleConsulta = new CDetalleConsulta();
        CConsultaEmbarazo oCConsultaEmbarazo = new CConsultaEmbarazo();

        CMetodosAnticonceptivos oCMetodosAnticonceptivos = new CMetodosAnticonceptivos();
        CEmpresa oCEmpresa = new CEmpresa();
        CPacientes oCPacientes = new CPacientes();
        CContactosPacientes oCContactosPacientes = new CContactosPacientes();
        CEmpleados oCEmpleados = new CEmpleados();
        CDiagnosticos oCDiagnosticos = new CDiagnosticos();
        CDiagnosticosConsulta oCDiagnosticosConsulta = new CDiagnosticosConsulta();
        CGabineteConsulta oCGabineteConsulta = new CGabineteConsulta();

        CExamenes oCExamenes = new CExamenes();
        CExamenesCategoria oCExamenesCategoria = new CExamenesCategoria();
        CExamenesConsulta oCExamenesConsulta = new CExamenesConsulta();

        CImagenesConsulta oCImagenesConsulta = new CImagenesConsulta();

        CVideosConsulta oCVideosConsulta = new CVideosConsulta();

        frmParamBusquedaConsulta oFrmParamBusquedaConsulta = new frmParamBusquedaConsulta();

        /// <summary>
        /// 0 = Periodo de Embarazo Iniciado
        /// 1 = Periodo de Embarazo Activo
        /// 2 = Periodo de Embarazo Finalizado
        /// </summary>
        int embarazoActivo = -1;

        /// <summary>
        /// Se establece al generar una nueva consulta, 
        /// 1 = Sin Embarazo,
        /// 2 = Con Embarazo
        /// </summary>
        int tipoConsultaSeleccionada = 0;

        /// <summary>
        /// Esta fecha se establece cuando se están mostrando datos para así de esta forma determinar el periodo al que pertenece
        /// una determinada consulta...
        /// </summary>
        DateTime fechaInicialPeriodoEmbarazo = new DateTime();

        /// <summary>
        /// Este dato se establece cuando se selecciona el paciente, de esta forma si no presenta MENARCA y se genera una consulta con embarazo
        /// el sistema no lo va a dejar hasta que modifique los datos...
        /// </summary>
        bool presentaMenarca = false;

        double pesoHabitual = 0;

        /// <summary>
        /// Variable para denotar si la fecha de ultima regla se encuentra a disposición del doctor, es decir, que la paciente
        /// sabe la fecha exacta de la FUR
        /// </summary>
        bool furDisponible = true;

        public SoftNetImageViewer softNetImageViewer1 = new SoftNetImageViewer();
        public List<GlobalElementsValues> oListGlobalElementValues = new List<GlobalElementsValues>();
        public GlobalElementsValues tempGlobalElementValues = new GlobalElementsValues();

        #endregion

        #region Métodos propios de diseño de interfaz

        private void SetStyles()
        {
            //Makes sure the form repaints when it was resized
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            try
            {
                // Getting the graphics object
                Graphics g = pevent.Graphics;

                // Creating the rectangle for the gradient
                System.Drawing.Rectangle rBackground = new System.Drawing.Rectangle(0, 0, this.Width, (this.Height) / 2);

                // Creating the lineargradient
                // Creating the lineargradient
                System.Drawing.Drawing2D.LinearGradientBrush bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground, System.Drawing.Color.FromArgb(12, 3, 3), System.Drawing.Color.FromArgb(90, 33, 32), 91);
                // Draw the gradient onto the form
                g.FillRectangle(bBackground, rBackground);

                // Disposing of the resources held by the brush
                bBackground.Dispose();

                // Getting the graphics object
                Graphics g3 = pevent.Graphics;

                // Creating the rectangle for the gradient
                System.Drawing.Rectangle rBackground3 = new System.Drawing.Rectangle(0, (this.Height) / 2, this.Width, (this.Height) / 2);

                // Creating the lineargradient
                System.Drawing.Drawing2D.LinearGradientBrush bBackground3 = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground3, System.Drawing.Color.FromArgb(90, 33, 32), System.Drawing.Color.FromArgb(12, 3, 3), 91);

                // Draw the gradient onto the form
                g.FillRectangle(bBackground3, rBackground3);

                // Disposing of the resources held by the brush
                bBackground3.Dispose();
            }
            catch { }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion

        private void LlenaComboMetodosAnticonceptivos()
        {
            cmbMetodoAnticonceptivo.DataSource = null;
            //Metodos_Globales.LlenarCombo(cmbMetodoAnticonceptivo, "Sp_S_Metodos_Anticonceptivos", "Metodos_Anticonceptivos", "id_metodo", "descripcion");
            Metodos_Globales.LlenarCombo(cmbMetodoAnticonceptivo, "Select * from Metodos_anticonceptivos Order by descripcion", "Metodos_Anticonceptivos", "id_metodo", "descripcion");

            if (cmbMetodoAnticonceptivo.Items.Count == 0)
                cmbMetodoAnticonceptivo.Items.Add("Ninguno");
        }

        private void frmConsultas_Load(object sender, EventArgs e)
        {
            this.panel9.Controls.Add(this.softNetImageViewer1);

            softNetImageViewer1.Location = new Point(0, 0);
            softNetImageViewer1.Show();

            ContainerPanelLocation();

            activo = true;
            //pictureBox4.Parent = grouper5;

            primeraVez = true;
            tobCancelar_Click(sender, e);
            primeraVez = false;

            Program.oMDI.panel4.BackColor = Color.Black;
            Program.oMDI.pictureBox2.BackColor = Color.Black;

            txtEditDetalleConsulta.Region = Shape.RoundedRegion(txtEditDetalleConsulta.Size, 3, Shape.Corner.None);
            txtEditTratamiento.Region = Shape.RoundedRegion(txtEditTratamiento.Size, 3, Shape.Corner.None);
            txtEditDiagnostico.Region = Shape.RoundedRegion(txtEditDiagnostico.Size, 3, Shape.Corner.None);

            txtEditDetalleConsulta.TextForeColor(Color.Black);
            txtEditDiagnostico.TextForeColor(Color.Black);
            txtEditTratamiento.TextForeColor(Color.Black);

            txtEditTratamiento.ChangeFont("Segoe Print");
            txtEditTratamiento.FontSize(14);
            txtEditTratamiento.ActivateBulletsAtStartup();

            LlenaComboMetodosAnticonceptivos();

            Transition t = new Transition(new TransitionType_EaseInEaseOut(300));
            t.add(panel2, "Top", 152);
            t.run();

            txtFoco.Focus();

            LlenarLista(true);
            LlenarListaExamenes(true);

            try
            {
                VistaConstants.SetWindowTheme(treeView1.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(treeView1.Handle, VistaConstants.TVM_SETEXTENDEDSTYLE, VistaConstants.TVS_EX_FADEINOUTEXPANDOS, VistaConstants.TVS_EX_FADEINOUTEXPANDOS);
                VistaConstants.SendMessage(treeView1.Handle, VistaConstants.TVM_SETEXTENDEDSTYLE, VistaConstants.TVS_EX_AUTOHSCROLL, VistaConstants.TVS_EX_AUTOHSCROLL);

                VistaConstants.SetWindowTheme(treeView2.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(treeView2.Handle, VistaConstants.TVM_SETEXTENDEDSTYLE, VistaConstants.TVS_EX_FADEINOUTEXPANDOS, VistaConstants.TVS_EX_FADEINOUTEXPANDOS);
                VistaConstants.SendMessage(treeView2.Handle, VistaConstants.TVM_SETEXTENDEDSTYLE, VistaConstants.TVS_EX_AUTOHSCROLL, VistaConstants.TVS_EX_AUTOHSCROLL);

                VistaConstants.SetWindowTheme(lstGabineteConsulta.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstGabineteConsulta.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);

                VistaConstants.SetWindowTheme(lstExamenesConsulta.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstExamenesConsulta.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);

                VistaConstants.SetWindowTheme(lstVideos.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstVideos.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
            }
            catch { }

            Program.oMDI.panel3.Visible = true;
            Program.oMDI.panel3.BringToFront();

            Program.oMDI.BarraPacientes.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");

            if (path != "")
                txtEditDetalleConsulta.GuardarArchivoTemporal(path + "\\test.rtf");

            oCDetalleConsulta.IdConsulta = "1";
            oCDetalleConsulta.BArchivo = Metodos_Globales.ReadFile(path + "\\test.rtf");

            oCDetalleConsulta.Insertar();
            txtEditDetalleConsulta.Limpiar();
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");

            byte[] infoArchivo = null;

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select * from Detalle_Consulta where id_consulta = 1", "Detalle_Consulta");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                infoArchivo = (byte[])dr[1];
            }
            ds.Dispose();

            Metodos_Globales.CreateTempFileFromByteArray(infoArchivo, path + "\\test.rtf");

            txtEditDetalleConsulta.AbrirArchivo(path + "\\test.rtf");
        }

        private void BloquearCampos()
        {
            dtFUR.Enabled = false;
            txtAmenorrea.Enabled = false;
            txtDetalleMenstruacion.Enabled = false;

            cmbMetodoAnticonceptivo.Enabled = false;
            txtDetalleMetodoAnticonceptivo.Enabled = false;

            txtEditDetalleConsulta.Enabled = false;
            txtEditDiagnostico.Enabled = false;
            txtEditTratamiento.Enabled = false;

            txtIMC.Enabled = false;
            TxtNombre.Enabled = false;
            TxtNumExpediente.Enabled = false;
            txtPesoHabitual.Enabled = false;
            txtPresionArterial.Enabled = false;
            txtTalla.Enabled = false;

            txtDiagnosticos.Enabled = false;

            tobBuscarPaciente.Enabled = false;

            //treeView1.Enabled = false;
            txtDetalleAdicional.Enabled = false;

            //treeView2.Enabled = false;
            txtDetalleAdicionalExamenes.Enabled = false;

            //btnAgregarImagen.Enabled = false;
            //tobEliminarImage.Enabled = false;

            //if (//flowLayoutPanel1.Controls.Count == 0)
            //{
            //    btnPhotoAlbum.Enabled = false;                
            //    tobMagnifyImage.Enabled = false;
            //}

            btnAgregarVideo.Enabled = false;
            btnReproducirVideo.Enabled = false;

            //Con Embarazo
            txtIMC2.Enabled = false;
            txtPesoHabitual2.Enabled = false;
            txtPresionArterial2.Enabled = false;
            txtTalla2.Enabled = false;
            txtHabitual3.Enabled = false;

            dtFur2.Enabled = false;
            dtFPP.Enabled = false;

            txtDetalleAdicionalFUR_FPP.Enabled = false;
            TxtFrecuenciaCardiacaFetal.Enabled = false;

            rdSiMF.Enabled = false;
            rdNoMF.Enabled = false;

            txtAlturaUterina.Enabled = false;
            txtUltrasonido.Enabled = false;

            tobCambiarOpcion.Enabled = false;
            tobUsarFUR.Enabled = false;
        }   

        private void DesbloquearCampos()
        {
            dtFUR.Enabled = true;
            txtAmenorrea.Enabled = true;
            txtDetalleMenstruacion.Enabled = true;

            cmbMetodoAnticonceptivo.Enabled = true;
            txtDetalleMetodoAnticonceptivo.Enabled = true;

            txtEditDetalleConsulta.Enabled = true;
            txtEditDiagnostico.Enabled = true;
            txtEditTratamiento.Enabled = true;

            txtIMC.Enabled = true;
            TxtNombre.Enabled = true;
            TxtNumExpediente.Enabled = true;
            txtPesoHabitual.Enabled = true;
            txtPresionArterial.Enabled = true;
            txtTalla.Enabled = true;

            txtDiagnosticos.Enabled = true;

            tobBuscarPaciente.Enabled = true;

            treeView1.Enabled = true;
            txtDetalleAdicional.Enabled = true;

            treeView2.Enabled = true;
            txtDetalleAdicionalExamenes.Enabled = true;

            //btnAgregarImagen.Enabled = true;
            //btnPhotoAlbum.Enabled = true;
            //tobEliminarImage.Enabled = true;
            //tobMagnifyImage.Enabled = true;

            btnAgregarVideo.Enabled = true;
            btnReproducirVideo.Enabled = true;

            //Con Embarazo
            txtIMC2.Enabled = true;
            txtPesoHabitual2.Enabled = true;
            txtPresionArterial2.Enabled = true;
            txtTalla2.Enabled = true;
            txtHabitual3.Enabled = true;

            if (modificar == false)
            {
                dtFur2.Enabled = true;
                dtFPP.Enabled = true;
                tobCambiarOpcion.Enabled = true;

                btnInfoEmbarazo.Visible = true;
            }

            txtDetalleAdicionalFUR_FPP.Enabled = true;
            TxtFrecuenciaCardiacaFetal.Enabled = true;

            rdSiMF.Enabled = true;
            rdNoMF.Enabled = true;

            txtAlturaUterina.Enabled = true;
            txtUltrasonido.Enabled = true;

            txtEditDetalleConsulta.UnProtectText();
            txtEditDiagnostico.UnProtectText();
            txtEditTratamiento.UnProtectText();

            tobUsarFUR.Enabled = true;
        }

        private void LimpiarCampos()
        {
            lblNumConsulta.Text = "";
            lblFechaConsulta.Text = "";

            dtFUR.Value = DateTime.Today;
            txtAmenorrea.Text = String.Empty;
            txtDetalleMenstruacion.Text = String.Empty;

            cmbMetodoAnticonceptivo.SelectedIndex = -1;
            txtDetalleMetodoAnticonceptivo.Text = String.Empty;
            txtIMC.Text = String.Empty;
            TxtNombre.Text = String.Empty;
            TxtNumExpediente.Text = String.Empty;
            txtPesoHabitual.Text = String.Empty;
            txtPresionArterial.Text = String.Empty;
            txtTalla.Text = String.Empty;

            txtDiagnosticos.Text = "";

            txtEditDetalleConsulta.Limpiar();
            txtEditDiagnostico.Limpiar();
            txtEditTratamiento.Limpiar();

            //Gabinete
            txtDetalleAdicional.Text = String.Empty;

            foreach (TreeNode oNodo in treeView1.Nodes)
            {
                foreach (TreeNode oNodo2 in oNodo.Nodes)
                {
                    oNodo2.ImageIndex = 1;
                    oNodo2.SelectedImageIndex = 1;
                }
            }

            treeView1.SelectedNode = null;
            object sender = new object();
            EventArgs e = new EventArgs();

            lblDescripcionEstudio.Text = "";

            toolStripButton1_Click(sender, e);

            //Exámenes de Laboratorio
            txtDetalleAdicionalExamenes.Text = String.Empty;

            foreach (TreeNode oNodo in treeView2.Nodes)
            {
                foreach (TreeNode oNodo2 in oNodo.Nodes)
                {
                    oNodo2.ImageIndex = 1;
                    oNodo2.SelectedImageIndex = 1;
                }
            }

            treeView2.SelectedNode = null;

            lblDescripcionExamen.Text = "";

            //flowLayoutPanel1.Controls.Clear();

            lstVideos.Items.Clear();

            tobContraerExamenes_Click(sender, e);

            //Con Embarazo

            txtIMC2.Text = "";
            txtPesoHabitual2.Text = "";
            txtPresionArterial2.Text = "";
            txtTalla2.Text = "";
            txtHabitual3.Text = "";

            dtFur2.Value = DateTime.Today;
            dtFPP.Value = DateTime.Today;

            txtDetalleAdicionalFUR_FPP.Text = "";
            TxtFrecuenciaCardiacaFetal.Text = "";

            rdSiMF.Checked = true;
            rdNoMF.Checked = false;

            txtAlturaUterina.Text = "";
            txtUltrasonido.Text = "";

            pBoxEmbarazoActivo.Visible = false;

            txtEditDetalleConsulta.EstableceValoresDefault();
            txtEditDiagnostico.EstableceValoresDefault();            

            txtEditTratamiento.ChangeFont("Segoe Print");
            txtEditTratamiento.FontSize(14);
            txtEditTratamiento.ActivateBulletsAtStartup();
        }

        #region Botones avanzar y retorceder en opciones

        //*********************************************************************************************************
        //**************** Detalle--><--Diagnosticos--><--Tratamiento--><--Exámenes--><--Gabinete *****************
        //*********************************************************************************************************

        private void tobForward_Click(object sender, EventArgs e)
        {
            //-2408, 0
            if (panelOpciones.Location.X == 0)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                t.add(panelOpciones, "Left", -480);
                t.run();

                //Ya está en los diagnósticos
                toolTip1.SetToolTip(tobForward, "Avance al Tratamiento de la Consulta");
                toolTip1.SetToolTip(tobBack, "Retroceda al Detalle de la Consulta");
            }
            else if (panelOpciones.Location.X == -480)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                t.add(panelOpciones, "Left", -960);
                t.run();

                //Ya está en el Tratamiento
                toolTip1.SetToolTip(tobForward, "Avance a los Exámenes de la Consulta");
                toolTip1.SetToolTip(tobBack, "Retroceda a los Diagnósticos de la Consulta");
            }
            else if (panelOpciones.Location.X == -960)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                t.add(panelOpciones, "Left", -1443);
                t.run();

                toolTip1.SetToolTip(tobForward, "Avance al Gabinete de la Consulta");
                toolTip1.SetToolTip(tobBack, "Retroceda al Tratamiento de la Consulta");
            }
            else if (panelOpciones.Location.X == -1443)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                t.add(panelOpciones, "Left", -1924);
                t.run();

                toolTip1.SetToolTip(tobForward, "Avance a las Imágenes de la Consulta");
                toolTip1.SetToolTip(tobBack, "Retroceda a los Exámenes de la Consulta");
            }//-2408, 0
            else if (panelOpciones.Location.X == -1924)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                t.add(panelOpciones, "Left", -2408);
                t.run();

                toolTip1.SetToolTip(tobForward, "Avance a los Videos de la Consulta");
                toolTip1.SetToolTip(tobBack, "Retroceda al Gabinete  de la Consulta");
            }//-2889, 0
            else if (panelOpciones.Location.X == -2408)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                t.add(panelOpciones, "Left", -2889);
                t.run();

                toolTip1.SetToolTip(tobForward, "");
                toolTip1.SetToolTip(tobBack, "Retroceda a las Imágenes de la Consulta");
            }
        }

        private void tobBack_Click(object sender, EventArgs e)
        {
            //
            if (panelOpciones.Location.X == -2889)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                t.add(panelOpciones, "Left", -2408);
                t.run();

                //Ya está en el Gabinete
                toolTip1.SetToolTip(tobForward, "Avance a las Videos de la Consulta");
                toolTip1.SetToolTip(tobBack, "Retroceda a los Exámenes de la Consulta");
            }
            else if (panelOpciones.Location.X == -2408)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                t.add(panelOpciones, "Left", -1924);
                t.run();

                //Ya está en el Gabinete
                toolTip1.SetToolTip(tobForward, "Avance a las Imágenes de la Consulta");
                toolTip1.SetToolTip(tobBack, "Retroceda a los Exámenes de la Consulta");
            }
            else if (panelOpciones.Location.X == -1924)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                t.add(panelOpciones, "Left", -1443);
                t.run();

                //Ya está en los exámenes
                toolTip1.SetToolTip(tobForward, "Avance al Gabinete de la Consulta");
                toolTip1.SetToolTip(tobBack, "Retroceda al Tratamiento de la Consulta");
            }
            else if (panelOpciones.Location.X == -1443)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                t.add(panelOpciones, "Left", -960);
                t.run();

                //Ya está en Tratamiento
                toolTip1.SetToolTip(tobForward, "Avance a los Exámenes de la Consulta");
                toolTip1.SetToolTip(tobBack, "Retroceda a los Diagnósticos de la Consulta");
            }
            else if (panelOpciones.Location.X == -960)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                t.add(panelOpciones, "Left", -480);
                t.run();

                //Ya está en Diagnósticos
                toolTip1.SetToolTip(tobForward, "Avance al Tratamiento de la Consulta");
                toolTip1.SetToolTip(tobBack, "Retroceda al Detalle de la Consulta");
            }
            else if (panelOpciones.Location.X == -480)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                t.add(panelOpciones, "Left", 0);
                t.run();

                //Ya está en el Detalle
                toolTip1.SetToolTip(tobForward, "Avance a los Diagnósticos de la Consulta");
                toolTip1.SetToolTip(tobBack, "");
            }
        }

        #endregion

        #region Modos

        private void ModoEscritura_Modificacion()
        {
            tobNuevo.Enabled = false;
            tobModificar.Enabled = false;
            tobGuardar.Enabled = true;
            tobCancelar.Enabled = true;
            tobPrimero.Enabled = false;
            tobAnterior.Enabled = false;
            tobSiguiente.Enabled = false;
            tobUltimo.Enabled = false;
            tobIniciarConsulta.Enabled = false;
            tobEjecutarConsulta.Enabled = false;
            tobCancelarConsulta.Enabled = false;

            tobGuardarDiagnostico.Enabled = true;

            btnInfoEmbarazo.Visible = false;

            oArregloDiagnosticos.Clear();

            if (nuevo == true)
            {
                btnInfoEmbarazo.Visible = false;

                lblFURNoDisponible.Visible = false;                
                tobUsarFUR.Image = Properties.Resources.ok__1_;
                tobUsarFUR.ToolTipText = "Dé click para No Utilizar un valor específico de F.U.R";
                furDisponible = true;
            }

            tobUsarFUR.Enabled = true;

            if (nuevo == true)
            {
                oArregloBytesImagenes.Clear();

                LlenarListaExamenes(true);
                LlenarLista(true);

                totalFilas = 0;
            }

            auxFila = -1;

            if (softNetImageViewer1 != null)
                softNetImageViewer1.EnableButtons(true, true, true, true);

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
        }

        private void ModoBloqueo()
        {
            nuevo = false;
            modificar = false;

            tobNuevo.Enabled = true;

            if (lblNumConsulta.Text.Trim() != "")
                tobModificar.Enabled = true;
            else
                tobModificar.Enabled = false;

            tobGuardar.Enabled = false;
            tobCancelar.Enabled = false;

            if (lblNumConsulta.Text.Trim() != "")
            {
                tobPrimero.Enabled = true;
                tobAnterior.Enabled = true;
                tobSiguiente.Enabled = true;
                tobUltimo.Enabled = true;
            }
            else
            {
                tobPrimero.Enabled = false;
                tobAnterior.Enabled = false;
                tobSiguiente.Enabled = false;
                tobUltimo.Enabled = false;
            }

            tobIniciarConsulta.Enabled = true;
            tobEjecutarConsulta.Enabled = false;
            tobCancelarConsulta.Enabled = false;

            tobGuardarDiagnostico.Enabled = false;

            tipoConsultaSeleccionada = 0;
            opcionElegida = -1;
            embarazoActivo = -1;

            auxFila = -1;

            dtFur2.Visible = true;
            dtFur2.Enabled = false;
            txtFUR.Visible = false;

            dtFPP.Enabled = false;
            dtFPP.Visible = false;
            txtFPP.Visible = true;

            pesoHabitual = 0;

            oIdDetalleGabinete.Clear();
            oDetalleGabinete.Clear();

            oIdDetalleExamenes.Clear();
            oDetalleExamenes.Clear();

            oArregloDiagnosticos.Clear();
            //oArregloBytesImagenes.Clear();

            if (lblNumConsulta.Text.Trim() != "")
            {
                if (modificar == true)
                    ResetImageControl(true, true, true, true);
                else//estaría en modo de consultA
                {
                    if (softNetImageViewer1 != null)
                        softNetImageViewer1.EnableButtons(false, false, true, true);
                }
            }
            else
                ResetImageControl(false, false, false, false);

            Program.oFrmImagenesConsultas.ResetImageControl();

            btnInfoEmbarazo.Visible = false;

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
        }

        private void ModoConsulta()
        {
            tobNuevo.Enabled = false;
            tobModificar.Enabled = false;
            tobGuardar.Enabled = false;
            tobCancelar.Enabled = false;
            tobPrimero.Enabled = false;
            tobAnterior.Enabled = false;
            tobSiguiente.Enabled = false;
            tobUltimo.Enabled = false;
            tobIniciarConsulta.Enabled = false;
            tobEjecutarConsulta.Enabled = true;
            tobCancelarConsulta.Enabled = true;

            btnInfoEmbarazo.Visible = false;

            tobGuardarDiagnostico.Enabled = false;

            lblFURNoDisponible.Visible = false;
            tobUsarFUR.Enabled = false;
            tobUsarFUR.Image = Properties.Resources.ok__1_;
            tobUsarFUR.ToolTipText = "Dé click para No Utilizar un valor específico de F.U.R";
            furDisponible = true;
        }

        #endregion

        #region Eventos Click de la barra de herramientas

        private void tobNuevo_Click(object sender, EventArgs e)
        {
            //FrmBlackBackground oFrmBlackBackground = new FrmBlackBackground();
            //oFrmBlackBackground.Show();
            frmTipoConsulta ofrmTipoConsulta = new frmTipoConsulta();
            ofrmTipoConsulta.ShowDialog(this);
            //oFrmBlackBackground.Close();

            tipoConsultaSeleccionada = ofrmTipoConsulta.OpcionElegida;

            if (tipoConsultaSeleccionada == 1 || tipoConsultaSeleccionada == 2)
            {
                nuevo = true;
                modificar = false;

                ModoEscritura_Modificacion();

                DesbloquearCampos();
                LimpiarCampos();

                lstGabineteConsulta.Visible = false;
                panelGabineteConsulta.Visible = true;

                lstExamenesConsulta.Visible = false;
                panelExamenes.Visible = true;
                
                if (panelOpciones.Location.X != 0)
                {
                    Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                    t.add(panelOpciones, "Left", 0);
                    t.run();
                }

                txtEditDetalleConsulta.TextForeColor(Color.Black);
                txtEditDiagnostico.TextForeColor(Color.Black);
                txtEditTratamiento.TextForeColor(Color.Black);

                if (tipoConsultaSeleccionada == 1)
                {
                    cmbMetodoAnticonceptivo.SelectedIndex = cmbMetodoAnticonceptivo.FindStringExact("Ninguno");

                    Transition t3 = new Transition(new TransitionType_EaseInEaseOut(300));
                    t3.add(panelDatosEmbarazo, "Top", this.Size.Height + 300);
                    t3.run();

                    Transition t2 = new Transition(new TransitionType_EaseInEaseOut(300));
                    t2.add(panel2, "Top", 152);
                    t2.run();

                    dtFUR_ValueChanged(sender, e);
                }
                else if (tipoConsultaSeleccionada == 2)
                {
                    opcionElegida = 0;

                    Transition t = new Transition(new TransitionType_EaseInEaseOut(300));
                    t.add(panel2, "Top", this.Size.Height + 300);
                    t.run();

                    Transition t2 = new Transition(new TransitionType_EaseInEaseOut(300));
                    t2.add(panelDatosEmbarazo, "Top", 152);
                    t2.run();

                    dtFur2_ValueChanged(sender, e);
                }
            }            
        }

        /// <summary>
        /// Limpia el arreglo de diagnósticos y lo llena con los diagnósticos encontrados en el campo correspondiente de diagnósticos
        /// </summary>
        private void DeterminaDiagnosticosUtilizados()
        {
            string[] lines = txtEditDiagnostico.TextLines();
            oArregloDiagnosticos.Clear();

            string auxCadena = "";
            string oCaracter = "";
            for (int i = 0; i < lines.Length; )
            {
                int index = 0;
                index = lines[i].IndexOf("{");
                auxCadena = "";

                if (index != -1)
                {
                    for (int c = 0; c < lines.Length; )
                    {
                        index++;
                        oCaracter = lines[i].Substring(index, 1);

                        if (oCaracter != "}")
                            auxCadena += oCaracter;
                        else
                        {
                            auxCadena += oCaracter;

                            if (auxCadena.EndsWith("}"))
                                auxCadena = auxCadena.Substring(0, auxCadena.Length - 1);

                            oArregloDiagnosticos.Add(auxCadena.Trim());
                            break;
                        }
                    }
                }
                i++;
            }
        }

        private void tobModificar_Click(object sender, EventArgs e)
        {
            bool continuar = false;

            FrmSolicitudAdmin oFrmSolicitudAdmin = new FrmSolicitudAdmin();
            oFrmSolicitudAdmin.ShowDialog();

            if (FrmSolicitudAdmin.Continuar == true)
                continuar = true;
            else
            {
                MessageBox.Show(this, "No se puede continuar con estas acciones hasta que un administrador del sistema otorgue la autorización necesaria, ya que así lo establecen los permisos de usuario establecidos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                continuar = false;
            }

            if (continuar == true)
            {
                nuevo = false;
                modificar = true;

                ModoEscritura_Modificacion();
                DesbloquearCampos();

                LlenarListaExamenes(false);
                SeñalaExamenesSeleccionados_Modificacion();

                LlenarLista(false);
                SeñalaGabinetesSeleccionados_Modificacion();

                DeterminaDiagnosticosUtilizados();

                TxtNumExpediente.Enabled = false;
                TxtNombre.Enabled = false;
                tobBuscarPaciente.Enabled = false;

                lstGabineteConsulta.Visible = false;
                panelGabineteConsulta.Visible = true;

                lstExamenesConsulta.Visible = false;
                panelExamenes.Visible = true;
            }
        }

        private bool VerificaDatos()
        {
            bool continuar = true;

            if (TxtNumExpediente.Text.Trim() == String.Empty)
            {
                MessageBox.Show(this, "Aún no se ha seleccionado la paciente para la cual se está generando esta consulta, verifique los valores para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                continuar = false;
            }

            if (tipoConsultaSeleccionada == 1)
            {
                if (cmbMetodoAnticonceptivo.SelectedValue == null || cmbMetodoAnticonceptivo.SelectedIndex == -1)
                {
                    MessageBox.Show(this, "No se ha establecido el Método Anticonceptivo utilizado, si desea establecer que no se está utilizando ningún método en el momento por favor seleccione el valor de \"Ninguno\". Verifique los valores para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    continuar = false;
                }

                if (txtIMC.Text.Trim() == "" || txtIMC.Text.Trim() == "0")
                {
                    MessageBox.Show(this, "No se ha especificado el Índice de Masa Corporal, verifique los valores para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    continuar = false;
                }

                if (txtPresionArterial.Text.Trim() == "")
                {
                    MessageBox.Show(this, "No se ha especificado un valor en el campo de la Presión Arterial, verifique los valores para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    continuar = false;
                }

                //Si sí presenta valor en Menarca y el valor de la Amenorrea es nulo entonces da error
                if (presentaMenarca == true)
                {
                    if (txtAmenorrea.Text == "")
                    {
                        MessageBox.Show(this, "El valor en amenorrea no puede ser nulo, verifique el valor de la Fecha de Última Menstruación para establecer dicho valor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        continuar = false;
                    }
                }
            }
            else if (tipoConsultaSeleccionada == 2)
            {
                if (txtIMC2.Text.Trim() == "" || txtIMC2.Text.Trim() == "0")
                {
                    MessageBox.Show(this, "No se ha especificado el Índice de Masa Corporal, verifique los valores para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtPesoHabitual2.Focus();
                    continuar = false;
                }
                
                if (txtPresionArterial2.Text.Trim() == "")
                {
                    MessageBox.Show(this, "El valor de la presión arterial no puede ser nulo, verifique los valores para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtPresionArterial2.Focus();
                    continuar = false;
                }

                if (dtFPP.Value.Date == dtFUR.Value.Date)
                {
                    MessageBox.Show(this, "Los valores de la Fecha de la Última Menstruación y la Fecha Probable de Parto poseen el mismo valor, verifique los valores para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    continuar = false;
                }

                if (TxtFrecuenciaCardiacaFetal.Text.Trim() == "")
                {
                    MessageBox.Show(this, "El valor de la Frecuencia Cardiaca Fetal no puede ser nulo, verifique los valores para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    TxtFrecuenciaCardiacaFetal.Focus();
                    continuar = false;
                }

                if (rdSiMF.Checked == false && rdNoMF.Checked == false)
                {
                    MessageBox.Show(this, "Debe seleccionar una opción para determinar si se presenta o no Movimiento Fetal, verifique los valores para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    rdSiMF.Focus();
                    continuar = false;
                }

                if (txtAlturaUterina.Text.Trim() == "")
                {
                    MessageBox.Show(this, "El valor de la Altura Uterina no puede ser nulo, verifique los valores para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtAlturaUterina.Focus();
                    continuar = false;
                }

                if (presentaMenarca == false)
                {
                    MessageBox.Show(this, "Este paciente no presenta ningún valor en la menarca por lo que no podrá generar ninguna consulta con embarazo hasta que se procedan a modificar dichos datos. Seleccione la opción de \"Antecedentes Obstétricos y Ginecológicos\" en la barra de acceso rápido para realizar estas acciones.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    continuar = false;
                }
            }

            return continuar;
        }

        byte[] ReadFile(string sPath)
        {
            try
            {
                //Initialize byte array with a null value initially.
                byte[] data = null;

                //Use FileInfo object to get file size.
                FileInfo fInfo = new FileInfo(sPath);
                long numBytes = fInfo.Length;

                //Open FileStream to read file
                FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

                //Use BinaryReader to read file stream into byte array.
                BinaryReader br = new BinaryReader(fStream);

                //When you use BinaryReader, you need to supply number of bytes to read from file.
                //In this case we want to read entire file. So supplying total number of bytes.
                data = br.ReadBytes((int)numBytes);
                return data;
            }
            catch
            {
                return null;
            }
        }

        private string crearCarpetaAppdata()
        {
            try
            {
                string directoryString = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData).ToString() + "\\SoftNet G-Clinic\\Video Files";

                if (!Directory.Exists(directoryString))
                    Directory.CreateDirectory(directoryString);

                return directoryString;
            }
            catch
            {
                return "";
            }
        }

        private void tobGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Está completamente seguro que los datos por almacenar son correctos?. Presione \"No\" si desea modificar los datos existentes antes de guardar la consulta.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (VerificaDatos() == true)
                {                    
                    //Se utilizan estas variables debido a que en MODO BLOQUEO se incializan y después de guardar las consultas se ingresa a dicho modo
                    //pero siempre queda la opción de modificar los valores entonces se necesitan esos valores, igual esos valores al generar una 
                    //nueva consulta se inicializan
                    int auxTipoConsultaSeleccionada = tipoConsultaSeleccionada;
                    int auxEmbarazoActivo = embarazoActivo;
                    double auxPesoHabitual = pesoHabitual;

                    Program.oFrmWaitSaving = new FrmWaitSaving();
                    Program.oFrmWaitSaving.Show();
                    Program.oFrmWaitSaving.Refresh();
                    Program.oFrmWaitSaving.Update();

                    Program.oCConsultas.NumExpediente = Convert.ToInt32(TxtNumExpediente.Text.Trim());

                    if (tipoConsultaSeleccionada == 1)
                    {
                        Program.oCConsultas.TipoConsulta = "0";//Sin embarazo

                        if (panelCancelMenstruacion.Visible == true)//si posee datos de la menstruación...
                            Program.oCConsultas.FechaUltimaMenstruacion = dtFUR.MinDate;
                        else
                        {
                            if (furDisponible == true)
                                Program.oCConsultas.FechaUltimaMenstruacion = dtFUR.Value.Date;
                            else
                                Program.oCConsultas.FechaUltimaMenstruacion = dtFUR.MinDate.AddYears(1);
                        }

                        Program.oCConsultas.Amenorrea = txtAmenorrea.Text.Trim().Replace(",", ".");
                        Program.oCConsultas.Detalle_Fur = txtDetalleMenstruacion.Text.Trim();

                        Program.oCConsultas.Peso = txtPesoHabitual.Text.Trim().Replace(",", ".");
                        Program.oCConsultas.Talla = txtTalla.Text.Trim().Replace(",", ".");
                        Program.oCConsultas.IMC = txtIMC.Text.Trim().Replace(",", ".");
                        Program.oCConsultas.PresionArterial = txtPresionArterial.Text.Trim();

                        Program.oCConsultas.IdMetodo = cmbMetodoAnticonceptivo.SelectedValue.ToString().Trim();
                        Program.oCConsultas.DetalleAnticoncepcion = txtDetalleMetodoAnticonceptivo.Text.Trim();
                    }
                    else if (tipoConsultaSeleccionada == 2)
                    {
                        Program.oCConsultas.TipoConsulta = "1";//CON embarazo

                        Program.oCConsultas.FechaUltimaMenstruacion = dtFur2.Value.Date;

                        Program.oCConsultas.Amenorrea = lblAmenorrea2.Text.Trim().Replace(",", ".");
                        Program.oCConsultas.Detalle_Fur = txtDetalleMenstruacion.Text.Trim();

                        Program.oCConsultas.Peso = txtPesoHabitual2.Text.Trim().Replace(",", ".");
                        Program.oCConsultas.Talla = txtTalla2.Text.Trim().Replace(",", ".");
                        Program.oCConsultas.IMC = txtIMC2.Text.Trim().Replace(",", ".");
                        Program.oCConsultas.PresionArterial = txtPresionArterial2.Text.Trim();

                        cmbMetodoAnticonceptivo.SelectedIndex = cmbMetodoAnticonceptivo.FindStringExact("Ninguno");
                        Program.oCConsultas.IdMetodo = cmbMetodoAnticonceptivo.SelectedValue.ToString().Trim();

                        Program.oCConsultas.DetalleAnticoncepcion = "";
                    }

                    path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");

                    if (path != "")
                    {
                        txtEditDetalleConsulta.GuardarArchivoTemporal(path + "\\Detalle_Consulta.rtf");
                        txtEditTratamiento.GuardarArchivoTemporal(path + "\\Tratamiento.rtf");
                        txtEditDiagnostico.GuardarArchivoTemporal(path + "\\Diagnostico.rtf");
                    }

                    Program.oCConsultas.DetalleConsulta = Metodos_Globales.ReadFile(path + "\\Detalle_Consulta.rtf");
                    Program.oCConsultas.Tratamiento = Metodos_Globales.ReadFile(path + "\\Tratamiento.rtf");
                    Program.oCConsultas.Diagnostico = Metodos_Globales.ReadFile(path + "\\Diagnostico.rtf");

                    //fechaConsulta = Program.oCConsultas.FechaConsulta;

                    if (nuevo == true)
                    {
                        fechaConsulta = DateTime.Now;
                        Program.oCConsultas.FechaConsulta = fechaConsulta;

                        Program.oCConsultas.Insertar();
                    }
                    else if (modificar == true)
                    {
                        Program.oCConsultas.IdConsulta = Convert.ToInt64(lblNumConsulta.Text.Trim());
                        Program.oCConsultas.FechaConsulta = fechaConsulta;

                        Program.oCConsultas.Modificar();
                    }

                    if (Program.oPersistencia.IsError == false)
                    {
                        if (nuevo == true)
                            lblNumConsulta.Text = Program.oCConsultas.Max_Consulta();

                        #region Datos con Embarazo

                        if (tipoConsultaSeleccionada == 2)//Con Embarazo
                        {
                            oCConsultaEmbarazo.IdConsulta = Convert.ToInt64(lblNumConsulta.Text.Trim());

                            if (oFechaIniEmbarazo != DateTime.MinValue)
                                oCConsultaEmbarazo.FechaInicialEmbarazo = oFechaIniEmbarazo;
                            else
                            {
                                embarazoActivo = 0;
                                oCConsultaEmbarazo.FechaInicialEmbarazo = dtFur2.Value.Date;
                            }

                            oCConsultaEmbarazo.Fpp = dtFPP.Value.Date;
                            oCConsultaEmbarazo.DetalleAdicional = txtDetalleAdicionalFUR_FPP.Text.Trim();
                            //oCConsultaEmbarazo.SemanasAmenorrea = lblAmenorrea2.Text.Trim();
                            oCConsultaEmbarazo.FrecuenciaCardiacaFetal = Convert.ToInt32(TxtFrecuenciaCardiacaFetal.Text.Trim());

                            if (rdSiMF.Checked == true)
                                oCConsultaEmbarazo.MovimientoFetal = true;
                            else if (rdNoMF.Checked == true)
                                oCConsultaEmbarazo.MovimientoFetal = false;

                            oCConsultaEmbarazo.AlturaUterina = txtAlturaUterina.Text.Trim();
                            oCConsultaEmbarazo.Ultrasonido = txtUltrasonido.Text.Trim();

                            if (embarazoActivo == 0)
                                oCConsultaEmbarazo.EstadoEmbarazo = "Inicializado";
                            else if (embarazoActivo == 1)
                                oCConsultaEmbarazo.EstadoEmbarazo = "Activo";
                            else if (embarazoActivo == 2)
                                oCConsultaEmbarazo.EstadoEmbarazo = "Finalizado";

                            if (nuevo == true)
                                oCConsultaEmbarazo.Insertar();
                            else if (modificar == true)
                                oCConsultaEmbarazo.Modificar();

                            if (Program.oPersistencia.IsError == true)
                            {
                                MessageBox.Show(this, "Se produjo un error en la inserción de los valores del embarazo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                        }

                        #endregion

                        if (nuevo == true)
                        {
                            //lblNumConsulta.Text = Program.oCConsultas.Max_Consulta();
                            lblFechaConsulta.Text = Program.oCConsultas.FechaConsulta.ToLongDateString() + " a las " + Program.oCConsultas.FechaConsulta.ToLongTimeString();

                            DeterminaDiagnosticosUtilizados();

                            //Agrega los diagnósticos por consulta
                            if (oArregloDiagnosticos.Count > 0)
                            {
                                oCDiagnosticosConsulta.IdConsulta = lblNumConsulta.Text.Trim();

                                foreach (string oIdDagnostico in oArregloDiagnosticos)
                                {
                                    int found = -1;
                                    string auxCadena = "";

                                    auxCadena = "{" + oIdDagnostico + "}";
                                    found = txtEditDiagnostico.FindText(auxCadena);

                                    if (found != -1)
                                    {
                                        oCDiagnosticosConsulta.IdDiagnostico = oIdDagnostico.Trim();
                                        oCDiagnosticosConsulta.Insertar();
                                    }
                                }
                            }

                            #region Guarda los Exámenes de Laboratorio

                            oCExamenesConsulta.IdConsulta = lblNumConsulta.Text.Trim();

                            int index = 0;
                            foreach (string oString in oIdDetalleExamenes)
                            {
                                oCExamenesConsulta.IdExamen = oString.Trim();

                                if (oIdDetalleExamenes.IndexOf(oString.Trim()) != -1)
                                    oCExamenesConsulta.DetalleAdicional = oDetalleExamenes[index].ToString().Trim();
                                else
                                    oCExamenesConsulta.DetalleAdicional = "";

                                //Se establece estático en cero porque es el estado inicial del Examen ya que se acaba 
                                //de solicitar al paciente para que se lo realice...
                                oCExamenesConsulta.Estado = "0";
                                oCExamenesConsulta.FechaResultados = dtFUR.MinDate;
                                oCExamenesConsulta.DetalleResultados = "";

                                oCExamenesConsulta.Insertar();

                                index++;
                            }

                            #endregion

                            #region Guarda el Gabinete

                            oCGabineteConsulta.IdConsulta = lblNumConsulta.Text.Trim();

                            index = 0;
                            foreach (string oString in oIdDetalleGabinete)
                            {
                                oCGabineteConsulta.IdGabinete = oString.Trim();

                                if (oIdDetalleGabinete.IndexOf(oString.Trim()) != -1)
                                    oCGabineteConsulta.DetalleAdicional = oDetalleGabinete[index].ToString().Trim();
                                else
                                    oCGabineteConsulta.DetalleAdicional = "";

                                //Se establece estático en cero porque es el estado inicial del Gabinete ya que se acaba 
                                //de solicitar al paciente para que se lo realice...
                                oCGabineteConsulta.Estado = "0";
                                oCGabineteConsulta.FechaResultados = dtFUR.MinDate;
                                oCGabineteConsulta.DetalleResultados = "";

                                oCGabineteConsulta.Insertar();

                                index++;
                            }

                            #endregion

                            #region Guarda las imágenes de la consulta

                            if (softNetImageViewer1.GlobalElementsDetails.Count > 0)
                            {
                                oCImagenesConsulta.IdConsulta = lblNumConsulta.Text.Trim();

                                foreach (GlobalElementsValues oElement in softNetImageViewer1.GlobalElementsDetails)//  flowLayoutPanel1.Controls.Count > 0)
                                {
                                    oCImagenesConsulta.Foto = oElement.OBytes; //ReadFile(oControl.Tag.ToString().Trim());
                                    oCImagenesConsulta.Insertar();
                                }
                            }

                            #endregion

                            #region Guarda los videos de la consulta

                            try
                            {
                                path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\VideoFiles\\Consulta " + lblNumConsulta.Text.Trim() + " - Expediente " + TxtNumExpediente.Text.Trim());
                                string newPath = "";

                                foreach (ListViewItem oItem in lstVideos.Items)
                                {
                                    newPath = path + "\\" + oItem.SubItems[0].Text.Trim();
                                    File.Copy(oItem.SubItems[1].Text.Trim(), newPath);

                                    oCVideosConsulta.IdConsulta = lblNumConsulta.Text.Trim();
                                    oCVideosConsulta.UrlVideo = newPath.Trim();

                                    oCVideosConsulta.Insertar();
                                }
                            }
                            catch { }

                            #endregion
                        }
                        else if (modificar == true)
                        {
                            DeterminaDiagnosticosUtilizados();

                            Program.oComprobaciones.Borrar("Diagnosticos_Consulta", "id_consulta = " + lblNumConsulta.Text.Trim());

                            if (Program.oPersistencia.IsError == false)
                            {
                                //Agrega los diagnósticos por consulta
                                if (oArregloDiagnosticos.Count > 0)
                                {
                                    oCDiagnosticosConsulta.IdConsulta = lblNumConsulta.Text.Trim();

                                    int found = -1;
                                    string auxCadena = "";
                                    foreach (string oIdDagnostico in oArregloDiagnosticos)
                                    {
                                        found = -1;
                                        auxCadena = "";

                                        auxCadena = "{" + oIdDagnostico + "}";
                                        found = txtEditDiagnostico.FindText(auxCadena);

                                        if (found != -1)
                                        {
                                            oCDiagnosticosConsulta.IdDiagnostico = oIdDagnostico.Trim();
                                            oCDiagnosticosConsulta.Insertar();
                                        }
                                    }
                                }
                            }

                            //////////////////////////////////////////////////////////////////////
                            #region Elimina y Guarda los Exámenes de Laboratorio

                            ArrayList oArregloEncontrados = new ArrayList();
                            ArrayList oArregloNoEncontrados = new ArrayList();
                            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Examenes_Consulta '" + lblNumConsulta.Text.Trim() + "'", "Examenes_Consulta a, Examenes_Laboratorio b");

                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                if (oIdDetalleExamenes.Contains(dr[0].ToString().Trim()))
                                    oArregloEncontrados.Add(dr[0].ToString().Trim());
                                else
                                    oArregloNoEncontrados.Add(dr[0].ToString().Trim());
                            }

                            oCExamenesConsulta.IdConsulta = lblNumConsulta.Text.Trim();

                            int index = 0;
                            foreach (string oString in oIdDetalleExamenes)
                            {
                                if (!oArregloEncontrados.Contains(oString.Trim()))
                                {
                                    //Program.oComprobaciones.Borrar("Examenes_Consulta" ,"id_consulta = " + lblNumConsulta.Text.Trim()); 

                                    oCExamenesConsulta.IdExamen = oString.Trim();

                                    if (oIdDetalleExamenes.IndexOf(oString.Trim()) != -1)
                                        oCExamenesConsulta.DetalleAdicional = oDetalleExamenes[index].ToString().Trim();
                                    else
                                        oCExamenesConsulta.DetalleAdicional = "";

                                    //Se establece estático en cero porque es el estado inicial del Examen ya que se acaba 
                                    //de solicitar al paciente para que se lo realice...
                                    oCExamenesConsulta.Estado = "0";
                                    oCExamenesConsulta.FechaResultados = dtFUR.MinDate;
                                    oCExamenesConsulta.DetalleResultados = "";

                                    oCExamenesConsulta.Insertar();
                                }
                                index++;
                            }

                            foreach (string oString in oArregloNoEncontrados)
                                Program.oComprobaciones.Borrar("Examenes_Consulta", "id_examen = " + oString.Trim() + " and id_consulta = " + lblNumConsulta.Text.Trim());

                            #endregion

                            #region Elimina y Guarda el Gabinete

                            //Program.oPersistencia.ejecutarSQL("sp_D_Gabinetes_Consulta '" + lblNumConsulta.Text.Trim() + "'");

                            //if (Program.oPersistencia.IsError == false)
                            //{
                            //}

                            //oCGabineteConsulta.IdConsulta = lblNumConsulta.Text.Trim();

                            //index = 0;
                            //foreach (string oString in oIdDetalleGabinete)
                            //{
                            //    oCGabineteConsulta.IdGabinete = oString.Trim();

                            //    if (oIdDetalleGabinete.IndexOf(oString.Trim()) != -1)
                            //        oCGabineteConsulta.DetalleAdicional = oDetalleGabinete[index].ToString().Trim();
                            //    else
                            //        oCGabineteConsulta.DetalleAdicional = "";
                                
                            //    //Se establece estático en cero porque es el estado inicial del Gabinete ya que se acaba 
                            //    //de solicitar al paciente para que se lo realice...
                            //    oCGabineteConsulta.Estado = "0";
                            //    oCGabineteConsulta.FechaResultados = dtFUR.MinDate;
                            //    oCGabineteConsulta.DetalleResultados = "";

                            //    oCGabineteConsulta.Insertar();

                            //    index++;
                            //}
                            ////}

                            #endregion

                            ArrayList oArregloGabEncontrados = new ArrayList();
                            ArrayList oArregloGabNoEncontrados = new ArrayList();
                            DataSet ds2 = Program.oPersistencia.ejecutarSQLListas("sp_S_Gabinete_Consulta '" + lblNumConsulta.Text.Trim() + "'", "Gabinete_Consulta a, Gabinete b");

                            foreach (DataRow dr in ds2.Tables[0].Rows)
                            {
                                if (oIdDetalleGabinete.Contains(dr[0].ToString().Trim()))
                                    oArregloGabEncontrados.Add(dr[0].ToString().Trim());
                                else
                                    oArregloGabNoEncontrados.Add(dr[0].ToString().Trim());
                            }

                            oCGabineteConsulta.IdConsulta = lblNumConsulta.Text.Trim();

                            index = 0;
                            foreach (string oString in oIdDetalleGabinete)
                            {
                                if (!oArregloGabEncontrados.Contains(oString.Trim()))
                                {
                                    //Program.oComprobaciones.Borrar("Examenes_Consulta" ,"id_consulta = " + lblNumConsulta.Text.Trim()); 

                                    oCGabineteConsulta.IdGabinete = oString.Trim();

                                    if (oIdDetalleGabinete.IndexOf(oString.Trim()) != -1)
                                        oCGabineteConsulta.DetalleAdicional = oDetalleGabinete[index].ToString().Trim();
                                    else
                                        oCGabineteConsulta.DetalleAdicional = "";

                                    //Se establece estático en cero porque es el estado inicial del Examen ya que se acaba 
                                    //de solicitar al paciente para que se lo realice...
                                    oCGabineteConsulta.Estado = "0";
                                    oCGabineteConsulta.FechaResultados = dtFUR.MinDate;
                                    oCGabineteConsulta.DetalleResultados = "";

                                    oCGabineteConsulta.Insertar();
                                }
                                index++;
                            }

                            foreach (string oString in oArregloGabNoEncontrados)
                                Program.oComprobaciones.Borrar("Gabinete_Consulta", "id_gabinete = " + oString.Trim() + " and id_consulta = " + lblNumConsulta.Text.Trim());



                            #region Guarda las imágenes de la consulta

                            Program.oComprobaciones.Borrar("Imagenes_Consulta", "id_consulta = " + lblNumConsulta.Text.Trim());

                            if (Program.oPersistencia.IsError == false)
                            {                                
                                if (softNetImageViewer1.GlobalElementsDetails.Count > 0)
                                {
                                    foreach (GlobalElementsValues oElement in softNetImageViewer1.GlobalElementsDetails)//  flowLayoutPanel1.Controls.Count > 0)
                                    {
                                        oCImagenesConsulta.Foto = oElement.OBytes;
                                        oCImagenesConsulta.Insertar();
                                    }
                                }
                                //if (//flowLayoutPanel1.Controls.Count > 0)
                                //{
                                //    oCImagenesConsulta.IdConsulta = lblNumConsulta.Text.Trim();

                                //    foreach (byte[] oByte in oArregloBytesImagenes)
                                //    {
                                //        oCImagenesConsulta.Foto = (byte[])oByte;
                                //        oCImagenesConsulta.Insertar();
                                //    }
                                //}
                            }
                            #endregion

                            #region Guarda los videos de la consulta

                            try
                            {
                                path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\VideoFiles\\Consulta " + lblNumConsulta.Text.Trim() + " - Expediente " + TxtNumExpediente.Text.Trim());

                                //Directory.Delete(path, true);
                                Program.oComprobaciones.Borrar("Videos_Consulta", "id_consulta = " + lblNumConsulta.Text.Trim());

                                string[] oFiles = Directory.GetFiles(path);

                                bool encontrado = false;
                                for (int i = 0; i < oFiles.Length; )
                                {
                                    foreach (ListViewItem oItem in lstVideos.Items)
                                    {
                                        if (oFiles[i].Trim() == oItem.SubItems[1].Text.Trim())
                                        {
                                            encontrado = true;
                                            break;
                                        }
                                        else
                                            encontrado = false;
                                    }

                                    if (encontrado == false)
                                        File.Delete(oFiles[i].Trim());

                                    i++;
                                }

                                if (Program.oPersistencia.IsError == false)
                                {
                                    string newPath = "";
                                    foreach (ListViewItem oItem in lstVideos.Items)
                                    {
                                        newPath = path + "\\" + oItem.SubItems[0].Text.Trim();

                                        if (!File.Exists(newPath))
                                            File.Copy(oItem.SubItems[1].Text.Trim(), newPath);

                                        oCVideosConsulta.IdConsulta = lblNumConsulta.Text.Trim();
                                        oCVideosConsulta.UrlVideo = newPath.Trim();

                                        oCVideosConsulta.Insertar();
                                    }
                                }
                            }
                            catch { }

                            #endregion

                        }

                        if (Program.oPersistencia.IsError == false)
                        {
                            if (tipoConsultaSeleccionada == 2)//Con Embarazo
                            {
                                if (Convert.ToDouble(txtHabitual3.Text.Trim()) != pesoHabitual)
                                {
                                    if (MessageBox.Show(this, "El valor del peso habitual del paciente ha sido modificado, ¿Desea modificar dichos valores en la ficha clínica del paciente?. Recuerde que dichos valores alterarán de igual manera el I.M.C del paciente.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                    {
                                        string pHabitual = txtHabitual3.Text.Trim();
                                        string talla = Program.oCPacientes.TallaHabitual(TxtNumExpediente.Text.Trim()).ToString();
                                        string IMC = Program.oCPacientes.CalculaIMC(pHabitual, talla).ToString();

                                        pHabitual = txtHabitual3.Text.Trim().Replace(",", ".");
                                        IMC = IMC.Replace(",", ".");

                                        Program.oComprobaciones.Modificar("peso = '" + pHabitual.Trim() + "', imc = '" + IMC.Trim() + "'", "Paciente", "num_expediente = " + TxtNumExpediente.Text.Trim());
                                    }
                                }
                            }

                            TxtNumExpediente_TextChanged(sender, e);//Actualiza el Dock con la información del paciente

                            BloquearCampos();
                            ModoBloqueo();

                            if (totalFilas > 0)
                            {
                                auxFila = fila;
                                oFrmParamBusquedaConsulta.btnBuscar_Click(sender, e);
                            }
                            else
                            {
                                auxFila = -1;
                                drGlobal = null;
                                dt = null;
                            }

                            //LlenaListaExamenesConsulta();
                            //LlenaListaGabineteConsulta();

                            LlenarListaExamenesConsulta();
                            LlenarListaGabineteConsulta();

                            lstExamenesConsulta.Visible = false;
                            lstGabineteConsulta.Visible = false;

                            panelExamenes.Visible = true;
                            panelGabineteConsulta.Visible = true;

                            //if (//flowLayoutPanel1.Controls.Count > 0)
                            //    btnPhotoAlbum.Enabled = true;

                            nuevo = false;
                            modificar = false;

                            tipoConsultaSeleccionada = auxTipoConsultaSeleccionada;
                            embarazoActivo = auxEmbarazoActivo;
                            pesoHabitual = auxPesoHabitual;

                            pBoxEmbarazoActivo.Visible = false;

                            //if (//flowLayoutPanel1.Controls.Count > 0)
                            //{
                            //    int count = 1;//se empieza en uno porque a la hora de pasar el índice para ver la imagen ampliada se le resta 1 
                            //                  //al valor actual
                            //    foreach (Control oControl in //flowLayoutPanel1.Controls)
                            //    {
                            //        oControl.Tag = count.ToString().Trim();
                            //        count++;
                            //    }
                            //}                            

                            Program.oFrmWaitSaving.Close();
                        }
                    }
                }
            }
        }

        private void tobCancelar_Click(object sender, EventArgs e)
        {
            bool continuar = false;

            if (primeraVez == false)
            {
                if (modificar == true)
                {
                    if (MessageBox.Show(this, "¿Realmente desea cancelar la modificación de la consulta? Se cerrará esta consulta inmediatamente después de realizar estas acciones", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        continuar = true;
                }
                else if (nuevo == true)
                {
                    if (MessageBox.Show(this, "¿Realmente desea cancelar la creación de la consulta? Se borrarán todos los datos ingresados inmediatamente después de realizar estas acciones", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        continuar = true;
                }
            }
            else
                continuar = true;

            if (continuar == true)
            {
                txtFoco.Focus();

                LimpiarCampos();
                BloquearCampos();

                ModoBloqueo();

                lstGabineteConsulta.Visible = false;
                panelGabineteConsulta.Visible = true;

                lstExamenesConsulta.Visible = false;
                panelExamenes.Visible = true;

                panelCancelMenstruacion.Visible = false;

                lblFURNoDisponible.Visible = false;
                tobUsarFUR.Enabled = false;
                tobUsarFUR.Image = Properties.Resources.ok__1_;
                tobUsarFUR.ToolTipText = "Dé click para No Utilizar un valor específico de F.U.R";
                furDisponible = true;
            }
        }

        private void tobIniciarConsulta_Click(object sender, EventArgs e)
        {
            oFrmParamBusquedaConsulta.Show(this);
        }
        
        private void MostrarDatos(int pFila)
        {
            try
            {
                drGlobal = null;
                drGlobal = dt.Rows[pFila];

                lblNumConsulta.Text = drGlobal[0].ToString().Trim();
                TxtNumExpediente.Text = drGlobal[1].ToString().Trim();

                TxtNombre.Text = drGlobal[16].ToString().Trim() + " " + drGlobal[17].ToString().Trim();

                //Falta el tipo de consulta
                lblFechaConsulta.Text = Convert.ToDateTime(drGlobal[3]).ToLongDateString() + " a las " + Convert.ToDateTime(drGlobal[3]).ToLongTimeString();
                fechaConsulta = Convert.ToDateTime(drGlobal[3]);

                //Min Date En SQL
                DateTime o = new DateTime(1753, 1, 1);//1/1/1753 12:00:00 AM 
                if (Convert.ToDateTime(drGlobal[4]) == o)
                {
                    panelCancelMenstruacion.Visible = true;
                    dtFUR.Value = Convert.ToDateTime(DateTime.Today);
                    lblFURNoDisponible.Visible = false;
                    tobUsarFUR.Image = Properties.Resources.nok__1_;
                    furDisponible = false;
                }
                else
                {
                    //Indica que la paciente no sabía la fecha de la última menstruación entonces se establece como NO DETERMINADA
                    //por eso se le agrega un año a la fecha mínima para diferenciar de cuando no se sabe a cuando no existe en cuyo caso
                    //saldría el CANCELAR sobre los campos...
                    if (Convert.ToDateTime(drGlobal[4]) != dtFUR.MinDate.AddYears(1))
                    {
                        panelCancelMenstruacion.Visible = false;
                        dtFUR.Value = Convert.ToDateTime(drGlobal[4]);                        
                        lblFURNoDisponible.Visible = false;
                        tobUsarFUR.Image = Properties.Resources.ok__1_;
                        tobUsarFUR.ToolTipText = "Dé click para No Utilizar un valor específico de F.U.R";
                        furDisponible = true;
                    }
                    else
                    {
                        panelCancelMenstruacion.Visible = false;
                        dtFUR.Value = Convert.ToDateTime(drGlobal[4]);
                        lblFURNoDisponible.Visible = true;
                        tobUsarFUR.Image = Properties.Resources.nok__1_;
                        tobUsarFUR.ToolTipText = "Dé click para Utilizar un valor específico de F.U.R";
                        furDisponible = false;
                    }
                }

                if (Convert.ToInt32(drGlobal[2]) == 0)
                    tipoConsultaSeleccionada = 1;
                else if (Convert.ToInt32(drGlobal[2]) == 1)
                    tipoConsultaSeleccionada = 2;

                if (drGlobal[2].ToString() == "0")//Tipo de Consulta SIN Embarazo
                {
                    txtAmenorrea.Text = drGlobal[5].ToString().Trim();

                    txtPesoHabitual.Text = drGlobal[7].ToString().Trim();
                    txtTalla.Text = drGlobal[8].ToString().Trim();
                    txtIMC.Text = drGlobal[9].ToString().Trim();
                    txtPresionArterial.Text = drGlobal[10].ToString().Trim();

                    Transition t3 = new Transition(new TransitionType_EaseInEaseOut(300));
                    t3.add(panelDatosEmbarazo, "Top", this.Size.Height + 300);
                    t3.run();

                    Transition t2 = new Transition(new TransitionType_EaseInEaseOut(300));
                    t2.add(panel2, "Top", 152);
                    t2.run();

                    txtDetalleMenstruacion.Text = drGlobal[6].ToString().Trim();

                    cmbMetodoAnticonceptivo.SelectedValue = drGlobal[11].ToString().Trim();
                    txtDetalleMetodoAnticonceptivo.Text = drGlobal[12].ToString().Trim();
                }
                else if (drGlobal[2].ToString() == "1")//Tipo de Consulta CON Embarazo
                {
                    dtFur2.Value = Convert.ToDateTime(drGlobal[4]);
                    lblAmenorrea2.Text = drGlobal[5].ToString().Trim();

                    pesoHabitual = oCPacientes.PesoHabitual(TxtNumExpediente.Text.Trim());
                    txtHabitual3.Text = pesoHabitual.ToString().Trim();

                    txtPesoHabitual2.Text = drGlobal[7].ToString().Trim();
                    txtTalla2.Text = drGlobal[8].ToString().Trim();
                    txtIMC2.Text = drGlobal[9].ToString().Trim();
                    txtPresionArterial2.Text = drGlobal[10].ToString().Trim();

                    Transition t = new Transition(new TransitionType_EaseInEaseOut(300));
                    t.add(panel2, "Top", this.Size.Height + 300);
                    t.run();

                    Transition t2 = new Transition(new TransitionType_EaseInEaseOut(300));
                    t2.add(panelDatosEmbarazo, "Top", 152);
                    t2.run();
                    
                    cmbMetodoAnticonceptivo.SelectedIndex = cmbMetodoAnticonceptivo.FindStringExact("Ninguno");
                    txtDetalleMetodoAnticonceptivo.Text = "";

                    oCConsultaEmbarazo.IdConsulta = Convert.ToInt64(lblNumConsulta.Text.Trim());

                    DataSet ds = oCConsultaEmbarazo.ConsultarSinParametros();

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                fechaInicialPeriodoEmbarazo = Convert.ToDateTime(dr[1]);
                                dtFPP.Value = Convert.ToDateTime(dr[2]);
                                txtDetalleAdicionalFUR_FPP.Text = dr[3].ToString().Trim();
                                TxtFrecuenciaCardiacaFetal.Text = dr[4].ToString().Trim();

                                if (Convert.ToBoolean(dr[5]) == true)
                                    rdSiMF.Checked = true;
                                else
                                    rdNoMF.Checked = true;

                                txtAlturaUterina.Text = dr[6].ToString().Trim();
                                txtUltrasonido.Text = dr[7].ToString().Trim();
                            }
                        }
                        ds.Dispose();
                    }
                }

                txtEditDetalleConsulta.Limpiar();
                txtEditTratamiento.Limpiar();
                txtEditDiagnostico.Limpiar();

                path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");

                byte[] detalleConsulta = null;
                detalleConsulta = (byte[])drGlobal[13];

                byte[] tratamiento = null;
                tratamiento = (byte[])drGlobal[14];

                byte[] diagnostico = null;
                diagnostico = (byte[])drGlobal[15];

                Metodos_Globales.CreateTempFileFromByteArray(detalleConsulta, path + "\\Detalle_Consulta.rtf");
                Metodos_Globales.CreateTempFileFromByteArray(tratamiento, path + "\\Tratamiento.rtf");
                Metodos_Globales.CreateTempFileFromByteArray(diagnostico, path + "\\Diagnostico.rtf");

                txtEditDetalleConsulta.AbrirArchivo(path + "\\Detalle_Consulta.rtf");
                txtEditTratamiento.AbrirArchivo(path + "\\Tratamiento.rtf");
                txtEditDiagnostico.AbrirArchivo(path + "\\Diagnostico.rtf");

                txtEditDetalleConsulta.ProtectText();
                txtEditTratamiento.ProtectText();
                txtEditDiagnostico.ProtectText();

                if (TxtNumExpediente.Text.Trim() != "")
                {
                    Program.oFrmDetallePaciente.NumExpediente = TxtNumExpediente.Text.Trim();
                    Program.oFrmDetallePaciente.EstableceDatosPacientes();
                }

                lstGabineteConsulta.Visible = false;
                panelGabineteConsulta.Visible = true;

                lstExamenesConsulta.Visible = false;//true;
                panelExamenes.Visible = true;

                //LlenaListaExamenesConsulta();
                LlenarListaExamenesConsulta();
                
                //LlenaListaGabineteConsulta();
                LlenarListaGabineteConsulta();

                if (lblNumConsulta.Text.Trim() != "")
                {
                    LlenarImagenes(lblNumConsulta.Text.Trim());
                    LlenarListaVideos(lblNumConsulta.Text.Trim());
                }
            }
            catch { }
        }

        private void RefreshDatatable(CConsultas pCConsultas)
        {
            dt = new DataTable();
            //dt.Load((IDataReader)oList, LoadOption.Upsert);
            dt = null;
            dt = new DataTable();
            drGlobal = null;
            sqlDR = null;

            if (oFrmParamBusquedaConsulta.buscarCondiagnosticos == false)
                sqlDR = Program.oCConsultas.ConsultarConParametros(oFrmParamBusquedaConsulta.SqlWhere);
            else
                sqlDR = Program.oPersistencia.ejecutarConsultaSQL(oFrmParamBusquedaConsulta.SqlWhere);

            if (sqlDR != null)
            {
                dt.Load(sqlDR, LoadOption.Upsert);
                //return true;
            }
            //else
            //    return false;
        }

        public void tobEjecutarConsulta_Click(object sender, EventArgs e)
        {
            if (oFrmParamBusquedaConsulta.SqlWhere != "")
            {
                sqlDR = null;
                dt = new DataTable();
                drGlobal = null;

                //El auxFila se establece cuando después de guardar en proceso de modificación de la consulta
                //se encuentra que hay al menos 1 fila existente, la cual debería de ser la o una de las que está
                //siendo modificada, por lo que al recargar los datos no debería irse a la primera consulta, sino 
                //a la actual (recien modificada)
                if (auxFila != -1)
                    fila = auxFila;
                else
                    fila = 0;

                if (oFrmParamBusquedaConsulta.buscarCondiagnosticos == false)
                    sqlDR = Program.oCConsultas.ConsultarConParametros(oFrmParamBusquedaConsulta.SqlWhere);
                else
                    sqlDR = Program.oPersistencia.ejecutarConsultaSQL(oFrmParamBusquedaConsulta.SqlWhere);
                
                if (sqlDR != null)
                {
                    if (sqlDR.HasRows == true)
                    {
                        ModoConsulta();
                      
                        dt.Load(sqlDR, LoadOption.Upsert);

                        if (!Program.oPersistencia.IsError)
                        {
                            int uf = dt.Rows.Count - 1;

                            totalFilas = uf;

                            if (dt.Rows.Count > 0)
                            {
                                if (fila < 0 || uf < 0)
                                {
                                    tobNuevo.Enabled = true;
                                    tobModificar.Enabled = false;
                                    tobGuardar.Enabled = false;
                                    tobCancelar.Enabled = false;
                                    tobPrimero.Enabled = false;
                                    tobSiguiente.Enabled = false;
                                    tobAnterior.Enabled = false;
                                    tobUltimo.Enabled = false;
                                    tobIniciarConsulta.Enabled = true;
                                    tobEjecutarConsulta.Enabled = false;
                                    tobCancelarConsulta.Enabled = false;
                                    tobSalir.Enabled = true;

                                    return;
                                }
                                else
                                {
                                    tobNuevo.Enabled = true;
                                    tobModificar.Enabled = true;
                                    tobGuardar.Enabled = false;
                                    tobCancelar.Enabled = false;
                                    tobPrimero.Enabled = true;
                                    tobSiguiente.Enabled = true;
                                    tobAnterior.Enabled = true;
                                    tobUltimo.Enabled = true;
                                    tobIniciarConsulta.Enabled = true;
                                    tobEjecutarConsulta.Enabled = false;
                                    tobCancelarConsulta.Enabled = true;
                                    tobSalir.Enabled = true;

                                    oFrmParamBusquedaConsulta.Hide();
                                }

                                MostrarDatos(fila);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "No se encontraron Consultas que coincidan con los parámetros de su búsqueda, por favor verifique los datos e intente de nuevo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        oFrmParamBusquedaConsulta.Activate();
                    }
                    sqlDR.Dispose();
                    dt.Dispose();
                }

                Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
            }
        }

        private void tobCancelarConsulta_Click(object sender, EventArgs e)
        {
            //tobCancelar_Click(sender, e);
            ModoBloqueo();
        }

        private void tobSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void tobBuscarPaciente_Click(object sender, EventArgs e)
        {
            FrmBlackBackground oFrmBlackBackground = new FrmBlackBackground();
            oFrmBlackBackground.Show();
            FrmPacientesExistentes oFrmPacientesExistentes = new FrmPacientesExistentes(TxtNumExpediente, TxtNombre);
            oFrmPacientesExistentes.ShowDialog();
            oFrmBlackBackground.Close();

            if (tipoConsultaSeleccionada == 2)//Con embarazo
            {
                oFechaIniEmbarazo = oCConsultaEmbarazo.DeterminaPeriodoEmbarazoIniciado(TxtNumExpediente.Text.Trim());

                if (oFechaIniEmbarazo != DateTime.MinValue)
                {
                    if (MessageBox.Show(this, "¿Se encontró un periodo de embarazo activo para esta paciente, ¿Desea iniciar un periodo nuevo y finalizar el periodo vigente actualmente?. Éstas acciones no pueden ser reversadas por el sistema.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string sql = "";
                        sql = "Update Consultas_Con_Embarazo SET estado_embarazo = 'Finalizado' WHERE id_consulta IN (SELECT max(CE.id_consulta) FROM Consultas_Con_Embarazo CE INNER JOIN Consulta_Paciente CP on CP.id_consulta = CE.id_consulta WHERE cp.num_expediente = " + TxtNumExpediente.Text.Trim() + ")";
                        Program.oPersistencia.ejecutarSQL(sql);

                        if (Program.oPersistencia.IsError == true)
                            MessageBox.Show(this, "El periodo de embarazo no pudo ser finalizado. Por favor intente de nuevo o contacte a su proveedor para reportar esta falla técnica.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show(this, "¡Periodo de embarazo finalizado exitósamente! Se procederá a generar un nuevo periodo de embarazo de esta consulta en adelante.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            oFechaIniEmbarazo = DateTime.MinValue;
                        }
                    }
                }

                if (oFechaIniEmbarazo != DateTime.MinValue)
                {
                    embarazoActivo = 1;
                    pBoxEmbarazoActivo.Visible = true;

                    dtFur2.Value = oCConsultaEmbarazo.FUR;

                    dtFur2.Visible = false;
                    dtFPP.Visible = false;
                    dtFur2.Enabled = false;
                    dtFPP.Enabled = false;

                    txtFUR.Visible = true;
                    txtFPP.Visible = true;

                    tobCambiarOpcion.Enabled = false;

                    pBoxEmbarazoActivo.Image = Properties.Resources.Active_Pregnant_Sky_Blue_80;
                    pBoxEmbarazoActivo.ImagenOriginal = Properties.Resources.Active_Pregnant_Sky_Blue_80;
                    pBoxEmbarazoActivo.HighlightedImage = Properties.Resources.Active_Pregnant_Sky_Blue_80_highlighted;

                    btnInfoEmbarazo.Visible = true;
                }
                else
                {
                    opcionElegida = 0;
                    embarazoActivo = 0;
                    pBoxEmbarazoActivo.Visible = true;

                    dtFur2.Visible = true;
                    dtFPP.Visible = false;
                    dtFur2.Enabled = true;
                    dtFPP.Enabled = true;

                    txtFUR.Visible = false;
                    txtFPP.Visible = true;

                    pBoxEmbarazoActivo.Image = Properties.Resources.Pregnancy_New_80;
                    pBoxEmbarazoActivo.ImagenOriginal = Properties.Resources.Pregnancy_New_80;
                    pBoxEmbarazoActivo.HighlightedImage = Properties.Resources.Pregnancy_New_80;

                    btnInfoEmbarazo.Visible = false;
                }
            }
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void tobBuscarPaciente_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void tobBuscarPaciente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void frmConsultas_FormClosed(object sender, FormClosedEventArgs e)
        {
            activo = false;

            Program.oMDI.panel4.BackColor = Color.White;
            Program.oMDI.pictureBox2.BackColor = Color.White;

            Program.oMDI.panel3.Visible = false;

            if (Program.oFrmHistoriaClinica != null)
            {
                if (Program.oFrmHistoriaClinica.Abierto == false)
                {
                    Program.oMDI.panelSoftOptions.Visible = true;
                    Program.oMDI.panel4.BackColor = Color.White;
                    Program.oMDI.pictureBox2.BackColor = Color.White;
                }
            }
            else
            {
                Program.oMDI.panelSoftOptions.Visible = true;
                Program.oMDI.panel4.BackColor = Color.White;
                Program.oMDI.pictureBox2.BackColor = Color.White;
            }

            ResetImageControl(false, false, false, false);

            Program.oFrmImagenesConsultas.ResetImageControl();

            Program.oFrmDock.timer2.Start();
            oFrmParamBusquedaConsulta.Dispose();
        }

        private void txtPesoHabitual_TextChanged(object sender, EventArgs e)
        {
            if (txtPesoHabitual.Text.Trim() == "" || txtPesoHabitual.Text.Trim() == "," || txtPesoHabitual.Text.Trim() == ".")
            {
                txtPesoHabitual.Text = "0";
                txtPesoHabitual.SelectAll();
            }

            if (txtTalla.Text.Trim() != "" && txtPesoHabitual.Text.Trim() != "")
                txtIMC.Text = Program.oCPacientes.CalculaIMC(txtPesoHabitual.Text.Trim(), txtTalla.Text.Trim()).ToString();
        }

        private void txtTalla_TextChanged(object sender, EventArgs e)
        {
            if (txtTalla.Text.Trim() == "" || txtTalla.Text.Trim() == "," || txtTalla.Text.Trim() == ".")
            {
                txtTalla.Text = "0";
                txtTalla.SelectAll();
            }

            if (txtTalla.Text.Trim() != "" && txtPesoHabitual.Text.Trim() != "")
                txtIMC.Text = Program.oCPacientes.CalculaIMC(txtPesoHabitual.Text.Trim(), txtTalla.Text.Trim()).ToString();
        }

        private void dtFUR_ValueChanged(object sender, EventArgs e)
        {
            if (dtFUR.Value.Date <= DateTime.Today.Date)
            {
                txtAmenorrea.Text = Program.oCConsultas.CalculoAmenorrea(dtFUR.Value) + " Semanas con " +
                     Program.oCConsultas.CalculoDiasAmenorrea(dtFUR.Value).ToString() + " días.";
                //txtAmenorrea.Text = Program.oCConsultas.CalculoAmenorrea(dtFUR.Value).ToString();
            }
            else
            {
                MessageBox.Show(this, "La fecha indicada en el detalle de la última menstruación debe ser menor o igual a la fecha actual.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtFUR.Value = DateTime.Today;
            }
        }

        private void GuardarNuevoMetodoAnticonceptivo()
        {
            oCMetodosAnticonceptivos.Descripcion = cmbMetodoAnticonceptivo.Text.Trim();

            oCMetodosAnticonceptivos.Insertar();
            LlenaComboMetodosAnticonceptivos();
            cmbMetodoAnticonceptivo.SelectedIndex = cmbMetodoAnticonceptivo.Items.Count - 1;

            if (Program.oPersistencia.IsError == false)
                MessageBox.Show(this, "El método anticonceptivo \"" + cmbMetodoAnticonceptivo.Text.Trim() + " \" fue almacenado correctamente en la base de datos del sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tobGuardarMetodosAnticonceptivos_Click(object sender, EventArgs e)
        {
            if (cmbMetodoAnticonceptivo.Text.Trim() != "")
            {
                if (oCMetodosAnticonceptivos.DeterminaMetodoRepetido(cmbMetodoAnticonceptivo.Text.Trim()) == false)
                {
                    GuardarNuevoMetodoAnticonceptivo();
                    Program.oFrmHistorialConsultas.LlenaComboMetodosAnticonceptivos();//Recarga el combo en el historial de consultas del DOCK
                }
                else
                    MessageBox.Show(this, "El método anticonceptivo ya existe entre la lista disponible, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmbMetodoAnticonceptivo_Leave(object sender, EventArgs e)
        {
            if (oCMetodosAnticonceptivos.DeterminaMetodoRepetido(cmbMetodoAnticonceptivo.Text.Trim()) == false)
            {
                if (MessageBox.Show(this, "El método anticonceptivo ingresado no existe actualmente en la base de datos, ¿Desea ingresarlo a la lista de Métodos Anticonceptivos del sistema?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    GuardarNuevoMetodoAnticonceptivo();
                else
                    cmbMetodoAnticonceptivo.SelectedIndex = -1;
            }
        }

        private void txtEditDetalleConsulta_Enter(object sender, EventArgs e)
        {
            this.VerticalScroll.Value = 0;
            this.AutoScrollPosition = new Point(0, 0);
        }

        private void txtEditDiagnostico_Enter(object sender, EventArgs e)
        {
            this.VerticalScroll.Value = 0;
            this.AutoScrollPosition = new Point(0, 0);
        }

        private void txtEditTratamiento_Enter(object sender, EventArgs e)
        {
            this.VerticalScroll.Value = 0;
            this.AutoScrollPosition = new Point(0, 0);
        }

        private void tobPrimero_Click(object sender, EventArgs e)
        {
            MostrarDatos(0);
        }

        private void tobAnterior_Click(object sender, EventArgs e)
        {
            fila = fila - 1;
            if (fila < 0)
                fila = 0;

            MostrarDatos(fila);
        }

        private void tobSiguiente_Click(object sender, EventArgs e)
        {
            fila += 1;

            if (fila > totalFilas)
                fila = totalFilas;

            MostrarDatos(fila);
        }

        private void tobUltimo_Click(object sender, EventArgs e)
        {
            fila = totalFilas;
            MostrarDatos(fila);
        }

        public void TxtNumExpediente_TextChanged(object sender, EventArgs e)
        {
            timerTraeDatosPaciente.Start();
        }

        private void FindAndChangeFont(RichTextBox oRTBox, string pCadena, int pLenght, Font oFont, Color oColor)
        {
            try
            {
                if (oRTBox != null)
                {
                    int i = oRTBox.Find(pCadena);
                    int j = pLenght;

                    if (i < 0)
                        i = 0;

                    if (j < 0)
                        j = 0;

                    oRTBox.Select(i, j);
                    oRTBox.SelectionFont = oFont;
                    oRTBox.SelectionColor = oColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FindAndChangeAlignment(RichTextBox oRTBox, string pCadena, int pLenght, int LRC)
        {
            try
            {
                if (oRTBox != null)
                {
                    int i = oRTBox.Find(pCadena);
                    int j = pLenght;

                    if (i < 0)
                        i = 0;

                    if (j < 0)
                        j = 0;

                    oRTBox.Select(i, j);

                    if (LRC == 0)
                        oRTBox.SelectionAlignment = HorizontalAlignment.Left;
                    else if (LRC == 1)
                        oRTBox.SelectionAlignment = HorizontalAlignment.Right;
                    else if (LRC == 2)
                        oRTBox.SelectionAlignment = HorizontalAlignment.Center;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GeneraDocumentoImpresion()
        {
            if (oCEmpresa.LeeDatosEmpresa() == true && oCPacientes.LeeDatosPaciente(TxtNumExpediente.Text.Trim()) == true)
            {
                TextEditor oTextEditor = new TextEditor();

                RichTextBox oAuxRTBox = new RichTextBox();

                oAuxRTBox.Rtf = txtEditTratamiento.rtfText;

                //txtEditTratamiento.Limpiar();

                ExtendedRichTextBox.RichTextBoxPrintCtrl oRichTextBox = new ExtendedRichTextBox.RichTextBoxPrintCtrl();
                oRichTextBox.Select(0, 0);
                oRichTextBox.SelectionAlignment = HorizontalAlignment.Center;

                Font oFont = new Font("Nyala", 18, FontStyle.Bold);
                Font oFontRegular = new Font("Arial", 9, FontStyle.Regular);
                Font oFontRegular2 = new Font("Segoe Print", 11, FontStyle.Regular);
                Font oFontBold = new Font("Arial", 9, FontStyle.Bold);
                Font oFontBold2 = new Font("Nyala", 25, FontStyle.Bold);
                Font oFontBold3 = new Font("Nyala", 16, FontStyle.Bold);

                oRichTextBox.SelectionFont = oFontRegular;
                oRichTextBox.SelectionAlignment = HorizontalAlignment.Right;
                oRichTextBox.SelectedText = lblFechaConsulta.Text.Trim() + Environment.NewLine + Environment.NewLine;

                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;

                oRichTextBox.SelectionFont = oFont;
                oRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
                oRichTextBox.SelectedText = oCEmpresa.NombreEmpresa.Trim();

                oRichTextBox.SelectedText += Environment.NewLine;

                oRichTextBox.SelectionFont = oFontRegular;
                oRichTextBox.SelectionAlignment = HorizontalAlignment.Center;

                oRichTextBox.SelectionFont = oFontRegular;
                oRichTextBox.SelectedText += oCEmpresa.Especialidad.Trim() + Environment.NewLine;
                oRichTextBox.SelectionFont = oFontRegular;
                oRichTextBox.SelectedText += oCEmpresa.ServiciosOfrecidos.Trim() + Environment.NewLine;
                oRichTextBox.SelectionFont = oFontRegular;
                oRichTextBox.SelectedText += oCEmpresa.Telefono.Trim() + Environment.NewLine;
                oRichTextBox.SelectionFont = oFontRegular;
                oRichTextBox.SelectedText += oCEmpresa.Email.Trim() + Environment.NewLine;
                oRichTextBox.SelectionFont = oFontRegular;
                oRichTextBox.SelectedText += oCEmpresa.Direccion.Trim() + Environment.NewLine;

                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;

                #region Datos Paciente

                oRichTextBox.SelectionFont = oFontBold;
                oRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                oRichTextBox.SelectedText += "Nombre del paciente: ";

                oRichTextBox.SelectionFont = oFontRegular2;
                string nomPaciente = oCPacientes.Nombre.Trim() + " " + oCPacientes.Apellidos.Trim();
                oRichTextBox.SelectedText += nomPaciente.Trim();

                oRichTextBox.SelectedText += "   ";

                oRichTextBox.SelectionFont = oFontBold;
                oRichTextBox.SelectedText += "Cédula: ";

                oRichTextBox.SelectionFont = oFontRegular2;
                oRichTextBox.SelectedText += oCPacientes.Cedula.Trim();

                oRichTextBox.SelectedText += Environment.NewLine;

                oRichTextBox.SelectionFont = oFontBold;
                oRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                oRichTextBox.SelectedText += "Edad: ";

                oRichTextBox.SelectionFont = oFontRegular2;
                int edad = oCPacientes.CalculaEdad(oCPacientes.FechaNacimiento);
                oRichTextBox.SelectedText += edad.ToString();

                oRichTextBox.SelectedText += "   ";

                oRichTextBox.SelectionFont = oFontBold;
                oRichTextBox.SelectedText += "Peso: ";

                oRichTextBox.SelectionFont = oFontRegular2;
                oRichTextBox.SelectedText += txtPesoHabitual.Text.Trim();

                string contactos = "";
                foreach (string oString in oCContactosPacientes.LeerContactosPaciente_ImpresionConsultaReceta(TxtNumExpediente.Text.Trim()))
                    contactos += oString.Trim() + " / ";

                if (contactos.EndsWith("/ "))
                    contactos = contactos.Substring(0, contactos.Length - 2);

                oRichTextBox.SelectedText += "  ";

                oRichTextBox.SelectionFont = oFontBold;
                oRichTextBox.SelectedText += "Teléfonos: ";

                oRichTextBox.SelectionFont = oFontRegular2;
                oRichTextBox.SelectedText += contactos.Trim();

                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;

                #endregion

                oRichTextBox.SelectionFont = oFontBold2;
                oRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                oRichTextBox.SelectedText += "R";

                oRichTextBox.SelectionFont = oFontBold3;
                oRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                oRichTextBox.SelectedText += "X";

                oRichTextBox.SelectionFont = oFontBold2;
                oRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                oRichTextBox.SelectedText += "/";

                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;

                //Adjunta el nuevo encabezado al texto original en el componente
                oRichTextBox.SelectedRtf = oAuxRTBox.Rtf;

                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;
                oRichTextBox.SelectedText += Environment.NewLine;

                string nombreEmp = "";
                nombreEmp = oCEmpleados.ObtieneNombreEmpleado(Program.oIdUsuario);

                string linea = "";

                for (int i = 0; i < nombreEmp.Length; )
                {
                    linea += "_";
                    i++;
                }

                oRichTextBox.SelectionFont = oFontRegular;
                oRichTextBox.SelectionAlignment = HorizontalAlignment.Right;
                oRichTextBox.SelectedText += linea;

                oRichTextBox.SelectedText += Environment.NewLine;

                oRichTextBox.SelectionFont = oFontRegular;
                oRichTextBox.SelectedText += "Dr. ";

                oRichTextBox.SelectionFont = oFontRegular;
                oRichTextBox.SelectedText += nombreEmp;

                oRichTextBox.SelectedText += Environment.NewLine;

                oRichTextBox.SelectionFont = oFontBold;
                oRichTextBox.SelectionAlignment = HorizontalAlignment.Right;
                oRichTextBox.SelectedText += "Código ";

                oRichTextBox.SelectionFont = oFontBold;
                oRichTextBox.SelectedText += oCEmpleados.ObtieneCodigoColegiado(Program.oIdUsuario);

                //Establece el texto en el control...
                //txtEditTratamiento.rtfText = oRichTextBox.Rtf;

                //txtEditTratamiento.OAuxRichTextBox = oRichTextBox;
                oTextEditor.PageSetupDialog1.AllowMargins = true;
                oTextEditor.PageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
                oTextEditor.PageSetupDialog1.PageSettings.Margins.Left = 1;
                oTextEditor.PageSetupDialog1.PageSettings.Margins.Right = 100;
                oTextEditor.PageSetupDialog1.PageSettings.Margins.Top = 1;
                //oTextEditor.PageSetupDialog1.PageSettings.Margins = 1;

                object sender = new object();
                EventArgs e = new EventArgs();
                //                txtEditTratamiento.printToolStripButton_Click(sender, e);//.Print();
                
                oTextEditor.rtfText = oRichTextBox.Rtf;
                oTextEditor.printToolStripButton_Click(sender, e);

                oAuxRTBox.Dispose();
                oRichTextBox.Dispose();
                oTextEditor.Dispose();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //GeneraDocumentoImpresion();
            if (oCEmpresa.LeeDatosEmpresa() == true && oCPacientes.LeeDatosPaciente(TxtNumExpediente.Text.Trim()) == true)
            {
                string nomPaciente = oCPacientes.Nombre.Trim() + " " + oCPacientes.Apellidos.Trim();

                string contactos = "";
                foreach (string oString in oCContactosPacientes.LeerContactosPaciente_ImpresionConsultaReceta(TxtNumExpediente.Text.Trim()))
                    contactos += oString.Trim() + " / ";

                Program.ofrmPrescriptionPad.ExportarPDF(nomPaciente, oCPacientes.Cedula.Trim(), oCPacientes.CalculaEdad(oCPacientes.FechaNacimiento).ToString(),
                                                        txtPesoHabitual.Text.Trim(), contactos, oCEmpleados.ObtieneNombreEmpleado(Program.oIdUsuario),
                                                        oCEmpleados.ObtieneCodigoColegiado(Program.oIdUsuario), txtEditTratamiento.TextLines(), true);
            }
        }

        private void btnFavoritos_Click(object sender, EventArgs e)
        {
            //if (TxtNumExpediente.Text.Trim() != "")
            //    Program.oFrmDetallePaciente.Show(this);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            txtEditDetalleConsulta.EstableceTexto(Clipboard.GetText(TextDataFormat.Rtf));
        }

        private void txtDiagnosticos_TextChanged(object sender, EventArgs e)
        {
            if (txtDiagnosticos.Text.Trim() != "")
                LlenarListaDiagnosticos();
            else
            {
                Grid1.Rows.Clear();
                Grid1.Visible = false;
            }
        }

        private void LlenarListaDiagnosticos()
        {
            int alturaGrid = 0;
            string formattedString = "";
            string[] ocadenaTemp = null;
            char[] caracterBuscado = { ' ' };
            Grid1.Rows.Clear();

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Diagnosticos_Param '" + txtDiagnosticos.Text.Trim() + "'", "Diagnosticos");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        formattedString = "";
                        ocadenaTemp = dr[1].ToString().Trim().Split(caracterBuscado);

                        int contCaracteres = 0;
                        for (int i = 0; i < ocadenaTemp.Length; )
                        {
                            contCaracteres += ocadenaTemp[i].Length;

                            if (contCaracteres >= 70 && i < ocadenaTemp.Length)
                            {
                                contCaracteres = 0;
                                formattedString += Environment.NewLine;

                                if (ocadenaTemp[i].Length == 1)
                                    i++;
                            }
                            else
                            {
                                formattedString += ocadenaTemp[i].ToString() + " ";
                                i++;
                            }
                        }

                        Grid1.Rows.Add(formattedString.Trim(), dr[0].ToString());
                    }

                    Grid1.Visible = true;

                    foreach (DataGridViewRow linea in Grid1.Rows)
                        alturaGrid += linea.Height;

                    Grid1.Size = new Size(410, alturaGrid + 3);

                    if (alturaGrid > 145)
                    {
                        Grid1.Size = new Size(410, 145);
                        Grid1.ScrollBars = ScrollBars.None;//.Vertical;
                    }
                    else
                        Grid1.ScrollBars = ScrollBars.None;

                    Grid1.Rows[0].Selected = true;
                }
                else
                    Grid1.Visible = false;
            }
            else
                Grid1.Visible = false;
        }

        private void tobGuardarDiagnostico_Click(object sender, EventArgs e)
        {
            if (oCDiagnosticos.DeterminaDiagnosticoRepetido(txtDiagnosticos.Text.Trim()) == false)
            {
                oCDiagnosticos.Descripcion = txtDiagnosticos.Text.Trim();
                oCDiagnosticos.Insertar();

                if (Program.oPersistencia.IsError == false)
                    LlenarListaDiagnosticos();
            }
            else
                MessageBox.Show(this, "El diagnóstico ingresado ya existe en la base de datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txtDiagnosticos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && Grid1.Rows.Count > 0)
            {
                Grid1.Rows[0].Selected = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void Grid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Grid1.CurrentRow.Index == 0 && e.KeyCode == Keys.Up)
                txtDiagnosticos.Focus();

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (!oArregloDiagnosticos.Contains(Grid1.Rows[Grid1.CurrentRow.Index].Cells[1].Value.ToString().Trim()))
                    {
                        oArregloDiagnosticos.Add(Grid1.Rows[Grid1.CurrentRow.Index].Cells[1].Value.ToString().Trim());

                        string diagnostico = "";
                        string idDiagnostico = "";

                        idDiagnostico = "{" + Grid1.Rows[Grid1.CurrentRow.Index].Cells[1].Value.ToString().Trim() + "} ";//Grid1.SelectedRows[0].Cells[1].Value.ToString().Trim() + "} ";
                        diagnostico = Grid1.Rows[Grid1.CurrentRow.Index].Cells[0].Value.ToString().Trim().Replace("\r\n", "");//Grid1.SelectedRows[0].Cells[0].Value.ToString().Trim().Replace("\r\n", "");

                        txtEditDiagnostico.SelectionColor(Color.Green);
                        txtEditDiagnostico.TextSelected(idDiagnostico);

                        txtEditDiagnostico.SelectionColor(Color.Black);
                        txtEditDiagnostico.TextSelected(diagnostico + Environment.NewLine + Environment.NewLine);

                        txtDiagnosticos.Text = "";
                        txtDiagnosticos.Focus();
                    }
                }
                catch { }
            }
        }

        private void Grid1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex + 1 == Grid1.RowCount)
            {
                int rowsHeight = 0;
                int contFilas = 0;

                contFilas = Grid1.DisplayedRowCount(false);

                int contador = 0;
                int auxContador = 0;

                foreach (DataGridViewRow linea in Grid1.Rows)
                {
                    if (linea.Displayed == true)
                    {
                        contador++;

                        if (linea.Index + 1 == Grid1.RowCount)
                            rowsHeight += linea.Height + 3;
                        else
                            rowsHeight += linea.Height;
                    }
                }

                if (contador == contFilas)
                    Grid1.Size = new Size(Grid1.Width, rowsHeight);
                else
                {
                    foreach (DataGridViewRow linea in Grid1.Rows)
                    {
                        if (linea.Displayed == true)
                        {
                            if (auxContador < contador)
                            {
                                rowsHeight += linea.Height + 1;
                                auxContador++;
                            }
                        }
                    }

                    Grid1.Size = new Size(Grid1.Width, rowsHeight);
                    Grid1.Refresh();
                }
            }
        }

        private void txtDiagnosticos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }                

            if (e.KeyChar == '{' || e.KeyChar == '}')
                e.Handled = true;

            if (Metodos_Globales.AvoidSpecialCharacters(e.KeyChar) == true)
            {
                MessageBox.Show(this, "Los caracteres \"[]{}(),;?*! @\\\" no pueden ser utilizados en este campo, por favor especifique otro caracter.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                e.Handled = true;
            }
        }

        #region Gabinete

        private int ObtieneIdGrupo(string pIdCategoria)
        {
            int index = 0;
            index = idCategoria.IndexOf(pIdCategoria);

            return index;
        }

        public void LlenarLista(bool pLimpiarArreglo)
        {
            treeView1.Nodes.Clear();
            
            idCategoria.Clear();
            nombreCategoria.Clear();

            if (pLimpiarArreglo == true)
            {
                oIdDetalleGabinete.Clear();
                oDetalleGabinete.Clear();
            }

            Font Font1 = new Font("Segoe Print", 9, FontStyle.Bold);

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Gabinetes_Categoria", "Gabinete_Categoria");
            DataSet ds2 = new DataSet();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ds2 = Program.oPersistencia.ejecutarSQLListas("sp_S_Categorias_Gabinete_Param2 '" + dr[0].ToString().Trim() + "'", "Categoria_Gabinete");

                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            if (!nombreCategoria.Contains(dr2[0].ToString().Trim()))
                            {
                                idCategoria.Add(dr[0].ToString().Trim());
                                nombreCategoria.Add(dr2[0].ToString().Trim());
                            }
                        }
                        ds2 = null;
                    }

                    int indice = 0;
                    foreach (string oGrupo in nombreCategoria)
                    {
                        this.treeView1.Nodes.Add(oGrupo);
                        this.treeView1.Nodes[indice].ImageIndex = 0;
                        this.treeView1.Nodes[indice].NodeFont = Font1;

                        indice++;
                    }

                    int index = 0;
                    int linea = 0;

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        index = ObtieneIdGrupo(dr[0].ToString().Trim());

                        //Selecciona el nombre y descripcion del Examen
                        ds2 = Program.oPersistencia.ejecutarSQLListas("sp_S_Gabinete_Param2 '" + dr[1].ToString().Trim() + "'", "Gabinete_Categoria");

                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            treeView1.Nodes[index].Nodes.Add(dr2[1].ToString().Trim());
                            treeView1.Nodes[index].LastNode.Tag = dr2[0].ToString().Trim();
                            treeView1.Nodes[index].LastNode.ImageIndex = 1;
                            treeView1.Nodes[index].LastNode.SelectedImageIndex = 1;

                            linea++;
                        }
                        ds2.Dispose();
                        linea = 0;
                    }
                }
            }
            
            ds.Dispose();

            treeView1.BackColor = Color.White;
        }

        public void SeñalaGabinetesSeleccionados_Modificacion()
        {
            foreach (TreeNode oNode in treeView1.Nodes)
            {
                foreach (TreeNode oNodo in oNode.Nodes)
                {
                    if (oIdDetalleGabinete.Contains(oNodo.Tag.ToString().Trim()))
                    {
                        oNodo.ImageIndex = 2;
                        oNodo.SelectedImageIndex = 2;
                    }
                }
            }
        }

        public void LlenarListaGabineteConsulta()
        {
            treeView1.Nodes.Clear();

            idCategoria.Clear();
            nombreCategoria.Clear();

            oIdDetalleGabinete.Clear();
            oDetalleGabinete.Clear();

            Font Font1 = new Font("Segoe Print", 9, FontStyle.Bold);

            int index = 0;

            //Seleccionamos los exámenes por consulta
            DataSet ds = oCGabineteConsulta.ConsultarSinParametros(lblNumConsulta.Text.Trim());//Program.oPersistencia.ejecutarSQLListas("sp_S_Examenes_Categoria", "Examenes_Categoria");
            DataSet ds2 = new DataSet();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        //Seleccionamos la descripción de las categorías de acuerdo al id de categoría y las almacenamos en un arreglo
                        //Select id_categoria_examen from i
                        string sql = "Select a.id_categoria_gabinete, b.descripcion from Gabinete_Categoria a, Categorias_Gabinete b " +
                                     "where  a.id_categoria_gabinete = b.id_categoria_gabinete and a.id_gabinete = " + dr[0].ToString().Trim();
                        ds2 = Program.oPersistencia.ejecutarSQLListas(sql.Trim(), "Gabinete_Categoria a, Categorias_Gabinete b");//"sp_S_Categorias_Examenes_Param2 '" + dr[1].ToString().Trim() + "'", "Categoria_Examenes");

                        if (ds2 != null)
                        {
                            int indice = 0;

                            foreach (DataRow dr2 in ds2.Tables[0].Rows)
                            {
                                if (!nombreCategoria.Contains(dr2[1].ToString().Trim()))
                                {
                                    idCategoria.Add(dr2[0].ToString().Trim());
                                    nombreCategoria.Add(dr2[1].ToString().Trim());

                                    //Agregamos como nodo padre las descripcion o nombre de las categorías de los exámenes
                                    this.treeView1.Nodes.Add(dr2[1].ToString().Trim());
                                    this.treeView1.Nodes[indice].ImageIndex = 0;
                                    this.treeView1.Nodes[indice].NodeFont = Font1;

                                    indice++;
                                }

                                index = ObtieneIdGrupo(dr2[0].ToString().Trim());
                            }
                            ds2.Dispose();
                        }

                        oIdDetalleGabinete.Add(dr[0].ToString().Trim());
                        oDetalleGabinete.Add(dr[2].ToString().Trim());

                        treeView1.Nodes[index].Nodes.Add(dr[6].ToString().Trim());
                        treeView1.Nodes[index].LastNode.Tag = dr[0].ToString().Trim();
                        treeView1.Nodes[index].LastNode.ImageIndex = 2;
                        treeView1.Nodes[index].LastNode.SelectedImageIndex = 2;
                    }
                }
            }            

            if (ds != null)
                ds.Dispose();

            treeView1.BackColor = Color.White;

            treeView1.ExpandAll();
        }

        private void LlenaListaGabineteConsulta()
        {
            try
            {
                lstGabineteConsulta.Items.Clear();

                DataSet ds = oCGabineteConsulta.ConsultarSinParametros(lblNumConsulta.Text.Trim());

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int linea = 0;

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            lstGabineteConsulta.Items.Add(dr[0].ToString().Trim());
                            lstGabineteConsulta.Items[linea].SubItems.Add(dr[3].ToString().Trim());
                            lstGabineteConsulta.Items[linea].SubItems.Add(dr[2].ToString().Trim());

                            linea++;
                        }
                    }
                    ds.Dispose();
                    oCGabineteConsulta.ConsultarSinParametros(lblNumConsulta.Text.Trim()).Dispose();
                }
            }
            catch { }
        }

        private void LeeDetalleAdicionalGabinete(string pIdGabinete)
        {
            try
            {
                int index = -1;

                if (oIdDetalleGabinete.Contains(pIdGabinete))
                {
                    index = oIdDetalleGabinete.IndexOf(pIdGabinete);
                    txtDetalleAdicional.Text = oDetalleGabinete[index].ToString().Trim();
                }
                else
                    txtDetalleAdicional.Text = "";
            }
            catch { }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            currentNode = -1;
            currentNode = Convert.ToInt32(e.Node.Tag);
            nodeImageIndex = e.Node.ImageIndex;

            lblDescripcionEstudio.Text = "";

            try
            {
                if (e.Node.Tag != null)
                {
                    DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Gabinete_Param2 '" + e.Node.Tag.ToString().Trim() + "'", "Gabinete_Categoria");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                        lblDescripcionEstudio.Text = dr[2].ToString().Trim();

                    LeeDetalleAdicionalGabinete(e.Node.Tag.ToString().Trim());
                }
                else
                    txtDetalleAdicional.Text = "";
            }
            catch { }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (nuevo == true || modificar == true)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (treeView1.SelectedNode != null)
                    {
                        if (treeView1.SelectedNode.Tag != null)
                        {
                            if (treeView1.SelectedNode.ImageIndex == 1)
                            {
                                if (!oIdDetalleGabinete.Contains(treeView1.SelectedNode.Tag.ToString().Trim()))
                                {
                                    oIdDetalleGabinete.Add(treeView1.SelectedNode.Tag.ToString().Trim());
                                    oDetalleGabinete.Add("");
                                }

                                treeView1.SelectedNode.ImageIndex = 2;
                                treeView1.SelectedNode.SelectedImageIndex = 2;

                                nodeImageIndex = 2;
                            }
                            else
                            {
                                treeView1.SelectedNode.ImageIndex = 1;
                                treeView1.SelectedNode.SelectedImageIndex = 1;

                                nodeImageIndex = 1;

                                int index = oIdDetalleGabinete.IndexOf(treeView1.SelectedNode.Tag.ToString().Trim());
                                if (index != -1)
                                {
                                    oIdDetalleGabinete.RemoveAt(index);

                                    try
                                    {
                                        oDetalleGabinete.RemoveAt(index);
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void txtDetalleAdicional_TextChanged(object sender, EventArgs e)
        {
            if (nuevo == true || modificar == true)
            {
                if (nodeImageIndex == 2)
                {
                    int index = oIdDetalleGabinete.IndexOf(currentNode.ToString().Trim());

                    if (oIdDetalleGabinete.Contains(currentNode.ToString().Trim()))
                    {
                        try
                        {
                            oIdDetalleGabinete.RemoveAt(index);
                            oDetalleGabinete.RemoveAt(index);
                        }
                        catch { }
                    }

                    oIdDetalleGabinete.Add(currentNode.ToString().Trim());
                    oDetalleGabinete.Add(txtDetalleAdicional.Text.Trim());
                }
            }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //if (nuevo == true)
            //{
            //    if (txtDetalleAdicional.Text.Trim() != String.Empty)
            //    {
            //        if (nodeImageIndex == 2)
            //        {
            //            int index = oIdDetalleGabinete.IndexOf(currentNode.ToString().Trim());

            //            if (oIdDetalleGabinete.Contains(currentNode.ToString().Trim()))
            //            {
            //                try
            //                {
            //                    oIdDetalleGabinete.RemoveAt(index);
            //                    oDetalleGabinete.RemoveAt(index);
            //                }
            //                catch { }
            //            }

            //            oIdDetalleGabinete.Add(currentNode.ToString().Trim());
            //            oDetalleGabinete.Add(txtDetalleAdicional.Text.Trim());
            //        }
            //    }
            //}
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (nuevo == true || modificar == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.Node.Parent != null)
                    {
                        KeyEventArgs e2 = new KeyEventArgs(Keys.Enter);
                        treeView1_KeyDown(sender, e2);
                    }
                }
            }
        }

        #endregion

        #region Exámenes de Laboratorio

        private int ObtieneIdGrupoExamenes(string pIdCategoria)
        {
            int index = 0;
            index = idCategoriaExamenes.IndexOf(pIdCategoria);

            return index;
        }

        public void LlenarListaExamenes(bool pLimpiarArreglo)
        {
            treeView2.Nodes.Clear();
            idCategoriaExamenes.Clear();
            nombreCategoriaExamenes.Clear();

            if (pLimpiarArreglo == true)
            {
                oIdDetalleExamenes.Clear();
                oDetalleExamenes.Clear();
            }

            Font Font1 = new Font("Segoe Print", 9, FontStyle.Bold);

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Examenes_Categoria", "Examenes_Categoria");
            DataSet ds2 = new DataSet();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ds2 = Program.oPersistencia.ejecutarSQLListas("sp_S_Categorias_Examenes_Param2 '" + dr[1].ToString().Trim() + "'", "Categoria_Examenes");

                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            if (!nombreCategoriaExamenes.Contains(dr2[0].ToString().Trim()))
                            {
                                idCategoriaExamenes.Add(dr[1].ToString().Trim());
                                nombreCategoriaExamenes.Add(dr2[0].ToString().Trim());
                            }
                        }
                        ds2 = null;
                    }

                    int indice = 0;
                    foreach (string oGrupo in nombreCategoriaExamenes)
                    {
                        this.treeView2.Nodes.Add(oGrupo);
                        this.treeView2.Nodes[indice].ImageIndex = 0;
                        this.treeView2.Nodes[indice].NodeFont = Font1;

                        indice++;
                    }

                    int index = 0;
                    int linea = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        index = ObtieneIdGrupoExamenes(dr[1].ToString().Trim());

                        //Selecciona el nombre y descripcion del Examen
                        ds2 = Program.oPersistencia.ejecutarSQLListas("sp_S_Examenes_Param2 '" + dr[0].ToString().Trim() + "'", "Examenes_Categoria");

                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            treeView2.Nodes[index].Nodes.Add(dr2[1].ToString().Trim());
                            treeView2.Nodes[index].LastNode.Tag = dr2[0].ToString().Trim();
                            treeView2.Nodes[index].LastNode.ImageIndex = 1;
                            treeView2.Nodes[index].LastNode.SelectedImageIndex = 1;

                            linea++;
                        }

                        linea = 0;
                    }
                }
            }

            ds2.Dispose();
            ds.Dispose();

            treeView2.BackColor = Color.White;
        }

        public void SeñalaExamenesSeleccionados_Modificacion()
        {
            foreach (TreeNode oNode in treeView2.Nodes)
            {
                foreach (TreeNode oNodo in oNode.Nodes)
                {
                    if (oIdDetalleExamenes.Contains(oNodo.Tag.ToString().Trim()))
                    {
                        oNodo.ImageIndex = 2;
                        oNodo.SelectedImageIndex = 2;
                    }
                }
            }
        }

        public void LlenarListaExamenesConsulta()
        {
            treeView2.Nodes.Clear();
            
            idCategoriaExamenes.Clear();
            nombreCategoriaExamenes.Clear();

            oIdDetalleExamenes.Clear();
            oDetalleExamenes.Clear();

            Font Font1 = new Font("Segoe Print", 9, FontStyle.Bold);

            int index = 0;

            //Seleccionamos los exámenes por consulta
            DataSet ds = oCExamenesConsulta.ConsultarSinParametros(lblNumConsulta.Text.Trim());//Program.oPersistencia.ejecutarSQLListas("sp_S_Examenes_Categoria", "Examenes_Categoria");
            DataSet ds2 = new DataSet();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        //Seleccionamos la descripción de las categorías de acuerdo al id de categoría y las almacenamos en un arreglo
                        //Select id_categoria_examen from i
                        string sql = "Select a.id_categoria_examen, b.descripcion from Examenes_Categoria a, Categorias_Examenes b " +
                                     "where  a.id_categoria_examen = b.id_categoria_examen and a.id_examen = " + dr[0].ToString().Trim();
                        ds2 = Program.oPersistencia.ejecutarSQLListas(sql.Trim(), "Examenes_Categoria a, Categorias_Examenes b");//"sp_S_Categorias_Examenes_Param2 '" + dr[1].ToString().Trim() + "'", "Categoria_Examenes");

                        if (ds2 != null)
                        {
                            int indice = 0;

                            foreach (DataRow dr2 in ds2.Tables[0].Rows)
                            {
                                if (!nombreCategoriaExamenes.Contains(dr2[1].ToString().Trim()))
                                {
                                    idCategoriaExamenes.Add(dr2[0].ToString().Trim());
                                    nombreCategoriaExamenes.Add(dr2[1].ToString().Trim());

                                    //Agregamos como nodo padre las descripcion o nombre de las categorías de los exámenes
                                    this.treeView2.Nodes.Add(dr2[1].ToString().Trim());
                                    this.treeView2.Nodes[indice].ImageIndex = 0;
                                    this.treeView2.Nodes[indice].NodeFont = Font1;

                                    indice++;
                                }

                                index = ObtieneIdGrupoExamenes(dr2[0].ToString().Trim());
                            }
                            ds2.Dispose();
                        }

                        oIdDetalleExamenes.Add(dr[0].ToString().Trim());
                        oDetalleExamenes.Add(dr[2].ToString().Trim());

                        treeView2.Nodes[index].Nodes.Add(dr[6].ToString().Trim());
                        treeView2.Nodes[index].LastNode.Tag = dr[0].ToString().Trim();
                        treeView2.Nodes[index].LastNode.ImageIndex = 2;
                        treeView2.Nodes[index].LastNode.SelectedImageIndex = 2;
                    }
                }
            }

            if (ds != null)
                ds.Dispose();

            treeView2.BackColor = Color.White;

            treeView2.ExpandAll();
        }

        private void LlenaListaExamenesConsulta()
        {
            try
            {
                lstExamenesConsulta.Items.Clear();

                DataSet ds = oCExamenesConsulta.ConsultarSinParametros(lblNumConsulta.Text.Trim());

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int linea = 0;

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            lstExamenesConsulta.Items.Add(dr[0].ToString().Trim());
                            lstExamenesConsulta.Items[linea].SubItems.Add(dr[6].ToString().Trim());
                            lstExamenesConsulta.Items[linea].SubItems.Add(dr[2].ToString().Trim());

                            linea++;
                        }
                    }
                    ds.Dispose();
                    oCExamenesConsulta.ConsultarSinParametros(lblNumConsulta.Text.Trim()).Dispose();
                }
            }
            catch { }
        }

        private void LeeDetalleAdicionalExamenes(string pIdExamenes)
        {
            try
            {
                int index = -1;                

                if (oIdDetalleExamenes.Contains(pIdExamenes))
                {
                    index = oIdDetalleExamenes.IndexOf(pIdExamenes);
                    txtDetalleAdicionalExamenes.Text = oDetalleExamenes[index].ToString().Trim();
                }
                else
                    txtDetalleAdicionalExamenes.Text = "";
            }
            catch { }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            currentNodeExamenes = -1;
            currentNodeExamenes = Convert.ToInt32(e.Node.Tag);
            nodeImageIndexExamenes = e.Node.ImageIndex;

            lblDescripcionExamen.Text = "";

            try
            {
                if (e.Node.Tag != null)
                {
                    DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Examenes_Param2 '" + e.Node.Tag.ToString().Trim() + "'", "Examenes_Categoria");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                        lblDescripcionExamen.Text = dr[2].ToString().Trim();

                    LeeDetalleAdicionalExamenes(e.Node.Tag.ToString().Trim());
                }
                else
                    txtDetalleAdicionalExamenes.Text = "";
            }
            catch { }
        }

        private void treeView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (nuevo == true || modificar == true)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (treeView2.SelectedNode != null)
                    {
                        if (treeView2.SelectedNode.Tag != null)
                        {
                            if (treeView2.SelectedNode.ImageIndex == 1)
                            {
                                if (!oIdDetalleExamenes.Contains(treeView2.SelectedNode.Tag.ToString().Trim()))
                                {
                                    oIdDetalleExamenes.Add(treeView2.SelectedNode.Tag.ToString().Trim());
                                    oDetalleExamenes.Add("");
                                }

                                treeView2.SelectedNode.ImageIndex = 2;
                                treeView2.SelectedNode.SelectedImageIndex = 2;

                                nodeImageIndexExamenes = 2;
                            }
                            else
                            {
                                treeView2.SelectedNode.ImageIndex = 1;
                                treeView2.SelectedNode.SelectedImageIndex = 1;

                                nodeImageIndexExamenes = 1;

                                int index = oIdDetalleExamenes.IndexOf(treeView2.SelectedNode.Tag.ToString().Trim());
                                if (index != -1)
                                {
                                    oIdDetalleExamenes.RemoveAt(index);

                                    try
                                    {
                                        oDetalleExamenes.RemoveAt(index);
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void tobContraerExamenes_Click(object sender, EventArgs e)
        {
            treeView2.CollapseAll();
        }

        private void tobExpandirExamenes_Click(object sender, EventArgs e)
        {
            treeView2.ExpandAll();
        }

        private void txtDetalleAdicionalExamenes_TextChanged(object sender, EventArgs e)
        {
            if (nuevo == true || modificar == true)
            {
                if (nodeImageIndexExamenes == 2)
                {
                    int index = oIdDetalleExamenes.IndexOf(currentNodeExamenes.ToString().Trim());

                    if (oIdDetalleExamenes.Contains(currentNodeExamenes.ToString().Trim()))
                    {
                        try
                        {
                            oIdDetalleExamenes[index] = currentNodeExamenes.ToString().Trim();//.RemoveAt(index);
                            oDetalleExamenes[index] = txtDetalleAdicionalExamenes.Text.Trim();//.RemoveAt(index);
                        }
                        catch { }
                    }

                    //oIdDetalleExamenes.Add(currentNodeExamenes.ToString().Trim());
                    //oDetalleExamenes.Add(txtDetalleAdicionalExamenes.Text.Trim());
                }
            }
        }

        private void treeView2_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //if (nuevo == true)
            //{
            //    if (txtDetalleAdicionalExamenes.Text.Trim() != String.Empty)
            //    {
            //        if (nodeImageIndexExamenes == 2)
            //        {
            //            int index = oIdDetalleExamenes.IndexOf(currentNodeExamenes.ToString().Trim());

            //            if (oIdDetalleExamenes.Contains(currentNodeExamenes.ToString().Trim()))
            //            {
            //                try
            //                {
            //                    oIdDetalleExamenes.RemoveAt(index);
            //                    oDetalleExamenes.RemoveAt(index);
            //                }
            //                catch { }
            //            }

            //            oIdDetalleExamenes.Add(currentNodeExamenes.ToString().Trim());
            //            oDetalleExamenes.Add(txtDetalleAdicionalExamenes.Text.Trim());
            //        }
            //    }
            //}
        }

        private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (nuevo == true || modificar == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.Node.Parent != null)
                    {
                        KeyEventArgs e2 = new KeyEventArgs(Keys.Enter);
                        treeView2_KeyDown(sender, e2);
                    }
                }
            }
        }

        #endregion

        private void tobCerrar_Click(object sender, EventArgs e)
        {
            if (TxtNumExpediente.Text.Trim() != "")
            {
                if (MessageBox.Show(this, "¿Realmente desea cerrar las consultas abiertas?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    txtFoco.Focus();

                    LimpiarCampos();
                    BloquearCampos();

                    ModoBloqueo();

                    lstGabineteConsulta.Visible = false;
                    panelGabineteConsulta.Visible = true;

                    lstExamenesConsulta.Visible = false;
                    panelExamenes.Visible = true;

                    panelCancelMenstruacion.Visible = false;

                    lblFURNoDisponible.Visible = false;
                    tobUsarFUR.Enabled = false;
                    tobUsarFUR.Image = Properties.Resources.ok__1_;
                    furDisponible = true;
                }
            }
        }

        #region Imágenes Consulta

        //private void btnAgregarImagen_Click(object sender, EventArgs e)
        //{
        //    try
        //    {                
        //        numImage = //flowLayoutPanel1.Controls.Count;// - 1;

        //        if (numImage < 0)
        //            numImage = 0;

        //        txtFoco.Focus();

        //        openFileDialog1.FileName = "";
        //        openFileDialog1.Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|*.png|BMP(*.bmp)|*.bmp|Todos(*.Jpg, *.Png, *.Jpeg, *.Bmp)|*.Jpg; *.Png; *.Jpeg; *.Bmp";
        //        openFileDialog1.FilterIndex = 4;
        //        openFileDialog1.RestoreDirectory = true;
        //        openFileDialog1.Multiselect = true;

        //        DialogResult Respuesta = openFileDialog1.ShowDialog();

        //        if (Respuesta != DialogResult.Cancel)
        //        {
        //            //if (openFileDialog1.FileNames.Length + numImage <= 600)
        //            //{

        //            foreach (string oFileName in openFileDialog1.FileNames)
        //            {
        //                numImage++;

        //                oPict = new PictureBox();
        //                oPict.Size = new Size(180, 180);
        //                oPict.Image = Properties.Resources.frame2;
        //                oPict.SizeMode = PictureBoxSizeMode.StretchImage;

        //                oPict.BackgroundImage = SafeImage.NonLockingOpen(oFileName.Trim());

        //                oPict.BackgroundImageLayout = ImageLayout.Stretch;
        //                oPict.Region = Shape.RoundedRegion(oPict.Size, 3, Shape.Corner.None);

        //                if (nuevo == true)
        //                    oPict.Tag = oFileName.Trim();
        //                else
        //                    oPict.Tag = numImage.ToString();

        //                oPict.Name = numImage.ToString();

        //                oGraphics = oPict.CreateGraphics();
        //                oGraphicsPath.AddRectangle(oPict.Bounds);

        //                oPict.MouseEnter += new EventHandler(oPict_MouseEnter);
        //                oPict.MouseLeave += new EventHandler(oPict_MouseLeave);

        //                //flowLayoutPanel1.Controls.Add(oPict);

        //                oArregloBytesImagenes.Add((byte[])ReadFile(oFileName.Trim()));
        //            }                    
        //            //}
        //            //else
        //            //    MessageBox.Show(this, "No se puede cargan más de 600 elementos a la vez", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show(this, "Error al Cargar la imagen", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    }
        //}

        //void oPict_MouseLeave(object sender, EventArgs e)
        //{
        //    panelOpcionesImagenes.Visible = false;
        //    //panel11.Visible = false;
        //}

        //void oPict_MouseEnter(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        PictureBox pb = (PictureBox)sender;
        //        foreach (Control o in //flowLayoutPanel1.Controls)
        //        {
        //            if (o.Tag.ToString().Trim() == pb.Tag.ToString().Trim())
        //            {
        //                panel11.Parent = o;
        //                break;
        //            }
        //        }

        //        auxPBox = pb;
        //        direccImage = pb.Tag.ToString().Trim();

        //        panel11.Location = new Point(107, 145);
        //        panel11.BringToFront();
        //        panel11.Visible = true;
        //    }
        //    catch { }
        //}

        //private void //flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    mouseX = e.X;
        //    mouseY = e.Y;

        //    if (oGraphicsPath.IsVisible(mouseX, mouseY))
        //    {
        //        //panelOpcionesImagenes.Visible = true;
        //        panelOpcionesImagenes.Location = new Point(107, 145);
        //        tobOpcionesImagen.Focus();
        //    }
        //    else
        //    {
        //        panelOpcionesImagenes.Visible = false;
        //        panel11.Visible = false;
        //    }
        //}

        //private void tobEliminarImage_Click_1(object sender, EventArgs e)
        //{
        //    if (modificar == true)
        //    {
        //        oArregloBytesImagenes.RemoveAt(Convert.ToInt32(auxPBox.Tag) - 1);

        //        string tagIndex = "";
        //        foreach (Control oControl in //flowLayoutPanel1.Controls)
        //        {
        //            tagIndex = oControl.Tag.ToString();

        //            if (Convert.ToInt32(tagIndex) > Convert.ToInt32(auxPBox.Tag))
        //                oControl.Tag = Convert.ToString((Convert.ToInt32(oControl.Tag) - 1));
        //        }
        //    }

        //    panel11.Visible = false;
        //    panel11.Parent = null;
        //    auxPBox.Dispose();
        //}

        //private void tobMagnifyImage_Click(object sender, EventArgs e)
        //{
        //    FrmBlackBackground oFrmBlackBackground = new FrmBlackBackground();

        //    try
        //    {                
        //        oFrmBlackBackground.Show();

        //        if (nuevo == true)
        //        {
        //            FrmImagenAmpliada oFrmImagenAmpliada = new FrmImagenAmpliada(File.ReadAllBytes(direccImage));
        //            oFrmImagenAmpliada.ShowDialog();
        //        }
        //        else
        //        {                    
        //            FrmImagenAmpliada oFrmImagenAmpliada = new FrmImagenAmpliada((Byte[])oArregloBytesImagenes[Convert.ToInt32(direccImage) - 1]);
        //            oFrmImagenAmpliada.ShowDialog();
        //        }

        //        oFrmBlackBackground.Close();
        //    }
        //    catch 
        //    {
        //        oFrmBlackBackground.Dispose();
        //    }
        //}

        //private void btnPhotoAlbum_Click(object sender, EventArgs e)
        //{
        //    //if (//flowLayoutPanel1.Controls.Count > 0)
        //    //{
        //    //    ArrayList oArreglo = new ArrayList();
        //    //    ArrayList oArregloTags = new ArrayList();

        //    //    int cont = 0;
        //    //    foreach (PictureBox oPict in //flowLayoutPanel1.Controls)
        //    //    {
        //    //        oArreglo.Add(oPict.BackgroundImage);
        //    //        oArregloTags.Add(cont.ToString());//oPict.Tag.ToString().Trim());

        //    //        try
        //    //        {
        //    //            oArregloBytesImagenes.Add((byte[])File.ReadAllBytes(oPict.Tag.ToString().Trim()));
        //    //        }
        //    //        catch { }

        //    //        cont++;
        //    //    }

        //    //    FrmBlackBackground oFrmBlackBackground = new FrmBlackBackground();
        //    //    oFrmBlackBackground.Show();
        //    //    frmPhotoAlbum ofrmPhotoAlbum = new frmPhotoAlbum(oArreglo, oArregloTags, oArregloBytesImagenes);

        //    //    ofrmPhotoAlbum.ShowDialog();
        //    //    oFrmBlackBackground.Close();
        //    //}
        //}

        private Image ConvierteBytesImagenes(byte[] pImageData)
        {
            Image newImage = null;

            //Get image data from gridview column.
            byte[] imageData = pImageData;

            //Read image data into a memory stream
            using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
            {
                ms.Write(imageData, 0, imageData.Length);

                //Set image variable value using memory stream.
                newImage = Image.FromStream(ms, true);
            }

            return newImage;
        }

        private void ResetImageControl(bool pEnableAdd, bool pEnableDelete, bool pEnableAlbum, bool pEnablePreview)
        {
            oListGlobalElementValues = null;
            softNetImageViewer1.Dispose();

            softNetImageViewer1 = new SoftNetImageViewer();
            softNetImageViewer1.EnableButtons(pEnableAdd, pEnableDelete, pEnableAlbum, pEnablePreview);
            
            this.panel9.Controls.Add(this.softNetImageViewer1);

            softNetImageViewer1.Location = new Point(0, 0);
            softNetImageViewer1.Show();
        }

        private void LlenarImagenes(string pIdConsulta)
        {
            if (modificar == true)
                ResetImageControl(true, true, true, true);
            else //estaría en modo de consultA
                ResetImageControl(false, false, true, true);

            int cont = 0;//1;
            
            oArregloBytesImagenes.Clear();
            ////flowLayoutPanel1.Controls.Clear();

            oListGlobalElementValues = null;
            oListGlobalElementValues = new List<GlobalElementsValues>();

            oCImagenesConsulta.IdConsulta = pIdConsulta.Trim();
            DataSet ds = oCImagenesConsulta.ConsultarDataset();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        tempGlobalElementValues = new GlobalElementsValues();
                        tempGlobalElementValues.OFileName = cont.ToString();
                        tempGlobalElementValues.OBytes = (byte[])dr[1];
                        tempGlobalElementValues.OImage = ConvierteBytesImagenes((byte[])dr[1]);
                        tempGlobalElementValues.OIndex = cont;

                        oListGlobalElementValues.Add(tempGlobalElementValues);

                        cont++;
                    }

                    softNetImageViewer1.AddImages(oListGlobalElementValues);
                }
                ds.Dispose();
            }
        }

        #endregion

        private void btnAgregarVideo_Click(object sender, EventArgs e)
        {
            try
            {
                txtFoco.Focus();

                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "AVI(*.avi)|*.avi|MOV(*.mov)|*.mov|MPG(*.mpg)|*.mpg|FLV(*.flv)|*.flv|Todos(*.Avi, *.Mov, *.Mpg, *.Flv)|*.Avi; *.Mov; *.Mpg; *.Flv";
                openFileDialog1.FilterIndex = 5;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.Multiselect = true;

                DialogResult Respuesta = openFileDialog1.ShowDialog();

                if (Respuesta != DialogResult.Cancel)
                {
                    foreach (string oFileName in openFileDialog1.FileNames)
                    {
                        string videoPath = oFileName.Trim();

                        string[] parts = videoPath.Split('\\');
                        int cont = parts.Length;

                        string videoName = parts[cont - 1].Trim();

                        lstVideos.Items.Add(videoName.Trim(), 0);//"", 0);
                        //lstVideos.Items[lstVideos.Items.Count - 1].SubItems.Add(videoName.Trim());
                        lstVideos.Items[lstVideos.Items.Count - 1].SubItems.Add(videoPath.Trim());
                    }
                }
            }
            catch
            {
                MessageBox.Show(this, "Error al Cargar la foto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnReproducirVideo_Click(object sender, EventArgs e)
        {
            if (lstVideos.Items.Count > 0)
            {
                if (lstVideos.SelectedItems.Count > 0)
                {
                    int index = 0;
                    if (File.Exists(lstVideos.SelectedItems[0].SubItems[1].Text.Trim()))
                    {
                        string[] list = new string[1];
                        list.SetValue(lstVideos.SelectedItems[0].SubItems[1].Text.Trim(), index );
                        frmVideo ofrmVideoPlayer = new frmVideo();
                        ofrmVideoPlayer.softNetVideoControl1.AddFiles(list);
                        ofrmVideoPlayer.ShowDialog(this);
                    }
                    else
                        MessageBox.Show(this, "No se puede encontrar el archivo indicado, verifique la ubicación del mismo");
                }
            }
        }

        private void lstVideos_ItemActivate(object sender, EventArgs e)
        {
            if (nuevo == true || modificar == true)
            {
                if (lstVideos.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show(this, "¿Realmente desea eliminar este video?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        lstVideos.Items.Remove(lstVideos.SelectedItems[0]);
                }
            }
        }

        private void LlenarListaVideos(string pIdConsulta)
        {
            lstVideos.Items.Clear();

            oCVideosConsulta.IdConsulta = pIdConsulta.Trim();
            DataSet ds = oCVideosConsulta.ConsultarDataset();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string videoPath = dr[1].ToString().Trim();

                        string[] parts = videoPath.Split('\\');
                        int cont = parts.Length;

                        string videoName = parts[cont - 1].Trim();

                        lstVideos.Items.Add(videoName, 0);
                        lstVideos.Items[lstVideos.Items.Count - 1].SubItems.Add(videoPath.Trim());
                    }

                    btnAgregarVideo.Enabled = false;
                    btnReproducirVideo.Enabled = true;
                }
            }

            if (ds != null)
                ds.Dispose();
        }

        private void timerTraeDatosPaciente_Tick(object sender, EventArgs e)
        {
            timerTraeDatosPaciente.Stop();

            if (TxtNumExpediente.Text.Trim() != "" && TxtNumExpediente.Text.Trim() != "0")
            {
                if (nuevo == true)
                {
                    ArrayList oArregloExFisico = Program.oCPacientes.LeeExamenFisicoPaciente(TxtNumExpediente.Text.Trim());

                    if (tipoConsultaSeleccionada == 1)
                    {
                        txtPesoHabitual.Text = oArregloExFisico[0].ToString();
                        txtTalla.Text = oArregloExFisico[1].ToString();
                        txtIMC.Text = oArregloExFisico[2].ToString();
                    }
                    else
                    {
                        pesoHabitual = Program.oCPacientes.PesoHabitual(TxtNumExpediente.Text.Trim());
                        txtHabitual3.Text = pesoHabitual.ToString();

                        txtPesoHabitual2.Text = oArregloExFisico[0].ToString();
                        txtTalla2.Text = oArregloExFisico[1].ToString();
                        txtIMC2.Text = oArregloExFisico[2].ToString();
                    }
                }

                Program.oFrmDetallePaciente.NumExpediente = TxtNumExpediente.Text.Trim();
                Program.oFrmDetallePaciente.EstableceDatosPacientes();

                presentaMenarca = Program.oFrmDetallePaciente.Menarca;//Determina si al paciente ya le llegó la menstruación o no...

                if (presentaMenarca == false)
                {
                    panelCancelMenstruacion.Visible = true;

                    dtFUR.Enabled = false;
                    txtAmenorrea.Text = "";
                    txtAmenorrea.Enabled = false;
                    txtDetalleMenstruacion.Text = "";
                    txtDetalleMenstruacion.Enabled = false;

                    if (tipoConsultaSeleccionada == 2)
                        MessageBox.Show(this, "Este paciente no presenta ningún valor en la menarca por lo que no podrá generar ninguna consulta con embarazo hasta que se procedan a modificar dichos datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (nuevo == true || modificar == true)
                    {
                        panelCancelMenstruacion.Visible = false;

                        dtFUR.Enabled = true;
                        //txtAmenorrea.Text = "";
                        txtAmenorrea.Enabled = true;
                        //txtDetalleMenstruacion.Text = "";
                        txtDetalleMenstruacion.Enabled = true;
                    }
                }

                Program.oFrmExamenesConsulta = new frmExamenesConsulta(TxtNumExpediente.Text.Trim());

                Program.oFrmVideosConsulta.NumExpediente = TxtNumExpediente.Text.Trim();
                Program.oFrmVideosConsulta.LlenarCarpetas();

                Program.oFrmImagenesConsultas.NumExpediente = TxtNumExpediente.Text.Trim();
                Program.oFrmImagenesConsultas.LlenarCarpetas();

                Program.oFrmEmbarazos.NumExpediente = TxtNumExpediente.Text.Trim();
                Program.oFrmEmbarazos.LlenarCarpetas();

                if (!String.IsNullOrEmpty(Program.oFrmHistorialConsultas.SqlWhere))//Program.oFrmHistorialConsultas.searching == true)
                {
                    Program.oFrmHistorialConsultas.SqlWhere = "";

                    Program.oFrmHistorialConsultas.btnConsultar.Visible = true;
                    Program.oFrmHistorialConsultas.btnMostrarTodos.Visible = false;
                    Program.oFrmHistorialConsultas.btnConsultar2.Visible = true;
                    Program.oFrmHistorialConsultas.btnMostrarTodos2.Visible = false;
                }

                Program.oFrmHistorialConsultas.PrimeraVez = true;
                Program.oFrmHistorialConsultas.NumExpediente = TxtNumExpediente.Text.Trim();
                Program.oFrmHistorialConsultas.Buscar();
                Program.oFrmHistorialConsultas.PrimeraVez = false;
            }
        }

        private void tonCambiarOpcion_Click(object sender, EventArgs e)
        {
            if (opcionElegida == 0)//Selecciona ingresar la Fecha de Última Regla
            {
                opcionElegida = 1;

                dtFur2.Visible = false;
                dtFur2.Enabled = false;
                txtFUR.Visible = true;

                dtFPP.Enabled = true;
                dtFPP.Visible = true;
                txtFPP.Visible = false;
            }
            else//Selecciona ingresar la Fecha Probable de Parto
            {
                opcionElegida = 0;

                dtFur2.Visible = true;
                dtFur2.Enabled = true;
                txtFUR.Visible = false;

                dtFPP.Enabled = false;
                dtFPP.Visible = false;
                txtFPP.Visible = true;
            }
        }

        private void dtFur2_ValueChanged(object sender, EventArgs e)
        {
            txtFUR.Text = dtFur2.Value.ToLongDateString();

            if (opcionElegida == 0)//Selecciona ingresar la Fecha de Última Regla
                dtFPP.Value = Program.oCConsultas.CalculoFPP(dtFur2.Value);

            lblAmenorrea2.Text = Program.oCConsultas.CalculoAmenorrea(dtFur2.Value) + " Semanas con " +
                                 Program.oCConsultas.CalculoDiasAmenorrea(dtFur2.Value).ToString() + " días.";
        }

        private void dtFPP_ValueChanged(object sender, EventArgs e)
        {
            txtFPP.Text = dtFPP.Value.ToLongDateString();

            if (opcionElegida == 1)//Selecciona ingresar la Fecha de Última Regla
                dtFur2.Value = Program.oCConsultas.CalculoFUR(dtFPP.Value);
        }

        private void pBoxEmbarazoActivo_Click(object sender, EventArgs e)
        {
            if (nuevo == true || modificar == true)
            {
                if (embarazoActivo == 1)
                {
                    if (MessageBox.Show(this, "¿Está seguro que desea finalizar el Periodo de Embarazo Activo?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        embarazoActivo = 2;

                        pBoxEmbarazoActivo.Image = Properties.Resources.Active_Pregnant_Red_80;
                        pBoxEmbarazoActivo.ImagenOriginal = Properties.Resources.Active_Pregnant_Red_80;
                        pBoxEmbarazoActivo.HighlightedImage = Properties.Resources.Active_Pregnant_Red_80_highlighted;
                    }
                }
                else if (embarazoActivo == 2)
                {
                    if (MessageBox.Show(this, "¿Está seguro que desea reestablecer y continuar el Periodo de Embarazo Activo?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        embarazoActivo = 1;

                        pBoxEmbarazoActivo.Image = Properties.Resources.Active_Pregnant_Sky_Blue_80;
                        pBoxEmbarazoActivo.ImagenOriginal = Properties.Resources.Active_Pregnant_Sky_Blue_80;
                        pBoxEmbarazoActivo.HighlightedImage = Properties.Resources.Active_Pregnant_Sky_Blue_80_highlighted;
                    }
                }
            }
        }

        private void pBoxEmbarazoActivo_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void txtPesoHabitual2_TextChanged(object sender, EventArgs e)
        {
            if (txtPesoHabitual2.Text.Trim() == "" || txtPesoHabitual2.Text.Trim() == "," || txtPesoHabitual2.Text.Trim() == ".")
            {
                txtPesoHabitual2.Text = "0";
                txtPesoHabitual2.SelectAll();
            }

            if (txtTalla2.Text.Trim() != "" && txtPesoHabitual2.Text.Trim() != "")
                txtIMC2.Text = Program.oCPacientes.CalculaIMC(txtPesoHabitual2.Text.Trim(), txtTalla2.Text.Trim()).ToString();
        }

        private void txtTalla2_TextChanged(object sender, EventArgs e)
        {
            if (txtTalla2.Text.Trim() == "" || txtTalla2.Text.Trim() == "," || txtTalla2.Text.Trim() == ".")
            {
                txtTalla2.Text = "0";
                txtTalla2.SelectAll();
            }

            if (txtTalla2.Text.Trim() != "" && txtPesoHabitual2.Text.Trim() != "")
                txtIMC2.Text = Program.oCPacientes.CalculaIMC(txtPesoHabitual2.Text.Trim(), txtTalla2.Text.Trim()).ToString();
        }

        private void txtIMC2_TextChanged(object sender, EventArgs e)
        {
            if (txtIMC2.Text.Trim() == "")
                txtIMC2.Text = "0";
        }

        private void txtIMC_TextChanged(object sender, EventArgs e)
        {
            if (txtIMC.Text.Trim() == "")
                txtIMC.Text = "0";
        }

        #region Eventos de Selección Automática de texto

        private void txtPesoHabitual2_Enter(object sender, EventArgs e)
        {
            txtPesoHabitual2.SelectAll();
        }

        private void txtPesoHabitual2_Click(object sender, EventArgs e)
        {
            txtPesoHabitual2.SelectAll();
        }

        private void txtTalla2_Click(object sender, EventArgs e)
        {
            txtTalla2.SelectAll();
        }

        private void txtTalla2_Enter(object sender, EventArgs e)
        {
            txtTalla2.SelectAll();
        }

        private void txtIMC2_Click(object sender, EventArgs e)
        {
            txtIMC2.SelectAll();
        }

        private void txtIMC2_Enter(object sender, EventArgs e)
        {
            txtIMC2.SelectAll();
        }

        private void txtPesoHabitual_Click(object sender, EventArgs e)
        {
            txtPesoHabitual.SelectAll();
        }

        private void txtPesoHabitual_Enter(object sender, EventArgs e)
        {
            txtPesoHabitual.SelectAll();
        }

        private void txtTalla_Click(object sender, EventArgs e)
        {
            txtTalla.SelectAll();
        }

        private void txtTalla_Enter(object sender, EventArgs e)
        {
            txtTalla.SelectAll();
        }

        private void txtIMC_Click(object sender, EventArgs e)
        {
            txtIMC.SelectAll();
        }

        private void txtIMC_Enter(object sender, EventArgs e)
        {
            txtIMC.SelectAll();
        }

        private void TxtFrecuenciaCardiacaFetal_TextChanged(object sender, EventArgs e)
        {
            if (TxtFrecuenciaCardiacaFetal.Text.Trim() == "")
                TxtFrecuenciaCardiacaFetal.Text = "0";
        }

        private void TxtFrecuenciaCardiacaFetal_Click(object sender, EventArgs e)
        {
            TxtFrecuenciaCardiacaFetal.SelectAll();
        }

        private void TxtFrecuenciaCardiacaFetal_Enter(object sender, EventArgs e)
        {
            TxtFrecuenciaCardiacaFetal.SelectAll();
        }

        #endregion

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Program.oMDI.MdiClient_MouseMove(sender, e);
        }

        private void tobExamenesLaboratorio_Click(object sender, EventArgs e)
        {
            frmExamenesLaboratorio ofrmExamenesLaboratorio = new frmExamenesLaboratorio();
            ofrmExamenesLaboratorio.ShowDialog(this);
        }

        private void tobGabinete_Click(object sender, EventArgs e)
        {
            frmGabinete ofrmGabinete = new frmGabinete();
            ofrmGabinete.ShowDialog(this);
        }

        private void txtHabitual3_Enter(object sender, EventArgs e)
        {
            if (txtHabitual3.Text.Trim() == "")
                txtHabitual3.Text = "0";

            txtHabitual3.SelectAll();
        }

        private void tobUsarFUR_Click(object sender, EventArgs e)
        {
            if (furDisponible == true)
            {
                furDisponible = false;

                dtFUR.Value = dtFUR.MinDate;
                lblFURNoDisponible.Visible = true;
                tobUsarFUR.Image = Properties.Resources.nok__1_;
                tobUsarFUR.ToolTipText = "Dé click para Utilizar un valor específico de F.U.R";
                txtAmenorrea.Text = "Indeterminada";
            }
            else
            {
                furDisponible = true;

                lblFURNoDisponible.Visible = false;
                dtFUR.Value = DateTime.Today;
                tobUsarFUR.Image = Properties.Resources.ok__1_;
                tobUsarFUR.ToolTipText = "Dé click para No Utilizar un valor específico de F.U.R";
            }
        }

        private void btnPrescriptionFormat_Click(object sender, EventArgs e)
        {
            Program.ofrmPrescriptionPad.ShowDialog(this);
            Program.ofrmPrescriptionPad.frmPrescriptionPad_Load(sender, e);
        }

        private void txtPesoHabitual_KeyPress(object sender, KeyPressEventArgs e)
        {            
            e.Handled = Metodos_Globales.AvoidedCharacters(txtPesoHabitual.Text, e);
        }

        private void txtTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Metodos_Globales.AvoidedCharacters(txtTalla.Text, e);
        }

        private void txtHabitual3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Metodos_Globales.AvoidedCharacters(txtHabitual3.Text, e);
        }

        private void txtPesoHabitual2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Metodos_Globales.AvoidedCharacters(txtPesoHabitual2.Text, e);
        }

        private void txtTalla2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Metodos_Globales.AvoidedCharacters(txtTalla2.Text, e);
        }

        private void consultasAntiguasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modificar == false)
            {
                FrmBlackBackground oBlack = new FrmBlackBackground();
                oBlack.Show(Program.oMDI);
                
                //oBlack.MdiParent = Program.oMDI;
                oBlack.Dock = DockStyle.Fill;
                oBlack.BringToFront();
                oBlack.Size = new Size((Program.oMDI.ClientRectangle.Width - Program.oMDI.panel1.Width), Parent.Height);
                oBlack.Opacity = 0.81;
                oBlack.Location = this.PointToScreen(new Point(0,0));

                frmConsultasAntiguasV2 ofrmConsultasAntiguas = new frmConsultasAntiguasV2(0, true);
                ofrmConsultasAntiguas.ShowDialog(this);

                Program.oFrmHistorialConsultas.PrimeraVez = true;
                Program.oFrmHistorialConsultas.NumExpediente = TxtNumExpediente.Text.Trim();
                Program.oFrmHistorialConsultas.Buscar();
                Program.oFrmHistorialConsultas.PrimeraVez = false;

                oBlack.Close();
            }
        }

        private void GrabarConsulta()
        {
            RecoveryXMLFile o = new RecoveryXMLFile();
            ArrayList examenes = new ArrayList();
            ArrayList detalleExamenes = new ArrayList();
            ArrayList gabinete = new ArrayList();
            ArrayList detalleGabinete = new ArrayList();

            examenes = oIdDetalleExamenes;
            detalleExamenes = oDetalleExamenes;
            gabinete = oIdDetalleGabinete;
            detalleGabinete = oDetalleGabinete;

            ArrayList oImagenes = new ArrayList();
            if (softNetImageViewer1.GlobalElementsDetails.Count > 0)
            {
                foreach (GlobalElementsValues oElement in softNetImageViewer1.GlobalElementsDetails)
                    oImagenes.Add(oElement.OFileName);
            }
            
            ArrayList oVideos = new ArrayList();
            foreach (ListViewItem oItem in lstVideos.Items)
                oVideos.Add(oItem.SubItems[1].Text.Trim());

            o.Consultas_CreateRecoveryXMLFile(txtEditDetalleConsulta.RTF(), 
                                              txtEditDiagnostico.RTF(), 
                                              txtEditTratamiento.RTF(), 
                                              examenes, 
                                              detalleExamenes, 
                                              gabinete, 
                                              detalleGabinete, 
                                              oImagenes, 
                                              oVideos);
        }

        private void CargaArchivoRecuperacion()
        {
            try
            {
                string path = Metodos_Globales.crearCarpetaAppdata("\\RecoveryFiles");
                string PathXml = path + "\\Recovery.xml";

                if (File.Exists(PathXml.Trim()))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNodeList m_nodelist = null;

                    xmldoc.Load(PathXml.Trim());

                    m_nodelist = xmldoc.SelectNodes("/Main/DetalleConsulta");
                    foreach (XmlNode Nodo in m_nodelist)
                        txtEditDetalleConsulta.rtfText = Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes.Item(0).Value.ToString());

                    m_nodelist = xmldoc.SelectNodes("/Main/Diagnostico");
                    foreach (XmlNode Nodo in m_nodelist)
                        txtEditDetalleConsulta.rtfText = Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes.Item(0).Value.ToString());

                    m_nodelist = xmldoc.SelectNodes("/Main/Tratamiento");
                    foreach (XmlNode Nodo in m_nodelist)
                        txtEditDetalleConsulta.rtfText = Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes.Item(0).Value.ToString());

                    string[] oExamenes= null;
                    m_nodelist = xmldoc.SelectNodes("/Main/Examenes");                                        
                    foreach (XmlNode Nodo in m_nodelist)
                        oExamenes =  Metodos_Globales.MetodoSplit(Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes.Item(0).Value.ToString()), new char[] {'/'} );

                    if (oExamenes != null)
                    {
                        foreach (string oString in oExamenes)
                            oIdDetalleExamenes.Add(oString);
                    }

                    string[] detalleExamenes = null;
                    m_nodelist = xmldoc.SelectNodes("/Main/DetalleExamenes");
                    foreach (XmlNode Nodo in m_nodelist)
                        detalleExamenes = Metodos_Globales.MetodoSplit(Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes.Item(0).Value.ToString()), new char[] { '/' });

                    if (detalleExamenes != null)
                    {
                        foreach (string oString in detalleExamenes)
                            oDetalleExamenes.Add(oString);
                    }

                    string[] oGabinete = null;
                    m_nodelist = xmldoc.SelectNodes("/Main/Gabinete");
                    foreach (XmlNode Nodo in m_nodelist)
                        oGabinete = Metodos_Globales.MetodoSplit(Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes.Item(0).Value.ToString()), new char[] { '/' });

                    if (oGabinete != null)
                    {
                        foreach (string oString in oGabinete)
                            oIdDetalleGabinete.Add(oString);
                    }

                    string[] detalleGabinete = null;
                    m_nodelist = xmldoc.SelectNodes("/Main/DetalleGabinete");
                    foreach (XmlNode Nodo in m_nodelist)
                        detalleGabinete = Metodos_Globales.MetodoSplit(Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes.Item(0).Value.ToString()), new char[] { '/' });

                    if (detalleGabinete != null)
                    {
                        foreach (string oString in detalleGabinete)
                            oDetalleGabinete.Add(oString);
                    }


                    string[] imagenes = null;
                    m_nodelist = xmldoc.SelectNodes("/Main/Imagenes");
                    foreach (XmlNode Nodo in m_nodelist)
                        imagenes = Metodos_Globales.MetodoSplit(Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes.Item(0).Value.ToString()), new char[] { '|' });

                    if (imagenes != null)
                        this.softNetImageViewer1.AddImages(softNetImageViewer1.flowLayoutPanel1, imagenes, softNetImageViewer1.oPict, 1, softNetImageViewer1.progressBar1);

                }
            }
            catch { }
        }

        private void cargarArchivoDeRecuperaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargaArchivoRecuperacion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GrabarConsulta();
        }
    }
}