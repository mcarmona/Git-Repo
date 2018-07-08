using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmTipoConsulta : Form
    {
        public frmTipoConsulta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 0 = Ninguna, 1 = Sin Embarazo, 2 = Con Embarazo
        /// </summary>
        int opcionElegida = 0;

        public int OpcionElegida
        {
            get { return opcionElegida; }
            set { opcionElegida = value; }
        }

        private void btnSinEmbarazo_Click(object sender, EventArgs e)
        {
            opcionElegida = 1;
            this.Close();
        }

        private void btnConEmbarazo_Click(object sender, EventArgs e)
        {
            opcionElegida = 2;
            this.Close();
        }

        private void frmTipoConsulta_Load(object sender, EventArgs e)
        {
            //Para que cubra todo el monitor habilitar la opción de Maximize en el form y quedar la línea 4 de este código
            this.MaximumSize = Program.oMDI.MaximumSize;
            this.Height = Program.oMDI.ClientSize.Height;
            this.Width = Program.oMDI.ClientSize.Width;
            this.SetDesktopBounds(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        }

        private void imagenCambianteLabel1_Click(object sender, EventArgs e)
        {
            opcionElegida = 0;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imagenCambianteLabel1_Click(sender, e);
        }
    }
}