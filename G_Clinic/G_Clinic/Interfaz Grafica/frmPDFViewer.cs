using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmPDFViewer : Form
    {
        #region Variables

        string path = "";

        private bool dragging;
        private bool resizing;
        private bool resizingUp;
        private bool resizingDown;
        private bool resizingLeft;
        private bool resizingRight;
        private int border = 4;
        private Size previousSize;
        private Point previousLocation;
        private Point offset;

        #endregion

        public frmPDFViewer(string pPath)
        {
            InitializeComponent();
            path = pPath;

            //this.Region = Shape.RoundedRegion(this.Size, 8, Shape.Corner.None);

            this.softNet_AdobePDFViewer1.toolStrip1.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.softNet_AdobePDFViewer1.toolStrip1.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.softNet_AdobePDFViewer1.toolStrip1.MouseUp += new MouseEventHandler(Form1_MouseUp);

            this.softNet_AdobePDFViewer1.toolStripButton7.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.softNet_AdobePDFViewer1.toolStripButton7.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.softNet_AdobePDFViewer1.toolStripButton7.MouseUp += new MouseEventHandler(Form1_MouseUp);

            this.softNet_AdobePDFViewer1.toolStripLabel3.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.softNet_AdobePDFViewer1.toolStripLabel3.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.softNet_AdobePDFViewer1.toolStripLabel3.MouseUp += new MouseEventHandler(Form1_MouseUp);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            offset = e.Location;
            if (resizing)
            {
                previousSize = this.Size;
                previousLocation = this.Location;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            resizing = false;
            resizingUp = false;
            resizingDown = false;
            resizingLeft = false;
            resizingRight = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                if (resizing)
                {
                    Point currentScreenPos = PointToScreen(e.Location);

                    //if (resizingLeft)
                    //{
                    //    if (resizingUp)
                    //    {
                    //        this.Width = previousLocation.X + previousSize.Width - currentScreenPos.X + offset.X;
                    //        this.Height = previousLocation.Y + previousSize.Height - currentScreenPos.Y + offset.Y;
                    //        this.Location = new Point
                    //        (previousLocation.X + previousSize.Width - this.Width,
                    //        previousLocation.Y + previousSize.Height - this.Height);
                    //    }
                    //    else if (resizingDown)
                    //    {
                    //        this.Width = previousLocation.X + previousSize.Width - currentScreenPos.X + offset.X;
                    //        this.Height = currentScreenPos.Y - previousLocation.Y + previousSize.Height - offset.Y;
                    //        this.Location = new Point
                    //        (previousLocation.X + previousSize.Width - this.Width,
                    //        previousLocation.Y);
                    //    }
                    //    else
                    //    {
                    //        this.Width = previousLocation.X + previousSize.Width - currentScreenPos.X + offset.X;
                    //        this.Location = new Point(previousLocation.X + previousSize.Width - this.Width, previousLocation.Y);
                    //    }
                    //}
                    //else if (resizingRight)
                    //{
                    //    if (resizingUp)
                    //    {
                    //        this.Width = currentScreenPos.X - previousLocation.X + previousSize.Width - offset.X;
                    //        this.Height = previousLocation.Y + previousSize.Height - currentScreenPos.Y + offset.Y;
                    //        this.Location = new Point
                    //        (previousLocation.X,
                    //        previousLocation.Y + previousSize.Height - this.Height);
                    //    }
                    //    else if (resizingDown)
                    //    {
                    //        this.Width = currentScreenPos.X - previousLocation.X + previousSize.Width - offset.X;
                    //        this.Height = currentScreenPos.Y - previousLocation.Y + previousSize.Height - offset.Y;
                    //    }
                    //    else
                    //    {
                    //        this.Width = currentScreenPos.X - previousLocation.X + previousSize.Width - offset.X;
                    //    }
                    //}
                    //else if (resizingUp)
                    //{
                    //    this.Height = previousLocation.Y + previousSize.Height - currentScreenPos.Y + offset.Y;
                    //    this.Location = new Point(previousLocation.X, previousLocation.Y + previousSize.Height - this.Height);
                    //}
                    //else if (resizingDown)
                    //{
                    //    this.Height = currentScreenPos.Y - previousLocation.Y + previousSize.Height - offset.Y;
                    //}
                }
                else
                {
                    Point currentScreenPos = PointToScreen(e.Location);
                    Location = new Point
                    (currentScreenPos.X - offset.X,
                    currentScreenPos.Y - offset.Y);
                }
            }
            //else
            //{
            //    if (e.X <= border)
            //    {
            //        resizing = true;
            //        resizingUp = false;
            //        resizingDown = false;
            //        resizingLeft = true;
            //        resizingRight = false;

            //        if (e.Y <= border)
            //        {
            //            this.Cursor = Cursors.SizeNWSE;
            //            resizingUp = true;
            //        }
            //        else if (e.Y >= this.Height - border)
            //        {
            //            this.Cursor = Cursors.SizeNESW;
            //            resizingDown = true;
            //        }
            //        else
            //        {
            //            this.Cursor = Cursors.SizeWE;
            //        }
            //    }
            //    else if (e.X >= this.Width - border)
            //    {
            //        resizing = true;
            //        resizingUp = false;
            //        resizingDown = false;
            //        resizingLeft = false;
            //        resizingRight = true;

            //        if (e.Y <= border)
            //        {
            //            this.Cursor = Cursors.SizeNESW;
            //            resizingUp = true;
            //        }
            //        else if (e.Y >= this.Height - border)
            //        {
            //            this.Cursor = Cursors.SizeNWSE;
            //            resizingDown = true;
            //        }
            //        else
            //        {
            //            this.Cursor = Cursors.SizeWE;
            //        }
            //    }
            //    else if (e.Y <= border)
            //    {
            //        resizing = true;
            //        resizingUp = true;
            //        resizingLeft = false;
            //        resizingRight = false;
            //        this.Cursor = Cursors.SizeNS;
            //    }
            //    else if (e.Y >= this.Height - border)
            //    {
            //        resizing = true;
            //        resizingDown = true;
            //        resizingLeft = false;
            //        resizingRight = false;
            //        this.Cursor = Cursors.SizeNS;
            //    }
            //    else
            //    {
            //        this.Cursor = Cursors.Default;
            //        resizing = false;
            //        resizingUp = false;
            //        resizingDown = false;
            //        resizingLeft = false;
            //        resizingRight = false;
            //    }
            //}
        }

        private void frmPDFViewer_Load(object sender, EventArgs e)
        {
            this.softNet_AdobePDFViewer1.btnFullSize.Visible = false;

            softNet_AdobePDFViewer1.FileLocation = path;
            softNet_AdobePDFViewer1.OpenDocument();
        }

        private void imagenCambiantePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imagenCambiantePictureBox2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }
    }
}
