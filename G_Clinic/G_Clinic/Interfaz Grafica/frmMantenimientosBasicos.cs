using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.L�gica_Negocios;
using G_Clinic.Miscelaneos_y_Recursos;
using System.Collections;

namespace G_Clinic
{
    public partial class frmMantenimientosBasicos : Form
    {
        bool nuevo = false;
        bool modificar = false;

        #region MoverForm

        const int WM_SYSCOMMAND = 0x112;
        const int MOUSE_MOVE = 0xF012;

        // Declaraciones del API
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        // funci�n privada usada para mover el formulario actual
        private void moverForm()
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, MOUSE_MOVE, 0);
        }

        #endregion

        CTiposContacto oCTiposContacto = new CTiposContacto();

        CPermisosEspeciales oCPermisosEspeciales = new CPermisosEspeciales();
        ArrayList oArregloPermisos = new ArrayList();

        public frmMantenimientosBasicos()
        {
            InitializeComponent();
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.Mantenimiento);

            Grid1.AutoGenerateColumns = false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void frmMantenimientosBasicos_Load(object sender, EventArgs e)
        {
            oArregloPermisos = oCPermisosEspeciales.LeePermisos(MDIPrincipal.RolUsuario.Trim(), this.Tag.ToString().Trim());
            tobCancelar_Click(sender, e);

            try
            {
                VistaConstants.SetWindowTheme(Grid1.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(Grid1.Handle, VistaConstants.TVM_SETEXTENDEDSTYLE, VistaConstants.TVS_EX_AUTOHSCROLL, VistaConstants.TVS_EX_AUTOHSCROLL);

                VistaConstants.SetWindowTheme(Grid1.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(Grid1.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
            }
            catch { }

        }

        #region Botones de Salida del Form

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            btnCerrar_Click(sender, e);
        }

        #endregion

        #region Botones de la barra de herramientas

        private void tobNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            modificar = false;

            Metodos_Globales.DesbloquearCampos(this);
            Metodos_Globales.EstableceFoco(TxtDescripcion);
            Metodos_Globales.LimpiaCampos(this);
            Metodos_Globales.ModoEscritura(toolStrip1);
            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
        }

        private void tobModificar_Click(object sender, EventArgs e)
        {
            if (Grid1.SelectedRows.Count > 0)
            {
                if (TxtDescripcion.Text.Trim() == "Celular" || TxtDescripcion.Text.Trim() == "Tel.Habitaci�n" || TxtDescripcion.Text.Trim() == "Email")
                {
                    MessageBox.Show(this, "Estos tipos de contactos son cruciales para el funcionamiento del sistema por lo que no podr�n ser eliminados o modificados", "No se pueden eliminar o modificar los datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                nuevo = false;
                modificar = true;

                Metodos_Globales.DesbloquearCampos(this);
                Metodos_Globales.EstableceFoco(TxtDescripcion);
                Metodos_Globales.ModoModificar(toolStrip1);
                Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
            }
            else
                MessageBox.Show(this, "Primero debe seleccionar la fila que contenga los valores deseados para realizar estas acciones", "Atenci�n", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tobGuardar_Click(object sender, EventArgs e)
        {
            bool continuar = false;

            if (MDIPrincipal.RolUsuario == "Administrador")
                continuar = true;
            else
            {
                if ((bool)oArregloPermisos[3] == true)
                {
                    FrmSolicitudAdmin oFrmSolicitudAdmin = new FrmSolicitudAdmin();
                    oFrmSolicitudAdmin.ShowDialog();

                    if (FrmSolicitudAdmin.Continuar == true)
                        continuar = true;
                    else
                    {
                        MessageBox.Show(this, "No se puede continuar con estas acciones hasta que un administrador del sistema otorgue la autorizaci�n necesaria, ya que as� lo establecen los permisos de usuario establecidos.", "Atenci�n", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        continuar = false;
                    }
                }
                else
                    continuar = true;
            }

            if (continuar == true)
            {
                if (TxtDescripcion.Text.Trim() != "")
                {
                    if (nuevo == true)
                    {
                        oCTiposContacto.IdTipo = "";
                        oCTiposContacto.Descripcion = TxtDescripcion.Text.Trim();

                        oCTiposContacto.Insertar();
                    }
                    else if (modificar == true)
                    {
                        oCTiposContacto.IdTipo = TxtCodigo.Text.Trim();
                        oCTiposContacto.Descripcion = TxtDescripcion.Text.Trim();

                        oCTiposContacto.Modificar();
                    }

                    if (!Program.oPersistencia.IsError)
                        tobCancelar_Click(sender, e);
                }
                else
                    MessageBox.Show(this, "El valor de la Descripci�n no puede ser nulo, verifique los valores para continuar", "Atenci�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tobCancelar_Click(object sender, EventArgs e)
        {
            Metodos_Globales.LlenarGrid(Grid1, oCTiposContacto.ConsultarSinParametros());
            Metodos_Globales.ModoBloqueo(toolStrip1, Grid1);

            Metodos_Globales.EjecutaPermisos(tobNuevo, tobModificar, tobEliminar, oArregloPermisos);

            if (tobModificar.Enabled == true || tobEliminar.Enabled == true)
            {
                if (Grid1.Rows.Count > 0)
                {
                    if (tobModificar.Enabled == true)
                        tobModificar.Enabled = true;
                    else
                        tobModificar.Enabled = false;

                    if (tobEliminar.Enabled == true)
                        tobEliminar.Enabled = true;
                    else
                        tobEliminar.Enabled = false;
                }
            }

            Metodos_Globales.LimpiaCampos(this);
            Metodos_Globales.BloquearCampos(this);
            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);

            toolStripStatusLabel2.Text = "";
        }

        private void tobEliminar_Click(object sender, EventArgs e)
        {
            if (Grid1.SelectedRows.Count > 0)
            {
                if (TxtDescripcion.Text.Trim() == "Celular" || TxtDescripcion.Text.Trim() == "Tel.Habitaci�n" || TxtDescripcion.Text.Trim() == "Email")
                {
                    MessageBox.Show(this, "Estos tipos de contactos son cruciales para el funcionamiento del sistema por lo que no podr�n ser eliminados o modificados", "No se pueden eliminar o modificar los datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                if (MessageBox.Show(this, "�Est� seguro que desea eliminar los datos seleccionados?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    oCTiposContacto.IdTipo = TxtCodigo.Text.Trim();
                    oCTiposContacto.Descripcion = "";

                    oCTiposContacto.Eliminar();

                    if (!Program.oPersistencia.IsError)
                        tobCancelar_Click(sender, e);

                    if (Grid1.RowCount > 0)
                    {
                        DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, 0);
                        Grid1_CellEnter(sender, e2);
                    }
                }
            }
            else
                MessageBox.Show(this, "Primero debe seleccionar la fila que contenga los valores deseados para realizar estas acciones", "Atenci�n", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Grid1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            TxtCodigo.Text = Grid1.CurrentRow.Cells[0].Value.ToString().Trim();
            TxtDescripcion.Text = Grid1.CurrentRow.Cells[1].Value.ToString().Trim();
        }

        private void tobIniciarConsulta_Click(object sender, EventArgs e)
        {
            nuevo = false;
            modificar = false;

            Metodos_Globales.DesbloquearCampos(this);
            Metodos_Globales.EstableceFoco(TxtDescripcion);
            Metodos_Globales.LimpiaCampos(this);
            Metodos_Globales.ModoConsulta(toolStrip1);
            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
        }

        private void tobEjecutarConsulta_Click(object sender, EventArgs e)
        {
            oCTiposContacto.Descripcion = TxtDescripcion.Text.Trim();
            Metodos_Globales.LlenarGrid(Grid1, oCTiposContacto.ConsultarConParametros());

            if (Grid1.Rows.Count > 0)
            {
                Metodos_Globales.ModoBloqueo(toolStrip1, Grid1);
                Metodos_Globales.EjecutaPermisos(tobNuevo, tobModificar, tobEliminar, oArregloPermisos);

                if (tobModificar.Enabled == true || tobEliminar.Enabled == true)
                {
                    if (tobModificar.Enabled == true)
                        tobModificar.Enabled = true;
                    else
                        tobModificar.Enabled = false;

                    if (tobEliminar.Enabled == true)
                        tobEliminar.Enabled = true;
                    else
                        tobEliminar.Enabled = false;
                }

                tobCancelarConsulta.Enabled = true;
            }
            else
            {
                MessageBox.Show(this, "No se encontraron resultados con los par�metros descritos", "Atenci�n", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                tobIniciarConsulta.Enabled = true;
                tobEjecutarConsulta.Enabled = false;
            }
        }

        private void tobCancelarConsulta_Click(object sender, EventArgs e)
        {
            tobCancelar_Click(sender, e);
        }

        private void tobSalir_Click(object sender, EventArgs e)
        {
            btnSalir_Click(sender, e);
        }

        #endregion

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            moverForm();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            moverForm();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TxtCodigo_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "C�digo Autogenerado del Tipo de Contacto (S�lo Lectura)";
        }

        private void TxtDescripcion_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Ingrese la descripci�n o nombre del Tipo de Contacto (Celular, Email, etc...)";
        }

        private void Grid1_Enter(object sender, EventArgs e)
        {
            if (nuevo == true || modificar == true)
                toolStripStatusLabel2.Text = "Seleccione la fila deseada sobre la cual desea trabajar";
        }

    }
}