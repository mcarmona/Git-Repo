using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections;
using System.Collections.Specialized;
using System.Threading;

namespace G_Clinic
{
    public partial class ImageViewerCtrl : UserControl
    {
        System.Windows.Forms.Timer oTimer = new System.Windows.Forms.Timer();

        private Image m_Image;
        private string m_ImageLocation;
        private int m_ImageNumber;
        private byte[] m_ImageBytes;
        private string m_TempImageLocation;

        Graphics graphicsObj = null;
        bool draw = false;

        int x, y, lastX, lastY, chosenOption = 0;

        Pen oPen = new Pen(Color.Black);
        SolidBrush oBrush = new SolidBrush(Color.Black);

        private bool m_IsThumbnail;
        private bool m_IsActive;

        public ImageViewerCtrl()
        {
            m_IsThumbnail = false;
            m_IsActive = false;

            InitializeComponent();
        }        

        public Image Image
        {
            set { m_Image = value; }
            get { return m_Image; }
        }

        public string ImageLocation
        {
            set { m_ImageLocation = value; }
            get { return m_ImageLocation; }
        }

        public string TempImageLocation
        {
            get { return m_TempImageLocation; }
            set { m_TempImageLocation = value; }
        }

        public int ImageNumber
        {
            get { return m_ImageNumber; }
            set { m_ImageNumber = value; }
        }

        public byte[] ImageBytes
        {
            get { return m_ImageBytes; }
            set { m_ImageBytes = value; }
        }

        public bool IsActive
        {
            set 
            { 
                m_IsActive = value;
                this.Invalidate();
            }
            get { return m_IsActive; }
        }

        public bool IsThumbnail
        {
            set { m_IsThumbnail = value; }
            get { return m_IsThumbnail; }
        }

        public void ImageSizeChanged(object sender, ThumbnailImageEventArgs e)
        {
            this.Width = e.Size;
            this.Height = e.Size;
            this.Invalidate();
        }

        public void LoadImage(string imageFilename, int width, int height)
        {
            Image tempImage = Image.FromFile(imageFilename);
            m_ImageLocation = imageFilename;

            int dw = tempImage.Width;
            int dh = tempImage.Height;
            int tw = width;
            int th = height;
            double zw = (tw / (double)dw);
            double zh = (th / (double)dh);
            double z = (zw <= zh) ? zw : zh;
            dw = (int)(dw * z);
            dh = (int)(dh * z);

            m_Image = new Bitmap(dw, dh);
            Graphics g = Graphics.FromImage(m_Image);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(tempImage, 0, 0, dw, dh);
            g.Dispose();

            tempImage.Dispose();
        }

        private GraphicsPath nada(Graphics gfxObj, Pen penObj, float X, float Y, float RectWidth, float RectHeight, float CornerRadius, bool draw)
        {
            GraphicsPath gfxPath = new GraphicsPath();

            try
            {
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

                gfxPath.CloseFigure();

                if (draw == true)
                    gfxObj.DrawPath(penObj, gfxPath);
            }
            catch { }
            finally
            {
                //gfxPath.Dispose();
            }

            return gfxPath;
        }

        static public GraphicsPath createRoundRect(int x, int y, int width, int height, int radius)
        {
            GraphicsPath gp = new GraphicsPath();

            if (radius == 0)
                gp.AddRectangle(new Rectangle(x, y, width, height));
            else
            {
                gp.AddLine(x + radius, y, x + width - radius, y);
                gp.AddArc(x + width - radius, y, radius, radius, 270, 90);
                gp.AddLine(x + width, y + radius, x + width, y + height - radius);
                gp.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);
                gp.AddLine(x + width - radius, y + height, x + radius, y + height);
                gp.AddArc(x, y + height - radius, radius, radius, 90, 90);
                gp.AddLine(x, y + height - radius, x, y + radius);
                gp.AddArc(x, y, radius, radius, 180, 90);
                gp.CloseFigure();
            }
            return gp;
        }

        public static Brush createFluffyBrush(GraphicsPath gp, float[] blendPositions, float[] blendFactors)
        {
            PathGradientBrush pgb = new PathGradientBrush(gp);
            Blend blend = new Blend();
            blend.Positions = blendPositions;
            blend.Factors = blendFactors;
            pgb.Blend = blend;
            pgb.CenterColor = Color.White;
            pgb.SurroundColors = new Color[] { Color.Black };
            return pgb;
        }

        public enum ChannelARGB
        {
            Blue = 0,
            Green = 1,
            Red = 2,
            Alpha = 3
        }

