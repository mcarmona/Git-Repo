using System;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using G_Clinic.Miscelaneos_y_Recursos;
using G_Clinic.Properties;

namespace G_Clinic
{
    class Comprobaciones
    {
        public static int Resultado = 0;//1 = Menor, 2 = Mayor, 3 = Igual

        String Tabla1 = "";
        String Tabla2 = "";
        String Campo1 = "";
        String Campo2 = "";
        String Condicion = "";

        double montoUtilizado = 0;//Este monto determina cuanto se ha utilizado del monto a favor disponible en otras facturas

        public string DevuelveFormatoFechaSql(DateTime Fecha)
        {
            string FormatoFechaSql = Fecha.Year.ToString() + "/" + Fecha.Day.ToString() + "/" + Fecha.Month.ToString() + " " +
                              Fecha.Hour.ToString() + ":" + Fecha.Minute.ToString() + ":" + Fecha.Second.ToString() + "." +
                              Fecha.Millisecond.ToString();

            return FormatoFechaSql;
        }

        public void Compara_Enteros_2_Tablas(String pCampo1, String pCampo2, String pTabla1, String pTabla2, String pCondicion)
        {
            Tabla1 = pTabla1;
            Tabla2 = pTabla2;
            Campo1 = pCampo1;
            Campo2 = pCampo2;
            Condicion = pCondicion;

            StringBuilder Sql = new StringBuilder("");
            SqlDataReader dr;

            Sql.Append("Select a." + Campo1 + ", b." + Campo2);
            Sql.Append(" From " + Tabla1 + " a, " + Tabla2 + " b");
            Sql.Append(" Where " + Condicion);

            dr = Program.oPersistencia.ejecutarConsultaSQL(Sql.ToString());

            // Hubo error ?
            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion);
                return;
            }

            while (dr.Read())
            {
                if (Convert.ToInt32(dr[0]) < Convert.ToInt32(dr[1]))
                {
                    Resultado = 1;
                }
                else if (Convert.ToInt32(dr[0]) > Convert.ToInt32(dr[1]))
                {
                    Resultado = 2;
                }
                else if (Convert.ToInt32(dr[0]) == Convert.ToInt32(dr[1]))
                {
                    Resultado = 3;
                }
            }

