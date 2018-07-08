using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CAntecedentesGenerales
    {
        #region Variables

        string num_expediente = "";
        string patologicos = "";
        string no_patologicos = "";
        string familiares = "";
        string quirurgicos = "";
        string alergias = "";
        string medicamentos = "";
        string otros = "";

        #endregion

        #region Encapsulaciones

        public string Num_expediente
        {
            get { return num_expediente; }
            set { num_expediente = value; }
        }

        public string Patologicos
        {
            get { return patologicos; }
            set { patologicos = value; }
        }

        public string No_patologicos
        {
            get { return no_patologicos; }
            set { no_patologicos = value; }
        }

        public string Familiares
        {
            get { return familiares; }
            set { familiares = value; }
        }

        public string Quirurgicos
        {
            get { return quirurgicos; }
            set { quirurgicos = value; }
        }

        public string Alergias
        {
            get { return alergias; }
            set { alergias = value; }
        }

        public string Medicamentos
        {
            get { return medicamentos; }
            set { medicamentos = value; }
        }

        public string Otros
        {
            get { return otros; }
            set { otros = value; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@num_expediente");
            oArreglo.Add("@patologicos");
            oArreglo.Add("@no_patologicos");
            oArreglo.Add("@familiares");
            oArreglo.Add("@quirurgicos");
            oArreglo.Add("@alergias");
            oArreglo.Add("@medicamentos");
            oArreglo.Add("@otros");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@patologicos");
            oArreglo.Add("@no_patologicos");
            oArreglo.Add("@familiares");
            oArreglo.Add("@quirurgicos");
            oArreglo.Add("@alergias");
            oArreglo.Add("@medicamentos");
            oArreglo.Add("@otros");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@num_expediente");

            return oArreglo;
        }
        
        private ArrayList oArregloAntecedentes()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(num_expediente);
            oArreglo.Add(patologicos);
            oArreglo.Add(no_patologicos);
            oArreglo.Add(familiares);
            oArreglo.Add(quirurgicos);
            oArreglo.Add(alergias);
            oArreglo.Add(medicamentos);
            oArreglo.Add(otros);

            return oArreglo;
        }

        private ArrayList oArregloAntecedentesModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(patologicos);
            oArreglo.Add(no_patologicos);
            oArreglo.Add(familiares);
            oArreglo.Add(quirurgicos);
            oArreglo.Add(alergias);
            oArreglo.Add(medicamentos);
            oArreglo.Add(otros);

            return oArreglo;
        }

        private ArrayList oArregloCondicion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(num_expediente);

            return oArreglo;
        }

        #endregion

        #region Métodos

        public void Insertar()
        {
            //Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Antecedentes_Generales", "num_expediente,patologicos,no_patologicos,familiares,quirurgicos,alergias,medicamentos,otros", oArregloAntecedentes());
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Antecedentes_Generales", oArregloParametrosInsertar(), oArregloAntecedentes());
        }

        public void Modificar()
        {
            //Program.oStoredProcedures.SP_Modificar("sp_U_Antecedentes_Generales", "patologicos,no_patologicos,familiares,quirurgicos,alergias,medicamentos,otros",
            //                                       "num_expediente", oArregloAntecedentesModificar(), oArregloCondicion());

            Program.oStoredProcedures.SP_Modificar("sp_U_Antecedentes_Generales", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloAntecedentesModificar(), oArregloCondicion());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Pacientes");
        }

        public SqlDataReader ConsultarConParametros(string parametrosCondicion)
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Pacientes_Param", parametrosCondicion, oArregloCondicion());
        }

        public DataSet ConsultarDataset()
        {
            return Program.oStoredProcedures.SP_Consultar_DataSet("sp_S_Antecedentes_Generales_Param", "num_expediente", oArregloCondicion());
        }

        #endregion
    }
}
