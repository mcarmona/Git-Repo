namespace G_Clinic.Interfaz_Grafica
{
    partial class frmPDFViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPDFViewer));
            this.softNet_AdobePDFViewer1 = new G_Clinic.Miscelaneos_y_Recursos.SoftNet_AdobePDFViewer_original();
            this.imagenCambiantePictureBox1 = new G_Clinic.ImagenCambiantePictureBox();
            this.imagenCambiantePictureBox2 = new G_Clinic.ImagenCambiantePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // softNet_AdobePDFViewer1
            // 
            this.softNet_AdobePDFViewer1.BackColor = System.Drawing.Color.Black;
            this.softNet_AdobePDFViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.softNet_AdobePDFViewer1.FileLocation = "";
            this.softNet_AdobePDFViewer1.Location = new System.Drawing.Point(0, 0);
            this.softNet_AdobePDFViewer1.Name = "softNet_AdobePDFViewer1";
            this.softNet_AdobePDFViewer1.Size = new System.Drawing.Size(561, 730);
            this.softNet_AdobePDFViewer1.TabIndex = 0;
            this.softNet_AdobePDFViewer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.softNet_AdobePDFViewer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.softNet_AdobePDFViewer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // imagenCambiantePictureBox1
            // 
            this.imagenCambiantePictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imagenCambiantePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.imagenCambiantePictureBox1.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox1.HighlightedImage")));
            this.imagenCambiantePictureBox1.Image = global::G_Clinic.Properties.Resources.close;
            this.imagenCambiantePictureBox1.Location = new System.Drawing.Point(496, 0);
            this.imagenCambiantePictureBox1.Name = "imagenCambiantePictureBox1";
            this.imagenCambiantePictureBox1.Size = new System.Drawing.Size(42, 17);
            this.imagenCambiantePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imagenCambiantePictureBox1.TabIndex = 279;
            this.imagenCambiantePictureBox1.TabStop = false;
            this.imagenCambiantePictureBox1.Visible = false;
            this.imagenCambiantePictureBox1.Click += new System.EventHandler(this.imagenCambiantePictureBox1_Click);
            // 
            // imagenCambiantePictureBox2
            // 
            this.imagenCambiantePictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imagenCambiantePictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.imagenCambiantePictureBox2.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox2.HighlightedImage")));
            this.imagenCambiantePictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox2.Image")));
            this.imagenCambiantePictureBox2.Location = new System.Drawing.Point(473, 0);
            this.imagenCambiantePictureBox2.Name = "imagenCambiantePictureBox2";
            this.imagenCambiantePictureBox2.Size = new System.Drawing.Size(24, 16);
            this.imagenCambiantePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imagenCambiantePictureBox2.TabIndex = 280;
            this.imagenCambiantePictureBox2.TabStop = false;
            this.imagenCambiantePictureBox2.Visible = false;
            this.imagenCambiantePictureBox2.Click += new System.EventHandler(this.imagenCambiantePictureBox2_Click);
            // 
            // frmPDFViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(561, 730);
            this.Controls.Add(this.imagenCambiantePictureBox2);
            this.Controls.Add(this.imagenCambiantePictureBox1);
            this.Controls.Add(this.softNet_AdobePDFViewer1);
            this.Name = "frmPDFViewer";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.frmPDFViewer_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Miscelaneos_y_Recursos.SoftNet_AdobePDFViewer_original softNet_AdobePDFViewer1;
        private ImagenCambiantePictureBox imagenCambiantePictureBox1;
        private ImagenCambiantePictureBox imagenCambiantePictureBox2;
    }
}