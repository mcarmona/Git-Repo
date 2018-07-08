using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Miscelaneos_y_Recursos;
using System.Collections;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmEmbarazos : Form
    {
        public frmEmbarazos()
        {
            InitializeComponent();

            this.Region = Shape.RoundedRegion(this.Size, 8, Shape.Corner.None);

            this.Left = ((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2);

            int top = 0;
            top = Screen.PrimaryScreen.WorkingArea.Height - this.Height - Program.oMDI.statusStrip1.Height - Program.oFrmDock.Height + 3;

            if (top < 0)
                top = 0;

            this.Top = top;

            this.softNetExamOrganizer1.Region = Shape.RoundedRegion(this.softNetExamOrganizer1.Size, 7, Shape.Corner.None);
        }

        bool activo = false;
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        string numExpediente = "";
        public string NumExpediente
        {
            get { return numExpediente; }
            set { numExpediente = value; }
        }

        ImagenCambianteLabel oImagenCambianteLabel = null;

        /// <summary>
        /// Método que agrega la fila y Columna iniciales, que pasarán a ser las cabeceras de las filas y columnas del grid
        /// </summary>
        private void AgregaFilaInicial_EncabezadosDatos()
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

            softNetExamOrganizer1.Rows.Add();
            softNetExamOrganizer1.Rows[1].Cells[0].Value = "Semanas de" + Environment.NewLine + "Amenorrea";

            softNetExamOrganizer1.Rows.Add();
            softNetExamOrganizer1.Rows[2].Cells[0].Value = "Peso";

            softNetExamOrganizer1.Rows.Add();
            softNetExamOrganizer1.Rows[3].Cells[0].Value = "I.M.C";

            softNetExamOrganizer1.Rows.Add();
            softNetExamOrganizer1.Rows[4].Cells[0].Value = "Presión Arterial";

            softNetExamOrganizer1.Rows.Add();
            softNetExamOrganizer1.Rows[5].Cells[0].Value = "Frecuencia Cardiaca" + Environment.NewLine + "Fetal";

            softNetExamOrganizer1.Rows.Add();
            softNetExamOrganizer1.Rows[6].Cells[0].Value = "Altura Uterina";

            softNetExamOrganizer1.Rows.Add();
            softNetExamOrganizer1.Rows[7].Cells[0].Value = "Movimiento Fetal";

            softNetExamOrganizer1.Rows.Add();
            softNetExamOrganizer1.Rows[8].Cells[0].Value = "Ultrasonido";
        }

        public void LlenarCarpetas()
        {
            pBoxEstado.Visible = false;

            softNetExamOrganizer1.Columns.Clear();
            softNetExamOrganizer1.Rows.Clear();

            AgregaFilaInicial_EncabezadosDatos();

            string tagEmbarazo = "";
            ArrayList oArregloEncontrados = new ArrayList();

            DateTime oFechaInicial = new DateTime();
            DateTime oFechaFinal = new DateTime();

            flowLayoutPanel1.Controls.Clear();

            string folderName = "";

            string sql = "Select distinct(a.id_consulta), a.fecha_consulta, b.fecha_inicial_embarazo, b.estado_embarazo from Consulta_Paciente a, Consultas_Con_Embarazo b " +
                         "Where a.id_consulta = b.id_consulta and a.num_expediente = " + numExpediente.Trim() +
                //" and (b.estado_embarazo = 'Inicializado' or b.estado_embarazo = 'Activo') Order by a.fecha_consulta";//" group by a.id_consulta, a.fecha_consulta";
                         " Order by a.id_consulta";//a.fecha_consulta";//" group by a.id_consulta, a.fecha_consulta";

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(sql.Trim(), "Consulta_Paciente");

            int cont = 0;
            oFechaInicial = DateTime.MinValue;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[3].ToString().Trim() == "Inicializado")
                {
                    tagEmbarazo = dr[0].ToString().Trim() + "-";
                    oFechaInicial = Convert.ToDateTime(dr[2]);
                }
                else
                    tagEmbarazo += dr[0].ToString() + "-";

                if (dr[3].ToString().Trim() == "Finalizado" || cont == (ds.Tables[0].Rows.Count - 1))
                {
                    if (dr[3].ToString().Trim() == "Finalizado")
                    {
                        oFechaFinal = Convert.ToDateTime(dr[1]);

                        if (oFechaInicial == DateTime.MinValue)
                            oFechaInicial = Convert.ToDateTime(dr[2]);

                        folderName = "Periodo de Embarazo del " + oFechaInicial.Date.ToShortDateString() + " al " + oFechaFinal.Date.ToShortDateString();
                        tagEmbarazo += "Finalizado-";
                    }
                    else
                    {
                        folderName = "Periodo de Embarazo del " + oFechaInicial.Date.ToShortDateString() + " a la actualidad.";
                        tagEmbarazo += "Activo-";
                    }

                    oFechaInicial = DateTime.MinValue;

                    oImagenCambianteLabel = new ImagenCambianteLabel();
                    oImagenCambianteLabel.AutoSize = false;
                    oImagenCambianteLabel.Size = new Size(100, 152);
                    oImagenCambianteLabel.Image = Properties.Resources.Pregnancy_Folder_90;
                    oImagenCambianteLabel.HighlightedImage = Properties.Resources.Pregnancy_Folder_90_highlighted;
                    oImagenCambianteLabel.Text = folderName;
                    oImagenCambianteLabel.ForeColor = Color.White;
                    oImagenCambianteLabel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    oImagenCambianteLabel.ImageAlign = ContentAlignment.TopCenter;
                    oImagenCambianteLabel.TextAlign = ContentAlignment.BottomCenter;
                    oImagenCambianteLabel.Tag = tagEmbarazo;

                    tagEmbarazo = "";

                    oImagenCambianteLabel.Click += new EventHandler(oImagenCambianteLabel_Click);

                    flowLayoutPanel1.Controls.Add(oImagenCambianteLabel);
                }
                cont++;
            }
            ds.Dispose();
        }

        private void MostrarDatosEmbarazo(string pTag)
        {
            pBoxEstado.Visible = true;
            softNetExamOrganizer1.Columns.Clear();
            softNetExamOrganizer1.Rows.Clear();

            AgregaFilaInicial_EncabezadosDatos();

            string consulta = "";
            int indexColumna = 1;

            char[] oChar = { '-' };
            string[] cadenaAux = pTag.Split(oChar, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cadenaAux.Length; i++)
            {
                if (cadenaAux[i].Trim() != "" && cadenaAux[i].Trim() != "Finalizado" && cadenaAux[i].Trim() != "Activo")
                {
                    consulta = "Select distinct(a.amenorrea), a.peso, a.imc, a.presion_arterial, b.frecuencia_cardiaca_fetal, b.altura_uterina, " +
                               "b.movimiento_fetal, b.ultrasonido, a.fecha_consulta from Consulta_Paciente a, Consultas_Con_Embarazo b " +
                               "Where a.id_consulta = b.id_consulta and a.id_consulta = " + cadenaAux[i].Trim();

                    DataSet ds = Program.oPersistencia.ejecutarSQLListas(consulta, "Consulta_Paciente a, Consultas_Con_Embarazo b");

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                DataGridViewColumn oColumn = new DataGridViewColumn();
                                DataGridViewCell oCell = new DataGridViewTextBoxCell();

                                oColumn.Name = "BaseColumn";
                                oColumn.CellTemplate = oCell;
                                oColumn.HeaderText = Convert.ToDateTime(dr[8]).ToShortDateString();
                                oColumn.Visible = true;
                                oColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                                softNetExamOrganizer1.Columns.Add(oColumn);

                                //Encabezado de Columna, Fecha de Consulta
                                softNetExamOrganizer1.Rows[0].Cells[indexColumna].Style.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                                softNetExamOrganizer1.Rows[0].Cells[indexColumna].Style.ForeColor = Color.Red;
                                softNetExamOrganizer1.Rows[0].Cells[indexColumna].Value = Convert.ToDateTime(dr[8]).ToShortDateString();

                                softNetExamOrganizer1.Rows[1].Cells[indexColumna].Value = dr[0].ToString().Trim();
                                softNetExamOrganizer1.Rows[2].Cells[indexColumna].Value = dr[1].ToString().Trim();
                                softNetExamOrganizer1.Rows[3].Cells[indexColumna].Value = dr[2].ToString().Trim();
                                softNetExamOrganizer1.Rows[4].Cells[indexColumna].Value = dr[3].ToString().Trim();
                                softNetExamOrganizer1.Rows[5].Cells[indexColumna].Value = dr[4].ToString().Trim();
                                softNetExamOrganizer1.Rows[6].Cells[indexColumna].Value = dr[5].ToString().Trim();

                                if (Convert.ToBoolean(dr[6]) == true)
                                    softNetExamOrganizer1.Rows[7].Cells[indexColumna].Value = "SÍ";
                                else
                                    softNetExamOrganizer1.Rows[7].Cells[indexColumna].Value = "NO";

                                softNetExamOrganizer1.Rows[8].Cells[indexColumna].Value = dr[7].ToString().Trim();

                                indexColumna++;
                            }
                        }
                    }
                    ds.Dispose();
                }
                else if (cadenaAux[i].Trim() == "Finalizado" || cadenaAux[i].Trim() == "Activo")
                {
                    if (cadenaAux[i].Trim() == "Finalizado")
                    {
                        pBoxEstado.Image = Properties.Resources.Pregnancy_Ok_135;
                        pBoxEstado.ImagenOriginal = Properties.Resources.Pregnancy_Ok_135;
                        pBoxEstado.HighlightedImage = Properties.Resources.Pregnancy_Ok_135_highlighted;
                        pBoxEstado.Tag = null;
                    }
                    else
                    {
                        int index = i - 1;
                        pBoxEstado.Image = Properties.Resources.Pregnancy_Active_135;
                        pBoxEstado.ImagenOriginal = Properties.Resources.Pregnancy_Active_135;
                        pBoxEstado.HighlightedImage = Properties.Resources.Pregnancy_Active_135_highlighted;

                        if (index < 0)
                            index = 0;

                        pBoxEstado.Tag = cadenaAux[index].ToString();                        
                    }
                }
            }
        }

        void oImagenCambianteLabel_Click(object sender, EventArgs e)
        {
            ImagenCambianteLabel oIMCL = (ImagenCambianteLabel)sender;
            MostrarDatosEmbarazo(oIMCL.Tag.ToString().Trim());
        }

        private void frmEmbarazos_Load(object sender, EventArgs e)
        {
            AgregaFilaInicial_EncabezadosDatos();
            LlenarCarpetas();
        }

        private void frmEmbarazos_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                activo = true;
            else
            {
                activo = false;
                Program.oMDI.Activate();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (Program.oFrmExamenesConsulta != null && Program.oFrmDetallePaciente != null && Program.oFrmImagenesConsultas != null &&
                Program.oFrmHistorialConsultas != null && Program.oFrmVideosConsulta != null)
            {
                if (Program.oFrmExamenesConsulta.Activo == false && Program.oFrmDetallePaciente.Activo == false &&
                    Program.oFrmImagenesConsultas.Activo == false && Program.oFrmHistorialConsultas.Activo == false &&
                    Program.oFrmVideosConsulta.Activo == false)
                {
                    EventArgs e2 = new EventArgs();
                    Program.oFrmDock.frmDock_MouseLeave(sender, e2);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnSalir_Click(sender, e);
        }

        private void pBoxEstado_Click(object sender, EventArgs e)
        {
            if (pBoxEstado.Tag != null)
            {
                if (!String.IsNullOrEmpty(pBoxEstado.Tag.ToString()))
                {
                    if (MessageBox.Show(this, "¿Está completamente seguro que desea finalizar el periodo de embarazo actualmente activo?. Éstas acciones no pueden ser reversadas.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string sql = "";                        
                        sql = "Update Consultas_Con_Embarazo SET estado_embarazo = 'Finalizado' WHERE id_consulta = " + pBoxEstado.Tag.ToString();
                        Program.oPersistencia.ejecutarSQL(sql);

                        if (Program.oPersistencia.IsError == true)
                            MessageBox.Show(this, "El periodo de embarazo no pudo ser finalizado. Por favor intente de nuevo o contacte a su proveedor para reportar esta falla técnica.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show(this, "¡Periodo de embarazo finalizado exitósamente! Se procederá a refrescar la información mostrada en esta pantalla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LlenarCarpetas();
                        }
                    }
                }
            }
            else
                MessageBox.Show(this, "El Periodo de embarazo ya sido finalizado previamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}