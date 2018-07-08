using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CMetodosAnticonceptivos
    {
        string idMetodo = "";
        string descripcion = "";

        public CMetodosAnticonceptivos()
        {
        }

        #region Encapsulaciones de Campos

        public String IdMetodo
        {
            set { idMetodo = value; }
            get { return idMetodo; }
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

            oArreglo.Add("@descripcion");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@descripcion");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_metodo");

            return oArreglo;
        }

        private ArrayList oArregloMetodosAnticonceptivos()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionMetodosAnticonceptivos()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionModif_EliminMetodosAnticonceptivos()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idMetodo);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            //Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Tipo_Contacto", "descripcion", oArregloTipoContactos()); 
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Metodos_Anticonceptivos", oArregloParametrosInsertar(), oArregloMetodosAnticonceptivos());
        }

        public void Modificar()
        {
            //Program.oStoredProcedures.SP_Modificar("sp_U_Tipo_Contacto", "descripcion", "id_tipo_contacto", oArregloTipoContactos(), oArregloCondicionModif_EliminTipoContactos()); 
            Program.oStoredProcedures.SP_Modificar("sp_U_Metodos_Anticonceptivos", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloMetodosAnticonceptivos(), oArregloCondicionModif_EliminMetodosAnticonceptivos());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Metodos_Anticonceptivos", "id_metodo", oArregloCondicionModif_EliminMetodosAnticonceptivos());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Metodos_Anticonceptivos");
        }

        public SqlDataReader ConsultarConParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Metodos_Anticonceptivos_Param", "descripcion", oArregloCondicionMetodosAnticonceptivos());
        }

        public bool DeterminaMetodoRepetido(string pNuevoMetodo)
        {
            bool repetido = false;

            DataSet ds =Program.oPersistencia.ejecutarSQLListas("sp_S_Metodos_Anticonceptivos_Param '" + pNuevoMetodo.Trim() + "'", "Metodos_Anticonceptivos");

            if (ds.Tables[0].Rows.Count > 0)
                repetido = true;
            ds.Dispose();

            return repetido; 
        }

        #endregion
    }
}
