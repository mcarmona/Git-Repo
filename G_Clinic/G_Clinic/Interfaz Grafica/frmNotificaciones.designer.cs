namespace G_Clinic
{
    partial class frmNotificaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotificaciones));
            this.label1 = new System.Windows.Forms.Label();
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.panel1 = new G_Clinic.PanelAvailableHours();
            this.lstContactos = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.imagenCambiantePictureBox3 = new G_Clinic.ImagenCambiantePictureBox();
            this.btnOk = new G_Clinic.ImagenCambiantePictureBox();
            this.cmbLapsoRecordatorio = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnCerrar = new G_Clinic.ImagenCambiantePictureBox();
            this.imagenCambiantePictureBox1 = new G_Clinic.ImagenCambiantePictureBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timerInicio = new System.Windows.Forms.Timer(this.components);
            this.timerEspera = new System.Windows.Forms.Timer(this.components);
            this.timerCerrar = new System.Windows.Forms.Timer(this.components);
            this.toolTipContactos = new System.Windows.Forms.ToolTip(this.components);
            this.lstContactos2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.grouper1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(96, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "¡Atención!";
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.Color.White;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.LightSteelBlue;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            this.grouper1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grouper1.BorderColor = System.Drawing.Color.Black;
            this.grouper1.BorderThickness = 1F;
            this.grouper1.Controls.Add(this.panel1);
            this.grouper1.Controls.Add(this.imagenCambiantePictureBox3);
            this.grouper1.Controls.Add(this.btnOk);
            this.grouper1.Controls.Add(this.cmbLapsoRecordatorio);
            this.grouper1.Controls.Add(this.linkLabel1);
            this.grouper1.Controls.Add(this.btnCerrar);
            this.grouper1.Controls.Add(this.imagenCambiantePictureBox1);
            this.grouper1.Controls.Add(this.lblDetalle);
            this.grouper1.Controls.Add(this.label1);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "";
            this.grouper1.Location = new System.Drawing.Point(2, -9);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(20);
            this.grouper1.PaintGroupBox = false;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.DimGray;
            this.grouper1.ShadowControl = true;
            this.grouper1.ShadowThickness = 2;
            this.grouper1.Size = new System.Drawing.Size(297, 181);
            this.grouper1.TabIndex = 0;
            this.grouper1.MouseLeave += new System.EventHandler(this.grouper1_MouseLeave);
            this.grouper1.MouseHover += new System.EventHandler(this.grouper1_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lstContactos2);
            this.panel1.Controls.Add(this.lstContactos);
            this.panel1.HoraFinal = System.TimeSpan.Parse("18:00:00");
            this.panel1.HoraInicial = System.TimeSpan.Parse("06:00:00");
            this.panel1.Location = new System.Drawing.Point(10, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 93);
            this.panel1.TabIndex = 16;
            this.panel1.TotalHours = 0;
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            // 
            // lstContactos
            // 
            this.lstContactos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstContactos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstContactos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstContactos.ForeColor = System.Drawing.Color.Black;
            this.lstContactos.FullRowSelect = true;
            this.lstContactos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstContactos.Location = new System.Drawing.Point(8, 6);
            this.lstContactos.Name = "lstContactos";
            this.lstContactos.Size = new System.Drawing.Size(261, 82);
            this.lstContactos.TabIndex = 0;
            this.lstContactos.UseCompatibleStateImageBehavior = false;
            this.lstContactos.View = System.Windows.Forms.View.Details;
            this.lstContactos.MouseEnter += new System.EventHandler(this.lstContactos_MouseEnter);
            this.lstContactos.MouseLeave += new System.EventHandler(this.lstContactos_MouseLeave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tipo";
            this.columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descripción";
            this.columnHeader2.Width = 183;
            // 
            // imagenCambiantePictureBox3
            // 
            this.imagenCambiantePictureBox3.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox3.HighlightedImage")));
            this.imagenCambiantePictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox3.Image")));
            this.imagenCambiantePictureBox3.Location = new System.Drawing.Point(262, 155);
            this.imagenCambiantePictureBox3.Name = "imagenCambiantePictureBox3";
            this.imagenCambiantePictureBox3.Size = new System.Drawing.Size(16, 16);
            this.imagenCambiantePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imagenCambiantePictureBox3.TabIndex = 15;
            this.imagenCambiantePictureBox3.TabStop = false;
            this.imagenCambiantePictureBox3.Visible = false;
            this.imagenCambiantePictureBox3.Click += new System.EventHandler(this.imagenCambiantePictureBox3_Click);
            // 
            // btnOk
            // 
            this.btnOk.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnOk.HighlightedImage")));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(232, 148);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(24, 24);
            this.btnOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnOk.TabIndex = 14;
            this.btnOk.TabStop = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmbLapsoRecordatorio
            // 
            this.cmbLapsoRecordatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLapsoRecordatorio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLapsoRecordatorio.FormattingEnabled = true;
            this.cmbLapsoRecordatorio.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "15",
            "30",
            "45",
            "60"});
            this.cmbLapsoRecordatorio.Location = new System.Drawing.Point(136, 152);
            this.cmbLapsoRecordatorio.Name = "cmbLapsoRecordatorio";
            this.cmbLapsoRecordatorio.Size = new System.Drawing.Size(42, 23);
            this.cmbLapsoRecordatorio.TabIndex = 11;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.White;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(4, 157);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(228, 15);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Recordar de nuevo en                 minutos";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnCerrar
            // 
            this.btnCerrar.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.HighlightedImage")));
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(262, 16);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 24);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.MouseLeave += new System.EventHandler(this.btnCerrar_MouseLeave);
            this.btnCerrar.Click += new System.EventHandler(this.imagenCambiantePictureBox2_Click);
            this.btnCerrar.MouseHover += new System.EventHandler(this.btnCerrar_MouseHover);
            // 
            // imagenCambiantePictureBox1
            // 
            this.imagenCambiantePictureBox1.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox1.HighlightedImage")));
            this.imagenCambiantePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox1.Image")));
            this.imagenCambiantePictureBox1.Location = new System.Drawing.Point(10, 9);
            this.imagenCambiantePictureBox1.Name = "imagenCambiantePictureBox1";
            this.imagenCambiantePictureBox1.Size = new System.Drawing.Size(40, 40);
            this.imagenCambiantePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imagenCambiantePictureBox1.TabIndex = 2;
            this.imagenCambiantePictureBox1.TabStop = false;
            this.imagenCambiantePictureBox1.MouseLeave += new System.EventHandler(this.imagenCambiantePictureBox1_MouseLeave_1);
            this.imagenCambiantePictureBox1.Click += new System.EventHandler(this.imagenCambiantePictureBox1_Click);
            this.imagenCambiantePictureBox1.MouseHover += new System.EventHandler(this.imagenCambiantePictureBox1_MouseHover);
            // 
            // lblDetalle
            // 
            this.lblDetalle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.Location = new System.Drawing.Point(9, 52);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(278, 93);
            this.lblDetalle.TabIndex = 1;
            this.lblDetalle.MouseLeave += new System.EventHandler(this.lblDetalle_MouseLeave);
            this.lblDetalle.MouseHover += new System.EventHandler(this.lblDetalle_MouseHover);
            // 
            // timer1
            // 
            this.timer1.Interval = 7;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerInicio
            // 
            this.timerInicio.Interval = 7;
            this.timerInicio.Tick += new System.EventHandler(this.timerInicio_Tick);
            // 
            // timerEspera
            // 
            this.timerEspera.Interval = 5000;
            this.timerEspera.Tick += new System.EventHandler(this.timerEspera_Tick);
            // 
            // timerCerrar
            // 
            this.timerCerrar.Interval = 2;
            this.timerCerrar.Tick += new System.EventHandler(this.timerCerrar_Tick);
            // 
            // toolTipContactos
            // 
            this.toolTipContactos.AutoPopDelay = 50000;
            this.toolTipContactos.ForeColor = System.Drawing.Color.Black;
            this.toolTipContactos.InitialDelay = 500;
            this.toolTipContactos.IsBalloon = true;
            this.toolTipContactos.ReshowDelay = 100;
            this.toolTipContactos.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipContactos.ToolTipTitle = "Contactos de Paciente";
            // 
            // lstContactos2
            // 
            this.lstContactos2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstContactos2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.lstContactos2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstContactos2.ForeColor = System.Drawing.Color.Black;
            this.lstContactos2.FullRowSelect = true;
            this.lstContactos2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstContactos2.Location = new System.Drawing.Point(8, 6);
            this.lstContactos2.Name = "lstContactos2";
            this.lstContactos2.Size = new System.Drawing.Size(261, 82);
            this.lstContactos2.TabIndex = 1;
            this.lstContactos2.UseCompatibleStateImageBehavior = false;
            this.lstContactos2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Descripción";
            this.columnHeader4.Width = 257;
            // 
            // frmNotificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(303, 175);
            this.ControlBox = false;
            this.Controls.Add(this.grouper1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNotificaciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FloralWhite;
            this.Load += new System.EventHandler(this.frmNotificaciones_Load);
            this.grouper1.ResumeLayout(false);
            this.grouper1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CodeVendor.Controls.Grouper grouper1;
        private ImagenCambiantePictureBox imagenCambiantePictureBox1;
        private System.Windows.Forms.Label lblDetalle;
        private ImagenCambiantePictureBox btnCerrar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timerInicio;
        public System.Windows.Forms.Timer timerEspera;
        private System.Windows.Forms.Timer timerCerrar;
        private System.Windows.Forms.ComboBox cmbLapsoRecordatorio;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private ImagenCambiantePictureBox btnOk;
        private ImagenCambiantePictureBox imagenCambiantePictureBox3;
        private System.Windows.Forms.ToolTip toolTipContactos;
        private System.Windows.Forms.ListView lstContactos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private PanelAvailableHours panel1;
        private System.Windows.Forms.ListView lstContactos2;
        private System.Windows.Forms.ColumnHeader columnHeader4;

    }
}