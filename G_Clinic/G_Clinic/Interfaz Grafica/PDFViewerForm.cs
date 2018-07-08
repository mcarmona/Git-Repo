using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class PDFViewerForm : Form
    {
        Document oDocument = null;
        public PDFViewerForm(Document pDocument)
        {
            InitializeComponent();
            oDocument = pDocument;
        }

        private void PDFViewerForm_Load(object sender, EventArgs e)
        {
            pdfViewer1.ShowDocument(oDocument);
        }
    }
}