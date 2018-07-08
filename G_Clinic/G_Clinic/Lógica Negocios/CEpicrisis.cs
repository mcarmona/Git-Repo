using System;
using System.Collections.Generic;
using System.Text;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO;
using System.Drawing;
using System.Collections;

namespace G_Clinic.Lógica_Negocios
{
    class CEpicrisis
    {
        #region Variables e Instancias

        CPacientes oCPacientes = new CPacientes();

        string numExpediente = "";
        public string NumExpediente
        {
            get { return numExpediente; }
            set { numExpediente = value; }
        }

        string nombre = "";
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public PdfDocument document = null;

        //// Create an empty page
        public PdfPage page = null;

        public XGraphics gfx = null;

        Graphics oGraphics = null;

        public double currentGlobalX = 0;
        public double currentGlobalY = 0;
        public double maxY = 0;

        public string wholeText = "";

        public ArrayList oArrayStringNewPage = new ArrayList();

        #endregion

        int fontSizes = 0;

        #region Fonts

        XFont fontArialBlack = null;
        XFont fontArialRegular = null;

        XFont fontSubtitles = new XFont("Arial", 18, XFontStyle.Bold);

        public double nextLine = 0;
        public double nextLine2 = 0;

        #endregion

        public CEpicrisis(Graphics pGraphics, string pDocumentName)
        {
            document = new PdfDocument();
            document.Info.Title = pDocumentName.Trim();
            

            page = document.AddPage();
            gfx = XGraphics.FromPdfPage(page);

            //nextLine = arialBlackX.GetHeight(gfx);
            //nextLine2 = oXArial.GetHeight(gfx);

            oGraphics = pGraphics;
        }

        public void AddPage()
        {
            gfx = XGraphics.FromPdfPage(document.AddPage(new PdfPage(document)));
            Program.oFrmEpicrisis.y = 50;
        }

        public void InicializaVariables(Graphics pGraphics)
        {
            page = document.AddPage();
            gfx = XGraphics.FromPdfPage(page);

            //nextLine = arialBlackX.GetHeight(gfx);
            //nextLine2 = oXArial.GetHeight(gfx);

            oGraphics = pGraphics;
        }

        /// <summary>
        /// Mide una cadena recién creada en PDF la cual sería siempre el encabezado de un campo de la hoja, ejemplo: CATEGORIA:
        /// </summary>
        /// <param name="pCadena"></param>
        /// <param name="pFont"></param>
        /// <returns></returns>
        private int StringWidth(string pCadena, System.Drawing.Font pFont)
        {
            int ancho = 0;
            SizeF oSize = new SizeF();

            oSize = oGraphics.MeasureString(pCadena, pFont);
            ancho = Convert.ToInt32(oSize.Width) + 20;

            return ancho;
        }

        //public void DrawTitleCenterAlign(string pTitulo)
        //{
        //    gfx.DrawString(pTitulo, oXFontTitle, XBrushes.Red, new XRect(0, 24, page.Width, 60), XStringFormats.Center);
        //}

        /// <summary>
        /// Dibuja los campos con sus respectivos valores
        /// </summary>
        /// <param name="pEncabezadoCampo">Encabezado de Campo, por ejemplo: Nombre</param>
        /// <param name="pValorCampo">Valor correspondiente al encabezado del campo, por ejemplo: Carlos Rodríguez</param>
        /// <param name="pX">Posición Actual Global de "X" para dibujar el texto</param>
        /// <param name="pY">Posición Actual Global de "Y" para dibujar el texto</param>
        //public void DrawText(string pEncabezadoCampo, string pValorCampo, double pX, double pY)
        //{
        //    int auxX = 0;

        //    gfx.DrawString(pEncabezadoCampo, oXFontArialBlack, XBrushes.Black, pX, pY);
        //    auxX = StringWidth(pEncabezadoCampo, oFontArialBlack);

        //    //auxX = Convert.ToInt32(pX) + auxX - 25;
        //    currentGlobalX = auxX;

