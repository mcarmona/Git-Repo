using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PdfSharp.Drawing;
using System.IO;
using PdfSharp.Pdf;
using System.Collections;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class SoftNet_IMGtoPDF : UserControl
    {        
        public bool ConvertButtonVisible
        {
            set { btnConvertirPDF.Visible = value; }
            get { return btnConvertirPDF.Visible; }
        }

        public SoftNet_IMGtoPDF()
        {
            InitializeComponent();
            softNet_AdobePDFViewer1.Region = Shape.RoundedRegion(softNet_AdobePDFViewer1.Size, 4, Shape.Corner.None);
            softNetImageViewer3.Nuevo = true;
        }

        private XSize ImageSize(PdfPage pPage, XImage pImage)
        {
            double promedio = 0;
            double ancho = 0;
            double altura = 0;

            promedio = pPage.Height / pPage.Width;

            if (pImage.PointWidth > pPage.Width || pImage.PointHeight > pPage.Height)
            {
                promedio = Convert.ToDouble(pImage.PointHeight) / Convert.ToDouble(pImage.PointWidth);

                altura = pPage.Height - 45;
                ancho = altura / promedio;

                while ((ancho + 15) > pPage.Width)
                {
                    altura--;
                    ancho = altura / promedio;
                }
            }
            else
            {
                ancho = pImage.PointWidth;
                altura = pImage.PointHeight;
            }
            return new XSize(ancho, altura);
        }
        
        private string ConvertImage(byte[] image, PdfPage pPage)
        {
            string path = "";
            Image oImage = Metodos_Globales.CreateTempImageFromByteArray(image, out path);

            //if (oImage != null)
            //{
            //    oImage = ImageResizer.ResizeImage(path, path, Convert.ToInt32(pPage.Width.Value), Convert.ToInt32(pPage.Height.Value), true);
            //}
            //else
            //    MessageBox.Show(this, "¿Hubo un problema con la creación de la imagen temporal, por favor intente de nuevo. Si el problema persiste comuníquese con la persona que da soporte a su empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            return path;
        }

        public void btnConvertirPDF_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                oPicLoading.Visible = true;
                lblProcesando.Visible = true;

                string fileName = "";
                string completeFileName = "";
                string path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");

                try
                {
                    fileName = "\\TempFile_PDF.pdf";
                    completeFileName = path + fileName;
                    File.Delete(completeFileName);
                }
                catch
                {
                    MessageBox.Show(this, "No se puede crear el archivo/reporte ya que otro está actualmente en uso, cierre el archivo temporal en uso primero y vuelva a intentar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                double xPos = 0;
                double yPos = 0;

                PdfDocument doc = new PdfDocument();

                int cont = 0;
                #region MyRegion
                //foreach (GlobalElementsValues oElement in softNetImageViewer3.GlobalElementsDetails)
                //{
                //    Application.DoEvents();

                //    doc.Pages.Add(new PdfPage());
                //    XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[cont]);
                //    XImage img = XImage.FromFile(oElement.OFileName);

                //    XSize oSize = ImageSize(doc.Pages[cont], img);

                //    if (doc.Pages[cont].Width > img.PointWidth)
                //        xPos = (doc.Pages[cont].Width - img.PointWidth) / 2;
                //    else
                //        xPos = (img.PointWidth - doc.Pages[cont].Width) / 2;

                //    yPos = (doc.Pages[cont].Height - img.PointHeight) / 2;

                //    xgr.DrawImage(img, xPos, yPos, oSize.Width, oSize.Height);

                //    xgr.Dispose();
                //    img.Dispose();
                //    cont++;
                //} 
                #endregion

                string filename = textBox1.Text.Trim();
                foreach (ListViewItem oItem in listView1.Items)
                {
                    Application.DoEvents();

                    doc.Pages.Add(new PdfPage());
                    XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[cont]);

                    //string path1 = ConvertImage(File.ReadAllBytes(filename + "\\" + oItem.Text.Trim()), doc.Pages[cont]);
                    XImage img = XImage.FromFile(filename + "\\" + oItem.Text.Trim());//oElement.OFileName);//path1) ;                    
 
                    XSize oSize = ImageSize(doc.Pages[cont], img);//img.Size;

                    //img.Size.Height = oSize.Height;

                    if (doc.Pages[cont].Width > oSize.Width)//img.PointWidth)
                        xPos = (doc.Pages[cont].Width - oSize.Width) / 2;//img.PointWidth) / 2;
                    else
                        xPos = (oSize.Width - doc.Pages[cont].Width) / 2;//(img.PointWidth - doc.Pages[cont].Width) / 2;

                    yPos = (doc.Pages[cont].Height - oSize.Height) / 2;//img.PointHeight) / 2;

                    xgr.DrawImage(img, xPos, yPos, oSize.Width, oSize.Height);

                    xgr.Dispose();
                    img.Dispose();
                    xgr = null;
                    img = null;

                    cont++;

                    //File.Delete(path1);
                }

                try
                {
                    doc.Save(completeFileName);
                }
                catch { MessageBox.Show(this, "No se puede generar el archivo si no hay imágenes disponibles", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                doc.Close();
                doc.Dispose();

                oPicLoading.Visible = false;
                lblProcesando.Visible = false;

                softNet_AdobePDFViewer1.FileLocation = completeFileName;
                softNet_AdobePDFViewer1.OpenDocument();
            }
            else
            {
                MessageBox.Show(this, "No se puede generar el archivo si no hay imágenes disponibles", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|*.png|BMP(*.bmp)|*.bmp|Todos(*.Jpg, *.Png, *.Jpeg, *.Bmp)|*.Jpg; *.Png; *.Jpeg; *.Bmp";
            openFileDialog1.FilterIndex = 4;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;

            DialogResult Respuesta = openFileDialog1.ShowDialog();

            if (Respuesta != DialogResult.Cancel)
            {
                textBox1.Text = Path.GetDirectoryName(openFileDialog1.FileName);
                listView1.Items.Clear();
                ArrayList oList = new ArrayList();
                oList.AddRange(openFileDialog1.FileNames);

                foreach (string oFileName in oList)
                    listView1.Items.Add(new ListViewItem(Path.GetFileName(oFileName.Trim())));
            }
        }
    }
}