            //  Cerrar el DataReader
            dr.Dispose();
        }

        public void Guardar(String pCampos, String pTabla)
        {
            Tabla1 = pTabla;
            Campo1 = pCampos;

            StringBuilder Sql = new StringBuilder("");

            Sql.Append("Insert into " + Tabla1 + " values (" + Campo1 + ")");

            Program.oPersistencia.ejecutarSQLTransaccion(Sql.ToString());

            // Hubo error ?
            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion);
                return;
            }
        }

        public void Modificar(String pCampos, String pTabla, String pCondicion)
        {
            Tabla1 = pTabla;
            Campo1 = pCampos;
            Condicion = pCondicion;

            StringBuilder Sql = new StringBuilder("");

            Sql.Append("Update " + Tabla1 + " set " + Campo1);
            if (Condicion != "")
            {
                Sql.Append(" where " + Condicion);
            }

            Program.oPersistencia.ejecutarSQLTransaccion(Sql.ToString());

            // Hubo error ?
            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion);
                return;
            }
        }

        public void Borrar(String pTabla, String pCondicion)
        {
            Tabla1 = pTabla;
            Condicion = pCondicion;

            StringBuilder Sql = new StringBuilder("");

            Sql.Append("Delete " + Tabla1);

            if (Condicion != "")
                Sql.Append(" where " + Condicion);

            Program.oPersistencia.ejecutarSQLTransaccion(Sql.ToString());

            // Hubo error ?
            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion);
                return;
            }
        }

        public double MontoUtilizado
        {
            set { montoUtilizado = value; }
            get { return montoUtilizado; }
        }

        /// <summary>
        /// Verifica si hay montos a favor generados por una factura que están siendo utilizados por otra factura
        /// </summary>
        /// <param name="pIdVenta"></param>
        /// <returns></returns>
        public bool VerificaMontosFavorGeneradosUtilizados(string pIdVenta)
        {
            bool respuesta = false;
            montoUtilizado = 0;

            StringBuilder sql = new StringBuilder("");

            sql.Append("Select id_monto from Montos_Favor_Articulos_Devueltos where id_venta = " + pIdVenta.Trim());

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(sql.ToString(), "Montos_Favor_Articulos_Devueltos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sql.Remove(0, sql.Length);
                    sql.Append("Select * from Facturas_Por_Montos_Favor_Ventas where id_monto = " + dr[0].ToString().Trim());

                    DataSet ds2 = Program.oPersistencia.ejecutarSQLListas(sql.ToString(), "Facturas_Por_Montos_Favor_Ventas");

                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        respuesta = true;

                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            montoUtilizado += Convert.ToDouble(dr2[2]);
                        }
                    }
                    ds2.Dispose();
                }
            }
            ds.Dispose();

            return respuesta;
        }

        /// <summary>
        /// Este método elimina las comillas simples de una sentencia SQL y las transforma, en este caso las duplica ' => '', de esta forma al
        /// enviar la sentencia a SQL no habrá problemas de este tipo
        /// </summary>
        /// <param name="pCadena">Recibe la cadena a convertir</param>
        /// <returns>Retorna la cadena correcta</returns>
        public string DevuelveCadenaCorrectaParaSentenciaSQL(string pCadena)
        {
            string cadenaCorrecta = "";

            if (pCadena.Trim().Contains("'") == true)
                cadenaCorrecta = pCadena.Replace("'", "''");
            else
                cadenaCorrecta = pCadena.Trim();

            return cadenaCorrecta;
        }

        public void copyDirectory(string Src, string Dst, ToolStripLabel oLabel, ProgressBar oBar)
        {
            oLabel.Text = "Generando folders...";            

            if (oBar.Value == oBar.Maximum)
                oBar.Value = 0;

            oBar.Value++;

            String[] Files;

            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst)) 
                Directory.CreateDirectory(Dst);
            Files = Directory.GetFileSystemEntries(Src);

            foreach (string Element in Files)
            {
                // Sub directories
                if (Directory.Exists(Element))
                {
                    copyDirectory(Element, Dst + Path.GetFileName(Element), oLabel, oBar);
                    Application.DoEvents();
                }// Files in directory
                else
                {
                    File.Copy(Element, Dst + Path.GetFileName(Element), true);
                    oLabel.Text = "Copiando archivos...";                    
                    oBar.Step++;

                    if (oBar.Value == oBar.Maximum)
                        oBar.Value = 0;
                }
            }

            oBar.Value = 98;

            oLabel.Text = "Backup creado satisfactoriamente!!";            
        }

        public void BackupDBLogins(string destinationFolder)
        {
            SqlConnection SqlCN = null;
            SqlDataReader oReader;
            DataTable dt = new DataTable();

            string oAppConnectionString = Settings.Default.GClinicConnectionString.Trim();// ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            SqlConnectionStringBuilder ayudante = new SqlConnectionStringBuilder();
            ayudante.ConnectionString = oAppConnectionString;
            ayudante.UserID = Program.oUsuario;
            ayudante.Password = Program.coClaveUsuario;
            ayudante.DataSource = Settings.Default.Server;
            ayudante.InitialCatalog = "master";

            SqlCN = new SqlConnection(ayudante.ToString());
            SqlCN.Open();

            SqlCommand oCommand = new SqlCommand();
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "sp_help_revlogin";
            oCommand.Connection = SqlCN;

            if (Program.oPersistencia.IsError == false)
            {
                oReader = Program.oPersistencia.ejecutarConsultaSQL(oCommand);
                dt.Load(oReader);

                StringBuilder oScript = new StringBuilder("");

                foreach (DataRow dr in dt.Rows)
                    oScript.AppendLine(dr[0].ToString());

                File.WriteAllText(destinationFolder, oScript.ToString());
                
                SqlCN.Close();
                SqlCN.Dispose();

                oReader.Close();
                oReader.Dispose();

                dt.Dispose();
                dt.Clear();
            }

            oCommand.Dispose();
        }
    }
}
