namespace G_Clinic.Miscelaneos_y_Recursos.ImageViewerControl
{
    partial class SoftNetImageViewer
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftNetImageViewer));
            this.panel11 = new System.Windows.Forms.Panel();
            this.tobOpcionesImagen = new System.Windows.Forms.ToolStrip();
            this.tobEliminarImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tobMagnifyImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.trackBarSize = new MB.Controls.ColorSlider();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnAgregarImagen = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.flowLayoutPanelMain = new G_Clinic.ThumbnailFlowLayoutPanel();
            this.panel11.SuspendLayout();
            this.tobOpcionesImagen.SuspendLayout();
            this.grouper1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.tobOpcionesImagen);
            this.panel11.Location = new System.Drawing.Point(7, 15);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(63, 28);
            this.panel11.TabIndex = 270;
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
            this.tobOpcionesImagen.Location = new System.Drawing.Point(0, -1);
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
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.Color.Transparent;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.Transparent;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            this.grouper1.BorderColor = System.Drawing.Color.Black;
            this.grouper1.BorderThickness = 1F;
            this.grouper1.Controls.Add(this.flowLayoutPanelMain);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "";
            this.grouper1.Location = new System.Drawing.Point(6, 15);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(20);
            this.grouper1.PaintGroupBox = false;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper1.ShadowControl = false;
            this.grouper1.ShadowThickness = 3;
            this.grouper1.Size = new System.Drawing.Size(377, 486);
            this.grouper1.TabIndex = 268;
            // 
            // trackBarSize
            // 
            this.trackBarSize.BackColor = System.Drawing.Color.Transparent;
            this.trackBarSize.BarInnerColor = System.Drawing.Color.Chartreuse;
            this.trackBarSize.BarOuterColor = System.Drawing.Color.DarkGreen;
            this.trackBarSize.BarPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.trackBarSize.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarSize.LargeChange = ((uint)(5u));
            this.trackBarSize.Location = new System.Drawing.Point(287, 3);
            this.trackBarSize.Maximum = 2;
            this.trackBarSize.Name = "trackBarSize";
            this.trackBarSize.Size = new System.Drawing.Size(90, 20);
            this.trackBarSize.SmallChange = ((uint)(1u));
            this.trackBarSize.TabIndex = 1;
            this.trackBarSize.Text = "colorSlider1";
            this.trackBarSize.ThumbRoundRectSize = new System.Drawing.Size(4, 5);
            this.trackBarSize.ThumbSize = 10;
            this.trackBarSize.Value = 1;
            this.trackBarSize.Visible = false;
            this.trackBarSize.ValueChanged += new System.EventHandler(this.trackBarSize_ValueChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(396, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 2);
            this.label1.TabIndex = 272;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HighlightedImage = global::G_Clinic.Properties.Resources.no_52_highlighted;
            this.btnCancel.Image = global::G_Clinic.Properties.Resources.no_52;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(389, 101);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 69);
            this.btnCancel.TabIndex = 271;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarImagen.ForeColor = System.Drawing.Color.White;
            this.btnAgregarImagen.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarImagen.HighlightedImage")));
            this.btnAgregarImagen.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarImagen.Image")));
            this.btnAgregarImagen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarImagen.Location = new System.Drawing.Point(389, 25);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(63, 69);
            this.btnAgregarImagen.TabIndex = 269;
            this.btnAgregarImagen.Text = "Agregar";
            this.btnAgregarImagen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(4, 13);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(369, 470);
            this.flowLayoutPanelMain.TabIndex = 0;
            // 
            // SoftNetImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.trackBarSize);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.grouper1);
            this.Name = "SoftNetImageViewer";
            this.Size = new System.Drawing.Size(456, 506);
            this.panel11.ResumeLayout(false);
            this.tobOpcionesImagen.ResumeLayout(false);
            this.tobOpcionesImagen.PerformLayout();
            this.grouper1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ToolStrip tobOpcionesImagen;
        private System.Windows.Forms.ToolStripButton tobEliminarImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton tobMagnifyImage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private ImagenCambianteLabel btnAgregarImagen;
        private CodeVendor.Controls.Grouper grouper1;
        private MB.Controls.ColorSlider trackBarSize;
        private ThumbnailFlowLayoutPanel flowLayoutPanelMain;
        private ImagenCambianteLabel btnCancel;
        private System.Windows.Forms.Label label1;
    }
}
