namespace G_Clinic.Miscelaneos_y_Recursos
{
    partial class PDFViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFViewer));
            this.pagePreview = new MigraDoc.Rendering.Forms.DocumentPreview();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tobPrintPreferences = new System.Windows.Forms.ToolStripButton();
            this.tobPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.tobImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tobPrevious = new System.Windows.Forms.ToolStripButton();
            this.tobNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tobCmbSize = new System.Windows.Forms.ToolStripComboBox();
            this.tobLess = new System.Windows.Forms.ToolStripButton();
            this.tobMore = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tobBestFit = new System.Windows.Forms.ToolStripButton();
            this.tobFitPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pagePreview
            // 
            this.pagePreview.BackColor = System.Drawing.SystemColors.Control;
            this.pagePreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pagePreview.Ddl = null;
            this.pagePreview.DesktopColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(211)))), ((int)(((byte)(228)))));
            this.pagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagePreview.Document = null;
            this.pagePreview.Location = new System.Drawing.Point(0, 39);
            this.pagePreview.Name = "pagePreview";
            this.pagePreview.Page = 0;
            this.pagePreview.PageColor = System.Drawing.Color.GhostWhite;
            this.pagePreview.PageSize = new System.Drawing.Size(595, 842);
            this.pagePreview.PrivateFonts = null;
            this.pagePreview.Size = new System.Drawing.Size(470, 490);
            this.pagePreview.TabIndex = 0;
            this.pagePreview.Zoom = MigraDoc.Rendering.Forms.Zoom.FullPage;
            this.pagePreview.ZoomPercent = 41;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.tobPrintPreferences,
            this.tobPrintPreview,
            this.tobImprimir,
            this.toolStripSeparator2,
            this.tobPrevious,
            this.tobNext,
            this.toolStripSeparator3,
            this.tobCmbSize,
            this.tobLess,
            this.tobMore,
            this.toolStripSeparator4,
            this.tobBestFit,
            this.tobFitPage,
            this.toolStripButton7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(470, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(2, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(5, 36);
            // 
            // tobPrintPreferences
            // 
            this.tobPrintPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobPrintPreferences.Image = ((System.Drawing.Image)(resources.GetObject("tobPrintPreferences.Image")));
            this.tobPrintPreferences.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobPrintPreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobPrintPreferences.Name = "tobPrintPreferences";
            this.tobPrintPreferences.Size = new System.Drawing.Size(36, 36);
            this.tobPrintPreferences.Text = "Imprimir";
            this.tobPrintPreferences.ToolTipText = "Dé click aquí para establecer las preferencias de impresión";
            this.tobPrintPreferences.Click += new System.EventHandler(this.tobPrintPreferences_Click);
            // 
            // tobPrintPreview
            // 
            this.tobPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("tobPrintPreview.Image")));
            this.tobPrintPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobPrintPreview.Name = "tobPrintPreview";
            this.tobPrintPreview.Size = new System.Drawing.Size(36, 36);
            this.tobPrintPreview.Text = "Imprimir";
            this.tobPrintPreview.ToolTipText = "Dé click aquí para vista previa del documento";
            this.tobPrintPreview.Click += new System.EventHandler(this.tobPrintPreview_Click);
            // 
            // tobImprimir
            // 
            this.tobImprimir.AutoSize = false;
            this.tobImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tobImprimir.Image")));
            this.tobImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobImprimir.Name = "tobImprimir";
            this.tobImprimir.Size = new System.Drawing.Size(35, 36);
            this.tobImprimir.Text = "Imprimir";
            this.tobImprimir.ToolTipText = "Dé click aquí para imprimir el documento";
            this.tobImprimir.Click += new System.EventHandler(this.tobImprimir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // tobPrevious
            // 
            this.tobPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobPrevious.Image = ((System.Drawing.Image)(resources.GetObject("tobPrevious.Image")));
            this.tobPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobPrevious.Name = "tobPrevious";
            this.tobPrevious.Size = new System.Drawing.Size(29, 36);
            this.tobPrevious.Text = "toolStripButton2";
            this.tobPrevious.ToolTipText = "Dé click aquí para ir a la página anterior del documento";
            this.tobPrevious.Click += new System.EventHandler(this.tobPreview_Click);
            // 
            // tobNext
            // 
            this.tobNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobNext.Image = ((System.Drawing.Image)(resources.GetObject("tobNext.Image")));
            this.tobNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobNext.Name = "tobNext";
            this.tobNext.Size = new System.Drawing.Size(29, 36);
            this.tobNext.Text = "toolStripButton2";
            this.tobNext.ToolTipText = "Dé click aquí para ir a la siguiente página del documento";
            this.tobNext.Click += new System.EventHandler(this.tobNext_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // tobCmbSize
            // 
            this.tobCmbSize.AutoSize = false;
            this.tobCmbSize.Items.AddRange(new object[] {
            "10%",
            "25%",
            "50%",
            "75%",
            "100%",
            "125%",
            "150%",
            "200%",
            "400%",
            "800%"});
            this.tobCmbSize.Name = "tobCmbSize";
            this.tobCmbSize.Size = new System.Drawing.Size(57, 23);
            this.tobCmbSize.Text = "100%";
            this.tobCmbSize.ToolTipText = "Seleccione el porcentaje de zoom que desea aplicar a la vista del documento";
            this.tobCmbSize.SelectedIndexChanged += new System.EventHandler(this.tobCmbSize_SelectedIndexChanged);
            this.tobCmbSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tobCmbSize_KeyPress);
            // 
            // tobLess
            // 
            this.tobLess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobLess.Image = ((System.Drawing.Image)(resources.GetObject("tobLess.Image")));
            this.tobLess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobLess.Name = "tobLess";
            this.tobLess.Size = new System.Drawing.Size(29, 36);
            this.tobLess.Text = "toolStripButton2";
            this.tobLess.ToolTipText = "Dé click aquí para reducir la magnificación de la página del documento";
            this.tobLess.Click += new System.EventHandler(this.tobLess_Click);
            // 
            // tobMore
            // 
            this.tobMore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobMore.Image = ((System.Drawing.Image)(resources.GetObject("tobMore.Image")));
            this.tobMore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobMore.Name = "tobMore";
            this.tobMore.Size = new System.Drawing.Size(29, 36);
            this.tobMore.Text = "toolStripButton2";
            this.tobMore.ToolTipText = "Dé click aquí para aumentar la magnificación de la página del documento";
            this.tobMore.Click += new System.EventHandler(this.tobMore_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 33);
            // 
            // tobBestFit
            // 
            this.tobBestFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobBestFit.Image = ((System.Drawing.Image)(resources.GetObject("tobBestFit.Image")));
            this.tobBestFit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobBestFit.Name = "tobBestFit";
            this.tobBestFit.Size = new System.Drawing.Size(29, 36);
            this.tobBestFit.Text = "toolStripButton2";
            this.tobBestFit.ToolTipText = "Dé click aquí para ajustar la página";
            this.tobBestFit.Click += new System.EventHandler(this.tobBestFit_Click);
            // 
            // tobFitPage
            // 
            this.tobFitPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobFitPage.Image = ((System.Drawing.Image)(resources.GetObject("tobFitPage.Image")));
            this.tobFitPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobFitPage.Name = "tobFitPage";
            this.tobFitPage.Size = new System.Drawing.Size(29, 36);
            this.tobFitPage.Text = "toolStripButton2";
            this.tobFitPage.ToolTipText = "Dé click aquí para ajustar la página";
            this.tobFitPage.Click += new System.EventHandler(this.tobFitPage_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton7.AutoSize = false;
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(38, 36);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip1.BackgroundImage")));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(470, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(455, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // PDFViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pagePreview);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "PDFViewer";
            this.Size = new System.Drawing.Size(470, 551);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MigraDoc.Rendering.Forms.DocumentPreview pagePreview;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton tobImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tobPrevious;
        private System.Windows.Forms.ToolStripButton tobNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox tobCmbSize;
        private System.Windows.Forms.ToolStripButton tobLess;
        private System.Windows.Forms.ToolStripButton tobFitPage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tobMore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tobBestFit;
        private System.Windows.Forms.ToolStripLabel toolStripButton7;
        private System.Windows.Forms.ToolStripButton tobPrintPreview;
        private System.Windows.Forms.ToolStripButton tobPrintPreferences;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
