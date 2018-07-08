using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CGabineteConsulta
    {
        #region Variables

        string idGabinete = "";
        string idConsulta = "";
        string detalleAdicional = "";
        string estado = "";
        DateTime fechaResultados = new DateTime();
        string detalleResultados = "";

        #endregion

        #region Encapsulaciones de Campos

        public String IdGabinete
        {
            set { idGabinete = value; }
            get { return idGabinete; }
        }

        public string IdConsulta
        {
            get { return idConsulta; }
            set { idConsulta = value; }
        }

        public string DetalleAdicional
        {
            get { return detalleAdicional; }
            set { detalleAdicional = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public DateTime FechaResultados
        {
            get { return fechaResultados; }
            set { fechaResultados = value; }
        }

        public string DetalleResultados
        {
            get { return detalleResultados; }
            set { detalleResultados = value; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_gabinete");
            oArreglo.Add("@id_consulta");
            oArreglo.Add("@detalle_adicional");
            oArreglo.Add("@estado");
            oArreglo.Add("@fecha_resultados");
            oArreglo.Add("@detalle_resultados");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@estado");
            oArreglo.Add("@fecha_resultados");
            oArreglo.Add("@detalle_resultados");

            return oArreglo;
        }

        private ArrayList oArregloParametrosEliminar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_gabinete");
            oArreglo.Add("@id_consulta");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionEliminar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_consulta");

            return oArreglo;
        }

        private ArrayList oArregloGabinetesConsulta()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idGabinete);
            oArreglo.Add(idConsulta);
            oArreglo.Add(detalleAdicional);
            oArreglo.Add(estado);
            oArreglo.Add(fechaResultados);
            oArreglo.Add(detalleResultados);

            return oArreglo;
        }

        private ArrayList oArregloGabinetesConsulta_Modificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(estado);
            oArreglo.Add(fechaResultados);
            oArreglo.Add(detalleResultados);

            return oArreglo;
        }

        private ArrayList oArregloCondicionExamenesConsulta()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idGabinete);
            oArreglo.Add(idConsulta);

            return oArreglo;
        }

        private ArrayList oArregloCondicionGabinetesConsulta()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idConsulta);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Gabinetes_Consulta", oArregloParametrosInsertar(), oArregloGabinetesConsulta());
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Gabinetes_Consulta", oArregloParametrosModificar(),
                                                                              oArregloParametrosEliminar(),
                                                                              oArregloGabinetesConsulta_Modificar(),
                                                                              oArregloCondicionExamenesConsulta());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Gabinetes_Consulta", "id_consulta", oArregloCondicionGabinetesConsulta());
        }

        public DataSet ConsultarSinParametros(string pIdConsulta)
        {
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Gabinete_Consulta '" + pIdConsulta.Trim() + "'", "Gabinete_Consulta");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }
            else
                return null;            
        }

        /// <summary>
        /// Devuelve la descripción del Gabinete, no el nombre
        /// </summary>
        /// <param name="pIdGabinete"></param>
        /// <returns></returns>
        public string DescripcionGabinete(string pIdGabinete)
        {
            string gabinete = "";
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select descripcion from Gabinete where id_gabinete = " + pIdGabinete.Trim(), "Gabinete");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                        gabinete = dr[0].ToString().Trim();
                }
                ds.Dispose();
            }

            return gabinete;
        }

        public string NombreGabinete(string pIdGabinete)
        {
            string gabinete = "";
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select nombre from Gabinete where id_gabinete = " + pIdGabinete.Trim(), "Gabinete");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                        gabinete = dr[0].ToString().Trim();
                }
                ds.Dispose();
            }

            return gabinete;
        }
        #endregion
    }
}