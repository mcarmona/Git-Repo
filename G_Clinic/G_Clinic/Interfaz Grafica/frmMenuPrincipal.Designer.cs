namespace G_Clinic.Interfaz_Grafica
{
    partial class frmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.transparentPictureBox1 = new G_Clinic.Miscelaneos_y_Recursos.TransparentPictureBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(6, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 351);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(8, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(484, 318);
            this.panel3.TabIndex = 0;
            // 
            // transparentPictureBox1
            // 
            this.transparentPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.transparentPictureBox1.BackgroundImage = global::G_Clinic.Properties.Resources.SoftNet_Orb_64;
            this.transparentPictureBox1.Location = new System.Drawing.Point(9, -4);
            this.transparentPictureBox1.Name = "transparentPictureBox1";
            this.transparentPictureBox1.Size = new System.Drawing.Size(59, 59);
            this.transparentPictureBox1.TabIndex = 0;
            this.transparentPictureBox1.MouseLeave += new System.EventHandler(this.transparentPictureBox1_MouseLeave);
            this.transparentPictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.transparentPictureBox1_MouseDown);
            this.transparentPictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.transparentPictureBox1_MouseUp);
            this.transparentPictureBox1.MouseEnter += new System.EventHandler(this.transparentPictureBox1_MouseEnter);
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(511, 382);
            this.Controls.Add(this.transparentPictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenuPrincipal";
            this.Text = "frmMenuPrincipal";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private G_Clinic.Miscelaneos_y_Recursos.TransparentPictureBox transparentPictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}