using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace G_Clinic
{
    public partial class frmRecordatorios : Form
    {
        #region Variables

        ArrayList oArreglo = new ArrayList();
        internal static int inicialX = 0;
        int coordenadaX = 0;
        internal static int coordenadaY = 0;
        internal static int contador = 1;
        Point oPoint;
        internal static ArrayList Posiciones = new ArrayList();
        internal static int formCount = 0;

        string Detalle = "";
        string IdCita = "";
        Color oColor;
        string IdPaciente = "";
        bool Abierto = false;

        #endregion

        public frmRecordatorios(string pDetalle, string pIdCita, Color pColor, string pIdPaciente, bool pTopMost)
        {
            InitializeComponent();
            this.Visible = false;
            Detalle = pDetalle;
            IdCita = pIdCita;
            oColor = pColor;
            IdPaciente = pIdPaciente;
            this.TopMost = pTopMost;

            try
            {
                VistaConstants.SetWindowTheme(lstContactos.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstContactos.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
            }
            catch { }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.Opacity = 1f;
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Opacity = 0.17f;
            base.OnMouseLeave(e);
        }

        private void ReorganizarRecordatorios()
        {
            int cont = 0;

            foreach (Form oForm in Application.OpenForms)
            {
                if (oForm.Tag != null)
                {
                    oForm.Location = ((Point)(Posiciones[cont]));
                    oForm.Tag = "frmRecordatorios " + cont.ToString();
                    cont++;//Inicializamos el contador con las posiciones para ir acorde a los tags de los forms
                }
            }
        }

        private Point DeterminarPosicion()
        {
            #region Calcula_X

            coordenadaX = (Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width) + 10;
            
            if (inicialX == 0)
                inicialX = coordenadaX;

            #endregion

            #region Calcula_Y

            if (coordenadaY == 0)
                coordenadaY += 20;
            else
            {
                coordenadaY += this.Height + 10;
            }

            if (coordenadaY > Screen.PrimaryScreen.WorkingArea.Height)
            {
                contador++;
                coordenadaY = 20;
                coordenadaX = (Screen.PrimaryScreen.WorkingArea.Width - (this.Size.Width * contador)) + 10;
                inicialX = coordenadaX;
            }

            #endregion

            oPoint = new Point(inicialX , coordenadaY);
            Posiciones.Add(oPoint);

            return oPoint;
        }

        private void frmRecordatorios_Load(object sender, EventArgs e)
        {
            foreach (Form oForm in Application.OpenForms)
            {
                if (oForm.Tag != null)
                {
                    if (oForm.Tag.ToString().Trim() == IdCita.Trim())
                    {
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
            }

            this.Tag = IdCita.Trim();// +Tag;
            grouper1.BackgroundGradientColor = oColor;

            if (grouper1.BackgroundGradientColor == Color.Red)
            {
                pictureBox1.Image = recursos.folden_border_red;
                pictPrioridad.Image = recursos.Alta;
            }
            else if (grouper1.BackgroundGradientColor == Color.Yellow)
            {
                pictureBox1.Image = recursos.fold_border_yellow;
                pictPrioridad.Image = recursos.Media;
            }            

            btnTelefonos.Tag = IdPaciente;
            lblDetalleCita.Text = Detalle.Trim();
            this.Location = DeterminarPosicion();
            this.Visible = true;
            DeterminaContactos();
            DesdibujaPanel(); 
            Abierto = true;
        }

        #region Eventos MouseEnter

        private void lblDetalle_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void grouper2_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void pictPrioridad_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void imagenCambiantePictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void btnOpciones_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void lstContactos_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void lblDetalleCita_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void grouper1_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
        }

        private void lblDetalleCita_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = 0.17f;
        }

        private void grouper1_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = 0.17f;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void imagenCambiantePictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void frmRecordatorios_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (Abierto == true)
                {
                    Posiciones.RemoveAt(Posiciones.Count - 1);
                    coordenadaY -= this.Height + 10;

                    ReorganizarRecordatorios();
                }
            }
            catch { }
        }

        private void frmRecordatorios_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void DeterminaContactos()
        {
            try
            {
                lstContactos.Items.Clear();
                lstContactos2.Items.Clear();

                if (IdPaciente != "" && IdPaciente != "0")
                {
                    int linea = 0;
                    string Consulta = "select a.descripcion, b.descripcion from Tipo_Contactos a, Contactos_Paciente b " +
                                      "where a.id_tipo_contacto = b.id_tipo_contacto and b.num_expediente = " + IdPaciente.Trim();

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
                    string Consulta = "Select contacto1, contacto2 from Citas where id_cita = " + IdCita.Trim();

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
            //163, 169
            int x = 0;
            int y = 0;

            for (x = 0; x <= 163; )
            {
                panel4.Size = new Size(x, 5);
                x += 2;
            }

            for (y = 5; y <= 169; )
            {
                y++;
                panel4.Size = new Size(x, y);
            }

            panel4.Size = new Size(163, 169);
        }

        private void DesdibujaPanel()
        {
            //163, 169
            int x = 163;

            for (int y = 169; y > 5; )
            {
                panel4.Size = new Size(x, y);
                y -= 2;
            }

            for (x = 163; x > 0; )
            {
                panel4.Size = new Size(x, 5);
                x -= 3;
            }

            panel4.Size = new Size(0, 0);
        }

        private void btnTelefonos_Click(object sender, EventArgs e)
        {
            if (panel4.Size.Width == 0)
                DibujaPanel();
            else
                DesdibujaPanel(); 
        }

        private void imagenCambiantePictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Está seguro que desea continuar?, recuerde que si continúa con estas acciones este mensaje no se mostrará nuevamente en el futuro.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Program.oMostrarRecordatorios.ModificarEstadoRecordatorios("2", IdCita.Trim());
                this.Close();
            }
        }

        private void btnOpciones_MouseClick(object sender, MouseEventArgs e)
        {
            Point oPunto = new Point();
            oPunto.X = btnOpciones.Location.X;
            oPunto.Y = btnOpciones.Height;

            contextMenuStrip2.Show(Cursor.Position, ToolStripDropDownDirection.Left);
        }

        private void eliminarArtículoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (this.TopMost == true)
                this.TopMost = false;
            else
                this.TopMost = true;
        }

    }
}