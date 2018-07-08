using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Lógica_Negocios;
using G_Clinic.Interfaz_Grafica;
using System.IO;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class SoftNetListPDFViewer : UserControl
    {
        int numExpediente = 0;
        public int NumExpediente
        {
            get { return numExpediente; }
            set { numExpediente = value; }
        }

        CConsultasAntiguas oCConsultasAntiguas = new CConsultasAntiguas(); 

        public SoftNetListPDFViewer()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstConsultas.SelectedItems.Count > 0)
            {
                string path = Path.GetTempFileName();

                byte[] documento = null;
                string detalle_adicional = "";

                DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select detalle_adicional, detalle_consulta from Consultas_Antiguas_Paciente where id_consulta = " + lstConsultas.SelectedItems[0].Text, "Consultas_Antiguas_Paciente");

                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        detalle_adicional = dr[0].ToString().Trim();
                        documento = (byte[])dr[1];
                    }
                    ds.Dispose();
                }

                txtDetalleAdicional.Text = detalle_adicional;

                File.Move(path, System.IO.Path.ChangeExtension(path, ".pdf"));
                path = System.IO.Path.ChangeExtension(path, ".pdf");
                System.IO.File.WriteAllBytes(path, documento);
 
                softNet_AdobePDFViewer1.FileLocation = path;
                softNet_AdobePDFViewer1.OpenDocument();
            }
        }

        private void tobNuevo_Click(object sender, EventArgs e)
        {
            if (NumExpediente != 0)
            {
                frmConsultasAntiguas ofrmConsultasAntiguas = new frmConsultasAntiguas(NumExpediente);
                ofrmConsultasAntiguas.ShowDialog();
            }
        }

        private void tobModificar_Click(object sender, EventArgs e)
        {
            txtDetalleAdicional.ReadOnly = false;
        }

        private void tobGuardar_Click(object sender, EventArgs e)
        {
            if (lstConsultas.SelectedItems.Count > 0)
            {
                oCConsultasAntiguas.Detalle_adicional = txtDetalleAdicional.Text.Trim();
                oCConsultasAntiguas.Id_consulta = Convert.ToInt32(lstConsultas.SelectedItems[0].Text.Trim());
                oCConsultasAntiguas.Modificar();

                listView1_SelectedIndexChanged(sender, e);
            }            
        }

        private void tobCancelar_Click(object sender, EventArgs e)
        {
            txtDetalleAdicional.ReadOnly = true;

            LlenarLista();
        }

        private void tobEliminar_Click(object sender, EventArgs e)
        {
            if (lstConsultas.SelectedItems.Count > 0)
            {
                oCConsultasAntiguas.Id_consulta = Convert.ToInt32(lstConsultas.SelectedItems[0].Text.Trim());
                oCConsultasAntiguas.Eliminar();

                LlenarLista();
            }
        }

        public void LlenarLista()
        {
            lstConsultas.Items.Clear();
            oCConsultasAntiguas.Num_expediente = NumExpediente;
            DataSet ds = oCConsultasAntiguas.Seleccionar();

            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int cont = 0;

                    lstConsultas.Items.Add(dr[0].ToString());
                    lstConsultas.Items[cont].SubItems.Add(Convert.ToDateTime(dr[2]).ToLongDateString());

                    cont++;
                }

                ds.Dispose();
            }
        }

        private void SoftNetListPDFViewer_Load(object sender, EventArgs e)
        {
            
        }
    }
}
