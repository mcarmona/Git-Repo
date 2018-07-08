using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class ImagenCambianteLabel : Label
    {
        public ImagenCambianteLabel()
        {
            InitializeComponent();
        }

        private Image Imagen;
        public Image ImagenOriginal;

        /// <summary>
        /// Establece la imagen que aparecerá cuando el mouse se posiciona dentro de los márgenes del control.
        /// </summary>
        [DefaultValue(null)]
        public Image HighlightedImage
        {
            get { return Imagen; }
            set { Imagen = value; }
        }

        protected override void OnCreateControl()
        {
            ImagenOriginal = this.Image;
            base.OnCreateControl();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.Image = HighlightedImage;
            this.Cursor = Cursors.Hand;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Image = ImagenOriginal;
            this.Cursor = Cursors.Default;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Image = ImagenOriginal;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.Image = HighlightedImage;
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Agregar código de dibujo personalizado aquí

            // Llamando a la clase base OnPaint
            base.OnPaint(pe);
        }
    }
}