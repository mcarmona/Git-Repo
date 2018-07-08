using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using G_Clinic.Lógica_Negocios;
using System.Collections;
using G_Clinic.Miscelaneos_y_Recursos;
using G_Clinic.Interfaz_Grafica;

namespace G_Clinic
{
    static class Program
    {
        #region Instancias Globales

        public static string coUsuario;
        public static string oIdUsuario;
        public static string nomUsuario;
        public static string coClaveUsuario;
        public static String Usuario;

        public static Persistencia oPersistencia;
        public static Comprobaciones oComprobaciones = new Comprobaciones();
        public static string oUsuario;
        public static MDIPrincipal oMDI;
        public static FrmIntro oFrmIntro;
        public static Stored_Procedures oStoredProcedures = new Stored_Procedures();
        public static FrmWait oFrmWait;
        public static FrmWaitSaving oFrmWaitSaving;
        public static Metodos_Globales oMetodosGlobales = new Metodos_Globales();

        public static frmHistoriaClinica oFrmHistoriaClinica;
        public static int MostraBarraInicio = 0;
        public static int OcultarLuegoConsulta = 0;
        public static int MostrarBarraSiempre = 0;

        public static ArrayList oArregloGlobal = new ArrayList();
        public static ArrayList oArregloGlobalCondiciones = new ArrayList();

        public static CPacientes oCPacientes = new CPacientes();
        public static frmDetallePaciente oFrmDetallePaciente;

        public static frmConsultas oFrmConsultas;
        public static CConsultas oCConsultas = new CConsultas();

        public static frmExamenesConsulta oFrmExamenesConsulta;

        public static frmImagenesConsultas oFrmImagenesConsultas;

        public static frmVideosConsulta oFrmVideosConsulta;

        public static frmHistorialConsultas oFrmHistorialConsultas;

        public static frmEmbarazos oFrmEmbarazos;

        public static frmDock oFrmDock;

        public static frmCalendario ofrmCalendario;

        public static frmCuadernoCitas oFrmCuadernoCitas;

        public static bool CrearNuevo;
        public static Mutex oMutex = new Mutex(true, "G-Clinic", out CrearNuevo);

        public static CCitas oCCitas = new CCitas();

        public static MostrarRecordatorios oMostrarRecordatorios = new MostrarRecordatorios();

        public static frmMenuPrincipal ofrmMenuPrincipal;

        public static int contRecordatorios = 0;

        public static frmNotificacion Notificaciones;

        public static FrmCambiarContraseñaUsuario oFrmCambiarContraseñaUsuario;

        public static frmMailSettings oFrmMailSettings;

        public static frmOrb oFrmOrb;

        public static frmEpicrisis oFrmEpicrisis;

        public static CEmpresa oCEmpresa = new CEmpresa();

        public static frmEnviarCorreos oFrmEnviarCorreos;

        public static frmPrescriptionPad ofrmPrescriptionPad;

        public static CLogs oCLogs = new CLogs();

        public static string oSMTPPort = "";

        public static bool oEnableSSL = false;
        
        #endregion

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!CrearNuevo)
            {
                MessageBox.Show("Solamente puede existir una instancia del sistema funcionando a la vez", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new TestForm1());
            //return;

            Program.oFrmIntro = new FrmIntro();

            Program.oFrmIntro.Show();

            Application.DoEvents();

            oMDI = new MDIPrincipal();
            Application.Run(oMDI);

            //Mantiene vivo el mutex hasta que se finalice el programa de manera normal
            GC.KeepAlive(oMutex);

            //Application.EnableVisualStyles();
        }
    }
}