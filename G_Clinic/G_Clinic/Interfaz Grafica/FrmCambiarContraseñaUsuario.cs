using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic
{
    public partial class FrmCambiarContraseñaUsuario : Form
    {
        public FrmCambiarContraseñaUsuario()
        {
            InitializeComponent();
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.Mantenimiento);
        }

        private void CargarImagen()
        {
            Image newImage = null;

            try
            {
                StringBuilder Sql = new StringBuilder("");

                Sql.Append("Select logo from Empresas");

                DataSet ds = Program.oPersistencia.ejecutarSQLListas(Sql.ToString(), "Empresas");

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            byte[] imageData = (byte[])dr[0];

                            //Initialize image variable

                            //Read image data into a memory stream
                            using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                            {
                                ms.Write(imageData, 0, imageData.Length);

                                //Set image variable value using memory stream.
                                newImage = Image.FromStream(ms, true);
                            }

                            //set picture
                            if (newImage != null)
                            {
                                PictureLogo.BackgroundImage = newImage;
                                PictureLogo.BackgroundImageLayout = ImageLayout.Zoom;//.Stretch;
                                PictureLogo.Image = Properties.Resources.User_Sistema;
                            }
                            break;
                        }
                    }
                }
                ds.Dispose();
            }
            catch
            {
            }
            finally
            {
                //this.sqlConnection1.Close();
            }
        }

        private void FrmCambiarContraseñaUsuario_Load(object sender, EventArgs e)
        {
            CargarImagen();
            checkBox1.Checked = false;
            checkBox1.Text = "Comprobar Contraseña";

            DataSet dt = Program.oPersistencia.ejecutarSQLListas(" sp_helpusername", "db");

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

        private void button1_Click(object sender, EventArgs e)
        {
            Program.oPersistencia = new Persistencia(this.cmbLogin.Text, this.TxtContraseña.Text, "");

            if (Program.oPersistencia.estado() == false)
            {
                MessageBox.Show(this, "Su usuario y/o contraseña son incorrectos. Verifique los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmCambioContraseña oFrmCambioContraseña = new FrmCambioContraseña(cmbLogin.Text.ToString().Trim(), TxtContraseña.Text.Trim());
                oFrmCambioContraseña.ShowDialog();
                //oFrmCambioContraseña.Opacity = 100;

                TxtContraseña.Text = "";
                checkBox1.Text = "Comprobar Contraseña";
                checkBox1.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Program.oPersistencia = new Persistencia(this.cmbLogin.Text, this.TxtContraseña.Text, "");

                if (Program.oPersistencia.estado() == false)
                {
                    checkBox1.Checked = false;
                    MessageBox.Show(this, "Su usuario y/o contraseña son incorrectos. Verifique los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkBox1.Text = "Comprobar Contraseña";
                }
                else
                {
                    Program.oPersistencia = new Persistencia(Program.oUsuario.Trim(), Program.coClaveUsuario.Trim(), "");
                    checkBox1.Text = "Contraseña Correcta";
                    //checkBox1.Enabled = false;
                }
            }
            else
                checkBox1.Text = "Comprobar Contraseña";
        }

        private void cmbLogin_SelectedValueChanged(object sender, EventArgs e)
        {
            TxtContraseña.Enabled = true;

            if (cmbLogin.Text.ToLower() == "admin")
            {
                TxtContraseña.Enabled = false;
            }
            checkBox1.Text = "Comprobar Contraseña";
            checkBox1.Checked = false;
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (FrmManual.Abierto == false)
            //{
            //    Program.oFrmManual = new FrmManual();
            //    Program.oFrmManual.Show();

            //    Program.oFrmManual.treeView1.SelectedNode = Program.oFrmManual.treeView1.Nodes[1].Nodes[10].Nodes[3];
            //    FrmManual.oArreglo.Add("1/10/3");
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

            //    Program.oFrmManual.treeView1.SelectedNode = Program.oFrmManual.treeView1.Nodes[1].Nodes[10].Nodes[3];
            //    FrmManual.oArreglo.Add("1/10/3");
            //    FrmManual.oArreglo2.Add("");
            //    FrmManual.contador++;
            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ayudaToolStripMenuItem_Click(sender, e);
        }

        private void FrmCambiarContraseñaUsuario_Activated(object sender, EventArgs e)
        {
            //if (FrmCambioContraseña.Cerrar == true)
            //{
            //    this.Close();
            //    this.Dispose();
            //    FrmCambioContraseña.Cerrar = false;
            //}
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}