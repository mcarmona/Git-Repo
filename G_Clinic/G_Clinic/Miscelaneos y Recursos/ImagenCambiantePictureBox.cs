using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace G_Clinic
{
    public partial class ImagenCambiantePictureBox : PictureBox
    {
        public ImagenCambiantePictureBox()
        {
            InitializeComponent();
        }

        private Image Imagen;
        private Image imagenOriginal;

        /// <summary>
        /// Establece la imagen que aparecerá cuando el mouse se posiciona dentro de los márgenes del control.
        /// </summary>
        [DefaultValue(null)]
        public Image HighlightedImage
        {
            get { return Imagen; }
            set {Imagen = value;}
        }

        [DefaultValue(null)]
        public Image ImagenOriginal
        {
            get { return imagenOriginal; }
            set { imagenOriginal = value; }
        }

        protected override void OnCreateControl()
        {
            ImagenOriginal = this.Image;
            base.OnCreateControl();
        }

        protected override void OnLoadCompleted(AsyncCompletedEventArgs e)
        {           
            base.OnLoadCompleted(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {            
            this.Image = HighlightedImage;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Image = ImagenOriginal;
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

        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    // TODO: Agregar código de dibujo personalizado aquí

        //    // Llamando a la clase base OnPaint
        //    base.OnPaint(pe);
        //}

    }
}
