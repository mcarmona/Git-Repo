using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class FocusedPictureBox : PictureBox
    {
        public FocusedPictureBox()
        {
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            this.Focus();
            base.OnClick(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.Focused == true)
                this.BackColor = Color.Blue;
            else
                this.BackColor = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Agregar código de dibujo personalizado aquí

            // Llamando a la clase base OnPaint
            base.OnPaint(pe);
        }
    }
}
