using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Lógica_Negocios;
using System.Collections;
using System.IO;
using G_Clinic.Properties;
using Transitions;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmDetallePaciente : Form
    {
        #region Variables e instancias

        bool activo = false;

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        string numExpediente = "";
        bool menarca = true;//Determina si una paciente trabaja con Menstruación o no, dependiendo si hay algún valor en la Menarca...

        Image newImage;

        ArrayList oArregloDatosMadre = new ArrayList();
        ArrayList oArregloDatosPadre = new ArrayList();
        ArrayList oArregloExamenObserv = new ArrayList();
        ArrayList oArregloAntecedentesGenerales = new ArrayList();
        ArrayList oArregloAntecedentesObstetGinec = new ArrayList();

        CPacientes oCPacientes = new CPacientes();
        CContactosPacientes oCContactosPacientes = new CContactosPacientes();
        CDatosFamiliaresPaciente oCDatosFamiliares = new CDatosFamiliaresPaciente();
        CAntecedentesGenerales oCAntecedentesGenerales = new CAntecedentesGenerales();
        CAntecedentes_ObstetGinec oCAntecedentes_ObstetGinec = new CAntecedentes_ObstetGinec();

        int numTab = 0;

        #endregion

        public frmDetallePaciente()
        {
            InitializeComponent();
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.Mantenimiento);

            try
            {
                VistaConstants.SetWindowTheme(lstContactos.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstContactos.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
            }
            catch { }
        }

        public string NumExpediente
        {
            get { return numExpediente; }
            set { numExpediente = value; }
        }

        public bool Menarca
        {
            get { return menarca; }
        }

        private void frmDetallePaciente_Load(object sender, EventArgs e)
        {
            if (groupContactos.Visible == true)
                groupContactos.Visible = false;

            this.Region = Shape.RoundedRegion(this.Size, 10, Shape.Corner.None);
            this.pictureBox1.Region = Shape.RoundedRegion(pictureBox1.Size, 1, Shape.Corner.None);

            this.Left = ((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2);

            int top = 0;
            top = Screen.PrimaryScreen.WorkingArea.Height - this.Height - Program.oMDI.statusStrip1.Height - Program.oFrmDock.Height + 5;

            if (top < 0)
                top = 0;

            this.Top = top;

            if (numExpediente.Trim() != "")
                EstableceDatosPacientes();
            else
                this.Close();
        }

        #region Datos Personales

        private void LlenaListaContactos_Paciente()
        {
            lstContactos.Items.Clear();
            
            if (lblNumExpediente.Text.Trim() != "")
            {
                DataTable oDataTable = Metodos_Globales.Consulta(oCContactosPacientes.Consultar());

                int i = 0;                
                if (oDataTable != null)
                {
                    foreach (DataRow dr in oDataTable.Rows)
                    {
                        lstContactos.Items.Add(dr[1].ToString().Trim());
                        lstContactos.Items[i].SubItems.Add(dr[2].ToString());
                        lstContactos.Items[i].SubItems.Add(dr[0].ToString());

                        i++;
                    }
                    oDataTable.Dispose();
                }
            }
        }
        

        private void HabilitaCamposDatosPersonales()
        {
            TxtNombre.Enabled = true;
            txtApellidos.Enabled = true;
            TxtCedula.Enabled = true;
            DtFecha_Naci.Enabled = true;
            TxtEdad.Enabled = true;
            CmbSexo.Enabled = true;
            CmbEstadoCivil.Enabled = true;
            TxtDireccion.Enabled = true;
            txtApellidos.Enabled = true;
            txtOcupacion.Enabled = true;
            RdNacional.Enabled = true;
            RdExtranjero.Enabled = true;
        }

        private void DeshabilitaCamposDatosPersonales()
        {
            TxtNombre.Enabled = false;
            txtApellidos.Enabled = false;
            TxtCedula.Enabled = false;
            DtFecha_Naci.Enabled = false;
            TxtEdad.Enabled = false;
            CmbSexo.Enabled = false;
            CmbEstadoCivil.Enabled = false;
            TxtDireccion.Enabled = false;
            txtApellidos.Enabled = false;
            txtOcupacion.Enabled = false;
            RdNacional.Enabled = false;
            RdExtranjero.Enabled = false;
        }

        private void LimpiaCamposDatosPersonales()
        {
            TxtNombre.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            TxtCedula.Text = String.Empty;
            DtFecha_Naci.Value = DateTime.Today;
            TxtEdad.Text = String.Empty;
            CmbSexo.SelectedIndex = 0;
            CmbEstadoCivil.SelectedIndex = 0;
            TxtDireccion.Text = String.Empty;
            txtOcupacion.Text = String.Empty;
            RdNacional.Checked = true;
        }

        #endregion

        #region Datos Familiares

        private void HabilitaCamposDatosFamiliares()
        {
            //Madre
            txtNombreMadre.Enabled = true;
            txtApellidosMadre.Enabled = true;
            txtTelefonosMadre.Enabled = true;
            txtEmailMadre.Enabled = true;
            txtObservacionesMadre.Enabled = true;

            //Padre
            txtNombrePadre.Enabled = true;
            txtApellidosPadre.Enabled = true;
            txtTelefonosPadre.Enabled = true;
            txtEmailPadre.Enabled = true;
            txtObservacionesPadre.Enabled = true;
        }

        private void DeshabilitaCamposDatosFamiliares()
        {
            //Madre
            txtNombreMadre.Enabled = false;
            txtApellidosMadre.Enabled = false;
            txtTelefonosMadre.Enabled = false;
            txtEmailMadre.Enabled = false;
            txtObservacionesMadre.Enabled = false;

            tobGuardarDatosMadre.Enabled = false;
            tobCancelarDatosMadre.Enabled = false;

            //Padre
            txtNombrePadre.Enabled = false;
            txtApellidosPadre.Enabled = false;
            txtTelefonosPadre.Enabled = false;
            txtEmailPadre.Enabled = false;
            txtObservacionesPadre.Enabled = false;

            tobGuardarDatosPadre.Enabled = false;
            tobCancelarDatosPadre.Enabled = false;
        }

        private void LimpiaCamposDatosFamiliares()
        {
            //Madre
            txtNombreMadre.Text = String.Empty;
            txtApellidosMadre.Text = String.Empty;
            txtTelefonosMadre.Text = String.Empty;
            txtEmailMadre.Text = String.Empty;
            txtObservacionesMadre.Text = String.Empty;

            //Padre
            txtNombrePadre.Text = String.Empty;
            txtApellidosPadre.Text = String.Empty;
            txtTelefonosPadre.Text = String.Empty;
            txtEmailPadre.Text = String.Empty;
            txtObservacionesPadre.Text = String.Empty;
        }

        #endregion

        #region Examen Físico y Observaciones Generales

        private void HabilitaCamposExamenObservaciones()
        {
            txtObservacionesGenerales.Enabled = true;
            
            cmbTipoSangre.Enabled = true;
            rdRHNegativo.Enabled = true;
            rdRHPositivo.Enabled = true;
        }

        private void DeshabilitaCamposExamenObservaciones()
        {
            txtObservacionesGenerales.Enabled = false;
            
            cmbTipoSangre.Enabled = false;
            rdRHNegativo.Enabled = false;
            rdRHPositivo.Enabled = false;

            btnGuardarExamenObservaciones.Enabled = false;
            btnCancelarExamenObservaciones.Enabled = false;
        }

        private void LimpiaCamposExamenObservaciones()
        {
            txtObservacionesGenerales.Text = String.Empty;

            cmbTipoSangre.Text = String.Empty;
            rdRHNegativo.Checked = false;
            rdRHPositivo.Checked = false;
        }

        #endregion

        /// <summary>
        /// Establece todos los datos relacionados con la Historia Clínica del paciente, de igual manera a como se trabaja directamente
        /// en el Historial Clínico directamente
        /// </summary>
        public void EstableceDatosPacientes()
        {
            object sender = new object();
            EventArgs e = new EventArgs();

            pictureBox1.BackgroundImage = Resources.Person_Red;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            lblNumExpediente.Text = numExpediente;

            if (lblNumExpediente.Text.Trim() != "")
            {
                DataSet ds = new DataSet();

                #region Datos Personales

                oArregloExamenObserv.Clear();

                ds = Program.oPersistencia.ejecutarSQLListas("sp_S_Pacientes_Param '" + lblNumExpediente.Text.Trim() + "'", "Paciente");

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr[1].ToString().Trim() == "0")
                                RdNacional.Checked = true;
                            else
                                RdExtranjero.Checked = true;

                            TxtCedula.Text = dr[2].ToString().Trim();
                            TxtNombre.Text = dr[3].ToString().Trim();
                            txtApellidos.Text = dr[4].ToString().Trim();

                            if (dr[5].ToString().Trim() == "0")
                                CmbSexo.SelectedIndex = 1;
                            else if (dr[5].ToString().Trim() == "1")
                                CmbSexo.SelectedIndex = 0;
                            else
                                CmbSexo.SelectedIndex = 2;

                            DtFecha_Naci.Value = Convert.ToDateTime(dr[6].ToString().Trim());
                            DtFecha_Naci.Text = DtFecha_Naci.Value.ToString(); 

                            if (dr[7].ToString().Trim() == "0")
                                CmbEstadoCivil.SelectedIndex = 0;//casada
                            else if (dr[7].ToString().Trim() == "1")
                                CmbEstadoCivil.SelectedIndex = 1;//soltera
                            else if (dr[7].ToString().Trim() == "2")
                                CmbEstadoCivil.SelectedIndex = 2;//unión libre
                            else if (dr[7].ToString().Trim() == "3")
                                CmbEstadoCivil.SelectedIndex = 3;//separada
                            else if (dr[7].ToString().Trim() == "4")
                                CmbEstadoCivil.SelectedIndex = 4;//viuda
                            else
                                CmbEstadoCivil.SelectedIndex = 5;//divorciada

                            txtOcupacion.Text = dr[8].ToString().Trim();
                            TxtDireccion.Text = dr[9].ToString().Trim();

                            
                            LimpiaCamposExamenObservaciones();

                            txtObservacionesGenerales.Text = dr[11].ToString().Trim();
                            oArregloExamenObserv.Add(txtObservacionesGenerales.Text.Trim());

                            cmbTipoSangre.Text = dr[15].ToString().Trim();
                            oArregloExamenObserv.Add(cmbTipoSangre.Text.Trim());

                            if (dr[16].ToString().Trim() == "+")
                                rdRHPositivo.Checked = true;
                            else if (dr[16].ToString().Trim() == "-")
                                rdRHNegativo.Checked = true;

                            oArregloExamenObserv.Add(dr[16].ToString().Trim());

                            try
                            {
                                //Get image data from gridview column.
                                byte[] imageData = (byte[])dr[10];

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
                                else
                                {
                                    pictureBox1.BackgroundImage = Resources.Person_Red;
                                    pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                                }
                            }
                            catch { }

                        }
                    }
                    else
                    {
                        ds.Dispose();
                        return;
                    }
                }
                else
                {
                    if (ds != null)
                        ds.Dispose();

                    return;
                }

                if (ds != null)
                    ds = null;

                if (lblNumExpediente.Text.Trim() != "")
                {
                    oCContactosPacientes.NumExpediente = lblNumExpediente.Text.Trim();
                    LlenaListaContactos_Paciente();
                }

                #endregion

                #region Datos Familiares

                oArregloDatosMadre.Clear();
                oArregloDatosPadre.Clear();

                oCDatosFamiliares.NumExpediente = lblNumExpediente.Text.Trim();

                try
                {
                    ds = oCDatosFamiliares.ConsultarDataset();
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                if (dr[1].ToString().Trim() == "Madre o Encargada")
                                {
                                    #region Almacena datos en arreglo de Madre y llena cajas de texto con datos

                                    txtNombreMadre.Text = dr[2].ToString().Trim();
                                    oArregloDatosMadre.Add(dr[2].ToString().Trim());

                                    txtApellidosMadre.Text = dr[3].ToString().Trim();
                                    oArregloDatosMadre.Add(dr[3].ToString().Trim());

                                    txtTelefonosMadre.Text = dr[4].ToString().Trim();
                                    oArregloDatosMadre.Add(dr[4].ToString().Trim());

                                    txtEmailMadre.Text = dr[5].ToString().Trim();
                                    oArregloDatosMadre.Add(dr[5].ToString().Trim());

                                    txtObservacionesMadre.Text = dr[6].ToString().Trim();
                                    oArregloDatosMadre.Add(dr[6].ToString().Trim());

                                    #endregion
                                }
                                else
                                {
                                    #region Almacena datos en arreglo de Padre y llena cajas de texto con datos

                                    txtNombrePadre.Text = dr[2].ToString().Trim();
                                    oArregloDatosPadre.Add(dr[2].ToString().Trim());

                                    txtApellidosPadre.Text = dr[3].ToString().Trim();
                                    oArregloDatosPadre.Add(dr[3].ToString().Trim());

                                    txtTelefonosPadre.Text = dr[4].ToString().Trim();
                                    oArregloDatosPadre.Add(dr[4].ToString().Trim());

                                    txtEmailPadre.Text = dr[5].ToString().Trim();
                                    oArregloDatosPadre.Add(dr[5].ToString().Trim());

                                    txtObservacionesPadre.Text = dr[6].ToString().Trim();
                                    oArregloDatosPadre.Add(dr[6].ToString().Trim());

                                    #endregion
                                }
                            }
                        }
                        else
                            LimpiaCamposDatosFamiliares();
                    }
                    else
                        LimpiaCamposDatosFamiliares();

                    ds = null;//Limpia para reutilizar el dataset en la siguiente consulta

                    if (oCDatosFamiliares.ConsultarDataset() != null)
                        oCDatosFamiliares.ConsultarDataset().Dispose();
                }
                catch { }

                #endregion

                #region Antecedentes Generales

                oArregloAntecedentesGenerales.Clear();

                try
                {
                    oCAntecedentesGenerales.Num_expediente = lblNumExpediente.Text.Trim();

                    ds = oCAntecedentesGenerales.ConsultarDataset();

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                oArregloAntecedentesGenerales.Add(dr[1].ToString().Trim());
                                oArregloAntecedentesGenerales.Add(dr[2].ToString().Trim());
                                oArregloAntecedentesGenerales.Add(dr[3].ToString().Trim());
                                oArregloAntecedentesGenerales.Add(dr[4].ToString().Trim());
                                oArregloAntecedentesGenerales.Add(dr[5].ToString().Trim());
                                oArregloAntecedentesGenerales.Add(dr[6].ToString().Trim());
                                oArregloAntecedentesGenerales.Add(dr[7].ToString().Trim());
                            }
                        }
                        else
                        {
                            tobGuardarAntecedentes.Enabled = true;
                            tobCancelarAntecedentes.Enabled = true;
                        }
                    }
                    else
                    {
                        tobGuardarAntecedentes.Enabled = true;
                        tobCancelarAntecedentes.Enabled = true;
                    }

                    ds = null;

                    if (oCAntecedentesGenerales.ConsultarDataset() != null)
                        oCAntecedentesGenerales.ConsultarDataset().Dispose();
                }
                catch { }

                #endregion

                #region Antecedentes Obstétricos y Ginecológicos

                oArregloAntecedentesObstetGinec.Clear();

                try
                {
                    oCAntecedentes_ObstetGinec.Num_Expediente = lblNumExpediente.Text.Trim();

                    ds = oCAntecedentes_ObstetGinec.ConsultarDataset();

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                txtGesta.Text = dr[1].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtGesta.Text.Trim());

                                txtPara.Text = dr[2].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtPara.Text.Trim());

                                txtAbortos.Text = dr[3].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtAbortos.Text.Trim());

                                txtCesareas.Text = dr[4].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtCesareas.Text.Trim());

                                txtGemelares.Text = dr[5].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtGemelares.Text.Trim());

                                txtMolas.Text = dr[6].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtMolas.Text.Trim());

                                txtEctopicos.Text = dr[7].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtEctopicos.Text.Trim());

                                txtObitos.Text = dr[8].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtObitos.Text.Trim());

                                dtFechaUltimoParto.Value = Convert.ToDateTime(dr[9].ToString().Trim());
                                oArregloAntecedentesObstetGinec.Add(dtFechaUltimoParto.Value);

                                txtComplicacionesUP.Text = dr[10].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtComplicacionesUP.Text.Trim());

                                txtMenarca.Text = dr[11].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtMenarca.Text.Trim());

                                txtMenopausia.Text = dr[12].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtMenopausia.Text.Trim());

                                txtCicloMenstrual.Text = dr[13].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtCicloMenstrual.Text.Trim());

                                cmbTipoCiclo.SelectedIndex = Convert.ToInt32(dr[14]);
                                oArregloAntecedentesObstetGinec.Add(cmbTipoCiclo.SelectedIndex);

                                txtDetalleTipoCiclo.Text = dr[15].ToString().Trim();
                                oArregloAntecedentesObstetGinec.Add(txtDetalleTipoCiclo.Text.Trim());
                            }

                            txtMenarca_TextChanged(sender, e);

                            btnGuardarAntecedObstetGinec.Enabled = false;
                            btnCancelarAntecedObstetGinec.Enabled = false;
                        }
                        else
                        {
                            LimpiaCamposAntecedentesObstetGinec();

                            txtMenarca_TextChanged(sender, e);

                            btnGuardarAntecedObstetGinec.Enabled = true;
                            btnCancelarAntecedObstetGinec.Enabled = false;
                        }
                    }
                    else
                    {
                        LimpiaCamposAntecedentesObstetGinec();

                        txtMenarca_TextChanged(sender, e);

                        btnGuardarAntecedObstetGinec.Enabled = true;
                        btnCancelarAntecedObstetGinec.Enabled = false;
                    }
                }
                catch { }

                if (ds != null)
                    ds.Dispose();

                if (oCAntecedentes_ObstetGinec.ConsultarDataset() != null)
                    oCAntecedentes_ObstetGinec.ConsultarDataset().Dispose();

                if (txtMenarca.Text.Trim() == "" || txtMenarca.Text.Trim() == "0")
                    menarca = false;
                else
                    menarca = true;

                #endregion
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (groupContactos.Visible == true)
                groupContactos.Visible = false;

            if (Program.oFrmExamenesConsulta != null && Program.oFrmImagenesConsultas != null && Program.oFrmHistorialConsultas != null &&
                Program.oFrmVideosConsulta != null && Program.oFrmEmbarazos != null)
            {
                if (Program.oFrmExamenesConsulta.Activo == false && Program.oFrmImagenesConsultas.Activo == false && 
                    Program.oFrmHistorialConsultas.Activo == false && Program.oFrmVideosConsulta.Activo == false && 
                    Program.oFrmEmbarazos.Activo == false)
                {
                    EventArgs e2 = new EventArgs();
                    Program.oFrmDock.frmDock_MouseLeave(sender, e2);
                }
            }
        }

        private void tobForward_Click(object sender, EventArgs e)
        {
            try
            {
                numTab++;

                if (numTab == tabControl1.TabCount)
                    numTab = tabControl1.TabCount - 1;

                tabControl1.SelectedIndex = numTab;
            }
            catch
            {
                numTab--;
            }
        }

        private void tobBack_Click(object sender, EventArgs e)
        {
            try
            {
                numTab--;

                if (numTab < 0)
                    numTab = 0;

                tabControl1.SelectedIndex = numTab;
            }
            catch
            {
                numTab++;
            }
        }

        private void lblDatosMadre_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 0;
        }

        private void lblDatosPadre_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 1;
            tabDatosMadre.BackgroundColor = Color.LightSteelBlue;
            tabDatosPadre.BackgroundColor = Color.Orange;
        }

        private void lblDatosMadre_MouseEnter(object sender, EventArgs e)
        {
            tabDatosMadre.BackgroundColor = Color.DodgerBlue;
        }

        private void lblDatosMadre_MouseDown(object sender, MouseEventArgs e)
        {
            tabDatosMadre.BackgroundColor = Color.LightSteelBlue;
        }

        private void lblDatosMadre_MouseLeave(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 0)
            {
                tabDatosMadre.BackgroundColor = Color.Orange;
                tabDatosPadre.BackgroundColor = Color.LightSteelBlue;
            }
            else
            {
                tabDatosMadre.BackgroundColor = Color.LightSteelBlue;
                tabDatosPadre.BackgroundColor = Color.Orange;
            }
        }

        private void lblDatosMadre_MouseUp(object sender, MouseEventArgs e)
        {
            tabDatosMadre.BackgroundColor = Color.DodgerBlue;
        }

        private void tabDatosPadre_MouseDown(object sender, MouseEventArgs e)
        {
            tabDatosPadre.BackgroundColor = Color.LightSteelBlue;
        }

        private void tabDatosPadre_MouseEnter(object sender, EventArgs e)
        {
            tabDatosPadre.BackgroundColor = Color.DodgerBlue;
        }

        private void tabDatosPadre_MouseLeave(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 1)
            {
                tabDatosMadre.BackgroundColor = Color.LightSteelBlue;
                tabDatosPadre.BackgroundColor = Color.Orange;
            }
            else
            {
                tabDatosMadre.BackgroundColor = Color.Orange;
                tabDatosPadre.BackgroundColor = Color.LightSteelBlue;
            }
        }

        private void tabDatosPadre_MouseUp(object sender, MouseEventArgs e)
        {
            tabDatosPadre.BackgroundColor = Color.DodgerBlue;
        }

        #region Datos Familiares

        #region Comprueba cambios realizados en datos de Madre

        private void CompruebaCambiosRealizados_DatosMadre()
        {
            if (lblNumExpediente.Text.Trim() != "")
            {
                tobGuardarDatosMadre.Enabled = false;
                tobCancelarDatosMadre.Enabled = false;

                if (oArregloDatosMadre.Count == 5)
                {
                    if (txtNombreMadre.Text.Trim() != oArregloDatosMadre[Convert.ToInt32(txtNombreMadre.Tag)].ToString().Trim() ||
                        txtApellidosMadre.Text.Trim() != oArregloDatosMadre[Convert.ToInt32(txtApellidosMadre.Tag)].ToString().Trim() ||
                        txtTelefonosMadre.Text.Trim() != oArregloDatosMadre[Convert.ToInt32(txtTelefonosMadre.Tag)].ToString().Trim() ||
                        txtEmailMadre.Text.Trim() != oArregloDatosMadre[Convert.ToInt32(txtEmailMadre.Tag)].ToString().Trim() ||
                        txtObservacionesMadre.Text.Trim() != oArregloDatosMadre[Convert.ToInt32(txtObservacionesMadre.Tag)].ToString().Trim())
                    {
                        tobGuardarDatosMadre.Enabled = true;
                        tobCancelarDatosMadre.Enabled = true;
                    }
                }
                else
                {
                    tobGuardarDatosMadre.Enabled = true;
                    tobCancelarDatosMadre.Enabled = false;
                }
            }
        }

        private void txtNombreMadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosMadre();
        }

        private void txtApellidosMadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosMadre();
        }

        private void txtTelefonosMadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosMadre();
        }

        private void txtEmailMadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosMadre();
        }

        private void txtObservacionesMadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosMadre();
        }

        #endregion

        #region Comprueba cambios realizados en datos de Padre

        private void CompruebaCambiosRealizados_DatosPadre()
        {
            if (lblNumExpediente.Text.Trim() != "")
            {
                tobGuardarDatosPadre.Enabled = false;
                tobCancelarDatosPadre.Enabled = false;

                if (oArregloDatosPadre.Count == 5)
                {
                    if (txtNombrePadre.Text.Trim() != oArregloDatosPadre[Convert.ToInt32(txtNombrePadre.Tag)].ToString().Trim() ||
                        txtApellidosPadre.Text.Trim() != oArregloDatosPadre[Convert.ToInt32(txtApellidosPadre.Tag)].ToString().Trim() ||
                        txtTelefonosPadre.Text.Trim() != oArregloDatosPadre[Convert.ToInt32(txtTelefonosPadre.Tag)].ToString().Trim() ||
                        txtEmailPadre.Text.Trim() != oArregloDatosPadre[Convert.ToInt32(txtEmailPadre.Tag)].ToString().Trim() ||
                        txtObservacionesPadre.Text.Trim() != oArregloDatosPadre[Convert.ToInt32(txtObservacionesPadre.Tag)].ToString().Trim())
                    {
                        tobGuardarDatosPadre.Enabled = true;
                        tobCancelarDatosPadre.Enabled = true;
                    }
                }
                else
                {
                    tobGuardarDatosPadre.Enabled = true;
                    tobCancelarDatosPadre.Enabled = false;
                }
            }
        }

        private void txtNombrePadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosPadre();
        }

        private void txtApellidosPadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosPadre();
        }

        private void txtTelefonosPadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosPadre();
        }

        private void txtEmailPadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosPadre();
        }

        private void txtObservacionesPadre_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_DatosPadre();
        }

        #endregion

        private void tobGuardarDatosMadre_Click(object sender, EventArgs e)
        {
            oCDatosFamiliares.NumExpediente = lblNumExpediente.Text.Trim();
            oCDatosFamiliares.TipoFamiliar = "Madre o Encargada";
            oCDatosFamiliares.Nombre = txtNombreMadre.Text.Trim();
            oCDatosFamiliares.Apellidos = txtApellidosMadre.Text.Trim();
            oCDatosFamiliares.Telefonos = txtTelefonosMadre.Text.Trim();
            oCDatosFamiliares.Email = txtEmailMadre.Text.Trim();
            oCDatosFamiliares.Observaciones = txtObservacionesMadre.Text.Trim();

            if (oArregloDatosMadre.Count == 0)
                oCDatosFamiliares.Insertar();
            else if (oArregloDatosMadre.Count > 0)
                oCDatosFamiliares.Modificar();

            #region Limpia arreglo y establece nuevos datos

            oArregloDatosMadre.Clear();
            oArregloDatosMadre.Add(txtNombreMadre.Text.Trim());
            oArregloDatosMadre.Add(txtApellidosMadre.Text.Trim());
            oArregloDatosMadre.Add(txtTelefonosMadre.Text.Trim());
            oArregloDatosMadre.Add(txtEmailMadre.Text.Trim());
            oArregloDatosMadre.Add(txtObservacionesMadre.Text.Trim());

            tobGuardarDatosMadre.Enabled = false;
            tobCancelarDatosMadre.Enabled = false;

            #endregion
        }

        private void tobCancelarDatosMadre_Click(object sender, EventArgs e)
        {
            if (oArregloDatosMadre.Count > 0)
            {
                txtNombreMadre.Text = oArregloDatosMadre[Convert.ToInt32(txtNombreMadre.Tag)].ToString().Trim();
                txtApellidosMadre.Text = oArregloDatosMadre[Convert.ToInt32(txtApellidosMadre.Tag)].ToString().Trim();
                txtTelefonosMadre.Text = oArregloDatosMadre[Convert.ToInt32(txtTelefonosMadre.Tag)].ToString().Trim();
                txtEmailMadre.Text = oArregloDatosMadre[Convert.ToInt32(txtEmailMadre.Tag)].ToString().Trim();
                txtObservacionesMadre.Text = oArregloDatosMadre[Convert.ToInt32(txtObservacionesMadre.Tag)].ToString().Trim();
            }
            else
            {
                txtNombreMadre.Text = "";
                txtApellidosMadre.Text = "";
                txtTelefonosMadre.Text = "";
                txtEmailMadre.Text = "";
                txtObservacionesMadre.Text = "";
            }

            tobGuardarDatosMadre.Enabled = false;
            tobCancelarDatosMadre.Enabled = false;
        }

        private void tobGuardarDatosPadre_Click(object sender, EventArgs e)
        {
            oCDatosFamiliares.NumExpediente = lblNumExpediente.Text.Trim();
            oCDatosFamiliares.TipoFamiliar = "Padre o Encargado";
            oCDatosFamiliares.Nombre = txtNombrePadre.Text.Trim();
            oCDatosFamiliares.Apellidos = txtApellidosPadre.Text.Trim();
            oCDatosFamiliares.Telefonos = txtTelefonosPadre.Text.Trim();
            oCDatosFamiliares.Email = txtEmailPadre.Text.Trim();
            oCDatosFamiliares.Observaciones = txtObservacionesPadre.Text.Trim();

            if (oArregloDatosPadre.Count == 0)
                oCDatosFamiliares.Insertar();
            else
                oCDatosFamiliares.Modificar();

            //oCDatosFamiliares.Modificar();

            #region Limpia arreglo y establece nuevos datos

            oArregloDatosPadre.Clear();
            oArregloDatosPadre.Add(txtNombrePadre.Text.Trim());
            oArregloDatosPadre.Add(txtApellidosPadre.Text.Trim());
            oArregloDatosPadre.Add(txtTelefonosPadre.Text.Trim());
            oArregloDatosPadre.Add(txtEmailPadre.Text.Trim());
            oArregloDatosPadre.Add(txtObservacionesPadre.Text.Trim());

            tobGuardarDatosPadre.Enabled = false;
            tobCancelarDatosPadre.Enabled = false;

            #endregion
        }

        private void tobCancelarDatosPadre_Click(object sender, EventArgs e)
        {
            if (oArregloDatosPadre.Count > 0)
            {
                txtNombrePadre.Text = oArregloDatosPadre[Convert.ToInt32(txtNombrePadre.Tag)].ToString().Trim();
                txtApellidosPadre.Text = oArregloDatosPadre[Convert.ToInt32(txtApellidosPadre.Tag)].ToString().Trim();
                txtTelefonosPadre.Text = oArregloDatosPadre[Convert.ToInt32(txtTelefonosPadre.Tag)].ToString().Trim();
                txtEmailPadre.Text = oArregloDatosPadre[Convert.ToInt32(txtEmailPadre.Tag)].ToString().Trim();
                txtObservacionesPadre.Text = oArregloDatosPadre[Convert.ToInt32(txtObservacionesPadre.Tag)].ToString().Trim();
            }
            else
            {
                txtNombrePadre.Text = "";
                txtApellidosPadre.Text = "";
                txtTelefonosPadre.Text = "";
                txtEmailPadre.Text = "";
                txtObservacionesPadre.Text = "";
            }

            tobGuardarDatosPadre.Enabled = false;
            tobCancelarDatosPadre.Enabled = false;
        }

        #endregion

        #region Observaciones Generales

        private void btnGuardarExamenObservaciones_Click(object sender, EventArgs e)
        {
            oCPacientes.Observaciones = txtObservacionesGenerales.Text.Trim();
            oCPacientes.Tipo_sangre = cmbTipoSangre.Text.Trim();

            if (rdRHPositivo.Checked == true)
                oCPacientes.Factor_rh = "+";
            else
                if (rdRHNegativo.Checked == true)
                    oCPacientes.Factor_rh = "-";

            Program.oComprobaciones.Modificar("observaciones = '" + oCPacientes.Observaciones.Trim() + 
                                              "', tipo_sangre = '" + oCPacientes.Tipo_sangre.Trim() + 
                                              "', factor_rh = '" + oCPacientes.Factor_rh.Trim() + "'", 
                                              "Paciente", 
                                              "num_expediente = " + lblNumExpediente.Text.Trim());

            #region Actualiza el Arreglo

            oArregloExamenObserv.Clear();
            oArregloExamenObserv.Add(txtObservacionesGenerales.Text.Trim());
            oArregloExamenObserv.Add(cmbTipoSangre.Text.Trim());
            if (rdRHPositivo.Checked == true)
                oArregloExamenObserv.Add("+");
            else
                if (rdRHNegativo.Checked == true)
                    oArregloExamenObserv.Add("-");

            btnGuardarExamenObservaciones.Enabled = false;
            btnCancelarExamenObservaciones.Enabled = false;

            #endregion
        }

        private void btnCancelarExamenObservaciones_Click(object sender, EventArgs e)
        {
            txtObservacionesGenerales.Text = oArregloExamenObserv[Convert.ToInt32(txtObservacionesGenerales.Tag)].ToString().Trim();
            cmbTipoSangre.Text = oArregloExamenObserv[Convert.ToInt32(cmbTipoSangre.Tag)].ToString().Trim();

            if (oArregloExamenObserv[Convert.ToInt32(rdRHPositivo.Tag)].ToString().Trim() == "+")
            {
                rdRHPositivo.Checked = true;
                rdRHNegativo.Checked = false;
            }
            else
            {
                rdRHPositivo.Checked = false;
                rdRHNegativo.Checked = true;
            }

            btnGuardarAntecedObstetGinec.Enabled = false;
            btnCancelarAntecedObstetGinec.Enabled = false;
        }

        private void CompruebaCambiosRealizados_ExamenObservaciones()
        {
            if (lblNumExpediente.Text.Trim() != "")
            {
                btnGuardarExamenObservaciones.Enabled = false;
                btnCancelarExamenObservaciones.Enabled = false;

                if (oArregloExamenObserv.Count == 3)
                {
                    string RH = "";

                    if (rdRHPositivo.Checked == true)
                        RH = "+";
                    else
                        if (rdRHNegativo.Checked == true)
                            RH = "-";

                    if (txtObservacionesGenerales.Text.Trim() != oArregloExamenObserv[Convert.ToInt32(txtObservacionesGenerales.Tag)].ToString().Trim() ||
                        cmbTipoSangre.Text.Trim() != oArregloExamenObserv[Convert.ToInt32(cmbTipoSangre.Tag)].ToString().Trim() ||
                        RH != oArregloExamenObserv[Convert.ToInt32(rdRHNegativo.Tag)].ToString().Trim())
                    {
                        btnGuardarExamenObservaciones.Enabled = true;
                        btnCancelarExamenObservaciones.Enabled = true;
                    }
                }
                else
                {
                    btnGuardarExamenObservaciones.Enabled = true;
                    btnCancelarExamenObservaciones.Enabled = true;
                }
            }
        }

        private void txtObservacionesGenerales_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_ExamenObservaciones();
        }

        #endregion

        #region Antecedentes Generales

        //-6, 41
        private void btnPatologicos_Click(object sender, EventArgs e)
        {
            lblAntecedente.Text = "Antecedentes Patológicos";

            if (oArregloAntecedentesGenerales.Count > 0)
                txtAntecedente.Text = oArregloAntecedentesGenerales[0].ToString().Trim();
            else
                txtAntecedente.Text = "";

            txtAntecedente.Tag = "0";

            Transition t = new Transition(new TransitionType_EaseInEaseOut(250));
            t.add(panelAntecedentes, "Top", -224);
            t.run();
        }

        private void btnNoPatologicos_Click(object sender, EventArgs e)
        {
            lblAntecedente.Text = "Antecedentes NO Patológicos";

            if (oArregloAntecedentesGenerales.Count > 0)
                txtAntecedente.Text = oArregloAntecedentesGenerales[1].ToString().Trim();
            else
                txtAntecedente.Text = "";

            txtAntecedente.Tag = "1";

            Transition t = new Transition(new TransitionType_EaseInEaseOut(250));
            t.add(panelAntecedentes, "Top", -224);
            t.run();
        }

        private void btnFamiliares_Click(object sender, EventArgs e)
        {
            lblAntecedente.Text = "Antecedentes Familiares";

            if (oArregloAntecedentesGenerales.Count > 0)
                txtAntecedente.Text = oArregloAntecedentesGenerales[2].ToString().Trim();
            else
                txtAntecedente.Text = "";

            txtAntecedente.Tag = "2";

            Transition t = new Transition(new TransitionType_EaseInEaseOut(250));
            t.add(panelAntecedentes, "Top", -224);
            t.run();
        }

        private void btnQuirurgicos_Click(object sender, EventArgs e)
        {
            lblAntecedente.Text = "Antecedentes Quirúrgicos";

            if (oArregloAntecedentesGenerales.Count > 0)
                txtAntecedente.Text = oArregloAntecedentesGenerales[3].ToString().Trim();
            else
                txtAntecedente.Text = "";

            txtAntecedente.Tag = "3";

            Transition t = new Transition(new TransitionType_EaseInEaseOut(250));
            t.add(panelAntecedentes, "Top", -224);
            t.run();
        }

        private void btnAlergias_Click(object sender, EventArgs e)
        {
            lblAntecedente.Text = "Alergias";

            if (oArregloAntecedentesGenerales.Count > 0)
                txtAntecedente.Text = oArregloAntecedentesGenerales[4].ToString().Trim();
            else
                txtAntecedente.Text = "";

            txtAntecedente.Tag = "4";

            Transition t = new Transition(new TransitionType_EaseInEaseOut(250));
            t.add(panelAntecedentes, "Top", -224);
            t.run();
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            lblAntecedente.Text = "Medicamentos";

            if (oArregloAntecedentesGenerales.Count > 0)
                txtAntecedente.Text = oArregloAntecedentesGenerales[5].ToString().Trim();
            else
                txtAntecedente.Text = "";

            txtAntecedente.Tag = "5";

            Transition t = new Transition(new TransitionType_EaseInEaseOut(250));
            t.add(panelAntecedentes, "Top", -224);
            t.run();
        }

        private void btnOtros_Click(object sender, EventArgs e)
        {
            lblAntecedente.Text = "Otros Antecedentes";

            if (oArregloAntecedentesGenerales.Count > 0)
                txtAntecedente.Text = oArregloAntecedentesGenerales[6].ToString().Trim();
            else
                txtAntecedente.Text = "";

            txtAntecedente.Tag = "6";

            Transition t = new Transition(new TransitionType_EaseInEaseOut(250));
            t.add(panelAntecedentes, "Top", -224);
            t.run();
        }

        #endregion

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(250));
            t.add(panelAntecedentes, "Top", 41);
            t.run();
        }

        private void CompruebaCambios_AntecedenteEspecifico()
        {
            if (lblNumExpediente.Text.Trim() != "")
            {
                if (oArregloAntecedentesGenerales.Count == 7)
                {
                    if (txtAntecedente.Text.Trim() != oArregloAntecedentesGenerales[Convert.ToInt32(txtAntecedente.Tag)].ToString().Trim())
                    {
                        tobGuardarAntecedentes.Enabled = true;
                        tobCancelarAntecedentes.Enabled = true;
                    }
                    else
                    {
                        tobGuardarAntecedentes.Enabled = false;
                        tobCancelarAntecedentes.Enabled = false;
                    }
                }
                else
                {
                    tobGuardarAntecedentes.Enabled = true;
                    tobCancelarAntecedentes.Enabled = true;
                }
            }
        }

        private void tobGuardarAntecedentes_Click(object sender, EventArgs e)
        {
            if (oArregloAntecedentesGenerales.Count == 0)
            {
                oCAntecedentesGenerales.Num_expediente = lblNumExpediente.Text.Trim();
                oCAntecedentesGenerales.Patologicos = "";
                oCAntecedentesGenerales.No_patologicos = "";
                oCAntecedentesGenerales.Familiares = "";
                oCAntecedentesGenerales.Quirurgicos = "";
                oCAntecedentesGenerales.Alergias = "";
                oCAntecedentesGenerales.Medicamentos = "";
                oCAntecedentesGenerales.Otros = "";

                oCAntecedentesGenerales.Insertar();

                for (int i = 0; i < 7; )
                {
                    oArregloAntecedentesGenerales.Add("");
                    i++;
                }
            }
            else
                oArregloAntecedentesGenerales[Convert.ToInt32(txtAntecedente.Tag)] = txtAntecedente.Text.Trim();

            oCAntecedentesGenerales.Num_expediente = lblNumExpediente.Text.Trim();
            oCAntecedentesGenerales.Patologicos = oArregloAntecedentesGenerales[0].ToString().Trim();
            oCAntecedentesGenerales.No_patologicos = oArregloAntecedentesGenerales[1].ToString().Trim();
            oCAntecedentesGenerales.Familiares = oArregloAntecedentesGenerales[2].ToString().Trim();
            oCAntecedentesGenerales.Quirurgicos = oArregloAntecedentesGenerales[3].ToString().Trim();
            oCAntecedentesGenerales.Alergias = oArregloAntecedentesGenerales[4].ToString().Trim();
            oCAntecedentesGenerales.Medicamentos = oArregloAntecedentesGenerales[5].ToString().Trim();
            oCAntecedentesGenerales.Otros = oArregloAntecedentesGenerales[6].ToString().Trim();

            if (oArregloAntecedentesGenerales.Count > 0)
                oCAntecedentesGenerales.Modificar();

            btnAtras_Click(sender, e);

            if (Program.oPersistencia.IsError == false)
            {
                oArregloAntecedentesGenerales[Convert.ToInt32(txtAntecedente.Tag)] = txtAntecedente.Text.Trim();
                tobGuardarAntecedentes.Enabled = false;
                tobCancelarAntecedentes.Enabled = false;
            }
        }

        private void tobCancelarAntecedentes_Click(object sender, EventArgs e)
        {
            txtAntecedente.Text = "";
            tobGuardarAntecedentes.Enabled = false;
            tobCancelarAntecedentes.Enabled = false;
        }

        private void txtAntecedente_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambios_AntecedenteEspecifico();
        }

        private void frmDetallePaciente_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                activo = true;
            else
                activo = false;

            if (this.Visible == false)
            {
                Program.oMDI.Activate();

                tabControl1.SelectedIndex = 0;
                numTab = 0;
            }
        }

        #region Antecedentes Obstétricos y Ginecológicos

        private bool VerificaValoresConcurrentesGesta()
        {
            int gesta = Convert.ToInt32(txtGesta.Text.Trim());

            int sumaValores = Convert.ToInt32(txtPara.Text.Trim()) +
                              Convert.ToInt32(txtGemelares.Text.Trim()) +
                              Convert.ToInt32(txtMolas.Text.Trim()) +
                              Convert.ToInt32(txtAbortos.Text.Trim()) +
                              Convert.ToInt32(txtCesareas.Text.Trim()) +
                              Convert.ToInt32(txtEctopicos.Text.Trim()) +
                              Convert.ToInt32(txtObitos.Text.Trim());

            if (sumaValores < gesta || sumaValores > gesta)
            {
                MessageBox.Show(this, "Los valores no coinciden con el total establecido en la gesta, los cuales deben coincidir con exactamente el mismo valor en la misma.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
                return true;
        }

        private void EstableceValorCero(Control oControl)
        {
            if (oControl.Text.Trim() == "")
            {
                oControl.Text = "0";
                ((TextBox)(oControl)).SelectAll();
            }
        }

        #region Eventos TextChanged

        private void txtGesta_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtGesta);

            if (lblAntecedente.Text.Trim() != "")
            {
                if (txtGesta.Text.Trim() == "0")
                {
                    dtFechaUltimoParto.Enabled = false;
                    txtComplicacionesUP.Enabled = false;
                    lblNoDisponible.Visible = true;
                }
                else
                {
                    dtFechaUltimoParto.Enabled = true;
                    txtComplicacionesUP.Enabled = true;
                    lblNoDisponible.Visible = false;
                }
            }
            else
                lblNoDisponible.Visible = false;
        }

        private void txtPara_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtPara);
        }

        private void txtGemelares_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtGemelares);
        }

        private void txtMolas_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtMolas);
        }

        private void txtAbortos_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtAbortos);
        }

        private void txtCesareas_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtCesareas);
        }

        private void txtEctopicos_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtEctopicos);
        }

        private void txtObitos_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtObitos);
        }

        private void BloqueaCampos_Gestas(int pOpcion)
        {
            if (pOpcion == 1)
            {
                txtGesta.Text = "0";
                txtPara.Text = "0";
                txtGemelares.Text = "0";
                txtMolas.Text = "0";
                txtAbortos.Text = "0";
                txtCesareas.Text = "0";
                txtEctopicos.Text = "0";
                txtObitos.Text = "0";

                txtGesta.Enabled = false;
                txtPara.Enabled = false;
                txtGemelares.Enabled = false;
                txtMolas.Enabled = false;
                txtAbortos.Enabled = false;
                txtCesareas.Enabled = false;
                txtEctopicos.Enabled = false;
                txtObitos.Enabled = false;
            }
            else if (pOpcion == 0)
            {
                txtGesta.Enabled = true;
                txtPara.Enabled = true;
                txtGemelares.Enabled = true;
                txtMolas.Enabled = true;
                txtAbortos.Enabled = true;
                txtCesareas.Enabled = true;
                txtEctopicos.Enabled = true;
                txtObitos.Enabled = true;
            }

            object sender = new object();
            EventArgs e = new EventArgs();

            txtGesta_TextChanged(sender, e);
        }

        private void txtMenarca_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtMenarca);

            if (txtMenarca.Text.Trim() == "0")
            {
                txtMenopausia.Enabled = false;
                txtMenopausia.Text = "0";
                txtCicloMenstrual.Enabled = false;
                txtCicloMenstrual.Text = "";
                cmbTipoCiclo.Enabled = false;
                cmbTipoCiclo.SelectedIndex = 2;
                txtDetalleTipoCiclo.Enabled = false;

                BloqueaCampos_Gestas(1);
            }
            else
            {
                txtMenopausia.Enabled = true;
                txtCicloMenstrual.Enabled = true;
                cmbTipoCiclo.Enabled = true;
                cmbTipoCiclo.SelectedIndex = 0;
                txtDetalleTipoCiclo.Enabled = true;

                BloqueaCampos_Gestas(0); 
            }
        }

        private void txtMenopausia_TextChanged(object sender, EventArgs e)
        {
            EstableceValorCero(txtMenopausia);
        }

        #endregion

        #region Eventos Enter Controles

        private void SeleccionaTexto(Control oControl)
        {
            ((TextBox)(oControl)).SelectAll();
        }

        private void txtGesta_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtGesta);
        }

        private void txtPara_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtPara);
        }

        private void txtGemelares_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtGemelares);
        }

        private void txtMolas_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtMolas);
        }

        private void txtAbortos_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtAbortos);
        }

        private void txtCesareas_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtCesareas);
        }

        private void txtEctopicos_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtEctopicos);
        }

        private void txtObitos_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtObitos);
        }

        private void txtMenarca_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtMenarca);
        }

        private void txtMenopausia_Enter(object sender, EventArgs e)
        {
            SeleccionaTexto(txtMenopausia);
        }

        #endregion

        private void DeshabilitaCamposAntecedentesObstetGinec()
        {
            txtGesta.Enabled = false;
            txtPara.Enabled = false;
            txtGemelares.Enabled = false;
            txtMolas.Enabled = false;
            txtAbortos.Enabled = false;
            txtCesareas.Enabled = false;
            txtEctopicos.Enabled = false;
            txtObitos.Enabled = false;

            dtFechaUltimoParto.Enabled = false;
            txtComplicacionesUP.Enabled = false;

            txtMenarca.Enabled = false;
            txtMenopausia.Enabled = false;
            txtCicloMenstrual.Enabled = false;
            cmbTipoCiclo.Enabled = false;
            txtDetalleTipoCiclo.Enabled = false;
        }

        private void HabilitaCamposAntecedentesObstetGinec()
        {
            txtGesta.Enabled = true;
            txtPara.Enabled = true;
            txtGemelares.Enabled = true;
            txtMolas.Enabled = true;
            txtAbortos.Enabled = true;
            txtCesareas.Enabled = true;
            txtEctopicos.Enabled = true;
            txtObitos.Enabled = true;

            dtFechaUltimoParto.Enabled = true;
            txtComplicacionesUP.Enabled = true;

            txtMenarca.Enabled = true;
            txtMenopausia.Enabled = true;
            txtCicloMenstrual.Enabled = true;
            cmbTipoCiclo.Enabled = true;
            txtDetalleTipoCiclo.Enabled = true;
        }

        private void LimpiaCamposAntecedentesObstetGinec()
        {
            txtGesta.Text = String.Empty;
            txtPara.Text = String.Empty;
            txtGemelares.Text = String.Empty;
            txtMolas.Text = String.Empty;
            txtAbortos.Text = String.Empty;
            txtCesareas.Text = String.Empty;
            txtEctopicos.Text = String.Empty;
            txtObitos.Text = String.Empty;

            dtFechaUltimoParto.Value = DateTime.Today;
            txtComplicacionesUP.Text = String.Empty;

            txtMenarca.Text = String.Empty;
            txtMenopausia.Text = String.Empty;
            txtCicloMenstrual.Text = String.Empty;
            cmbTipoCiclo.SelectedIndex = -1;
            txtDetalleTipoCiclo.Text = String.Empty;
        }

        private void btnGuardarAntecedObstetGinec_Click(object sender, EventArgs e)
        {
            //if (VerificaValoresConcurrentesGesta() == true)
            //{
                if (cmbTipoCiclo.SelectedIndex != -1 || cmbTipoCiclo.SelectedIndex == 2 && txtMenarca.Text.Trim() != "0")
                {
                    if (cmbTipoCiclo.SelectedIndex != 2 && txtMenarca.Text.Trim() == "0")
                    {
                        MessageBox.Show(this, "No puede establecer un tipo de ciclo si el valor de la menarca del paciente no ha sido establecida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    oCAntecedentes_ObstetGinec.Num_Expediente = lblNumExpediente.Text.Trim();
                    oCAntecedentes_ObstetGinec.Gesta = txtGesta.Text.Trim();
                    oCAntecedentes_ObstetGinec.Para = txtPara.Text.Trim();
                    oCAntecedentes_ObstetGinec.Abortos = txtAbortos.Text.Trim();
                    oCAntecedentes_ObstetGinec.Cesareas = txtCesareas.Text.Trim();
                    oCAntecedentes_ObstetGinec.Gemelares = txtGemelares.Text.Trim();
                    oCAntecedentes_ObstetGinec.Molas = txtMolas.Text.Trim();
                    oCAntecedentes_ObstetGinec.Ectopicos = txtEctopicos.Text.Trim();
                    oCAntecedentes_ObstetGinec.Obitos = txtObitos.Text.Trim();
                    oCAntecedentes_ObstetGinec.UltimoParto = dtFechaUltimoParto.Value;
                    oCAntecedentes_ObstetGinec.ComplicacionesUltimoParto = txtComplicacionesUP.Text.Trim();
                    oCAntecedentes_ObstetGinec.Menarca = txtMenarca.Text.Trim();
                    oCAntecedentes_ObstetGinec.Menopausia = txtMenopausia.Text.Trim();
                    oCAntecedentes_ObstetGinec.CicloMenstrual = txtCicloMenstrual.Text.Trim();
                    oCAntecedentes_ObstetGinec.TipoCiclo = cmbTipoCiclo.SelectedIndex.ToString().Trim();
                    oCAntecedentes_ObstetGinec.DetalleTipoCiclo = txtDetalleTipoCiclo.Text.Trim();

                    if (oArregloAntecedentesObstetGinec.Count == 0)
                        oCAntecedentes_ObstetGinec.Insertar();
                    else
                        oCAntecedentes_ObstetGinec.Modificar();

                    #region Limpia arreglo y reestablece nuevos datos

                    oArregloAntecedentesObstetGinec.Clear();

                    oArregloAntecedentesObstetGinec.Add(txtGesta.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtPara.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtAbortos.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtCesareas.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtGemelares.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtMolas.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtEctopicos.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtObitos.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(dtFechaUltimoParto.Value);
                    oArregloAntecedentesObstetGinec.Add(txtComplicacionesUP.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtMenarca.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtMenopausia.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(txtCicloMenstrual.Text.Trim());
                    oArregloAntecedentesObstetGinec.Add(cmbTipoCiclo.SelectedIndex);
                    oArregloAntecedentesObstetGinec.Add(txtDetalleTipoCiclo.Text.Trim());

                    #endregion

                    CompruebaCambiosRealizados_AntecedentesObstetGinec();

                    ///Actualiza los datos del paciente en la pantalla de consultas por aquello de datos como Amenorrea y otros...
                    Program.oFrmConsultas.TxtNumExpediente_TextChanged(sender, e);

                    Notificacion.mostrarVentana("Datos Actualizados!!!", "Los datos del paciente han sido actualizados para que pueda trabajar sin ningún problema.", Notificacion.Imagen.Soporte, 8);
                }
                else
                    MessageBox.Show(this, "Debe establecer un tipo de ciclo válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void CompruebaCambiosRealizados_AntecedentesObstetGinec()
        {
            if (lblNumExpediente.Text.Trim() != "")
            {
                if (txtMenarca.Text.Trim() == "" || txtMenarca.Text.Trim() == "0")
                    menarca = false;
                else
                    menarca = true;

                btnGuardarAntecedObstetGinec.Enabled = false;
                btnCancelarAntecedObstetGinec.Enabled = false;

                if (oArregloAntecedentesObstetGinec.Count == 15)
                {
                    if (txtGesta.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtGesta.Tag)].ToString().Trim() ||
                        txtPara.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtPara.Tag)].ToString().Trim() ||
                        txtAbortos.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtAbortos.Tag)].ToString().Trim() ||
                        txtCesareas.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtCesareas.Tag)].ToString().Trim() ||
                        txtGemelares.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtGemelares.Tag)].ToString().Trim() ||
                        txtMolas.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtMolas.Tag)].ToString().Trim() ||
                        txtEctopicos.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtEctopicos.Tag)].ToString().Trim() ||
                        txtObitos.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtObitos.Tag)].ToString().Trim() ||
                        dtFechaUltimoParto.Value != Convert.ToDateTime(oArregloAntecedentesObstetGinec[Convert.ToInt32(dtFechaUltimoParto.Tag)]) ||
                        txtComplicacionesUP.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtComplicacionesUP.Tag)].ToString().Trim() ||
                        txtMenarca.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtMenarca.Tag)].ToString().Trim() ||
                        txtMenopausia.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtMenopausia.Tag)].ToString().Trim() ||
                        txtCicloMenstrual.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtCicloMenstrual.Tag)].ToString().Trim() ||
                        cmbTipoCiclo.SelectedIndex.ToString() != oArregloAntecedentesObstetGinec[Convert.ToInt32(cmbTipoCiclo.Tag)].ToString().Trim() ||
                        txtDetalleTipoCiclo.Text != oArregloAntecedentesObstetGinec[Convert.ToInt32(txtDetalleTipoCiclo.Tag)].ToString().Trim())
                    {
                        btnGuardarAntecedObstetGinec.Enabled = true;
                        btnCancelarAntecedObstetGinec.Enabled = true;
                    }
                }
                else
                {
                    btnGuardarAntecedObstetGinec.Enabled = true;
                    btnCancelarAntecedObstetGinec.Enabled = false;
                }
            }
        }

        private void btnCancelarAntecedObstetGinec_Click(object sender, EventArgs e)
        {
            txtGesta.Text = oArregloAntecedentesObstetGinec[0].ToString().Trim();
            txtPara.Text = oArregloAntecedentesObstetGinec[1].ToString().Trim();
            txtAbortos.Text = oArregloAntecedentesObstetGinec[2].ToString().Trim();
            txtCesareas.Text = oArregloAntecedentesObstetGinec[3].ToString().Trim();
            txtGemelares.Text = oArregloAntecedentesObstetGinec[4].ToString().Trim();
            txtMolas.Text = oArregloAntecedentesObstetGinec[5].ToString().Trim();
            txtEctopicos.Text = oArregloAntecedentesObstetGinec[6].ToString().Trim();
            txtObitos.Text = oArregloAntecedentesObstetGinec[7].ToString().Trim();
            dtFechaUltimoParto.Value = Convert.ToDateTime(oArregloAntecedentesObstetGinec[8]);
            txtComplicacionesUP.Text = oArregloAntecedentesObstetGinec[9].ToString().Trim();
            txtMenarca.Text = oArregloAntecedentesObstetGinec[10].ToString().Trim();
            txtMenopausia.Text = oArregloAntecedentesObstetGinec[11].ToString().Trim();
            txtCicloMenstrual.Text = oArregloAntecedentesObstetGinec[12].ToString().Trim();
            cmbTipoCiclo.SelectedIndex = Convert.ToInt32(oArregloAntecedentesObstetGinec[13]);
            txtDetalleTipoCiclo.Text = oArregloAntecedentesObstetGinec[14].ToString().Trim();

            btnGuardarAntecedObstetGinec.Enabled = false;
            btnCancelarAntecedObstetGinec.Enabled = false;
        }

        #region Eventos KeyUp de Cajas de Texto

        private void txtGesta_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtPara_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtGemelares_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtMolas_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtAbortos_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtCesareas_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtEctopicos_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtObitos_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void dtFechaUltimoParto_ValueChanged(object sender, EventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtComplicacionesUP_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtMenarca_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtMenopausia_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtCicloMenstrual_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void cmbTipoCiclo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtMenarca.Text.Trim() != "0" && txtMenarca.Text.Trim() != "")
            {
                if (cmbTipoCiclo.SelectedIndex == 2)
                {
                    cmbTipoCiclo.SelectedIndex = 0;
                    MessageBox.Show(this, "El tipo de ciclo sólamente se catalogará como \"No Disponible\" cuando no se presente ningún valor en la Menarca del paciente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        private void txtDetalleTipoCiclo_KeyUp(object sender, KeyEventArgs e)
        {
            CompruebaCambiosRealizados_AntecedentesObstetGinec();
        }

        #endregion

        private void cmbTipoCiclo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Down) || e.KeyChar == Convert.ToChar(Keys.Up) || e.KeyChar == Convert.ToChar(Keys.Tab))
                e.Handled = false;
            else
                e.Handled = true;
        }

        #endregion

        private void DtFecha_Naci_ValueChanged(object sender, EventArgs e)
        {
            DateTime Fecha_Actual = DateTime.Now; //se declara una variable de tipo datetime y se le da el valor de la fecha actual
            DateTime Fecha_Nac; //se declara otra variable que va a ser la indicada por el usuario
            int Edad = 0;

            Fecha_Nac = Convert.ToDateTime(DtFecha_Naci.Value);
            Edad = Fecha_Actual.Year - Fecha_Nac.Year;

            if (new DateTime(Fecha_Actual.Year, Fecha_Nac.Month, Fecha_Nac.Day) > Fecha_Actual)
            {
                Edad--;
            }
            TxtEdad.Text = Edad.ToString();
        }

        public void CambiarOpcion(int pNumOpcion)
        {
            numTab = pNumOpcion;

            tabControl1.SelectedIndex = numTab;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnSalir_Click(sender, e);   
        }

        private void cmbTipoSangre_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompruebaCambiosRealizados_ExamenObservaciones();
        }

        private void rdRHPositivo_CheckedChanged(object sender, EventArgs e)
        {
            CompruebaCambiosRealizados_ExamenObservaciones();
        }

        private void rdRHNegativo_CheckedChanged(object sender, EventArgs e)
        {
            CompruebaCambiosRealizados_ExamenObservaciones();
        }

        private void cmbTipoSangre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnContactos_Click(object sender, EventArgs e)
        {
            if (lblNumExpediente.Text.Trim() != "")
            {
                if (groupContactos.Visible == true)
                    groupContactos.Visible = false;
                else
                    groupContactos.Visible = true;
            }
        }

    }
}