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

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmExamenesConsulta : Form
    {
        bool activo = false;

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        string numExpediente = "";

        public frmExamenesConsulta(string pNumExpediente)
        {
            InitializeComponent();
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.ExamenesYGabinete);

            numExpediente = pNumExpediente;

            this.Region = Shape.RoundedRegion(this.Size, 8, Shape.Corner.None);
            softNetExamOrganizer1.Region = Shape.RoundedRegion(softNetExamOrganizer1.Size, 7, Shape.Corner.None);

            this.Left = ((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2);

            int top = 0;
            top = Screen.PrimaryScreen.WorkingArea.Height - this.Height - Program.oMDI.statusStrip1.Height - Program.oFrmDock.Height;

            if (top < 0)
                top = 0;

            this.Top = top;
        }

        #region Variables e instancias

        CExamenesConsulta oCExamenesConsulta = new CExamenesConsulta();
        CGabineteConsulta oCGabineteConsulta = new CGabineteConsulta();
        CPacientes oCPacientes = new CPacientes();

        ArrayList oArregloIdExamenes = new ArrayList();
        ArrayList oArregloExamenes = new ArrayList();
        ArrayList oArregloFechasResultados = new ArrayList();
        ArrayList oArregloDetalleAdicional = new ArrayList();

        ArrayList oArregloIdGabinetes = new ArrayList();
        ArrayList oArregloGabinetes = new ArrayList();
        ArrayList oArregloFechasResultadosGabinete = new ArrayList();
        ArrayList oArregloDetalleAdicionalGabinete = new ArrayList();

        ArrayList oArregloTempTag = new ArrayList();

        #endregion

        private void ObtieneDatosPaciente()
        {
            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Pacientes_Param '" + numExpediente.Trim() + "'", "Paciente");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TxtNombre.Text = dr[3].ToString().Trim() + " " + dr[4].ToString().Trim();
                        txtDetAdicionalExamenes.Text += dr["DetallesAdicionalesExamenes"].ToString().Trim();
                    }
                }
            }
            ds.Dispose();
        }

        private void frmExamenesConsulta_Load(object sender, EventArgs e)
        {
            lblNumExpediente.Text = numExpediente.Trim();

            ObtieneDatosPaciente();
            AgregarExamenesAGrid();
            AgregarGabinetesAGrid();
        }

        /// <summary>
        /// Método que agrega la fila y Columna iniciales, que pasarán a ser las cabeceras de las filas y columnas del grid
        /// </summary>
        private void AgregaFilaInicial()
        {
            softNetExamOrganizer1.Columns.Clear();
            softNetExamOrganizer1.Rows.Clear();

            DataGridViewColumn oColumn = new DataGridViewColumn();
            DataGridViewCell oCell = new DataGridViewTextBoxCell();

            oColumn.Name = "BaseColumn";
            oColumn.CellTemplate = oCell;
            oColumn.HeaderText = "Base Column";
            oColumn.Frozen = true;
            oColumn.Visible = true;
            oColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            softNetExamOrganizer1.Columns.Add(oColumn);
            softNetExamOrganizer1.Rows.Add();
        }

        /// <summary>
        /// Agrega los exámenes prescritos al Historial de Exámenes del Paciente, durante 
        /// </summary>
        private void AgregarExamenesAGrid()
        {
            #region Limpia Arreglos

            oArregloIdExamenes.Clear();
            oArregloExamenes.Clear();
            oArregloFechasResultados.Clear();
            oArregloDetalleAdicional.Clear();

            #endregion

            AgregaFilaInicial();

            int indexFila = 1;
            int auxIndexFila = 0;
            int indexColumna = 1;
            int auxIndexColumna = -1;

            string nombreExamen = "";
            DateTime fechaResultado = new DateTime();

            StringBuilder oSql = new StringBuilder();
            oSql.Append("Select a.*, b.nombre, d.fecha_consulta, detalle_resultados ");
            oSql.Append("from Examenes_Consulta a, Examenes_Laboratorio b, Paciente c, Consulta_Paciente d ");
            oSql.Append("where a.id_examen = b.id_examen and a.id_consulta = d.id_consulta and d.num_expediente = c.num_expediente ");
            oSql.Append("and c.num_expediente = " + numExpediente.Trim() + " order by d.fecha_consulta");

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(oSql.ToString().Trim(), "Examenes_Consulta a, Examenes_Laboratorio b, Paciente c, Consulta_Paciente d");//"Select * from Consulta_Paciente where num_expediente = " + NumExpediente.Trim(), "Consulta_Paciente");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        nombreExamen = "";
                        nombreExamen = dr[6].ToString().Trim();

                        if (!oArregloExamenes.Contains(nombreExamen.Trim()))
                        {
                            auxIndexFila = -1;

                            oArregloExamenes.Add(nombreExamen.Trim());

                            softNetExamOrganizer1.Rows.Add();
                            softNetExamOrganizer1.Rows[indexFila].Cells[0].Value = nombreExamen.Trim();
                            softNetExamOrganizer1.Rows[indexFila].Cells[0].Tag = dr[0].ToString().Trim();
                        }
                        else
                            auxIndexFila = oArregloExamenes.IndexOf(nombreExamen.Trim()) + 1;

                        fechaResultado = dtFechaResultados.MinDate;
                        fechaResultado = Convert.ToDateTime(dr[7]).Date;
                        DateTime auxFechaResultado = Convert.ToDateTime(dr[7]);

                        if (!oArregloFechasResultados.Contains(fechaResultado.Date))
                        {
                            auxIndexColumna = -1;

                            DataGridViewColumn oColumn = new DataGridViewColumn();
                            DataGridViewCell oCell = new DataGridViewTextBoxCell();

                            oColumn.Name = "BaseColumn";
                            oColumn.CellTemplate = oCell;
                            oColumn.HeaderText = auxFechaResultado.ToLongDateString() + " a las " + auxFechaResultado.ToLongTimeString();//fechaResultado.Date.ToShortDateString();
                            oColumn.Visible = true;
                            oColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                            softNetExamOrganizer1.Columns.Add(oColumn);

                            oArregloFechasResultados.Add(fechaResultado.Date);
                            softNetExamOrganizer1.Rows[0].Cells[indexColumna].Value = fechaResultado.Date.ToShortDateString();

                            if (auxIndexFila == -1)
                            {
                                if (dr[5].ToString().Trim() != "")
                                {
                                    var val = dr[5].ToString().Trim();
                                    var tooltip = dr[5].ToString().Trim();

                                    if (val.Length > 150)
                                    {
                                        val = val.Substring(0, 150) + "...";
                                    }

                                    val = val.Replace("+", " con ");
                                    tooltip = tooltip.Replace("+", " con ");// presenta un error a la hora de presentar los datos en la celda o tooltip si el texto contiene  "+"

                                    softNetExamOrganizer1.Rows[indexFila].Cells[indexColumna].Tag = dr[5].ToString().Trim();
                                    softNetExamOrganizer1.Rows[indexFila].Cells[indexColumna].Value = val;
                                    softNetExamOrganizer1.Rows[indexFila].Cells[indexColumna].ToolTipText = tooltip;
                                }
                                else
                                {
                                    softNetExamOrganizer1.Rows[indexFila].Cells[indexColumna].Style.Font = new Font("Arial", 46, FontStyle.Bold);
                                    softNetExamOrganizer1.Rows[indexFila].Cells[indexColumna].Style.ForeColor = Color.Red;
                                    softNetExamOrganizer1.Rows[indexFila].Cells[indexColumna].Value = "-";
                                }

                                softNetExamOrganizer1.Rows[indexFila].Cells[indexColumna].Tag = dr[1].ToString().Trim() + "$" +
                                                                                                dr[2].ToString().Trim() + "$" +
                                                                                                dr[3].ToString().Trim() + "$" +
                                                                                                dr[4].ToString().Trim() + "$" +
                                                                                                dr[5].ToString().Trim() + "$" +
                                                                                                dr[7].ToString().Trim();

                                indexFila++;
                            }
                            else
                            {
                                if (dr[5].ToString().Trim() != "")
                                {
                                    var val = dr[5].ToString().Trim();

                                    if (val.Length > 150)
                                    {
                                        val = val.Substring(0, 150) + "...";
                                    }

                                    softNetExamOrganizer1.Rows[auxIndexFila].Cells[indexColumna].Value = val;
                                    softNetExamOrganizer1.Rows[auxIndexFila].Cells[indexColumna].ToolTipText = dr[5].ToString().Trim();
                                }
                                else
                                {
                                    softNetExamOrganizer1.Rows[auxIndexFila].Cells[indexColumna].Style.Font = new Font("Arial", 46, FontStyle.Bold);
                                    softNetExamOrganizer1.Rows[auxIndexFila].Cells[indexColumna].Style.ForeColor = Color.Red;
                                    softNetExamOrganizer1.Rows[auxIndexFila].Cells[indexColumna].Value = "-";
                                }

                                softNetExamOrganizer1.Rows[auxIndexFila].Cells[indexColumna].Tag = dr[1].ToString().Trim() + "$" +
                                                                                                   dr[2].ToString().Trim() + "$" +
                                                                                                   dr[3].ToString().Trim() + "$" +
                                                                                                   dr[4].ToString().Trim() + "$" +
                                                                                                   dr[5].ToString().Trim() + "$" +
                                                                                                   dr[7].ToString().Trim();
                            }
                            indexColumna++;
                        }
                        else
                        {
                            auxIndexColumna = oArregloFechasResultados.IndexOf(fechaResultado.Date) + 1;

                            if (auxIndexFila == -1)
                            {
                                if (dr[5].ToString().Trim() != "")
                                {
                                    var val = dr[5].ToString().Trim();

                                    if (val.Length > 150)
                                    {
                                        val = val.Substring(0, 150) + "...";
                                    }

                                    softNetExamOrganizer1.Rows[indexFila].Cells[auxIndexColumna].Value = val;
                                    softNetExamOrganizer1.Rows[indexFila].Cells[auxIndexColumna].ToolTipText = dr[5].ToString().Trim();
                                }
                                else
                                {
                                    softNetExamOrganizer1.Rows[indexFila].Cells[auxIndexColumna].Style.Font = new Font("Arial", 46, FontStyle.Bold);
                                    softNetExamOrganizer1.Rows[indexFila].Cells[auxIndexColumna].Style.ForeColor = Color.Red;
                                    softNetExamOrganizer1.Rows[indexFila].Cells[auxIndexColumna].Value = "-";
                                }

                                softNetExamOrganizer1.Rows[indexFila].Cells[auxIndexColumna].Tag = dr[1].ToString().Trim() + "$" +
                                                                                                   dr[2].ToString().Trim() + "$" +
                                                                                                   dr[3].ToString().Trim() + "$" +
                                                                                                   dr[4].ToString().Trim() + "$" +
                                                                                                   dr[5].ToString().Trim() + "$" +
                                                                                                   dr[7].ToString().Trim();

                                indexFila++;
                            }
                            else
                            {
                                if (dr[5].ToString().Trim() != "")
                                {
                                    var val = dr[5].ToString().Trim();

                                    if (val.Length > 150)
                                    {
                                        val = val.Substring(0, 150) + "...";
                                    }

                                    softNetExamOrganizer1.Rows[auxIndexFila].Cells[auxIndexColumna].Value = val;
                                    softNetExamOrganizer1.Rows[auxIndexFila].Cells[auxIndexColumna].ToolTipText = dr[5].ToString().Trim();
                                }
                                else
                                {
                                    softNetExamOrganizer1.Rows[auxIndexFila].Cells[auxIndexColumna].Style.Font = new Font("Arial", 46, FontStyle.Bold);
                                    softNetExamOrganizer1.Rows[auxIndexFila].Cells[auxIndexColumna].Style.ForeColor = Color.Red;
                                    softNetExamOrganizer1.Rows[auxIndexFila].Cells[auxIndexColumna].Value = "-";
                                }

                                softNetExamOrganizer1.Rows[auxIndexFila].Cells[auxIndexColumna].Tag = dr[1].ToString().Trim() + "$" +
                                                                                                      dr[2].ToString().Trim() + "$" +
                                                                                                      dr[3].ToString().Trim() + "$" +
                                                                                                      dr[4].ToString().Trim() + "$" +
                                                                                                      dr[5].ToString().Trim() + "$" +
                                                                                                      dr[7].ToString().Trim();
                            }
                        }
                    }
                    ds.Dispose();
                }
            }
        }

        private void AgregaFilaInicialGabinete()
        {
            softNetExamOrganizer2.Columns.Clear();
            softNetExamOrganizer2.Rows.Clear();

            DataGridViewColumn oColumn = new DataGridViewColumn();
            DataGridViewCell oCell = new DataGridViewTextBoxCell();

            oColumn.Name = "BaseColumn";
            oColumn.CellTemplate = oCell;
            oColumn.HeaderText = "Base Column";
            oColumn.Frozen = true;
            oColumn.Visible = true;
            oColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            softNetExamOrganizer2.Columns.Add(oColumn);
            softNetExamOrganizer2.Rows.Add();
        }

        private void AgregarGabinetesAGrid()
        {
            #region Limpia Arreglos

            oArregloIdGabinetes.Clear();
            oArregloGabinetes.Clear();
            oArregloFechasResultadosGabinete.Clear();
            oArregloDetalleAdicionalGabinete.Clear();

            #endregion

            AgregaFilaInicialGabinete();

            int indexFila = 1;
            int auxIndexFila = 0;
            int indexColumna = 1;
            int auxIndexColumna = -1;

            string nombreGabinete = "";
            DateTime fechaResultado = new DateTime();

            StringBuilder oSql = new StringBuilder();
            oSql.Append("Select a.*, b.nombre, d.fecha_consulta, detalle_resultados ");
            oSql.Append("from Gabinete_Consulta a, Gabinete b, Paciente c, Consulta_Paciente d ");
            oSql.Append("where a.id_gabinete = b.id_gabinete and a.id_consulta = d.id_consulta and d.num_expediente = c.num_expediente ");
            oSql.Append("and c.num_expediente = " + numExpediente.Trim() + " order by d.fecha_consulta");

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(oSql.ToString().Trim(), "Gabinete_Consulta a, Gabinete b, Paciente c, Consulta_Paciente d");//"Select * from Consulta_Paciente where num_expediente = " + NumExpediente.Trim(), "Consulta_Paciente");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        nombreGabinete = "";
                        nombreGabinete = dr[6].ToString().Trim();

                        if (!oArregloGabinetes.Contains(nombreGabinete.Trim()))
                        {
                            auxIndexFila = -1;

                            oArregloGabinetes.Add(nombreGabinete.Trim());

                            softNetExamOrganizer2.Rows.Add();
                            softNetExamOrganizer2.Rows[indexFila].Cells[0].Value = nombreGabinete.Trim();
                            softNetExamOrganizer2.Rows[indexFila].Cells[0].Tag = dr[0].ToString().Trim();
                        }
                        else
                            auxIndexFila = oArregloGabinetes.IndexOf(nombreGabinete.Trim()) + 1;

                        fechaResultado = dtFechaResultados.MinDate;
                        fechaResultado = Convert.ToDateTime(dr[7]).Date;
                        DateTime auxFechaResultado = Convert.ToDateTime(dr[7]);

                        if (!oArregloFechasResultadosGabinete.Contains(fechaResultado.Date))
                        {
                            auxIndexColumna = -1;

                            DataGridViewColumn oColumn = new DataGridViewColumn();
                            DataGridViewCell oCell = new DataGridViewTextBoxCell();

                            oColumn.Name = "BaseColumn";
                            oColumn.CellTemplate = oCell;
                            oColumn.HeaderText = auxFechaResultado.ToLongDateString() + " a las " + auxFechaResultado.ToLongTimeString();//fechaResultado.Date.ToShortDateString();
                            oColumn.Visible = true;
                            oColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                            softNetExamOrganizer2.Columns.Add(oColumn);

                            oArregloFechasResultadosGabinete.Add(fechaResultado.Date);
                            softNetExamOrganizer2.Rows[0].Cells[indexColumna].Value = fechaResultado.Date.ToShortDateString();

                            if (auxIndexFila == -1)
                            {
                                if (dr[5].ToString().Trim() != "")
                                {
                                    var val = dr[5].ToString().Trim();
                                    var tooltip = dr[5].ToString().Trim();

                                    if (val.Length > 150)
                                    {
                                        val = val.Substring(0, 150) + "...";
                                    }

                                    val = val.Replace("+", " con ");
                                    tooltip = tooltip.Replace("+", " con ");// presenta un error a la hora de presentar los datos en la celda o tooltip si el texto contiene  "+"

                                    softNetExamOrganizer2.Rows[indexFila].Cells[indexColumna].Tag = dr[5].ToString().Trim();
                                    softNetExamOrganizer2.Rows[indexFila].Cells[indexColumna].Value = val;
                                    softNetExamOrganizer2.Rows[indexFila].Cells[indexColumna].ToolTipText = tooltip;
                                }                                
                                else
                                {
                                    softNetExamOrganizer2.Rows[indexFila].Cells[indexColumna].Style.Font = new Font("Arial", 46, FontStyle.Bold);
                                    softNetExamOrganizer2.Rows[indexFila].Cells[indexColumna].Style.ForeColor = Color.Red;
                                    softNetExamOrganizer2.Rows[indexFila].Cells[indexColumna].Value = "-";
                                }

                                softNetExamOrganizer2.Rows[indexFila].Cells[indexColumna].Tag = dr[1].ToString().Trim() + "$" +
                                                                                                dr[2].ToString().Trim() + "$" +
                                                                                                dr[3].ToString().Trim() + "$" +
                                                                                                dr[4].ToString().Trim() + "$" +
                                                                                                dr[5].ToString().Trim() + "$" +
                                                                                                dr[7].ToString().Trim();

                                indexFila++;
                            }
                            else
                            {
                                if (dr[5].ToString().Trim() != "")
                                {
                                    var val = dr[5].ToString().Trim();

                                    if (val.Length > 150)
                                    {
                                        val = val.Substring(0, 150) + "...";
                                    }

                                    softNetExamOrganizer2.Rows[auxIndexFila].Cells[indexColumna].Value = val;
                                    softNetExamOrganizer2.Rows[auxIndexFila].Cells[indexColumna].ToolTipText = dr[5].ToString().Trim();
                                }
                                else
                                {
                                    softNetExamOrganizer2.Rows[auxIndexFila].Cells[indexColumna].Style.Font = new Font("Arial", 46, FontStyle.Bold);
                                    softNetExamOrganizer2.Rows[auxIndexFila].Cells[indexColumna].Style.ForeColor = Color.Red;
                                    softNetExamOrganizer2.Rows[auxIndexFila].Cells[indexColumna].Value = "-";
                                }

                                softNetExamOrganizer2.Rows[auxIndexFila].Cells[indexColumna].Tag = dr[1].ToString().Trim() + "$" +
                                                                                                   dr[2].ToString().Trim() + "$" +
                                                                                                   dr[3].ToString().Trim() + "$" +
                                                                                                   dr[4].ToString().Trim() + "$" +
                                                                                                   dr[5].ToString().Trim() + "$" +
                                                                                                   dr[7].ToString().Trim();
                            }
                            indexColumna++;
                        }
                        else
                        {
                            auxIndexColumna = oArregloFechasResultadosGabinete.IndexOf(fechaResultado.Date) + 1;

                            if (auxIndexFila == -1)
                            {
                                if (dr[5].ToString().Trim() != "")
                                {
                                    var val = dr[5].ToString().Trim();

                                    if (val.Length > 150)
                                    {
                                        val = val.Substring(0, 150) + "...";
                                    }

                                    softNetExamOrganizer2.Rows[indexFila].Cells[auxIndexColumna].Value = val;
                                    softNetExamOrganizer2.Rows[indexFila].Cells[auxIndexColumna].ToolTipText = dr[5].ToString().Trim();
                                }
                                else
                                {
                                    softNetExamOrganizer2.Rows[indexFila].Cells[auxIndexColumna].Style.Font = new Font("Arial", 46, FontStyle.Bold);
                                    softNetExamOrganizer2.Rows[indexFila].Cells[auxIndexColumna].Style.ForeColor = Color.Red;
                                    softNetExamOrganizer2.Rows[indexFila].Cells[auxIndexColumna].Value = "-";
                                }

                                softNetExamOrganizer2.Rows[indexFila].Cells[auxIndexColumna].Tag = dr[1].ToString().Trim() + "$" +
                                                                                                   dr[2].ToString().Trim() + "$" +
                                                                                                   dr[3].ToString().Trim() + "$" +
                                                                                                   dr[4].ToString().Trim() + "$" +
                                                                                                   dr[5].ToString().Trim() + "$" +
                                                                                                   dr[7].ToString().Trim();

                                indexFila++;
                            }
                            else
                            {
                                if (dr[5].ToString().Trim() != "")
                                {
                                    var val = dr[5].ToString().Trim();

                                    if (val.Length > 150)
                                    {
                                        val = val.Substring(0, 150) + "...";
                                    }

                                    softNetExamOrganizer2.Rows[auxIndexFila].Cells[auxIndexColumna].Value = val;
                                    softNetExamOrganizer2.Rows[auxIndexFila].Cells[auxIndexColumna].ToolTipText = dr[5].ToString().Trim();
                                }
                                else
                                {
                                    softNetExamOrganizer2.Rows[auxIndexFila].Cells[auxIndexColumna].Style.Font = new Font("Arial", 46, FontStyle.Bold);
                                    softNetExamOrganizer2.Rows[auxIndexFila].Cells[auxIndexColumna].Style.ForeColor = Color.Red;
                                    softNetExamOrganizer2.Rows[auxIndexFila].Cells[auxIndexColumna].Value = "-";
                                }

                                softNetExamOrganizer2.Rows[auxIndexFila].Cells[auxIndexColumna].Tag = dr[1].ToString().Trim() + "$" +
                                                                                                      dr[2].ToString().Trim() + "$" +
                                                                                                      dr[3].ToString().Trim() + "$" +
                                                                                                      dr[4].ToString().Trim() + "$" +
                                                                                                      dr[5].ToString().Trim() + "$" +
                                                                                                      dr[7].ToString().Trim();
                            }
                        }
                    }
                    ds.Dispose();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiaCampos()
        {
            txtNombreExamen.Text = String.Empty;
            dtFechaResultados.Value = dtFechaResultados.MinDate;
            txtDetalleResultados.Text = String.Empty;
            txtDetalleExamen.Text = "¡No se estableció un detalle adicional para este examen!";
            lblFechaPrescripcion.Text = "";
            panel2.BackgroundImage = null;
            lblNoDisponible.Visible = true;
        }

        /// <summary>
        /// id_consulta, detalle_adicional, estado
        /// </summary>
        /// <param name="pTag"></param>
        private void ObtieneDatosTag(string pTag)
        {
            oArregloTempTag.Clear();

            string[] ocadenaTemp = null;
            char[] caracterBuscado = { '$' };

            ocadenaTemp = pTag.Split(caracterBuscado);

            if (ocadenaTemp.Length > 0)
            {
                oArregloTempTag.Add(ocadenaTemp[0].Trim());//Id Consulta
                oArregloTempTag.Add(ocadenaTemp[1].Trim());//Detalle Adicional
                oArregloTempTag.Add(ocadenaTemp[2].Trim());//Estado
                oArregloTempTag.Add(ocadenaTemp[3].Trim());//Fecha Resultados
                oArregloTempTag.Add(ocadenaTemp[4].Trim());//Detalle Resultados
                oArregloTempTag.Add(ocadenaTemp[5].Trim());//Fecha Prescripción
            }
        }

        private void softNetExamOrganizer1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LimpiaCampos();

                if (softNetExamOrganizer1.CurrentRow.Cells[e.ColumnIndex].Tag != null)
                {
                    ObtieneDatosTag(softNetExamOrganizer1.CurrentRow.Cells[e.ColumnIndex].Tag.ToString().Trim());

                    txtNombreExamen.Text = this.softNetExamOrganizer1.CurrentCell.OwningRow.Cells[0].Value.ToString().Trim();
                    lblFechaPrescripcion.Text = Convert.ToDateTime(oArregloTempTag[5]).ToLongDateString();//this.softNetExamOrganizer1.CurrentCell.OwningColumn.HeaderText.Trim();

                    txtDetalleResultados.Text = oArregloTempTag[4].ToString().Trim();
                    txtDetalleExamen.Text = oArregloTempTag[1].ToString().Trim();

                    dtFechaResultados.Value = Convert.ToDateTime(oArregloTempTag[3]);

                    if (dtFechaResultados.Value.Date == dtFechaResultados.MinDate.Date)
                        lblNoDisponible.Visible = true;
                    else
                        lblNoDisponible.Visible = false;

                    if (Convert.ToBoolean(oArregloTempTag[2]) == true)
                        panel2.BackgroundImage = Properties.Resources.Check_2_210;
                    else
                        panel2.BackgroundImage = null;
                }
            }
            catch { }
        }

        private void softNetExamOrganizer2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LimpiaCampos();

                if (softNetExamOrganizer2.CurrentRow.Cells[e.ColumnIndex].Tag != null)
                {
                    ObtieneDatosTag(softNetExamOrganizer2.CurrentRow.Cells[e.ColumnIndex].Tag.ToString().Trim());

                    txtNombreExamen.Text = this.softNetExamOrganizer2.CurrentCell.OwningRow.Cells[0].Value.ToString().Trim();
                    lblFechaPrescripcion.Text = Convert.ToDateTime(oArregloTempTag[5]).ToLongDateString();//this.softNetExamOrganizer1.CurrentCell.OwningColumn.HeaderText.Trim();

                    txtDetalleResultados.Text = oArregloTempTag[4].ToString().Trim();
                    txtDetalleExamen.Text = oArregloTempTag[1].ToString().Trim();

                    dtFechaResultados.Value = Convert.ToDateTime(oArregloTempTag[3]);

                    if (dtFechaResultados.Value.Date == dtFechaResultados.MinDate.Date)
                        lblNoDisponible.Visible = true;
                    else
                        lblNoDisponible.Visible = false;

                    if (Convert.ToBoolean(oArregloTempTag[2]) == true)
                        panel2.BackgroundImage = Properties.Resources.Check_2_210;
                    else
                        panel2.BackgroundImage = null;
                }
            }
            catch { }
        }

        private void tobModificar_Click(object sender, EventArgs e)
        {
            dtFechaResultados.Enabled = true;
            txtDetalleResultados.Enabled = true;

            tobModificar.Enabled = false;
            tobGuardar.Enabled = true;
            tobCancelar.Enabled = true;
            tobEliminar.Enabled = false;

            lblNoDisponible.Visible = false;
        }

        private void tobGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    if (txtDetalleResultados.Text.Trim() == "")
                    {
                        MessageBox.Show(this, "Debe de especificar el valor correspondiente al resultado del gabinete, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDetalleResultados.Focus();
                        return;
                    }

                    oCGabineteConsulta.IdConsulta = oArregloTempTag[0].ToString().Trim();
                    oCGabineteConsulta.IdGabinete = softNetExamOrganizer2.CurrentRow.Cells[0].Tag.ToString().Trim();

                    oCGabineteConsulta.Estado = "1";
                    oCGabineteConsulta.FechaResultados = dtFechaResultados.Value.Date;
                    oCGabineteConsulta.DetalleResultados = txtDetalleResultados.Text.Trim();

                    oCGabineteConsulta.Modificar();

                    if (Program.oPersistencia.IsError == false)
                    {
                        tobCancelar_Click(sender, e);
                        AgregarGabinetesAGrid();
                    }
                }
                else
                {
                    if (txtDetalleResultados.Text.Trim() == "")
                    {
                        MessageBox.Show(this, "Debe de especificar el valor correspondiente al resultado del examen, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDetalleResultados.Focus();
                        return;
                    }

                    oCExamenesConsulta.IdConsulta = oArregloTempTag[0].ToString().Trim();
                    oCExamenesConsulta.IdExamen = softNetExamOrganizer1.CurrentRow.Cells[0].Tag.ToString().Trim();

                    oCExamenesConsulta.Estado = "1";
                    oCExamenesConsulta.FechaResultados = dtFechaResultados.Value.Date;
                    oCExamenesConsulta.DetalleResultados = txtDetalleResultados.Text.Trim();

                    oCExamenesConsulta.Modificar();

                    if (Program.oPersistencia.IsError == false)
                    {
                        tobCancelar_Click(sender, e);
                        AgregarExamenesAGrid();
                    }
                }
            }
            catch { }
        }

        private void tobCancelar_Click(object sender, EventArgs e)
        {
            tobModificar.Enabled = true;
            tobGuardar.Enabled = false;
            tobCancelar.Enabled = false;
            tobEliminar.Enabled = true;

            LimpiaCampos();

            dtFechaResultados.Enabled = false;
            txtDetalleResultados.Enabled = false;
        }

        private void tobEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Está completamente seguro que desea eliminar este resultado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    if (tabControl1.SelectedIndex == 0)
                    {
                        oCGabineteConsulta.IdConsulta = oArregloTempTag[0].ToString().Trim();
                        oCGabineteConsulta.IdGabinete = softNetExamOrganizer2.CurrentRow.Cells[0].Tag.ToString().Trim();

                        oCGabineteConsulta.Estado = "0";
                        oCGabineteConsulta.FechaResultados = dtFechaResultados.MinDate.Date;
                        oCGabineteConsulta.DetalleResultados = "";

                        oCGabineteConsulta.Modificar();

                        if (Program.oPersistencia.IsError == false)
                        {
                            tobCancelar_Click(sender, e);
                            AgregarGabinetesAGrid();
                        }
                    }
                    else
                    {
                        oCExamenesConsulta.IdConsulta = oArregloTempTag[0].ToString().Trim();
                        oCExamenesConsulta.IdExamen = softNetExamOrganizer1.CurrentRow.Cells[0].Tag.ToString().Trim();

                        oCExamenesConsulta.Estado = "0";
                        oCExamenesConsulta.FechaResultados = dtFechaResultados.MinDate.Date;
                        oCExamenesConsulta.DetalleResultados = "";

                        oCExamenesConsulta.Modificar();

                        if (Program.oPersistencia.IsError == false)
                        {
                            tobCancelar_Click(sender, e);
                            AgregarExamenesAGrid();
                        }
                    }
                }
                catch { }
            }

            //if (MessageBox.Show(this, "¿Está completamente seguro que desea eliminar los resultados de este examen?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        oCExamenesConsulta.IdConsulta = oArregloTempTag[0].ToString().Trim();
            //        oCExamenesConsulta.IdExamen = softNetExamOrganizer1.CurrentRow.Cells[0].Tag.ToString().Trim();

            //        oCExamenesConsulta.Estado = "0";
            //        oCExamenesConsulta.FechaResultados = dtFechaResultados.MinDate.Date;
            //        oCExamenesConsulta.DetalleResultados = "";

            //        oCExamenesConsulta.Modificar();

            //        if (Program.oPersistencia.IsError == false)
            //        {
            //            tobCancelar_Click(sender, e);
            //            AgregarExamenesAGrid();
            //        }
            //    }
            //    catch { }
            //}
        }

        private void frmExamenesConsulta_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Hide();

            if (Program.oFrmDetallePaciente != null && Program.oFrmImagenesConsultas != null && Program.oFrmHistorialConsultas != null &&
                Program.oFrmVideosConsulta != null && Program.oFrmEmbarazos != null)
            {
                if (Program.oFrmDetallePaciente.Activo == false && Program.oFrmImagenesConsultas.Activo == false && 
                    Program.oFrmHistorialConsultas.Activo == false && Program.oFrmVideosConsulta.Activo == false && 
                    Program.oFrmEmbarazos.Activo == false)
                {
                    EventArgs e2 = new EventArgs();
                    Program.oFrmDock.frmDock_MouseLeave(sender, e2);
                }
            }
        }

        private void frmExamenesConsulta_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                activo = true;

                //if (numExpediente.Trim() != "")
                //    AgregarExamenesAGrid();
            }
            else
            {
                activo = false;
                Program.oMDI.Activate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (Program.oFrmDetallePaciente != null && Program.oFrmImagenesConsultas != null && Program.oFrmVideosConsulta != null && Program.oFrmHistorialConsultas != null)
            {
                if (Program.oFrmDetallePaciente.Activo == false && Program.oFrmImagenesConsultas.Activo == false && Program.oFrmVideosConsulta.Activo == false && Program.oFrmHistorialConsultas.Activo == false)
                {
                    EventArgs e2 = new EventArgs();
                    Program.oFrmDock.frmDock_MouseLeave(sender, e2);
                }
            }
        }

        private void tobGuardarDetAdicExam_Click(object sender, EventArgs e)
        {
            oCPacientes.DetallesAdicExamenes = txtDetAdicionalExamenes.Text.Trim();
            oCPacientes.NumExpediente = Convert.ToInt32(lblNumExpediente.Text);

            oCPacientes.Modificar_DatosPaciente_DetalleExamenes();
        }

    }
}