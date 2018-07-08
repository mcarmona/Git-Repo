using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using G_Clinic.Interfaz_Grafica;
using System.Windows.Forms;

namespace G_Clinic
{
    class CCitas
    {
        #region Variables

        long id_cita = 0;
        string num_expediente = "";
        int id_emp = 0;
        DateTime fecha;
        DateTime duracion;
        string detalle = "";
        string estado_cita = "";
        DateTime fecha_inicial_record;
        DateTime hora_inicial_record;
        int lapso_recordatorio = 0;
        string prioridad_recordatorio = "";
        int estado_recordatorio = 0;
        bool tipo_paciente = false;
        string nombre_paciente = "";
        string contacto1 = "";
        string contacto2 = "";
        bool prioridad = false;

        #endregion

        #region Encapsulaciones

        public long Id_cita
        {
            get { return id_cita; }
            set { id_cita = value; }
        }

        public string Num_expediente
        {
            get { return num_expediente; }
            set { num_expediente = value; }
        }

        public int Id_emp
        {
            get { return id_emp; }
            set { id_emp = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public DateTime Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }

        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        public string Estado_cita
        {
            get { return estado_cita; }
            set { estado_cita = value; }
        }

        public DateTime Fecha_inicial_record
        {
            get { return fecha_inicial_record; }
            set { fecha_inicial_record = value; }
        }

        public DateTime Hora_inicial_record
        {
            get { return hora_inicial_record; }
            set { hora_inicial_record = value; }
        }

        public int Lapso_recordatorio
        {
            get { return lapso_recordatorio; }
            set { lapso_recordatorio = value; }
        }

        public string Prioridad_recordatorio
        {
            get { return prioridad_recordatorio; }
            set { prioridad_recordatorio = value; }
        }

        public int Estado_recordatorio
        {
            get { return estado_recordatorio; }
            set { estado_recordatorio = value; }
        }

        public bool Tipo_paciente
        {
            get { return tipo_paciente; }
            set { tipo_paciente = value; }
        }

        public string Nombre_Paciente
        {
            get { return nombre_paciente; }
            set { nombre_paciente = value; }
        }

        public string Contacto1
        {
            get { return contacto1; }
            set { contacto1 = value; }
        }

        public string Contacto2
        {
            get { return contacto2; }
            set { contacto2 = value; }
        }

        public bool Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        #endregion

        #region Variables Lógica

        ArrayList oArregloHoras = new ArrayList();
        StringBuilder oSql;

        DateTime horaInicial = new DateTime();
        DateTime horaFinal = new DateTime();

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@num_expediente");
            oArreglo.Add("@id_emp");
            oArreglo.Add("@fecha");
            oArreglo.Add("@duracion");
            oArreglo.Add("@detalle");
            oArreglo.Add("@estado_cita");
            oArreglo.Add("@fecha_inicial_record");
            //oArreglo.Add("@hora_inicial_record");
            oArreglo.Add("@lapso_recordatorio");
            oArreglo.Add("@prioridad_recordatorio");
            oArreglo.Add("@estado_recordatorio");
            oArreglo.Add("@tipo_paciente");
            oArreglo.Add("@nombre_paciente");
            oArreglo.Add("@contacto1");
            oArreglo.Add("@contacto2");
            oArreglo.Add("@prioridad");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@num_expediente");
            oArreglo.Add("@id_emp");
            oArreglo.Add("@fecha");
            oArreglo.Add("@duracion");
            oArreglo.Add("@detalle");
            oArreglo.Add("@estado_cita");
            oArreglo.Add("@fecha_inicial_record");
            //oArreglo.Add("@hora_inicial_record");
            oArreglo.Add("@lapso_recordatorio");
            oArreglo.Add("@prioridad_recordatorio");
            oArreglo.Add("@estado_recordatorio");
            oArreglo.Add("@tipo_paciente");
            oArreglo.Add("@nombre_paciente");
            oArreglo.Add("@contacto1");
            oArreglo.Add("@contacto2");
            oArreglo.Add("@prioridad");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_cita");

            return oArreglo;
        }

        private ArrayList oArregloConsulta()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(num_expediente);
            oArreglo.Add(id_emp);
            oArreglo.Add(fecha);
            oArreglo.Add(duracion);
            oArreglo.Add(detalle);
            oArreglo.Add(estado_cita);
            oArreglo.Add(fecha_inicial_record);
            //oArreglo.Add(hora_inicial_record);
            oArreglo.Add(lapso_recordatorio);
            oArreglo.Add(prioridad_recordatorio);
            oArreglo.Add(estado_recordatorio);
            oArreglo.Add(tipo_paciente);
            oArreglo.Add(nombre_paciente);
            oArreglo.Add(contacto1);
            oArreglo.Add(contacto2);
            oArreglo.Add(prioridad);

            return oArreglo;
        }

        private ArrayList oArregloCondicion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(id_cita);