        //    gfx.DrawString(pValorCampo, oXArial, XBrushes.Black, auxX, pY);
        //}

        ///// <summary>
        ///// Dibuja los campos con sus respectivos valores
        ///// </summary>
        ///// <param name="pEncabezadoCampo">Encabezado de Campo, por ejemplo: Nombre</param>
        ///// <param name="pValorCampo">Valor correspondiente al encabezado del campo, por ejemplo: Carlos Rodríguez</param>
        ///// <param name="pX">Posición Actual Global de "X" para dibujar el texto</param>
        ///// <param name="pY">Posición Actual Global de "Y" para dibujar el texto</param>
        //public void DrawTextImportant(string pEncabezadoCampo, string pValorCampo, double pX, double pY)
        //{
        //    int auxX = 0;

        //    gfx.DrawString(pEncabezadoCampo, oXFontArialBlack, XBrushes.Black, pX, pY);
        //    auxX = StringWidth(pEncabezadoCampo, oFontArialBlack);

        //    currentX = auxX;

        //    gfx.DrawString(pValorCampo, oXFontArialBlack, XBrushes.Red, auxX, pY);
        //}

        public void CreaDocumento(string pFileName)
        {
            document.Save(pFileName);
        }

        //void DrawTextAlignment(XGraphics gfx, int number)
        //{
        //    //BeginBox(gfx, number, "Text Alignment");
        //    XRect rect = new XRect(0, 0, 250, 140);

        //    XFont font = new XFont("Verdana", 10);
        //    XBrush brush = XBrushes.Purple;
        //    XStringFormat format = new XStringFormat();

        //    gfx.DrawRectangle(XPens.YellowGreen, rect);
        //    gfx.DrawLine(XPens.YellowGreen, rect.Width / 2, 0, rect.Width / 2, rect.Height);
        //    gfx.DrawLine(XPens.YellowGreen, 0, rect.Height / 2, rect.Width, rect.Height / 2);

        //    gfx.DrawString("TopLeft", font, brush, rect, format);

        //    format.Alignment = XStringAlignment.Center;
        //    gfx.DrawString("TopCenter", font, brush, rect, format);

        //    format.Alignment = XStringAlignment.Far;
        //    gfx.DrawString("TopRight", font, brush, rect, format);

        //    format.LineAlignment = XLineAlignment.Center;
        //    format.Alignment = XStringAlignment.Near;
        //    gfx.DrawString("CenterLeft", font, brush, rect, format);

        //    format.Alignment = XStringAlignment.Center;
        //    gfx.DrawString("Center", font, brush, rect, format);

        //    format.Alignment = XStringAlignment.Far;
        //    gfx.DrawString("CenterRight", font, brush, rect, format);

        //    format.LineAlignment = XLineAlignment.Far;
        //    format.Alignment = XStringAlignment.Near;
        //    gfx.DrawString("BottomLeft", font, brush, rect, format);

        //    format.Alignment = XStringAlignment.Center;
        //    gfx.DrawString("BottomCenter", font, brush, rect, format);

        //    format.Alignment = XStringAlignment.Far;
        //    gfx.DrawString("BottomRight", font, brush, rect, format);

        //    //EndBox(gfx);
        //}

        public void DrawDateTitle(string title)
        {
            XRect rect = new XRect(300, 65, 250, 15);
            XFont font = new XFont("Verdana", 9, XFontStyle.Regular);
            XStringFormat oXStringFormats = new XStringFormat();

            oXStringFormats.Alignment = XStringAlignment.Far;
            gfx.DrawString(title, font, XBrushes.Black, rect, oXStringFormats);
        }

