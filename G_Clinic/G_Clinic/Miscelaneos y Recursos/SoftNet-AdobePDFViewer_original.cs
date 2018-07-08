using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Interfaz_Grafica;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class SoftNet_AdobePDFViewer_original : UserControl
    {
        string fileLocation = "";
        public string FileLocation
        {
            get { return fileLocation; }
            set { fileLocation = value; }
        }

        public SoftNet_AdobePDFViewer_original()
        {
            InitializeComponent();
        }

        public void CloseDocument()
        {
            axAcroPDF1.LoadFile("");
        }

        public void OpenDocument()
        {
            axAcroPDF1.LoadFile(FileLocation);
        }

        private void SoftNet_AdobePDFViewer_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void SoftNet_AdobePDFViewer_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void SoftNet_AdobePDFViewer_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btnFullSize_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(FileLocation))
                {
                    frmPDFViewer ofrmPDFViewer = new frmPDFViewer(FileLocation);
                    ofrmPDFViewer.Show(this);
                }
            }
            catch { }
        }
    }
}
