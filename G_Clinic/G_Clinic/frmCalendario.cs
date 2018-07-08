using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.Calendar;
using System.Data.SqlClient;
using G_Clinic.Miscelaneos_y_Recursos;
using G_Clinic.Lógica_Negocios;
using Transitions;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmCalendario : Form
    {
        public frmCalendario()
        {
            InitializeComponent();

            monthView1.Region = Shape.RoundedRegion(monthView1.Size, 6, Shape.Corner.None);
            lblFecha1.Visible = false;
        }

        #region Variables

        CCitas oCCitas = new CCitas();
        CPacientes oCPacientes = new CPacientes();
        CEmail oCEmail = new CEmail();

        VScrollBar vScrollBar = new VScrollBar();

        ArrayList oArregloTextoRecordatorios = new ArrayList();
        ArrayList oArregloTagRecordatorios = new ArrayList();
        ArrayList oArregloResumenRecordatorios = new ArrayList();

        List<CalendarItem> itemsCitas = new List<CalendarItem>();//Generamos una lista de los ítems que ingresaremos al calendario
        CalendarItem contextItem = null;

        string auxTagRecordatorio = "";

        /// <summary>
        /// True = Paciente Nuevo
        /// False = Paciente Existente        
        /// </summary>
        bool tipoPaciente = false;
        bool itemSeleccionado = false;

        public string idCitaSeleccionada = "";
        CalendarItem oItem = null;

        bool permisoEliminar = false;

        int globalX = 0;
        int globalY = 0;

        int index = 0;

        #endregion

        #region Modos

        bool nuevo = false;//Modo al que ingresará la aplicación cuando se va a ingresar una nueva cita
        bool modificar = false;//Modo al que ingresará la aplicación cuando se va a modificar una cita existente

        #endregion

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

        /// <summary>
        /// Sobreescribimos el método CreateParams para minimizar el parpadeo del form
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public void tobNuevaCita_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(100));
            t.add(panelPaneles, "Left", 0);
            t.run();

            tobNuevaCita.Enabled = false;
            toolStripStatusLabel2.Text = "Modo:";
            toolStripStatusLabel3.Text = "Nuevo Ingreso";

            //this.tableLayoutPanel1.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 0f);

            oCalendario.TimeScale = oTimeScale();

            monthView1.Enabled = false;
            nuevo = true;
            DesbloquearCampos();
            InicializarCampos();
            dtFechaCita_ValueChanged(sender, e);
            dtFechaCita.Value = new DateTime(dtFechaCita.Value.Year, dtFechaCita.Value.Month, dtFechaCita.Value.Day,
                                             dtFechaCita.Value.Hour, dtFechaCita.Value.Minute, 0);
        }

        private void Agrega_CargaEventosCalendario()
        {
            #region Eventos del Calendario

            oCalendario.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(oCalendario_ItemDoubleClick);
            oCalendario.DayHeaderClick += new System.Windows.Forms.Calendar.Calendar.CalendarDayEventHandler(oCalendario_DayHeaderClick);
            oCalendario.ItemCreating += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(oCalendario_ItemCreating);
            oCalendario.ItemCreated += new Calendar.CalendarItemCancelEventHandler(oCalendario_ItemCreated);
            oCalendario.ItemMouseHover += new Calendar.CalendarItemEventHandler(oCalendario_ItemMouseHover);
            oCalendario.ItemMouseLeave += new Calendar.CalendarItemEventHandler(oCalendario_ItemMouseLeave);
            oCalendario.LoadItems += new Calendar.CalendarLoadEventHandler(oCalendario_LoadItems);
            oCalendario.ViewRangeChanged += new CancelEventHandler(oCalendario_ViewRangeChanged);
            oCalendario.ItemSelected += new Calendar.CalendarItemEventHandler(oCalendario_ItemSelected);
            oCalendario.MouseEnter += new EventHandler(oCalendario_MouseEnter);
            oCalendario.MouseLeave += new EventHandler(oCalendario_MouseLeave);
            oCalendario.OverFlowMouseHover += new Calendar.CalendarDayEventHandler(oCalendario_OverFlowMouseHover);
            oCalendario.OverFlowMouseLeave += new Calendar.CalendarDayEventHandler(oCalendario_OverFlowMouseLeave);
            oCalendario.ItemDeleting += new Calendar.CalendarItemCancelEventHandler(oCalendario_ItemDeleting);

            #endregion

            #region Establecemos las horas que se verán resaltadas en los días del calendario existente

            TimeSpan oTimeSpanInicio = new TimeSpan(Program.oCCitas.HoraInicial.Hour, Program.oCCitas.HoraInicial.Minute, 0);
            TimeSpan oTimeSpanFinal = new TimeSpan(Program.oCCitas.HoraFinal.Hour, Program.oCCitas.HoraFinal.Minute, 0);

            oCalendario.HighlightRanges = new CalendarHighlightRange[] {
                new CalendarHighlightRange( DayOfWeek.Monday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Tuesday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Wednesday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Thursday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Friday, oTimeSpanInicio, oTimeSpanFinal)
            };

            #endregion

            #region Asignamos Propiedades al Calendario y a otros controles y lo agregamos al Panel correspondiente

            oCalendario.Dock = DockStyle.Fill;
            oCalendario.Visible = true;
            oCalendario.Show();

            oCalendario.TimeScale = oTimeScale();

            oCalendario.MaximumViewDays = 35;

            panel3.Controls.Add(oCalendario);

            grouper1.Parent = oCalendario;//Establecemos como parent al calendario para el control Grouper para establecer la transparencia total
            grouperTimeScale.Parent = oCalendario;//Establecemos como parent al calendario para el control Grouper para establecer la transparencia total

            monthView1.SelectionStart = PrimerDiaDelMes(System.DateTime.Today);
            DateTime fecha = new DateTime();
            fecha = DateTime.Today;
            fecha = new DateTime(fecha.Year, fecha.Month, DateTime.DaysInMonth(fecha.Year, fecha.Month));
            monthView1.SelectionEnd = new DateTime(fecha.Year, fecha.Month, DateTime.DaysInMonth(fecha.Year, fecha.Month));   //  UltimoDiaDelMes(System.DateTime.Today);

            #endregion

            index = 0;

            double duration = Convert.ToDouble((int)oCalendario.TimeScale);
            index = Convert.ToInt32(Math.Floor(oTimeSpanInicio.TotalMinutes / duration));

            oItem = new CalendarItem(oCalendario);
        }

        private void oCalendario_ItemDeleting(object sender, CalendarItemCancelEventArgs e)
        {
            if (permisoEliminar == false)
                //Cancelamos la eliminación de los ítems directamente desde el calendario mediante la tecla DEL o SUPR
                e.Cancel = true;
        }

        private void oCalendario_OverFlowMouseLeave(object sender, CalendarDayEventArgs e)
        {
            toolStripStatusLabel4.Visible = false;
        }

        private void oCalendario_OverFlowMouseHover(object sender, CalendarDayEventArgs e)
        {
            toolStripStatusLabel4.Visible = true;
        }

        private void oCalendario_MouseLeave(object sender, EventArgs e)
        {
            //Inicializamos el timer para contar el tiempo en que deberá cerrarse un detalle de un ítem en caso de que haya uno abierto
            //y el cursor ya no está dentro de los márgenes del calendario
            timer1.Start();
        }

        private void oCalendario_MouseEnter(object sender, EventArgs e)
        {
            //if (grouper1.Visible == true)
            //    grouper1.Visible = false;

            //throw new Exception("The method or operation is not implemented.");
        }

        private void oCalendario_ItemSelected(object sender, CalendarItemEventArgs e)
        {
            idCitaSeleccionada = e.Item.Tag.ToString().Trim();
            oItem = e.Item;

            if (nuevo == false)
                LlenarDatosModoModificar(e.Item.Tag.ToString().Trim());
            //e.Item.
            //throw new Exception("The method or operation is not implemented.");
        }

        private void oCalendario_ViewRangeChanged(object sender, CancelEventArgs e)
        {
            //Verificamos si el calendario está en modo de un solo día, si SÍ entonces asignamos el resumen de los recordatorios
            //a cada uno de los ítems del calendario mediante el ArrayList oArregloResumenRecordatorios, siguiendo el índice de 
            //las cadenas presentes en el mismo.
            if (oCalendario.DaysMode == CalendarDaysMode.Expanded)
            {
                int Contador = 0;

                foreach (CalendarItem oItem in itemsCitas)
                {
                    oItem.Text = oArregloResumenRecordatorios[Contador].ToString().Trim();
                    Contador++;
                }
            }
            else
            {
                //Si está en vista de mes eliminamos el texto de todos los ítems para que sólamente se muestre la hora de cada ítem
                //y no haya desbordamiento de texto.
                foreach (CalendarItem oItem in itemsCitas)
                {
                    oItem.Text = "";
                }
            }
        }

        private void oCalendario_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            ColocarItems();//Coloca los ítems creados en el calendario
        }

        private void oCalendario_ItemMouseLeave(object sender, CalendarItemEventArgs e)
        {
            //Evento que se produce cuando el cursor abandona el área de un ítem del calendario, para ocultar el mensaje con el detalle
            //de la cita correspondiente al ítem sobre el cual se estaba posicionado
            if (grouper1.Visible == true)
                grouper1.Visible = false;
        }

        /// <summary>
        /// Método que devuelve la posición del grouper para que este no sea vea cortado
        /// </summary>
        /// <param name="PosicionItemY"></param>
        /// <param name="AlturaItem"></param>
        /// <param name="PosicionItemX"></param>
        /// <param name="AnchoItem"></param>
        /// <returns></returns>
        private Point CalcularPosicionGrouper(int PosicionItemY, int AlturaItem, int PosicionItemX, int AnchoItem)
        {
            Point posicionGrouper = new Point();

            int AlturaCalendario = oCalendario.Size.Height;
            int AnchoCalendario = oCalendario.Size.Width;
            int AlturaGrouper = grouper1.Size.Height;
            int AnchoGrouper = grouper1.Size.Width;

            //Establece la posición X del control
            if ((PosicionItemX + grouper1.Width > AnchoCalendario))
            {
                posicionGrouper.X = PosicionItemX - (AnchoItem * 2);
            }
            else
                posicionGrouper.X = grouper1.Location.X;

            //Establece la posición Y del control
            if ((PosicionItemY + grouper1.Location.Y) > AlturaCalendario)
                posicionGrouper.Y = (PosicionItemY - grouper1.Size.Height);
            else
                posicionGrouper.Y = grouper1.Location.Y;

            return posicionGrouper;
        }

        /// <summary>
        /// Evento que se dispara cuando el cursor del mouse se encuentra dentro de los márgenes de un ítem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oCalendario_ItemMouseHover(object sender, CalendarItemEventArgs e)
        {
            if (e.Item.Tag.ToString() != "")// Verificamos que el tag o etiqueta del ítem no sea nula, ya que esta funcionará como la clave 
            //para llamar los datos correspondientes
            {
                if (auxTagRecordatorio != e.Item.Tag.ToString().Trim())
                {
                    auxTagRecordatorio = e.Item.Tag.ToString().Trim();
                    grouper1.Visible = false;
                }

                if (grouper1.Visible == false)
                {
                    int Contador = 0;

                    //Seleccionamos el índice del tag dentro dentro del arreglo oArregloTagRecordatorios que contiene todos los tags de todos los ítems
                    Contador = oArregloTagRecordatorios.IndexOf(e.Item.Tag.ToString().Trim());

                    //foreach (string oTag in oArregloTagRecordatorios)
                    //{
                    //    if (oTag.Trim() == e.Item.Tag.ToString().Trim())
                    //    {
                    //        break;
                    //    }
                    //    else
                    //        Contador++;
                    //}

                    //Igualamos el detalle del grouper o mensaje al arreglo de detalles oArregloTextoRecordatorios en la posición del contador
                    //ya que van acordes ya que se ingresan al mismo tiempo en el mismo slot por así decirlo
                    lblDetalleCita.Text = oArregloTextoRecordatorios[Contador].ToString().Trim();

                    pictPrioridad.Image = e.Item.Image;

                    //Verificamos el color del ítem para determinar la imagen, color y prioridad del mensaje(grouper)
                    if (e.Item.BackgroundColor == Color.Red)
                    {
                        lblPrioridad.Text = "Alta";
                        pictPrioridad.Image = recursos.Alta;
                        grouper1.BackgroundGradientColor = e.Item.BackgroundColor;
                    }
                    else if (e.Item.BackgroundColor == Color.Yellow)
                    {
                        lblPrioridad.Text = "Media";
                        pictPrioridad.Image = recursos.Media;
                        grouper1.BackgroundGradientColor = e.Item.BackgroundColor;
                    }
                    else
                    {
                        lblPrioridad.Text = "Normal";
                        pictPrioridad.Image = recursos.Normal;
                        grouper1.BackgroundGradientColor = Color.LightSteelBlue;
                    }

                    Point oPosicion = new Point(e.Item.Bounds.Location.X, e.Item.Bounds.Location.Y + 15);

                    grouper1.Location = oPosicion;

                    //Después de establecer la posición original de mensaje se verifica la misma mediante el método CalcularPosicionGrouper
                    //en caso de que se provoque el desbordamiento del mensaje dentro de los márgenes del calendario
                    grouper1.Location = CalcularPosicionGrouper(e.Item.Bounds.Location.Y, e.Item.Bounds.Height, e.Item.Bounds.Location.X, e.Item.Bounds.Width);   //.Location = oPosicion;

                    grouper1.Visible = true;
                }
            }
            else
                grouper1.Visible = false;
        }

        private void oCalendario_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            itemsCitas.Add(e.Item);//Agregamos los ítems al calendario
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(monthView1.SelectionStart).Day == Convert.ToDateTime(monthView1.SelectionEnd).Day)
                    vScrollBar.Visible = true;
                else
                    vScrollBar.Visible = false;

                oCalendario.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);

                oCalendario.TimeUnitsOffset = index * (-1);

                if (tobSelecMensual.Checked == true)
                    lblFecha1.Text = Metodos_Globales.NombreDelMes(Convert.ToInt32(monthView1.SelectionStart.Date.Month)) + " del " + monthView1.SelectionEnd.Date.Year.ToString();
                else if (tobSelecManual.Checked == true)
                {
                    if (monthView1.SelectionStart.Date == monthView1.SelectionEnd.Date)
                        lblFecha1.Text = monthView1.SelectionStart.Date.ToLongDateString();
                    else
                        lblFecha1.Text = "Del " + monthView1.SelectionStart.Date.ToShortDateString() + "  al  " + monthView1.SelectionEnd.Date.ToShortDateString();
                }
            }
            catch { }
        }

        public CalendarTimeScaleUnit GetTimeUnit(CalendarDay day)
        {
            return day.TimeUnits[index];
        }

        private void oCalendario_DayHeaderClick(object sender, System.Windows.Forms.Calendar.CalendarDayEventArgs e)
        {
            oCalendario.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);

            oCalendario.TimeScale = oTimeScale();

            oCalendario.EnsureVisible(GetTimeUnit(e.CalendarDay));//.AutoScrollPosition = new Point(0, 150); 
            monthView1.SelectionMode = MonthView.MonthViewSelection.Month;

            lblFecha1.Text = e.CalendarDay.Date.ToLongDateString();
        }

        public void oCalendario_ItemDoubleClick(object sender, System.Windows.Forms.Calendar.CalendarItemEventArgs e)
        {
            if (idCitaSeleccionada.Trim() != "")
            {
                if (e.Item.Pattern == System.Drawing.Drawing2D.HatchStyle.DiagonalCross)
                    MessageBox.Show(this, "La cita no podrá ser modificada ya que es una cita previa a la fecha actual, proceda a generar una nueva cita en lugar de estas acciones.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                else
                {
                    toolStripStatusLabel2.Text = "Modo:";
                    toolStripStatusLabel3.Text = "Modificación";

                    //this.tableLayoutPanel1.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 0f);

                    oCalendario.TimeScale = oTimeScale();

                    monthView1.Enabled = false;

                    nuevo = false;
                    modificar = true;

                    //LlenarDatosModoModificar(e.Item.Tag.ToString().Trim());

                    DesbloquearCampos();
                }
            }
        }

        private void oCalendario_ItemCreating(object sender, System.Windows.Forms.Calendar.CalendarItemCancelEventArgs e)
        {
            e.Cancel = true;
        }

        public DateTime PrimerDiaDelMes(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public DateTime UltimoDiaDelMes(DateTime dateTime)
        {
            DateTime PrimerDiaDelMes = new DateTime(dateTime.Year, dateTime.Month, 1);
            return PrimerDiaDelMes.AddMonths(1).AddDays(-1);
        }

        private void LlenaComboDoctores()
        {
            cmbDoctores.DataSource = null;
            Metodos_Globales.LlenarCombo(cmbDoctores, "Select id_emp, nombre from Empleados where id_categoria_emp = 1", "Empleados", "id_emp", "nombre");
        }

        private void BloquearCampos()
        {
            cmbDoctores.Enabled = false;

            txtNumExpediente.Enabled = false;
            txtNombrePacienteExistente.Enabled = false;
            txtNombrePacienteNuevo.Enabled = false;
            txtContacto1.Enabled = false;
            txtContacto2.Enabled = false;
            tobBuscarPaciente.Enabled = false;
            btnListo1.Enabled = false;
            btnListo2.Enabled = false;

            dtFechaCita.Enabled = false;
            dateTimePicker1.Enabled = false;
            numericUDHoras.Enabled = false;
            numericUDMinutos.Enabled = false;
            txtDetalle.Enabled = false;
            rdNormal.Enabled = false;
            rdMedia.Enabled = false;
            rdAlta.Enabled = false;
            btnGuardarCita.Enabled = false;
            btnCancelarCita.Enabled = false;
            tobBuscarPaciente.Enabled = false;

            checkBoxPrioridadCita.Enabled = false;
        }

        private void DesbloquearCampos()
        {
            cmbDoctores.Enabled = true;

            txtNumExpediente.Enabled = true;
            txtNombrePacienteExistente.Enabled = true;
            txtNombrePacienteNuevo.Enabled = true;
            txtContacto1.Enabled = true;
            txtContacto2.Enabled = true;
            tobBuscarPaciente.Enabled = true;
            btnListo1.Enabled = true;
            btnListo2.Enabled = true;

            dtFechaCita.Enabled = true;
            dateTimePicker1.Enabled = true;
            numericUDHoras.Enabled = true;
            numericUDMinutos.Enabled = true;
            txtDetalle.Enabled = true;
            rdNormal.Enabled = true;
            rdMedia.Enabled = true;
            rdAlta.Enabled = true;
            btnGuardarCita.Enabled = true;
            btnCancelarCita.Enabled = true;
            tobBuscarPaciente.Enabled = true;

            checkBoxPrioridadCita.Enabled = true;
        }

        public void ModoBloqueo()
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(100));
            t.add(panelPaneles, "Left", 0);
            t.run();

            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel2.Text = "";
            toolStripStatusLabel3.Text = "";

            nuevo = false;
            modificar = false;
            itemSeleccionado = false;

            //this.tableLayoutPanel1.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 24.26f);
            nuevo = false;
            InicializarCampos();
            BloquearCampos();

            tobNuevaCita.Enabled = true;

            oCalendario.TimeScale = oTimeScale();

            monthView1.Enabled = true;
            monthView1.Select();
            monthView1.SelectionStart = PrimerDiaDelMes(System.DateTime.Today);
            monthView1.SelectionEnd = UltimoDiaDelMes(System.DateTime.Today);

            oCalendario.SetViewRange(PrimerDiaDelMes(System.DateTime.Today), UltimoDiaDelMes(System.DateTime.Today));

            idCitaSeleccionada = "";

            AñadirItemsCalendario();
        }

        private void btnGuardarCita_Click(object sender, EventArgs e)
        {
            if (VerificaCampos() == false)
            {
                GuardarRecordatorio();
                Program.oMostrarRecordatorios.DeterminarRecordatoriosDelDiaActual();
            }
        }

        private void GuardarRecordatorio()
        {
            try
            {
                DateTime oFechaFinal = new DateTime();
                double MinutosDuracion = 0;
                MinutosDuracion = Convert.ToDouble((Convert.ToInt32(numericUDHoras.Value) * 60) + Convert.ToInt32(numericUDMinutos.Value));
                oFechaFinal = dtFechaCita.Value.AddMinutes(MinutosDuracion);

                string Mensaje = "";

                if (nuevo == true)
                    Mensaje = Program.oCCitas.VerificaHorasDisponiblesDoctorPorDia(cmbDoctores.SelectedValue.ToString().Trim(), dtFechaCita.Value, dtFechaCita.Value, oFechaFinal, "");
                else if (modificar == true)
                    Mensaje = Program.oCCitas.VerificaHorasDisponiblesDoctorPorDia(cmbDoctores.SelectedValue.ToString().Trim(), dtFechaCita.Value, dtFechaCita.Value, oFechaFinal, txtIdCita.Text.Trim());

                if (Mensaje == "")
                {
                    if (MessageBox.Show(this, "¿Está seguro que desea programar una cita para el doctor " + cmbDoctores.Text.Trim() + " el día " + dtFechaCita.Text + ", con el asunto de: " + txtDetalle.Text.Trim() + "?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        string qry = "";

                        if (nuevo == true)
                        {
                            oCCitas.Tipo_paciente = tipoPaciente;

                            if (tipoPaciente == false)
                            {
                                oCCitas.Num_expediente = txtNumExpediente.Text.Trim();

                                oCCitas.Nombre_Paciente = "";
                                oCCitas.Contacto1 = "";
                                oCCitas.Contacto2 = "";
                            }
                            else
                            {
                                oCCitas.Num_expediente = "0";

                                oCCitas.Nombre_Paciente = txtNombrePacienteNuevo.Text.Trim();
                                oCCitas.Contacto1 = txtContacto1.Text.Trim();
                                oCCitas.Contacto2 = txtContacto2.Text.Trim();
                            }

                            oCCitas.Id_emp = Convert.ToInt32(cmbDoctores.SelectedValue.ToString().Trim());
                            oCCitas.Fecha = dtFechaCita.Value;

                            MinutosDuracion = 0;
                            MinutosDuracion = Convert.ToDouble((Convert.ToInt32(numericUDHoras.Value) * 60) + Convert.ToInt32(numericUDMinutos.Value));
                            oCCitas.Duracion = dtFechaCita.Value.AddMinutes(MinutosDuracion);

                            oCCitas.Detalle = txtDetalle.Text.Trim();
                            oCCitas.Estado_cita = "0";

                            oCCitas.Fecha_inicial_record = dateTimePicker1.Value;
                            //oCCitas.Hora_inicial_record = dateTimePicker1.Value;

                            oCCitas.Lapso_recordatorio = 0;//Convert.ToInt32(cmbLapsoRecordatorio.Text.Trim());

                            if (rdAlta.Checked == true)
                                oCCitas.Prioridad_recordatorio = "Alta";
                            else if (rdMedia.Checked == true)
                                oCCitas.Prioridad_recordatorio = "Media";
                            else if (rdNormal.Checked == true)
                                oCCitas.Prioridad_recordatorio = "Normal";

                            oCCitas.Estado_recordatorio = 0;//Estado inicial, sin modificar, recien creado.

                            if (checkBoxPrioridadCita.Checked == true)
                                oCCitas.Prioridad = true;
                            else
                                oCCitas.Prioridad = false;

                            oCCitas.Insertar();

                            #region
                            //                            SqlCommand SqlCom = null;

                            //                            qry = "insert into Citas(id_paciente, id_doctor, fecha, duracion, detalle, estado_cita, fecha_inicial_record, hora_inicial_record, lapso_record, prioridad_record, estado_record) " +
                            //                            "values (@id_paciente, @id_doctor, @fecha, @duracion, @detalle, @estado_cita, @fecha_inicial_record, @hora_inicial_record, @lapso_record, @prioridad_record, @estado_record)";

                            //                            SqlCom = new SqlCommand(qry, Program.oPersistencia.conexion);

                            ////                            SqlCom.Parameters.Add(new SqlParameter("@id_paciente", (object)cmbPacientes.SelectedValue.ToString().Trim()));
                            //                            SqlCom.Parameters.Add(new SqlParameter("@id_doctor", (object)cmbDoctores.SelectedValue.ToString().Trim()));
                            //                            SqlCom.Parameters.Add(new SqlParameter("@fecha", (object)dtFechaCita.Value));
                            //                            MinutosDuracion = 0;
                            //                            MinutosDuracion = Convert.ToDouble((Convert.ToInt32(numericUDHoras.Value) * 60) + Convert.ToInt32(numericUDMinutos.Value));
                            //                            SqlCom.Parameters.Add(new SqlParameter("@duracion", (object)dtFechaCita.Value.AddMinutes(MinutosDuracion)));

                            //                            SqlCom.Parameters.Add(new SqlParameter("@detalle", (object)txtDetalle.Text.Trim()));
                            //                            SqlCom.Parameters.Add(new SqlParameter("@estado_cita", (object)"0"));
                            ////                            SqlCom.Parameters.Add(new SqlParameter("@fecha_inicial_record", (object)dtFechaRecordatorio.Value.ToShortDateString()));
                            ////                            SqlCom.Parameters.Add(new SqlParameter("@hora_inicial_record", (object)dtHoraInicialRecordatorio.Value));
                            //                            SqlCom.Parameters.Add(new SqlParameter("@lapso_record", (object)cmbLapsoRecordatorio.Text.ToString()));

                            //                            if (rdAlta.Checked == true)
                            //                                SqlCom.Parameters.Add(new SqlParameter("@prioridad_record", (object)"Alta"));
                            //                            else if (rdMedia.Checked == true)
                            //                                SqlCom.Parameters.Add(new SqlParameter("@prioridad_record", (object)"Media"));
                            //                            else if (rdNormal.Checked == true)
                            //                                SqlCom.Parameters.Add(new SqlParameter("@prioridad_record", (object)"Normal"));

                            //                            SqlCom.Parameters.Add(new SqlParameter("@estado_record", (object)"0"));//Estado inicial, sin modificar, recien creado.

                            //                            SqlCom.ExecuteNonQuery();

                            #endregion

                            // Verifico el Error
                            if (Program.oPersistencia.IsError == true)
                                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                            else
                                ModoBloqueo();
                        }
                        else if (modificar == true)
                        {
                            oCCitas.Id_cita = Convert.ToInt64(txtIdCita.Text.Trim());

                            oCCitas.Tipo_paciente = tipoPaciente;

                            if (tipoPaciente == false)
                            {
                                oCCitas.Num_expediente = txtNumExpediente.Text.Trim();

                                oCCitas.Nombre_Paciente = "";
                                oCCitas.Contacto1 = "";
                                oCCitas.Contacto2 = "";
                            }
                            else
                            {
                                oCCitas.Num_expediente = "0";

                                oCCitas.Nombre_Paciente = txtNombrePacienteNuevo.Text.Trim();
                                oCCitas.Contacto1 = txtContacto1.Text.Trim();
                                oCCitas.Contacto2 = txtContacto2.Text.Trim();
                            }

                            oCCitas.Id_emp = Convert.ToInt32(cmbDoctores.SelectedValue.ToString().Trim());
                            oCCitas.Fecha = dtFechaCita.Value;

                            MinutosDuracion = 0;
                            MinutosDuracion = Convert.ToDouble((Convert.ToInt32(numericUDHoras.Value) * 60) + Convert.ToInt32(numericUDMinutos.Value));
                            oCCitas.Duracion = dtFechaCita.Value.AddMinutes(MinutosDuracion);

                            oCCitas.Detalle = txtDetalle.Text.Trim();
                            oCCitas.Estado_cita = "0";

                            oCCitas.Fecha_inicial_record = dateTimePicker1.Value;
                            //oCCitas.Hora_inicial_record = dateTimePicker1.Value;

                            oCCitas.Lapso_recordatorio = 0;//Convert.ToInt32(cmbLapsoRecordatorio.Text.Trim());

                            if (rdAlta.Checked == true)
                                oCCitas.Prioridad_recordatorio = "Alta";
                            else if (rdMedia.Checked == true)
                                oCCitas.Prioridad_recordatorio = "Media";
                            else if (rdNormal.Checked == true)
                                oCCitas.Prioridad_recordatorio = "Normal";

                            oCCitas.Estado_recordatorio = 0;//Estado inicial, sin modificar, recien creado.

                            if (checkBoxPrioridadCita.Checked == true)
                                oCCitas.Prioridad = true;
                            else
                                oCCitas.Prioridad = false;

                            oCCitas.Modificar();

                            //                            SqlCommand SqlCom = null;

                            //                            qry = "Update Citas set id_paciente = @id_paciente, id_doctor = @id_doctor, fecha = @fecha, duracion = @duracion, detalle = @detalle, estado_cita = @estado_cita," +
                            //                            "fecha_inicial_record = @fecha_inicial_record, hora_inicial_record = @hora_inicial_record, lapso_record = @lapso_record, prioridad_record = @prioridad_record, estado_record = @estado_record " +
                            //                            "where id_cita = @id_cita";

                            //                            SqlCom = new SqlCommand(qry, Program.oPersistencia.conexion);

                            ////                            SqlCom.Parameters.Add(new SqlParameter("@id_paciente", (object)cmbPacientes.SelectedValue.ToString().Trim()));
                            //                            SqlCom.Parameters.Add(new SqlParameter("@id_doctor", (object)cmbDoctores.SelectedValue.ToString().Trim()));
                            //                            SqlCom.Parameters.Add(new SqlParameter("@fecha", (object)dtFechaCita.Value));
                            //                            MinutosDuracion = 0;
                            //                            MinutosDuracion = Convert.ToDouble((Convert.ToInt32(numericUDHoras.Value) * 60) + Convert.ToInt32(numericUDMinutos.Value));
                            //                            SqlCom.Parameters.Add(new SqlParameter("@duracion", (object)dtFechaCita.Value.AddMinutes(MinutosDuracion)));
                            //                            SqlCom.Parameters.Add(new SqlParameter("@detalle", (object)txtDetalle.Text.Trim()));
                            //                            SqlCom.Parameters.Add(new SqlParameter("@estado_cita", (object)"0"));
                            ////                            SqlCom.Parameters.Add(new SqlParameter("@fecha_inicial_record", (object)dtFechaRecordatorio.Value.ToShortDateString()));
                            ////                            SqlCom.Parameters.Add(new SqlParameter("@hora_inicial_record", (object)dtHoraInicialRecordatorio.Value));
                            //                            SqlCom.Parameters.Add(new SqlParameter("@lapso_record", (object)cmbLapsoRecordatorio.Text.ToString()));

                            //                            if (rdAlta.Checked == true)
                            //                                SqlCom.Parameters.Add(new SqlParameter("@prioridad_record", (object)"Alta"));
                            //                            else if (rdMedia.Checked == true)
                            //                                SqlCom.Parameters.Add(new SqlParameter("@prioridad_record", (object)"Media"));
                            //                            else if (rdNormal.Checked == true)
                            //                                SqlCom.Parameters.Add(new SqlParameter("@prioridad_record", (object)"Normal"));

                            //                            SqlCom.Parameters.Add(new SqlParameter("@estado_record", (object)"0"));//Estado inicial, sin modificar, recien creado.
                            //                            SqlCom.Parameters.Add(new SqlParameter("@id_cita", (object)txtIdCita.Text.Trim()));

                            //                            SqlCom.ExecuteNonQuery();

                            // Verifico el Error
                            if (Program.oPersistencia.IsError == true)
                                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                            else
                                ModoBloqueo();
                        }
                    }
                }
                else
                    MessageBox.Show(this, Mensaje.Trim(), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { }
        }

        private void InicializarCampos()
        {
            if (cmbDoctores.Items.Count > 0)
                cmbDoctores.SelectedIndex = -1;

            txtNumExpediente.Text = "";
            txtNombrePacienteExistente.Text = "";

            txtNombrePacienteNuevo.Text = "";
            txtContacto1.Text = "";
            txtContacto2.Text = "";

            TimeSpan oTimeSpan = new TimeSpan(0, 0, 0);
            dtFechaCita.Value = DateTime.Today + oTimeSpan;
            dateTimePicker1.Value = DateTime.Today + oTimeSpan;

            numericUDHoras.Value = 0;
            numericUDMinutos.Value = 0;

            txtDetalle.Text = "";

            rdNormal.Checked = false;
            rdMedia.Checked = false;
            rdAlta.Checked = true;

            checkBoxPrioridadCita.Checked = false;
        }

        private void dtFechaCita_ValueChanged(object sender, EventArgs e)
        {
            int Index = 0;
            foreach (CalendarDay oDay in oCalendario.Days)
            {
                if (oDay.Date == dtFechaCita.Value.Date)
                {
                    Index = oDay.Index;
                    break;
                }
            }

            System.Windows.Forms.Calendar.CalendarDayEventArgs e2 = new CalendarDayEventArgs(this.oCalendario.Days[Index]);

            if (nuevo == true || modificar == true)
            {
                oCalendario.SetViewRange(dtFechaCita.Value, dtFechaCita.Value);
                oCalendario.TimeScale = oTimeScale();
                oCalendario.EnsureVisible(GetTimeUnit(e2.CalendarDay));
                //monthView1.SelectionMode = MonthView.MonthViewSelection.Month;
            }
            //else
            //{
            //    oCalendario.SetViewRange(PrimerDiaDelMes(dtFechaCita.Value), UltimoDiaDelMes(dtFechaCita.Value));
            //    oCalendario.TimeScale = oTimeScale();
            //    oCalendario.EnsureVisible(GetTimeUnit(e2.CalendarDay));
            //    //monthView1.SelectionMode = MonthView.MonthViewSelection.Month;
            //}

            lblFecha1.Text = dtFechaCita.Value.Date.ToLongDateString();
        }

        private void btnCancelarCita_Click(object sender, EventArgs e)
        {
            ModoBloqueo();
        }

        private void AñadirItemsCalendario()
        {
            itemsCitas.Clear();//Limpia la lista global de ítems
            oCalendario.Items.Clear();//Limpia los ítems del calendario

            //Limpia los arreglos
            oArregloTextoRecordatorios.Clear();
            oArregloTagRecordatorios.Clear();
            oArregloResumenRecordatorios.Clear();

            string NombrePaciente = "";
            string NombreDoctor = "";

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select * from Citas", "Citas");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        #region Selecciona el nombre del paciente

                        DataSet ds2 = Program.oPersistencia.ejecutarSQLListas("Select nombre, apellidos from Paciente where num_expediente = " + dr[1].ToString().Trim(), "Pacientes");

                        if (ds2 != null)
                        {
                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                                {
                                    NombrePaciente = dr2[0].ToString().Trim() + " " + dr2[1].ToString().Trim();
                                    break;
                                }
                            }
                            else
                                NombrePaciente = dr[12].ToString().Trim();
                        }
                        ds2.Dispose();

                        #endregion

                        #region Selecciona el nombre del doctor

                        DataSet ds3 = Program.oPersistencia.ejecutarSQLListas("Select nombre from Empleados where id_emp = " + dr[2].ToString().Trim(), "Doctores");

                        if (ds3 != null)
                        {
                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr3 in ds3.Tables[0].Rows)
                                {
                                    NombreDoctor = dr3[0].ToString().Trim();
                                    break;
                                }
                            }
                        }
                        ds3.Dispose();

                        #endregion

                        string Descripcion = "";
                        Descripcion = "El paciente: " + NombrePaciente + " tiene establecida una cita con el doctor: " + NombreDoctor + " el día: " + Convert.ToDateTime(dr[3]).ToLongDateString() + " a las " + Convert.ToDateTime(dr[3]).ToLongTimeString()
                            + " por motivos de " + dr[5].ToString().Trim();

                        string Resumen = "Cita programada con el doctor " + NombreDoctor + " a las " + Convert.ToDateTime(dr[3]).ToLongTimeString();

                        CalendarItem oItemCalendario = new CalendarItem(oCalendario);
                        oItemCalendario.StartDate = Convert.ToDateTime(dr[3]);
                        oItemCalendario.EndDate = Convert.ToDateTime(dr[4]);
                        oArregloTextoRecordatorios.Add(Descripcion.Trim());
                        oArregloTagRecordatorios.Add(dr[0].ToString().Trim());
                        oArregloResumenRecordatorios.Add(Resumen.Trim());
                        oItemCalendario.Tag = dr[0].ToString().Trim();

                        if (dr[9].ToString() == "Alta")
                        {
                            oItemCalendario.Image = recursos.Alta;
                            oItemCalendario.ApplyColor(Color.Red);
                            oItemCalendario.ImageAlign = CalendarItemImageAlign.East;
                            oItemCalendario.ForeColor = Color.Black;
                        }
                        else if (dr[9].ToString() == "Media")
                        {
                            oItemCalendario.Image = recursos.Media;
                            oItemCalendario.ApplyColor(Color.Yellow);
                            oItemCalendario.ImageAlign = CalendarItemImageAlign.East;
                            oItemCalendario.ForeColor = Color.Black;
                        }
                        else if (dr[9].ToString() == "Normal")
                        {
                            oItemCalendario.Image = recursos.Normal;
                            oItemCalendario.ImageAlign = CalendarItemImageAlign.East;
                            oItemCalendario.ForeColor = Color.Black;
                            //No se aplica color para que quede el color por defecto.
                        }

                        if (dr[6].ToString().Trim() == "1")
                        {
                            oItemCalendario.Pattern = System.Drawing.Drawing2D.HatchStyle.DiagonalCross;
                            oItemCalendario.PatternColor = Color.Red;
                            oCalendario.Invalidate(oItemCalendario);
                        }

                        itemsCitas.Add(oItemCalendario);
                    }

                    ColocarItems();
                }
            }
            ds.Dispose();
        }

        private void ColocarItems()
        {
            foreach (CalendarItem item in itemsCitas)
            {
                if (oCalendario.ViewIntersects(item))
                {
                    oCalendario.Items.Add(item);
                }
            }
        }

        public void LlenarDatosModoModificar(string id_cita)
        {
            try
            {
                object sender = new object();
                EventArgs e = new EventArgs();

                string sentenciaSQL = "Select * from Citas where id_cita = " + id_cita.Trim();

                DataSet ds = Program.oPersistencia.ejecutarSQLListas(sentenciaSQL, "Citas");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txtIdCita.Text = dr[0].ToString().Trim();

                    if (Convert.ToBoolean(dr[11]) == false)//Paciente existente
                    {
                        itemSeleccionado = true;
                        btnBuscarPaciente_Click(sender, e);

                        txtNumExpediente.Text = dr[1].ToString().Trim();
                        txtNombrePacienteExistente.Text = oCPacientes.NombreDePaciente(txtNumExpediente.Text.Trim());

                        txtNombrePacienteNuevo.Text = "";
                        txtContacto1.Text = "";
                        txtContacto2.Text = "";
                    }
                    else
                    {
                        itemSeleccionado = true;
                        btnPacienteNuevo_Click(sender, e);

                        txtNumExpediente.Text = "";
                        txtNombrePacienteExistente.Text = "";

                        txtNombrePacienteNuevo.Text = dr[12].ToString().Trim();
                        txtContacto1.Text = dr[13].ToString().Trim();
                        txtContacto2.Text = dr[14].ToString().Trim();
                    }

                    cmbDoctores.SelectedValue = dr[2].ToString().Trim();
                    dtFechaCita.Value = Convert.ToDateTime(dr[3]);

                    //var span = System.TimeSpan.FromMinutes(121);
                    //var hours = ((int)span.TotalHours).ToString();
                    //var minutes = span.Minutes.ToString();


                    TimeSpan oTimeSpan = new TimeSpan();
                    oTimeSpan = Convert.ToDateTime(dr[4]).TimeOfDay - Convert.ToDateTime(dr[3]).TimeOfDay;

                    double duracionHoras = oTimeSpan.Hours;
                    double duracionMinutos = oTimeSpan.Minutes;

                    int horainicial = Convert.ToDateTime(dr[3]).Hour;


                    //if (horainicial > 12)
                    //    horainicial -= 12;

                    //int horas = Convert.ToDateTime(dr[4]).Hour;

                    //if (horas > 12)
                    //    horas -= 12;

                    //horas -= horainicial;

                    //if (horas < 0)
                    //    horas = 0;

                    //int minutos = Convert.ToDateTime(dr[4]).Minute;
                    numericUDHoras.Value = (decimal)duracionHoras;
                    numericUDMinutos.Value = (decimal)duracionMinutos;
                    txtDetalle.Text = dr[5].ToString().Trim();
                    dateTimePicker1.Value = Convert.ToDateTime(dr[7]);

                    cmbLapsoRecordatorio.SelectedIndex = cmbLapsoRecordatorio.Items.IndexOf(dr[9].ToString().Trim());

                    if (dr[9].ToString().Trim() == "Alta")
                        rdAlta.Checked = true;
                    else if (dr[9].ToString().Trim() == "Media")
                        rdMedia.Checked = true;
                    else if (dr[9].ToString().Trim() == "Normal")
                        rdNormal.Checked = true;

                    if (Convert.ToBoolean(dr[15]) == true)
                        checkBoxPrioridadCita.Checked = true;
                    else
                        checkBoxPrioridadCita.Checked = false;
                }

                ds.Dispose();
            }
            catch { }
        }

        #region Métodos para desaparecer el grouper si ya abandonó el área del ítem y se mantiene visible

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (grouper1.Visible == true)
                grouper1.Visible = false;

            timer1.Stop();
        }

        private void grouper1_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void lblDetalleCita_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void monthView1_MouseEnter(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Program.oMostrarRecordatorios.MuestraRecordatoriosDiaActual();
        }

        #endregion

        private bool VerificaCampos()
        {
            bool Verifica = false;

            DateTime horaInicial = dtFechaCita.Value;
            DateTime horaFinal = dtFechaCita.Value.AddHours(Convert.ToDouble(numericUDHoras.Value)).AddMinutes(Convert.ToDouble(numericUDMinutos.Value));

            if (cmbDoctores.SelectedValue == null)
            {
                Verifica = true;
                MessageBox.Show(this, "El nombre del doctor no puede estar vacío, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //else if (cmbPacientes.SelectedValue == null)
            //{
            //    Verifica = true;
            //    MessageBox.Show(this, "El nombre del paciente no puede estar vacío, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            else if (txtDetalle.Text.Trim() == "")
            {
                Verifica = true;
                MessageBox.Show(this, "El detalle de la cita no puede quedar vacío, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dtFechaCita.Value.Date < DateTime.Today.Date)
            {
                Verifica = true;
                MessageBox.Show(this, "La fecha de la cita a generar no puede ser menor a la fecha actual, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dateTimePicker1.Value.Date < DateTime.Today.Date)
            {
                Verifica = true;
                MessageBox.Show(this, "La fecha del recordatorio no puede ser menor a la fecha actual, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numericUDHoras.Value == 0 && numericUDMinutos.Value == 0)
            {
                Verifica = true;
                MessageBox.Show(this, "Debe establecer una duración de la cita mayor a cero, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dateTimePicker1.Value.Date == DateTime.Today.Date)
            {
                if (dateTimePicker1.Value.TimeOfDay < DateTime.Today.TimeOfDay)
                {
                    Verifica = true;
                    MessageBox.Show(this, "La hora inicial del recordatorio no puede ser menor a la hora actual, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Verifica == false)
            {
                if (tipoPaciente == true)//Nuevo Paciente
                {
                    if (txtContacto1.Text.Trim() == "" && txtContacto2.Text.Trim() == "")
                    {
                        Verifica = true;
                        MessageBox.Show(this, "Debe ingresar al menos un contacto para el paciente para poder generar esta cita correctamente, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (txtNombrePacienteNuevo.Text.Trim() == "")
                    {
                        Verifica = true;
                        MessageBox.Show(this, "Debe ingresar el nombre del paciente para poder generar esta cita correctamente, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (txtNumExpediente.Text.Trim() == "")
                    {
                        Verifica = true;
                        MessageBox.Show(this, "Debe seleccionar un paciente válido existente, ya que seleccionó trabajar con Pacientes Existentes, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


            //////^&&&*^%#$^&%^&%^&
            if (Verifica == false)
            {
                if (horaInicial.TimeOfDay < Program.oCCitas.HoraInicial.TimeOfDay)
                {
                    Verifica = true;

                    if (MessageBox.Show(this, "La hora inicial establecida para la cita es menor a la hora inicial establecida en el horario de su clínica, ¿Desea generar esta cita de todas formas?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        Verifica = false;
                }
                else if (horaInicial.TimeOfDay > Program.oCCitas.HoraFinal.TimeOfDay)
                {
                    Verifica = true;

                    if (MessageBox.Show(this, "La hora final establecida para la cita es mayor a la hora final establecida en el horario de su clínica, ¿Desea generar esta cita de todas formas?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        Verifica = false;
                }
            }

            return Verifica;
        }

        private void btnNuevaCita_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Modo:";
            toolStripStatusLabel3.Text = "Nuevo Ingreso";

            //this.tableLayoutPanel1.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 0f);
            oCalendario.TimeScale = oTimeScale();
            monthView1.Enabled = false;
            nuevo = true;
            DesbloquearCampos();
            InicializarCampos();
            dtFechaCita_ValueChanged(sender, e);
            dtFechaCita.Value = new DateTime(dtFechaCita.Value.Year, dtFechaCita.Value.Month, dtFechaCita.Value.Day,
                                             dtFechaCita.Value.Hour, dtFechaCita.Value.Minute, 0);
        }

        private void tobOpcionesCitas_Click(object sender, EventArgs e)
        {
            frmOpcionesGenerales ofrmOpcionesGenerales = new frmOpcionesGenerales();
            ofrmOpcionesGenerales.ShowDialog(this);
        }

        private void frmCalendario_Load(object sender, EventArgs e)
        {
            panelOpciones.Parent = oCalendario;
            panelOpciones.BackColor = Color.Transparent;
            panelOpciones.BringToFront();

            toolStrip4.Parent = oCalendario;
            toolStrip4.BackColor = Color.Transparent;
            //toolStrip4.Location = new Point(oCalendario.Width - toolStrip4.Width, (oCalendario.Height - toolStrip4.Height) / 2);            

            Program.oCCitas.DeterminaHorasPorDia();
            Agrega_CargaEventosCalendario();

            oCalendario.SetViewRange(PrimerDiaDelMes(System.DateTime.Today), UltimoDiaDelMes(System.DateTime.Today));

            monthView1.DaySelectedBackgroundColor = Color.Orange;

            //Agrega_CargaEventosVScrollBar(); 

            Program.oMostrarRecordatorios.CitaFinalizada();//Finaliza las citas cuya fecha ha expirado 
            LlenaComboDoctores();

            ModoBloqueo();
            oCalendario.Select();
            oCalendario.Focus();

            oCalendario.TimeScale = CalendarTimeScale.ThirtyMinutes;

            if (oCCitas.DeterminaHorarioEstablecido() == false)
            {
                MessageBox.Show(this, "Debe de establecer el horario y número de cubículos de su empresa para poder trabajar con el módulo de citas del sistema", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                frmOpcionesGenerales oFrmOpcionesGenerales = new frmOpcionesGenerales();
                oFrmOpcionesGenerales.ShowDialog(this);
            }

            toolStrip4.BringToFront();
            frmCalendario_SizeChanged(sender, e);
            toolStrip4.Visible = true;

            lblFecha1.Text = Metodos_Globales.NombreDelMes(Convert.ToInt32(DateTime.Today.Month)) + " del " + DateTime.Today.Year.ToString();
            lblFecha1.Visible = true;
        }

        private void tobBuscarPaciente_Click(object sender, EventArgs e)
        {
            FrmBlackBackground oFrmBlackBackground = new FrmBlackBackground();
            oFrmBlackBackground.Show();
            FrmPacientesExistentes oFrmPacientesExistentes = new FrmPacientesExistentes(txtNumExpediente, txtNombrePacienteExistente);
            oFrmPacientesExistentes.ShowDialog();
            oFrmBlackBackground.Close();
        }

        private void tobTimeScale_Click(object sender, EventArgs e)
        {

        }

        private CalendarTimeScale oTimeScale()
        {
            CalendarTimeScale oCTimeScale = CalendarTimeScale.ThirtyMinutes;

            if (rd1Hora.Checked == true)
                oCTimeScale = CalendarTimeScale.SixtyMinutes;
            else if (rd30min.Checked == true)
                oCTimeScale = CalendarTimeScale.ThirtyMinutes;
            else if (rd15min.Checked == true)
                oCTimeScale = CalendarTimeScale.FifteenMinutes;
            else if (rd10min.Checked == true)
                oCTimeScale = CalendarTimeScale.TenMinutes;
            else if (rd5min.Checked == true)
                oCTimeScale = CalendarTimeScale.FiveMinutes;

            return oCTimeScale;
        }

        private void tobOkTimeScale_Click(object sender, EventArgs e)
        {
            oCalendario.TimeScale = oTimeScale();
            grouperTimeScale.Visible = false;
        }

        private void btnLibroCitas_Click(object sender, EventArgs e)
        {
            Program.oFrmCuadernoCitas = new frmCuadernoCitas();
            Program.oFrmCuadernoCitas.Show(this);
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            if (nuevo == true || itemSeleccionado == true)
            {
                tipoPaciente = false;

                txtNombrePacienteNuevo.Text = "";
                txtContacto1.Text = "";
                txtContacto2.Text = "";

                Transition t = new Transition(new TransitionType_EaseInEaseOut(100));
                t.add(panelPaneles, "Left", -452);
                t.run();
            }
        }

        private void btnPacienteNuevo_Click(object sender, EventArgs e)
        {
            if (nuevo == true || itemSeleccionado == true)
            {
                tipoPaciente = true;

                txtNumExpediente.Text = "";
                txtNombrePacienteExistente.Text = "";

                Transition t = new Transition(new TransitionType_EaseInEaseOut(100));
                t.add(panelPaneles, "Left", -907);
                t.run();
            }
        }

        private void btnListo1_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(100));
            t.add(panelPaneles, "Left", 0);
            t.run();
        }

        private void btnListo2_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(100));
            t.add(panelPaneles, "Left", 0);
            t.run();
        }

        private Point PosicionBarraOpciones()
        {
            globalX = panel3.Width + 1;
            globalY = (panel3.Height - panelOpciones.Height) / 2;

            return new Point(globalX, globalY);
        }

        private void frmCalendario_SizeChanged(object sender, EventArgs e)
        {
            toolStrip4.Location = new Point(oCalendario.Width - toolStrip4.Width, (oCalendario.Height - toolStrip4.Height) / 2);
            panelOpciones.Location = PosicionBarraOpciones();
        }

        private void btnEscalaTiempo_Click(object sender, EventArgs e)
        {
            grouperTimeScale.Visible = true;
        }

        public void btnEliminarCita_Click(object sender, EventArgs e)
        {
            if (nuevo == false && modificar == false)
            {
                if (idCitaSeleccionada.Trim() != "")
                {
                    //MessageBox.Show(oItem.Date.TimeOfDay.ToString());
                    if (MessageBox.Show(this, "¿Está completamente seguro que desea eliminar la cita seleccionada?, estas acciones no son reversibles. ¿Desea continuar con estas acciones?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        string idDoctor = cmbDoctores.SelectedValue.ToString().Trim();

                        TimeSpan oTime = new TimeSpan();
                        oTime = oItem.Duration;

                        Program.oCCitas.Id_cita = Convert.ToInt64(idCitaSeleccionada.Trim());
                        Program.oCCitas.Eliminar();

                        oCalendario.Items.Remove(oItem);
                        Program.oCCitas.VerificaCitasConPrioridad(dtFechaCita.Value, oTime, idDoctor);

                        ModoBloqueo();
                        //permisoEliminar = true;
                        //oCalendario.Items.Remove(oItem);
                        //permisoEliminar = false;
                    }
                }
            }
        }

        private void btnNuevaCita_Click_1(object sender, EventArgs e)
        {
            tobNuevaCita_Click(sender, e);
        }

        private void btnModificarCita_Click(object sender, EventArgs e)
        {
            CalendarItemEventArgs e2 = new CalendarItemEventArgs(oItem);
            oCalendario_ItemDoubleClick(sender, e2);
        }

        private void imagenCambianteLabel4_Click(object sender, EventArgs e)
        {
            frmConsultasPaciente ofrmConsultasPaciente = new frmConsultasPaciente();
            ofrmConsultasPaciente.Show(this);
        }

        private void toolStrip4_MouseEnter(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void panelOpciones_MouseEnter(object sender, EventArgs e)
        {
            timer3.Stop();
        }

        private void panelOpciones_MouseLeave(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            //503, 0 Shown
            //618, 0 Hidden
            int pos = globalX - panelOpciones.Width + 3;

            panelOpciones.BringToFront();
            Transition t = new Transition(new TransitionType_EaseInEaseOut(5));
            t.add(panelOpciones, "Left", pos);
            t.run();

            timer2.Stop();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //503, 0 Shown
            //618, 0 Hidden
            panelOpciones.BringToFront();

            Transition t = new Transition(new TransitionType_EaseInEaseOut(5));
            t.add(panelOpciones, "Left", globalX);
            t.run();

            timer3.Stop();
        }

        private void toolStrip4_MouseLeave(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void tobSelecMensual_Click(object sender, EventArgs e)
        {
            monthView1.SelectionMode = MonthView.MonthViewSelection.Month;
            tobSelecManual.Checked = false;
            tobSelecMensual.Checked = true;
        }

        private void tobSelecManual_Click(object sender, EventArgs e)
        {
            monthView1.SelectionMode = MonthView.MonthViewSelection.Manual;
            tobSelecMensual.Checked = false;
            tobSelecManual.Checked = true;
        }

        private void oCalendario_Click(object sender, EventArgs e)
        {
            if (oCalendario.State == Calendar.CalendarState.DraggingTimeSelection)
            {
                if (panelPaneles.Left != 0)
                {
                    Transition t = new Transition(new TransitionType_EaseInEaseOut(100));
                    t.add(panelPaneles, "Left", 0);
                    t.run();

                    InicializarCampos();
                }
            }
        }

        private void cmbDoctores_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione el médico al cual le va a asignar la cita";
        }

        private void dtFechaCita_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione la fecha y hora inicial en la cual desea establecer la cita";
        }

        private void numericUDHoras_Enter(object sender, EventArgs e)
        {
            numericUDHoras.Select(0, numericUDHoras.Value.ToString().Length);

            toolStripStatusLabel1.Text = "Seleccione un estimado de horas que durará la cita";
        }

        private void numericUDMinutos_Enter(object sender, EventArgs e)
        {
            numericUDMinutos.Select(0, numericUDMinutos.Value.ToString().Length);

            toolStripStatusLabel1.Text = "Seleccione el total de minutos que acompañan a las horas de la duración de la cita";
        }

        private void txtDetalle_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Establezca el detalle del motivo de la cita";
        }

        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione la fecha y hora a la cual desea establecer el recordatorio para la cita";
        }

        private void tobSendMail_Click(object sender, EventArgs e)
        {
            if (txtNumExpediente.Text.Trim() != "")
            {
                if (tobSendMail.Checked == false)
                {
                    if (MessageBox.Show(this, "¿Realmente desea agregar a este paciente a la lista de los pacientes que reciben notificaciones de citas por correo electrónico?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Program.oComprobaciones.Guardar(txtNumExpediente.Text.Trim(), "Pacientes_Notificar_Correo");
                        tobSendMail.Checked = true;
                    }
                }
                else if (tobSendMail.Checked == true)
                {
                    if (MessageBox.Show(this, "¿Realmente desea eliminar este paciente de la lista de los pacientes que reciben notificaciones de citas por correo electrónico?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Program.oComprobaciones.Borrar("Pacientes_Notificar_Correo", "num_expediente = " + txtNumExpediente.Text.Trim());
                        tobSendMail.Checked = false;
                    }
                }
            }
        }

        private void txtNumExpediente_TextChanged(object sender, EventArgs e)
        {
            if (txtNumExpediente.Text.Trim() != "")
                tobSendMail.Checked = oCEmail.RecibeNotificaciones(txtNumExpediente.Text.Trim());
        }

        private void txtNumExpediente_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Seleccione el paciente al cual deseal asignar la cita";
        }

        private void txtNombrePacienteNuevo_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese el nombre del paciente al cual deseal asignar la cita";
        }

        private void txtContacto1_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese un contacto por medio del cual se pueda comunicar con el paciente";
        }

        private void txtContacto2_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ingrese otro contacto por medio del cual se pueda comunicar con el paciente";
        }
    }
}