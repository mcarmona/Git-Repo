using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CAntecedentes_ObstetGinec
    {
        #region Variables

        string num_expediente = "";
        string gesta = "";
        string para = "";
        string abortos = "";
        string cesareas = "";
        string gemelares = "";
        string molas = "";
        string ectopicos = "";
        string obitos = "";
        DateTime ultimo_parto;
        string complicaciones_up = "";
        string menarca = "";
        string menopausia = "";
        string ciclo_menstrual = "";
        string tipo_ciclo = "";
        string detalle_tipo_ciclo = "";
        string detalleAdicional = "";

        #endregion        

        #region Encapsulaciones

        public string Num_Expediente
        {
            get { return num_expediente; }
            set { num_expediente = value; }
        }

        public string Gesta
        {
            get { return gesta; }
            set { gesta = value; }
        }

        public string Para
        {
            get { return para; }
            set { para = value; }
        }

        public string Abortos
        {
            get { return abortos; }
            set { abortos = value; }
        }

        public string Cesareas
        {
            get { return cesareas; }
            set { cesareas = value; }
        }

        public string Gemelares
        {
            get { return gemelares; }
            set { gemelares = value; }
        }

        public string Molas
        {
            get { return molas; }
            set { molas = value; }
        }

        public string Ectopicos
        {
            get { return ectopicos; }
            set { ectopicos = value; }
        }

        public string Obitos
        {
            get { return obitos; }
            set { obitos = value; }
        }

        public DateTime UltimoParto
        {
            get { return ultimo_parto; }
            set { ultimo_parto = value; }
        }

        public string ComplicacionesUltimoParto
        {
            get { return complicaciones_up; }
            set { complicaciones_up = value; }
        }

        public string Menarca
        {
            get { return menarca; }
            set { menarca = value; }
        }

        public string Menopausia
        {
            get { return menopausia; }
            set { menopausia = value; }
        }

        public string CicloMenstrual
        {
            get { return ciclo_menstrual; }
            set { ciclo_menstrual = value; }
        }

        public string TipoCiclo
        {
            get { return tipo_ciclo; }
            set { tipo_ciclo = value; }
        }

        public string DetalleTipoCiclo
        {
            get { return detalle_tipo_ciclo; }
            set { detalle_tipo_ciclo = value; }
        }

        public string DetalleAdicional
        {
            get { return detalleAdicional; }
            set { detalleAdicional = value; }
        }

        #endregion

        #region Arreglos

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();
            
            oArreglo.Add("@num_expediente");
            oArreglo.Add("@gesta");
            oArreglo.Add("@para");
            oArreglo.Add("@abortos");
            oArreglo.Add("@cesareas");
            oArreglo.Add("@gemelares");
            oArreglo.Add("@molas");
            oArreglo.Add("@ectopicos");
            oArreglo.Add("@obitos");
            oArreglo.Add("@ultimo_parto");
            oArreglo.Add("@complicaciones_up");
            oArreglo.Add("@menarca");
            oArreglo.Add("@menopausia");
            oArreglo.Add("@ciclo_menstrual");
            oArreglo.Add("@tipo_ciclo");
            oArreglo.Add("@detalle_tipo_ciclo");
            oArreglo.Add("@detalles_adicionales");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@gesta");
            oArreglo.Add("@para");
            oArreglo.Add("@abortos");
            oArreglo.Add("@cesareas");
            oArreglo.Add("@gemelares");
            oArreglo.Add("@molas");
            oArreglo.Add("@ectopicos");
            oArreglo.Add("@obitos");
            oArreglo.Add("@ultimo_parto");
            oArreglo.Add("@complicaciones_up");
            oArreglo.Add("@menarca");
            oArreglo.Add("@menopausia");
            oArreglo.Add("@ciclo_menstrual");
            oArreglo.Add("@tipo_ciclo");
            oArreglo.Add("@detalle_tipo_ciclo");
            oArreglo.Add("@detalles_adicionales");

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicionModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@num_expediente");

            return oArreglo;
        }
        
        private ArrayList oArregloAntecedentes_Obstet_Ginec()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(num_expediente);
            oArreglo.Add(gesta);
            oArreglo.Add(para);
            oArreglo.Add(abortos);
            oArreglo.Add(cesareas);
            oArreglo.Add(gemelares);
            oArreglo.Add(molas);
            oArreglo.Add(ectopicos);
            oArreglo.Add(obitos);
            oArreglo.Add(ultimo_parto);
            oArreglo.Add(complicaciones_up);
            oArreglo.Add(menarca);
            oArreglo.Add(menopausia);
            oArreglo.Add(ciclo_menstrual);
            oArreglo.Add(tipo_ciclo);
            oArreglo.Add(detalle_tipo_ciclo);
            oArreglo.Add(detalleAdicional);

            return oArreglo;
        }

        private ArrayList oArregloAntecedentesModificar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(gesta);
            oArreglo.Add(para);
            oArreglo.Add(abortos);
            oArreglo.Add(cesareas);
            oArreglo.Add(gemelares);
            oArreglo.Add(molas);
            oArreglo.Add(ectopicos);
            oArreglo.Add(obitos);
            oArreglo.Add(ultimo_parto);
            oArreglo.Add(complicaciones_up);
            oArreglo.Add(menarca);
            oArreglo.Add(menopausia);
            oArreglo.Add(ciclo_menstrual);
            oArreglo.Add(tipo_ciclo);
            oArreglo.Add(detalle_tipo_ciclo);
            oArreglo.Add(detalleAdicional);

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
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Antecedentes_Obstet_Ginec", oArregloParametrosInsertar(), oArregloAntecedentes_Obstet_Ginec());
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Antecedentes_Obstet_Ginec", oArregloParametrosModificar(), oArregloParametrosCondicionModificar(), oArregloAntecedentesModificar(), oArregloCondicion());
        }

        public SqlDataReader ConsultarSinParametros()
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Antecedentes_Obstet_Ginec");
        }

        public SqlDataReader ConsultarConParametros(string parametrosCondicion)
        {
            return Program.oStoredProcedures.SP_Consultar("sp_S_Antecedentes_Obstet_Ginec_Param", parametrosCondicion, oArregloCondicion());
        }

        public DataSet ConsultarDataset()
        {
            return Program.oStoredProcedures.SP_Consultar_DataSet("sp_S_Antecedentes_Obstet_Ginec_Param", "num_expediente", oArregloCondicion());
        }

        #endregion

    }
}
