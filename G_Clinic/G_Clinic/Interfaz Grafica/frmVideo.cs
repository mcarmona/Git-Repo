using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmVideo : Form
    {
        public frmVideo()
        {
            InitializeComponent();
            this.Region = Shape.RoundedRegion(this.Size, 8, Shape.Corner.None);
        }

        string[] fileNames;
        public string[] FileName
        {
            get { return fileNames; }
            set { fileNames = value; }
        }

        private void imagenCambiantePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVideo_Load(object sender, EventArgs e)
        {
            try
            {
                if (fileNames.Length > 0)
                    softNetVideoControl1.AddFiles(fileNames);
            }
            catch {
                //Do Nothing
            }
        }
    }
}
