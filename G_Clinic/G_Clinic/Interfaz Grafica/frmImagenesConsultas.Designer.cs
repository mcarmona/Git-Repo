namespace G_Clinic.Interfaz_Grafica
{
    partial class frmImagenesConsultas
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
            oGlobalElementList = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImagenesConsultas));
            this.label27 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPhotoAlbum = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnSalir = new G_Clinic.ImagenCambiantePictureBox();
            this.photoAlbum1 = new G_Clinic.Miscelaneos_y_Recursos.PhotoAlbum();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(974, 120);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(69, 1);
            this.label27.TabIndex = 269;
            // 
            // panel3
            // 
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 562);
            this.panel3.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(50, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 247;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(-86, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 248;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(-3, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(54, 54);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 129;
            this.pictureBox3.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-2, 105);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(221, 461);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnPhotoAlbum
            // 
            this.btnPhotoAlbum.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhotoAlbum.ForeColor = System.Drawing.Color.White;
            this.btnPhotoAlbum.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnPhotoAlbum.HighlightedImage")));
            this.btnPhotoAlbum.Image = ((System.Drawing.Image)(resources.GetObject("btnPhotoAlbum.Image")));
            this.btnPhotoAlbum.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPhotoAlbum.Location = new System.Drawing.Point(967, 131);
            this.btnPhotoAlbum.Name = "btnPhotoAlbum";
            this.btnPhotoAlbum.Size = new System.Drawing.Size(88, 106);
            this.btnPhotoAlbum.TabIndex = 268;
            this.btnPhotoAlbum.Text = "Ver en modo\r\n de Pantalla \r\n  Completa";
            this.btnPhotoAlbum.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPhotoAlbum.Click += new System.EventHandler(this.btnPhotoAlbum_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.HighlightedImage")));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(992, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(42, 17);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnSalir.TabIndex = 247;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // photoAlbum1
            // 
            this.photoAlbum1.BackColor = System.Drawing.Color.Black;
            this.photoAlbum1.ContainerHeight = 0;
            this.photoAlbum1.ContainerWidth = 0;
            this.photoAlbum1.Location = new System.Drawing.Point(220, 5);
            this.photoAlbum1.Name = "photoAlbum1";
            this.photoAlbum1.Size = new System.Drawing.Size(838, 554);
            this.photoAlbum1.TabIndex = 1;
            this.photoAlbum1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.photoAlbum1_KeyDown);
            // 
            // frmImagenesConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(1063, 562);
            this.Controls.Add(this.btnPhotoAlbum);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.photoAlbum1);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmImagenesConsultas";
            this.Opacity = 0.96D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmImagenesConsultas_Load);
            this.VisibleChanged += new System.EventHandler(this.frmImagenesConsultas_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmImagenesConsultas_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private G_Clinic.Miscelaneos_y_Recursos.PhotoAlbum photoAlbum1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel btnPhotoAlbum;
        private System.Windows.Forms.Label label27;
        private ImagenCambiantePictureBox btnSalir;
        private System.Windows.Forms.Button button1;
    }
}