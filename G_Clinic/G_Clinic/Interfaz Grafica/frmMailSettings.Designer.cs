namespace G_Clinic.Interfaz_Grafica
{
    partial class frmMailSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMailSettings));
            this.imagenCambiantePictureBox1 = new G_Clinic.ImagenCambiantePictureBox();
            this.mailSettings1 = new G_Clinic.Miscelaneos_y_Recursos.MailSettings();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imagenCambiantePictureBox1
            // 
            this.imagenCambiantePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.imagenCambiantePictureBox1.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox1.HighlightedImage")));
            this.imagenCambiantePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox1.Image")));
            this.imagenCambiantePictureBox1.ImagenOriginal = ((System.Drawing.Image)(resources.GetObject("imagenCambiantePictureBox1.ImagenOriginal")));
            this.imagenCambiantePictureBox1.Location = new System.Drawing.Point(269, -1);
            this.imagenCambiantePictureBox1.Name = "imagenCambiantePictureBox1";
            this.imagenCambiantePictureBox1.Size = new System.Drawing.Size(42, 17);
            this.imagenCambiantePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imagenCambiantePictureBox1.TabIndex = 118;
            this.imagenCambiantePictureBox1.TabStop = false;
            this.imagenCambiantePictureBox1.Click += new System.EventHandler(this.imagenCambiantePictureBox1_Click);
            // 
            // mailSettings1
            // 
            this.mailSettings1.BackColor = System.Drawing.Color.Transparent;
            this.mailSettings1.HideParent = true;
            this.mailSettings1.Location = new System.Drawing.Point(12, 9);
            this.mailSettings1.Name = "mailSettings1";
            this.mailSettings1.Size = new System.Drawing.Size(324, 278);
            this.mailSettings1.TabIndex = 0;
            // 
            // frmMailSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(342, 299);
            this.Controls.Add(this.imagenCambiantePictureBox1);
            this.Controls.Add(this.mailSettings1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMailSettings";
            this.Opacity = 0.96D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmMailSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagenCambiantePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private G_Clinic.Miscelaneos_y_Recursos.MailSettings mailSettings1;
        private ImagenCambiantePictureBox imagenCambiantePictureBox1;
    }
}