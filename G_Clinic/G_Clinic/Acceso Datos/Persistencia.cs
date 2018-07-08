using System;
using System.Data;
using System.Data.SqlClient;
using G_Clinic.Properties;
//using System.Management.Instrumentation; 

namespace G_Clinic
{
    class Persistencia
    {
        // Variables de instancia
        private Boolean isError;
        private String errorDescripcion;
        public SqlConnection conexion;

        //static Boolean activaInstancia = false;
        static int instancias = 0;

        // Constructor
        public Persistencia(String pUsuario, String pContrasena, String pServidor)
        {
            string oAppConnectionString = Settings.Default.GClinicConnectionString.Trim();//ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            SqlConnectionStringBuilder ayudante = new SqlConnectionStringBuilder();
            ayudante.ConnectionString = oAppConnectionString;
            ayudante.UserID = pUsuario;
            ayudante.Password = pContrasena;
            ayudante.DataSource = Settings.Default.Server.Trim() + Settings.Default.Port.Trim();

            //ayudante.DataSource = "Data Source=MANUEL\\MSSQLSERVER2012;Initial Catalog=G_Clinic;User ID=ken;Password=kenneth;";
            conexion = new SqlConnection(ayudante.ToString());

            instancias += 1;
            
            // no puede haber + de una instancia de la clase
            if (instancias > 1)
                return;

            try
            {
                IsError = false;
                conexion.Open();
                instancias = 0;
                Program.oMDI.toolStripStatusLabel3.Image = recursos.Connected_Yes;
                Program.oMDI.toolStripStatusLabel3.Text = "Estado: Conectado   ";
            }
            catch (Exception error)
            {
                IsError = true;
                ErrorDescripcion = "Error de Conexión \n";
                ErrorDescripcion += error.Message;
                instancias = 0;
                Program.oMDI.toolStripStatusLabel3.Image = recursos.not_connected;
                Program.oMDI.toolStripStatusLabel3.Text = "Estado: Desconectado   ";
            }
        }

        // Indica el estado de la persistencia
        public Boolean estado()
        {
            String mensaje = "";

            // estado dela conexión
            switch (conexion.State)
            {
                case System.Data.ConnectionState.Broken: mensaje = "Quebrada";
                    break;
                case System.Data.ConnectionState.Closed: mensaje = "Cerrada";
                    break;
                case System.Data.ConnectionState.Connecting: mensaje = "Conectandose";
                    break;
                case System.Data.ConnectionState.Executing: mensaje = "Ejecutando";
                    break;
                case System.Data.ConnectionState.Fetching: mensaje = "Extrayendo";
                    break;
                case System.Data.ConnectionState.Open: mensaje = "Abierta";
                    break;
            }

            // cargar la propiedad con el estado de la conexion
            ErrorDescripcion = mensaje;


            if ((conexion.State == ConnectionState.Open) ||
                  (conexion.State == ConnectionState.Executing) ||
                  (conexion.State == ConnectionState.Fetching))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // destructor
        ~Persistencia()
        {
            try
            {
                IsError = false;
                conexion.Close();
            }
            catch (Exception error)
            {
                IsError = true;
                ErrorDescripcion = "Error de Desconexión \n";
                ErrorDescripcion += error.Message;
            }
        }

        // Método para manipular DQL (Select)
        public SqlDataReader ejecutarConsultaSQL(String pSql)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                //conexion.Open();
                cmd = new SqlCommand(pSql, conexion);

                // capturar la excepción
                try
                {
                    IsError = false;
                    dr = cmd.ExecuteReader();
                }

                catch (SqlException errorSql)
                {
                    IsError = true;
                    ErrorDescripcion = "Error en ejecutarSQL \n";
                    ErrorDescripcion += errorSql.Message;
                }
                catch (Exception error)
                {
                    IsError = true;
                    ErrorDescripcion = "Error en ejecutarConsultaSQL \n";
                    ErrorDescripcion += error.Message;
                }
                return dr;
            }
            finally 
            {
                //if (cmd != null)
                //    cmd.Dispose();

                //dr cannot be disposed 'cause after the value is returned a while Read is being applied...
            }
        }

        // Método para manipular DQL (Select)
        public SqlDataReader ejecutarConsultaSQL(SqlCommand oSqlCommand)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr = null;

