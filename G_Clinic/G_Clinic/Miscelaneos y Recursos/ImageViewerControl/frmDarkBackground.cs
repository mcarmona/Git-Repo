using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic.Miscelaneos_y_Recursos.ImageViewerControl
{
    public partial class frmDarkBackground : Form
    {
        public frmDarkBackground()
        {
            InitializeComponent();
        }

        private void frmDarkBackground_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.83f;
            this.Refresh();
            this.Update();
            //Para que cubra todo el monitor habilitar la opci�n de Maximize en el form y quedar la l�nea 4 de este c�digo
            this.MaximumSize = Program.oMDI.MaximumSize;
            this.Height = Program.oMDI.ClientSize.Height;
            this.Width = Program.oMDI.ClientSize.Width;
            this.SetDesktopBounds(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height); 
        }
    }
}