using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
using System.IO;

namespace G_Clinic.Miscelaneos_y_Recursos.ImageViewerControl
{
    public partial class SoftNetImageViewer : UserControl
    {
        public event ThumbnailImageEventHandler OnImageSizeChanged;

        private ThumbnailController m_Controller;

        private ImageDialog m_ImageDialog;

        private ImageViewerCtrl m_ActiveImageViewerCtrl;        

        private int ImageSize
        {
            get
            {
                return (165);//64 * (this.trackBarSize.Value + 1));
            }
        }

        public SoftNetImageViewer()
        {
            InitializeComponent();

            //m_ImageDialog = new ImageDialog(new Size(0, 0));

            m_AddImageDelegate = new DelegateAddImage(this.AddImage);

            m_Controller = new ThumbnailController();
            m_Controller.OnStart += new ThumbnailControllerEventHandler(m_Controller_OnStart);
            m_Controller.OnAdd += new ThumbnailControllerEventHandler(m_Controller_OnAdd);
            m_Controller.OnEnd += new ThumbnailControllerEventHandler(m_Controller_OnEnd);
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(GC.GetTotalMemory(true).ToString());
            this.AddFolder();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.m_Controller.CancelScanning = true;
        }

        private void AddFolder()
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = @"Choose folder path";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.flowLayoutPanelMain.Controls.Clear();
                m_Controller.AddFolder(dlg.SelectedPath);
                //this.buttonCancel.Enabled = true;
                this.btnAgregarImagen.Enabled = false;                
            }
        }

        private void m_Controller_OnStart(object sender, ThumbnailControllerEventArgs e)
        {

        }

        private void m_Controller_OnAdd(object sender, ThumbnailControllerEventArgs e)
        {
            this.AddImage(e.ImageFilename, e.Counter);
            this.Invalidate();
        }

        private void m_Controller_OnEnd(object sender, ThumbnailControllerEventArgs e)
        {
            // thread safe
            if (this.InvokeRequired)
            {
                this.Invoke(new ThumbnailControllerEventHandler(m_Controller_OnEnd), sender, e);
            }
            else
            {
                this.btnCancel.Enabled = false;
                this.btnAgregarImagen.Enabled = true;

                MessageBox.Show(GC.GetTotalMemory(true).ToString());
            }
        }

        delegate void DelegateAddImage(string imageFilename, int imageNumber);

        private DelegateAddImage m_AddImageDelegate;

        private void AddImage(string imageFilename, int imageNumber)
        {
            // thread safe
            if (this.InvokeRequired)
            {
                this.Invoke(m_AddImageDelegate, imageFilename, imageNumber);
            }
            else
            {
                int size = ImageSize;

                ImageViewerCtrl ImageViewerCtrl = new ImageViewerCtrl();
                ImageViewerCtrl.Dock = DockStyle.Bottom;
                ImageViewerCtrl.LoadImage(imageFilename, 256, 256);

                ImageViewerCtrl.TempImageLocation = Path.GetTempPath() + Path.GetFileName(imageFilename);
                ImageViewerCtrl.ImageBytes = File.ReadAllBytes(imageFilename);
                ImageViewerCtrl.Width = size;
                ImageViewerCtrl.Height = size;
                ImageViewerCtrl.IsThumbnail = true;
                
                //ImageViewerCtrl.Tag = 
                ImageViewerCtrl.MouseClick += new MouseEventHandler(ImageViewerCtrl_MouseClick);

                this.OnImageSizeChanged += new ThumbnailImageEventHandler(ImageViewerCtrl.ImageSizeChanged);                

                ImageViewerCtrl.MouseEnter += new EventHandler(ImageViewerCtrl_MouseEnter);

                this.flowLayoutPanelMain.Controls.Add(ImageViewerCtrl);
            }
        }        

        void ImageViewerCtrl_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (panel11.Parent != (ImageViewerCtrl)sender)
                {
                    m_ActiveImageViewerCtrl = (ImageViewerCtrl)sender;

                    panel11.Location = new Point(((ImageViewerCtrl)sender).Width - panel11.Width - 3,
                                                 ((ImageViewerCtrl)sender).Height - panel11.Height - 3);
                    panel11.BringToFront();
                    panel11.Visible = true;

                    panel11.Parent = (ImageViewerCtrl)sender;
                }
            }
            catch { }
        }

        private void ImageViewerCtrl_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void trackBarSize_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.OnImageSizeChanged(this, new ThumbnailImageEventArgs(ImageSize));
            }
            catch { }
        }

        private Size MaximizedImageSize()
        {
            Image oImage = Image.FromFile(m_ActiveImageViewerCtrl.ImageLocation);
            double promedio = 0, altura = 0, ancho = 0;

            if (oImage.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                promedio = Convert.ToDouble(oImage.Size.Height) / Convert.ToDouble(oImage.Size.Width);

                altura = Screen.PrimaryScreen.WorkingArea.Height - 45;
                ancho = altura / promedio;

                while ((ancho + 95) > Screen.PrimaryScreen.WorkingArea.Width)
                {
                    altura -= 1;
                    ancho = altura / promedio;
                }
            }
            else
            {
                ancho = oImage.Width; 
                altura = oImage.Height;
            }

            return new Size((int)ancho, (int)altura);
        }

        private void tobMagnifyImage_Click(object sender, EventArgs e)
        {
            m_ActiveImageViewerCtrl.IsActive = true;
                
            //if (m_ImageDialog.IsDisposed) 

            ArrayList oImageValues = new ArrayList();
            oImageValues.Add(m_ActiveImageViewerCtrl.ImageNumber);
            oImageValues.Add(m_ActiveImageViewerCtrl.ImageBytes);
            oImageValues.Add(m_ActiveImageViewerCtrl.TempImageLocation);

            m_ImageDialog = new ImageDialog(MaximizedImageSize(), oImageValues);
            if (!m_ImageDialog.Visible) m_ImageDialog.Show();

            m_ImageDialog.SetImage(m_ActiveImageViewerCtrl.ImageLocation);
        }

        private void tobEliminarImage_Click(object sender, EventArgs e)
        {
            panel11.Parent = null;
            m_ActiveImageViewerCtrl.Dispose();            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.m_Controller.CancelScanning = true;
        }
    }
}