        public void DrawTitle(string title)
        {
            XRect rect = new XRect(new XPoint(), gfx.PageSize);
            rect.Inflate(-10, -100);
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
            gfx.DrawString(title, font, XBrushes.Black, rect, XStringFormats.TopCenter);

            //rect.Offset(0, 5);
            //font = new XFont("Verdana", 8, XFontStyle.Italic);
            //XStringFormat format = new XStringFormat();
            //format.Alignment = XStringAlignment.Near;
            //format.LineAlignment = XLineAlignment.Far;
            //gfx.DrawString("Created with " + PdfSharp.ProductVersionInfo.Producer, font, XBrushes.DarkOrchid, rect, format);

            //font = new XFont("Verdana", 8);
            //format.Alignment = XStringAlignment.Center;
            //gfx.DrawString("1", font, XBrushes.DarkOrchid, rect, format);

            //document.Outlines.Add(title, page, true);
        }

        //public void BeginBox(XGraphics gfx, int number, string title)
        //{
        //    const int dEllipse = 15;
        //    XRect rect = new XRect(0, 20, 300, 200);
        //    if (number % 2 == 0)
        //        rect.X = 300 - 5;
        //    rect.Y = 40 + ((number - 1) / 2) * (200 - 5);
        //    rect.Inflate(-10, -10);
        //    XRect rect2 = rect;
        //    rect2.Offset(10, 10);
        //    gfx.DrawRoundedRectangle(new XSolidBrush(XColors.AliceBlue), rect2, new XSize(dEllipse + 8, dEllipse + 8));
        //    XLinearGradientBrush brush = new XLinearGradientBrush(rect, XColors.AliceBlue, XColors.AntiqueWhite, XLinearGradientMode.Vertical);

        //    gfx.DrawRoundedRectangle(XPens.Aqua, brush, rect, new XSize(dEllipse, dEllipse));
        //    rect.Inflate(-5, -5);

        //    XFont font = new XFont("Verdana", 12, XFontStyle.Regular);
        //    gfx.DrawString(title, font, XBrushes.Navy, rect, XStringFormats.TopCenter);

        //    rect.Inflate(-10, -5);
        //    rect.Y += 20;
        //    rect.Height -= 20;

        //    //this.state = gfx.Save();
        //    gfx.TranslateTransform(rect.X, rect.Y);
        //}

        //public void EndBox(XGraphics gfx)
        //{
        //    gfx.Restore();//this.state);
        //}

        ////void MeasureText(XGraphics gfx, int number)
        ////{
        ////    //BeginBox(gfx, number, "Measure Text");

        ////    const XFontStyle style = XFontStyle.Regular;
        ////    XFont font = new XFont("Times New Roman", 95, style);

        ////    const string text = "Hallo";
        ////    const double x = 20, y = 100;
        ////    XSize size = gfx.MeasureString(text, font);

        ////    double lineSpace = font.GetHeight(gfx);
        ////    int cellSpace = font.FontFamily.GetLineSpacing(style);
        ////    int cellAscent = font.FontFamily.GetCellAscent(style);
        ////    int cellDescent = font.FontFamily.GetCellDescent(style);
        ////    int cellLeading = cellSpace - cellAscent - cellDescent;

        ////    // Get effective ascent
        ////    double ascent = lineSpace * cellAscent / cellSpace;
        ////    gfx.DrawRectangle(XBrushes.Bisque, x, y - ascent, size.Width, ascent);

        ////    // Get effective descent
        ////    double descent = lineSpace * cellDescent / cellSpace;
        ////    gfx.DrawRectangle(XBrushes.LightGreen, x, y, size.Width, descent);

        ////    // Get effective leading
        ////    double leading = lineSpace * cellLeading / cellSpace;
        ////    gfx.DrawRectangle(XBrushes.Yellow, x, y + descent, size.Width, leading);

        ////    // Draw text half transparent
        ////    XColor color = XColors.DarkSlateBlue;
        ////    color.A = 0.6;
        ////    gfx.DrawString(text, font, new XSolidBrush(color), x, y);

        ////    //EndBox(gfx);
        ////}

        private void InitializeArray()
        {
            oArrayStringNewPage.Add("");
            oArrayStringNewPage.Add("");
            oArrayStringNewPage.Add("");
            oArrayStringNewPage.Add("");
        }

