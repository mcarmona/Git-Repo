using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmConsultasHistorialConsultas : Form
    {
        string sqlSentence = "";
        public string SqlSentence
        {
            get { return sqlSentence; }
            set { sqlSentence = value; }
        }

        public frmConsultasHistorialConsultas()
        {
            InitializeComponent();
        }

        private void frmConsultasHistorialConsultas_Load(object sender, EventArgs e)
        {
            this.Region = Shape.RoundedRegion(this.Size, 10, Shape.Corner.None);
            
            LlenaComboMetodosAnticonceptivos();

            this.Left = ((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2);
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height - Program.oMDI.statusStrip1.Height - Program.oFrmDock.Height + 22;

            cmbMetodoAnticonceptivo.SelectedIndex = -1;
        }

        private void LlenaComboMetodosAnticonceptivos()
        {
            cmbMetodoAnticonceptivo.DataSource = null;
            Metodos_Globales.LlenarCombo(cmbMetodoAnticonceptivo, "Sp_S_Metodos_Anticonceptivos", "Metodos_Anticonceptivos", "id_metodo", "descripcion");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEjecutarBusqueda_Click(object sender, EventArgs e)
        {
            sqlSentence = "";

            if (rdFechaExacta.Checked == true)
                sqlSentence += " and cast(convert(varchar, fecha_consulta, 112) as datetime) = '" + dtFechaCosnulta.Value.ToShortDateString() + "'" +
                    " or cast(convert(varchar, fecha_consulta2, 112) as datetime) = '" + dtFechaCosnulta.Value.ToShortDateString() + "'";
            else if (rdIndicesFechas.Checked == true)
                sqlSentence += " and cast(convert(varchar, fecha_consulta ,112) as datetime) >= '" + dtFechaInicial.Value.ToShortDateString() + "' and cast(convert(varchar, fecha_consulta ,112) as datetime) <= '" + dtFechaFinal.Value.ToShortDateString() + "'" +
                    " or (cast(convert(varchar, fecha_consulta2 ,112) as datetime) >= '" + dtFechaInicial.Value.ToShortDateString() + "' and cast(convert(varchar, fecha_consulta2, 112) as datetime) <= '" + dtFechaFinal.Value.ToShortDateString() + "')";

            if (cmbMetodoAnticonceptivo.SelectedIndex != -1)
                sqlSentence += " and id_metodo = " + cmbMetodoAnticonceptivo.SelectedValue.ToString().Trim();

            if (rdValorExacto.Checked == true)
            {
                if (txtPesoHabitual.Text.Trim() != "0" && txtPesoHabitual.Text.Trim() != "")
                    sqlSentence += " and peso = " + txtPesoHabitual.Text.Trim();

                if (txtTalla.Text.Trim() != "0" && txtTalla.Text.Trim() != "")
                    sqlSentence += " and talla = " + txtTalla.Text.Trim();

                if (txtIMC.Text.Trim() != "0" && txtIMC.Text.Trim() != "")
                    sqlSentence += " and imc = " + txtIMC.Text.Trim();
            }
            else if (rdRangos.Checked == true)
            {
                if (txtPeso1.Text.Trim() != "0" && txtPeso1.Text.Trim() != "" && txtPeso2.Text.Trim() != "0" && txtPeso2.Text.Trim() != "")
                    sqlSentence += " and peso >= " + txtPeso1.Text.Trim() + " and peso <= " + txtPeso2.Text.Trim();

                if (txtTalla1.Text.Trim() != "0" && txtTalla1.Text.Trim() != "" && txtTalla2.Text.Trim() != "0" && txtTalla2.Text.Trim() != "")
                    sqlSentence += " and talla >= " + txtTalla1.Text.Trim() + " and talla <= " + txtTalla2.Text.Trim();

                if (txtIMC1.Text.Trim() != "0" && txtIMC1.Text.Trim() != "" && txtIMC2.Text.Trim() != "0" && txtIMC2.Text.Trim() != "")
                    sqlSentence += " and imc >= " + txtIMC1.Text.Trim() + " and imc <= " + txtIMC2.Text.Trim();
            }

            if (txtPresionArterial.Text.Trim() != "")
                sqlSentence += " and presion_arterial = '" + txtPresionArterial.Text.Trim() + "'";

            Program.oFrmHistorialConsultas.SqlWhere = sqlSentence;

            this.Close();
        }

        private void tobLimpiar_Click(object sender, EventArgs e)
        {
            dtFechaCosnulta.Value = DateTime.Now;
            dtFechaFinal.Value = DateTime.Now;
            dtFechaInicial.Value = DateTime.Now;

            rdFechaExacta.Checked = false;
            rdIndicesFechas.Checked = false;
            rdRangos.Checked = false;
            rdValorExacto.Checked = false;

            cmbMetodoAnticonceptivo.SelectedIndex = -1;

            txtIMC.Text = "0";
            txtIMC1.Text = "0";
            txtIMC2.Text = "0";
            txtPeso1.Text = "0";
            txtPeso2.Text = "0";
            txtPesoHabitual.Text = "0";
            txtPresionArterial.Text = "0";
            txtTalla.Text = "0";
            txtTalla1.Text = "0";
            txtTalla2.Text = "0";
        }
    }
}