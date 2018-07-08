using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Miscelaneos_y_Recursos;
using G_Clinic.Lógica_Negocios;
using System.IO;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmVideosConsulta : Form
    {
        public frmVideosConsulta()
        {
            InitializeComponent();

            this.Region = Shape.RoundedRegion(this.Size, 8, Shape.Corner.None);

            this.Left = ((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2);

            int top = 0;
            top = Screen.PrimaryScreen.WorkingArea.Height - this.Height - Program.oMDI.statusStrip1.Height - Program.oFrmDock.Height + 5;

            if (top < 0)
                top = 0;

            this.Top = top;

            //try
            //{
            //    VistaConstants.SetWindowTheme(lstVideos.Handle, "explorer", null); //Explorer style
            //    VistaConstants.SendMessage(lstVideos.Handle, VistaConstants.LVM_SETEXTENDEDLISTVIEWSTYLE, VistaConstants.LVS_EX_DOUBLEBUFFER, VistaConstants.LVS_EX_DOUBLEBUFFER);
            //}
            //catch { }
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

        CVideosConsulta oCVideosConsulta = new CVideosConsulta();

        public void LlenarCarpetas()
        {
            //lstVideos.Items.Clear();
            flowLayoutPanel1.Controls.Clear();

            string folderName = "";

            string sql = "Select a.id_consulta, a.fecha_consulta from Consulta_Paciente a, Videos_Consulta b " +
                         "where a.id_consulta = b.id_consulta and a.num_expediente = " + numExpediente.Trim() +
                         " group by a.id_consulta, a.fecha_consulta";

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(sql.Trim(), "Consulta_Paciente");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                folderName = "Consulta #" + dr[0].ToString() + ", " + Convert.ToDateTime(dr[1]).ToShortDateString();

                oImagenCambianteLabel = new ImagenCambianteLabel();
                oImagenCambianteLabel.AutoSize = false;
                oImagenCambianteLabel.Size = new Size(100, 100);
                oImagenCambianteLabel.Image = Properties.Resources.Videos_75;
                oImagenCambianteLabel.HighlightedImage = Properties.Resources.Videos_75_highlighted;
                oImagenCambianteLabel.Text = folderName;
                oImagenCambianteLabel.ForeColor = Color.White;
                oImagenCambianteLabel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                oImagenCambianteLabel.ImageAlign = ContentAlignment.TopCenter;
                oImagenCambianteLabel.TextAlign = ContentAlignment.BottomCenter;
                oImagenCambianteLabel.Tag = dr[0].ToString().Trim();

                oImagenCambianteLabel.Click += new EventHandler(oImagenCambianteLabel_Click);

                flowLayoutPanel1.Controls.Add(oImagenCambianteLabel);
            }
            ds.Dispose();
        }

        void oImagenCambianteLabel_Click(object sender, EventArgs e)
        {
            ImagenCambianteLabel iMCL = (ImagenCambianteLabel)sender;
            LlenarListaVideos(iMCL.Tag.ToString().Trim());
        }

        private void LlenarListaVideos(string pIdConsulta)
        {
            //lstVideos.Items.Clear();
            int index = 0;
            string[] fileNames;

            oCVideosConsulta.IdConsulta = pIdConsulta.Trim();
            DataSet ds = oCVideosConsulta.ConsultarDataset();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    fileNames = new string[ds.Tables[0].Rows.Count];
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        fileNames.SetValue(dr[1].ToString().Trim(), index);
                        index++;
                    }
                    
                    softNetVideoControl1.AddFiles(fileNames);
                }
            }
            ds.Dispose();
        }

        private void frmVideosConsulta_Load(object sender, EventArgs e)
        {
        }

        private void btnReproducirVideo_Click(object sender, EventArgs e)
        {
            //if (lstVideos.Items.Count > 0)
            //{
            //    if (lstVideos.SelectedItems.Count > 0)
            //    {
            //        if (File.Exists(lstVideos.SelectedItems[0].SubItems[1].Text.Trim()))
            //        {
            //            softNetVideoPlayer22.Visible = true;
            //            softNetVideoPlayer22.Update();

            //            if (softNetVideoPlayer32 != null)
            //                softNetVideoPlayer32.Dispose();

            //            softNetVideoPlayer32 = new SoftNetVideoPlayer3();
            //            softNetVideoPlayer32.Size = new Size(437, 333);
            //            panel2.Controls.Add(softNetVideoPlayer32);
            //            softNetVideoPlayer32.Location = new Point(339, 82);

            //            string videoURL = lstVideos.SelectedItems[0].SubItems[1].Text.Trim();
            //            softNetVideoPlayer32.VideoURL = videoURL.Trim();
            //            softNetVideoPlayer32.lstVideos.Items.Add(videoURL.Trim());
            //            softNetVideoPlayer32.lstVideos.Items[softNetVideoPlayer32.lstVideos.Items.Count - 1].SubItems.Add(videoURL.Trim());

            //            softNetVideoPlayer32.tobPlay.Enabled = true;
            //            softNetVideoPlayer32.axVLCPlugin1.addTarget(videoURL.Trim(), null, AXVLC.VLCPlaylistMode.VLCPlayListReplaceAndGo, 0);

            //            softNetVideoPlayer32.VideoOptionsEnable = false;
            //            softNetVideoPlayer32.tobPlay_Click(sender, e);

            //            softNetVideoPlayer22.Visible = false;
            //        }
            //        else
            //            MessageBox.Show(this, "No se puede encontrar el archivo indicado, verifique la ubicación del mismo");
            //    }
            //}
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (Program.oFrmExamenesConsulta != null && Program.oFrmDetallePaciente != null && Program.oFrmImagenesConsultas != null && 
                Program.oFrmHistorialConsultas != null && Program.oFrmEmbarazos != null)
            {
                if (Program.oFrmExamenesConsulta.Activo == false && Program.oFrmDetallePaciente.Activo == false &&
                    Program.oFrmImagenesConsultas.Activo == false && Program.oFrmHistorialConsultas.Activo == false &&
                    Program.oFrmEmbarazos.Activo == false)
                {
                    EventArgs e2 = new EventArgs();
                    Program.oFrmDock.frmDock_MouseLeave(sender, e2);
                }
            }
        }

        private void frmVideosConsulta_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                activo = true;
            else
            {
                activo = false;

                try
                {
                    Program.oMDI.Activate();
                }
                catch { }
            }
        }

        private void frmVideosConsulta_FormClosing(object sender, FormClosingEventArgs e)
        {
            //softNetVideoPlayer22.tobStop_Click(sender, e);

            //if (softNetVideoPlayer32 != null)
            //    softNetVideoPlayer32.tobStop_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnSalir_Click(sender, e);
        }

    }
}