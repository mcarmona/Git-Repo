using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.L�gica_Negocios;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmCategoriasGabinete : Form
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

        //CCategoriasGabinete
        CCategoriasGabinete oCCategoriasGabinete = new CCategoriasGabinete();

        public frmCategoriasGabinete()
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

        private void frmCategoriasGabinete_Load(object sender, EventArgs e)
        {
            tobCancelar_Click(sender, e);
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
            if (TxtDescripcion.Text.Trim() != "")
            {
                if (nuevo == true)
                {
                    oCCategoriasGabinete.IdCategoriaGabinete = "";
                    oCCategoriasGabinete.Descripcion = TxtDescripcion.Text.Trim();

                    oCCategoriasGabinete.Insertar();
                }
                else if (modificar == true)
                {
                    oCCategoriasGabinete.IdCategoriaGabinete = TxtCodigo.Text.Trim();
                    oCCategoriasGabinete.Descripcion = TxtDescripcion.Text.Trim();

                    oCCategoriasGabinete.Modificar();
                }

                if (!Program.oPersistencia.IsError)
                    tobCancelar_Click(sender, e);
            }
            else
                MessageBox.Show(this, "El valor de la Descripci�n no puede ser nulo, verifique los valores para continuar", "Atenci�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tobCancelar_Click(object sender, EventArgs e)
        {
            Metodos_Globales.LlenarGrid(Grid1, oCCategoriasGabinete.ConsultarSinParametros());
            Metodos_Globales.ModoBloqueo(toolStrip1, Grid1);
            Metodos_Globales.LimpiaCampos(this);
            Metodos_Globales.BloquearCampos(this);
            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);

            if (Grid1.Rows.Count == 0)
                toolStripStatusLabel2.Text = "Presione el bot�n \"Nuevo\" para ingresar un nuevo m�todo anticonceptivo";
            else
                toolStripStatusLabel2.Text = "Seleccione la fila deseada sobre la cual desea trabajar";
        }

        private void tobEliminar_Click(object sender, EventArgs e)
        {
            if (Grid1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(this, "�Est� seguro que desea eliminar los datos seleccionados?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    oCCategoriasGabinete.IdCategoriaGabinete = TxtCodigo.Text.Trim();
                    oCCategoriasGabinete.Descripcion = "";

                    oCCategoriasGabinete.Eliminar();

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
            oCCategoriasGabinete.Descripcion = TxtDescripcion.Text.Trim();
            Metodos_Globales.LlenarGrid(Grid1, oCCategoriasGabinete.ConsultarConParametros());

            if (Grid1.Rows.Count > 0)
            {
                Metodos_Globales.ModoBloqueo(toolStrip1, Grid1);                

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
            toolStripStatusLabel2.Text = "C�digo Autogenerado de la Categor�a de Gabinete (S�lo Lectura)"; 
        }

        private void TxtDescripcion_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Ingrese la descripci�n o nombre de la categor�a de gabinete";
        }

        private void Grid1_Enter(object sender, EventArgs e)
        {
            if (nuevo == true || modificar == true)
                toolStripStatusLabel2.Text = "Seleccione la fila deseada sobre la cual desea trabajar";
        }
    }
}