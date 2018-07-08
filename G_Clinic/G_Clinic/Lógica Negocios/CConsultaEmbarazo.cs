using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace G_Clinic.Lógica_Negocios
{
    class CConsultaEmbarazo
    {
        #region Variables

        long idConsulta = 0;
        public long IdConsulta
        {
            get { return idConsulta; }
            set { idConsulta = value; }
        }

        long idConsultaActiva = 0;
        public long IdConsultaActiva
        {
            get { return idConsultaActiva; }
            set { idConsultaActiva = value; }
        }

        DateTime fechaInicialEmbarazo;
        public DateTime FechaInicialEmbarazo
        {
            get { return fechaInicialEmbarazo; }
            set { fechaInicialEmbarazo = value; }
        }

        DateTime fpp;
        public DateTime Fpp
        {
            get { return fpp; }
            set { fpp = value; }
        }

        string detalleAdicional = "";
        public string DetalleAdicional
        {
            get { return detalleAdicional; }
            set { detalleAdicional = value; }
        }

        string semanasAmenorrea = "";
        public string SemanasAmenorrea
        {
            get { return semanasAmenorrea; }
            set { semanasAmenorrea = value; }
        }

        int frecuenciaCardiacaFetal = 0;
        public int FrecuenciaCardiacaFetal
        {
            get { return frecuenciaCardiacaFetal; }
            set { frecuenciaCardiacaFetal = value; }
        }

        bool movimientoFetal = false;
        public bool MovimientoFetal
        {
            get { return movimientoFetal; }
            set { movimientoFetal = value; }
        }

        string alturaUterina = "";
        public string AlturaUterina
        {
            get { return alturaUterina; }
            set { alturaUterina = value; }
        }

        string ultrasonido = "";
        public string Ultrasonido
        {
            get { return ultrasonido; }
            set { ultrasonido = value; }
        }

        string estadoEmbarazo = "";
        public string EstadoEmbarazo
        {
            get { return estadoEmbarazo; }
            set { estadoEmbarazo = value; }
        }
                
        /// <summary>
        /// Se utiliza este datos la FUR para establecerlo en la pantalla de consultas para determinar automáticamente la FPP ya que al estar
        /// activo un embarazo debería de poseer los mismos datos del embarazo inicial...
        /// </summary>
        DateTime fur = new DateTime();
        public DateTime FUR
        {
            get { return fur; }
            set { fur = value; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_consulta");
            oArreglo.Add("@fecha_inicial_embarazo");
            oArreglo.Add("@fpp");
            oArreglo.Add("@detalle_adicional");
            //oArreglo.Add("@semanas_amenorrea");
            oArreglo.Add("@frecuencia_cardiaca_fetal");
            oArreglo.Add("@movimiento_fetal");
            oArreglo.Add("@altura_uterina");
            oArreglo.Add("@ultrasonido");
            oArreglo.Add("@estado_embarazo");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@detalle_adicional");
            oArreglo.Add("@frecuencia_cardiaca_fetal");
            oArreglo.Add("@movimiento_fetal");
            oArreglo.Add("@altura_uterina");
            oArreglo.Add("@ultrasonido");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_consulta");

            return oArreglo;
        }

        private ArrayList oArregloConsultaInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idConsulta);
            oArreglo.Add(fechaInicialEmbarazo);
            oArreglo.Add(fpp);
            oArreglo.Add(detalleAdicional);
            //oArreglo.Add(semanasAmenorrea);
            oArreglo.Add(frecuenciaCardiacaFetal);
            oArreglo.Add(movimientoFetal);
            oArreglo.Add(alturaUterina);
            oArreglo.Add(ultrasonido);
            oArreglo.Add(estadoEmbarazo);

            return oArreglo;
        }

        private ArrayList oArregloConsultaModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(detalleAdicional);
            oArreglo.Add(frecuenciaCardiacaFetal);
            oArreglo.Add(movimientoFetal);
            oArreglo.Add(alturaUterina);
            oArreglo.Add(ultrasonido);

            return oArreglo;
        }

        private ArrayList oArregloCondicion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idConsulta);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Consultas_Embarazo", oArregloParametrosInsertar(), oArregloConsultaInsertar());
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Consultas_Embarazo", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloConsultaModificar(), oArregloCondicion());
        }

        public DataSet ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar_DataSet("sp_S_Consultas_Embarazo_Param", "id_consulta", oArregloCondicion());
        }

        #endregion

        #region Lógica

        /// <summary>
        /// Determina si hay un periodo de embarazo Iniciado o Activo, este buscará automáticamente por estas palabras ya que cuando
        /// se finalice el periodo de embarazo todos los estados Activos Actuales pasarón a 'Inactivos' llegando hasta 'Finalizados'
        /// </summary>
        /// <param name="pNumExpediente"></param>
        /// <returns></returns>
        public DateTime DeterminaPeriodoEmbarazoIniciado(string pNumExpediente)
        {
            DateTime dt = DateTime.MinValue;

            if (pNumExpediente.Trim() != "")
            {
                string consulta = "Select b.fecha_inicial_embarazo, a.id_consulta, a.fecha_ultima_menstruacion, b.estado_embarazo from Consulta_Paciente a, Consultas_Con_Embarazo b " +
                                  "Where a.id_consulta = b.id_consulta and a.tipo_consulta = 1 " +
                    //"and (b.estado_embarazo = 'Activo' or b.estado_embarazo = 'Inicializado') " + 
                                  "and a.num_expediente = " + pNumExpediente.Trim();// + " Order By a.id_consulta ASC";

                DataSet ds = Program.oPersistencia.ejecutarSQLListas(consulta, "Consulta_Paciente a, Consultas_Con_Embarazo b");

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr[3].ToString().Trim() == "Inicializado")
                            {
                                //Se trae la FUR para establecerla en la pantalla de consultas para determinar automáticamente la FPP ya que al estar
                                //activo el embarazo debería de poseer los mismos datos del embarazo inicial...
                                fur = Convert.ToDateTime(dr[2]);
                                idConsultaActiva = Convert.ToInt64(dr[1]);//En caso de q se quiera cerrar el periodo de embarazo activo en el formulario de consultas
                                dt = Convert.ToDateTime(dr[0]);//Fecha inicial de embarazo
                            }
                            else if (dr[3].ToString().Trim() == "Finalizado")
                            {
                                fur = DateTime.MinValue;
                                dt = DateTime.MinValue;
                            }
                        }
                    }
                    ds.Dispose();
                }
            }
            return dt;
        }

        #endregion
    }
}