using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic
{
    public partial class FrmBlackBackground : Form
    {
        public FrmBlackBackground()
        {
            InitializeComponent();
        }

        public static bool Abierto = false;

        private void FrmBlackBackground_Load(object sender, EventArgs e)
        {
            Abierto = true;
            this.Opacity = 0.83f;
            this.Refresh();
            this.Update();
            //Para que cubra todo el monitor habilitar la opción de Maximize en el form y quedar la línea 4 de este código
            this.MaximumSize = Program.oMDI.MaximumSize;
            this.Height = Program.oMDI.ClientSize.Height;
            this.Width = Program.oMDI.ClientSize.Width;
            this.SetDesktopBounds(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height); 
        }

        private void FrmBlackBackground_FormClosed(object sender, FormClosedEventArgs e)
        {
            Abierto = false;
        }
    }
}