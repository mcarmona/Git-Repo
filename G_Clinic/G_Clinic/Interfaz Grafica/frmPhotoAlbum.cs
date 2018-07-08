using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmPhotoAlbum : Form
    {
        List<GlobalElementsValues> oGlobalElementValues = new List<GlobalElementsValues>();
        
        public frmPhotoAlbum(List<GlobalElementsValues> pGlobalElementsValues)
        {
            InitializeComponent();

            oGlobalElementValues = pGlobalElementsValues;
        }

        private void frmPhotoAlbum_Load(object sender, EventArgs e)
        {
            this.MaximumSize = Program.oMDI.MaximumSize;
            this.Height = Program.oMDI.ClientSize.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.SetDesktopBounds(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

            photoAlbum1.OListGlobalElementsValues = oGlobalElementValues;
            photoAlbum1.AñadirImagenes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(true);
        }

        private void imagenCambianteLabel2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}