using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmMonthCalendar : Form
    {
        public frmMonthCalendar()
        {
            InitializeComponent();
        }

        private Point FormLocation()
        {
            Point oPoint;

            int x = Program.oFrmCuadernoCitas.Left + Program.oFrmCuadernoCitas.Width - this.Width + 25;
            int y = Program.oFrmCuadernoCitas.Top - 25;

            oPoint = new Point(x, y);

            return oPoint;
        }

        private void btnAnterior_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1f;
        }

        private void btnAnterior_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = 0.17f;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            TimeSpan oTimeSpan = new TimeSpan(2, 0, 0, 0);
            DateTime oDateTime = monthCalendar1.SelectionEnd.Subtract(oTimeSpan);

            monthCalendar1.SetDate(oDateTime);
            monthCalendar1.SelectionStart = oDateTime;
            monthCalendar1.SelectionEnd = oDateTime;

            DateRangeEventArgs e2 = new DateRangeEventArgs(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd);
            monthCalendar1_DateSelected(sender, e2);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            DateTime oDateTime = monthCalendar1.SelectionEnd.AddDays(2);

            monthCalendar1.SetDate(oDateTime);
            monthCalendar1.SelectionStart = oDateTime;
            monthCalendar1.SelectionEnd = oDateTime;

            DateRangeEventArgs e2 = new DateRangeEventArgs(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd);
            monthCalendar1_DateSelected(sender, e2);
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            Program.oFrmCuadernoCitas.monthCalendar1_DateSelected(sender, e);
        }

        private void frmMonthCalendar_Load(object sender, EventArgs e)
        {
            this.Location = FormLocation();
        }

        private void frmMonthCalendar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.FormOwnerClosing)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Program.oFrmCuadernoCitas.monthCalendar1_DateChanged(sender, e); 
        }
    }
}