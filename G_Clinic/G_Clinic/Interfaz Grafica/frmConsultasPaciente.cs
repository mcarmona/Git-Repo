using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using System.Collections;
using Transitions;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmConsultasPaciente : Form
    {
        int opcionSeleccionada = -1;

        private void SetStyles()
        {
            //Makes sure the form repaints when it was resized
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

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

        public frmConsultasPaciente()
        {
            InitializeComponent();

            monthView1.Region = Shape.RoundedRegion(monthView1.Size, 4, Shape.Corner.None);
            SetStyles();
        }

        //Calendar oCalendario = new Calendar();

        List<CalendarItem> itemsCitas = new List<CalendarItem>();//Generamos una lista de los ítems que ingresaremos al calendario

        ArrayList oArregloTextoRecordatorios = new ArrayList();
        ArrayList oArregloTagRecordatorios = new ArrayList();
        ArrayList oArregloResumenRecordatorios = new ArrayList();

        DateTime oFechaSeleccionada;

        string auxTagRecordatorio = "";

        string idCitaSeleccionada = "";
        CalendarItem oItem = null;

        int index = 0;

        private void Agrega_CargaEventosCalendario()
        {
            #region Eventos del Calendario

            oCalendario.ItemDoubleClick += new Calendar.CalendarItemEventHandler(oCalendario_ItemDoubleClick);
            oCalendario.DayHeaderClick += new Calendar.CalendarDayEventHandler(oCalendario_DayHeaderClick);
            oCalendario.ItemCreating += new Calendar.CalendarItemCancelEventHandler(oCalendario_ItemCreating);
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
            oCalendario.Click += new EventHandler(oCalendario_Click);

            #endregion

            #region Establecemos las horas que se verán resaltadas en los días del calendario existente

            TimeSpan oTimeSpanInicio = new TimeSpan(Program.oCCitas.HoraInicial.Hour, Program.oCCitas.HoraInicial.Minute, 0);
            TimeSpan oTimeSpanFinal = new TimeSpan(Program.oCCitas.HoraFinal.Hour, Program.oCCitas.HoraFinal.Minute, 0);

            oCalendario.HighlightRanges = new CalendarHighlightRange[] {
                new CalendarHighlightRange( DayOfWeek.Monday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Tuesday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Wednesday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Thursday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Friday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Saturday, oTimeSpanInicio, oTimeSpanFinal)
            };

            #endregion

            #region Asignamos Propiedades al Calendario y a otros controles y lo agregamos al Panel correspondiente

            grouper1.Parent = oCalendario;//Establecemos como parent al calendario para el control Grouper para establecer la transparencia total

            #region Calendario 1

            oCalendario.Visible = true;
            oCalendario.Show();

            oCalendario.TimeScale = CalendarTimeScale.ThirtyMinutes;

            oCalendario.MaximumViewDays = 35;

            oCalendario.Size = new Size(596, 483);
            panel1.Controls.Add(oCalendario);
            oCalendario.Location = new Point(0, -1);

            #endregion

            oCalendario.TimeUnitsOffset = index * (-1);//Devuelve el mismo valor pero negativo
            oCalendario.Region = Shape.RoundedRegion(oCalendario.Size, 4, Shape.Corner.None);

            #endregion
        }

        void oCalendario_Click(object sender, EventArgs e)
        {
            try
            {
                oFechaSeleccionada = new DateTime(oCalendario.SelectedElementStart.Date.Year,
                                      oCalendario.SelectedElementStart.Date.Month,
                                      oCalendario.SelectedElementStart.Date.Day,
                                      oCalendario.SelectedElementStart.Date.Hour,
                                      oCalendario.SelectedElementStart.Date.Minute,
                                      0);
            }
            catch
            {
                oFechaSeleccionada = DateTime.MinValue;
            }
        }

        #region Eventos Calendario 1

        void oCalendario_ItemDeleting(object sender, CalendarItemCancelEventArgs e)
        {
            //Cancelamos la eliminación de los ítems directamente desde el calendario mediante la tecla DEL o SUPR
            e.Cancel = true;
        }

        void oCalendario_OverFlowMouseLeave(object sender, CalendarDayEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void oCalendario_OverFlowMouseHover(object sender, CalendarDayEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void oCalendario_MouseLeave(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void oCalendario_MouseEnter(object sender, EventArgs e)
        {
            //  throw new Exception("The method or operation is not implemented.");
        }

        void oCalendario_ItemSelected(object sender, CalendarItemEventArgs e)
        {
            idCitaSeleccionada = e.Item.Tag.ToString().Trim();
            oItem = e.Item;
        }

        void oCalendario_ViewRangeChanged(object sender, CancelEventArgs e)
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

        void oCalendario_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            ColocarItems();//Coloca los ítems creados en el calendario
        }

        void oCalendario_ItemMouseLeave(object sender, CalendarItemEventArgs e)
        {
            //Evento que se produce cuando el cursor abandona el área de un ítem del calendario, para ocultar el mensaje con el detalle
            //de la cita correspondiente al ítem sobre el cual se estaba posicionado
            if (grouper1.Visible == true)
                grouper1.Visible = false;

            //throw new Exception("The method or operation is not implemented.");
        }

        //Método que devuelve la posición del grouper para que este no sea vea cortado
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

        void oCalendario_ItemMouseHover(object sender, CalendarItemEventArgs e)
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

            //throw new Exception("The method or operation is not implemented.");
        }

        void oCalendario_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            itemsCitas.Add(e.Item);//Agregamos los ítems al calendario
        }

        void oCalendario_ItemCreating(object sender, CalendarItemCancelEventArgs e)
        {
            e.Cancel = true;
        }

        void oCalendario_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            //oCalendario.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
            //oCalendario.ScrollTimeUnits(800);
            //oCalendario.EnsureVisible(GetTimeUnit(e.CalendarDay));
        }

        void oCalendario_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        public CalendarTimeScaleUnit GetTimeUnit(CalendarDay day)
        {
            return day.TimeUnits[index];
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

        private void frmConsultasPaciente1_Load(object sender, EventArgs e)
        {
            //DeterminaHorarioClinica();
            opcionSeleccionada = 0;
            oCalendario.SetViewRange(PrimerDiaDelMes(System.DateTime.Today), UltimoDiaDelMes(System.DateTime.Today));
            monthView1.DaySelectedBackgroundColor = Color.Orange;

            Agrega_CargaEventosCalendario();

            //DateRangeEventArgs e2 = new DateRangeEventArgs(DateTime.Today, DateTime.Today);
            //monthCalendar1_DateSelected(sender, e2);

            //frmMonthCalendar ofrmMonthCalendar = new frmMonthCalendar();
            //ofrmMonthCalendar.Show(this);   
        }

        private void AñadirItemsCalendario()
        {
            if (TxtNombre.Text.Trim() != "" || textBox1.Text.Trim () != "")
            {
                itemsCitas.Clear();//Limpia la lista global de ítems

                oCalendario.Items.Clear();//Limpia los ítems del calendario

                //Limpia los arreglos
                oArregloTextoRecordatorios.Clear();
                oArregloTagRecordatorios.Clear();
                oArregloResumenRecordatorios.Clear();

                string NombrePaciente = "";
                string NombreDoctor = "";

                string sqlConsulta = "";

                if (opcionSeleccionada == 0)
                    sqlConsulta = "Select * from Citas where num_expediente = " + TxtNumExpediente.Text.Trim();
                else if (opcionSeleccionada == 1)
                    sqlConsulta = "Select * from Citas where nombre_paciente like '%" + textBox1.Text.Trim() + "%'";

                DataSet ds = Program.oPersistencia.ejecutarSQLListas(sqlConsulta.Trim(), "Citas");

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            NombrePaciente = TxtNombre.Text.Trim();

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

                            itemsCitas.Add(oItemCalendario);
                        }

                        ColocarItems();
                    }
                }
                ds.Dispose();
            }
        }

        private void ColocarItems()
        {
            int Contador = 0;

            foreach (CalendarItem item in itemsCitas)
            {
                item.Text = oArregloResumenRecordatorios[Contador].ToString().Trim();
                Contador++;

                if (oCalendario.ViewIntersects(item))
                    oCalendario.Items.Add(item);
            }
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oCalendario.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
            }
            catch { }
        }

        private void tobBuscarPaciente_Click(object sender, EventArgs e)
        {
            FrmBlackBackground oFrmBlackBackground = new FrmBlackBackground();
            oFrmBlackBackground.Show();
            FrmPacientesExistentes oFrmPacientesExistentes = new FrmPacientesExistentes(TxtNumExpediente, TxtNombre);
            oFrmPacientesExistentes.ShowDialog();
            oFrmBlackBackground.Close();

            AñadirItemsCalendario();
        }

        private void tobNuevaCita_Click(object sender, EventArgs e)
        {
            if (Program.ofrmCalendario != null)
            {
                if (MessageBox.Show(this, "¿Realmente desea generar una cita el día y a la hora seleccionados?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Program.ofrmCalendario.tobNuevaCita_Click(sender, e);
                    this.Close();
                }
            }
        }

        private void tobModificarCita_Click(object sender, EventArgs e)
        {
            if (oItem != null && Program.ofrmCalendario != null)
            {
                if (MessageBox.Show(this, "¿Realmente desea modificar los valores de la cita seleccionada?, esta ventana se cerrará para realizar dichas acciones", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Program.ofrmCalendario.LlenarDatosModoModificar(oItem.Tag.ToString().Trim());
                    CalendarItemEventArgs e2 = new CalendarItemEventArgs(oItem);


                    this.Close();
                    Program.ofrmCalendario.oCalendario_ItemDoubleClick(sender, e2);
                }
            }
        }

        private void tobEliminarCita_Click(object sender, EventArgs e)
        {
            if (idCitaSeleccionada != null && idCitaSeleccionada.Trim() != "")
            {
                if (MessageBox.Show(this, "¿Realmente desea eliminar la cita seleccionada?, esta ventana se cerrará para realizar dichas acciones", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Program.ofrmCalendario.idCitaSeleccionada = idCitaSeleccionada.Trim();

                    this.Close();
                    Program.ofrmCalendario.btnEliminarCita_Click(sender, e);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tobBuscar_Click(object sender, EventArgs e)
        {
            //panel3
            opcionSeleccionada = 0;
            Transition t = new Transition(new TransitionType_EaseInEaseOut(150));
            t.add(panel3, "Left", 0);
            t.run();

            tobBuscar.Checked = true;
            tobIngresar.Checked = false;

            textBox1.Text = "";
        }

        private void tobIngresar_Click(object sender, EventArgs e)
        {
            opcionSeleccionada = 1;
            Transition t = new Transition(new TransitionType_EaseInEaseOut(150));
            t.add(panel3, "Left", -589);
            t.run();

            tobBuscar.Checked = false;
            tobIngresar.Checked = true;

            TxtNombre.Text = "";
            TxtNumExpediente.Text = "";            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AñadirItemsCalendario();
        }

        private void panel3_Move(object sender, EventArgs e)
        {
            //panel3.Update();
            //panelOpciones.Update();
            // panel2.Update();
            //panel1.Update();
        }
    }
}