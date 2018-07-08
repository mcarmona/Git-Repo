using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using G_Clinic.Lógica_Negocios;
using G_Clinic.Miscelaneos_y_Recursos;
using Transitions;
using System.IO;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmHistorialConsultas : Form
    {
        #region Variables

        bool primeraVez = false;//Denota que se están cargando los datos del historial por 1era vez, por lo que si no se encuentran resultados

        public bool PrimeraVez
        {
            get { return primeraVez; }
            set { primeraVez = value; }
        }
        //no debería de mostrar ningún mensaje de nada...

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

        DataRow drGlobal = null;
        DataTable dt;
        SqlDataReader sqlDR = null;

        int fila = 0;
        int totalFilas = 0;
        int totalConsultasEncontradas = 0;

        string sqlWhere = "";
        public string SqlWhere
        {
            get { return sqlWhere; }
            set { sqlWhere = value; }
        }

        CExamenesConsulta oCExamenesConsulta = new CExamenesConsulta();
        CConsultaEmbarazo oCConsultaEmbarazo = new CConsultaEmbarazo();
        CGabineteConsulta oCGabineteConsulta = new CGabineteConsulta();

        public bool searching = false;

        int auxIniPos = 0;

        #endregion

        public frmHistorialConsultas()
        {
            InitializeComponent();

            try
            {
                VistaConstants.SetWindowTheme(lstGabineteConsulta.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstGabineteConsulta.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);

                VistaConstants.SetWindowTheme(lstExamenesConsulta.Handle, "explorer", null); //Explorer style
                VistaConstants.SendMessage(lstExamenesConsulta.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
            }
            catch { }

            this.Region = Shape.RoundedRegion(this.Size, 10, Shape.Corner.None);

            this.Left = ((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2);

            int top = 0;
            top = Screen.PrimaryScreen.WorkingArea.Height - this.Height - Program.oMDI.statusStrip1.Height - Program.oFrmDock.Height + 15;

            if (top < 0)
                top = 0;

            this.Top = top;

            LlenaComboMetodosAnticonceptivos();
        }

        public void LlenaComboMetodosAnticonceptivos()
        {
            cmbMetodoAnticonceptivo.DataSource = null;
            Metodos_Globales.LlenarCombo(cmbMetodoAnticonceptivo, "Sp_S_Metodos_Anticonceptivos", "Metodos_Anticonceptivos", "id_metodo", "descripcion");
        }

        private void frmHistorialConsultas_Load(object sender, EventArgs e)
        {
            auxIniPos = navigatePanel.Location.X;
        }

        private void Filtrar()
        {
            if (sqlWhere.CompareTo("") == 0)
            {
                sqlWhere = "num_expediente,";
                Program.oCConsultas.NumExpediente = Convert.ToInt32(numExpediente.Trim());
            }
        }

        public void Buscar()
        {
            sqlDR = null;
            dt = new DataTable();
            drGlobal = null;

            fila = 0;

            SqlCommand oCommand = new SqlCommand();
            oCommand.Connection = Program.oPersistencia.conexion;
            oCommand.CommandText = "sp_Historial_Consultas";
            oCommand.Parameters.AddWithValue("num_expediente", (object)NumExpediente.Trim());
            oCommand.Parameters.AddWithValue("condicion", (object)SqlWhere.Trim());
            oCommand.CommandType = CommandType.StoredProcedure;

            sqlDR = Program.oPersistencia.ejecutarConsultaSQL(oCommand);

            if (sqlDR != null)
            {
                if (sqlDR.HasRows == true)
                {
                    //ModoConsulta();

                    dt.Load(sqlDR, LoadOption.Upsert);

                    if (!Program.oPersistencia.IsError)
                    {
                        int uf = dt.Rows.Count - 1;

                        totalFilas = uf;
                        totalConsultasEncontradas = dt.Rows.Count;

                        if (dt.Rows.Count > 0)
                        {
                            if (fila < 0 || uf < 0)
                            {
                                tobPrimero.Enabled = false;
                                tobSiguiente.Enabled = false;
                                tobAnterior.Enabled = false;
                                tobUltimo.Enabled = false;

                                return;
                            }
                            else
                            {
                                tobPrimero.Enabled = true;
                                tobSiguiente.Enabled = true;
                                tobAnterior.Enabled = true;
                                tobUltimo.Enabled = true;
                            }

                            MostrarDatos(fila);
                        }
                    }
                }
                else
                {
                    if (primeraVez == false)
                        MessageBox.Show(this, "No se encontraron Consultas que coincidan con los parámetros de su búsqueda, por favor verifique los datos e intente de nuevo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //oFrmParamBusquedaConsulta.Activate();

                    LimpiarCampos();
                }
                sqlDR.Dispose();
                dt.Dispose();
            }
            else
                LimpiarCampos();
        }

        private void Centrar()
        {
            label1.Left = (panel1.Width - label1.Width) / 2;
        }

        private void LimpiarCampos()
        {
            lblNumConsulta.Text = "";
            lblFechaConsulta.Text = "";

            dtFUR.Value = DateTime.Today;
            txtAmenorrea.Text = String.Empty;
            txtDetalleMenstruacion.Text = String.Empty;

            cmbMetodoAnticonceptivo.SelectedIndex = -1;
            txtDetalleMetodoAnticonceptivo.Text = String.Empty;
            
            txtIMC.Text = String.Empty;
            txtPesoHabitual.Text = String.Empty;
            txtPresionArterial.Text = String.Empty;
            txtTalla.Text = String.Empty;

            richTextBox1.Text = String.Empty;
            richTextBox2.Text = String.Empty;
            richTextBox3.Text = String.Empty;

            lstExamenesConsulta.Items.Clear();
            lstGabineteConsulta.Items.Clear();

            txtDetalleAdicionalFUR_FPP.Text = "";
            TxtFrecuenciaCardiacaFetal.Text = "";

            rdSiMF.Checked = true;
            rdNoMF.Checked = false;

            txtAlturaUterina.Text = "";
            txtUltrasonido.Text = "";
            txtFUR.Text = "";
            txtFPP.Text = "";

            lblAmenorrea2.Text = "";

            softNet_AdobePDFViewer1.CloseDocument();

            Transition t4 = new Transition(new TransitionType_EaseInEaseOut(300));
            t4.add(Mainpanel, "Left", -1120);
            t4.run();

            Transition t5 = new Transition(new TransitionType_EaseInEaseOut(300));
            t5.add(navigatePanel, "Left", 468);
            t5.run();

            //softNet_AdobePDFViewer1.CloseDocument();
        }

        /// <summary>
        /// -1120, 0
        /// 468, 0
        /// </summary>
        /// <param name="pFila"></param>
        private void MostrarDatos(int pFila)
        {
            try
            {
                drGlobal = dt.Rows[pFila];

                if (drGlobal[0] != DBNull.Value)
                {
                    Transition t4 = new Transition(new TransitionType_EaseInEaseOut(300));
                    t4.add(Mainpanel, "Left", -1120);
                    t4.run();

                    Transition t5 = new Transition(new TransitionType_EaseInEaseOut(300));
                    t5.add(navigatePanel, "Left", 468);
                    t5.run();


                    lblNumConsulta.Text = drGlobal[0].ToString().Trim();
                    //TxtNumExpediente.Text = drGlobal[1].ToString().Trim();

                    //TxtNombre.Text = drGlobal[16].ToString().Trim() + " " + drGlobal[17].ToString().Trim();

                    //Falta el tipo de consulta
                    lblFechaConsulta.Text = Convert.ToDateTime(drGlobal[3]).ToLongDateString() + " a las " + Convert.ToDateTime(drGlobal[3]).ToLongTimeString();
                    //fechaConsulta = Convert.ToDateTime(drGlobal[3]);

                    //Min Date En SQL                
                    DateTime o = new DateTime(1753, 1, 1);//1/1/1753 12:00:00 AM 
                    if (Convert.ToDateTime(drGlobal[4]) == o)
                    {
                        panelCancelMenstruacion.Visible = true;
                        dtFUR.Value = Convert.ToDateTime(DateTime.Today);
                    }
                    else
                    {
                        panelCancelMenstruacion.Visible = false;
                        dtFUR.Value = Convert.ToDateTime(drGlobal[4]);
                    }

                    txtPesoHabitual.Text = drGlobal[7].ToString().Trim();
                    txtTalla.Text = drGlobal[8].ToString().Trim();
                    txtIMC.Text = drGlobal[9].ToString().Trim();
                    txtPresionArterial.Text = drGlobal[10].ToString().Trim();

                    if (drGlobal[2].ToString() == "0")//Tipo de Consulta SIN Embarazo
                    {
                        txtAmenorrea.Text = drGlobal[5].ToString().Trim();

                        Transition t3 = new Transition(new TransitionType_EaseInEaseOut(300));
                        t3.add(panelDatosEmbarazo, "Top", this.Size.Height + 300);
                        t3.run();

                        Transition t2 = new Transition(new TransitionType_EaseInEaseOut(300));
                        t2.add(panel2, "Top", 164);
                        t2.run();

                        txtDetalleMenstruacion.Text = drGlobal[6].ToString().Trim();

                        cmbMetodoAnticonceptivo.SelectedValue = drGlobal[11].ToString().Trim();
                        txtDetalleMetodoAnticonceptivo.Text = drGlobal[12].ToString().Trim();
                    }
                    else if (drGlobal[2].ToString() == "1")//Tipo de Consulta CON Embarazo
                    {

                        txtFUR.Text = Convert.ToDateTime(drGlobal[4]).ToLongDateString(); ;
                        lblAmenorrea2.Text = drGlobal[5].ToString().Trim();

                        Transition t = new Transition(new TransitionType_EaseInEaseOut(300));
                        t.add(panel2, "Top", this.Size.Height);
                        t.run();

                        Transition t2 = new Transition(new TransitionType_EaseInEaseOut(300));
                        t2.add(panelDatosEmbarazo, "Top", 164);
                        t2.run();

                        cmbMetodoAnticonceptivo.SelectedIndex = cmbMetodoAnticonceptivo.FindStringExact("Ninguno");
                        txtDetalleMetodoAnticonceptivo.Text = "";

                        oCConsultaEmbarazo.IdConsulta = Convert.ToInt64(lblNumConsulta.Text.Trim());

                        DataSet ds = oCConsultaEmbarazo.ConsultarSinParametros();

                        if (ds != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    //fechaInicialPeriodoEmbarazo = Convert.ToDateTime(dr[1]);
                                    txtFPP.Text = Convert.ToDateTime(dr[2]).ToLongDateString();
                                    txtDetalleAdicionalFUR_FPP.Text = dr[3].ToString().Trim();
                                    TxtFrecuenciaCardiacaFetal.Text = dr[4].ToString().Trim();

                                    if (Convert.ToBoolean(dr[5]) == true)
                                        rdSiMF.Checked = true;
                                    else
                                        rdNoMF.Checked = true;

                                    txtAlturaUterina.Text = dr[6].ToString().Trim();
                                    txtUltrasonido.Text = dr[7].ToString().Trim();
                                }
                            }
                            ds.Dispose();
                        }
                    }


                    //txtEditDetalleConsulta.Limpiar();
                    //txtEditTratamiento.Limpiar();
                    //txtEditDiagnostico.Limpiar();

                    string path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");

                    byte[] detalleConsulta = null;
                    detalleConsulta = (byte[])drGlobal[13];

                    byte[] tratamiento = null;
                    tratamiento = (byte[])drGlobal[14];

                    byte[] diagnostico = null;
                    diagnostico = (byte[])drGlobal[15];

                    Metodos_Globales.CreateTempFileFromByteArray(detalleConsulta, path + "\\Detalle_Consulta.rtf");
                    Metodos_Globales.CreateTempFileFromByteArray(tratamiento, path + "\\Tratamiento.rtf");
                    Metodos_Globales.CreateTempFileFromByteArray(diagnostico, path + "\\Diagnostico.rtf");

                    try
                    {
                        richTextBox1.LoadFile(path + "\\Detalle_Consulta.rtf", RichTextBoxStreamType.RichText);
                    }
                    catch
                    {
                        richTextBox1.LoadFile(path + "\\Detalle_Consulta.rtf", RichTextBoxStreamType.PlainText);
                    }

                    try
                    {
                        richTextBox2.LoadFile(path + "\\Diagnostico.rtf", RichTextBoxStreamType.RichText);
                    }
                    catch
                    {
                        richTextBox2.LoadFile(path + "\\Diagnostico.rtf", RichTextBoxStreamType.PlainText);
                    }

                    try
                    {
                        richTextBox3.LoadFile(path + "\\Tratamiento.rtf", RichTextBoxStreamType.RichText);
                    }
                    catch (Exception)
                    {
                        richTextBox3.LoadFile(path + "\\Tratamiento.rtf", RichTextBoxStreamType.PlainText);
                    }

                    richTextBox1.SelectAll();
                    richTextBox1.SelectionProtected = true;
                    richTextBox1.Select(0, 0);

                    richTextBox2.SelectAll();
                    richTextBox2.SelectionProtected = true;
                    richTextBox2.Select(0, 0);

                    richTextBox3.SelectAll();
                    richTextBox3.SelectionProtected = true;
                    richTextBox3.Select(0, 0);

                    LlenaListaExamenesConsulta();
                    LlenaListaGabineteConsulta();
                }
                else if (drGlobal["id_consulta2"] != DBNull.Value)
                {
                    Transition t4 = new Transition(new TransitionType_EaseInEaseOut(300));
                    t4.add(Mainpanel, "Left", 41);
                    t4.run();

                    Transition t5 = new Transition(new TransitionType_EaseInEaseOut(300));
                    t5.add(navigatePanel, "Left", 609);
                    t5.run();

                    string path = Path.GetTempFileName();

                    byte[] documento = null;
                    string detalle_adicional = "";

                    detalle_adicional = drGlobal["detalle_adicional2"].ToString().Trim();
                    documento = (byte[])drGlobal["detalle_consulta2"];

                    lblFecha2.Text = Convert.ToDateTime(drGlobal["fecha_consulta2"]).ToLongDateString();
                    txtDetalleAdicional.Text = detalle_adicional;

                    File.Move(path, System.IO.Path.ChangeExtension(path, ".pdf"));
                    path = System.IO.Path.ChangeExtension(path, ".pdf");
                    System.IO.File.WriteAllBytes(path, documento);

                    softNet_AdobePDFViewer1.FileLocation = path;
                    softNet_AdobePDFViewer1.OpenDocument();
                }
                else
                {
                    Transition t4 = new Transition(new TransitionType_EaseInEaseOut(300));
                    t4.add(Mainpanel, "Left", -1120);
                    t4.run();

                    Transition t5 = new Transition(new TransitionType_EaseInEaseOut(300));
                    t5.add(navigatePanel, "Left", 468);
                    t5.run();
                }
            }
            catch { }
        }

        //private void MostrarDatos(int pFila)
        //{
        //    try
        //    {
        //        drGlobal = dt.Rows[pFila];

        //        lblNumConsulta.Text = drGlobal[0].ToString().Trim();
        //        //TxtNumExpediente.Text = drGlobal[1].ToString().Trim();
        //        //TxtNombre.Text = drGlobal[16].ToString().Trim() + " " + drGlobal[17].ToString().Trim();

        //        //Falta el tipo de consulta
        //        lblFechaConsulta.Text = Convert.ToDateTime(drGlobal[3]).ToLongDateString() + " a las " + Convert.ToDateTime(drGlobal[3]).ToLongTimeString();
        //        //fechaConsulta = Convert.ToDateTime(drGlobal[3]);

        //        //Min Date En SQL
        //        DateTime o = new DateTime(1753, 1, 1);//1/1/1753 12:00:00 AM 
        //        if (Convert.ToDateTime(drGlobal[4]) == o)
        //        {
        //            panelCancelMenstruacion.Visible = true;
        //            dtFUR.Value = Convert.ToDateTime(DateTime.Today);

        //            dtFUR.Enabled = false;
        //            txtAmenorrea.Enabled = false;
        //            txtDetalleMenstruacion.Enabled = false;
        //        }
        //        else
        //        {
        //            panelCancelMenstruacion.Visible = false;
        //            dtFUR.Value = Convert.ToDateTime(drGlobal[4]);

        //            dtFUR.Enabled = true;
        //            txtAmenorrea.Enabled = true;
        //            txtDetalleMenstruacion.Enabled = true;
        //        }

        //        txtAmenorrea.Text = drGlobal[5].ToString().Trim();
        //        txtDetalleMenstruacion.Text = drGlobal[6].ToString().Trim();

        //        txtPesoHabitual.Text = drGlobal[7].ToString().Trim();
        //        txtTalla.Text = drGlobal[8].ToString().Trim();
        //        txtIMC.Text = drGlobal[9].ToString().Trim();
        //        txtPresionArterial.Text = drGlobal[10].ToString().Trim();

        //        cmbMetodoAnticonceptivo.SelectedValue = drGlobal[11].ToString().Trim();
        //        txtDetalleMetodoAnticonceptivo.Text = drGlobal[12].ToString().Trim();

        //        string path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic\\TempFiles");

        //        byte[] detalleConsulta = null;
        //        detalleConsulta = (byte[])drGlobal[13];

        //        byte[] tratamiento = null;
        //        tratamiento = (byte[])drGlobal[14];

        //        byte[] diagnostico = null;
        //        diagnostico = (byte[])drGlobal[15];

        //        Metodos_Globales.CreateTempFileFromByteArray(detalleConsulta, path + "\\Detalle_Consulta.rtf");
        //        Metodos_Globales.CreateTempFileFromByteArray(tratamiento, path + "\\Tratamiento.rtf");
        //        Metodos_Globales.CreateTempFileFromByteArray(diagnostico, path + "\\Diagnostico.rtf");

        //        richTextBox1.LoadFile(path + "\\Detalle_Consulta.rtf", RichTextBoxStreamType.RichText);
        //        richTextBox2.LoadFile(path + "\\Diagnostico.rtf", RichTextBoxStreamType.RichText);
        //        richTextBox3.LoadFile(path + "\\Tratamiento.rtf", RichTextBoxStreamType.RichText);

        //        richTextBox1.SelectAll();
        //        richTextBox1.SelectionProtected = true;
        //        richTextBox1.Select(0, 0);

        //        richTextBox2.SelectAll();
        //        richTextBox2.SelectionProtected = true;
        //        richTextBox2.Select(0, 0);

        //        richTextBox3.SelectAll();
        //        richTextBox3.SelectionProtected = true;
        //        richTextBox3.Select(0, 0);

        //        LlenaListaExamenesConsulta();
        //        LlenaListaGabineteConsulta();
        //    }
        //    catch { }
        //}

        private void LlenaListaGabineteConsulta()
        {
            try
            {
                lstGabineteConsulta.Items.Clear();

                DataSet ds = oCGabineteConsulta.ConsultarSinParametros(lblNumConsulta.Text.Trim());

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int linea = 0;

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            lstGabineteConsulta.Items.Add(dr[0].ToString().Trim());
                            lstGabineteConsulta.Items[linea].SubItems.Add(dr[6].ToString().Trim());
                            lstGabineteConsulta.Items[linea].SubItems.Add(dr[2].ToString().Trim());
                            lstGabineteConsulta.Items[linea].SubItems.Add(Convert.ToDateTime(dr[4]).ToShortDateString());
                            lstGabineteConsulta.Items[linea].SubItems.Add(dr[5].ToString().Trim());

                            linea++;
                        }
                    }
                    ds.Dispose();
                    oCGabineteConsulta.ConsultarSinParametros(lblNumConsulta.Text.Trim()).Dispose();
                }
            }
            catch { }
        }

        private void LlenaListaExamenesConsulta()
        {
            try
            {
                lstExamenesConsulta.Items.Clear();

                DataSet ds = oCExamenesConsulta.ConsultarSinParametros(lblNumConsulta.Text.Trim());

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int linea = 0;

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            lstExamenesConsulta.Items.Add(dr[0].ToString().Trim());
                            lstExamenesConsulta.Items[linea].SubItems.Add(dr[6].ToString().Trim());
                            lstExamenesConsulta.Items[linea].SubItems.Add(dr[2].ToString().Trim());
                            lstExamenesConsulta.Items[linea].SubItems.Add(Convert.ToDateTime(dr[4]).ToShortDateString());
                            lstExamenesConsulta.Items[linea].SubItems.Add(dr[5].ToString().Trim());

                            linea++;
                        }
                    }
                    ds.Dispose();
                    oCExamenesConsulta.ConsultarSinParametros(lblNumConsulta.Text.Trim()).Dispose();
                }
            }
            catch { }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (Program.oFrmExamenesConsulta != null && Program.oFrmDetallePaciente != null && Program.oFrmImagenesConsultas != null &&
                Program.oFrmVideosConsulta != null && Program.oFrmEmbarazos != null)
            {
                if (Program.oFrmExamenesConsulta.Activo == false && Program.oFrmDetallePaciente.Activo == false &&
                    Program.oFrmImagenesConsultas.Activo == false && Program.oFrmVideosConsulta.Activo == false &&
                    Program.oFrmEmbarazos.Activo == false)
                {
                    EventArgs e2 = new EventArgs();
                    Program.oFrmDock.frmDock_MouseLeave(sender, e2);
                }
            }
        }

        private void btnDetalleConsulta_Click(object sender, EventArgs e)
        {
            label1.Text = "Detalle de Consulta";
            Centrar();

            richTextBox1.Visible = true;
            richTextBox2.Visible = false;
            richTextBox3.Visible = false;
        }

        private void btnDiagnostico_Click(object sender, EventArgs e)
        {
            label1.Text = "Diagnóstico";
            Centrar();

            richTextBox1.Visible = false;
            richTextBox2.Visible = true;
            richTextBox3.Visible = false;
        }

        private void btnTratamiento_Click(object sender, EventArgs e)
        {
            label1.Text = "Tratamiento";
            Centrar();

            richTextBox3.Visible = true;
            richTextBox2.Visible = false;
            richTextBox1.Visible = false;
        }

        private void tobPrimero_Click(object sender, EventArgs e)
        {            
            fila = 0;
            MostrarDatos(0);
        }

        private void tobAnterior_Click(object sender, EventArgs e)
        {
            fila = fila - 1;
            if (fila < 0)
                fila = 0;

            MostrarDatos(fila);
        }

        private void tobSiguiente_Click(object sender, EventArgs e)
        {
            fila += 1;

            if (fila > totalFilas)
                fila = totalFilas;

            MostrarDatos(fila);
        }

        private void tobUltimo_Click(object sender, EventArgs e)
        {
            fila = totalFilas;
            MostrarDatos(fila);
        }

        private void frmHistorialConsultas_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                activo = true;
            else
            {
                activo = false;
                Program.oMDI.Activate();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            fila = 0;

            frmConsultasHistorialConsultas ofrmConsultasHistorialConsultas = new frmConsultasHistorialConsultas();
            ofrmConsultasHistorialConsultas.ShowDialog(Program.oFrmHistorialConsultas);

            if (sqlWhere != "")
            {
                searching = true;

                Buscar();

                if (totalConsultasEncontradas > 0)
                {
                    btnConsultar.Visible = false;
                    btnConsultar2.Visible = false;
                    btnMostrarTodos.Visible = true;
                    btnMostrarTodos2.Visible = true;
                }
            }
        }

        public void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            sqlWhere = "";
            Buscar();

            btnConsultar.Visible = true;
            btnMostrarTodos.Visible = false;
            btnConsultar2.Visible = true;
            btnMostrarTodos2.Visible = false;

            //searching = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnSalir_Click(sender, e);
        }

        private void btnConsultar2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarConsultaAntigua_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(NumExpediente.Trim()))
            {
                if (!String.IsNullOrEmpty(SqlWhere))
                    if (MessageBox.Show(this, "Estas acciones harán que el filtro de búsqueda utilizado actualmente se reinicie y se mostrarán todos los registros existentes sin ningún filtro aplicado. ¿Desea continuar con estas acciones?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                        return;

                frmConsultasAntiguas ofrmConsultasAntiguas = new frmConsultasAntiguas(Convert.ToInt32(NumExpediente.Trim()));
                ofrmConsultasAntiguas.ShowDialog();

                btnMostrarTodos_Click(sender, e);
            }
        }

        private void btnConsultar2_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void CursorPos(int pIniPos, int pFinalPos)
        {
            int xPos = 0;
            if (pIniPos < pFinalPos)
            {
                xPos = pFinalPos - pIniPos;
                Cursor.Position = new Point(Cursor.Position.X + xPos, Cursor.Position.Y);
            }
            else if (pIniPos > pFinalPos)
            {
                xPos = pIniPos - pFinalPos;
                Cursor.Position = new Point(Cursor.Position.X - xPos, Cursor.Position.Y);
            }
        }

        private void navigatePanel_LocationChanged(object sender, EventArgs e)
        {
            CursorPos(auxIniPos, navigatePanel.Location.X);

            auxIniPos = navigatePanel.Location.X;
        }

        private void tobCopy_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Visible == true)
            {
                richTextBox1.SelectAll();
                richTextBox1.SelectionProtected = false;
                richTextBox1.Copy();
                richTextBox1.Select(0, 0);
                richTextBox1.SelectionProtected = true;
            }
            else if (richTextBox2.Visible == true)
            {
                richTextBox2.SelectAll();
                richTextBox2.SelectionProtected = false;
                richTextBox2.Copy();
                richTextBox2.Select(0, 0);
                richTextBox2.SelectionProtected = true;
            }
            else if (richTextBox3.Visible == true)
            {
                richTextBox3.SelectAll();
                richTextBox3.SelectionProtected = false;
                richTextBox3.Copy();
                richTextBox3.Select(0, 0);
                richTextBox3.SelectionProtected = true;
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Visible == true)
            {
                richTextBox1.SelectionProtected = false;
                richTextBox1.Copy();
                richTextBox1.Select(0, 0);
                richTextBox1.SelectionProtected = true;
            }
            else if (richTextBox2.Visible == true)
            {
                richTextBox2.SelectionProtected = false;
                richTextBox2.Copy();
                richTextBox2.Select(0, 0);
                richTextBox2.SelectionProtected = true;
            }
            else if (richTextBox3.Visible == true)
            {
                richTextBox3.SelectionProtected = false;
                richTextBox3.Copy();
                richTextBox3.Select(0, 0);
                richTextBox3.SelectionProtected = true;
            }
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Visible == true)
                richTextBox1.SelectAll();
            else if (richTextBox2.Visible == true)
                richTextBox2.SelectAll();
            else if (richTextBox3.Visible == true)
                richTextBox3.SelectAll();
        }
    }
}