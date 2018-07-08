using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Drawing;
using G_Clinic.Lógica_Negocios;
using System.Windows.Forms;

namespace G_Clinic
{
    class MostrarRecordatorios
    {
        #region Variables

        public static ArrayList oIdCita = new ArrayList();//Arreglo que añade los id's de las citas correspondientes a mostrar en el día
        public static ArrayList oArregloHoras = new ArrayList();//Arreglo que añade las horas en que se deberán mostrar los recordatorios del día actual
        public static ArrayList oFechaCita = new ArrayList();//Arreglo que almacena las fechas de las citas a los cuales corresponden los recordatorios
        public static ArrayList oColores = new ArrayList();//Arreglo que añade los colores a mostrar correspondientes a la prioridad de las citas
        public static ArrayList oDoctores = new ArrayList();//Arreglo que añade los doctores correspondientes a las citas disponibles
        public static ArrayList oPaciente = new ArrayList();//Arreglo que añade los pacientes correspondientes a las citas disponibles
        public static ArrayList oIdPaciente = new ArrayList();//Arreglo que añade los id's de los pacientes correspondientes a las citas disponibles
        public static ArrayList oDetalle = new ArrayList();//Arreglo que añade el detalle o descripción de la citas disponibles
        public static ArrayList oPrioridad = new ArrayList();//Arreglo que añade la prioridad de las citas disponibles
        public static ArrayList oLapso = new ArrayList();//No se utiliza actualmente
        public static ArrayList oEstadoAuxTemporal = new ArrayList();//Arreglo que añade un estado temporal a los recordatorios mostrados para no mostrarlos más de una vez

        /// <summary>
        /// Variable que almacena el nombre del paciente
        /// </summary>
        string NombrePaciente = "";
        
        /// <summary>
        /// Variable que almacena el nombre del doctor
        /// </summary>
        string NombreDoctor = "";

        CEmail oCEmail = new CEmail();
        bool correosEnviados = false;

        /// <summary>
        /// Variable que determina si los correos electrónicos correspondientes fueron enviados correctamente o no
        /// </summary>
        public bool CorreosEnviados
        {
            get { return correosEnviados; }
            set { correosEnviados = value; }
        }

        #endregion

        public ArrayList DeterminarRecordatoriosDelDiaActual()
        {
            try
            {
                oIdCita.Clear();
                oArregloHoras.Clear();
                oFechaCita.Clear();
                oColores.Clear();
                oDoctores.Clear();
                oPaciente.Clear();
                oIdPaciente.Clear();
                oDetalle.Clear();
                oPrioridad.Clear();
                oLapso.Clear();
                oEstadoAuxTemporal.Clear();

                int Contador = 0;
                string Sentencia = "";
                Sentencia = "Select * from Citas where cast(convert(varchar, fecha_inicial_record ,112) as datetime) = '" + System.DateTime.Today.ToShortDateString() + "' and estado_recordatorio != 2";
                DataSet ds = Program.oPersistencia.ejecutarSQLListas(Sentencia, "Citas");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    oIdCita.Add(dr[0].ToString());

                    #region Selecciona el nombre del paciente

                    if (Convert.ToBoolean(dr[11]) == false)//Paciente Existente
                    {                        
                        DataSet ds2 = Program.oPersistencia.ejecutarSQLListas("Select num_expediente, nombre + ' ' + apellidos from Paciente where num_expediente = " + dr[1].ToString().Trim(), "Paciente");

                        if (ds2 != null)
                        {
                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                                {
                                    oIdPaciente.Add(dr2[0].ToString().Trim());
                                    NombrePaciente = dr2[1].ToString().Trim();
                                    break;
                                }
                            }
                        }
                        ds2.Dispose();
                    }
                    else
                    {
                        oIdPaciente.Add(0);
                        NombrePaciente = dr[12].ToString().Trim();
                    }

                        #endregion

                    #region Selecciona el nombre del doctor

                    DataSet ds3 = Program.oPersistencia.ejecutarSQLListas("Select nombre from Empleados where id_emp = " + dr[2].ToString().Trim(), "Empleados");

                    if (ds3 != null)
                    {
                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr3 in ds3.Tables[0].Rows)
                            {
                                NombreDoctor = dr3[0].ToString().Trim();
                                break;
                            }
                        }
                    }
                    ds3.Dispose();

