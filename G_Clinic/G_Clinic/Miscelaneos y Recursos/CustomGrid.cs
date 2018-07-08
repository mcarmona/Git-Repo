using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class CustomGrid : DataGridView 
    {
        public CustomGrid()
        {
            InitializeComponent();
        }

        public void RoundedCornerRectangle(Graphics gfxObj, Pen penObj, float X, float Y, float RectWidth, float RectHeight, float CornerRadius)
        {
            //Creamos una variable de tipo GraphicsPath para definir los bordes del rectángulo a dibujar para realizar acciones sobre él
            GraphicsPath gfxPath = new GraphicsPath();

            //     Inicio -> -> -> -> -> -> ->
            //   Fin                         ↓
            //   ↑                           ↓
            //   ↑                           ↓
            //   ↑                           ↓
            //   ↑                           ↓
            //   ↑                           ↓ 
            //   <- <- <- <- <- <- <- <- <- <-

            #region Coordenadas para dibujar bordes redondeados del rectángulo

            //Esquina superior izquierda del rectangulo redondeado
            gfxPath.AddArc(X, Y, CornerRadius * 2, CornerRadius * 2, 180, 90);

            //Esquina superior derecha del rectangulo redondeado
            gfxPath.AddArc(X + RectWidth - (CornerRadius * 2), Y, CornerRadius * 2, CornerRadius * 2, 270, 90);

            //Esquina inferior derecha del rectangulo redondeado
            gfxPath.AddArc(X + RectWidth - (CornerRadius * 2), Y + RectHeight - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 0, 90);

            //Esquina inferior izquierda del rectangulo redondeado
            gfxPath.AddArc(X, Y + RectHeight - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 90, 90);


            #endregion

            //Método que une automáticamente las líneas que no se unen mediante la creación del rectángulo, para que se unan correctamente 
            //deben de seguir el orden establecido mediante el esquema situado arriba
            gfxPath.CloseFigure();

            //Creamos una brocha que sea linear desvaneciente para rellenar el sendero creado mediante el GraphicsPath
            LinearGradientBrush bBackground = new LinearGradientBrush(gfxPath.GetBounds(), System.Drawing.Color.White, System.Drawing.Color.FromArgb(214 , 240, 253), 91);

            //Rellenamos el Path(rectángulo) mediante la brocha de color con efecto desvaneciente
            gfxObj.FillPath(bBackground, gfxPath);

            //Dibujamos el borde del Path(rectángulo) mediante un lápiz el cual recibimos del parámetro
            gfxObj.DrawPath(penObj, gfxPath);

            //shadowPath.Dispose();//Para utilizar sombra
            gfxPath.Dispose();
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            //if (e.State == DataGridViewElementStates.Selected)
            //{
                //Establecemos una nueva variable de tipo Graphics a partir del panel para asignarle el rectángulo dibujado al mismo
                System.Drawing.Graphics graphicsObj;
                graphicsObj = this.CreateGraphics();

                //Generamos una nueva variable de tipo Pen y le asignamos el color negro o cualquier otro que se desee...
                Pen oPen = new Pen(Color.Black);

                //Invocamos al método y RoundedCornerRectangle junto con todos los parámetros necesarios
                ////Para utilizar sombra debemos restar más al width y al height para que entre la sombra en el rectángulo
                RoundedCornerRectangle(graphicsObj, oPen, 0, 0, this.CurrentCell.Size.Width - 1, this.CurrentCell.Size.Height - 1, 7);

                //Establecemos el tipo de suavidad que se aplicará a los gráficos dibujados
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //}
            base.OnCellPainting(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Agregar código de dibujo personalizado aquí

            // Llamando a la clase base OnPaint
            base.OnPaint(pe);
        }
    }
}
