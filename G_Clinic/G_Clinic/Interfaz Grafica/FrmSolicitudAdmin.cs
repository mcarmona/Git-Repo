using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic;

namespace G_Clinic
{
    public partial class FrmSolicitudAdmin : Form
    {
        bool BotonPresionado = false;//Verifica que se haya presionado un botón para determinar que acción realizar y no simplemente cerrar el form

        public FrmSolicitudAdmin()
        {
            InitializeComponent();
            this.Region = Shape.RoundedRegion(this.Size, 6, Shape.Corner.None);
        }

        /// <summary>
        /// Variable Global para verificar si se continúa con cuales sean las acciones deseadas o no, solo si el usuario y contraseñas son correctos
        /// y si es administrador es que continuar se convierte a true.
        /// </summary>
        public static bool Continuar = false;

        private void FrmSolicitudAdmin_Load(object sender, EventArgs e)
        {
            TxtUsuario.Focus();
            Continuar = false;
        }

        private void FrmSolicitudAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BotonPresionado == false)
                e.Cancel = true;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Continuar = false;

                if (TxtUsuario.Text != "" && TxtContraseña.Text != "")
                {
                    Program.oPersistencia = new Persistencia(this.TxtUsuario.Text.Trim(), this.TxtContraseña.Text, "");

                    if (Program.oPersistencia.estado() == false)
                    {
                        MessageBox.Show(this, "Su usuario y/o contraseña son incorrectos. Verifique los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        StringBuilder Sql = new StringBuilder("");
                        DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_helpuser", "db");

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (TxtUsuario.Text.Trim() == dr[0].ToString().Trim() || TxtUsuario.Text.Trim() == dr[2].ToString().Trim())
                            {
                                if (dr[1].ToString().Trim() == "Administrador")// && dr[3].ToString().Trim() == "Punto_Venta")
                                {
                                    Continuar = true;
                                    BotonPresionado = true;
                                    this.Close();
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show(this, "El empleado al que pertenece este usuario no posee los atributos necesarios para poder realizar estas acciones.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    Continuar = false;

                                    //DataSet DS = Program.oPersistencia.ejecutarSQLListas("sp_helpuser " + TxtUsuario.Text.Trim(), "db");

                                    //foreach (DataRow dr1 in DS.Tables[0].Rows)
                                    //{
                                    //    DataSet DS2 = Program.oPersistencia.ejecutarSQLListas("select id_emp from Usuario_Empleado where id_usuario = " + dr1[5].ToString().Trim(), "Usuario_Empleado");

                                    //    foreach (DataRow dr2 in DS2.Tables[0].Rows)
                                    //    {
                                    //        DataSet DS3 = Program.oPersistencia.ejecutarSQLListas("select id_emp from Empleados_Autorizados_PermiAdmin where id_emp = " + dr2[0].ToString().Trim(), "Usuario_Empleado");

                                    //        if (DS3.Tables[0].Rows.Count > 0)
                                    //        {
                                    //            Continuar = true;
                                    //            BotonPresionado = true;
                                    //            this.Close();
                                    //            break;
                                    //        }
                                    //        else
                                    //        {
                                    //            MessageBox.Show(this, "El empleado al que pertenece este usuario no posee los atributos necesarios para poder realizar estas acciones.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    //            Continuar = false;
                                    //        }
                                    //        DS3.Dispose();
                                    //        break;
                                    //    }
                                    //    DS2.Dispose();
                                    //    break;
                                    //}
                                    //DS.Dispose();
                                }
                            }
                            else
                                Continuar = false;
                        }
                    }
                }
                else
                    MessageBox.Show(this, "Ninguno de los 2 campos actuales puede estar en blanco, Verifique los datos para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch { }
            finally
            {
                Program.oPersistencia = new Persistencia(Program.oUsuario.Trim(), Program.coClaveUsuario.Trim(), "");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Continuar = false;
            BotonPresionado = true;
            this.Close();
        }

        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Digite un usuario administrador del sistema";
        }

        private void TxtContraseña_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Digite la contraseña del usuario ingresado anteriormente";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}