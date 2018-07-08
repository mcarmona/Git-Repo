using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmContraseñaCorreo : Form
    {
        TextBox oPassword = new TextBox();

        public frmContraseñaCorreo(TextBox pPassword)
        {
            InitializeComponent();
            oPassword = pPassword;
        }

        private void frmContraseñaCorreo_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            oPassword.Text = textBox1.Text.Trim();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {            
            oPassword.Text = "";
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox1.UseSystemPasswordChar = false;
            else
                textBox1.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnOk_Click(sender, e);
        }
    }
}