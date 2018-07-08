namespace G_Clinic.Miscelaneos_y_Recursos
{
    partial class SotNet_PictToPDF
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SotNet_PictToPDF));
            this.pdfViewer1 = new G_Clinic.Miscelaneos_y_Recursos.PDFViewer();
            this.softNetImageViewer1 = new G_Clinic.Miscelaneos_y_Recursos.SoftNetImageViewer();
            this.SuspendLayout();
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pdfViewer1.Location = new System.Drawing.Point(655, 8);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(454, 603);
            this.pdfViewer1.TabIndex = 10;
            // 
            // softNetImageViewer1
            // 
            this.softNetImageViewer1.Location = new System.Drawing.Point(0, 0);
            this.softNetImageViewer1.Name = "softNetImageViewer1";
            this.softNetImageViewer1.Nuevo = false;
            this.softNetImageViewer1.PictSize = new System.Drawing.Size(180, 180);
            this.softNetImageViewer1.Size = new System.Drawing.Size(478, 555);
            this.softNetImageViewer1.TabIndex = 0;
            // 
            // SotNet_PictToPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pdfViewer1);
            this.Name = "SotNet_PictToPDF";
            this.Size = new System.Drawing.Size(1130, 622);
            this.ResumeLayout(false);

        }

        #endregion

        private PDFViewer pdfViewer1;
        private SoftNetImageViewer softNetImageViewer1;

    }
}
