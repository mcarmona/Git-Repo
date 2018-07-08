using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Collections;

namespace G_Clinic
{
    public partial class frmNotificaciones : Form
    {
        #region Variables

        string id_Cita = "";
        string Detalle = "";
        string NombrePaciente = "";
        string IdCliente = "";
        DateTime Fecha = new DateTime();
        string NombreDoctor = "";
        string Prioridad = "";
        string Mensaje = "";

        int x = 0;
        int y = 0;
        int Bottom = 0;
        int tiempoVisible = 0;

        //Representa la posicion vertical del aviso
        int posicion = 0;
        int posVertical = 0;

        internal static int posicionVertical = 0;
        internal static int multiplicador = 1;

        internal static ArrayList listaSlots = new ArrayList();

        SoundPlayer oSoundPlayer;

        #endregion

        public frmNotificaciones(string pIdCita, string pDetalle, string pIdCliente, string pCliente, DateTime pFecha, string pDoctor, string pPrioridad)
        {
            InitializeComponent();
            id_Cita = pIdCita;
            Detalle = pDetalle;
            NombrePaciente = pCliente;
            NombreDoctor = pDoctor;
            Prioridad = pPrioridad;
            IdCliente = pIdCliente;
            Fecha = pFecha;
        }

        private void GeneraMensaje()
        {
            if (Prioridad == "Normal")
            {
                oSoundPlayer = new SoundPlayer(recursos.beep_normal);
                grouper1.BackgroundGradientColor = Color.LightSteelBlue;
            }
            else if (Prioridad == "Media")
            {
                oSoundPlayer = new SoundPlayer(recursos.beep_medium);
                grouper1.BackgroundGradientColor = Color.Yellow;
            }
            else if (Prioridad == "Alta")
            {
                oSoundPlayer = new SoundPlayer(recursos.beep_high);
                grouper1.BackgroundGradientColor = Color.Red;
            }

            Mensaje = "El paciente: " + NombrePaciente + " posee una cita el día " + Fecha.ToLongDateString() + " a las " + Fecha.ToLongTimeString() + " con el doctor " + NombreDoctor + " por motivo de " + Detalle.Trim();
            
            //245, máximo de caracteres permitidos para que aparezcan en el texto del mensaje
            if (Mensaje.Length > 245)
            {
                Mensaje.Remove(245, (Mensaje.Length - 245));
                Mensaje += "...";
            }
            
            lblDetalle.Text = Mensaje;
        }

        private void mostrarVentana()
        {
            if (Prioridad == "Normal")
            {
                tiempoVisible = 8;
            }
            else if (Prioridad == "Media")
            {
                tiempoVisible = 11;
            }
            else if (Prioridad == "Alta")
            {
                tiempoVisible = 15;
            }

            bool slotAsignado = false;

            #region - Se asigna un slot a la nueva ventana -

            //Le asignamos un slot a la ventana
            while (slotAsignado == false)
            {
                //Calculamos la posicion del nuevo slot
                posicionVertical = Screen.PrimaryScreen.Bounds.Bottom - 65 - ((180) * multiplicador);

                //Verificamos si la posicion del slot ya esta ocupada. Si no,
                //Le asignamos el numero de posicion a la nueva  slot y lo
                //agregamos a la lista de slots asignados
                if (listaSlots.Contains(posicionVertical) == false)
                {
                    if (posicionVertical >= 68)
                    {
                        listaSlots.Add(posicionVertical);
                        slotAsignado = true;
                    }
                    //Si todos los slots ya estan llenos
                    //entonces no mostramos el mensaje
                    else
                    {
                        return;
                    }
                }
                //Si el slot ya esta asignado, entonces cambiamos el multiplicador
                //y intentamos otravez
                else
                {
                    multiplicador++;
                }

                timerEspera.Interval = tiempoVisible * 1000;

                posVertical = posicionVertical;
            }
            #endregion
        }

        private void frmNotificaciones_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Size.Width - 10, Screen.PrimaryScreen.Bounds.Bottom);

            GeneraMensaje();
            mostrarVentana();

