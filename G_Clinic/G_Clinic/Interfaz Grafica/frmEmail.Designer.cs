namespace G_Clinic.Interfaz_Grafica
{
    partial class frmEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmail));
            this.lstContactos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEmisor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPara = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tobBuscarPaciente = new System.Windows.Forms.ToolStripButton();
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBuscarPaciente = new System.Windows.Forms.TextBox();
            this.rdSeleccionarTodos = new System.Windows.Forms.RadioButton();
            this.rdSeleccionarVarios = new System.Windows.Forms.RadioButton();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.label47 = new System.Windows.Forms.Label();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.tobGuardarEmisor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tobEliminarEmisor = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tobSendMail = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tobAdjuntar = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lstAttachments = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.tobNewMail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tobCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnGmail = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.imagenCambiantePictureBox1 = new G_Clinic.ImagenCambiantePictureBox();
            this.btnMinimize = new G_Clinic.ImagenCambiantePictureBox();
            this.editor1 = new G_Clinic.Editor();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.grouper1.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // lstContactos
            // 
            this.lstContactos.CheckBoxes = true;
            this.lstContactos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstContactos.FullRowSelect = true;
            this.lstContactos.HideSelection = false;
            this.lstContactos.Location = new System.Drawing.Point(10, 72);
            this.lstContactos.Name = "lstContactos";
            this.lstContactos.Size = new System.Drawing.Size(326, 401);
            this.lstContactos.TabIndex = 0;
            this.lstContactos.UseCompatibleStateImageBehavior = false;
            this.lstContactos.View = System.Windows.Forms.View.Details;
            this.lstContactos.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstContactos_ItemChecked);
            this.lstContactos.SelectedIndexChanged += new System.EventHandler(this.lstContactos_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 24;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dirección Email";
            this.columnHeader2.Width = 137;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nombre del Paciente";
            this.columnHeader3.Width = 250;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "De:";
            // 
            // cmbEmisor
            // 
            this.cmbEmisor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmisor.FormattingEnabled = true;
            this.cmbEmisor.Location = new System.Drawing.Point(58, 115);
            this.cmbEmisor.Name = "cmbEmisor";
            this.cmbEmisor.Size = new System.Drawing.Size(276, 25);
            this.cmbEmisor.TabIndex = 2;
            this.cmbEmisor.Enter += new System.EventHandler(this.cmbEmisor_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Para:";
            // 
            // txtPara
            // 
            this.txtPara.Location = new System.Drawing.Point(61, 146);
            this.txtPara.Multiline = true;
            this.txtPara.Name = "txtPara";
            this.txtPara.Size = new System.Drawing.Size(500, 77);
            this.txtPara.TabIndex = 3;
            this.txtPara.Enter += new System.EventHandler(this.txtPara_Enter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.editor1);
            this.panel1.Location = new System.Drawing.Point(12, 333);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 285);
            this.panel1.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(569, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 2);
            this.label10.TabIndex = 263;
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
            this.toolStrip2.Location = new System.Drawing.Point(569, 141);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(71, 84);
            this.toolStrip2.TabIndex = 262;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tobBuscarPaciente
            // 
            this.tobBuscarPaciente.AutoSize = false;
            this.tobBuscarPaciente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobBuscarPaciente.ForeColor = System.Drawing.Color.White;
            this.tobBuscarPaciente.Image = ((System.Drawing.Image)(resources.GetObject("tobBuscarPaciente.Image")));
            this.tobBuscarPaciente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobBuscarPaciente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobBuscarPaciente.Name = "tobBuscarPaciente";
            this.tobBuscarPaciente.Size = new System.Drawing.Size(68, 81);
            this.tobBuscarPaciente.Text = "Buscar";
            this.tobBuscarPaciente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobBuscarPaciente.ToolTipText = "Buscar Paciente";
            this.tobBuscarPaciente.Click += new System.EventHandler(this.tobBuscarPaciente_Click);
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(199)))), ((int)(((byte)(240)))));
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.SlateGray;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            this.grouper1.BorderColor = System.Drawing.Color.Transparent;
            this.grouper1.BorderThickness = 1F;
            this.grouper1.Controls.Add(this.lstContactos);
            this.grouper1.Controls.Add(this.label6);
            this.grouper1.Controls.Add(this.txtBuscarPaciente);
            this.grouper1.Controls.Add(this.rdSeleccionarTodos);
            this.grouper1.Controls.Add(this.rdSeleccionarVarios);
            this.grouper1.Controls.Add(this.toolStrip5);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "";
            this.grouper1.Location = new System.Drawing.Point(646, 138);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(20);
            this.grouper1.PaintGroupBox = false;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grouper1.ShadowControl = false;
            this.grouper1.ShadowThickness = 3;
            this.grouper1.Size = new System.Drawing.Size(345, 480);
            this.grouper1.TabIndex = 264;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(298, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 2);
            this.label6.TabIndex = 276;
            // 
            // txtBuscarPaciente
            // 
            this.txtBuscarPaciente.ForeColor = System.Drawing.Color.Gray;
            this.txtBuscarPaciente.Location = new System.Drawing.Point(9, 48);
            this.txtBuscarPaciente.Name = "txtBuscarPaciente";
            this.txtBuscarPaciente.Size = new System.Drawing.Size(286, 20);
            this.txtBuscarPaciente.TabIndex = 2;
            this.txtBuscarPaciente.Text = "Ingrese el nombre de la persona deseada...";
            this.txtBuscarPaciente.Click += new System.EventHandler(this.txtBuscarPaciente_Click);
            this.txtBuscarPaciente.TextChanged += new System.EventHandler(this.txtBuscarPaciente_TextChanged);
            this.txtBuscarPaciente.Enter += new System.EventHandler(this.txtBuscarPaciente_Click);
            // 
            // rdSeleccionarTodos
            // 
            this.rdSeleccionarTodos.AutoSize = true;
            this.rdSeleccionarTodos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSeleccionarTodos.ForeColor = System.Drawing.Color.White;
            this.rdSeleccionarTodos.Location = new System.Drawing.Point(141, 23);
            this.rdSeleccionarTodos.Name = "rdSeleccionarTodos";
            this.rdSeleccionarTodos.Size = new System.Drawing.Size(125, 19);
            this.rdSeleccionarTodos.TabIndex = 1;
            this.rdSeleccionarTodos.Text = "Seleccionar Todos";
            this.rdSeleccionarTodos.UseVisualStyleBackColor = true;
            this.rdSeleccionarTodos.CheckedChanged += new System.EventHandler(this.rdSeleccionarTodos_CheckedChanged);
            // 
            // rdSeleccionarVarios
            // 
            this.rdSeleccionarVarios.AutoSize = true;
            this.rdSeleccionarVarios.Checked = true;
            this.rdSeleccionarVarios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSeleccionarVarios.ForeColor = System.Drawing.Color.White;
            this.rdSeleccionarVarios.Location = new System.Drawing.Point(9, 23);
            this.rdSeleccionarVarios.Name = "rdSeleccionarVarios";
            this.rdSeleccionarVarios.Size = new System.Drawing.Size(126, 19);
            this.rdSeleccionarVarios.TabIndex = 1;
            this.rdSeleccionarVarios.TabStop = true;
            this.rdSeleccionarVarios.Text = "Seleccionar Varios";
            this.rdSeleccionarVarios.UseVisualStyleBackColor = true;
            this.rdSeleccionarVarios.CheckedChanged += new System.EventHandler(this.rdSeleccionarVarios_CheckedChanged);
            // 
            // toolStrip5
            // 
            this.toolStrip5.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip5.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip5.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip5.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip5.Location = new System.Drawing.Point(298, 35);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip5.Size = new System.Drawing.Size(39, 39);
            this.toolStrip5.TabIndex = 275;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.ToolTipText = "Guardar dirección de correo";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.Color.Transparent;
            this.label47.Location = new System.Drawing.Point(336, 141);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(65, 2);
            this.label47.TabIndex = 266;
            // 
            // toolStrip4
            // 
            this.toolStrip4.AutoSize = false;
            this.toolStrip4.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobGuardarEmisor,
            this.toolStripSeparator2,
            this.tobEliminarEmisor});
            this.toolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip4.Location = new System.Drawing.Point(337, 113);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip4.Size = new System.Drawing.Size(62, 30);
            this.toolStrip4.TabIndex = 265;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // tobGuardarEmisor
            // 
            this.tobGuardarEmisor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobGuardarEmisor.Image = ((System.Drawing.Image)(resources.GetObject("tobGuardarEmisor.Image")));
            this.tobGuardarEmisor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobGuardarEmisor.Name = "tobGuardarEmisor";
            this.tobGuardarEmisor.Size = new System.Drawing.Size(26, 27);
            this.tobGuardarEmisor.ToolTipText = "Guardar dirección de correo";
            this.tobGuardarEmisor.Click += new System.EventHandler(this.tobGuardarEmisor_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tobEliminarEmisor
            // 
            this.tobEliminarEmisor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobEliminarEmisor.Image = ((System.Drawing.Image)(resources.GetObject("tobEliminarEmisor.Image")));
            this.tobEliminarEmisor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobEliminarEmisor.Name = "tobEliminarEmisor";
            this.tobEliminarEmisor.Size = new System.Drawing.Size(26, 27);
            this.tobEliminarEmisor.ToolTipText = "Eliminar dirección de correo";
            this.tobEliminarEmisor.Click += new System.EventHandler(this.tobEliminarEmisor_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(477, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 2);
            this.label3.TabIndex = 268;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(38, 38);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobSendMail});
            this.toolStrip1.Location = new System.Drawing.Point(480, 90);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(89, 55);
            this.toolStrip1.TabIndex = 267;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tobSendMail
            // 
            this.tobSendMail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobSendMail.ForeColor = System.Drawing.Color.White;
            this.tobSendMail.Image = ((System.Drawing.Image)(resources.GetObject("tobSendMail.Image")));
            this.tobSendMail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobSendMail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobSendMail.Name = "tobSendMail";
            this.tobSendMail.Size = new System.Drawing.Size(86, 52);
            this.tobSendMail.Text = "Enviar Correo";
            this.tobSendMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobSendMail.ToolTipText = "Enviar correo a los destinatarios indicados";
            this.tobSendMail.Click += new System.EventHandler(this.tobSendMail_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(38, 38);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobAdjuntar});
            this.toolStrip3.Location = new System.Drawing.Point(14, 257);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(94, 39);
            this.toolStrip3.TabIndex = 269;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tobAdjuntar
            // 
            this.tobAdjuntar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobAdjuntar.ForeColor = System.Drawing.Color.White;
            this.tobAdjuntar.Image = ((System.Drawing.Image)(resources.GetObject("tobAdjuntar.Image")));
            this.tobAdjuntar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobAdjuntar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobAdjuntar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobAdjuntar.Name = "tobAdjuntar";
            this.tobAdjuntar.Size = new System.Drawing.Size(91, 36);
            this.tobAdjuntar.Text = "Adjuntar";
            this.tobAdjuntar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobAdjuntar.ToolTipText = "Buscar Paciente";
            this.tobAdjuntar.Click += new System.EventHandler(this.tobAdjuntar_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 2);
            this.label4.TabIndex = 271;
            // 
            // lstAttachments
            // 
            this.lstAttachments.CheckBoxes = true;
            this.lstAttachments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.lstAttachments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAttachments.FullRowSelect = true;
            this.lstAttachments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstAttachments.HideSelection = false;
            this.lstAttachments.Location = new System.Drawing.Point(102, 259);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(538, 68);
            this.lstAttachments.TabIndex = 1;
            this.lstAttachments.UseCompatibleStateImageBehavior = false;
            this.lstAttachments.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "";
            this.columnHeader6.Width = 496;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Seleccione los archivos que desee adjuntar...";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(61, 232);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(579, 20);
            this.txtAsunto.TabIndex = 273;
            this.txtAsunto.Enter += new System.EventHandler(this.txtAsunto_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 272;
            this.label5.Text = "Asunto:";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(253, 63);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 274;
            this.txtPassword.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(261, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(478, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 277;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 627);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip1.TabIndex = 278;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.SkyBlue;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(985, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Orange;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(11, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 2);
            this.label7.TabIndex = 280;
            // 
            // toolStrip6
            // 
            this.toolStrip6.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip6.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip6.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip6.ImageScalingSize = new System.Drawing.Size(38, 38);
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobNewMail,
            this.toolStripSeparator1,
            this.tobCancelar});
            this.toolStrip6.Location = new System.Drawing.Point(12, 20);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip6.Size = new System.Drawing.Size(181, 68);
            this.toolStrip6.TabIndex = 279;
            this.toolStrip6.Text = "toolStrip6";
            // 
            // tobNewMail
            // 
            this.tobNewMail.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobNewMail.ForeColor = System.Drawing.Color.White;
            this.tobNewMail.Image = ((System.Drawing.Image)(resources.GetObject("tobNewMail.Image")));
            this.tobNewMail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobNewMail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobNewMail.Name = "tobNewMail";
            this.tobNewMail.Size = new System.Drawing.Size(100, 65);
            this.tobNewMail.Text = "Crear Nuevo";
            this.tobNewMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobNewMail.ToolTipText = "Crear nuevo mensaje de correo electrónico";
            this.tobNewMail.Click += new System.EventHandler(this.tobNewMail_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Azure;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 60);
            // 
            // tobCancelar
            // 
            this.tobCancelar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobCancelar.ForeColor = System.Drawing.Color.White;
            this.tobCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tobCancelar.Image")));
            this.tobCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobCancelar.Name = "tobCancelar";
            this.tobCancelar.Size = new System.Drawing.Size(72, 65);
            this.tobCancelar.Text = "Cancelar";
            this.tobCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobCancelar.ToolTipText = "Cancelar el mensaje de correo electrónico en proceso";
            this.tobCancelar.Click += new System.EventHandler(this.tobCancelar_Click);
            // 
            // btnGmail
            // 
            this.btnGmail.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnGmail.HighlightedImage")));
            this.btnGmail.Image = ((System.Drawing.Image)(resources.GetObject("btnGmail.Image")));
            this.btnGmail.Location = new System.Drawing.Point(827, 41);
            this.btnGmail.Name = "btnGmail";
            this.btnGmail.Size = new System.Drawing.Size(161, 106);
            this.btnGmail.TabIndex = 277;
            this.btnGmail.Click += new System.EventHandler(this.btnGmail_Click);
            // 
            // imagenCambiantePictureBox1
            // 
            this.imagenCambiantePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.imagenCambiantePictureBox1.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox1.HighlightedImage")));
            this.imagenCambiantePictureBox1.Image = global::G_Clinic.Properties.Resources.close;
            this.imagenCambiantePictureBox1.Location = new System.Drawing.Point(936, 0);
            this.imagenCambiantePictureBox1.Name = "imagenCambiantePictureBox1";
            this.imagenCambiantePictureBox1.Size = new System.Drawing.Size(42, 17);
            this.imagenCambiantePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imagenCambiantePictureBox1.TabIndex = 276;
            this.imagenCambiantePictureBox1.TabStop = false;
            this.imagenCambiantePictureBox1.Click += new System.EventHandler(this.imagenCambiantePictureBox1_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.HighlightedImage")));
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(913, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(24, 17);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMinimize.TabIndex = 275;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // editor1
            // 
            this.editor1.BodyHtml = null;
            this.editor1.BodyText = null;
            this.editor1.DocumentText = resources.GetString("editor1.DocumentText");
            this.editor1.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.editor1.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.editor1.FontSize = G_Clinic.FontSize.Three;
            this.editor1.Location = new System.Drawing.Point(0, 0);
            this.editor1.Name = "editor1";
            this.editor1.Size = new System.Drawing.Size(628, 285);
            this.editor1.TabIndex = 0;
            // 
            // frmEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1000, 649);
            this.Controls.Add(this.btnGmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip6);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.imagenCambiantePictureBox1);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.txtAsunto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstAttachments);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.txtPara);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.toolStrip4);
            this.Controls.Add(this.grouper1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEmisor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtPassword);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmail";
            this.Opacity = 0.93D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoftNet Mail";
            this.Load += new System.EventHandler(this.frmEmail_Load);
            this.panel1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.grouper1.ResumeLayout(false);
            this.grouper1.PerformLayout();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstContactos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEmisor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPara;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tobBuscarPaciente;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private CodeVendor.Controls.Grouper grouper1;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tobGuardarEmisor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tobSendMail;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tobAdjuntar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstAttachments;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton tobEliminarEmisor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtBuscarPaciente;
        private System.Windows.Forms.RadioButton rdSeleccionarTodos;
        private System.Windows.Forms.RadioButton rdSeleccionarVarios;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private ImagenCambiantePictureBox imagenCambiantePictureBox1;
        private ImagenCambiantePictureBox btnMinimize;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel btnGmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripButton tobNewMail;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton tobCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private Editor editor1;        
    }
}