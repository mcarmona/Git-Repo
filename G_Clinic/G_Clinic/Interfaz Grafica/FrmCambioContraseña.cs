using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Microsoft.SqlServer.Server;
using G_Clinic.Miscelaneos_y_Recursos; 

namespace G_Clinic
{
    public partial class FrmCambioContraseña : Form
    {
        string Login = "";
        string Password = "";
        public static bool Cerrar = false;

        public FrmCambioContraseña(string Usuario, string Contraseña)
        {
            InitializeComponent();
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.Mantenimiento);
            Login = Usuario;
            Password = Contraseña;
        }

        private void FrmCambioContraseña_Load(object sender, EventArgs e)
        {
            Cerrar = false;
            //MessageBox.Show(Login.ToString());  
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Dispose(); 
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            String sentencia = "";

            if (TxtContraseña1.Text.Trim() != "" && TxtContraseña2.Text.Trim() != "")
            {
                if (TxtContraseña1.Text.ToLower() == TxtContraseña2.Text.ToLower())
                {
                    sentencia = "sp_password '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(this.Password.ToString().Trim()) + "','";
                    sentencia += Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(this.TxtContraseña1.Text.ToString().Trim()) + "','";
                    sentencia += Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(this.Login.ToString().Trim()) + "'";

                    // Ejecutar Store Procedure
                    Program.oPersistencia.ejecutarSQL(sentencia);
                    if (Program.oPersistencia.IsError == true)
                    {
                        MessageBox.Show("Error" + Program.oPersistencia.ErrorDescripcion, "Error");
                        return;
                    }
                    else
                    {
                        //Si el usuario es igual al actualmente logueado en el sistema entonces, cierra la conexión y la reabre con los nuevos parámetros
                        //Se debe de igualar las variables estáticas de usuario y contraseña porque otras ventanas necesitan dichos datos, y si se utilizan
                        //los datos viejos da un error de conexión.
                        if (Login.ToString().Trim() == Program.oUsuario.ToString().Trim())
                        {
                            if (Program.oPersistencia.estado() == false)
                            {
                                MessageBox.Show(this, "Su usuario y/o contraseña son incorrectos. Verifique los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show(this, "El usuario con los nuevos valores establecidos corresponde al usuario activo actualmente en el sistema, por lo que el sistema deberá reinicializarse para que inicie sesión nuevamente sin ningún problema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.ExitThread();
                                Program.oMutex.Close();
                                Application.Restart();
                                //Cerrar = true;
                                //this.Visible = false;
                                //Program.oFrmCambiarContraseñaUsuario.Visible = false;
                                //Program.oPersistencia.conexion.Dispose();
                                //Program.oPersistencia.conexion.Close();
                                //Persistencia oPersistencia = new Persistencia("", "", "");

                                //Program.oMDI.MDI_Principal_Load(sender, e);

                                return;
                            }
                        }

                        Dispose();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show(this, "La Contraseña no es la misma, Verifique los valores para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            else
                MessageBox.Show(this, "Ninguno de los 2 campos pueden estar en blanco, verifique los valores para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void FrmCambioContraseña_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false && Cerrar == true)
            {
                this.Close();
                this.Dispose();
                Program.oFrmCambiarContraseñaUsuario.Close();
            }
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

        private void TxtContraseña1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtContraseña1.Text.Trim() == "")
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

        private void TxtContraseña2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtContraseña2.Text.Trim() == "")
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

    }
}