            timerInicio.Start();// .Enabled = true;
            DesdibujaPanel();
            DeterminaContactos();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (y > Bottom)
            //{
            //    this.Location = new Point(x, y -= 21);
            //}
            //else
            //{
            //    oSoundPlayer.Play();
            //    timer1.Enabled = false;
            //    y = Bottom;
            //    this.Location = new Point(x, y);
            //    this.Activate();
            //}
        }

        private void imagenCambiantePictureBox2_Click(object sender, EventArgs e)
        {
            timerCerrar.Enabled = true;
            //this.Close();
        }

        #region - Evento Tick del timer Inicio

        private void timerInicio_Tick(object sender, EventArgs e)
        {
            posicion += 15;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - posicion, posVertical);

            if (posicion >= 315)
            {
                timerInicio.Enabled = false;
                timerEspera.Enabled = true;

                oSoundPlayer.Play();
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
            try
            {
                posicion -= 5;
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - posicion, posVertical);

                if (posicion <= 0)
                {
                    this.Opacity = 0.3;
                    listaSlots.Remove(posVertical);
                    this.Close();

                    if (grouper1.BackgroundGradientColor == Color.Red)
                    {
                        frmRecordatorios ofrmRecordatorios = new frmRecordatorios(Mensaje, id_Cita, Color.Red, IdCliente, true);
                        ofrmRecordatorios.Show();
                        Program.contRecordatorios++;
                    }
                    else if (grouper1.BackgroundGradientColor == Color.Yellow)
                    {
                        frmRecordatorios ofrmRecordatorios = new frmRecordatorios(Mensaje, id_Cita, Color.Yellow, IdCliente, false);
                        ofrmRecordatorios.Show();
                        Program.contRecordatorios++;
                    }
                }
            }
            catch 
            {
                //Atrapa el error en caso de que el objeto form haya sido eliminado
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

        #region - Eventos Mouse Hover que evita que se oculte el aviso si el usuario tiene el mouse sobre él

        private void lblDetalle_MouseHover(object sender, EventArgs e)
        {
            timerEspera.Enabled = false;
        }

        private void grouper1_MouseHover(object sender, EventArgs e)
        {
            timerEspera.Enabled = false;
        }

        private void imagenCambiantePictureBox1_MouseHover(object sender, EventArgs e)
        {
            timerEspera.Enabled = false;
            //DibujaPanel(); 
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            timerEspera.Enabled = false;
        }

        private void btnCerrar_MouseHover(object sender, EventArgs e)
        {
            timerEspera.Enabled = false;
        }
        
        #endregion

        #region - Eventos Mouse leave que oculta el aviso si el usuario quita el mouse -

        private void lblDetalle_MouseLeave(object sender, EventArgs e)
        {
            timerEspera.Enabled = true;
        }

        private void grouper1_MouseLeave(object sender, EventArgs e)
        {
            timerEspera.Enabled = true;
        }

        private void imagenCambiantePictureBox1_MouseLeave(object sender, EventArgs e)
        {
            timerEspera.Enabled = true;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            timerEspera.Enabled = true;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            timerEspera.Enabled = true;
        }
        
        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Program.oMostrarRecordatorios.ModificarHoraRecordatorios(cmbLapsoRecordatorio.Text.Trim(), id_Cita.Trim()) == true)
            {
                btnCerrar_Click(sender, e);
                Program.oMostrarRecordatorios.ModificarEstadoRecordatorios("1", id_Cita.Trim());  
            }
        }

        //private void DeterminaContactos()
        //{
        //    try
        //    {
        //        int linea = 0;
        //        string Consulta = "select a.descripcion, b.descripcion from Tipo_Contactos a, Contactos_Paciente b " +
        //                          "where a.id_tipo_contacto = b.id_tipo_contacto and b.num_expediente = " + IdCliente.Trim();

        //        DataSet ds = Program.oPersistencia.ejecutarSQLListas(Consulta.Trim(), "Tipo_Contactos a, Contactos_Paciente b");

        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            lstContactos.Items.Add(dr[0].ToString().Trim());
        //            lstContactos.Items[linea].SubItems.Add(dr[1].ToString().Trim());
        //            linea++;
        //        }
        //        ds.Dispose();
        //    }
        //    catch { }
        //}

        private void DeterminaContactos()
        {
            try
            {
                lstContactos.Items.Clear();
                lstContactos2.Items.Clear();

                if (IdCliente != "" && IdCliente != "0")
                {
                    int linea = 0;
                    string Consulta = "select a.descripcion, b.descripcion from Tipo_Contactos a, Contactos_Paciente b " +
                                      "where a.id_tipo_contacto = b.id_tipo_contacto and b.num_expediente = " + IdCliente.Trim();

                    DataSet ds = Program.oPersistencia.ejecutarSQLListas(Consulta.Trim(), "Tipo_Contactos a, Contactos_Paciente b");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstContactos.Items.Add(dr[0].ToString().Trim());
                        lstContactos.Items[linea].SubItems.Add(dr[1].ToString().Trim());
                        linea++;
                    }
                    ds.Dispose();

                    lstContactos.Visible = true;
                    lstContactos2.Visible = false;
                }
                else
                {                    
                    string Consulta = "Select contacto1, contacto2 from Citas where id_cita = " + id_Cita.Trim();

                    DataSet ds = Program.oPersistencia.ejecutarSQLListas(Consulta.Trim(), "Citas");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstContactos2.Items.Add(dr[0].ToString().Trim());
                        lstContactos2.Items.Add(dr[1].ToString().Trim());
                    }
                    ds.Dispose();

                    lstContactos.Visible = false;
                    lstContactos2.Visible = true;
                }
            }
            catch { }
        }

        private void DibujaPanel()
        {
            //275, 93
            int x = 0;
            int y = 0;

            for (x = 0; x <= 275;)
            {
                panel1.Size = new Size(x, 5);
                x += 2;
            }

            for (y = 0; y <= 93; )
            {
                y++;
                panel1.Size = new Size(x, y);
            }

            panel1.Size = new Size(275, 93);
            DeterminaContactos();
        }

        private void DesdibujaPanel()
        {
            //275, 93
            int x = 275;

            for (int y = 93; y > 5; )
            {
                panel1.Size = new Size(x, y);
                y -= 1;
            }

            for (x = 275; x > 0; )
            {
                panel1.Size = new Size(x, 5);
                x -= 2;
            }

            panel1.Size = new Size(0, 0);
        }

        private void imagenCambiantePictureBox1_MouseLeave_1(object sender, EventArgs e)
        {
            timerEspera.Enabled = false;
            //DesdibujaPanel();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            timerEspera.Enabled = false;
            //DibujaPanel(); 
        }

        private void lstContactos_MouseEnter(object sender, EventArgs e)
        {
            timerEspera.Enabled = false;
            //DibujaPanel();
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            timerEspera.Enabled = true;
            //DesdibujaPanel(); 
        }

        private void imagenCambiantePictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Size.Width == 0)
                DibujaPanel();
            else
                DesdibujaPanel(); 
        }

        private void lstContactos_MouseLeave(object sender, EventArgs e)
        {
            timerEspera.Enabled = true;
        }

        private void imagenCambiantePictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

    }
}