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

//Usar la tabla syslogin, sysuser
namespace G_Clinic
{
    public partial class FrmSeguridad : Form
    {
        public FrmSeguridad()
        {
            InitializeComponent();
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.Mantenimiento);
        }

        string Nombre = "";

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            if (txtRol.Text != "")
            {
                if (MessageBox.Show(this, "Está seguro que desea generar el rol \"" + txtRol.Text.Trim() + "\"", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    String sentencia = "";

                    if (txtRol.Text.Trim().Contains("'"))
                        txtRol.Text = txtRol.Text.Trim().Replace("'", "");

                    if (txtRol.Text.Trim().Length == 0)
                        return;
                    sentencia = "sp_addRole " + txtRol.Text.Trim();

                    Program.oPersistencia.ejecutarSQL(sentencia);
                    if (Program.oPersistencia.IsError == true)
                    {   
                        //MessageBox.Show("Error" + Program.oPersistencia.ErrorDescripcion, "Error");
                        MessageBox.Show(this, "El rol ingresado ya existe en la base de datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop); 
                        return;
                    }

                    this.txtRol.Focus();
                    this.txtRol.Text = "";
                    MessageBox.Show(this, "El Rol fue creado exitósamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  
                    cargarRoles();
                }
            }
            else
            {
                MessageBox.Show(this, "No puede guardar datos si no hay datos ingresados, Ingrese un valor para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);  
            }

            DataSet dt1 = Program.oPersistencia.ejecutarSQLListas("select 'RoleName' = name, 'RoleId' = uid, 'IsAppRole' = isapprole from sysusers where (issqlrole = 1 and name != 'public' and name != 'db_owner' and name != 'db_accessadmin' and name != 'db_securityadmin' and name != 'db_ddladmin' and name != 'db_backupoperator' and name != 'db_datareader' and name != 'db_datawriter' and name != 'db_denydatareader' and name != 'db_denydatawriter')  ", "db");
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

        private void LlenarCombos()
        {
            // Cargar lo logins
            //DataSet dt = Program.oPersistencia.ejecutarSQLListas("sp_helplogins ", "db");
            DataSet dt = Program.oPersistencia.ejecutarSQLListas("use master select name from syslogins where dbname = 'G_Clinic'", "db");

            //Establecemos de nuevo la conexión la Base de Datos G_Clinic luego de extraer los datos necesarios de la Base de Datos Master
            //Program.oPersistencia = new Persistencia(Program.oUsuario, Program.coClaveUsuario, "Localhost"); 
            Program.oPersistencia.ejecutarSQLTransaccion("use G_Clinic");

            // Verifico el Error
            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                return;
            }

            // llena el combo
            this.cmbLogin.DataSource = dt.Tables["db"];
            this.cmbLogin.DisplayMember = dt.Tables["db"].Columns[0].ToString();
            this.cmbLogin.ValueMember = dt.Tables["db"].Columns[0].ToString();

            dt.Dispose();

            DataSet dt_3 = Program.oPersistencia.ejecutarSQLListas("sp_helpuser", "db");

            // Verifico el Error
            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                return;
            }

            CmbUsuario.Items.Clear();
            CmbUsuario2.Items.Clear();
            foreach (DataRow dr in dt_3.Tables[0].Rows)
            {
                if (dr[0].ToString() != "guest" && dr[0].ToString() != "dbo" && dr[0].ToString() != "INFORMATION_SCHEMA" && dr[0].ToString() != "sys")
                {
                    this.CmbUsuario.Items.Add(dr[0].ToString());
                    this.CmbUsuario2.Items.Add(dr[0].ToString());
                }
            }
            dt_3.Dispose();

            CmbUsuario.SelectedIndex = 0;
            CmbUsuario2.SelectedIndex = 0;

            #region Se cambió la forma de llenar los combos de usuarios ya que traía hasta los usuarios del sistema
            
            //this.CmbUsuario.DataSource = dt_3.Tables["db"];
            //this.CmbUsuario.DisplayMember = dt_3.Tables["db"].Columns[0].ToString();
            //this.CmbUsuario.ValueMember = dt_3.Tables["db"].Columns[5].ToString();

            //this.CmbUsuario2.DataSource = dt_3.Tables["db"];
            //this.CmbUsuario2.DisplayMember = dt_3.Tables["db"].Columns[0].ToString();
            //this.CmbUsuario2.ValueMember = dt_3.Tables["db"].Columns[5].ToString();

            #endregion

            //*****************Se cambió para que se muestren unicamente los roles que no son del sistema propiamente sólo los que el usuario ingresa
            DataSet dt1 = Program.oPersistencia.ejecutarSQLListas("select 'RoleName' = name, 'RoleId' = uid, 'IsAppRole' = isapprole from sysusers where (issqlrole = 1 and name != 'public' and name != 'db_owner' and name != 'db_accessadmin' and name != 'db_securityadmin' and name != 'db_ddladmin' and name != 'db_backupoperator' and name != 'db_datareader' and name != 'db_datawriter' and name != 'db_denydatareader' and name != 'db_denydatawriter')  ", "db");
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

        public bool VerificarEmpleadosIngresados()
        {
            DataSet ds = null;

            try
            {
                ds = Program.oPersistencia.ejecutarSQLListas("Select * from Empleados", "Empleados");

                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
            finally 
            {
                ds.Dispose();
            } 
        }

        private void FrmSeguridad_Load(object sender, EventArgs e)
        {
            if (VerificarEmpleadosIngresados() == true)
            {
                try
                {
                    VistaConstants.SetWindowTheme(lstRoles.Handle, "explorer", null); //Explorer style
                    VistaConstants.SendMessage(lstRoles.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
                    VistaConstants.SetWindowTheme(LstRolesXUsuario.Handle, "explorer", null); //Explorer style
                    VistaConstants.SendMessage(LstRolesXUsuario.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
                    VistaConstants.SetWindowTheme(LstUsuarioEmpleado.Handle, "explorer", null); //Explorer style
                    VistaConstants.SendMessage(LstUsuarioEmpleado.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
                }
                catch { }

                cargarRoles();
                //cargarBaseDatos();

                DataSet ds2 = Program.oPersistencia.ejecutarSQLListas("Select id_emp, nombre from Empleados", "Empleados");

                this.CmbEmpleados.DataSource = ds2.Tables["Empleados"];
                this.CmbEmpleados.DisplayMember = ds2.Tables["Empleados"].Columns[1].ToString();
                this.CmbEmpleados.ValueMember = ds2.Tables["Empleados"].Columns[0].ToString();

                this.CmbEmpleados2.DataSource = ds2.Tables["Empleados"];
                this.CmbEmpleados2.DisplayMember = ds2.Tables["Empleados"].Columns[1].ToString();
                this.CmbEmpleados2.ValueMember = ds2.Tables["Empleados"].Columns[0].ToString();

                ds2.Dispose();

                LlenarCombos();

                this.BtnEliminar.Region = Shape.RoundedRegion(BtnEliminar.Size, 2, Shape.Corner.None);
                this.BtnUsuarioEmpleado.Region = Shape.RoundedRegion(BtnUsuarioEmpleado.Size, 2, Shape.Corner.None);
                this.button3.Region = Shape.RoundedRegion(button3.Size, 2, Shape.Corner.None);
                this.button1.Region = Shape.RoundedRegion(button1.Size, 2, Shape.Corner.None);
                this.BtnCrearLogin1.Region = Shape.RoundedRegion(BtnCrearLogin1.Size, 2, Shape.Corner.None);
                this.BtnCrearRol1.Region = Shape.RoundedRegion(BtnCrearRol1.Size, 2, Shape.Corner.None);
                this.BtnAsignarUsuario.Region = Shape.RoundedRegion(BtnAsignarUsuario.Size, 2, Shape.Corner.None);
                this.BtnCerrarListaUsuarios.Region = Shape.RoundedRegion(BtnCerrarListaUsuarios.Size, 2, Shape.Corner.None);
                this.BtnCerrarListaRolesUsuario.Region = Shape.RoundedRegion(BtnCerrarListaRolesUsuario.Size, 2, Shape.Corner.None);
                this.button2.Region = Shape.RoundedRegion(button2.Size, 2, Shape.Corner.None);

                //if (cmbLogin.Items.Count > 0)
                //    button2.Enabled = false;//Botón para ver roles por usuario
                cmbBaseDatos.SelectedIndex = 0;
            }
            else
            {
                if (MessageBox.Show(this, "No puede continuar hasta haber ingresado los empleados que utilizarán el sistema. ¿Desea realizar estas acciones en este momento?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    this.Close();
                    this.Dispose();

                    FrmMantEmpleados oFrmMantEmpleados = new FrmMantEmpleados();
                    oFrmMantEmpleados.ShowDialog(); 
                }
                else
                {
                    this.Close();
                    this.Dispose();
                }
            }
        }

        private void cargarBaseDatos()
        {
            DataSet dt = Program.oPersistencia.ejecutarSQLListas(" sp_helpdb ", "db");

            // Verifico el Error
            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                return;
            }

            // llena el combo
            this.cmbBaseDatos.DataSource = dt.Tables["db"];
            this.cmbBaseDatos.DisplayMember = dt.Tables["db"].Columns[0].ToString();
            this.cmbBaseDatos.ValueMember = dt.Tables["db"].Columns[0].ToString();

            dt.Dispose();
        }

        //Carga los roles de una base de datos
        private void cargarRoles()
        {
            //SqlDataReader dr = Program.oPersistencia.ejecutarConsultaSQL(" sp_helprole ");
            SqlDataReader dr = Program.oPersistencia.ejecutarConsultaSQL("select 'RoleName' = name, 'RoleId' = uid, 'IsAppRole' = isapprole from sysusers where (issqlrole = 1 and name != 'public' and name != 'db_owner' and name != 'db_accessadmin' and name != 'db_securityadmin' and name != 'db_ddladmin' and name != 'db_backupoperator' and name != 'db_datareader' and name != 'db_datawriter' and name != 'db_denydatareader' and name != 'db_denydatawriter')  order by RoleName");   

            // Verifico el Error
            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                return;
            }

            this.lstRoles.Items.Clear();

            while (dr.Read())
                this.lstRoles.Items.Add(dr.GetValue(0).ToString());

            dr.Dispose();

        }

        private void btnCrearLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword1.Text.Trim().Length >= 6)
            {
                if (txtLogin.Text.ToLower() != "admin")
                {
                    if (txtLogin.Text == "" || txtPassword1.Text == "" || txtPassword2.Text == "")
                    {
                        MessageBox.Show(this, "Alguno de los campos está vacío, Verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        String sentencia = "";

                        if (this.txtLogin.Text.Trim().Length == 0)
                            return;

                        if (this.txtPassword1.Text.Trim().CompareTo(this.txtPassword2.Text.Trim()) != 0)
                        {
                            MessageBox.Show(this, "Los Password son diferentes, Verifique los valores para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.txtPassword1.Focus();
                            return;
                        }

                        if (MessageBox.Show(this, "Está seguro que desea generar el login \"" + txtLogin.Text.Trim() + "\"", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            // Primero Login, luego password y por ultimo Base de datos default
                            sentencia = "sp_addLogin " + txtLogin.Text.Trim() + ",'";
                            sentencia += txtPassword1.Text.Trim() + "', ";
                            sentencia += this.cmbBaseDatos.Text.Trim() + ",";
                            sentencia += "Spanish";
                        }

                        Program.oPersistencia.ejecutarSQL(sentencia);

                        if (Program.oPersistencia.IsError == true)
                        {
                            MessageBox.Show("Error" + Program.oPersistencia.ErrorDescripcion, "Error");
                            MessageBox.Show(this, "El login ingresado ya existe en la base de datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        this.txtLogin.Text = "";
                        this.txtLogin.Focus();
                        this.txtPassword1.Text = "";
                        this.txtPassword2.Text = "";

                        MessageBox.Show(this, "El Login fue creado exitósamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    // Cargar lo logins
                    //DataSet dt = Program.oPersistencia.ejecutarSQLListas(" sp_helplogins ", "db");
                    DataSet dt = Program.oPersistencia.ejecutarSQLListas("use master select name from syslogins where dbname = 'G_Clinic'", "db");

                    //Establecemos de nuevo la conexión la Base de Datos G_Clinic luego de extraer los datos necesarios de la Base de Datos Master
                    //Program.oPersistencia = new Persistencia(Program.oUsuario, Program.coClaveUsuario, "Localhost");
                    Program.oPersistencia.ejecutarSQLTransaccion("Use G_Clinic");

                    // Verifico el Error
                    if (Program.oPersistencia.IsError == true)
                    {
                        MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                        return;
                    }

                    // llena el combo
                    this.cmbLogin.DataSource = dt.Tables["db"];
                    this.cmbLogin.DisplayMember = dt.Tables["db"].Columns[0].ToString();
                    this.cmbLogin.ValueMember = dt.Tables["db"].Columns[0].ToString();

                    dt.Dispose();
                }
                else
                    MessageBox.Show(this, "El usuario \"admin\" está reservado para el control del sistema propiamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show(this, "La contraseña debe ser de al menos 6 caracteres.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);  
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
        }

        private void cmbLogin_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtUsuario.Text = this.cmbLogin.SelectedValue.ToString().Trim();
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.ToLower() != "admin")
            {
                if (MessageBox.Show(this, "Está seguro que desea generar el usuario \"" + txtUsuario.Text.Trim() + "\"", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    if (LstRolesXUsuario.Items.Count > 0)
                    {
                        Program.oPersistencia.ejecutarSQL("sp_dropuser '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(txtUsuario.Text.Trim()) + "'");
                        Program.oPersistencia.ejecutarSQL("sp_dropsrvrolemember '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(cmbLogin.Text.Trim()) + "' , '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(LstRolesXUsuario.Items[0].Text.Trim()) + "'");
                    }

                    String sentencia = "";
                    //  Crear el  usuario
                    // primero el login luego el nombre del usuario que se recomienda
                    // sea el mismo del login y de ultimo el rol con esto se asocia!
                    sentencia = "sp_adduser " + this.cmbLogin.SelectedValue.ToString().Trim() + ",";
                    sentencia += this.txtUsuario.Text.Trim() + ", ";
                    sentencia += this.cmbRol.SelectedValue.ToString();

                    Program.oPersistencia.ejecutarSQL(sentencia);

                    if (Program.oPersistencia.IsError == true)
                    {
                        //MessageBox.Show("Error" + Program.oPersistencia.ErrorDescripcion, "Error");
                        MessageBox.Show(this, "El usuario ingresado ya existe en la base de datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    String Sentencia2 = "";
                    Sentencia2 = "sp_addsrvrolemember " + this.cmbLogin.SelectedValue.ToString().Trim() + ", 'sysadmin'";

                    Program.oPersistencia.ejecutarSQL(Sentencia2);

                    if (Program.oPersistencia.IsError == true)
                    {
                        MessageBox.Show("Error" + Program.oPersistencia.ErrorDescripcion, "Error");
                        return;
                    }

                    MessageBox.Show(this, "El Usuario fue creado exitósamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cmbLogin.Focus();

                    DataSet dt_3 = Program.oPersistencia.ejecutarSQLListas("sp_helpuser", "db");

                    // Verifico el Error
                    if (Program.oPersistencia.IsError == true)
                    {
                        MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                        return;
                    }

                    CmbUsuario.Items.Clear();
                    CmbUsuario2.Items.Clear();
                    foreach (DataRow dr in dt_3.Tables[0].Rows)
                    {
                        if (dr[0].ToString() != "guest" && dr[0].ToString() != "dbo" && dr[0].ToString() != "INFORMATION_SCHEMA" && dr[0].ToString() != "sys")
                        {
                            this.CmbUsuario.Items.Add(dr[0].ToString());
                            this.CmbUsuario2.Items.Add(dr[0].ToString());
                        }
                    }
                    dt_3.Dispose();

                    CmbUsuario.SelectedIndex = 0;

                    //this.CmbUsuario.DataSource = dt_3.Tables["db"];
                    //this.CmbUsuario.DisplayMember = dt_3.Tables["db"].Columns[0].ToString();
                    //this.CmbUsuario.ValueMember = dt_3.Tables["db"].Columns[5].ToString();

//                    dt_3.Dispose();

                    Llenar_Rol_Usuario();

                    if (txtUsuario.Text.Trim() == Program.oUsuario.ToString().Trim())
                    {
                        this.Close();

                        MessageBox.Show(this, "Usted decidió modificar el rol del usuario actualmente activo en el sistema, por lo que deberá de proceder a iniciar sesión nuevamente para reestablecer los permisos asignados a este usuario. Se cerrarán todas las ventanas que el sistema evalúe que no pueden continuar abiertas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //if (FrmVentas.Abierto == true)
                        //    Program.oVentas.Close();

                        //if (FrmFacturasCredito.Abierto == true)
                        //    Program.oFrmFacturasCredito.Close();

                        Program.oMDI.MDIPrincipal_Load(sender, e);
                    }
                }
            }
            else
                MessageBox.Show(this, "No puede realizar ningún tipo de acción sobre este usuario ya que está reservado para el sistema", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbBaseDatos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenusXRol oFrmMenusXRol = new FrmMenusXRol();
            oFrmMenusXRol.ShowDialog();
        }

        private void BtnCrearRol1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
            this.AcceptButton = btnCrearRol;
        }

        private void BtnCrearLogin1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            this.AcceptButton = btnCrearLogin;
        }

        private void BtnAsignarUsuario_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[2];
            this.AcceptButton = btnCrearUsuario;
        }

        private void BtnUsuarioEmpleado_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[3];
            this.AcceptButton = BtnAsignar;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtUsuario.Text = this.cmbLogin.SelectedValue.ToString().Trim();

            if (tabControl1.SelectedTab == tabControl1.TabPages[3])
            {
                CmbEmpleados_SelectedValueChanged(sender, e);
                CmbUsuario_SelectedValueChanged(sender, e);
            }

            if (tabControl1.SelectedTab == tabControl1.TabPages[2])
            {
                Llenar_Rol_Usuario();
            }
        }
    
        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            bool Verifica = false;

            if (pictureBox3.Tag.ToString().Trim() == "No Disponible")
            {
                Verifica = true;
                MessageBox.Show(this, "Este empleado ya posee un usuario asignado, proceda a modificar sus valores si así lo considera necesario o seleccione otro empleado de la lista disponible", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);  
            }

            if (pictureBox7.Tag.ToString().Trim() == "No Disponible" && CmbUsuario.Text.ToLower() == "admin")
            {
                Verifica = true;
                MessageBox.Show(this, "El usuario admin no puede ser asignado a ningún empleado del sistema ya que está reservado por el sistema", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (pictureBox7.Tag.ToString().Trim() == "No Disponible")
            {
                Verifica = true;
                MessageBox.Show(this, "Este usuario ya fue sido asignado al empleado: " + Nombre + ". Proceda a modificar sus valores si así lo considera necesario o seleccione otro usuario de la lista disponible", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            string id = "";
            DataSet ds4 = Program.oPersistencia.ejecutarSQLListas("sp_helpuser '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(CmbUsuario.Text.Trim()) + "'", "dbo");

            foreach (DataRow dr in ds4.Tables[0].Rows)
            {
                id = dr[5].ToString().Trim();
            }
            ds4.Dispose();

            if (id == "")
            {
                Verifica = true;
                MessageBox.Show(this, "Hay un problema con el usuario creado y no se puede asignar, cierre la pantalla e intente de nuevo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (Verifica == false)
            {
                //Program.oComprobaciones.Guardar(CmbEmpleados.SelectedValue.ToString().Trim() + ", " + CmbUsuario.SelectedValue.ToString(), "Usuario_Empleado");
                Program.oComprobaciones.Guardar(CmbEmpleados.SelectedValue.ToString().Trim() + ", " + id, "Usuario_Empleado");

                MessageBox.Show(this, "El Usuario fue asignado exitósamente a este empleado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (Program.oUsuario.Trim().ToLower() == CmbUsuario.Text.Trim().ToLower())
                {
                    Seguridad.Id_Emp = CmbEmpleados.SelectedValue.ToString().Trim();
                    new Seguridad().VerificarEstadoUsuario(id.Trim());     
                }

                CmbEmpleados_SelectedValueChanged(sender, e);
                CmbUsuario_SelectedValueChanged(sender, e); 
            }
        }

        private void Llenar_Usuario_Asignado()
        {
            LstUsuarioEmpleado.Items.Clear(); 

            if (tabControl1.SelectedTab == tabControl1.TabPages[3])
            {
                StringBuilder Sql = new StringBuilder("");

                Sql.Append("Select * from Usuario_Empleado where id_emp = " + CmbEmpleados2.SelectedValue.ToString().Trim());

                DataSet ds = Program.oPersistencia.ejecutarSQLListas(Sql.ToString(), "Usuario_Empleado");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Sql.Remove(0, Sql.Length);
                    Sql.Append("select * from sysusers where uid = " + dr[1].ToString().Trim());

                    DataSet ds2 = Program.oPersistencia.ejecutarSQLListas(Sql.ToString(), "Usuario_Empleado");

                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        LstUsuarioEmpleado.Items.Add(dr2[2].ToString().Trim());
                        break;
                    }
                    ds.Dispose();

                    break;
                }
                ds.Dispose();
            }
        }

        private void CmbEmpleados_SelectedValueChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages[3])
            {
                StringBuilder Sql = new StringBuilder("");

                Sql.Append("Select * from Usuario_Empleado where id_emp = " + CmbEmpleados.SelectedValue.ToString().Trim());

                DataSet ds = Program.oPersistencia.ejecutarSQLListas(Sql.ToString(), "Usuario_Empleado");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    pictureBox3.Image = recursos.Cancelar16;
                    pictureBox3.Tag = "No Disponible"; 
                }
                else
                {
                    pictureBox3.Image = recursos.ok16;
                    pictureBox3.Tag = "Disponible"; 
                }

                CmbEmpleados2_SelectedIndexChanged(sender, e); 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Llenar_Usuario_Asignado();
            pictureBox6.Visible = true;
            grouper1.Visible = true;
        }

        private void CmbEmpleados2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_Usuario_Asignado(); 
        }

        private void CmbUsuario_SelectedValueChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
            {
                string id = "";
                DataSet ds4 = Program.oPersistencia.ejecutarSQLListas("sp_helpuser '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(CmbUsuario.Text.Trim()) + "'", "dbo");

                foreach (DataRow dr in ds4.Tables[0].Rows)
                {
                    id = dr[5].ToString().Trim();
                }
                ds4.Dispose();

                Nombre = "";
                pictureBox7.Image = recursos.ok16;
                pictureBox7.Tag = "Disponible";

                //DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select id_usuario from Usuario_Empleado where id_usuario = " + CmbUsuario.SelectedValue.ToString(), "Usuario_Empleado");
                string sentencia = "";
                sentencia = "Select a.nombre from Empleados a, Usuario_Empleado b where a.id_emp = b.id_emp and b.id_usuario = " + id.Trim();//CmbUsuario.SelectedValue.ToString().Trim();                
                
                DataSet ds = Program.oPersistencia.ejecutarSQLListas(sentencia.Trim(), "Empleados a, Usuario_Empleado b");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    pictureBox7.Image = recursos.Cancelar16;
                    pictureBox7.Tag = "No Disponible"; 

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Nombre = dr[0].ToString().Trim();
                        break;
                    }
                }
                ds.Dispose();

                if (CmbUsuario.Text.ToLower() == "admin")
                {
                    pictureBox7.Image = recursos.Cancelar16;
                    pictureBox7.Tag = "No Disponible"; 
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (LstUsuarioEmpleado.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "¿Está seguro que desea eliminar este usuario para este empleado?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    Program.oComprobaciones.Borrar("Usuario_Empleado", "id_emp = " + CmbEmpleados2.SelectedValue.ToString().Trim());

                    if (Seguridad.Id_Emp == CmbEmpleados2.SelectedValue.ToString().Trim().ToLower())
                    {
                        Seguridad.Id_Emp = "";
                        Seguridad.Estado_Emp = ""; //new Seguridad().VerificarEstadoUsuario(CmbUsuario.SelectedValue.ToString());
                    }

                    CmbEmpleados_SelectedValueChanged(sender, e);
                    CmbUsuario_SelectedValueChanged(sender, e);
                    Llenar_Usuario_Asignado();
                }
            }
            else
                MessageBox.Show(this, "Debe de seleccionar un elemento de la lista disponible para poder proceder con estas acciones", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  
        }

        private void BtnCerrarListaUsuarios_Click(object sender, EventArgs e)
        {
            grouper1.Visible = false;
            pictureBox6.Visible = false;
        }

        private void BtnVerAjustes_Click(object sender, EventArgs e)
        {

        }

        private void txtRol_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese el nombre del nuevo rol a crear";
        }

        private void txtLogin_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese el nombre del Login que desea crear";
        }

        private void txtPassword1_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese la contraseña que desea asignar al login";
        }

        private void txtPassword2_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese de nuevo la contraseña";
        }

        private void cmbBaseDatos_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void cmbLogin_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione el login que desea asignar a su usuario";
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Nombre de usuario a crear(Solo lectura)";
        }

        private void cmbRol_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione el rol que desea establecer para este usuario";
        }

        private void CmbEmpleados_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione el empleado al cual desea asignar un usuario";
        }

        private void CmbUsuario_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione el usuario que desea asignarle al empleado";
        }

        private void Llenar_Rol_Usuario()
        {
            try
            {
                if (txtUsuario.Text != "")
                {
                    LstRolesXUsuario.Items.Clear();

                    if (tabControl1.SelectedIndex == 2)
                    {
                        DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_helpuser '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(txtUsuario.Text.Trim()) + "'", "db");

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            LstRolesXUsuario.Items.Add(dr[1].ToString().Trim());
                            break;
                        }
                        ds.Dispose();
                    }
                }
            }
            catch { }
        }

        private void CmbUsuario2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 2)
                {
                    LstRolesXUsuario.Items.Clear();

                    DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_helpuser '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(CmbUsuario2.Text.Trim()) + "'", "db");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        LstRolesXUsuario.Items.Add(dr[1].ToString().Trim());
                        break;
                    }
                    ds.Dispose();
                }
            }
            catch { }
        }

        private void BtnCerrarListaRolesUsuario_Click(object sender, EventArgs e)
        {
            grouper2.Visible = false;
            pictureBox8.Visible = false; 
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int contador = 0;

                LstRolesXUsuario.Items.Clear();

                if (tabControl1.SelectedIndex == 2)
                {
                    for (int i = 0; i < CmbUsuario2.Items.Count; i++)
                    {
                        contador++;
                        if (CmbUsuario2.GetItemText(CmbUsuario2.Items[i]).Trim() == txtUsuario.Text.Trim())
                        {
                            if (CmbUsuario2.SelectedIndex == i)
                            {
                                LstRolesXUsuario.Items.Clear();

                                DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_helpuser '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(txtUsuario.Text.Trim()) + "'", "db");

                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    LstRolesXUsuario.Items.Add(dr[1].ToString().Trim());
                                    break;
                                }
                                ds.Dispose();
                            }
                            else
                                CmbUsuario2.SelectedIndex = i;
                            
                            contador = 0;
                            break;
                        }
                    }

                    if (contador == CmbUsuario2.Items.Count)
                        MessageBox.Show(this, "Actualmente no existe un usuario creado con este login", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop); 
                }

                pictureBox8.Visible = true;
                grouper2.Visible = true;
            }
            catch {}
        }

