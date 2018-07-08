namespace G_Clinic
{
    partial class ImageDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageDialog));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tobEditImage = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageViewerFull = new G_Clinic.ImageViewerCtrl();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(65, 65);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobEditImage});
            this.toolStrip1.Location = new System.Drawing.Point(3, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(70, 74);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tobEditImage
            // 
            this.tobEditImage.AutoSize = false;
            this.tobEditImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobEditImage.Image = ((System.Drawing.Image)(resources.GetObject("tobEditImage.Image")));
            this.tobEditImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobEditImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobEditImage.Name = "tobEditImage";
            this.tobEditImage.Size = new System.Drawing.Size(69, 69);
            this.tobEditImage.Text = "Edit with Paint.Net";
            this.tobEditImage.Click += new System.EventHandler(this.tobEditImage_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(489, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(75, 73);
            this.panel1.TabIndex = 2;
            // 
            // imageViewerFull
            // 
            this.imageViewerFull.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.imageViewerFull.BackColor = System.Drawing.Color.Transparent;
            this.imageViewerFull.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageViewerFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewerFull.Image = null;
            this.imageViewerFull.ImageBytes = null;
            this.imageViewerFull.ImageLocation = null;
            this.imageViewerFull.ImageNumber = 0;
            this.imageViewerFull.IsActive = false;
            this.imageViewerFull.IsThumbnail = false;
            this.imageViewerFull.Location = new System.Drawing.Point(0, 0);
            this.imageViewerFull.Name = "imageViewerFull";
            this.imageViewerFull.Size = new System.Drawing.Size(567, 515);
            this.imageViewerFull.TabIndex = 0;
            this.imageViewerFull.TempImageLocation = null;
            this.imageViewerFull.Load += new System.EventHandler(this.imageViewerFull_Load);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(567, 515);
            this.shapeContainer1.TabIndex = 3;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(323, 256);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(89, 124);
            // 
            // ImageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(567, 515);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.imageViewerFull);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImageDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Viewer";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImageDialog_FormClosed);
            this.Load += new System.EventHandler(this.ImageDialog_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageDialog_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageDialog_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageDialog_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageDialog_MouseUp);
            this.Resize += new System.EventHandler(this.ImageDialog_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ImageViewerCtrl imageViewerFull;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tobEditImage;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;

    }
}