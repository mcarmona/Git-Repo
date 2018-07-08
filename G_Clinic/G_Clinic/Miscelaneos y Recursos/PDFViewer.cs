using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.Rendering.Printing;
using System.Drawing.Printing;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class PDFViewer : UserControl
    {
        Document document = null;
        PrinterSettings printerSettings = new PrinterSettings();

        public PDFViewer()
        {
            InitializeComponent();
        }        

        public System.Drawing.Color BackGroundColor
        {
            get { return pagePreview.DesktopColor; }
            set { pagePreview.DesktopColor = value; }
        } 

        public Document Document
        {
            get { return document; }
        }

        public void ShowDocument(Document pDocumento)
        {
            // Create a new MigraDoc document
            document = pDocumento;

            // HACK
            string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
            this.pagePreview.Ddl = ddl;

            UpdateStatusBar();
        }

        void UpdateStatusBar()
        {
            string info = String.Format("Página {0} de {1} - Zoom: {2}%", this.pagePreview.Page, this.pagePreview.PageCount, this.pagePreview.ZoomPercent);

            this.toolStripStatusLabel1.Text = info;
            this.tobCmbSize.Text = pagePreview.ZoomPercent.ToString() + "%";
        }

        private void tobPreview_Click(object sender, EventArgs e)
        {
            this.pagePreview.PrevPage();
            UpdateStatusBar();
        }

        private void tobNext_Click(object sender, EventArgs e)
        {
            this.pagePreview.NextPage();
            UpdateStatusBar();
        }

        private void tobCmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hack menu item to zoom value...
            string name = tobCmbSize.Items[tobCmbSize.SelectedIndex].ToString();// ((MenuItem)sender).Text;
            name = name.Substring(0, name.Length - 1);
            this.pagePreview.ZoomPercent = int.Parse(name);

            UpdateStatusBar();
        }

        private void tobLess_Click(object sender, EventArgs e)
        {
            try
            {
                string auxPercentaje = tobCmbSize.Text.Trim();

                if (tobCmbSize.FindStringExact(tobCmbSize.Text.Trim()) == -1)
                {
                    foreach (string oString in tobCmbSize.Items)
                    {
                        string percentaje = oString.Substring(0, oString.Length - 1);

                        if (Convert.ToDouble(percentaje) >= Convert.ToDouble(tobCmbSize.Text.Substring(0, tobCmbSize.Text.Trim().Length - 1)))
                        {
                            tobCmbSize.SelectedIndex = tobCmbSize.Items.IndexOf(percentaje + "%") - 1;
                            tobCmbSize_SelectedIndexChanged(sender, e);

                            break;
                        }
                    }
                }
                else
                    tobCmbSize.SelectedIndex = tobCmbSize.FindStringExact(tobCmbSize.Text.Trim()) - 1;

                UpdateStatusBar();
            }
            catch { }
        }

        private void tobMore_Click(object sender, EventArgs e)
        {
            try
            {
                string auxPercentaje = tobCmbSize.Text.Trim();

                if (tobCmbSize.FindStringExact(tobCmbSize.Text.Trim()) == -1)
                {
                    foreach (string oString in tobCmbSize.Items)
                    {
                        string percentaje = oString.Substring(0, oString.Length - 1);

                        if (Convert.ToDouble(percentaje) >= Convert.ToDouble(tobCmbSize.Text.Substring(0, tobCmbSize.Text.Trim().Length - 1)))
                        {
                            tobCmbSize.SelectedIndex = tobCmbSize.Items.IndexOf(percentaje + "%");
                            tobCmbSize_SelectedIndexChanged(sender, e);

                            break;
                        }
                    }
                }
                else
                    tobCmbSize.SelectedIndex = tobCmbSize.FindStringExact(tobCmbSize.Text.Trim()) + 1;

                UpdateStatusBar();
            }
            catch { }
        }

        private void tobCmbSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tobFitPage_Click(object sender, EventArgs e)
        {
            this.pagePreview.Zoom = MigraDoc.Rendering.Forms.Zoom.FullPage;
            UpdateStatusBar();
        }

        private void tobBestFit_Click(object sender, EventArgs e)
        {
            this.pagePreview.Zoom = MigraDoc.Rendering.Forms.Zoom.BestFit;
            UpdateStatusBar();
        }

        private void tobImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                // Reuse the renderer from the preview
                DocumentRenderer renderer = this.pagePreview.Renderer;

                if (renderer != null)
                {
                    int pageCount = renderer.FormattedDocument.PageCount;

                    // Creates a PrintDocument that simplyfies printing of MigraDoc documents
                    MigraDocPrintDocument printDocument = new MigraDocPrintDocument();

                    // Attach the current printer settings
                    printDocument.PrinterSettings = this.printerSettings;

                    if (this.printerSettings.PrintRange == PrintRange.Selection)
                        printDocument.SelectedPage = this.pagePreview.Page;

                    // Attach the current document renderer
                    printDocument.Renderer = renderer;

                    // Print the document
                    printDocument.Print();
                }
            }
            catch { }
        }

        private void tobPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pagePreview.Renderer != null)
                {
                    using (PrintPreviewDialog dialog = new PrintPreviewDialog())
                    {
                        dialog.Text = "Document Print Preview";
                        dialog.ShowIcon = false;
#if NET_2_0
        dialog.ShowIcon = false;
#endif
                        dialog.MinimizeBox = false;
                        dialog.MaximizeBox = false;

                        // Reuse the renderer from the preview
                        DocumentRenderer renderer = this.pagePreview.Renderer;

                        // Creates a PrintDocument that simplifies printing of MigraDoc documents
                        MigraDocPrintDocument printDocument = new MigraDocPrintDocument();

                        // Attach the current printer settings
                        printDocument.PrinterSettings = this.printerSettings;

                        // Attach the current document renderer
                        printDocument.Renderer = renderer;

                        // Attach the current print document
                        dialog.Document = printDocument;

                        // Show the preview
                        dialog.ShowDialog();
                    }
                }
            }
            catch { }
        }

        private void tobPrintPreferences_Click(object sender, EventArgs e)
        {
            try
            {
                using (PrintDialog dialog = new PrintDialog())
                {
                    dialog.PrinterSettings = this.printerSettings;
                    dialog.AllowSelection = true;
                    dialog.AllowSomePages = true;
                    dialog.ShowDialog();
                }
            }
            catch { }
        }
    }
}