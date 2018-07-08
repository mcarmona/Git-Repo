using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CImagenesConsulta
    {
        string idConsulta = "";
        byte[] foto;

        public string IdConsulta
        {
            get { return idConsulta; }
            set { idConsulta = value; }
        }

        public byte[] Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_consulta");
            oArreglo.Add("@foto");

            return oArreglo;
        }

        private ArrayList oArregloCondicion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idConsulta);

            return oArreglo;
        }

        private ArrayList oArregloImagenes()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(idConsulta);
            if (foto != null)
                oArreglo.Add(foto);

            return oArreglo;
        }

        public void Insertar()
        {            
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Imagenes_Consulta", oArregloParametrosInsertar(), oArregloImagenes());
        }

        public DataSet ConsultarDataset()
        {
            return Program.oStoredProcedures.SP_Consultar_DataSet("sp_S_Imagenes_Consulta", "id_consulta", oArregloCondicion());
        }
    }
}
