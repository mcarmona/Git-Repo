using System;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic.Lógica_Negocios
{
    class CConsultas
    {
        #region Variables

        long idConsulta = 0;
        int numExpediente = 0;
        string tipoConsulta = "";

        string tipo_ced = "";
        public string Tipo_ced
        {
            get { return tipo_ced; }
            set { tipo_ced = value; }
        }

        string cedula = "";
        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        string nombre = "";
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        string apellidos = "";
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        DateTime fechaConsulta;
        DateTime fechaUltimaMenstruacion;
        string amenorrea = "";
        string detalleFur = "";
        string peso = "";
        string talla;
        string imc = "";
        string presionArterial = "";
        string idMetodo = "";
        string detalleAnticoncepcion = "";
        byte[] detalleConsulta;
        byte[] tratamiento;
        byte[] diagnostico;

        DateTime fechaInicial;
        public DateTime FechaInicial
        {
            get { return fechaInicial; }
            set { fechaInicial = value; }
        }

        DateTime fechaFinal;
        public DateTime FechaFinal
        {
            get { return fechaFinal; }
            set { fechaFinal = value; }
        }

        #endregion

        #region Encapsulaciones de Campos

        public long IdConsulta
        {
            get { return idConsulta; }
            set { idConsulta = value; }
        }

        public int NumExpediente
        {
            get { return numExpediente; }
            set { numExpediente = value; }
        }

        public string TipoConsulta
        {
            get { return tipoConsulta; }
            set { tipoConsulta = value; }
        }

        public DateTime FechaConsulta
        {
            get { return fechaConsulta; }
            set { fechaConsulta = value; }
        }

        public DateTime FechaUltimaMenstruacion
        {
            get { return fechaUltimaMenstruacion; }
            set { fechaUltimaMenstruacion = value; }
        }

        public string Amenorrea
        {
            get { return amenorrea; }
            set { amenorrea = value; }
        }

        public string Detalle_Fur
        {
            get { return detalleFur; }
            set { detalleFur = value; }
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

        public string PresionArterial
        {
            get { return presionArterial; }
            set { presionArterial = value; }
        }

        public string IdMetodo
        {
            get { return idMetodo; }
            set { idMetodo = value; }
        }

        public string DetalleAnticoncepcion
        {
            get { return detalleAnticoncepcion; }
            set { detalleAnticoncepcion = value; }
        }

        public byte[] DetalleConsulta
        {
            get { return detalleConsulta; }
            set { detalleConsulta = value; }
        }

        public byte[] Tratamiento
        {
            get { return tratamiento; }
            set { tratamiento = value; }
        }

        public byte[] Diagnostico
        {
            get { return diagnostico; }
            set { diagnostico = value; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@num_expediente");
            oArreglo.Add("@tipo_consulta");
            oArreglo.Add("@fecha_consulta");
            oArreglo.Add("@fecha_ultima_menstruacion");
            oArreglo.Add("@amenorrea");
            oArreglo.Add("@detalle_fur");
            oArreglo.Add("@peso");
            oArreglo.Add("@talla");
            oArreglo.Add("@imc");
            oArreglo.Add("@presion_arterial");
            oArreglo.Add("@id_metodo");
            oArreglo.Add("@detalle_anticoncepcion");
            oArreglo.Add("@detalle_consulta");
            oArreglo.Add("@tratamiento");
            oArreglo.Add("@diagnostico");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@num_expediente");
            oArreglo.Add("@tipo_consulta");
            oArreglo.Add("@fecha_consulta");
            oArreglo.Add("@fecha_ultima_menstruacion");
            oArreglo.Add("@amenorrea");
            oArreglo.Add("@detalle_fur");
            oArreglo.Add("@peso");
            oArreglo.Add("@talla");
            oArreglo.Add("@imc");
            oArreglo.Add("@presion_arterial");
            oArreglo.Add("@id_metodo");
            oArreglo.Add("@detalle_anticoncepcion");
            oArreglo.Add("@detalle_consulta");
            oArreglo.Add("@tratamiento");
            oArreglo.Add("@diagnostico");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_consulta");

            return oArreglo;
        }

        private ArrayList oArregloConsulta()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(numExpediente);
            oArreglo.Add(tipoConsulta);
            oArreglo.Add(fechaConsulta);
            oArreglo.Add(fechaUltimaMenstruacion);
            oArreglo.Add(amenorrea);
            oArreglo.Add(detalleFur);
            oArreglo.Add(peso);
            oArreglo.Add(talla);
            oArreglo.Add(imc);
            oArreglo.Add(presionArterial);
            oArreglo.Add(idMetodo);
            oArreglo.Add(detalleAnticoncepcion);
            oArreglo.Add(detalleConsulta);
            oArreglo.Add(tratamiento);
            oArreglo.Add(diagnostico);

            return oArreglo;
        }

        private ArrayList oArregloCondicion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idConsulta);

            return oArreglo;
        }

        private ArrayList oArregloCondicionConsulta()
        {
            ArrayList oArreglo = new ArrayList();

            if (idConsulta != 0)
                oArreglo.Add(idConsulta);

            if (numExpediente != 0)
                oArreglo.Add(numExpediente);

            if (tipo_ced != null)
                oArreglo.Add(tipo_ced);

            if (cedula != null)
                oArreglo.Add(cedula);

            if (nombre != null)
                oArreglo.Add(nombre);

            if (apellidos != null)
                oArreglo.Add(apellidos);

            //if (tipoConsulta != null)
            //    oArreglo.Add(tipoConsulta);

            if (fechaConsulta != System.DateTime.MinValue)
                oArreglo.Add(fechaConsulta);

            if (fechaInicial != System.DateTime.MinValue && fechaFinal != DateTime.MinValue)
            {
                oArreglo.Add(fechaInicial);
                oArreglo.Add(fechaFinal);
            }

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            //Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Pacientes", "tipo_ced,cedula,nombre,apellidos,sexo,fecha_nacimiento,estado_civil,ocupacion,domicilio,foto,observaciones,peso,talla,imc", oArregloPacientes());
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Consulta", oArregloParametrosInsertar(), oArregloConsulta());
        }

        public void Modificar()
        {
            //Program.oStoredProcedures.SP_Modificar("sp_U_Pacientes", "tipo_ced,cedula,nombre,apellidos,sexo,fecha_nacimiento,estado_civil,ocupacion,domicilio,foto",
            //                                       "num_expediente", oArregloPacientes(), oArregloCondicion());
            Program.oStoredProcedures.SP_Modificar("sp_U_Consulta", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloConsulta(), oArregloCondicion());

        }

        public string Consulta_MaxNumExpediente()
        {
            string numExp = "";

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Max_Pacientes", "Paciente");

            foreach (DataRow dr in ds.Tables[0].Rows)
                numExp = dr[0].ToString().Trim();

            return numExp;
        }

        public string Max_Consulta()
        {
            string numConsulta = "";

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Max_Consulta", "Consulta");

            foreach (DataRow dr in ds.Tables[0].Rows)
                numConsulta = dr[0].ToString().Trim();

            return numConsulta;
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Consulta");
        }

        public SqlDataReader ConsultarConParametros(string parametrosCondicion)
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Consulta_Param", parametrosCondicion, oArregloCondicionConsulta());
        }

        public ArrayList DetallesConsultaEpicrisis(string pIdConsulta)
        {
            string path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");
            ArrayList oArrayList = new ArrayList();
            string sqlConsulta = "Select fecha_consulta, detalle_consulta, tratamiento, diagnostico, id_consulta from Consulta_Paciente where id_consulta = " + pIdConsulta.Trim();

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(sqlConsulta.Trim(), "Consultas");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    System.Windows.Forms.RichTextBox oRTB = new System.Windows.Forms.RichTextBox();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        oArrayList.Clear();

                        byte[] detalleConsulta = null;
                        detalleConsulta = (byte[])dr[1];

                        byte[] tratamiento = null;
                        tratamiento = (byte[])dr[2];

                        byte[] diagnostico = null;
                        diagnostico = (byte[])dr[3];

                        Metodos_Globales.CreateTempFileFromByteArray(detalleConsulta, path + "\\Detalle_Consulta.rtf");
                        Metodos_Globales.CreateTempFileFromByteArray(tratamiento, path + "\\Tratamiento.rtf");
                        Metodos_Globales.CreateTempFileFromByteArray(diagnostico, path + "\\Diagnostico.rtf");

                        try
                        {
                            oRTB.LoadFile(path + "\\Detalle_Consulta.rtf", System.Windows.Forms.RichTextBoxStreamType.RichText);
                        }
                        catch
                        {
                            oRTB.LoadFile(path + "\\Detalle_Consulta.rtf", System.Windows.Forms.RichTextBoxStreamType.PlainText);
                        }
                        oArrayList.Add(oRTB.Text);

                        try
                        {
                            oRTB.LoadFile(path + "\\Diagnostico.rtf", System.Windows.Forms.RichTextBoxStreamType.RichText);
                        }
                        catch
                        {
                            oRTB.LoadFile(path + "\\Diagnostico.rtf", System.Windows.Forms.RichTextBoxStreamType.PlainText);
                        }                        
                        oArrayList.Add(oRTB.Text);

                        try
                        {
                            oRTB.LoadFile(path + "\\Tratamiento.rtf", System.Windows.Forms.RichTextBoxStreamType.RichText);
                        }
                        catch
                        {
                            oRTB.LoadFile(path + "\\Tratamiento.rtf", System.Windows.Forms.RichTextBoxStreamType.PlainText);
                        }
                        oArrayList.Add(oRTB.Text);

                    }
                }
                ds.Dispose();
            }

            return oArrayList;
        }

        #endregion

        #region Lógica

        /// <summary>
        /// Calcula las semanas de Amenorrea
        /// </summary>
        /// <param name="pFUR"></param>
        /// <returns>Devuelve las semanas redondeadas </returns>
        public double CalculoAmenorrea(DateTime pFUR)
        {
            if (pFUR.Date <= DateTime.Today.Date)
            {
                double ValorAmenorrea = 0;

                TimeSpan tp = new TimeSpan();
                tp = DateTime.Today.Date - pFUR.Date;

                ValorAmenorrea = tp.TotalDays / 7;

                return Math.Floor(ValorAmenorrea);
            }
            else
                return -1;
        }

        /// <summary>
        /// Cuenta los días de Amenorrea en la semana determinada por la función CalculoAmenorra
        /// </summary>
        /// <param name="pFur"></param>
        /// <returns></returns>
        public int CalculoDiasAmenorrea(DateTime pFur)
        {
            double ValorAmenorrea = 0;

            TimeSpan tp = new TimeSpan();
            tp = DateTime.Today.Date - pFur.Date;

            ValorAmenorrea = tp.TotalDays;

            int totalDays = Convert.ToInt32(ValorAmenorrea);

            int cont = 0;
            for (int i = 0; i < totalDays; )
            {
                cont++;

                if (cont > 6)
                    cont = 0;

                i++;
            }

            return cont;
        }

        /// <summary>
        /// Calcula la Fecha Probable de Parto de acuerdo a la Fecha de la Última Regla
        /// </summary>
        /// <param name="pFur"></param>
        /// <returns></returns>
        public DateTime CalculoFPP(DateTime pFur)
        {
            DateTime fpp = new DateTime();

            fpp = pFur.AddDays(280);

            return fpp;
        }

        /// <summary>
        /// Calcula la Fecha de la última menstruación de acuerdo a la Fecha Probable de Parto, la cual la podrían determinar por Ultrasonido
        /// pero ya eso le concierne al médico
        /// </summary>
        /// <param name="pFPP"></param>
        /// <returns></returns>
        public DateTime CalculoFUR(DateTime pFPP)
        {
            DateTime fur = new DateTime();
            TimeSpan oTimeSpan = new TimeSpan(280, 0, 0, 0);

            fur = pFPP.Subtract(oTimeSpan);

            return fur;
        }

        #endregion
    }
}