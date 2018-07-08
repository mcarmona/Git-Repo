using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic
{
    public partial class FrmMenusXRol : Form
    {
        public FrmMenusXRol()
        {
            InitializeComponent();
        }

        bool Nuevo = false;
        bool Actualizar = false;
        bool Eliminar = false;
        int Linea = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            LstDestino.Items.Clear();
            if (LstDestino.Items.Count > 0)
            {
                for (int i = 0; i < LstOrigen.Items.Count; i++)
                {
                    foreach (ListViewItem Item in LstDestino.Items)
                    {
                        if (Item.SubItems[1].Text != null)
                        {
                            if (LstOrigen.Items[i].Text.Trim() != Item.Text.ToString())
                            {
                                LstDestino.Items.Add(LstOrigen.Items[i].Text.ToString());
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < LstOrigen.Items.Count; i++)
                {
                    LstDestino.Items.Add(LstOrigen.Items[i].Text.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (LstDestino.SelectedItems.Count > 0)
            {
                LstDestino.SelectedItems[0].Remove();
            }
        }

        private void ModoBloqueo()
        {
            tobNuevo.Enabled = true;
            tobGuardar.Enabled = false;
            tobCancelar.Enabled = false;
            tobSalir.Enabled = true;

            cmbRol.Enabled = true;

            LstOrigen.Enabled = true;
            LstDestino.Enabled = true;

            BtnAgregaTodo.Enabled = false;
            BtnAgregaUno.Enabled = false;
            BtnQuitaTodo.Enabled = false;
            BtnQuitaUno.Enabled = false;

            int linea = 0;

            LstDestino.Items.Clear();

            SqlDataReader dr = Program.oPersistencia.ejecutarConsultaSQL("select idmenu from rolesXmenu where roldb = '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(cmbRol.Text) + "'");
            // Verifico el Error
            if (Program.oPersistencia.IsError == true)
            {
                return;
            }

            while (dr.Read())
            {
                this.LstDestino.Items.Add(dr.GetValue(0).ToString().Trim());
                linea = linea + 1;
            }

            dr.Dispose();//Cierra el datareader

            if (LstDestino.Items.Count > 0)
            {
                tobModificar.Enabled = true;
            }

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
        }

        private void ModoEscritura()
        {
            tobNuevo.Enabled = false;
            tobModificar.Enabled = false;
            tobGuardar.Enabled = true;
            tobCancelar.Enabled = true;
            tobSalir.Enabled = true;

            cmbRol.Enabled = true;

            LstOrigen.Enabled = true;
            LstDestino.Enabled = true;

            BtnAgregaTodo.Enabled = true;
            BtnAgregaUno.Enabled = true;
            BtnQuitaTodo.Enabled = true;
            BtnQuitaUno.Enabled = true;

            LstDestino.Items.Clear();

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
        }

        private void ModoModificar()
        {
            tobNuevo.Enabled = false;
            tobModificar.Enabled = false;
            tobGuardar.Enabled = true;
            tobCancelar.Enabled = true;
            tobSalir.Enabled = true;

            cmbRol.Enabled = false;

            LstOrigen.Enabled = true;
            LstDestino.Enabled = true;

            BtnAgregaTodo.Enabled = true;
            BtnAgregaUno.Enabled = true;
            BtnQuitaTodo.Enabled = true;
            BtnQuitaUno.Enabled = true;

            Metodos_Globales.BloqueaTeclasRapidas(toolStrip1, menuStrip1);
        }

        private void FrmMenusXRol_Load(object sender, EventArgs e)
        {
            try
            {
                VistaConstants.SetWindowTheme(LstDestino.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(LstDestino.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
                VistaConstants.SetWindowTheme(LstOrigen.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(LstOrigen.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
            }
            catch { }

            Cargar_Combos();

            LstOrigen.View = View.Details;
            LstOrigen.Columns.Add("Menús", 250, HorizontalAlignment.Left);

            LstDestino.View = View.Details;
            LstDestino.Columns.Add("Menús", 250, HorizontalAlignment.Left);

            LlenarListaOrigen();

            ModoBloqueo(); 
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

        private void LlenarListaOrigen()
        {
            int linea = 0;

            LstOrigen.Items.Clear();

            SqlDataReader dr = Program.oPersistencia.ejecutarConsultaSQL("select idmenu from menu");
            // Verifico el Error
            if (Program.oPersistencia.IsError == true)
            {
                return;
            }

            while (dr.Read())
            {
                this.LstOrigen.Items.Add(dr.GetValue(0).ToString().Trim());
                linea = linea + 1;

            }

            dr.Dispose();//Cierra el datareader
        }

        private void BtnAgregaUno_Click(object sender, EventArgs e)
        {
            int contador = 0;
            //int Linea 

            if (LstOrigen.SelectedItems.Count > 0)
            {
                if (LstDestino.Items.Count == 0)
                {
                    LstDestino.Items.Add(LstOrigen.SelectedItems[0].Text.ToString().Trim());
                    Linea++;
                }
                else
                {
                    for (int i = 0; i <= LstDestino.Items.Count; i++)
                    {
                        if (LstOrigen.SelectedItems[0].Text.ToString().Trim() != LstDestino.Items[i].Text.ToString())
                        {
                            contador++;
                            if (contador == LstDestino.Items.Count)
                            {
                                LstDestino.Items.Add(LstOrigen.SelectedItems[0].Text.ToString().Trim());
                                Linea++;
                            }
                        }
                        else
                        {
                            i = 0;
                            return;
                        }
                    }
                }
            }
        }

        private void BtnQuitaTodo_Click(object sender, EventArgs e)
        {
            LstDestino.Items.Clear();  
        }

        private void tobSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbRol_SelectedValueChanged(object sender, EventArgs e)
        {
            int linea = 0;

            LstDestino.Items.Clear();

            SqlDataReader dr = Program.oPersistencia.ejecutarConsultaSQL("select idmenu from rolesXmenu where roldb = '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(cmbRol.Text.Trim()) + "'");
            // Verifico el Error
            if (Program.oPersistencia.IsError == true)
            {
                return;
            }

            while (dr.Read())
            {
                this.LstDestino.Items.Add(dr.GetValue(0).ToString().Trim());
                linea = linea + 1;

            }

            dr.Dispose();//Cierra el datareader

            toolStripStatusLabel1.Text = "Agregue o elimine opciones de menú como ud considere\n necesario para modificar el Rol: " + cmbRol.Text + ""; 
        }

        private void tobNuevo_Click(object sender, EventArgs e)
        {
            DataSet dt1 = Program.oPersistencia.ejecutarSQLListas("select idmenu from rolesXmenu where roldb = '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(cmbRol.Text.Trim()) + "'", "rolesXmenu");
            // Verifico el Error
            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                return;
            }
            else
            {
                if (dt1.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(this, "El rol seleccionado ya posee un registro de Menús asignado a él, Intente con un rol al que no se le hayan asignado Menús todavía", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ModoEscritura();
                    toolStripStatusLabel1.Text = "Seleccione las diferentes opciones de menú que desea agregar al Rol: " + cmbRol.Text + ""; 
                    Nuevo = true;
                }
            }            
        }

        private void tobCancelar_Click(object sender, EventArgs e)
        {
            ModoBloqueo();
            Nuevo = false;
            Actualizar = false;
            Eliminar = false;

            toolStripStatusLabel1.Text = "";
        }

        private void tobGuardar_Click(object sender, EventArgs e)
        {
            if (Nuevo == true)
            {
                for (int i = 0; i < LstDestino.Items.Count; i++)
                {
                    StringBuilder Sql = new StringBuilder("");

                    Sql.Append("execute sp_I_RolesXMenu'");
                    Sql.Append(LstDestino.Items[i].Text.ToString().Trim());                    
                    Sql.Append("','");
                    Sql.Append(Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(this.cmbRol.Text.Trim()));
                    Sql.Append("'");

                    // Ejecutar Store Procedure
                    Program.oPersistencia.ejecutarSQLTransaccion(Sql.ToString());

                    // Verifico el Error
                    if (Program.oPersistencia.IsError == true)
                    {
                        MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                    }
                    else
                    {
                        Nuevo = false;
                    }//if
                }
            }

            if (Actualizar == true)
            {

                Program.oPersistencia.ejecutarSQLTransaccion("delete from rolesxmenu where roldb ='" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(cmbRol.Text.Trim())+ "'");

                if (Program.oPersistencia.IsError == true)
                {
                    MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                }
                else
                {
                    for (int i = 0; i < LstDestino.Items.Count; i++)
                    {
                        StringBuilder Sql = new StringBuilder("");

                        Sql.Append("execute sp_I_RolesXMenu'");
                        Sql.Append(LstDestino.Items[i].Text.ToString().Trim());
                        Sql.Append("','");
                        Sql.Append(Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(this.cmbRol.Text.Trim()));
                        Sql.Append("'");

                        // Ejecutar Store Procedure
                        Program.oPersistencia.ejecutarSQLTransaccion(Sql.ToString());

                        // Verifico el Error
                        if (Program.oPersistencia.IsError == true)
                        {
                            MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                        }
                        else
                        {
                            Nuevo = false;
                        }//if
                    }

                    Actualizar = false;
                }//if
            }
            ModoBloqueo();
        }

        private void tobModificar_Click(object sender, EventArgs e)
        {
            Actualizar = true;
            ModoModificar();
            toolStripStatusLabel1.Text = "Agregue o elimine opciones de menú como ud considere\n necesario para modificar el Rol: " + cmbRol.Text + ""; 
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (FrmManual.Abierto == false)
            //{
            //    Program.oFrmManual = new FrmManual();
            //    Program.oFrmManual.Show();

            //    Program.oFrmManual.treeView1.SelectedNode = Program.oFrmManual.treeView1.Nodes[1].Nodes[10].Nodes[1];
            //    FrmManual.oArreglo.Add("1/10/1");
            //    FrmManual.oArreglo2.Add("");
            //    FrmManual.contador++;
            //}
            //else
            //{
            //    //Esto permite que el form abierto su muestre sobre el form modal
            //    Program.oFrmManual.Hide();
            //    Program.oFrmManual.Enabled = false;
            //    Program.oFrmManual.Enabled = true;
            //    Program.oFrmManual.Show(Program.oMDI);
            //    Program.oFrmManual.WindowState = FormWindowState.Maximized;

            //    Program.oFrmManual.treeView1.SelectedNode = Program.oFrmManual.treeView1.Nodes[1].Nodes[10].Nodes[1];
            //    FrmManual.oArreglo.Add("1/10/1");
            //    FrmManual.oArreglo2.Add("");
            //    FrmManual.contador++;
            //}
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            aToolStripMenuItem_Click(sender, e); 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}