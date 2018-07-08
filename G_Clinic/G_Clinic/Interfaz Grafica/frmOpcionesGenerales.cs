using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace G_Clinic
{
    public partial class frmOpcionesGenerales : Form
    {
        public frmOpcionesGenerales()
        {
            InitializeComponent();
        }

        string cubiculo = "";
        CCitas oCCitas = new CCitas();

        bool datosGuardados = false;
        bool salir = false;

        private void CargarDatos()
        {
            #region Carga datos previamente almacenados

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select * from Detalle_Clinica_Citas", "Detalle_Clinica_Citas");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dtInicio.Value = Convert.ToDateTime(dr[0]);
                        dtFinal.Value = Convert.ToDateTime(dr[1]);
                        cubiculo = dr[2].ToString();

                        if (dr[2].ToString().Trim() == "0")
                        {
                            rdUnico.Checked = true;
                            txtVarios.Text = "";
                        }
                        else if (dr[2].ToString().Trim() == "1")
                        {
                            rdUnoDoctor.Checked = true;
                            txtVarios.Text = "";
                        }
                        else if (dr[2].ToString().Trim() == "2")
                        {
                            rdVarios.Checked = true;
                            txtVarios.Text = dr[3].ToString().Trim();
                        }

                        if (dr[4] != DBNull.Value)
                            dtRecordatorioEmail.Value = Convert.ToDateTime(dr[4]);
                        else
                            dtRecordatorioEmail.Value = System.DateTime.Now;
                    }
                }
            }
            ds.Dispose();

            #endregion
        }

        private void frmOpcionesGenerales_Load(object sender, EventArgs e)
        {
            CargarDatos();

            if (oCCitas.DeterminaHorarioEstablecido() == true)
                datosGuardados = true;
            else
                datosGuardados = false;
        }

        private bool VerificaDatos()
        {
            bool Continuar = true;

            if (rdVarios.Checked == true && txtVarios.Text.Trim().Equals(""))
            {
                Continuar = false;
                MessageBox.Show(this, "Debe especificar la cantidad total de cubículos disponibles para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtVarios.Focus();
            }
            else if (rdUnico.Checked == false && rdUnoDoctor.Checked == false && rdVarios.Checked == false)
            {
                Continuar = false;
                MessageBox.Show(this, "Debe seleccionar una de las opciones que detalle el total de cubículos disponibles para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (dtFinal.Value.Hour <= dtInicio.Value.Hour)
            {
                if (dtFinal.Value.Minute == dtInicio.Value.Minute)
                {
                    Continuar = false;
                    MessageBox.Show(this, "La hora inicial no puede ser mayor o igual a la hora final de atención.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (dtRecordatorioEmail.Value.TimeOfDay < dtInicio.Value.TimeOfDay || dtRecordatorioEmail.Value.TimeOfDay > dtFinal.Value.TimeOfDay)
            {
                Continuar = false;
                MessageBox.Show(this, "La hora destinada para enviar recordatorios por correo debe de estar dentro del rango de horas especificado en el horario de la clínica, Verifique los valores para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return Continuar;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificaDatos() == true)
            {
                if (MessageBox.Show(this, "¿Está seguro(a) que los datos son correctos y desea continuar con la inserción de datos?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    #region Verifica datos incluídos previamente

                    if (datosGuardados == true)
                        Program.oComprobaciones.Borrar("Detalle_Clinica_Citas", "cubiculos = " + cubiculo);

                    #endregion

                    SqlCommand SqlCom = null;

                    string qry = "insert into Detalle_Clinica_Citas(hora_inicio, hora_final, cubiculos, total_cubiculos, hora_recordatorio_mail) " +
                    "values (@hora_inicio, @hora_final, @cubiculos, @total_cubiculos, @hora_recordatorio_mail)";

                    SqlCom = new SqlCommand(qry, Program.oPersistencia.conexion);

                    SqlCom.Parameters.Add(new SqlParameter("@hora_inicio", (object)dtInicio.Value));
                    SqlCom.Parameters.Add(new SqlParameter("@hora_final", (object)dtFinal.Value));
                    if (rdUnico.Checked == true)
                    {
                        SqlCom.Parameters.Add(new SqlParameter("@cubiculos", (object)0));
                        SqlCom.Parameters.Add(new SqlParameter("@total_cubiculos", (object)1));
                    }
                    else if (rdUnoDoctor.Checked == true)
                    {
                        SqlCom.Parameters.Add(new SqlParameter("@cubiculos", (object)1));
                        SqlCom.Parameters.Add(new SqlParameter("@total_cubiculos", (object)0));
                    }
                    else if (rdVarios.Checked == true)
                    {
                        SqlCom.Parameters.Add(new SqlParameter("@cubiculos", (object)2));
                        SqlCom.Parameters.Add(new SqlParameter("@total_cubiculos", (object)Convert.ToInt32(txtVarios.Text.Trim())));
                    }
                    SqlCom.Parameters.Add(new SqlParameter("@hora_recordatorio_mail", (object)dtRecordatorioEmail.Value));

                    SqlCom.ExecuteNonQuery();

                    // Verifico el Error
                    if (Program.oPersistencia.IsError == true)
                        MessageBox.Show(Program.oPersistencia.ErrorDescripcion, "Error de SQL");
                    else
                    {
                        datosGuardados = true;
                        this.Close();
                    }
                }
            }
        }

        private void rdVarios_CheckedChanged(object sender, EventArgs e)
        {
            if (rdVarios.Checked == true)
                txtVarios.Enabled = true;
            else
                txtVarios.Enabled = false;
        }

        private void frmOpcionesGenerales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datosGuardados == false)
            {
                if (salir == false)
                {
                    if (MessageBox.Show(this, "El módulo de Citas del sistema no podrá funcionar hasta establecer un horario y la cantidad de cubículos disponibles, ¿Desea salir sin establecer los datos (el módulo de citas se cerrará automáticamente)?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        salir = true;
                        this.Close();
                        Program.ofrmCalendario.Close();
                    }
                    else
                        e.Cancel = true;
                }
            }
        }
    }
}