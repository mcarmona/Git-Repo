using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
using G_Clinic.Miscelaneos_y_Recursos;
using System.Drawing.Printing;
using PdfSharp;
using PdfSharp.Forms;
using PdfSharp.Pdf.Printing;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmPrescriptionPad : Form
    {
        public frmPrescriptionPad()
        {
            InitializeComponent();
            this.Region = Shape.RoundedRegion(this.Size, 8, Shape.Corner.None);
            
            openFileDialog1.InitialDirectory = Environment.SpecialFolder.ProgramFiles.ToString();
        }

        XMLCreator oXMLCreator = new XMLCreator();
        public XGraphics gfx = null;

        #region Lee valores de archivo XML

        Font nomClinica = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        Font especialidad = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        Font serviciosOfrecidos = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        Font telefono = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        Font email = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        Font direccion = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        Font nombrePaciente = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        Font cedula = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        Font edad = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        Font peso = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        Font telefonos = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        Font rx = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        Font firma = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);

        XFont xNomClinica = null;
        XFont xEspecialidad = null;
        XFont xServiciosOfrecidos = null;
        XFont xTelefono = null;
        XFont xEmail = null;
        XFont xDireccion = null;
        XFont xNombrePaciente = null;
        XFont xCedula = null;
        XFont xEdad = null;
        XFont xPeso = null;
        XFont xTelefonos = null;
        XFont xRx = null;
        XFont xFirma = null;
        XFont xNormalFont = new XFont("Microsoft Sans Serif", 9f);
        XFont xItemsReceta = new XFont("Segoe Print", 10f);

        private Font DeterminaValoresFuente(string pValoresFuente)
        {
            Font oFont = null;
            char[] oChar = new char[] { '|' };

            string[] valoresFuente = pValoresFuente.Split(oChar);

            FontFamily oFontFamily = new FontFamily(valoresFuente[0].Trim());

            if (valoresFuente[2].Trim() == "Bold")
                oFont = new Font(oFontFamily, (float)Convert.ToDouble(valoresFuente[1]), FontStyle.Bold);
            else if (valoresFuente[2].Trim() == "Italic")
                oFont = new Font(oFontFamily, (float)Convert.ToDouble(valoresFuente[1]), FontStyle.Italic);
            else if (valoresFuente[2].Trim() == "Regular")
                oFont = new Font(oFontFamily, (float)Convert.ToDouble(valoresFuente[1]), FontStyle.Regular);
            else if (valoresFuente[2].Trim() == "Strikeout")
                oFont = new Font(oFontFamily, (float)Convert.ToDouble(valoresFuente[1]), FontStyle.Strikeout);
            else if (valoresFuente[2].Trim() == "Underline")
                oFont = new Font(oFontFamily, (float)Convert.ToDouble(valoresFuente[1]), FontStyle.Underline);

            return oFont;
        }

        private int DeterminaValorX(string pValoresX)
        {
            int x = 0;

            char[] oChar = new char[] { '|' };
            string[] valoresFuente = pValoresX.Split(oChar);

            return x = Convert.ToInt32(valoresFuente[3]);
        }

        private int DeterminaValorY(string pValoresY)
        {
            int y = 0;

            char[] oChar = new char[] { '|' };
            string[] valoresFuente = pValoresY.Split(oChar);

            return y = Convert.ToInt32(valoresFuente[4]);
        }

        private void EstableceImpresoraYEjecutableAdobe()
        {
            try
            {
                char[] oChar = new char[] { '|' };
                string[] valoresFuente = oXMLCreator.ReadNodes("/Formato/print").Split(oChar);

                txtAdobeExePath.Text = valoresFuente[0].Trim();
                comboBox1.SelectedIndex = comboBox1.FindStringExact(valoresFuente[1].Trim());
            }
            catch { }
        }

        private void EstableceValoresXY()
        {
            //nomClinica = DeterminaValoresFuente(txtFuenteNombreClinica.Tag.ToString());
            //especialidad = DeterminaValoresFuente(txtFuenteEspecialidad.Tag.ToString());
            //serviciosOfrecidos = DeterminaValoresFuente(txtFuenteServiciosOfrecidos.Tag.ToString());
            //telefono = DeterminaValoresFuente(txtFuenteTelefono.Tag.ToString());
            //email = DeterminaValoresFuente(txtFuenteEmail.Tag.ToString());
            //direccion = DeterminaValoresFuente(txtFuenteDireccion.Tag.ToString());
            //nombrePaciente = DeterminaValoresFuente(txtFuenteNombrePaciente.Tag.ToString());
            //cedula = DeterminaValoresFuente(txtFuenteCedula.Tag.ToString());
            //edad = DeterminaValoresFuente(txtFuenteEdad.Tag.ToString());
            //peso = DeterminaValoresFuente(txtFuentePeso.Tag.ToString());
            //telefonos = DeterminaValoresFuente(txtFuenteTelefonos.Tag.ToString());
            //rx = DeterminaValoresFuente(txtFuenteRX.Tag.ToString());
            //firma = DeterminaValoresFuente(txtFuenteFirma.Tag.ToString());

            //txtFuenteNombreClinica.Text = nomClinica.Name.Trim() + ", " + nomClinica.SizeInPoints + "pts.";
            //txtFuenteEspecialidad.Text = especialidad.Name.Trim() + ", " + especialidad.SizeInPoints + "pts.";
            //txtFuenteServiciosOfrecidos.Text = serviciosOfrecidos.Name.Trim() + ", " + serviciosOfrecidos.SizeInPoints + "pts.";
            //txtFuenteTelefono.Text = telefono.Name.Trim() + ", " + telefono.SizeInPoints + "pts.";
            //txtFuenteEmail.Text = email.Name.Trim() + ", " + email.SizeInPoints + "pts.";
            //txtFuenteDireccion.Text = direccion.Name.Trim() + ", " + direccion.SizeInPoints + "pts.";
            //txtFuenteNombrePaciente.Text = nombrePaciente.Name.Trim() + ", " + nombrePaciente.SizeInPoints + "pts.";
            //txtFuenteCedula.Text = cedula.Name.Trim() + ", " + cedula.SizeInPoints + "pts.";
            //txtFuenteEdad.Text = edad.Name.Trim() + ", " + edad.SizeInPoints + "pts.";
            //txtFuentePeso.Text = peso.Name.Trim() + ", " + peso.SizeInPoints + "pts.";
            //txtFuenteTelefonos.Text = telefonos.Name.Trim() + ", " + telefonos.SizeInPoints + "pts.";
            //txtFuenteRX.Text = rx.Name.Trim() + ", " + rx.SizeInPoints + "pts.";
            //txtFuenteFirma.Text = firma.Name.Trim() + ", " + firma.SizeInPoints + "pts.";

            //nomClinica = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/nomClinica"));
            //especialidad = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/especialidad"));
            //serviciosOfrecidos = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/serviciosOfrecidos"));
            //telefono = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/telefono"));
            //email = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/email"));
            //direccion = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/direccion"));
            //nombrePaciente = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/nombrePaciente"));
            //cedula = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/cedula"));
            //edad = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/edad"));
            //peso = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/peso"));
            //telefonos = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/telefonos"));
            //rx = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/rx"));
            //firma = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/firma"));

            txtXNomClinica.Value = Convert.ToDecimal(DeterminaValorX(oXMLCreator.ReadNodes("/Formato/nomClinica")));
            txtYNombreClinica.Value = Convert.ToDecimal(DeterminaValorY(oXMLCreator.ReadNodes("/Formato/nomClinica")));

            txtXEspecialidad.Value = Convert.ToDecimal(DeterminaValorX(oXMLCreator.ReadNodes("/Formato/especialidad")));
            txtYEspecialidad.Value = Convert.ToDecimal(DeterminaValorY(oXMLCreator.ReadNodes("/Formato/especialidad")));

            txtXServiciosOfrecidos.Value = Convert.ToDecimal(DeterminaValorX(oXMLCreator.ReadNodes("/Formato/serviciosOfrecidos")));
            txtYServiciosOfrecidos.Value = Convert.ToDecimal(DeterminaValorY(oXMLCreator.ReadNodes("/Formato/serviciosOfrecidos")));

            txtXTelefono.Value = Convert.ToDecimal(DeterminaValorX(oXMLCreator.ReadNodes("/Formato/telefono")));
            txtYTelefono.Value = Convert.ToDecimal(DeterminaValorY(oXMLCreator.ReadNodes("/Formato/telefono")));

            txtXEmail.Value = Convert.ToDecimal(DeterminaValorX(oXMLCreator.ReadNodes("/Formato/email")));
            txtYEmail.Value = Convert.ToDecimal(DeterminaValorY(oXMLCreator.ReadNodes("/Formato/email")));

            txtXDireccion.Value = Convert.ToDecimal(DeterminaValorX(oXMLCreator.ReadNodes("/Formato/direccion")));
            txtYDireccion.Value = Convert.ToDecimal(DeterminaValorY(oXMLCreator.ReadNodes("/Formato/direccion")));

            txtXNomPaciente.Value = Convert.ToDecimal(DeterminaValorX(oXMLCreator.ReadNodes("/Formato/nombrePaciente")));
            txtYNombrePaciente.Value = Convert.ToDecimal(DeterminaValorY(oXMLCreator.ReadNodes("/Formato/nombrePaciente")));

            txtXCedula.Value = Convert.ToDecimal(DeterminaValorX(oXMLCreator.ReadNodes("/Formato/cedula")));
            txtYCedula.Value = Convert.ToDecimal(DeterminaValorY(oXMLCreator.ReadNodes("/Formato/cedula")));

            txtXEdad.Value = Convert.ToDecimal(DeterminaValorX(oXMLCreator.ReadNodes("/Formato/edad")));
            txtYEdad.Value = Convert.ToDecimal(DeterminaValorY(oXMLCreator.ReadNodes("/Formato/edad")));

            txtXPeso.Value = Convert.ToDecimal(DeterminaValorX(oXMLCreator.ReadNodes("/Formato/peso")));
            txtYPeso.Value = Convert.ToDecimal(DeterminaValorY(oXMLCreator.ReadNodes("/Formato/peso")));

            txtXTelefonosPaciente.Value = Convert.ToDecimal(DeterminaValorX(oXMLCreator.ReadNodes("/Formato/telefonos")));
            txtYTelefonosPaciente.Value = Convert.ToDecimal(DeterminaValorY(oXMLCreator.ReadNodes("/Formato/telefonos")));

            txtXRx.Value = Convert.ToDecimal(DeterminaValorX(oXMLCreator.ReadNodes("/Formato/rx")));
            txtYRx.Value = Convert.ToDecimal(DeterminaValorY(oXMLCreator.ReadNodes("/Formato/rx")));

            txtXFirma.Value = Convert.ToDecimal(DeterminaValorX(oXMLCreator.ReadNodes("/Formato/firma")));
            txtYFirma.Value = Convert.ToDecimal(DeterminaValorY(oXMLCreator.ReadNodes("/Formato/firma")));
        }

        /// <summary>
        /// Lee el archivo XML correspondiente y mediante el método DeterminaValoresFuente establece los valores a todas las fuentes
        /// existentes.
        /// </summary>
        private void EstableceValoresFuentes()
        {
            oXMLCreator.PathXml = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\UserInfo") + "\\Recetas.Xml";

            nomClinica = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/nomClinica"));
            especialidad = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/especialidad"));
            serviciosOfrecidos = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/serviciosOfrecidos"));
            telefono = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/telefono"));
            email = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/email"));
            direccion = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/direccion"));
            nombrePaciente = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/nombrePaciente"));
            cedula = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/cedula"));
            edad = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/edad"));
            peso = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/peso"));
            telefonos = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/telefonos"));
            rx = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/rx"));
            firma = DeterminaValoresFuente(oXMLCreator.ReadNodes("/Formato/firma"));
        }

        private void EstableceTextoFuente()
        {
            txtFuenteNombreClinica.Text = nomClinica.Name.Trim() + ", " + nomClinica.SizeInPoints + "pts.";
            txtFuenteEspecialidad.Text = especialidad.Name.Trim() + ", " + especialidad.SizeInPoints + "pts.";
            txtFuenteServiciosOfrecidos.Text = serviciosOfrecidos.Name.Trim() + ", " + serviciosOfrecidos.SizeInPoints + "pts.";
            txtFuenteTelefono.Text = telefono.Name.Trim() + ", " + telefono.SizeInPoints + "pts.";
            txtFuenteEmail.Text = email.Name.Trim() + ", " + email.SizeInPoints + "pts.";
            txtFuenteDireccion.Text = direccion.Name.Trim() + ", " + direccion.SizeInPoints + "pts.";
            txtFuenteNombrePaciente.Text = nombrePaciente.Name.Trim() + ", " + nombrePaciente.SizeInPoints + "pts.";
            txtFuenteCedula.Text = cedula.Name.Trim() + ", " + cedula.SizeInPoints + "pts.";
            txtFuenteEdad.Text = edad.Name.Trim() + ", " + edad.SizeInPoints + "pts.";
            txtFuentePeso.Text = peso.Name.Trim() + ", " + peso.SizeInPoints + "pts.";
            txtFuenteTelefonos.Text = telefonos.Name.Trim() + ", " + telefonos.SizeInPoints + "pts.";
            txtFuenteRX.Text = rx.Name.Trim() + ", " + rx.SizeInPoints + "pts.";
            txtFuenteFirma.Text = firma.Name.Trim() + ", " + firma.SizeInPoints + "pts.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = nomClinica;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
                nomClinica = fontDialog1.Font;

            EstableceTextoFuente();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = especialidad;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
                especialidad = fontDialog1.Font;

            EstableceTextoFuente();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = serviciosOfrecidos;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
                serviciosOfrecidos = fontDialog1.Font;

            EstableceTextoFuente();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = telefono;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
                telefono = fontDialog1.Font;

            EstableceTextoFuente();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = email;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
                email = fontDialog1.Font;

            EstableceTextoFuente();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = direccion;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
                direccion = fontDialog1.Font;

            EstableceTextoFuente();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = nombrePaciente;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
                nombrePaciente = fontDialog1.Font;

            EstableceTextoFuente();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = cedula;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
                cedula = fontDialog1.Font;

            EstableceTextoFuente();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = edad;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
                edad = fontDialog1.Font;

            EstableceTextoFuente();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = peso;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
                peso = fontDialog1.Font;

            EstableceTextoFuente();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = telefonos;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
                telefonos = fontDialog1.Font;

            EstableceTextoFuente();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = rx;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
                rx = fontDialog1.Font;

            EstableceTextoFuente();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = firma;

            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
                firma = fontDialog1.Font;

            EstableceTextoFuente();
        }

        #endregion

        private XFont oXFont(Font pFont)
        {
            XFont oFont = null;

            try
            {
                oFont = new XFont(pFont.FontFamily.Name, Convert.ToDouble(pFont.Size));
            }
            catch { oFont = new XFont("Microsoft Sans Serif", 8.25f); }
            return oFont;
        }

        public XSize TextSize(string pText, XFont pXFont)
        {
            XSize size = new XSize();

            return size = gfx.MeasureString(pText, pXFont);
        }

        ////public PagePreview.RenderEvent RenderEvent
        ////{
        ////    get { return this.renderEvent; }
        ////    set
        ////    {
        ////        this.pagePreview.SetRenderEvent(value);
        ////        this.renderEvent = value;
        ////    }
        ////}
        ////PagePreview.RenderEvent renderEvent;

        ///// <summary>
        ///// Prints the document to the default printer.
        ///// See MSDN documentation for information about printer selection and printer settings.
        ///// </summary>
        //public void Print()
        //{
        //    PrintDocument pd = new PrintDocument();
        //    pd.PrintPage += new PrintPageEventHandler(PrintPage);
        //    pd.Print();
        //}

        ///// <summary>
        ///// Draws the page on the printer.
        ///// </summary>
        //private void PrintPage(object sender, PrintPageEventArgs ev)
        //{
        //    Graphics graphics = ev.Graphics;
        //    graphics.PageUnit = GraphicsUnit.Point;
        //    gfx = XGraphics.FromGraphics(graphics, PageSizeConverter.ToSize(PageSize.A4));

        //    //if (this.renderEvent != null)
        //    //    this.renderEvent(gfx);

        //    ev.HasMorePages = false;
        //}

        public void Print()
        {
            string file = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles") + "\\TempFile_Prescription.pdf";

            if (File.Exists(file))
            {
                PdfFilePrinter.AdobeReaderPath = txtAdobeExePath.Text.Trim();
                // Set the file to print and the Windows name of the printer.
                PdfFilePrinter printer = new PdfFilePrinter(file, comboBox1.Text.Trim());
                //&nbsp;
                try
                {
                    printer.Print();                    
                }
                catch 
                {}
            }
        }

        public void ExportarPDF(string pNombrePaciente, string pCedula, string pEdad, string pPeso, string pTelefonos,
                                string pNombreDoctor, string pCodigoDoctor, string[] pItemsReceta, bool pPrint)
        {
            #region Variables Privadas

            PdfDocument document = new PdfDocument();

            document.Info.Title = Program.oCEmpresa.NombreEmpresa;

            //// Create an empty page
            PdfPage page = document.AddPage();

            gfx = XGraphics.FromPdfPage(page);

            string completeFileName = "";

            double x = 50, auxX = 0, y = 135;

            string categoria = "";

            char[] caracterBuscado = { ' ' };
            string[] ocadenaTemp = null;

            string fileName = "";

            #region Fonts

            //Título
            //XFont nomClinica = FormatoPDF.FontName(txtFuenteNombreClinica.te;

            xNomClinica = oXFont(nomClinica);
            xEspecialidad = oXFont(especialidad);
            xServiciosOfrecidos = oXFont(serviciosOfrecidos);
            xTelefono = oXFont(telefono);
            xEmail = oXFont(email);
            xDireccion = oXFont(direccion);
            xNombrePaciente = oXFont(nombrePaciente);
            xCedula = oXFont(cedula);
            xEdad = oXFont(edad);
            xPeso = oXFont(peso);
            xTelefonos = oXFont(telefonos);
            xRx = oXFont(rx);
            xFirma = oXFont(firma);

            #endregion

            //double nextLine = arialBlack.GetHeight(gfx);
            //double nextLine2 = arial.GetHeight(gfx);

            #endregion

            try
            {
                fileName = "\\TempFile_Prescription.pdf";
                completeFileName = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles") + fileName;
                File.Delete(completeFileName);
            }
            catch
            {
                MessageBox.Show(this, "No se puede crear el archivo/reporte ya que otro está actualmente en uso, cierre el archivo temporal en uso primero y vuelva a intentar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            gfx.DrawString(Program.oCEmpresa.NombreEmpresa.Trim(), xNomClinica, XBrushes.Black, Convert.ToDouble(txtXNomClinica.Value), Convert.ToDouble(txtYNombreClinica.Value));
            gfx.DrawString(DateTime.Now.ToLongDateString(), xNormalFont, XBrushes.Black, 365, Convert.ToDouble(txtYNombreClinica.Value));
            gfx.DrawString(Program.oCEmpresa.Especialidad.Trim(), xEspecialidad, XBrushes.Black, Convert.ToDouble(txtXEspecialidad.Value), Convert.ToDouble(txtYEspecialidad.Value));
            gfx.DrawString(Program.oCEmpresa.ServiciosOfrecidos.Trim(), xServiciosOfrecidos, XBrushes.Black, Convert.ToDouble(txtXServiciosOfrecidos.Value), Convert.ToDouble(txtYServiciosOfrecidos.Value));
            gfx.DrawString(Program.oCEmpresa.Telefono.Trim(), xTelefono, XBrushes.Black, Convert.ToDouble(txtXTelefono.Value), Convert.ToDouble(txtYTelefono.Value));
            gfx.DrawString(Program.oCEmpresa.Email.Trim(), xEmail, XBrushes.Black, Convert.ToDouble(txtXEmail.Value), Convert.ToDouble(txtYEmail.Value));
            gfx.DrawString(Program.oCEmpresa.Direccion.Trim(), xDireccion, XBrushes.Black, Convert.ToDouble(txtXDireccion.Value), Convert.ToDouble(txtYDireccion.Value));

            gfx.DrawString("Nombre del Paciente: ", xNombrePaciente, XBrushes.Black, Convert.ToDouble(txtXNomPaciente.Value), Convert.ToDouble(txtYNombrePaciente.Value));
            gfx.DrawString("Cédula: ", xCedula, XBrushes.Black, Convert.ToDouble(txtXCedula.Value), Convert.ToDouble(txtYCedula.Value));
            gfx.DrawString("Edad: ", xEdad, XBrushes.Black, Convert.ToDouble(txtXEdad.Value), Convert.ToDouble(txtYEdad.Value));
            gfx.DrawString("Peso: ", xPeso, XBrushes.Black, Convert.ToDouble(txtXPeso.Value), Convert.ToDouble(txtYPeso.Value));
            gfx.DrawString("Teléfonos: ", xTelefonos, XBrushes.Black, Convert.ToDouble(txtXTelefonosPaciente.Value), Convert.ToDouble(txtYTelefonosPaciente.Value));

            gfx.DrawString(pNombrePaciente, xNormalFont, XBrushes.Black, TextSize("Nombre del Paciente: ", xNombrePaciente).Width + Convert.ToDouble(txtXNomPaciente.Value) + 6, Convert.ToDouble(txtYNombrePaciente.Value));
            gfx.DrawString(pCedula.Trim(), xNormalFont, XBrushes.Black, TextSize("Cédula: ", xCedula).Width + Convert.ToDouble(txtXCedula.Value) + 10, Convert.ToDouble(txtYCedula.Value));
            gfx.DrawString(pEdad.Trim(), xNormalFont, XBrushes.Black, TextSize("Edad: ", xEdad).Width + Convert.ToDouble(txtXEdad.Value) + 10, Convert.ToDouble(txtYEdad.Value));
            gfx.DrawString(pPeso.Trim(), xNormalFont, XBrushes.Black, TextSize("Peso: ", xPeso).Width + Convert.ToDouble(txtXPeso.Value) + 10, Convert.ToDouble(txtYPeso.Value));
            gfx.DrawString(pTelefonos.Trim(), xNormalFont, XBrushes.Black, TextSize("Teléfonos: ", xTelefono).Width + Convert.ToDouble(txtXTelefonosPaciente.Value) + 10, Convert.ToDouble(txtYTelefonosPaciente.Value));

            gfx.DrawString("Rx: ", xRx, XBrushes.Black, Convert.ToDouble(txtXRx.Value), Convert.ToDouble(txtYRx.Value));

            if (pItemsReceta != null)
            {
                double auxY = Convert.ToDouble(txtYRx.Value);
                for (int i = 0; i < pItemsReceta.Length; )
                {
                    gfx.DrawString(pItemsReceta[i].Trim(), xItemsReceta, XBrushes.Black, TextSize("Rx: ", xRx).Width + Convert.ToDouble(txtXRx.Value) + 10, auxY);
                    auxY += 12;
                    i++;
                }
            }

            gfx.DrawString("____________________", xFirma, XBrushes.Black, Convert.ToDouble(txtXFirma.Value), Convert.ToDouble(txtYFirma.Value));
            gfx.DrawString(pNombreDoctor, xFirma, XBrushes.Black, Convert.ToDouble(txtXFirma.Value), Convert.ToDouble(txtYFirma.Value + 15));
            gfx.DrawString(pCodigoDoctor, xFirma, XBrushes.Black, Convert.ToDouble(txtXFirma.Value), Convert.ToDouble(txtYFirma.Value + 27));

            document.ViewerPreferences.FitWindow = true;

            #region Crea archivo temporal y da opción de guardar archivo en carpeta de preferencia

            //Salvamos el documento en la carpeta de archivos temporales...
            document.Save(completeFileName);

            #region Guarda Copia de Archivo Temporal - INACTIVO

            //try
            //{
            //    SaveFileDialog oSaveFileDialog = new SaveFileDialog();

            //    oSaveFileDialog.Filter = "PDF File|*.pdf";
            //    oSaveFileDialog.Title = "Guardar copia de Hoja de Reparación";

            //    if (oSaveFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        string newDestiny = "";

            //        if (!oSaveFileDialog.FileName.Contains(".pdf"))
            //            newDestiny = oSaveFileDialog.FileName.Trim() + ".pdf";
            //        else
            //            newDestiny = oSaveFileDialog.FileName.Trim();

            //        File.Copy(completeFileName, newDestiny);

            //        completeFileName = newDestiny; 
            //    }
            //}
            //catch { }

            #endregion

            #endregion

            //Inicia el proceso, es decir, abre el archivo, si no se guardó el archivo recién generado en otra ubicación 
            //se abrirá el archivo Temporal
            //Process oProcess = 
            Process.Start(completeFileName);

            if (pPrint == true)
                this.Print();

            //System.Threading.Thread.Sleep(5000);

            //oProcess.CloseMainWindow();
            //oProcess.Close();            

            #region Liberamos Recursos

            gfx.Dispose();
            document.Dispose();

            #endregion
        }

        private void btnPrevisualizarReceta_Click(object sender, EventArgs e)
        {
            ExportarPDF("","","","","","","",null, false);
        }

        public void ListaDeImpresorasInstaladas()
        {
            comboBox1.Items.Clear();

            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
                comboBox1.Items.Add(strPrinter.Trim());
        }

        public void frmPrescriptionPad_Load(object sender, EventArgs e)
        {
            ListaDeImpresorasInstaladas();

            if (File.Exists(Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\UserInfo") + "\\Recetas.Xml"))
            {
                EstableceValoresFuentes();
                EstableceValoresXY();
                EstableceImpresoraYEjecutableAdobe();
            }

            EstableceTextoFuente();
        }

        private void btnGuardarFormato_Click(object sender, EventArgs e)
        {
            File.Delete(Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\UserInfo") + "\\Recetas.Xml");

            oXMLCreator.CreateXMLDocument(Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\UserInfo") + "\\Recetas.Xml", "Formato");

            oXMLCreator.AddChildNodes("nomClinica", nomClinica.Name.Trim() + "|" + nomClinica.Size.ToString().Trim() + "|" + nomClinica.Style.ToString().Trim() + "|" + txtXNomClinica.Value.ToString() + "|" + txtYNombreClinica.Value.ToString());
            oXMLCreator.AddChildNodes("especialidad", especialidad.Name.Trim() + "|" + especialidad.Size.ToString().Trim() + "|" + especialidad.Style.ToString().Trim() + "|" + txtXEspecialidad.Value.ToString() + "|" + txtYEspecialidad.Value.ToString());
            oXMLCreator.AddChildNodes("serviciosOfrecidos", serviciosOfrecidos.Name.Trim() + "|" + serviciosOfrecidos.Size.ToString().Trim() + "|" + serviciosOfrecidos.Style.ToString().Trim() + "|" + txtXServiciosOfrecidos.Value.ToString() + "|" + txtYServiciosOfrecidos.Value.ToString());
            oXMLCreator.AddChildNodes("telefono", telefono.Name.Trim() + "|" + telefono.Size.ToString().Trim() + "|" + telefono.Style.ToString().Trim() + "|" + txtXTelefono.Value.ToString() + "|" + txtYTelefono.Value.ToString());
            oXMLCreator.AddChildNodes("email", email.Name.Trim() + "|" + email.Size.ToString().Trim() + "|" + email.Style.ToString().Trim() + "|" + txtXEmail.Value.ToString() + "|" + txtYEmail.Value.ToString());
            oXMLCreator.AddChildNodes("direccion", direccion.Name.Trim() + "|" + direccion.Size.ToString().Trim() + "|" + direccion.Style.ToString().Trim() + "|" + txtXDireccion.Value.ToString() + "|" + txtYDireccion.Value.ToString());
            oXMLCreator.AddChildNodes("nombrePaciente", nombrePaciente.Name.Trim() + "|" + nombrePaciente.Size.ToString().Trim() + "|" + nombrePaciente.Style.ToString().Trim() + "|" + txtXNomPaciente.Value.ToString() + "|" + txtYNombrePaciente.Value.ToString());
            oXMLCreator.AddChildNodes("cedula", cedula.Name.Trim() + "|" + cedula.Size.ToString().Trim() + "|" + cedula.Style.ToString().Trim() + "|" + txtXCedula.Value.ToString() + "|" + txtYCedula.Value.ToString());
            oXMLCreator.AddChildNodes("edad", edad.Name.Trim() + "|" + edad.Size.ToString().Trim() + "|" + edad.Style.ToString().Trim() + "|" + txtXEdad.Value.ToString() + "|" + txtYEdad.Value.ToString());
            oXMLCreator.AddChildNodes("peso", peso.Name.Trim() + "|" + peso.Size.ToString().Trim() + "|" + peso.Style.ToString().Trim() + "|" + txtXPeso.Value.ToString() + "|" + txtYPeso.Value.ToString());
            oXMLCreator.AddChildNodes("telefonos", telefonos.Name.Trim() + "|" + telefonos.Size.ToString().Trim() + "|" + telefonos.Style.ToString().Trim() + "|" + txtXTelefonosPaciente.Value.ToString() + "|" + txtYTelefonosPaciente.Value.ToString());
            oXMLCreator.AddChildNodes("rx", rx.Name.Trim() + "|" + rx.Size.ToString().Trim() + "|" + rx.Style.ToString().Trim() + "|" + txtXRx.Value.ToString() + "|" + txtYRx.Value.ToString());
            oXMLCreator.AddChildNodes("firma", firma.Name.Trim() + "|" + firma.Size.ToString().Trim() + "|" + firma.Style.ToString().Trim() + "|" + txtXFirma.Value.ToString() + "|" + txtYFirma.Value.ToString());

            oXMLCreator.AddChildNodes("print", txtAdobeExePath.Text.Trim() + "|" + comboBox1.Text.Trim());
        }

        private void txtXNomClinica_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtYNombreClinica_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                txtAdobeExePath.Text = openFileDialog1.FileName.Trim();
        }

        private void tobPrinter_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
            comboBox1.Focus();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void frmPrescriptionPad_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
                Program.oMDI.Activate();
        }
    }
}