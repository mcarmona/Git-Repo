using System;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CPacientes
    {
        #region Variables

        int numExpediente = 0;
        string tipoCedula = "";
        string cedula = "";
        string nombre = "";
        string apellidos = "";
        string sexo = "";
        DateTime fechaNacimiento;
        string estadoCivil = "";
        string ocupacion = "";
        string domicilio = "";
        byte[] bFoto;
        byte[] infoImagen;//Variable opcional para no tener que leer la imagen desde el disco duro, sino desde la Bd en caso de que no se modifique o elimine la imagen
        string observaciones = "";
        string peso = "";
        string talla = "";
        string imc = "";
        string tipo_sangre = "";
        string factor_rh = "";
        string detallesAdicExamenes = "";

        #endregion

        #region Encapsulaciones de Campos

        public int NumExpediente
        {
            get { return numExpediente; }
            set { numExpediente = value; }
        }

        public string TipoCedula
        {
            get { return tipoCedula; }
            set { tipoCedula = value; }
        }

        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public string EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }

        public string Ocupacion
        {
            get { return ocupacion; }
            set { ocupacion = value; }
        }

        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }

        public byte[] BFoto
        {
            get { return bFoto; }
            set { bFoto = value; }
        }

        public byte[] InfoImagen
        {
            get { return infoImagen; }
            set { infoImagen = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public string Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public string Talla
        {
            get { return talla; }
            set { talla = value; }
        }

        public string IMC
        {
            get { return imc; }
            set { imc = value; }
        }

        public string Tipo_sangre
        {
            get { return tipo_sangre; }
            set { tipo_sangre = value; }
        }

        public string Factor_rh
        {
            get { return factor_rh; }
            set { factor_rh = value; }
        }

        public string DetallesAdicExamenes
        {
            get { return detallesAdicExamenes; }
            set { detallesAdicExamenes = value; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@tipo_ced");
            oArreglo.Add("@cedula");
            oArreglo.Add("@nombre");
            oArreglo.Add("@apellidos");
            oArreglo.Add("@sexo");
            oArreglo.Add("@fecha_nacimiento");
            oArreglo.Add("@estado_civil");
            oArreglo.Add("@ocupacion");
            oArreglo.Add("@domicilio");
            oArreglo.Add("@foto");
            oArreglo.Add("@observaciones");
            oArreglo.Add("@peso");
            oArreglo.Add("@talla");
            oArreglo.Add("@imc");
            oArreglo.Add("@tipo_sangre");
            oArreglo.Add("@factor_rh");

            return oArreglo;
        }

        private ArrayList oArregloParametrosInsertarNoIMage()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@tipo_ced");
            oArreglo.Add("@cedula");
            oArreglo.Add("@nombre");
            oArreglo.Add("@apellidos");
            oArreglo.Add("@sexo");
            oArreglo.Add("@fecha_nacimiento");
            oArreglo.Add("@estado_civil");
            oArreglo.Add("@ocupacion");
            oArreglo.Add("@domicilio");
            oArreglo.Add("@observaciones");
            oArreglo.Add("@peso");
            oArreglo.Add("@talla");
            oArreglo.Add("@imc");
            oArreglo.Add("@tipo_sangre");
            oArreglo.Add("@factor_rh");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@tipo_ced");
            oArreglo.Add("@cedula");
            oArreglo.Add("@nombre");
            oArreglo.Add("@apellidos");
            oArreglo.Add("@sexo");
            oArreglo.Add("@fecha_nacimiento");
            oArreglo.Add("@estado_civil");
            oArreglo.Add("@ocupacion");
            oArreglo.Add("@domicilio");
            oArreglo.Add("@foto");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificarNoImage()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@tipo_ced");
            oArreglo.Add("@cedula");
            oArreglo.Add("@nombre");
            oArreglo.Add("@apellidos");
            oArreglo.Add("@sexo");
            oArreglo.Add("@fecha_nacimiento");
            oArreglo.Add("@estado_civil");
            oArreglo.Add("@ocupacion");
            oArreglo.Add("@domicilio");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificarDatosPaciente()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@observaciones");
            oArreglo.Add("@peso");
            oArreglo.Add("@talla");
            oArreglo.Add("@imc");
            oArreglo.Add("@tipo_sangre");
            oArreglo.Add("@factor_rh");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar_DetalleExamenesPaciente()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@DetallesAdicionalesExamenes");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@num_expediente");

            return oArreglo;
        }

        private ArrayList oArregloPacientes()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(tipoCedula);
            oArreglo.Add(cedula);
            oArreglo.Add(nombre);
            oArreglo.Add(apellidos);
            oArreglo.Add(sexo);
            oArreglo.Add(fechaNacimiento);
            oArreglo.Add(estadoCivil);
            oArreglo.Add(ocupacion);
            oArreglo.Add(domicilio);
            if (infoImagen != null)
                oArreglo.Add(infoImagen);
            oArreglo.Add(observaciones);
            oArreglo.Add(peso);
            oArreglo.Add(talla);
            oArreglo.Add(imc);
            oArreglo.Add(tipo_sangre);
            oArreglo.Add(factor_rh);

            return oArreglo;
        }

        private ArrayList oArregloDatosPacientes()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(observaciones);
            oArreglo.Add(peso);
            oArreglo.Add(talla);
            oArreglo.Add(imc);
            oArreglo.Add(tipo_sangre);
            oArreglo.Add(factor_rh);

            return oArreglo;
        }

        private ArrayList oArreglo_DetExamPacientes()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(detallesAdicExamenes);

            return oArreglo;
        }

        private ArrayList oArregloCondicion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(numExpediente);

            return oArreglo;
        }

        private ArrayList oArregloCondicionConsulta()
        {
            ArrayList oArreglo = new ArrayList();

            if (numExpediente != 0)
                oArreglo.Add(numExpediente);

            if (tipoCedula != null)
                oArreglo.Add(tipoCedula);

            if (cedula != null)
                oArreglo.Add(cedula);

            if (nombre != null)
                oArreglo.Add(nombre);

            if (apellidos != null)
                oArreglo.Add(apellidos);

            if (fechaNacimiento != DateTime.MinValue)
                oArreglo.Add(fechaNacimiento.Date);

            if (sexo != null)
                oArreglo.Add(sexo);

            if (estadoCivil != null)
                oArreglo.Add(estadoCivil);

            if (ocupacion != null)
                oArreglo.Add(ocupacion);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            //Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Pacientes", "tipo_ced,cedula,nombre,apellidos,sexo,fecha_nacimiento,estado_civil,ocupacion,domicilio,foto,observaciones,peso,talla,imc", oArregloPacientes());
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Pacientes", oArregloParametrosInsertar(), oArregloPacientes());
        }

        public void Insertar_NoImage()
        {
            //Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Pacientes_NoImage", "tipo_ced,cedula,nombre,apellidos,sexo,fecha_nacimiento,estado_civil,ocupacion,domicilio,observaciones,peso,talla,imc", oArregloPacientes());
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Pacientes_NoImage", oArregloParametrosInsertarNoIMage(), oArregloPacientes());
        }

        public void Modificar()
        {
            //Program.oStoredProcedures.SP_Modificar("sp_U_Pacientes", "tipo_ced,cedula,nombre,apellidos,sexo,fecha_nacimiento,estado_civil,ocupacion,domicilio,foto",
            //                                       "num_expediente", oArregloPacientes(), oArregloCondicion());
            Program.oStoredProcedures.SP_Modificar("sp_U_Pacientes", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloPacientes(), oArregloCondicion());

        }

        public void Modificar_NoImage()
        {
            //Program.oStoredProcedures.SP_Modificar("sp_U_Pacientes_NoImage", "tipo_ced,cedula,nombre,apellidos,sexo,fecha_nacimiento,estado_civil,ocupacion,domicilio",
            //                           "num_expediente", oArregloPacientes(), oArregloCondicion());

            Program.oStoredProcedures.SP_Modificar("sp_U_Pacientes_NoImage", oArregloParametrosModificarNoImage(), oArregloParametrosCondicionModificar(), oArregloPacientes(), oArregloCondicion());
        }

        /// <summary>
        /// Método que modifica solo las observaciones generales y el examen físico de los pacientes
        /// </summary>
        public void Modificar_DatosPaciente()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Pacientes2", oArregloParametrosModificarDatosPaciente(), oArregloParametrosCondicionModificar(), oArregloDatosPacientes(), oArregloCondicion());
        }

        public void Modificar_DatosPaciente_DetalleExamenes()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Pacientes_DetAdicExamenes", oArregloParametrosModificar_DetalleExamenesPaciente(), oArregloParametrosCondicionModificar(), oArreglo_DetExamPacientes(), oArregloCondicion());
        }

        public string Consulta_MaxNumExpediente()
        {
            string numExp = "";

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Max_Pacientes", "Paciente");

            foreach (DataRow dr in ds.Tables[0].Rows)
                numExp = dr[0].ToString().Trim();

            return numExp;
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Pacientes");
        }

        public SqlDataReader ConsultarConParametros(string parametrosCondicion)
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Pacientes_Param", parametrosCondicion, oArregloCondicionConsulta());
        }

        public DataSet ConsultarV2(string parametrosCondicion)
        {
            return Program.oStoredProcedures.SP_Consultar_DataSetV2("sp_S_Pacientes_Param", parametrosCondicion, oArregloCondicionConsulta());
        }

        /// <summary>
        /// Lee todos los datos ingresados en la tabla de Pacientes y seguidamente los asigna a las variables correspondientes a esta clase,
        /// de esta forma al invocar los datos desde otra clase podemos manipular los datos reales del Paciente
        /// </summary>
        /// <returns>retorna una variable de tipo BOOLEAN que determina si sí se encontraron datos en la tabla de Pacientes o no</returns>
        public bool LeeDatosPaciente(string pNumExpediente)
        {
            bool datosEncontrados = false;

            DataSet ds = new DataSet();

            ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Pacientes_Param '" + pNumExpediente.Trim() + "'", "Paciente");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    numExpediente = Convert.ToInt32(dr[0].ToString().Trim());
                    cedula = dr[2].ToString().Trim();
                    nombre = dr[3].ToString().Trim();

                    apellidos = dr[4].ToString().Trim();
                    fechaNacimiento = Convert.ToDateTime(dr[6]);
                    peso = dr[12].ToString().Trim();
                }

                datosEncontrados = true;
            }
            else
                datosEncontrados = false;
            ds.Dispose();

            return datosEncontrados;
        }

        #endregion

        #region Lógica

        public double PesoHabitual(string pNumExpediente)
        {
            double peso = 0;
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select peso from Paciente where num_expediente = " + pNumExpediente.Trim(), "Paciente");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                        peso = Convert.ToDouble(dr[0]);
                }
                ds.Dispose();
            }

            return peso;
        }

        public double TallaHabitual(string pNumExpediente)
        {
            double talla = 0;
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select talla from Paciente where num_expediente = " + pNumExpediente.Trim(), "Paciente");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                        talla = Convert.ToDouble(dr[0]);
                }
                ds.Dispose();
            }

            return talla;
        }


        public double CalculaIMC(string peso, string talla)
        {
            try
            {
                double pHabitual = 0;
                double talla2 = 0;

                if (peso.Contains("."))
                {
                    peso = peso.Trim().Replace(".", ",");
                    pHabitual = Convert.ToDouble(peso);
                }
                else
                    pHabitual = Convert.ToDouble(peso);

                if (talla.Contains("."))
                {
                    talla = talla.Trim().Replace(".", ",");
                    talla2 = Convert.ToDouble(talla);
                }
                else
                    talla2 = Convert.ToDouble(talla);

                double IMC = 0;

                IMC = pHabitual / (Math.Pow(talla2, 2));

                if (Double.IsInfinity(IMC) || Double.IsNaN(IMC))
                    IMC = 0;

                return IMC;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Método que devuelve un arreglo con los valores del Examen Físico dependiendo del paciente que se quiera consultar.
        /// Primero se verifica si dicho paciente posee dichos valores originalmente, es decir, si fueron ingresados directamente
        /// en la Historia Clínica de este o si dichos datos fueron actualizados en una consulta, mediante esta forma podemos comparar
        /// en un futuro los diferentes cambios en el peso, talla e imc del paciente con el pasar del tiempo y a través de las consultas.
        /// </summary>
        /// <param name="pNumExpediente">Parámetro que recibe el num de expediente del paciente a evaluar</param>
        /// <returns>Devuelve un arreglo con los valores de Peso, Talla e IMC del paciente correspondiente</returns>
        public ArrayList LeeExamenFisicoPaciente(string pNumExpediente)
        {
            ArrayList oArregloExFisico = new ArrayList();

            //Seleccionamos datos del paciente para evaluar los datos del examen físico sólamente, para ver si ya han sido ingresados
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Pacientes_Param '" + pNumExpediente + "'", "Paciente");

            if (ds.Tables[0].Rows.Count > 0)
            {
                string idConsulta = "";

                //Seleccionamos el num max de consulta para obtener los valores más recientes del examen físico del paciente...
                string sql = "Select MAX(a.id_consulta) From Consulta_Paciente a, Paciente b " +
                             "Where a.num_expediente = b.num_expediente And b.num_expediente = " + pNumExpediente;
                DataSet ds2 = Program.oPersistencia.ejecutarSQLListas(sql, "Consulta_Paciente a, Paciente b");

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds2.Tables[0].Rows)
                        idConsulta = dr[0].ToString().Trim();//Establecemos el id de consulta                    
                    ds2.Dispose();

                    if (idConsulta != null && idConsulta != "")
                    {
                        //Seleccionamos los datos del examen físico del paciente de acuerdo a la consulta realizada más reciente
                        sql = "Select peso, talla, imc From Consulta_Paciente Where id_consulta = " + idConsulta.Trim();
                        DataSet ds3 = Program.oPersistencia.ejecutarSQLListas(sql, "Consulta_Paciente");

                        foreach (DataRow dr in ds3.Tables[0].Rows)
                        {
                            //Almacenamos los valores en un arreglo
                            oArregloExFisico.Add(dr[0]);
                            oArregloExFisico.Add(dr[1]);
                            oArregloExFisico.Add(dr[2]);
                        }
                        ds3.Dispose();
                    }
                    else
                    {
                        //Seleccionamos los datos del examen físico del paciente de acuerdo a los datos del paciente en la Historia Clínica,
                        //ya que no se encontró ninguna consulta
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            oArregloExFisico.Add(dr[12]);
                            oArregloExFisico.Add(dr[13]);
                            oArregloExFisico.Add(dr[14]);
                        }
                    }
                }
                else
                {
                    //Seleccionamos los datos del examen físico del paciente de acuerdo a los datos del paciente en la Historia Clínica,
                    //ya que no se encontró ninguna consulta
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        oArregloExFisico.Add(dr[12]);
                        oArregloExFisico.Add(dr[13]);
                        oArregloExFisico.Add(dr[14]);
                    }
                }
            }
            else
            {
                oArregloExFisico.Add(0);
                oArregloExFisico.Add(0);
                oArregloExFisico.Add(0);
            }
            ds.Dispose();

            return oArregloExFisico;
        }

        public int CalculaEdad(DateTime pFechaNacimiento)
        {
            DateTime Fecha_Actual = DateTime.Now; //se declara una variable de tipo datetime y se le da el valor de la fecha actual

            int Edad = 0;

            if (Fecha_Actual.Year > pFechaNacimiento.Year)
                Edad = Fecha_Actual.Year - pFechaNacimiento.Year;
            else
                Edad = 0;

            return Edad;
        }

        /// <summary>
        /// Devuelve el nombre del paciente por medio del número de expediente
        /// </summary>
        /// <param name="pNumExpediente">Número de Expediente del paciente que se buscará el nombre</param>
        /// <returns></returns>
        public string NombreDePaciente(string pNumExpediente)
        {
            string nombrePaciente = "";
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select nombre + ' ' + apellidos as Nombre from Paciente where num_expediente = " + pNumExpediente.Trim(), "Paciente");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                        nombrePaciente = dr[0].ToString();
                }
            }
            ds.Dispose();

            return nombrePaciente;
        }

        public ArrayList ConsultasPorPaciente(string pNumExpediente)
        {
            ArrayList oArreglo = new ArrayList();

            try
            {                
                if (pNumExpediente.Trim() != "")
                {                    
                    string sql = "Select id_consulta, fecha_consulta from Consulta_Paciente where num_expediente = " + pNumExpediente.Trim();

                    DataSet ds = Program.oPersistencia.ejecutarSQLListas(sql, "Consulta_Paciente");

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                                //Incluye el ID de Consulta y la fecha de la consulta
                                oArreglo.Add(dr[0].ToString().Trim() + " $ " + Convert.ToDateTime(dr[1]));
                        }
                        ds.Dispose();
                    }
                }
            }
            catch { return oArreglo; }

            return oArreglo;
        }

        #endregion
    }
}