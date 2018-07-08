using System;
namespace G_Clinic.Miscelaneos_y_Recursos
{
    partial class SoftNetImageViewer
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
            oObjectList = null;
            globalElementsDetails = null;

            flowLayoutPanel1.Controls.Clear();

            try
            {
                flowLayoutPanel1.Dispose();
            }
            catch { }
            GC.Collect();

            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftNetImageViewer));
            this.panel9 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label27 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.tobOpcionesImagen = new System.Windows.Forms.ToolStrip();
            this.tobEliminarImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tobMagnifyImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panelOpcionesImagenes = new System.Windows.Forms.Panel();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.btnAgregarImagen = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnPhotoAlbum = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.tobOpcionesImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.flowLayoutPanel1);
            this.panel9.Controls.Add(this.progressBar1);
            this.panel9.Controls.Add(this.label27);
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.panelOpcionesImagenes);
            this.panel9.Controls.Add(this.pictureBox10);
            this.panel9.Controls.Add(this.btnAgregarImagen);
            this.panel9.Controls.Add(this.btnPhotoAlbum);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(476, 555);
            this.panel9.TabIndex = 266;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 81);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(391, 446);
            this.flowLayoutPanel1.TabIndex = 271;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(286, 531);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(118, 18);
            this.progressBar1.TabIndex = 270;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(418, 161);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 1);
            this.label27.TabIndex = 268;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.tobOpcionesImagen);
            this.panel11.Location = new System.Drawing.Point(10, 14);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(63, 30);
            this.panel11.TabIndex = 266;
            this.panel11.Visible = false;
            // 
            // tobOpcionesImagen
            // 
            this.tobOpcionesImagen.AutoSize = false;
            this.tobOpcionesImagen.BackColor = System.Drawing.Color.Transparent;
            this.tobOpcionesImagen.Dock = System.Windows.Forms.DockStyle.None;
            this.tobOpcionesImagen.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tobOpcionesImagen.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.tobOpcionesImagen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobEliminarImage,
            this.toolStripSeparator11,
            this.tobMagnifyImage,
            this.toolStripLabel1});
            this.tobOpcionesImagen.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tobOpcionesImagen.Location = new System.Drawing.Point(2, 1);
            this.tobOpcionesImagen.Name = "tobOpcionesImagen";
            this.tobOpcionesImagen.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tobOpcionesImagen.Size = new System.Drawing.Size(68, 31);
            this.tobOpcionesImagen.TabIndex = 184;
            // 
            // tobEliminarImage
            // 
            this.tobEliminarImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobEliminarImage.Image = ((System.Drawing.Image)(resources.GetObject("tobEliminarImage.Image")));
            this.tobEliminarImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobEliminarImage.Name = "tobEliminarImage";
            this.tobEliminarImage.Size = new System.Drawing.Size(26, 28);
            this.tobEliminarImage.ToolTipText = "Eliminar Imagen";
            this.tobEliminarImage.Click += new System.EventHandler(this.tobEliminarImage_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.AutoSize = false;
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 23);
            // 
            // tobMagnifyImage
            // 
            this.tobMagnifyImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobMagnifyImage.Image = ((System.Drawing.Image)(resources.GetObject("tobMagnifyImage.Image")));
            this.tobMagnifyImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobMagnifyImage.Name = "tobMagnifyImage";
            this.tobMagnifyImage.Size = new System.Drawing.Size(26, 28);
            this.tobMagnifyImage.Text = "toolStripButton1";
            this.tobMagnifyImage.ToolTipText = "Ampliar Imagen";
            this.tobMagnifyImage.Click += new System.EventHandler(this.tobMagnifyImage_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(6, 0);
            // 
            // panelOpcionesImagenes
            // 
            this.panelOpcionesImagenes.Location = new System.Drawing.Point(-68, 25);
            this.panelOpcionesImagenes.Name = "panelOpcionesImagenes";
            this.panelOpcionesImagenes.Size = new System.Drawing.Size(63, 32);
            this.panelOpcionesImagenes.TabIndex = 265;
            this.panelOpcionesImagenes.Visible = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(133, 14);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(210, 60);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox10.TabIndex = 3;
            this.pictureBox10.TabStop = false;
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarImagen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarImagen.ForeColor = System.Drawing.Color.White;
            this.btnAgregarImagen.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarImagen.HighlightedImage")));
            this.btnAgregarImagen.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarImagen.Image")));
            this.btnAgregarImagen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarImagen.Location = new System.Drawing.Point(409, 81);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(63, 69);
            this.btnAgregarImagen.TabIndex = 1;
            this.btnAgregarImagen.Text = "Agregar";
            this.btnAgregarImagen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // btnPhotoAlbum
            // 
            this.btnPhotoAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhotoAlbum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhotoAlbum.ForeColor = System.Drawing.Color.White;
            this.btnPhotoAlbum.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnPhotoAlbum.HighlightedImage")));
            this.btnPhotoAlbum.Image = ((System.Drawing.Image)(resources.GetObject("btnPhotoAlbum.Image")));
            this.btnPhotoAlbum.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPhotoAlbum.Location = new System.Drawing.Point(401, 168);
            this.btnPhotoAlbum.Name = "btnPhotoAlbum";
            this.btnPhotoAlbum.Size = new System.Drawing.Size(79, 91);
            this.btnPhotoAlbum.TabIndex = 267;
            this.btnPhotoAlbum.Text = "Ver Album de Fotos";
            this.btnPhotoAlbum.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPhotoAlbum.Click += new System.EventHandler(this.btnPhotoAlbum_Click);
            // 
            // SoftNetImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel9);
            this.Name = "SoftNetImageViewer";
            this.Size = new System.Drawing.Size(476, 555);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.tobOpcionesImagen.ResumeLayout(false);
            this.tobOpcionesImagen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ToolStrip tobOpcionesImagen;
        private System.Windows.Forms.ToolStripButton tobEliminarImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton tobMagnifyImage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel panelOpcionesImagenes;
        private System.Windows.Forms.PictureBox pictureBox10;
        private ImagenCambianteLabel btnAgregarImagen;
        private ImagenCambianteLabel btnPhotoAlbum;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.ProgressBar progressBar1;
    }
}
