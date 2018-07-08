namespace G_Clinic
{
    partial class FrmMantEmpleados
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMantEmpleados));
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbSexo = new System.Windows.Forms.ComboBox();
            this.CmbEstadoCivil = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DtFecha_Naci = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtEdad = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNomEmpl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Id_Emp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FecNac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoCivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.Codigo_Colegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NuevotoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.iniciarConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarConsultaF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TxtCedula = new System.Windows.Forms.TextBox();
            this.RdNacional = new System.Windows.Forms.RadioButton();
            this.RdExtranjero = new System.Windows.Forms.RadioButton();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.lstContactos = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tobNuevoContacto = new System.Windows.Forms.ToolStripButton();
            this.tobModificarContacto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tobGuardarContacto = new System.Windows.Forms.ToolStripButton();
            this.tobCancelarContacto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tobEliminarContacto = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.label12 = new System.Windows.Forms.Label();
            this.panelContactos = new System.Windows.Forms.Panel();
            this.cmbContactos = new System.Windows.Forms.ComboBox();
            this.txtDescripcionContactos = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbCategoriasEmp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdActivo = new System.Windows.Forms.RadioButton();
            this.rdInactivo = new System.Windows.Forms.RadioButton();
            this.txtCodigoColegiado = new AMS.TextBox.NumericTextBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.tobGuardarCategoria = new System.Windows.Forms.ToolStripButton();
            this.label14 = new System.Windows.Forms.Label();
            this.WebCamCapture = new WebCam_Capture.WebCamCapture();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tobNuevo = new System.Windows.Forms.ToolStripButton();
            this.tobModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tobGuardar = new System.Windows.Forms.ToolStripButton();
            this.tobCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tobIniciarConsulta = new System.Windows.Forms.ToolStripButton();
            this.tobEjecutarConsulta = new System.Windows.Forms.ToolStripButton();
            this.tobCancelarConsulta = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tobSalir = new System.Windows.Forms.ToolStripButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.tobCameraOn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tobSnapshot = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tobCameraOff = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnFoto = new System.Windows.Forms.ToolStripButton();
            this.BtnRemover = new System.Windows.Forms.ToolStripButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.imagenCambiantePictureBox1 = new G_Clinic.ImagenCambiantePictureBox();
            this.btnMinimize = new G_Clinic.ImagenCambiantePictureBox();
            this.btnDetalleContactos = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnSalir = new G_Clinic.ImagenCambiantePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.panelContactos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel4.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.BackColor = System.Drawing.Color.White;
            this.TxtCodigo.Enabled = false;
            this.TxtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigo.ForeColor = System.Drawing.Color.Red;
            this.TxtCodigo.Location = new System.Drawing.Point(146, 90);
            this.TxtCodigo.MaxLength = 9;
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(74, 34);
            this.TxtCodigo.TabIndex = 0;
            this.TxtCodigo.Tag = "id_emp";
            this.TxtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtCodigo.Enter += new System.EventHandler(this.TxtCodigo_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 84;
            this.label1.Text = "Id de Empleado";
            // 
            // CmbSexo
            // 
            this.CmbSexo.Enabled = false;
            this.CmbSexo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSexo.FormattingEnabled = true;
            this.CmbSexo.Items.AddRange(new object[] {
            "Femenino",
            "Masculino",
            "Otro"});
            this.CmbSexo.Location = new System.Drawing.Point(146, 255);
            this.CmbSexo.Name = "CmbSexo";
            this.CmbSexo.Size = new System.Drawing.Size(133, 23);
            this.CmbSexo.TabIndex = 5;
            this.CmbSexo.Tag = "sexo_emp";
            this.CmbSexo.Text = "Femenino";
            this.CmbSexo.Enter += new System.EventHandler(this.CmbSexo_Enter);
            this.CmbSexo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbSexo_KeyPress);
            // 
            // CmbEstadoCivil
            // 
            this.CmbEstadoCivil.Enabled = false;
            this.CmbEstadoCivil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstadoCivil.FormattingEnabled = true;
            this.CmbEstadoCivil.Items.AddRange(new object[] {
            "Casado",
            "Soltero"});
            this.CmbEstadoCivil.Location = new System.Drawing.Point(396, 255);
            this.CmbEstadoCivil.Name = "CmbEstadoCivil";
            this.CmbEstadoCivil.Size = new System.Drawing.Size(153, 23);
            this.CmbEstadoCivil.TabIndex = 6;
            this.CmbEstadoCivil.Tag = "estado_civil";
            this.CmbEstadoCivil.Text = "Casado";
            this.CmbEstadoCivil.Enter += new System.EventHandler(this.CmbEstadoCivil_Enter);
            this.CmbEstadoCivil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbEstadoCivil_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(324, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 15);
            this.label10.TabIndex = 74;
            this.label10.Text = "Estado Civil";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(18, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 15);
            this.label7.TabIndex = 72;
            this.label7.Text = "Fecha de Nacimiento";
            // 
            // DtFecha_Naci
            // 
            this.DtFecha_Naci.CustomFormat = "dddd\', \'dd MMMM  yyyy";
            this.DtFecha_Naci.Enabled = false;
            this.DtFecha_Naci.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFecha_Naci.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecha_Naci.Location = new System.Drawing.Point(146, 223);
            this.DtFecha_Naci.Name = "DtFecha_Naci";
            this.DtFecha_Naci.Size = new System.Drawing.Size(207, 23);
            this.DtFecha_Naci.TabIndex = 4;
            this.DtFecha_Naci.Tag = "fec_nacimiento";
            this.DtFecha_Naci.Value = new System.DateTime(2010, 11, 24, 0, 0, 0, 0);
            this.DtFecha_Naci.ValueChanged += new System.EventHandler(this.DtFecha_Naci_ValueChanged);
            this.DtFecha_Naci.Enter += new System.EventHandler(this.DtFecha_Naci_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(360, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 73;
            this.label8.Text = "Edad";
            // 
            // TxtEdad
            // 
            this.TxtEdad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.TxtEdad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtEdad.Enabled = false;
            this.TxtEdad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEdad.ForeColor = System.Drawing.Color.DarkOrange;
            this.TxtEdad.Location = new System.Drawing.Point(386, 223);
            this.TxtEdad.MaxLength = 3;
            this.TxtEdad.Multiline = true;
            this.TxtEdad.Name = "TxtEdad";
            this.TxtEdad.ReadOnly = true;
            this.TxtEdad.Size = new System.Drawing.Size(36, 17);
            this.TxtEdad.TabIndex = 20;
            this.TxtEdad.Tag = "edad";
            this.TxtEdad.Text = "0";
            this.TxtEdad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtEdad.Enter += new System.EventHandler(this.TxtEdad_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(18, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 15);
            this.label11.TabIndex = 75;
            this.label11.Text = "Sexo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 43;
            this.label2.Text = "Nombre";
            // 
            // TxtNomEmpl
            // 
            this.TxtNomEmpl.BackColor = System.Drawing.Color.White;
            this.TxtNomEmpl.Enabled = false;
            this.TxtNomEmpl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNomEmpl.Location = new System.Drawing.Point(146, 131);
            this.TxtNomEmpl.MaxLength = 65;
            this.TxtNomEmpl.Name = "TxtNomEmpl";
            this.TxtNomEmpl.Size = new System.Drawing.Size(286, 23);
            this.TxtNomEmpl.TabIndex = 1;
            this.TxtNomEmpl.Tag = "nombre";
            this.TxtNomEmpl.Enter += new System.EventHandler(this.TxtNomEmpl_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(18, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 44;
            this.label3.Text = "Cédula";
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.BackColor = System.Drawing.Color.White;
            this.TxtDireccion.Enabled = false;
            this.TxtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDireccion.Location = new System.Drawing.Point(146, 287);
            this.TxtDireccion.MaxLength = 150;
            this.TxtDireccion.Multiline = true;
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(294, 59);
            this.TxtDireccion.TabIndex = 7;
            this.TxtDireccion.Tag = "direc_emp";
            this.TxtDireccion.Enter += new System.EventHandler(this.TxtDireccion_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(18, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 15);
            this.label6.TabIndex = 47;
            this.label6.Text = "Direccion Residencial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 69;
            this.label5.Text = "Categoría";
            // 
            // CmbEstado
            // 
            this.CmbEstado.Enabled = false;
            this.CmbEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.CmbEstado.Location = new System.Drawing.Point(146, 412);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(121, 23);
            this.CmbEstado.TabIndex = 1;
            this.CmbEstado.Text = "Activo";
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.Grid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(126)))), ((int)(((byte)(106)))));
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Emp,
            this.Nombre,
            this.Cedula,
            this.TipoCed,
            this.FecNac,
            this.Sexo,
            this.Direccion,
            this.EstadoCivil,
            this.CategoriaEmp,
            this.Estado,
            this.Imagen,
            this.Codigo_Colegiado});
            this.Grid1.Location = new System.Drawing.Point(21, 388);
            this.Grid1.MultiSelect = false;
            this.Grid1.Name = "Grid1";
            this.Grid1.ReadOnly = true;
            this.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid1.Size = new System.Drawing.Size(979, 204);
            this.Grid1.TabIndex = 13;
            this.Grid1.Enter += new System.EventHandler(this.Grid1_Enter);
            this.Grid1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_RowEnter);
            this.Grid1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellEnter);
            // 
            // Id_Emp
            // 
            this.Id_Emp.DataPropertyName = "id_emp";
            this.Id_Emp.HeaderText = "Id Empleado";
            this.Id_Emp.Name = "Id_Emp";
            this.Id_Emp.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 200;
            // 
            // Cedula
            // 
            this.Cedula.DataPropertyName = "cedula";
            this.Cedula.HeaderText = "Cedula";
            this.Cedula.Name = "Cedula";
            this.Cedula.ReadOnly = true;
            this.Cedula.Width = 150;
            // 
            // TipoCed
            // 
            this.TipoCed.DataPropertyName = "tipo_ced";
            this.TipoCed.HeaderText = "Column14";
            this.TipoCed.Name = "TipoCed";
            this.TipoCed.ReadOnly = true;
            this.TipoCed.Visible = false;
            // 
            // FecNac
            // 
            this.FecNac.DataPropertyName = "fec_nacimiento";
            this.FecNac.HeaderText = "Fecha de Nacimiento";
            this.FecNac.Name = "FecNac";
            this.FecNac.ReadOnly = true;
            this.FecNac.Width = 200;
            // 
            // Sexo
            // 
            this.Sexo.DataPropertyName = "sexo_emp";
            this.Sexo.HeaderText = "Sexo";
            this.Sexo.Name = "Sexo";
            this.Sexo.ReadOnly = true;
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "direc_emp";
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 200;
            // 
            // EstadoCivil
            // 
            this.EstadoCivil.DataPropertyName = "estado_civil";
            this.EstadoCivil.HeaderText = "Estado Civil";
            this.EstadoCivil.Name = "EstadoCivil";
            this.EstadoCivil.ReadOnly = true;
            this.EstadoCivil.Width = 150;
            // 
            // CategoriaEmp
            // 
            this.CategoriaEmp.DataPropertyName = "id_categoria_emp";
            this.CategoriaEmp.HeaderText = "Categoría";
            this.CategoriaEmp.Name = "CategoriaEmp";
            this.CategoriaEmp.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // Imagen
            // 
            this.Imagen.DataPropertyName = "foto";
            this.Imagen.HeaderText = "Imagen";
            this.Imagen.Name = "Imagen";
            this.Imagen.ReadOnly = true;
            this.Imagen.Visible = false;
            // 
            // Codigo_Colegiado
            // 
            this.Codigo_Colegiado.DataPropertyName = "codigo_colegiado";
            this.Codigo_Colegiado.HeaderText = "Código";
            this.Codigo_Colegiado.Name = "Codigo_Colegiado";
            this.Codigo_Colegiado.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1022, 24);
            this.menuStrip1.TabIndex = 101;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevotoolStripMenuItem1,
            this.modificarToolStripMenuItem,
            this.toolStripSeparator2,
            this.guardarToolStripMenuItem,
            this.cancelarToolStripMenuItem,
            this.toolStripSeparator3,
            this.iniciarConsultaToolStripMenuItem,
            this.ejecutarConsultaToolStripMenuItem,
            this.cancelarConsultaF8ToolStripMenuItem,
            this.toolStripSeparator5,
            this.salirToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.nuevoToolStripMenuItem.Text = "Archivo";
            // 
            // NuevotoolStripMenuItem1
            // 
            this.NuevotoolStripMenuItem1.Name = "NuevotoolStripMenuItem1";
            this.NuevotoolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NuevotoolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
            this.NuevotoolStripMenuItem1.Text = "Nuevo";
            this.NuevotoolStripMenuItem1.Click += new System.EventHandler(this.tobNuevo_Click_1);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.tobModificar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.tobGuardar_Click);
            // 
            // cancelarToolStripMenuItem
            // 
            this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
            this.cancelarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.cancelarToolStripMenuItem.Text = "Cancelar";
            this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.tobCancelar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
            // 
            // iniciarConsultaToolStripMenuItem
            // 
            this.iniciarConsultaToolStripMenuItem.Name = "iniciarConsultaToolStripMenuItem";
            this.iniciarConsultaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.iniciarConsultaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.iniciarConsultaToolStripMenuItem.Text = "Iniciar Consulta";
            this.iniciarConsultaToolStripMenuItem.Click += new System.EventHandler(this.tobIniConsulta_Click);
            // 
            // ejecutarConsultaToolStripMenuItem
            // 
            this.ejecutarConsultaToolStripMenuItem.Name = "ejecutarConsultaToolStripMenuItem";
            this.ejecutarConsultaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.ejecutarConsultaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ejecutarConsultaToolStripMenuItem.Text = "Ejecutar Consulta ";
            this.ejecutarConsultaToolStripMenuItem.Click += new System.EventHandler(this.tobConsultar_Click);
            // 
            // cancelarConsultaF8ToolStripMenuItem
            // 
            this.cancelarConsultaF8ToolStripMenuItem.Name = "cancelarConsultaF8ToolStripMenuItem";
            this.cancelarConsultaF8ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.cancelarConsultaF8ToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.cancelarConsultaF8ToolStripMenuItem.Text = "Cancelar Consulta ";
            this.cancelarConsultaF8ToolStripMenuItem.Click += new System.EventHandler(this.tobCancelConsulta_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(189, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.tobSalir_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::G_Clinic.recursos.xmag_51;
            this.pictureBox2.Location = new System.Drawing.Point(152, 200);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 51);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 119;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "Ampliar Tamaño de Imagen");
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            // 
            // TxtCedula
            // 
            this.TxtCedula.BackColor = System.Drawing.Color.White;
            this.TxtCedula.Enabled = false;
            this.TxtCedula.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCedula.Location = new System.Drawing.Point(146, 191);
            this.TxtCedula.MaxLength = 15;
            this.TxtCedula.Name = "TxtCedula";
            this.TxtCedula.Size = new System.Drawing.Size(248, 23);
            this.TxtCedula.TabIndex = 3;
            this.TxtCedula.Tag = "cedula";
            this.TxtCedula.Text = "1-1204-0667-2344";
            this.TxtCedula.Enter += new System.EventHandler(this.TxtCedula_Enter);
            // 
            // RdNacional
            // 
            this.RdNacional.AutoSize = true;
            this.RdNacional.BackColor = System.Drawing.Color.Transparent;
            this.RdNacional.Checked = true;
            this.RdNacional.Enabled = false;
            this.RdNacional.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdNacional.ForeColor = System.Drawing.Color.White;
            this.RdNacional.Location = new System.Drawing.Point(146, 163);
            this.RdNacional.Name = "RdNacional";
            this.RdNacional.Size = new System.Drawing.Size(72, 19);
            this.RdNacional.TabIndex = 2;
            this.RdNacional.TabStop = true;
            this.RdNacional.Tag = "tipo_ced";
            this.RdNacional.Text = "Nacional";
            this.RdNacional.UseVisualStyleBackColor = false;
            // 
            // RdExtranjero
            // 
            this.RdExtranjero.AutoSize = true;
            this.RdExtranjero.BackColor = System.Drawing.Color.Transparent;
            this.RdExtranjero.Enabled = false;
            this.RdExtranjero.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdExtranjero.ForeColor = System.Drawing.Color.White;
            this.RdExtranjero.Location = new System.Drawing.Point(240, 164);
            this.RdExtranjero.Name = "RdExtranjero";
            this.RdExtranjero.Size = new System.Drawing.Size(82, 19);
            this.RdExtranjero.TabIndex = 19;
            this.RdExtranjero.Tag = "tipo_ced";
            this.RdExtranjero.Text = "Extranjera";
            this.RdExtranjero.UseVisualStyleBackColor = false;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // lstContactos
            // 
            this.lstContactos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.lstContactos.BackgroundImageTiled = true;
            this.lstContactos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstContactos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstContactos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstContactos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstContactos.ForeColor = System.Drawing.Color.White;
            this.lstContactos.FullRowSelect = true;
            this.lstContactos.Location = new System.Drawing.Point(0, 0);
            this.lstContactos.Name = "lstContactos";
            this.lstContactos.Size = new System.Drawing.Size(220, 207);
            this.lstContactos.TabIndex = 11;
            this.lstContactos.UseCompatibleStateImageBehavior = false;
            this.lstContactos.View = System.Windows.Forms.View.Details;
            this.lstContactos.SelectedIndexChanged += new System.EventHandler(this.lstContactos_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tipo Contacto";
            this.columnHeader1.Width = 89;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Detalle";
            this.columnHeader2.Width = 131;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "id_Tipo_Contacto";
            this.columnHeader3.Width = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobNuevoContacto,
            this.tobModificarContacto,
            this.toolStripSeparator6,
            this.tobGuardarContacto,
            this.tobCancelarContacto,
            this.toolStripSeparator7,
            this.tobEliminarContacto});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(852, 353);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(145, 29);
            this.toolStrip2.TabIndex = 133;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tobNuevoContacto
            // 
            this.tobNuevoContacto.Enabled = false;
            this.tobNuevoContacto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobNuevoContacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobNuevoContacto.Image = ((System.Drawing.Image)(resources.GetObject("tobNuevoContacto.Image")));
            this.tobNuevoContacto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobNuevoContacto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobNuevoContacto.Name = "tobNuevoContacto";
            this.tobNuevoContacto.Size = new System.Drawing.Size(26, 26);
            this.tobNuevoContacto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tobNuevoContacto.ToolTipText = "Agregar Nuevo Contacto (Ctrl + N)";
            this.tobNuevoContacto.Click += new System.EventHandler(this.tobNuevoContacto_Click);
            // 
            // tobModificarContacto
            // 
            this.tobModificarContacto.Enabled = false;
            this.tobModificarContacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobModificarContacto.Image = ((System.Drawing.Image)(resources.GetObject("tobModificarContacto.Image")));
            this.tobModificarContacto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobModificarContacto.Name = "tobModificarContacto";
            this.tobModificarContacto.Size = new System.Drawing.Size(26, 26);
            this.tobModificarContacto.ToolTipText = "Modificar Contacto Existente";
            this.tobModificarContacto.Click += new System.EventHandler(this.tobModificarContacto_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // tobGuardarContacto
            // 
            this.tobGuardarContacto.Enabled = false;
            this.tobGuardarContacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobGuardarContacto.Image = ((System.Drawing.Image)(resources.GetObject("tobGuardarContacto.Image")));
            this.tobGuardarContacto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobGuardarContacto.Name = "tobGuardarContacto";
            this.tobGuardarContacto.Size = new System.Drawing.Size(26, 26);
            this.tobGuardarContacto.ToolTipText = "Guardar Datos del Contacto";
            this.tobGuardarContacto.Click += new System.EventHandler(this.tobGuardarContacto_Click);
            // 
            // tobCancelarContacto
            // 
            this.tobCancelarContacto.Enabled = false;
            this.tobCancelarContacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobCancelarContacto.Image = ((System.Drawing.Image)(resources.GetObject("tobCancelarContacto.Image")));
            this.tobCancelarContacto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobCancelarContacto.Name = "tobCancelarContacto";
            this.tobCancelarContacto.Size = new System.Drawing.Size(26, 26);
            this.tobCancelarContacto.ToolTipText = "Cancelar Cambios";
            this.tobCancelarContacto.Click += new System.EventHandler(this.tobCancelarContacto_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 29);
            // 
            // tobEliminarContacto
            // 
            this.tobEliminarContacto.Enabled = false;
            this.tobEliminarContacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobEliminarContacto.Image = ((System.Drawing.Image)(resources.GetObject("tobEliminarContacto.Image")));
            this.tobEliminarContacto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobEliminarContacto.Name = "tobEliminarContacto";
            this.tobEliminarContacto.Size = new System.Drawing.Size(26, 26);
            this.tobEliminarContacto.ToolTipText = "Eliminar Contacto";
            this.tobEliminarContacto.Click += new System.EventHandler(this.tobEliminarContacto_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(855, 354);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip3.Size = new System.Drawing.Size(145, 29);
            this.toolStrip3.TabIndex = 134;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(851, 380);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(146, 2);
            this.label12.TabIndex = 135;
            // 
            // panelContactos
            // 
            this.panelContactos.BackColor = System.Drawing.Color.Transparent;
            this.panelContactos.Controls.Add(this.cmbContactos);
            this.panelContactos.Controls.Add(this.txtDescripcionContactos);
            this.panelContactos.Location = new System.Drawing.Point(0, -24);
            this.panelContactos.Name = "panelContactos";
            this.panelContactos.Size = new System.Drawing.Size(219, 23);
            this.panelContactos.TabIndex = 11;
            this.panelContactos.Tag = "219, 23";
            // 
            // cmbContactos
            // 
            this.cmbContactos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.cmbContactos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContactos.DropDownWidth = 121;
            this.cmbContactos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbContactos.ForeColor = System.Drawing.Color.White;
            this.cmbContactos.FormattingEnabled = true;
            this.cmbContactos.Items.AddRange(new object[] {
            "Celular",
            "Teléfono de Habitación"});
            this.cmbContactos.Location = new System.Drawing.Point(0, 0);
            this.cmbContactos.Name = "cmbContactos";
            this.cmbContactos.Size = new System.Drawing.Size(89, 23);
            this.cmbContactos.TabIndex = 0;
            // 
            // txtDescripcionContactos
            // 
            this.txtDescripcionContactos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.txtDescripcionContactos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcionContactos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionContactos.ForeColor = System.Drawing.Color.White;
            this.txtDescripcionContactos.Location = new System.Drawing.Point(90, 0);
            this.txtDescripcionContactos.Name = "txtDescripcionContactos";
            this.txtDescripcionContactos.Size = new System.Drawing.Size(130, 23);
            this.txtDescripcionContactos.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.panel1.Controls.Add(this.panelContactos);
            this.panel1.Controls.Add(this.lstContactos);
            this.panel1.Location = new System.Drawing.Point(780, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 207);
            this.panel1.TabIndex = 137;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(417, 225);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 15);
            this.label21.TabIndex = 73;
            this.label21.Text = "años";
            // 
            // cmbCategoriasEmp
            // 
            this.cmbCategoriasEmp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategoriasEmp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategoriasEmp.Enabled = false;
            this.cmbCategoriasEmp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoriasEmp.FormattingEnabled = true;
            this.cmbCategoriasEmp.Location = new System.Drawing.Point(146, 355);
            this.cmbCategoriasEmp.Name = "cmbCategoriasEmp";
            this.cmbCategoriasEmp.Size = new System.Drawing.Size(157, 23);
            this.cmbCategoriasEmp.TabIndex = 9;
            this.cmbCategoriasEmp.Tag = "estado_civil";
            this.cmbCategoriasEmp.Enter += new System.EventHandler(this.CmbEstadoCivil_Enter);
            this.cmbCategoriasEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbEstadoCivil_KeyPress);
            this.cmbCategoriasEmp.SelectedValueChanged += new System.EventHandler(this.cmbCategoriasEmp_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(341, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 69;
            this.label4.Text = "Código Colegiado";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdActivo);
            this.groupBox1.Controls.Add(this.rdInactivo);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Lavender;
            this.groupBox1.Location = new System.Drawing.Point(448, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 66);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado Actual";
            // 
            // rdActivo
            // 
            this.rdActivo.AutoSize = true;
            this.rdActivo.BackColor = System.Drawing.Color.Transparent;
            this.rdActivo.Checked = true;
            this.rdActivo.Enabled = false;
            this.rdActivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdActivo.ForeColor = System.Drawing.Color.White;
            this.rdActivo.Location = new System.Drawing.Point(14, 17);
            this.rdActivo.Name = "rdActivo";
            this.rdActivo.Size = new System.Drawing.Size(61, 19);
            this.rdActivo.TabIndex = 0;
            this.rdActivo.TabStop = true;
            this.rdActivo.Tag = "tipo_ced";
            this.rdActivo.Text = "Activo";
            this.rdActivo.UseVisualStyleBackColor = false;
            // 
            // rdInactivo
            // 
            this.rdInactivo.AutoSize = true;
            this.rdInactivo.BackColor = System.Drawing.Color.Transparent;
            this.rdInactivo.Enabled = false;
            this.rdInactivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdInactivo.ForeColor = System.Drawing.Color.White;
            this.rdInactivo.Location = new System.Drawing.Point(14, 37);
            this.rdInactivo.Name = "rdInactivo";
            this.rdInactivo.Size = new System.Drawing.Size(70, 19);
            this.rdInactivo.TabIndex = 1;
            this.rdInactivo.Tag = "tipo_ced";
            this.rdInactivo.Text = "Inactivo";
            this.rdInactivo.UseVisualStyleBackColor = false;
            // 
            // txtCodigoColegiado
            // 
            this.txtCodigoColegiado.AllowNegative = false;
            this.txtCodigoColegiado.DigitsInGroup = 0;
            this.txtCodigoColegiado.Enabled = false;
            this.txtCodigoColegiado.Flags = 65536;
            this.txtCodigoColegiado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoColegiado.ForeColor = System.Drawing.Color.DarkRed;
            this.txtCodigoColegiado.Location = new System.Drawing.Point(449, 356);
            this.txtCodigoColegiado.MaxDecimalPlaces = 0;
            this.txtCodigoColegiado.MaxLength = 6;
            this.txtCodigoColegiado.MaxWholeDigits = 6;
            this.txtCodigoColegiado.Name = "txtCodigoColegiado";
            this.txtCodigoColegiado.Prefix = "";
            this.txtCodigoColegiado.RangeMax = 1.7976931348623157E+308;
            this.txtCodigoColegiado.RangeMin = -1.7976931348623157E+308;
            this.txtCodigoColegiado.Size = new System.Drawing.Size(100, 24);
            this.txtCodigoColegiado.TabIndex = 10;
            this.txtCodigoColegiado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoColegiado.Enter += new System.EventHandler(this.txtCodigoColegiado_Enter);
            // 
            // toolStrip4
            // 
            this.toolStrip4.AutoSize = false;
            this.toolStrip4.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobGuardarCategoria});
            this.toolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip4.Location = new System.Drawing.Point(305, 353);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip4.Size = new System.Drawing.Size(27, 29);
            this.toolStrip4.TabIndex = 142;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // tobGuardarCategoria
            // 
            this.tobGuardarCategoria.Enabled = false;
            this.tobGuardarCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobGuardarCategoria.Image = ((System.Drawing.Image)(resources.GetObject("tobGuardarCategoria.Image")));
            this.tobGuardarCategoria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobGuardarCategoria.Name = "tobGuardarCategoria";
            this.tobGuardarCategoria.Size = new System.Drawing.Size(26, 26);
            this.tobGuardarCategoria.Click += new System.EventHandler(this.tobGuardarCategoria_Click);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(304, 380);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 2);
            this.label14.TabIndex = 73;
            // 
            // WebCamCapture
            // 
            this.WebCamCapture.CaptureHeight = 240;
            this.WebCamCapture.CaptureWidth = 320;
            this.WebCamCapture.FrameNumber = ((ulong)(0ul));
            this.WebCamCapture.Location = new System.Drawing.Point(17, 17);
            this.WebCamCapture.Name = "WebCamCapture";
            this.WebCamCapture.Size = new System.Drawing.Size(342, 252);
            this.WebCamCapture.TabIndex = 0;
            this.WebCamCapture.TimeToCapture_milliseconds = 100;
            this.WebCamCapture.ImageCaptured += new WebCam_Capture.WebCamCapture.WebCamEventHandler(this.WebCamCapture_ImageCaptured);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(11, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 246);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.statusStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 599);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1022, 35);
            this.panel3.TabIndex = 139;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 7);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1022, 28);
            this.statusStrip1.TabIndex = 46;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1007, 23);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 23);
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.imagenCambiantePictureBox1);
            this.panel2.Controls.Add(this.btnMinimize);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1022, 95);
            this.panel2.TabIndex = 138;
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(271, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(476, 2);
            this.label13.TabIndex = 126;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(10, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 128;
            this.pictureBox3.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobNuevo,
            this.tobModificar,
            this.toolStripSeparator1,
            this.tobGuardar,
            this.tobCancelar,
            this.toolStripSeparator8,
            this.tobIniciarConsulta,
            this.tobEjecutarConsulta,
            this.tobCancelarConsulta,
            this.toolStripSeparator4,
            this.tobSalir});
            this.toolStrip1.Location = new System.Drawing.Point(273, 8);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(469, 70);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tobNuevo
            // 
            this.tobNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobNuevo.ForeColor = System.Drawing.Color.White;
            this.tobNuevo.Image = global::G_Clinic.Properties.Resources.Nuevo;
            this.tobNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tobNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobNuevo.Name = "tobNuevo";
            this.tobNuevo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tobNuevo.Size = new System.Drawing.Size(52, 67);
            this.tobNuevo.Text = "Nuevo";
            this.tobNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobNuevo.ToolTipText = "Nuevo (Ctrl + N)";
            this.tobNuevo.Click += new System.EventHandler(this.tobNuevo_Click_1);
            // 
            // tobModificar
            // 
            this.tobModificar.Enabled = false;
            this.tobModificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobModificar.ForeColor = System.Drawing.Color.White;
            this.tobModificar.Image = global::G_Clinic.Properties.Resources.Modificar;
            this.tobModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobModificar.Name = "tobModificar";
            this.tobModificar.Size = new System.Drawing.Size(64, 67);
            this.tobModificar.Text = "Modificar";
            this.tobModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobModificar.ToolTipText = "Modificar (Ctrl + M)";
            this.tobModificar.Click += new System.EventHandler(this.tobModificar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 70);
            // 
            // tobGuardar
            // 
            this.tobGuardar.Enabled = false;
            this.tobGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobGuardar.ForeColor = System.Drawing.Color.White;
            this.tobGuardar.Image = global::G_Clinic.Properties.Resources.Guardar;
            this.tobGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobGuardar.Name = "tobGuardar";
            this.tobGuardar.Size = new System.Drawing.Size(56, 67);
            this.tobGuardar.Text = "Guardar";
            this.tobGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tobGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobGuardar.ToolTipText = "Guardar (Ctrl + G)";
            this.tobGuardar.Click += new System.EventHandler(this.tobGuardar_Click);
            // 
            // tobCancelar
            // 
            this.tobCancelar.Enabled = false;
            this.tobCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobCancelar.ForeColor = System.Drawing.Color.White;
            this.tobCancelar.Image = global::G_Clinic.Properties.Resources.Cancelar;
            this.tobCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobCancelar.Name = "tobCancelar";
            this.tobCancelar.Size = new System.Drawing.Size(58, 67);
            this.tobCancelar.Text = "Cancelar";
            this.tobCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobCancelar.ToolTipText = "Cancelar (Ctrl + C)";
            this.tobCancelar.Click += new System.EventHandler(this.tobCancelar_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 70);
            // 
            // tobIniciarConsulta
            // 
            this.tobIniciarConsulta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobIniciarConsulta.ForeColor = System.Drawing.Color.White;
            this.tobIniciarConsulta.Image = global::G_Clinic.Properties.Resources.IniciarConsulta;
            this.tobIniciarConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobIniciarConsulta.Name = "tobIniciarConsulta";
            this.tobIniciarConsulta.Size = new System.Drawing.Size(52, 67);
            this.tobIniciarConsulta.Text = "Iniciar ";
            this.tobIniciarConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobIniciarConsulta.ToolTipText = "Iniciar Consulta (F5)";
            this.tobIniciarConsulta.Click += new System.EventHandler(this.tobIniConsulta_Click);
            // 
            // tobEjecutarConsulta
            // 
            this.tobEjecutarConsulta.Enabled = false;
            this.tobEjecutarConsulta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobEjecutarConsulta.ForeColor = System.Drawing.Color.White;
            this.tobEjecutarConsulta.Image = global::G_Clinic.Properties.Resources.EjecutarConsulta;
            this.tobEjecutarConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobEjecutarConsulta.Name = "tobEjecutarConsulta";
            this.tobEjecutarConsulta.Size = new System.Drawing.Size(56, 67);
            this.tobEjecutarConsulta.Text = "Ejecutar";
            this.tobEjecutarConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobEjecutarConsulta.ToolTipText = "Ejecutar Consulta (F6)";
            this.tobEjecutarConsulta.Click += new System.EventHandler(this.tobConsultar_Click);
            // 
            // tobCancelarConsulta
            // 
            this.tobCancelarConsulta.Enabled = false;
            this.tobCancelarConsulta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobCancelarConsulta.ForeColor = System.Drawing.Color.White;
            this.tobCancelarConsulta.Image = global::G_Clinic.Properties.Resources.CancelarConsulta;
            this.tobCancelarConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobCancelarConsulta.Name = "tobCancelarConsulta";
            this.tobCancelarConsulta.Size = new System.Drawing.Size(58, 67);
            this.tobCancelarConsulta.Text = "Cancelar";
            this.tobCancelarConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobCancelarConsulta.ToolTipText = "Cancelar Consulta (F7)";
            this.tobCancelarConsulta.Click += new System.EventHandler(this.tobCancelConsulta_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 70);
            // 
            // tobSalir
            // 
            this.tobSalir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobSalir.ForeColor = System.Drawing.Color.White;
            this.tobSalir.Image = global::G_Clinic.Properties.Resources.Salir;
            this.tobSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobSalir.Name = "tobSalir";
            this.tobSalir.Size = new System.Drawing.Size(52, 67);
            this.tobSalir.Text = "Salir";
            this.tobSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobSalir.ToolTipText = "Salir (Alt + F4)";
            this.tobSalir.Click += new System.EventHandler(this.tobSalir_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(71, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 20);
            this.label9.TabIndex = 120;
            this.label9.Text = "Catálogo de Empleados";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(741, 11);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(6, 68);
            this.label20.TabIndex = 127;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(0, 90);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(7, 545);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 140;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(1015, 86);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(7, 545);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 141;
            this.pictureBox5.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.toolStrip5);
            this.panel4.Location = new System.Drawing.Point(559, 343);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(207, 40);
            this.panel4.TabIndex = 143;
            // 
            // toolStrip5
            // 
            this.toolStrip5.AutoSize = false;
            this.toolStrip5.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip5.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip5.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobCameraOn,
            this.toolStripSeparator9,
            this.tobSnapshot,
            this.toolStripSeparator10,
            this.tobCameraOff,
            this.toolStripSeparator11,
            this.toolStripSeparator12,
            this.BtnFoto,
            this.BtnRemover});
            this.toolStrip5.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip5.Location = new System.Drawing.Point(24, 8);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip5.Size = new System.Drawing.Size(165, 34);
            this.toolStrip5.TabIndex = 144;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // tobCameraOn
            // 
            this.tobCameraOn.Enabled = false;
            this.tobCameraOn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobCameraOn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobCameraOn.Image = ((System.Drawing.Image)(resources.GetObject("tobCameraOn.Image")));
            this.tobCameraOn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobCameraOn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobCameraOn.Name = "tobCameraOn";
            this.tobCameraOn.Size = new System.Drawing.Size(28, 31);
            this.tobCameraOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tobCameraOn.ToolTipText = "Encender Cámara";
            this.tobCameraOn.Click += new System.EventHandler(this.tobCameraOn_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.AutoSize = false;
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 28);
            // 
            // tobSnapshot
            // 
            this.tobSnapshot.Enabled = false;
            this.tobSnapshot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobSnapshot.Image = ((System.Drawing.Image)(resources.GetObject("tobSnapshot.Image")));
            this.tobSnapshot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobSnapshot.Name = "tobSnapshot";
            this.tobSnapshot.Size = new System.Drawing.Size(28, 31);
            this.tobSnapshot.ToolTipText = "Tomar Foto";
            this.tobSnapshot.Click += new System.EventHandler(this.tobSnapshot_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.AutoSize = false;
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 28);
            // 
            // tobCameraOff
            // 
            this.tobCameraOff.Enabled = false;
            this.tobCameraOff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobCameraOff.Image = ((System.Drawing.Image)(resources.GetObject("tobCameraOff.Image")));
            this.tobCameraOff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobCameraOff.Name = "tobCameraOff";
            this.tobCameraOff.Size = new System.Drawing.Size(28, 31);
            this.tobCameraOff.ToolTipText = "Detener Cámara";
            this.tobCameraOff.Click += new System.EventHandler(this.tobCameraOff_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.AutoSize = false;
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.AutoSize = false;
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 28);
            // 
            // BtnFoto
            // 
            this.BtnFoto.Enabled = false;
            this.BtnFoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.BtnFoto.Image = ((System.Drawing.Image)(resources.GetObject("BtnFoto.Image")));
            this.BtnFoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnFoto.Name = "BtnFoto";
            this.BtnFoto.Size = new System.Drawing.Size(28, 31);
            this.BtnFoto.ToolTipText = "Buscar archivo de imagen";
            this.BtnFoto.Click += new System.EventHandler(this.BtnFoto_Click);
            // 
            // BtnRemover
            // 
            this.BtnRemover.Enabled = false;
            this.BtnRemover.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.BtnRemover.Image = ((System.Drawing.Image)(resources.GetObject("BtnRemover.Image")));
            this.BtnRemover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRemover.Name = "BtnRemover";
            this.BtnRemover.Size = new System.Drawing.Size(28, 31);
            this.BtnRemover.ToolTipText = "Remover Foto";
            this.BtnRemover.Click += new System.EventHandler(this.BtnRemover_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::G_Clinic.Properties.Resources.frame_;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Location = new System.Drawing.Point(554, 91);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(216, 262);
            this.panel5.TabIndex = 145;
            // 
            // imagenCambiantePictureBox1
            // 
            this.imagenCambiantePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.imagenCambiantePictureBox1.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox1.HighlightedImage")));
            this.imagenCambiantePictureBox1.Image = global::G_Clinic.Properties.Resources.close;
            this.imagenCambiantePictureBox1.Location = new System.Drawing.Point(963, 0);
            this.imagenCambiantePictureBox1.Name = "imagenCambiantePictureBox1";
            this.imagenCambiantePictureBox1.Size = new System.Drawing.Size(42, 17);
            this.imagenCambiantePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imagenCambiantePictureBox1.TabIndex = 130;
            this.imagenCambiantePictureBox1.TabStop = false;
            this.imagenCambiantePictureBox1.Click += new System.EventHandler(this.imagenCambiantePictureBox1_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.HighlightedImage")));
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(940, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(24, 17);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMinimize.TabIndex = 129;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnDetalleContactos
            // 
            this.btnDetalleContactos.BackColor = System.Drawing.Color.Transparent;
            this.btnDetalleContactos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalleContactos.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleContactos.ForeColor = System.Drawing.Color.White;
            this.btnDetalleContactos.HighlightedImage = global::G_Clinic.Properties.Resources.Contact_40_highlighted;
            this.btnDetalleContactos.Image = global::G_Clinic.Properties.Resources.Contact_40;
            this.btnDetalleContactos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalleContactos.Location = new System.Drawing.Point(782, 100);
            this.btnDetalleContactos.Name = "btnDetalleContactos";
            this.btnDetalleContactos.Size = new System.Drawing.Size(211, 36);
            this.btnDetalleContactos.TabIndex = 132;
            this.btnDetalleContactos.Text = "Detalle de Contactos";
            this.btnDetalleContactos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalleContactos.Click += new System.EventHandler(this.btnDetalleContactos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.HighlightedImage")));
            this.btnSalir.Image = global::G_Clinic.Properties.Resources.close;
            this.btnSalir.Location = new System.Drawing.Point(958, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(42, 17);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnSalir.TabIndex = 131;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmMantEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1022, 634);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.toolStrip4);
            this.Controls.Add(this.txtCodigoColegiado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbCategoriasEmp);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.TxtCodigo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnDetalleContactos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.RdNacional);
            this.Controls.Add(this.TxtCedula);
            this.Controls.Add(this.RdExtranjero);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbSexo);
            this.Controls.Add(this.CmbEstadoCivil);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DtFecha_Naci);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtEdad);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNomEmpl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.CmbEstado);
            this.Controls.Add(this.panel4);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMantEmpleados";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Empleados";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Load += new System.EventHandler(this.FrmMantEmpleados_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMantEmpleados_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMantEmpleados_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panelContactos.ResumeLayout(false);
            this.panelContactos.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel4.ResumeLayout(false);
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbSexo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker DtFecha_Naci;
        private System.Windows.Forms.ComboBox CmbEstadoCivil;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtEdad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNomEmpl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tobNuevo;
        private System.Windows.Forms.ToolStripButton tobModificar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tobGuardar;
        private System.Windows.Forms.ToolStripButton tobCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tobSalir;
        private System.Windows.Forms.ToolStripButton tobIniciarConsulta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NuevotoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarConsultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarConsultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarConsultaF8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TextBox TxtCedula;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton RdExtranjero;
        private System.Windows.Forms.RadioButton RdNacional;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripButton tobEjecutarConsulta;
        private System.Windows.Forms.ToolStripButton tobCancelarConsulta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pictureBox3;
        private ImagenCambiantePictureBox btnSalir;
        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel btnDetalleContactos;
        private System.Windows.Forms.ListView lstContactos;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tobNuevoContacto;
        private System.Windows.Forms.ToolStripButton tobModificarContacto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tobGuardarContacto;
        private System.Windows.Forms.ToolStripButton tobCancelarContacto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tobEliminarContacto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.Panel panelContactos;
        private System.Windows.Forms.TextBox txtDescripcionContactos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbContactos;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private ImagenCambiantePictureBox btnMinimize;
        private ImagenCambiantePictureBox imagenCambiantePictureBox1;
        private System.Windows.Forms.ComboBox cmbCategoriasEmp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdActivo;
        private System.Windows.Forms.RadioButton rdInactivo;
        private AMS.TextBox.NumericTextBox txtCodigoColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Emp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCed;
        private System.Windows.Forms.DataGridViewTextBoxColumn FecNac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoCivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewImageColumn Imagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_Colegiado;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tobGuardarCategoria;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton tobCameraOn;
        private System.Windows.Forms.ToolStripButton tobCameraOff;
        private System.Windows.Forms.ToolStripButton tobSnapshot;
        private System.Windows.Forms.ToolStripButton BtnFoto;
        private System.Windows.Forms.Panel panel4;
        private WebCam_Capture.WebCamCapture WebCamCapture;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton BtnRemover;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.Panel panel5;
    }
}

