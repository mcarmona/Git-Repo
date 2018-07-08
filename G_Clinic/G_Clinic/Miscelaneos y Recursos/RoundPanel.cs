using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace G_Clinic
{
    public partial class RoundPanel : Panel
    {
        public RoundPanel()
        {
            InitializeComponent();
            this.Size = new Size(0, 0);
        }

        GraphicsPath gfxPath2 = new GraphicsPath();

        public void DrawPanel()
        {
            int x = 0;
            int y = 0;
            
            //178, 224
            for (x = 0; x < 110; )
            {               
                for (y = 0; y < 200; )
                {
                    this.Size = new Size(x, y); 
                    y += 2;
                }
                x++;
            }
        }

        public void RoundedCornerRectangle(Graphics gfxObj, Pen penObj, float X, float Y, float RectWidth, float RectHeight, float CornerRadius)
        {
            //Creamos una variable de tipo GraphicsPath para definir los bordes del rectángulo a dibujar para realizar acciones sobre él
            GraphicsPath gfxPath = new GraphicsPath();
            //GraphicsPath shadowPath = new GraphicsPath();//Para utilizar sombra

            //     Inicio -> -> -> -> -> -> ->
            //   Fin                         ↓
            //   ↑                           ↓
            //   ↑                           ↓
            //   ↑                           ↓
            //   ↑                           ↓
            //   ↑                           ↓ 
            //   <- <- <- <- <- <- <- <- <- <-

            #region Coordenadas para dibujar bordes rectos del rectángulo

            ////Esquina superior izquierda del rectángulo, llega hasta la derecha superior
            //gfxPath.AddLine(X, Y, X + RectWidth, Y);

            ////Esquina superior derecha del rectángulo, llega hasta la derecha inferior
            //gfxPath.AddLine(X + RectWidth, Y, X + RectWidth, Y + RectHeight);

            ////Esquina inferior derecha del rectángulo, llega hasta la izquierda inferior
            //gfxPath.AddLine(X + RectWidth, Y + RectHeight, X, Y + RectHeight);

            ////Esquina inferior izquierda del rectángulo, llega hasta la izquierda superior
            //gfxPath.AddLine(X, Y + RectHeight, X, Y);
            
            #endregion

            #region Coordenadas para dibujar bordes redondeados del rectángulo

            ////Esquina superior izquierda del rectangulo redondeado
            //gfxPath.AddArc(X, Y, CornerRadius * 2, CornerRadius * 2, 180, 90);

            ////Esquina superior derecha del rectangulo redondeado
            //gfxPath.AddArc(X + RectWidth - (CornerRadius * 2), Y, CornerRadius * 2, CornerRadius * 2, 270, 90);

            ////Esquina inferior derecha del rectangulo redondeado
            //gfxPath.AddArc(X + RectWidth - (CornerRadius * 2), Y + RectHeight - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 0, 90);

            ////Esquina inferior izquierda del rectangulo redondeado
            //gfxPath.AddArc(X, Y + RectHeight - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 90, 90);

            //Esquina superior izquierda del rectangulo redondeado
            gfxPath.AddArc(X, Y, CornerRadius * 2, CornerRadius * 2, 180, 90);

            //Esquina superior derecha del rectangulo redondeado
            gfxPath.AddArc(X + RectWidth - (CornerRadius * 2), Y, CornerRadius * 2, CornerRadius * 2, 270, 90);

            //Esquina inferior derecha del rectangulo redondeado
            gfxPath.AddArc(X + RectWidth - (CornerRadius * 2), Y + RectHeight - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 0, 90);

            //Esquina inferior izquierda del rectangulo redondeado
            gfxPath.AddArc(X, Y + RectHeight - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 90, 90);


            #endregion

            #region Coordenadas para sombra con bordes redondeados del rectángulo

            //Para utilizar sombra

            ////Esquina superior izquierda del rectangulo redondeado
            //shadowPath.AddArc(X + 2, Y + 2, (CornerRadius * 2) + 2, (CornerRadius * 2) + 2, 180, 90);

            ////Esquina superior derecha del rectangulo redondeado
            //shadowPath.AddArc(X + RectWidth - (CornerRadius * 2) + 2, Y + 2, (CornerRadius * 2) + 2, (CornerRadius * 2) + 2, 270, 90);

            ////Esquina inferior derecha del rectangulo redondeado
            //shadowPath.AddArc(X + RectWidth - (CornerRadius * 2) + 2, Y + RectHeight - (CornerRadius * 2) + 2, (CornerRadius * 2) + 2, (CornerRadius * 2) + 2, 0, 90);

            ////Esquina inferior izquierda del rectangulo redondeado
            //shadowPath.AddArc(X + 2, Y + RectHeight - (CornerRadius * 2) + 2, (CornerRadius * 2) + 2, (CornerRadius * 2) + 2, 90, 90);

            #endregion

            //Método que une automáticamente las líneas que no se unen mediante la creación del rectángulo, para que se unan correctamente 
            //deben de seguir el orden establecido mediante el esquema situado arriba
            
            //shadowPath.CloseFigure();//Para utilizar sombra
            gfxPath.CloseFigure();
            
            //Creamos una brocha que sea linear desvaneciente para rellenar el sendero creado mediante el GraphicsPath
            LinearGradientBrush bBackground = new LinearGradientBrush(gfxPath.GetBounds(), System.Drawing.Color.White, System.Drawing.Color.LightSteelBlue, 91);
            
            //Para utilizar sombra
            //LinearGradientBrush shadowBackground = new LinearGradientBrush(shadowPath.GetBounds(), Color.FromArgb(95, Color.LightGray), Color.FromArgb(95, Color.LightGray), 91);

            //Rellenamos el Path(rectángulo) mediante la brocha de color con efecto desvaneciente
            //gfxObj.FillPath(shadowBackground, shadowPath);//Para utilizar sombra

            //Rellenamos el Path(rectángulo) mediante la brocha de color con efecto desvaneciente
            gfxObj.FillPath(bBackground, gfxPath);

            //Dibujamos el borde del Path(rectángulo) mediante un lápiz el cual recibimos del parámetro
            gfxObj.DrawPath(penObj, gfxPath);

            //shadowPath.Dispose();//Para utilizar sombra
            gfxPath.Dispose();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //Sólamente si no queremos dibujar el rectángulo y queremos que el panel sea transparente, el valor de alpha se puede modificar, entre menor sea el número más transparencia habrá...
            //Debemos establecer la propiedad parent para este control preferiblemente
            //this.BackColor = Color.FromArgb(123, Color.Red);

            //Establecemos el color transparente de fondo para que el resto del panel no se vea afectado por el rectángulo dibujado en él o por ningún otro color
            this.BackColor = Color.Transparent;

            //Establecemos una nueva variable de tipo Graphics a partir del panel para asignarle el rectángulo dibujado al mismo
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();

            //Generamos una nueva variable de tipo Pen y le asignamos el color negro o cualquier otro que se desee...
            Pen oPen = new Pen(Color.FromArgb(154,223,254));

            //Invocamos al método y RoundedCornerRectangle junto con todos los parámetros necesarios
            ////Para utilizar sombra debemos restar más al width y al height para que entre la sombra en el rectángulo
            RoundedCornerRectangle(graphicsObj, oPen, 0, 0, this.Width - 1, this.Height - 1, 7);

            //Establecemos el tipo de suavidad que se aplicará a los gráficos dibujados
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //DrawPanel();
 
            base.OnPaint(pe);
        }

    }
}
