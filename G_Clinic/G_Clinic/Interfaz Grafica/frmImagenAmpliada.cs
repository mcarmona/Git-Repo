using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic
{
    public partial class FrmImagenAmpliada : Form
    {
        byte[] Imagen = null;
        private Image loadedImage;

        public FrmImagenAmpliada(byte[] pImagen, bool allowEdit)
        {
            InitializeComponent();
            Imagen = pImagen;
            btnPaint.Visible = allowEdit;
        }

        private void CalcularTamañoMaximoLienzoConImagen(Image pImage, PictureBox pBoxImage)
        {
            double promedio = 0;
            double ancho = 0;
            double altura = 0;

            if (pBoxImage.Image.Size.Height > panel1.Size.Height)
            {
                promedio = Convert.ToDouble(pImage.Size.Height) / Convert.ToDouble(pImage.Size.Width);

                pBoxImage.SizeMode = PictureBoxSizeMode.Normal;

                altura = Screen.PrimaryScreen.WorkingArea.Height - 45;
                ancho = altura / promedio;

                while ((ancho + 95) > Screen.PrimaryScreen.WorkingArea.Width)
                {
                    altura -= 1;
                    ancho = altura / promedio;
                }

                pBoxImage.Height = Convert.ToInt32(altura);

                pBoxImage.Width = Convert.ToInt32(ancho);//Math.Floor(Convert.ToDouble(pBoxImage.Height) / promedio));
            }
            pBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// Constricts a set of given dimensions while keeping aspect ratio.
        /// </summary>
        private Size ShrinkToDimensions(int originalWidth, int originalHeight, int maxWidth, int maxHeight)
        {
            int newWidth = 0;
            int newHeight = 0;

            if (originalWidth >= originalHeight)
            {
                //Match area width to max width
                if (originalWidth <= maxWidth)
                {
                    newWidth = originalWidth;
                    newHeight = originalHeight;
                }
                else
                {
                    newWidth = maxWidth;
                    newHeight = originalHeight * maxWidth / originalWidth;
                }
            }
            else
            {
                //Match area height to max height
                if (originalHeight <= maxHeight)
                {
                    newWidth = originalWidth;
                    newHeight = originalHeight;
                }
                else
                {
                    newWidth = originalWidth * maxHeight / originalHeight;
                    newHeight = maxHeight;
                }
            }

            return new Size(newWidth, newHeight);
        }

        private void FrmImagenAmpliada_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox3.Image = recursos.folder_image;
                pictureBox2.Image = recursos.gtk_close_55;

                Image newImage = null;
                //Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(Imagen, 0, Imagen.Length))
                {
                    ms.Write(Imagen, 0, Imagen.Length);

                    //Set image variable value using memory stream.
                    newImage = Image.FromStream(ms, true);
                }

                //set picture
                if (newImage != null)
                {
                    pictureBox1.Image = newImage;
                    
                    loadedImage = newImage;
                }

                if (newImage.Size.Height > Screen.PrimaryScreen.WorkingArea.Height - 25 || newImage.Size.Width > Screen.PrimaryScreen.WorkingArea.Width - 25)
                {
                    CalcularTamañoMaximoLienzoConImagen(pictureBox1.Image, pictureBox1);
                }
                else
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

                int X = 0;
                int Y = 0;
                Y = pictureBox1.Size.Height + 22;
                X = pictureBox1.Size.Width + 22;

                panel1.Size = new Size(X, Y);

                Y = 0;
                Y = panel1.Height + 15;
                this.Size = new Size(X + 75, Y);

                pictureBox1.Location = new Point(11, 11);

                this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
                this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;

                panel1.Region = Shape.RoundedRegion(panel1.Size, 3, Shape.Corner.None);

                pictureBox2.Location = new Point(panel1.Width + 13, panel1.Height - pictureBox2.Height + 15);
                label1.Location = new Point(panel1.Width + 20, panel1.Height - pictureBox2.Height + 7);
                pictureBox3.Location = new Point(panel1.Width + 15, panel1.Height - pictureBox2.Height - 14 - label1.Height - pictureBox3.Height + 14);

                btnPaint.Location = new Point(panel1.Width + 15, 8);
            }
            catch { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = recursos.gtk_close_55;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = recursos.gtk_close_55_highlighted;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = recursos.gtk_close_55;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = recursos.gtk_close_55_highlighted;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg";
            saveFileDialog1.Title = "Guardar Imagen a Disco Duro";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                // Declaramos fs para tener crear un nuevo archivo temporal en la maquina cliente.
                // y memStream para almacenar en memoria la cadena recibida.
                string sImagenTemporal = saveFileDialog1.FileName;

                string sBase64 = "";
                sBase64 = Convert.ToBase64String(Imagen);

                FileStream fs = new FileStream(sImagenTemporal, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                byte[] bytes;

                try
                {
                    bytes = Convert.FromBase64String(sBase64);
                    bw.Write(bytes);
                }

                catch
                {
                    MessageBox.Show("Ocurrió un error al leer la imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }

                finally
                {
                    fs.Close();
                    bytes = null;
                    bw = null;
                    sBase64 = null;
                }
            }
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = recursos.folder_image;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = recursos.folder_image_highlighted;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = recursos.folder_image;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = recursos.folder_image;
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se creará una copia temporal de la imagen actual por propósitos de edición, desea continuar con estas acciones?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string path = "";
                Image oImage = Metodos_Globales.CreateTempImageFromByteArray(Imagen, out path);

                if (oImage != null)
                {
                    System.Diagnostics.Process.Start("mspaint", path).WaitForExit();

                    oImage = Image.FromFile(path);

                    GlobalElementsValues oElement = new GlobalElementsValues { OBytes = File.ReadAllBytes(path), OFileName = path, OImage = oImage, OIndex = Program.oFrmConsultas.softNetImageViewer1.Controls.Count };
                    Program.oFrmConsultas.softNetImageViewer1.AddSingleImage(oElement);

                    Notificacion.mostrarVentana("Atención", "Nueva imagen editada fue agregada a su lista de imágenes disponible", Notificacion.Imagen.Soporte, 7);
                }
                else
                    MessageBox.Show(this, "¿Hubo un problema con la creación de la imagen temporal, por favor intente de nuevo. Si el problema persiste comuníquese con la persona que da soporte a su empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}