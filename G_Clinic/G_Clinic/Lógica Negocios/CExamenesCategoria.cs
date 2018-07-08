using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CExamenesCategoria
    {
        #region Variables

        string id_Categoria_Examen = "";
        string id_Examen = "";
        string auxId_Categoria_Examen = "";
        string descripcion = "";
        string nombre = "";

        #endregion

        #region Encapsulaciones de Campos

        public String IdCategoriaExamen
        {
            set { id_Categoria_Examen = value; }
            get { return id_Categoria_Examen; }
        }

        public String IdExamen
        {
            set { id_Examen = value; }
            get { return id_Examen; }
        }

        public string AuxId_Categoria_Examen
        {
            get { return auxId_Categoria_Examen; }
            set { auxId_Categoria_Examen = value; }
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

            oArreglo.Add("@id_categoria_examen");
            oArreglo.Add("@id_examen");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_examen");
            oArreglo.Add("@id_categoria_examen1");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_examen");
            oArreglo.Add("@id_categoria_examen");

            return oArreglo;
        }

        private ArrayList oArregloGabinetesCategoriaIngresar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(id_Categoria_Examen);
            oArreglo.Add(id_Examen);

            return oArreglo;
        }

        private ArrayList oArregloGabinetesCategoria()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(id_Examen);
            oArreglo.Add(auxId_Categoria_Examen);

            return oArreglo;
        }

        private ArrayList oArregloModificarGabinetesCategoria()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(id_Examen);
            oArreglo.Add(id_Categoria_Examen);

            return oArreglo;
        }

        private ArrayList oArregloCondicionGabinetesCategoria()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(id_Categoria_Examen);
            oArreglo.Add(id_Examen);

            return oArreglo;
        }

        private ArrayList oArregloCondicionModif_EliminGabinestesCategoria()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(id_Examen);
            oArreglo.Add(id_Categoria_Examen);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Examenes_Categoria", oArregloParametrosInsertar(), oArregloGabinetesCategoriaIngresar());
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Examenes_Categoria", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloGabinetesCategoria(), oArregloModificarGabinetesCategoria());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Examenes_Categoria", "id_examen, id_categoria_examen", oArregloCondicionModif_EliminGabinestesCategoria());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Examenes_Categoria");
        }

        /// <summary>
        /// Este método devuelve un dataset con los resultados de una consulta añadiendo cualquiera de los 3 campos pero el campo de 
        /// pIdCategoriaExamen no puede ser nulo por referencias en el StoredProcedure correspondiente y los joins entre tablas...
        /// </summary>
        /// <param name="pIdCategoriaGabinete"></param>
        /// <param name="pDescripcion"></param>
        /// <param name="pNombre"></param>
        /// <returns></returns>
        public DataSet ConsultarConParametros(string pIdCategoriaExamen, string pDescripcion, string pNombre)
        {
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Examenes_Param '" + pIdCategoriaExamen.Trim() + "', '" + pDescripcion.Trim() + "', '" + pNombre.Trim() + "'",
                                                                 "Categorias_Examenes a, Examenes_Laboratorio b, Examenes_Categoria c");
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
