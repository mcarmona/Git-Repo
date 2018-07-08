using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace G_Clinic.Lógica_Negocios
{
    class CLogs
    {
        #region Variables

        string procName = "";
        public string ProcName
        {
            get { return procName; }
            set { procName = value; }
        }

        string action = "";
        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        string parameters = "";
        public string Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        string conditionParameters = "";
        public string ConditionParameters
        {
            get { return conditionParameters; }
            set { conditionParameters = value; }
        }

        string errorMessage = "";
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        string userName = "";
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        #endregion

        /// <summary>
        /// Resets all variables except username which is reseted when a different user starts session
        /// </summary>
        public void InitializeValues()
        {
            procName = "";
            action = "";
            parameters = "";
            conditionParameters = "";
            errorMessage = "";
        }

        public void InsertLog()
        {
            int actionType = 1;
            SqlCommand oCommand = new SqlCommand();
            oCommand.Connection = Program.oPersistencia.conexion;
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;
            oCommand.Parameters.AddWithValue("action_type", (object)actionType);
            oCommand.Parameters.AddWithValue("proc_name", (object)ProcName);
            oCommand.Parameters.AddWithValue("action", (object)Action);
            oCommand.Parameters.AddWithValue("parameters", (object)Parameters);
            oCommand.Parameters.AddWithValue("condition_parameters", (object)ConditionParameters);
            oCommand.Parameters.AddWithValue("error_description", (object)ErrorMessage);
            oCommand.Parameters.AddWithValue("username", (object)UserName);
            oCommand.CommandText = "sp_Log_DataManipulation";

            Program.oPersistencia.ejecutarSQL(oCommand);

            if (Program.oPersistencia.IsError == true)
                MessageBox.Show("There was an error inserting log=>" + Program.oPersistencia.ErrorDescripcion);

            oCommand.Dispose();
        }
    }
}