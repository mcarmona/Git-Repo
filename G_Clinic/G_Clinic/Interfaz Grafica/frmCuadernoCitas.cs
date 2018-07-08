using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using System.Collections;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmCuadernoCitas : Form
    {        
        public frmCuadernoCitas()
        {
            InitializeComponent();            
        }

        Calendar oCalendario = new Calendar();
        Calendar oCalendario2 = new Calendar();

        List<CalendarItem> itemsCitas = new List<CalendarItem>();//Generamos una lista de los ítems que ingresaremos al calendario
        List<CalendarItem> itemsCitas2 = new List<CalendarItem>();//Generamos una lista de los ítems que ingresaremos al calendario

        ArrayList oArregloTextoRecordatorios = new ArrayList();
        ArrayList oArregloTagRecordatorios = new ArrayList();
        ArrayList oArregloResumenRecordatorios = new ArrayList();

        DateTime oFechaSeleccionada;
 
        int index = 0;

        bool dateChanged = false;
        
        string auxTagRecordatorio = "";

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

            oCalendario2.ItemDoubleClick += new Calendar.CalendarItemEventHandler(oCalendario2_ItemDoubleClick);
            oCalendario2.DayHeaderClick += new Calendar.CalendarDayEventHandler(oCalendario2_DayHeaderClick);
            oCalendario2.ItemCreating += new Calendar.CalendarItemCancelEventHandler(oCalendario2_ItemCreating);
            oCalendario2.ItemCreated += new Calendar.CalendarItemCancelEventHandler(oCalendario2_ItemCreated);
            oCalendario2.ItemMouseHover += new Calendar.CalendarItemEventHandler(oCalendario2_ItemMouseHover);
            oCalendario2.ItemMouseLeave += new Calendar.CalendarItemEventHandler(oCalendario2_ItemMouseLeave);
            oCalendario2.LoadItems += new Calendar.CalendarLoadEventHandler(oCalendario2_LoadItems);
            oCalendario2.ViewRangeChanged += new CancelEventHandler(oCalendario2_ViewRangeChanged);
            oCalendario2.ItemSelected += new Calendar.CalendarItemEventHandler(oCalendario2_ItemSelected);
            oCalendario2.MouseEnter += new EventHandler(oCalendario2_MouseEnter);
            oCalendario2.MouseLeave += new EventHandler(oCalendario2_MouseLeave);
            oCalendario2.OverFlowMouseHover += new Calendar.CalendarDayEventHandler(oCalendario2_OverFlowMouseHover);
            oCalendario2.OverFlowMouseLeave += new Calendar.CalendarDayEventHandler(oCalendario2_OverFlowMouseLeave);
            oCalendario2.ItemDeleting += new Calendar.CalendarItemCancelEventHandler(oCalendario2_ItemDeleting);
            oCalendario2.Click += new EventHandler(oCalendario2_Click);

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

            oCalendario2.HighlightRanges = new CalendarHighlightRange[] {
                new CalendarHighlightRange( DayOfWeek.Monday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Tuesday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Wednesday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Thursday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Friday, oTimeSpanInicio, oTimeSpanFinal),
                new CalendarHighlightRange( DayOfWeek.Saturday, oTimeSpanInicio, oTimeSpanFinal)
            };

            #endregion

            #region Asignamos Propiedades al Calendario y a otros controles y lo agregamos al Panel correspondiente

            #region Calendario 1

            oCalendario.Visible = true;
            oCalendario.Show();

            oCalendario.TimeScale = CalendarTimeScale.ThirtyMinutes;

            oCalendario.MaximumViewDays = 7;

            oCalendario.Size = new Size(468, 553);
            panel2.Controls.Add(oCalendario);
            oCalendario.Location = new Point(36, 84);

            #endregion

            #region Calendario 2

            oCalendario2.Visible = true;
            oCalendario2.Show();

            oCalendario2.TimeScale = CalendarTimeScale.ThirtyMinutes;

            oCalendario2.MaximumViewDays = 7;

            oCalendario2.Size = new Size(468, 553);
            panel2.Controls.Add(oCalendario2);
            oCalendario2.Location = new Point(570, 84);

            #endregion

            oCalendario.TimeUnitsOffset = index * (-1);//Devuelve el mismo valor pero negativo
            oCalendario2.TimeUnitsOffset = index * (-1);//Devuelve el mismo valor pero negativo

            #endregion
        }

        void oCalendario2_Click(object sender, EventArgs e)
        {
            try
            {
                oFechaSeleccionada = new DateTime(oCalendario2.SelectedElementStart.Date.Year,
                                      oCalendario2.SelectedElementStart.Date.Month,
                                      oCalendario2.SelectedElementStart.Date.Day,
                                      oCalendario2.SelectedElementStart.Date.Hour,
                                      oCalendario2.SelectedElementStart.Date.Minute,
                                      0);
            }
            catch 
            { 
                oFechaSeleccionada = DateTime.MinValue;
            }
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
            //throw new Exception("The method or operation is not implemented.");
        }

        void oCalendario_ViewRangeChanged(object sender, CancelEventArgs e)
        {
        }

        void oCalendario_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            ColocarItems();//Coloca los ítems creados en el calendario
        }

        /// <summary>
        /// Evento que se produce cuando el cursor abandona el área de un ítem del calendario, para ocultar el mensaje con el detalle
        /// de la cita correspondiente al ítem sobre el cual se estaba posicionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void oCalendario_ItemMouseLeave(object sender, CalendarItemEventArgs e)
        {
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
                grouper1.Parent = oCalendario;

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
            oCalendario.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
            oCalendario.ScrollTimeUnits(800);
            oCalendario.EnsureVisible(GetTimeUnit(e.CalendarDay));
        }

        void oCalendario_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }
        
        #endregion        

        #region Eventos Calendario 2

        void oCalendario2_ItemDeleting(object sender, CalendarItemCancelEventArgs e)
        {
            //Cancelamos la eliminación de los ítems directamente desde el calendario mediante la tecla DEL o SUPR
            e.Cancel = true;
        }

        void oCalendario2_OverFlowMouseLeave(object sender, CalendarDayEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void oCalendario2_OverFlowMouseHover(object sender, CalendarDayEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void oCalendario2_MouseLeave(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void oCalendario2_MouseEnter(object sender, EventArgs e)
        {
            //  throw new Exception("The method or operation is not implemented.");
        }

        void oCalendario2_ItemSelected(object sender, CalendarItemEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void oCalendario2_ViewRangeChanged(object sender, CancelEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void oCalendario2_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            ColocarItems2();//Coloca los ítems creados en el calendario
        }

        /// <summary>
        /// Evento que se produce cuando el cursor abandona el área de un ítem del calendario, para ocultar el mensaje con el detalle
        /// de la cita correspondiente al ítem sobre el cual se estaba posicionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void oCalendario2_ItemMouseLeave(object sender, CalendarItemEventArgs e)
        {
            if (grouper1.Visible == true)
                grouper1.Visible = false;
        }

        /// <summary>
        /// Evento que se dispara cuando el cursor del mouse se encuentra dentro de los márgenes de un ítem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oCalendario2_ItemMouseHover(object sender, CalendarItemEventArgs e)
        {
            if (e.Item.Tag.ToString() != "")// Verificamos que el tag o etiqueta del ítem no sea nula, ya que esta funcionará como la clave 
            //para llamar los datos correspondientes
            {
                grouper1.Parent = oCalendario2;

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

        void oCalendario2_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            itemsCitas2.Add(e.Item);//Agregamos los ítems al calendario
        }

        void oCalendario2_ItemCreating(object sender, CalendarItemCancelEventArgs e)
        {
            e.Cancel = true;
        }

        void oCalendario2_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            oCalendario2.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
            oCalendario2.EnsureVisible(GetTimeUnit(e.CalendarDay));
        }

        void oCalendario2_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion        

        private void DeterminaHorarioClinica()
        {
            DateTime d = new DateTime();
            index = 0;

            DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select hora_inicio from Detalle_Clinica_Citas", "Detalle_Clinica_Citas");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                    d = Convert.ToDateTime(dr[0]);

                double duration = Convert.ToDouble((int)oCalendario.TimeScale);

                index = Convert.ToInt32(Math.Floor(d.TimeOfDay.TotalMinutes / duration));
            }
            ds.Dispose();
        }

        public CalendarTimeScaleUnit GetTimeUnit(CalendarDay day)
        {
            return day.TimeUnits[index];
        }

        private void frmCuadernoCitas_Load(object sender, EventArgs e)
        {
            DeterminaHorarioClinica();

            Agrega_CargaEventosCalendario();
            AñadirItemsCalendario();

            DateRangeEventArgs e2 = new DateRangeEventArgs(DateTime.Today, DateTime.Today);
            monthCalendar1_DateSelected(sender, e2);

            frmMonthCalendar ofrmMonthCalendar = new frmMonthCalendar();
            ofrmMonthCalendar.Show(this);
        }

        private void imagenCambiantePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AñadirItemsCalendario()
        {
            itemsCitas.Clear();//Limpia la lista global de ítems
            itemsCitas2.Clear();

            oCalendario.Items.Clear();//Limpia los ítems del calendario
            oCalendario2.Items.Clear();

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

                        string Resumen = NombrePaciente + " (" + dr[5].ToString() + ").";//"Cita programada con el doctor " + NombreDoctor + " a las " + Convert.ToDateTime(dr[3]).ToLongTimeString();

                        CalendarItem oItemCalendario = new CalendarItem(oCalendario);
                        CalendarItem oItemCalendario2 = new CalendarItem(oCalendario2);

                        oItemCalendario.StartDate = Convert.ToDateTime(dr[3]);
                        oItemCalendario.EndDate = Convert.ToDateTime(dr[4]);

                        oItemCalendario2.StartDate = Convert.ToDateTime(dr[3]);
                        oItemCalendario2.EndDate = Convert.ToDateTime(dr[4]);

                        oArregloTextoRecordatorios.Add(Descripcion.Trim());
                        oArregloTagRecordatorios.Add(dr[0].ToString().Trim());
                        oArregloResumenRecordatorios.Add(Resumen.Trim());

                        oItemCalendario.Tag = dr[0].ToString().Trim();
                        oItemCalendario2.Tag = dr[0].ToString().Trim();

                        if (dr[9].ToString() == "Alta")
                        {
                            oItemCalendario.Image = recursos.Alta;
                            oItemCalendario.ApplyColor(Color.Red);
                            oItemCalendario.ImageAlign = CalendarItemImageAlign.East;
                            oItemCalendario.ForeColor = Color.Black;

                            oItemCalendario2.Image = recursos.Alta;
                            oItemCalendario2.ApplyColor(Color.Red);
                            oItemCalendario2.ImageAlign = CalendarItemImageAlign.East;
                            oItemCalendario2.ForeColor = Color.Black;
                        }
                        else if (dr[9].ToString() == "Media")
                        {
                            oItemCalendario.Image = recursos.Media;
                            oItemCalendario.ApplyColor(Color.Yellow);
                            oItemCalendario.ImageAlign = CalendarItemImageAlign.East;
                            oItemCalendario.ForeColor = Color.Black;

                            oItemCalendario2.Image = recursos.Media;
                            oItemCalendario2.ApplyColor(Color.Yellow);
                            oItemCalendario2.ImageAlign = CalendarItemImageAlign.East;
                            oItemCalendario2.ForeColor = Color.Black;
                        }
                        else if (dr[9].ToString() == "Normal")
                        {
                            oItemCalendario.Image = recursos.Normal;
                            oItemCalendario.ImageAlign = CalendarItemImageAlign.East;
                            oItemCalendario.ForeColor = Color.Black;
                            //No se aplica color para que quede el color por defecto.

                            oItemCalendario2.Image = recursos.Normal;
                            oItemCalendario2.ImageAlign = CalendarItemImageAlign.East;
                            oItemCalendario2.ForeColor = Color.Black;
                        }

                        //oItemCalendario2 = oItemCalendario;

                        itemsCitas.Add(oItemCalendario);
                        itemsCitas2.Add(oItemCalendario2);
                    }

                    ColocarItems();
                    ColocarItems2();
                }
            }
            ds.Dispose();
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

        private void ColocarItems2()
        {
            int Contador = 0;

            foreach (CalendarItem oItem2 in itemsCitas2)
            {
                oItem2.Text = oArregloResumenRecordatorios[Contador].ToString().Trim();
                Contador++;

                if (oCalendario2.ViewIntersects(oItem2))
                    oCalendario2.Items.Add(oItem2);
            }
        }

        public void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            oCalendario.Invalidate();
            oCalendario2.Invalidate();            

            oCalendario.SetViewRange(e.Start, e.Start);
            oCalendario.TimeScale = CalendarTimeScale.ThirtyMinutes;

            oCalendario2.SetViewRange(e.Start.AddDays(1), e.Start.AddDays(1));
            oCalendario2.TimeScale = CalendarTimeScale.ThirtyMinutes;

            int Index = 0;
            foreach (CalendarDay oDay in oCalendario.Days)
            {
                if (oDay.Date == monthCalendar1.SelectionEnd.Date)
                {
                    Index = oDay.Index;
                    break;
                }
            }

            System.Windows.Forms.Calendar.CalendarDayEventArgs e2 = new CalendarDayEventArgs(this.oCalendario.Days[Index]);
            
            oCalendario.EnsureVisible(GetTimeUnit(e2.CalendarDay));


            dateTimePicker1.Value = e.Start;
            dateTimePicker2.Value = e.Start.AddDays(1);

            lblFecha1.Text = dateTimePicker1.Text;
            lblFecha2.Text = dateTimePicker2.Text;
        }

        public void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void tobNuevaCita_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Realmente desea generar una cita el día y a la hora seleccionados?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Program.ofrmCalendario.tobNuevaCita_Click(sender, e);

                if (oFechaSeleccionada.Date != DateTime.MinValue)
                {
                    Program.ofrmCalendario.dtFechaCita.Value = oFechaSeleccionada;
                    this.Close();
                }
                else
                    MessageBox.Show(this, "No se ha seleccionado una fecha válida para realizar estas acciones, seleccione la fecha de cualquiera de las fechas disponibles y vuelva a intentar");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}