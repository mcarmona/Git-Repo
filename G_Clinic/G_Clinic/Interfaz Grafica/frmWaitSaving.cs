using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic
{
    public partial class FrmWaitSaving : Form
    {
        public FrmWaitSaving()
        {
            InitializeComponent();
            this.SetStyles();
        }

        private void SetStyles()
        {
            //Makes sure the form repaints when it was resized
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void FrmWait_Activated(object sender, EventArgs e)
        {
            //pictureBox4.Refresh();
        }

        private void FrmWait_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.MaximumSize = Program.oMDI.MaximumSize;
            this.Height = Program.oMDI.ClientSize.Height;
            this.Width = Program.oMDI.ClientSize.Width;
            this.SetDesktopBounds(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void FrmWait_Enter(object sender, EventArgs e)
        {
            //pictureBox4.Refresh();
        }

        private void FrmWait_Shown(object sender, EventArgs e)
        {
            //pictureBox4.Refresh(); 
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PictureBox oPictureBox = new PictureBox();
            //oPictureBox.Image = Resource1.loading6_3;
            oPictureBox.Visible = true;
            //oPictureBox.Location = new Point((this.Width / 2) - (pictureBox4.Width / 2), this.Height / 2 + 55);
            //this.Controls.Add(oPictureBox);  
        }

        private void FrmWait_FormClosed(object sender, FormClosedEventArgs e)
        {
            //backgroundWorker1.CancelAsync(); 
        }

        private void FrmWait_SizeChanged(object sender, EventArgs e)
        {
            //this.Visible = true;
        }
    }
}