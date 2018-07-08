using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Properties;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmServer : Form
    {
        public frmServer()
        {
            InitializeComponent();
        }

        public Point oLocation
        {
            set { this.Location = value; }
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            if (Settings.Default.Port != null && Settings.Default.Port != "")
            {
                txtPuerto.Text = Settings.Default.Port;

                if (txtPuerto.Text.Trim().Contains(","))
                    txtPuerto.Text = txtPuerto.Text.Replace(",", "");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtServer.Text.Trim() == String.Empty)
                Settings.Default.Server = "Localhost";
            else
                Settings.Default.Server = txtServer.Text.Trim();

            if (txtServer.Text.Trim().Contains(","))
            {
                int index = txtServer.Text.Trim().IndexOf(",");
                Settings.Default.Port = txtServer.Text.Trim().Substring(index, (txtServer.Text.Trim().Length - index));
            }
            else
                if (txtPuerto.Text != null && txtPuerto.Text.Trim() != "")
                {
                    if (txtPuerto.Text.Contains(","))
                        Settings.Default.Port = txtPuerto.Text.Trim();
                    else
                        Settings.Default.Port = "," + txtPuerto.Text.Trim();
                }

            Settings.Default.Save();

            this.Close();
        }

        private void imagenCambianteLabel1_Click(object sender, EventArgs e)
        {
            btnGuardar_Click(sender, e);
        }
    }
}