using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace G_Clinic.Lógica_Negocios
{
    class CConsultasAntiguas
    {
        #region MyRegion

        int id_consulta = 0;
        public int Id_consulta
        {
            get { return id_consulta; }
            set { id_consulta = value; }
        }

        int num_expediente = 0;
        public int Num_expediente
        {
            get { return num_expediente; }
            set { num_expediente = value; }
        }

        DateTime fecha_consulta = new DateTime();
        public DateTime Fecha_consulta
        {
            get { return fecha_consulta; }
            set { fecha_consulta = value; }
        }

        string detalle_adicional = "";
        public string Detalle_adicional
        {
            get { return detalle_adicional; }
            set { detalle_adicional = value; }
        }

        byte[] detalle_consulta;
        public byte[] Detalle_consulta
        {
            get { return detalle_consulta; }
            set { detalle_consulta = value; }
        } 
        #endregion

        private ArrayList oArregloParametrosInsertar()
        {
            ArrayList oArreglo = new ArrayList();
            oArreglo.Add("@num_expediente"); 
            oArreglo.Add("@fecha_consulta");
            oArreglo.Add("@detalle_adicional");
            oArreglo.Add("@detalle_consulta");

            return oArreglo;
        }

        private ArrayList oArregloParametrosModificar()
        {
            ArrayList oArreglo = new ArrayList();
            oArreglo.Add("@detalle_adicional");

            return oArreglo;
        }

        private ArrayList oArregloConsulta()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(Num_expediente);
            oArreglo.Add(Fecha_consulta);
            oArreglo.Add(Detalle_adicional);
            oArreglo.Add(Detalle_consulta);

            return oArreglo;
        }

        private ArrayList oArregloModificarConsulta()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(Detalle_adicional);

            return oArreglo;
        }

        private ArrayList oArregloParametrosCondicion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add("@id_consulta_antigua");

            return oArreglo;
        }

        private ArrayList oArregloCondicion()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(Id_consulta);

            return oArreglo;
        }

        private ArrayList oArregloCondicionSeleccionar()
        {
            ArrayList oArreglo = new ArrayList();

            oArreglo.Add(Num_expediente);

            return oArreglo;
        }

        public void Insertar()
        {
            Program.oStoredProcedures.SP_GuardarNuevo("sp_I_Consulta_Antigua", oArregloParametrosInsertar(), oArregloConsulta());
        }

        public void Modificar()
        {
            Program.oStoredProcedures.SP_Modificar("sp_U_Consulta_Anterior", oArregloParametrosModificar(), oArregloParametrosCondicion(), oArregloModificarConsulta(), oArregloCondicion());
        }

        public void Eliminar()
        {
            Program.oStoredProcedures.SP_Eliminar("sp_D_Consulta_Anterior", "id_consulta_antigua", oArregloCondicion());
        }

        public DataSet Seleccionar()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Program.oStoredProcedures.SP_Consultar_DataSet("sp_S_Consulta_Anterior", "num_expediente", oArregloCondicionSeleccionar());
                return ds;
            }
            catch { return ds; }
            finally 
            {
                if (ds != null)
                    ds.Dispose();
            }
        }
    }
}
