using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CEmpresa
    {
        #region Variables

        string idEmpresa = "";
        string nombreEmpresa = "";
        string paisCiudad = "";
        string especialidad = "";
        string serviciosOfrecidos = "";
        string cedJuridica = "";
        string direccion = "";
        string telefono = "";
        string paginaWeb = "";
        string email = "";
        string logo = "";

        #endregion

        #region Encapsulaciones de campos

        public string IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }

        public string NombreEmpresa
        {
            get { return nombreEmpresa; }
            set { nombreEmpresa = value; }
        }

        public string PaisCiudad
        {
            get { return paisCiudad; }
            set { paisCiudad = value; }
        }

        public string Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        public string ServiciosOfrecidos
        {
            get { return serviciosOfrecidos; }
            set { serviciosOfrecidos = value; }
        }

        public string CedJuridica
        {
            get { return cedJuridica; }
            set { cedJuridica = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string PaginaWeb
        {
            get { return paginaWeb; }
            set { paginaWeb = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }

        #endregion

        public DataSet DatosEmpresa()
        {
            DataSet ds = new DataSet();

            ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Empresas", "Empresas");

            return ds;
        }

        /// <summary>
        /// Lee todos los datos ingresados en la tabla de empresas y seguidamente los asigna a las variables correspondientes a esta clase,
        /// de esta forma al invocar los datos desde otra clase podemos manipular los datos reales de la empresa
        /// </summary>
        /// <returns>retorna una variable de tipo BOOLEAN que determina si sí se encontraron datos en la tabla de Empresas o no</returns>
        public bool LeeDatosEmpresa()
        {
            bool datosEncontrados = false;

            DataSet ds = new DataSet();

            ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Empresas", "Empresas");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    idEmpresa = dr[0].ToString().Trim();
                    paisCiudad = dr[1].ToString().Trim();
                    nombreEmpresa = dr[2].ToString().Trim();
                    especialidad = dr[3].ToString().Trim();
                    serviciosOfrecidos = dr[4].ToString().Trim();
                    cedJuridica = dr[5].ToString().Trim();
                    direccion = dr[6].ToString().Trim();
                    telefono = dr[7].ToString().Trim();
                    paginaWeb = dr[8].ToString().Trim();
                    email = dr[9].ToString().Trim();
                }

                datosEncontrados = true;
            }
            else
                datosEncontrados = false;
            ds.Dispose();

            return datosEncontrados;
        }
    }
}