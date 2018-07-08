using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using G_Clinic.Miscelaneos_y_Recursos.ImageViewerControl;
using G_Clinic.Miscelaneos_y_Recursos;
using System.IO;
using System.Collections;
using System.Collections.Specialized;

namespace G_Clinic
{
    public partial class ImageDialog : Form
    {
        frmDarkBackground ofrmDarkBackground = new frmDarkBackground();
        string oImagePath = "";
        Thread thread = null;

        string path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");
        ArrayList oValues = new ArrayList();

        public ImageDialog(Size pSize, ArrayList pValues)
        {
            InitializeComponent();
            this.Size = pSize;
            oValues = pValues;

            this.imageViewerFull.ImageNumber = (int)pValues[0];
            this.imageViewerFull.ImageBytes = (byte[])pValues[1];
            this.imageViewerFull.TempImageLocation = (string)pValues[2];

            this.Region = Shape.RoundedRegion(this.Size, 7, Shape.Corner.None);
        }

        public void SetImage(string filename)
        {
            thread = new Thread(new ParameterizedThreadStart(SetImageIntern));
            thread.IsBackground = true;
            thread.Start(filename);
        }

        private void SetImageIntern(object filename)
        {
            this.imageViewerFull.BackgroundImage = Image.FromFile((string)filename);
            this.imageViewerFull.Invalidate();
            oImagePath = (string)filename;
            //this.imageViewerFull.BackgroundImage
        }

        private void ImageDialog_Resize(object sender, EventArgs e)
        {
            this.imageViewerFull.Invalidate();
        }

        private void ImageDialog_Load(object sender, EventArgs e)
        {
            panel1.Parent = imageViewerFull;
            panel1.Location = new Point(this.Width - panel1.Width - 5, 5);
            ofrmDarkBackground.Show();
        }

        private void ImageDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            ofrmDarkBackground.Close();
        }

        private void EditImage(string pFileName)
        {
            string completeFileName = this.imageViewerFull.TempImageLocation;

            File.Copy(pFileName, completeFileName, true);
            
            //int option = -1;

            if (File.Exists(@"C:\Program Files\Paint.NET\PaintDotNet.exe"))
            {
                MessageBox.Show(completeFileName);
                System.Diagnostics.Process.Start(@"C:\Program Files\Paint.NET\PaintDotNet.exe", completeFileName).WaitForExit();
                //System.Diagnostics.ProcessStartInfo o = new System.Diagnostics.ProcessStartInfo();
                //o.FileName = completeFileName;
                //o.LoadUserProfile = true;
                //o.Arguments = completeFileName;

                //System.Diagnostics.Process p1 = new System.Diagnostics.Process();
                //p1.StartInfo.FileName = @"C:\Program Files\Paint.NET\PaintDotNet.exe";
                //p1.EnableRaisingEvents = true;
                //p1.SynchronizingObject = this;
                //p1.StartInfo.Arguments = completeFileName;//img.Tag.ToString();//pFileName;//
                //p1.Exited += new EventHandler(p1_Exited);

                //p1.Start();
            }
            oImagePath = pFileName;//path + Path.GetFileName(oImagePath);
        }

        private void tobEditImage_Click(object sender, EventArgs e)
        {
            //DialogResult oResult = MessageBox.Show(this, "¿Desea modificar el archivo original con los cambios apunto de realizar?",
            //              "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            //if (oResult == DialogResult.Yes)
            //{
            //    string fileCopy = Path.GetDirectoryName(oImagePath) + "\\" + Path.GetFileName(oImagePath).Replace(Path.GetFileNameWithoutExtension(oImagePath), Path.GetFileNameWithoutExtension(oImagePath) + " (Copy)");
                    
            //    File.Copy(oImagePath, fileCopy);

            //    if (File.Exists(fileCopy))
            //        EditImage(fileCopy);
            //}
            //else if (oResult == DialogResult.No)
                EditImage(oImagePath);
        }

        void p1_Exited(object sender, EventArgs e)
        {
            //File.Copy(imageViewerFull.TempImageLocation, path + Path.GetFileName(oImagePath));
            //this.imageViewerFull.BackgroundImage = Image.FromFile(oImagePath);

            //this.imageViewerFull.ImageLocation = oImagePath;
            //this.imageViewerFull.ImageBytes = File.ReadAllBytes(oImagePath);
            //MessageBox.Show("Yey!!!");
        }

        private void tobPen_Click(object sender, EventArgs e)
        {

        }

        private void tobRectangulo_Click(object sender, EventArgs e)
        {

        }

        private void tobCirculo_Click(object sender, EventArgs e)
        {

        }

        private void tobTexto_Click(object sender, EventArgs e)
        {

        }

        private void tobLinea_Click(object sender, EventArgs e)
        {

        }

        private void ImageDialog_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ImageDialog_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void ImageDialog_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void ImageDialog_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void tobColor_Click(object sender, EventArgs e)
        {
            
        }

        private void imageViewerFull_Load(object sender, EventArgs e)
        {

        }
    }
}