using System;
namespace G_Clinic.Miscelaneos_y_Recursos
{
    partial class PhotoAlbum
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
            oListGlobalElementsValues = null;
            OListGlobalElementsValues = null;

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Dispose();
            GC.Collect();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoAlbum));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrevious = new G_Clinic.ImagenCambiantePictureBox();
            this.btnNext = new G_Clinic.ImagenCambiantePictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.imagenCambianteLabel2 = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnGuardarImagen = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnOcultarVistaPrevia = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnMostrarVistaPrevia = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tobLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tobRight = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(917, 411);
            this.panel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(122, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(673, 51);
            this.label1.TabIndex = 5;
            this.label1.Text = "Deslice el cursor del mouse sobre la imagen deseada para visualizar la misma en s" +
    "u tamaño original";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(263, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 380);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            this.panel1.VisibleChanged += new System.EventHandler(this.panel1_VisibleChanged);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnPrevious.HighlightedImage")));
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(13, 161);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(27, 59);
            this.btnPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.TabStop = false;
            this.btnPrevious.Visible = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnNext.HighlightedImage")));
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(351, 161);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(27, 59);
            this.btnNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnNext.TabIndex = 6;
            this.btnNext.TabStop = false;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(10, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(370, 355);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.imagenCambianteLabel2);
            this.panel3.Controls.Add(this.btnGuardarImagen);
            this.panel3.Controls.Add(this.btnOcultarVistaPrevia);
            this.panel3.Controls.Add(this.btnMostrarVistaPrevia);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(917, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(95, 411);
            this.panel3.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(5, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 3);
            this.label4.TabIndex = 6;
            this.label4.Visible = false;
            // 
            // imagenCambianteLabel2
            // 
            this.imagenCambianteLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imagenCambianteLabel2.ForeColor = System.Drawing.Color.White;
            this.imagenCambianteLabel2.HighlightedImage = global::G_Clinic.recursos.gtk_close_55_highlighted;
            this.imagenCambianteLabel2.Image = global::G_Clinic.recursos.gtk_close_55;
            this.imagenCambianteLabel2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.imagenCambianteLabel2.Location = new System.Drawing.Point(-2, 128);
            this.imagenCambianteLabel2.Name = "imagenCambianteLabel2";
            this.imagenCambianteLabel2.Size = new System.Drawing.Size(96, 88);
            this.imagenCambianteLabel2.TabIndex = 0;
            this.imagenCambianteLabel2.Text = "Cerrar Álbum de Fotos";
            this.imagenCambianteLabel2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.imagenCambianteLabel2.Visible = false;
            // 
            // btnGuardarImagen
            // 
            this.btnGuardarImagen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarImagen.ForeColor = System.Drawing.Color.White;
            this.btnGuardarImagen.HighlightedImage = global::G_Clinic.recursos.folder_image_highlighted;
            this.btnGuardarImagen.Image = global::G_Clinic.recursos.folder_image;
            this.btnGuardarImagen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardarImagen.Location = new System.Drawing.Point(-2, 19);
            this.btnGuardarImagen.Name = "btnGuardarImagen";
            this.btnGuardarImagen.Size = new System.Drawing.Size(96, 88);
            this.btnGuardarImagen.TabIndex = 0;
            this.btnGuardarImagen.Text = "Guardar Copia de Imagen";
            this.btnGuardarImagen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarImagen.Click += new System.EventHandler(this.btnGuardarImagen_Click);
            // 
            // btnOcultarVistaPrevia
            // 
            this.btnOcultarVistaPrevia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcultarVistaPrevia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOcultarVistaPrevia.ForeColor = System.Drawing.Color.White;
            this.btnOcultarVistaPrevia.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnOcultarVistaPrevia.HighlightedImage")));
            this.btnOcultarVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("btnOcultarVistaPrevia.Image")));
            this.btnOcultarVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOcultarVistaPrevia.Location = new System.Drawing.Point(-3, 307);
            this.btnOcultarVistaPrevia.Name = "btnOcultarVistaPrevia";
            this.btnOcultarVistaPrevia.Size = new System.Drawing.Size(100, 95);
            this.btnOcultarVistaPrevia.TabIndex = 7;
            this.btnOcultarVistaPrevia.Text = "Ocultar Vista Previa";
            this.btnOcultarVistaPrevia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOcultarVistaPrevia.Click += new System.EventHandler(this.btnOcultarVistaPrevia_Click);
            // 
            // btnMostrarVistaPrevia
            // 
            this.btnMostrarVistaPrevia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMostrarVistaPrevia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarVistaPrevia.ForeColor = System.Drawing.Color.White;
            this.btnMostrarVistaPrevia.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnMostrarVistaPrevia.HighlightedImage")));
            this.btnMostrarVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("btnMostrarVistaPrevia.Image")));
            this.btnMostrarVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMostrarVistaPrevia.Location = new System.Drawing.Point(-3, 297);
            this.btnMostrarVistaPrevia.Name = "btnMostrarVistaPrevia";
            this.btnMostrarVistaPrevia.Size = new System.Drawing.Size(100, 105);
            this.btnMostrarVistaPrevia.TabIndex = 8;
            this.btnMostrarVistaPrevia.Text = "Mostrar Vista Previa";
            this.btnMostrarVistaPrevia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMostrarVistaPrevia.Visible = false;
            this.btnMostrarVistaPrevia.Click += new System.EventHandler(this.btnMostrarVistaPrevia_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.toolStrip2);
            this.panel4.Controls.Add(this.toolStrip1);
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 411);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1012, 130);
            this.panel4.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(979, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 14);
            this.label3.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(-2, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 14);
            this.label2.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobLeft});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(29, 130);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tobLeft
            // 
            this.tobLeft.AutoSize = false;
            this.tobLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobLeft.Image = ((System.Drawing.Image)(resources.GetObject("tobLeft.Image")));
            this.tobLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobLeft.Name = "tobLeft";
            this.tobLeft.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tobLeft.Size = new System.Drawing.Size(29, 115);
            this.tobLeft.Click += new System.EventHandler(this.tobLeft_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobRight});
            this.toolStrip1.Location = new System.Drawing.Point(983, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(29, 130);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tobRight
            // 
            this.tobRight.AutoSize = false;
            this.tobRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobRight.Image = ((System.Drawing.Image)(resources.GetObject("tobRight.Image")));
            this.tobRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobRight.Name = "tobRight";
            this.tobRight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tobRight.Size = new System.Drawing.Size(29, 115);
            this.tobRight.Click += new System.EventHandler(this.tobRight_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(29, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(954, 130);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.LocationChanged += new System.EventHandler(this.flowLayoutPanel1_LocationChanged);
            // 
            // PhotoAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.DoubleBuffered = true;
            this.Name = "PhotoAlbum";
            this.Size = new System.Drawing.Size(1012, 541);
            this.Load += new System.EventHandler(this.PhotoAlbum_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PhotoAlbum_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tobRight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tobLeft;
        private ImagenCambianteLabel imagenCambianteLabel2;
        private ImagenCambianteLabel btnGuardarImagen;
        private System.Windows.Forms.Label label4;
        private ImagenCambianteLabel btnOcultarVistaPrevia;
        private ImagenCambiantePictureBox btnPrevious;
        private ImagenCambiantePictureBox btnNext;
        private ImagenCambianteLabel btnMostrarVistaPrevia;
    }
}
