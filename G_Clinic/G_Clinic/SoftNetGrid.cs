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
    public partial class SoftNetGrid : DataGridView
    {
        public SoftNetGrid()
        {
            InitializeComponent();
        }

        GraphicsPath gfxPath;
        GraphicsPath gfxPath2;

        private RectangleF RoundedRectangle(float X, float Y, float RectWidth, float RectHeight, float CornerRadius)
        {
            gfxPath = new GraphicsPath();
            gfxPath2 = new GraphicsPath();
            RectangleF oRectangleF = new RectangleF();

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

            #region Coordenadas para dibujar bordes redondeados delineantes del rectángulo

            //Esquina inferior izquierda del rectangulo redondeado
            gfxPath2.AddArc(X + 1, Y + RectHeight - (CornerRadius * 2) - 1, (CornerRadius * 2), (CornerRadius * 2), 90, 90);

            //Esquina superior izquierda del rectangulo redondeado
            gfxPath2.AddArc(X + 1, Y + 1, (CornerRadius * 2), (CornerRadius * 2), 180, 90);
            gfxPath2.AddLine(X + CornerRadius, Y + 1, X + RectWidth - 4, Y + 1);//(CornerRadius) , Y + 1);

            //Esquina superior derecha del rectangulo redondeado
            gfxPath2.AddArc(X + RectWidth - (CornerRadius * 2) - 1, Y + 1, (CornerRadius * 2), (CornerRadius * 2), 270, 90);

            //Esquina inferior derecha del rectangulo redondeado
            gfxPath2.AddArc(X + RectWidth - (CornerRadius * 2), Y + RectHeight - (CornerRadius * 2) - 1, (CornerRadius * 2) - 1, (CornerRadius * 2), 0, 90);
            gfxPath2.AddLine(X + RectWidth - (CornerRadius * 2), Y + RectHeight - 1, X + (CornerRadius), Y + RectHeight - 1);

            #endregion

            gfxPath.CloseFigure();
            gfxPath2.CloseFigure();

            oRectangleF = gfxPath.GetBounds();

            return oRectangleF;
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);

            try
            {
                e.CellStyle.BackColor = Color.White;

                Font oFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular, GraphicsUnit.Point);

                Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor);

                if (e.RowIndex >= 0)
                {
                    if (this.Rows[e.RowIndex].Cells[0].Selected == true)
                    {
                        RectangleF oRectF = new RectangleF();

                        if (this.HorizontalScrollBar.Visible == false)
                            oRectF = RoundedRectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 3, 
                                                      e.CellBounds.Height - 3, 4);
                        else
                            oRectF = RoundedRectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 20, 
                                                      e.CellBounds.Height - 3, 4);

                        //using (LinearGradientBrush gridBrush = new LinearGradientBrush(e.CellBounds, Color.FromArgb(233, 247, 254), Color.FromArgb(197, 233, 251), 90))//Celeste
                        using (LinearGradientBrush gridBrush = new LinearGradientBrush(e.CellBounds, Color.FromArgb(254, 247, 213), Color.FromArgb(255, 199, 28), 90))//Orange
                        {
                            //using (Pen gridLinePen = new Pen(Color.FromArgb(183, 231, 252)))//Celeste
                            using (Pen gridLinePen = new Pen(Color.FromArgb(255, 210, 86)))//Orange                            
                            {
                                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);

                                // Erase the cell.
                                e.Graphics.FillPath(gridBrush, gfxPath);

                                // Draw the inset highlight box.
                                //Pen oPen = new Pen(Color.FromArgb(183, 231, 252));//Celeste
                                Pen oPen = new Pen(Color.FromArgb(255, 210, 86));//Orange

                                e.Graphics.DrawPath(oPen, gfxPath);
                                gfxPath.Dispose();

                                //Pen oPen2 = new Pen(Color.FromArgb(243, 250, 254));//Celeste
                                Pen oPen2 = new Pen(Color.FromArgb(255, 252, 206));

                                e.Graphics.DrawPath(oPen2, gfxPath2);
                                gfxPath2.Dispose();

                                PointF oPoint = new PointF(e.CellBounds.X + 1, e.CellBounds.Y + 1);

                                // Draw the text content of the cell, ignoring alignment.
                                if (e.Value != null)
                                {
                                    e.Graphics.DrawString((String)e.Value, oFont,
                                        Brushes.Black, oPoint);
                                }
                                e.Handled = true;
                            }
                        }
                    }
                    else
                    {                        
                        e.Graphics.FillRectangle(Brushes.White, e.CellBounds);

                        PointF oPoint = new PointF(e.CellBounds.X + 1, e.CellBounds.Y + 1);

                        // Draw the text content of the cell, ignoring alignment.
                        if (e.Value != null)
                        {
                            e.Graphics.DrawString((String)e.Value, oFont,
                                Brushes.Black, oPoint);
                        }
                        e.Handled = true;
                    }
                }
            }
            catch { }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Agregar código de dibujo personalizado aquí

            // Llamando a la clase base OnPaint
            base.OnPaint(pe);
        }
    }
}
