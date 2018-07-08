using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CDatosFamiliaresPaciente
    {
        #region Variables

        string numExpediente = "";
        string tipoFamiliar = "";        
        string nombre = "";        
        string apellidos = "";        
        string telefonos = "";        
        string email = "";        
        string observaciones = "";

        #endregion

        #region Encapsulaciones de Campos

        public string NumExpediente
        {
            get { return numExpediente; }
            set { numExpediente = value; }
        }

        public string TipoFamiliar
        {
            get { return tipoFamiliar; }
            set { tipoFamiliar = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Telefonos
        {
            get { return telefonos; }
            set { telefonos = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@num_expediente");
            oArreglo.Add("@tipo_familiar");
            oArreglo.Add("@nombre");
            oArreglo.Add("@apellidos");
            oArreglo.Add("@telefonos");
            oArreglo.Add("@email");
            oArreglo.Add("@observaciones");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@nombre");
            oArreglo.Add("@apellidos");
            oArreglo.Add("@telefonos");
            oArreglo.Add("@email");
            oArreglo.Add("@observaciones");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@num_expediente");
            oArreglo.Add("@tipo_familiar");

            return oArreglo;
        }

        private ArrayList oArregloDatosFamiliares()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(numExpediente); 
            oArreglo.Add(tipoFamiliar);
            oArreglo.Add(nombre);
            oArreglo.Add(apellidos);
            oArreglo.Add(telefonos);
            oArreglo.Add(email);
            oArreglo.Add(observaciones);

            return oArreglo;
        }

        private ArrayList oArregloDatosFamiliaresModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(nombre);
            oArreglo.Add(apellidos);
            oArreglo.Add(telefonos);
            oArreglo.Add(email);
            oArreglo.Add(observaciones);

            return oArreglo;
        }

        private ArrayList oArregloCondicion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(numExpediente);
            oArreglo.Add(tipoFamiliar); 

            return oArreglo;
        }

        private ArrayList oArregloSeleccion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(numExpediente);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            //Program.oStoredProcedures.SP_GuardarNuevo("sp_I_DatosFamiliares", "num_expediente,tipo_familiar,nombre,apellidos,telefonos,email,observaciones", oArregloDatosFamiliares());
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_DatosFamiliares", oArregloParametrosInsertar(), oArregloDatosFamiliares());
        }

        public void Modificar()
        {
            //Program.oStoredProcedures.SP_Modificar("sp_U_DatosFamiliares", "nombre,apellidos,telefonos,email,observaciones", "num_expediente,tipo_familiar", oArregloDatosFamiliaresModificar(), oArregloCondicion());
            Program.oStoredProcedures.SP_Modificar("sp_U_DatosFamiliares", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloDatosFamiliaresModificar(), oArregloCondicion());
        }

        public SqlDataReader Consultar()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_DatosFamiliares", "num_expediente", oArregloSeleccion());
        }

        public DataSet ConsultarDataset()
        {
            return Program.oStoredProcedures.SP_Consultar_DataSet("sp_S_DatosFamiliares", "num_expediente", oArregloSeleccion());
        }

        #endregion
    }
}
