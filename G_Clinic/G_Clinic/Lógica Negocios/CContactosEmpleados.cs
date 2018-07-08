using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace G_Clinic.Lógica_Negocios
{
    class CContactosEmpleados
    {
        #region Variables

        string idEmpleado = "";
        int idTipoContacto = 0;
        string descripcion = "";

        string auxIdTIpoContacto = "";
        string auxDescripcion = "";

        #endregion

        #region Encapsulaciones

        public string IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        public int IdTipoContacto
        {
            get { return idTipoContacto; }
            set { idTipoContacto = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string AuxIdTIpoContacto
        {
            get { return auxIdTIpoContacto; }
            set { auxIdTIpoContacto = value; }
        }

        public string AuxDescripcion
        {
            get { return auxDescripcion; }
            set { auxDescripcion = value; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_emp");
            oArreglo.Add("@id_tipo_contacto");
            oArreglo.Add("@descripcion");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_tipo_contacto1");
            oArreglo.Add("@descripcion1");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_emp");
            oArreglo.Add("@id_tipo_contacto");
            oArreglo.Add("@descripcion");

            return oArreglo;
        }

        private ArrayList oArregloContactosEmpleado()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idEmpleado);
            oArreglo.Add(idTipoContacto);
            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloContactosEmpleadoModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(auxIdTIpoContacto);  
            oArreglo.Add(auxDescripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionContactosPorEmpleado()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idEmpleado);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            //Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Contactos_Empleado", "id_emp,id_tipo_contacto,descripcion", oArregloContactosEmpleado());
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Contactos_Empleado", oArregloParametrosInsertar(), oArregloContactosEmpleado());
        }

        public void Modificar()
        {
            //Program.oStoredProcedures.SP_Modificar("sp_U_Contactos_Empleado", "id_tipo_contacto1,descripcion1", "id_emp,id_tipo_contacto,descripcion", oArregloContactosEmpleadoModificar(), oArregloContactosEmpleado());
            Program.oStoredProcedures.SP_Modificar("sp_U_Contactos_Empleado", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloContactosEmpleadoModificar(), oArregloContactosEmpleado());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Contactos_Empleado", "id_emp,id_tipo_contacto,descripcion", oArregloContactosEmpleado());
        }

        public SqlDataReader Consultar()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Contactos_Empleado", "id_emp", oArregloCondicionContactosPorEmpleado());
        }

        #endregion
    }
}
