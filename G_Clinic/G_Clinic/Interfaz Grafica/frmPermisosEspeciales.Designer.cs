namespace G_Clinic.Interfaz_Grafica
{
    partial class frmPermisosEspeciales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermisosEspeciales));
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tobCategoriasEmpleados = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tobTiposContactos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tobMetodosAnticonceptivos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tobGabinete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tobExamenesLaboratorio = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tobHistoriaClinica = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tobNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tobModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tobEliminar = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSalir = new G_Clinic.ImagenCambiantePictureBox();
            this.btnCancelar = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnListo = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(66, 75);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(210, 21);
            this.cmbRol.TabIndex = 101;
            this.cmbRol.SelectedIndexChanged += new System.EventHandler(this.cmbRol_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(24, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 102;
            this.label4.Text = "Roles";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.toolStrip2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gold;
            this.groupBox1.Location = new System.Drawing.Point(27, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 301);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Mantenimientos";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 2);
            this.label3.TabIndex = 91;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AllowMerge = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobCategoriasEmpleados,
            this.toolStripSeparator3,
            this.tobTiposContactos,
            this.toolStripSeparator4,
            this.tobMetodosAnticonceptivos,
            this.toolStripSeparator5,
            this.tobGabinete,
            this.toolStripSeparator6,
            this.tobExamenesLaboratorio,
            this.toolStripSeparator7,
            this.tobHistoriaClinica});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(9, 23);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.ShowItemToolTips = false;
            this.toolStrip2.Size = new System.Drawing.Size(194, 266);
            this.toolStrip2.TabIndex = 90;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tobCategoriasEmpleados
            // 
            this.tobCategoriasEmpleados.BackColor = System.Drawing.Color.Transparent;
            this.tobCategoriasEmpleados.CheckOnClick = true;
            this.tobCategoriasEmpleados.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobCategoriasEmpleados.ForeColor = System.Drawing.Color.White;
            this.tobCategoriasEmpleados.Image = ((System.Drawing.Image)(resources.GetObject("tobCategoriasEmpleados.Image")));
            this.tobCategoriasEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobCategoriasEmpleados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobCategoriasEmpleados.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobCategoriasEmpleados.Name = "tobCategoriasEmpleados";
            this.tobCategoriasEmpleados.Size = new System.Drawing.Size(192, 36);
            this.tobCategoriasEmpleados.Tag = "Categorias_de_Empleados";
            this.tobCategoriasEmpleados.Text = "Categorías de Empleados";
            this.tobCategoriasEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobCategoriasEmpleados.Click += new System.EventHandler(this.tobCategoriasEmpleados_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(192, 6);
            // 
            // tobTiposContactos
            // 
            this.tobTiposContactos.CheckOnClick = true;
            this.tobTiposContactos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobTiposContactos.ForeColor = System.Drawing.Color.White;
            this.tobTiposContactos.Image = ((System.Drawing.Image)(resources.GetObject("tobTiposContactos.Image")));
            this.tobTiposContactos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobTiposContactos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobTiposContactos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobTiposContactos.Name = "tobTiposContactos";
            this.tobTiposContactos.Size = new System.Drawing.Size(192, 36);
            this.tobTiposContactos.Tag = "Tipos_de_Contactos";
            this.tobTiposContactos.Text = "Tipos de Contactos";
            this.tobTiposContactos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobTiposContactos.Click += new System.EventHandler(this.tobTiposContactos_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(192, 6);
            // 
            // tobMetodosAnticonceptivos
            // 
            this.tobMetodosAnticonceptivos.CheckOnClick = true;
            this.tobMetodosAnticonceptivos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobMetodosAnticonceptivos.ForeColor = System.Drawing.Color.White;
            this.tobMetodosAnticonceptivos.Image = ((System.Drawing.Image)(resources.GetObject("tobMetodosAnticonceptivos.Image")));
            this.tobMetodosAnticonceptivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobMetodosAnticonceptivos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobMetodosAnticonceptivos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobMetodosAnticonceptivos.Name = "tobMetodosAnticonceptivos";
            this.tobMetodosAnticonceptivos.Size = new System.Drawing.Size(192, 36);
            this.tobMetodosAnticonceptivos.Tag = "Métodos_Anticonceptivos";
            this.tobMetodosAnticonceptivos.Text = "Métodos Anticonceptivos";
            this.tobMetodosAnticonceptivos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobMetodosAnticonceptivos.Click += new System.EventHandler(this.tobMetodosAnticonceptivos_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(192, 6);
            // 
            // tobGabinete
            // 
            this.tobGabinete.CheckOnClick = true;
            this.tobGabinete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobGabinete.ForeColor = System.Drawing.Color.White;
            this.tobGabinete.Image = ((System.Drawing.Image)(resources.GetObject("tobGabinete.Image")));
            this.tobGabinete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobGabinete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobGabinete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobGabinete.Name = "tobGabinete";
            this.tobGabinete.Size = new System.Drawing.Size(192, 36);
            this.tobGabinete.Tag = "Gabinete";
            this.tobGabinete.Text = "Gabinete";
            this.tobGabinete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobGabinete.Click += new System.EventHandler(this.tobGabinete_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(192, 6);
            // 
            // tobExamenesLaboratorio
            // 
            this.tobExamenesLaboratorio.CheckOnClick = true;
            this.tobExamenesLaboratorio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobExamenesLaboratorio.ForeColor = System.Drawing.Color.White;
            this.tobExamenesLaboratorio.Image = ((System.Drawing.Image)(resources.GetObject("tobExamenesLaboratorio.Image")));
            this.tobExamenesLaboratorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobExamenesLaboratorio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobExamenesLaboratorio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobExamenesLaboratorio.Name = "tobExamenesLaboratorio";
            this.tobExamenesLaboratorio.Size = new System.Drawing.Size(192, 36);
            this.tobExamenesLaboratorio.Tag = "Examenes_de_Laboratorio";
            this.tobExamenesLaboratorio.Text = "Exámenes de Laboratorio";
            this.tobExamenesLaboratorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobExamenesLaboratorio.Click += new System.EventHandler(this.tobExamenesLaboratorio_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(192, 6);
            // 
            // tobHistoriaClinica
            // 
            this.tobHistoriaClinica.CheckOnClick = true;
            this.tobHistoriaClinica.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobHistoriaClinica.ForeColor = System.Drawing.Color.White;
            this.tobHistoriaClinica.Image = ((System.Drawing.Image)(resources.GetObject("tobHistoriaClinica.Image")));
            this.tobHistoriaClinica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobHistoriaClinica.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobHistoriaClinica.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobHistoriaClinica.Name = "tobHistoriaClinica";
            this.tobHistoriaClinica.Size = new System.Drawing.Size(192, 36);
            this.tobHistoriaClinica.Tag = "Historia_Clínica";
            this.tobHistoriaClinica.Text = "Historia Clínica";
            this.tobHistoriaClinica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobHistoriaClinica.Click += new System.EventHandler(this.tobHistoriaClinica_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobNuevo,
            this.toolStripSeparator1,
            this.tobModificar,
            this.toolStripSeparator2,
            this.tobEliminar});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(289, 150);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(285, 54);
            this.toolStrip1.TabIndex = 88;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tobNuevo
            // 
            this.tobNuevo.BackColor = System.Drawing.Color.Transparent;
            this.tobNuevo.CheckOnClick = true;
            this.tobNuevo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobNuevo.ForeColor = System.Drawing.Color.White;
            this.tobNuevo.Image = global::G_Clinic.Properties.Resources.Nuevo;
            this.tobNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobNuevo.Name = "tobNuevo";
            this.tobNuevo.Size = new System.Drawing.Size(86, 51);
            this.tobNuevo.Text = "Ingresar Datos";
            this.tobNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tobNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobNuevo.ToolTipText = "Habilitar permiso de ingresar nuevos datos.";
            this.tobNuevo.Click += new System.EventHandler(this.tobNuevo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // tobModificar
            // 
            this.tobModificar.CheckOnClick = true;
            this.tobModificar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobModificar.ForeColor = System.Drawing.Color.White;
            this.tobModificar.Image = global::G_Clinic.Properties.Resources.Modificar;
            this.tobModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobModificar.Name = "tobModificar";
            this.tobModificar.Size = new System.Drawing.Size(94, 51);
            this.tobModificar.Text = "Modificar Datos";
            this.tobModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tobModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobModificar.ToolTipText = "Habilitar permiso de modificar datos existentes.";
            this.tobModificar.Click += new System.EventHandler(this.tobModificar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
            // 
            // tobEliminar
            // 
            this.tobEliminar.CheckOnClick = true;
            this.tobEliminar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobEliminar.ForeColor = System.Drawing.Color.White;
            this.tobEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tobEliminar.Image")));
            this.tobEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobEliminar.Name = "tobEliminar";
            this.tobEliminar.Size = new System.Drawing.Size(86, 51);
            this.tobEliminar.Text = "Eliminar Datos";
            this.tobEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tobEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobEliminar.ToolTipText = "Habilitar eliminar datos existentes";
            this.tobEliminar.Click += new System.EventHandler(this.tobEliminar_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(286, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 2);
            this.label2.TabIndex = 89;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(270, 226);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(324, 34);
            this.checkBox1.TabIndex = 104;
            this.checkBox1.Text = "Habilitar Solicitud de Usuario Administrador para realizar\r\nlas acciones denegada" +
                "s.";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(270, 269);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(333, 49);
            this.checkBox2.TabIndex = 104;
            this.checkBox2.Text = "Habilitar Permiso para Modificar valores de \"Antecedentes\r\nGenerales\" y \"Antecede" +
                "ntes Obstétricos y Ginecológicos\" \r\nen la Historia Clínica de los pacientes.";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lavender;
            this.label1.Location = new System.Drawing.Point(334, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 33);
            this.label1.TabIndex = 102;
            this.label1.Text = "Permisos Efectivos";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(555, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 116;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(419, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(2, 36);
            this.label5.TabIndex = 118;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(146, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 119;
            this.pictureBox1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.HighlightedImage")));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(561, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(42, 17);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnSalir.TabIndex = 247;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.HighlightedImage")));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(427, 353);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(129, 51);
            this.btnCancelar.TabIndex = 117;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnListo
            // 
            this.btnListo.BackColor = System.Drawing.Color.Transparent;
            this.btnListo.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListo.ForeColor = System.Drawing.Color.White;
            this.btnListo.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnListo.HighlightedImage")));
            this.btnListo.Image = ((System.Drawing.Image)(resources.GetObject("btnListo.Image")));
            this.btnListo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListo.Location = new System.Drawing.Point(312, 353);
            this.btnListo.Name = "btnListo";
            this.btnListo.Size = new System.Drawing.Size(107, 51);
            this.btnListo.TabIndex = 117;
            this.btnListo.Text = "Listo";
            this.btnListo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListo.Click += new System.EventHandler(this.btnListo_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.Color.Yellow;
            this.labelInfo.Location = new System.Drawing.Point(41, 427);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(544, 29);
            this.labelInfo.TabIndex = 248;
            this.labelInfo.Text = "La solicitud de Usuario Administrador sólamente será válida en los \"Antecedentes " +
                "Generales\" y los \"Antecedentes Obstétricos y Ginecológicos\" en la Historia Clíni" +
                "ca";
            this.labelInfo.Visible = false;
            // 
            // frmPermisosEspeciales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(116)))), ((int)(((byte)(114)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(627, 470);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnListo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelInfo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPermisosEspeciales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permisos Especiales";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.Load += new System.EventHandler(this.frmPermisosEspeciales_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tobNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tobModificar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tobEliminar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tobCategoriasEmpleados;
        private System.Windows.Forms.ToolStripButton tobTiposContactos;
        private System.Windows.Forms.ToolStripButton tobMetodosAnticonceptivos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tobHistoriaClinica;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel btnListo;
        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel btnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton tobGabinete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tobExamenesLaboratorio;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ImagenCambiantePictureBox btnSalir;
        private System.Windows.Forms.Label labelInfo;
    }
}