using System;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CCategoriasEmpleado
    {
        string idCategorias = "";
        string descripcion = "";

        #region Encapsulaciones de Campos

        public String IdCategoria
        {
            set { idCategorias = value; }
            get { return idCategorias; }
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

            oArreglo.Add("@id_categoria_emp");

            return oArreglo;
        }

        private ArrayList oArregloCategoriasEmpleado()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionCategoriasEmpleado()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionModif_EliminCategoriasEmpleado()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idCategorias);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Categoria_Empleado", oArregloParametrosInsertar(), oArregloCategoriasEmpleado()); 
        }
       
        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Categoria_Empleado", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloCategoriasEmpleado(), oArregloCondicionModif_EliminCategoriasEmpleado()); 
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Categoria_Empleado", "id_categoria_emp", oArregloCondicionModif_EliminCategoriasEmpleado());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Categoria_Empleado");
        }

        public SqlDataReader ConsultarConParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Categoria_Empleado_Param", "descripcion", oArregloCondicionCategoriasEmpleado());  
        }

        public bool DeterminaCategoriaRepetida(string pNuevaCategoria)
        {
            bool repetido = false;

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Categoria_Empleado_Param '" + pNuevaCategoria.Trim() + "'", "Categorias_Empleado");

            if (ds.Tables[0].Rows.Count > 0)
                repetido = true;
            ds.Dispose();

            return repetido;
        }

        #endregion

    }
}