        public void DetermineNextMaxYValue(double pTextSize)
        {
            maxY = 0;
            double oTextHeight = 0;
            currentGlobalY = 0;

            fontArialRegular = new XFont("Arial", pTextSize, XFontStyle.Regular);

            foreach (string oString in oArrayStringNewPage)
            {
                oTextHeight = TextSize(oString, fontArialRegular).Height;

                if (oTextHeight > maxY)
                    maxY = oTextHeight;
            }
        }

        private void PDF()
        {
            document.Info.Title = "Documento Epicrisis";
        }

        public XSize TextSize(string pText, XFont pXFont)
        {
            XSize size = new XSize();

            return size = gfx.MeasureString(pText, pXFont);
        }

        public void DrawTextRegular(string pText, double pX, double pY, double pFontSize)
        {
            if (pFontSize < 8)
                pFontSize = 8;

            fontArialRegular = new XFont("Arial", pFontSize, XFontStyle.Regular);
            gfx.DrawString(pText, fontArialRegular, XBrushes.Black, pX, pY);

            currentGlobalX = TextSize(pText, fontArialRegular).Width;

            fontArialRegular = null;
        }

        public void DrawTextBold(string pText, double pX, double pY, double pFontSize, string pFontFamilyName)
        {
            if (pFontSize < 8)
                pFontSize = 8;

            fontArialBlack = new XFont(pFontFamilyName, pFontSize, XFontStyle.Bold);
            gfx.DrawString(pText, fontArialBlack, XBrushes.Black, pX, pY);

            currentGlobalX = TextSize(pText, fontArialBlack).Width;

            fontArialBlack = null;
        }

        public void PaintRestOfForm()
        {
            XSolidBrush oXSolidBrush = new XSolidBrush(XColors.White);
            DrawRectangle(oXSolidBrush, 0, 751, page.Width, (page.Height - 751));
        }

        public void DrawHeaderAndValueText(string pHeader, double pHeaderSize, string pValue, double pValueSize, double pX, double pY)
        {
            double auxX = 0;
            fontArialBlack = new XFont("Arial", pHeaderSize, XFontStyle.Bold);
            gfx.DrawString(pHeader, fontArialBlack, XBrushes.Black, pX, pY);

            auxX = TextSize(pHeader, fontArialBlack).Width;

            fontArialRegular = new XFont("Arial", pValueSize, XFontStyle.Regular);
            gfx.DrawString(pValue, fontArialRegular, XBrushes.Black, pX + auxX + 5, pY);

            currentGlobalX = (pX + auxX) + TextSize(pValue, fontArialRegular).Width;

            fontArialBlack = null;
            fontArialRegular = null;
        }

        public void DrawLine(double pX, double pY, XColor pXColor, double pWidth, double pLenght, double pHeight)
        {
            XPen pen = new XPen(pXColor, pWidth);
            gfx.DrawLine(pen, pX, pY, pLenght, pHeight);
        }

        public void DrawRectangle(XSolidBrush oXSolidBrush, double pX, double pY, double pWidth, double pHeight)
        {
            gfx.DrawRectangle(oXSolidBrush, pX, pY, pWidth, pHeight);
        }

