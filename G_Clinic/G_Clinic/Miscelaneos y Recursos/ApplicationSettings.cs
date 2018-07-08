using G_Clinic.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public enum FormType
    {
        Mantenimiento = 1,
        DetalleDeConsulta = 2,
        ExamenesYGabinete = 3
    }

    public static class ApplicationSettings
    {
        public static Font FuenteMantenimientos
        {
            get
            {
                return Settings.Default.FuenteDeMantenimientos;
            }
        }

        public static Font FuenteDeDetalleConsultas
        {
            get
            {
                return Settings.Default.FuenteDeDetalleConsultas;
            }
        }

        public static Font FuenteDeResultadoExamenesYGabinete
        {
            get
            {
                return Settings.Default.FuenteDeResultadoExamenesYGabinete;
            }
        }
    }
}
