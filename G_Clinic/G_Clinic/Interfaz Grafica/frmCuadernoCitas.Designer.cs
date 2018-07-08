namespace G_Clinic.Interfaz_Grafica
{
    partial class frmCuadernoCitas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuadernoCitas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tobNuevaCita = new System.Windows.Forms.ToolStripButton();
            this.imagenCambiantePictureBox1 = new G_Clinic.ImagenCambiantePictureBox();
            this.lblFecha1 = new System.Windows.Forms.Label();
            this.lblFecha2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.pictPrioridad = new System.Windows.Forms.PictureBox();
            this.lblDetalleCita = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).BeginInit();
            this.grouper1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictPrioridad)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 682);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.grouper1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Controls.Add(this.imagenCambiantePictureBox1);
            this.panel2.Controls.Add(this.lblFecha1);
            this.panel2.Controls.Add(this.lblFecha2);
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1071, 677);
            this.panel2.TabIndex = 156;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(-64, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 261;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 4);
            this.label1.TabIndex = 260;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobNuevaCita});
            this.toolStrip1.Location = new System.Drawing.Point(327, 23);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(171, 55);
            this.toolStrip1.TabIndex = 259;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tobNuevaCita
            // 
            this.tobNuevaCita.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobNuevaCita.ForeColor = System.Drawing.Color.Black;
            this.tobNuevaCita.Image = ((System.Drawing.Image)(resources.GetObject("tobNuevaCita.Image")));
            this.tobNuevaCita.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tobNuevaCita.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobNuevaCita.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobNuevaCita.Name = "tobNuevaCita";
            this.tobNuevaCita.Size = new System.Drawing.Size(168, 52);
            this.tobNuevaCita.Text = "Generar Nueva Cita";
            this.tobNuevaCita.ToolTipText = "Generar Nueva Cita";
            this.tobNuevaCita.Click += new System.EventHandler(this.tobNuevaCita_Click);
            // 
            // imagenCambiantePictureBox1
            // 
            this.imagenCambiantePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.imagenCambiantePictureBox1.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox1.HighlightedImage")));
            this.imagenCambiantePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox1.Image")));
            this.imagenCambiantePictureBox1.Location = new System.Drawing.Point(1042, 652);
            this.imagenCambiantePictureBox1.Name = "imagenCambiantePictureBox1";
            this.imagenCambiantePictureBox1.Size = new System.Drawing.Size(16, 16);
            this.imagenCambiantePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imagenCambiantePictureBox1.TabIndex = 163;
            this.imagenCambiantePictureBox1.TabStop = false;
            this.imagenCambiantePictureBox1.Click += new System.EventHandler(this.imagenCambiantePictureBox1_Click);
            // 
            // lblFecha1
            // 
            this.lblFecha1.AutoSize = true;
            this.lblFecha1.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha1.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha1.ForeColor = System.Drawing.Color.Red;
            this.lblFecha1.Location = new System.Drawing.Point(40, 24);
            this.lblFecha1.Name = "lblFecha1";
            this.lblFecha1.Size = new System.Drawing.Size(185, 39);
            this.lblFecha1.TabIndex = 3;
            this.lblFecha1.Text = "27 Julio 2010";
            // 
            // lblFecha2
            // 
            this.lblFecha2.AutoSize = true;
            this.lblFecha2.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha2.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha2.ForeColor = System.Drawing.Color.Red;
            this.lblFecha2.Location = new System.Drawing.Point(570, 24);
            this.lblFecha2.Name = "lblFecha2";
            this.lblFecha2.Size = new System.Drawing.Size(185, 39);
            this.lblFecha2.TabIndex = 3;
            this.lblFecha2.Text = "28 Julio 2010";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd MMMM yyyy";
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(347, 36);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(114, 20);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd MMMM yyyy";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(595, 36);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(114, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Enabled = false;
            this.monthCalendar1.Location = new System.Drawing.Point(222, 83);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.Color.White;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.LightSteelBlue;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            this.grouper1.BorderColor = System.Drawing.Color.Black;
            this.grouper1.BorderThickness = 1F;
            this.grouper1.Controls.Add(this.label11);
            this.grouper1.Controls.Add(this.lblPrioridad);
            this.grouper1.Controls.Add(this.pictPrioridad);
            this.grouper1.Controls.Add(this.lblDetalleCita);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "";
            this.grouper1.Location = new System.Drawing.Point(103, 112);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(20);
            this.grouper1.PaintGroupBox = false;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.DimGray;
            this.grouper1.ShadowControl = true;
            this.grouper1.ShadowThickness = 3;
            this.grouper1.Size = new System.Drawing.Size(228, 267);
            this.grouper1.TabIndex = 262;
            this.grouper1.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(45, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Prioridad:";
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrioridad.ForeColor = System.Drawing.Color.Red;
            this.lblPrioridad.Location = new System.Drawing.Point(114, 26);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(0, 16);
            this.lblPrioridad.TabIndex = 2;
            // 
            // pictPrioridad
            // 
            this.pictPrioridad.Location = new System.Drawing.Point(15, 22);
            this.pictPrioridad.Name = "pictPrioridad";
            this.pictPrioridad.Size = new System.Drawing.Size(24, 24);
            this.pictPrioridad.TabIndex = 1;
            this.pictPrioridad.TabStop = false;
            // 
            // lblDetalleCita
            // 
            this.lblDetalleCita.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleCita.ForeColor = System.Drawing.Color.Black;
            this.lblDetalleCita.Location = new System.Drawing.Point(10, 67);
            this.lblDetalleCita.Name = "lblDetalleCita";
            this.lblDetalleCita.Size = new System.Drawing.Size(204, 190);
            this.lblDetalleCita.TabIndex = 0;
            // 
            // frmCuadernoCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(1079, 681);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCuadernoCitas";
            this.Opacity = 0.95;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuaderno de Citas";
            this.TransparencyKey = System.Drawing.Color.LightGray;
            this.Load += new System.EventHandler(this.frmCuadernoCitas_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).EndInit();
            this.grouper1.ResumeLayout(false);
            this.grouper1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictPrioridad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFecha2;
        private System.Windows.Forms.Label lblFecha1;
        private System.Windows.Forms.Panel panel2;
        private ImagenCambiantePictureBox imagenCambiantePictureBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tobNuevaCita;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private CodeVendor.Controls.Grouper grouper1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.PictureBox pictPrioridad;
        private System.Windows.Forms.Label lblDetalleCita;
    }
}