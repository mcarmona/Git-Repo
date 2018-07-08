using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using G_Clinic.Interfaz_Grafica;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic
{
    public partial class FrmMiEmpresa : Form
    {
        public FrmMiEmpresa()
        {
            InitializeComponent();
            Utilidades.EstablecerFuentesEnFormulario(this, FormType.Mantenimiento);
        }

        bool Ingresar_Otra = false;
        bool Presionado = false;
        bool Modificar = false;
        bool Click_Modificar = false;
        bool Click_Eliminar = false;
        private long m_lImageFileLength = 0;
        private byte[] m_barrImg;
        string DireccImage = "";
        int Contador_Filas_Actuales = 0;
        byte[] InfoImagen;//Variable opcional para no tener que leer la imagen desde el disco duro, sino desde la Bd en caso de que no se modifique o elimine la imagen
        byte[] Imagen = null;

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            Presionado = true;

            if (tabPage1.Focus())
            {
                if (Presionado == true)
                {
                    tabControl1.SelectedIndex = 1; //tabpage 2
                    Presionado = false;
                    BtnAnterior.Enabled = true;

                    if (Grid1.Rows[0].Cells[0].Value == null)
                    {
                        TxtCodigo.Text = "1";
                        TxtPaisCiudad.Focus();
                    }
                    else
                        BtnIngresarOtra.Focus();  
                }
            }

            if (tabPage2.Focus())
            {
                TxtPaisCiudad.Focus();
                if (Ingresar_Otra == false)
                {
                    if (Presionado == true)
                    {
                        if (Grid1.Rows[0].Cells[0].Value == null)
                            MessageBox.Show(this, "No hay ninguna Empresa ingresada, Ingrese los datos necesarios y seguidamente presione el botón: \"Listo\" para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            tabControl1.SelectedIndex = 2;
                            Presionado = false;
                            SendKeys.Send("{TAB}");

                            if (Program.oFrmMailSettings.Abierto == true)
                                Program.oFrmMailSettings.Hide();
                        }
                    }
                }
            }

            if (tabPage3.Focus())
            {
                if (Grid1.Rows[0].Cells[0].Value == null)
                {
                    MessageBox.Show(this, "No hay ninguna Empresa ingresada, Ingrese los datos necesarios y seguidamente presione el botón: \"Listo\" para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    if (Presionado == true)
                    {
                        tabControl1.SelectedIndex = 3;
                        Presionado = false;
                    }
                }
            }

            if (tabPage4.Focus())
            {
                if (Grid1.Rows[0].Cells[0].Value == null)
                {
                    MessageBox.Show(this, "No hay ninguna Empresa ingresada, Ingrese los datos necesarios y seguidamente presione el botón: \"Listo\" para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (Presionado == true)
                    {
                        tabControl1.SelectedIndex = 4;
                        Presionado = false;
                        BtnSiguiente.Enabled = false;
                    }
                }
            }
        }

        public bool VerificarCampos()
        {
            bool Correcto = true;

            if (txtEspecialidad.Text.Trim() == "")
            {
                MessageBox.Show(this, "El campo de Especialidad no puede estar vacío. Verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Correcto = false;
                txtEspecialidad.Focus();
            }

            if (txtServicios.Text.Trim() == "")
            {
                MessageBox.Show(this, "El campo de Servicios Ofrecidos no puede estar vacío. Verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Correcto = false;
                txtServicios.Focus();
            }

            if (TxtCedulaJuridica.Text.Trim() == "")
            {
                MessageBox.Show(this, "El campo de Cédula Jurídica no puede estar vacío. Verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Correcto = false;
                TxtCedulaJuridica.Focus();
            }

            if (TxtPaisCiudad.Text.Trim() == "")
            {
                MessageBox.Show(this, "El campo de País/Ciudad no puede estar vacío. Verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Correcto = false;
                TxtPaisCiudad.Focus();
            }

            if (TxtDirección.Text.Trim() == "")
            {
                MessageBox.Show(this, "El campo de la Dirección no puede estar vacío. Verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Correcto = false;
                TxtDirección.Focus();
            }

            if (TxtNombre.Text.Trim() == "")
            {
                MessageBox.Show(this, "El campo de Nombre de la Empresa no puede estar vacío. Verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Correcto = false;
                TxtNombre.Focus();
            }

            if (TxtTelefono.Text.Trim() == "")
            {
                MessageBox.Show(this, "El campo de Teléfono no puede estar vacío. Verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Correcto = false;
                TxtTelefono.Focus();
            }

            if (TxtCodigo.Text.Trim() == "")
            {
                MessageBox.Show(this, "El campo de Código no puede estar vacío. Verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Correcto = false;
                TxtCodigo.Focus();
            }

            return Correcto;
        }

        private void BtnListo_Click(object sender, EventArgs e)
        {
            if (VerificarCampos() == true)
            {
                bool REpetido = false;

                if (Grid1.Rows[0].Cells[0].Value != null)
                {
                    if (TxtCodigo.Text != "" && TxtNombre.Text != "" && TxtDirección.Text != "" && TxtTelefono.Text != ""
                        && TxtPaisCiudad.Text != "")
                    {
                        foreach (DataGridViewRow dr in Grid1.Rows)
                        {
                            if (dr.Cells[0].Value != null)
                            {
                                if (Modificar == false)
                                {
                                    if (TxtCodigo.Text.Trim().ToLower() != dr.Cells["Codigo_Empresa"].Value.ToString().Trim().ToLower() ||
                                        TxtNombre.Text.Trim().ToLower() != dr.Cells["Nombre"].Value.ToString().Trim().ToLower() ||
                                        TxtDirección.Text.Trim().ToLower() != dr.Cells["Direccion"].Value.ToString().Trim().ToLower())

                                        REpetido = false;
                                    else
                                        REpetido = true;
                                }
                            }
                        }

                        if (REpetido == false)
                        {
                            if (Modificar == true)
                            {
                                Grid1.CurrentRow.Cells["Codigo_Empresa"].Value = TxtCodigo.Text.Trim();
                                Grid1.CurrentRow.Cells["Nombre"].Value = TxtNombre.Text.Trim();
                                Grid1.CurrentRow.Cells["Direccion"].Value = TxtDirección.Text.Trim();
                                Grid1.CurrentRow.Cells["Telefono"].Value = TxtTelefono.Text.Trim();
                                Grid1.CurrentRow.Cells["Pagina_Web"].Value = TxtPagWeb.Text.Trim();
                                Grid1.CurrentRow.Cells["Correo_Electronico"].Value = TxtCorreoElectrónico.Text.Trim();
                                Grid1.CurrentRow.Cells["Pais_Ciudad"].Value = TxtPaisCiudad.Text.Trim();
                                Grid1.CurrentRow.Cells["Ced_Juridica"].Value = TxtCedulaJuridica.Text.Trim();
                                Grid1.CurrentRow.Cells["Especialidad"].Value = txtEspecialidad.Text.Trim();
                                Grid1.CurrentRow.Cells["Servicios"].Value = txtServicios.Text.Trim();

                                Ingresar_Otra = false;

                                BtnListo.Enabled = false;
                                BtnCancelar.Enabled = false;
                                BtnIngresarOtra.Enabled = true;

                                TxtCodigo.Text = "";
                                TxtNombre.Text = "";
                                TxtDirección.Text = "";
                                TxtTelefono.Text = "";
                                TxtPagWeb.Text = "";
                                TxtCorreoElectrónico.Text = "";
                                TxtPaisCiudad.Text = "";
                                TxtCedulaJuridica.Text = "";
                                txtEspecialidad.Text = "";
                                txtServicios.Text = "";

                                ModoBloqueo();
                                Modificar = false;

                                if (Grid1.Rows.Count > 1)
                                {
                                    foreach (DataGridViewRow Fila in Grid1.Rows)
                                    {
                                        if (Fila.Cells[0].Value != null)
                                        {
                                            Fila.Cells["Nombre"].Value = Grid1.CurrentRow.Cells["Nombre"].Value.ToString().Trim();
                                            Fila.Cells["Pais_Ciudad"].Value = Grid1.CurrentRow.Cells["Pais_Ciudad"].Value.ToString().Trim();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Grid1.Rows.Add(TxtCodigo.Text.Trim(), TxtPaisCiudad.Text.Trim(), TxtNombre.Text.Trim(), txtEspecialidad.Text.Trim(), 
                                    txtServicios.Text.Trim(), TxtCedulaJuridica.Text.Trim(), TxtDirección.Text.Trim(), TxtTelefono.Text.Trim(),
                                    TxtPagWeb.Text.Trim(), TxtCorreoElectrónico.Text.Trim());

                                Ingresar_Otra = false;

                                BtnListo.Enabled = false;
                                BtnCancelar.Enabled = false;
                                BtnIngresarOtra.Enabled = true;

                                TxtCodigo.Text = "";
                                TxtNombre.Text = "";
                                TxtDirección.Text = "";
                                TxtTelefono.Text = "";
                                TxtPagWeb.Text = "";
                                TxtCorreoElectrónico.Text = "";
                                TxtPaisCiudad.Text = "";
                                TxtCedulaJuridica.Text = "";
                                txtEspecialidad.Text = "";
                                txtServicios.Text = "";

                                ModoBloqueo();
                                Modificar = false;
                            }
                        }
                    }
                    else
                        MessageBox.Show(this, "Los campos con un círculo de color rojo son necesarios por lo que ninguno puede permanecer vacío, verifique los valores para continuar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (Grid1.Rows.Count == 1)
                {
                    if (Modificar == true)
                    {
                        Grid1.CurrentRow.Cells["Codigo_Empresa"].Value = TxtCodigo.Text;
                        Grid1.CurrentRow.Cells["Nombre"].Value = TxtNombre.Text;
                        Grid1.CurrentRow.Cells["Direccion"].Value = TxtDirección.Text;
                        Grid1.CurrentRow.Cells["Telefono"].Value = TxtTelefono.Text;
                        Grid1.CurrentRow.Cells["Pagina_Web"].Value = TxtPagWeb.Text;
                        Grid1.CurrentRow.Cells["Correo_Electronico"].Value = TxtCorreoElectrónico.Text;
                        Grid1.CurrentRow.Cells["Pais_Ciudad"].Value = TxtPaisCiudad.Text;
                        Grid1.CurrentRow.Cells["Ced_Juridica"].Value = TxtCedulaJuridica.Text.Trim();
                        Grid1.CurrentRow.Cells["Especialidad"].Value = txtEspecialidad.Text.Trim();
                        Grid1.CurrentRow.Cells["Servicios"].Value = txtServicios.Text.Trim();

                        Ingresar_Otra = false;

                        BtnListo.Enabled = false;
                        BtnCancelar.Enabled = false;
                        BtnIngresarOtra.Enabled = true;

                        TxtCodigo.Text = "";
                        TxtNombre.Text = "";
                        TxtDirección.Text = "";
                        TxtTelefono.Text = "";
                        TxtPagWeb.Text = "";
                        TxtCorreoElectrónico.Text = "";
                        TxtPaisCiudad.Text = "";
                        TxtCedulaJuridica.Text = "";
                        txtEspecialidad.Text = "";
                        txtServicios.Text = "";

                        ModoBloqueo();
                        Modificar = false;
                    }
                    else
                    {
                        Grid1.Rows.Add(TxtCodigo.Text.Trim(), TxtPaisCiudad.Text.Trim(), TxtNombre.Text.Trim(), txtEspecialidad.Text.Trim(), txtServicios.Text.Trim(),
                                       TxtCedulaJuridica.Text.Trim(), TxtDirección.Text.Trim(), TxtTelefono.Text.Trim(), TxtPagWeb.Text.Trim(),
                                       TxtCorreoElectrónico.Text.Trim());

                        Ingresar_Otra = false;

                        BtnListo.Enabled = false;
                        BtnCancelar.Enabled = false;
                        BtnIngresarOtra.Enabled = true;

                        TxtCodigo.Text = "";
                        TxtNombre.Text = "";
                        TxtDirección.Text = "";
                        TxtTelefono.Text = "";
                        TxtPagWeb.Text = "";
                        TxtCorreoElectrónico.Text = "";
                        TxtPaisCiudad.Text = "";
                        TxtCedulaJuridica.Text = "";
                        txtEspecialidad.Text = "";
                        txtServicios.Text = "";

                        ModoBloqueo();
                        Modificar = false;
                    }
                }
            }
        }

        private void BtnIngresarOtra_Click(object sender, EventArgs e)
        {
            Ingresar_Otra = true;
            Modificar = false;

            TxtCodigo.Text = "";
            TxtNombre.Text = "";
            TxtDirección.Text = "";
            TxtTelefono.Text = "";
            TxtPagWeb.Text = "";
            TxtCorreoElectrónico.Text = "";
            TxtPaisCiudad.Text = "";
            TxtCedulaJuridica.Text = "";
            txtEspecialidad.Text = "";
            txtServicios.Text = "";

            BtnListo.Enabled = false;
            BtnCancelar.Enabled = true;
            BtnIngresarOtra.Enabled = false;
            ModoEscritura(); 

            TxtCodigo.Text = Convert.ToString(Convert.ToInt32(Grid1.Rows[Grid1.Rows.Count - 2].Cells[0].Value) + 1);
            TxtPaisCiudad.Focus();

            if (Grid1.Rows.Count > 1)
            {
                if (Grid1.Rows[0].Cells["Nombre"].Value != null && Grid1.Rows[0].Cells["Nombre"].Value != DBNull.Value)
                {
                    TxtNombre.Text = Grid1.Rows[0].Cells["Nombre"].Value.ToString().Trim();
                    TxtNombre.Enabled = false;
                    //TxtPaisCiudad.Text = Grid1.Rows[0].Cells["Pais_Ciudad"].Value.ToString().Trim();
                    //TxtPaisCiudad.Enabled = false;
                    //MessageBox.Show(this,"El nombre de la empresa no puede ser modificable ya que todas las demás empresas o sedes formarán parte de la misma, para cambiar el nombre proceda a dirigirse al siguiente paso y modificar el nombre de la primera empresa generada que será el nombre principal de su empresa"); 
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Ingresar_Otra = false;
            Modificar = false;

            TxtCodigo.Text = "";
            TxtNombre.Text = "";
            TxtDirección.Text = "";
            TxtTelefono.Text = "";
            TxtPagWeb.Text = "";
            TxtCorreoElectrónico.Text = "";
            TxtPaisCiudad.Text = "";
            TxtCedulaJuridica.Text = "";
            txtEspecialidad.Text = "";
            txtServicios.Text = "";

            ModoBloqueo();

            BtnCancelar.Enabled = false;
            BtnListo.Enabled = false;

            if (Grid1.Rows[0].Cells[0].Value != null)
            {
                BtnIngresarOtra.Enabled = true;
            }
            else
            {
                ModoEscritura();
                TxtCodigo.Text = "1";
                BtnListo.Enabled = true;
                BtnCancelar.Enabled = false;
                BtnIngresarOtra.Enabled = false;
            }
        }

        private void ModoBloqueo()
        {
            TxtCodigo.Enabled = false;
            TxtNombre.Enabled = false;
            TxtDirección.Enabled = false;
            TxtTelefono.Enabled = false;
            TxtPagWeb.Enabled = false;
            TxtCorreoElectrónico.Enabled = false;
            TxtPaisCiudad.Enabled = false;
            TxtCedulaJuridica.Enabled = false;
            txtEspecialidad.Enabled = false;
            txtServicios.Enabled = false;
        }

        private void ModoEscritura()
        {
            TxtCodigo.Enabled = true;
            TxtNombre.Enabled = true;
            TxtDirección.Enabled = true;
            TxtTelefono.Enabled = true;
            TxtPagWeb.Enabled = true;
            TxtCorreoElectrónico.Enabled = true;
            TxtPaisCiudad.Enabled = true;
            TxtCedulaJuridica.Enabled = true;
            txtEspecialidad.Enabled = true;
            txtServicios.Enabled = true;

            TxtPaisCiudad.Focus(); 
        }

        private void CargarImagen()
        {
            Image newImage = null;

            try
            {				
                StringBuilder Sql = new StringBuilder("");

                Sql.Append("Select logo from Empresas");

                DataSet ds = Program.oPersistencia.ejecutarSQLListas(Sql.ToString(), "Empresas");

                if(ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            byte[] imageData = (byte[])dr[0];

                            InfoImagen = imageData; 
                            //Initialize image variable

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
                                pictureBox2.BackgroundImage = newImage;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;//.Stretch;
                            }

                            break; 
                        }
                    }
                }
                ds.Dispose(); 
           }
            catch
            {
            }
            finally
            {
                //this.sqlConnection1.Close();
            }
        }

        private void FrmMiEmpresa_Load(object sender, EventArgs e)
        {
            BtnIngresarOtra.Enabled = false;
            BtnAnterior.Enabled = false;
            LLenar_Grid();

            CargarImagen();             

            if (Grid1.Rows[0].Cells[0].Value == null)
            {
                ModoEscritura();
                BtnListo.Enabled = true;
                BtnCancelar.Enabled = false;
                BtnIngresarOtra.Enabled = false;
            }
            else
            {
                ModoBloqueo();
                BtnListo.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnIngresarOtra.Enabled = true; 
            }

            Contador_Filas_Actuales = Grid1.Rows.Count;

            Program.oFrmMailSettings = new frmMailSettings();
            //if (Grid1.Rows.Count > 1)
            //    BtnIngresarOtra.Enabled = true;
        }

        private void bn_cancelar1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            Presionado = true;

            if (tabPage1.Focus())
            {
            }

            if (tabPage2.Focus())
            {
                if (Presionado == true)
                {
                    tabControl1.SelectedIndex = 0; //tabpage 2
                    Presionado = false;
                    BtnAnterior.Enabled = false;
                    BtnSiguiente.Enabled = true;
                }
            }

            if (tabPage3.Focus())
            {
                if (Presionado == true)
                {
                    tabControl1.SelectedIndex = 1; //tabpage 2
                    Presionado = false;
                    BtnSiguiente.Enabled = true;
                }

                if (Grid1.Rows[0].Cells[0].Value == null)
                {
                    ModoEscritura();
                    BtnListo.Enabled = true;
                    BtnCancelar.Enabled = false;
                    BtnIngresarOtra.Enabled = false;
                    TxtCodigo.Text = "1"; 
                }

                BtnSiguiente.Enabled = true;
            }

            if (tabPage4.Focus())
            {
                if (Presionado == true)
                {
                    tabControl1.SelectedIndex = 2;
                    Presionado = false;
                    BtnSiguiente.Enabled = true;
                }
            }

            if (tabPage5.Focus())
            {
                if (Presionado == true)
                {
                    tabControl1.SelectedIndex = 3;
                    Presionado = false;
                    BtnSiguiente.Enabled = true;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Grid1.CurrentRow != null)
                {
                    if (Grid1.CurrentRow.Cells["Codigo_Empresa"].Value != null)
                    {
                        Modificar = true;
                        Click_Modificar = true;

                        TxtCodigo.Text = Grid1.CurrentRow.Cells["Codigo_Empresa"].Value.ToString();
                        TxtNombre.Text = Grid1.CurrentRow.Cells["Nombre"].Value.ToString();
                        TxtDirección.Text = Grid1.CurrentRow.Cells["Direccion"].Value.ToString();
                        TxtTelefono.Text = Grid1.CurrentRow.Cells["Telefono"].Value.ToString();
                        TxtPagWeb.Text = Grid1.CurrentRow.Cells["Pagina_Web"].Value.ToString();
                        TxtCorreoElectrónico.Text = Grid1.CurrentRow.Cells["Correo_Electronico"].Value.ToString();
                        TxtPaisCiudad.Text = Grid1.CurrentRow.Cells["Pais_Ciudad"].Value.ToString();
                        TxtCedulaJuridica.Text = Grid1.CurrentRow.Cells["Ced_Juridica"].Value.ToString();
                        txtEspecialidad.Text = Grid1.CurrentRow.Cells["Especialidad"].Value.ToString();
                        txtServicios.Text = Grid1.CurrentRow.Cells["Servicios"].Value.ToString();

                        BtnAnterior_Click(sender, e);

                        ModoEscritura();
                        BtnCancelar.Enabled = true;
                        BtnListo.Enabled = true;
                        BtnIngresarOtra.Enabled = false;

                        if (Grid1.Rows.Count > 1)
                        {
                            if (Grid1.SelectedRows[0].Index == 0)
                            {
                                TxtNombre.Enabled = true;
                                //TxtPaisCiudad.Enabled = true;
                            }
                            else
                            {
                                TxtNombre.Enabled = false;
                                //TxtPaisCiudad.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void TxtCorreoElectrónico_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Grid1.CurrentRow != null)
                {
                    if (Grid1.CurrentRow.Cells["Codigo_Empresa"].Value != null)
                    {
                        if (Grid1.CurrentRow.Index > 0)
                        {
                            StringBuilder Sql = new StringBuilder();

                            Sql.Append("Delete from Empresas where id_empresa = " + Grid1.CurrentRow.Cells["Codigo_Empresa"].Value.ToString().Trim());

                            // Ejecutar Store Procedure
                            Program.oPersistencia.ejecutarSQLTransaccion(Sql.ToString());

                            // Verifico el Error
                            if (Program.oPersistencia.IsError == true)
                            {
                                //MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                                MessageBox.Show(this, "La empresa que ha intentado eliminar está siendo utilizada por otras pantallas o procesos del sistema por lo que no puede ser eliminada, modifique las dependencias de esta primero como la asignación de una máquina a esta empresa para poder continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                System.Media.SystemSounds.Exclamation.Play();
                            }
                            else
                            {
                                StringBuilder SQL12 = new StringBuilder();

                                SQL12.Append("select * from Empresas");

                                DataSet ds12 = Program.oPersistencia.ejecutarSQLListas(SQL12.ToString(), "Empresas");
                                //Extraer un DataSet
                                if (ds12 != null)
                                {
                                    if (ds12.Tables[0].Rows.Count == 0)
                                    {
                                        StringBuilder sql = new StringBuilder();

                                        sql.Append("DBCC CHECKIDENT (Empresas, RESEED,0)");

                                        // Ejecutar Store Procedure
                                        DataSet ds = Program.oPersistencia.ejecutarSQLListas(sql.ToString(), "Empresas");

                                        // Verifico el Error
                                        if (Program.oPersistencia.IsError == true)
                                        {
                                            MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                                        }

                                        if (Grid1.CurrentRow.Index == 0)
                                        {
                                            Grid1.Rows.Clear();  
                                        }
                                        else if (Grid1.CurrentRow.Index > 0)
                                        {
                                            Grid1.Rows.Remove(Grid1.CurrentRow);
                                        }

                                    }
                                    else
                                    {
                                        Grid1.Rows.Clear();
                                        LLenar_Grid();
                                    }
                                }
                            }
                        }
                        else
                        {
                            StringBuilder SQL12 = new StringBuilder();

                            SQL12.Append("select * from Empresas");

                            DataSet ds12 = Program.oPersistencia.ejecutarSQLListas(SQL12.ToString(), "Empresas");
                            //Extraer un DataSet
                            if (ds12 != null)
                            {
                                if (ds12.Tables[0].Rows.Count == 0)
                                {
                                    if (Grid1.CurrentRow.Index == 0)
                                    {
                                        if (MessageBox.Show(this, "Si decide borrar la Empresa Madre se eliminarán todas las demás empresas ingresadas, ¿Está seguro que desea continuar?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                                        {
                                            Grid1.Rows.Clear();
                                        }
                                    }
                                }
                                else if (ds12.Tables[0].Rows.Count > 0)
                                {
                                    if (Grid1.CurrentRow.Index == 0)
                                    {
                                        MessageBox.Show(this, "La Empresa Madre del Sistema no puede ser eliminada, sin embargo recuerde que puede modificar sus valores según guste mediante el botón \"Modificar\"", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            ds12.Dispose();
                        }
                    }
                }

                if (Grid1.Rows.Count == 1)
                    BtnAnterior_Click(sender, e); 
            }
            catch { }
        }

        byte[] ReadFile(string sPath)
        {
            try
            {
                //Initialize byte array with a null value initially.
                byte[] data = null;

                //Use FileInfo object to get file size.
                FileInfo fInfo = new FileInfo(sPath);
                long numBytes = fInfo.Length;

                //Open FileStream to read file
                FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

                //Use BinaryReader to read file stream into byte array.
                BinaryReader br = new BinaryReader(fStream);

                //When you use BinaryReader, you need to supply number of bytes to read from file.
                //In this case we want to read entire file. So supplying total number of bytes.
                data = br.ReadBytes((int)numBytes);
                return data;
            }
            catch
            {
                return null;
            }
        }

        private void bn_Final_Click(object sender, EventArgs e)
        {
            bool GuardadoSatisfactoriamente = false;
            pb_datos.Value = 0;
            byte[] imageData = ReadFile(DireccImage.Trim());
            string qry = "";
            SqlCommand SqlCom = null;

            if (imageData == null)
                imageData = InfoImagen; 

            foreach (DataGridViewRow Linea in Grid1.Rows)
            {
                if (Linea.Cells[0].Value != null)
                {
                    bool IngresadoPreviamente = false;
                    StringBuilder SQL12 = new StringBuilder();

                    SQL12.Append("select * from Empresas");

                    DataSet ds12 = Program.oPersistencia.ejecutarSQLListas(SQL12.ToString(), "Empresas");
                    //Extraer un DataSet
                    if (ds12 != null)
                    {
                        if (ds12.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr12 in ds12.Tables[0].Rows)
                            {
                                if (dr12[0].ToString().Trim() == Linea.Cells["Codigo_Empresa"].Value.ToString().Trim())
                                {
                                    IngresadoPreviamente = true;
                                    break;
                                }
                            }
                        }
                    }
                    ds12.Dispose();

                    if (IngresadoPreviamente == false)
                    {
                        pb_datos.Step = 5;

                        if (Linea.Cells[0].Value != null)
                        {
                            pb_datos.PerformStep(); // Incrementa el progress bar en 5

                            if (imageData != null)
                            {
                                qry = "insert into Empresas(pais_ciudad, nombre, especialidad, servicios_ofrecidos, ced_juridica, direccion, telefono, paginaweb, email, logo) " +
                                                   "values (@pais_ciudad, @nombre, @especialidad, @servicios_ofrecidos, @ced_juridica, @direccion, @telefono, @pag_web, @email, @logo)";
                                pb_datos.PerformStep();
                                //Initialize SqlCommand object for insert.
                                SqlCom = new SqlCommand(qry, Program.oPersistencia.conexion);
                                pb_datos.PerformStep();
                            }
                            else
                            {
                                qry = "insert into Empresas(pais_ciudad, nombre, especialidad, servicios_ofrecidos, ced_juridica, direccion, telefono, paginaweb, email, logo) " +
                                                   "values (@pais_ciudad, @nombre, @especialidad, @servicios_ofrecidos, @ced_juridica, @direccion, @telefono, @pag_web, @email, '')";
                                pb_datos.PerformStep();
                                //Initialize SqlCommand object for insert.
                                SqlCom = new SqlCommand(qry, Program.oPersistencia.conexion);
                                pb_datos.PerformStep();
                            }

                            SqlCom.Parameters.Add(new SqlParameter("@pais_ciudad", (object)Linea.Cells["Pais_Ciudad"].Value.ToString().Trim()));
                            pb_datos.PerformStep();
                            SqlCom.Parameters.Add(new SqlParameter("@nombre", (object)Linea.Cells["Nombre"].Value.ToString().Trim()));
                            pb_datos.PerformStep();
                            SqlCom.Parameters.Add(new SqlParameter("@especialidad", (object)Linea.Cells["Especialidad"].Value.ToString().Trim()));
                            pb_datos.PerformStep();
                            SqlCom.Parameters.Add(new SqlParameter("@servicios_ofrecidos", (object)Linea.Cells["Servicios"].Value.ToString().Trim()));
                            pb_datos.PerformStep();
                            SqlCom.Parameters.Add(new SqlParameter("@ced_juridica", (object)Linea.Cells["Ced_Juridica"].Value.ToString().Trim()));
                            pb_datos.PerformStep();
                            SqlCom.Parameters.Add(new SqlParameter("@direccion", (object)Linea.Cells["Direccion"].Value.ToString().Trim()));
                            pb_datos.PerformStep();
                            SqlCom.Parameters.Add(new SqlParameter("@telefono", (object)Linea.Cells["Telefono"].Value.ToString().Trim()));
                            pb_datos.PerformStep();
                            SqlCom.Parameters.Add(new SqlParameter("@pag_web", (object)Linea.Cells["Pagina_Web"].Value.ToString().Trim()));
                            pb_datos.PerformStep();
                            SqlCom.Parameters.Add(new SqlParameter("@email", (object)Linea.Cells["Correo_Electronico"].Value.ToString().Trim()));
                            pb_datos.PerformStep();
                            if (imageData != null)
                                SqlCom.Parameters.Add(new SqlParameter("@logo", (object)imageData));
                            pb_datos.PerformStep();

                            SqlCom.ExecuteNonQuery();

                            // Verifico el Error
                            if (Program.oPersistencia.IsError == true)
                            {
                                MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                            }
                            else
                                GuardadoSatisfactoriamente = true;                            
                        }
                        pb_datos.Value = 100;
                    }
                    else
                    {
                        if (imageData != null)
                        {
                            qry = "Update Empresas set pais_ciudad = @pais_ciudad, nombre = @nombre, especialidad = @especialidad, servicios_ofrecidos = @servicios_ofrecidos, ced_juridica = @ced_juridica, direccion = @direccion, " +
                                "telefono = @telefono, paginaweb = @pag_web, email = @email, logo = @logo  where id_empresa = @id_empresa";
                            pb_datos.PerformStep();
                            //Initialize SqlCommand object for insert.
                            SqlCom = new SqlCommand(qry, Program.oPersistencia.conexion);
                            pb_datos.PerformStep();
                        }
                        else
                        {
                            qry = "Update Empresas set pais_ciudad = @pais_ciudad, nombre = @nombre, ced_juridica = @ced_juridica, direccion = @direccion, " +
                                "telefono = @telefono, paginaweb = @pag_web, email = @email, logo = '' where id_empresa = @id_empresa";
                            pb_datos.PerformStep();
                            //Initialize SqlCommand object for insert.
                            SqlCom = new SqlCommand(qry, Program.oPersistencia.conexion);
                            pb_datos.PerformStep();
                        }

                        SqlCom.Parameters.Add(new SqlParameter("@pais_ciudad", (object)Linea.Cells["Pais_Ciudad"].Value.ToString().Trim()));
                        pb_datos.PerformStep();
                        SqlCom.Parameters.Add(new SqlParameter("@nombre", (object)Linea.Cells["Nombre"].Value.ToString().Trim()));
                        pb_datos.PerformStep();
                        SqlCom.Parameters.Add(new SqlParameter("@especialidad", (object)Linea.Cells["Especialidad"].Value.ToString().Trim()));
                        pb_datos.PerformStep();
                        SqlCom.Parameters.Add(new SqlParameter("@servicios_ofrecidos", (object)Linea.Cells["Servicios"].Value.ToString().Trim()));
                        pb_datos.PerformStep();
                        SqlCom.Parameters.Add(new SqlParameter("@ced_juridica", (object)Linea.Cells["Ced_Juridica"].Value.ToString().Trim()));
                        pb_datos.PerformStep();
                        SqlCom.Parameters.Add(new SqlParameter("@direccion", (object)Linea.Cells["Direccion"].Value.ToString().Trim()));
                        pb_datos.PerformStep();
                        SqlCom.Parameters.Add(new SqlParameter("@telefono", (object)Linea.Cells["Telefono"].Value.ToString().Trim()));
                        pb_datos.PerformStep();
                        SqlCom.Parameters.Add(new SqlParameter("@pag_web", (object)Linea.Cells["Pagina_Web"].Value.ToString().Trim()));
                        pb_datos.PerformStep();
                        SqlCom.Parameters.Add(new SqlParameter("@email", (object)Linea.Cells["Correo_Electronico"].Value.ToString().Trim()));
                        pb_datos.PerformStep();
                        if (imageData != null)
                            SqlCom.Parameters.Add(new SqlParameter("@logo", (object)imageData));
                        pb_datos.PerformStep(); 
                        SqlCom.Parameters.Add(new SqlParameter("@id_empresa", (object)Linea.Cells["Codigo_Empresa"].Value.ToString().Trim()));
                        pb_datos.PerformStep();

                        SqlCom.ExecuteNonQuery();

                        #region

                        /*StringBuilder Sql5 = new StringBuilder();

                        Sql5.Append("Update Empresas set nombre = '");
                        pb_datos.PerformStep();
                        Sql5.Append(Linea.Cells["Nombre"].Value.ToString().Trim());
                        pb_datos.PerformStep();
                        Sql5.Append("', direccion = '");
                        pb_datos.PerformStep();
                        Sql5.Append(Linea.Cells["Direccion"].Value.ToString().Trim());
                        pb_datos.PerformStep();
                        Sql5.Append("', telefono = '");
                        pb_datos.PerformStep();
                        Sql5.Append(Linea.Cells["Telefono"].Value.ToString().Trim());
                        pb_datos.PerformStep();
                        Sql5.Append("', paginaweb = '");
                        pb_datos.PerformStep();
                        Sql5.Append(Linea.Cells["Pagina_Web"].Value.ToString().Trim());
                        pb_datos.PerformStep();
                        Sql5.Append("', email = '");
                        pb_datos.PerformStep();
                        Sql5.Append(Linea.Cells["Correo_Electronico"].Value.ToString().Trim());
                        pb_datos.PerformStep();
                        Sql5.Append("', nombre_local = '");
                        pb_datos.PerformStep();
                        Sql5.Append(Linea.Cells["Nombre_Local"].Value.ToString().Trim());
                        pb_datos.PerformStep();
                        Sql5.Append("', pais_ciudad = '");
                        pb_datos.PerformStep();
                        Sql5.Append(Linea.Cells["Pais_Ciudad"].Value.ToString().Trim());
                        pb_datos.PerformStep();
                        if (pictureBox2.Image != null)
                        {
                            Sql5.Append("', logo = '");
                            Sql5.Append(SqlCom.Parameters["@imagen"].Value); 
                            //Sql5.Append(m_barrImg);
                        }
                        Sql5.Append("', ced_juridica = '");
                        pb_datos.PerformStep();
                        Sql5.Append(Linea.Cells["Ced_Juridica"].Value.ToString().Trim());
                        pb_datos.PerformStep();
                        Sql5.Append("' where id_empresa = ");
                        pb_datos.PerformStep();
                        Sql5.Append(Linea.Cells["Codigo_Empresa"].Value.ToString().Trim());
                        pb_datos.PerformStep();

                        // Ejecutar Store Procedure
                        Program.oPersistencia.ejecutarSQLTransaccion(Sql5.ToString());
                        */
                        #endregion
                        // Verifico el Error
                        if (Program.oPersistencia.IsError == true)
                        {
                            MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                        }
                        else
                        {
                            GuardadoSatisfactoriamente = true;
                            Program.oCEmpresa.LeeDatosEmpresa();
                        }
                    }
                }
            }

            if (GuardadoSatisfactoriamente == true)
            {
                if (Program.oPersistencia.IsError == true)
                {
                    MessageBox.Show(Program.oPersistencia.ErrorDescripcion, " Error de SQL");
                }
                else
                {
                    for (int contador = 0; contador == pb_datos.Maximum; contador++)
                    {
                        pb_datos.Value = contador;
                    }
                    MessageBox.Show(this, "¡La inclusión de Empresas a su sistema se ha realizado satisfactoriamente!", "Inclusión de Empresas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    button3.Enabled = true;
                    button3.Visible = true;
                    label17.Visible = true;
                    BtnAnterior.Enabled = false;
                    bn_cancelar1.Enabled = false;
                    bn_Final.Enabled = false;

                    this.AcceptButton = button3;
                }
            }
        }

        private void BtnFoto_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|*.png|GIF(*.gif)|*.gif|Todos(*.Jpg, *.Png, *.Gif, *.Tiff, *.Jpeg, *.Bmp)|*.Jpg; *.Png; *.Gif; *.Tiff; *.Jpeg; *.Bmp";
                openFileDialog1.FilterIndex = 4;

                if (String.IsNullOrEmpty(openFileDialog1.InitialDirectory))
                    openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                
                openFileDialog1.RestoreDirectory = true;

                DialogResult Respuesta = openFileDialog1.ShowDialog();

                if (Respuesta != DialogResult.Cancel)
                {
                    pictureBox2.BackgroundImage = Image.FromFile(this.openFileDialog1.FileName.Trim());
                    pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;//.Stretch;  
                    DireccImage = this.openFileDialog1.FileName.Trim();
                }
            }
            catch
            {
                MessageBox.Show(this, "Error al Cargar la foto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            DireccImage = "";
            this.pictureBox2.BackgroundImage = null;
            InfoImagen = null;
        }

        private void LLenar_Grid()//Hecho para llenar los grids sin enlazar a base de datos y que se puedan ingresar mas filas
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("select * from Empresas");

            DataSet ds = Program.oPersistencia.ejecutarSQLListas(sql.ToString(), "Empresas");
            // Extraer un DataSet
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Grid1.Rows.Add(dr[0].ToString().Trim(), dr[1].ToString().Trim(), dr[2].ToString().Trim(), dr[3].ToString().Trim(),
                                dr[4].ToString().Trim(), dr[5].ToString().Trim(), dr[6].ToString().Trim(), dr[7].ToString().Trim(),
                                dr[8].ToString().Trim(), dr[9].ToString().Trim(), dr[10].ToString().Trim());
                        }
                    }
                }
            }
            ds.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabPage1.Focus())
            {
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    e.Handled = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //toolTip1.Show("Ingrese el Nombre Global de su Empresa \nPor ejemplo: Boutique (Nombre de su empresa", button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //toolTip1.Show("Ingrese el Nombre del Local respectivo de su Empresa \nPor ejemplo: -Boutique (Nombre de su empresa) Local 1", button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //toolTip1.Show("Ingrese el Nombre del país y ciudad en que está ubicada la empresa \nPor ejemplo: San José, Costa Rica", button6);
        }

        private void VerificarEmpresasIngresadas()
        {
            DataSet ds2 = Program.oPersistencia.ejecutarSQLListas("Select * from Empresas", "Empresas");
            if (ds2 != null && ds2.Tables.Count > 0)
            {

                if (ds2.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(this, "No puede continuar hasta haber incluído alguna empresa en el sistema por lo que el sistema se bloqueará y no podrá realizar ninguna acción sobre el mismo, excepto en el \"Asistente de inclusión de su Empresa.\" ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    foreach (ToolStripMenuItem menu in Program.oMDI.menuStrip1.Items)
                    {
                        for (int i = 0; i < menu.DropDownItems.Count; i++)
                        {
                            if (menu.DropDownItems[i].Name != "Detalle_Empresa" && menu.DropDownItems[i].Name != "Salir")
                            {
                                menu.DropDownItems[i].Enabled = false;
                            }
                        }
                    }
                }
                else if (ds2.Tables[0].Rows.Count > 0 && MDIPrincipal.BloquearBarra == false)
                {
                    if (MDIPrincipal.MACAdress != "")
                    {
                        StringBuilder sql = new StringBuilder();
                        sql.Append("select nombre from Empresas");

                        DataSet ds = Program.oPersistencia.ejecutarSQLListas(sql.ToString(), "Empresas a, EmpresasXEquipo b");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                Program.oMDI.Text = dr[0].ToString().Trim() + " - SoftNet Business Solutions";
                                Program.oMDI.toolStripStatusLabel4.Text = "   " + dr[0].ToString().Trim();
                            }
                        }
                        ds.Dispose();
                    }
                }
            }
            ds2.Dispose();
        }

        private void FrmMiEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            VerificarEmpresasIngresadas();

            if (Program.oFrmMailSettings.Abierto == true)
                Program.oFrmMailSettings.Close();
        }

        private void TxtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (Grid1.Rows.Count > 1)
            {
                if (TxtCodigo.Text != "" && TxtNombre.Text != "" && TxtDirección.Text != "" && TxtTelefono.Text != "")
                {
                    BtnListo.Enabled = true;
                    BtnCancelar.Enabled = true;
                }
            }
        }

        private void TxtTelefono_Enter(object sender, EventArgs e)
        {
            if (Grid1.Rows.Count > 1)
            {
                if (TxtCodigo.Text != "" && TxtNombre.Text != "" && TxtDirección.Text != "" && TxtTelefono.Text != "")
                {
                    BtnListo.Enabled = true;
                    BtnCancelar.Enabled = true;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
                TxtPaisCiudad.Focus();
        }

        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void BtnSiguiente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.Handled = true;
            }
        }

        private void BtnAnterior_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.Handled = true;
            }
        }

        private void bn_cancelar1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.Handled = true;
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmTopics oFrmTopics = new FrmTopics("groupIngresarEmpresa");//ASí se llama el groupbox que contiene los índices de búsqueda de la ayuda del sistema
            //oFrmTopics.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ayudaToolStripMenuItem_Click(sender, e); 
        }

        private void imagenCambiantePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void btnGuardarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox2.BackgroundImage != null)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "JPeg Image|*.jpg";
                    saveFileDialog1.Title = "Guardar Imagen a Disco Duro";
                    saveFileDialog1.ShowDialog();

                    if (saveFileDialog1.FileName != "")
                    {
                        //Imagen = ImageToByte(DeterminaImagenSeleccionada());//pictureBox1.Image);
                        if (InfoImagen == null)
                            Imagen = ImageToByte(pictureBox2.BackgroundImage);
                        else
                            Imagen = InfoImagen;//ConvertImageToBytes(DeterminaImagenSeleccionada());//pictureBox1.Image);

                        string sImagenTemporal = saveFileDialog1.FileName;

                        string sBase64 = "";
                        sBase64 = Convert.ToBase64String(Imagen);

                        FileStream fs = new FileStream(sImagenTemporal, FileMode.Create);
                        BinaryWriter bw = new BinaryWriter(fs);
                        byte[] bytes;

                        try
                        {
                            bytes = Convert.FromBase64String(sBase64);
                            MessageBox.Show("La imagen fue guardada satisfactoriamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            bw.Write(bytes);
                        }

                        catch
                        {
                            MessageBox.Show("Ocurrió un error al leer la imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        }

                        finally
                        {
                            fs.Close();
                            bytes = null;
                            bw = null;
                            sBase64 = null;
                        }
                    }
                }
            }
            catch { }
        }

        private void tobSettings_Click(object sender, EventArgs e)
        {
            if (!Program.oFrmMailSettings.Visible)
                Program.oFrmMailSettings.Show(this);
        }

    }
}