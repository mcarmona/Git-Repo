using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic
{
    public partial class FrmIntro : Form
    {
        public FrmIntro()
        {
            InitializeComponent();
        }

        // Define the CS_DROPSHADOW constant
        private const int CS_DROPSHADOW = 0x00020000;

        // Override the CreateParams property
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void FrmIntro_Load(object sender, EventArgs e)
        {
            this.Region = Shape.RoundedRegion(this.Size, 2, Shape.Corner.None);
        }

        private void FrmIntro_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Close();
                this.Dispose();
            }
        }
    }
}