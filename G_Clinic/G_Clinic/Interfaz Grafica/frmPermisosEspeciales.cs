using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using G_Clinic.Lógica_Negocios;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmPermisosEspeciales : Form
    {
        public frmPermisosEspeciales()
        {
            InitializeComponent();

            this.Region = Shape.RoundedRegion(this.Size, 8, Shape.Corner.None);
        }

        #region Variables y Arreglos

        ArrayList oArregloCatEmpleados = new ArrayList();
        ArrayList oArregloTiposContactos = new ArrayList();
        ArrayList oArregloMetodosAnticonceptivos = new ArrayList();
        ArrayList oArregloGabinete = new ArrayList();
        ArrayList oArregloExamenesLaboratorio = new ArrayList();
        ArrayList oArregloHistoriaClinica = new ArrayList();

        ArrayList oArregloOpciones = new ArrayList();

        bool agregar = false;
        bool modificar = false;
        bool eliminar = false;

        CPermisosEspeciales oCPermisosEspeciales = new CPermisosEspeciales();

        bool opening = true;

        #endregion

        private void HabilitaUnicaOpcionSeleccionada(object sender)
        {
            ToolStripButton oButton = new ToolStripButton();
            string oTag = "";
            int index = 0;

            if (sender is ToolStripButton)
            {
                oButton = (ToolStripButton)sender;
                oTag = oButton.Tag.ToString().Trim();
            }

            if (oTag != "" && oTag != null)
            {
                foreach (ToolStripItem oItem in toolStrip2.Items)
                {
                    if (oItem is ToolStripButton)
                    {
                        if (oItem.Tag.ToString() == oTag)
                            break;
                    }
                    index++;
                }
            }

            if (tobCategoriasEmpleados.Tag.ToString() != oTag)
            {
                if (tobCategoriasEmpleados.Checked == true)
                    tobCategoriasEmpleados.Checked = false;
            }

            if (tobTiposContactos.Tag.ToString() != oTag)
            {
                if (tobTiposContactos.Checked == true)
                    tobTiposContactos.Checked = false;
            }

            if (tobMetodosAnticonceptivos.Tag.ToString() != oTag)
            {
                if (tobMetodosAnticonceptivos.Checked == true)
                    tobMetodosAnticonceptivos.Checked = false;
            }

            if (tobGabinete.Tag.ToString() != oTag)
            {
                if (tobGabinete.Checked == true)
                    tobGabinete.Checked = false;
            }

            if (tobExamenesLaboratorio.Tag.ToString() != oTag)
            {
                if (tobExamenesLaboratorio.Checked == true)
                    tobExamenesLaboratorio.Checked = false;
            }

            if (tobHistoriaClinica.Tag.ToString() != oTag)
            {
                if (tobHistoriaClinica.Checked == true)
                {
                    tobHistoriaClinica.Checked = false;
                    labelInfo.Visible = false;
                }
            }
        }

        private void InicializaArreglos()
        {
            tobNuevo.Checked = false;
            tobModificar.Checked = false;
            tobEliminar.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;

            LlenaArregloAuxiliar();

            foreach (ToolStripItem oItem in toolStrip2.Items)
            {
                if (oItem is ToolStripButton)
                {
                    if (oItem.Tag.ToString() == "Categorias_de_Empleados")
                        oArregloCatEmpleados = oCPermisosEspeciales.LeePermisos(cmbRol.Text.Trim(), oItem.Tag.ToString().Trim());
                    else if (oItem.Tag.ToString() == "Tipos_de_Contactos")
                        oArregloTiposContactos = oCPermisosEspeciales.LeePermisos(cmbRol.Text.Trim(), oItem.Tag.ToString().Trim());
                    else if (oItem.Tag.ToString() == "Métodos_Anticonceptivos")
                        oArregloMetodosAnticonceptivos = oCPermisosEspeciales.LeePermisos(cmbRol.Text.Trim(), oItem.Tag.ToString().Trim());
                    else if (oItem.Tag.ToString() == "Gabinete")
                        oArregloGabinete = oCPermisosEspeciales.LeePermisos(cmbRol.Text.Trim(), oItem.Tag.ToString().Trim());
                    else if (oItem.Tag.ToString() == "Examenes_de_Laboratorio")
                        oArregloExamenesLaboratorio = oCPermisosEspeciales.LeePermisos(cmbRol.Text.Trim(), oItem.Tag.ToString().Trim());
                    else if (oItem.Tag.ToString() == "Historia_Clínica")
                        oArregloHistoriaClinica = oCPermisosEspeciales.LeePermisos(cmbRol.Text.Trim(), oItem.Tag.ToString().Trim());
                }
            }

            if (oArregloCatEmpleados.Count == 5)
            {
                checkBox1.Checked = (bool)oArregloCatEmpleados[3];
                checkBox2.Checked = (bool)oArregloCatEmpleados[4];
            }
        }

        private void Cargar_Combos()
        {
            DataSet dt1 = Program.oPersistencia.ejecutarSQLListas("Select 'RoleName' = name, 'RoleId' = uid, 'IsAppRole' = isapprole from sysusers where (issqlrole = 1 and name != 'public' and name != 'db_owner' and name != 'db_accessadmin' and name != 'db_securityadmin' and name != 'db_ddladmin' and name != 'db_backupoperator' and name != 'db_datareader' and name != 'db_datawriter' and name != 'db_denydatareader' and name != 'db_denydatawriter')  order by RoleName", "db");
            // Verifico el Error
            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                return;
            }

            // llena el combo
            this.cmbRol.DataSource = dt1.Tables["db"];
            this.cmbRol.DisplayMember = dt1.Tables["db"].Columns[0].ToString();
            this.cmbRol.ValueMember = dt1.Tables["db"].Columns[0].ToString();

            dt1.Dispose();
        }

        private void frmPermisosEspeciales_Load(object sender, EventArgs e)
        {
            Cargar_Combos();
            InicializaArreglos();

            tobCategoriasEmpleados.Checked = true;
            tobCategoriasEmpleados_Click(sender, e);
            opening = false;
        }

        private void tobCategoriasEmpleados_Click(object sender, EventArgs e)
        {
            if (opening == false)
                HabilitaUnicaOpcionSeleccionada(sender);

            if (tobCategoriasEmpleados.Checked == true)
            {
                LlenaArregloAuxiliar();

                for (int i = 0; i < oArregloCatEmpleados.Count; )
                {
                    oArregloOpciones[i] = oArregloCatEmpleados[i];
                    i++;
                }

                tobNuevo.Checked = (bool)oArregloOpciones[0];
                tobModificar.Checked = (bool)oArregloOpciones[1];
                tobEliminar.Checked = (bool)oArregloOpciones[2];
            }
        }

        private void tobTiposContactos_Click(object sender, EventArgs e)
        {
            HabilitaUnicaOpcionSeleccionada(sender);

            if (tobTiposContactos.Checked == true)
            {
                LlenaArregloAuxiliar();

                for (int i = 0; i < oArregloTiposContactos.Count; )
                {
                    oArregloOpciones[i] = oArregloTiposContactos[i];
                    i++;
                }

                tobNuevo.Checked = (bool)oArregloOpciones[0];
                tobModificar.Checked = (bool)oArregloOpciones[1];
                tobEliminar.Checked = (bool)oArregloOpciones[2];
            }
        }

        private void tobMetodosAnticonceptivos_Click(object sender, EventArgs e)
        {
            HabilitaUnicaOpcionSeleccionada(sender);

            if (tobMetodosAnticonceptivos.Checked == true)
            {
                LlenaArregloAuxiliar();

                for (int i = 0; i < oArregloMetodosAnticonceptivos.Count; )
                {
                    oArregloOpciones[i] = oArregloMetodosAnticonceptivos[i];
                    i++;
                }

                tobNuevo.Checked = (bool)oArregloOpciones[0];
                tobModificar.Checked = (bool)oArregloOpciones[1];
                tobEliminar.Checked = (bool)oArregloOpciones[2];
            }
        }

        private void tobGabinete_Click(object sender, EventArgs e)
        {
            HabilitaUnicaOpcionSeleccionada(sender);

            if (tobGabinete.Checked == true)
            {
                LlenaArregloAuxiliar();

                for (int i = 0; i < oArregloGabinete.Count; )
                {
                    oArregloOpciones[i] = oArregloGabinete[i];
                    i++;
                }

                tobNuevo.Checked = (bool)oArregloOpciones[0];
                tobModificar.Checked = (bool)oArregloOpciones[1];
                tobEliminar.Checked = (bool)oArregloOpciones[2];
            }
        }

        private void tobExamenesLaboratorio_Click(object sender, EventArgs e)
        {
            HabilitaUnicaOpcionSeleccionada(sender);

            if (tobExamenesLaboratorio.Checked == true)
            {
                LlenaArregloAuxiliar();

                for (int i = 0; i < oArregloExamenesLaboratorio.Count; )
                {
                    oArregloOpciones[i] = oArregloExamenesLaboratorio[i];
                    i++;
                }

                tobNuevo.Checked = (bool)oArregloOpciones[0];
                tobModificar.Checked = (bool)oArregloOpciones[1];
                tobEliminar.Checked = (bool)oArregloOpciones[2];
            }
        }

        private void LlenaArregloAuxiliar()
        {
            if (oArregloOpciones.Count == 0)
            {
                oArregloOpciones.Add(false);
                oArregloOpciones.Add(false);
                oArregloOpciones.Add(false);
                oArregloOpciones.Add(false);
                oArregloOpciones.Add(false);
            }
        }

        private void tobHistoriaClinica_Click(object sender, EventArgs e)
        {
            HabilitaUnicaOpcionSeleccionada(sender);

            if (tobHistoriaClinica.Checked == true)
            {
                labelInfo.Visible = true;
                LlenaArregloAuxiliar();

                for (int i = 0; i < oArregloHistoriaClinica.Count; )
                {
                    oArregloOpciones[i] = oArregloHistoriaClinica[i];
                    i++;
                }

                tobNuevo.Checked = (bool)oArregloOpciones[0];
                tobModificar.Checked = (bool)oArregloOpciones[1];
                tobEliminar.Checked = (bool)oArregloOpciones[2];
            }
        }

        private void ActualizaArreglos()
        {
            if (tobCategoriasEmpleados.Checked == true)
            {
                //oArregloCatEmpleados.Clear();

                oArregloCatEmpleados[0] = oArregloOpciones[0];
                oArregloCatEmpleados[1] = oArregloOpciones[1];
                oArregloCatEmpleados[2] = oArregloOpciones[2];
            }
            else if (tobTiposContactos.Checked == true)
            {
                //oArregloTiposContactos.Clear();

                oArregloTiposContactos[0] = oArregloOpciones[0];
                oArregloTiposContactos[1] = oArregloOpciones[1];
                oArregloTiposContactos[2] = oArregloOpciones[2];
            }
            else if (tobMetodosAnticonceptivos.Checked == true)
            {
                //oArregloMetodosAnticonceptivos.Clear();

                oArregloMetodosAnticonceptivos[0] = oArregloOpciones[0];
                oArregloMetodosAnticonceptivos[1] = oArregloOpciones[1];
                oArregloMetodosAnticonceptivos[2] = oArregloOpciones[2];
            }
            else if (tobGabinete.Checked == true)
            {
                //oArregloGabinete.Clear();

                oArregloGabinete[0] = oArregloOpciones[0];
                oArregloGabinete[1] = oArregloOpciones[1];
                oArregloGabinete[2] = oArregloOpciones[2];
            }
            else if (tobExamenesLaboratorio.Checked == true)
            {
                //oArregloExamenesLaboratorio.Clear();

                oArregloExamenesLaboratorio[0] = oArregloOpciones[0];
                oArregloExamenesLaboratorio[1] = oArregloOpciones[1];
                oArregloExamenesLaboratorio[2] = oArregloOpciones[2];
            }
            else if (tobHistoriaClinica.Checked == true)
            {
                //oArregloHistoriaClinica.Clear();

                oArregloHistoriaClinica[0] = oArregloOpciones[0];
                oArregloHistoriaClinica[1] = oArregloOpciones[1];
                oArregloHistoriaClinica[2] = oArregloOpciones[2];
            }
        }

        private void tobNuevo_Click(object sender, EventArgs e)
        {
            if (tobNuevo.Checked == true)
                agregar = true;
            else
                agregar = false;

            oArregloOpciones[0] = (bool)agregar;

            ActualizaArreglos();
        }

        private void tobModificar_Click(object sender, EventArgs e)
        {
            if (tobModificar.Checked == true)
                modificar = true;
            else
                modificar = false;

            oArregloOpciones[1] = (bool)modificar;

            ActualizaArreglos();
        }

        private void tobEliminar_Click(object sender, EventArgs e)
        {
            if (tobEliminar.Checked == true)
                eliminar = true;
            else
                eliminar = false;

            oArregloOpciones[2] = (bool)eliminar;

            ActualizaArreglos();
        }

        private void btnListo_Click(object sender, EventArgs e)
        {
            if (cmbRol.Text != "Administrador")
            {
                oCPermisosEspeciales.Rol = cmbRol.Text.Trim();

                #region Elimina los registros primero

                oCPermisosEspeciales.IdMenu = "Categorias_de_Empleados";
                oCPermisosEspeciales.Eliminar_Metodo();

                oCPermisosEspeciales.IdMenu = "Tipos_de_Contactos";
                oCPermisosEspeciales.Eliminar_Metodo();

                oCPermisosEspeciales.IdMenu = "Métodos_Anticonceptivos";
                oCPermisosEspeciales.Eliminar_Metodo();

                oCPermisosEspeciales.IdMenu = "Gabinete";
                oCPermisosEspeciales.Eliminar_Metodo();

                oCPermisosEspeciales.IdMenu = "Examenes_de_Laboratorio";
                oCPermisosEspeciales.Eliminar_Metodo();

                oCPermisosEspeciales.IdMenu = "Historia_Clínica";
                oCPermisosEspeciales.Eliminar_Metodo();

                #endregion

                #region Guarda los datos de todos

                oCPermisosEspeciales.IdMenu = "Categorias_de_Empleados";
                oCPermisosEspeciales.Agregar = (bool)oArregloCatEmpleados[0];
                oCPermisosEspeciales.Modificar = (bool)oArregloCatEmpleados[1];
                oCPermisosEspeciales.Eliminar = (bool)oArregloCatEmpleados[2];
                oCPermisosEspeciales.SolicitudAdmin = checkBox1.Checked;
                oCPermisosEspeciales.PermisoHistoriaClinica = checkBox2.Checked;

                oCPermisosEspeciales.Insertar();

                oCPermisosEspeciales.IdMenu = "Tipos_de_Contactos";
                oCPermisosEspeciales.Agregar = (bool)oArregloTiposContactos[0];
                oCPermisosEspeciales.Modificar = (bool)oArregloTiposContactos[1];
                oCPermisosEspeciales.Eliminar = (bool)oArregloTiposContactos[2];
                oCPermisosEspeciales.SolicitudAdmin = checkBox1.Checked;
                oCPermisosEspeciales.PermisoHistoriaClinica = checkBox2.Checked;

                oCPermisosEspeciales.Insertar();

                oCPermisosEspeciales.IdMenu = "Métodos_Anticonceptivos";
                oCPermisosEspeciales.Agregar = (bool)oArregloMetodosAnticonceptivos[0];
                oCPermisosEspeciales.Modificar = (bool)oArregloMetodosAnticonceptivos[1];
                oCPermisosEspeciales.Eliminar = (bool)oArregloMetodosAnticonceptivos[2];
                oCPermisosEspeciales.SolicitudAdmin = checkBox1.Checked;
                oCPermisosEspeciales.PermisoHistoriaClinica = checkBox2.Checked;

                oCPermisosEspeciales.Insertar();

                oCPermisosEspeciales.IdMenu = "Gabinete";
                oCPermisosEspeciales.Agregar = (bool)oArregloGabinete[0];
                oCPermisosEspeciales.Modificar = (bool)oArregloGabinete[1];
                oCPermisosEspeciales.Eliminar = (bool)oArregloGabinete[2];
                oCPermisosEspeciales.SolicitudAdmin = checkBox1.Checked;
                oCPermisosEspeciales.PermisoHistoriaClinica = checkBox2.Checked;

                oCPermisosEspeciales.Insertar();

                oCPermisosEspeciales.IdMenu = "Examenes_de_Laboratorio";
                oCPermisosEspeciales.Agregar = (bool)oArregloExamenesLaboratorio[0];
                oCPermisosEspeciales.Modificar = (bool)oArregloExamenesLaboratorio[1];
                oCPermisosEspeciales.Eliminar = (bool)oArregloExamenesLaboratorio[2];
                oCPermisosEspeciales.SolicitudAdmin = checkBox1.Checked;
                oCPermisosEspeciales.PermisoHistoriaClinica = checkBox2.Checked;

                oCPermisosEspeciales.Insertar();

                oCPermisosEspeciales.IdMenu = "Historia_Clínica";
                oCPermisosEspeciales.Agregar = (bool)oArregloHistoriaClinica[0];
                oCPermisosEspeciales.Modificar = (bool)oArregloHistoriaClinica[1];
                oCPermisosEspeciales.Eliminar = (bool)oArregloHistoriaClinica[2];
                oCPermisosEspeciales.SolicitudAdmin = checkBox1.Checked;
                oCPermisosEspeciales.PermisoHistoriaClinica = checkBox2.Checked;

                oCPermisosEspeciales.Insertar();

                #endregion

                if (Program.oPersistencia.IsError == false)
                    MessageBox.Show(this, "Los permisos de usuario han sido establecidos de forma satisfactoria", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show(this, "No se puede agregar \"Permisos Especiales\" a los usuarios administradores puesto que estos poseen todos los permisos necesarios para desempeñarse en el sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRol.SelectedIndex == cmbRol.FindStringExact("Administrador"))
                MessageBox.Show(this, "El usuario \"Administrador\" posee todos los permisos, por lo que no podrá asignar ningún tipo de permiso especial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            InicializaArreglos();

            opening = true;
            tobCategoriasEmpleados.Checked = true;
            tobCategoriasEmpleados_Click(sender, e);
            opening = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            InicializaArreglos();

            opening = true;
            tobCategoriasEmpleados.Checked = true;
            tobCategoriasEmpleados_Click(sender, e);
            opening = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}