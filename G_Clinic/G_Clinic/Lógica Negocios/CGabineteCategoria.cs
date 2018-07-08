using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CGabineteCategoria
    {
        #region Variables

        string id_Categoria_Gabinete = "";
        string id_Gabinete = "";
        string auxId_Categoria_Gabinete = "";
        string descripcion = "";
        string nombre = "";

        #endregion

        #region Encapsulaciones de Campos

        public String IdCategoriaGabinete
        {
            set { id_Categoria_Gabinete = value; }
            get { return id_Categoria_Gabinete; }
        }

        public String IdGabinete
        {
            set { id_Gabinete = value; }
            get { return id_Gabinete; }
        }
        
        public string AuxId_Categoria_Gabinete
        {
            get { return auxId_Categoria_Gabinete; }
            set { auxId_Categoria_Gabinete = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_categoria_gabinete");
            oArreglo.Add("@id_gabinete");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_gabinete");
            oArreglo.Add("@id_categoria_gabinete1");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_gabinete");
            oArreglo.Add("@id_categoria_gabinete");

            return oArreglo;
        }

        private ArrayList oArregloGabinetesCategoriaIngresar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(id_Categoria_Gabinete);
            oArreglo.Add(id_Gabinete);

            return oArreglo;
        }

        private ArrayList oArregloGabinetesCategoria()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(id_Gabinete);
            oArreglo.Add(auxId_Categoria_Gabinete);

            return oArreglo;
        }

        private ArrayList oArregloModificarGabinetesCategoria()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(id_Gabinete);
            oArreglo.Add(id_Categoria_Gabinete);

            return oArreglo;
        }        

        private ArrayList oArregloCondicionGabinetesCategoria()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(id_Categoria_Gabinete);
            oArreglo.Add(id_Gabinete);

            return oArreglo;
        }

        private ArrayList oArregloCondicionModif_EliminGabinestesCategoria()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(id_Gabinete);
            oArreglo.Add(id_Categoria_Gabinete);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Gabinetes_Categoria", oArregloParametrosInsertar(), oArregloGabinetesCategoriaIngresar());
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Gabinetes_Categoria", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloGabinetesCategoria(), oArregloModificarGabinetesCategoria());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Gabinetes_Categoria", "id_gabinete, id_categoria_gabinete", oArregloCondicionModif_EliminGabinestesCategoria());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Gabinete_Categoria");
        }

        /// <summary>
        /// Este método devuelve un dataset con los resultados de una consulta añadiendo cualquiera de los 3 campos pero el campo de 
        /// pIdCategoriaGabinete no puede ser nulo por referencias en el StoredProcedure correspondiente y los joins entre tablas...
        /// </summary>
        /// <param name="pIdCategoriaGabinete"></param>
        /// <param name="pDescripcion"></param>
        /// <param name="pNombre"></param>
        /// <returns></returns>
        public DataSet ConsultarConParametros(string pIdCategoriaGabinete, string pDescripcion, string pNombre)
        {
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Gabinete_Param '" + pIdCategoriaGabinete.Trim() + "', '" + pDescripcion.Trim() + "', '" + pNombre.Trim() + "'",
                                                                 "Categorias_Gabinete a, Gabinete b, Gabinete_Categoria c");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }
            return null;            
        }

        #endregion
    }
}