                    #endregion

                    oArregloHoras.Add(Convert.ToDateTime(dr[7]).ToLongTimeString());

                    if (dr[9].ToString().Trim() == "Media")
                        oColores.Add(Color.Yellow);
                    else if (dr[9].ToString().Trim() == "Alta")
                        oColores.Add(Color.Red);
                    else if (dr[9].ToString().Trim() == "Normal")
                        oColores.Add(Color.LightSteelBlue);

                    oDoctores.Add(NombreDoctor);
                    oPaciente.Add(NombrePaciente);
                    oDetalle.Add(dr[5].ToString().Trim());
                    oPrioridad.Add(dr[9].ToString().Trim());
                    oFechaCita.Add(Convert.ToDateTime(dr[3]));
                    oLapso.Add(dr[8].ToString().Trim());
                    oEstadoAuxTemporal.Add("0");

                    Contador++;
                }
                ds.Dispose();

                return oArregloHoras;
            }
            catch { return null; }
        }

        //Autor: Gonzalo Rodríguez
        //Fecha: 08/03/10
        //Este procedimiento muestra los recordatorios del día actual almacenados en los arreglos iniciados en el procedimiento
        //"Determinar recordatorios del actual"
        public void MuestraRecordatoriosDiaActual()
        {
            //El timer hace tick cada segundo
            int contador = 0;

            //Buscamos la hora y minuto actuales dentro del arreglo de horas
            foreach (string oHora in oArregloHoras)
            {
                if (System.DateTime.Now.TimeOfDay.Hours == Convert.ToDateTime(oHora).TimeOfDay.Hours)
                {
                    if (System.DateTime.Now.TimeOfDay.Minutes == Convert.ToDateTime(oHora).TimeOfDay.Minutes)
                    {
                        //Si el estado del arreglo en la posic "contador" es igual a cero entonces se muestra el mensaje
                        if (oEstadoAuxTemporal[contador].ToString().Trim() == "0")
                        {
                            //asignamos un 1 en la posicion "contador" del arreglo para establecer que ya este mensaje fue mostrado
                            oEstadoAuxTemporal[contador] = "1";

                            //Llamamos a las notificaciones del sistema junto con sus parámetros respectivos en la posición "contador"
                            frmNotificaciones ofrmNotificaciones = new frmNotificaciones(oIdCita[contador].ToString().Trim(), oDetalle[contador].ToString().Trim(),
                                oIdPaciente[contador].ToString().Trim(), oPaciente[contador].ToString().Trim(),
                                Convert.ToDateTime(oFechaCita[contador]), oDoctores[contador].ToString().Trim(), oPrioridad[contador].ToString().Trim());
                            ofrmNotificaciones.Show();
                        }
                    }
                }
                contador++;
            }
        }

        public void ModificarEstadoRecordatorios(string Estado, string id_Cita)
        {
            //Estado 0 = Sin mostrar
            //Estado 1 = Mostrado con posibilidades de volver a mostrar
            //Estado 2 = Finalizado
            Program.oComprobaciones.Modificar("estado_recordatorio = " + Estado.Trim(), "Citas", "id_cita = " + id_Cita);
        }

        public void ModificarEstadoCita(string Estado, string id_Cita)
        {
            //Estado 0 = Pendiente
            //Estado 1 = Finalizada
            Program.oComprobaciones.Modificar("estado_cita = " + Estado.Trim(), "Citas", "id_cita = " + id_Cita);
        }

        public bool ModificarHoraRecordatorios(string Minutos, string id_Cita)
        {
            try
            {
                bool guardadoCorrectamente = false;
                DateTime oHora = new DateTime();
                DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select fecha_inicial_record from Citas where id_cita = " + id_Cita.Trim(), "Citas");

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                            oHora = Convert.ToDateTime(dr[0]);

                        oHora = oHora.AddMinutes(Convert.ToDouble(Minutos));

                        SqlCommand SqlCom = null;

                        string qry = "Update Citas set fecha_inicial_record = @fecha_inicial_record where id_cita = @id_cita";

                        SqlCom = new SqlCommand(qry, Program.oPersistencia.conexion);

                        SqlCom.Parameters.Add(new SqlParameter("@fecha_inicial_record", (object)oHora));
                        SqlCom.Parameters.Add(new SqlParameter("@id_cita", (object)id_Cita.Trim()));

                        SqlCom.ExecuteNonQuery();

                        if (Program.oPersistencia.IsError == false)
                        {
                            guardadoCorrectamente = true;
                            DeterminarRecordatoriosDelDiaActual();
                        }
                    }
                }

                return guardadoCorrectamente;
            }
            catch { return false; }
        }

        public void MuestraRecordatoriosAltaPrioridad()
        {
            try
            {
                string Sentencia = "";
                Sentencia = "Select * from Citas where cast(convert(varchar, fecha_inicial_record ,112) as datetime) <= '" + System.DateTime.Today.ToShortDateString() + "' and estado_recordatorio != 2 and prioridad_recordatorio = 'Alta'";

                DataSet ds = Program.oPersistencia.ejecutarSQLListas(Sentencia, "Citas");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //Verificamos que la fecha de la cita todavía no haya transcurrido, de lo contrario modificamos el estado de la cita
                    //para señarlarla como finalizada
                    if (Convert.ToDateTime(dr[3]) >= DateTime.Today)
                    {
                        //Verificamos que el día del recordatorio sea igual al día actual 
                        if (Convert.ToDateTime(dr[7]).ToShortDateString() == DateTime.Today.ToShortDateString())
                        {
                            //Verificamos si la hora y minuto del recordatorio son menores a la hora actual del sistema
                            //así de esta forma si habíamos cerrado la aplicación durante el transcurso de un recordatorio pendiente
                            //este se muestre de igual forma para notificar el recordatorio
                            if (Convert.ToDateTime(dr[7]).Hour <= DateTime.Now.Hour)
                            {
                                //if (Convert.ToDateTime(dr[7]).Minute <= DateTime.Now.Minute)
                                //{
                                if (Convert.ToBoolean(dr[11]) == false)//Paciente Existente
                                {
                                    #region Selecciona el nombre del paciente

                                    DataSet ds2 = Program.oPersistencia.ejecutarSQLListas("Select num_expediente, nombre + ' ' + apellidos from Paciente where num_expediente = " + dr[1].ToString().Trim(), "Paciente");

                                    if (ds2 != null)
                                    {
                                        if (ds2.Tables[0].Rows.Count > 0)
                                        {
                                            foreach (DataRow dr2 in ds2.Tables[0].Rows)
                                            {
                                                oIdPaciente.Add(dr2[0].ToString().Trim());
                                                NombrePaciente = dr2[1].ToString().Trim();
                                                break;
                                            }
                                        }
                                    }
                                    ds2.Dispose();

                                    #endregion
                                }
                                else
                                {
                                    oIdPaciente.Add(0);
                                    NombrePaciente = dr[12].ToString().Trim();
                                }

                                #region Selecciona el nombre del doctor

                                DataSet ds3 = Program.oPersistencia.ejecutarSQLListas("Select nombre from Empleados where id_emp = " + dr[2].ToString().Trim(), "Empleados");

                                if (ds3 != null)
                                {
                                    if (ds3.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                                        {
                                            NombreDoctor = dr3[0].ToString().Trim();
                                            break;
                                        }
                                    }
                                }
                                ds3.Dispose();

                                #endregion

                                DateTime Fecha = new DateTime();
                                Fecha = Convert.ToDateTime(dr[3]);

                                string Mensaje = "El paciente: " + NombrePaciente + " posee una cita el día " + Fecha.ToLongDateString() + " a las " + Fecha.ToLongTimeString() + " con el doctor " + NombreDoctor + " por motivo de " + dr[5].ToString().Trim();
                                frmRecordatorios ofrmRecordatorios = new frmRecordatorios(Mensaje, dr[0].ToString(), Color.Red, dr[1].ToString().Trim(), true);
                                ofrmRecordatorios.Show();
                                Program.contRecordatorios++;
                                //}
                            }
                        }
                        else
                        {
                            //Si el día del recordatorio ya transcurrió y el recordatorio no ha sido finalizado se vuelve a mostrar, ya que se supone
                            //que cuando el sistema muestre los recordatorios el usuario debería de tomar las acciones necesarias y eliminar el recordatorio
                            #region Selecciona el nombre del paciente

                            DataSet ds2 = Program.oPersistencia.ejecutarSQLListas("Select num_expediente, nombre + ' ' + apellidos from Paciente where num_expediente = " + dr[1].ToString().Trim(), "Paciente");

                            if (ds2 != null)
                            {
                                if (ds2.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                                    {
                                        oIdPaciente.Add(dr2[0].ToString().Trim());
                                        NombrePaciente = dr2[1].ToString().Trim();
                                        break;
                                    }
                                }
                            }
                            ds2.Dispose();

                            #endregion

                            #region Selecciona el nombre del doctor

                            DataSet ds3 = Program.oPersistencia.ejecutarSQLListas("Select nombre from Empleados where id_emp = " + dr[2].ToString().Trim(), "Empleados");

                            if (ds3 != null)
                            {
                                if (ds3.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                                    {
                                        NombreDoctor = dr3[0].ToString().Trim();
                                        break;
                                    }
                                }
                            }
                            ds3.Dispose();

                            #endregion

                            DateTime Fecha = new DateTime();
                            Fecha = Convert.ToDateTime(dr[3]);

                            string Mensaje = "El paciente: " + NombrePaciente + " posee una cita el día " + Fecha.ToLongDateString() + " a las " + Fecha.ToLongTimeString() + " con el doctor " + NombreDoctor + " por motivo de " + dr[5].ToString().Trim();
                            frmRecordatorios ofrmRecordatorios = new frmRecordatorios(Mensaje, dr[0].ToString(), Color.Red, dr[1].ToString().Trim(), true);
                            ofrmRecordatorios.Show();
                            Program.contRecordatorios++;
                        }
                    }
                    else
                    {
                        //Finaliza la cita ya que la fecha establecida para la misma ya caducó.
                        ModificarEstadoCita("1", dr[0].ToString().Trim());

                        //Finaliza el recordatorio con la cita ya que la fecha de la cita ya caducó.
                        ModificarEstadoRecordatorios("2", dr[0].ToString().Trim());
                    }
                }
                ds.Dispose();
            }
            catch { }
        }

        public void CitaFinalizada()
        {
            string consulta = "Select id_cita from Citas where cast(convert(varchar, fecha, 112) as datetime) < '" + DateTime.Today.ToShortDateString() + "'";
            DataSet ds = Program.oPersistencia.ejecutarSQLListas(consulta.Trim(), "Citas");

            foreach (DataRow dr in ds.Tables[0].Rows)
                Program.oMostrarRecordatorios.ModificarEstadoCita("1", dr[0].ToString().Trim());

            ds.Dispose();
        }

        public void EnviarNotificacionesCorreo(string pPassword)
        {
            try
            {
                int cont = 0;
                string para = "";
                string asunto = "";
                string detalle = "";

                foreach (string idCita in oIdCita)
                {
                    para = "";
                    asunto = "";
                    detalle = "";

                    para = oCEmail.CorreosPaciente(oIdPaciente[cont].ToString().Trim());

                    if (para != "")
                    {
                        asunto = "Recordatorio de cita médica con el doctor: " + oDoctores[cont].ToString().Trim();
                        detalle = "Por este medio se le recuerda que tiene una cita pendiente con el Doctor: " + oDoctores[cont].ToString().Trim() +
                                  " para el día " + Convert.ToDateTime(oFechaCita[cont]).ToLongDateString()
                                  + " a las " + Convert.ToDateTime(oFechaCita[cont]).ToShortTimeString()
                                  + ", por motivo de: " + oDetalle[cont].ToString().Trim() + ". Se le solicita por favor confirmar por este medio " +
                                  "a la misma dirección de la cual se envió este correo o llamar a los teléfonos: " + Program.oCEmpresa.Telefono +
                                  Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine
                                  + "Pd. Este correo fue generado automáticamente por el sistema utilizado en la clínica: " + Program.oCEmpresa.NombreEmpresa
                                  + ", cualquier duda o consulta con respecto a la cita favor llamar o responder este correo.";

                        oCEmail.GeneraMailNotificacion(Program.oCEmpresa.Email,  pPassword, para, asunto, detalle);
                    }

                    cont++;
                }

                correosEnviados = true;
            }
            catch 
            {
                correosEnviados = false;
                MessageBox.Show(Program.oMDI, "Se produjo un error al enviar los correos electrónicos, por favor verifique los datos de la cuenta de GMAIL en los \"Datos de la empresa\" y proceda a intentar de nuevo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}