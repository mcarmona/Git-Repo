using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class CustomToolStrip : MenuStrip
    {
        public CustomToolStrip()
        {
            InitializeComponent();
        }

        protected override void OnMenuActivate(EventArgs e)
        {
            if (this.BackColor != Color.Red)
                this.BackColor = Color.Red;
            else if (this.BackColor == Color.Red)
                this.BackColor = Color.Purple;

            base.OnMenuActivate(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Agregar código de dibujo personalizado aquí

            // Llamando a la clase base OnPaint
            base.OnPaint(pe);
        }
    }
}
