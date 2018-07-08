using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Lógica_Negocios;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmCambioCitaPrioridad : Form
    {
        #region Variables

        bool cerrar = false;
        string idCita = "";
        DateTime fechaHora = new DateTime();
        DateTime fechaHoraRecordatorios = new DateTime();
        CPacientes oCPacientes = new CPacientes();
        TimeSpan oDuracion = new TimeSpan();
        string oIdEmp = "";

        #endregion

        public frmCambioCitaPrioridad(string pIdCita, DateTime pFechaHora, TimeSpan pDuracion, DateTime pFechaRecordatorio, string pIdEmp)
        {
            InitializeComponent();
            idCita = pIdCita;
            fechaHora = pFechaHora;
            oDuracion = pDuracion;
            fechaHoraRecordatorios = pFechaRecordatorio;
            oIdEmp = pIdEmp;

            this.Region = Shape.RoundedRegion(this.Size, 8, Shape.Corner.None);
        }

        private void DeterminaContactos(string pNumExpediente)
        {
            try
            {
                lstContactos.Items.Clear();
                lstContactos2.Items.Clear();

                if (pNumExpediente != "" && pNumExpediente != "0")
                {
                    int linea = 0;
                    string Consulta = "select a.descripcion, b.descripcion from Tipo_Contactos a, Contactos_Paciente b " +
                                      "where a.id_tipo_contacto = b.id_tipo_contacto and b.num_expediente = " + pNumExpediente.Trim();

                    DataSet ds = Program.oPersistencia.ejecutarSQLListas(Consulta.Trim(), "Tipo_Contactos a, Contactos_Paciente b");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstContactos.Items.Add(dr[0].ToString().Trim());
                        lstContactos.Items[linea].SubItems.Add(dr[1].ToString().Trim());
                        linea++;
                    }
                    ds.Dispose();

                    lstContactos.Visible = true;
                    lstContactos2.Visible = false;
                }
                else
                {
                    string Consulta = "Select contacto1, contacto2 from Citas where id_cita = " + idCita.Trim();

                    DataSet ds = Program.oPersistencia.ejecutarSQLListas(Consulta.Trim(), "Citas");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstContactos2.Items.Add(dr[0].ToString().Trim());
                        lstContactos2.Items.Add(dr[1].ToString().Trim());
                    }
                    ds.Dispose();

                    lstContactos.Visible = false;
                    lstContactos2.Visible = true;
                }
            }
            catch { }
        }

        private void DeterminarDatosCitaOriginal()
        {
            string sql = "Select * from Citas where id_cita = " + idCita.Trim();

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(sql, "Citas");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lblFechaHoraOriginal.Text = Convert.ToDateTime(dr[3]).ToLongDateString() + " a las " + Convert.ToDateTime(dr[3]).Hour.ToString() + ":" + Convert.ToDateTime(dr[3]).Minute.ToString();

                        TimeSpan oTime = new TimeSpan();
                        oTime = Convert.ToDateTime(dr[4]).Subtract(Convert.ToDateTime(dr[3]));

                        lblDuracionOriginal.Text = oTime.Hours.ToString() + " horas con " + oTime.Minutes.ToString() + " minutos.";
                        lblDetalleOriginal.Text = dr[5].ToString().Trim();

                        if (Convert.ToBoolean(dr[11]) == false)
                        {
                            lblNombrePaciente.Text = oCPacientes.NombreDePaciente(dr[1].ToString().Trim());
                            DeterminaContactos(dr[1].ToString().Trim());
                        }
                        else
                        {
                            lblNombrePaciente.Text = dr[12].ToString().Trim();
                            DeterminaContactos("0");
                        }
                    }
                }
                ds.Dispose();
            }
        }

        private void EstableceDatosCitaConCambios()
        {
            lblFechaHoraReemplezada.Text = fechaHora.ToLongDateString() + " a las " + fechaHora.TimeOfDay.ToString();
            lblDuracionReemplazada.Text = oDuracion.Hours.ToString() + " horas con " + oDuracion.Minutes.ToString() + " minutos.";
        }

        private void frmCambioCitaPrioridad_Load(object sender, EventArgs e)
        {
            DeterminarDatosCitaOriginal();
            EstableceDatosCitaConCambios();
        }

        private void btnCambiarCita_Click(object sender, EventArgs e)
        {
            DateTime oFecha = new DateTime();
            oFecha = fechaHora.Add(oDuracion);

            string Mensaje = Program.oCCitas.VerificaHorasDisponiblesDoctorPorDia(oIdEmp.Trim(), fechaHora, fechaHora, oFecha, idCita.Trim());

            if (Mensaje == "")
            {
                Program.oComprobaciones.Modificar("fecha = '" + Program.oComprobaciones.DevuelveFormatoFechaSql(fechaHora) + "', " +
                    "duracion = '" + Program.oComprobaciones.DevuelveFormatoFechaSql(oFecha) + "', " +
                    "fecha_inicial_record = '" + Program.oComprobaciones.DevuelveFormatoFechaSql(fechaHoraRecordatorios) + "', " +
                    "prioridad = 'False'", "Citas", "id_cita = " + idCita.Trim());

                if (Program.oPersistencia.IsError == false)
                {
                    Program.ofrmCalendario.ModoBloqueo();
                    MessageBox.Show(this, "La fecha ha sido cambiada a otro día satisfactoriamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    cerrar = true;
                    this.Close();
                }
                else
                    MessageBox.Show(this, "Se produjo un error y la fecha no ha sido cambiada a otro día", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show(this, Mensaje.Trim(), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Está completamente seguro(a) que no desea cambiar la cita de día?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                cerrar = true;
                this.Close();
            }
            else
                cerrar = false;
        }

        private void frmCambioCitaPrioridad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrar == false)
                e.Cancel = true;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}