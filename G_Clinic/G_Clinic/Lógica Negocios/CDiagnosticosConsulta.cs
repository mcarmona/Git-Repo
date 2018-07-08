using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic.Lógica_Negocios
{
    class CDiagnosticosConsulta
    {
        string idDiagnostico = "";
        string idConsulta = "";

        public CDiagnosticosConsulta()
        {
        }

        #region Encapsulaciones de Campos

        public String IdDiagnostico
        {
            set { idDiagnostico = value; }
            get { return idDiagnostico; }
        }

        public String IdConsulta
        {
            set { idConsulta = value; }
            get { return idConsulta; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_consulta");
            oArreglo.Add("@id_diagnostico");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_consulta");
            oArreglo.Add("@id_diagnostico");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@aux_id_consulta");
            oArreglo.Add("@aux_id_diagnostico");

            return oArreglo;
        }

        private ArrayList oArregloDiagnosticos()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idConsulta);
            oArreglo.Add(idDiagnostico);

            return oArreglo;
        }

        private ArrayList oArregloCondicionDiagnosticos()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idConsulta);

            return oArreglo;
        }

        private ArrayList oArregloCondicionModif_EliminDiagnosticos()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idConsulta);
            oArreglo.Add(idDiagnostico);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Diagnosticos_Consulta", oArregloParametrosInsertar(), oArregloDiagnosticos());
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Diagnosticos", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloDiagnosticos(), oArregloCondicionModif_EliminDiagnosticos());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Diagnosticos_Consulta", "id_consulta,id_diagnostico", oArregloCondicionModif_EliminDiagnosticos());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Diagnosticos_Consulta");
        }

        public SqlDataReader ConsultarConParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Diagnosticos_Param", "id_consulta", oArregloCondicionDiagnosticos());
        }

        public bool DeterminaDiagnosticoRepetido(string pidConsulta, string pIdDiagnostico)
        {
            bool repetido = false;

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select * from Diagnosticos_Consulta where id_consulta = " + pidConsulta.Trim() + " and id_diagnostico = " + pIdDiagnostico.Trim() + "'", "Diagnosticos_Consulta");

            if (ds.Tables[0].Rows.Count > 0)
                repetido = true;

            ds.Dispose();

            return repetido;
        }

        #endregion


    }
}
