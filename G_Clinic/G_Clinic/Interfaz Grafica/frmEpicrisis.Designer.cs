namespace G_Clinic.Interfaz_Grafica
{
    partial class frmEpicrisis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEpicrisis));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstConsultasPaciente = new System.Windows.Forms.ListView();
            this.IdConsulta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumConsulta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FechaConsulta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rdSeleccionar = new System.Windows.Forms.RadioButton();
            this.rdNoIncluirDetallesConsultas = new System.Windows.Forms.RadioButton();
            this.rdTodas = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tobBuscarPaciente = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNumExpediente = new AMS.TextBox.NumericTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tobGuardar = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pdfViewer1 = new G_Clinic.Miscelaneos_y_Recursos.PDFViewer();
            this.btnMinimize = new G_Clinic.ImagenCambiantePictureBox();
            this.btnGenerarArchivo = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnSalir = new G_Clinic.ImagenCambiantePictureBox();
            this.btnMSWord = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnAdobeReader = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.cbIncluirGabinete = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbIncluirGabinete);
            this.groupBox1.Controls.Add(this.lstConsultasPaciente);
            this.groupBox1.Controls.Add(this.rdSeleccionar);
            this.groupBox1.Controls.Add(this.rdNoIncluirDetallesConsultas);
            this.groupBox1.Controls.Add(this.rdTodas);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Location = new System.Drawing.Point(21, 321);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 274);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones de documento";
            // 
            // lstConsultasPaciente
            // 
            this.lstConsultasPaciente.CheckBoxes = true;
            this.lstConsultasPaciente.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdConsulta,
            this.NumConsulta,
            this.FechaConsulta,
            this.columnHeader1});
            this.lstConsultasPaciente.Enabled = false;
            this.lstConsultasPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstConsultasPaciente.ForeColor = System.Drawing.Color.Black;
            this.lstConsultasPaciente.Location = new System.Drawing.Point(16, 68);
            this.lstConsultasPaciente.Name = "lstConsultasPaciente";
            this.lstConsultasPaciente.Size = new System.Drawing.Size(368, 197);
            this.lstConsultasPaciente.TabIndex = 1;
            this.lstConsultasPaciente.UseCompatibleStateImageBehavior = false;
            this.lstConsultasPaciente.View = System.Windows.Forms.View.Details;
            // 
            // IdConsulta
            // 
            this.IdConsulta.Text = "";
            this.IdConsulta.Width = 19;
            // 
            // NumConsulta
            // 
            this.NumConsulta.Text = "Nº de Consulta";
            this.NumConsulta.Width = 90;
            // 
            // FechaConsulta
            // 
            this.FechaConsulta.Text = "Fecha de Consulta";
            this.FechaConsulta.Width = 254;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader1.Width = 0;
            // 
            // rdSeleccionar
            // 
            this.rdSeleccionar.AutoSize = true;
            this.rdSeleccionar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSeleccionar.ForeColor = System.Drawing.Color.White;
            this.rdSeleccionar.Location = new System.Drawing.Point(16, 43);
            this.rdSeleccionar.Name = "rdSeleccionar";
            this.rdSeleccionar.Size = new System.Drawing.Size(222, 19);
            this.rdSeleccionar.TabIndex = 0;
            this.rdSeleccionar.Text = "Seleccionar las consultas deseadas...";
            this.rdSeleccionar.UseVisualStyleBackColor = true;
            // 
            // rdNoIncluirDetallesConsultas
            // 
            this.rdNoIncluirDetallesConsultas.AutoSize = true;
            this.rdNoIncluirDetallesConsultas.Checked = true;
            this.rdNoIncluirDetallesConsultas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNoIncluirDetallesConsultas.ForeColor = System.Drawing.Color.White;
            this.rdNoIncluirDetallesConsultas.Location = new System.Drawing.Point(269, 43);
            this.rdNoIncluirDetallesConsultas.Name = "rdNoIncluirDetallesConsultas";
            this.rdNoIncluirDetallesConsultas.Size = new System.Drawing.Size(190, 19);
            this.rdNoIncluirDetallesConsultas.TabIndex = 0;
            this.rdNoIncluirDetallesConsultas.TabStop = true;
            this.rdNoIncluirDetallesConsultas.Text = "No incluir detalle de consultas";
            this.rdNoIncluirDetallesConsultas.UseVisualStyleBackColor = true;
            this.rdNoIncluirDetallesConsultas.Visible = false;
            this.rdNoIncluirDetallesConsultas.CheckedChanged += new System.EventHandler(this.rdTodas_CheckedChanged);
            // 
            // rdTodas
            // 
            this.rdTodas.AutoSize = true;
            this.rdTodas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTodas.ForeColor = System.Drawing.Color.White;
            this.rdTodas.Location = new System.Drawing.Point(16, 22);
            this.rdTodas.Name = "rdTodas";
            this.rdTodas.Size = new System.Drawing.Size(164, 19);
            this.rdTodas.TabIndex = 0;
            this.rdTodas.Text = "Incluir todas las consultas";
            this.rdTodas.UseVisualStyleBackColor = true;
            this.rdTodas.CheckedChanged += new System.EventHandler(this.rdTodas_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(549, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 2);
            this.label10.TabIndex = 267;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(38, 38);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobBuscarPaciente});
            this.toolStrip2.Location = new System.Drawing.Point(549, 69);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(51, 60);
            this.toolStrip2.TabIndex = 266;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tobBuscarPaciente
            // 
            this.tobBuscarPaciente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobBuscarPaciente.ForeColor = System.Drawing.Color.White;
            this.tobBuscarPaciente.Image = ((System.Drawing.Image)(resources.GetObject("tobBuscarPaciente.Image")));
            this.tobBuscarPaciente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobBuscarPaciente.Name = "tobBuscarPaciente";
            this.tobBuscarPaciente.Size = new System.Drawing.Size(48, 57);
            this.tobBuscarPaciente.Text = "Buscar";
            this.tobBuscarPaciente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobBuscarPaciente.ToolTipText = "Buscar Paciente";
            this.tobBuscarPaciente.Click += new System.EventHandler(this.tobBuscarPaciente_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(216, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 265;
            this.label3.Text = "Paciente:";
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.Color.White;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.ForeColor = System.Drawing.Color.Black;
            this.TxtNombre.Location = new System.Drawing.Point(275, 98);
            this.TxtNombre.MaxLength = 65;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.ReadOnly = true;
            this.TxtNombre.Size = new System.Drawing.Size(271, 20);
            this.TxtNombre.TabIndex = 263;
            this.TxtNombre.Tag = "nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 264;
            this.label1.Text = "N° de Expediente:";
            // 
            // TxtNumExpediente
            // 
            this.TxtNumExpediente.AllowNegative = false;
            this.TxtNumExpediente.BackColor = System.Drawing.Color.White;
            this.TxtNumExpediente.DigitsInGroup = 0;
            this.TxtNumExpediente.Flags = 65536;
            this.TxtNumExpediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumExpediente.ForeColor = System.Drawing.Color.Red;
            this.TxtNumExpediente.Location = new System.Drawing.Point(128, 96);
            this.TxtNumExpediente.MaxDecimalPlaces = 0;
            this.TxtNumExpediente.MaxLength = 8;
            this.TxtNumExpediente.MaxWholeDigits = 9;
            this.TxtNumExpediente.Name = "TxtNumExpediente";
            this.TxtNumExpediente.Prefix = "";
            this.TxtNumExpediente.RangeMax = 1.7976931348623157E+308D;
            this.TxtNumExpediente.RangeMin = -1.7976931348623157E+308D;
            this.TxtNumExpediente.ReadOnly = true;
            this.TxtNumExpediente.Size = new System.Drawing.Size(82, 22);
            this.TxtNumExpediente.TabIndex = 262;
            this.TxtNumExpediente.Tag = "num_expediente";
            this.TxtNumExpediente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(212, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 271;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(228)))), ((int)(((byte)(200)))));
            this.textBox1.Location = new System.Drawing.Point(21, 145);
            this.textBox1.MaxLength = 5000;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(522, 167);
            this.textBox1.TabIndex = 273;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 265;
            this.label4.Text = "Detalle Epicrisis:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(38, 38);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobGuardar});
            this.toolStrip1.Location = new System.Drawing.Point(547, 141);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(45, 45);
            this.toolStrip1.TabIndex = 276;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tobGuardar
            // 
            this.tobGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobGuardar.ForeColor = System.Drawing.Color.White;
            this.tobGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tobGuardar.Image")));
            this.tobGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobGuardar.Name = "tobGuardar";
            this.tobGuardar.Size = new System.Drawing.Size(42, 42);
            this.tobGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobGuardar.ToolTipText = "Guardar Machote (guía de texto para las futuras epicrisis).";
            this.tobGuardar.Click += new System.EventHandler(this.tobGuardar_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(547, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 2);
            this.label2.TabIndex = 277;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1084, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 1);
            this.label5.TabIndex = 278;
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.BackColor = System.Drawing.Color.Transparent;
            this.pdfViewer1.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(211)))), ((int)(((byte)(228)))));
            this.pdfViewer1.Location = new System.Drawing.Point(607, 28);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(455, 567);
            this.pdfViewer1.TabIndex = 274;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.HighlightedImage")));
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(1084, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(24, 17);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMinimize.TabIndex = 272;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnGenerarArchivo
            // 
            this.btnGenerarArchivo.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerarArchivo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarArchivo.ForeColor = System.Drawing.Color.White;
            this.btnGenerarArchivo.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnGenerarArchivo.HighlightedImage")));
            this.btnGenerarArchivo.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerarArchivo.Image")));
            this.btnGenerarArchivo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGenerarArchivo.Location = new System.Drawing.Point(442, 353);
            this.btnGenerarArchivo.Name = "btnGenerarArchivo";
            this.btnGenerarArchivo.Size = new System.Drawing.Size(135, 134);
            this.btnGenerarArchivo.TabIndex = 270;
            this.btnGenerarArchivo.Text = "Previsualizar Archivo Epicrisis";
            this.btnGenerarArchivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerarArchivo.Click += new System.EventHandler(this.btnGenerarArchivo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.HighlightedImage")));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(1107, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(42, 17);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnSalir.TabIndex = 248;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnMSWord
            // 
            this.btnMSWord.BackColor = System.Drawing.Color.Transparent;
            this.btnMSWord.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMSWord.ForeColor = System.Drawing.Color.White;
            this.btnMSWord.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnMSWord.HighlightedImage")));
            this.btnMSWord.Image = ((System.Drawing.Image)(resources.GetObject("btnMSWord.Image")));
            this.btnMSWord.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMSWord.Location = new System.Drawing.Point(1080, 169);
            this.btnMSWord.Name = "btnMSWord";
            this.btnMSWord.Size = new System.Drawing.Size(76, 97);
            this.btnMSWord.TabIndex = 275;
            this.btnMSWord.Text = " Abrir con \r\nMS Word®";
            this.btnMSWord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMSWord.Click += new System.EventHandler(this.btnMSWord_Click);
            // 
            // btnAdobeReader
            // 
            this.btnAdobeReader.BackColor = System.Drawing.Color.Transparent;
            this.btnAdobeReader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdobeReader.ForeColor = System.Drawing.Color.White;
            this.btnAdobeReader.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnAdobeReader.HighlightedImage")));
            this.btnAdobeReader.Image = ((System.Drawing.Image)(resources.GetObject("btnAdobeReader.Image")));
            this.btnAdobeReader.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdobeReader.Location = new System.Drawing.Point(1061, 55);
            this.btnAdobeReader.Name = "btnAdobeReader";
            this.btnAdobeReader.Size = new System.Drawing.Size(117, 97);
            this.btnAdobeReader.TabIndex = 275;
            this.btnAdobeReader.Text = "    Abrir con \r\nAdobe Reader®";
            this.btnAdobeReader.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdobeReader.Click += new System.EventHandler(this.btnAdobeReader_Click);
            // 
            // cbIncluirGabinete
            // 
            this.cbIncluirGabinete.AutoSize = true;
            this.cbIncluirGabinete.ForeColor = System.Drawing.Color.Yellow;
            this.cbIncluirGabinete.Location = new System.Drawing.Point(269, 24);
            this.cbIncluirGabinete.Name = "cbIncluirGabinete";
            this.cbIncluirGabinete.Size = new System.Drawing.Size(115, 19);
            this.cbIncluirGabinete.TabIndex = 2;
            this.cbIncluirGabinete.Text = "Incluir Gabinete";
            this.cbIncluirGabinete.UseVisualStyleBackColor = true;
            // 
            // frmEpicrisis
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.BackgroundImage = global::G_Clinic.Properties.Resources._1__1_1_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1176, 628);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGenerarArchivo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNumExpediente);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnMSWord);
            this.Controls.Add(this.btnAdobeReader);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEpicrisis";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Epicrisis";
            this.Load += new System.EventHandler(this.frmEpicrisis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstConsultasPaciente;
        private System.Windows.Forms.ColumnHeader NumConsulta;
        private System.Windows.Forms.ColumnHeader FechaConsulta;
        private System.Windows.Forms.RadioButton rdSeleccionar;
        private System.Windows.Forms.RadioButton rdTodas;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ImagenCambiantePictureBox btnSalir;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tobBuscarPaciente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label1;
        public AMS.TextBox.NumericTextBox TxtNumExpediente;
        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel btnGenerarArchivo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColumnHeader IdConsulta;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private ImagenCambiantePictureBox btnMinimize;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdNoIncluirDetallesConsultas;
        private G_Clinic.Miscelaneos_y_Recursos.PDFViewer pdfViewer1;
        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel btnAdobeReader;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tobGuardar;
        private System.Windows.Forms.Label label2;
        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel btnMSWord;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbIncluirGabinete;
    }
}