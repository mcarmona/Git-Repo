using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CExamenes
    {
        string idExamen = "";
        string nombre = "";
        string descripcion = "";        

        #region Encapsulaciones de Campos

        public String IdExamen
        {
            set { idExamen = value; }
            get { return idExamen; }
        }

        public String Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        public String Descripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@nombre");
            oArreglo.Add("@descripcion");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@nombre");
            oArreglo.Add("@descripcion");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_examen");

            return oArreglo;
        }

        private ArrayList oArregloExamen()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(nombre);
            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionExamen()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(nombre);
            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionModif_EliminExamen()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idExamen);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Examenes_Laboratorio", oArregloParametrosInsertar(), oArregloExamen());
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Examenes_Laboratorio", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloExamen(), oArregloCondicionModif_EliminExamen());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Examenes_Laboratorio", "id_examen", oArregloCondicionModif_EliminExamen());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Examenes_Laboratorio");
        }

        public SqlDataReader ConsultarConParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Examenes_Param", "nombre", oArregloCondicionExamen());
        }

        public string Max_Examen()
        {
            string numExamen = "";

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Max_Examenes", "Examenes_Laboratorio");

            foreach (DataRow dr in ds.Tables[0].Rows)
                numExamen = dr[0].ToString().Trim();

            return numExamen;
        }

        #endregion
    }
}
