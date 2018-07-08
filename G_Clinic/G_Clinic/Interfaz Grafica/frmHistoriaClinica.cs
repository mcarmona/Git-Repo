using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Lógica_Negocios;
using G_Clinic.Miscelaneos_y_Recursos;
using Transitions;
using System.IO;
using System.Collections;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmHistoriaClinica : Form
    {
        Size oSize = new Size();
        Point oPanelLocation = new Point();

        CConsultasAntiguas oCConsultasAntiguas = new CConsultasAntiguas();
        frmPDFViewer ofrmPDFViewer = null;

        public void ContainerPanelLocation()
        {
            int x = 0;
            x = (this.ClientSize.Width - panel1.Width) / 2;

            if (this.VerticalScroll.Visible == true)
                panel1.Location = new Point(x - 12, this.panel1.Location.Y);
            else
                panel1.Location = new Point(x, this.panel1.Location.Y);
        }

        public frmHistoriaClinica()
        {
            InitializeComponent();            

            this.SetStyles();

            this.MdiParent = Program.oMDI;
            this.Dock = DockStyle.Fill;
            this.BringToFront();

            Grid1.AutoGenerateColumns = false;
            pictureBox2.Parent = pictureBox1;

            try
            {
                VistaConstants.SetWindowTheme(lstContactos.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstContactos.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);

                VistaConstants.SetWindowTheme(lstConsultas.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstConsultas.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
            }
            catch { }



            //this.Size = new Size((Program.oMDI.ClientRectangle.Width - Program.oMDI.panel1.Width), Parent.Height);
            oSize = this.Size;
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.Mantenimiento);

            toolTip1.SetToolTip(txtApellidos, txtApellidos.ToolTipAutoText());
        }

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
                System.Drawing.Rectangle rBackground = new System.Drawing.Rectangle(0, 0, this.Width, this.Height / 2);

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
                System.Drawing.Rectangle rBackground3 = new System.Drawing.Rectangle(0, this.Height / 2, this.Width, this.Height / 2);

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

        #region Variables

        public bool Abierto = false;

        bool Nuevo = false;
        bool Modificar = false;
        bool Consultar = false;

        bool nuevoContacto = false;
        bool modificarContacto = false;

        int Verifica;
        int Verifica2;//creada para ver si hay alguna fila seleccionada en el grid a la hora de modificar
        int negativo = 0;//Variable creada para evaluar si el valor de la edad es negativo...

        string DireccImage = "";

        byte[] InfoImagen;//Variable opcional para no tener que leer la imagen desde el disco duro, sino desde la Bd en caso de que no se modifique o elimine la imagen

        bool ImagenDisponible = false;

        //CPacientes Program.oCPacientes = new CPacientes();
        CContactosPacientes oCContactosPacientes = new CContactosPacientes();
        CDatosFamiliaresPaciente oCDatosFamiliares = new CDatosFamiliaresPaciente();
        CAntecedentesGenerales oCAntecedentesGenerales = new CAntecedentesGenerales();
        CAntecedentes_ObstetGinec oCAntecedentes_ObstetGinec = new CAntecedentes_ObstetGinec();

        AutoCompleteStringCollection oAutoComplete = new AutoCompleteStringCollection();

        public String sqlWhere = "";

        ArrayList oArregloDatosMadre = new ArrayList();
        ArrayList oArregloDatosPadre = new ArrayList();
        ArrayList oArregloExamenObserv = new ArrayList();
        ArrayList oArregloAntecedentesGenerales = new ArrayList();
        ArrayList oArregloAntecedentesObstetGinec = new ArrayList();

        ArrayList oArregloRefrescamiento = new ArrayList();

        public Point oPosition = new Point();

        /// <summary>
        /// Índice que indica el # de fila seleccionado actualmente, esto con el fin de que si el usuario da click sobre la misma fila
        /// seleccionada los datos se vuelven a cargar sin razón, ya que se dispara el evento CellEnter(), por lo que se estableció esta
        /// variable, la cual cambia c/vez que se selecciona una fila. Dicha variable se inicializa en -1 ya que nunca va a existir el
        /// SelectedIndex = -1 en una fila del grid. Dicha variable se inicializa en la barra del MDI también
        /// </summary>
        public int indiceFilaSeleccionada = -1;

        /// <summary>
        /// Índice auxiliar que almacena temporalmente el # de fila seleccionado actualmente, luego este la variable indiceFilaSeleccionada se iguala a esta
        /// para actualizar sus valores y el auxiliar índice de fila seleccionada se convierte a -1, este valor dejará de ser -1 sólamente cuando se ocupen refrescar
        /// valores de la fila actualmente seleccionada, la cual coincidirá con el valor en la variable indiceFilaSeleccionada
        /// </summary>
        public int auxIndiceFilaSeleccionada = -1;

        /// <summary>
        /// Variable que indica si se está consultando directamente desde esta pantalla o desde la barra del MDI, dicha variable 
        /// se establece en true al dar click en tobIniciarConsulta, se generó con el fin de establecer dónde se establecen los 
        /// parámetros para la búsqueda del paciente, si en el método Filtrar() local o el Filtrar() del MDI
        /// </summary>
        public bool consultaLocal = false;

        CPermisosEspeciales oCPermisosEspeciales = new CPermisosEspeciales();
        ArrayList oArregloPermisos = new ArrayList();

        int altoOriginalAntecedentes = 0;
        int altoOriginalPanel5 = 0;
        int altoOriginalPanel1 = 0;

        /// <summary>
        /// Variable creada para determinar si se utilizará la Fecha de Último PArto o no, en caso que la paciente no sepa el dato exacto...
        /// </summary>
        bool usarFUP = false;

        #endregion

        private void frmHistoriaClinica_Load(object sender, EventArgs e)
        {
            Abierto = true;

            oArregloPermisos = oCPermisosEspeciales.LeePermisos(MDIPrincipal.RolUsuario.Trim(), this.Tag.ToString().Trim());

            Program.oMDI.panel4.BackColor = Color.Black;
            Program.oMDI.pictureBox2.BackColor = Color.Black;

            LlenaComboContactos();
            HabilitaOpcionesContactos();

            if (Grid1.RowCount > 0)
            {
                //Se compara el estado después de verificar los permisos del usuario
                if (tobModificar.Enabled == true)
                    tobModificar.Enabled = true;
                else
                    tobModificar.Enabled = false;
            }

            LimpiaCamposDatosPersonales();

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip2);

            this.pictureBox1.Region = Shape.RoundedRegion(pictureBox1.Size, 3, Shape.Corner.None);

            Program.oMDI.panelOpcionesHistoriaClinica.Visible = true;
            Program.oMDI.panelOpcionesHistoriaClinica.BringToFront();

            txtFoco.Focus();

            if (Program.MostrarBarraSiempre == 1 || Program.MostraBarraInicio == 1)
            {
                Program.oMDI.BarraPacientes.Show();
                Program.oMDI.BarraPacientes.BringToFront();
            }

            oPanelLocation = panel1.Location;

            ContainerPanelLocation();
            CalculaPosicionBarra();

            altoOriginalAntecedentes = txtPatologicos.Height;
            altoOriginalPanel1 = panel1.Height;
            altoOriginalPanel5 = panel5.Height;
        }

        private void frmHistoriaClinica_FormClosed(object sender, FormClosedEventArgs e)
        {
            Abierto = false;

            if (Program.oFrmConsultas != null)
            {
                if (Program.oFrmConsultas.Activo == false)
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

            if (Program.oMDI.BarraPacientes.Visible == true)
                Program.oMDI.BarraPacientes.Visible = false;

            Program.oMDI.panelOpcionesHistoriaClinica.Visible = false;

            Program.oMDI.txtCedulaPaciente.Text = "";
            Program.oMDI.txtNombrePaciente.Text = "";
        }

        #region Eventos Misceláneos de controles

        private void CmbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Down) || e.KeyChar == Convert.ToChar(Keys.Up) || e.KeyChar == Convert.ToChar(Keys.Tab))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void CmbEstadoCivil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Down) || e.KeyChar == Convert.ToChar(Keys.Up) || e.KeyChar == Convert.ToChar(Keys.Tab))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (InfoImagen != null && ImagenDisponible == true)
                {
                    txtFoco.Focus();

                    FrmBlackBackground oFrmBlackBackground = new FrmBlackBackground();
                    oFrmBlackBackground.Show();

                    bool allowEdit = false;
                    if (Nuevo == true || Modificar == true)
                        allowEdit = true;

                    FrmImagenAmpliada oFrmImagenAmpliada = new FrmImagenAmpliada(InfoImagen, allowEdit);
                    oFrmImagenAmpliada.ShowDialog();
                    oFrmBlackBackground.Close();
                }
            }
            catch { }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = recursos.xmag_51;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = recursos.xmag_51_highlighted;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = recursos.xmag_51;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (InfoImagen != null && ImagenDisponible == true)
                pictureBox2.Image = recursos.xmag_51;
            else
                pictureBox2.Image = recursos.xmag_51_highlighted;
        }

        #endregion

        #region Métodos de Estados de Controles

        #region Datos Personales

        private void HabilitaCamposDatosPersonales()
        {
            TxtNumExpediente.Enabled = true;
            TxtNombre.Enabled = true;
            txtApellidos.Enabled = true;
            TxtCedula.Enabled = true;
            DtFecha_Naci.Enabled = true;            
            CmbSexo.Enabled = true;
            CmbEstadoCivil.Enabled = true;
            TxtDireccion.Enabled = true;
            txtApellidos.Enabled = true;
            txtOcupacion.Enabled = true;

            tobCameraOn.Enabled = true;
            tobCameraOff.Enabled = false;
            tobSnapshot.Enabled = false;
            BtnFoto.Enabled = true;
            BtnRemover.Enabled = true;

            RdNacional.Enabled = true;
            RdExtranjero.Enabled = true;
        }

        private void DeshabilitaCamposDatosPersonales()
        {
            TxtNumExpediente.Enabled = false;
            TxtNombre.Enabled = false;
            txtApellidos.Enabled = false;
            TxtCedula.Enabled = false;
            DtFecha_Naci.Enabled = false;
            CmbSexo.Enabled = false;
            CmbEstadoCivil.Enabled = false;
            TxtDireccion.Enabled = false;
            txtApellidos.Enabled = false;
            txtOcupacion.Enabled = false;

            tobCameraOn.Enabled = false;
            tobCameraOff.Enabled = false;
            tobSnapshot.Enabled = false;
            BtnFoto.Enabled = false;
            BtnRemover.Enabled = false;
            WebCamCapture.Stop();

            txtFoco.Focus();
            RdNacional.Enabled = false;
            RdExtranjero.Enabled = false;
        }

        private void LimpiaCamposDatosPersonales()
        {
            TxtNumExpediente.Text = String.Empty;
            TxtNombre.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            TxtCedula.Text = String.Empty;
            DtFecha_Naci.Value = DateTime.Today;
            TxtEdad.Text = String.Empty;
            CmbSexo.SelectedIndex = 0;
            CmbEstadoCivil.SelectedIndex = 0;
            TxtDireccion.Text = String.Empty;
            txtOcupacion.Text = String.Empty;
            RdNacional.Checked = true;
            lblJoinDate.Text = String.Empty;
        }

        #endregion

        #region Datos Familiares

        private void HabilitaCamposDatosFamiliares()
        {
            //Madre
            txtNombreMadre.Enabled = true;
            txtApellidosMadre.Enabled = true;
            txtTelefonosMadre.Enabled = true;
            txtEmailMadre.Enabled = true;
            txtObservacionesMadre.Enabled = true;

            //Padre
            txtNombrePadre.Enabled = true;
            txtApellidosPadre.Enabled = true;
            txtTelefonosPadre.Enabled = true;
            txtEmailPadre.Enabled = true;
            txtObservacionesPadre.Enabled = true;
        }

        private void DeshabilitaCamposDatosFamiliares()
        {
            //Madre
            txtNombreMadre.Enabled = false;
            txtApellidosMadre.Enabled = false;
            txtTelefonosMadre.Enabled = false;
            txtEmailMadre.Enabled = false;
            txtObservacionesMadre.Enabled = false;

            tobGuardarDatosMadre.Enabled = false;
            tobCancelarDatosMadre.Enabled = false;

            //Padre
            txtNombrePadre.Enabled = false;
            txtApellidosPadre.Enabled = false;
            txtTelefonosPadre.Enabled = false;
            txtEmailPadre.Enabled = false;
            txtObservacionesPadre.Enabled = false;

            tobGuardarDatosPadre.Enabled = false;
            tobCancelarDatosPadre.Enabled = false;
        }

        private void LimpiaCamposDatosFamiliares()
        {
            //Madre
            txtNombreMadre.Text = String.Empty;
            txtApellidosMadre.Text = String.Empty;
            txtTelefonosMadre.Text = String.Empty;
            txtEmailMadre.Text = String.Empty;
            txtObservacionesMadre.Text = String.Empty;

            //Padre
            txtNombrePadre.Text = String.Empty;
            txtApellidosPadre.Text = String.Empty;
            txtTelefonosPadre.Text = String.Empty;
            txtEmailPadre.Text = String.Empty;
            txtObservacionesPadre.Text = String.Empty;
        }

        #endregion

        #region Examen Físico y Observaciones Generales

        private void HabilitaCamposExamenObservaciones()
        {
            txtPesoHabitual.Enabled = true;
            txtTalla.Enabled = true;
            txtIMC.Enabled = true;
            txtObservacionesGenerales.Enabled = true;
            cmbTipoSangre.Enabled = true;
            rdRHNegativo.Enabled = true;
            rdRHPositivo.Enabled = true;
        }

        private void DeshabilitaCamposExamenObservaciones()
        {
            txtPesoHabitual.Enabled = false;
            txtTalla.Enabled = false;
            txtIMC.Enabled = false;
            txtObservacionesGenerales.Enabled = false;
            cmbTipoSangre.Enabled = false;
            rdRHNegativo.Enabled = false;
            rdRHPositivo.Enabled = false;

            btnGuardarExamenObservaciones.Enabled = false;
            btnCancelarExamenObservaciones.Enabled = false;
        }

        private void LimpiaCamposExamenObservaciones()
        {
            txtPesoHabitual.Text = String.Empty;
            txtTalla.Text = String.Empty;
            txtIMC.Text = String.Empty;
            cmbTipoSangre.Text = String.Empty;
            rdRHNegativo.Checked = false;
            rdRHPositivo.Checked = false;
            txtObservacionesGenerales.Text = String.Empty;
        }

        #endregion

        #region Antecedentes

        private void HabilitaCamposAntecedentes()
        {
            txtPatologicos.Enabled = true;
            txtNOPatologicos.Enabled = true;
            txtFamiliares.Enabled = true;
            txtQuirurgicos.Enabled = true;
            txtAlergias.Enabled = true;
            txtMedicamentos.Enabled = true;
            txtOtros.Enabled = true;
        }

        private void DeshabilitaCamposAntecedentes()
        {
            txtPatologicos.Enabled = false;
            txtNOPatologicos.Enabled = false;
            txtFamiliares.Enabled = false;
            txtQuirurgicos.Enabled = false;
            txtAlergias.Enabled = false;
            txtMedicamentos.Enabled = false;
            txtOtros.Enabled = false;

            btnGuardarAntecedentesGenerales.Enabled = false;
            btnCancelarAntecedGenerales.Enabled = false;
        }

        private void LimpiaCamposAntecedentes()
        {
            txtPatologicos.Text = String.Empty;
            txtNOPatologicos.Text = String.Empty;
            txtFamiliares.Text = String.Empty;
            txtQuirurgicos.Text = String.Empty;
            txtAlergias.Text = String.Empty;
            txtMedicamentos.Text = String.Empty;
            txtOtros.Text = String.Empty;
        }

        #endregion

        #endregion

        #region Modos

        private void ModoIniciarConsulta()
        {
            Consultar = true;

            TxtNumExpediente.Enabled = true;
            TxtNumExpediente.ReadOnly = false;
            TxtNombre.Enabled = true;
            txtApellidos.Enabled = true;
            TxtCedula.Enabled = true;
            DtFecha_Naci.Enabled = true;
            CmbSexo.Enabled = true;
            CmbEstadoCivil.Enabled = true;
            TxtDireccion.Enabled = false;
            txtOcupacion.Enabled = false;
            BtnFoto.Enabled = false;
            BtnRemover.Enabled = false;

            LimpiaCamposDatosPersonales();

            Metodos_Globales.ModoConsulta(toolStrip1);

            Grid1.Enabled = false;

            RdExtranjero.Enabled = true;
            RdNacional.Enabled = true;

            BtnFoto.Enabled = false;
            BtnRemover.Enabled = false;

            lstContactos.Items.Clear();
            tobEliminarContacto.Enabled = false;
            tobModificarContacto.Enabled = false;
            tobNuevoContacto.Enabled = false;
            tobGuardarContacto.Enabled = false;
            tobCancelarContacto.Enabled = false;

            TxtNumExpediente.ReadOnly = false;

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip2);
        }

        private void ModoEscritura()
        {
            Nuevo = true;
            Modificar = false;
            Consultar = false;

            Grid1.DataSource = null;

            InfoImagen = null;
            pictureBox1.Image = null;

            lstContactos.Items.Clear();
            HabilitaOpcionesContactos();

            LimpiaCamposDatosPersonales();
            LimpiaCamposDatosFamiliares();
            LimpiaCamposExamenObservaciones();
            LimpiaCamposAntecedentes();
            LimpiaCamposAntecedentesObstetGinec();

            DeshabilitaCamposAntecedentes();
            DeshabilitaCamposExamenObservaciones();
            DeshabilitaCamposDatosFamiliares();
            DeshabilitaCamposAntecedentesObstetGinec();
            HabilitaCamposDatosPersonales();

            btnReturn.Enabled = false;
            btnMagnify.Enabled = false;
            btnGuardarExamenObservaciones.Enabled = false;
            btnGuardarAntecedentesGenerales.Enabled = false;
            btnCancelarAntecedObstetGinec.Enabled = false;
            btnGuardarAntecedObstetGinec.Enabled = false;
            btnCancelarExamenObservaciones.Enabled = false;
            btnCancelarAntecedGenerales.Enabled = false;
            tobCancelarDatosMadre.Enabled = false;
            tobGuardarDatosMadre.Enabled = false;
            tobGuardarDatosPadre.Enabled = false;
            tobCancelarDatosPadre.Enabled = false;

            Metodos_Globales.ModoEscritura(toolStrip1);

            Grid1.Enabled = false;

            TxtNumExpediente.ReadOnly = true;

            BtnFoto.Enabled = true;
            BtnRemover.Enabled = true;

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip2);
        }

        private void ModoModificar()
        {
            Nuevo = false;
            Modificar = true;

            HabilitaCamposDatosPersonales();

            Metodos_Globales.ModoModificar(toolStrip1);

            Grid1.Enabled = false;

            BtnFoto.Enabled = true;
            BtnRemover.Enabled = true;

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip2);

            tobEliminarContacto.Enabled = false;
            tobModificarContacto.Enabled = false;
            tobNuevoContacto.Enabled = false;
            tobGuardarContacto.Enabled = false;
            tobCancelarContacto.Enabled = false;

            TxtNumExpediente.ReadOnly = true;
        }

        private void ModoBloqueo()
        {
            txtFoco.Focus();

            Nuevo = false;
            Modificar = false;

            if (Grid1.RowCount == 0)
            {
                DeshabilitaCamposDatosFamiliares();
                DeshabilitaCamposExamenObservaciones();
                DeshabilitaCamposAntecedentes();
                DeshabilitaCamposAntecedentesObstetGinec();
            }
            else
            {                
                if (txtNombreMadre.Enabled == false)
                    HabilitaCamposDatosFamiliares();

                if (txtPesoHabitual.Enabled == false)
                    HabilitaCamposExamenObservaciones();

                //Estos campos son únicamente para doctores osea administradores, mas adelante se hará más flexible, por ahorita quedará así...
                if (MDIPrincipal.RolUsuario == "Administrador")
                {
                    if (txtPatologicos.Enabled == false)
                        HabilitaCamposAntecedentes();

                    if (txtGesta.Enabled == false)
                        HabilitaCamposAntecedentesObstetGinec();
                }
                else
                {
                    if ((bool)oArregloPermisos[4] == true)
                    {
                        if (txtPatologicos.Enabled == false)
                            HabilitaCamposAntecedentes();

                        if (txtGesta.Enabled == false)
                            HabilitaCamposAntecedentesObstetGinec();
                    }
                    else
                    {

                        DeshabilitaCamposAntecedentes();
                        DeshabilitaCamposAntecedentesObstetGinec();

                        LimpiaCamposAntecedentes();
                        LimpiaCamposAntecedentesObstetGinec();
                    }
                }

                btnReturn.Enabled = false;
                btnMagnify.Enabled = false;
                btnGuardarExamenObservaciones.Enabled = false;
                btnGuardarAntecedentesGenerales.Enabled = false;
                btnCancelarAntecedObstetGinec.Enabled = false;
                btnGuardarAntecedObstetGinec.Enabled = false;
                btnCancelarExamenObservaciones.Enabled = false;
                btnCancelarAntecedGenerales.Enabled = false;
                tobCancelarDatosMadre.Enabled = false;
                tobGuardarDatosMadre.Enabled = false;
                tobGuardarDatosPadre.Enabled = false;
                tobCancelarDatosPadre.Enabled = false;
            }

            if (Grid1.Rows.Count > 0)
                tobModificar.Enabled = true;
            else
                pictureBox1.Image = null;

            Metodos_Globales.ModoBloqueo(toolStrip1, Grid1);

            Grid1.Enabled = true;

            BtnFoto.Enabled = false;
            BtnRemover.Enabled = false;
            DireccImage = "";
            InfoImagen = null;
            ImagenDisponible = false;

            TxtNumExpediente.ReadOnly = true;

            DeshabilitaCamposDatosPersonales();

            this.VerticalScroll.Visible = true;

            TamañosOriginales();

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip2);
        }

        #endregion

        private void LimpiarArreglos()
        {
            oArregloAntecedentesObstetGinec.Clear();
            oArregloAntecedentesGenerales.Clear();
            oArregloDatosMadre.Clear();
            oArregloDatosPadre.Clear();
            oArregloExamenObserv.Clear();            
        }

        #region Eventos Click de Barra de Herramientas

        public void tobNuevo_Click(object sender, EventArgs e)
        {
            if (Grid1.RowCount > 0)
            {
                Program.oMDI.vScroll_HistoriaClinica = 0;
                txtFoco.Focus();
                if (MessageBox.Show(this, "Para ingresar un nuevo paciente al sistema deberá de cerrar los expedientes actualmente abiertos, ¿Desea realizar estas acciones en este momento?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Nuevo = true;
                    CerrarExpedientes();
                    tobCerrar.Enabled = false;

                    ModoEscritura();
                    InfoImagen = null;
                    TxtNombre.Focus();
                    this.VerticalScroll.Visible = false;
                }
            }
            else
            {
                ModoEscritura();
                InfoImagen = null;
                TxtNombre.Focus();
                this.VerticalScroll.Visible = false;
            }
        }

        private void tobModificar_Click(object sender, EventArgs e)
        {
            ModoModificar();
        }

        private void tobGuardar_Click(object sender, EventArgs e)
        {
            byte[] imageData = null;
            StringBuilder Sql = new StringBuilder("");

            if (Nuevo == true)
            {
                // Inserta
                VerificaCampo();

                if (Verifica == 0)
                {
                    if (RdNacional.Checked == true)
                        Program.oCPacientes.TipoCedula = "0";
                    else
                        Program.oCPacientes.TipoCedula = "1";

                    Program.oCPacientes.Cedula = TxtCedula.Text.Trim();
                    Program.oCPacientes.Nombre = TxtNombre.Text.Trim();
                    Program.oCPacientes.Apellidos = txtApellidos.Text.Trim();

                    if (CmbSexo.Text == "Masculino")
                        Program.oCPacientes.Sexo = "0";
                    else if (CmbSexo.Text == "Femenino")
                        Program.oCPacientes.Sexo = "1";
                    else
                        Program.oCPacientes.Sexo = "2";

                    Program.oCPacientes.FechaNacimiento = DtFecha_Naci.Value;

                    //Casada
                    //Soltera
                    //Unión Libre
                    //Separada
                    //Viuda
                    //Divorciada
                    if (CmbEstadoCivil.Text == "Casada")
                        Program.oCPacientes.EstadoCivil = "0";
                    else if (CmbEstadoCivil.Text == "Soltera")
                        Program.oCPacientes.EstadoCivil = "1";
                    else if (CmbEstadoCivil.Text == "Unión Libre")
                        Program.oCPacientes.EstadoCivil = "2";
                    else if (CmbEstadoCivil.Text == "Separada")
                        Program.oCPacientes.EstadoCivil = "3";
                    else if (CmbEstadoCivil.Text == "Viuda")
                        Program.oCPacientes.EstadoCivil = "4";
                    else
                        Program.oCPacientes.EstadoCivil = "5";

                    Program.oCPacientes.Ocupacion = txtOcupacion.Text.Trim();
                    Program.oCPacientes.Domicilio = TxtDireccion.Text.Trim();

                    imageData = ReadFile(DireccImage.Trim());

                    if (imageData == null)
                    {
                        imageData = InfoImagen;
                        Program.oCPacientes.InfoImagen = imageData;
                    }
                    else
                        Program.oCPacientes.InfoImagen = imageData;

                    Program.oCPacientes.Observaciones = "";
                    Program.oCPacientes.Talla = "";
                    Program.oCPacientes.Peso = "";
                    Program.oCPacientes.IMC = "";
                    Program.oCPacientes.Tipo_sangre = "";
                    Program.oCPacientes.Factor_rh = "";

                    if (imageData != null)
                        Program.oCPacientes.Insertar();
                    else
                        Program.oCPacientes.Insertar_NoImage();

                    if (Program.oPersistencia.IsError == false)
                    {
                        //Selecciona el último paciente ingresado
                        TxtNumExpediente.Text = Program.oCPacientes.Consulta_MaxNumExpediente();
                        Program.oCPacientes.NumExpediente = Convert.ToInt32(TxtNumExpediente.Text.Trim());

                        Metodos_Globales.LlenarGrid(Grid1, Program.oCPacientes.ConsultarConParametros("num_expediente"));

                        Grid1.Rows[Grid1.Rows.GetLastRow(DataGridViewElementStates.None)].Selected = true;
                        DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, Grid1.Rows.GetLastRow(DataGridViewElementStates.None));

                        if (imageData != null)
                            Grid1.SelectedRows[0].Cells["Imagen"].Value = imageData;

                        Grid1_CellEnter(sender, e2);
                        Grid1.FirstDisplayedScrollingRowIndex = Grid1.Rows.GetLastRow(DataGridViewElementStates.None);

                        txtFoco.Focus();

                        tobCancelar_Click(sender, e);

                        if (MessageBox.Show(this, "¿Desea agregar un contacto para el paciente en estos momentos?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            Nuevo = true;
                            tobNuevoContacto_Click(sender, e);
                        }
                    }
                }
            }//Fin del If
            else if (Modificar == true)
            {
                Nuevo = false;

                Verifica_Datos_Seleccionados();

                VerificaCampo();

                if (Verifica2 == 0)
                {
                    if (Verifica == 0)
                    {
                        Program.oCPacientes.NumExpediente = Convert.ToInt32(TxtNumExpediente.Text.Trim());

                        if (RdNacional.Checked == true)
                            Program.oCPacientes.TipoCedula = "0";
                        else
                            Program.oCPacientes.TipoCedula = "1";

                        Program.oCPacientes.Cedula = TxtCedula.Text.Trim();
                        Program.oCPacientes.Nombre = TxtNombre.Text.Trim();
                        Program.oCPacientes.Apellidos = txtApellidos.Text.Trim();

                        if (CmbSexo.Text == "Masculino")
                            Program.oCPacientes.Sexo = "0";
                        else if (CmbSexo.Text == "Femenino")
                            Program.oCPacientes.Sexo = "1";
                        else
                            Program.oCPacientes.Sexo = "2";

                        Program.oCPacientes.FechaNacimiento = DtFecha_Naci.Value;

                        //Casada
                        //Soltera
                        //Unión Libre
                        //Separada
                        //Viuda
                        //Divorciada
                        if (CmbEstadoCivil.Text == "Casada")
                            Program.oCPacientes.EstadoCivil = "0";
                        else if (CmbEstadoCivil.Text == "Soltera")
                            Program.oCPacientes.EstadoCivil = "1";
                        else if (CmbEstadoCivil.Text == "Unión Libre")
                            Program.oCPacientes.EstadoCivil = "2";
                        else if (CmbEstadoCivil.Text == "Separada")
                            Program.oCPacientes.EstadoCivil = "3";
                        else if (CmbEstadoCivil.Text == "Viuda")
                            Program.oCPacientes.EstadoCivil = "4";
                        else
                            Program.oCPacientes.EstadoCivil = "5";

                        Program.oCPacientes.Ocupacion = txtOcupacion.Text.Trim();
                        Program.oCPacientes.Domicilio = TxtDireccion.Text.Trim();

                        imageData = ReadFile(DireccImage.Trim());

                        if (imageData == null)
                        {
                            imageData = InfoImagen;
                            Program.oCPacientes.InfoImagen = imageData;
                        }
                        else
                            Program.oCPacientes.InfoImagen = imageData;

                        Program.oCPacientes.Observaciones = "";
                        Program.oCPacientes.Talla = "";
                        Program.oCPacientes.Peso = "";
                        Program.oCPacientes.IMC = "";
                        Program.oCPacientes.Tipo_sangre = "";
                        Program.oCPacientes.Factor_rh = "";

                        if (imageData != null)
                            Program.oCPacientes.Modificar();
                        else
                            Program.oCPacientes.Modificar_NoImage();

                        if (Program.oPersistencia.IsError == false)
                        {
                            tobCancelar_Click(sender, e);
                            RefrescaValoresEnGrid(Grid1.SelectedRows);

                            DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, indiceFilaSeleccionada);
                            indiceFilaSeleccionada = -1;                            

                            if (imageData != null)
                                Grid1.SelectedRows[0].Cells["Imagen"].Value = imageData;

                            Grid1_CellEnter(sender, e2);
                        }
                    }
                }
                //fin modificar

                txtFoco.Focus();
            }
        }

        private void tobCancelar_Click(object sender, EventArgs e)
        {
            //Metodos_Globales.LlenarGrid(Grid1, Program.oCPacientes.ConsultarSinParametros());
            ModoBloqueo();

            if (Grid1.RowCount > 0)
                tobCerrar.Enabled = true;            
        }

        private void tobIniciarConsulta_Click(object sender, EventArgs e)
        {
            consultaLocal = true;
            ModoIniciarConsulta();

            LimpiaCamposDatosPersonales();
            LimpiaCamposDatosFamiliares();
            LimpiaCamposExamenObservaciones();
            LimpiaCamposAntecedentes();
            LimpiaCamposAntecedentesObstetGinec();

            DeshabilitaCamposDatosFamiliares();
            DeshabilitaCamposExamenObservaciones();
            DeshabilitaCamposAntecedentes();
            DeshabilitaCamposAntecedentesObstetGinec();

            btnReturn.Enabled = false;
            //btnMagnify.Enabled = false;
            btnGuardarExamenObservaciones.Enabled = false;
            btnGuardarAntecedentesGenerales.Enabled = false;
            btnCancelarExamenObservaciones.Enabled = false;
            btnCancelarAntecedObstetGinec.Enabled = false;
            btnGuardarAntecedObstetGinec.Enabled = false;
            btnCancelarAntecedGenerales.Enabled = false;
            tobCancelarDatosMadre.Enabled = false;
            tobGuardarDatosMadre.Enabled = false;
            tobGuardarDatosPadre.Enabled = false;
            tobCancelarDatosPadre.Enabled = false;

            tobCerrar.Enabled = false;

            CmbSexo.SelectedIndex = -1;
            CmbEstadoCivil.SelectedIndex = -1;
            RdExtranjero.Checked = false;
            RdNacional.Checked = false;
            TxtNumExpediente.Enabled = true;

            TxtNumExpediente.Focus();

            pictureBox1.Image = null;
            BtnFoto.Enabled = false;
            BtnRemover.Enabled = false;
            DireccImage = "";
            InfoImagen = null;
            ImagenDisponible = false;
        }

        /// <summary>
        /// Establece la cadena que contendrá los parámetros por medio de los cuales se realizará la consulta del paciente correspondiente
        /// Dichos parámetros se establecen de acuerdo al tag que contengan los controles correspondientes
        /// </summary>
        /// <param name="oControl">Recibe el control del cual se extraerá el valor del "Tag" correspondiente y de esta forma
        /// se irá concatenando la cadena que contiene los parámetros para la sentencia</param>
        public void CadenaFiltrado(Control oControl)
        {
            if (String.IsNullOrEmpty(sqlWhere))
                sqlWhere += oControl.Tag.ToString().Trim() + ",";
            else
                sqlWhere += oControl.Tag.ToString().Trim() + ",";

            if (sqlWhere.Trim().CompareTo("Where") == 0)
            {
                sqlWhere = "";
            }
        }

        /// <summary>
        /// Establece los campos por los cuales se filtrará dependiendo si hay valores o no en los mismos
        /// </summary>
        public void Filtrar()
        {
            sqlWhere = "";

            if (TxtNumExpediente.Text.Trim() != "")
                CadenaFiltrado(TxtNumExpediente);

            if (RdExtranjero.Checked == true || RdNacional.Checked == true)
                CadenaFiltrado(RdExtranjero);

            if (TxtCedula.Text.Trim() != "")
                CadenaFiltrado(TxtCedula);

            if (TxtNombre.Text.Trim() != "")
                CadenaFiltrado(TxtNombre);

            if (txtApellidos.Text.Trim() != "")
                CadenaFiltrado(txtApellidos);

            if (TxtEdad.Text.Trim() != "" && txtOcupacion.Text.Trim() != "0")
                CadenaFiltrado(DtFecha_Naci);

            if (CmbSexo.SelectedIndex != -1)
                CadenaFiltrado(CmbSexo);

            if (CmbEstadoCivil.SelectedIndex != -1)
                CadenaFiltrado(CmbEstadoCivil);

            if (txtOcupacion.Text.Trim() != "")
                CadenaFiltrado(txtOcupacion);
        }

        public void ReiniciaValoresForm()
        {
            Grid1.DataSource = null;

            LimpiaCamposDatosPersonales();
            LimpiaCamposDatosFamiliares();
            LimpiaCamposExamenObservaciones();
            LimpiaCamposAntecedentes();
            LimpiaCamposAntecedentesObstetGinec();

            DeshabilitaCamposDatosPersonales();
            DeshabilitaCamposDatosFamiliares();
            DeshabilitaCamposExamenObservaciones();
            DeshabilitaCamposAntecedentes();
            DeshabilitaCamposAntecedentesObstetGinec();

            btnReturn.Enabled = false;
            btnMagnify.Enabled = false;
            btnGuardarExamenObservaciones.Enabled = false;
            btnGuardarAntecedentesGenerales.Enabled = false;
            btnCancelarAntecedObstetGinec.Enabled = false;
            btnGuardarAntecedObstetGinec.Enabled = false;
            btnCancelarExamenObservaciones.Enabled = false;
            btnCancelarAntecedGenerales.Enabled = false;
            tobCancelarDatosMadre.Enabled = false;
            tobGuardarDatosMadre.Enabled = false;
            tobGuardarDatosPadre.Enabled = false;
            tobCancelarDatosPadre.Enabled = false;

            CmbSexo.SelectedIndex = -1;
            CmbEstadoCivil.SelectedIndex = -1;
            RdExtranjero.Checked = false;
            RdNacional.Checked = false;
            TxtNumExpediente.Enabled = true;
        }

        public void Almacena_Valores_Para_Refrescamientos_Datos()
        {
            #region Establece valores en la clase de Empleados

            oArregloRefrescamiento.Add(Program.oCPacientes.NumExpediente);
            oArregloRefrescamiento.Add(Program.oCPacientes.TipoCedula);
            oArregloRefrescamiento.Add(Program.oCPacientes.Cedula);
            oArregloRefrescamiento.Add(Program.oCPacientes.Nombre);
            oArregloRefrescamiento.Add(Program.oCPacientes.Apellidos);
            oArregloRefrescamiento.Add(Program.oCPacientes.FechaNacimiento);
            oArregloRefrescamiento.Add(Program.oCPacientes.Sexo);
            oArregloRefrescamiento.Add(Program.oCPacientes.EstadoCivil);
            oArregloRefrescamiento.Add(Program.oCPacientes.Ocupacion);

            #endregion
        }

        public void tobEjecutarConsulta_Click(object sender, EventArgs e)
        {
            Consultar = false;

            if (consultaLocal == true)
            {
                #region Establece valores en la clase de Pacientes

                if (TxtNumExpediente.Text.Trim() != "")
                    Program.oCPacientes.NumExpediente = Convert.ToInt32(TxtNumExpediente.Text.Trim());
                else
                    Program.oCPacientes.NumExpediente = 0;

                if (RdExtranjero.Checked == true || RdNacional.Checked == true)
                {
                    if (RdNacional.Checked == true)
                        Program.oCPacientes.TipoCedula = "0";
                    else
                        Program.oCPacientes.TipoCedula = "1";
                }
                else
                    Program.oCPacientes.TipoCedula = null;

                if (TxtCedula.Text.Trim() != "")
                    Program.oCPacientes.Cedula = TxtCedula.Text.Trim();
                else
                    Program.oCPacientes.Cedula = null;

                if (TxtNombre.Text.Trim() != "")
                    Program.oCPacientes.Nombre = TxtNombre.Text.Trim();
                else
                    Program.oCPacientes.Nombre = null;

                if (txtApellidos.Text.Trim() != "")
                    Program.oCPacientes.Apellidos = txtApellidos.Text.Trim();
                else
                    Program.oCPacientes.Apellidos = null;

                if (TxtEdad.Text.Trim() != "" && txtOcupacion.Text.Trim() != "0")
                    Program.oCPacientes.FechaNacimiento = DtFecha_Naci.Value;
                else
                    Program.oCPacientes.FechaNacimiento = DateTime.MinValue;

                if (CmbSexo.SelectedIndex != -1)
                    Program.oCPacientes.Sexo = CmbSexo.SelectedIndex.ToString().Trim();
                else
                    Program.oCPacientes.Sexo = null;

                if (CmbEstadoCivil.SelectedIndex != -1)
                    Program.oCPacientes.EstadoCivil = CmbEstadoCivil.SelectedIndex.ToString().Trim();
                else
                    Program.oCPacientes.EstadoCivil = null;

                if (txtOcupacion.Text.Trim() != "")
                    Program.oCPacientes.Ocupacion = txtOcupacion.Text.Trim();
                else
                    Program.oCPacientes.Ocupacion = null;

                #endregion

                Filtrar();
            }

            if (sqlWhere.EndsWith(","))//El sqlWhere se establece en el método "CadenaFiltrado"
                sqlWhere = sqlWhere.Substring(0, sqlWhere.Length - 1);

            Almacena_Valores_Para_Refrescamientos_Datos();

            Metodos_Globales.LlenarGrid(Grid1, Program.oCPacientes.ConsultarConParametros(sqlWhere));

            if (Grid1.Rows.Count == 0)
            {
                MessageBox.Show(this, "No se encontraron resultados que coincidan con los parámetros de su búsqueda.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (consultaLocal == true)
                    tobIniciarConsulta_Click(sender, e);
            }
            else
            {
                txtFoco.Focus();

                Nuevo = false;
                Modificar = false;

                Metodos_Globales.ModoEjecucionConsulta(toolStrip1, Grid1);

                //HabilitaOpcionesContactos();

                DeshabilitaCamposDatosPersonales();
                HabilitaCamposDatosFamiliares();
                HabilitaCamposExamenObservaciones();

                btnGuardarAntecedObstetGinec.Enabled = false;
                btnCancelarAntecedObstetGinec.Enabled = false;

                Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip2);

                Grid1.Enabled = true;
                Consultar = true;

                indiceFilaSeleccionada = -1;
                DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, Grid1.Rows.GetFirstRow(DataGridViewElementStates.None));
                Grid1_CellEnter(sender, e2);

                tobCerrar.Enabled = true;
                consultaLocal = false;

                txtMenarca_TextChanged(sender, e);

                if (MDIPrincipal.RolUsuario == "Administrador")
                {
                    HabilitaCamposAntecedentes();
                    HabilitaCamposAntecedentesObstetGinec();
                }
                else
                {
                    if ((bool)oArregloPermisos[4] == true)
                    {
                        HabilitaCamposAntecedentes();
                        HabilitaCamposAntecedentesObstetGinec();
                    }
                    else
                    {
                        DeshabilitaCamposAntecedentes();
                        DeshabilitaCamposAntecedentesObstetGinec();

                        LimpiaCamposAntecedentesObstetGinec();
                        LimpiaCamposAntecedentes();
                    }
                }

                btnGuardarAntecedObstetGinec.Enabled = false;
            }
        }

        private void tobCancelarConsulta_Click(object sender, EventArgs e)
        {            
            tobCancelar_Click(sender, e);
        }

        public void tobSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Métodos Misceláneos

        private void LlenaComboContactos()
        {
            cmbContactos.DataSource = null;
            Metodos_Globales.LlenarCombo(cmbContactos, "Sp_S_Tipo_Contacto", "Tipo_Contactos", "id_tipo_contacto", "descripcion");
        }

        private void VerificaCampo()
        {
            Verifica = 0;
            negativo = 0;//Variable creada para evaluar si el valor de la edad es negativo...
            int X = 0;

            if (TxtNombre.Text.Trim().Trim() == "")
            {
                Verifica = 1;
                MessageBox.Show(this, "No hay ningun valor en Nombre, Ingrese algun valor para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtNombre.Focus();
            }

            if (TxtCedula.Text.Trim().Trim() == "")
            {
                Verifica = 1;
                MessageBox.Show(this, "No hay ningun valor en Cedula, Ingrese algun valor para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtCedula.Focus();
            }

            if (TxtDireccion.Text.Trim() == "")
            {
                Verifica = 1;
                MessageBox.Show(this, "No hay ningun valor en Dirección, Ingrese algun valor para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtDireccion.Focus();
            }

            if (CmbSexo.Text.Trim() == "")
            {
                Verifica = 1;
                MessageBox.Show(this, "No hay ningun valor seleccionado en Sexo, Seleccione algun valor para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CmbSexo.Focus();
            }

            if (TxtEdad.Text.Trim() == "")
            {
                Verifica = 1;
                MessageBox.Show(this, "No hay ningun valor en Edad, Seleccione la fecha de nacimiento para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtEdad.Focus();
            }

            if (TxtEdad.Text.Trim() != "")
            {
                X = Convert.ToInt32(TxtEdad.Text.Trim());

                if (X <= 0)
                {
                    negativo = 1;
                }

                if (negativo == 1)
                {
                    Verifica = 1;
                    MessageBox.Show(this, "El valor de la Edad no puede ser negativo o cero, Verifique los valores de la Fecha de Nacimiento", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtEdad.Focus();
                }
            }

            if (CmbEstadoCivil.Text.Trim() == "")
            {
                Verifica = 1;
                MessageBox.Show(this, "No ha seleccionado ningun valor en Estado Civil , Seleccione algun valor para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CmbEstadoCivil.Focus();
            }

            if (txtOcupacion.Text.Trim() == "")
            {
                Verifica = 1;
                MessageBox.Show(this, "No hay ningun valor en la ocupación del paciente, ingrese algun valor para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtOcupacion.Focus();
            }
        }

        private void Verifica_Datos_Seleccionados()
        {
            Verifica2 = 0;

            if (TxtNumExpediente.Text == "")
            {
                Verifica2 = 1;
            }

        }

        private void DtFecha_Naci_ValueChanged(object sender, EventArgs e)
        {
            DateTime Fecha_Actual = DateTime.Now; //se declara una variable de tipo datetime y se le da el valor de la fecha actual
            DateTime Fecha_Nac; //se declara otra variable que va a ser la indicada por el usuario
            int Edad = 0;

            if (DtFecha_Naci.Text != "")
            {
                Fecha_Nac = Convert.ToDateTime(DtFecha_Naci.Text);
                Edad = Fecha_Actual.Year - Fecha_Nac.Year;

                if (new DateTime(Fecha_Actual.Year, Fecha_Nac.Month, Fecha_Nac.Day) > Fecha_Actual)
                {
                    Edad--;
                }
                TxtEdad.Text = Edad.ToString();
            }
        }

        private void BtnFoto_Click(object sender, EventArgs e)
        {
            try
            {
                txtFoco.Focus();

                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|*.png|BMP(*.bmp)|*.bmp|Todos(*.Jpg, *.Png, *.Jpeg, *.Bmp)|*.Jpg; *.Png; *.Jpeg; *.Bmp";
                openFileDialog1.FilterIndex = 4;
                openFileDialog1.RestoreDirectory = true;

                DialogResult Respuesta = openFileDialog1.ShowDialog();

                if (Respuesta != DialogResult.Cancel)
                {
                    pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName.Trim());
                    DireccImage = this.openFileDialog1.FileName.Trim();
                }
            }
            catch
            {
                MessageBox.Show(this, "Error al Cargar la foto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
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

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = null;
            DireccImage = "";
            InfoImagen = null;
        }

        private void btnDetalleContactos_Click(object sender, EventArgs e)
        {
            frmMantenimientosBasicos ofrmMantenimientosBasicos = new frmMantenimientosBasicos();
            ofrmMantenimientosBasicos.ShowDialog();

            txtFoco.Focus();
            LlenaComboContactos();
        }

        private void Grid1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Image newImage = null;

            try
            {
                if (Grid1.CurrentRow != null && Grid1.SelectedRows.Count > 0)
                {
                    if (indiceFilaSeleccionada != Grid1.SelectedRows[0].Index)
                    {
                        indiceFilaSeleccionada = Grid1.SelectedRows[0].Index;
                        //auxIndiceFilaSeleccionada = Grid1.SelectedRows[0].Index;

                        TxtNumExpediente.Text = Grid1.SelectedRows[0].Cells["Num_Expediente"].Value.ToString();

                        oCContactosPacientes.NumExpediente = TxtNumExpediente.Text.Trim();

                        if (Grid1.SelectedRows[0].Cells["TipoCed"].Value.ToString() == "0")
                        {
                            RdNacional.Checked = true;
                            TxtCedula.Text = Grid1.SelectedRows[0].Cells["Cedula"].Value.ToString();
                        }
                        else
                        {
                            RdExtranjero.Checked = true;
                            TxtCedula.Text = Grid1.SelectedRows[0].Cells["Cedula"].Value.ToString();
                        }

                        TxtNombre.Text = Grid1.SelectedRows[0].Cells["Nombre"].Value.ToString();
                        txtApellidos.Text = Grid1.SelectedRows[0].Cells["Apellidos"].Value.ToString();

                        if (Grid1.SelectedRows[0].Cells["Sexo"].Value.ToString() == "0")
                            CmbSexo.SelectedIndex = 1;//Hombre
                        else if (Grid1.SelectedRows[0].Cells["Sexo"].Value.ToString() == "1")
                            CmbSexo.SelectedIndex = 0;//Mujer
                        else
                            CmbSexo.SelectedIndex = 2;//Otro

                        DtFecha_Naci.Text = Grid1.SelectedRows[0].Cells["FecNac"].Value.ToString();

                        //Casada
                        //Soltera
                        //Unión Libre
                        //Separada
                        //Viuda
                        //Divorciada
                        if (Grid1.SelectedRows[0].Cells["EstadoCivil"].Value.ToString() == "0")
                            CmbEstadoCivil.SelectedIndex = 0;//Casado
                        else if (Grid1.SelectedRows[0].Cells["EstadoCivil"].Value.ToString() == "1")
                            CmbEstadoCivil.SelectedIndex = 1;//Soltero
                        else if (Grid1.SelectedRows[0].Cells["EstadoCivil"].Value.ToString() == "2")
                            CmbEstadoCivil.SelectedIndex = 2;//Unión Libre
                        else if (Grid1.SelectedRows[0].Cells["EstadoCivil"].Value.ToString() == "3")
                            CmbEstadoCivil.SelectedIndex = 3;//Separada
                        else if (Grid1.SelectedRows[0].Cells["EstadoCivil"].Value.ToString() == "4")
                            CmbEstadoCivil.SelectedIndex = 4;//Viuda
                        else
                            CmbEstadoCivil.SelectedIndex = 5;//Divorciada

                        TxtDireccion.Text = Grid1.SelectedRows[0].Cells["Direccion"].Value.ToString();
                        txtOcupacion.Text = Grid1.SelectedRows[0].Cells["Ocupacion"].Value.ToString();

                        if (Grid1.SelectedRows[0].Cells["FechaIngreso"].Value != null)
                            lblJoinDate.Text = "Se unió el " + Convert.ToDateTime(Grid1.SelectedRows[0].Cells["FechaIngreso"].Value).ToLongDateString();

                        #region Datos de Examen Físico y Observaciones Generales

                        oArregloExamenObserv.Clear();

                        txtPesoHabitual.Text = Convert.ToDouble(Grid1.SelectedRows[0].Cells["Peso"].Value).ToString();
                        oArregloExamenObserv.Add(txtPesoHabitual.Text.Trim());

                        txtTalla.Text = Convert.ToDouble(Grid1.SelectedRows[0].Cells["Talla"].Value).ToString();
                        oArregloExamenObserv.Add(txtTalla.Text.Trim());

                        txtIMC.Text = Convert.ToDouble(Grid1.SelectedRows[0].Cells["IMC"].Value).ToString();//Program.oCPacientes.CalculaIMC(txtPesoHabitual.Text.Trim(), txtTalla.Text.Trim()).ToString();
                        oArregloExamenObserv.Add(txtIMC.Text.Trim());

                        cmbTipoSangre.Text = Grid1.SelectedRows[0].Cells["Tipo_Sangre"].Value.ToString();
                        oArregloExamenObserv.Add(cmbTipoSangre.Text.Trim());

                        if (Grid1.SelectedRows[0].Cells["FactorRH"].Value.ToString() == "+")
                            rdRHPositivo.Checked = true;
                        else if (Grid1.SelectedRows[0].Cells["FactorRH"].Value.ToString() == "-")
                            rdRHNegativo.Checked = true;

                        oArregloExamenObserv.Add(Grid1.SelectedRows[0].Cells["FactorRH"].Value.ToString());

                        txtObservacionesGenerales.Text = Grid1.SelectedRows[0].Cells["Observaciones"].Value.ToString();
                        oArregloExamenObserv.Add(txtObservacionesGenerales.Text.Trim());

                        #endregion

                        try
                        {
                            //Get image data from gridview column.
                            byte[] imageData = (byte[])Grid1.SelectedRows[0].Cells["Imagen"].Value;

                            InfoImagen = imageData;
                            //Initialize image variable

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
                                ImagenDisponible = true;
                                pictureBox1.Image = newImage;
                            }
                            else
                            {
                                ImagenDisponible = false;
                                pictureBox1.Image = null;
                                InfoImagen = null;//Verificar
                            }
                        }
                        catch
                        {
                            ImagenDisponible = false;
                            pictureBox1.Image = null;
                            InfoImagen = null;//Verificar
                        }
                        
                        //Application.DoEvents();

                        if (Nuevo == false && Modificar == false)
                        {
                            LlenaListaContactos_Empleado();
                            DatosPacientes();

                            HabilitarOpcionesConsultasAntiguas(true);
                            LlenarConsultasAntiguas();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (newImage == null)
                {
                    ImagenDisponible = false;
                    pictureBox1.Image = null;
                    InfoImagen = null;//Verificar
                }
            }
        }

        #endregion

        #region Métodos relacionados con el manejo de Contactos

        private void AutoResize_ListViewColumn()
        {
            int anchoExtra = 0;
            lstContactos.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            if (lstContactos.Width > lstContactos.Columns[1].Width)
            {
                anchoExtra = lstContactos.Width - lstContactos.Columns[1].Width - lstContactos.Columns[0].Width;
                lstContactos.Columns[1].Width = lstContactos.Columns[1].Width + anchoExtra - 4;
            }
        }

        private void LlenaListaContactos_Empleado()
        {
            DataTable oDataTable = Metodos_Globales.Consulta(oCContactosPacientes.Consultar());

            int i = 0;
            lstContactos.Items.Clear();

            if (oDataTable != null)
            {
                foreach (DataRow dr in oDataTable.Rows)
                {
                    ListViewItem viewItem = new ListViewItem();
                    
                    lstContactos.Items.Add(dr[1].ToString().Trim());
                    lstContactos.Items[i].SubItems.Add(dr[2].ToString());
                    lstContactos.Items[i].SubItems.Add(dr[0].ToString());

                    i++;
                }
                oDataTable.Dispose();
            }

            HabilitaOpcionesContactos();
        }

        private void HabilitaOpcionesContactos()
        {
            if (Grid1.RowCount > 0)
            {
                if (lstContactos.Items.Count > 0)
                {
                    tobNuevoContacto.Enabled = true;
                    tobModificarContacto.Enabled = true;
                    tobEliminarContacto.Enabled = true;
                    tobGuardarContacto.Enabled = false;
                    tobCancelarContacto.Enabled = false;
                }
                else
                {
                    tobNuevoContacto.Enabled = true;
                    tobModificarContacto.Enabled = false;
                    tobEliminarContacto.Enabled = false;
                    tobGuardarContacto.Enabled = false;
                    tobCancelarContacto.Enabled = false;
                }
            }
            else
            {
                tobEliminarContacto.Enabled = false;
                tobModificarContacto.Enabled = false;
                tobNuevoContacto.Enabled = false;
                tobGuardarContacto.Enabled = false;
                tobCancelarContacto.Enabled = false;
            }
        }

        private void ModoBloqueoContactos()
        {
            nuevoContacto = false;
            modificarContacto = false;

            Transition t = new Transition(new TransitionType_EaseInEaseOut(250));
            t.add(panelContactos, "Top", -24);
            t.run();

            cmbContactos.SelectedIndex = -1;
            txtDescripcionContactos.Text = "";

            oCContactosPacientes.NumExpediente = "";
            oCContactosPacientes.IdTipoContacto = 0;
            oCContactosPacientes.Descripcion = "";

            if (Nuevo == true)
            {
                object sender = new object();
                EventArgs e = new EventArgs();

                if (MessageBox.Show(this, "¿Desea ingresar otro contacto para este paciente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    nuevoContacto = true;
                    //indiceFilaSeleccionada = -1;
                    oCContactosPacientes.NumExpediente = TxtNumExpediente.Text.Trim();
                    //DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, Grid1.Rows.GetLastRow(DataGridViewElementStates.None));
                    //Grid1_CellEnter(sender, e2);
                    LlenaListaContactos_Empleado();
                    tobNuevoContacto_Click(sender, e);
                }
                else
                {
                    //tobCancelar_Click(sender, e);
                    //HabilitaOpcionesContactos();
                    Nuevo = false;
                    indiceFilaSeleccionada = -1;
                    Grid1.Enabled = true;
                }
            }
            else
            {
                HabilitaOpcionesContactos();
                Grid1.Enabled = true;
            }
        }

        private int DeterminaPosicion()
        {
            int y = 0;

            if (lstContactos.Items.Count <= 9)
            {
                if (nuevoContacto == true)
                    y = lstContactos.Height - lstContactos.DisplayRectangle.Height + 21;
                if (modificarContacto == true)
                    if (lstContactos.SelectedItems.Count > 0)
                        y = (lstContactos.Height - lstContactos.DisplayRectangle.Height + 17) + lstContactos.SelectedItems[0].Bounds.Location.Y - lstContactos.SelectedItems[0].Bounds.Height;
            }
            else
            {
                if (nuevoContacto == true)
                    y = lstContactos.Height - lstContactos.DisplayRectangle.Height;
                if (modificarContacto == true)
                    if (lstContactos.SelectedItems.Count > 0)
                        y = (lstContactos.Height - lstContactos.DisplayRectangle.Height) + lstContactos.SelectedItems[0].Bounds.Location.Y - lstContactos.SelectedItems[0].Bounds.Height;
            }

            return y;
        }

        private void IngresaNuevoContacto()
        {
            nuevoContacto = true;
            modificarContacto = false;

            Transition t = new Transition(new TransitionType_EaseInEaseOut(250));
            t.add(panelContactos, "Top", DeterminaPosicion());
            t.run();
            panelContactos.Refresh();
            cmbContactos.Focus();
        }

        private void ModificaContacto()
        {
            nuevoContacto = false;
            modificarContacto = true;

            if (lstContactos.SelectedItems.Count > 0)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(250));
                t.add(panelContactos, "Top", DeterminaPosicion());
                t.run();
                panelContactos.Refresh();

                cmbContactos.SelectedValue = lstContactos.SelectedItems[0].SubItems[2].Text.Trim();
                txtDescripcionContactos.Text = lstContactos.SelectedItems[0].SubItems[1].Text.Trim();

                cmbContactos.Focus();
            }
        }

        private void tobNuevoContacto_Click(object sender, EventArgs e)
        {
            IngresaNuevoContacto();
            Grid1.Enabled = false;

            tobEliminarContacto.Enabled = false;
            tobModificarContacto.Enabled = false;
            tobNuevoContacto.Enabled = false;
            tobGuardarContacto.Enabled = true;
            tobCancelarContacto.Enabled = true;

            lstContactos.SelectedItems.Clear();
        }

        private void tobModificarContacto_Click(object sender, EventArgs e)
        {
            if (lstContactos.SelectedItems.Count > 0)
            {
                ModificaContacto();
                Grid1.Enabled = false;

                tobEliminarContacto.Enabled = false;
                tobModificarContacto.Enabled = false;
                tobNuevoContacto.Enabled = false;
                tobGuardarContacto.Enabled = true;
                tobCancelarContacto.Enabled = true;
            }
            else
                MessageBox.Show(this, "Debe seleccionar primero el contacto a modificar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tobGuardarContacto_Click(object sender, EventArgs e)
        {
            DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, Grid1.CurrentRow.Index);

            if (nuevoContacto == true)
            {
                if (cmbContactos.SelectedIndex != -1)
                {
                    oCContactosPacientes.NumExpediente = TxtNumExpediente.Text.Trim();
                    oCContactosPacientes.IdTipoContacto = Convert.ToInt32(cmbContactos.SelectedValue);
                    oCContactosPacientes.Descripcion = txtDescripcionContactos.Text.Trim();

                    oCContactosPacientes.Insertar();

                    if (Program.oPersistencia.IsError == false)
                    {
                        tobCancelarContacto_Click(sender, e);

                        if (Nuevo == false)
                        {
                            indiceFilaSeleccionada = -1;
                            Grid1_CellEnter(sender, e2);
                        }
                    }
                }
            }
            else if (modificarContacto == true)
            {
                if (lstContactos.SelectedItems.Count > 0)
                {
                    if (cmbContactos.SelectedIndex != -1)
                    {
                        oCContactosPacientes.NumExpediente = TxtNumExpediente.Text.Trim();
                        oCContactosPacientes.IdTipoContacto = Convert.ToInt32(lstContactos.SelectedItems[0].SubItems[2].Text);
                        oCContactosPacientes.AuxIdTIpoContacto = cmbContactos.SelectedValue.ToString().Trim();
                        oCContactosPacientes.Descripcion = lstContactos.SelectedItems[0].SubItems[1].Text.Trim();
                        oCContactosPacientes.AuxDescripcion = txtDescripcionContactos.Text.Trim();

                        oCContactosPacientes.Modificar();

                        if (Program.oPersistencia.IsError == false)
                        {
                            tobCancelarContacto_Click(sender, e);
                            indiceFilaSeleccionada = -1;
                            Grid1_CellEnter(sender, e2);
                        }
                    }
                }
            }
        }

        private void tobCancelarContacto_Click(object sender, EventArgs e)
        {
            ModoBloqueoContactos();
        }

        private void tobEliminarContacto_Click(object sender, EventArgs e)
        {
            if (lstContactos.SelectedItems.Count > 0)
            {
                oCContactosPacientes.NumExpediente = TxtNumExpediente.Text.Trim();
                oCContactosPacientes.IdTipoContacto = Convert.ToInt32(lstContactos.SelectedItems[0].SubItems[2].Text.Trim());
                oCContactosPacientes.Descripcion = lstContactos.SelectedItems[0].SubItems[1].Text.Trim();

                oCContactosPacientes.Eliminar();

                if (Program.oPersistencia.IsError == false)
                {
                    tobCancelarContacto_Click(sender, e);
                    indiceFilaSeleccionada = -1;
                    DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, Grid1.CurrentRow.Index);
                    Grid1_CellEnter(sender, e2);
                }
            }
            else
                MessageBox.Show(this, "Debe seleccionar primero el contacto a eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void lstContactos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modificarContacto == true)
            {
                if (lstContactos.SelectedItems.Count > 0)
                {
                    ModificaContacto();
                }
            }
        }

        #endregion

        #region Datos Familiares

        #region Comprueba cambios realizados en datos de Madre

        private void CompruebaCambiosRealizados_DatosMadre()
        {
            if (TxtNumExpediente.Text.Trim() != "")
            {
                tobGuardarDatosMadre.Enabled = false;
                tobCancelarDatosMadre.Enabled = false;

                if (oArregloDatosMadre.Count == 5)
                {
                    if (txtNombreMadre.Text.Trim() != oArregloDatosMadre[Convert.ToInt32(txtNombreMadre.Tag)].ToString().Trim() ||
                        txtApellidosMadre.Text.Trim() != oArregloDatosMadre[Convert.ToInt32(txtApellidosMadre.Tag)].ToString().Trim() ||
                        txtTelefonosMadre.Text.Trim() != oArregloDatosMadre[Convert.ToInt32(txtTelefonosMadre.Tag)].ToString().Trim() ||
                        txtEmailMadre.Text.Trim() != oArregloDatosMadre[Convert.ToInt32(txtEmailMadre.Tag)].ToString().Trim() ||
                        txtObservacionesMadre.Text.Trim() != oArregloDatosMadre[Convert.ToInt32(txtObservacionesMadre.Tag)].ToString().Trim())
                    {
                        tobGuardarDatosMadre.Enabled = true;
                        tobCancelarDatosMadre.Enabled = true;
                    }
                }
                else
                {
                    tobGuardarDatosMadre.Enabled = true;
                    tobCancelarDatosMadre.Enabled = false;
                }
            }
        }

        private void txtNombreMadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosMadre();
        }

        private void txtApellidosMadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosMadre();
        }

        private void txtTelefonosMadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosMadre();
        }

        private void txtEmailMadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosMadre();
        }

        private void txtObservacionesMadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosMadre();
        }

        #endregion

        #region Comprueba cambios realizados en datos de Padre

        private void CompruebaCambiosRealizados_DatosPadre()
        {
            if (TxtNumExpediente.Text.Trim() != "")
            {
                tobGuardarDatosPadre.Enabled = false;
                tobCancelarDatosPadre.Enabled = false;

                if (oArregloDatosPadre.Count == 5)
                {
                    if (txtNombrePadre.Text.Trim() != oArregloDatosPadre[Convert.ToInt32(txtNombrePadre.Tag)].ToString().Trim() ||
                        txtApellidosPadre.Text.Trim() != oArregloDatosPadre[Convert.ToInt32(txtApellidosPadre.Tag)].ToString().Trim() ||
                        txtTelefonosPadre.Text.Trim() != oArregloDatosPadre[Convert.ToInt32(txtTelefonosPadre.Tag)].ToString().Trim() ||
                        txtEmailPadre.Text.Trim() != oArregloDatosPadre[Convert.ToInt32(txtEmailPadre.Tag)].ToString().Trim() ||
                        txtObservacionesPadre.Text.Trim() != oArregloDatosPadre[Convert.ToInt32(txtObservacionesPadre.Tag)].ToString().Trim())
                    {
                        tobGuardarDatosPadre.Enabled = true;
                        tobCancelarDatosPadre.Enabled = true;
                    }
                }
                else
                {
                    tobGuardarDatosPadre.Enabled = true;
                    tobCancelarDatosPadre.Enabled = false;
                }
            }
        }

        private void txtNombrePadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosPadre();
        }

        private void txtApellidosPadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosPadre();
        }

        private void txtTelefonosPadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosPadre();
        }

        private void txtEmailPadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosPadre();
        }

        private void txtObservacionesPadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosPadre();
        }

        #endregion

        private void tobGuardarDatosMadre_Click(object sender, EventArgs e)
        {
            oCDatosFamiliares.NumExpediente = TxtNumExpediente.Text.Trim();
            oCDatosFamiliares.TipoFamiliar = "Madre o Encargada";
            oCDatosFamiliares.Nombre = txtNombreMadre.Text.Trim();
            oCDatosFamiliares.Apellidos = txtApellidosMadre.Text.Trim();
            oCDatosFamiliares.Telefonos = txtTelefonosMadre.Text.Trim();
            oCDatosFamiliares.Email = txtEmailMadre.Text.Trim();
            oCDatosFamiliares.Observaciones = txtObservacionesMadre.Text.Trim();

            if (oArregloDatosMadre.Count == 0)
                oCDatosFamiliares.Insertar();
            else if (oArregloDatosMadre.Count > 0)
                oCDatosFamiliares.Modificar();

            #region Limpia arreglo y establece nuevos datos

            oArregloDatosMadre.Clear();
            oArregloDatosMadre.Add(txtNombreMadre.Text.Trim());
            oArregloDatosMadre.Add(txtApellidosMadre.Text.Trim());
            oArregloDatosMadre.Add(txtTelefonosMadre.Text.Trim());
            oArregloDatosMadre.Add(txtEmailMadre.Text.Trim());
            oArregloDatosMadre.Add(txtObservacionesMadre.Text.Trim());

            tobGuardarDatosMadre.Enabled = false;
            tobCancelarDatosMadre.Enabled = false;

            #endregion
        }

        private void tobCancelarDatosMadre_Click(object sender, EventArgs e)
        {
            if (oArregloDatosMadre.Count > 0)
            {
                txtNombreMadre.Text = oArregloDatosMadre[Convert.ToInt32(txtNombreMadre.Tag)].ToString().Trim();
                txtApellidosMadre.Text = oArregloDatosMadre[Convert.ToInt32(txtApellidosMadre.Tag)].ToString().Trim();
                txtTelefonosMadre.Text = oArregloDatosMadre[Convert.ToInt32(txtTelefonosMadre.Tag)].ToString().Trim();
                txtEmailMadre.Text = oArregloDatosMadre[Convert.ToInt32(txtEmailMadre.Tag)].ToString().Trim();
                txtObservacionesMadre.Text = oArregloDatosMadre[Convert.ToInt32(txtObservacionesMadre.Tag)].ToString().Trim();
            }
            else
            {
                txtNombreMadre.Text = "";
                txtApellidosMadre.Text = "";
                txtTelefonosMadre.Text = "";
                txtEmailMadre.Text = "";
                txtObservacionesMadre.Text = "";
            }

            tobGuardarDatosMadre.Enabled = false;
            tobCancelarDatosMadre.Enabled = false;
        }

        private void tobGuardarDatosPadre_Click(object sender, EventArgs e)
        {
            oCDatosFamiliares.NumExpediente = TxtNumExpediente.Text.Trim();
            oCDatosFamiliares.TipoFamiliar = "Padre o Encargado";
            oCDatosFamiliares.Nombre = txtNombrePadre.Text.Trim();
            oCDatosFamiliares.Apellidos = txtApellidosPadre.Text.Trim();
            oCDatosFamiliares.Telefonos = txtTelefonosPadre.Text.Trim();
            oCDatosFamiliares.Email = txtEmailPadre.Text.Trim();
            oCDatosFamiliares.Observaciones = txtObservacionesPadre.Text.Trim();

            if (oArregloDatosPadre.Count == 0)
                oCDatosFamiliares.Insertar();
            else
                oCDatosFamiliares.Modificar();

            //oCDatosFamiliares.Modificar();

            #region Limpia arreglo y establece nuevos datos

            oArregloDatosPadre.Clear();
            oArregloDatosPadre.Add(txtNombrePadre.Text.Trim());
            oArregloDatosPadre.Add(txtApellidosPadre.Text.Trim());
            oArregloDatosPadre.Add(txtTelefonosPadre.Text.Trim());
            oArregloDatosPadre.Add(txtEmailPadre.Text.Trim());
            oArregloDatosPadre.Add(txtObservacionesPadre.Text.Trim());

            tobGuardarDatosPadre.Enabled = false;
            tobCancelarDatosPadre.Enabled = false;

            #endregion
        }

        private void tobCancelarDatosPadre_Click(object sender, EventArgs e)
        {
            if (oArregloDatosPadre.Count > 0)
            {
                txtNombrePadre.Text = oArregloDatosPadre[Convert.ToInt32(txtNombrePadre.Tag)].ToString().Trim();
                txtApellidosPadre.Text = oArregloDatosPadre[Convert.ToInt32(txtApellidosPadre.Tag)].ToString().Trim();
                txtTelefonosPadre.Text = oArregloDatosPadre[Convert.ToInt32(txtTelefonosPadre.Tag)].ToString().Trim();
                txtEmailPadre.Text = oArregloDatosPadre[Convert.ToInt32(txtEmailPadre.Tag)].ToString().Trim();
                txtObservacionesPadre.Text = oArregloDatosPadre[Convert.ToInt32(txtObservacionesPadre.Tag)].ToString().Trim();
            }
            else
            {
                txtNombrePadre.Text = "";
                txtApellidosPadre.Text = "";
                txtTelefonosPadre.Text = "";
                txtEmailPadre.Text = "";
                txtObservacionesPadre.Text = "";
            }

            tobGuardarDatosPadre.Enabled = false;
            tobCancelarDatosPadre.Enabled = false;
        }

        #endregion

        #region Examen Físico y Observaciones Generales

        private void btnGuardarExamenObservaciones_Click(object sender, EventArgs e)
        {
            Program.oCPacientes.NumExpediente = Convert.ToInt32(TxtNumExpediente.Text.Trim());

            string PesoHabitual = txtPesoHabitual.Text.Replace(",", ".");
            string Talla = txtTalla.Text.Replace(",", ".");
            string IMC = txtIMC.Text.Replace(",", ".");

            Program.oCPacientes.Peso = PesoHabitual.Trim();
            Program.oCPacientes.Talla = Talla.Trim();
            Program.oCPacientes.IMC = IMC.Trim();
            Program.oCPacientes.Tipo_sangre = cmbTipoSangre.Text.Trim();

            if (rdRHPositivo.Checked == true)
                Program.oCPacientes.Factor_rh = "+";
            else
                if (rdRHNegativo.Checked == true)
                    Program.oCPacientes.Factor_rh = "-";

            Program.oCPacientes.Observaciones = txtObservacionesGenerales.Text.Trim();

            Program.oCPacientes.Modificar_DatosPaciente();

            #region Actualiza el Arreglo

            oArregloExamenObserv.Clear();
            oArregloExamenObserv.Add(txtPesoHabitual.Text.Trim());
            oArregloExamenObserv.Add(txtTalla.Text.Trim());
            oArregloExamenObserv.Add(txtIMC.Text.Trim());
            oArregloExamenObserv.Add(cmbTipoSangre.Text.Trim());
            if (rdRHPositivo.Checked == true)
                oArregloExamenObserv.Add("+");
            else
                if (rdRHNegativo.Checked == true)
                    oArregloExamenObserv.Add("-");
            oArregloExamenObserv.Add(txtObservacionesGenerales.Text.Trim());

            btnGuardarExamenObservaciones.Enabled = false;
            btnCancelarExamenObservaciones.Enabled = false;

            #endregion
        }

        private void btnCancelarExamenObservaciones_Click(object sender, EventArgs e)
        {
            txtPesoHabitual.Text = oArregloExamenObserv[Convert.ToInt32(txtPesoHabitual.Tag)].ToString().Trim();
            txtTalla.Text = oArregloExamenObserv[Convert.ToInt32(txtTalla.Tag)].ToString().Trim();
            txtIMC.Text = oArregloExamenObserv[Convert.ToInt32(txtIMC.Tag)].ToString().Trim();
            txtObservacionesGenerales.Text = oArregloExamenObserv[Convert.ToInt32(txtObservacionesGenerales.Tag)].ToString().Trim();
            cmbTipoSangre.Text = oArregloExamenObserv[Convert.ToInt32(cmbTipoSangre.Tag)].ToString().Trim();

            if (oArregloExamenObserv[Convert.ToInt32(rdRHPositivo.Tag)].ToString().Trim() == "+")
                rdRHPositivo.Checked = true;
            else
                rdRHNegativo.Checked = true;

            btnGuardarExamenObservaciones.Enabled = false;
            btnCancelarExamenObservaciones.Enabled = false;
        }

        private void CompruebaCambiosRealizados_ExamenObservaciones()
        {
            if (TxtNumExpediente.Text.Trim() != "")
            {
                btnGuardarExamenObservaciones.Enabled = false;
                btnCancelarExamenObservaciones.Enabled = false;

                if (oArregloExamenObserv.Count == 6)
                {
                    string RH = "";

                    if (rdRHPositivo.Checked == true)
                        RH = "+";
                    else
                        if (rdRHNegativo.Checked == true)
                            RH = "-";

                    if (txtPesoHabitual.Text.Trim() != oArregloExamenObserv[Convert.ToInt32(txtPesoHabitual.Tag)].ToString().Trim() ||
                        txtTalla.Text.Trim() != oArregloExamenObserv[Convert.ToInt32(txtTalla.Tag)].ToString().Trim() ||
                        txtIMC.Text.Trim() != oArregloExamenObserv[Convert.ToInt32(txtIMC.Tag)].ToString().Trim() ||
                        txtObservacionesGenerales.Text.Trim() != oArregloExamenObserv[Convert.ToInt32(txtObservacionesGenerales.Tag)].ToString().Trim() ||
                        cmbTipoSangre.Text.Trim() != oArregloExamenObserv[Convert.ToInt32(cmbTipoSangre.Tag)].ToString().Trim() ||
                        RH != oArregloExamenObserv[Convert.ToInt32(rdRHNegativo.Tag)].ToString().Trim())
                    {
                        btnGuardarExamenObservaciones.Enabled = true;
                        btnCancelarExamenObservaciones.Enabled = true;
                    }
                }
            }
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

        private void txtPesoHabitual_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_ExamenObservaciones();
        }

        private void txtTalla_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_ExamenObservaciones();
        }

        private void txtIMC_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_ExamenObservaciones();
        }

        private void txtObservacionesGenerales_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_ExamenObservaciones();
        }

        #endregion

        #region Antecedentes Generales

        private void btnGuardarAntecedentesGenerales_Click(object sender, EventArgs e)
        {
            bool continuar = false;

            if (MDIPrincipal.RolUsuario == "Administrador")
                continuar = true;
            else
            {
                if ((bool)oArregloPermisos[3] == true)
                {
                    FrmSolicitudAdmin oFrmSolicitudAdmin = new FrmSolicitudAdmin();
                    oFrmSolicitudAdmin.ShowDialog();

                    if (FrmSolicitudAdmin.Continuar == true)
                        continuar = true;
                    else
                    {
                        MessageBox.Show(this, "No se puede continuar con estas acciones hasta que un administrador del sistema otorgue la autorización necesaria, ya que así lo establecen los permisos de usuario establecidos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        continuar = false;
                    }
                }
                else
                    continuar = true;
            }

            if (continuar == true)
            {
                oCAntecedentesGenerales.Num_expediente = TxtNumExpediente.Text.Trim();
                oCAntecedentesGenerales.Patologicos = txtPatologicos.Text.Trim();
                oCAntecedentesGenerales.No_patologicos = txtNOPatologicos.Text.Trim();
                oCAntecedentesGenerales.Familiares = txtFamiliares.Text.Trim();
                oCAntecedentesGenerales.Quirurgicos = txtQuirurgicos.Text.Trim();
                oCAntecedentesGenerales.Alergias = txtAlergias.Text.Trim();
                oCAntecedentesGenerales.Medicamentos = txtMedicamentos.Text.Trim();
                oCAntecedentesGenerales.Otros = txtOtros.Text.Trim();

                if (oArregloAntecedentesGenerales.Count == 0)
                    oCAntecedentesGenerales.Insertar();
                else if (oArregloAntecedentesGenerales.Count > 0)
                    oCAntecedentesGenerales.Modificar();

                #region Limpia arreglo y reestablece nuevos datos

                oArregloAntecedentesGenerales.Clear();

                oArregloAntecedentesGenerales.Add(txtPatologicos.Text.Trim());
                oArregloAntecedentesGenerales.Add(txtNOPatologicos.Text.Trim());
                oArregloAntecedentesGenerales.Add(txtFamiliares.Text.Trim());
                oArregloAntecedentesGenerales.Add(txtQuirurgicos.Text.Trim());
                oArregloAntecedentesGenerales.Add(txtAlergias.Text.Trim());
                oArregloAntecedentesGenerales.Add(txtMedicamentos.Text.Trim());
                oArregloAntecedentesGenerales.Add(txtOtros.Text.Trim());

                #endregion

                CompruebaCambios_AntecedenteEspecifico(this.ActiveControl);
                CompruebaCambiosRealizados_AntecedentesGenerales();
            }
        }

        private void btnCancelarAntecedGenerales_Click(object sender, EventArgs e)
        {
            if (oArregloAntecedentesGenerales.Count == 7)
            {
                txtPatologicos.Text = oArregloAntecedentesGenerales[Convert.ToInt32(txtPatologicos.Tag)].ToString().Trim();
                txtNOPatologicos.Text = oArregloAntecedentesGenerales[Convert.ToInt32(txtNOPatologicos.Tag)].ToString().Trim();
                txtFamiliares.Text = oArregloAntecedentesGenerales[Convert.ToInt32(txtFamiliares.Tag)].ToString().Trim();
                txtQuirurgicos.Text = oArregloAntecedentesGenerales[Convert.ToInt32(txtQuirurgicos.Tag)].ToString().Trim();
                txtAlergias.Text = oArregloAntecedentesGenerales[Convert.ToInt32(txtAlergias.Tag)].ToString().Trim();
                txtMedicamentos.Text = oArregloAntecedentesGenerales[Convert.ToInt32(txtMedicamentos.Tag)].ToString().Trim();
                txtOtros.Text = oArregloAntecedentesGenerales[Convert.ToInt32(txtOtros.Tag)].ToString().Trim();
            }
            else
            {
                txtPatologicos.Text = "";
                txtNOPatologicos.Text = "";
                txtFamiliares.Text = "";
                txtQuirurgicos.Text = "";
                txtAlergias.Text = "";
                txtMedicamentos.Text = "";
                txtOtros.Text = "";
            }

            btnGuardarAntecedentesGenerales.Enabled = false;
            btnCancelarAntecedGenerales.Enabled = false;
        }

        #region Eventos Enter de las textbox correspondientes a Antecedentes Generales

        private void CompruebaCambios_AntecedenteEspecifico(Control oControl)
        {
            if (TxtNumExpediente.Text.Trim() != "")
            {
                if (oArregloAntecedentesGenerales.Count == 7)
                {
                    if (oControl.Text != oArregloAntecedentesGenerales[Convert.ToInt32(oControl.Tag)].ToString().Trim())
                        btnReturn.Enabled = true;
                    else
                        btnReturn.Enabled = false;
                }
                else
                    btnReturn.Enabled = false;
            }
        }

        private void txtPatologicos_MouseEnter(object sender, EventArgs e)
        {
            panelPatologicos.Controls.Add(toolOpciones);
            toolOpciones.Location = new Point(0, 0);

            CompruebaCambios_AntecedenteEspecifico(txtPatologicos);
        }

        private void txtNOPatologicos_MouseEnter(object sender, EventArgs e)
        {
            panelNOPato.Controls.Add(toolOpciones);
            toolOpciones.Location = new Point(0, 0);

            CompruebaCambios_AntecedenteEspecifico(txtNOPatologicos);
        }

        private void txtFamiliares_MouseEnter(object sender, EventArgs e)
        {
            panelFamiliares.Controls.Add(toolOpciones);
            toolOpciones.Location = new Point(0, 0);

            CompruebaCambios_AntecedenteEspecifico(txtFamiliares);
        }

        private void txtQuirurgicos_MouseEnter(object sender, EventArgs e)
        {
            panelQuirurgicos.Controls.Add(toolOpciones);
            toolOpciones.Location = new Point(0, 0);

            CompruebaCambios_AntecedenteEspecifico(txtQuirurgicos);
        }

        private void txtAlergias_MouseEnter(object sender, EventArgs e)
        {
            panelAlergias.Controls.Add(toolOpciones);
            toolOpciones.Location = new Point(0, 0);

            CompruebaCambios_AntecedenteEspecifico(txtAlergias);
        }

        private void txtMedicamentos_MouseEnter(object sender, EventArgs e)
        {
            panelMedicamentos.Controls.Add(toolOpciones);
            toolOpciones.Location = new Point(0, 0);

            CompruebaCambios_AntecedenteEspecifico(txtMedicamentos);
        }

        private void txtOtros_MouseEnter(object sender, EventArgs e)
        {
            panelOtros.Controls.Add(toolOpciones);
            toolOpciones.Location = new Point(0, 0);

            CompruebaCambios_AntecedenteEspecifico(txtOtros);
        }

        #endregion

        #region Eventos KeyUp correspondientes a Antecedentes Generales

        private void CompruebaCambiosRealizados_AntecedentesGenerales()
        {
            if (TxtNumExpediente.Text.Trim() != "")
            {
                btnGuardarAntecedentesGenerales.Enabled = false;
                btnCancelarAntecedGenerales.Enabled = false;

                if (oArregloAntecedentesGenerales.Count == 7)
                {
                    if (txtPatologicos.Text.Trim() != oArregloAntecedentesGenerales[Convert.ToInt32(txtPatologicos.Tag)].ToString().Trim() ||
                        txtNOPatologicos.Text.Trim() != oArregloAntecedentesGenerales[Convert.ToInt32(txtNOPatologicos.Tag)].ToString().Trim() ||
                        txtFamiliares.Text.Trim() != oArregloAntecedentesGenerales[Convert.ToInt32(txtFamiliares.Tag)].ToString().Trim() ||
                        txtQuirurgicos.Text.Trim() != oArregloAntecedentesGenerales[Convert.ToInt32(txtQuirurgicos.Tag)].ToString().Trim() ||
                        txtAlergias.Text.Trim() != oArregloAntecedentesGenerales[Convert.ToInt32(txtAlergias.Tag)].ToString().Trim() ||
                        txtMedicamentos.Text.Trim() != oArregloAntecedentesGenerales[Convert.ToInt32(txtMedicamentos.Tag)].ToString().Trim() ||
                        txtOtros.Text.Trim() != oArregloAntecedentesGenerales[Convert.ToInt32(txtOtros.Tag)].ToString().Trim())
                    {
                        btnGuardarAntecedentesGenerales.Enabled = true;
                        btnCancelarAntecedGenerales.Enabled = true;
                    }
                }
                else
                {
                    btnGuardarAntecedentesGenerales.Enabled = true;
                    btnCancelarAntecedGenerales.Enabled = false;
                }
            }
        }

        private void txtPatologicos_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesGenerales();
            CompruebaCambios_AntecedenteEspecifico(txtPatologicos);
        }

        private void txtNOPatologicos_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesGenerales();
            CompruebaCambios_AntecedenteEspecifico(txtNOPatologicos);
        }

        private void txtFamiliares_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesGenerales();
            CompruebaCambios_AntecedenteEspecifico(txtFamiliares);
        }

        private void txtQuirurgicos_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesGenerales();
            CompruebaCambios_AntecedenteEspecifico(txtQuirurgicos);
        }

        private void txtAlergias_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesGenerales();
            CompruebaCambios_AntecedenteEspecifico(txtAlergias);
        }

        private void txtMedicamentos_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesGenerales();
            CompruebaCambios_AntecedenteEspecifico(txtMedicamentos);
        }

        private void txtOtros_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesGenerales();
            CompruebaCambios_AntecedenteEspecifico(txtOtros);
        }

        #endregion

        private void RetornaValorOriginal(Control oControl)
        {
            oControl.Text = oArregloAntecedentesGenerales[Convert.ToInt32(oControl.Tag)].ToString().Trim();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (panelPatologicos.Controls.Contains(toolOpciones))
            {
                RetornaValorOriginal(txtPatologicos);
            }
            else if (panelNOPato.Controls.Contains(toolOpciones))
            {
                RetornaValorOriginal(txtNOPatologicos);
            }
            else if (panelFamiliares.Controls.Contains(toolOpciones))
            {
                RetornaValorOriginal(txtFamiliares);
            }
            else if (panelQuirurgicos.Controls.Contains(toolOpciones))
            {
                RetornaValorOriginal(txtQuirurgicos);
            }
            else if (panelAlergias.Controls.Contains(toolOpciones))
            {
                RetornaValorOriginal(txtAlergias);
            }
            else if (panelMedicamentos.Controls.Contains(toolOpciones))
            {
                RetornaValorOriginal(txtMedicamentos);
            }
            else if (panelOtros.Controls.Contains(toolOpciones))
            {
                RetornaValorOriginal(txtOtros);
            }

            CompruebaCambiosRealizados_AntecedentesGenerales();
        }

        /// <summary>
        /// Reestablece los valores de los controles de los antecedentes a su valor original
        /// </summary>
        private void TamañosOriginales()
        {
            txtPatologicos.Height = altoOriginalAntecedentes;
            txtNOPatologicos.Height = altoOriginalAntecedentes;
            txtFamiliares.Height = altoOriginalAntecedentes;
            txtQuirurgicos.Height = altoOriginalAntecedentes;
            txtAlergias.Height = altoOriginalAntecedentes;
            txtMedicamentos.Height = altoOriginalAntecedentes;
            txtOtros.Height = altoOriginalAntecedentes;

            panel5.Height = altoOriginalPanel5;
            panel1.Height = altoOriginalPanel1;

            tableLayoutPanel1.RowStyles[0].Height = 200;
            tableLayoutPanel1.RowStyles[1].Height = 200;
            tableLayoutPanel1.RowStyles[2].Height = 200;
            tableLayoutPanel1.RowStyles[3].Height = 256;
        }

        private Size TextBoxSize(TextBox pTextBox)
        {
            int oHeight = Convert.ToInt32(Metodos_Globales.MeasureString(this.CreateGraphics(), pTextBox, pTextBox.Font));

            return new Size(pTextBox.Width, oHeight);
        }

        private void btnMagnify_Click(object sender, EventArgs e)
        {
            Size oSize = new Size();
            int diferenciaAlturas = 0;
            int verticalScrollPosition = this.VerticalScroll.Value;

            TamañosOriginales();

            if (panelPatologicos.Controls.Contains(toolOpciones))
            {
                oSize = TextBoxSize(txtPatologicos);

                if (oSize.Height > altoOriginalAntecedentes)
                {
                    txtPatologicos.Size = oSize;

                    diferenciaAlturas = oSize.Height - altoOriginalAntecedentes;

                    tableLayoutPanel1.RowStyles[0].Height += diferenciaAlturas;
                    panel5.Height += diferenciaAlturas;
                    panel1.Height += diferenciaAlturas;
                }
            }
            else if (panelNOPato.Controls.Contains(toolOpciones))
            {
                oSize = TextBoxSize(txtNOPatologicos);

                if (oSize.Height > altoOriginalAntecedentes)
                {
                    txtNOPatologicos.Size = oSize;

                    diferenciaAlturas = oSize.Height - altoOriginalAntecedentes;

                    tableLayoutPanel1.RowStyles[0].Height += diferenciaAlturas;
                    panel5.Height += diferenciaAlturas;
                    panel1.Height += diferenciaAlturas;
                }
            }
            else if (panelFamiliares.Controls.Contains(toolOpciones))
            {
                oSize = TextBoxSize(txtFamiliares);

                if (oSize.Height > altoOriginalAntecedentes)
                {
                    txtFamiliares.Size = oSize;

                    diferenciaAlturas = oSize.Height - altoOriginalAntecedentes;

                    tableLayoutPanel1.RowStyles[1].Height += diferenciaAlturas;
                    panel5.Height += diferenciaAlturas;
                    panel1.Height += diferenciaAlturas;
                }
            }
            else if (panelQuirurgicos.Controls.Contains(toolOpciones))
            {
                oSize = TextBoxSize(txtQuirurgicos);

                if (oSize.Height > altoOriginalAntecedentes)
                {
                    txtQuirurgicos.Size = oSize;

                    diferenciaAlturas = oSize.Height - altoOriginalAntecedentes;

                    tableLayoutPanel1.RowStyles[1].Height += diferenciaAlturas;
                    panel5.Height += diferenciaAlturas;
                    panel1.Height += diferenciaAlturas;
                }
            }
            else if (panelAlergias.Controls.Contains(toolOpciones))
            {
                oSize = TextBoxSize(txtAlergias);

                if (oSize.Height > altoOriginalAntecedentes)
                {
                    txtAlergias.Size = oSize;

                    diferenciaAlturas = oSize.Height - altoOriginalAntecedentes;

                    tableLayoutPanel1.RowStyles[2].Height += diferenciaAlturas;
                    panel5.Height += diferenciaAlturas;
                    panel1.Height += diferenciaAlturas;
                }
            }
            else if (panelMedicamentos.Controls.Contains(toolOpciones))
            {
                oSize = TextBoxSize(txtMedicamentos);

                if (oSize.Height > altoOriginalAntecedentes)
                {
                    txtMedicamentos.Size = oSize;

                    diferenciaAlturas = oSize.Height - altoOriginalAntecedentes;

                    tableLayoutPanel1.RowStyles[2].Height += diferenciaAlturas;
                    panel5.Height += diferenciaAlturas;
                    panel1.Height += diferenciaAlturas;
                }
            }
            else if (panelOtros.Controls.Contains(toolOpciones))
            {
                oSize = TextBoxSize(txtOtros);

                if (oSize.Height > altoOriginalAntecedentes)
                {
                    txtOtros.Size = oSize;

                    diferenciaAlturas = oSize.Height - altoOriginalAntecedentes;

                    tableLayoutPanel1.RowStyles[3].Height += diferenciaAlturas;
                    panel5.Height += diferenciaAlturas;
                    panel1.Height += diferenciaAlturas;
                }
            }

            this.AutoScrollPosition = new Point(0, verticalScrollPosition);
        }

        #endregion

        private void DatosPacientes()
        {
            DataSet ds = new DataSet();

            #region Datos Familiares

            oArregloDatosMadre.Clear();
            oArregloDatosPadre.Clear();

            oCDatosFamiliares.NumExpediente = TxtNumExpediente.Text.Trim();

            try
            {
                ds = oCDatosFamiliares.ConsultarDataset();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr[1].ToString().Trim() == "Madre o Encargada")
                            {
                                #region Almacena datos en arreglo de Madre y llena cajas de texto con datos

                                txtNombreMadre.Text = dr[2].ToString().Trim();
                                oArregloDatosMadre.Add(dr[2].ToString().Trim());

                                txtApellidosMadre.Text = dr[3].ToString().Trim();
                                oArregloDatosMadre.Add(dr[3].ToString().Trim());

                                txtTelefonosMadre.Text = dr[4].ToString().Trim();
                                oArregloDatosMadre.Add(dr[4].ToString().Trim());

                                txtEmailMadre.Text = dr[5].ToString().Trim();
                                oArregloDatosMadre.Add(dr[5].ToString().Trim());

                                txtObservacionesMadre.Text = dr[6].ToString().Trim();
                                oArregloDatosMadre.Add(dr[6].ToString().Trim());

                                #endregion
                            }
                            else
                            {
                                #region Almacena datos en arreglo de Padre y llena cajas de texto con datos

                                txtNombrePadre.Text = dr[2].ToString().Trim();
                                oArregloDatosPadre.Add(dr[2].ToString().Trim());

                                txtApellidosPadre.Text = dr[3].ToString().Trim();
                                oArregloDatosPadre.Add(dr[3].ToString().Trim());

                                txtTelefonosPadre.Text = dr[4].ToString().Trim();
                                oArregloDatosPadre.Add(dr[4].ToString().Trim());

                                txtEmailPadre.Text = dr[5].ToString().Trim();
                                oArregloDatosPadre.Add(dr[5].ToString().Trim());

                                txtObservacionesPadre.Text = dr[6].ToString().Trim();
                                oArregloDatosPadre.Add(dr[6].ToString().Trim());

                                #endregion
                            }
                        }
                    }
                    else
                        LimpiaCamposDatosFamiliares();
                }
                else
                    LimpiaCamposDatosFamiliares();

                ds = null;//Limpia para reutilizar el dataset en la siguiente consulta

                if (oCDatosFamiliares.ConsultarDataset() != null)
                    oCDatosFamiliares.ConsultarDataset().Dispose();
            }
            catch { }

            #endregion

            #region Antecedentes Generales

            if (MDIPrincipal.RolUsuario == "Administrador" || (bool)oArregloPermisos[4] == true)
            {
                oArregloAntecedentesGenerales.Clear();

                try
                {
                    oCAntecedentesGenerales.Num_expediente = TxtNumExpediente.Text.Trim();

                    ds = oCAntecedentesGenerales.ConsultarDataset();

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                txtPatologicos.Text = dr[1].ToString().Trim();
                                oArregloAntecedentesGenerales.Add(txtPatologicos.Text.Trim());

                                txtNOPatologicos.Text = dr[2].ToString().Trim();
                                oArregloAntecedentesGenerales.Add(txtNOPatologicos.Text.Trim());

                                txtFamiliares.Text = dr[3].ToString().Trim();
                                oArregloAntecedentesGenerales.Add(txtFamiliares.Text.Trim());

                                txtQuirurgicos.Text = dr[4].ToString().Trim();
                                oArregloAntecedentesGenerales.Add(txtQuirurgicos.Text.Trim());

                                txtAlergias.Text = dr[5].ToString().Trim();
                                oArregloAntecedentesGenerales.Add(txtAlergias.Text.Trim());

                                txtMedicamentos.Text = dr[6].ToString().Trim();
                                oArregloAntecedentesGenerales.Add(txtMedicamentos.Text.Trim());

                                txtOtros.Text = dr[7].ToString().Trim();
                                oArregloAntecedentesGenerales.Add(txtOtros.Text.Trim());

                                btnMagnify.Enabled = true;
                            }
                        }
                        else
                            LimpiaCamposAntecedentes();
                    }
                    else
                        LimpiaCamposAntecedentes();

                    ds = null;

                    if (oCAntecedentesGenerales.ConsultarDataset() != null)
                        oCAntecedentesGenerales.ConsultarDataset().Dispose();
                }
                catch { }
            }
            #endregion

            #region Antecedentes Obstétricos y Ginecológicos

            if (MDIPrincipal.RolUsuario == "Administrador" || (bool)oArregloPermisos[4] == true)
            {
                oArregloAntecedentesObstetGinec.Clear();

                try
                {
                    oCAntecedentes_ObstetGinec.Num_Expediente = TxtNumExpediente.Text.Trim();

                    ds = oCAntecedentes_ObstetGinec.ConsultarDataset();

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                txtGesta.Text = dr[1].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtGesta.Text.Trim());

                                txtPara.Text = dr[2].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtPara.Text.Trim());

                                txtAbortos.Text = dr[3].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtAbortos.Text.Trim());

                                txtCesareas.Text = dr[4].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtCesareas.Text.Trim());

                                txtGemelares.Text = dr[5].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtGemelares.Text.Trim());

                                txtMolas.Text = dr[6].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtMolas.Text.Trim());

                                txtEctopicos.Text = dr[7].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtEctopicos.Text.Trim());

                                txtObitos.Text = dr[8].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtObitos.Text.Trim());

                                dtFechaUltimoParto.Value = Convert.ToDateTime(dr[9].ToString().Trim());
                                oArregloAntecedentesObstetGinec.Add(dtFechaUltimoParto.Value);

                                txtComplicacionesUP.Text = dr[10].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtComplicacionesUP.Text.Trim());

                                txtMenarca.Text = dr[11].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtMenarca.Text.Trim());

                                txtMenopausia.Text = dr[12].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtMenopausia.Text.Trim());

                                txtCicloMenstrual.Text = dr[13].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtCicloMenstrual.Text.Trim());

                                cmbTipoCiclo.SelectedIndex = Convert.ToInt32(dr[14]);
                                oArregloAntecedentesObstetGinec.Add(cmbTipoCiclo.SelectedIndex);

                                txtDetalleTipoCiclo.Text = dr[15].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtDetalleTipoCiclo.Text.Trim());

                                txtDetalleAdicionalesAntGin.Text = dr[16].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtDetalleAdicionalesAntGin.Text.Trim());
                            }

                            btnGuardarAntecedObstetGinec.Enabled = false;
                            btnCancelarAntecedObstetGinec.Enabled = false;
                        }
                        else
                        {
                            LimpiaCamposAntecedentesObstetGinec();

                            object sender = new object();
                            EventArgs e = new EventArgs();
                            txtMenarca_TextChanged(sender, e);

                            btnGuardarAntecedObstetGinec.Enabled = true;
                            btnCancelarAntecedObstetGinec.Enabled = false;
                        }
                    }
                    else
                    {
                        LimpiaCamposAntecedentesObstetGinec();

                        object sender = new object();
                        EventArgs e = new EventArgs();
                        txtMenarca_TextChanged(sender, e);

                        btnGuardarAntecedObstetGinec.Enabled = true;
                        btnCancelarAntecedObstetGinec.Enabled = false;
                    }
                }
                catch { }

                if (ds != null)
                    ds.Dispose();

                if (oCAntecedentes_ObstetGinec.ConsultarDataset() != null)
                    oCAntecedentes_ObstetGinec.ConsultarDataset().Dispose();
            }
            #endregion
        }

        private void frmHistoriaClinica_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Activate();
        }

        public void CalculaPosicionBarra()
        {
            try
            {
                int promedio = Program.oMDI.BarraPacientes.Height - Program.oMDI.statusStrip1.Height;
                int Bottom = Program.oMDI.statusStrip1.Top - Program.oMDI.statusStrip1.Height - promedio;//(Screen.PrimaryScreen.WorkingArea.Height - Program.oMDI.BarraPacientes.Height - Program.oMDI.statusStrip1.Height);// -Program.oMDI.toolStripBuscar.Height;

                if (Program.oFrmHistoriaClinica.HorizontalScroll.Visible == true)
                    Bottom = Bottom - 19;

                if (Program.oMDI.autoHide == false)
                {
                    Program.oMDI.BarraPacientes.Size = new Size(Program.oMDI.ClientRectangle.Width - Program.oMDI.panel1.Width, Program.oMDI.BarraPacientes.Height);
                    Program.oMDI.BarraPacientes.Location = new Point(Program.oMDI.panel1.Width, Bottom);
                }
                else
                {
                    Program.oMDI.BarraPacientes.Size = new Size(Program.oMDI.ClientRectangle.Width, Program.oMDI.BarraPacientes.Height);
                    Program.oMDI.BarraPacientes.Location = new Point(0, Bottom);
                }
            }
            catch { }
        }

        private void barra_Click(object sender, EventArgs e)
        {
            if (Program.MostrarBarraSiempre == 0)
            {
                if (Program.oMDI.BarraPacientes.Visible == false)
                {
                    Program.oMDI.BarraPacientes.Show();
                    Program.oMDI.BarraPacientes.BringToFront();
                }
                else
                    Program.oMDI.BarraPacientes.Hide();
            }
        }

        public void frmHistoriaClinica_Scroll(object sender, ScrollEventArgs e)
        {
            lstContactos.Update();
        }

        private void RefrescaValoresEnGrid(DataGridViewSelectedRowCollection selectedRow)
        {
            if (selectedRow.Count > 0)
            {
                if (RdNacional.Checked)
                    Grid1.SelectedRows[0].Cells["TipoCed"].Value = "0";
                else
                    Grid1.SelectedRows[0].Cells["TipoCed"].Value = "1";

                Grid1.SelectedRows[0].Cells["Cedula"].Value = TxtCedula.Text.Trim();
                Grid1.SelectedRows[0].Cells["Nombre"].Value = TxtNombre.Text.Trim();
                Grid1.SelectedRows[0].Cells["Apellidos"].Value = txtApellidos.Text.Trim();
                Grid1.SelectedRows[0].Cells["Sexo"].Value = CmbSexo.SelectedIndex.ToString();
                Grid1.SelectedRows[0].Cells["FecNac"].Value = DtFecha_Naci.Text.Trim();
                Grid1.SelectedRows[0].Cells["EstadoCivil"].Value = CmbEstadoCivil.SelectedIndex.ToString();
                Grid1.SelectedRows[0].Cells["Direccion"].Value = TxtDireccion.Text.Trim();
                Grid1.SelectedRows[0].Cells["Ocupacion"].Value = txtOcupacion.Text.Trim();
            }
        }

        private void RefrescaValores()
        {
            try
            {
                if (sqlWhere.Equals(""))
                {
                    #region Establece valores en la clase Persona

                    Program.oCPacientes.NumExpediente = Convert.ToInt32(oArregloRefrescamiento[0]);

                    if (oArregloRefrescamiento[1] != null)
                        Program.oCPacientes.TipoCedula = oArregloRefrescamiento[1].ToString().Trim();
                    else
                        Program.oCPacientes.TipoCedula = null;

                    if (oArregloRefrescamiento[2] != null)
                        Program.oCPacientes.Cedula = oArregloRefrescamiento[2].ToString().Trim();
                    else
                        Program.oCPacientes.Cedula = null;

                    if (oArregloRefrescamiento[3] != null)
                        Program.oCPacientes.Nombre = oArregloRefrescamiento[3].ToString().Trim();
                    else
                        Program.oCPacientes.Nombre = null;

                    if (oArregloRefrescamiento[4] != null)
                        Program.oCPacientes.Apellidos = oArregloRefrescamiento[4].ToString().Trim();
                    else
                        Program.oCPacientes.Apellidos = null;

                    Program.oCPacientes.FechaNacimiento = Convert.ToDateTime(oArregloRefrescamiento[5]);

                    if (oArregloRefrescamiento[6] != null)
                        Program.oCPacientes.Sexo = oArregloRefrescamiento[6].ToString().Trim();
                    else
                        Program.oCPacientes.Sexo = null;

                    if (oArregloRefrescamiento[7] != null)
                        Program.oCPacientes.EstadoCivil = oArregloRefrescamiento[7].ToString().Trim();
                    else
                        Program.oCPacientes.EstadoCivil = null;

                    if (oArregloRefrescamiento[8] != null)
                        Program.oCPacientes.Ocupacion = oArregloRefrescamiento[8].ToString().Trim();
                    else
                        Program.oCPacientes.Ocupacion = null;

                    #endregion

                    Metodos_Globales.LlenarGrid(Grid1, Program.oCPacientes.ConsultarConParametros(sqlWhere));

                    object sender = new object();
                    DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, indiceFilaSeleccionada);
                    Grid1_CellEnter(sender, e2);
                }
            }
            catch { }
        }

        private void CerrarExpedientes()
        {
            if (Nuevo == false)
            {
                txtFoco.Focus();
                Grid1.DataSource = null;

                InfoImagen = null;
                pictureBox1.Image = null;

                lstContactos.Items.Clear();
                HabilitaOpcionesContactos();

                LimpiaCamposDatosPersonales();
                LimpiaCamposDatosFamiliares();
                LimpiaCamposExamenObservaciones();
                LimpiaCamposAntecedentes();
                LimpiaCamposAntecedentesObstetGinec();

                DeshabilitaCamposAntecedentesObstetGinec();
                DeshabilitaCamposAntecedentes();
                DeshabilitaCamposExamenObservaciones();
                DeshabilitaCamposDatosFamiliares();
                DeshabilitaCamposDatosPersonales();

                btnReturn.Enabled = false;
                btnMagnify.Enabled = false;
                btnGuardarExamenObservaciones.Enabled = false;
                btnGuardarAntecedentesGenerales.Enabled = false;
                btnCancelarAntecedObstetGinec.Enabled = false;
                btnGuardarAntecedObstetGinec.Enabled = false;
                btnCancelarExamenObservaciones.Enabled = false;
                btnCancelarAntecedGenerales.Enabled = false;
                tobCancelarDatosMadre.Enabled = false;
                tobGuardarDatosMadre.Enabled = false;
                tobGuardarDatosPadre.Enabled = false;
                tobCancelarDatosPadre.Enabled = false;

                tobNuevo.Enabled = true;
                tobModificar.Enabled = false;
                tobGuardar.Enabled = false;
                tobCancelar.Enabled = false;
                tobIniciarConsulta.Enabled = true;
                tobCancelarConsulta.Enabled = false;
                tobEjecutarConsulta.Enabled = false;
                tobCerrar.Enabled = false;

                HabilitarOpcionesConsultasAntiguas(false);
                txtDetalleAdicional.Text = "";
                lstConsultas.Items.Clear();
                
                if (ofrmPDFViewer != null)
                    ofrmPDFViewer.Close();
            }

            LimpiarArreglos();

            Nuevo = false;
            Modificar = false;
            Consultar = false;
        }

        public void tobCerrar_Click(object sender, EventArgs e)
        {
            if (Grid1.RowCount > 0)
            {
                Program.oMDI.vScroll_HistoriaClinica = 0;
                txtFoco.Focus();

                if (MessageBox.Show(this, "¿Está completamente seguro que desea cerrar los expedientes abiertos?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CerrarExpedientes();
                }
            }
            else
                MessageBox.Show(this, "No hay ningún expediente abierto para cerrar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private bool VerificaValoresConcurrentesGesta()
        {
            int gesta = Convert.ToInt32(txtGesta.Text.Trim());

            int sumaValores = Convert.ToInt32(txtPara.Text.Trim()) +
                              Convert.ToInt32(txtGemelares.Text.Trim()) +
                              Convert.ToInt32(txtMolas.Text.Trim()) +
                              Convert.ToInt32(txtAbortos.Text.Trim()) +
                              Convert.ToInt32(txtCesareas.Text.Trim()) +
                              Convert.ToInt32(txtEctopicos.Text.Trim()) +
                              Convert.ToInt32(txtObitos.Text.Trim());

            if (sumaValores < gesta || sumaValores > gesta)
            {
                MessageBox.Show(this, "Los valores no coinciden con el total establecido en la gesta, los cuales deben coincidir con exactamente el mismo valor en la misma.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
                return true;
        }

        private void EstableceValorCero(Control oControl)
        {
            if (oControl.Text.Trim() == "")
            {
                oControl.Text = "0";
                ((TextBox)(oControl)).SelectAll();
            }
        }

        #region Antecedentes Obstétricos y Ginecológicos

        #region Eventos TextChanged

        private void txtGesta_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtGesta);

            if (Grid1.RowCount > 0)
            {
                if (MDIPrincipal.RolUsuario == "Administrador" || (bool)oArregloPermisos[4] == true)
                {
                    if (txtGesta.Text.Trim() == "0")
                    {
                        tobUsarFUP.Enabled = false;
                        lblUsarFUP.Visible = false;
                        tobUsarFUP.Image = Properties.Resources.ok__1_;
                        tobUsarFUP.ToolTipText = "Dé click para No Utilizar un valor específico de la fecha de último parto";
                        usarFUP = false;
                        lblUsarFUP.Visible = false;

                        dtFechaUltimoParto.Enabled = false;
                        txtComplicacionesUP.Enabled = false;
                        txtComplicacionesUP.Visible = false;
                        lblNoDisponible.Visible = true;
                    }
                    else
                    {
                        if (dtFechaUltimoParto.Value.Date == new DateTime(1900, 1, 1))
                        {
                            tobUsarFUP.Enabled = true;
                            lblUsarFUP.Visible = true;
                            tobUsarFUP.Image = Properties.Resources.nok__1_;
                            tobUsarFUP.ToolTipText = "Dé click para Utilizar un valor específico de la fecha de último parto";
                            usarFUP = false;                           
                        }
                        else
                        {
                            tobUsarFUP.Enabled = true;
                            lblUsarFUP.Visible = false;
                            tobUsarFUP.Image = Properties.Resources.ok__1_;
                            tobUsarFUP.ToolTipText = "Dé click para No Utilizar un valor específico de la fecha de último parto";
                            usarFUP = true;
                            lblUsarFUP.Visible = false;
                        }

                        dtFechaUltimoParto.Enabled = true;
                        txtComplicacionesUP.Enabled = true;
                        lblNoDisponible.Visible = false;
                        txtComplicacionesUP.Visible = true;
                    }
                }
            }
            else
                lblNoDisponible.Visible = false;
        }

        private void txtPara_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtPara);
        }

        private void txtGemelares_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtGemelares);
        }

        private void txtMolas_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtMolas);
        }

        private void txtAbortos_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtAbortos);
        }

        private void txtCesareas_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtCesareas);
        }

        private void txtEctopicos_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtEctopicos);
        }

        private void txtObitos_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtObitos);
        }

        private void BloqueaCampos_Gestas(int pOpcion)
        {
            if (pOpcion == 1)
            {
                txtGesta.Text = "0";
                txtPara.Text = "0";
                txtGemelares.Text = "0";
                txtMolas.Text = "0";
                txtAbortos.Text = "0";
                txtCesareas.Text = "0";
                txtEctopicos.Text = "0";
                txtObitos.Text = "0";

                txtGesta.Enabled = false;
                txtPara.Enabled = false;
                txtGemelares.Enabled = false;
                txtMolas.Enabled = false;
                txtAbortos.Enabled = false;
                txtCesareas.Enabled = false;
                txtEctopicos.Enabled = false;
                txtObitos.Enabled = false;
            }
            else if (pOpcion == 0)
            {
                txtGesta.Enabled = true;
                txtPara.Enabled = true;
                txtGemelares.Enabled = true;
                txtMolas.Enabled = true;
                txtAbortos.Enabled = true;
                txtCesareas.Enabled = true;
                txtEctopicos.Enabled = true;
                txtObitos.Enabled = true;
            }

            object sender = new object();
            EventArgs e = new EventArgs();

            txtGesta_TextChanged(sender, e);
        }

        private void txtMenarca_TextChanged(object sender, EventArgs e)
        {
            if (MDIPrincipal.RolUsuario == "Administrador" || (bool)oArregloPermisos[4] == true)
            {
                EstableceValorCero(txtMenarca);

                if (txtMenarca.Text.Trim() == "0")
                {
                    txtMenopausia.Enabled = false;
                    txtMenopausia.Text = "0";
                    txtCicloMenstrual.Enabled = false;
                    txtCicloMenstrual.Text = "";
                    cmbTipoCiclo.Enabled = false;
                    cmbTipoCiclo.SelectedIndex = 2;
                    txtDetalleTipoCiclo.Enabled = false;
                    
                    tobUsarFUP.Enabled = false;
                    lblUsarFUP.Visible = false;
                    tobUsarFUP.Image = Properties.Resources.ok__1_;
                    tobUsarFUP.ToolTipText = "Dé click para No Utilizar un valor específico de la fecha de último parto";
                    usarFUP = true;
                    lblUsarFUP.Visible = false;

                    BloqueaCampos_Gestas(1);
                }
                else
                {
                    txtMenopausia.Enabled = true;
                    txtCicloMenstrual.Enabled = true;
                    cmbTipoCiclo.Enabled = true;
                    cmbTipoCiclo.SelectedIndex = 0;
                    txtDetalleTipoCiclo.Enabled = true;

                    if (dtFechaUltimoParto.Value.Date == new DateTime(1900, 1, 1))
                    {
                        lblUsarFUP.Visible = true;
                        tobUsarFUP.Enabled = true;
                        tobUsarFUP.Image = Properties.Resources.nok__1_;
                        tobUsarFUP.ToolTipText = "Dé click para Utilizar un valor específico de la fecha de último parto";

                        usarFUP = false;
                    }
                    else
                    {
                        tobUsarFUP.Enabled = true;
                        tobUsarFUP.Image = Properties.Resources.ok__1_;
                        tobUsarFUP.ToolTipText = "Dé click para No Utilizar un valor específico de la fecha de último parto";
                        usarFUP = true;
                        lblUsarFUP.Visible = false;
                    }

                    BloqueaCampos_Gestas(0);
                }
            }
        }

        private void txtMenopausia_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtMenopausia);
        }

        private void txtDetalleAdicionalesAntGin_TextChanged(object sender, EventArgs e)
        {
            //fEstableceValorCero(txtDetalleAdicionalesAntGin);
        }

        #endregion

        #region Eventos Enter Controles

        private void SeleccionaTexto(Control oControl)
        {
            ((TextBox)(oControl)).SelectAll();
        }

        private void txtGesta_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtGesta);
        }

        private void txtPara_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtPara);
        }

        private void txtGemelares_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtGemelares);
        }

        private void txtMolas_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtMolas);
        }

        private void txtAbortos_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtAbortos);
        }

        private void txtCesareas_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtCesareas);
        }

        private void txtEctopicos_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtEctopicos);
        }

        private void txtObitos_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtObitos);
        }

        private void txtMenarca_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtMenarca);
        }

        private void txtMenopausia_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtMenopausia);
        }

        #endregion

        private void DeshabilitaCamposAntecedentesObstetGinec()
        {
            txtGesta.Enabled = false;
            txtPara.Enabled = false;
            txtGemelares.Enabled = false;
            txtMolas.Enabled = false;
            txtAbortos.Enabled = false;
            txtCesareas.Enabled = false;
            txtEctopicos.Enabled = false;
            txtObitos.Enabled = false;
            txtDetalleAdicionalesAntGin.Enabled = false;

            dtFechaUltimoParto.Enabled = false;
            txtComplicacionesUP.Enabled = false;

            txtMenarca.Enabled = false;
            txtMenopausia.Enabled = false;
            txtCicloMenstrual.Enabled = false;
            cmbTipoCiclo.Enabled = false;
            txtDetalleTipoCiclo.Enabled = false;
        }

        private void HabilitaCamposAntecedentesObstetGinec()
        {
            txtGesta.Enabled = true;
            txtPara.Enabled = true;
            txtGemelares.Enabled = true;
            txtMolas.Enabled = true;
            txtAbortos.Enabled = true;
            txtCesareas.Enabled = true;
            txtEctopicos.Enabled = true;
            txtObitos.Enabled = true;
            txtDetalleAdicionalesAntGin.Enabled = true;

            if (dtFechaUltimoParto.Value.Date != new DateTime(1900, 1, 1))
            {
                dtFechaUltimoParto.Enabled = true;
                txtComplicacionesUP.Enabled = true;
            }
            else
            {
                dtFechaUltimoParto.Enabled = false;
                txtComplicacionesUP.Enabled = false;
            }

            txtMenarca.Enabled = true;
            txtMenopausia.Enabled = true;
            txtCicloMenstrual.Enabled = true;
            cmbTipoCiclo.Enabled = true;
            txtDetalleTipoCiclo.Enabled = true;
        }

        private void LimpiaCamposAntecedentesObstetGinec()
        {
            txtGesta.Text = String.Empty;
            txtPara.Text = String.Empty;
            txtGemelares.Text = String.Empty;
            txtMolas.Text = String.Empty;
            txtAbortos.Text = String.Empty;
            txtCesareas.Text = String.Empty;
            txtEctopicos.Text = String.Empty;
            txtObitos.Text = String.Empty;
            txtDetalleAdicionalesAntGin.Text = String.Empty;

            dtFechaUltimoParto.Value = DateTime.Today;
            txtComplicacionesUP.Text = String.Empty;

            txtMenarca.Text = String.Empty;
            txtMenopausia.Text = String.Empty;
            txtCicloMenstrual.Text = String.Empty;
            cmbTipoCiclo.SelectedIndex = -1;
            txtDetalleTipoCiclo.Text = String.Empty;
        }

        private void btnGuardarAntecedObstetGinec_Click(object sender, EventArgs e)
        {
            //if (VerificaValoresConcurrentesGesta() == true)
            //{
            bool continuar = false;

            if (MDIPrincipal.RolUsuario == "Administrador")
                continuar = true;
            else
            {
                if ((bool)oArregloPermisos[3] == true)
                {
                    FrmSolicitudAdmin oFrmSolicitudAdmin = new FrmSolicitudAdmin();
                    oFrmSolicitudAdmin.ShowDialog();

                    if (FrmSolicitudAdmin.Continuar == true)
                        continuar = true;
                    else
                    {
                        MessageBox.Show(this, "No se puede continuar con estas acciones hasta que un administrador del sistema otorgue la autorización necesaria, ya que así lo establecen los permisos de usuario establecidos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        continuar = false;
                    }
                }
                else
                    continuar = true;
            }

            if (continuar == true)
            {
                if (cmbTipoCiclo.SelectedIndex != -1 || cmbTipoCiclo.SelectedIndex == 2 && txtMenarca.Text.Trim() != "0")
                {
                    if (cmbTipoCiclo.SelectedIndex != 2 && txtMenarca.Text.Trim() == "0")
                    {
                        MessageBox.Show(this, "No puede establecer un tipo de ciclo si el valor de la menarca del paciente no ha sido establecida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    oCAntecedentes_ObstetGinec.Num_Expediente = TxtNumExpediente.Text.Trim();
                    oCAntecedentes_ObstetGinec.Gesta = txtGesta.Text.Trim();
                    oCAntecedentes_ObstetGinec.Para = txtPara.Text.Trim();
                    oCAntecedentes_ObstetGinec.Abortos = txtAbortos.Text.Trim();
                    oCAntecedentes_ObstetGinec.Cesareas = txtCesareas.Text.Trim();
                    oCAntecedentes_ObstetGinec.Gemelares = txtGemelares.Text.Trim();
                    oCAntecedentes_ObstetGinec.Molas = txtMolas.Text.Trim();
                    oCAntecedentes_ObstetGinec.Ectopicos = txtEctopicos.Text.Trim();
                    oCAntecedentes_ObstetGinec.Obitos = txtObitos.Text.Trim();
                    oCAntecedentes_ObstetGinec.UltimoParto = dtFechaUltimoParto.Value;
                    oCAntecedentes_ObstetGinec.ComplicacionesUltimoParto = txtComplicacionesUP.Text.Trim();
                    oCAntecedentes_ObstetGinec.Menarca = txtMenarca.Text.Trim();
                    oCAntecedentes_ObstetGinec.Menopausia = txtMenopausia.Text.Trim();
                    oCAntecedentes_ObstetGinec.CicloMenstrual = txtCicloMenstrual.Text.Trim();
                    oCAntecedentes_ObstetGinec.TipoCiclo = cmbTipoCiclo.SelectedIndex.ToString().Trim();
                    oCAntecedentes_ObstetGinec.DetalleTipoCiclo = txtDetalleTipoCiclo.Text.Trim();
                    oCAntecedentes_ObstetGinec.DetalleAdicional = txtDetalleAdicionalesAntGin.Text.Trim();

                    if (oArregloAntecedentesObstetGinec.Count == 0)
                        oCAntecedentes_ObstetGinec.Insertar();
                    else
                        oCAntecedentes_ObstetGinec.Modificar();

                    #region Limpia arreglo y reestablece nuevos datos

                    oArregloAntecedentesObstetGinec.Clear();

                    oArregloAntecedentesObstetGinec.Add(txtGesta.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtPara.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtAbortos.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtCesareas.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtGemelares.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtMolas.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtEctopicos.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtObitos.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(dtFechaUltimoParto.Value);
                    oArregloAntecedentesObstetGinec.Add(txtComplicacionesUP.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtMenarca.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtMenopausia.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtCicloMenstrual.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(cmbTipoCiclo.SelectedIndex);
                    oArregloAntecedentesObstetGinec.Add(txtDetalleTipoCiclo.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtDetalleAdicionalesAntGin.Text.Trim());

                    #endregion

                    CompruebaCambiosRealizados_AntecedentesObstetGinec();
                }
                else
                    MessageBox.Show(this, "Debe establecer un tipo de ciclo válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
        }

        private void CompruebaCambiosRealizados_AntecedentesObstetGinec()
        {
            if (TxtNumExpediente.Text.Trim() != "")
            {
                btnGuardarAntecedObstetGinec.Enabled = false;
                btnCancelarAntecedObstetGinec.Enabled = false;

                if (oArregloAntecedentesObstetGinec.Count == 16)
                {
                    if (txtGesta.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtGesta.Tag)].ToString().Trim() ||
                        txtPara.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtPara.Tag)].ToString().Trim() ||
                        txtAbortos.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtAbortos.Tag)].ToString().Trim() ||
                        txtCesareas.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtCesareas.Tag)].ToString().Trim() ||
                        txtGemelares.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtGemelares.Tag)].ToString().Trim() ||
                        txtMolas.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtMolas.Tag)].ToString().Trim() ||
                        txtEctopicos.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtEctopicos.Tag)].ToString().Trim() ||
                        txtObitos.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtObitos.Tag)].ToString().Trim() ||
                        dtFechaUltimoParto.Value != Convert.ToDateTime(oArregloAntecedentesObstetGinec[Convert.ToInt32(dtFechaUltimoParto.Tag)]) ||
                        txtComplicacionesUP.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtComplicacionesUP.Tag)].ToString().Trim() ||
                        txtMenarca.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtMenarca.Tag)].ToString().Trim() ||
                        txtMenopausia.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtMenopausia.Tag)].ToString().Trim() ||
                        txtCicloMenstrual.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtCicloMenstrual.Tag)].ToString().Trim() ||
                        cmbTipoCiclo.SelectedIndex.ToString() != oArregloAntecedentesObstetGinec[Convert.ToInt32(cmbTipoCiclo.Tag)].ToString().Trim() ||
                        txtDetalleTipoCiclo.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtDetalleTipoCiclo.Tag)].ToString().Trim() ||
                        txtDetalleAdicionalesAntGin.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtDetalleAdicionalesAntGin.Tag)].ToString().Trim())
                    {
                        btnGuardarAntecedObstetGinec.Enabled = true;
                        btnCancelarAntecedObstetGinec.Enabled = true;
                    }
                }
                else
                {
                    btnGuardarAntecedObstetGinec.Enabled = true;
                    btnCancelarAntecedObstetGinec.Enabled = false;
                }
            }
        }

        private void btnCancelarAntecedObstetGinec_Click(object sender, EventArgs e)
        {
            txtGesta.Text = oArregloAntecedentesObstetGinec[0].ToString().Trim();
            txtPara.Text = oArregloAntecedentesObstetGinec[1].ToString().Trim();
            txtAbortos.Text = oArregloAntecedentesObstetGinec[2].ToString().Trim();
            txtCesareas.Text = oArregloAntecedentesObstetGinec[3].ToString().Trim();
            txtGemelares.Text = oArregloAntecedentesObstetGinec[4].ToString().Trim();
            txtMolas.Text = oArregloAntecedentesObstetGinec[5].ToString().Trim();
            txtEctopicos.Text = oArregloAntecedentesObstetGinec[6].ToString().Trim();
            txtObitos.Text = oArregloAntecedentesObstetGinec[7].ToString().Trim();
            dtFechaUltimoParto.Value = Convert.ToDateTime(oArregloAntecedentesObstetGinec[8]);
            txtComplicacionesUP.Text = oArregloAntecedentesObstetGinec[9].ToString().Trim();
            txtMenarca.Text = oArregloAntecedentesObstetGinec[10].ToString().Trim();
            txtMenopausia.Text = oArregloAntecedentesObstetGinec[11].ToString().Trim();
            txtCicloMenstrual.Text = oArregloAntecedentesObstetGinec[12].ToString().Trim();
            cmbTipoCiclo.SelectedIndex = Convert.ToInt32(oArregloAntecedentesObstetGinec[13]);
            txtDetalleTipoCiclo.Text = oArregloAntecedentesObstetGinec[14].ToString().Trim();
            txtDetalleAdicionalesAntGin.Text = oArregloAntecedentesObstetGinec[15].ToString().Trim();

            btnGuardarAntecedObstetGinec.Enabled = false;
            btnCancelarAntecedObstetGinec.Enabled = false;
        }

        #region Eventos KeyUp de Cajas de Texto

        private void txtGesta_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtPara_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtGemelares_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtMolas_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtAbortos_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtCesareas_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtEctopicos_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtObitos_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void dtFechaUltimoParto_ValueChanged(object sender, EventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();

            if (dtFechaUltimoParto.Value.Date == new DateTime(1900, 1, 1))
            {
                tobUsarFUP.Enabled = true;
                lblUsarFUP.Visible = true;
                tobUsarFUP.Image = Properties.Resources.nok__1_;
                tobUsarFUP.ToolTipText = "Dé click para Utilizar un valor específico de la fecha de último parto";
                usarFUP = false;
            }
            else
            {
                if (txtGesta.Text.Trim() != "0" && txtGesta.Text.Trim() != "")
                {
                    tobUsarFUP.Enabled = true;
                    lblUsarFUP.Visible = false;
                    tobUsarFUP.Image = Properties.Resources.ok__1_;
                    tobUsarFUP.ToolTipText = "Dé click para No Utilizar un valor específico de la fecha de último parto";
                    usarFUP = true;
                }
                else
                {
                    tobUsarFUP.Enabled = false;
                    lblUsarFUP.Visible = false;
                    tobUsarFUP.Image = Properties.Resources.ok__1_;
                    tobUsarFUP.ToolTipText = "Dé click para No Utilizar un valor específico de la fecha de último parto";
                    usarFUP = false;
                }
            }
        }

        private void txtComplicacionesUP_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtMenarca_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtMenopausia_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtCicloMenstrual_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void cmbTipoCiclo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtMenarca.Text.Trim() != "0" && txtMenarca.Text.Trim() != "")
            {
                if (cmbTipoCiclo.SelectedIndex == 2)
                {
                    cmbTipoCiclo.SelectedIndex = 0;
                    MessageBox.Show(this, "El tipo de ciclo sólamente se catalogará como \"No Disponible\" cuando no se presente ningún valor en la Menarca del paciente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtDetalleTipoCiclo_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtDetalleAdicionalesAntGin_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        #endregion

        private void cmbTipoCiclo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Down) || e.KeyChar == Convert.ToChar(Keys.Up) || e.KeyChar == Convert.ToChar(Keys.Tab))
                e.Handled = false;
            else
                e.Handled = true;
        }

        #endregion

        private void frmHistoriaClinica_Activated(object sender, EventArgs e)
        {
            try
            {
                if (Program.MostrarBarraSiempre == 1 || Program.MostraBarraInicio == 1)
                {
                    Program.oMDI.BarraPacientes.Show();
                    Program.oMDI.BarraPacientes.BringToFront();
                }
            }
            catch { }
        }

        private void cmbTipoSangre_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompruebaCambiosRealizados_ExamenObservaciones();
        }

        private void rdRHPositivo_CheckedChanged(object sender, EventArgs e)
        {
            CompruebaCambiosRealizados_ExamenObservaciones();
        }

        private void rdRHNegativo_CheckedChanged(object sender, EventArgs e)
        {
            CompruebaCambiosRealizados_ExamenObservaciones();
        }

        private void cmbTipoSangre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Program.oMDI.MdiClient_MouseMove(sender, e);
        }

        private void btnGuardarAntecedentesGenerales_EnabledChanged(object sender, EventArgs e)
        {
            tobGuardarAntecedentesGenerales.Enabled = btnGuardarAntecedentesGenerales.Enabled;
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (Program.oMDI.BarraPacientes.Visible == false)
                Program.oMDI.BarraPacientes.Show();
            else
                Program.oMDI.BarraPacientes.Hide();
        }

        private void tobCameraOn_Click(object sender, EventArgs e)
        {
            tobCameraOn.Enabled = false;
            tobCameraOff.Enabled = true;
            tobSnapshot.Enabled = true;

            //pictureBox1.BackgroundImageLayout = ImageLayout.None;
            // change the capture time frame
            this.WebCamCapture.TimeToCapture_milliseconds = 20;//(int)this.numCaptureTime.Value;

            // start the video capture. let the control handle the
            // frame numbers.
            this.WebCamCapture.Start(0);
        }

        private void tobCameraOff_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Realmente desea detener la cámara?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                // stop the video capture
                tobCameraOn.Enabled = true;
                tobCameraOff.Enabled = false;
                tobSnapshot.Enabled = false;

                this.WebCamCapture.Stop();
                this.pictureBox1.Image = null;
            }
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        private void tobSnapshot_Click(object sender, EventArgs e)
        {
            try
            {
                System.Media.SoundPlayer oSoundPlayer = new System.Media.SoundPlayer(Properties.Resources.camera1);
                oSoundPlayer.Play();

                string path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");
                path += "\\tempPicture.jpg";

                try
                {
                    File.Delete(path);
                }
                catch { }

                //this.pictureBox1.BackgroundImage = cropImage(this.pictureBox1.BackgroundImage, pictureBox1.ClientRectangle);
                this.pictureBox1.Image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                DireccImage = path;

                tobCameraOn.Enabled = true;
                tobCameraOff.Enabled = false;
                tobSnapshot.Enabled = false;

                this.WebCamCapture.Stop();
            }
            catch (Exception oExc) 
            { 
                MessageBox.Show(this, "Se detectó un error: " + oExc.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.WebCamCapture.Stop();
            }
        }

        private void WebCamCapture_ImageCaptured(object source, WebCam_Capture.WebcamEventArgs e)
        {
            
        }

        private void FrmMantEmpleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WebCamCapture.Stop();
        }

        private void WebCamCapture_ImageCaptured_1(object source, WebCam_Capture.WebcamEventArgs e)
        {
            this.pictureBox1.Image = e.WebCamImage;
        }

        private void tobUsarFUP_Click(object sender, EventArgs e)
        {
            if (usarFUP == true)
            {
                usarFUP = false;

                lblUsarFUP.Visible = true;
                tobUsarFUP.Image = Properties.Resources.nok__1_;
                tobUsarFUP.ToolTipText = "Dé click para Utilizar un valor específico de la fecha de último parto";
                dtFechaUltimoParto.Value = new DateTime(1900, 1, 1);
            }
            else
            {
                usarFUP = true;

                lblUsarFUP.Visible = false;
                tobUsarFUP.Image = Properties.Resources.ok__1_;
                tobUsarFUP.ToolTipText = "Dé click para No Utilizar un valor específico de la fecha de último parto";
                dtFechaUltimoParto.Value = DateTime.Today;
            }
        }

        private void lblUsarFUP_VisibleChanged(object sender, EventArgs e)
        {
            bool t = lblUsarFUP.Visible;
        }

        private void txtPesoHabitual_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Metodos_Globales.AvoidedCharacters(txtPesoHabitual.Text, e);
        }

        private void txtTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Metodos_Globales.AvoidedCharacters(txtTalla.Text, e);
        }

        private void btnAgregarConsultaAntigua_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtNumExpediente.Text.Trim()))
            {
                frmConsultasAntiguas ofrmConsultasAntiguas = new frmConsultasAntiguas(Convert.ToInt32(TxtNumExpediente.Text.Trim()));                
                ofrmConsultasAntiguas.ShowDialog();

                LlenarConsultasAntiguas();
            }
        }

        private void HabilitarOpcionesConsultasAntiguas(bool pHabilitar)
        {
            tobModificarConsulta.Enabled = pHabilitar;
            tobGuardarConsulta.Enabled = pHabilitar;
            tobCancelarModifConsulta.Enabled = pHabilitar;
            tobEliminarConsulta.Enabled = pHabilitar;
        }

        private void LlenarConsultasAntiguas()
        {
            lstConsultas.Items.Clear();
            txtDetalleAdicional.Text = "";
            HabilitarOpcionesConsultasAntiguas(false);

            oCConsultasAntiguas.Num_expediente = Convert.ToInt32(TxtNumExpediente.Text.Trim());
            DataSet ds = oCConsultasAntiguas.Seleccionar();

            if (ds != null)
            {
                int cont = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstConsultas.Items.Add(dr[0].ToString());
                    lstConsultas.Items[cont].SubItems.Add(Convert.ToDateTime(dr[2]).ToLongDateString());

                    cont++;
                }

                ds.Dispose();
            }
        }

        private void lstConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstConsultas.SelectedItems.Count > 0)
            {
                string path = Path.GetTempFileName();

                byte[] documento = null;
                string detalle_adicional = "";

                DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select detalle_adicional, detalle_consulta from Consultas_Antiguas_Paciente where id_consulta = " + lstConsultas.SelectedItems[0].Text, "Consultas_Antiguas_Paciente");

                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        detalle_adicional = dr[0].ToString().Trim();
                        documento = (byte[])dr[1];
                    }
                    ds.Dispose();
                }

                txtDetalleAdicional.Text = detalle_adicional;

                if (ofrmPDFViewer != null)
                    ofrmPDFViewer.Close();

                File.Move(path, System.IO.Path.ChangeExtension(path, ".pdf"));
                path = System.IO.Path.ChangeExtension(path, ".pdf");
                System.IO.File.WriteAllBytes(path, documento);

                ofrmPDFViewer = new frmPDFViewer(path);
                ofrmPDFViewer.StartPosition = FormStartPosition.Manual;
                ofrmPDFViewer.Location = new Point(0, ((Screen.PrimaryScreen.WorkingArea.Height - ofrmPDFViewer.Height) / 2));
                ofrmPDFViewer.Show(this);

                lstConsultas.Focus();

                tobModificarConsulta.Enabled = true;
                tobEliminarConsulta.Enabled = true;
            }
            else
                HabilitarOpcionesConsultasAntiguas(false);
        }

        private void tobModificarConsulta_Click(object sender, EventArgs e)
        {
            txtDetalleAdicional.ReadOnly = false;

            tobModificar.Enabled = false;
            tobGuardarConsulta.Enabled = true;
            tobCancelarModifConsulta.Enabled = true;
        }

        private void tobGuardarConsulta_Click(object sender, EventArgs e)
        {
            if (lstConsultas.SelectedItems.Count > 0)
            {
                oCConsultasAntiguas.Detalle_adicional = txtDetalleAdicional.Text.Trim();
                oCConsultasAntiguas.Id_consulta = Convert.ToInt32(lstConsultas.SelectedItems[0].Text.Trim());
                oCConsultasAntiguas.Modificar();

                tobCancelarModifConsulta_Click(sender, e);
            }            
        }

        private void tobCancelarModifConsulta_Click(object sender, EventArgs e)
        {
            txtDetalleAdicional.ReadOnly = true;
            LlenarConsultasAntiguas();

            tobModificar.Enabled = true;
            tobGuardarConsulta.Enabled = false;
            tobCancelarModifConsulta.Enabled = false;
        }

        private void tobEliminarConsulta_Click(object sender, EventArgs e)
        {
            if (lstConsultas.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "¿Está seguro de querer proceder con estas acciones?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    oCConsultasAntiguas.Id_consulta = Convert.ToInt32(lstConsultas.SelectedItems[0].Text.Trim());
                    oCConsultasAntiguas.Eliminar();

                    LlenarConsultasAntiguas();

                    HabilitarOpcionesConsultasAntiguas(false);
                }
            }
        }

        private void lstConsultas_Click(object sender, EventArgs e)
        {

        }

        private void lstConsultas_DoubleClick(object sender, EventArgs e)
        {
        }

        private void tobModificarConsulta_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void TxtNumExpediente_KeyDown(object sender, KeyEventArgs e)
        {
            if (consultaLocal == true)
            {
                if (e.KeyCode == Keys.Enter)
                    SendKeys.Send("{F6}");
            }
        }

        private void txtApellidos_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtApellidos, txtApellidos.Text);
        }

        private void txtApellidos_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(txtApellidos, txtApellidos.Text);
        }
    }
}