            return oArreglo;
        }

        private ArrayList oArregloCondicionConsulta()
        {
            ArrayList oArreglo = new ArrayList();

            //if (idConsulta != 0)
            //    oArreglo.Add(idConsulta);

            //if (numExpediente != 0)
            //    oArreglo.Add(numExpediente);

            //if (tipo_ced != null)
            //    oArreglo.Add(tipo_ced);

            //if (cedula != null)
            //    oArreglo.Add(cedula);

            //if (nombre != null)
            //    oArreglo.Add(nombre);

            //if (apellidos != null)
            //    oArreglo.Add(apellidos);

            ////if (tipoConsulta != null)
            ////    oArreglo.Add(tipoConsulta);

            //if (fechaConsulta != System.DateTime.MinValue)
            //    oArreglo.Add(fechaConsulta);

            //if (fechaInicial != System.DateTime.MinValue && fechaFinal != DateTime.MinValue)
            //{
            //    oArreglo.Add(fechaInicial);
            //    oArreglo.Add(fechaFinal);
            //}

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Citas", oArregloParametrosInsertar(), oArregloConsulta());
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Citas", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloConsulta(), oArregloCondicion());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Citas", "id_cita", oArregloCondicion());
        }

        #endregion

        #region Lógica

        public bool DeterminaHorarioEstablecido()
        {
            string sqlConsulta = "Select * from Detalle_Clinica_Citas";

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(sqlConsulta, "Detalle_Clinica_Citas");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
                ds.Dispose();
            }
            else
                return false;
        }

        public DateTime HoraInicial
        {
            set { horaInicial = value; }
            get { return horaInicial; }
        }

        public DateTime HoraFinal
        {
            set { horaFinal = value; }
            get { return horaFinal; }
        }

        /// <summary>
        /// Determina el total de horas de la jornada laboral
        /// </summary>
        public void DeterminaHorasPorDia()
        {
            try
            {
                DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select * from Detalle_Clinica_Citas", "Detalle_Clinica_Citas");

                double oTotal = 0;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    horaInicial = Convert.ToDateTime(dr[0]);
                    horaFinal = Convert.ToDateTime(dr[1]);

                    oTotal = ((TimeSpan)(horaFinal - horaInicial)).TotalHours;
                }
                ds.Dispose();
            }
            catch { }
        }

        public string VerificaHorasDisponiblesDoctorPorDia(string pIdDoctor, DateTime pFecha, DateTime pHoraInicio, DateTime pHoraFinal, string pIdCita)
        {
            try
            {
                string Mensaje = "";
                oSql = new StringBuilder("");
                string Cubiculos = "";

                #region Selecciona la opción que indica la cantidad de cubículos disponibles

                DataSet datasetCubic = Program.oPersistencia.ejecutarSQLListas("Select cubiculos from Detalle_Clinica_Citas", "Detalle_Clinica_Citas");

                foreach (DataRow dr in datasetCubic.Tables[0].Rows)
                    Cubiculos = dr[0].ToString().Trim();

                datasetCubic.Dispose();

                #endregion

                //Establece que sólamente hay un cubículo en toda la clínica donde se atenderán los pacientes
                if (Cubiculos == "0")
                {
                    #region Selección de Citas por Doctor, Fecha y Hora Inicial y Final de la cita

                    oSql.Append("Select * from Citas where cast(convert(varchar, fecha, 112) as datetime) = '" + pFecha.ToShortDateString() + "'");

                    //Este valor se recibe a la hora de guardar en las citas si se está modificando para no buscar en los rangos de fecha de la cita actual
                    if (pIdCita.Trim() != "")
                        oSql.Append(" and id_cita != " + pIdCita.Trim());

                    DataSet ds = Program.oPersistencia.ejecutarSQLListas(oSql.ToString(), "Citas");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        //Verificamos que los rangos de la hora inicial de la cita recibidos no estén dentro de los rangos de una cita existente
                        //if (pHoraInicio.TimeOfDay >= Convert.ToDateTime(dr[3]).TimeOfDay && pHoraInicio.TimeOfDay <= Convert.ToDateTime(dr[4]).TimeOfDay)
                        if (pHoraInicio.TimeOfDay > Convert.ToDateTime(dr[3]).TimeOfDay && pHoraInicio.TimeOfDay < Convert.ToDateTime(dr[4]).TimeOfDay)
                        {
                            Mensaje = "La hora inicial de la cita no se encuentra disponible ya que ya existe una cita programada entre el rango de horas de horas establecido.";
                            break;
                        }
                        //Verificamos que los rangos de la hora final de la cita recibidos no estén dentro de los rangos de una cita existente
                        //else if (pHoraFinal.TimeOfDay >= Convert.ToDateTime(dr[3]).TimeOfDay && pHoraFinal.TimeOfDay <= Convert.ToDateTime(dr[4]).TimeOfDay)
                        else if (pHoraFinal.TimeOfDay > Convert.ToDateTime(dr[3]).TimeOfDay && pHoraFinal.TimeOfDay < Convert.ToDateTime(dr[4]).TimeOfDay)
                        {
                            Mensaje = "La hora final de la cita no se encuentra disponible ya que ya existe una cita programada entre el rango de horas establecido.";
                            break;
                        }
                    }
                    ds.Dispose();

                    #endregion
                }
                //Establece que hay un cubículo por doctor la clínica donde se atenderán los pacientes
                else if (Cubiculos == "1")
                {
                    #region Selección de Citas por Doctor, Fecha y Hora Inicial y Final de la cita

                    oSql.Append("Select * from Citas where id_emp = " + pIdDoctor.Trim());
                    oSql.Append(" and cast(convert(varchar, fecha, 112) as datetime) = '" + pFecha.ToShortDateString() + "'");
                    //Este valor se recibe a la hora de guardar en las citas si se está modificando para no buscar en los rangos de fecha de la cita actual
                    if (pIdCita.Trim() != "")
                        oSql.Append(" and id_cita != " + pIdCita.Trim());

                    DataSet ds = Program.oPersistencia.ejecutarSQLListas(oSql.ToString(), "Citas");

                    TimeSpan horaInicioBD = new TimeSpan();
                    TimeSpan horaFinalBD = new TimeSpan();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        //Verificamos que los rangos de la hora inicial de la cita recibidos no estén dentro de los rangos de una cita existente
                        //if (pHoraInicio.TimeOfDay >= Convert.ToDateTime(dr[3]).TimeOfDay && pHoraInicio.TimeOfDay <= Convert.ToDateTime(dr[4]).TimeOfDay)
                        horaInicioBD = Convert.ToDateTime(dr[3]).TimeOfDay;
                        horaFinalBD = Convert.ToDateTime(dr[4]).TimeOfDay;

                        if (pHoraInicio.TimeOfDay >= horaInicioBD && pHoraInicio.TimeOfDay < horaFinalBD)
                        {
                            Mensaje = "La hora inicial de la cita no se encuentra disponible ya que ya existe una cita programada entre el rango de horas de horas establecido.";
                            break;
                        }
                        //Verificamos que los rangos de la hora final de la cita recibidos no estén dentro de los rangos de una cita existente
                        //else if (pHoraFinal.TimeOfDay >= Convert.ToDateTime(dr[3]).TimeOfDay && pHoraFinal.TimeOfDay <= Convert.ToDateTime(dr[4]).TimeOfDay)
                        else if (pHoraFinal.TimeOfDay > horaInicioBD && pHoraFinal.TimeOfDay <= horaFinalBD)
                        {
                            Mensaje = "La hora final de la cita no se encuentra disponible ya que ya existe una cita programada entre el rango de horas establecido.";
                            break;
                        }
                    }
                    ds.Dispose();

                    #endregion
                }
                return Mensaje;

            }
            catch { return "Error"; }
        }

        public void VerificaCitasConPrioridad(DateTime pFechaCita, TimeSpan pDuracion, string pDoctor)
        {
            string consulta = "Select * from Citas where estado_cita = 0 and prioridad = 'true' and fecha > '" + Program.oComprobaciones.DevuelveFormatoFechaSql(pFechaCita) + "' and id_emp = " + pDoctor.Trim();
            //"and cast(convert(varchar, fecha ,112) as datetime) < '" pFechaCita.dat;                              

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(consulta, "Citas");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (MessageBox.Show("Actualmente existe un paciente para el cual se estableció prioridad en la cita, dado que se acaba de eliminar una cita dicho paciente con prioridad obtiene el lugar de la cita recién eliminada. Verifique los valores de la cita para reacomodar la misma en el nuevo espacio disponible... ¿Desea realizar estas acciones?.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            frmCambioCitaPrioridad ofrmCambioCitaPrioridad = new frmCambioCitaPrioridad(dr[0].ToString().Trim(),
                                                                                                        pFechaCita,
                                                                                                        pDuracion,
                                                                                                        Convert.ToDateTime(dr[7]),
                                                                                                        pDoctor.Trim());
                            ofrmCambioCitaPrioridad.Show(Program.ofrmCalendario);
                            break;
                        }
                    }
                }
                ds.Dispose();
            }
        }

        public TimeSpan DeterminaHoraEnviarCorreos()
        {
            TimeSpan oTimeSpan = new TimeSpan();
            try
            {
                DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select hora_recordatorio_mail from Detalle_Clinica_Citas", "Detalle_Clinica_Citas");
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                            oTimeSpan = Convert.ToDateTime(dr[0]).TimeOfDay;
                    }
                    ds.Dispose();
                }
            }
            catch
            {
                oTimeSpan = DateTime.Today.TimeOfDay;
            }

            return oTimeSpan;
        }

        #endregion
    }
}