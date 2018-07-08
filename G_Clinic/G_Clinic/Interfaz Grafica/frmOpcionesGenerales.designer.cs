namespace G_Clinic
{
    partial class frmOpcionesGenerales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpcionesGenerales));
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVarios = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdVarios = new System.Windows.Forms.RadioButton();
            this.rdUnoDoctor = new System.Windows.Forms.RadioButton();
            this.rdUnico = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.dtRecordatorioEmail = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // dtFinal
            // 
            this.dtFinal.CustomFormat = "hh:mm tt";
            this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFinal.Location = new System.Drawing.Point(168, 61);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.ShowUpDown = true;
            this.dtFinal.Size = new System.Drawing.Size(75, 20);
            this.dtFinal.TabIndex = 7;
            // 
            // dtInicio
            // 
            this.dtInicio.CustomFormat = "hh:mm tt";
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicio.Location = new System.Drawing.Point(56, 61);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.ShowUpDown = true;
            this.dtInicio.Size = new System.Drawing.Size(75, 20);
            this.dtInicio.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtVarios);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.rdVarios);
            this.groupBox1.Controls.Add(this.rdUnoDoctor);
            this.groupBox1.Controls.Add(this.rdUnico);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Location = new System.Drawing.Point(8, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 134);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el Total de cubículos";
            // 
            // txtVarios
            // 
            this.txtVarios.Enabled = false;
            this.txtVarios.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVarios.ForeColor = System.Drawing.Color.Red;
            this.txtVarios.Location = new System.Drawing.Point(313, 97);
            this.txtVarios.MaxLength = 2;
            this.txtVarios.Name = "txtVarios";
            this.txtVarios.Size = new System.Drawing.Size(34, 22);
            this.txtVarios.TabIndex = 3;
            this.txtVarios.Text = "0";
            this.txtVarios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.label1.Location = new System.Drawing.Point(28, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Especifique el número de cubículos disponibles:";
            // 
            // rdVarios
            // 
            this.rdVarios.AutoSize = true;
            this.rdVarios.Enabled = false;
            this.rdVarios.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdVarios.ForeColor = System.Drawing.Color.Black;
            this.rdVarios.Location = new System.Drawing.Point(18, 78);
            this.rdVarios.Name = "rdVarios";
            this.rdVarios.Size = new System.Drawing.Size(120, 19);
            this.rdVarios.TabIndex = 2;
            this.rdVarios.TabStop = true;
            this.rdVarios.Text = "Varios cubículos";
            this.rdVarios.UseVisualStyleBackColor = true;
            this.rdVarios.CheckedChanged += new System.EventHandler(this.rdVarios_CheckedChanged);
            // 
            // rdUnoDoctor
            // 
            this.rdUnoDoctor.AutoSize = true;
            this.rdUnoDoctor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdUnoDoctor.ForeColor = System.Drawing.Color.Black;
            this.rdUnoDoctor.Location = new System.Drawing.Point(18, 26);
            this.rdUnoDoctor.Name = "rdUnoDoctor";
            this.rdUnoDoctor.Size = new System.Drawing.Size(153, 19);
            this.rdUnoDoctor.TabIndex = 1;
            this.rdUnoDoctor.TabStop = true;
            this.rdUnoDoctor.Text = "Un cubículo por doctor";
            this.rdUnoDoctor.UseVisualStyleBackColor = true;
            // 
            // rdUnico
            // 
            this.rdUnico.AutoSize = true;
            this.rdUnico.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdUnico.ForeColor = System.Drawing.Color.Black;
            this.rdUnico.Location = new System.Drawing.Point(18, 52);
            this.rdUnico.Name = "rdUnico";
            this.rdUnico.Size = new System.Drawing.Size(163, 19);
            this.rdUnico.TabIndex = 0;
            this.rdUnico.TabStop = true;
            this.rdUnico.Text = "Un solo cubículo en total";
            this.rdUnico.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "De las                     a las";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Especifique el horario de su clínica:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.HighlightedImage")));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(296, 17);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(58, 67);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Listo";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(269, -1);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(108, 106);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 26;
            this.pictureBox6.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(374, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "Enviar recordatorios por correo electrónico a las                            ?";
            // 
            // dtRecordatorioEmail
            // 
            this.dtRecordatorioEmail.CustomFormat = "hh:mm tt";
            this.dtRecordatorioEmail.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRecordatorioEmail.Location = new System.Drawing.Point(296, 110);
            this.dtRecordatorioEmail.Name = "dtRecordatorioEmail";
            this.dtRecordatorioEmail.ShowUpDown = true;
            this.dtRecordatorioEmail.Size = new System.Drawing.Size(75, 20);
            this.dtRecordatorioEmail.TabIndex = 29;
            // 
            // frmOpcionesGenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(390, 282);
            this.Controls.Add(this.dtRecordatorioEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtFinal);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOpcionesGenerales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opciones Generales de Citas";
            this.Load += new System.EventHandler(this.frmOpcionesGenerales_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOpcionesGenerales_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFinal;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtVarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdVarios;
        private System.Windows.Forms.RadioButton rdUnoDoctor;
        private System.Windows.Forms.RadioButton rdUnico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel btnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtRecordatorioEmail;
    }
}