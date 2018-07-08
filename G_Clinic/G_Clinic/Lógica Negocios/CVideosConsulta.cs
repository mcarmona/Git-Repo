using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace G_Clinic.Lógica_Negocios
{
    class CVideosConsulta
    {
        string idConsulta = "";
        string urlVideo = "";

        public string IdConsulta
        {
            get { return idConsulta; }
            set { idConsulta = value; }
        }

        public string UrlVideo
        {
            get { return urlVideo; }
            set { urlVideo = value; }
        }

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_consulta");
            oArreglo.Add("@url_video");

            return oArreglo;
        }

        private ArrayList oArregloCondicion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idConsulta);

            return oArreglo;
        }

        private ArrayList oArregloVideos()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idConsulta);
            oArreglo.Add(urlVideo);

            return oArreglo;
        }

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Videos_Consulta", oArregloParametrosInsertar(), oArregloVideos());
        }

        public DataSet ConsultarDataset()
        {
            return Program.oStoredProcedures.SP_Consultar_DataSet("sp_S_Videos_Consulta", "id_consulta", oArregloCondicion());
        }
    }
}
