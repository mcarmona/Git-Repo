using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class AutoCompletePatientSearch : UserControl
    {
        public AutoCompletePatientSearch()
        {
            InitializeComponent();
        }

        private int ListHeight()
        {
            int lHeight = lHeight = txtNombre.Height;

            if (lstPacientesDisponibles.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lstPacientesDisponibles.Items)
                    lHeight += lstPacientesDisponibles.GetItemRect(oItem.Index).Height;

                lHeight += 2;
            }

            return lHeight;
        }

        private void CargaAutoComplete(string searchParam)
        {
            lstPacientesDisponibles.Items.Clear();

            SqlCommand oCommand = new SqlCommand();
            oCommand.CommandText = "sp_InfoPacientes";
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.Connection = Program.oPersistencia.conexion;
            oCommand.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "searchParam", Value = searchParam });

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(oCommand);

            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstPacientesDisponibles.Items.Add(dr["num_expediente"].ToString());
                lstPacientesDisponibles.Items[i].SubItems.Add(dr["Nombre"].ToString().Trim());
                lstPacientesDisponibles.Items[i].SubItems.Add(dr["cedula"].ToString().Trim());

                i++;
            }

            ds.Dispose();
            oCommand.Dispose();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNombre.Text.Trim()))
                CargaAutoComplete(txtNombre.Text.Trim());                

            this.Height = ListHeight();
        }

        private void txtNombre_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void lstPacientesDisponibles_DoubleClick(object sender, EventArgs e)
        {
            if (lstPacientesDisponibles.SelectedItems.Count > 0)
            {
                txtNombre.Text = lstPacientesDisponibles.SelectedItems[0].SubItems[1].Text.Trim();
            }
        }

        private void lstPacientesDisponibles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (lstPacientesDisponibles.SelectedItems.Count > 0)
                {
                    txtNombre.Text = lstPacientesDisponibles.SelectedItems[0].SubItems[1].Text.Trim();
                }
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
                lstPacientesDisponibles.Focus();
        }
    }
}