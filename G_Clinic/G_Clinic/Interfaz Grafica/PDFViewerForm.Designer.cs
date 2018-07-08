namespace G_Clinic.Interfaz_Grafica
{
    partial class PDFViewerForm
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
            this.pdfViewer1 = new G_Clinic.Miscelaneos_y_Recursos.PDFViewer();
            this.SuspendLayout();
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(550, 560);
            this.pdfViewer1.TabIndex = 0;
            // 
            // PDFViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 560);
            this.Controls.Add(this.pdfViewer1);
            this.Name = "PDFViewerForm";
            this.Text = "SoftNet - PDFViewer";
            this.Load += new System.EventHandler(this.PDFViewerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private G_Clinic.Miscelaneos_y_Recursos.PDFViewer pdfViewer1;
    }
}