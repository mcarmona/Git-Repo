namespace G_Clinic
{
    partial class ImageViewerCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageViewerCtrl));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tobPen = new System.Windows.Forms.ToolStripButton();
            this.tobRectangulo = new System.Windows.Forms.ToolStripButton();
            this.tobCirculo = new System.Windows.Forms.ToolStripButton();
            this.tobTexto = new System.Windows.Forms.ToolStripButton();
            this.tobLinea = new System.Windows.Forms.ToolStripButton();
            this.tobColor = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobPen,
            this.tobRectangulo,
            this.tobCirculo,
            this.tobTexto,
            this.tobLinea,
            this.tobColor});
            this.toolStrip2.Location = new System.Drawing.Point(10, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(282, 41);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tobPen
            // 
            this.tobPen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tobPen.ForeColor = System.Drawing.Color.White;
            this.tobPen.Image = ((System.Drawing.Image)(resources.GetObject("tobPen.Image")));
            this.tobPen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobPen.Name = "tobPen";
            this.tobPen.Size = new System.Drawing.Size(31, 38);
            this.tobPen.Text = "Pen";
            this.tobPen.Click += new System.EventHandler(this.tobPen_Click);
            // 
            // tobRectangulo
            // 
            this.tobRectangulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tobRectangulo.ForeColor = System.Drawing.Color.White;
            this.tobRectangulo.Image = ((System.Drawing.Image)(resources.GetObject("tobRectangulo.Image")));
            this.tobRectangulo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobRectangulo.Name = "tobRectangulo";
            this.tobRectangulo.Size = new System.Drawing.Size(47, 38);
            this.tobRectangulo.Text = "Square";
            // 
            // tobCirculo
            // 
            this.tobCirculo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tobCirculo.ForeColor = System.Drawing.Color.White;
            this.tobCirculo.Image = ((System.Drawing.Image)(resources.GetObject("tobCirculo.Image")));
            this.tobCirculo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobCirculo.Name = "tobCirculo";
            this.tobCirculo.Size = new System.Drawing.Size(41, 38);
            this.tobCirculo.Text = "Circle";
            // 
            // tobTexto
            // 
            this.tobTexto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tobTexto.ForeColor = System.Drawing.Color.White;
            this.tobTexto.Image = ((System.Drawing.Image)(resources.GetObject("tobTexto.Image")));
            this.tobTexto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobTexto.Name = "tobTexto";
            this.tobTexto.Size = new System.Drawing.Size(33, 38);
            this.tobTexto.Text = "Text";
            // 
            // tobLinea
            // 
            this.tobLinea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tobLinea.ForeColor = System.Drawing.Color.White;
            this.tobLinea.Image = ((System.Drawing.Image)(resources.GetObject("tobLinea.Image")));
            this.tobLinea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobLinea.Name = "tobLinea";
            this.tobLinea.Size = new System.Drawing.Size(39, 38);
            this.tobLinea.Text = "Línea";
            // 
            // tobColor
            // 
            this.tobColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tobColor.ForeColor = System.Drawing.Color.White;
            this.tobColor.Image = ((System.Drawing.Image)(resources.GetObject("tobColor.Image")));
            this.tobColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobColor.Name = "tobColor";
            this.tobColor.Size = new System.Drawing.Size(40, 38);
            this.tobColor.Text = "Color";
            // 
            // ImageViewerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.toolStrip2);
            this.DoubleBuffered = true;
            this.Name = "ImageViewerCtrl";
            this.Size = new System.Drawing.Size(337, 280);
            this.Load += new System.EventHandler(this.ImageViewerCtrl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageViewerCtrl_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageViewerCtrl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageViewerCtrl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageViewerCtrl_MouseUp);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tobPen;
        private System.Windows.Forms.ToolStripButton tobRectangulo;
        private System.Windows.Forms.ToolStripButton tobCirculo;
        private System.Windows.Forms.ToolStripButton tobTexto;
        private System.Windows.Forms.ToolStripButton tobLinea;
        private System.Windows.Forms.ToolStripButton tobColor;

    }
}
