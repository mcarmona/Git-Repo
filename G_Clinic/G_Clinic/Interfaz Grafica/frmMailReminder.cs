using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmMailReminder : Form
    {
        public frmMailReminder()
        {
            InitializeComponent();
        }

        private void frmMailReminder_Load(object sender, EventArgs e)
        {
            BackgroundWorker oBackgroundWorker = new BackgroundWorker();
            

        }
    }
}