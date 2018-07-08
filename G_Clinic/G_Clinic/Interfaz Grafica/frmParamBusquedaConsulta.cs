using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Properties;
using System.Collections;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmParamBusquedaConsulta : Form
    {
        public frmParamBusquedaConsulta()
        {
            InitializeComponent();
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.Mantenimiento);

            try
            {
                VistaConstants.SetWindowTheme(lstDiagnosticos.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstDiagnosticos.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
            }
            catch { }
        }

        string sqlWhere = "";
        public string SqlWhere
        {
            get { return sqlWhere; }
            set { sqlWhere = value; }
        }

        ArrayList oArregloDiagnosticos = new ArrayList();
        ArrayList oArregloChecked = new ArrayList();

        public bool buscarCondiagnosticos = false;

        private void CalcularPosicionBtnEjecutarConsulta()
        {
            btnEjecutarBusqueda.Left = (panel1.Location.X + panel1.Width);
            btnEjecutarBusqueda.Top = (panel1.Location.Y + panel1.Height) - btnEjecutarBusqueda.Height;
        }

        private void frmParamBusquedaConsulta_Load(object sender, EventArgs e)
        {
            this.MaximumSize = Program.oMDI.MaximumSize;
            this.Height = Program.oMDI.ClientSize.Height;
            this.Width = Program.oMDI.ClientSize.Width;
            this.SetDesktopBounds(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

            LlenarListaDiagnosticos("");
            CalcularPosicionBtnEjecutarConsulta();

            this.Opacity = Convert.ToDouble(0.93);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void CadenaFiltrado2(Control oControl)
        {
            if (oControl is TextBox)
            {
                if (oControl.Name != "TxtCedula" && oControl.Name != "TxtNombre" && oControl.Name != "txtApellidos")
                    sqlWhere += " and a." + oControl.Tag.ToString().Trim() + " = '" + oControl.Text.Trim() + "'";
                else
                    sqlWhere += " and b." + oControl.Tag.ToString().Trim() + " = '" + oControl.Text.Trim() + "'";
            }
            else if (oControl is RadioButton)
            {
                if (((RadioButton)(oControl)).Checked == true)
                {
                    if (oControl.Name == "RdNacional")
                        sqlWhere += " and b." + oControl.Tag.ToString().Trim() + " = 0";
                    else
                        sqlWhere += " and b." + oControl.Tag.ToString().Trim() + " = 1";
                }
            }
            else if (oControl is DateTimePicker)
            {
                if (oControl is DateTimePicker)
                {
                    if (oControl.Name == "dtFechaInicial")
                        sqlWhere += " and cast(convert(varchar, a.fecha_consulta ,112) as datetime) >= '" + ((DateTimePicker)(oControl)).Value.ToShortDateString() + "'";
                    else
                        sqlWhere += " and cast(convert(varchar, a.fecha_consulta ,112) as datetime) <= '" + ((DateTimePicker)(oControl)).Value.ToShortDateString() + "'";
                }
            }


            if (sqlWhere.Trim().CompareTo("Where") == 0)
                sqlWhere = "";
        }

        public void DiagnosticosPorConsulta()
        {
            sqlWhere = "Select distinct a.*, b.nombre, b.apellidos from Consulta_Paciente a, Paciente b, Diagnosticos_Consulta c " +
                       "where a.num_expediente = b.num_expediente and a.id_consulta = c.id_consulta";

            if (TxtIdConsulta.Text.Trim() != "")
                CadenaFiltrado2(TxtIdConsulta);

            if (TxtNumExpediente.Text.Trim() != "")
                CadenaFiltrado2(TxtNumExpediente);

            if (RdExtranjero.Checked == true || RdNacional.Checked == true)
                CadenaFiltrado2(RdExtranjero);

            if (TxtCedula.Text.Trim() != "")
                CadenaFiltrado2(TxtCedula);

            if (TxtNombre.Text.Trim() != "")
                CadenaFiltrado2(TxtNombre);

            if (txtApellidos.Text.Trim() != "")
                CadenaFiltrado2(txtApellidos);

            if (rdFechaExacta.Checked == true)
                CadenaFiltrado2(dtFechaCosnulta);

            if (rdIndicesFechas.Checked == true)
            {
                CadenaFiltrado2(dtFechaInicial);
                CadenaFiltrado2(dtFechaFinal);
            }

            if (lstDiagnosticos.CheckedItems.Count > 0)
            {
                sqlWhere += " and ";
                int cont = 0;
                foreach (ListViewItem oItem in lstDiagnosticos.CheckedItems)
                {
                    if (cont == 0)
                        sqlWhere += "c." + lstDiagnosticos.Tag.ToString() + " = " + oItem.Tag.ToString().Trim();
                    else
                        sqlWhere += " or c." + lstDiagnosticos.Tag.ToString() + " = " + oItem.Tag.ToString().Trim();

                    cont++;
                }

                //sqlWhere += " group by a.id_consulta";
            }
        }

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

            if (TxtIdConsulta.Text.Trim() != "")
                CadenaFiltrado(TxtIdConsulta);

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

            if (rdFechaExacta.Checked == true)
                CadenaFiltrado(dtFechaCosnulta);

            if (rdIndicesFechas.Checked == true)
            {
                CadenaFiltrado(dtFechaInicial);
                CadenaFiltrado(dtFechaFinal);
            }
        }

        public void btnBuscar_Click(object sender, EventArgs e)
        {
            if (lstDiagnosticos.CheckedItems.Count == 0)
            {
                buscarCondiagnosticos = false;

                Filtrar();

                if (sqlWhere.EndsWith(","))//El sqlWhere se establece en el método "CadenaFiltrado"
                    sqlWhere = sqlWhere.Substring(0, sqlWhere.Length - 1);

                if (TxtIdConsulta.Text.Trim() != "")
                    Program.oCConsultas.IdConsulta = Convert.ToInt64(TxtIdConsulta.Text.Trim());
                else
                    Program.oCConsultas.IdConsulta = 0;

                if (TxtNumExpediente.Text.Trim() != "")
                    Program.oCConsultas.NumExpediente = Convert.ToInt32(TxtNumExpediente.Text.Trim());
                else
                    Program.oCConsultas.NumExpediente = 0;

                if (RdExtranjero.Checked == true || RdNacional.Checked == true)
                {
                    if (RdNacional.Checked == true)
                        Program.oCConsultas.Tipo_ced = "0";
                    else
                        Program.oCConsultas.Tipo_ced = "1";
                }
                else
                    Program.oCConsultas.Tipo_ced = null;

                if (TxtCedula.Text.Trim() != "")
                    Program.oCConsultas.Cedula = TxtCedula.Text.Trim();
                else
                    Program.oCConsultas.Cedula = null;

                if (TxtNombre.Text.Trim() != "")
                    Program.oCConsultas.Nombre = TxtNombre.Text.Trim();
                else
                    Program.oCConsultas.Nombre = null;

                if (txtApellidos.Text.Trim() != "")
                    Program.oCConsultas.Apellidos = txtApellidos.Text.Trim();
                else
                    Program.oCConsultas.Apellidos = null;

                if (rdFechaExacta.Checked == true)
                    Program.oCConsultas.FechaConsulta = dtFechaCosnulta.Value.Date;
                else
                    Program.oCConsultas.FechaConsulta = DateTime.MinValue;

                if (rdIndicesFechas.Checked == true)
                {
                    Program.oCConsultas.FechaInicial = dtFechaInicial.Value.Date;
                    Program.oCConsultas.FechaFinal = dtFechaFinal.Value.Date;
                }
                else
                {
                    Program.oCConsultas.FechaInicial = DateTime.MinValue;
                    Program.oCConsultas.FechaFinal = DateTime.MinValue;
                }
            }
            else
            {
                buscarCondiagnosticos = true;
                DiagnosticosPorConsulta();
            }

            Program.oFrmConsultas.tobEjecutarConsulta_Click(sender, e);
        }

        private void btnEjecutarBusqueda_Click(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }

        private void tobLimpiar_Click(object sender, EventArgs e)
        {
            txtApellidos.Text = "";
            TxtCedula.Text = "";
            TxtIdConsulta.Text = "";
            TxtNombre.Text = "";
            TxtNumExpediente.Text = "";
            txtDiagnosticos.Text = "";

            oArregloChecked.Clear();
            LlenarListaDiagnosticos("");

            rdFechaExacta.Checked = false;
            rdIndicesFechas.Checked = false;
            RdNacional.Checked = false;
            RdExtranjero.Checked = false;

            dtFechaCosnulta.Value = DateTime.Today;
            dtFechaFinal.Value = DateTime.Today;
            dtFechaInicial.Value = DateTime.Today;

            pictureBox3.BackgroundImage = Resources.Person_Red;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void tobBuscarPaciente_Click(object sender, EventArgs e)
        {
            FrmBlackBackground oFrmBlackBackground = new FrmBlackBackground();
            oFrmBlackBackground.Show();

            RadioButton tempTipoCedula = new RadioButton();
            frmPacientesExistentesBusquedaConsultas oFrmPacientesExistentes = new frmPacientesExistentesBusquedaConsultas(TxtNumExpediente, TxtNombre, txtApellidos, TxtCedula, pictureBox3, tempTipoCedula);
            oFrmPacientesExistentes.ShowDialog();

            if (tempTipoCedula.Checked == true)
                RdNacional.Checked = true;
            else
                RdExtranjero.Checked = true;

            tempTipoCedula.Dispose();
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;

            oFrmBlackBackground.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LlenarListaDiagnosticos(string pDiagnostico)
        {
            lstDiagnosticos.Items.Clear();

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Diagnosticos_Param '" + pDiagnostico.Trim() + "'", "Diagnosticos");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstDiagnosticos.Items.Add(dr[1].ToString().Trim());
                        lstDiagnosticos.Items[lstDiagnosticos.Items.Count - 1].Tag = dr[0].ToString().Trim();

                        if (oArregloChecked.Contains(dr[0].ToString().Trim()))
                            lstDiagnosticos.Items[lstDiagnosticos.Items.Count - 1].Checked = true;
                    }
                }
                ds.Dispose();
            }
        }

        private void txtDiagnosticos_TextChanged(object sender, EventArgs e)
        {
            LlenarListaDiagnosticos(txtDiagnosticos.Text.Trim());
        }

        private void lstDiagnosticos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                if (e.Item.Tag != null)
                {
                    if (e.Item.Checked == true)
                    {
                        if (!oArregloChecked.Contains(e.Item.Tag.ToString().Trim()))
                            oArregloChecked.Add(e.Item.Tag.ToString().Trim());
                    }
                    else
                        oArregloChecked.RemoveAt(oArregloChecked.IndexOf(e.Item.Tag.ToString().Trim()));
                }
            }
            catch { }
        }
    }
}