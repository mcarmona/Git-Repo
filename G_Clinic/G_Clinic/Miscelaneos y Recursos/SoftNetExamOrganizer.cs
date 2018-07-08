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
    public partial class SoftNetExamOrganizer : DataGridView
    {
        #region Variables

        Font oFont = null;

        Font oFuente = new Font("Segoe Print", 11, FontStyle.Regular);
        public Font OFuente
        {
            get { return oFuente; }
            set { oFuente = value; }
        }

        Font generalFont = new Font("Segoe UI", 10, FontStyle.Regular);
        public Font GeneralFont
        {
            get { return generalFont; }
            set { generalFont = value; }
        }

        Font oFuente2 = new Font("Segoe UI", 10, FontStyle.Regular);
        public Font OFuente2
        {
            get { return oFuente2; }
            set { oFuente2 = value; }
        }

        Color columnHeaderColor = Color.Black;
        public Color ColumnHeaderColor
        {
            get { return columnHeaderColor; }
            set { columnHeaderColor = value; }
        }

        Font columnHeaderFont = new Font("Segoe UI", 10, FontStyle.Regular);
        public Font ColumnHeaderFont
        {
            get { return columnHeaderFont; }
            set { columnHeaderFont = value; }
        }

        Color rowHeaderColor = Color.Black;
        public Color RowHeaderColor
        {
            get { return rowHeaderColor; }
            set { rowHeaderColor = value; }
        }

        Font rowHeaderFont = new Font("Segoe UI", 10, FontStyle.Regular);
        public Font RowHeaderFont
        {
            get { return rowHeaderFont; }
            set { rowHeaderFont = value; }
        }

        #endregion

        public SoftNetExamOrganizer()
        {
            InitializeComponent();
            //AgregarFilaInicial();

            //oFont = this.Font;
        }

        #region Variables y Encapsulaciones

        GraphicsPath gfxPath;
        GraphicsPath gfxPath2;

        /// <summary>
        /// Parámetro que se mostrará en la columna inicial para denotar el encabezado de las columnas
        /// </summary>
        string headerRow = "";
        public string HeaderRow
        {
            get { return headerRow; }
            set { headerRow = value; }
        }

        /// <summary>
        /// Parámetro que se mostrará en la columna inicial para denotar el encabezado de las filas
        /// </summary>
        string headerColumn = "";
        public string HeaderColumn
        {
            get { return headerColumn; }
            set { headerColumn = value; }
        }


        string stringToUse = "";

        public string StringToUse
        {
            get { return stringToUse; }
            set { stringToUse = value; }
        }

        #endregion

        private void AgregarFilaInicial()
        {
            DataGridViewColumn oColumn = new DataGridViewColumn();

            oColumn.CellTemplate = new DataGridViewTextBoxCell();
            oColumn.Name = "BaseColumn";
            oColumn.HeaderText = "";
            oColumn.Frozen = true;
            oColumn.Visible = true;
            oColumn.Width = 116;
            oColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.Columns.Insert(0, oColumn); //.Add(oColumn);
            this.ColumnHeadersVisible = false;

            this.Rows.Add();

            this.Rows[0].Cells[0].ReadOnly = true;
            this.Rows[0].Height = 40;
            //this.Rows[0].Cells[0].Style.Font = oFuente;
            //this.Rows[0].DefaultCellStyle.Font = columnHeaderFont;
        }

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

        private float MeasureTextHeight(string pCadenaTexto, Font pFont)
        {
            Graphics oGraphics = this.CreateGraphics();
            float textHeight = 0;

            string[] ocadenaTemp = null;
            char[] caracterBuscado = { '\r', '\n' };

            ocadenaTemp = pCadenaTexto.Split(caracterBuscado, StringSplitOptions.RemoveEmptyEntries);

            textHeight = oGraphics.MeasureString(pCadenaTexto, pFont).Height;

            return textHeight;
        }

        private float MeasureTextWidth(string pCadenaTexto, Font pFont)
        {
            Graphics oGraphics = this.CreateGraphics();
            float textWidth = 0;

            textWidth = oGraphics.MeasureString(pCadenaTexto, pFont).Width;

            return textWidth;
        }

        private String FormattedString(string pCadenaTexto, Font pFont)
        {
            stringToUse = "";
            string newString = "";
            string auxNewString = "";
            string auxNewString2 = "";

            string[] ocadenaTemp = null;
            char[] caracterBuscado = { ' ' };
            int fragmentWidth = 0;

            ocadenaTemp = pCadenaTexto.Split(caracterBuscado);

            if (ocadenaTemp.Length > 1)
            {
                for (int i = 0; i < ocadenaTemp.Length; )
                {
                    newString += ocadenaTemp[i].Trim() + " ";
                    fragmentWidth += Convert.ToInt32(MeasureTextWidth(ocadenaTemp[i].Trim() + "", pFont));

                    if (fragmentWidth <= 185)//this.Rows[this.CurrentRow.Index].Cells[CurrentCell.ColumnIndex].ContentBounds.Width) //185)
                    {
                        //newString += ocadenaTemp[i].Trim() + " ";
                        i++;
                    }
                    else
                    {
                        fragmentWidth = 0;
                        //newString = "";
                        newString += Environment.NewLine;

                        i++;
                        //if (ocadenaTemp[i].Length == 1)
                        //    i++;
                    }

                    //i++;
                }
            }
            else
            {
                int contador = 1;
                int indiceCorte = 0;
                int inicio = 0;

                newString = "";

                string cadenaOriginal = ocadenaTemp[0].Trim();

                for (int c = 0; c < cadenaOriginal.Length; )
                {
                    if (indiceCorte <= this.Rows[this.CurrentRow.Index].Cells[CurrentCell.ColumnIndex].Size.Width)//ContentBounds.Width)
                    {
                        newString = cadenaOriginal.Substring(inicio, contador);
                        indiceCorte = Convert.ToInt32(MeasureTextWidth(newString, pFont));

                        contador++;
                    }
                    else
                    {
                        newString += Environment.NewLine;
                        auxNewString += newString;
                        newString = "";
                        indiceCorte = 0;
                        inicio = contador - 1;
                        contador = 1;
                        c--;
                    }
                    c++;
                }

                auxNewString2 = auxNewString + newString;

                if (auxNewString2.Contains("\r\n\r\n"))
                    auxNewString2 = auxNewString2.Replace("\r\n\r\n", "\r\n");

                if (auxNewString2.Contains("\r\n\n"))
                    auxNewString2 = auxNewString2.Replace("\r\n\n", "\r\n");

                newString = auxNewString2;
            }

            //newString = auxNewString + newString;

            stringToUse = newString;

            if (stringToUse.EndsWith(" "))
            {
                stringToUse = stringToUse.Substring(0, stringToUse.Length - 1);
                newString = stringToUse;
            }

            return newString;
        }

        private Point TextLocation(Rectangle pRect, Rectangle pRectContentBounds, string pCellText, int pRowIndex, int pColumnIndex)
        {
            int middleCenter = 0;
            int middleHeight = 0;

            Font oFont2 = null;

            if (pRowIndex == 0)
                oFont2 = ColumnHeaderFont;
            else
                oFont2 = RowHeaderFont;

            if (pColumnIndex != 0)
            {
                //middleCenter = (pRect.X + (pRect.Width - Convert.ToInt32(MeasureTextWidth(pCellText, this.Font))) / 2);
                //middleHeight = (pRect.Y + (pRect.Height - Convert.ToInt32(MeasureTextHeight(pCellText, this.Font))) / 2);
                if (pRowIndex == 0)
                {
                    middleCenter = (pRect.X + (pRect.Width - Convert.ToInt32(MeasureTextWidth(pCellText, oFont2))) / 2);
                    middleHeight = (pRect.Y + (pRect.Height - Convert.ToInt32(MeasureTextHeight(pCellText, oFont2))) / 2);
                }
                else
                {
                    middleCenter = (pRect.X + (pRect.Width - Convert.ToInt32(MeasureTextWidth(pCellText, generalFont))) / 2);
                    middleHeight = (pRect.Y + (pRect.Height - Convert.ToInt32(MeasureTextHeight(pCellText, generalFont))) / 2);
                }
            }
            else
            {
                //middleCenter = (pRect.X + (pRect.Width - Convert.ToInt32(MeasureTextWidth(pCellText, oFuente2))) / 2);
                //middleHeight = (pRect.Y + (pRect.Height - Convert.ToInt32(MeasureTextHeight(pCellText, oFuente2))) / 2);
                middleCenter = (pRect.X + (pRect.Width - Convert.ToInt32(MeasureTextWidth(pCellText, oFont2))) / 2);
                middleHeight = (pRect.Y + (pRect.Height - Convert.ToInt32(MeasureTextHeight(pCellText, oFont2))) / 2);
            }

            Point oPoint = new Point(middleCenter, middleHeight);

            return oPoint;
        }

        private Size AutoCellSize(string pCellValue, int pIndex, Font pFont)
        {
            string formatedText = FormattedString(pCellValue.Trim(), pFont);
            Size oSize = new Size();

            int cellHeight = 0;
            int cellWidth = 0;

            if (pIndex != 0)
            {
                //cellHeight = Convert.ToInt32(MeasureTextHeight(FormattedString(pCellValue.Trim(), oFont), oFont) + 5);
                //cellWidth = Convert.ToInt32(MeasureTextWidth(FormattedString(pCellValue.Trim(), oFont), oFont) + 5);
                cellHeight = Convert.ToInt32(MeasureTextHeight(formatedText, pFont) + 5);
                cellWidth = Convert.ToInt32(MeasureTextWidth(formatedText, pFont) + 5);
            }
            else
            {
                //cellHeight = Convert.ToInt32(MeasureTextHeight(FormattedString(pCellValue.Trim(), oFuente2), oFuente2) + 5);
                //cellWidth = Convert.ToInt32(MeasureTextWidth(FormattedString(pCellValue.Trim(), oFuente2), oFuente2) + 5);
                cellHeight = Convert.ToInt32(MeasureTextHeight(formatedText, pFont) + 5);
                cellWidth = Convert.ToInt32(MeasureTextWidth(formatedText, pFont) + 5);
            }

            oSize.Width = cellWidth;
            oSize.Height = cellHeight;

            return oSize;
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);

            try
            {
                e.CellStyle.BackColor = Color.White;

                if (e.RowIndex == 0 && e.ColumnIndex == 0)
                {
                    if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == false)
                    {
                        if (e.RowIndex == 0 && e.ColumnIndex == 0)
                        {
                            Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor);

                            RectangleF oRectF = new RectangleF();
                            oRectF = RoundedRectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1, 4);

                            using (LinearGradientBrush gridBrush = new LinearGradientBrush(oRectF, Color.FromArgb(254, 247, 213), Color.FromArgb(255, 199, 28), 90))//Orange
                            {
                                using (Pen gridLinePen = new Pen(Color.FromArgb(255, 210, 86)))//Orange                            
                                {
                                    e.Graphics.FillRectangle(Brushes.White, e.CellBounds);

                                    if (e.ColumnIndex == this.ColumnCount - 1)
                                    {
                                        Rectangle oRect = e.CellBounds;
                                        oRect.X = oRect.Width - 3;
                                        SolidBrush oSolidBrush = new SolidBrush(this.BackgroundColor);
                                        e.Graphics.FillRectangle(oSolidBrush, oRect);
                                    }

                                    // Erase the cell.
                                    e.Graphics.FillPath(gridBrush, gfxPath);

                                    // Draw the inset highlight box.
                                    Pen oPen = new Pen(Color.FromArgb(255, 210, 86));//Orange

                                    e.Graphics.DrawPath(oPen, gfxPath);
                                    gfxPath.Dispose();

                                    Pen oPen2 = new Pen(Color.FromArgb(255, 252, 206));

                                    e.Graphics.DrawPath(oPen2, gfxPath2);
                                    gfxPath2.Dispose();

                                    Pen oPen3 = new Pen(Color.FromArgb(204, 148, 0));
                                    e.Graphics.DrawLine(oPen3, 6, 6, e.CellBounds.Width - 5, e.CellBounds.Height - 5);


                                    SolidBrush oBrush = new SolidBrush(Color.Black);//.FromArgb(204, 148, 0));
                                    //string headerRow = "Fecha";
                                    //string headerColumn = "Examen";

                                    Font oFuente = new Font("Segoe Print", 11, FontStyle.Regular);

                                    PointF oPoint = new PointF((e.CellBounds.Width / 2) - 2, e.CellBounds.Y - 4);
                                    e.Graphics.DrawString(headerColumn, oFuente, oBrush, oPoint);

                                    oPoint = new PointF((e.CellBounds.X) + 5, e.CellBounds.Height - 25);
                                    e.Graphics.DrawString(headerRow, oFuente, oBrush, oPoint);

                                    //if (this.CurrentCell.Style.Font == null)
                                    //    this.CurrentCell.Style.Font = oFuente;

                                    e.Handled = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        //Darker Orange
                        //253,241,185
                        //249,152,48

                        Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor);

                        RectangleF oRectF = new RectangleF();
                        oRectF = RoundedRectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1, 4);

                        using (LinearGradientBrush gridBrush = new LinearGradientBrush(oRectF, Color.FromArgb(253, 241, 185), Color.FromArgb(249, 152, 48), 90))//Orange
                        {
                            using (Pen gridLinePen = new Pen(Color.FromArgb(255, 210, 86)))//Orange                            
                            {
                                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);

                                if (e.ColumnIndex == this.ColumnCount - 1)
                                {
                                    Rectangle oRect = e.CellBounds;
                                    oRect.X = oRect.Width - 3;
                                    SolidBrush oSolidBrush = new SolidBrush(this.BackgroundColor);
                                    e.Graphics.FillRectangle(oSolidBrush, oRect);
                                }

                                // Erase the cell.
                                e.Graphics.FillPath(gridBrush, gfxPath);

                                // Draw the inset highlight box.
                                Pen oPen = new Pen(Color.FromArgb(255, 210, 86));//Orange

                                e.Graphics.DrawPath(oPen, gfxPath);
                                gfxPath.Dispose();

                                Pen oPen2 = new Pen(Color.FromArgb(255, 252, 206));

                                e.Graphics.DrawPath(oPen2, gfxPath2);
                                gfxPath2.Dispose();

                                Pen oPen3 = new Pen(Color.FromArgb(204, 148, 0));
                                e.Graphics.DrawLine(oPen3, 6, 6, e.CellBounds.Width - 5, e.CellBounds.Height - 5);

                                SolidBrush oBrush = new SolidBrush(Color.Black);//.FromArgb(204, 148, 0));
                                //string headerRow = "Fecha";
                                //string headerColumn = "Examen";

                                Font oFuente = new Font("Segoe Print", 11, FontStyle.Regular);

                                PointF oPoint = new PointF((e.CellBounds.Width / 2) - 2, e.CellBounds.Y - 4);
                                e.Graphics.DrawString(headerColumn, oFuente, oBrush, oPoint);

                                oPoint = new PointF((e.CellBounds.X) + 5, e.CellBounds.Height - 25);
                                e.Graphics.DrawString(headerRow, oFuente, oBrush, oPoint);

                                //if (this.CurrentCell.Style.Font == null)
                                //    this.CurrentCell.Style.Font = oFuente;

                                e.Handled = true;
                            }
                        }
                    }
                }
                else
                {
                    if (e.RowIndex == 0 || e.ColumnIndex == 0)
                    {
                        if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == false)
                        {
                            RectangleF oRectF = new RectangleF();
                            oRectF = RoundedRectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1, 4);

                            using (LinearGradientBrush gridBrush = new LinearGradientBrush(oRectF, Color.FromArgb(233, 247, 254), Color.FromArgb(197, 233, 251), 90))//Celeste
                            {
                                using (Pen gridLinePen = new Pen(Color.FromArgb(183, 231, 252)))//Celeste
                                {
                                    e.Graphics.FillRectangle(Brushes.White, e.CellBounds);

                                    if (e.ColumnIndex == this.ColumnCount - 1)
                                    {
                                        Rectangle oRect = e.CellBounds;
                                        oRect.X = (oRect.X + oRect.Width) - 3;
                                        SolidBrush oSolidBrush = new SolidBrush(this.BackgroundColor);
                                        e.Graphics.FillRectangle(oSolidBrush, oRect);
                                    }

                                    // Erase the cell.
                                    e.Graphics.FillPath(gridBrush, gfxPath);

                                    // Draw the inset highlight box.
                                    Pen oPen = new Pen(Color.FromArgb(183, 231, 252));//Celeste

                                    e.Graphics.DrawPath(oPen, gfxPath);
                                    gfxPath.Dispose();

                                    Pen oPen2 = new Pen(Color.FromArgb(243, 250, 254));//Celeste

                                    e.Graphics.DrawPath(oPen2, gfxPath2);
                                    gfxPath2.Dispose();

                                    PointF oPoint = new PointF(e.CellBounds.X + 1, e.CellBounds.Y + 1);

                                    // Draw the text content of the cell, ignoring alignment.
                                    if (e.Value != null)
                                    {
                                        //e.Graphics.DrawString((String)e.Value, oFuente2,
                                        //Brushes.Black,
                                        //TextLocation(e.CellBounds, this.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds, e.Value.ToString().Trim(), e.RowIndex, e.ColumnIndex));

                                        if (e.ColumnIndex == 0)
                                        {
                                            Brush oBrush = new SolidBrush(RowHeaderColor);

                                            //if (this.CurrentCell.Style.Font == null)
                                            //    this.CurrentCell.Style.Font = RowHeaderFont;

                                            e.Graphics.DrawString((String)e.Value, RowHeaderFont,
                                                                  oBrush,
                                            TextLocation(e.CellBounds, this.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds, e.Value.ToString().Trim(), e.RowIndex, e.ColumnIndex));
                                        }
                                        else
                                        {
                                            Brush oBrush = new SolidBrush(ColumnHeaderColor);

                                            //if (this.CurrentCell.Style.Font == null)
                                            //    this.CurrentCell.Style.Font = ColumnHeaderFont;

                                            e.Graphics.DrawString((String)e.Value, ColumnHeaderFont,
                                                                  oBrush,
                                            TextLocation(e.CellBounds, this.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds, e.Value.ToString().Trim(), e.RowIndex, e.ColumnIndex));
                                        }
                                    }

                                    e.Handled = true;
                                }
                            }
                        }
                        else
                        {
                            //10,152,214
                            RectangleF oRectF = new RectangleF();
                            oRectF = RoundedRectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1, 4);

                            using (LinearGradientBrush gridBrush = new LinearGradientBrush(oRectF, Color.FromArgb(233, 247, 254), Color.FromArgb(131, 214, 250), 90))//Celeste
                            {
                                using (Pen gridLinePen = new Pen(Color.FromArgb(183, 231, 252)))//Celeste
                                {
                                    e.Graphics.FillRectangle(Brushes.White, e.CellBounds);

                                    if (e.ColumnIndex == this.ColumnCount - 1)
                                    {
                                        Rectangle oRect = e.CellBounds;
                                        oRect.X = (oRect.X + oRect.Width) - 3;
                                        SolidBrush oSolidBrush = new SolidBrush(this.BackgroundColor);
                                        e.Graphics.FillRectangle(oSolidBrush, oRect);
                                    }

                                    // Erase the cell.
                                    e.Graphics.FillPath(gridBrush, gfxPath);

                                    // Draw the inset highlight box.
                                    Pen oPen = new Pen(Color.FromArgb(183, 231, 252));//Celeste

                                    e.Graphics.DrawPath(oPen, gfxPath);
                                    gfxPath.Dispose();

                                    Pen oPen2 = new Pen(Color.FromArgb(243, 250, 254));//Celeste

                                    e.Graphics.DrawPath(oPen2, gfxPath2);
                                    gfxPath2.Dispose();

                                    PointF oPoint = new PointF(e.CellBounds.X + 1, e.CellBounds.Y + 1);

                                    // Draw the text content of the cell, ignoring alignment.
                                    if (e.Value != null)
                                    {
                                        //e.Graphics.DrawString((String)e.Value, oFuente2,
                                        //                      Brushes.Black,
                                        //TextLocation(e.CellBounds, this.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds, e.Value.ToString().Trim(), e.RowIndex, e.ColumnIndex));

                                        if (e.ColumnIndex == 0)
                                        {
                                            Brush oBrush = new SolidBrush(RowHeaderColor);

                                            //if (this.CurrentCell.Style.Font == null)
                                            //    this.CurrentCell.Style.Font = RowHeaderFont;

                                            e.Graphics.DrawString((String)e.Value, RowHeaderFont,
                                                                  oBrush,
                                            TextLocation(e.CellBounds, this.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds, e.Value.ToString().Trim(), e.RowIndex, e.ColumnIndex));
                                        }
                                        else
                                        {
                                            Brush oBrush = new SolidBrush(ColumnHeaderColor);

                                            //if (this.CurrentCell.Style.Font == null)
                                            //    this.CurrentCell.Style.Font = ColumnHeaderFont;

                                            e.Graphics.DrawString((String)e.Value, ColumnHeaderFont,
                                                                  oBrush,
                                            TextLocation(e.CellBounds, this.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds, e.Value.ToString().Trim(), e.RowIndex, e.ColumnIndex));
                                        }
                                    }

                                    e.Handled = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == true)
                        {
                            RectangleF oRectF = new RectangleF();
                            oRectF = RoundedRectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2, e.CellBounds.Height - 2, 4);

                            e.Graphics.FillRectangle(Brushes.White, oRectF);

                            oRectF = RoundedRectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4,
                                                      e.CellBounds.Height - 4, 4);

                            using (LinearGradientBrush gridBrush = new LinearGradientBrush(e.CellBounds, Color.FromArgb(255, 255, 255), Color.FromArgb(253, 248, 104), 90))//Amarillo
                            {
                                using (Pen gridLinePen = new Pen(Color.FromArgb(233, 227, 3)))//Amarillo
                                {
                                    // Erase the cell.
                                    e.Graphics.FillPath(gridBrush, gfxPath);

                                    // Draw the inset highlight box.
                                    Pen oPen = new Pen(Color.FromArgb(233, 227, 3));//Amarillo

                                    e.Graphics.DrawPath(oPen, gfxPath);
                                    gfxPath.Dispose();

                                    Pen oPen2 = new Pen(Color.FromArgb(255, 254, 250));//Amarillo

                                    e.Graphics.DrawPath(oPen2, gfxPath2);
                                    gfxPath2.Dispose();

                                    PointF oPoint = new PointF(e.CellBounds.X + 1, e.CellBounds.Y + 1);

                                    // Draw the text content of the cell, ignoring alignment.
                                    if (e.Value != null)
                                    {
                                        //if (this.CurrentCell.Style.Font == null)
                                        //    this.CurrentCell.Style.Font = oFont;

                                        e.Graphics.DrawString((String)e.Value, GeneralFont,
                                            Brushes.Black, TextLocation(e.CellBounds, this.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds, e.Value.ToString().Trim(), e.RowIndex, e.ColumnIndex));
                                    }

                                    e.Handled = true;
                                }
                            }
                        }
                        else
                        {
                            Rectangle oRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);

                            e.Graphics.FillRectangle(Brushes.White, oRect);

                            if (e.Value != null)
                            {
                                //if (this.CurrentCell.Style.Font == null)
                                //    this.CurrentCell.Style.Font = oFont;

                                e.Graphics.DrawString((String)e.Value, GeneralFont,
                                    Brushes.Black, TextLocation(e.CellBounds, this.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds, e.Value.ToString().Trim(), e.RowIndex, e.ColumnIndex));
                            }

                            e.Handled = true;
                            e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);
                        }
                    }
                }
            }
            catch { }
        }

        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
        {
            if (e.Column.Index != 0)
            {
                if (e.Column.Width > 300)
                    e.Column.Width = 300;
                else if (e.Column.Width < 100)
                    e.Column.Width = 100;
            }

            base.OnColumnWidthChanged(e);
        }

        private Size CheckMaxHeightRow(int currentRowIndex, Size currentRowSize)
        {
            Size oSize = currentRowSize;

            foreach (DataGridViewCell cell in this.Rows[currentRowIndex].Cells)
            {
                if (cell.Size.Height > currentRowSize.Height)
                    oSize = cell.Size;
            }

            return oSize;
        }

        private int CheckMaxWidthRow(int currentColumnIndex, Size currentColumnSize)
        {
            int cellWidth = currentColumnSize.Width;
            Size oSize = currentColumnSize;

            foreach (DataGridViewRow linea in this.Rows)
            {
                if (linea.Cells[currentColumnIndex].Size.Width == 300)
                {
                    cellWidth = 300;
                    return cellWidth;
                }
                else if (linea.Cells[currentColumnIndex].Size.Width > cellWidth)
                    cellWidth = linea.Cells[currentColumnIndex].Size.Width;
            }

            return cellWidth;
        }

        //protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        //        {
        //            int cellWidth = 0;
        //            int rowHeight = 0;

        //            ///Se declara una variable de tipo Size que calculará un tamaño automático mediante el método AutoCellSize()
        //            Size o = AutoCellSize(this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim());

        //            cellWidth = o.Width;
        //            rowHeight = o.Height;

        //            ///Se verifica que no haya otra fila de mayor altura para entonces tomar la altura mayor como base para el resto
        //            ///de la fila y que no se vea desbordado el texto
        //            Size oSize = CheckMaxHeightRow(e.RowIndex, o);

        //            ///Si los valores son diferentes es porque se encontró una fila mayor a la auxiliar recién generada medio el
        //            ///cálculo automático AutoCellSize()
        //            if (o != oSize)
        //            {
        //                rowHeight = oSize.Height;
        //                cellWidth = oSize.Width;
        //            }

        //            ///Se verifica el Ancho mayor de toda la columna para que no se presente desbordamiento
        //            int cellWidth2 = CheckMaxWidthRow(e.ColumnIndex, o);

        //            if (cellWidth2 != o.Width)
        //                cellWidth = cellWidth2;

        //            this.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Width = cellWidth;
        //            this.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningRow.Height = rowHeight;

        //            this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = stringToUse;
        //        }
        //    }
        //    catch { }

        //    base.OnCellEndEdit(e);
        //}

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    if (e.RowIndex > 0)
                    {
                        int cellWidth = 0;
                        int rowHeight = 0;

                        Font oFont2 = null;

                        if (e.ColumnIndex > 0)
                            oFont2 = GeneralFont;
                        else
                            oFont2 = RowHeaderFont;

                        ///Se declara una variable de tipo Size que calculará un tamaño automático mediante el método AutoCellSize()
                        Size o = AutoCellSize(this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim(), e.ColumnIndex, oFont2);

                        cellWidth = o.Width;
                        rowHeight = o.Height;

                        ///Se verifica que no haya otra fila de mayor altura para entonces tomar la altura mayor como base para el resto
                        ///de la fila y que no se vea desbordado el texto
                        Size oSize = CheckMaxHeightRow(e.RowIndex, o);

                        ///Si los valores son diferentes es porque se encontró una fila mayor a la auxiliar recién generada medio el
                        ///cálculo automático AutoCellSize()
                        if (o.Height != oSize.Height)
                            rowHeight = oSize.Height;

                        ///Se verifica el Ancho mayor de toda la columna para que no se presente desbordamiento
                        int cellWidth2 = CheckMaxWidthRow(e.ColumnIndex, o);

                        if (cellWidth2 != o.Width)
                            cellWidth = cellWidth2;

                        this.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Width = cellWidth;
                        this.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningRow.Height = rowHeight;

                        int a = Convert.ToInt32(MeasureTextWidth(stringToUse, oFont2));
                        this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = stringToUse;
                    }
                }
            }
            catch { }

            base.OnCellValueChanged(e);
        }

        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex == 0)
                this.Rows[0].DefaultCellStyle.Font = columnHeaderFont;
            else
            {
                //foreach (DataGridViewCell oCell in this.Rows[e.RowIndex].Cells)
                //{
                //    if (oCell.ColumnIndex == 0)
                //        oCell.Style.Font = RowHeaderFont;
                //    else
                //        oCell.Style.Font = GeneralFont;
                //}
                
                //this.Rows[e.RowIndex].Cells.DefaultCellStyle.Font = GeneralFont;
                this.Rows[e.RowIndex].Cells[0].Style.Font = RowHeaderFont;
             
                //this.Rows[e.RowIndex].Cells[1].Style.Font = generalFont;
            }

            base.OnRowsAdded(e);
        }

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            e.Column.DefaultCellStyle.Font = generalFont;
            base.OnColumnAdded(e);
        }

        protected override void OnCellDoubleClick(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                this.Rows[e.RowIndex].Selected = true;

            base.OnCellDoubleClick(e);
        }

        protected override void OnCreateControl()
        {
            //AgregarFilaInicial();
            base.OnCreateControl();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Agregar código de dibujo personalizado aquí

            // Llamando a la clase base OnPaint
            base.OnPaint(pe);
        }
    }
}