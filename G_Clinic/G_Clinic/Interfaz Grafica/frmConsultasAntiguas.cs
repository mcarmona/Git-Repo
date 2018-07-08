using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Transitions;
using G_Clinic.Lógica_Negocios;
using System.IO;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmConsultasAntiguas : Form
    {
        CConsultasAntiguas oCConsultasAntiguas = new CConsultasAntiguas();

        int idPaciente = 0;
        public frmConsultasAntiguas(int pIDPaciente)
        {
            InitializeComponent();
            this.Region = Shape.RoundedRegion(this.Size, 8, Shape.Corner.None);
            idPaciente = pIDPaciente;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCConsultasAntiguas.Num_expediente = idPaciente;
            oCConsultasAntiguas.Fecha_consulta = dtFechaConsulta.Value;
            oCConsultasAntiguas.Detalle_adicional = txtDetallesAdicionales.Text.Trim();

            string path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");
            path += "\\TempFile_PDF.pdf";
            oCConsultasAntiguas.Detalle_consulta = File.ReadAllBytes(path);

            oCConsultasAntiguas.Insertar();

            if (Program.oPersistencia.IsError == false)
            {
                MessageBox.Show(this, "Consulta generada correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        /// <summary>
        /// 17, 54
        /// -511, 54
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirPDF_Click(object sender, EventArgs e)
        {
            softNet_IMGtoPDF1.btnConvertirPDF_Click(sender, e);

            if (softNet_IMGtoPDF1.listView1.Items.Count > 0)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
                t.add(panelOpciones, "Left", -511);
                t.run();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
            t.add(panelOpciones, "Left", 17);
            t.run();
        }

        private void imagenCambiantePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imagenCambianteLabel1_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
            t.add(panelOpciones, "Left", -511);
            t.run();
        }

        private void frmConsultasAntiguas_Load(object sender, EventArgs e)
        {
            lblNumExpediente.Text = idPaciente.ToString().Trim();
            
            CPacientes o = new CPacientes();
            lblNombre.Text = o.NombreDePaciente(idPaciente.ToString());

            o = null;
        }
    }
}
