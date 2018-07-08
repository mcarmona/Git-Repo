using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using G_Clinic.Lógica_Negocios;
using G_Clinic.Miscelaneos_y_Recursos;
using System.Collections;
using System.IO;

namespace G_Clinic.Interfaz_Grafica
{
    public partial class frmImagenesConsultas : Form
    {
        #region Variables

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
        CImagenesConsulta oCImagenesConsulta = new CImagenesConsulta();

        List<GlobalElementsValues> oGlobalElementList = new List<GlobalElementsValues>();
        GlobalElementsValues tempGlobalElementValues = new GlobalElementsValues();

        #endregion

        public frmImagenesConsultas()
        {
            InitializeComponent();

            this.Region = Shape.RoundedRegion(this.Size, 8, Shape.Corner.None);

            this.Left = ((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2);

            int top = 0;
            top = Screen.PrimaryScreen.WorkingArea.Height - this.Height - Program.oMDI.statusStrip1.Height - Program.oFrmDock.Height + 5;

            if (top < 0)
                top = 0;

            this.Top = top;
        }

        public void LlenarCarpetas()
        {
            this.photoAlbum1.Clear();
            flowLayoutPanel1.Controls.Clear();

            string folderName = "";

            string sql = "Select a.id_consulta, a.fecha_consulta from Consulta_Paciente a, Imagenes_Consulta b " +
                         "where a.id_consulta = b.id_consulta and a.num_expediente = " + numExpediente.Trim() +
                         " group by a.id_consulta, a.fecha_consulta";

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(sql.Trim(), "Consulta_Paciente");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                folderName = "Consulta #" + dr[0].ToString() + ", " + Convert.ToDateTime(dr[1]).ToShortDateString();

                oImagenCambianteLabel = new ImagenCambianteLabel();
                oImagenCambianteLabel.AutoSize = false;
                oImagenCambianteLabel.Size = new Size(100, 100);
                oImagenCambianteLabel.Image = Properties.Resources.Pictures_75;
                oImagenCambianteLabel.HighlightedImage = Properties.Resources.Pictures_75_highlighted;
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

        private Image ConvierteBytesImagenes(byte[] pImageData)
        {
            Image newImage = null;

            //Get image data from gridview column.
            byte[] imageData = pImageData;

            //Read image data into a memory stream
            using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
            {
                ms.Write(imageData, 0, imageData.Length);

                //Set image variable value using memory stream.
                newImage = Image.FromStream(ms, true);
            }

            return newImage;
        }

        public void ResetImageControl()
        {
            photoAlbum1.Dispose();
            oGlobalElementList = null;

            photoAlbum1 = new PhotoAlbum();
            this.Controls.Add(photoAlbum1);
            photoAlbum1.Location = new Point(220, 5);
            photoAlbum1.Size = new Size(838, 554); 
        }

        private void LlenarImagenes(string pIdConsulta)
        {
            ResetImageControl();
            oGlobalElementList = new List<GlobalElementsValues>();
            photoAlbum1.Clear();

            int cont = 0;

            oCImagenesConsulta.IdConsulta = pIdConsulta.Trim();
            DataSet ds = oCImagenesConsulta.ConsultarDataset();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        tempGlobalElementValues = new GlobalElementsValues();
                        tempGlobalElementValues.OFileName = cont.ToString();
    
                        tempGlobalElementValues.OBytes = (byte[])dr[1];
                        tempGlobalElementValues.OImage = ConvierteBytesImagenes((byte[])dr[1]);
                        tempGlobalElementValues.OIndex = cont;

                        oGlobalElementList.Add(tempGlobalElementValues);

                        cont++;
                    }
                }
            }
            ds.Dispose();

            photoAlbum1.OListGlobalElementsValues = oGlobalElementList;
            photoAlbum1.AñadirImagenes();
        }

        void oImagenCambianteLabel_Click(object sender, EventArgs e)
        {
            ImagenCambianteLabel iMCL = (ImagenCambianteLabel)sender;
            LlenarImagenes(iMCL.Tag.ToString().Trim());
        }

        private void frmImagenesConsultas_Load(object sender, EventArgs e)
        {
        }

        private void frmImagenesConsultas_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                activo = true;
            else
            {
                activo = false;
                Program.oMDI.Activate();
            }
        }

        private void btnPhotoAlbum_Click(object sender, EventArgs e)
        {
            FrmBlackBackground oFrmBlackBackground = new FrmBlackBackground();
            oFrmBlackBackground.Show();
            frmPhotoAlbum ofrmPhotoAlbum = new frmPhotoAlbum(oGlobalElementList);

            ofrmPhotoAlbum.ShowDialog();
            oFrmBlackBackground.Close();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            if (Program.oFrmExamenesConsulta != null && Program.oFrmDetallePaciente != null && Program.oFrmHistorialConsultas != null &&
                Program.oFrmVideosConsulta != null && Program.oFrmEmbarazos != null)
            {
                if (Program.oFrmExamenesConsulta.Activo == false && Program.oFrmDetallePaciente.Activo == false &&
                    Program.oFrmHistorialConsultas.Activo == false && Program.oFrmVideosConsulta.Activo == false &&
                    Program.oFrmEmbarazos.Activo == false)
                {
                    EventArgs e2 = new EventArgs();
                    Program.oFrmDock.frmDock_MouseLeave(sender, e2);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnSalir_Click_1(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            btnPhotoAlbum_Click(sender, e);
        }

        private void photoAlbum1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void frmImagenesConsultas_KeyDown(object sender, KeyEventArgs e)
        {
            photoAlbum1.PhotoAlbum_KeyDown(sender, e);
        }
    }
}