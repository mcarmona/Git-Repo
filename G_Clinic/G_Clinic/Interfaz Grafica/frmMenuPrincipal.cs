using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();

            this.Left = -3;
            this.Top = 19;
        }

        private void transparentPictureBox1_MouseEnter(object sender, EventArgs e)
        {
            transparentPictureBox1.BackgroundImage = Properties.Resources.SoftNet_Orb_64_highlighted_2;
        }

        private void transparentPictureBox1_MouseLeave(object sender, EventArgs e)
        {
            transparentPictureBox1.BackgroundImage = Properties.Resources.SoftNet_Orb_64;
        }

        private void transparentPictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            transparentPictureBox1.BackgroundImage = Properties.Resources.SoftNet_Orb_64_Pressed;
        }

        private void transparentPictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            transparentPictureBox1.BackgroundImage = Properties.Resources.SoftNet_Orb_64_highlighted_2;
        }

        private void transparentPictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
                panel1.Visible = false;
            else
                panel1.Visible = true;
        }
    }
}