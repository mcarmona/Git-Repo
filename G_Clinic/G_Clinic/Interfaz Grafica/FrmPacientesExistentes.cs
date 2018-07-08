using System;
using System.Drawing;
using System.Windows.Forms;
using G_Clinic.Lógica_Negocios;
using G_Clinic.Miscelaneos_y_Recursos;
using System.IO;
using G_Clinic.Properties;
using System.Data;
using System.Data.SqlClient;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class FrmPacientesExistentes : Form
    {
        #region Variables e Instancias

        TextBox oNumExpediente;
        TextBox oPaciente;
        string sqlWhere = "";
        CPacientes oCPacientes = new CPacientes();

        #endregion

        #region Constructor

        public FrmPacientesExistentes(TextBox pNumExpediente, TextBox pPaciente)
        {
            InitializeComponent();
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.Mantenimiento);

            Grid1.AutoGenerateColumns = false;

            this.pictureBox1.Region = Shape.RoundedRegion(pictureBox1.Size, 3, Shape.Corner.None);
            oNumExpediente = pNumExpediente;
            oPaciente = pPaciente;
        }

        #endregion

        #region Procesos de Filtrado de Datos

        /// <summary>
        /// Establece la cadena que contendrá los parámetros por medio de los cuales se realizará la consulta del paciente correspondiente
        /// Dichos parámetros se establecen de acuerdo al tag que contengan los controles correspondientes
        /// </summary>
        /// <param name="oControl">Recibe el control del cual se extraerá el valor del "Tag" correspondiente y de esta forma
        /// se irá concatenando la cadena que contiene los parámetros para la sentencia</param>
        public void CadenaFiltrado(Control oControl)
        {
            if (String.IsNullOrEmpty(sqlWhere))
                sqlWhere += oControl.Tag.ToString().Trim() + ",";
            else
                sqlWhere += oControl.Tag.ToString().Trim() + ",";

            if (sqlWhere.Trim().CompareTo("Where") == 0)
            {
                sqlWhere = "";
            }
        }

        /// <summary>
        /// Establece los campos por los cuales se filtrará dependiendo si hay valores o no en los mismos
        /// </summary>
        public void Filtrar()
        {
            sqlWhere = "";

            if (TxtNumExpediente.Text.Trim() != "")
                CadenaFiltrado(TxtNumExpediente);

            if (RdExtranjero.Checked == true || RdNacional.Checked == true)
                CadenaFiltrado(RdExtranjero);

            if (TxtCedula.Text.Trim() != "")
                CadenaFiltrado(TxtCedula);

            if (TxtNombre.Text.Trim() != "")
                CadenaFiltrado(TxtNombre);

            if (txtApellidos.Text.Trim() != "")
                CadenaFiltrado(txtApellidos);

            if (TxtEdad.Text.Trim() != "" && TxtEdad.Text.Trim() != "0")
                CadenaFiltrado(DtFecha_Naci);
        }

        #endregion

        #region Eventos

        public DataTable CargarGrid(SqlDataReader oSqlDataReader)
        {
            // Declara datatable
            DataTable datatable = null;

            try
            {
                // Declara Datareader
                SqlDataReader dr = oSqlDataReader;

                //Si ocurrio un errro hacer la excepción
                if (!Program.oPersistencia.IsError)
                {
                    if (dr.HasRows == true)
                    {
                        // crear una nueva instancia del DataTable
                        datatable = new DataTable();

                        // llena el dataTable con la info del Datareader
                        datatable.Load(dr, LoadOption.Upsert);

                        //Cerrar el DataReader
                        dr.Close();
                        dr.Dispose();

                        //Cerrar el DataReader
                        dr = null;

                        return datatable;
                    }
                    else
                    {
                        dr.Dispose();
                        dr.Close();
                        dr = null;

                        return null;
                    }
                }
                else
                    return null;
            }
            catch { return null; }
            finally
            {
                if (datatable != null)
                    datatable.Dispose();
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            Filtrar();

            #region Establece valores en la clase de Pacientes

            if (TxtNumExpediente.Text.Trim() != "")
                oCPacientes.NumExpediente = Convert.ToInt32(TxtNumExpediente.Text.Trim());
            else
                oCPacientes.NumExpediente = 0;

            if (RdExtranjero.Checked == true || RdNacional.Checked == true)
            {
                if (RdNacional.Checked == true)
                    oCPacientes.TipoCedula = "0";
                else
                    oCPacientes.TipoCedula = "1";
            }
            else
                oCPacientes.TipoCedula = null;

            if (TxtCedula.Text.Trim() != "")
                oCPacientes.Cedula = TxtCedula.Text.Trim();
            else
                oCPacientes.Cedula = null;

            if (TxtNombre.Text.Trim() != "")
                oCPacientes.Nombre = TxtNombre.Text.Trim();
            else
                oCPacientes.Nombre = null;

            if (txtApellidos.Text.Trim() != "")
                oCPacientes.Apellidos = txtApellidos.Text.Trim();
            else
                oCPacientes.Apellidos = null;

            if (TxtEdad.Text.Trim() != "" && TxtEdad.Text.Trim() != "0")
                oCPacientes.FechaNacimiento = DtFecha_Naci.Value;
            else
                oCPacientes.FechaNacimiento = DateTime.MinValue;

            #endregion

            Grid1.DataSource = null;
            Metodos_Globales.LlenarGrid(Grid1, oCPacientes.ConsultarConParametros(sqlWhere));

            //Grid1.DataSource = oCPacientes.ConsultarV2(sqlWhere);

            if (Grid1.RowCount > 0)
            {
                DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, Grid1.Rows.GetFirstRow(DataGridViewElementStates.None));
                Grid1_CellEnter(sender, e2);
                Grid1.Focus();
            }
        }

        private void Grid1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Image newImage = null;

            try
            {
                if (Grid1.CurrentRow != null && Grid1.SelectedRows.Count > 0)
                {
                        TxtNumExpediente.Text = Grid1.SelectedRows[0].Cells["Num_Expediente"].Value.ToString();

                        if (Grid1.SelectedRows[0].Cells["TipoCed"].Value.ToString() == "0")
                        {
                            RdNacional.Checked = true;
                            TxtCedula.Text = Grid1.SelectedRows[0].Cells["Cedula"].Value.ToString();
                        }
                        else
                        {
                            RdExtranjero.Checked = true;
                            TxtCedula.Text = Grid1.SelectedRows[0].Cells["Cedula"].Value.ToString();
                        }

                        TxtNombre.Text = Grid1.SelectedRows[0].Cells["Nombre"].Value.ToString();
                        txtApellidos.Text = Grid1.SelectedRows[0].Cells["Apellidos"].Value.ToString();

                        DtFecha_Naci.Text = Grid1.SelectedRows[0].Cells["FecNac"].Value.ToString();

                        //Get image data from gridview column.
                        byte[] imageData = (byte[])Grid1.SelectedRows[0].Cells["Imagen"].Value;

                        try
                        {
                            //Read image data into a memory stream
                            using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                            {
                                ms.Write(imageData, 0, imageData.Length);

                                //Set image variable value using memory stream.
                                newImage = Image.FromStream(ms, true);
                            }

                            //set picture
                            if (newImage != null)
                            {
                                pictureBox1.BackgroundImage = newImage;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                            }
                        }
                        catch 
                        {
                            if (newImage == null)
                            {
                                pictureBox1.BackgroundImage = Resources.Person_Red;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }                    
                }
            }
            catch (Exception ex)
            {
                if (newImage == null)
                {
                    pictureBox1.BackgroundImage = Resources.Person_Red;
                    pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }
        }

        private void FrmPacientesExistentes_Load(object sender, EventArgs e)
        {
        }

        private void DtFecha_Naci_ValueChanged(object sender, EventArgs e)
        {
            DateTime Fecha_Actual = DateTime.Now; //se declara una variable de tipo datetime y se le da el valor de la fecha actual
            DateTime Fecha_Nac; //se declara otra variable que va a ser la indicada por el usuario
            int Edad = 0;

            if (DtFecha_Naci.Text != "")
            {
                Fecha_Nac = Convert.ToDateTime(DtFecha_Naci.Text);
                Edad = Fecha_Actual.Year - Fecha_Nac.Year;

                if (new DateTime(Fecha_Actual.Year, Fecha_Nac.Month, Fecha_Nac.Day) > Fecha_Actual)
                {
                    Edad--;
                }
                TxtEdad.Text = Edad.ToString();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RdNacional_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                RdExtranjero.Checked = true;
        }

        private void RdExtranjero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                RdNacional.Checked = true;
        }

        private void Grid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Grid1.CurrentRow != null)
                {
                    DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, Grid1.CurrentRow.Index);
                    Grid1_CellDoubleClick(sender, e2);
                }
            }
        }

        private void Grid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Grid1.SelectedRows.Count > 0)
            {
                if (Grid1.CurrentRow.Cells["Num_Expediente"].Value != null)
                {
                    oNumExpediente.Text = Grid1.CurrentRow.Cells["Num_Expediente"].Value.ToString();
                    oPaciente.Text = Grid1.CurrentRow.Cells["Nombre"].Value.ToString() + " " +
                                     Grid1.CurrentRow.Cells["Apellidos"].Value.ToString();

                    btnSalir_Click(sender, e);
                }
            }
        }

        #endregion

        #region Eventos Enter (Ayuda para el usuario)

        private void TxtNumExpediente_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Ingrese el N° de Expediente para incluir este parámetro en la búsqueda del paciente";
        }

        private void txtApellidos_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Ingrese el o los Apellidos para incluir este parámetro en la búsqueda del paciente";
        }

        private void TxtCedula_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Ingrese el N° de cédula para incluir este parámetro en la búsqueda del paciente";
        }

        private void RdNacional_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Seleccione esta opción para incluir este parámetro en la búsqueda del paciente";
        }

        private void RdExtranjero_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "seleccione esta opción para incluir este parámetro en la búsqueda del paciente";
        }

        private void TxtNombre_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Ingrese el Nombre para incluir este parámetro en la búsqueda del paciente";
        }

        private void DtFecha_Naci_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Seleccione la fecha de nacimiento para incluir este parámetro en la búsqueda del paciente";
        }

        private void Grid1_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Seleccione el nombre deseado de la lista disponible y presione la tecla \"Enter\"";
        }

        #endregion

        private void tobLimpiar_Click(object sender, EventArgs e)
        {
            Grid1.DataSource = null;

            txtApellidos.Text = String.Empty;
            TxtCedula.Text = String.Empty;
            TxtEdad.Text = String.Empty;
            TxtNombre.Text = String.Empty;
            TxtNumExpediente.Text = String.Empty;
            DtFecha_Naci.Value = DateTime.Today;
            pictureBox1.BackgroundImage = Resources.Person_Red;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;

            RdExtranjero.Checked = false;
            RdNacional.Checked = false;
        }

        private void tobNuevoPaciente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Ésta ventana se cerrará y se procederá a ingresar al Módulo de Historia Clínica para que proceda a ingresar un nuevo paciente, ¿realmente desea realizar dichas acciones?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Program.oMDI.historiaClínicaToolStripMenuItem_Click(sender, e);

                if (Program.oFrmHistoriaClinica != null)
                {
                    Program.oFrmHistoriaClinica.tobNuevo_Click(sender, e);

                    this.Close();

                    Program.oFrmHistoriaClinica.Activate();
                    Program.oFrmHistoriaClinica.TxtNombre.Focus();
                }
            }
        }

        private void btn10Ultimos_Click(object sender, EventArgs e)
        {
            tobLimpiar_Click(sender, e);

            string sql = "Select Top 10 * from Paciente Order By num_expediente Desc";  
            Metodos_Globales.LlenarGrid(Grid1, sql.Trim());

            if (Grid1.RowCount > 0)
            {
                DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, Grid1.Rows.GetFirstRow(DataGridViewElementStates.None));
                Grid1_CellEnter(sender, e2);
                Grid1.Focus();
            }
        }

        private void FrmPacientesExistentes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Grid1.DataSource = null;
        }
    }
}