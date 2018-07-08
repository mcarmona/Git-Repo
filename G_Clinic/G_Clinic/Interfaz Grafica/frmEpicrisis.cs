using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Lógica_Negocios;
using System.Collections;
using G_Clinic.Miscelaneos_y_Recursos;
using System.IO;
using System.Diagnostics;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.Xml;
using MigraDoc.RtfRendering;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmEpicrisis : Form
    {
        public frmEpicrisis()
        {
            InitializeComponent();

            this.Region = Shape.RoundedRegion(this.Size, 8, Shape.Corner.None);
            this.pdfViewer1.Region = Shape.RoundedRegion(pdfViewer1.Size, 3, Shape.Corner.None);
        }

        Document oDocument = null;
        PdfDocumentRenderer pdfRenderer = null;
        public double y = 175;

        #region Instancias

        PDFiText oPDFiText = new PDFiText();
        CPacientes oCPacientes = new CPacientes();
        CConsultas oCConsultas = new CConsultas();
        CConsultaEmbarazo oCConsultaEmbarazo = new CConsultaEmbarazo();
        CExamenesConsulta oCExamenesConsulta = new CExamenesConsulta();
        CGabineteConsulta oCGabineteConsulta = new CGabineteConsulta();
        CEmpleados oCEmpleados = new CEmpleados();
        CEmpresa oCEmpresa = new CEmpresa();

        #endregion

        private void frmEpicrisis_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";

                string PathXml = crearCarpetaAppdata() + "\\EpicrisisTextGuide.xml";

                if (File.Exists(PathXml.Trim()))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNodeList m_nodelist = null;

                    xmldoc.Load(PathXml.Trim());

                    m_nodelist = xmldoc.SelectNodes("/DetalleEpicrisis/Detalle");

                    foreach (XmlNode Nodo in m_nodelist)
                        textBox1.Text = Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes.Item(0).Value.ToString());
                }
            }
            catch { }

        }

        private void LlenaListaConsultasPaciente()
        {
            lstConsultasPaciente.Items.Clear();

            ArrayList oArreglo = oCPacientes.ConsultasPorPaciente(TxtNumExpediente.Text.Trim());
            char[] oChar = { '$' };

            foreach (string oCadena2 in oArreglo)
            {
                string[] oCadena = Metodos_Globales.MetodoSplit(oCadena2, oChar);

                lstConsultasPaciente.Items.Add("");
                lstConsultasPaciente.Items[lstConsultasPaciente.Items.Count - 1].SubItems.Add(oCadena[0].ToString().Trim());
                lstConsultasPaciente.Items[lstConsultasPaciente.Items.Count - 1].SubItems.Add(Convert.ToDateTime(oCadena[1]).ToLongDateString() + " a las " + Convert.ToDateTime(oCadena[1]).ToLongTimeString());
                lstConsultasPaciente.Items[lstConsultasPaciente.Items.Count - 1].SubItems.Add(Convert.ToDateTime(oCadena[1]).ToString());
            }
        }

        private void tobBuscarPaciente_Click(object sender, EventArgs e)
        {
            FrmBlackBackground oFrmBlackBackground = new FrmBlackBackground();
            oFrmBlackBackground.Show();
            FrmPacientesExistentes oFrmPacientesExistentes = new FrmPacientesExistentes(TxtNumExpediente, TxtNombre);
            oFrmPacientesExistentes.ShowDialog();
            oFrmBlackBackground.Close();

            LlenaListaConsultasPaciente();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTodas.Checked == true)
                lstConsultasPaciente.Enabled = false;
            else
                lstConsultasPaciente.Enabled = true;
        }

        private Document DocumentoEpicrisis()
        {
            Document document = new Document();

            if (TxtNumExpediente.Text.Trim() != "")
            {
                if (lstConsultasPaciente.Items.Count > 0)
                {
                    if (oCEmpresa.LeeDatosEmpresa() == true && oCPacientes.LeeDatosPaciente(TxtNumExpediente.Text.Trim()) == true)
                    {
                        Section section = document.AddSection();

                        #region Encabezado (Fecha, Título, Datos Personales y Detalle Opcional)

                        Table tableHeader = document.LastSection.AddTable();

                        tableHeader.Borders.Visible = true;
                        tableHeader.Borders.Width = 0;

                        Column columnHeader = tableHeader.AddColumn("8cm");
                        columnHeader.Format.Alignment = ParagraphAlignment.Right;

                        columnHeader = tableHeader.AddColumn("8cm");
                        columnHeader.Format.Alignment = ParagraphAlignment.Center;

                        Row rowHeader = tableHeader.AddRow();
                        tableHeader.AddRow();
                        tableHeader.AddRow();
                        tableHeader.AddRow();

                        #region Fecha

                        Paragraph oParagraphDate = rowHeader.Cells[0].AddParagraph(DateTime.Now.Date.ToLongDateString());
                        oParagraphDate.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 10);
                        rowHeader.Cells[0].MergeRight = 1;
                        #endregion

                        #region Título

                        rowHeader = tableHeader.AddRow();
                        rowHeader.Cells[0].MergeRight = 1;

                        Paragraph oParagraphTitle = rowHeader.Cells[0].AddParagraph("Epicrisis");
                        oParagraphTitle.Format.Alignment = ParagraphAlignment.Center;
                        oParagraphTitle.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 26);

                        #endregion

                        tableHeader.AddRow();
                        tableHeader.AddRow();
                        tableHeader.AddRow();

                        #region Datos Personales (Nombre y Cédula)

                        rowHeader = tableHeader.AddRow();

                        Paragraph oParagraphNombre = rowHeader.Cells[0].AddParagraph();
                        FormattedText oFormattedTextNombre = oParagraphNombre.AddFormattedText("Nombre: ");
                        oFormattedTextNombre.Bold = true;
                        oFormattedTextNombre.Font.Name = "Segoe UI";
                        oFormattedTextNombre.Font.Size = 11;

                        oParagraphNombre.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 9);
                        oParagraphNombre.AddText(oCPacientes.Nombre.Trim() + " " + oCPacientes.Apellidos.Trim());

                        oParagraphNombre.Format.Alignment = ParagraphAlignment.Left;

                        Paragraph oParagraphCedula = rowHeader.Cells[1].AddParagraph();
                        FormattedText oFormattedTextCedula = oParagraphCedula.AddFormattedText("Cédula: ");
                        oFormattedTextCedula.Bold = true;
                        oFormattedTextCedula.Font.Name = "Segoe UI";
                        oFormattedTextCedula.Font.Size = 11;

                        oParagraphCedula.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 9);
                        oParagraphCedula.AddText(oCPacientes.Cedula);

                        oParagraphCedula.Format.Alignment = ParagraphAlignment.Left;

                        #endregion

                        tableHeader.AddRow();
                        tableHeader.AddRow();

                        #region Detalle Opcional

                        rowHeader = tableHeader.AddRow();
                        rowHeader.Cells[0].MergeRight = 1;

                        Paragraph oParagraphDetalleOpcional = rowHeader.Cells[0].AddParagraph();
                        FormattedText oFormattedDetalleOpcional = oParagraphDetalleOpcional.AddFormattedText(textBox1.Text.Trim());
                        oFormattedDetalleOpcional.Font.Name = "Arial";
                        oFormattedDetalleOpcional.Font.Size = 10;
                        oParagraphDetalleOpcional.Format.Alignment = ParagraphAlignment.Left;

                        #endregion

                        tableHeader.AddRow();
                        tableHeader.AddRow();
                        tableHeader.AddRow();

                        #endregion

                        #region Tabla de Datos de Consultas

                        if (rdNoIncluirDetallesConsultas.Checked == false)
                        {
                            Table tableData = document.LastSection.AddTable();

                            tableData.Borders.Visible = true;
                            tableData.Borders.Width = 0.74;
                            tableData.Borders.Color = new MigraDoc.DocumentObjectModel.Color(192, 80, 77);

                            Column columnData = tableData.AddColumn("2.8cm");
                            columnData.Format.Alignment = ParagraphAlignment.Center;

                            columnData = tableData.AddColumn("3.5cm");
                            columnData.Format.Alignment = ParagraphAlignment.Center;

                            columnData = tableData.AddColumn("3.5cm");
                            columnData.Format.Alignment = ParagraphAlignment.Center;

                            columnData = tableData.AddColumn("3.7cm");
                            columnData.Format.Alignment = ParagraphAlignment.Center;

                            columnData = tableData.AddColumn("3.7cm");
                            columnData.Format.Alignment = ParagraphAlignment.Center;

                            Row rowData = tableData.AddRow();

                            rowData.Borders.Top.Clear();
                            rowData.Borders.Left.Clear();
                            rowData.Borders.Right.Clear();
                            rowData.Borders.Bottom.Width = Unit.FromMillimeter(1);

                            Paragraph oParagraphDataHeader = new Paragraph();

                            oParagraphDataHeader = rowData.Cells[0].AddParagraph("Fecha de Consulta");
                            oParagraphDataHeader.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 13);
                            oParagraphDataHeader.Format.Font.Bold = true;

                            oParagraphDataHeader = rowData.Cells[1].AddParagraph("Detalle de la Consulta");
                            oParagraphDataHeader.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 13);
                            oParagraphDataHeader.Format.Font.Bold = true;

                            oParagraphDataHeader = rowData.Cells[2].AddParagraph("Diagnóstico");
                            oParagraphDataHeader.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 13);
                            oParagraphDataHeader.Format.Font.Bold = true;

                            oParagraphDataHeader = rowData.Cells[3].AddParagraph("Tratamiento");
                            oParagraphDataHeader.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 13);
                            oParagraphDataHeader.Format.Font.Bold = true;

                            oParagraphDataHeader = rowData.Cells[4].AddParagraph("Exámenes Prescritos");
                            oParagraphDataHeader.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 13);
                            oParagraphDataHeader.Format.Font.Bold = true;

                            Paragraph oParagraphData = new Paragraph();
                            ArrayList oArregloDetallesConsultaEpicrisis = new ArrayList();

                            int alternateColor = 0;
                            bool continuar = false;
                            foreach (ListViewItem oItem in lstConsultasPaciente.Items)
                            {
                                if (rdTodas.Checked == true)
                                    continuar = true;
                                else if (rdSeleccionar.Checked == true)
                                {
                                    if (oItem.Checked == true)
                                        continuar = true;
                                    else
                                        continuar = false;
                                }

                                if (continuar == true)
                                {
                                    oArregloDetallesConsultaEpicrisis = oCConsultas.DetallesConsultaEpicrisis(oItem.SubItems[1].Text.Trim());

                                    rowData = tableData.AddRow();

                                    //if (alternateColor == 0)
                                    //    rowData.Shading.Color = new MigraDoc.DocumentObjectModel.Color(239, 211, 210);
                                    //else
                                    rowData.Shading.Color = Colors.White;

                                    oParagraphData = rowData.Cells[0].AddParagraph(Convert.ToDateTime(oItem.SubItems[3].Text).ToShortDateString());
                                    oParagraphData.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 12);
                                    oParagraphData.Format.Font.Bold = true;
                                    oParagraphData.Format.Font.Color = new MigraDoc.DocumentObjectModel.Color(36, 64, 97);
                                    oParagraphData.Format.Alignment = ParagraphAlignment.Center;
                                    rowData.Cells[0].Shading.Color = Colors.White;

                                    oParagraphData = rowData.Cells[1].AddParagraph(oArregloDetallesConsultaEpicrisis[0].ToString().Trim());
                                    oParagraphData.Format.Font.Bold = false;
                                    oParagraphData.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 8);
                                    oParagraphData.Format.Alignment = ParagraphAlignment.Left;

                                    string oTratamiento = oArregloDetallesConsultaEpicrisis[1].ToString().Trim();

                                    int c = 0;
                                    while (oTratamiento.Contains("{") || oTratamiento.Contains("}"))
                                    {
                                        if (c == 0)
                                            oTratamiento = Metodos_Globales.CortaSeccionDeTexto(oTratamiento, "{", "}", "");
                                        else
                                            oTratamiento = Metodos_Globales.CortaSeccionDeTexto(oTratamiento, "{", "}", ", ");

                                        c++;
                                    }

                                    oParagraphData = rowData.Cells[2].AddParagraph(oTratamiento.Trim());
                                    oParagraphData.Format.Font.Bold = false;
                                    oParagraphData.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 8);
                                    oParagraphData.Format.Alignment = ParagraphAlignment.Left;

                                    oParagraphData = rowData.Cells[3].AddParagraph(oArregloDetallesConsultaEpicrisis[2].ToString().Trim());
                                    oParagraphData.Format.Font.Bold = false;
                                    oParagraphData.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 8);
                                    oParagraphData.Format.Alignment = ParagraphAlignment.Left;

                                    string detalleExamen = "";
                                    DataSet ds = oCExamenesConsulta.ConsultarSinParametros(oItem.SubItems[1].Text.Trim());

                                    if (ds != null)
                                    {
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in ds.Tables[0].Rows)
                                            {
                                                if (Convert.ToBoolean(dr[3]) == true)
                                                    detalleExamen = "• " + oCExamenesConsulta.NombreExamen(dr[0].ToString().Trim()) + "(" + dr[5].ToString().Trim() + ").";
                                                else
                                                    detalleExamen = "• " + oCExamenesConsulta.NombreExamen(dr[0].ToString().Trim()) + "(\"Pendiente de resultados\").";

                                                oParagraphData = rowData.Cells[4].AddParagraph(detalleExamen.Trim());
                                                oParagraphData.Format.Font.Bold = false;
                                                oParagraphData.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 8);
                                                oParagraphData.Format.Alignment = ParagraphAlignment.Left;
                                                oParagraphData.AddLineBreak();
                                            }
                                        }
                                        ds.Dispose();
                                    }

                                    if (alternateColor == 0)
                                        alternateColor = 1;
                                    else
                                        alternateColor = 0;

                                    rowData.Borders.Top.Clear();
                                    rowData.Borders.Left.Clear();
                                    //rowData.Borders.Bottom.Clear();
                                }
                            }
                        }
                        #endregion

                        #region Agrega Footer

                        Section section2 = document.LastSection;

                        section2.PageSetup.OddAndEvenPagesHeaderFooter = false;

                        HeaderFooter footer = new HeaderFooter();
                        Paragraph paraFooter = new Paragraph();
                        MigraDoc.DocumentObjectModel.Font ofont = new MigraDoc.DocumentObjectModel.Font("Arial", 8);
                        paraFooter.AddLineBreak();
                        ofont.Color = Colors.Black;

                        string nombreEmp = oCEmpleados.ObtieneNombreEmpleado(Program.oIdUsuario);
                        string codEmpleado = oCEmpleados.ObtieneCodigoColegiado(Program.oIdUsuario);

                        string footerText = "________________________________" + Environment.NewLine + nombreEmp.Trim() + Environment.NewLine + "Cód. " + codEmpleado.Trim();
                        paraFooter.AddFormattedText(footerText, ofont);
                        paraFooter.Format.Alignment = ParagraphAlignment.Right;
                        footer.Add(paraFooter);
                        //section2.Footers.Primary = footer;                    
                        document.LastSection.Footers.Primary = footer;

                        #endregion

                        #region Crea el documento

                        pdfRenderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
                        pdfRenderer.Document = document;
                        pdfRenderer.RenderDocument();

                        #endregion
                    }
                }
            }

            oDocument = document;

            return document;
        }

        private Document DocumentoEpicrisisGabinete()
        {
            Document document = new Document();

            if (TxtNumExpediente.Text.Trim() != "")
            {
                if (lstConsultasPaciente.Items.Count > 0)
                {
                    if (oCEmpresa.LeeDatosEmpresa() == true && oCPacientes.LeeDatosPaciente(TxtNumExpediente.Text.Trim()) == true)
                    {
                        Section section = document.AddSection();

                        #region Encabezado (Fecha, Título, Datos Personales y Detalle Opcional)

                        Table tableHeader = document.LastSection.AddTable();

                        tableHeader.Borders.Visible = true;
                        tableHeader.Borders.Width = 0;

                        Column columnHeader = tableHeader.AddColumn("8cm");
                        columnHeader.Format.Alignment = ParagraphAlignment.Right;

                        columnHeader = tableHeader.AddColumn("8cm");
                        columnHeader.Format.Alignment = ParagraphAlignment.Center;

                        Row rowHeader = tableHeader.AddRow();
                        tableHeader.AddRow();
                        tableHeader.AddRow();
                        tableHeader.AddRow();

                        #region Fecha

                        Paragraph oParagraphDate = rowHeader.Cells[0].AddParagraph(DateTime.Now.Date.ToLongDateString());
                        oParagraphDate.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 10);
                        rowHeader.Cells[0].MergeRight = 1;
                        #endregion

                        #region Título

                        rowHeader = tableHeader.AddRow();
                        rowHeader.Cells[0].MergeRight = 1;

                        Paragraph oParagraphTitle = rowHeader.Cells[0].AddParagraph("Epicrisis");
                        oParagraphTitle.Format.Alignment = ParagraphAlignment.Center;
                        oParagraphTitle.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 26);

                        #endregion

                        tableHeader.AddRow();
                        tableHeader.AddRow();
                        tableHeader.AddRow();

                        #region Datos Personales (Nombre y Cédula)

                        rowHeader = tableHeader.AddRow();

                        Paragraph oParagraphNombre = rowHeader.Cells[0].AddParagraph();
                        FormattedText oFormattedTextNombre = oParagraphNombre.AddFormattedText("Nombre: ");
                        oFormattedTextNombre.Bold = true;
                        oFormattedTextNombre.Font.Name = "Segoe UI";
                        oFormattedTextNombre.Font.Size = 11;

                        oParagraphNombre.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 9);
                        oParagraphNombre.AddText(oCPacientes.Nombre.Trim() + " " + oCPacientes.Apellidos.Trim());

                        oParagraphNombre.Format.Alignment = ParagraphAlignment.Left;

                        Paragraph oParagraphCedula = rowHeader.Cells[1].AddParagraph();
                        FormattedText oFormattedTextCedula = oParagraphCedula.AddFormattedText("Cédula: ");
                        oFormattedTextCedula.Bold = true;
                        oFormattedTextCedula.Font.Name = "Segoe UI";
                        oFormattedTextCedula.Font.Size = 11;

                        oParagraphCedula.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 9);
                        oParagraphCedula.AddText(oCPacientes.Cedula);

                        oParagraphCedula.Format.Alignment = ParagraphAlignment.Left;

                        #endregion

                        tableHeader.AddRow();
                        tableHeader.AddRow();

                        #region Detalle Opcional

                        rowHeader = tableHeader.AddRow();
                        rowHeader.Cells[0].MergeRight = 1;

                        Paragraph oParagraphDetalleOpcional = rowHeader.Cells[0].AddParagraph();
                        FormattedText oFormattedDetalleOpcional = oParagraphDetalleOpcional.AddFormattedText(textBox1.Text.Trim());
                        oFormattedDetalleOpcional.Font.Name = "Arial";
                        oFormattedDetalleOpcional.Font.Size = 10;
                        oParagraphDetalleOpcional.Format.Alignment = ParagraphAlignment.Left;

                        #endregion

                        tableHeader.AddRow();
                        tableHeader.AddRow();
                        tableHeader.AddRow();

                        #endregion

                        #region Tabla de Datos de Consultas

                        if (rdNoIncluirDetallesConsultas.Checked == false)
                        {
                            Table tableData = document.LastSection.AddTable();

                            tableData.Borders.Visible = true;
                            tableData.Borders.Width = 0.74;
                            tableData.Borders.Color = new MigraDoc.DocumentObjectModel.Color(192, 80, 77);

                            Column columnData = tableData.AddColumn("2.8cm");
                            columnData.Format.Alignment = ParagraphAlignment.Center;

                            columnData = tableData.AddColumn("3.5cm");
                            columnData.Format.Alignment = ParagraphAlignment.Center;

                            columnData = tableData.AddColumn("3.5cm");
                            columnData.Format.Alignment = ParagraphAlignment.Center;

                            columnData = tableData.AddColumn("3.7cm");
                            columnData.Format.Alignment = ParagraphAlignment.Center;

                            columnData = tableData.AddColumn("3.7cm");
                            columnData.Format.Alignment = ParagraphAlignment.Center;

                            Row rowData = tableData.AddRow();

                            rowData.Borders.Top.Clear();
                            rowData.Borders.Left.Clear();
                            rowData.Borders.Right.Clear();
                            rowData.Borders.Bottom.Width = Unit.FromMillimeter(1);

                            Paragraph oParagraphDataHeader = new Paragraph();

                            //oParagraphDataHeader = rowData.Cells[0].AddParagraph("Fecha de Consulta");
                            //oParagraphDataHeader.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 13);
                            //oParagraphDataHeader.Format.Font.Bold = true;

                            oParagraphDataHeader = rowData.Cells[0].AddParagraph("Detalle de la Consulta");
                            oParagraphDataHeader.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 13);
                            oParagraphDataHeader.Format.Font.Bold = true;

                            oParagraphDataHeader = rowData.Cells[1].AddParagraph("Diagnóstico");
                            oParagraphDataHeader.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 13);
                            oParagraphDataHeader.Format.Font.Bold = true;

                            oParagraphDataHeader = rowData.Cells[2].AddParagraph("Tratamiento");
                            oParagraphDataHeader.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 13);
                            oParagraphDataHeader.Format.Font.Bold = true;

                            oParagraphDataHeader = rowData.Cells[3].AddParagraph("Exámenes Prescritos");
                            oParagraphDataHeader.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 13);
                            oParagraphDataHeader.Format.Font.Bold = true;

                            oParagraphDataHeader = rowData.Cells[4].AddParagraph("Gabinete");
                            oParagraphDataHeader.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 13);
                            oParagraphDataHeader.Format.Font.Bold = true;

                            Paragraph oParagraphData = new Paragraph();
                            ArrayList oArregloDetallesConsultaEpicrisis = new ArrayList();

                            int alternateColor = 0;
                            bool continuar = false;
                            foreach (ListViewItem oItem in lstConsultasPaciente.Items)
                            {
                                if (rdTodas.Checked == true)
                                    continuar = true;
                                else if (rdSeleccionar.Checked == true)
                                {
                                    if (oItem.Checked == true)
                                        continuar = true;
                                    else
                                        continuar = false;
                                }

                                if (continuar == true)
                                {
                                    oArregloDetallesConsultaEpicrisis = oCConsultas.DetallesConsultaEpicrisis(oItem.SubItems[1].Text.Trim());

                                    rowData = tableData.AddRow();

                                    //if (alternateColor == 0)
                                    //    rowData.Shading.Color = new MigraDoc.DocumentObjectModel.Color(239, 211, 210);
                                    //else
                                    rowData.Shading.Color = Colors.White;

                                    string consultaHeader = Convert.ToDateTime(oItem.SubItems[3].Text).ToShortDateString();

                                    oParagraphData = rowData.Cells[0].AddParagraph(consultaHeader);
                                    oParagraphData.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 12);
                                    oParagraphData.Format.Font.Bold = true;
                                    oParagraphData.Format.Font.Color = new MigraDoc.DocumentObjectModel.Color(36, 64, 97);
                                    oParagraphData.Format.Alignment = ParagraphAlignment.Left;
                                    rowData.Cells[0].Shading.Color = Colors.White;

                                    oParagraphData = rowData.Cells[0].AddParagraph("");
                                    oParagraphData = rowData.Cells[0].AddParagraph(oArregloDetallesConsultaEpicrisis[0].ToString().Trim());
                                    oParagraphData.Format.Font.Bold = false;
                                    oParagraphData.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 8);
                                    oParagraphData.Format.Alignment = ParagraphAlignment.Left;

                                    string oTratamiento = oArregloDetallesConsultaEpicrisis[1].ToString().Trim();

                                    int c = 0;
                                    while (oTratamiento.Contains("{") || oTratamiento.Contains("}"))
                                    {
                                        if (c == 0)
                                            oTratamiento = Metodos_Globales.CortaSeccionDeTexto(oTratamiento, "{", "}", "");
                                        else
                                            oTratamiento = Metodos_Globales.CortaSeccionDeTexto(oTratamiento, "{", "}", ", ");

                                        c++;
                                    }

                                    oParagraphData = rowData.Cells[1].AddParagraph(oTratamiento.Trim());
                                    oParagraphData.Format.Font.Bold = false;
                                    oParagraphData.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 8);
                                    oParagraphData.Format.Alignment = ParagraphAlignment.Left;

                                    oParagraphData = rowData.Cells[2].AddParagraph(oArregloDetallesConsultaEpicrisis[2].ToString().Trim());
                                    oParagraphData.Format.Font.Bold = false;
                                    oParagraphData.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 8);
                                    oParagraphData.Format.Alignment = ParagraphAlignment.Left;

                                    string detalleExamen = "";
                                    DataSet ds = oCExamenesConsulta.ConsultarSinParametros(oItem.SubItems[1].Text.Trim());

                                    if (ds != null)
                                    {
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in ds.Tables[0].Rows)
                                            {
                                                if (Convert.ToBoolean(dr[3]) == true)
                                                    detalleExamen = "• " + oCExamenesConsulta.NombreExamen(dr[0].ToString().Trim()) + "(" + dr[5].ToString().Trim() + ").";
                                                else
                                                    detalleExamen = "• " + oCExamenesConsulta.NombreExamen(dr[0].ToString().Trim()) + "(\"Pendiente de resultados\").";

                                                oParagraphData = rowData.Cells[3].AddParagraph(detalleExamen.Trim());
                                                oParagraphData.Format.Font.Bold = false;
                                                oParagraphData.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 8);
                                                oParagraphData.Format.Alignment = ParagraphAlignment.Left;
                                                oParagraphData.AddLineBreak();
                                            }
                                        }
                                        ds.Dispose();
                                    }

                                    string gabinete = "";
                                    DataSet ds1 = oCGabineteConsulta.ConsultarSinParametros(oItem.SubItems[1].Text.Trim());

                                    if (ds1 != null)
                                    {
                                        if (ds1.Tables[0].Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in ds1.Tables[0].Rows)
                                            {
                                                if (Convert.ToBoolean(dr[3]) == true)
                                                    gabinete = "• " + oCGabineteConsulta.NombreGabinete(dr[0].ToString().Trim()) + "(" + dr[5].ToString().Trim() + ").";
                                                else
                                                    gabinete = "• " + oCGabineteConsulta.NombreGabinete(dr[0].ToString().Trim()) + "(\"Pendiente de resultados\").";

                                                oParagraphData = rowData.Cells[4].AddParagraph(gabinete.Trim());
                                                oParagraphData.Format.Font.Bold = false;
                                                oParagraphData.Format.Font = new MigraDoc.DocumentObjectModel.Font("Arial", 8);
                                                oParagraphData.Format.Alignment = ParagraphAlignment.Left;
                                                oParagraphData.AddLineBreak();
                                            }
                                        }
                                        ds1.Dispose();
                                    }

                                    if (alternateColor == 0)
                                        alternateColor = 1;
                                    else
                                        alternateColor = 0;

                                    rowData.Borders.Top.Clear();
                                    rowData.Borders.Left.Clear();
                                    //rowData.Borders.Bottom.Clear();
                                }
                            }
                        }
                        #endregion

                        #region Agrega Footer

                        Section section2 = document.LastSection;

                        section2.PageSetup.OddAndEvenPagesHeaderFooter = false;

                        HeaderFooter footer = new HeaderFooter();
                        Paragraph paraFooter = new Paragraph();
                        MigraDoc.DocumentObjectModel.Font ofont = new MigraDoc.DocumentObjectModel.Font("Arial", 8);
                        paraFooter.AddLineBreak();
                        ofont.Color = Colors.Black;

                        string nombreEmp = oCEmpleados.ObtieneNombreEmpleado(Program.oIdUsuario);
                        string codEmpleado = oCEmpleados.ObtieneCodigoColegiado(Program.oIdUsuario);

                        string footerText = "________________________________" + Environment.NewLine + nombreEmp.Trim() + Environment.NewLine + "Cód. " + codEmpleado.Trim();
                        paraFooter.AddFormattedText(footerText, ofont);
                        paraFooter.Format.Alignment = ParagraphAlignment.Right;
                        footer.Add(paraFooter);
                        //section2.Footers.Primary = footer;                    
                        document.LastSection.Footers.Primary = footer;

                        #endregion

                        #region Crea el documento

                        pdfRenderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
                        pdfRenderer.Document = document;
                        pdfRenderer.RenderDocument();

                        #endregion
                    }
                }
            }

            oDocument = document;

            return document;
        }

        private void btnGenerarArchivo_Click(object sender, EventArgs e)
        {
            if (!cbIncluirGabinete.Checked)
                pdfViewer1.ShowDocument(DocumentoEpicrisis());
            else
                pdfViewer1.ShowDocument(DocumentoEpicrisisGabinete());
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAdobeReader_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show(this, "No se puede crear el archivo/reporte ya que otro está actualmente en uso, cierre el archivo temporal en uso primero y vuelva a intentar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (pdfRenderer != null)
            {
                pdfRenderer.PdfDocument.Save(completeFileName);
                Process.Start(completeFileName);
            }
            else
            {
                btnGenerarArchivo_Click(sender, e);

                if (pdfRenderer != null)
                {
                    pdfRenderer.PdfDocument.Save(completeFileName);
                    Process.Start(completeFileName);
                }
                else
                    MessageBox.Show(this, "El archivo debe previsualizarse primero antes de ser mostrado en Adobe Reader", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);               
            }
        }

        private string crearCarpetaAppdata()
        {
            try
            {
                string directoryString = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData).ToString() + "\\SoftNet G-Clinic\\Epicrisis";

                if (!Directory.Exists(directoryString))
                    Directory.CreateDirectory(directoryString);//Console.WriteLine("Directory \"{0}\" exists", directoryString);

                return directoryString;
            }
            catch
            {
                return "";
            }
        }

        private void recordarDatosEnEquipo()
        {
            try
            {
                File.Delete(crearCarpetaAppdata() + "\\EpicrisisTextGuide.xml");

                if (crearCarpetaAppdata().Trim() != "")
                {
                    int nodeCount = 0;
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNode xmlRoot, xmlNode;

                    string PathXml = crearCarpetaAppdata() + "\\EpicrisisTextGuide.xml";

                    if (!File.Exists(PathXml.Trim()))
                    {
                        xmlRoot = xmldoc.CreateElement("DetalleEpicrisis");
                        nodeCount = 0;
                    }
                    else
                    {
                        xmldoc.Load(PathXml.Trim());
                        xmlRoot = xmldoc.SelectSingleNode("/DetalleEpicrisis");
                        nodeCount = xmldoc.ChildNodes.Count;
                    }

                    nodeCount++;

                    xmldoc.AppendChild(xmlRoot);
                    xmlNode = xmldoc.CreateElement("Detalle");// + nodeCount.ToString());
                    xmlRoot.AppendChild(xmlNode);
                    xmlNode.InnerText = Encrypt_Decrypt.Encriptar(textBox1.Text.Trim());//Agregamos el nombre del usuario deseado

                    xmldoc.Save(PathXml.Trim());
                }
            }
            catch
            {
                MessageBox.Show(this, "Se produjo un error al crear el archivo que contiene la guía de texto para las epicrisis generadas, por favor intente de nuevo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tobGuardar_Click(object sender, EventArgs e)
        {
            recordarDatosEnEquipo();
        }

        private void btnMSWord_Click(object sender, EventArgs e)
        {
            string path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");
            string completeFileName = "";
            try
            {
                string fileName = "\\TempFile_Epicrisis.rtf";
                completeFileName = path + fileName;

                File.Delete(completeFileName);
            }
            catch
            {
                MessageBox.Show(this, "No se puede crear el archivo/reporte ya que otro está actualmente en uso, cierre el archivo temporal en uso primero y vuelva a intentar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            RtfDocumentRenderer rtf = new RtfDocumentRenderer();
            rtf.Render(this.pdfViewer1.Document, completeFileName.Trim(), null);

            Process.Start(completeFileName.Trim());
        }
    }
}