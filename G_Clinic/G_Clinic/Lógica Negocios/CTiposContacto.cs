using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace G_Clinic.Lógica_Negocios
{
    class CTiposContacto
    {
        string idTipo = "";
        string descripcion = "";

        public CTiposContacto()
        {

        }

        #region Encapsulaciones de Campos

        public String IdTipo
        {
            set { idTipo = value; }
            get { return idTipo; }
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

            oArreglo.Add("@id_tipo_contacto");

            return oArreglo;
        }

        private ArrayList oArregloTipoContactos()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionTipoContactos()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionModif_EliminTipoContactos()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idTipo);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            //Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Tipo_Contacto", "descripcion", oArregloTipoContactos()); 
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Tipo_Contacto", oArregloParametrosInsertar(), oArregloTipoContactos()); 
        }
       
        public void Modificar()
        {
            //Program.oStoredProcedures.SP_Modificar("sp_U_Tipo_Contacto", "descripcion", "id_tipo_contacto", oArregloTipoContactos(), oArregloCondicionModif_EliminTipoContactos()); 
            Program.oStoredProcedures.SP_Modificar("sp_U_Tipo_Contacto", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloTipoContactos(), oArregloCondicionModif_EliminTipoContactos()); 
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Tipo_Contacto", "id_tipo_contacto", oArregloCondicionModif_EliminTipoContactos());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Tipo_Contacto");
        }

        public SqlDataReader ConsultarConParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Tipo_Contacto_Param", "descripcion", oArregloCondicionTipoContactos());  
        }

        #endregion

    }
}
