using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Lógica_Negocios;
using G_Clinic.Miscelaneos_y_Recursos;
using System.Collections;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmGabinete : Form
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
        // función privada usada para mover el formulario actual
        private void moverForm()
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, MOUSE_MOVE, 0);
        }

        #endregion

        #region Variables e instancias

        CGabinete oCGabinete = new CGabinete();
        CCategoriasGabinete oCCategoriasGabinete = new CCategoriasGabinete();
        CGabineteCategoria oCGabineteCategoria = new CGabineteCategoria();

        ArrayList nombreCategoria = new ArrayList();
        ArrayList idCategoria = new ArrayList();

        CPermisosEspeciales oCPermisosEspeciales = new CPermisosEspeciales();
        ArrayList oArregloPermisos = new ArrayList();

        #endregion

        public frmGabinete()
        {
            InitializeComponent();
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.Mantenimiento);
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
            Metodos_Globales.EstableceFoco(txtNombre);
            LimpiaCampos();
            Metodos_Globales.ModoEscritura(toolStrip1);

            tobGuardarCategoria.Enabled = true;

            lstGabinete.Enabled = false;

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
        }

        private void tobModificar_Click(object sender, EventArgs e)
        {
            if (lstGabinete.SelectedItems.Count > 0)
            {
                nuevo = false;
                modificar = true;

                Metodos_Globales.DesbloquearCampos(this);
                Metodos_Globales.EstableceFoco(TxtDescripcion);
                Metodos_Globales.ModoModificar(toolStrip1);

                tobGuardarCategoria.Enabled = true;

                lstGabinete.Enabled = false;

                Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
            }
            else
                MessageBox.Show(this, "Debe de seleccionar el estudio deseado de la lista disponible para poder modificar sus valores.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private bool VerificaCampos()
        {
            bool continuar = true;

            if (txtNombre.Text.Trim() == "")
            {
                continuar = false;
                MessageBox.Show(this, "El nombre del estudio no puede estar en blanco, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
            }

            if (cmbCategorias.SelectedIndex == -1)
            {
                continuar = false;
                MessageBox.Show(this, "Debe seleccionar la categoría a la que pertenecerá el estudio descrito, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategorias.Focus();
            }

            return continuar;
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
                        MessageBox.Show(this, "No se puede continuar con estas acciones hasta que un administrador del sistema otorgue la autorización necesaria, ya que así lo establecen los permisos de usuario establecidos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        continuar = false;
                    }
                }
                else
                    continuar = true;
            }

            if (continuar == true)
            {
                cmbCategorias_Leave(sender, e);

                if (VerificaCampos() == true)
                {
                    if (cmbCategorias.SelectedValue != null)
                    {
                        if (nuevo == true)
                        {
                            oCGabinete.IdGabinete = "";
                            oCGabinete.Nombre = txtNombre.Text.Trim();
                            oCGabinete.Descripcion = TxtDescripcion.Text.Trim();

                            oCGabinete.Insertar();//Primero inserta el Gabinete

                            oCGabineteCategoria.IdGabinete = oCGabinete.Max_Gabinete();
                            oCGabineteCategoria.IdCategoriaGabinete = cmbCategorias.SelectedValue.ToString().Trim();

                            oCGabineteCategoria.Insertar();//Luego inserte el Gabinete por categoría
                        }
                        else if (modificar == true)
                        {
                            oCGabinete.IdGabinete = lstGabinete.SelectedItems[0].SubItems[1].Text.Trim();
                            oCGabinete.Nombre = txtNombre.Text.Trim();
                            oCGabinete.Descripcion = TxtDescripcion.Text.Trim();

                            oCGabinete.Modificar();//Primero modifica los valores del gabinete

                            oCGabineteCategoria.AuxId_Categoria_Gabinete = cmbCategorias.SelectedValue.ToString().Trim();
                            oCGabineteCategoria.IdGabinete = lstGabinete.SelectedItems[0].SubItems[1].Text.Trim();
                            oCGabineteCategoria.IdCategoriaGabinete = lstGabinete.SelectedItems[0].SubItems[0].Text.Trim();

                            oCGabineteCategoria.Modificar();
                        }

                        if (!Program.oPersistencia.IsError)
                            tobCancelar_Click(sender, e);
                    }
                }
            }
        }

        private int ObtieneIdGrupo(string pIdCategoria)
        {
            int index = 0;
            index = idCategoria.IndexOf(pIdCategoria);

            return index;
        }

        private void LlenarLista()
        {
            idCategoria.Clear();
            nombreCategoria.Clear();
            lstGabinete.Items.Clear();
            lstGabinete.Groups.Clear();

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Gabinetes_Categoria", "Gabinete_Categoria");
            DataSet ds2 = new DataSet();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ds2 = Program.oPersistencia.ejecutarSQLListas("sp_S_Categorias_Gabinete_Param2 '" + dr[0].ToString().Trim() + "'", "Categoria_Gabinete");

                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            if (!nombreCategoria.Contains(dr2[0].ToString().Trim()))
                            {
                                idCategoria.Add(dr[0].ToString().Trim());
                                nombreCategoria.Add(dr2[0].ToString().Trim());
                            }
                        }
                        ds2 = null;
                    }

                    foreach (string oGrupo in nombreCategoria)
                        lstGabinete.Groups.Add(new ListViewGroup(oGrupo.Trim(), HorizontalAlignment.Left));

                    int index = 0;
                    int linea = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        index = ObtieneIdGrupo(dr[0].ToString().Trim());

                        //Selecciona el nombre y descripcion del Examen
                        ds2 = Program.oPersistencia.ejecutarSQLListas("sp_S_Gabinete_Param2 '" + dr[1].ToString().Trim() + "'", "Gabinete_Categoria");

                        lstGabinete.Items.Add(dr[0].ToString().Trim()).Group = lstGabinete.Groups[index];
                        lstGabinete.Items[linea].SubItems.Add(dr[1].ToString().Trim());

                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            lstGabinete.Items[linea].SubItems.Add(dr2[1].ToString().Trim());
                            lstGabinete.Items[linea].SubItems.Add(dr2[2].ToString().Trim());
                        }

                        linea++;
                    }
                }
            }
            ds2.Dispose();
            ds.Dispose();
        }

        private void ModoBloqueo()
        {
            LlenarLista();

            //tobNuevo.Enabled = true;
            lstGabinete.Enabled = true;

            Metodos_Globales.EjecutaPermisos(tobNuevo, tobModificar, tobEliminar, oArregloPermisos);

            if (tobModificar.Enabled == true || tobEliminar.Enabled == true)
            {
                if (lstGabinete.Items.Count > 0)
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
                else
                {
                    tobModificar.Enabled = false;
                    tobEliminar.Enabled = false;
                }
            }

            //if (lstGabinete.Items.Count > 0)
            //{
            //    tobModificar.Enabled = true;
            //    tobEliminar.Enabled = true;
            //}
            //else
            //{
            //    tobModificar.Enabled = false;
            //    tobEliminar.Enabled = false;
            //}

            tobGuardar.Enabled = false;
            tobCancelar.Enabled = false;
            tobIniciarConsulta.Enabled = true;
            tobEjecutarConsulta.Enabled = false;
            tobCancelarConsulta.Enabled = false;
            tobSalir.Enabled = true;

            tobGuardarCategoria.Enabled = false;

            nuevo = false;
            modificar = false;

            if (lstGabinete.Items.Count == 0)
                toolStripStatusLabel2.Text = "Presione el botón \"Nuevo\" para ingresar un nuevo estudio al Gabinete";
            else
                toolStripStatusLabel2.Text = "Seleccione la fila deseada sobre la cual desea trabajar";
        }

        private void tobCancelar_Click(object sender, EventArgs e)
        {
            LlenarLista();
            ModoBloqueo();
            LimpiaCampos();

            cmbCategorias.Text = "";

            Metodos_Globales.BloquearCampos(this);
            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
        }

        private void tobEliminar_Click(object sender, EventArgs e)
        {
            if (lstGabinete.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "¿Está seguro que desea eliminar los datos seleccionados?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    oCGabineteCategoria.IdGabinete = lstGabinete.SelectedItems[0].SubItems[1].Text.Trim();
                    oCGabineteCategoria.IdCategoriaGabinete = lstGabinete.SelectedItems[0].SubItems[0].Text.Trim();
                    oCGabineteCategoria.AuxId_Categoria_Gabinete = "";

                    oCGabineteCategoria.Eliminar();

                    oCGabinete.IdGabinete = lstGabinete.SelectedItems[0].SubItems[1].Text.Trim();
                    oCGabinete.Nombre = "";
                    oCGabinete.Descripcion = "";

                    oCGabinete.Eliminar();

                    if (!Program.oPersistencia.IsError)
                        tobCancelar_Click(sender, e);
                    else
                    {
                        oCGabineteCategoria.Insertar();//si da error se reinsertar el gabinete por categoría que se había eliminado previamente
                        tobCancelar_Click(sender, e);
                    }
                }
            }
            else
                MessageBox.Show(this, "Debe de seleccionar el estudio deseado de la lista disponible para poder continuar con estas acciones.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tobIniciarConsulta_Click(object sender, EventArgs e)
        {
            nuevo = false;
            modificar = false;

            Metodos_Globales.DesbloquearCampos(this);
            Metodos_Globales.EstableceFoco(txtNombre);
            LimpiaCampos();
            Metodos_Globales.ModoConsulta(toolStrip1);

            tobGuardarCategoria.Enabled = true;
            
            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
        }

        private void LlenarListaConsulta(DataSet ds)
        {
            idCategoria.Clear();
            nombreCategoria.Clear();
            lstGabinete.Items.Clear();
            lstGabinete.Groups.Clear();

            DataSet ds2 = new DataSet();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ds2 = Program.oPersistencia.ejecutarSQLListas("sp_S_Categorias_Gabinete_Param2 '" + dr[0].ToString().Trim() + "'", "Categoria_Gabinete");

                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            if (!nombreCategoria.Contains(dr2[0].ToString().Trim()))
                            {
                                idCategoria.Add(dr[0].ToString().Trim());
                                nombreCategoria.Add(dr2[0].ToString().Trim());
                            }
                        }
                        ds2 = null;
                    }

                    foreach (string oGrupo in nombreCategoria)
                        lstGabinete.Groups.Add(new ListViewGroup(oGrupo.Trim(), HorizontalAlignment.Left));

                    int index = 0;
                    int linea = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        index = ObtieneIdGrupo(dr[0].ToString().Trim());

                        //Selecciona el nombre y descripcion del Examen
                        ds2 = Program.oPersistencia.ejecutarSQLListas("sp_S_Gabinete_Param2 '" + dr[1].ToString().Trim() + "'", "Gabinete_Categoria");

                        lstGabinete.Items.Add(dr[0].ToString().Trim()).Group = lstGabinete.Groups[index];
                        lstGabinete.Items[linea].SubItems.Add(dr[1].ToString().Trim());

                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            lstGabinete.Items[linea].SubItems.Add(dr2[1].ToString().Trim());
                            lstGabinete.Items[linea].SubItems.Add(dr2[2].ToString().Trim());
                        }

                        linea++;
                    }
                }
            }
            ds2.Dispose();
        }

        private void tobEjecutarConsulta_Click(object sender, EventArgs e)
        {
            #region Establece valores en la clase de Gabinete por Categorías

            if (cmbCategorias.SelectedValue != null)
                oCGabineteCategoria.IdCategoriaGabinete = cmbCategorias.SelectedValue.ToString().Trim();
            else
                oCGabineteCategoria.IdCategoriaGabinete = "";

            if (TxtDescripcion.Text.Trim() != "")
                oCGabineteCategoria.Descripcion = TxtDescripcion.Text.Trim();
            else
                oCGabineteCategoria.Descripcion = "";

            if (txtNombre.Text.Trim() != "")
                oCGabineteCategoria.Nombre = txtNombre.Text.Trim();
            else
                oCGabineteCategoria.Nombre = "";

            #endregion

            DataSet ds = oCGabineteCategoria.ConsultarConParametros(oCGabineteCategoria.IdCategoriaGabinete.Trim(), oCGabineteCategoria.Descripcion.Trim(), oCGabineteCategoria.Nombre.Trim());
            LlenarListaConsulta(ds);

            if (ds != null)
            {
                ds.Dispose();
                oCGabineteCategoria.ConsultarConParametros(oCGabineteCategoria.IdCategoriaGabinete.Trim(), oCGabineteCategoria.Descripcion.Trim(), oCGabineteCategoria.Nombre.Trim()).Dispose();
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

        private void LlenaComboCategorias()
        {
            cmbCategorias.DataSource = null;
            Metodos_Globales.LlenarCombo(cmbCategorias, "sp_S_Categorias_Gabinete", "Categorias_Gabinete", "id_categoria_gabinete", "descripcion");
        }

        private void GuardarNuevaCategoria()
        {
            oCCategoriasGabinete.Descripcion = cmbCategorias.Text.Trim();

            oCCategoriasGabinete.Insertar();
            LlenaComboCategorias();
            cmbCategorias.SelectedIndex = cmbCategorias.Items.Count - 1;

            if (Program.oPersistencia.IsError == false)
                MessageBox.Show(this, "La categoría \"" + cmbCategorias.Text.Trim() + " \" fue almacenada correctamente en la base de datos del sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tobGuardarCategoria_Click(object sender, EventArgs e)
        {
            if (cmbCategorias.Text.Trim() != "")
            {
                if (oCCategoriasGabinete.DeterminaCategoriaRepetida(cmbCategorias.Text.Trim()) == false)
                {
                    GuardarNuevaCategoria();
                }
                else
                    MessageBox.Show(this, "La categoría ya existe entre la lista disponible, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmbCategorias_Leave(object sender, EventArgs e)
        {
            if (nuevo == true || modificar == true)
            {
                if (oCCategoriasGabinete.DeterminaCategoriaRepetida(cmbCategorias.Text.Trim()) == false)
                {
                    if (MessageBox.Show(this, "La categoría ingresada no existe actualmente en la base de datos, ¿Desea ingresarla a la lista de Métodos Anticonceptivos del sistema?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        GuardarNuevaCategoria();
                    else
                        cmbCategorias.SelectedIndex = -1;
                }
            }
        }

        private void frmGabinete_Load(object sender, EventArgs e)
        {
            LlenaComboCategorias();

            oArregloPermisos = oCPermisosEspeciales.LeePermisos(MDIPrincipal.RolUsuario.Trim(), this.Tag.ToString().Trim());

            tobCancelar_Click(sender, e);

            try
            {
                VistaConstants.SetWindowTheme(lstGabinete.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstGabinete.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
            }
            catch { }
        }

        private void LimpiaCampos()
        {
            txtNombre.Text = "";
            TxtDescripcion.Text = "";
            cmbCategorias.SelectedIndex = -1;
        }

        private void lstGabinete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGabinete.SelectedItems.Count > 0)
            {
                txtNombre.Text = lstGabinete.SelectedItems[0].SubItems[2].Text.Trim();
                TxtDescripcion.Text = lstGabinete.SelectedItems[0].SubItems[3].Text.Trim();
                cmbCategorias.SelectedValue = lstGabinete.SelectedItems[0].SubItems[0].Text.Trim();
            }
            else
                LimpiaCampos();
        }

        private void tobModificarCategoria_Click(object sender, EventArgs e)
        {
            FrmBlackBackground ofrm = new FrmBlackBackground();
            ofrm.Show(); 
            frmCategoriasGabinete ofrmCategoriasGabinete = new frmCategoriasGabinete();
            ofrmCategoriasGabinete.ShowDialog();
            ofrm.Close();

            LlenaComboCategorias();

            if (lstGabinete.SelectedItems.Count > 0)
                lstGabinete_SelectedIndexChanged(sender, e);
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Ingrese el nombre del estudio correspondiente";
        }

        private void TxtDescripcion_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Ingrese una descripción rápida del estudio";
        }

        private void cmbCategorias_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Seleccione o ingrese una categoría para asignar al estudio";
        }

        private void frmGabinete_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.oFrmConsultas != null)
            {
                if (Program.oFrmConsultas.Activo == true)
                {
                    if (Program.oFrmConsultas.modificar == false)
                        Program.oFrmConsultas.LlenarLista(true);
                    else
                    {
                        Program.oFrmConsultas.LlenarLista(false);
                        Program.oFrmConsultas.SeñalaGabinetesSeleccionados_Modificacion();
                    }
                }
            }
        }
    }
}