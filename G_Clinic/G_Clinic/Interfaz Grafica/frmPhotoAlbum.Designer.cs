using System;
namespace G_Clinic.Interfaz_Grafica
{
    partial class frmPhotoAlbum
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
            oGlobalElementValues = null;

            photoAlbum1.Dispose();
            GC.Collect();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhotoAlbum));
            this.button1 = new System.Windows.Forms.Button();
            this.imagenCambianteLabel2 = new G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel();
            this.photoAlbum1 = new G_Clinic.Miscelaneos_y_Recursos.PhotoAlbum();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(-88, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imagenCambianteLabel2
            // 
            this.imagenCambianteLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imagenCambianteLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imagenCambianteLabel2.ForeColor = System.Drawing.Color.White;
            this.imagenCambianteLabel2.HighlightedImage = global::G_Clinic.recursos.gtk_close_55_highlighted;
            this.imagenCambianteLabel2.Image = global::G_Clinic.recursos.gtk_close_55;
            this.imagenCambianteLabel2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.imagenCambianteLabel2.Location = new System.Drawing.Point(787, 122);
            this.imagenCambianteLabel2.Name = "imagenCambianteLabel2";
            this.imagenCambianteLabel2.Size = new System.Drawing.Size(90, 88);
            this.imagenCambianteLabel2.TabIndex = 1;
            this.imagenCambianteLabel2.Text = "Cerrar Álbum de Fotos";
            this.imagenCambianteLabel2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.imagenCambianteLabel2.Click += new System.EventHandler(this.imagenCambianteLabel2_Click);
            // 
            // photoAlbum1
            // 
            this.photoAlbum1.BackColor = System.Drawing.Color.Transparent;
            this.photoAlbum1.ContainerHeight = 0;
            this.photoAlbum1.ContainerWidth = 0;
            this.photoAlbum1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoAlbum1.Location = new System.Drawing.Point(0, 0);
            this.photoAlbum1.Name = "photoAlbum1";
            this.photoAlbum1.Size = new System.Drawing.Size(882, 635);
            this.photoAlbum1.TabIndex = 3;
            // 
            // frmPhotoAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(882, 635);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imagenCambianteLabel2);
            this.Controls.Add(this.photoAlbum1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPhotoAlbum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Photo Album";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Load += new System.EventHandler(this.frmPhotoAlbum_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private G_Clinic.Miscelaneos_y_Recursos.ImagenCambianteLabel imagenCambianteLabel2;
        private System.Windows.Forms.Button button1;
        private G_Clinic.Miscelaneos_y_Recursos.PhotoAlbum photoAlbum1;
    }
}