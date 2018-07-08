namespace G_Clinic.Interfaz_Grafica
{
    partial class frmParamBusquedaConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParamBusquedaConsulta));
            this.label2 = new System.Windows.Forms.Label();
            this.TxtIdConsulta = new AMS.TextBox.NumericTextBox();
            this.dtFechaCosnulta = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdIndicesFechas = new System.Windows.Forms.RadioButton();
            this.rdFechaExacta = new System.Windows.Forms.RadioButton();
            this.dtFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtNumExpediente = new AMS.TextBox.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tobBuscarPaciente = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDiagnosticos = new System.Windows.Forms.TextBox();
            this.lstDiagnosticos = new System.Windows.Forms.ListView();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tobLimpiar = new System.Windows.Forms.ToolStripButton();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.RdExtranjero = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCedula = new System.Windows.Forms.TextBox();
            this.RdNacional = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnEjecutarBusqueda = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 18);
            this.label2.TabIndex = 252;
            this.label2.Text = "N° de Consulta:";
            // 
            // TxtIdConsulta
            // 
            this.TxtIdConsulta.AllowNegative = false;
            this.TxtIdConsulta.BackColor = System.Drawing.Color.White;
            this.TxtIdConsulta.DigitsInGroup = 0;
            this.TxtIdConsulta.Flags = 65536;
            this.TxtIdConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdConsulta.ForeColor = System.Drawing.Color.Red;
            this.TxtIdConsulta.Location = new System.Drawing.Point(145, 39);
            this.TxtIdConsulta.MaxDecimalPlaces = 0;
            this.TxtIdConsulta.MaxLength = 32;
            this.TxtIdConsulta.MaxWholeDigits = 32;
            this.TxtIdConsulta.Name = "TxtIdConsulta";
            this.TxtIdConsulta.Prefix = "";
            this.TxtIdConsulta.RangeMax = 1.7976931348623157E+308;
            this.TxtIdConsulta.RangeMin = -1.7976931348623157E+308;
            this.TxtIdConsulta.Size = new System.Drawing.Size(170, 26);
            this.TxtIdConsulta.TabIndex = 0;
            this.TxtIdConsulta.Tag = "id_consulta";
            this.TxtIdConsulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtFechaCosnulta
            // 
            this.dtFechaCosnulta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaCosnulta.Location = new System.Drawing.Point(156, 26);
            this.dtFechaCosnulta.Name = "dtFechaCosnulta";
            this.dtFechaCosnulta.Size = new System.Drawing.Size(254, 21);
            this.dtFechaCosnulta.TabIndex = 1;
            this.dtFechaCosnulta.Tag = "fecha_consulta";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdIndicesFechas);
            this.groupBox1.Controls.Add(this.rdFechaExacta);
            this.groupBox1.Controls.Add(this.dtFechaFinal);
            this.groupBox1.Controls.Add(this.dtFechaInicial);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtFechaCosnulta);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Lavender;
            this.groupBox1.Location = new System.Drawing.Point(24, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 151);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Índices de fechas";
            // 
            // rdIndicesFechas
            // 
            this.rdIndicesFechas.AutoSize = true;
            this.rdIndicesFechas.ForeColor = System.Drawing.Color.White;
            this.rdIndicesFechas.Location = new System.Drawing.Point(21, 58);
            this.rdIndicesFechas.Name = "rdIndicesFechas";
            this.rdIndicesFechas.Size = new System.Drawing.Size(196, 19);
            this.rdIndicesFechas.TabIndex = 258;
            this.rdIndicesFechas.Text = "Seleccionar índices de fechas";
            this.rdIndicesFechas.UseVisualStyleBackColor = true;
            // 
            // rdFechaExacta
            // 
            this.rdFechaExacta.AutoSize = true;
            this.rdFechaExacta.ForeColor = System.Drawing.Color.White;
            this.rdFechaExacta.Location = new System.Drawing.Point(21, 26);
            this.rdFechaExacta.Name = "rdFechaExacta";
            this.rdFechaExacta.Size = new System.Drawing.Size(129, 19);
            this.rdFechaExacta.TabIndex = 0;
            this.rdFechaExacta.Text = "Usar fecha exacta";
            this.rdFechaExacta.UseVisualStyleBackColor = true;
            // 
            // dtFechaFinal
            // 
            this.dtFechaFinal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaFinal.Location = new System.Drawing.Point(156, 111);
            this.dtFechaFinal.Name = "dtFechaFinal";
            this.dtFechaFinal.Size = new System.Drawing.Size(254, 21);
            this.dtFechaFinal.TabIndex = 5;
            this.dtFechaFinal.Tag = "fecha_final";
            // 
            // dtFechaInicial
            // 
            this.dtFechaInicial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaInicial.Location = new System.Drawing.Point(156, 83);
            this.dtFechaInicial.Name = "dtFechaInicial";
            this.dtFechaInicial.Size = new System.Drawing.Size(254, 21);
            this.dtFechaInicial.TabIndex = 3;
            this.dtFechaInicial.Tag = "fecha_inicial";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Lavender;
            this.label7.Location = new System.Drawing.Point(70, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Fecha Final:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Lavender;
            this.label6.Location = new System.Drawing.Point(70, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Fecha Inicial:";
            // 
            // TxtNumExpediente
            // 
            this.TxtNumExpediente.AllowNegative = false;
            this.TxtNumExpediente.BackColor = System.Drawing.Color.White;
            this.TxtNumExpediente.DigitsInGroup = 0;
            this.TxtNumExpediente.Flags = 65536;
            this.TxtNumExpediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumExpediente.ForeColor = System.Drawing.Color.Red;
            this.TxtNumExpediente.Location = new System.Drawing.Point(127, 26);
            this.TxtNumExpediente.MaxDecimalPlaces = 0;
            this.TxtNumExpediente.MaxLength = 8;
            this.TxtNumExpediente.MaxWholeDigits = 9;
            this.TxtNumExpediente.Name = "TxtNumExpediente";
            this.TxtNumExpediente.Prefix = "";
            this.TxtNumExpediente.RangeMax = 1.7976931348623157E+308;
            this.TxtNumExpediente.RangeMin = -1.7976931348623157E+308;
            this.TxtNumExpediente.Size = new System.Drawing.Size(113, 24);
            this.TxtNumExpediente.TabIndex = 0;
            this.TxtNumExpediente.Tag = "num_expediente";
            this.TxtNumExpediente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 252;
            this.label1.Text = "N° de Expediente:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobBuscarPaciente});
            this.toolStrip1.Location = new System.Drawing.Point(245, 29);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(71, 86);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tobBuscarPaciente
            // 
            this.tobBuscarPaciente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobBuscarPaciente.ForeColor = System.Drawing.Color.White;
            this.tobBuscarPaciente.Image = ((System.Drawing.Image)(resources.GetObject("tobBuscarPaciente.Image")));
            this.tobBuscarPaciente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobBuscarPaciente.Name = "tobBuscarPaciente";
            this.tobBuscarPaciente.Size = new System.Drawing.Size(68, 83);
            this.tobBuscarPaciente.Text = "Buscar";
            this.tobBuscarPaciente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobBuscarPaciente.ToolTipText = "Buscar Paciente";
            this.tobBuscarPaciente.Click += new System.EventHandler(this.tobBuscarPaciente_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(242, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 2);
            this.label4.TabIndex = 252;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.toolStrip2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TxtIdConsulta);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(4, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(825, 481);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDiagnosticos);
            this.groupBox4.Controls.Add(this.lstDiagnosticos);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Lavender;
            this.groupBox4.Location = new System.Drawing.Point(466, 29);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(347, 441);
            this.groupBox4.TabIndex = 255;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lista de diagnósticos existentes";
            // 
            // txtDiagnosticos
            // 
            this.txtDiagnosticos.Location = new System.Drawing.Point(11, 26);
            this.txtDiagnosticos.Multiline = true;
            this.txtDiagnosticos.Name = "txtDiagnosticos";
            this.txtDiagnosticos.Size = new System.Drawing.Size(325, 50);
            this.txtDiagnosticos.TabIndex = 1;
            this.txtDiagnosticos.TextChanged += new System.EventHandler(this.txtDiagnosticos_TextChanged);
            // 
            // lstDiagnosticos
            // 
            this.lstDiagnosticos.CheckBoxes = true;
            this.lstDiagnosticos.Location = new System.Drawing.Point(11, 82);
            this.lstDiagnosticos.Name = "lstDiagnosticos";
            this.lstDiagnosticos.Size = new System.Drawing.Size(325, 349);
            this.lstDiagnosticos.TabIndex = 0;
            this.lstDiagnosticos.Tag = "id_diagnostico";
            this.lstDiagnosticos.UseCompatibleStateImageBehavior = false;
            this.lstDiagnosticos.View = System.Windows.Forms.View.SmallIcon;
            this.lstDiagnosticos.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstDiagnosticos_ItemChecked);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(381, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 2);
            this.label10.TabIndex = 254;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobLimpiar});
            this.toolStrip2.Location = new System.Drawing.Point(381, 18);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(55, 54);
            this.toolStrip2.TabIndex = 253;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tobLimpiar
            // 
            this.tobLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobLimpiar.ForeColor = System.Drawing.Color.Lavender;
            this.tobLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("tobLimpiar.Image")));
            this.tobLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobLimpiar.Name = "tobLimpiar";
            this.tobLimpiar.Size = new System.Drawing.Size(52, 51);
            this.tobLimpiar.Text = "Limpiar";
            this.tobLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobLimpiar.ToolTipText = "Limpiar Campos";
            this.tobLimpiar.Click += new System.EventHandler(this.tobLimpiar_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(31, 307);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(413, 1);
            this.label8.TabIndex = 252;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.toolStrip1);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.TxtNombre);
            this.groupBox3.Controls.Add(this.txtApellidos);
            this.groupBox3.Controls.Add(this.RdExtranjero);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.TxtCedula);
            this.groupBox3.Controls.Add(this.TxtNumExpediente);
            this.groupBox3.Controls.Add(this.RdNacional);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Lavender;
            this.groupBox3.Location = new System.Drawing.Point(24, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(430, 193);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos de Paciente";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::G_Clinic.Properties.Resources.Person_Red;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Image = global::G_Clinic.Properties.Resources.frame_;
            this.pictureBox3.Location = new System.Drawing.Point(313, 45);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(109, 131);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 268;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 267;
            this.label3.Text = "Nombre:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(15, 153);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 15);
            this.label17.TabIndex = 266;
            this.label17.Text = "Apellidos:";
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.Color.White;
            this.TxtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(81, 118);
            this.TxtNombre.MaxLength = 65;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(226, 23);
            this.TxtNombre.TabIndex = 3;
            this.TxtNombre.Tag = "nombre";
            // 
            // txtApellidos
            // 
            this.txtApellidos.BackColor = System.Drawing.Color.White;
            this.txtApellidos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.Location = new System.Drawing.Point(81, 150);
            this.txtApellidos.MaxLength = 65;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(226, 23);
            this.txtApellidos.TabIndex = 4;
            this.txtApellidos.Tag = "apellidos";
            // 
            // RdExtranjero
            // 
            this.RdExtranjero.AutoSize = true;
            this.RdExtranjero.BackColor = System.Drawing.Color.Transparent;
            this.RdExtranjero.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdExtranjero.ForeColor = System.Drawing.Color.White;
            this.RdExtranjero.Location = new System.Drawing.Point(159, 59);
            this.RdExtranjero.Name = "RdExtranjero";
            this.RdExtranjero.Size = new System.Drawing.Size(82, 19);
            this.RdExtranjero.TabIndex = 263;
            this.RdExtranjero.Tag = "tipo_ced";
            this.RdExtranjero.Text = "Extranjera";
            this.RdExtranjero.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 262;
            this.label5.Text = "Cédula:";
            // 
            // TxtCedula
            // 
            this.TxtCedula.BackColor = System.Drawing.Color.White;
            this.TxtCedula.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCedula.Location = new System.Drawing.Point(81, 85);
            this.TxtCedula.MaxLength = 30;
            this.TxtCedula.Name = "TxtCedula";
            this.TxtCedula.Size = new System.Drawing.Size(159, 23);
            this.TxtCedula.TabIndex = 2;
            this.TxtCedula.Tag = "cedula";
            // 
            // RdNacional
            // 
            this.RdNacional.AutoSize = true;
            this.RdNacional.BackColor = System.Drawing.Color.Transparent;
            this.RdNacional.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdNacional.ForeColor = System.Drawing.Color.White;
            this.RdNacional.Location = new System.Drawing.Point(81, 59);
            this.RdNacional.Name = "RdNacional";
            this.RdNacional.Size = new System.Drawing.Size(72, 19);
            this.RdNacional.TabIndex = 1;
            this.RdNacional.Tag = "tipo_ced";
            this.RdNacional.Text = "Nacional";
            this.RdNacional.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(33, -33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 613);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(211, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(412, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 261;
            this.pictureBox1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(-89, 266);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(0, 1);
            this.btnSalir.TabIndex = 264;
            this.btnSalir.Text = "button1";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBuscar.Location = new System.Drawing.Point(-89, 278);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(0, 2);
            this.btnBuscar.TabIndex = 265;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Lavender;
            this.label9.Location = new System.Drawing.Point(111, 499);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(679, 42);
            this.label9.TabIndex = 266;
            this.label9.Text = "Ingrese los datos referentes a la consulta que desea visualizar y presione la tec" +
                "la \"Enter\"\r\n                         o presione la tecla \"Escape\" para cancelar " +
                "la búsqueda.";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(784, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(103, 98);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 262;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnEjecutarBusqueda
            // 
            this.btnEjecutarBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEjecutarBusqueda.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutarBusqueda.ForeColor = System.Drawing.Color.White;
            this.btnEjecutarBusqueda.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnEjecutarBusqueda.HighlightedImage")));
            this.btnEjecutarBusqueda.Image = ((System.Drawing.Image)(resources.GetObject("btnEjecutarBusqueda.Image")));
            this.btnEjecutarBusqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEjecutarBusqueda.Location = new System.Drawing.Point(938, 191);
            this.btnEjecutarBusqueda.Name = "btnEjecutarBusqueda";
            this.btnEjecutarBusqueda.Size = new System.Drawing.Size(195, 158);
            this.btnEjecutarBusqueda.TabIndex = 1;
            this.btnEjecutarBusqueda.Text = "Ejecutar Búsqueda";
            this.btnEjecutarBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEjecutarBusqueda.Click += new System.EventHandler(this.btnEjecutarBusqueda_Click);
            // 
            // frmParamBusquedaConsulta
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(901, 547);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEjecutarBusqueda);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmParamBusquedaConsulta";
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            this.Text = "frmParamBusquedaConsulta";
            this.Load += new System.EventHandler(this.frmParamBusquedaConsulta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private AMS.TextBox.NumericTextBox TxtIdConsulta;
        private System.Windows.Forms.DateTimePicker dtFechaCosnulta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtFechaFinal;
        private System.Windows.Forms.DateTimePicker dtFechaInicial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdIndicesFechas;
        private System.Windows.Forms.RadioButton rdFechaExacta;
        private AMS.TextBox.NumericTextBox TxtNumExpediente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tobBuscarPaciente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCedula;
        private System.Windows.Forms.RadioButton RdNacional;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RdExtranjero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox3;
        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel btnEjecutarBusqueda;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tobLimpiar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView lstDiagnosticos;
        private System.Windows.Forms.TextBox txtDiagnosticos;
    }
}