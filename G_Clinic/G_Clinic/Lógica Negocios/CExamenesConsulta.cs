using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CExamenesConsulta
    {
        #region Variables

        string idExamen = "";
        string idConsulta = "";
        string detalleAdicional = "";
        string estado = "";
        DateTime fechaResultados = new DateTime();
        string detalleResultados = "";

        #endregion

        #region Encapsulaciones de Campos

        public String IdExamen
        {
            set { idExamen = value; }
            get { return idExamen; }
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

            oArreglo.Add("@id_examen");
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

            oArreglo.Add("@id_examen");
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

            oArreglo.Add(idExamen);
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

            oArreglo.Add(idExamen);
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
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Examenes_Consulta", oArregloParametrosInsertar(), oArregloGabinetesConsulta());
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Detalle_Examenes_Consulta", oArregloParametrosModificar(),
                                                                                     oArregloParametrosEliminar(),
                                                                                     oArregloGabinetesConsulta_Modificar(),
                                                                                     oArregloCondicionExamenesConsulta());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Examenes_Consulta", "id_consulta", oArregloCondicionGabinetesConsulta());
        }

        public DataSet ConsultarSinParametros(string pIdConsulta)
        {
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Examenes_Consulta '" + pIdConsulta.Trim() + "'", "Examenes_Consulta");

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

        public string DescripcionExamen(string pIdExamen)
        {
            string examen = "";
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select descripcion from Examenes_Laboratorio where id_examen = " + pIdExamen.Trim(), "Examenes_Laboratorio");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                        examen = dr[0].ToString().Trim();
                }
                ds.Dispose();
            }

            return examen;
        }

        public string NombreExamen(string pIdExamen)
        {
            string examen = "";
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select nombre from Examenes_Laboratorio where id_examen = " + pIdExamen.Trim(), "Examenes_Laboratorio");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                        examen = dr[0].ToString().Trim();
                }
                ds.Dispose();
            }

            return examen;
        }
        #endregion
    }
}