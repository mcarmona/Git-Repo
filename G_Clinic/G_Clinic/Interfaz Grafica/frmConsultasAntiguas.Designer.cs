namespace G_Clinic.Interfaz_Grafica
{
    partial class frmConsultasAntiguas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultasAntiguas));
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
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.panelOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).BeginInit();
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
            this.panelOpciones.Location = new System.Drawing.Point(17, 54);
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
            this.btnGuardar.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.HighlightedImage")));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(1438, 508);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(86, 79);
            this.btnGuardar.TabIndex = 6;
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
            this.label3.Location = new System.Drawing.Point(24, 20);
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
            this.label4.Location = new System.Drawing.Point(237, 20);
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
            this.lblNumExpediente.Location = new System.Drawing.Point(104, 19);
            this.lblNumExpediente.Name = "lblNumExpediente";
            this.lblNumExpediente.Size = new System.Drawing.Size(0, 20);
            this.lblNumExpediente.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Gold;
            this.lblNombre.Location = new System.Drawing.Point(300, 19);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 20);
            this.lblNombre.TabIndex = 4;
            // 
            // imagenCambiantePictureBox1
            // 
            this.imagenCambiantePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.imagenCambiantePictureBox1.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox1.HighlightedImage")));
            this.imagenCambiantePictureBox1.Image = global::G_Clinic.Properties.Resources.close;
            this.imagenCambiantePictureBox1.Location = new System.Drawing.Point(962, 0);
            this.imagenCambiantePictureBox1.Name = "imagenCambiantePictureBox1";
            this.imagenCambiantePictureBox1.Size = new System.Drawing.Size(42, 17);
            this.imagenCambiantePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imagenCambiantePictureBox1.TabIndex = 278;
            this.imagenCambiantePictureBox1.TabStop = false;
            this.imagenCambiantePictureBox1.Click += new System.EventHandler(this.imagenCambiantePictureBox1_Click);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.miniToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(38, 38);
            this.miniToolStrip.Location = new System.Drawing.Point(48, 20);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.miniToolStrip.Size = new System.Drawing.Size(51, 60);
            this.miniToolStrip.TabIndex = 279;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(38, 38);
            this.toolStrip2.Location = new System.Drawing.Point(608, 6);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(51, 60);
            this.toolStrip2.TabIndex = 279;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // frmConsultasAntiguas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1025, 671);
            this.Controls.Add(this.imagenCambiantePictureBox1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblNumExpediente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelOpciones);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultasAntiguas";
            this.Opacity = 0.92D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas Antiguas";
            this.Load += new System.EventHandler(this.frmConsultasAntiguas_Load);
            this.panelOpciones.ResumeLayout(false);
            this.panelOpciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).EndInit();
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
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStrip toolStrip2;



    }
}