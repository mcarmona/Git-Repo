using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
using G_Clinic.Miscelaneos_y_Recursos;
using System.Drawing.Printing;
using PdfSharp;
using PdfSharp.Forms;
using PdfSharp.Pdf.Printing;
using G_Clinic.Properties;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmFuentesDelSistema : Form
    {
        public frmFuentesDelSistema()
        {
            InitializeComponent();
            this.Region = Shape.RoundedRegion(this.Size, 8, Shape.Corner.None);

            openFileDialog1.InitialDirectory = Environment.SpecialFolder.ProgramFiles.ToString();
        }

        public void EstableceValoresFuentes()
        {
            txtMantenimientosGenerales.Text = Utilidades.FormatoLegibleDeFuente(Settings.Default.FuenteDeMantenimientos);
            txtDetallesConsultas.Text = Utilidades.FormatoLegibleDeFuente(Settings.Default.FuenteDeDetalleConsultas);
            txtExamenesYGabinete.Text = Utilidades.FormatoLegibleDeFuente(Settings.Default.FuenteDeResultadoExamenesYGabinete);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = Settings.Default.FuenteDeMantenimientos;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Settings.Default.FuenteDeMantenimientos = fontDialog1.Font;
                txtMantenimientosGenerales.Text = Utilidades.FormatoLegibleDeFuente(fontDialog1.Font);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = Settings.Default.FuenteDeDetalleConsultas;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Settings.Default.FuenteDeDetalleConsultas = fontDialog1.Font;
                txtDetallesConsultas.Text = Utilidades.FormatoLegibleDeFuente(fontDialog1.Font);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = Settings.Default.FuenteDeResultadoExamenesYGabinete;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Settings.Default.FuenteDeResultadoExamenesYGabinete = fontDialog1.Font;
                txtExamenesYGabinete.Text = Utilidades.FormatoLegibleDeFuente(fontDialog1.Font);
            }
        }

        public void frmPrescriptionPad_Load(object sender, EventArgs e)
        {
            EstableceValoresFuentes();
        }

        private void btnGuardarFormato_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            MessageBox.Show(this, "Los cambios se han guardado satisfactoriamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            //    txtAdobeExePath.Text = openFileDialog1.FileName.Trim();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void frmPrescriptionPad_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
                Program.oMDI.Activate();
        }
    }
}