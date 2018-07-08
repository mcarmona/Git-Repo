using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Transitions;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class PhotoAlbum : UserControl
    {
        #region Variables

        byte[] Imagen = null;
        Panel oPanel = null;
        PictureBox oPict = null;

        /// <summary>
        /// La que contiene la flecha indicando cual es la que tiene el foco
        /// </summary>
        PictureBox oPict2 = new PictureBox();
        PictureBox auxPBox = null;
        string direccImage = "";
        Graphics oGraphics;
        GraphicsPath oGraphicsPath = new GraphicsPath();
        Image oImagenActual = null;

        int containerHeight = 0;

        int totalPicturesWidth = 0;

        public int ContainerHeight
        {
            get { return containerHeight; }
            set { containerHeight = value; }
        }

        int containerWidth = 0;

        int globalIndex = 0;

        int selectedIndex = -1;

        public int ContainerWidth
        {
            get { return containerWidth; }
            set { containerWidth = value; }
        }

        #endregion

        List<GlobalElementsValues> oListGlobalElementsValues = new List<GlobalElementsValues>();
        public List<GlobalElementsValues> OListGlobalElementsValues
        {
            get { return oListGlobalElementsValues; }
            set { oListGlobalElementsValues = value; }
        }

        GlobalElementsValues tempElementsValues = new GlobalElementsValues();

        public PhotoAlbum()
        {
            InitializeComponent();
        }

        private void CalcularTamañoMaximoLienzoConImagen(Image pImage, PictureBox pBoxImage)
        {
            double promedio = 0;
            double ancho = 0;
            double altura = 0;

            pBoxImage.Image = pImage;

            promedio = Convert.ToDouble(pImage.Size.Height) / Convert.ToDouble(pImage.Size.Width);

            pBoxImage.SizeMode = PictureBoxSizeMode.Normal;
            altura = panel2.Height - 45;

            ancho = altura / promedio;

            while ((ancho + 22) > panel2.Width)
            {
                altura -= 1;
                ancho = altura / promedio;
            }

            pBoxImage.Height = Convert.ToInt32(altura);
            pBoxImage.Width = Convert.ToInt32(ancho);

            pBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void Clear()
        {
            flowLayoutPanel1.Controls.Clear();
            panel1.Visible = false;
            label1.Visible = true;
        }

        private void VisualizarImagen(Image oImage)
        {
            try
            {
                Image newImage = oImage;

                if (newImage.Size.Height > panel2.Height - 25 || newImage.Size.Width > panel2.Width - 25)
                    CalcularTamañoMaximoLienzoConImagen(newImage, pictureBox1);
                else
                {
                    pictureBox1.Image = newImage;
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                }


                int X = 0, Y = 0;
                Y = pictureBox1.Size.Height + 22;
                X = pictureBox1.Size.Width + 22;

                panel1.Size = new Size(X, Y);

                Y = 0;
                Y = panel1.Height + 15;

                pictureBox1.Location = new Point(11, 11);

                panel1.Top = (panel2.Height - panel1.Height) / 2;
                panel1.Left = (panel2.Width - panel1.Width) / 2;

                panel1.Region = Shape.RoundedRegion(panel1.Size, 3, Shape.Corner.None);

                if (panel1.Visible == false)
                    panel1.Visible = true;

                ColocarFlechas();
            }
            catch { }
        }

        public void AñadirImagenes()
        {
            int index = 0;
            totalPicturesWidth = 0;
            oPict2.Visible = false;

            foreach (GlobalElementsValues oElement in oListGlobalElementsValues)
            {
                try
                {
                    oPanel = new Panel();
                    oPanel.BackColor = Color.Transparent;

                    oPict = new PictureBox();
                    oPict.Size = new Size(100, 100);

                    oPanel.Size = new Size(100, 100 + 24);//10 extra y 14 del tamaño de la imagen de la flecha

                    oPict.Image = Properties.Resources.frame2;
                    oPict.SizeMode = PictureBoxSizeMode.StretchImage;
                    oPict.BackgroundImage = oElement.OImage;
                    oPict.BackgroundImageLayout = ImageLayout.Stretch;
                    oPict.Region = Shape.RoundedRegion(oPict.Size, 3, Shape.Corner.None);
                    oPict.Name = index.ToString();

                    oPict.Tag = oElement;

                    oGraphics = oPict.CreateGraphics();
                    oGraphicsPath.AddRectangle(oPict.Bounds);

                    oPict.MouseEnter += new EventHandler(oPict_MouseEnter);
                    oPict.MouseLeave += new EventHandler(oPict_MouseLeave);

                    oPanel.Controls.Add(oPict);
                    oPanel.Controls.Add(oPict2);

                    oPict2.Location = new Point(0, 0);
                    //oPict2.Location = new Point(((oPict.Width - oPict2.Width) / 2), oPict.Height);

                    flowLayoutPanel1.Controls.Add(oPanel);

                    totalPicturesWidth += oPanel.Width + 6;//se suman tanto los márgenes derechos como izquierdos equivalentes a 3 en c/u
                }
                catch
                {
                    oPict2.Location = new Point(0, 0);
                    //oPict2.Location = new Point(((oPict.Width - oPict2.Width) / 2), oPict.Height);

                    flowLayoutPanel1.Controls.Add(oPanel);
                }
                index++;
            }

            flowLayoutPanel1.Width = totalPicturesWidth;

            if (panel4.Visible == false)
            {
                panel4.Visible = true;
                btnOcultarVistaPrevia.Visible = true;
                btnMostrarVistaPrevia.Visible = false;
            }
        }

        void oPict_MouseLeave(object sender, EventArgs e)
        {
            //panelOpcionesImagenes.Visible = false;
            //panel11.Visible = false;
        }

        private void MostrarFocoImagen(Control oParent)
        {
            oPict2.Visible = true;
            oPict2.Parent = oParent;
            oPict2.Location = new Point(((oPict.Width - oPict2.Width) / 2), oPict.Height);
            //oPict2.Location = new Point(30, 100);
        }

        void oPict_MouseEnter(object sender, EventArgs e)
        {
            if (btnOcultarVistaPrevia.Visible == true)
            {
                PictureBox pb = (PictureBox)sender;

                //try
                //{
                    tempElementsValues = (GlobalElementsValues)pb.Tag;

                    VisualizarImagen(pb.BackgroundImage);
                    globalIndex = tempElementsValues.OIndex;
                    oImagenActual = pb.BackgroundImage;

                    MostrarFocoImagen(pb.Parent);

                    auxPBox = pb;
                    direccImage = pb.Tag.ToString().Trim();
                //}
                //catch { }
                //finally { }
            }
        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
                label1.Visible = false;
            else
                label1.Visible = true;
        }

        private void tobLeft_Click(object sender, EventArgs e)
        {
            int x = flowLayoutPanel1.Location.X + 500;

            if (x > 0)
                x = toolStrip2.Width;

            Transition t = new Transition(new TransitionType_EaseInEaseOut(350));
            t.add(flowLayoutPanel1, "Left", x);
            t.run();
        }

        private void tobRight_Click(object sender, EventArgs e)
        {
            int x = flowLayoutPanel1.Location.X - 500;

            if ((x + flowLayoutPanel1.Width) < toolStrip1.Location.X)
                x = toolStrip1.Location.X - flowLayoutPanel1.Width;

            Transition t = new Transition(new TransitionType_EaseInEaseOut(350));
            t.add(flowLayoutPanel1, "Left", x);
            t.run();
        }

        private void PhotoAlbum_Load(object sender, EventArgs e)
        {
            btnNext.Parent = pictureBox1;
            btnPrevious.Parent = pictureBox1;

            oPict2.Image = Properties.Resources.arrow_up;
            oPict2.SizeMode = PictureBoxSizeMode.AutoSize;
            oPict2.Visible = false;

            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.Location = new Point(toolStrip2.Width, 0);
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (null);
        }

        public static byte[] ConvertImageToBytes(Image image)
        {
            if (image != null)
            {
                MemoryStream ms = new MemoryStream();

                using (ms)
                {
                    image.Save(ms, ImageFormat.Bmp);
                    byte[] bytes = ms.ToArray();

                    return bytes;
                }
            }
            else
            {
                return null;
            }
        }

        //private Image DeterminaImagenSeleccionada()
        //{
        //    Image oImage = null;

        //    foreach (Control o in flowLayoutPanel1.Controls)
        //    {
        //        if (o.Tag.ToString().Trim() == pictureBox1.Tag.ToString().Trim())
        //        {
        //            oImage = ((PictureBox)(o)).BackgroundImage;
        //            break;
        //        }
        //    }

        //    return oImage;
        //}

        private void btnGuardarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|*.jpg";
                saveFileDialog1.Title = "Guardar Imagen a Disco Duro";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    Imagen = tempElementsValues.OBytes;
                    string sImagenTemporal = saveFileDialog1.FileName;

                    string sBase64 = "";
                    sBase64 = Convert.ToBase64String(Imagen);

                    FileStream fs = new FileStream(sImagenTemporal, FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);
                    byte[] bytes;

                    try
                    {
                        bytes = Convert.FromBase64String(sBase64);
                        MessageBox.Show("La imagen fue guardada satisfactoriamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            catch { MessageBox.Show("Ocurrió un error al leer la imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1); }
        }

        private void flowLayoutPanel1_LocationChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Update();
        }

        private void ColocarFlechas()
        {
            btnPrevious.SuspendLayout();
            btnPrevious.Location = new Point(5, (pictureBox1.Height - btnPrevious.Height) / 2);
            btnPrevious.ResumeLayout();

            btnNext.SuspendLayout();
            btnNext.Location = new Point(pictureBox1.Width - btnNext.Width - 7, (pictureBox1.Height - btnPrevious.Height) / 2);
            btnNext.ResumeLayout();

            //btnPrevious.Refresh();
        }

        private void btnOcultarVistaPrevia_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;

            btnNext.Visible = true;
            btnPrevious.Visible = true;

            btnMostrarVistaPrevia.Visible = true;
            btnOcultarVistaPrevia.Visible = false;

            VisualizarImagen(oImagenActual);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                VisualizarImagen(oListGlobalElementsValues[globalIndex - 1].OImage);
                globalIndex--;

                foreach (Control o in flowLayoutPanel1.Controls)
                {
                    if (o is PictureBox)
                    {
                        if (((GlobalElementsValues)(o.Tag)).OIndex == globalIndex)
                            MostrarFocoImagen(o);

                        break;
                    }
                }
            }
            catch { }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                VisualizarImagen(oListGlobalElementsValues[globalIndex + 1].OImage);
                globalIndex++;

                foreach (Control o in flowLayoutPanel1.Controls)
                {
                    if (o is PictureBox)
                    {
                        if (((GlobalElementsValues)(o.Tag)).OIndex == globalIndex)
                            MostrarFocoImagen(o);

                        break;
                    }
                }
            }
            catch { }
        }

        private void btnMostrarVistaPrevia_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;

            btnNext.Visible = false;
            btnPrevious.Visible = false;

            btnMostrarVistaPrevia.Visible = false;
            btnOcultarVistaPrevia.Visible = true;

            Point oPoint = new Point();
            oPoint = btnOcultarVistaPrevia.PointToScreen(btnOcultarVistaPrevia.Location);
            oPoint.X = oPoint.X + this.btnOcultarVistaPrevia.Location.X + 51;
            oPoint.Y = this.btnOcultarVistaPrevia.Location.Y + 54;

            Cursor.Position = oPoint;

            VisualizarImagen(oImagenActual);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (btnMostrarVistaPrevia.Visible == true)
            {
                EventArgs e2 = new EventArgs();

                if (e.Button == MouseButtons.Left)
                    btnNext_Click(sender, e2);
                else
                    btnPrevious_Click(sender, e2);
            }
        }

        public void PhotoAlbum_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnMostrarVistaPrevia.Visible == true)
            {
                EventArgs e2 = new EventArgs();

                if (e.KeyCode == Keys.Right)
                    btnNext_Click(sender, e2);
                else if (e.KeyCode == Keys.Left)
                    btnPrevious_Click(sender, e2);
            }
        }
    }
}