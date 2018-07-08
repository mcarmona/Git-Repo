namespace G_Clinic.Interfaz_Grafica
{
    partial class TestForm1
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.softNet_IMGtoPDF1 = new G_Clinic.Miscelaneos_y_Recursos.SoftNet_IMGtoPDF();
            this.SuspendLayout();
            // 
            // softNet_IMGtoPDF1
            // 
            this.softNet_IMGtoPDF1.Location = new System.Drawing.Point(12, 12);
            this.softNet_IMGtoPDF1.Name = "softNet_IMGtoPDF1";
            this.softNet_IMGtoPDF1.Size = new System.Drawing.Size(1258, 622);
            this.softNet_IMGtoPDF1.TabIndex = 0;
            // 
            // TestForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 637);
            this.Controls.Add(this.softNet_IMGtoPDF1);
            this.Name = "TestForm1";
            this.Text = "TestForm1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private Miscelaneos_y_Recursos.SoftNet_IMGtoPDF softNet_IMGtoPDF1;


    }
}