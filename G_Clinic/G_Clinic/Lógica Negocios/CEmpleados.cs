using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CEmpleados
    {
        #region Variables

        int idEmp = 0;
        string cedula = "";
        string tipoCedula = "";
        string nombre = "";
        DateTime fechaNacimiento;
        string sexo = "";
        string direccion = "";
        string estadoCivil = "";
        string estado = "";
        string categoriaEmp = "";
        string codigoColegiado = "";
        byte[] bFoto;
        byte[] infoImagen;//Variable opcional para no tener que leer la imagen desde el disco duro, sino desde la Bd en caso de que no se modifique o elimine la imagen

        #endregion

        #region Encapsulaciones de Campos

        public int IDEmp
        {
            get { return idEmp; }
            set { idEmp = value; }
        }

        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        public string TipoCedula
        {
            get { return tipoCedula; }
            set { tipoCedula = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string CategoriaEmp
        {
            get { return categoriaEmp; }
            set { categoriaEmp = value; }
        }

        public byte[] BFoto
        {
            get { return bFoto; }
            set { bFoto = value; }
        }

        public byte[] InfoImagen
        {
            get { return infoImagen; }
            set { infoImagen = value; }
        }

        public string CodigoColegiado
        {
            get { return codigoColegiado; }
            set { codigoColegiado = value; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@cedula");
            oArreglo.Add("@tipo_ced");
            oArreglo.Add("@nombre");
            oArreglo.Add("@fec_nacimiento");
            oArreglo.Add("@sexo_emp");
            oArreglo.Add("@direc_emp");
            oArreglo.Add("@estado_civil");
            oArreglo.Add("@estado");
            oArreglo.Add("@foto");
            oArreglo.Add("@id_categoria_emp");
            oArreglo.Add("@codigo_colegiado");

            return oArreglo;
        }

        private ArrayList oArregloParametrosInsertarNoImage()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@cedula");
            oArreglo.Add("@tipo_ced");
            oArreglo.Add("@nombre");
            oArreglo.Add("@fec_nacimiento");
            oArreglo.Add("@sexo_emp");
            oArreglo.Add("@direc_emp");
            oArreglo.Add("@estado_civil");
            oArreglo.Add("@estado");
            oArreglo.Add("@id_categoria_emp");
            oArreglo.Add("@codigo_colegiado");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@cedula");
            oArreglo.Add("@tipo_ced");
            oArreglo.Add("@nombre");
            oArreglo.Add("@fec_nacimiento");
            oArreglo.Add("@sexo_emp");
            oArreglo.Add("@direc_emp");
            oArreglo.Add("@estado_civil");
            oArreglo.Add("@estado");
            oArreglo.Add("@foto");
            oArreglo.Add("@id_categoria_emp");
            oArreglo.Add("@codigo_colegiado");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificarNoImage()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@cedula");
            oArreglo.Add("@tipo_ced");
            oArreglo.Add("@nombre");
            oArreglo.Add("@fec_nacimiento");
            oArreglo.Add("@sexo_emp");
            oArreglo.Add("@direc_emp");
            oArreglo.Add("@estado_civil");
            oArreglo.Add("@estado");
            oArreglo.Add("@id_categoria_emp");
            oArreglo.Add("@codigo_colegiado");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_emp");

            return oArreglo;
        }

        private ArrayList oArregloEmpleados()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(cedula);
            oArreglo.Add(tipoCedula);
            oArreglo.Add(nombre);
            oArreglo.Add(fechaNacimiento);
            oArreglo.Add(sexo);
            oArreglo.Add(direccion);
            oArreglo.Add(estadoCivil);
            oArreglo.Add(estado);
            if (infoImagen != null)
                oArreglo.Add(infoImagen);
            oArreglo.Add(categoriaEmp);
            oArreglo.Add(codigoColegiado);   

            return oArreglo;
        }

        private ArrayList oArregloCondicion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idEmp);

            return oArreglo;
        }

        private ArrayList oArregloCondicionConsulta()
        {
            ArrayList oArreglo = new ArrayList();

            if (idEmp != 0)
                oArreglo.Add(idEmp);

            if (cedula != null)
                oArreglo.Add(cedula);

            if (tipoCedula != null)
                oArreglo.Add(tipoCedula);

            if (nombre != null)
                oArreglo.Add(nombre);

            if (sexo != null)
                oArreglo.Add(sexo);

            if (estadoCivil != null)
                oArreglo.Add(estadoCivil);

            if (categoriaEmp != null)
                oArreglo.Add(categoriaEmp);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            //Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Empleados", "cedula,tipo_ced,nombre,fec_nacimiento,sexo_emp,direc_emp,estado_civil,estado,foto,categoria_emp", oArregloEmpleados());
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Empleados", oArregloParametrosInsertar(), oArregloEmpleados());
        }

        public void Insertar_NoImage()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Empleados_NoImage", oArregloParametrosInsertarNoImage(), oArregloEmpleados());
        }

        public void Modificar()
        {
            //Program.oStoredProcedures.SP_Modificar("sp_U_Empleados", "cedula,tipo_ced,nombre,fec_nacimiento,sexo_emp,direc_emp,estado_civil,estado,foto,categoria_emp",
            //                                       "id_emp", oArregloEmpleados(), oArregloCondicion());
            Program.oStoredProcedures.SP_Modificar("sp_U_Empleados", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloEmpleados(), oArregloCondicion());
        }

        public void Modificar_NoImage()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Empleados_NoImage", oArregloParametrosModificarNoImage(), oArregloParametrosCondicionModificar(), oArregloEmpleados(), oArregloCondicion());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Empleados");
        }

        public SqlDataReader ConsultarConParametros(string parametrosCondicion)
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Empleados_Param", parametrosCondicion, oArregloCondicionConsulta());
        }

        public string ObtieneCodigoColegiado(string pIdUsuario)
        {
            string _idEmp = "";
            string codColegiado = "";

            StringBuilder oSql = new StringBuilder("");

            oSql.Append("Select id_emp from Usuario_Empleado where id_usuario = " + pIdUsuario.Trim());

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(oSql.ToString(), "Usuario_Empleado");

            foreach (DataRow dr in ds.Tables[0].Rows)
                _idEmp = dr[0].ToString();

            ds = null;

            if (_idEmp != "")
            {
                oSql.Remove(0, oSql.Length);
                oSql.Append("Select codigo_colegiado from Empleados where id_emp = " + _idEmp.Trim());

                ds = Program.oPersistencia.ejecutarSQLListas(oSql.ToString(), "Empleados");

                foreach (DataRow dr in ds.Tables[0].Rows)
                    codColegiado = dr[0].ToString();
            }

            ds.Dispose();

            return codColegiado;
        }

        public string ObtieneNombreEmpleado(string pIdUsuario)
        {
            string _idEmp = "";
            string nomEmp = "";

            StringBuilder oSql = new StringBuilder("");

            oSql.Append("Select id_emp from Usuario_Empleado where id_usuario = " + pIdUsuario.Trim());

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(oSql.ToString(), "Usuario_Empleado");

            foreach (DataRow dr in ds.Tables[0].Rows)
                _idEmp = dr[0].ToString();

            ds = null;

            if (_idEmp != "")
            {
                oSql.Remove(0, oSql.Length);
                oSql.Append("Select nombre from Empleados where id_emp = " + _idEmp.Trim());

                ds = Program.oPersistencia.ejecutarSQLListas(oSql.ToString(), "Empleados");

                foreach (DataRow dr in ds.Tables[0].Rows)
                    nomEmp = dr[0].ToString();
            }

            ds.Dispose();

            return nomEmp;
        }

        #endregion
    }
}
