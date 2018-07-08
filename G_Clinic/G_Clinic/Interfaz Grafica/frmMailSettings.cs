using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmMailSettings : Form
    {
        public bool Abierto = false;
        public bool overwriteLocation = true;

        public frmMailSettings()
        {
            InitializeComponent();

            this.Region = Shape.RoundedRegion(this.Size, 6, Shape.Corner.None);
        }

        private void frmMailSettings_Load(object sender, EventArgs e)
        {
            Abierto = true;

            if (overwriteLocation == true)
            {
                this.StartPosition = FormStartPosition.Manual;

                this.Location = new Point(this.Owner.Left + (this.Owner.Width - this.Width) / 2,
                    (this.Owner.Top + ((FrmMiEmpresa)(this.Owner)).TxtPagWeb.Top + 5) - this.Height);
            }
            else
                this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void imagenCambiantePictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}