        public static void transferOneARGBChannelFromOneBitmapToAnother(Bitmap source, Bitmap dest, ChannelARGB sourceChannel, ChannelARGB destChannel)
        {
            if (source.Size != dest.Size)
                throw new ArgumentException();

            Rectangle r = new Rectangle(Point.Empty, source.Size);
            BitmapData bdSrc = source.LockBits(r, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData bdDst = dest.LockBits(r, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* bpSrc = (byte*)bdSrc.Scan0.ToPointer();
                byte* bpDst = (byte*)bdDst.Scan0.ToPointer();
                bpSrc += (int)sourceChannel;
                bpDst += (int)destChannel;
                for (int i = r.Height * r.Width; i > 0; i--)
                {
                    *bpDst = *bpSrc;
                    bpSrc += 4;
                    bpDst += 4;
                }
            }
            source.UnlockBits(bdSrc);
            dest.UnlockBits(bdDst);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (g == null) return;
            if (m_Image == null) return;

            int dw = m_Image.Width;
            int dh = m_Image.Height;
            int tw = this.Width -8; // remove border, 4*4 
            int th = this.Height -8; // remove border, 4*4 
            double zw = (tw / (double)dw);
            double zh = (th / (double)dh);
            double z = (zw <= zh) ? zw : zh;

            dw = (int)(dw * z);
            dh = (int)(dh * z);
            int dl = 4 + (tw - dw) / 2; // add border 2*2
            int dt = 4 + (th - dh) / 2; // add border 2*2

            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (m_IsThumbnail)
            {
                Bitmap bmpFluffy = new Bitmap((Bitmap)m_Image);
                Rectangle r = new Rectangle(Point.Empty, bmpFluffy.Size);

                using (Bitmap bmpMask = new Bitmap(r.Width, r.Height))
                using (Graphics g2 = Graphics.FromImage(bmpMask))
                using (GraphicsPath path = createRoundRect(r.X, r.Y, r.Width, r.Height, Math.Min(r.Width, r.Height) / 5))
                using (Brush brush = createFluffyBrush(path, new float[] { 0.0f, 0.1f, 0.1f, 1.0f } , new float[] { 0.05f, 1.5f, 3.5f, 3.5f }))//new float[] { 0.0f, 0.1f, 1.0f }, new float[] { 0.0f, 0.95f, 1.0f }))
                {
                    g2.FillRectangle(Brushes.Black, r);
                    g2.SmoothingMode = SmoothingMode.HighQuality;
                    g2.FillPath(brush, path);
                    transferOneARGBChannelFromOneBitmapToAnother(bmpMask, bmpFluffy, ChannelARGB.Blue, ChannelARGB.Alpha);
                }

                g.DrawImage((Image)bmpFluffy, dl, dt, dw, dh);
            }
            else 
                g.DrawImage(m_Image, dl, dt, dw, dh);
            
            //if (m_IsActive)
        }

        private void OnResize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void ImageViewerCtrl_MouseDown(object sender, MouseEventArgs e)
        {
            if (draw == false)
            {
                x = e.X;
                y = e.Y;
            }

            draw = true;
        }

        private void ImageViewerCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            lastX = e.X;
            lastY = e.Y;

            if (draw)
            {
                Thread.Sleep(3000);
                //graphicsObj.FillEllipse(oBrush, e.X, e.Y, 3, 7);
                graphicsObj.DrawLine(oPen, e.X, e.Y, e.X + 1, e.Y + 1);                
            }
            //PaintEventArgs e2 = new PaintEventArgs(graphicsObj, new Rectangle(0, 0, this.Width, this.Height));
            //ImageViewerCtrl_Paint(sender, e2);
        }

        private void ImageViewerCtrl_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;

            lastX = e.X;
            lastY = e.Y;            
        }

        private void DrawLine()
        {
            //if (draw == true)
                //graphicsObj.DrawLine(oPen, //.DrawEllipse(oPen, x, y, 2, 2);//.DrawPath(oPen, new GraphicsPath());

            //GraphicsPath oGraphicsPath = new GraphicsPath();
            
        }

        private void ImageViewerCtrl_Paint(object sender, PaintEventArgs e)
        {
            
            //if (IsThumbnail == false)
            //{
            //    switch (chosenOption)
            //    {
            //        case 0: DrawLine();
            //            break;
            //    };
            //}
        }

        private void ImageViewerCtrl_Load(object sender, EventArgs e)
        {
            toolStrip2.Parent = this;
            graphicsObj = this.CreateGraphics();

            if (IsThumbnail == false)
                toolStrip2.Visible = true;
            else
                toolStrip2.Visible = false;
        }

        private void tobPen_Click(object sender, EventArgs e)
        {

        }
    }

    public class ThumbnailImageEventArgs : EventArgs
    {
        public ThumbnailImageEventArgs(int size)
        {
            this.Size = size;
        }

        public int Size;
    }

    public delegate void ThumbnailImageEventHandler(object sender, ThumbnailImageEventArgs e);
}