        private void FrmSeguridad_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.oUsuario.ToLower() != "admin" && Program.coClaveUsuario.Trim().ToLower() != "admin_G_Clinic_adminlogin_1029384756")
            {
                if (Seguridad.Id_Emp.Trim() == "" || Seguridad.Estado_Emp == "Inactivo")
                {
                    MessageBox.Show(this, "Este usuario no puede realizar ningún tipo de acciones sobre el sistema ya que no se ha asignado a ningún empleado. Deberá iniciar sesión nuevamente con un usuario válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    this.Visible = false;

                    Program.oPersistencia.conexion.Dispose();
                    Program.oPersistencia.conexion.Close();
                    Persistencia oPersistencia = new Persistencia("", "", "");

                    Program.oMDI.MDIPrincipal_Load(sender, e);
                }
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmTopics oFrmTopics = new FrmTopics("groupSeguridad");
            //oFrmTopics.ShowDialog();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            ayudaToolStripMenuItem_Click(sender, e); 
        }

        private bool VerificaCaracteres(string Caracter)
        {
            bool Encontrado = false;

            switch (Caracter)
            {
                case "[":
                    Encontrado = true;
                    break;
                case "]":
                    Encontrado = true;
                    break;
                case "{":
                    Encontrado = true;
                    break;
                case "}":
                    Encontrado = true;
                    break;
                case "(":
                    Encontrado = true;
                    break;
                case ")":
                    Encontrado = true;
                    break;
                case ",":
                    Encontrado = true;
                    break;
                case ";":
                    Encontrado = true;
                    break;
                case "?":
                    Encontrado = true;
                    break;
                case "*":
                    Encontrado = true;
                    break;
                case "@":
                    Encontrado = true;
                    break;
                case "!":
                    Encontrado = true;
                    break;
                case " ":
                    Encontrado = true;
                    break;
                case "\\":
                    Encontrado = true;
                    break;
            }

            return Encontrado;
        }

        private void txtPassword1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPassword1.Text.Trim() == "")
            {
                if (e.KeyChar.ToString().Trim() == " " || e.KeyChar.ToString().Trim() == "@" || e.KeyChar.ToString().Trim() == "$")
                {
                    MessageBox.Show(this, "La contraseña no puede iniciar con los caracteres '@,$' o un espacio en blanco ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    e.Handled = true;
                }
                else
                {
                    //[]{}(),;?*! @
                    if (VerificaCaracteres(e.KeyChar.ToString()) == true)
                    {
                        MessageBox.Show(this, "Los caracteres \"[]{}(),;?*! @\\\" no pueden ser utilizados en una contraseña, por favor especifique otro caracter.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        e.Handled = true;
                        return;
                    }
                }
            }
            else
            {
                //[]{}(),;?*! @
                if (VerificaCaracteres(e.KeyChar.ToString()) == true)
                {
                    MessageBox.Show(this, "Los caracteres \"[]{}(),;?*! @\\\" no pueden ser utilizados en una contraseña, por favor especifique otro caracter.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void txtPassword2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPassword2.Text.Trim() == "")
            {
                if (e.KeyChar.ToString() == " " || e.KeyChar.ToString() == "@" || e.KeyChar.ToString() == "$")
                {
                    MessageBox.Show(this, "La contraseña no puede iniciar con los caracteres '@,$' o un espacio en blanco ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    e.Handled = true;
                }
                else
                {
                    //[]{}(),;?*! @
                    if (VerificaCaracteres(e.KeyChar.ToString()) == true)
                    {
                        MessageBox.Show(this, "Los caracteres \"[]{}(),;?*! @\\\" no pueden ser utilizados en una contraseña, por favor especifique otro caracter.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        e.Handled = true;
                    }
                }
            }
            else
            {
                //[]{}(),;?*! @
                if (VerificaCaracteres(e.KeyChar.ToString()) == true)
                {
                    MessageBox.Show(this, "Los caracteres \"[]{}(),;?*! @\\\" no pueden ser utilizados en una contraseña, por favor especifique otro caracter.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    e.Handled = true;
                }
            }
        }

        private void txtRol_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string a = e.KeyChar.ToString(); 
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'")
            {
                e.Handled = true;
                MessageBox.Show(this, "El caracter ' no puede ser ingresado en un login, por favor especifique otro caracter.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}