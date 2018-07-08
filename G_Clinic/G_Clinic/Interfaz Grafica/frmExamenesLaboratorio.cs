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
    public partial class frmExamenesLaboratorio : Form
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

        CExamenes oCExamenes = new CExamenes();
        CCategoriasExamenes oCCategoriasExamenes = new CCategoriasExamenes();
        CExamenesCategoria oCExamenesCategoria = new CExamenesCategoria();

        ArrayList nombreCategoria = new ArrayList();
        ArrayList idCategoria = new ArrayList();

        CPermisosEspeciales oCPermisosEspeciales = new CPermisosEspeciales();
        ArrayList oArregloPermisos = new ArrayList();

        #endregion

        public frmExamenesLaboratorio()
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
                MessageBox.Show(this, "Debe de seleccionar el examen deseado de la lista disponible para poder modificar sus valores.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private bool VerificaCampos()
        {
            bool continuar = true;

            if (txtNombre.Text.Trim() == "")
            {
                continuar = false;
                MessageBox.Show(this, "El nombre del examen no puede estar en blanco, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
            }

            if (cmbCategorias.SelectedIndex == -1)
            {
                continuar = false;
                MessageBox.Show(this, "Debe seleccionar la categoría a la que pertenecerá el examen descrito, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            oCExamenes.IdExamen = "";
                            oCExamenes.Nombre = txtNombre.Text.Trim();
                            oCExamenes.Descripcion = TxtDescripcion.Text.Trim();

                            oCExamenes.Insertar();//Primero inserta el Gabinete

                            oCExamenesCategoria.IdExamen = oCExamenes.Max_Examen();
                            oCExamenesCategoria.IdCategoriaExamen = cmbCategorias.SelectedValue.ToString().Trim();

                            oCExamenesCategoria.Insertar();//Luego inserte el Gabinete por categoría
                        }
                        else if (modificar == true)
                        {
                            oCExamenes.IdExamen = lstGabinete.SelectedItems[0].SubItems[1].Text.Trim();
                            oCExamenes.Nombre = txtNombre.Text.Trim();
                            oCExamenes.Descripcion = TxtDescripcion.Text.Trim();

                            oCExamenes.Modificar();//Primero modifica los valores del gabinete

                            oCExamenesCategoria.AuxId_Categoria_Examen = cmbCategorias.SelectedValue.ToString().Trim();
                            oCExamenesCategoria.IdExamen = lstGabinete.SelectedItems[0].SubItems[1].Text.Trim();
                            oCExamenesCategoria.IdCategoriaExamen = lstGabinete.SelectedItems[0].SubItems[0].Text.Trim();

                            oCExamenesCategoria.Modificar();
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
            try
            {
                idCategoria.Clear();
                nombreCategoria.Clear();
                lstGabinete.Items.Clear();
                lstGabinete.Groups.Clear();

                DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Examenes_Categoria", "Examenes_Categoria");
                DataSet ds2 = new DataSet();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            ds2 = Program.oPersistencia.ejecutarSQLListas("sp_S_Categorias_Examenes_Param2 '" + dr[1].ToString().Trim() + "'", "Categorias_Examenes");

                            foreach (DataRow dr2 in ds2.Tables[0].Rows)
                            {
                                if (!nombreCategoria.Contains(dr2[0].ToString().Trim()))
                                {
                                    idCategoria.Add(dr[1].ToString().Trim());
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
                            index = ObtieneIdGrupo(dr[1].ToString().Trim());

                            //Selecciona el nombre y descripcion del Examen
                            ds2 = Program.oPersistencia.ejecutarSQLListas("sp_S_Examenes_Param2 '" + dr[0].ToString().Trim() + "'", "Examenes_Categoria");

                            lstGabinete.Items.Add(dr[1].ToString().Trim()).Group = lstGabinete.Groups[index];
                            lstGabinete.Items[linea].SubItems.Add(dr[0].ToString().Trim());

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
            catch { }
        }

        private void ModoBloqueo()
        {
            LlenarLista();

            lstGabinete.Enabled = true;
            //tobNuevo.Enabled = true;

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
                toolStripStatusLabel2.Text = "Presione el botón \"Nuevo\" para ingresar un nuevo examen a la lista";
            else
                toolStripStatusLabel2.Text = "Seleccione la fila deseada sobre la cual desea trabajar";
        }

        private void tobCancelar_Click(object sender, EventArgs e)
        {
            //LlenarLista();
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
                    oCExamenesCategoria.IdExamen = lstGabinete.SelectedItems[0].SubItems[1].Text.Trim();
                    oCExamenesCategoria.IdCategoriaExamen = lstGabinete.SelectedItems[0].SubItems[0].Text.Trim();
                    oCExamenesCategoria.AuxId_Categoria_Examen = "";

                    oCExamenesCategoria.Eliminar();

                    oCExamenes.IdExamen = lstGabinete.SelectedItems[0].SubItems[1].Text.Trim();
                    oCExamenes.Nombre = "";
                    oCExamenes.Descripcion = "";

                    oCExamenes.Eliminar();

                    if (!Program.oPersistencia.IsError)
                        tobCancelar_Click(sender, e);
                    else
                    {
                        oCExamenesCategoria.Insertar();//si da error se reinsertar el examen por categoría que se había eliminado previamente
                        tobCancelar_Click(sender, e);
                    }
                }
            }
            else
                MessageBox.Show(this, "Debe de seleccionar el examen deseado de la lista disponible para poder continuar con estas acciones.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        ds2 = Program.oPersistencia.ejecutarSQLListas("sp_S_Categorias_Examenes_Param2 '" + dr[0].ToString().Trim() + "'", "Categorias_Examenes");

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
                        ds2 = Program.oPersistencia.ejecutarSQLListas("sp_S_Examenes_Param2 '" + dr[1].ToString().Trim() + "'", "Examenes_Categoria");

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
                oCExamenesCategoria.IdCategoriaExamen = cmbCategorias.SelectedValue.ToString().Trim();
            else
                oCExamenesCategoria.IdCategoriaExamen = "";

            if (TxtDescripcion.Text.Trim() != "")
                oCExamenesCategoria.Descripcion = TxtDescripcion.Text.Trim();
            else
                oCExamenesCategoria.Descripcion = "";

            if (txtNombre.Text.Trim() != "")
                oCExamenesCategoria.Nombre = txtNombre.Text.Trim();
            else
                oCExamenesCategoria.Nombre = "";

            #endregion

            DataSet ds = oCExamenesCategoria.ConsultarConParametros(oCExamenesCategoria.IdCategoriaExamen.Trim(), oCExamenesCategoria.Descripcion.Trim(), oCExamenesCategoria.Nombre.Trim());
            LlenarListaConsulta(ds);

            if (ds != null)
            {
                ds.Dispose();
                oCExamenesCategoria.ConsultarConParametros(oCExamenesCategoria.IdCategoriaExamen.Trim(), oCExamenesCategoria.Descripcion.Trim(), oCExamenesCategoria.Nombre.Trim()).Dispose();
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
            Metodos_Globales.LlenarCombo(cmbCategorias, "sp_S_Categorias_Examenes", "Categorias_Examenes", "id_categoria_examen", "descripcion");
        }

        private void GuardarNuevaCategoria()
        {
            oCCategoriasExamenes.Descripcion = cmbCategorias.Text.Trim();

            oCCategoriasExamenes.Insertar();
            LlenaComboCategorias();
            cmbCategorias.SelectedIndex = cmbCategorias.Items.Count - 1;

            if (Program.oPersistencia.IsError == false)
                MessageBox.Show(this, "La categoría \"" + cmbCategorias.Text.Trim() + " \" fue almacenada correctamente en la base de datos del sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tobGuardarCategoria_Click(object sender, EventArgs e)
        {
            if (cmbCategorias.Text.Trim() != "")
            {
                if (oCCategoriasExamenes.DeterminaCategoriaRepetida(cmbCategorias.Text.Trim()) == false)
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
                if (oCCategoriasExamenes.DeterminaCategoriaRepetida(cmbCategorias.Text.Trim()) == false)
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
            frmCategoriasExamenes ofrmCategoriasExamenes = new frmCategoriasExamenes();
            ofrmCategoriasExamenes.ShowDialog();
            ofrm.Close();

            LlenaComboCategorias();

            if (lstGabinete.SelectedItems.Count > 0)
                lstGabinete_SelectedIndexChanged(sender, e);
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Ingrese el nombre del examen correspondiente";
        }

        private void TxtDescripcion_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Ingrese una descripción rápida del examen";
        }

        private void cmbCategorias_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Seleccione o ingrese una categoría para asignar al examen";
        }

        private void frmExamenesLaboratorio_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.oFrmConsultas != null)
            {
                if (Program.oFrmConsultas.Activo == true)
                {
                    if (Program.oFrmConsultas.modificar == false)
                        Program.oFrmConsultas.LlenarListaExamenes(true);
                    else
                    {
                        Program.oFrmConsultas.LlenarListaExamenes(false);
                        Program.oFrmConsultas.SeñalaExamenesSeleccionados_Modificacion();
                    }
                }
            }
        }
    }
}