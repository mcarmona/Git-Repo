namespace G_Clinic.Interfaz_Grafica
{
    partial class frmTipoConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoConsulta));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imagenCambianteLabel1 = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnSinEmbarazo = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.btnConEmbarazo = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(311, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 215);
            this.label1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSinEmbarazo);
            this.panel1.Controls.Add(this.btnConEmbarazo);
            this.panel1.Location = new System.Drawing.Point(195, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 362);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(-83, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 7);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(46, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(530, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // imagenCambianteLabel1
            // 
            this.imagenCambianteLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imagenCambianteLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imagenCambianteLabel1.ForeColor = System.Drawing.Color.White;
            this.imagenCambianteLabel1.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("imagenCambianteLabel1.HighlightedImage")));
            this.imagenCambianteLabel1.Image = ((System.Drawing.Image)(resources.GetObject("imagenCambianteLabel1.Image")));
            this.imagenCambianteLabel1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.imagenCambianteLabel1.Location = new System.Drawing.Point(965, 9);
            this.imagenCambianteLabel1.Name = "imagenCambianteLabel1";
            this.imagenCambianteLabel1.Size = new System.Drawing.Size(45, 49);
            this.imagenCambianteLabel1.TabIndex = 4;
            this.imagenCambianteLabel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.imagenCambianteLabel1.Click += new System.EventHandler(this.imagenCambianteLabel1_Click);
            // 
            // btnSinEmbarazo
            // 
            this.btnSinEmbarazo.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinEmbarazo.ForeColor = System.Drawing.Color.White;
            this.btnSinEmbarazo.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnSinEmbarazo.HighlightedImage")));
            this.btnSinEmbarazo.Image = ((System.Drawing.Image)(resources.GetObject("btnSinEmbarazo.Image")));
            this.btnSinEmbarazo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSinEmbarazo.Location = new System.Drawing.Point(-9, 69);
            this.btnSinEmbarazo.Name = "btnSinEmbarazo";
            this.btnSinEmbarazo.Size = new System.Drawing.Size(324, 295);
            this.btnSinEmbarazo.TabIndex = 0;
            this.btnSinEmbarazo.Text = "Consulta Sin Embarazo";
            this.btnSinEmbarazo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSinEmbarazo.Click += new System.EventHandler(this.btnSinEmbarazo_Click);
            // 
            // btnConEmbarazo
            // 
            this.btnConEmbarazo.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConEmbarazo.ForeColor = System.Drawing.Color.White;
            this.btnConEmbarazo.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnConEmbarazo.HighlightedImage")));
            this.btnConEmbarazo.Image = ((System.Drawing.Image)(resources.GetObject("btnConEmbarazo.Image")));
            this.btnConEmbarazo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConEmbarazo.Location = new System.Drawing.Point(308, 69);
            this.btnConEmbarazo.Name = "btnConEmbarazo";
            this.btnConEmbarazo.Size = new System.Drawing.Size(324, 295);
            this.btnConEmbarazo.TabIndex = 1;
            this.btnConEmbarazo.Text = "Consulta Con Embarazo";
            this.btnConEmbarazo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConEmbarazo.Click += new System.EventHandler(this.btnConEmbarazo_Click);
            // 
            // frmTipoConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(1022, 551);
            this.Controls.Add(this.imagenCambianteLabel1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTipoConsulta";
            this.Opacity = 0.93;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmTipoConsulta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel btnSinEmbarazo;
        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel btnConEmbarazo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel imagenCambianteLabel1;
        private System.Windows.Forms.Button button1;
    }
}