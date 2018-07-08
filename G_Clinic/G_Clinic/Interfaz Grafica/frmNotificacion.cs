#region - Notas del CopyRight -
//SecuryCore - Libreria de gestion de usuarios
//Copyright (C) 2007  Juan de jesus ramos
//
//Este programa es Software Libre; Usted puede redistribuirlo y/o modificarlo 
//bajo los términos de la GNU Lesser General Public Licnese (LGPL) tal y como ha sido 
//públicada por la Free Software Foundation; bien la versión 2.1 de la Licencia, 
//o (a su opción) cualquier versión posterior.
//
//Esta libreria se distribuye con la esperanza de que sea útil, pero SI NINGUNA 
//GARANTÍA; tampoco las implícitas garantías de MERCANTILIDAD o ADECUACIÓN A UN 
//PROPÓSITO PARTICULAR. Consulte la GNU Lesser General Public License (LGPL) para más  
//detalles. Usted debe recibir una copia de la GNU Lesser General Public License (LGPL) 
//junto con este programa; si no, escriba a la Free Software Foundation Inc.    
//51 Franklin Street, 5º Piso, Boston, MA 02110-1301, USA.
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Media;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic
{
    internal partial class frmNotificacion : Form
    {
        //Representa la posicion vertical del aviso
        int posicion = 0;
        int posVertical = 0;

        #region - Constructor -
        public frmNotificacion(int posicionVertical)
        {
            InitializeComponent();
            posVertical = posicionVertical;
        }
        #endregion

        #region - Agrega el efecto DropShadow al formulario -
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                CreateParams parameters = base.CreateParams;

                if (DropShadowSupported)
                {
                    parameters.ClassStyle = (parameters.ClassStyle | CS_DROPSHADOW);
                }

                return parameters;
            }
        }

        public static bool DropShadowSupported
        {
            get { return IsWindowsXPOrAbove; }
        }

        public static bool IsWindowsXPOrAbove
        {
            get
            {
                OperatingSystem system = Environment.OSVersion;
                bool runningNT = system.Platform == PlatformID.Win32NT;

                return runningNT && system.Version.CompareTo(new Version(5, 1, 0, 0)) >= 0;
            }
        }
        #endregion

        #region - Evento Load -
        private void frmNotificacion_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Size.Width-10,Screen.PrimaryScreen.Bounds.Bottom);
            timerInicio.Enabled = true;
        }
        #endregion

        #region - Evento Tick del timer Inicio -
        private void timerInicio_Tick(object sender, EventArgs e)
        {
            posicion += 5;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - posicion - 37, posVertical);


            if (posicion>=190)
            {
                timerInicio.Enabled = false;
                timerEspera.Enabled = true;

                SoundPlayer myPlayer = new SoundPlayer(recursos.Popup);
                myPlayer.Play();
            }
        }
        #endregion

        #region - Evento click del icono para cerrar el aviso -
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            timerInicio.Enabled = false;
            timerEspera.Enabled = false;
            timerCerrar.Enabled = true;
        }
        #endregion

        #region - Evento tick del timer que cierra el aviso -
        private void timerCerrar_Tick(object sender, EventArgs e)
        {
            posicion -= 5;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - posicion, posVertical);

            if (posicion <= 0)
            {
                this.Opacity = 0.3;
                G_Clinic.Notificacion.listaSlots.Remove(posVertical);
                this.Close();
            }
        }
        #endregion

        #region - Evento tick del timer que espera -
        private void timerEspera_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            timerEspera.Enabled = false;
            timerCerrar.Enabled = true;
        }
        #endregion

        #region - Evento Mouse Over que evita que se oculte el aviso si el usuario tiene el mouse sobre el -
        private void lblTexto_MouseHover(object sender, EventArgs e)
        {
            timerEspera.Enabled = false;
        }
        #endregion

        #region - Evento Mouse leave que oculta el aviso si el usuario quita el mouse -
        private void lblTexto_MouseLeave(object sender, EventArgs e)
        {
            timerEspera.Enabled = true;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            btnCerrar_Click(sender,e);
        }

    }
}