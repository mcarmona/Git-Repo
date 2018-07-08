using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Miscelaneos_y_Recursos;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmOrb : Form
    {
        public frmOrb()
        {
            InitializeComponent();
        }

        #region Set Transparent Background

        /// <para>Changes the current bitmap.</para>
        public void SetBitmap(Bitmap bitmap)
        {
            SetBitmap(bitmap, 255);
        }

        /// <para>Changes the current bitmap with a custom opacity level.  Here is where all happens!</para>
        public void SetBitmap(Bitmap bitmap, byte opacity)
        {
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

            // The ideia of this is very simple,
            // 1. Create a compatible DC with screen;
            // 2. Select the bitmap with 32bpp with alpha-channel in the compatible DC;
            // 3. Call the UpdateLayeredWindow.

            IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
            IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));  // grab a GDI handle from this GDI+ bitmap
                oldBitmap = Win32.SelectObject(memDc, hBitmap);

                Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.Point pointSource = new Win32.Point(0, 0);
                Win32.Point topPos = new Win32.Point(Left, Top);
                Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
                blend.BlendOp = Win32.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = opacity;
                blend.AlphaFormat = Win32.AC_SRC_ALPHA;

                Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
            }
            finally
            {
                Win32.ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBitmap);
                    //Windows.DeleteObject(hBitmap); // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from Win32 GDI and it's working fine without any resource leak.
                    Win32.DeleteObject(hBitmap);
                }
                Win32.DeleteDC(memDc);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00080000; // This form has to have the WS_EX_LAYERED extended style
                return cp;
            }
        }

        #endregion

        public void OrbLocation()
        {
            try
            {
                this.Location = new Point(Program.oMDI.Location.X + 16, Program.oMDI.Location.Y + 25);
            }
            catch
            {
                this.Location = new Point(16, 25);
            }
        }

        private void frmOrb_Load(object sender, EventArgs e)
        {
            //activo = true;
            Bitmap oBitmap = new Bitmap(this.BackgroundImage);
            SetBitmap(oBitmap);

            OrbLocation();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            try
            {
                this.BackgroundImage = Properties.Resources.SoftNet_Orb_64_highlighted_2;

                Bitmap oBitmap = new Bitmap(this.BackgroundImage);
                SetBitmap(oBitmap);
            }
            catch { }

            base.OnMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            try
            {
                this.BackgroundImage = Properties.Resources.SoftNet_Orb_64_Pressed;

                Bitmap oBitmap = new Bitmap(this.BackgroundImage);
                SetBitmap(oBitmap);
            }
            catch { }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            try
            {
                this.BackgroundImage = Properties.Resources.SoftNet_Orb_64_highlighted_2;

                Bitmap oBitmap = new Bitmap(this.BackgroundImage);
                SetBitmap(oBitmap);
            }
            catch { }

            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            try
            {
                this.BackgroundImage = Properties.Resources.SoftNet_Orb_64;

                Bitmap oBitmap = new Bitmap(this.BackgroundImage);
                SetBitmap(oBitmap);

                Program.oMDI.Activate();
            }
            catch { }

            base.OnMouseLeave(e);
        }

        private void frmOrb_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}