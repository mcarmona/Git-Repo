namespace G_Clinic.Miscelaneos_y_Recursos
{
    partial class SoftNet_IMGtoPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftNet_IMGtoPDF));
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelConvertAndSave = new System.Windows.Forms.Panel();
            this.softNet_AdobePDFViewer1 = new G_Clinic.Miscelaneos_y_Recursos.SoftNet_AdobePDFViewer_original();
            this.panelLoadImages = new System.Windows.Forms.Panel();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnConvertirPDF = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.softNetImageViewer3 = new G_Clinic.Miscelaneos_y_Recursos.SoftNetImageViewer();
            this.oPicLoading = new System.Windows.Forms.PictureBox();
            this.btnAgregarImagen = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.panel1.SuspendLayout();
            this.PanelConvertAndSave.SuspendLayout();
            this.panelLoadImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oPicLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.PanelConvertAndSave);
            this.panel1.Controls.Add(this.panelLoadImages);
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 614);
            this.panel1.TabIndex = 1;
            // 
            // PanelConvertAndSave
            // 
            this.PanelConvertAndSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PanelConvertAndSave.Controls.Add(this.softNet_AdobePDFViewer1);
            this.PanelConvertAndSave.Location = new System.Drawing.Point(514, 3);
            this.PanelConvertAndSave.Name = "PanelConvertAndSave";
            this.PanelConvertAndSave.Size = new System.Drawing.Size(469, 604);
            this.PanelConvertAndSave.TabIndex = 6;
            // 
            // softNet_AdobePDFViewer1
            // 
            this.softNet_AdobePDFViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.softNet_AdobePDFViewer1.BackColor = System.Drawing.Color.Black;
            this.softNet_AdobePDFViewer1.FileLocation = "";
            this.softNet_AdobePDFViewer1.Location = new System.Drawing.Point(2, 7);
            this.softNet_AdobePDFViewer1.Name = "softNet_AdobePDFViewer1";
            this.softNet_AdobePDFViewer1.Size = new System.Drawing.Size(464, 594);
            this.softNet_AdobePDFViewer1.TabIndex = 0;
            // 
            // panelLoadImages
            // 
            this.panelLoadImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLoadImages.Controls.Add(this.lblProcesando);
            this.panelLoadImages.Controls.Add(this.label1);
            this.panelLoadImages.Controls.Add(this.listView1);
            this.panelLoadImages.Controls.Add(this.btnBrowseFolder);
            this.panelLoadImages.Controls.Add(this.textBox1);
            this.panelLoadImages.Controls.Add(this.btnConvertirPDF);
            this.panelLoadImages.Controls.Add(this.softNetImageViewer3);
            this.panelLoadImages.Controls.Add(this.oPicLoading);
            this.panelLoadImages.Location = new System.Drawing.Point(3, 3);
            this.panelLoadImages.Name = "panelLoadImages";
            this.panelLoadImages.Size = new System.Drawing.Size(504, 604);
            this.panelLoadImages.TabIndex = 0;
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.ForeColor = System.Drawing.Color.White;
            this.lblProcesando.Location = new System.Drawing.Point(405, 200);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(73, 13);
            this.lblProcesando.TabIndex = 12;
            this.lblProcesando.Text = "Procesando...";
            this.lblProcesando.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Seleccione las imágenes que desea convertir a archivo PDF...";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 63);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(368, 524);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nombre de Archivo";
            this.columnHeader1.Width = 364;
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseFolder.Location = new System.Drawing.Point(447, 33);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(33, 23);
            this.btnBrowseFolder.TabIndex = 9;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(433, 20);
            this.textBox1.TabIndex = 8;
            // 
            // btnConvertirPDF
            // 
            this.btnConvertirPDF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertirPDF.ForeColor = System.Drawing.Color.White;
            this.btnConvertirPDF.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnConvertirPDF.HighlightedImage")));
            this.btnConvertirPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnConvertirPDF.Image")));
            this.btnConvertirPDF.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConvertirPDF.Location = new System.Drawing.Point(393, 63);
            this.btnConvertirPDF.Name = "btnConvertirPDF";
            this.btnConvertirPDF.Size = new System.Drawing.Size(97, 101);
            this.btnConvertirPDF.TabIndex = 7;
            this.btnConvertirPDF.Text = "Convertir a PDF";
            this.btnConvertirPDF.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConvertirPDF.Click += new System.EventHandler(this.btnConvertirPDF_Click);
            // 
            // softNetImageViewer3
            // 
            this.softNetImageViewer3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.softNetImageViewer3.Enabled = false;
            this.softNetImageViewer3.Location = new System.Drawing.Point(-495, 289);
            this.softNetImageViewer3.Name = "softNetImageViewer3";
            this.softNetImageViewer3.Nuevo = false;
            this.softNetImageViewer3.PictSize = new System.Drawing.Size(180, 180);
            this.softNetImageViewer3.Size = new System.Drawing.Size(489, 283);
            this.softNetImageViewer3.TabIndex = 6;
            this.softNetImageViewer3.Visible = false;
            // 
            // oPicLoading
            // 
            this.oPicLoading.BackColor = System.Drawing.Color.Transparent;
            this.oPicLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oPicLoading.Image = ((System.Drawing.Image)(resources.GetObject("oPicLoading.Image")));
            this.oPicLoading.Location = new System.Drawing.Point(389, 177);
            this.oPicLoading.Name = "oPicLoading";
            this.oPicLoading.Size = new System.Drawing.Size(104, 18);
            this.oPicLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.oPicLoading.TabIndex = 5;
            this.oPicLoading.TabStop = false;
            this.oPicLoading.Visible = false;
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarImagen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarImagen.ForeColor = System.Drawing.Color.White;
            this.btnAgregarImagen.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarImagen.HighlightedImage")));
            this.btnAgregarImagen.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarImagen.Image")));
            this.btnAgregarImagen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarImagen.Location = new System.Drawing.Point(346, -3);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(100, 84);
            this.btnAgregarImagen.TabIndex = 7;
            this.btnAgregarImagen.Text = "Convertir a PDF";
            this.btnAgregarImagen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // SoftNet_IMGtoPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SoftNet_IMGtoPDF";
            this.Size = new System.Drawing.Size(999, 625);
            this.panel1.ResumeLayout(false);
            this.PanelConvertAndSave.ResumeLayout(false);
            this.panelLoadImages.ResumeLayout(false);
            this.panelLoadImages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oPicLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelConvertAndSave;
        private SoftNet_AdobePDFViewer_original softNet_AdobePDFViewer1;
        private System.Windows.Forms.Panel panelLoadImages;
        private System.Windows.Forms.PictureBox oPicLoading;
        private SoftNetImageViewer softNetImageViewer3;
        private ImagenCambianteLabel btnConvertirPDF;
        private ImagenCambianteLabel btnAgregarImagen;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListView listView1;
    }
}
