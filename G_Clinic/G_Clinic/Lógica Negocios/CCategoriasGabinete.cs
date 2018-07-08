using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CCategoriasGabinete
    {
        string id_Categoria_Gabinete = "";
        string descripcion = "";

        #region Encapsulaciones de Campos

        public String IdCategoriaGabinete
        {
            set { id_Categoria_Gabinete = value; }
            get { return id_Categoria_Gabinete; }
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

            oArreglo.Add("@id_categoria_gabinete");

            return oArreglo;
        }

        private ArrayList oArregloCategoriasGabinete()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionCategoriasGabinete()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionModif_EliminCategoriasGabinete()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(id_Categoria_Gabinete);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Categorias_Gabinete", oArregloParametrosInsertar(), oArregloCategoriasGabinete());
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Categorias_Gabinete", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloCategoriasGabinete(), oArregloCondicionModif_EliminCategoriasGabinete());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Categorias_Gabinete", "id_categoria_gabinete", oArregloCondicionModif_EliminCategoriasGabinete());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Categorias_Gabinete");
        }

        public SqlDataReader ConsultarConParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Categorias_Gabinete_Param", "descripcion", oArregloCondicionCategoriasGabinete());
        }

        public bool DeterminaCategoriaRepetida(string pNuevaCategoria)
        {
            bool repetido = false;

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Categorias_Gabinete_Param '" + pNuevaCategoria.Trim() + "'", "Categorias_Gabinete");

            if (ds.Tables[0].Rows.Count > 0)
                repetido = true;
            ds.Dispose();

            return repetido;
        }

        #endregion
    }
}
