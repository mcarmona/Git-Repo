namespace G_Clinic.Interfaz_Grafica
{
    partial class frmResultadosExamenesConsulta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResultadosExamenesConsulta));
            this.dtFechaResultados = new System.Windows.Forms.DateTimePicker();
            this.txtDetalleResultados = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tobBuscarPaciente = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtNumExpediente = new AMS.TextBox.NumericTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tobModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tobGuardar = new System.Windows.Forms.ToolStripButton();
            this.tobCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tobEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtNombreExamen = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDetalleExamen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaPrescripcion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoDisponible = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.softNetExamOrganizer2 = new G_Clinic.Miscelaneos_y_Recursos.SoftNetExamOrganizer();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softNetExamOrganizer1 = new G_Clinic.Miscelaneos_y_Recursos.SoftNetExamOrganizer();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMinimize = new G_Clinic.ImagenCambiantePictureBox();
            this.btnSalir = new G_Clinic.ImagenCambiantePictureBox();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.softNetExamOrganizer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softNetExamOrganizer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // dtFechaResultados
            // 
            this.dtFechaResultados.CustomFormat = "dddd\', \'dd MMMM  yyyy";
            this.dtFechaResultados.Enabled = false;
            this.dtFechaResultados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaResultados.Location = new System.Drawing.Point(197, 175);
            this.dtFechaResultados.Name = "dtFechaResultados";
            this.dtFechaResultados.Size = new System.Drawing.Size(230, 23);
            this.dtFechaResultados.TabIndex = 0;
            this.dtFechaResultados.Tag = "fec_nacimiento";
            this.dtFechaResultados.Value = new System.DateTime(2010, 11, 6, 0, 0, 0, 0);
            // 
            // txtDetalleResultados
            // 
            this.txtDetalleResultados.BackColor = System.Drawing.Color.White;
            this.txtDetalleResultados.Enabled = false;
            this.txtDetalleResultados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleResultados.Location = new System.Drawing.Point(197, 204);
            this.txtDetalleResultados.MaxLength = 3500;
            this.txtDetalleResultados.Multiline = true;
            this.txtDetalleResultados.Name = "txtDetalleResultados";
            this.txtDetalleResultados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalleResultados.Size = new System.Drawing.Size(354, 49);
            this.txtDetalleResultados.TabIndex = 1;
            this.txtDetalleResultados.Tag = "nombre";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(8, 175);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(186, 15);
            this.label39.TabIndex = 228;
            this.label39.Text = "Fecha de realización de examen:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.White;
            this.label41.Location = new System.Drawing.Point(8, 204);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(132, 15);
            this.label41.TabIndex = 229;
            this.label41.Text = "Resultado del Examen:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 233;
            this.label3.Text = "Nombre de Examen:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtNombre);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TxtNumExpediente);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Controls.Add(this.toolStrip3);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.txtNombreExamen);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.txtDetalleResultados);
            this.panel1.Controls.Add(this.label41);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblNoDisponible);
            this.panel1.Controls.Add(this.dtFechaResultados);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 260);
            this.panel1.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(581, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 2);
            this.label10.TabIndex = 267;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(38, 38);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobBuscarPaciente});
            this.toolStrip1.Location = new System.Drawing.Point(584, 53);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(51, 60);
            this.toolStrip1.TabIndex = 266;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tobBuscarPaciente
            // 
            this.tobBuscarPaciente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobBuscarPaciente.ForeColor = System.Drawing.Color.White;
            this.tobBuscarPaciente.Image = global::G_Clinic.Properties.Resources.Search_Patient;
            this.tobBuscarPaciente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobBuscarPaciente.Name = "tobBuscarPaciente";
            this.tobBuscarPaciente.Size = new System.Drawing.Size(48, 57);
            this.tobBuscarPaciente.Text = "Buscar";
            this.tobBuscarPaciente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobBuscarPaciente.ToolTipText = "Buscar Paciente";
            this.tobBuscarPaciente.Click += new System.EventHandler(this.tobBuscarPaciente_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(207, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(549, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 268;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(208, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 265;
            this.label4.Text = "Paciente:";
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.Color.White;
            this.TxtNombre.Enabled = false;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.ForeColor = System.Drawing.Color.Black;
            this.TxtNombre.Location = new System.Drawing.Point(269, 82);
            this.TxtNombre.MaxLength = 65;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.ReadOnly = true;
            this.TxtNombre.Size = new System.Drawing.Size(311, 20);
            this.TxtNombre.TabIndex = 263;
            this.TxtNombre.Tag = "nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 264;
            this.label5.Text = "N° de Expediente:";
            // 
            // TxtNumExpediente
            // 
            this.TxtNumExpediente.AllowNegative = false;
            this.TxtNumExpediente.BackColor = System.Drawing.Color.White;
            this.TxtNumExpediente.DigitsInGroup = 0;
            this.TxtNumExpediente.Enabled = false;
            this.TxtNumExpediente.Flags = 65536;
            this.TxtNumExpediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumExpediente.ForeColor = System.Drawing.Color.Red;
            this.TxtNumExpediente.Location = new System.Drawing.Point(133, 82);
            this.TxtNumExpediente.MaxDecimalPlaces = 0;
            this.TxtNumExpediente.MaxLength = 8;
            this.TxtNumExpediente.MaxWholeDigits = 9;
            this.TxtNumExpediente.Name = "TxtNumExpediente";
            this.TxtNumExpediente.Prefix = "";
            this.TxtNumExpediente.RangeMax = 1.7976931348623157E+308D;
            this.TxtNumExpediente.RangeMin = -1.7976931348623157E+308D;
            this.TxtNumExpediente.ReadOnly = true;
            this.TxtNumExpediente.Size = new System.Drawing.Size(58, 22);
            this.TxtNumExpediente.TabIndex = 262;
            this.TxtNumExpediente.Tag = "num_expediente";
            this.TxtNumExpediente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(-16, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(10, 10);
            this.button1.TabIndex = 251;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(430, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 2);
            this.label12.TabIndex = 250;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobModificar,
            this.toolStripSeparator6,
            this.tobGuardar,
            this.tobCancelar,
            this.toolStripSeparator7,
            this.tobEliminar});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(431, 170);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(117, 29);
            this.toolStrip2.TabIndex = 248;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tobModificar
            // 
            this.tobModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobModificar.Image = ((System.Drawing.Image)(resources.GetObject("tobModificar.Image")));
            this.tobModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobModificar.Name = "tobModificar";
            this.tobModificar.Size = new System.Drawing.Size(26, 26);
            this.tobModificar.Click += new System.EventHandler(this.tobModificar_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // tobGuardar
            // 
            this.tobGuardar.Enabled = false;
            this.tobGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tobGuardar.Image")));
            this.tobGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobGuardar.Name = "tobGuardar";
            this.tobGuardar.Size = new System.Drawing.Size(26, 26);
            this.tobGuardar.Click += new System.EventHandler(this.tobGuardar_Click);
            // 
            // tobCancelar
            // 
            this.tobCancelar.Enabled = false;
            this.tobCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tobCancelar.Image")));
            this.tobCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobCancelar.Name = "tobCancelar";
            this.tobCancelar.Size = new System.Drawing.Size(26, 26);
            this.tobCancelar.Click += new System.EventHandler(this.tobCancelar_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 29);
            // 
            // tobEliminar
            // 
            this.tobEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tobEliminar.Image")));
            this.tobEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobEliminar.Name = "tobEliminar";
            this.tobEliminar.Size = new System.Drawing.Size(26, 26);
            this.tobEliminar.Click += new System.EventHandler(this.tobEliminar_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(434, 171);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip3.Size = new System.Drawing.Size(117, 29);
            this.toolStrip3.TabIndex = 249;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(11, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 53);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 244;
            this.pictureBox2.TabStop = false;
            // 
            // txtNombreExamen
            // 
            this.txtNombreExamen.BackColor = System.Drawing.Color.Black;
            this.txtNombreExamen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreExamen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreExamen.ForeColor = System.Drawing.Color.Orange;
            this.txtNombreExamen.Location = new System.Drawing.Point(140, 127);
            this.txtNombreExamen.Name = "txtNombreExamen";
            this.txtNombreExamen.Size = new System.Drawing.Size(322, 18);
            this.txtNombreExamen.TabIndex = 234;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.txtDetalleExamen);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblFechaPrescripcion);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(468, 60);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel2.Size = new System.Drawing.Size(488, 200);
            this.panel2.TabIndex = 2;
            // 
            // txtDetalleExamen
            // 
            this.txtDetalleExamen.BackColor = System.Drawing.Color.Transparent;
            this.txtDetalleExamen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleExamen.ForeColor = System.Drawing.Color.White;
            this.txtDetalleExamen.Location = new System.Drawing.Point(102, 105);
            this.txtDetalleExamen.Name = "txtDetalleExamen";
            this.txtDetalleExamen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDetalleExamen.Size = new System.Drawing.Size(384, 88);
            this.txtDetalleExamen.TabIndex = 234;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 68);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 233;
            this.label1.Text = "Fecha Prescripción:";
            // 
            // lblFechaPrescripcion
            // 
            this.lblFechaPrescripcion.AutoSize = true;
            this.lblFechaPrescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaPrescripcion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaPrescripcion.ForeColor = System.Drawing.Color.Yellow;
            this.lblFechaPrescripcion.Location = new System.Drawing.Point(126, 68);
            this.lblFechaPrescripcion.Name = "lblFechaPrescripcion";
            this.lblFechaPrescripcion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFechaPrescripcion.Size = new System.Drawing.Size(126, 17);
            this.lblFechaPrescripcion.TabIndex = 233;
            this.lblFechaPrescripcion.Text = "Fecha Prescripción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(99, 88);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Detalle de Examen:";
            // 
            // lblNoDisponible
            // 
            this.lblNoDisponible.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDisponible.ForeColor = System.Drawing.Color.Silver;
            this.lblNoDisponible.Location = new System.Drawing.Point(197, 172);
            this.lblNoDisponible.Name = "lblNoDisponible";
            this.lblNoDisponible.Size = new System.Drawing.Size(234, 27);
            this.lblNoDisponible.TabIndex = 2;
            this.lblNoDisponible.Text = "¡No disponible!";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(9, 262);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(943, 326);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.softNetExamOrganizer2);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 42);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(935, 280);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gabinete";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Black;
            this.tabPage2.Controls.Add(this.softNetExamOrganizer1);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 42);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(935, 280);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Exámenes de Laboratorio";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Diagnosticos 55.png");
            this.imageList1.Images.SetKeyName(1, "laboratory 55.png");
            // 
            // softNetExamOrganizer2
            // 
            this.softNetExamOrganizer2.AllowUserToAddRows = false;
            this.softNetExamOrganizer2.AllowUserToDeleteRows = false;
            this.softNetExamOrganizer2.AllowUserToResizeColumns = false;
            this.softNetExamOrganizer2.AllowUserToResizeRows = false;
            this.softNetExamOrganizer2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.softNetExamOrganizer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.softNetExamOrganizer2.ColumnHeaderColor = System.Drawing.Color.Red;
            this.softNetExamOrganizer2.ColumnHeaderFont = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.softNetExamOrganizer2.ColumnHeadersVisible = false;
            this.softNetExamOrganizer2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.softNetExamOrganizer2.GeneralFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.softNetExamOrganizer2.HeaderColumn = "Fecha";
            this.softNetExamOrganizer2.HeaderRow = "Gabinete";
            this.softNetExamOrganizer2.Location = new System.Drawing.Point(0, 0);
            this.softNetExamOrganizer2.Name = "softNetExamOrganizer2";
            this.softNetExamOrganizer2.OFuente = new System.Drawing.Font("Segoe Print", 11F);
            this.softNetExamOrganizer2.OFuente2 = new System.Drawing.Font("Segoe UI", 10F);
            this.softNetExamOrganizer2.ReadOnly = true;
            this.softNetExamOrganizer2.RowHeaderColor = System.Drawing.Color.Black;
            this.softNetExamOrganizer2.RowHeaderFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.softNetExamOrganizer2.RowHeadersVisible = false;
            this.softNetExamOrganizer2.RowHeadersWidth = 15;
            this.softNetExamOrganizer2.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.softNetExamOrganizer2.RowTemplate.Height = 40;
            this.softNetExamOrganizer2.Size = new System.Drawing.Size(935, 280);
            this.softNetExamOrganizer2.StringToUse = "";
            this.softNetExamOrganizer2.TabIndex = 2;
            this.softNetExamOrganizer2.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.softNetExamOrganizer2_CellEnter);
            this.softNetExamOrganizer2.CellErrorTextNeeded += new System.Windows.Forms.DataGridViewCellErrorTextNeededEventHandler(this.softNetExamOrganizer2_CellErrorTextNeeded);
            this.softNetExamOrganizer2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.softNetExamOrganizer2_DataError);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.FillWeight = 116F;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // softNetExamOrganizer1
            // 
            this.softNetExamOrganizer1.AllowUserToAddRows = false;
            this.softNetExamOrganizer1.AllowUserToDeleteRows = false;
            this.softNetExamOrganizer1.AllowUserToResizeColumns = false;
            this.softNetExamOrganizer1.AllowUserToResizeRows = false;
            this.softNetExamOrganizer1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.softNetExamOrganizer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.softNetExamOrganizer1.ColumnHeaderColor = System.Drawing.Color.Red;
            this.softNetExamOrganizer1.ColumnHeaderFont = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.softNetExamOrganizer1.ColumnHeadersVisible = false;
            this.softNetExamOrganizer1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.softNetExamOrganizer1.GeneralFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.softNetExamOrganizer1.HeaderColumn = "Fecha";
            this.softNetExamOrganizer1.HeaderRow = "Examen";
            this.softNetExamOrganizer1.Location = new System.Drawing.Point(0, 0);
            this.softNetExamOrganizer1.Name = "softNetExamOrganizer1";
            this.softNetExamOrganizer1.OFuente = new System.Drawing.Font("Segoe Print", 11F);
            this.softNetExamOrganizer1.OFuente2 = new System.Drawing.Font("Segoe UI", 10F);
            this.softNetExamOrganizer1.ReadOnly = true;
            this.softNetExamOrganizer1.RowHeaderColor = System.Drawing.Color.Black;
            this.softNetExamOrganizer1.RowHeaderFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.softNetExamOrganizer1.RowHeadersVisible = false;
            this.softNetExamOrganizer1.RowHeadersWidth = 15;
            this.softNetExamOrganizer1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.softNetExamOrganizer1.RowTemplate.Height = 40;
            this.softNetExamOrganizer1.Size = new System.Drawing.Size(935, 280);
            this.softNetExamOrganizer1.StringToUse = "";
            this.softNetExamOrganizer1.TabIndex = 1;
            this.softNetExamOrganizer1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.softNetExamOrganizer1_CellEnter);
            // 
            // Column1
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.FillWeight = 116F;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.HighlightedImage")));
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.ImagenOriginal = ((System.Drawing.Image)(resources.GetObject("btnMinimize.ImagenOriginal")));
            this.btnMinimize.Location = new System.Drawing.Point(875, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(24, 17);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMinimize.TabIndex = 276;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.HighlightedImage")));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImagenOriginal = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImagenOriginal")));
            this.btnSalir.Location = new System.Drawing.Point(899, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(42, 17);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnSalir.TabIndex = 245;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmResultadosExamenesConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(962, 598);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmResultadosExamenesConsulta";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Examenes por Paciente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExamenesConsulta_FormClosing);
            this.Load += new System.EventHandler(this.frmExamenesConsulta_Load);
            this.VisibleChanged += new System.EventHandler(this.frmExamenesConsulta_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.softNetExamOrganizer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softNetExamOrganizer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFechaResultados;
        private System.Windows.Forms.TextBox txtDetalleResultados;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFechaPrescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNombreExamen;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ImagenCambiantePictureBox btnSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tobModificar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tobGuardar;
        private System.Windows.Forms.ToolStripButton tobCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tobEliminar;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtDetalleExamen;
        private System.Windows.Forms.Label lblNoDisponible;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tobBuscarPaciente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label5;
        public AMS.TextBox.NumericTextBox TxtNumExpediente;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ImagenCambiantePictureBox btnMinimize;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private G_Clinic.Miscelaneos_y_Recursos.SoftNetExamOrganizer softNetExamOrganizer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TabPage tabPage2;
        private G_Clinic.Miscelaneos_y_Recursos.SoftNetExamOrganizer softNetExamOrganizer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ImageList imageList1;

    }
}