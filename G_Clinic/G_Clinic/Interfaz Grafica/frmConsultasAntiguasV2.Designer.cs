namespace G_Clinic.Interfaz_Grafica
{
    partial class frmConsultasAntiguasV2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultasAntiguasV2));
            this.panelOpciones = new System.Windows.Forms.Panel();
            this.imagenCambianteLabel1 = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnAnterior = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnConvertirPDF = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.softNet_IMGtoPDF1 = new G_Clinic.Miscelaneos_y_Recursos.SoftNet_IMGtoPDF();
            this.btnGuardar = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFechaConsulta = new System.Windows.Forms.DateTimePicker();
            this.txtDetallesAdicionales = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNumExpediente = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.imagenCambiantePictureBox1 = new G_Clinic.ImagenCambiantePictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tobBuscarPaciente = new System.Windows.Forms.ToolStripButton();
            this.panelBuscarPaciente = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtNumExpediente = new AMS.TextBox.NumericTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.panelBuscarPaciente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelOpciones
            // 
            this.panelOpciones.BackColor = System.Drawing.Color.Transparent;
            this.panelOpciones.Controls.Add(this.imagenCambianteLabel1);
            this.panelOpciones.Controls.Add(this.btnAnterior);
            this.panelOpciones.Controls.Add(this.btnConvertirPDF);
            this.panelOpciones.Controls.Add(this.softNet_IMGtoPDF1);
            this.panelOpciones.Controls.Add(this.btnGuardar);
            this.panelOpciones.Controls.Add(this.label2);
            this.panelOpciones.Controls.Add(this.dtFechaConsulta);
            this.panelOpciones.Controls.Add(this.txtDetallesAdicionales);
            this.panelOpciones.Controls.Add(this.label1);
            this.panelOpciones.Location = new System.Drawing.Point(12, 99);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Size = new System.Drawing.Size(1544, 611);
            this.panelOpciones.TabIndex = 2;
            // 
            // imagenCambianteLabel1
            // 
            this.imagenCambianteLabel1.BackColor = System.Drawing.Color.Transparent;
            this.imagenCambianteLabel1.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("imagenCambianteLabel1.HighlightedImage")));
            this.imagenCambianteLabel1.Image = ((System.Drawing.Image)(resources.GetObject("imagenCambianteLabel1.Image")));
            this.imagenCambianteLabel1.Location = new System.Drawing.Point(430, 504);
            this.imagenCambianteLabel1.Name = "imagenCambianteLabel1";
            this.imagenCambianteLabel1.Size = new System.Drawing.Size(66, 70);
            this.imagenCambianteLabel1.TabIndex = 279;
            this.imagenCambianteLabel1.Click += new System.EventHandler(this.imagenCambianteLabel1_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.Color.Transparent;
            this.btnAnterior.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnAnterior.HighlightedImage")));
            this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
            this.btnAnterior.Location = new System.Drawing.Point(1018, 504);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(86, 95);
            this.btnAnterior.TabIndex = 9;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnConvertirPDF
            // 
            this.btnConvertirPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertirPDF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertirPDF.ForeColor = System.Drawing.Color.White;
            this.btnConvertirPDF.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnConvertirPDF.HighlightedImage")));
            this.btnConvertirPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnConvertirPDF.Image")));
            this.btnConvertirPDF.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConvertirPDF.Location = new System.Drawing.Point(407, 78);
            this.btnConvertirPDF.Name = "btnConvertirPDF";
            this.btnConvertirPDF.Size = new System.Drawing.Size(97, 101);
            this.btnConvertirPDF.TabIndex = 8;
            this.btnConvertirPDF.Text = "Convertir a PDF";
            this.btnConvertirPDF.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConvertirPDF.Click += new System.EventHandler(this.btnConvertirPDF_Click);
            // 
            // softNet_IMGtoPDF1
            // 
            this.softNet_IMGtoPDF1.BackColor = System.Drawing.Color.Transparent;
            this.softNet_IMGtoPDF1.ConvertButtonVisible = true;
            this.softNet_IMGtoPDF1.Location = new System.Drawing.Point(3, 6);
            this.softNet_IMGtoPDF1.Name = "softNet_IMGtoPDF1";
            this.softNet_IMGtoPDF1.Size = new System.Drawing.Size(999, 604);
            this.softNet_IMGtoPDF1.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.HighlightedImage")));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(1440, 487);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(86, 102);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1012, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Detalles Adicionales:";
            // 
            // dtFechaConsulta
            // 
            this.dtFechaConsulta.Location = new System.Drawing.Point(1133, 31);
            this.dtFechaConsulta.Name = "dtFechaConsulta";
            this.dtFechaConsulta.Size = new System.Drawing.Size(200, 20);
            this.dtFechaConsulta.TabIndex = 4;
            // 
            // txtDetallesAdicionales
            // 
            this.txtDetallesAdicionales.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetallesAdicionales.Location = new System.Drawing.Point(1133, 69);
            this.txtDetallesAdicionales.Multiline = true;
            this.txtDetallesAdicionales.Name = "txtDetallesAdicionales";
            this.txtDetallesAdicionales.Size = new System.Drawing.Size(394, 522);
            this.txtDetallesAdicionales.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1012, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha de Consulta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(24, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "ID Paciente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(237, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nombre:";
            // 
            // lblNumExpediente
            // 
            this.lblNumExpediente.AutoSize = true;
            this.lblNumExpediente.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumExpediente.ForeColor = System.Drawing.Color.Gold;
            this.lblNumExpediente.Location = new System.Drawing.Point(104, 64);
            this.lblNumExpediente.Name = "lblNumExpediente";
            this.lblNumExpediente.Size = new System.Drawing.Size(0, 20);
            this.lblNumExpediente.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Gold;
            this.lblNombre.Location = new System.Drawing.Point(300, 64);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 20);
            this.lblNombre.TabIndex = 4;
            // 
            // imagenCambiantePictureBox1
            // 
            this.imagenCambiantePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.imagenCambiantePictureBox1.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox1.HighlightedImage")));
            this.imagenCambiantePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox1.Image")));
            this.imagenCambiantePictureBox1.Location = new System.Drawing.Point(969, 3);
            this.imagenCambiantePictureBox1.Name = "imagenCambiantePictureBox1";
            this.imagenCambiantePictureBox1.Size = new System.Drawing.Size(48, 48);
            this.imagenCambiantePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imagenCambiantePictureBox1.TabIndex = 278;
            this.imagenCambiantePictureBox1.TabStop = false;
            this.imagenCambiantePictureBox1.Click += new System.EventHandler(this.imagenCambiantePictureBox1_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(644, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 2);
            this.label10.TabIndex = 280;
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
            this.toolStrip2.Location = new System.Drawing.Point(647, 6);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(51, 60);
            this.toolStrip2.TabIndex = 279;
            this.toolStrip2.Text = "toolStrip2";
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
            // panelBuscarPaciente
            // 
            this.panelBuscarPaciente.Controls.Add(this.label5);
            this.panelBuscarPaciente.Controls.Add(this.TxtNombre);
            this.panelBuscarPaciente.Controls.Add(this.label6);
            this.panelBuscarPaciente.Controls.Add(this.TxtNumExpediente);
            this.panelBuscarPaciente.Controls.Add(this.label10);
            this.panelBuscarPaciente.Controls.Add(this.toolStrip2);
            this.panelBuscarPaciente.Location = new System.Drawing.Point(17, 49);
            this.panelBuscarPaciente.Name = "panelBuscarPaciente";
            this.panelBuscarPaciente.Size = new System.Drawing.Size(727, 67);
            this.panelBuscarPaciente.TabIndex = 280;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(243, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 284;
            this.label5.Text = "Paciente:";
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.Color.White;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.ForeColor = System.Drawing.Color.Black;
            this.TxtNombre.Location = new System.Drawing.Point(304, 25);
            this.TxtNombre.MaxLength = 65;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.ReadOnly = true;
            this.TxtNombre.Size = new System.Drawing.Size(336, 20);
            this.TxtNombre.TabIndex = 282;
            this.TxtNombre.Tag = "nombre";
            this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(21, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 16);
            this.label6.TabIndex = 283;
            this.label6.Text = "N° de Expediente:";
            // 
            // TxtNumExpediente
            // 
            this.TxtNumExpediente.AllowNegative = false;
            this.TxtNumExpediente.BackColor = System.Drawing.Color.White;
            this.TxtNumExpediente.DigitsInGroup = 0;
            this.TxtNumExpediente.Flags = 65536;
            this.TxtNumExpediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumExpediente.ForeColor = System.Drawing.Color.Red;
            this.TxtNumExpediente.Location = new System.Drawing.Point(149, 19);
            this.TxtNumExpediente.MaxDecimalPlaces = 0;
            this.TxtNumExpediente.MaxLength = 8;
            this.TxtNumExpediente.MaxWholeDigits = 9;
            this.TxtNumExpediente.Name = "TxtNumExpediente";
            this.TxtNumExpediente.Prefix = "";
            this.TxtNumExpediente.RangeMax = 1.7976931348623157E+308D;
            this.TxtNumExpediente.RangeMin = -1.7976931348623157E+308D;
            this.TxtNumExpediente.ReadOnly = true;
            this.TxtNumExpediente.Size = new System.Drawing.Size(82, 29);
            this.TxtNumExpediente.TabIndex = 281;
            this.TxtNumExpediente.Tag = "num_expediente";
            this.TxtNumExpediente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtNumExpediente.TextChanged += new System.EventHandler(this.TxtNumExpediente_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(303, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(419, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 280;
            this.pictureBox1.TabStop = false;
            // 
            // frmConsultasAntiguasV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1025, 706);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelBuscarPaciente);
            this.Controls.Add(this.imagenCambiantePictureBox1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblNumExpediente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelOpciones);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultasAntiguasV2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consultas Antiguas";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.Load += new System.EventHandler(this.frmConsultasAntiguas_Load);
            this.panelOpciones.ResumeLayout(false);
            this.panelOpciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panelBuscarPaciente.ResumeLayout(false);
            this.panelBuscarPaciente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelOpciones;
        private Miscelaneos_y_Recursos.ImagenCambianteLabel btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFechaConsulta;
        private System.Windows.Forms.TextBox txtDetallesAdicionales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNumExpediente;
        private System.Windows.Forms.Label lblNombre;
        private ImagenCambiantePictureBox imagenCambiantePictureBox1;
        private Miscelaneos_y_Recursos.SoftNet_IMGtoPDF softNet_IMGtoPDF1;
        private Miscelaneos_y_Recursos.ImagenCambianteLabel btnAnterior;
        private Miscelaneos_y_Recursos.ImagenCambianteLabel btnConvertirPDF;
        private Miscelaneos_y_Recursos.ImagenCambianteLabel imagenCambianteLabel1;
        private System.Windows.Forms.Panel panelBuscarPaciente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tobBuscarPaciente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label6;
        public AMS.TextBox.NumericTextBox TxtNumExpediente;
        private System.Windows.Forms.PictureBox pictureBox1;



    }
}