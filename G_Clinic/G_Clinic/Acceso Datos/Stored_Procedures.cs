using System;
using System.Collections;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    public class Stored_Procedures
    {
        String Tabla1 = "";
        String Campo1 = "";
        String Condicion = "";
        String ParametrosSQL = "";        

        public Stored_Procedures()
        {
            
        }

        #region Procedimientos antiguos para generar Stored Procedures sin que estén creados en la base de datos (INACTIVO)

        //public void SP_GuardarNuevo(string pTabla, string pCampos, ArrayList pValores)
        //{
        //    ParametrosSQL = "";
        //    ArrayList oArregloParametros = new ArrayList();
        //    Tabla1 = pTabla;
        //    Campo1 = pCampos;

        //    SqlCommand SqlCom = null;
        //    StringBuilder Sql = new StringBuilder("");

        //    Sql.Append("Insert into " + Tabla1 + "(" + pCampos + ")" + " values (");

        //    char[] oCaracterBuscado = { ',', ' ' };
        //    string[] oCadenaTemporal = pCampos.Split(oCaracterBuscado);

        //    for (int i = 0; i < oCadenaTemporal.Length; i++)
        //    {
        //        if (oCadenaTemporal[i] != String.Empty)
        //        {
        //            ParametrosSQL += "@" + oCadenaTemporal[i].Trim() + ", ";
        //            oArregloParametros.Add("@" + oCadenaTemporal[i].Trim());
        //        }
        //    }

        //    if (ParametrosSQL.EndsWith(", "))
        //        ParametrosSQL = ParametrosSQL.Substring(0, ParametrosSQL.Length - 2);

        //    Sql.Append(ParametrosSQL.Trim() + ")");

        //    SqlCom = new SqlCommand(Sql.ToString(), Program.oPersistencia.conexion);

        //    int cont = 0;

        //    foreach (string oParameter in oArregloParametros)
        //    {
        //        SqlCom.Parameters.Add(new SqlParameter(oParameter.Trim(), (object)pValores[cont]));
        //        cont++;
        //    }

        //    Program.oPersistencia.ejecutarSQL(SqlCom);

        //    if (Program.oPersistencia.IsError == true)
        //        MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");

        //    Program.oArregloGlobal.Clear();
        //}




        //public void SP_Modificar(string pTabla, string pCampos, string pCondicion, ArrayList pValores, ArrayList pValoresCondicion)
        //{
        //    ParametrosSQL = "";
        //    ArrayList oArregloParametros = new ArrayList();
        //    Tabla1 = pTabla;
        //    Campo1 = pCampos;
        //    Condicion = pCondicion;

        //    SqlCommand SqlCom = null;

        //    StringBuilder Sql = new StringBuilder("");

        //    Sql.Append("Update " + Tabla1 + " set ");// + Campo1);

        //    char[] oCaracterBuscado = { ',', ' ' };
        //    string[] oCadenaTemporal = pCampos.Split(oCaracterBuscado);

        //    for (int i = 0; i < oCadenaTemporal.Length; i++)
        //    {
        //        if (oCadenaTemporal[i] != String.Empty)
        //        {
        //            ParametrosSQL += oCadenaTemporal[i].Trim() + " = " + "@" + oCadenaTemporal[i].Trim() + ", ";
        //            oArregloParametros.Add("@" + oCadenaTemporal[i].Trim());
        //        }
        //    }

        //    if (ParametrosSQL.EndsWith(", "))
        //        ParametrosSQL = ParametrosSQL.Substring(0, ParametrosSQL.Length - 2);

        //    Sql.Append(ParametrosSQL.Trim());

        //    //Condicion
        //    ParametrosSQL = "";
        //    oCadenaTemporal = pCondicion.Split(oCaracterBuscado);
        //    ArrayList oArregloCondicion = new ArrayList();

        //    for (int i = 0; i < oCadenaTemporal.Length; i++)
        //    {
        //        if (oCadenaTemporal[i] != String.Empty)
        //        {
        //            ParametrosSQL += oCadenaTemporal[i].Trim() + " = " + "@" + oCadenaTemporal[i].Trim() + " and ";
        //            oArregloCondicion.Add("@" + oCadenaTemporal[i].Trim());
        //        }
        //    }

        //    if (ParametrosSQL.EndsWith("and "))
        //        ParametrosSQL = ParametrosSQL.Substring(0, ParametrosSQL.Length - 4);

        //    if (Condicion != "")
        //        Sql.Append(" where " + ParametrosSQL.Trim());

        //    SqlCom = new SqlCommand(Sql.ToString(), Program.oPersistencia.conexion);

        //    int cont = 0;
        //    foreach (string oParameter in oArregloParametros)
        //    {
        //        SqlCom.Parameters.Add(new SqlParameter(oParameter.Trim(), (object)pValores[cont]));
        //        cont++;
        //    }

        //    cont = 0;
        //    foreach (string oParameter in oArregloCondicion)
        //    {
        //        SqlCom.Parameters.Add(new SqlParameter(oParameter.Trim(), (object)pValoresCondicion[cont]));
        //        cont++;
        //    }

        //    Program.oPersistencia.ejecutarSQL(SqlCom);

        //    if (Program.oPersistencia.IsError == true)
        //        MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");

        //    Program.oArregloGlobal.Clear();
        //    Program.oArregloGlobalCondiciones.Clear();
        //}




        //public void SP_Eliminar(string pTabla, string pCondicion, ArrayList pValoresCondicion)
        //{
        //    ParametrosSQL = "";
        //    ArrayList oArregloParametros = new ArrayList();
        //    Tabla1 = pTabla;
        //    Condicion = pCondicion;

        //    SqlCommand SqlCom = null;

        //    StringBuilder Sql = new StringBuilder("");

        //    Sql.Append("Delete " + Tabla1);

        //    char[] oCaracterBuscado = { ',', ' ' };
        //    string[] oCadenaTemporal = pCondicion.Split(oCaracterBuscado);
        //    ArrayList oArregloCondicion = new ArrayList();

        //    for (int i = 0; i < oCadenaTemporal.Length; i++)
        //    {
        //        if (oCadenaTemporal[i] != String.Empty)
        //        {
        //            ParametrosSQL += oCadenaTemporal[i].Trim() + " = " + "@" + oCadenaTemporal[i].Trim() + " and ";
        //            oArregloCondicion.Add("@" + oCadenaTemporal[i].Trim());
        //        }
        //    }

        //    if (ParametrosSQL.EndsWith("and "))
        //        ParametrosSQL = ParametrosSQL.Substring(0, ParametrosSQL.Length - 4);

        //    if (Condicion != "")
        //        Sql.Append(" where " + ParametrosSQL.Trim());

        //    SqlCom = new SqlCommand(Sql.ToString(), Program.oPersistencia.conexion);

        //    int cont = 0;
        //    foreach (string oParameter in oArregloCondicion)
        //    {
        //        SqlCom.Parameters.Add(new SqlParameter(oParameter.Trim(), (object)pValoresCondicion[cont]));
        //        cont++;
        //    }

        //    Program.oPersistencia.ejecutarSQL(SqlCom);

        //    if (Program.oPersistencia.IsError == true)
        //        MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");

        //    Program.oArregloGlobalCondiciones.Clear();
        //}

        #endregion

        //public void SP_GuardarNuevo(string pStoreProcedureName, string pCampos, ArrayList pValores)
        //{
        //    ArrayList oArregloParametros = new ArrayList();
        //    Campo1 = pCampos;

        //    SqlCommand SqlCom = new SqlCommand(); 

        //    char[] oCaracterBuscado = { ',', ' ' };
        //    string[] oCadenaTemporal = pCampos.Split(oCaracterBuscado);

        //    for (int i = 0; i < oCadenaTemporal.Length; i++)
        //    {
        //        if (oCadenaTemporal[i] != String.Empty)
        //            oArregloParametros.Add("@" + oCadenaTemporal[i].Trim());
        //    }

        //    SqlCom.Connection = Program.oPersistencia.conexion;

        //    SqlCom.CommandType = System.Data.CommandType.StoredProcedure;
        //    SqlCom.CommandText = pStoreProcedureName.Trim();

        //    int cont = 0;
        //    foreach (string oParameter in oArregloParametros)
        //    {
        //        SqlCom.Parameters.AddWithValue(oParameter.Trim(), (object)pValores[cont]);
        //        cont++;
        //    }

        //    Program.oPersistencia.ejecutarSQL(SqlCom);

        //    if (Program.oPersistencia.IsError == true)
        //        MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");

        //    SqlCom.Dispose();
        //    Program.oArregloGlobal.Clear();
        //}

        public void SP_GuardarNuevo(string pStoreProcedureName, ArrayList oArregloParametros, ArrayList pValores)
        {
            Program.oCLogs.InitializeValues();

            Program.oCLogs.ProcName = pStoreProcedureName;
            Program.oCLogs.Action = "Insert";

            SqlCommand SqlCom = new SqlCommand();

            SqlCom.Connection = Program.oPersistencia.conexion;

            SqlCom.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCom.CommandText = pStoreProcedureName.Trim();

            int cont = 0;
            foreach (string oParameter in oArregloParametros)
            {
                SqlCom.Parameters.AddWithValue(oParameter.Trim(), (object)pValores[cont]);
                Program.oCLogs.Parameters += oParameter.Trim() + (object)pValores[cont].ToString() + "||";
                cont++;
            }

            Program.oPersistencia.ejecutarSQL(SqlCom);

            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                Program.oCLogs.ErrorMessage = Program.oPersistencia.ErrorDescripcion.Trim();
            }

            Program.oCLogs.InsertLog();

            SqlCom.Dispose();
            Program.oArregloGlobal.Clear();
        }

        //public void SP_Modificar(string pStoreProcedureName, string pCampos, string pCondicion, ArrayList pValores, ArrayList pValoresCondicion)
        //{
        //    ParametrosSQL = "";
        //    ArrayList oArregloParametros = new ArrayList();
        //    Campo1 = pCampos;
        //    Condicion = pCondicion;

        //    SqlCommand SqlCom = new SqlCommand(); 

        //    char[] oCaracterBuscado = { ',', ' ' };
        //    string[] oCadenaTemporal = pCampos.Split(oCaracterBuscado);

        //    for (int i = 0; i < oCadenaTemporal.Length; i++)
        //    {
        //        if (oCadenaTemporal[i] != String.Empty)
        //            oArregloParametros.Add("@" + oCadenaTemporal[i].Trim());
        //    }

        //    //Condicion
        //    oCadenaTemporal = pCondicion.Split(oCaracterBuscado);
        //    ArrayList oArregloCondicion = new ArrayList();

        //    for (int i = 0; i < oCadenaTemporal.Length; i++)
        //    {
        //        if (oCadenaTemporal[i] != String.Empty)
        //            oArregloCondicion.Add("@" + oCadenaTemporal[i].Trim());
        //    }

        //    SqlCom.Connection = Program.oPersistencia.conexion;

        //    SqlCom.CommandType = System.Data.CommandType.StoredProcedure;
        //    SqlCom.CommandText = pStoreProcedureName.Trim();

        //    int cont = 0;
        //    foreach (string oParameter in oArregloParametros)
        //    {
        //        SqlCom.Parameters.AddWithValue(oParameter.Trim(), (object)pValores[cont]);//(new SqlParameter(oParameter.Trim(), (object)pValores[cont]));
        //        cont++;
        //    }

        //    cont = 0;
        //    foreach (string oParameter in oArregloCondicion)
        //    {
        //        if (!oArregloParametros.Contains(oParameter))
        //            SqlCom.Parameters.AddWithValue(oParameter.Trim(), (object)pValoresCondicion[cont]);//new SqlParameter(oParameter.Trim(), (object)pValoresCondicion[cont]))
        //        cont++;
        //    }

        //    Program.oPersistencia.ejecutarSQL(SqlCom);

        //    if (Program.oPersistencia.IsError == true)
        //        MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");

        //    Program.oArregloGlobal.Clear();
        //    Program.oArregloGlobalCondiciones.Clear();
        //    SqlCom.Dispose();
        //}

        public void SP_Modificar(string pStoreProcedureName, ArrayList oArregloParametros, ArrayList oArregloCondicion, ArrayList pValores, ArrayList pValoresCondicion)
        {
            Program.oCLogs.InitializeValues();

            Program.oCLogs.ProcName = pStoreProcedureName;
            Program.oCLogs.Action = "Update";

            SqlCommand SqlCom = new SqlCommand();

            SqlCom.Connection = Program.oPersistencia.conexion;

            SqlCom.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCom.CommandText = pStoreProcedureName.Trim();

            int cont = 0;
            foreach (string oParameter in oArregloParametros)
            {
                SqlCom.Parameters.AddWithValue(oParameter.Trim(), (object)pValores[cont]);//(new SqlParameter(oParameter.Trim(), (object)pValores[cont]));
                Program.oCLogs.Parameters += oParameter.Trim() + (object)pValores[cont].ToString() + "||";
                cont++;
            }

            cont = 0;
            foreach (string oParameter in oArregloCondicion)
            {
                if (!oArregloParametros.Contains(oParameter))
                {
                    SqlCom.Parameters.AddWithValue(oParameter.Trim(), (object)pValoresCondicion[cont]);//new SqlParameter(oParameter.Trim(), (object)pValoresCondicion[cont]))
                    Program.oCLogs.ConditionParameters += oParameter.Trim() + (object)pValoresCondicion[cont].ToString() + "||";
                }
                cont++;
            }

            Program.oPersistencia.ejecutarSQL(SqlCom);

            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                Program.oCLogs.ErrorMessage = Program.oPersistencia.ErrorDescripcion.Trim();
            }

            Program.oCLogs.InsertLog();

            Program.oArregloGlobal.Clear();
            Program.oArregloGlobalCondiciones.Clear();
            SqlCom.Dispose();
        }

        public void SP_Eliminar(string pSP, string pCondicion, ArrayList pValoresCondicion)
        {
            Program.oCLogs.InitializeValues();

            Program.oCLogs.ProcName = pSP;
            Program.oCLogs.Action = "Delete";

            ArrayList oArregloParametros = new ArrayList();
            Condicion = pCondicion;

            SqlCommand SqlCom = new SqlCommand();

            char[] oCaracterBuscado = { ',', ' ' };
            string[] oCadenaTemporal = pCondicion.Split(oCaracterBuscado);
            ArrayList oArregloCondicion = new ArrayList();

            for (int i = 0; i < oCadenaTemporal.Length; i++)
            {
                if (oCadenaTemporal[i] != String.Empty)
                    oArregloCondicion.Add("@" + oCadenaTemporal[i].Trim());
            }

            SqlCom.Connection = Program.oPersistencia.conexion;
            SqlCom.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCom.CommandText = pSP.Trim();

            int cont = 0;
            foreach (string oParameter in oArregloCondicion)
            {
                SqlCom.Parameters.AddWithValue(oParameter.Trim(), (object)pValoresCondicion[cont]);
                Program.oCLogs.ConditionParameters += oParameter.Trim() + (object)pValoresCondicion[cont].ToString() + "||";
                cont++;
            }

            Program.oPersistencia.ejecutarSQL(SqlCom);

            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                Program.oCLogs.ErrorMessage = Program.oPersistencia.ErrorDescripcion.Trim();
            }

            Program.oCLogs.InsertLog();

            Program.oArregloGlobalCondiciones.Clear();
            SqlCom.Dispose();
        }

        public SqlDataReader SP_Consultar(string pSP, string pCondicion, ArrayList pValoresCondicion)
        {
            SqlDataReader oSqlDataReader = null;
            try
            {                
                ArrayList oArregloParametros = new ArrayList();
                Condicion = pCondicion;

                SqlCommand SqlCom = new SqlCommand();

                char[] oCaracterBuscado = { ',', ' ' };
                string[] oCadenaTemporal = pCondicion.Split(oCaracterBuscado);
                ArrayList oArregloCondicion = new ArrayList();

                for (int i = 0; i < oCadenaTemporal.Length; i++)
                {
                    if (oCadenaTemporal[i] != String.Empty)
                        oArregloCondicion.Add("@" + oCadenaTemporal[i].Trim());
                }

                SqlCom.Connection = Program.oPersistencia.conexion;
                SqlCom.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCom.CommandText = pSP.Trim();

                int cont = 0;
                foreach (string oParameter in oArregloCondicion)
                {
                    SqlCom.Parameters.AddWithValue(oParameter.Trim(), (object)pValoresCondicion[cont]);
                    cont++;
                }

                oSqlDataReader = Program.oPersistencia.ejecutarConsultaSQL(SqlCom);

                if (Program.oPersistencia.IsError == true)
                    MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");

                Program.oArregloGlobalCondiciones.Clear();
                SqlCom.Dispose();

                return oSqlDataReader;
            }
            finally             
            {
                //if (oSqlDataReader != null)
                //    oSqlDataReader.Dispose();
            }
        }

        public SqlDataReader SP_Consultar(string pSP)
        {
            SqlDataReader oSqlDataReader = null;

            try
            {
                SqlCommand SqlCom = new SqlCommand();

                SqlCom.Connection = Program.oPersistencia.conexion;
                SqlCom.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCom.CommandText = pSP.Trim();

                oSqlDataReader = Program.oPersistencia.ejecutarConsultaSQL(SqlCom);

                if (Program.oPersistencia.IsError == true)
                    MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");

                Program.oArregloGlobalCondiciones.Clear();
                SqlCom.Dispose();

                return oSqlDataReader;
            }
            finally
            {
                //if (oSqlDataReader != null)
                //    oSqlDataReader.Dispose();
            }
        }

        public DataSet SP_Consultar_DataSet(string pSP, string pCondicion, ArrayList pValoresCondicion)
        {
            DataSet ds = new DataSet();

            ArrayList oArregloParametros = new ArrayList();
            Condicion = pCondicion;

            char[] oCaracterBuscado = { ',', ' ' };
            string[] oCadenaTemporal = pCondicion.Split(oCaracterBuscado);
            ArrayList oArregloCondicion = new ArrayList();

            for (int i = 0; i < oCadenaTemporal.Length; i++)
            {
                if (oCadenaTemporal[i] != String.Empty)
                    oArregloCondicion.Add("@" + oCadenaTemporal[i].Trim());
            }

            SqlCommand SqlCom = new SqlCommand();

            SqlCom.Connection = Program.oPersistencia.conexion;
            SqlCom.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCom.CommandText = pSP.Trim();

            int cont = 0;
            foreach (string oParameter in oArregloCondicion)
            {
                SqlCom.Parameters.AddWithValue(oParameter.Trim(), (object)pValoresCondicion[cont]);
                cont++;
            }

            ds = Program.oPersistencia.ejecutarSQLListas(SqlCom);

            Program.oArregloGlobalCondiciones.Clear();
            SqlCom.Dispose();

            if (ds.Tables[0].Rows.Count > 0)
                return ds;
            else
            {
                ds.Dispose();
                return null;
            }
            //if (Program.oPersistencia.IsError == true)
            //    MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");

        }

        public DataSet SP_Consultar_DataSetV2(string pSP, string pCondicion, ArrayList pValoresCondicion)
        {
            DataSet ds = new DataSet();

            try
            {
                ArrayList oArregloParametros = new ArrayList();
                Condicion = pCondicion;

                char[] oCaracterBuscado = { ',', ' ' };
                string[] oCadenaTemporal = pCondicion.Split(oCaracterBuscado);
                ArrayList oArregloCondicion = new ArrayList();

                for (int i = 0; i < oCadenaTemporal.Length; i++)
                {
                    if (oCadenaTemporal[i] != String.Empty)
                        oArregloCondicion.Add("@" + oCadenaTemporal[i].Trim());
                }

                SqlCommand SqlCom = new SqlCommand();

                SqlCom.Connection = Program.oPersistencia.conexion;
                SqlCom.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCom.CommandText = pSP.Trim();

                int cont = 0;
                foreach (string oParameter in oArregloCondicion)
                {
                    SqlCom.Parameters.AddWithValue(oParameter.Trim(), (object)pValoresCondicion[cont]);
                    cont++;
                }

                ds = Program.oPersistencia.ejecutarSQLListas(SqlCom);

                Program.oArregloGlobalCondiciones.Clear();
                SqlCom.Dispose();

                if (ds.Tables[0].Rows.Count > 0)
                    return ds;
                else
                {
                    ds.Dispose();
                    return null;
                }
            }
            catch { return null; }
            finally
            {
                ds.Dispose();
                ds = null;
            }
            //if (Program.oPersistencia.IsError == true)
            //    MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");

        }
    }
}