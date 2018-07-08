using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class TextEditor : UserControl
    {
        #region Variables

        private string currentFile;
        private int checkPrint;

        int indentValue = 0;

        ExtendedRichTextBox.RichTextBoxPrintCtrl oAuxRichTextBox = new ExtendedRichTextBox.RichTextBoxPrintCtrl();

        /// <summary>
        /// Variable que hay que utilizar para poder enviar a imprimir desde código, es 100% necesaria
        /// </summary>
        public ExtendedRichTextBox.RichTextBoxPrintCtrl OAuxRichTextBox
        {
            get { return oAuxRichTextBox; }
            set { oAuxRichTextBox = value; }
        }

        PrintDialog oPrintDialog = new PrintDialog();
        PrintDocument oPrintDocument = new PrintDocument();
        PrintPreviewDialog oPrintPreviewDialog = new PrintPreviewDialog();

        public Font defaultFont = null;
        public Color defaultForeColor = new Color();

        #endregion

        public TextEditor()
        {
            InitializeComponent();
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(rtbDoc.SelectionFont == null))
                {
                    System.Drawing.Font currentFont = rtbDoc.SelectionFont;
                    System.Drawing.FontStyle newFontStyle;

                    newFontStyle = rtbDoc.SelectionFont.Style ^ FontStyle.Bold;

                    rtbDoc.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

                    boldButton.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(rtbDoc.SelectionFont == null))
                {
                    System.Drawing.Font currentFont = rtbDoc.SelectionFont;
                    System.Drawing.FontStyle newFontStyle;

                    newFontStyle = rtbDoc.SelectionFont.Style ^ FontStyle.Italic;

                    rtbDoc.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(rtbDoc.SelectionFont == null))
                {
                    System.Drawing.Font currentFont = rtbDoc.SelectionFont;
                    System.Drawing.FontStyle newFontStyle;

                    newFontStyle = rtbDoc.SelectionFont.Style ^ FontStyle.Underline;

                    rtbDoc.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog1.Color = rtbDoc.ForeColor;
                if (ColorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rtbDoc.SelectionColor = ColorDialog1.Color;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void backColorButton_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog1.Color = rtbDoc.BackColor;
                if (ColorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rtbDoc.SelectionBackColor = ColorDialog1.Color;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.Title = "RTE - Insert Image File";
            OpenFileDialog1.DefaultExt = "rtf";
            OpenFileDialog1.Filter = "Bitmap Files|*.bmp|JPEG Files|*.jpg|GIF Files|*.gif";
            OpenFileDialog1.FilterIndex = 2;
            OpenFileDialog1.FileName = "";
            OpenFileDialog1.ShowDialog();

            if (OpenFileDialog1.FileName == "")
            {
                return;
            }

            try
            {
                string strImagePath = OpenFileDialog1.FileName;
                Image oImage = null;

                DialogResult o = MessageBox.Show(this, "¿Se creará una copia temporal de la imagen actual por propósitos de edición, desea continuar con estas acciones?. Presione SÍ si desea modificar la imagen, NO si desea agregar la imagen original y CANCELAR para no realizar ninguna acción", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (o == System.Windows.Forms.DialogResult.Yes)
                {
                    string path = "";
                    oImage = Metodos_Globales.CreateTempImageFromByteArray(File.ReadAllBytes(strImagePath), out path);

                    if (oImage != null)
                    {
                        System.Diagnostics.Process.Start("mspaint", path).WaitForExit();

                        oImage = Image.FromFile(path);
                    }
                    else
                        MessageBox.Show(this, "¿Hubo un problema con la creación de la imagen temporal, por favor intente de nuevo. Si el problema persiste comuníquese con la persona que da soporte a su empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (o == DialogResult.No)
                    oImage = Image.FromFile(strImagePath);

                if (oImage != null)
                {
                    Clipboard.SetDataObject(oImage);
                    DataFormats.Format df;
                    df = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (this.rtbDoc.CanPaste(df))
                    {
                        this.rtbDoc.Paste(df);
                    }

                    oImage.Dispose();
                    oImage = null;
                }
            }
            catch
            {
                MessageBox.Show("Unable to insert image format selected.", "RTE - Paste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void justifyLeftButton_Click(object sender, EventArgs e)
        {
            rtbDoc.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void justifyCenterButton_Click(object sender, EventArgs e)
        {
            rtbDoc.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void justifyRightButton_Click(object sender, EventArgs e)
        {
            rtbDoc.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void orderedListButton_Click(object sender, EventArgs e)
        {

        }

        private void unorderedListButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtbDoc.SelectionBullet == false)
                {
                    rtbDoc.BulletIndent = 10;
                    rtbDoc.SelectionBullet = true;
                }
                else
                    rtbDoc.SelectionBullet = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void fontToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(rtbDoc.SelectionFont == null))
                {
                    FontDialog1.Font = rtbDoc.SelectionFont;
                }
                else
                {
                    FontDialog1.Font = null;
                }
                FontDialog1.ShowApply = true;
                if (FontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rtbDoc.SelectionFont = FontDialog1.Font;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog1.Title = "RTE - Save File";
                SaveFileDialog1.DefaultExt = "rtf";
                SaveFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|HTML Files|*.htm|All Files|*.*";
                SaveFileDialog1.FilterIndex = 1;

                if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (SaveFileDialog1.FileName == "")
                    {
                        return;
                    }

                    string strExt;
                    strExt = System.IO.Path.GetExtension(SaveFileDialog1.FileName);
                    strExt = strExt.ToUpper();

                    if (strExt == ".RTF")
                    {
                        rtbDoc.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        System.IO.StreamWriter txtWriter;
                        txtWriter = new System.IO.StreamWriter(SaveFileDialog1.FileName);
                        txtWriter.Write(rtbDoc.Text);
                        txtWriter.Close();
                        txtWriter = null;
                        rtbDoc.SelectionStart = 0;
                        rtbDoc.SelectionLength = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Save File request cancelled by user.", "Cancelled");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void OpenFile()
        {
            try
            {
                OpenFileDialog1.Title = "RTE - Open File";
                OpenFileDialog1.DefaultExt = "rtf";
                OpenFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|HTML Files|*.htm|All Files|*.*";
                OpenFileDialog1.FilterIndex = 1;
                OpenFileDialog1.FileName = string.Empty;

                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    if (OpenFileDialog1.FileName == "")
                    {
                        return;
                    }

                    string strExt;
                    strExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName);
                    strExt = strExt.ToUpper();

                    if (strExt == ".RTF")
                    {
                        rtbDoc.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        System.IO.StreamReader txtReader;
                        txtReader = new System.IO.StreamReader(OpenFileDialog1.FileName);
                        rtbDoc.Text = txtReader.ReadToEnd();
                        txtReader.Close();
                        txtReader = null;
                        rtbDoc.SelectionStart = 0;
                        rtbDoc.SelectionLength = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Open File request cancelled by user.", "Cancelled");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        public void GuardarArchivoTemporal(string pFileName)
        {
            rtbDoc.SaveFile(pFileName, RichTextBoxStreamType.RichText);
        }

        public void AbrirArchivo(string pFileName)
        {
            try
            {
                rtbDoc.LoadFile(pFileName, RichTextBoxStreamType.RichText);
            }
            catch 
            { 
                rtbDoc.LoadFile(pFileName, RichTextBoxStreamType.PlainText); 
            }
        }

        public void Limpiar()
        {
            rtbDoc.Clear();
        }

        public string RTF()
        {
            return rtbDoc.Rtf;
        }

        public string rtfText
        {
            set { rtbDoc.Rtf = value; }
            get { return rtbDoc.Rtf; }
        }

        public void textCopy()
        {
            rtbDoc.SelectAll(); 
            rtbDoc.Copy();
        }

        public void textPaste()
        {
            rtbDoc.Paste();
        }

        public string SelectedText
        {
            get { return rtbDoc.SelectedText; }
        }

        public void EstableceTexto(string pRTB)
        {
            rtbDoc.Rtf = pRTB;
        }

        public void ProtectText()
        {
            rtbDoc.SelectAll();
            rtbDoc.SelectionProtected = true;
            rtbDoc.Select(0, 0);
        }

        public void UnProtectText()
        {
            rtbDoc.SelectAll();
            rtbDoc.SelectionProtected = false;
            rtbDoc.Select(0, 0);
        }

        public int FindText(string pText)
        {
            int foundValue= rtbDoc.Find(pText, RichTextBoxFinds.WholeWord);
            rtbDoc.Select(0, 0);//No permite que se seleccione ningún tipo de texto
            
            return foundValue;
        }

        public string[] TextLines()
        {
            return rtbDoc.Lines;
        }

        public string Texto
        {
            set { rtbDoc.Text += value; }
            get { return rtbDoc.Text; }
        }

        public void SetReadOnly(bool state)
        {
            rtbDoc.ReadOnly = state;
        }

        public void TextSelected(string selectedText)
        {
            rtbDoc.SelectedText += selectedText;            
        }

        public int TotalLines()
        {
            string[] oLines = rtbDoc.Lines;

            return oLines.Length;
        }

        public void SelectionColor(Color oColor)
        {
            rtbDoc.SelectionColor = oColor;
        }

        public void TextForeColor(Color oColor)
        {
            rtbDoc.ForeColor = oColor;
        }

        public void ChangeFont(string pFontName)
        {
            rtbDoc.Font = new Font(pFontName, rtbDoc.Font.Size, rtbDoc.Font.Style);  
        }

        public void FontSize(float pSize)
        {
            rtbDoc.Font = new Font(rtbDoc.Font.FontFamily, pSize, rtbDoc.Font.Style); 
        }

        public void ActivateBulletsAtStartup()
        {
            rtbDoc.SelectionBullet = true;
        }

        #region Print

        public void Print()
        {
            try
            {
                oPrintDialog.Document = oPrintDocument;

                if (oPrintDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    oPrintDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        void oPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            checkPrint = oAuxRichTextBox.Print(checkPrint, oAuxRichTextBox.TextLength, e);

            if (checkPrint < oAuxRichTextBox.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        void oPrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            checkPrint = 0;
        }

        

        #endregion

        #region Print Directly

        private void PrintDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            checkPrint = 0;
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            checkPrint = rtbDoc.Print(checkPrint, rtbDoc.TextLength, e);

            if (checkPrint < rtbDoc.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        public void printToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog1.Document = PrintDocument1;

                if (PrintDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    PrintDocument1.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        #endregion

        private void printPreview_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreviewDialog1.Document = PrintDocument1;
                PrintPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void outdentButton_Click(object sender, EventArgs e)
        {
            indentValue -= 5;

            if (indentValue < 0)
                indentValue = 0;

            rtbDoc.SelectionIndent = indentValue;
        }

        private void indentButton_Click(object sender, EventArgs e)
        {
            indentValue += 5;

            if (indentValue > 20)
                indentValue = 20;

            rtbDoc.SelectionIndent = indentValue;
        }

        public void EstableceValoresDefault()
        {
            rtbDoc.SelectionIndent = 0;
            rtbDoc.Font = defaultFont;
            rtbDoc.ForeColor = defaultForeColor;
            rtbDoc.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void TextEditor_Load(object sender, EventArgs e)
        {
            defaultFont = rtbDoc.Font;
            defaultForeColor = rtbDoc.ForeColor;
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDoc.Copy();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDoc.Paste();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDoc.Cut();
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDoc.SelectAll();
        }
    }
}
