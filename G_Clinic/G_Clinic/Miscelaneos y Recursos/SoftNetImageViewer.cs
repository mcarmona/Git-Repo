using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Threading;
using G_Clinic.Interfaz_Grafica;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class SoftNetImageViewer : UserControl
    {
        #region Variables

        OpenFileDialog openFileDialog1 = null;
        int numImage;
        public PictureBox oPict = null;
        bool nuevo;
        List<Byte[]> oArregloBytesImagenes = null;
        List<Control> oObjectList = null;
        PictureBox auxPBox = null;
        string direccImage = "";

        Size pictSize = new Size();
        public Size PictSize
        {
            get { return pictSize; }
            set { pictSize = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        List<GlobalElementsValues> globalElementsDetails = new List<GlobalElementsValues>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<GlobalElementsValues> GlobalElementsDetails
        {
            get { return globalElementsDetails; }
            set { globalElementsDetails = value; }
        }

        GlobalElementsValues tempElementsValues = new GlobalElementsValues();
        GlobalElementsValues oGlobalElementsValues = new GlobalElementsValues();

        public bool Nuevo
        {
            get { return nuevo; }
            set { nuevo = value; }
        }        

        #endregion

        #region Diseño de interfaz

        private void SetStyles()
        {
            //Makes sure the form repaints when it was resized
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }        

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion

        public SoftNetImageViewer()
        {
            InitializeComponent();

            openFileDialog1 = new OpenFileDialog();
            numImage = 0;
            nuevo = Nuevo;
            oArregloBytesImagenes = new List<byte[]>();
            oObjectList = new List<Control>();

            if (PictSize.Height == 0 && PictSize.Width == 0)
                PictSize = new Size(180, 180);
        }

        public void EnableButtons(bool pEnableAdd, bool pEnableDelete, bool pEnableAlbum, bool pEnablePreview)
        {
            tobEliminarImage.Enabled = pEnableDelete;
            btnAgregarImagen.Enabled = pEnableAdd;
            btnPhotoAlbum.Enabled = pEnableAlbum;
            tobMagnifyImage.Enabled = pEnablePreview;
        }

        public void AddSingleImage(GlobalElementsValues oElement)
        {
            numImage = flowLayoutPanel1.Controls.Count;

            if (numImage < 0)
                numImage = 0;

            numImage++;

            oPict = new PictureBox();
            oPict.Size = PictSize;
            oPict.Image = Properties.Resources.frame2;
            oPict.SizeMode = PictureBoxSizeMode.StretchImage;

            oPict.BackgroundImage = oElement.OImage;

            oPict.BackgroundImageLayout = ImageLayout.Stretch;
            oPict.Region = Shape.RoundedRegion(oPict.Size, 3, Shape.Corner.None);

            oPict.Name = numImage.ToString();

            oPict.MouseEnter += new EventHandler(oPict_MouseEnter);
            oPict.MouseLeave += new EventHandler(oPict_MouseLeave);

            flowLayoutPanel1.Controls.Add(oPict);

            GlobalElementsDetails.Add(oElement);

            oPict.Tag = GlobalElementsDetails[numImage - 1];            
        }

        public void AddImages(FlowLayoutPanel pFlowPanel, string[] pFileNames, PictureBox pPict, int pStep, ProgressBar pBar)
        {
            try
            {
                if (globalElementsDetails == null)
                    globalElementsDetails = new List<GlobalElementsValues>();

                if (pFileNames.Length <= 250)
                {
                    pBar.Step = pStep;

                    foreach (string oFileName in pFileNames)
                    {
                        Application.DoEvents();

                        numImage = pFlowPanel.Controls.Count;

                        if (numImage < 0)
                            numImage = 0;

                        numImage++;

                        pPict = new PictureBox();
                        pPict.Size = PictSize;
                        pPict.Image = Properties.Resources.frame2;
                        pPict.SizeMode = PictureBoxSizeMode.StretchImage;

                        pPict.BackgroundImage = SafeImage.NonLockingOpen(oFileName.Trim());

                        pPict.BackgroundImageLayout = ImageLayout.Stretch;
                        pPict.Region = Shape.RoundedRegion(pPict.Size, 3, Shape.Corner.None);

                        if (nuevo == true)
                            pPict.Tag = oFileName.Trim();
                        else
                            pPict.Tag = numImage.ToString();

                        pPict.Name = numImage.ToString();

                        pPict.MouseEnter += new EventHandler(oPict_MouseEnter);
                        pPict.MouseLeave += new EventHandler(oPict_MouseLeave);

                        oGlobalElementsValues = new GlobalElementsValues(); 
                        oGlobalElementsValues.OIndex = numImage - 1;
                        oGlobalElementsValues.OFileName = pPict.Tag.ToString();
                        oGlobalElementsValues.OImage = pPict.BackgroundImage;
                        oGlobalElementsValues.OBytes = File.ReadAllBytes(oFileName.Trim());

                        globalElementsDetails.Add(oGlobalElementsValues);

                        pPict.Tag = globalElementsDetails[numImage - 1];

                        pFlowPanel.Controls.Add(pPict);

                        pBar.PerformStep();
                    }
                }
                else
                    MessageBox.Show(this, "Por motivos de desempeño, no se permite agregar más de 250 imágenes a la vez", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch { }
        }

        public void AddImages(List<GlobalElementsValues> pListGlobalElement)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();

                progressBar1.Step = 1;
                progressBar1.Maximum = pListGlobalElement.Count;

                foreach (GlobalElementsValues oElement in pListGlobalElement)
                {
                    Application.DoEvents();

                    numImage = flowLayoutPanel1.Controls.Count;

                    if (numImage < 0)
                        numImage = 0;

                    numImage++;

                    oPict = new PictureBox();
                    oPict.Size = PictSize;
                    oPict.Image = Properties.Resources.frame2;
                    oPict.SizeMode = PictureBoxSizeMode.StretchImage;

                    oPict.BackgroundImage = oElement.OImage;

                    oPict.BackgroundImageLayout = ImageLayout.Stretch;
                    oPict.Region = Shape.RoundedRegion(oPict.Size, 3, Shape.Corner.None);

                    oPict.Name = numImage.ToString();

                    oPict.MouseEnter += new EventHandler(oPict_MouseEnter);
                    oPict.MouseLeave += new EventHandler(oPict_MouseLeave);

                    flowLayoutPanel1.Controls.Add(oPict);

                    oPict.Tag = pListGlobalElement[numImage - 1];

                    progressBar1.PerformStep();

                }
                globalElementsDetails = pListGlobalElement;
            }
            catch { }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                numImage = flowLayoutPanel1.Controls.Count;

                if (numImage < 0)
                    numImage = 0;

                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|*.png|BMP(*.bmp)|*.bmp|Todos(*.Jpg, *.Png, *.Jpeg, *.Bmp)|*.Jpg; *.Png; *.Jpeg; *.Bmp";
                openFileDialog1.FilterIndex = 4;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.Multiselect = true;

                DialogResult Respuesta = openFileDialog1.ShowDialog();

                if (Respuesta != DialogResult.Cancel)
                {
                    progressBar1.Maximum = openFileDialog1.FileNames.Length;
                    AddImages(flowLayoutPanel1, openFileDialog1.FileNames, oPict, 1, progressBar1);
                    progressBar1.Value = progressBar1.Maximum;
                }
            }
            catch
            {
                MessageBox.Show(this, "Error al Cargar la imagen", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        void oPict_MouseLeave(object sender, EventArgs e)
        {
            panelOpcionesImagenes.Visible = false;
        }

        void oPict_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            try
            {
                tempElementsValues = (GlobalElementsValues)pb.Tag;
                panel11.Parent = pb;

                auxPBox = pb;//We create temp object so we can dispose it

                panel11.Location = new Point((pb.Width - panel11.Width) - 10, (pb.Height - panel11.Height) - 10);
                panel11.BringToFront();
                panel11.Visible = true;
            }
            catch { }
            finally { }
        }

        private void tobEliminarImage_Click(object sender, EventArgs e)
        {
            globalElementsDetails.Remove(tempElementsValues);// .RemoveAt(tempElementsValues.OIndex);

            panel11.Visible = false;
            panel11.Parent = null;
            auxPBox.Dispose();
        }

        private void tobMagnifyImage_Click(object sender, EventArgs e)
        {
            FrmBlackBackground oFrmBlackBackground = new FrmBlackBackground();

            try
            {
                oFrmBlackBackground.Show();

                bool allowEdit = false;
                if (btnAgregarImagen.Enabled == true)
                    allowEdit = true;

                FrmImagenAmpliada oFrmImagenAmpliada = new FrmImagenAmpliada(tempElementsValues.OBytes, allowEdit);
                oFrmImagenAmpliada.ShowDialog();

                oFrmBlackBackground.Close();
            }
            catch { }
            finally { oFrmBlackBackground.Dispose(); }
        }

        private void btnPhotoAlbum_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                FrmBlackBackground oFrmBlackBackground = new FrmBlackBackground();
                oFrmBlackBackground.Show();
                frmPhotoAlbum ofrmPhotoAlbum = new frmPhotoAlbum(globalElementsDetails);

                ofrmPhotoAlbum.ShowDialog();
                oFrmBlackBackground.Close();
            }
        }
    }
}