using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Security.Permissions;

namespace G_Clinic
{
    public partial class PanelAvailableHours : Panel
    {
        public PanelAvailableHours()
        {
            InitializeComponent();
            this.SetStyles();
            this.BackColor = Color.Transparent;
        }

        private int Hours;
        private TimeSpan oHoraInicial = new TimeSpan();
        private TimeSpan oHoraFinal = new TimeSpan();

        /// <summary>
        /// Establece el total de horas laborables que se verán dentro de los márgenes del control.
        /// </summary>
        [DefaultValue("")]
        public Int32 TotalHours
        {
            get { return Hours; }
            set { Hours = value; }
        }

        /// <summary>
        /// Establece la hora inicial de donde empezará el rango de horas que se verán dentro de los márgenes del control.
        /// </summary>
        [DefaultValue("")]
        public TimeSpan HoraInicial
        {
            get { return oHoraInicial; }
            set { oHoraInicial = value; }
        }

        /// <summary>
        /// Establece la hora final en la que finalizará el rango de horas que se verán dentro de los márgenes del control.
        /// </summary>
        [DefaultValue("")]
        public TimeSpan HoraFinal
        {
            get { return oHoraFinal; }
            set { oHoraFinal = value; }
        }

        private void SetStyles()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.ContainerControl, true);
            SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
        }

        public void DrawString(string s,Font font,Brush brush,PointF point)
        {

        }

        public void TimeScale(Graphics gfxObj, Pen penObj, TimeSpan pHoraInicial, TimeSpan pHoraFinal)
        {
            ArrayList oArregloHoras = new ArrayList();

            double TotalHoras = 0;
            TotalHoras = ((TimeSpan)(pHoraFinal - pHoraInicial)).TotalHours;
            TotalHoras = Math.Abs(TotalHoras);

            for (int i = pHoraInicial.Hours; i < pHoraFinal.Hours; )
            {
                oArregloHoras.Add(i.ToString());
                i++;
            }

            //Creamos una variable de tipo GraphicsPath para definir los bordes del rectángulo a dibujar para realizar acciones sobre él
            GraphicsPath gfxPath = new GraphicsPath();

            //     Inicio -> ->
            //   Fin          ↓
            //   ↑            ↓
            //   ↑            ↓
            //   ↑            ↓
            //   ↑            ↓
            //   ↑            ↓
            //   <- <- <- <- <-

            #region Coordenadas para dibujar bordes rectos del rectángulo

            //Dibuja la línea vertical grande
            //

            int y = 50;
            for (int i = 0; i < TotalHoras; )
            {
                y += 45;
                gfxPath.AddLine(25, y, 50, y);
                gfxPath.CloseFigure();
                i++;
            }

            gfxPath.AddLine(50, 50, 50, this.Height - 15);
            //Dibujamos el borde del Path(rectángulo) mediante un lápiz el cual recibimos del parámetro
            gfxObj.DrawPath(penObj, gfxPath);

            //shadowPath.Dispose();//Para utilizar sombra
            gfxPath.Dispose();

            #endregion
        }

        public void RoundedCornerRectangle(Graphics gfxObj, Pen penObj, Pen penObj2, Pen penObj3, float X, float Y, float RectWidth, float RectHeight, float CornerRadius)
        {
            //Creamos una variable de tipo GraphicsPath para definir los bordes del rectángulo a dibujar para realizar acciones sobre él
            GraphicsPath gfxPath = new GraphicsPath();
            GraphicsPath gfxPath2 = new GraphicsPath();
            GraphicsPath gfxPath3 = new GraphicsPath();

            //     Inicio -> ->
            //   Fin          ↓
            //   ↑            ↓
            //   ↑            ↓
            //   ↑            ↓
            //   ↑            ↓
            //   ↑            ↓
            //   <- <- <- <- <-

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

            //Esquina superior izquierda del rectangulo redondeado
            gfxPath.AddArc(X, Y, CornerRadius * 2, CornerRadius * 2, 180, 90);

            //Esquina superior derecha del rectangulo redondeado
            gfxPath.AddArc(X + RectWidth - (CornerRadius * 2), Y, CornerRadius * 2, CornerRadius * 2, 270, 90);

            //Esquina inferior derecha del rectangulo redondeado
            gfxPath.AddArc(X + RectWidth - (CornerRadius * 2), Y + RectHeight - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 0, 90);

            //Esquina inferior izquierda del rectangulo redondeado
            gfxPath.AddArc(X, Y + RectHeight - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 90, 90);

            #endregion

            #region Coordenadas para dibujar bordes redondeados de colores del rectángulo

            //Esquina inferior izquierda del rectangulo redondeado
            gfxPath2.AddArc(X + 1, Y + RectHeight - (CornerRadius * 2), (CornerRadius * 2), (CornerRadius * 2), 90, 90);

            //Esquina superior izquierda del rectangulo redondeado
            gfxPath2.AddArc(X + 1, Y + 1, (CornerRadius * 2), (CornerRadius * 2), 180, 90);
            gfxPath2.AddLine(X + CornerRadius, Y + 1, X + RectWidth - 4, Y + 1);//(CornerRadius) , Y + 1);

            //Esquina superior derecha del rectangulo redondeado
            gfxPath3.AddArc(X + RectWidth - (CornerRadius * 2) - 1, Y + 1, (CornerRadius * 2), (CornerRadius * 2) , 270, 90);

            //Esquina inferior derecha del rectangulo redondeado
            gfxPath3.AddArc(X + RectWidth - (CornerRadius * 2) , Y + RectHeight - (CornerRadius * 2) - 1, (CornerRadius * 2) - 1, (CornerRadius * 2), 0, 90);
            gfxPath3.AddLine(X + RectWidth - (CornerRadius * 2), Y + RectHeight - 1, X + (CornerRadius), Y + RectHeight - 1);

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
            gfxPath.CloseFigure();

            SolidBrush oSolidBrush = new SolidBrush(Color.FromArgb(123, Color.Black));  
            //Rellenamos el Path(rectángulo) mediante la brocha de color con efecto desvaneciente
            gfxObj.FillPath(oSolidBrush, gfxPath);

            //Dibujamos el borde del Path(rectángulo) mediante un lápiz el cual recibimos del parámetro
            gfxObj.DrawPath(penObj, gfxPath);
            gfxObj.DrawPath(penObj2, gfxPath2);
            //gfxObj.DrawPath(penObj3, gfxPath3);

            //shadowPath.Dispose();//Para utilizar sombra
            gfxPath.Dispose();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //Establecemos una nueva variable de tipo Graphics a partir del panel para asignarle el rectángulo dibujado al mismo
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();

            //Generamos una nueva variable de tipo Pen y le asignamos el color negro o cualquier otro que se desee...
            Pen oPen = new Pen(Color.Black);
            Pen oPen2 = new Pen(Color.LightGray);
            Pen oPen3 = new Pen(Color.Black);

            //Invocamos al método y RoundedCornerRectangle junto con todos los parámetros necesarios
            RoundedCornerRectangle(graphicsObj, oPen, oPen2, oPen3, 0, 0, this.Width - 1, this.Height - 1, 7);

            TimeSpan t1 = new TimeSpan(8, 0,0);
            TimeSpan t2 = new TimeSpan(15, 0,0);

            //TimeScale(graphicsObj, oPen2, HoraInicial, HoraFinal);

            //Establecemos el tipo de suavidad que se aplicará a los gráficos dibujados
            //pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            //pe.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //pe.Graphics.Clear(Color.Transparent);  

            // Llamando a la clase base OnPaint
            
            base.OnPaint(pe);
            SemiTransparent();
        }

        protected override void OnCreateControl()
        {
            oHoraFinal = new TimeSpan(18, 0, 0);
            oHoraInicial = new TimeSpan(6, 0, 0); 
            //base.OnCreateControl();
        }

        protected void InvalidateEx()
        {
            if (Parent == null)
                return;
            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }

        private CreateParams SemiTransparent()
        {
            new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();

            CreateParams cp = base.CreateParams;
            cp.ExStyle |= 0x00000020;//0x20;
            return cp;//base.CreateParams; 
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;//cp.ExStyle = 0x20;
                return cp;//base.CreateParams; 
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //No se hace nada
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            //base.OnLayout(levent);
        }
    }
}