            try
            {
                //conexion.Open();
                cmd = oSqlCommand;//new SqlCommand(pSql, conexion);

                // capturar la excepción
                try
                {
                    IsError = false;
                    dr = cmd.ExecuteReader();
                }

                catch (SqlException errorSql)
                {
                    IsError = true;
                    ErrorDescripcion = "Error en ejecutarSQL \n";
                    ErrorDescripcion += errorSql.Message;
                }
                catch (Exception error)
                {
                    IsError = true;
                    ErrorDescripcion = "Error en ejecutarConsultaSQL \n";
                    ErrorDescripcion += error.Message;
                }
                return dr;
            }
            finally
            {
                //if (cmd != null)
                //    cmd.Dispose();

                //if (dr != null)
                //    dr.Dispose();
            }
        }

        // Método para manipular DQL (Select) Para busquedas escalares SUM(), Count(), Etc.
        public String ejecutarScalarSQL(String pSql, String pTipo)
        {

            SqlCommand cmd;
            Int32 dr = 0;
            float df = 0;
            String valorRetorno = "";

            cmd = new SqlCommand(pSql, conexion);

            // capturar la excepción
            try
            {
                IsError = false;

                switch (pTipo)
                {
                    case "I":
                        dr = (Int32)cmd.ExecuteScalar();
                        break;
                    case "F":
                        df = (float)cmd.ExecuteScalar();
                        break;
                    case "S":
                        valorRetorno = (string)cmd.ExecuteScalar();
                        break;
                    default:
                        break;
                }

                //if (pTipo == "I")
                //    dr = (Int32)cmd.ExecuteScalar();
                //if (pTipo == "F")
                //    df = (float)cmd.ExecuteScalar();
            }

            catch (SqlException errorSql)
            {
                IsError = true;
                ErrorDescripcion = "Error en ejecutarSQL \n";
                ErrorDescripcion += errorSql.Message;
            }
            catch (Exception error)
            {
                IsError = true;
                ErrorDescripcion = "Error en ejecutarConsultaSQL \n";
                ErrorDescripcion += error.Message;
            }

            if (pTipo == "I")
                valorRetorno = dr.ToString();
            if (pTipo == "F")
                valorRetorno = df.ToString();
            
            cmd.Dispose();

            return valorRetorno;
        }

        //Método para manipular DQL (Select) Exclusivo para carga de listas y combos
        public DataSet ejecutarSQLListas(SqlCommand pSqlCommand)
        {
            SqlDataAdapter vDatos = new SqlDataAdapter(pSqlCommand);
            DataSet dsTabla = new DataSet();

            try
            {
                // capturar la excepción
                try
                {
                    IsError = false;
                    vDatos.Fill(dsTabla);
                }

                catch (SqlException errorSql)
                {
                    IsError = true;
                    ErrorDescripcion = "Error en ejecutarSQL \n";
                    ErrorDescripcion += errorSql.Message;
                }
                catch (Exception error)
                {
                    IsError = true;
                    ErrorDescripcion = "Error en ejecutarConsultaSQL \n";
                    ErrorDescripcion += error.Message;
                }

                return dsTabla;
            }
            finally 
            {
                if (vDatos != null)
                    vDatos.Dispose();

                if (dsTabla != null)
                    dsTabla.Dispose();
            }
        }

        // Método para manipular DQL (Select) Exclusivo para carga de listas y combos
        public DataSet ejecutarSQLListas(String pSql, String pnTabla)
        {
            SqlDataAdapter vDatos = new SqlDataAdapter(pSql, conexion);
            DataSet dsTabla = new DataSet();

            try
            {
                // capturar la excepción
                try
                {
                    IsError = false;
                    vDatos.Fill(dsTabla, pnTabla);
                }

                catch (SqlException errorSql)
                {
                    IsError = true;
                    ErrorDescripcion = "Error en ejecutarSQL \n";
                    ErrorDescripcion += errorSql.Message;
                }
                catch (Exception error)
                {
                    IsError = true;
                    ErrorDescripcion = "Error en ejecutarConsultaSQL \n";
                    ErrorDescripcion += error.Message;
                }

                return dsTabla;
            }
            finally
            {
                if (vDatos != null)
                    vDatos.Dispose();

                if (dsTabla != null)
                    dsTabla.Dispose();
            }
        }

        // Método para manipular DML (Insert, Update, Delete)
        public void ejecutarSQL(SqlCommand oSqlCommand)//public void ejecutarSQL(String pSql)
        {
            // Definicion de Command
            //SqlCommand cmd = null;

            try
            {
                //conexion.Open();
                IsError = false;
                //cmd = new SqlCommand(pSql.ToString(), conexion);
                //cmd.ExecuteNonQuery();
                oSqlCommand.ExecuteNonQuery();
                //conexion.Close();
            }
            catch (SqlException errorSql)
            {
                IsError = true;
                ErrorDescripcion = "Error en ejecutarSQL \n";
                ErrorDescripcion += errorSql.Message;
            }
            catch (Exception error)
            {
                IsError = true;
                ErrorDescripcion = "Error en ejecutarSQL \n";
                ErrorDescripcion += error.Message;
            }
        }

        // Método para manipular DML (Insert, Update, Delete)
        public void ejecutarSQL(String pSql)
        {

            // Definicion de Command
            SqlCommand cmd = null;

            try
            {
                IsError = false;
                cmd = new SqlCommand(pSql.ToString(), conexion);
                cmd.ExecuteNonQuery();

            }
            catch (SqlException errorSql)
            {
                IsError = true;
                ErrorDescripcion = "Error en ejecutarSQL \n";
                ErrorDescripcion += errorSql.Message;
            }
            catch (Exception error)
            {
                IsError = true;
                ErrorDescripcion = "Error en ejecutarSQL \n";
                ErrorDescripcion += error.Message;
            }

            //cmd.Dispose();
        }

        public void ejecutarSQLTransaccion(String pSql)
        {
            // Definicion de Command
            SqlCommand cmd = null;
            SqlTransaction Transaccion;
            IsError = false;

            // Inicio de la transaccion
            Transaccion = conexion.BeginTransaction();

            try
            {
                cmd = new SqlCommand(pSql.ToString(), conexion);
                cmd.Transaction = Transaccion;
                cmd.Connection = conexion;
                cmd.ExecuteNonQuery();
                Transaccion.Commit();
            }
            catch (SqlException errorSql)
            {
                IsError = true;
                ErrorDescripcion = "Error en ejecutarSQL \n";
                ErrorDescripcion += errorSql.Message;
                Transaccion.Rollback();
            }
            catch (Exception error)
            {
                IsError = true;
                ErrorDescripcion = "Error en ejecutarSQL \n";
                ErrorDescripcion += error.Message;
                Transaccion.Rollback();
            }

            cmd.Dispose();
            Transaccion.Dispose();
        }

        // Set & Gets
        public Boolean IsError
        {
            set { isError = value; }
            get { return isError; }
        }

        public String ErrorDescripcion
        {
            set { errorDescripcion = value; }
            get { return errorDescripcion; }
        }
    }
}
