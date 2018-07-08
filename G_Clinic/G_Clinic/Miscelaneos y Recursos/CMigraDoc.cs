using System;
using System.Collections.Generic;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System.IO;
using System.Diagnostics;
using PdfSharp.Drawing;
using System.Collections;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel.Shapes;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    class CMigraDoc
    {
        public Document document = null;
        PdfDocument pdfDocument = null;
        public Section section = null;

        public XGraphics gfx = null;

        XFont fontArialBlack = null;
        XFont fontArialRegular = null;

        XFont fontSubtitles = new XFont("Arial", 18, XFontStyle.Bold);

        public Table table = null;

        Column column = null;
        Row row = null;
        Cell cell = null;

        public void CreatesDocument()
        {
            document = new Document();
            section = document.AddSection();
        }

        public void AddTitle(string pTitle, Font pFont)
        {
            section.PageSetup.OddAndEvenPagesHeaderFooter = true;
            section.PageSetup.StartingNumber = 1;

            HeaderFooter header = section.Headers.Primary;
            header.Format.Font = pFont;
            header.Format.Alignment = ParagraphAlignment.Center;

            header.AddParagraph(pTitle);
        }

        public XSize TextSize(string pText, XFont pXFont)
        {
            XSize size = new XSize();

            return size;// = gfx.MeasureString(pText, pXFont);
        }

        public void DrawText()
        {
            //TextFrame tf = document.add footer.AddTextFrame();
            //tf.RelativeHorizontal = RelativeHorizontal.Page;
            //tf.RelativeVertical = RelativeVertical.Paragraph;
            //tf.Left = ShapePosition.Right;
            //tf.WrapFormat.Style = WrapStyle.Through;
            //tf.Width = Unit.FromMillimeter(36);
            //tf.Height = Unit.FromPoint(12 + 2);
        }

        public void DrawTextRegular(string pText, double pX, double pY, double pFontSize)
        {
            if (pFontSize < 8)
                pFontSize = 8;

            fontArialRegular = new XFont("Arial", pFontSize, XFontStyle.Regular);
            //gfx.DrawString(pText, fontArialRegular, XBrushes.Black, pX, pY);

            double currentGlobalX = TextSize(pText, fontArialRegular).Width;

            fontArialRegular = null;
        }

        public void AddSpaceBetweenLines(string pUnit)
        {
            Paragraph oParagraph = new Paragraph();
            oParagraph.Format.SpaceBefore = pUnit;
        }

        public void AddParagraph(ArrayList oArregloEncabezados, ArrayList pArregloResultados)
        {
            Paragraph oParagraph = new Paragraph();
            oParagraph = section.AddParagraph();
            oParagraph.Format.SpaceBefore = "1cm";
            oParagraph.Format.Alignment = ParagraphAlignment.Left;


            int i = 0;
            foreach (string oTexto in oArregloEncabezados)
            {
                FormattedText oFormattedText = oParagraph.AddFormattedText(oTexto);
                oFormattedText.Bold = true;
                oFormattedText.Font.Name = "Segoe Print";
                oFormattedText.Font.Size = 12;

                oParagraph.Format.Font = new Font("Arial", 11);
                oParagraph.AddText(pArregloResultados[i].ToString().Trim());
                oParagraph.AddText("        ");

                i++;
            }
        }

        /// <summary>
        /// Defines page setup, headers, and footers.
        /// </summary>
        public void DefineContentSection()
        {
            Section section = document.AddSection();
            section.PageSetup.OddAndEvenPagesHeaderFooter = true;
            section.PageSetup.StartingNumber = 1;

            HeaderFooter header = section.Headers.Primary;
            header.AddParagraph("\tOdd Page Header");

            header = section.Headers.EvenPage;
            header.AddParagraph("Even Page Header");

            // Create a paragraph with centered page number. See definition of style "Footer".
            Paragraph paragraph = new Paragraph();
            paragraph.AddTab();
            paragraph.AddPageField();

            // Add paragraph to footer for odd pages.
            section.Footers.Primary.Add(paragraph);
            // Add clone of paragraph to footer for odd pages. Cloning is necessary because an object must
            // not belong to more than one other object. If you forget cloning an exception is thrown.
            section.Footers.EvenPage.Add(paragraph.Clone());
        }

        /// <summary>
        /// This is the first step after Creating the table, it adds the first column to the existing table
        /// </summary>
        /// <param name="pTable">Table in wich the first column it's going to be added</param>
        /// <param name="pWidth">Width of the first Column</param>
        /// <param name="pAlignment">How the text is going to be presented, if centered, justified, left or right</param>
        public void AddFirstColumn(Table pTable, double pWidth, int pAlignment)
        {
            column = pTable.AddColumn(Unit.FromCentimeter(pWidth));

            if (pAlignment == 0)
                column.Format.Alignment = ParagraphAlignment.Left;
            else if (pAlignment == 1)
                column.Format.Alignment = ParagraphAlignment.Center;
            else if (pAlignment == 2)
                column.Format.Alignment = ParagraphAlignment.Right;
            else if (pAlignment == 3)
                column.Format.Alignment = ParagraphAlignment.Justify;
        }

        /// <summary>
        /// Add a New Column to the table, after you have added the first row with the "AddFirstColumn" method
        /// </summary>
        /// <param name="pTable">Table in wich the table is going to be added</param>
        /// <param name="pWidth">Width of the new Column</param>
        /// <param name="pAlignment">How the text is going to be presented, centered, justified, left or right</param>
        public void AddColumn(Table pTable, double pWidth, int pAlignment)
        {
            pTable.AddColumn(Unit.FromCentimeter(pWidth));

            if (pAlignment == 0)
                column.Format.Alignment = ParagraphAlignment.Left;
            else if (pAlignment == 1)
                column.Format.Alignment = ParagraphAlignment.Center;
            else if (pAlignment == 2)
                column.Format.Alignment = ParagraphAlignment.Right;
            else if (pAlignment == 3)
                column.Format.Alignment = ParagraphAlignment.Justify;
        }

        /// <summary>
        /// Adds a Row, this process goes after adding all the columns, not before
        /// </summary>
        /// <param name="pTable"></param>
        public void AddRow(Table pTable)
        {
            row = pTable.AddRow();
        }

        /// <summary>
        /// Adds the text to the cells depending on their index
        /// </summary>
        /// <param name="pCellIndex">Index of the cell that is going to add the text</param>
        /// <param name="pColumnText">Text added to the Cell</param>
        public void AddCellsText(int pCellIndex, string pColumnText)
        {
            cell = row.Cells[pCellIndex];
            cell.AddParagraph(pColumnText.Trim());
        }

        /// <summary>
        /// Creates the table from Scratch, this is for starting a new instance of the table
        /// </summary>
        public void CreateTable()
        {
            table = new Table();

            Paragraph oPara = document.LastSection.AddParagraph();
            oPara.Format.SpaceBefore = "1cm";

            table.Borders.Width = 0;
        }

        /// <summary>
        /// Adds the table to the document after the population of the table it's complete
        /// </summary>
        public void AddTable()
        {
            document.LastSection.Add(table);
        }

        public void DemonstrateSimpleTable()
        {
            for (int i = 0; i < 11; i++)
            {
                Paragraph oPara = document.LastSection.AddParagraph("Simple Tables", "Heading2");
                oPara.Format.SpaceBefore = "2cm";

                Table table = new Table();
                table.Borders.Width = 0.75;

                Column column = table.AddColumn(Unit.FromCentimeter(2));
                column.Format.Alignment = ParagraphAlignment.Center;

                table.AddColumn(Unit.FromCentimeter(5));

                Row row = table.AddRow();
                row.Shading.Color = Colors.PaleGoldenrod;
                Cell cell = row.Cells[0];
                cell.AddParagraph("Itemus");
                cell = row.Cells[1];
                cell.AddParagraph("Descriptum");

                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph("1");
                cell = row.Cells[1];
                cell.AddParagraph("fds d g gdffgd hfdfjdg gfhngd fhhfjfhg jghj jkgfjh fg hj hjfg hfhg jdfjf hjfj hf hj fhjfgj fgjdtytrsgafgfs d");

                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph("2");
                cell = row.Cells[1];
                cell.AddParagraph("fgdhfjuyfhdgst rttyeyhje thyjertyty y e hthe hr er th etge");

                table.SetEdge(0, 0, 2, 3, Edge.Box, BorderStyle.Single, 1.5, Colors.Black);

                document.LastSection.Add(table);
            }
        }

        //public void DemonstrateAlignment()
        //{
        //    document.LastSection.AddParagraph("Cell Alignment", "Heading2");

        //    Table table = document.LastSection.AddTable();
        //    table.Borders.Visible = true;
        //    table.Format.Shading.Color = Colors.LavenderBlush;
        //    table.Shading.Color = Colors.Salmon;
        //    table.TopPadding = 5;
        //    table.BottomPadding = 5;

        //    Column column = table.AddColumn();
        //    column.Format.Alignment = ParagraphAlignment.Left;

        //    column = table.AddColumn();
        //    column.Format.Alignment = ParagraphAlignment.Center;

        //    column = table.AddColumn();
        //    column.Format.Alignment = ParagraphAlignment.Right;

        //    table.Rows.Height = 35;

        //    Row row = table.AddRow();
        //    row.VerticalAlignment = VerticalAlignment.Top;
        //    row.Cells[0].AddParagraph("Text");
        //    row.Cells[1].AddParagraph("Text");
        //    row.Cells[2].AddParagraph("Text");

        //    row = table.AddRow();
        //    row.VerticalAlignment = VerticalAlignment.Center;
        //    row.Cells[0].AddParagraph("Text");
        //    row.Cells[1].AddParagraph("Text");
        //    row.Cells[2].AddParagraph("Text");

        //    row = table.AddRow();
        //    row.VerticalAlignment = VerticalAlignment.Bottom;
        //    row.Cells[0].AddParagraph("Text");
        //    row.Cells[1].AddParagraph("Text");
        //    row.Cells[2].AddParagraph("Text");
        //}

        public void DemonstrateCellMerge()
        {
            document.LastSection.AddParagraph("Cell Merge", "Heading2");

            Table table = document.LastSection.AddTable();
            table.Borders.Visible = true;
            table.TopPadding = 5;
            table.BottomPadding = 5;

            Column column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Left;

            column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Right;

            table.Rows.Height = 35;

            Row row = table.AddRow();
            row.Cells[0].AddParagraph("Merge Right");
            row.Cells[0].MergeRight = 1;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[0].MergeDown = 1;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[0].AddParagraph("Merge Down");

            table.AddRow();
        }

        public void OpenDocument()
        {
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();

            string fileName = "";
            string completeFileName = "";

            string path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");

            try
            {
                fileName = "\\TempFile_Epicrisis.pdf";
                completeFileName = path + fileName;
                File.Delete(completeFileName);
            }
            catch
            {
                return;
            }

            pdfRenderer.PdfDocument.Save(completeFileName);
            Process.Start(completeFileName);
        }

        public void Prueba()
        {
            Paragraph oParagraph = new Paragraph();
            oParagraph = section.AddParagraph();
            oParagraph.Format.Alignment = ParagraphAlignment.Left;
            oParagraph.AddText("jueputa carepicha...");
            //oParagraph.Document = document;

            Section sec = document.AddSection();
            TextFrame tf = sec.AddTextFrame();            

            tf.FillFormat.Color = Colors.Red;
            tf.FillFormat.Visible = true;

            tf.LineFormat.Color = Colors.Black;
            tf.LineFormat.Width = Unit.FromMillimeter(1d);
            tf.LineFormat.Visible = true;
            tf.Left = 100;
            tf.Top = 10;

            tf.Add(oParagraph);

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;

            renderer.RenderDocument();
        }
    }
}