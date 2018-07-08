using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmActivityLogReport : Form
    {
        public frmActivityLogReport()
        {
            InitializeComponent();
            this.SetStyles();
        }

        Comprobaciones oComprobaciones = new Comprobaciones();
 
        #region Métodos propios de diseño de interfaz

        private void SetStyles()
        {
            //Makes sure the form repaints when it was resized
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            try
            {
                // Getting the graphics object
                Graphics g = pevent.Graphics;

                // Creating the rectangle for the gradient
                System.Drawing.Rectangle rBackground = new System.Drawing.Rectangle(0, 0, this.Width, (this.Height) / 2);

                // Creating the lineargradient
                // Creating the lineargradient
                System.Drawing.Drawing2D.LinearGradientBrush bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground, Color.FromArgb(204, 217, 234), System.Drawing.Color.White, 91);
                // Draw the gradient onto the form
                g.FillRectangle(bBackground, rBackground);

                // Disposing of the resources held by the brush
                bBackground.Dispose();

                // Getting the graphics object
                Graphics g3 = pevent.Graphics;

                // Creating the rectangle for the gradient
                System.Drawing.Rectangle rBackground3 = new System.Drawing.Rectangle(0, (this.Height) / 2, this.Width, (this.Height) / 2);

                // Creating the lineargradient
                System.Drawing.Drawing2D.LinearGradientBrush bBackground3 = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground3, System.Drawing.Color.White, Color.FromArgb(204, 217, 234), 91);

                // Draw the gradient onto the form
                g.FillRectangle(bBackground3, rBackground3);

                // Disposing of the resources held by the brush
                bBackground3.Dispose();
            }
            catch { }
        }

        #endregion
        private string Accion(string pAccion)
        {
            string accion = "";
            switch (pAccion)
            {
                case "Insertar":
                    accion = "Insertar";
                    break;
                case "Modificar":
                    accion = "Update";
                    break;
                case "Eliminar":
                    accion = "Delete";
                    break;
            }

            return accion;
        }

        private void btnBuscarLogs_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            try
            {
                SqlCommand oSql = new SqlCommand();
                oSql.Connection = Program.oPersistencia.conexion;
                oSql.CommandType = CommandType.StoredProcedure;
                oSql.CommandText = "sp_S_ReporteLogs";
                oSql.Parameters.AddWithValue("startdate", dtFechaInicial.Value.ToShortDateString());// WithValue("startdate", (object)dtFechaInicial.Value.ToShortDateString());
                oSql.Parameters.AddWithValue("enddate", dtFechaFinal.Value.ToShortDateString());
                oSql.Parameters.AddWithValue("username", (object)cmbUsuario.Text);
                oSql.Parameters.AddWithValue("action", (object)Accion(cmbAccion.Text.ToString()));

                DataSet ds = Program.oPersistencia.ejecutarSQLListas(oSql);

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    ds.Dispose();
                }

                oSql.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Se encontró un error en el sistema, por favor intente de nuevo." + Environment.NewLine + ex.Message + ". " + Environment.NewLine + ex.InnerException + ".", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void CargarUsuarios()
        {
            DataSet dt_3 = Program.oPersistencia.ejecutarSQLListas("sp_helpuser", "db");

            // Verifico el Error
            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                return;
            }

            cmbUsuario.Items.Clear();
            foreach (DataRow dr in dt_3.Tables[0].Rows)
            {
                if (dr[0].ToString() != "guest" && dr[0].ToString() != "dbo" && dr[0].ToString() != "INFORMATION_SCHEMA" && dr[0].ToString() != "sys")
                    this.cmbUsuario.Items.Add(dr[0].ToString());
            }
            dt_3.Dispose();
        }

        private void frmActivityLogReport_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // creating Excel Application
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();


                // creating new WorkBook within Excel application
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

                // creating new Excelsheet in workbook
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                // see the excel sheet behind the program
                app.Visible = true;

                // get the reference of first sheet. By default its name is Sheet1.
                // store its reference to worksheet

                try
                {
                    worksheet = workbook.Sheets["Hoja1"];
                }
                catch { worksheet = workbook.Sheets["Sheet1"]; }                    

                worksheet = workbook.ActiveSheet;

                // changing the name of active sheet
                worksheet.Name = "Exported from gridview";


                // storing header part in Excel
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                // storing Each row and column value to excel sheet
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save the application
                workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                MessageBox.Show(this, "Se exportó satisfactoriamente el registro de actividades a un archivo de Excel, dicho archivo se encuentra ubicado en: c:\\output.xls", "Archivo exportado con éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception oExc) { MessageBox.Show(this, "Se produjo el siguiente error al exportar: " + oExc.Message); }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
            cmbUsuario.SelectedIndex = -1;
            cmbAccion.SelectedIndex = -1;

            dtFechaInicial.Value = DateTime.Today;
            dtFechaFinal.Value = DateTime.Today;
        }
    }
}