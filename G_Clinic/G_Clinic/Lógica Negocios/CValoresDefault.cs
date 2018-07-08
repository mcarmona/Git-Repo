using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CValoresDefault
    {
        #region Instancias

        CMetodosAnticonceptivos oCMetodosAnticonceptivos = new CMetodosAnticonceptivos();
        CTiposContacto oCTiposContacto = new CTiposContacto();
        CCategoriasEmpleado oCCategoriasEmpleado = new CCategoriasEmpleado();

        #endregion

        /// <summary>
        /// Establece los valores que son necesarios para el funcionamiento del sistema sin que el usuario tenga control alguno sobre ellos
        /// </summary>
        /// <returns></returns>
        public void EstableceValoresDefault()
        {
            string sqlConsulta = "";
            DataSet ds = new DataSet();

            #region Métodos Anticonceptivos

            sqlConsulta = "Select * from Metodos_Anticonceptivos where descripcion = 'Ninguno'";

            ds = Program.oPersistencia.ejecutarSQLListas(sqlConsulta, "Metodos_Anticonceptivos");

            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                oCMetodosAnticonceptivos.Descripcion = "Ninguno";
                oCMetodosAnticonceptivos.Insertar();
            }
            ds = null;

            #endregion

            #region Tipos de Contacto

            //Tipos de Contacto, valores default = Celular, Tel.Habitación, Email
            sqlConsulta = "Select * from Tipo_Contactos where descripcion = 'Celular'";
            ds = Program.oPersistencia.ejecutarSQLListas(sqlConsulta, "Tipo_Contactos");

            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                oCTiposContacto.Descripcion = "Celular";
                oCTiposContacto.Insertar();
            }
            ds = null;

            sqlConsulta = "Select * from Tipo_Contactos where descripcion = 'Tel.Habitación'";
            ds = Program.oPersistencia.ejecutarSQLListas(sqlConsulta, "Tipo_Contactos");

            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                oCTiposContacto.Descripcion = "Tel.Habitación";
                oCTiposContacto.Insertar();
            }
            ds = null;

            sqlConsulta = "Select * from Tipo_Contactos where descripcion = 'Email'";
            ds = Program.oPersistencia.ejecutarSQLListas(sqlConsulta, "Tipo_Contactos");

            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                oCTiposContacto.Descripcion = "Email";
                oCTiposContacto.Insertar();
            }
            ds = null;

            #endregion

            #region Categorías de Empleado

            sqlConsulta = "Select * from Categorias_Empleado where descripcion = 'Médico'";

            ds = Program.oPersistencia.ejecutarSQLListas(sqlConsulta, "Categorias_Empleado");

            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                oCCategoriasEmpleado.Descripcion = "Médico";
                oCCategoriasEmpleado.Insertar();
            }

            #endregion

            ds.Dispose();
        }
    }
}
