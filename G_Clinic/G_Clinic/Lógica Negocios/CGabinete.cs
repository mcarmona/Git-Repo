using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CGabinete
    {
        string idGabinete = "";
        string nombre = "";
        string descripcion = "";

        #region Encapsulaciones de Campos

        public String IdGabinete
        {
            set { idGabinete = value; }
            get { return idGabinete; }
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

            oArreglo.Add("@id_gabinete");

            return oArreglo;
        }

        private ArrayList oArregloGabinete()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(nombre);
            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionGabinete()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(nombre);
            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionModif_EliminGabinete()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idGabinete);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Gabinete", oArregloParametrosInsertar(), oArregloGabinete()); 
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Gabinete", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloGabinete(), oArregloCondicionModif_EliminGabinete());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Gabinete", "id_gabinete", oArregloCondicionModif_EliminGabinete());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Gabinete");
        }

        public SqlDataReader ConsultarConParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Gabinete_Param", "nombre", oArregloCondicionGabinete());  
        }

        public string Max_Gabinete()
        {
            string numGabinete = "";

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Max_Gabinete", "Gabinete");

            foreach (DataRow dr in ds.Tables[0].Rows)
                numGabinete = dr[0].ToString().Trim();

            return numGabinete;
        }

        #endregion
    }
}