        public void DrawLongText(string pText, char[] pCaracterBuscado, int pMaxCaracteres, double pX, double pY, double pTextSize, int pOpcionIngresada)
        {
            currentGlobalX = pX;
            currentGlobalY = pY;

            fontArialRegular = new XFont("Arial", pTextSize, XFontStyle.Regular);

            double auxX = pX;

            pText = pText.Replace("\n", " ");
            string[] ocadenaTemp = pText.Split(pCaracterBuscado, StringSplitOptions.RemoveEmptyEntries);
            string auxCadenaTemporal = "";

            double textHeight = TextSize("a", fontArialRegular).Height;
            int contCaracteres = 0;
            for (int i = 0; i < ocadenaTemp.Length; )
            {
                contCaracteres += ocadenaTemp[i].Length;
                if (contCaracteres >= pMaxCaracteres && i < ocadenaTemp.Length)
                {
                    if (pY >= 750)//778
                    {
                        PaintRestOfForm();

                        if (oArrayStringNewPage.Count == 0)
                            InitializeArray();

                        if (pOpcionIngresada == 0)
                            oArrayStringNewPage[0] += auxCadenaTemporal.Trim() + Environment.NewLine;
                        if (pOpcionIngresada == 1)
                            oArrayStringNewPage[1] += auxCadenaTemporal.Trim() + Environment.NewLine;
                        if (pOpcionIngresada == 2)
                            oArrayStringNewPage[2] += auxCadenaTemporal.Trim() + Environment.NewLine;
                        if (pOpcionIngresada == 3)
                            oArrayStringNewPage[3] += auxCadenaTemporal.Trim() + Environment.NewLine;
                    }
                    else
                        gfx.DrawString(auxCadenaTemporal.Trim(), fontArialRegular, XBrushes.Black, auxX + 15, pY);

                    pY += textHeight + 2;

                    wholeText += auxCadenaTemporal;

                    auxCadenaTemporal = "";
                    auxCadenaTemporal += Environment.NewLine;
                    contCaracteres = 0;

                    if ((pY + textHeight) > maxY)
                        maxY = pY + textHeight;

                    currentGlobalX = auxX + TextSize(auxCadenaTemporal, fontArialRegular).Width;
                }
                else
                {
                    auxCadenaTemporal += ocadenaTemp[i].ToString() + " ";
                    i++;
                }

                if (i >= ocadenaTemp.Length)
                {
                    if (pY >= 750)
                    {
                        PaintRestOfForm();

                        if (oArrayStringNewPage.Count == 0)
                            InitializeArray();

                        if (pOpcionIngresada == 0)
                            oArrayStringNewPage[0] += auxCadenaTemporal.Trim() + Environment.NewLine;
                        if (pOpcionIngresada == 1)
                            oArrayStringNewPage[1] += auxCadenaTemporal.Trim() + Environment.NewLine;
                        if (pOpcionIngresada == 2)
                            oArrayStringNewPage[2] += auxCadenaTemporal.Trim() + Environment.NewLine;
                        if (pOpcionIngresada == 3)
                            oArrayStringNewPage[3] += auxCadenaTemporal.Trim() + Environment.NewLine;
                    }

                    gfx.DrawString(auxCadenaTemporal.Trim(), fontArialRegular, XBrushes.Black, auxX + 15, pY);
                    wholeText += auxCadenaTemporal;
                }

                currentGlobalX = auxX + 15;
            }

            currentGlobalY = pY;
            fontArialRegular = null;
        }

        public void DrawTable()
        {
            
        }

        public void MeasureText(XGraphics gfx, int number)
        {
            const XFontStyle style = XFontStyle.Regular;
            XFont font = new XFont("Times New Roman", 95, style);
            const string text = "Hallo";
            const double x = 20, y = 100;
            XSize size = gfx.MeasureString(text, font);

            double lineSpace = font.GetHeight(gfx);

            int cellSpace = font.FontFamily.GetLineSpacing(style);
            int cellAscent = font.FontFamily.GetCellAscent(style);
            int cellDescent = font.FontFamily.GetCellDescent(style);
            int cellLeading = cellSpace - cellAscent - cellDescent;
            // Get effective ascent
            double ascent = lineSpace * cellAscent / cellSpace;
            gfx.DrawRectangle(XBrushes.Bisque, x, y - ascent, size.Width, ascent);
            // Get effective descent
            double descent = lineSpace * cellDescent / cellSpace;
            gfx.DrawRectangle(XBrushes.LightGreen, x, y, size.Width, descent);
            // Get effective leading
            double leading = lineSpace * cellLeading / cellSpace;
            gfx.DrawRectangle(XBrushes.Yellow, x, y + descent, size.Width, leading);
            // Draw text half transparent
            XColor color = XColors.DarkSlateBlue;
            color.A = 0.6;
            gfx.DrawString(text, font, new XSolidBrush(color), x, y);
        }
    }
}