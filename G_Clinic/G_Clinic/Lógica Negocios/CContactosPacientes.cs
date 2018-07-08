using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CContactosPacientes
    {
        #region Variables

        string numExpediente = "";
        int idTipoContacto = 0;
        string descripcion = "";

        string auxIdTIpoContacto = "";
        string auxDescripcion = "";

        #endregion

        #region Encapsulaciones

        public string NumExpediente
        {
            get { return numExpediente; }
            set { numExpediente = value; }
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

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();
                                      
            oArreglo.Add("@id_tipo_contacto1");
            oArreglo.Add("@descripcion1");

            return oArreglo;
        }

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@num_expediente");
            oArreglo.Add("@id_tipo_contacto");
            oArreglo.Add("@descripcion");

            return oArreglo;
        }

        private ArrayList oArregloContactosPaciente()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(numExpediente);
            oArreglo.Add(idTipoContacto);
            oArreglo.Add(descripcion);

            return oArreglo;
        }

        private ArrayList oArregloContactosPacienteModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(auxIdTIpoContacto);
            oArreglo.Add(auxDescripcion);

            return oArreglo;
        }

        private ArrayList oArregloCondicionContactosPorPaciente()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(numExpediente);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            //Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Contactos_Paciente", "num_expediente,id_tipo_contacto,descripcion", oArregloContactosPaciente());
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Contactos_Paciente", oArregloParametrosInsertar(), oArregloContactosPaciente());
        }

        public void Modificar()
        {
            //Program.oStoredProcedures.SP_Modificar("sp_U_Contactos_Paciente", "id_tipo_contacto1,descripcion1", "num_expediente,id_tipo_contacto,descripcion", oArregloContactosPacienteModificar(), oArregloContactosPaciente());
            Program.oStoredProcedures.SP_Modificar("sp_U_Contactos_Paciente", oArregloParametrosModificar(), oArregloParametrosInsertar(), oArregloContactosPacienteModificar(), oArregloContactosPaciente());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Contactos_Paciente", "num_expediente,id_tipo_contacto,descripcion", oArregloContactosPaciente());
        }

        public SqlDataReader Consultar()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Contactos_Paciente", "num_expediente", oArregloCondicionContactosPorPaciente());
        }

        /// <summary>
        /// Dicho método extrae únicamente el número de celular de paciente y el Tel.Habitación, debido a este método los tipos de contacto
        /// tales como: Celular y Tel.Habitación entre otros fueron restringidos contra su modificación o eliminación, es decir que quedaron
        /// estáticos dentro del mantenimiento de Tipo de Contactos.
        /// los  Estos datos son únicamente para la impresión de recetas u otros documentos que los requieran
        /// </summary>
        /// <param name="pNumExpediente">Recibe el número de expediente sobre el cual se realizará la consulta de los contactos</param>
        /// <returns>Devuelve un arreglo con los valores de los contactos correspondientes a Celular y Tel.Habitación</returns>
        public ArrayList LeerContactosPaciente_ImpresionConsultaReceta(string pNumExpediente)
        {
            ArrayList oContactos = new ArrayList();
 
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Contactos_Paciente '" + pNumExpediente + "'", "Contactos_Paciente");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataSet ds2 = Program.oPersistencia.ejecutarSQLListas("Select descripcion from Tipo_Contactos where id_tipo_contacto = " + dr[0].ToString().Trim(), "Tipo_Contactos");

                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    if (dr2[0].ToString().Trim() == "Celular" || dr2[0].ToString().Trim() == "Tel.Habitación")
                        oContactos.Add(dr[2].ToString().Trim()); 
                }
            }
            ds.Dispose();

            return oContactos;
        }

        #endregion

    }
}
