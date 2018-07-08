using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class TransparentPictureBox : Panel
    {
        public TransparentPictureBox()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            this.BackColor = Color.Transparent;
            Invalidate(); 
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }

        private void DrawImage()
        {
            
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            this.BackColor = Color.Transparent;

            if (this.BackgroundImage != null)
                pe.Graphics.DrawImage(this.BackgroundImage, 0, 0);
            // TODO: Agregar código de dibujo personalizado aquí

            // Llamando a la clase base OnPaint
            base.OnPaint(pe);
        }
    }
}
