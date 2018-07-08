using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CPermisosEspeciales
    {
        #region Variables

        string rol = "";
        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        string idMenu = "";
        public string IdMenu
        {
            get { return idMenu; }
            set { idMenu = value; }
        }

        bool agregar = false;
        public bool Agregar
        {
            get { return agregar; }
            set { agregar = value; }
        }

        bool modificar = false;
        public bool Modificar
        {
            get { return modificar; }
            set { modificar = value; }
        }

        bool eliminar = false;
        public bool Eliminar
        {
            get { return eliminar; }
            set { eliminar = value; }
        }

        bool solicitudAdmin = false;
        public bool SolicitudAdmin
        {
            get { return solicitudAdmin; }
            set { solicitudAdmin = value; }
        }

        bool permisoHistoriaClinica = false;
        public bool PermisoHistoriaClinica
        {
            get { return permisoHistoriaClinica; }
            set { permisoHistoriaClinica = value; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@rol");
            oArreglo.Add("@idMenu");
            oArreglo.Add("@agregar");
            oArreglo.Add("@modificar");
            oArreglo.Add("@eliminar");
            oArreglo.Add("@solicitud_admin");
            oArreglo.Add("@permiso_historia_clinica");

            return oArreglo;
        }

        private ArrayList oArregloPermisosEspeciales()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(rol);
            oArreglo.Add(idMenu);
            oArreglo.Add(agregar);
            oArreglo.Add(modificar);
            oArreglo.Add(eliminar);
            oArreglo.Add(solicitudAdmin);
            oArreglo.Add(permisoHistoriaClinica);

            return oArreglo;
        }

        private ArrayList oArregloCondicion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(rol);
            oArreglo.Add(idMenu);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Permisos_Especiales", oArregloParametrosInsertar(), oArregloPermisosEspeciales());
        }

        public void Eliminar_Metodo()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Permisos_Especiales", "rol,idMenu", oArregloCondicion());
        }

        #endregion

        #region Lógica

        public ArrayList LeePermisos(string pRol, string pIdMenu)
        {
            ArrayList oArreglo = new ArrayList();
            oArreglo.Add(false);
            oArreglo.Add(false);
            oArreglo.Add(false);
            oArreglo.Add(false);
            oArreglo.Add(false);

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select * from Permisos_Especiales where rol = '" + pRol + "' and idMenu = '" + pIdMenu.Trim() + "'", "Permisos_Especiales");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oArreglo.Clear();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        oArreglo.Add(Convert.ToBoolean(dr[2]));
                        oArreglo.Add(Convert.ToBoolean(dr[3]));
                        oArreglo.Add(Convert.ToBoolean(dr[4]));
                        oArreglo.Add(Convert.ToBoolean(dr[5]));
                        oArreglo.Add(Convert.ToBoolean(dr[6]));
                    }
                }
                ds.Dispose();
            }

            return oArreglo;
        }

        #endregion
    }
}