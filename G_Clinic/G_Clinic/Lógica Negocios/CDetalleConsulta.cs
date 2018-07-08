using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.IO;

namespace G_Clinic.Lógica_Negocios
{
    class CDetalleConsulta
    {
        #region Variables

        string idConsulta = "";
        string detalle = "";

        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        byte[] bArchivo;

        /// <summary>
        /// Variable opcional para no tener que leer el archivo desde el disco duro, sino desde la Bd en caso de que no se modifique o elimine el archivo
        /// </summary>
        byte[] infoArchivo;

        #endregion

        #region Encapsulaciones de Campos

        public string IdConsulta
        {
            get { return idConsulta; }
            set { idConsulta = value; }
        }

        public byte[] BArchivo
        {
            get { return bArchivo; }
            set { bArchivo = value; }
        }

        /// <summary>
        /// Variable opcional para no tener que leer el archivo desde el disco duro, sino desde la Bd en caso de que no se modifique o elimine el archivo
        /// </summary>
        public byte[] InfoArchivo
        {
            get { return infoArchivo; }
            set { infoArchivo = value; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_consulta");
            oArreglo.Add("@detalle_consulta");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_consulta");

            return oArreglo;
        }

        private ArrayList oArregloDetalle_Consulta()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idConsulta);
            oArreglo.Add(bArchivo);

            return oArreglo;
        }

        private ArrayList oArregloCondicion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idConsulta);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Detalle_Consulta", oArregloParametrosInsertar(), oArregloDetalle_Consulta());
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Detalle_Consulta", oArregloDetalle_Consulta(), oArregloParametrosCondicionModificar(), oArregloDetalle_Consulta(), oArregloCondicion());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Detalle_Consulta");
        }

        public SqlDataReader ConsultarConParametros(string parametrosCondicion)
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Detalle_Consulta_Param", parametrosCondicion, oArregloCondicion());
        }

        #endregion
    }
}
