using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using GDI = System.Drawing;
using System.Drawing;
using System.Diagnostics;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    class PDFiText
    {
        //string path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");

        //public PdfPTable datatable = null;
        //public Document document = null;
        //PdfWriter writer = null;

        //string fileName = "";
        //string completeFileName = "";

        ////BaseFont fontArial = BaseFont.CreateFont("Arial", BaseFont.CP1252, false);
        ////iTextSharp.text.Font arial = new iTextSharp.text.Font(fontArial, 12, Font.BOLD, Color.Black);

        //public void CreatesDocument()
        //{
        //    document = new Document(PageSize.A4, 50, 50, 50, 50);

        //    // creation of the different writers
        //    try
        //    {
        //        fileName = "\\TempFile_Epicrisis.pdf";
        //        completeFileName = path + fileName;

        //        File.Delete(completeFileName);
        //    }
        //    catch
        //    {
        //        //MessageBox.Show(this, "No se puede crear el archivo/reporte ya que otro está actualmente en uso, cierre el archivo temporal en uso primero y vuelva a intentar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return;
        //    }

        //    writer = PdfWriter.GetInstance(document, new FileStream(completeFileName, FileMode.Create));

        //    //we add some meta information to the document
        //    document.AddAuthor("SofNet Business Solutions");
        //    document.AddSubject("This is the result of a Test.");

        //    document.Open();
        //}

        //public void AddTitle(string pTitle, float pFontSize, BaseColor pColor)
        //{
        //    iTextSharp.text.Font arial = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, pFontSize, iTextSharp.text.Font.BOLD, pColor);

        //    Paragraph oParagraph = new Paragraph(pTitle, arial);
        //    oParagraph.Alignment = 1;            

        //    document.Add(oParagraph);
        //}

        //public void AddText(string pText, float pFontSize, BaseColor pColor)
        //{
        //    //PdfContentByte cb = iTextSharp.text.pdf.PdfWriter.GetISOBytes( PdfWriter.DirectContent;
        //    //cb.beginText();
        //    //cb.setTextMatrix(100, 400);
        //    //cb.showText("Text at position 100,400.");
            
            
        //    //MemoryStream ms = new MemoryStream();
        //    //PdfWriter oPdfWriter = PdfWriter.GetInstance(document, ms);

        //    //iTextSharp.text.Font arial = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, pFontSize, iTextSharp.text.Font.BOLD, pColor);

        //    //PdfContentByte cb = new PdfContentByte(oPdfWriter);// PdfWriter.GetISOBytes("Text at position 100,400.");
        //    //cb.BeginText();
        //    //cb.SetTextMatrix(100, 400);

            
        //    //cb.SetFontAndSize(FontFactory.COURIER, pFontSize);

        //    //cb.ShowText("Text at position 100,400.");


        //    //PdfContentByte cb = writer.DirectContent;
        //    //ColumnText ct = new ColumnText(cb);
        //    //ct.SetSimpleColumn(new Phrase(new Chunk(pText, FontFactory.GetFont(FontFactory.HELVETICA, 18, iTextSharp.text.Font.NORMAL))),
        //    //                   0, 0, 50, 36, 25, Element.ALIGN_LEFT);
        //    //ct.Go();



        //    PdfContentByte cb = writer.DirectContent;
        //    cb.BeginText();
        //    cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false), pFontSize);
        //    cb.SetTextMatrix(46, 0);
        //    cb.ShowText(pText);
        //    cb.EndText();




        //    //iTextSharp.text.Font arial = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, pFontSize, iTextSharp.text.Font.BOLD, pColor);

        //    //Paragraph oParagraph = new Paragraph(pText, arial);
        //    //oParagraph.Alignment = 1;

            
        //    //document.Add(oParagraph);
        //}

        //public void OpenDocument()
        //{
        //    Process.Start(completeFileName);
        //}
    }
}