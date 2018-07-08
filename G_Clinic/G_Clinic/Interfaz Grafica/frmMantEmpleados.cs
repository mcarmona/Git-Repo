using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using G_Clinic.Miscelaneos_y_Recursos;
using G_Clinic.Interfaz_Grafica;
using G_Clinic.Lógica_Negocios;
using G_Clinic.Properties;
using Transitions;

namespace G_Clinic
{
    public partial class FrmMantEmpleados : Form
    {
        //Estado Activo = 0, Inactivo = 1
        public FrmMantEmpleados()
        {
            this.SuspendLayout();
            InitializeComponent();
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.Mantenimiento);

            Grid1.AutoGenerateColumns = false;
            pictureBox2.Parent = pictureBox1;
            pictureBox2.Location = new Point(pictureBox1.Width - pictureBox2.Width - 10, pictureBox1.Height - pictureBox2.Height - 10);
            try
            {
                VistaConstants.SetWindowTheme(lstContactos.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstContactos.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
            }
            catch { }
            this.ResumeLayout();
        }

        #region MoverForm

        const int WM_SYSCOMMAND = 0x112;
        const int MOUSE_MOVE = 0xF012;

        // Declaraciones del API
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        // función privada usada para mover el formulario actual
        private void moverForm()
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, MOUSE_MOVE, 0);
        }

        #endregion

        private void setStyles()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            this.UpdateStyles();
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

        #region Variables

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

        CEmpleados oCEmpleados = new CEmpleados();
        CContactosEmpleados oCContactosEmpleados = new CContactosEmpleados();
        CCategoriasEmpleado oCCategoriasEmpleado = new CCategoriasEmpleado();

        AutoCompleteStringCollection oAutoComplete = new AutoCompleteStringCollection();

        #endregion

        #region Eventos Misceláneos de controles

        private void TxtCodEmpl_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese el Id del Empleado a consultar";
        }

        private void TxtNombre_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese el Nombre del Empleado a consultar";
        }

        private void TxtNomEmpl_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese el Nombre del Empleado";
        }

        private void TxtCedula_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese el Número de Cédula del Empleado";
        }

        private void CmbSexo_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione una opción para determinar el Sexo del Empleado";
        }

        private void DtFecha_Naci_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione una fecha para determinar la Fecha de Nacimiento del Empleado";
        }

        private void TxtEdad_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione una fecha para determinar la Edad del Empleado";
        }

        private void CmbEstadoCivil_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione la categoría a la cual pertenece el empleado";
        }

        private void TxtDireccion_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese la Dirección Residencial del Empleado";
        }

        private void DtFechaIng_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione una fecha para determinar la Fecha de Ingreso del Empleado a la empresa";
        }

        private void CmbEstado_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Presione la Tecla F1 para ver listado de los Estados del Empleado existentes";
        }

        private void CmbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Down) || e.KeyChar == Convert.ToChar(Keys.Up) || e.KeyChar == Convert.ToChar(Keys.Tab))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void CmbEstadoCivil_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (InfoImagen != null && ImagenDisponible == true)
                {
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

        #region Métodos de estados de controles

        private void HabilitaCampos()
        {
            TxtCodigo.Enabled = true;
            TxtNomEmpl.Enabled = true;
            TxtCedula.Enabled = true;
            DtFecha_Naci.Enabled = true;
            TxtEdad.Enabled = true;
            CmbSexo.Enabled = true;
            CmbEstadoCivil.Enabled = true;
            TxtDireccion.Enabled = true;
            cmbCategoriasEmp.Enabled = true;
            rdActivo.Enabled = true;
            rdInactivo.Enabled = true;
            txtCodigoColegiado.Enabled = true;

            tobCameraOn.Enabled = true;
            tobCameraOff.Enabled = false;
            tobSnapshot.Enabled = false;
            BtnFoto.Enabled = true;
            BtnRemover.Enabled = true;

            pictureBox2.Enabled = true;
            RdNacional.Enabled = true;
            RdExtranjero.Enabled = true;
            tobGuardarCategoria.Enabled = true;
        }

        private void DeshabilitaCampos()
        {
            TxtCodigo.Enabled = false;
            TxtNomEmpl.Enabled = false;
            TxtCedula.Enabled = false;
            DtFecha_Naci.Enabled = false;
            TxtEdad.Enabled = false;
            CmbSexo.Enabled = false;
            CmbEstadoCivil.Enabled = false;
            TxtDireccion.Enabled = false;
            cmbCategoriasEmp.Enabled = false;
            rdActivo.Enabled = false;
            rdInactivo.Enabled = false;
            txtCodigoColegiado.Enabled = false;

            tobCameraOn.Enabled = false;
            tobCameraOff.Enabled = false;            
            tobSnapshot.Enabled = false;
            BtnFoto.Enabled = false;
            BtnRemover.Enabled = false;
            WebCamCapture.Stop();
            
            RdNacional.Enabled = false;
            RdExtranjero.Enabled = false;
            tobGuardarCategoria.Enabled = false;
        }

        private void LimpiaCampos()
        {
            TxtCodigo.Text = String.Empty;
            TxtNomEmpl.Text = String.Empty;
            TxtCedula.Text = String.Empty;
            DtFecha_Naci.Value = DateTime.Today;
            TxtEdad.Text = String.Empty;
            CmbSexo.SelectedIndex = 0;
            CmbEstadoCivil.SelectedIndex = 0;
            TxtDireccion.Text = String.Empty;
            //cmbCategoriasEmp.Text = string.Empty;
            CmbEstado.SelectedIndex = 0;
            RdNacional.Checked = true;
            rdActivo.Checked = true;
            txtCodigoColegiado.Text = String.Empty;
        }

        #endregion

        #region Modos

        private void ModoIniciarConsulta()
        {
            Consultar = true;

            TxtCodigo.Enabled = true;
            TxtCodigo.ReadOnly = false;
            TxtNomEmpl.Enabled = true;
            TxtCedula.Enabled = true;
            CmbSexo.Enabled = true;
            DtFecha_Naci.Enabled = false;
            TxtEdad.Enabled = false;
            CmbEstadoCivil.Enabled = true;
            CmbEstado.Enabled = false;
            TxtDireccion.Enabled = false;
            CmbEstado.Enabled = true;
            cmbCategoriasEmp.Enabled = true;

            LimpiaCampos();

            Metodos_Globales.ModoConsulta(toolStrip1);

            Grid1.Enabled = false;

            RdExtranjero.Enabled = true;
            RdNacional.Enabled = true;

            BtnFoto.Enabled = false;
            pictureBox2.Enabled = false;

            errorProvider1.SetError(this.pictureBox1, "");

            lstContactos.Items.Clear();
            tobEliminarContacto.Enabled = false;
            tobModificarContacto.Enabled = false;
            tobNuevoContacto.Enabled = false;
            tobGuardarContacto.Enabled = false;
            tobCancelarContacto.Enabled = false;

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
        }

        private void ModoEscritura()
        {
            Nuevo = true;
            Modificar = false;
            Consultar = false;

            HabilitaCampos();
            LimpiaCampos();

            Metodos_Globales.ModoEscritura(toolStrip1);

            Grid1.Enabled = false;

            BtnFoto.Enabled = true;
            pictureBox2.Enabled = true;

            errorProvider1.SetError(this.pictureBox1, "");

            tobEliminarContacto.Enabled = false;
            tobModificarContacto.Enabled = false;
            tobNuevoContacto.Enabled = false;
            tobGuardarContacto.Enabled = false;
            tobCancelarContacto.Enabled = false;

            lstContactos.Items.Clear();

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
        }

        private void ModoModificar()
        {
            Nuevo = false;
            Modificar = true;
            Consultar = false;

            HabilitaCampos();

            object sender = new object();
            EventArgs e = new EventArgs();
            cmbCategoriasEmp_SelectedValueChanged(sender, e);

            Metodos_Globales.ModoModificar(toolStrip1);

            Grid1.Enabled = false;

            BtnFoto.Enabled = true;
            pictureBox2.Enabled = true;

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);

            tobEliminarContacto.Enabled = false;
            tobModificarContacto.Enabled = false;
            tobNuevoContacto.Enabled = false;
            tobGuardarContacto.Enabled = false;
            tobCancelarContacto.Enabled = false;
        }

        private void ModoBloqueo()
        {
            Nuevo = false;
            Modificar = false;
            Consultar = false;

            DeshabilitaCampos();

            if (Grid1.Rows.Count > 0)
                tobModificar.Enabled = true;

            Metodos_Globales.ModoBloqueo(toolStrip1, Grid1);
            CargaAutoComplete();

            Grid1.Enabled = true;

            pictureBox2.Enabled = true;
            
            toolStripStatusLabel1.Text = "";
            DireccImage = "";

            HabilitaOpcionesContactos();

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
        }

        #endregion

        #region Eventos Click de Barra de Herramientas

        private void tobNuevo_Click_1(object sender, EventArgs e)
        {
            ModoEscritura();
            InfoImagen = null;
            //int maximo = 0;

            //StringBuilder sql1 = new StringBuilder();
            //sql1.Append("Select * from empleados");

            //// Extraer un DataSet
            //DataSet ds1 = Program.oPersistencia.ejecutarSQLListas(sql1.ToString(), "Empleados");

            //if (ds1.Tables[0].Rows.Count > 0)
            //{
            //    StringBuilder sql = new StringBuilder();
            //    sql.Append("Select max(id_emp) from empleados");

            //    // Extraer un DataSet
            //    DataSet ds = Program.oPersistencia.ejecutarSQLListas(sql.ToString(), "Empleados");

            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {

            //        maximo = Convert.ToInt32(dr[0].ToString().Trim());
            //        TxtCodigo.Text = Convert.ToString(maximo + 1);
            //    }

            //    ds.Dispose();
            //}
            //else
            //{
            //    TxtCodigo.Text = "1";
            //}

            //ds1.Dispose();
            //Llenar_Grid();
            TxtNomEmpl.Focus();
        }

        private void tobModificar_Click(object sender, EventArgs e)
        {
            //Modificar = true;
            //Nuevo = false;
            ModoModificar();
            //Llenar_Grid();
            //DireccImage = Grid1.CurrentRow.Cells["Column13"].Value.ToString();
        }

        private void tobGuardar_Click(object sender, EventArgs e)
        {
            byte[] imageData = null;
            StringBuilder Sql = new StringBuilder("");

            if (Nuevo == true)
            {
                Modificar = false;

                // Inserta
                VerificaCampo();

                if (Verifica == 0)
                {
                    oCEmpleados.Cedula = TxtCedula.Text.Trim();

                    if (RdNacional.Checked == true)
                        oCEmpleados.TipoCedula = "0";
                    else
                        oCEmpleados.TipoCedula = "1";

                    oCEmpleados.Nombre = TxtNomEmpl.Text.Trim();
                    oCEmpleados.FechaNacimiento = DtFecha_Naci.Value;
                    oCEmpleados.Sexo = CmbSexo.Text.Trim();
                    oCEmpleados.Direccion = TxtDireccion.Text.Trim();
                    oCEmpleados.EstadoCivil = CmbEstadoCivil.Text.Trim();

                    if (rdActivo.Checked == true)
                        oCEmpleados.Estado = "0";//True
                    else
                        oCEmpleados.Estado = "1";

                    oCEmpleados.CategoriaEmp = cmbCategoriasEmp.SelectedValue.ToString().Trim();
                    oCEmpleados.CodigoColegiado = txtCodigoColegiado.Text.Trim();

                    imageData = ReadFile(DireccImage.Trim());

                    if (imageData == null)
                    {
                        imageData = InfoImagen;
                        oCEmpleados.InfoImagen = imageData;
                    }
                    else
                        oCEmpleados.InfoImagen = imageData;

                    if (imageData != null)
                        oCEmpleados.Insertar();
                    else
                        oCEmpleados.Insertar_NoImage();

                    if (Program.oPersistencia.IsError == false)
                    {
                        if (MessageBox.Show(this, "¿Desea agregar un contacto para el empleado en estos momentos?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            Metodos_Globales.LlenarGrid(Grid1, oCEmpleados.ConsultarSinParametros());

                            Grid1.Rows[Grid1.Rows.GetLastRow(DataGridViewElementStates.None)].Selected = true;
                            DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, Grid1.Rows.GetLastRow(DataGridViewElementStates.None));
                            Grid1_CellEnter(sender, e2);
                            Grid1.FirstDisplayedScrollingRowIndex = Grid1.Rows.GetLastRow(DataGridViewElementStates.None);

                            tobNuevoContacto_Click(sender, e);
                        }
                        else
                            tobCancelar_Click(sender, e);
                    }
                }
            }//Fin del If

            if (Modificar == true)
            {
                Nuevo = false;

                Verifica_Datos_Seleccionados();

                VerificaCampo();

                if (Verifica2 == 0)
                {
                    if (Verifica == 0)
                    {
                        string qry = "";
                        imageData = ReadFile(DireccImage.Trim());

                        if (imageData == null)
                            imageData = InfoImagen;

                        oCEmpleados.IDEmp = Convert.ToInt32(TxtCodigo.Text.Trim());
                        oCEmpleados.Cedula = TxtCedula.Text.Trim();

                        if (RdNacional.Checked == true)
                            oCEmpleados.TipoCedula = "0";
                        else
                            oCEmpleados.TipoCedula = "1";

                        oCEmpleados.Nombre = TxtNomEmpl.Text.Trim();
                        oCEmpleados.FechaNacimiento = DtFecha_Naci.Value;
                        oCEmpleados.Sexo = CmbSexo.Text.Trim();
                        oCEmpleados.Direccion = TxtDireccion.Text.Trim();
                        oCEmpleados.EstadoCivil = CmbEstadoCivil.Text.Trim();

                        if (rdActivo.Checked == true)
                            oCEmpleados.Estado = "0";//True
                        else
                            oCEmpleados.Estado = "1";

                        oCEmpleados.CategoriaEmp = cmbCategoriasEmp.SelectedValue.ToString().Trim();
                        oCEmpleados.CodigoColegiado = txtCodigoColegiado.Text.Trim();

                        imageData = ReadFile(DireccImage.Trim());

                        if (imageData == null)
                        {
                            imageData = InfoImagen;
                            oCEmpleados.InfoImagen = imageData;
                        }
                        else
                            oCEmpleados.InfoImagen = imageData;

                        if (imageData != null)
                            oCEmpleados.Modificar();
                        else
                            oCEmpleados.Modificar_NoImage();

                        if (Program.oPersistencia.IsError == false)
                            tobCancelar_Click(sender, e);
                    }
                }
            }//fin modificar

            Grid1.Focus();
        }

        private void tobCancelar_Click(object sender, EventArgs e)
        {
            Metodos_Globales.LlenarGrid(Grid1, oCEmpleados.ConsultarSinParametros());
            ModoBloqueo();

            if (Grid1.Rows.Count == 0)
                toolStripStatusLabel1.Text = "Presione el botón \"Nuevo\" para ingresar un nuevo empleado";
            else
                toolStripStatusLabel1.Text = "Seleccione la fila deseada sobre la cual desea trabajar";

            try
            {
                File.Delete(Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles") + "\\tempPicture.jpg");
                File.Delete(Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles") + "\\tempPicture1.jpg");
            }
            catch { }

            Grid1.Focus();
        }

        private void tobIniConsulta_Click(object sender, EventArgs e)
        {
            ModoIniciarConsulta();
            LimpiaCampos();
            CmbSexo.SelectedIndex = -1;
            CmbEstadoCivil.SelectedIndex = -1;
            RdExtranjero.Checked = false;
            RdNacional.Checked = false;
            TxtCodigo.Enabled = true;
        }

        private void tobConsultar_Click(object sender, EventArgs e)
        {
            #region Establece valores en la clase de Empleados

            if (TxtCodigo.Text.Trim() != "")
                oCEmpleados.IDEmp = Convert.ToInt32(TxtCodigo.Text.Trim());
            else
                oCEmpleados.IDEmp = 0;

            if (TxtNomEmpl.Text.Trim() != "")
                oCEmpleados.Nombre = TxtNomEmpl.Text.Trim();
            else
                oCEmpleados.Nombre = null;

            if (RdExtranjero.Checked == true || RdNacional.Checked == true)
            {
                if (RdNacional.Checked == true)
                    oCEmpleados.TipoCedula = "0";
                else
                    oCEmpleados.TipoCedula = "1";
            }
            else
                oCEmpleados.TipoCedula = null;

            if (TxtCedula.Text.Trim() != "")
                oCEmpleados.Cedula = TxtCedula.Text.Trim();
            else
                oCEmpleados.Cedula = null;

            if (CmbSexo.SelectedIndex != -1)
                oCEmpleados.Sexo = CmbSexo.Text.Trim();
            else
                oCEmpleados.Sexo = null;

            if (CmbEstadoCivil.SelectedIndex != -1)
                oCEmpleados.EstadoCivil = CmbEstadoCivil.Text.Trim();
            else
                oCEmpleados.EstadoCivil = null;

            if (cmbCategoriasEmp.Text.Trim() != "")
                oCEmpleados.CategoriaEmp = cmbCategoriasEmp.Text.Trim();
            else
                oCEmpleados.CategoriaEmp = null;

            #endregion

            Metodos_Globales.LlenarGrid(Grid1, oCEmpleados.ConsultarConParametros(Filtrar(this)));
            Grid1.Enabled = true;
            ModoBloqueo();
            tobEjecutarConsulta.Enabled = false;
            tobIniciarConsulta.Enabled = true;
            tobCancelarConsulta.Enabled = true;
        }

        private void tobCancelConsulta_Click(object sender, EventArgs e)
        {
            tobCancelar_Click(sender, e);
        }

        private void tobSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;

            base.OnPaintBackground(e);
        }

        private void Llenar_Grid_Sin_Filtro()
        {
            // Declarar datatable
            DataTable datatable;

            // Declarar Datareader
            SqlDataReader dr = null;

            // formar el SQL
            StringBuilder sql = new StringBuilder("");
            sql.Append("select * from Empleados order by id_emp");

            // llenar el dataReader con la persistencia
            dr = Program.oPersistencia.ejecutarConsultaSQL(sql.ToString());

            //Si ocurrio un errro hacer la excepción
            if (!Program.oPersistencia.IsError)
            {
                // crear una nueva instancia del DataTable
                datatable = new DataTable();

                // llena el dataTable con la info del Datareader
                datatable.Load(dr, LoadOption.Upsert);

                // Llena los campos del Grid con el datatable
                Grid1.DataSource = datatable;

                //Cerrar el DataReader
                dr.Close();
            }
            else
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            //Cerrar el DataReader
            dr = null;
        }

        private void Llenar_Grid()
        {
            Grid1.SuspendLayout();
            // Declarar datatable
            DataTable datatable;

            // Declarar Datareader
            SqlDataReader dr = null;

            // formar el SQL
            StringBuilder sql = new StringBuilder("");
            sql.Append("select * from Empleados");
            //id_emp,cedula,nombre,tel_emp,cel_emp,direc_emp,sexo_emp,fec_nacimiento,edad,estado_civil,fec_ingreso,precio_hora,id_estado from Empleados");
            // si se está filtrando
            if (Modificar == true)
                sql.Append(" where id_emp = " + Grid1.CurrentRow.Cells["Id_Emp"].Value.ToString().Trim());
            if (Consultar == true)
                sql.Append(this.Filtrar(this));

            // llenar el dataReader con la persistencia
            if (this.Filtrar(this).Length == 0)
                dr = Program.oPersistencia.ejecutarConsultaSQL("execute sp_S_Empleado");
            else
                dr = Program.oPersistencia.ejecutarConsultaSQL(sql.ToString());

            //Si ocurrio un errro hacer la excepción
            if (!Program.oPersistencia.IsError)
            {
                // crear una nueva instancia del DataTable
                datatable = new DataTable();

                // llena el dataTable con la info del Datareader
                datatable.Load(dr, LoadOption.Upsert);

                // Llena los campos del Grid con el datatable
                Grid1.DataSource = datatable;

                //Cerrar el DataReader
                dr.Close();
            }
            else
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            //Cerrar el DataReader
            dr = null;

            Grid1.ResumeLayout();
        }

        public string Filtrar(System.Windows.Forms.Form oFormulario)
        {
            String sqlWhere = "";

            foreach (System.Windows.Forms.Control oTextBox in oFormulario.Controls)
            {
                if (oTextBox is TextBox)
                {
                    //Validar que el Tag no este nulo y que el TextBox tenga algun valor para forma la condicion
                    // Ojo solo hace filtros pensado en que los datos son caracter
                    if ((((TextBox)(oTextBox)).Tag.ToString().Trim() != "") && ((((TextBox)(oTextBox)).Text.ToString().Trim() != "")))
                    {
                        if (String.IsNullOrEmpty(sqlWhere))
                        {
                            sqlWhere += ((TextBox)oTextBox).Tag.ToString().Trim() + ",";//" Where " + ((TextBox)oTextBox).Tag + " like '%" + ((TextBox)oTextBox).Text.Trim() + "%'";
                        }
                        else
                        {
                            sqlWhere += ((TextBox)oTextBox).Tag.ToString().Trim() + ",";//" and " + ((TextBox)oTextBox).Tag + " like '%" + ((TextBox)oTextBox).Text.Trim() + "%'";
                        }//if
                    }//if
                }//if
                else if (oTextBox is ComboBox)
                {
                    if ((((ComboBox)(oTextBox)).Tag.ToString().Trim() != "") && ((((ComboBox)(oTextBox)).Text.ToString().Trim() != "")))
                    {
                        if (String.IsNullOrEmpty(sqlWhere))
                        {
                            sqlWhere += ((ComboBox)oTextBox).Tag.ToString().Trim() + ",";//" Where " + ((ComboBox)oTextBox).Tag// + " like '%" + ((ComboBox)oTextBox).Text.Trim() + "%'";
                        }
                        else
                        {
                            sqlWhere += ((ComboBox)oTextBox).Tag.ToString().Trim() + ",";//" and " + ((ComboBox)oTextBox).Tag + " like '%" + ((ComboBox)oTextBox).Text.Trim() + "%'";
                        }//if
                    }//if
                }
                else if (oTextBox is RadioButton)
                {
                    if (((RadioButton)(oTextBox)).Checked == true)
                    {
                        if (String.IsNullOrEmpty(sqlWhere))
                        {
                            sqlWhere += ((RadioButton)oTextBox).Tag.ToString().Trim() + ",";//" Where " + ((ComboBox)oTextBox).Tag// + " like '%" + ((ComboBox)oTextBox).Text.Trim() + "%'";
                        }
                        else
                        {
                            sqlWhere += ((RadioButton)oTextBox).Tag.ToString().Trim() + ",";//" and " + ((ComboBox)oTextBox).Tag + " like '%" + ((ComboBox)oTextBox).Text.Trim() + "%'";
                        }//if
                    }
                }
                //else if (oTextBox is DateTimePicker)
                //{
                //    if ((((DateTimePicker)(oTextBox)).Tag.ToString().Trim() != "") && (((DateTimePicker)(oTextBox)).Tag.ToString().Trim() != "") )
                //}
            }

            if (sqlWhere.Trim().CompareTo("Where") == 0)
            {
                sqlWhere = "";
            }

            if (sqlWhere.EndsWith(","))
                sqlWhere = sqlWhere.Substring(0, sqlWhere.Length - 1);

            return sqlWhere;
        }//FormarCondicion

        private void LlenaComboContactos()
        {
            cmbContactos.BeginUpdate();
            cmbContactos.DataSource = null;
            Metodos_Globales.LlenarCombo(cmbContactos, "Sp_S_Tipo_Contacto", "Tipo_Contactos", "id_tipo_contacto", "descripcion");
            cmbContactos.EndUpdate();
        }

        private void LlenaComboCategoriasEmpleado()
        {
            cmbCategoriasEmp.DataSource = null;
            Metodos_Globales.LlenarCombo(cmbCategoriasEmp, "Sp_S_Categoria_Empleado", "Categorias_Empleado", "id_categoria_emp", "descripcion");
        }

        private void CargaAutoComplete()
        {
            //oAutoComplete.Clear();

            //DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select categoria_emp from Empleados", "Empleados");

            //foreach (DataRow dr in ds.Tables[0].Rows)
            //    oAutoComplete.Add(dr[0].ToString().Trim());

            //ds.Dispose();

            //cmbCategoriasEmp.AutoCompleteCustomSource = oAutoComplete;
        }

        private void FrmMantEmpleados_Load(object sender, EventArgs e)
        {
            LlenaComboContactos();
            LlenaComboCategoriasEmpleado();

            Metodos_Globales.LlenarGrid(Grid1, "sp_S_Empleados");

            HabilitaOpcionesContactos();
            //CargaAutoComplete();

            if (Grid1.RowCount > 0)
                tobModificar.Enabled = true;

            LimpiaCampos();

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);

            this.pictureBox1.Region = Shape.RoundedRegion(pictureBox1.Size, 3, Shape.Corner.None);
        }

        private void VerificaCampo()
        {
            Verifica = 0;
            negativo = 0;//Variable creada para evaluar si el valor de la edad es negativo...
            int X = 0;

            if (TxtNomEmpl.Text.Trim().Trim() == "")
            {
                Verifica = 1;
                MessageBox.Show(this, "No hay ningun valor en Nombre, Ingrese algun valor para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtNomEmpl.Focus();
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

            if (CmbEstado.Text.Trim() == "")
            {
                Verifica = 1;
                MessageBox.Show(this, "No hay ningun valor seleccionado en Estado, seleccione algun valor para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CmbEstado.Focus();
            }

            if (cmbCategoriasEmp.Text.Trim() == "")
            {
                Verifica = 1;
                MessageBox.Show(this, "No hay ningun valor en la categoría del empleado, ingrese algun valor para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbCategoriasEmp.Focus();
            }
        }

        private void Verifica_Datos_Seleccionados()
        {
            Verifica2 = 0;

            if (TxtCodigo.Text == "")
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
            pictureBox1.Image = null;
            DireccImage = "";
            InfoImagen = null;
        }

        private void LlenaListaContactos_Empleado()
        {
            DataTable oDataTable = Metodos_Globales.Consulta(oCContactosEmpleados.Consultar());

            int i = 0;
            lstContactos.Items.Clear();

            if (oDataTable != null)
            {
                lstContactos.BeginUpdate();
                foreach (DataRow dr in oDataTable.Rows)
                {
                    lstContactos.Items.Add(dr[1].ToString().Trim());
                    lstContactos.Items[i].SubItems.Add(dr[2].ToString());
                    lstContactos.Items[i].SubItems.Add(dr[0].ToString());

                    i++;
                }
                oDataTable.Dispose();
                lstContactos.EndUpdate();
            }
        }

        private void Grid1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Image newImage = null;

            //try
            //{
            //    if (Grid1.CurrentRow != null)
            //    {
            //        TxtCodigo.Text = Grid1.Rows[e.RowIndex].Cells["Id_Emp"].Value.ToString();

            //        oCContactosEmpleados.IdEmpleado = TxtCodigo.Text.Trim();
            //        LlenaListaContactos_Empleado();

            //        TxtNomEmpl.Text = Grid1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            //        if (Grid1.Rows[e.RowIndex].Cells["TipoCed"].Value.ToString() == "0")
            //        {
            //            RdNacional.Checked = true;
            //            TxtCedula.Text = Grid1.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
            //        }
            //        else
            //        {
            //            RdExtranjero.Checked = true;
            //            TxtCedula.Text = Grid1.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
            //        }
            //        CmbSexo.Text = Grid1.Rows[e.RowIndex].Cells["Sexo"].Value.ToString();
            //        DtFecha_Naci.Text = Grid1.Rows[e.RowIndex].Cells["FecNac"].Value.ToString();
            //        CmbEstadoCivil.Text = Grid1.Rows[e.RowIndex].Cells["EstadoCivil"].Value.ToString();
            //        TxtDireccion.Text = Grid1.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();

            //        if (Grid1.Rows[e.RowIndex].Cells["Estado"].Value.ToString() == "0")
            //            CmbEstado.SelectedIndex = 0;                    
            //        else
            //            CmbEstado.SelectedIndex = 1;

            //        cmbCategoriasEmp.Text = Grid1.Rows[e.RowIndex].Cells["CategoriaEmp"].Value.ToString();

            //        //Get image data from gridview column.
            //        byte[] imageData = (byte[])Grid1.Rows[e.RowIndex].Cells["Imagen"].Value;

            //        InfoImagen = imageData;
            //        //Initialize image variable

            //        //Read image data into a memory stream
            //        using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
            //        {
            //            ms.Write(imageData, 0, imageData.Length);

            //            //Set image variable value using memory stream.
            //            newImage = Image.FromStream(ms, true);
            //        }

            //        //set picture
            //        if (newImage != null)
            //        {
            //            ImagenDisponible = true;
            //            pictureBox1.BackgroundImage = newImage;
            //            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (newImage == null)
            //    {
            //        ImagenDisponible = false;
            //        pictureBox1.BackgroundImage = Resources.Person_Red;
            //        pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            //        InfoImagen = null;//Verificar
            //    }
            //}
        }

        private void FrmMantEmpleados_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (Program.oUsuario.Trim().ToLower() != "admin" && Program.coClaveUsuario.Trim().ToLower() != "admin_punto_venta_adminlogin_1029384756" && Seguridad.Id_Emp.Trim() != "")
            //{
            //    //////////////Verifica el estado del empleado para no permitirle estar en el sistema si su estado es inactivo///////////////////
            //    StringBuilder Sql = new StringBuilder("");
            //    Sql.Remove(0, Sql.Length);
            //    Sql.Append("Select id_usuario from Usuario_Empleado where id_emp = " + Seguridad.Id_Emp.Trim());

            //    DataSet ds = Program.oPersistencia.ejecutarSQLListas(Sql.ToString(), "Usuario_Empleado");

            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {
            //        if (new Seguridad().VerificarEstadoUsuario(dr[0].ToString().Trim()) == false)
            //        {
            //            MessageBox.Show(this, "Deberá iniciar sesión nuevamente con un usuario válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            this.Visible = false;

            //            Program.oPersistencia.conexion.Dispose();
            //            Program.oPersistencia.conexion.Close();
            //            Persistencia oPersistencia = new Persistencia("", "", "");

            //            Program.oMDI.MDIPrincipal_Load(sender, e);
            //            break;
            //        }
            //    }
            //    ds.Dispose();
            //}

        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmTopics oFrmTopics = new FrmTopics("groupEmpleados");//ASí se llama el groupbox en FrmTopics que contiene los índices de búsqueda de la ayuda de esta pantalla
            //oFrmTopics.ShowDialog();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            ayudaToolStripMenuItem_Click(sender, e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            tobSalir_Click(sender, e);
        }

        private void RdNacional_CheckedChanged(object sender, EventArgs e)
        {

        }

        #region Métodos relacionados con el manejo de Contactos

        private void HabilitaOpcionesContactos()
        {
            if (Grid1.RowCount > 0)
            {
                tobNuevoContacto.Enabled = true;
                tobModificarContacto.Enabled = true;
                tobEliminarContacto.Enabled = true;
                tobGuardarContacto.Enabled = false;
                tobCancelarContacto.Enabled = false;
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

            oCContactosEmpleados.IdEmpleado = "";
            oCContactosEmpleados.IdTipoContacto = 0;
            oCContactosEmpleados.Descripcion = "";

            if (Nuevo == true)
            {
                object sender = new object();
                EventArgs e = new EventArgs();

                if (MessageBox.Show(this, "¿Desea ingresar otro contacto para este empleado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    nuevoContacto = true;
                    DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, Grid1.Rows.GetLastRow(DataGridViewElementStates.None));
                    Grid1_CellEnter(sender, e2);
                    tobNuevoContacto_Click(sender, e);
                }
                else
                {
                    tobCancelar_Click(sender, e);
                    HabilitaOpcionesContactos();
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
                    oCContactosEmpleados.IdEmpleado = TxtCodigo.Text.Trim();
                    oCContactosEmpleados.IdTipoContacto = Convert.ToInt32(cmbContactos.SelectedValue);
                    oCContactosEmpleados.Descripcion = txtDescripcionContactos.Text.Trim();

                    oCContactosEmpleados.Insertar();

                    if (Program.oPersistencia.IsError == false)
                    {
                        tobCancelarContacto_Click(sender, e);

                        if (Nuevo == false)
                            Grid1_CellEnter(sender, e2);
                    }
                }
            }
            else if (modificarContacto == true)
            {
                if (lstContactos.SelectedItems.Count > 0)
                {
                    if (cmbContactos.SelectedIndex != -1)
                    {
                        oCContactosEmpleados.IdEmpleado = TxtCodigo.Text.Trim();
                        oCContactosEmpleados.IdTipoContacto = Convert.ToInt32(lstContactos.SelectedItems[0].SubItems[2].Text);
                        oCContactosEmpleados.AuxIdTIpoContacto = cmbContactos.SelectedValue.ToString().Trim();
                        oCContactosEmpleados.Descripcion = lstContactos.SelectedItems[0].SubItems[1].Text.Trim();
                        oCContactosEmpleados.AuxDescripcion = txtDescripcionContactos.Text.Trim();

                        oCContactosEmpleados.Modificar();

                        if (Program.oPersistencia.IsError == false)
                        {
                            tobCancelarContacto_Click(sender, e);
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
                oCContactosEmpleados.IdEmpleado = TxtCodigo.Text.Trim();
                oCContactosEmpleados.IdTipoContacto = Convert.ToInt32(lstContactos.SelectedItems[0].SubItems[2].Text.Trim());
                oCContactosEmpleados.Descripcion = lstContactos.SelectedItems[0].SubItems[1].Text.Trim();

                oCContactosEmpleados.Eliminar();

                if (Program.oPersistencia.IsError == false)
                {
                    tobCancelarContacto_Click(sender, e);
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

        private void Grid1_Enter(object sender, EventArgs e)
        {
            if (Grid1.Rows.Count > 0)
            {
                Grid1.Rows[Grid1.Rows.GetFirstRow(DataGridViewElementStates.None)].Selected = true;
                DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, Grid1.Rows.GetFirstRow(DataGridViewElementStates.None));
                Grid1_CellEnter(sender, e2);
                Grid1.FirstDisplayedScrollingRowIndex = Grid1.Rows.GetFirstRow(DataGridViewElementStates.None);
            }
        }

        private void btnDetalleContactos_Click(object sender, EventArgs e)
        {
            frmMantenimientosBasicos ofrmMantenimientosBasicos = new frmMantenimientosBasicos();
            ofrmMantenimientosBasicos.ShowDialog();
            LlenaComboContactos();
        }

        private void Grid1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Image newImage = null;

            try
            {
                if (Grid1.CurrentRow != null)
                {
                    TxtCodigo.Text = Grid1.Rows[e.RowIndex].Cells["Id_Emp"].Value.ToString();

                    oCContactosEmpleados.IdEmpleado = TxtCodigo.Text.Trim();
                    LlenaListaContactos_Empleado();

                    TxtNomEmpl.Text = Grid1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                    if (Grid1.Rows[e.RowIndex].Cells["TipoCed"].Value.ToString() == "0")
                    {
                        RdNacional.Checked = true;
                        TxtCedula.Text = Grid1.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
                    }
                    else
                    {
                        RdExtranjero.Checked = true;
                        TxtCedula.Text = Grid1.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
                    }

                    CmbSexo.Text = Grid1.Rows[e.RowIndex].Cells["Sexo"].Value.ToString();
                    DtFecha_Naci.Text = Grid1.Rows[e.RowIndex].Cells["FecNac"].Value.ToString();
                    CmbEstadoCivil.Text = Grid1.Rows[e.RowIndex].Cells["EstadoCivil"].Value.ToString();
                    TxtDireccion.Text = Grid1.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();

                    if (Convert.ToBoolean(Grid1.Rows[e.RowIndex].Cells["Estado"].Value) == false)
                        rdActivo.Checked = true;
                    else
                        rdInactivo.Checked = true;

                    cmbCategoriasEmp.SelectedValue = Grid1.Rows[e.RowIndex].Cells["CategoriaEmp"].Value.ToString();

                    txtCodigoColegiado.Text = Grid1.Rows[e.RowIndex].Cells["Codigo_Colegiado"].Value.ToString();

                    //Get image data from gridview column.
                    byte[] imageData = (byte[])Grid1.Rows[e.RowIndex].Cells["Imagen"].Value;

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

        private void imagenCambiantePictureBox1_Click(object sender, EventArgs e)
        {
            tobSalir_Click(sender, e);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            moverForm();
        }

        private void GuardarNuevaCategoriaEmpleado()
        {
            oCCategoriasEmpleado.Descripcion = cmbCategoriasEmp.Text.Trim();

            oCCategoriasEmpleado.Insertar();
            LlenaComboCategoriasEmpleado();
            cmbCategoriasEmp.SelectedIndex = cmbCategoriasEmp.Items.Count - 1;

            if (Program.oPersistencia.IsError == false)
                MessageBox.Show(this, "La categoría \"" + cmbCategoriasEmp.Text.Trim() + " \" fue almacenada correctamente en la base de datos del sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tobGuardarCategoria_Click(object sender, EventArgs e)
        {
            if (cmbCategoriasEmp.Text.Trim() != "")
            {
                if (oCCategoriasEmpleado.DeterminaCategoriaRepetida(cmbCategoriasEmp.Text.Trim()) == false)
                    GuardarNuevaCategoriaEmpleado();
                else
                    MessageBox.Show(this, "La categoría ingresada ya existe entre la lista disponible, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TxtCodigo_Enter(object sender, EventArgs e)
        {

        }

        private void cmbCategoriasEmp_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Nuevo == true || Modificar == true)
            {
                if (cmbCategoriasEmp.Text.Trim() == "Médico")
                    txtCodigoColegiado.Enabled = true;
                else
                    txtCodigoColegiado.Enabled = false;
            }
        }

        private void txtCodigoColegiado_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese el código de Colegiado del empleado (solo médicos)";
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
            }
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
                catch 
                {
                }

                //this.pictureBox1.BackgroundImage = cropImage(this.pictureBox1.BackgroundImage, pictureBox1.ClientRectangle);
                this.pictureBox1.Image.Save(path);
                DireccImage = path;

                tobCameraOn.Enabled = true;
                tobCameraOff.Enabled = false;
                tobSnapshot.Enabled = false;

                this.WebCamCapture.Stop();                
            }
            catch { }
        }

        private void WebCamCapture_ImageCaptured(object source, WebCam_Capture.WebcamEventArgs e)
        {
            this.pictureBox1.Image = e.WebCamImage;
        }

        private void FrmMantEmpleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WebCamCapture.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

    }
}