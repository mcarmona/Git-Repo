using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CCategoriasExamenes
    {
        string id_Categoria_Examen = "";
        string descripcion = "";

        #region Encapsulaciones de Campos

        public String IdCategoriaExamen
        {
            set { id_Categoria_Examen = value; }
            get { return id_Categoria_Examen; }
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

            oArreglo.Add("@id_categoria_examen");

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

            oArreglo.Add(id_Categoria_Examen);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Categorias_Examenes", oArregloParametrosInsertar(), oArregloCategoriasGabinete());
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Categorias_Examenes", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloCategoriasGabinete(), oArregloCondicionModif_EliminCategoriasGabinete());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Categorias_Examenes", "id_categoria_examen", oArregloCondicionModif_EliminCategoriasGabinete());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Categorias_Examenes");
        }

        public SqlDataReader ConsultarConParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Categorias_Examenes_Param", "descripcion", oArregloCondicionCategoriasGabinete());
        }

        public bool DeterminaCategoriaRepetida(string pNuevaCategoria)
        {
            bool repetido = false;

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Categorias_Examenes_Param '" + pNuevaCategoria.Trim() + "'", "Categorias_Examenes");

            if (ds.Tables[0].Rows.Count > 0)
                repetido = true;
            ds.Dispose();

            return repetido;
        }

        #endregion
    }
}
