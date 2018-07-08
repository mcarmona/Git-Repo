using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Text.RegularExpressions;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    class Metodos_Globales
    {
        public static void CargaTodosCombos()
        {
            ////Carga los ComboBox del sistema
            //LlenarCombo(cmbAlumnos, "Select * from Alumnos", "Alumnos", "id_alumno", "nombre");
            //LlenarCombo(cmbAlumnos2, "Select * from Alumnos", "Alumnos", "id_alumno", "nombre");
            //LlenarCombo(cmbAlumnos3, "Select * from Alumnos", "Alumnos", "id_alumno", "nombre");
            //LlenarCombo(cmbLibros, "Select * from Libros", "Libros", "id_libro", "titulo");
        }

        public static void CargarDatos()
        {
            ////Carga los datos de los tipos de contactos
            //LlenarGrid(Grid1, "Select * from Tipo_Contactos");
            //ModoBloqueo(toolStrip2, Grid1);
            //BloquearCampos(0);

            ////Carga los datos de los alumnos
            //LlenarGrid(Grid2, "Select * from Alumnos");
            //ModoBloqueo(toolStrip4, Grid2);
            //BloquearCampos(1);

            ////Carga los datos de los alumnos
            //LlenarGrid(Grid3, "Select * from Libros");
            //ModoBloqueo(toolStrip6, Grid3);
            //BloquearCampos(2);

            //CargaTodosCombos();

            //LlenarListaLibrosPedido();
            //lblFechaExpiracion.Text = dtFechaPrestamo.Value.AddMonths(1).ToLongDateString();
        }

        #region Métodos Globales

        public static void BloqueaTeclasRapidas(ToolStrip pToolStrip, MenuStrip pMenuStrip)
        {
            try
            {
                int c = 0;

                foreach (ToolStripItem oItem in pToolStrip.Items)
                {
                    if (oItem is ToolStripButton)
                    {
                        if (oItem.Enabled == false)
                        {
                            foreach (ToolStripMenuItem menu in pMenuStrip.Items)
                            {
                                for (int i = 0; i < menu.DropDownItems.Count; )
                                {
                                    menu.DropDownItems[c].Enabled = false;
                                    break;
                                }
                                break;
                            }
                        }
                        else
                        {
                            foreach (ToolStripMenuItem menu in pMenuStrip.Items)
                            {
                                for (int i = 0; i < menu.DropDownItems.Count; )
                                {
                                    menu.DropDownItems[c].Enabled = true;
                                    break;
                                }
                                break;
                            }
                        }
                    }
                    c++;
                }
            }
            catch { }
        }

        public static void ModoBloqueo(ToolStrip oToolStrip, DataGridView oGrid)
        {
            foreach (ToolStripItem oButton in oToolStrip.Items)
            {
                if (oButton is ToolStripButton)
                {
                    if (oButton.Name == "tobNuevo")
                        oButton.Enabled = true;
                    else if (oButton.Name == "tobModificar")
                    {
                        if (oGrid.Rows.Count > 0)
                            oButton.Enabled = true;
                        else
                            oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobGuardar")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobCancelar")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobEliminar")
                    {
                        if (oGrid.Rows.Count > 0)
                            oButton.Enabled = true;
                        else
                            oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobIniciarConsulta")
                    {
                        oButton.Enabled = true;
                    }
                    else if (oButton.Name == "tobEjecutarConsulta")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobCancelarConsulta")
                    {
                        oButton.Enabled = false;
                    }
                }
            }
        }

        public static void ModoModificar(ToolStrip oToolStrip)
        {
            foreach (ToolStripItem oButton in oToolStrip.Items)
            {
                if (oButton is ToolStripButton)
                {
                    if (oButton.Name == "tobNuevo")
                        oButton.Enabled = false;
                    else if (oButton.Name == "tobModificar")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobGuardar")
                    {
                        oButton.Enabled = true;
                    }
                    else if (oButton.Name == "tobCancelar")
                    {
                        oButton.Enabled = true;
                    }
                    else if (oButton.Name == "tobEliminar")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobIniciarConsulta")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobEjecutarConsulta")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobCancelarConsulta")
                    {
                        oButton.Enabled = false;
                    }
                }
            }
        }

        public static void ModoEscritura(ToolStrip oToolStrip)
        {
            foreach (ToolStripItem oButton in oToolStrip.Items)
            {
                if (oButton is ToolStripButton)
                {
                    if (oButton.Name == "tobNuevo")
                        oButton.Enabled = false;
                    else if (oButton.Name == "tobModificar")
                        oButton.Enabled = false;
                    else if (oButton.Name == "tobGuardar")
                        oButton.Enabled = true;
                    else if (oButton.Name == "tobCancelar")
                        oButton.Enabled = true;
                    else if (oButton.Name == "tobEliminar")
                        oButton.Enabled = false;
                    //else if (oButton.Name == "tobPrimero")
                    //    oButton.Enabled = false;
                    //else if (oButton.Name == "tobSiguiente")
                    //    oButton.Enabled = false;
                    //else if (oButton.Name == "tobAnterior")
                    //    oButton.Enabled = false;
                    //else if (oButton.Name == "tobUltimo")
                    //    oButton.Enabled = false;
                    else if (oButton.Name == "tobIniciarConsulta")
                        oButton.Enabled = false;
                    else if (oButton.Name == "tobEjecutarConsulta")
                        oButton.Enabled = false;
                    else if (oButton.Name == "tobCancelarConsulta")
                        oButton.Enabled = false;
                }
            }
        }

        public static void ModoConsulta(ToolStrip oToolStrip)
        {
            foreach (ToolStripItem oButton in oToolStrip.Items)
            {
                if (oButton is ToolStripButton)
                {
                    if (oButton.Name == "tobNuevo")
                        oButton.Enabled = false;
                    else if (oButton.Name == "tobModificar")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobGuardar")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobCancelar")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobEliminar")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobIniciarConsulta")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobEjecutarConsulta")
                    {
                        oButton.Enabled = true;
                    }
                    else if (oButton.Name == "tobCancelarConsulta")
                    {
                        oButton.Enabled = true;
                    }
                }
            }
        }

        public static void ModoEjecucionConsulta(ToolStrip oToolStrip, DataGridView oGrid)
        {
            foreach (ToolStripItem oButton in oToolStrip.Items)
            {
                if (oButton is ToolStripButton)
                {
                    if (oButton.Name == "tobNuevo")
                        oButton.Enabled = false;
                    else if (oButton.Name == "tobModificar")
                    {
                        if (oGrid.Rows.Count > 0)
                            oButton.Enabled = true;
                        else
                            oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobGuardar")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobCancelar")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobEliminar")
                    {
                        if (oGrid.Rows.Count > 0)
                            oButton.Enabled = true;
                        else
                            oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobIniciarConsulta")
                    {
                        oButton.Enabled = true;
                    }
                    else if (oButton.Name == "tobEjecutarConsulta")
                    {
                        oButton.Enabled = false;
                    }
                    else if (oButton.Name == "tobCancelarConsulta")
                    {
                        oButton.Enabled = true;
                    }
                }
            }
        }

        public static void BloquearCampos(Form oForm)
        {
            foreach (Control oControl in oForm.Controls)
            {
                if (oControl is TextBox)
                    oControl.Enabled = false;
                else if (oControl is ComboBox)
                    oControl.Enabled = false;
                else if (oControl is DateTimePicker)
                    oControl.Enabled = false;
            }
        }

        public static void DesbloquearCampos(Form oForm)
        {
            foreach (Control oControl in oForm.Controls)
            {
                if (oControl is TextBox)
                    oControl.Enabled = true;
                else if (oControl is ComboBox)
                    oControl.Enabled = true;
                else if (oControl is DateTimePicker)
                    oControl.Enabled = true;
            }
        }

        public static void LimpiaCampos(Form oForm)
        {
            foreach (Control oControl in oForm.Controls)
            {
                if (oControl is TextBox)
                    oControl.Text = "";
            }
        }

        public static DataTable Consulta(SqlDataReader oSqlDataReader)
        {
            DataTable datatable;

            SqlDataReader dr = oSqlDataReader;

            //Si ocurrio un errro hacer la excepción
            if (!Program.oPersistencia.IsError)
            {
                if (dr.HasRows == true)
                {
                    // crear una nueva instancia del DataTable
                    datatable = new DataTable();

                    // llena el dataTable con la info del Datareader
                    datatable.Load(dr, LoadOption.Upsert);

                    //Cerrar el DataReader
                    dr.Close();

                    //Cerrar el DataReader
                    dr = null;

                    return datatable;
                }
                else
                {
                    dr.Close();
                    return null;
                    dr = null;
                }
            }
            else
                return null;
        }

        /// <summary>
        /// Carga el Grid directamente desde la base de datos mediante una sentencia SQL, este método va ligado directamente con otro método
        /// llamado "LlenarGrid()", el cual recibe una sentencia de consulta SQL, la cual será pasada directamente a este método para realizar
        /// los pasos para cargar el grid correspondiente. Este método no será utilizado en ningún otro lugar más que como método privado en esta
        /// clase, simplemente se utiliza como static por razones de accesibilidad entre métodos ya que todos los métodos son static en esta clase.
        /// </summary>
        /// <param name="SentenciaSQL">Recibe una sentencia de consulta SQL desde el método LlenarGrid(), con la cual se cargarán los datos</param>
        /// <returns>Devuelve un DataTable que será asignado al grid correspondiente mediante el método LlenarGrid()</returns>
        public static DataTable CargarGrid(string SentenciaSQL)
        {
            // Declara datatable
            DataTable datatable;

            // Declara Datareader
            SqlDataReader dr = null;

            // llenar el dataReader con la persistencia
            dr = Program.oPersistencia.ejecutarConsultaSQL(SentenciaSQL.Trim());

            //Si ocurrio un errro hacer la excepción
            if (!Program.oPersistencia.IsError)
            {
                if (dr.HasRows == true)
                {
                    // crear una nueva instancia del DataTable
                    datatable = new DataTable();

                    // llena el dataTable con la info del Datareader
                    datatable.Load(dr, LoadOption.Upsert);

                    //Cerrar el DataReader
                    dr.Close();

                    //Cerrar el DataReader
                    dr = null;

                    return datatable;
                }
                else
                {
                    dr.Close();
                    dr = null;
                    return null;
                }
            }
            else
                return null;
        }

        public static DataTable CargarGrid(SqlDataReader oSqlDataReader)
        {            
            // Declara datatable
            DataTable datatable = null;

            try
            {
                // Declara Datareader
                SqlDataReader dr = oSqlDataReader;

                //Si ocurrio un errro hacer la excepción
                if (!Program.oPersistencia.IsError)
                {
                    if (dr.HasRows == true)
                    {
                        // crear una nueva instancia del DataTable
                        datatable = new DataTable();

                        // llena el dataTable con la info del Datareader
                        datatable.Load(dr, LoadOption.Upsert);

                        //Cerrar el DataReader
                        dr.Close();
                        dr.Dispose();

                        //Cerrar el DataReader
                        dr = null;

                        return datatable;
                    }
                    else
                    {
                        dr.Dispose();
                        dr.Close();
                        dr = null;

                        return null;
                    }
                }
                else
                    return null;
            }
            catch { return null; }
            finally
            {
                if (datatable != null)
                    datatable.Dispose();
            }
        }

        /// <summary>
        /// Establece el Datasource para un grid existente mediante otro método de nombre "LlenarGrid()", cuya función es enlazar los datos directamente
        /// desde la base de datos del sistema ,con éste método sólamente hay que igualar el datasource del Grid a llenar con el método
        /// LlenarGrid() y sus respectivos parámetros
        /// </summary>
        /// <param name="oGrid">Grid al cual se le establecerá el DataSource</param>
        /// <param name="SentenciaSQL">Recibe la sentencia SQL de consulta con la cual se cargará el grid correspondiente</param>
        public static void LlenarGrid(DataGridView oGrid, string SentenciaSQL)
        {
            oGrid.DataSource = CargarGrid(SentenciaSQL.Trim());
        }

        public static void LlenarGrid(DataGridView oGrid, SqlDataReader oSqlDataReader)
        {
            oGrid.DataSource = null;
            DataTable oDataTable = CargarGrid(oSqlDataReader);
            oGrid.DataSource = oDataTable;
        }

        public static DataSet Consulta(String Sentencia, String pTabla)
        {
            DataSet ds = Program.oPersistencia.ejecutarSQLListas(Sentencia, pTabla);
            return ds;
        }

        public static void LlenarCombo(ComboBox oCombo, string SentenciaSQL, string Tabla, string pValueMember, string pDisplayMember)
        {
            oCombo.DataSource = null;
            oCombo.ValueMember = Tabla + "." + pValueMember.Trim();
            oCombo.DisplayMember = Tabla + "." + pDisplayMember.Trim();
            oCombo.DataSource = Consulta(SentenciaSQL, Tabla);
        }

        public static void AgregarDatosListView(ListView oListView)
        {
            //int linea = 0;

            //if (oListView.Items.Count > 0)
            //    linea = oListView.Items.Count - 1;

            //oListView.Items.Add();             
        }

        public static void EstableceFoco(Control oControl)
        {
            oControl.Focus();
        }

        /// <summary>
        /// Agrega una carpeta al folder AppData del sistema, para que se agregue correctamente deberá de establecerse el \\ antes del nombre
        /// del folder, dicho método solamente crea la carpeta, no crea ningún archivo ni nada por el estilo... 
        /// </summary>
        /// <param name="pFolderName"></param>
        /// <returns>Path del folder, si la carpeta ya está creada no hace mas que devolver el nombre</returns>
        public static string crearCarpetaAppdata(string pFolderName)
        {
            try
            {
                string directoryString = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData).ToString() + pFolderName.Trim();

                if (!Directory.Exists(directoryString))
                    Directory.CreateDirectory(directoryString);

                return directoryString;
            }
            catch
            {
                return "";
            }
        }

        public static byte[] ReadFile(string sPath)
        {
            try
            {
                //Initialize byte array with a null value initially.
                byte[] data = File.ReadAllBytes(sPath);
                return data;
            }
            catch
            {
                return null;
            }
        }

        public static void CreateTempFileFromByteArray(byte[] pFileData, string pFileName)
        {
            FileStream oFileStream = new FileStream(pFileName, FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(oFileStream);
            bw.Write(pFileData);
            bw.Close();
            oFileStream.Close();
        }

        public static Image CreateTempImageFromByteArray(byte[] Imagen, out string pPath)
        {
            pPath = crearCarpetaAppdata("\\TempFiles");            
            Image newImage = null;
            string sImagenTemporal = pPath + "tmpImage.jpg";
            
            // Declaramos fs para tener crear un nuevo archivo temporal en la maquina cliente.
            // y memStream para almacenar en memoria la cadena recibida.
            while (File.Exists(sImagenTemporal))
            {
                if (sImagenTemporal.Contains(".jpg"))
                    sImagenTemporal = sImagenTemporal.Replace(".jpg", "");

                sImagenTemporal += "(copy)";
            }

            if (!sImagenTemporal.Contains(".jpg"))
                sImagenTemporal += ".jpg";

            pPath = sImagenTemporal;

            string sBase64 = "";
            sBase64 = Convert.ToBase64String(Imagen);

            FileStream fs = new FileStream(sImagenTemporal, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            byte[] bytes;

            try
            {
                bytes = Convert.FromBase64String(sBase64);
                bw.Write(bytes);
            }

            catch
            {
                MessageBox.Show("Ocurrió un error al leer la imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }

            finally
            {
                //Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(Imagen, 0, Imagen.Length))
                {
                    ms.Write(Imagen, 0, Imagen.Length);

                    //Set image variable value using memory stream.
                    newImage = Image.FromStream(ms, true);
                }

                fs.Close();
                bytes = null;
                bw = null;
                sBase64 = null;
            }

            return newImage;
        }

        public static void EjecutaPermisos(ToolStripButton oNuevo, ToolStripButton oModificar, ToolStripButton oEliminar, ArrayList oArregloPermisos)
        {
            if (MDIPrincipal.RolUsuario != "Administrador")
            {
                if (oArregloPermisos.Count > 0)
                {
                    oNuevo.Enabled = (bool)oArregloPermisos[0];
                    oModificar.Enabled = (bool)oArregloPermisos[1];
                    oEliminar.Enabled = (bool)oArregloPermisos[2];
                }
            }
            else
            {
                oNuevo.Enabled = true;
                oModificar.Enabled = true;
                oEliminar.Enabled = true;
            }
        }

        public static void EjecutaPermisos(ToolStripButton oNuevo, ToolStripButton oModificar, ArrayList oArregloPermisos)
        {
            if (MDIPrincipal.RolUsuario != "Administrador")
            {
                if (oArregloPermisos.Count > 0)
                {
                    oNuevo.Enabled = (bool)oArregloPermisos[0];
                    oModificar.Enabled = (bool)oArregloPermisos[1];
                }
            }
            else
            {
                oNuevo.Enabled = true;
                oModificar.Enabled = true;
            }
        }

        public static string[] MetodoSplit(string pValorCampo, char[] pCaracterBuscado)
        {
            string[] ocadenaTemp = pValorCampo.Split(pCaracterBuscado, StringSplitOptions.RemoveEmptyEntries);
            return ocadenaTemp;
        }

        public static string CortaSeccionDeTexto(string pTexto, string pCaracterInicialBuscado, string pCaracterFinalBuscado, string pNuevoCaracter)
        {
            string oTexto = pTexto;

            int indexCaracterInicial = oTexto.IndexOf(pCaracterInicialBuscado);
            int indexCaracterFinal = oTexto.IndexOf("}");

            int lenghtSubstring = 0;

            lenghtSubstring = indexCaracterFinal - (indexCaracterInicial);

            if (lenghtSubstring <= 0)
                indexCaracterFinal = indexCaracterInicial + 1;

            oTexto = pTexto.Substring(indexCaracterInicial, lenghtSubstring + 1);

            oTexto = pTexto.Replace(oTexto, pNuevoCaracter);

            return oTexto;
        }

        public static string NombreDelMes(int pMonth)
        {
            string nombreMes = "";

            switch (pMonth)
            {
                case 1:
                    nombreMes = "Enero";
                    break;
                case 2:
                    nombreMes = "Febrero";
                    break;
                case 3:
                    nombreMes = "Marzo";
                    break;
                case 4:
                    nombreMes = "Abril";
                    break;
                case 5:
                    nombreMes = "Mayo";
                    break;
                case 6:
                    nombreMes = "Junio";
                    break;
                case 7:
                    nombreMes = "Julio";
                    break;
                case 8:
                    nombreMes = "Agosto";
                    break;
                case 9:
                    nombreMes = "Setiembre";
                    break;
                case 10:
                    nombreMes = "Octubre";
                    break;
                case 11:
                    nombreMes = "Noviembre";
                    break;
                case 12:
                    nombreMes = "Diciembre";
                    break;
            }

            return nombreMes;
        }

        public static float MeasureString(Graphics pGraphics, TextBox pTextBox, Font pFont)
        {
            Graphics oGraphics = pGraphics;            
            float oHeight = 0;

            foreach (string oCadena in pTextBox.Lines)
                oHeight += oGraphics.MeasureString(oCadena, pFont).Height;

            return oHeight;
        }

        /// <summary>
        /// Avoid entering all characters but numericals, back space, comma and dots
        /// </summary>
        /// <param name="textToCheck"> Verifies is the string already contains commas or dots, in which case don't allow values to be entered
        /// it also prevents from entering commas or dots if the string is empty </param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool AvoidedCharacters(String textToCheck, KeyPressEventArgs e)
        {
            if ((textToCheck.Trim().Length == 0) && (e.KeyChar.ToString().Equals(",") || e.KeyChar.ToString().Equals(".")))
                return true;

            if ((textToCheck.Trim().Contains(",") || textToCheck.Trim().Contains(".")) && (e.KeyChar.ToString().Equals(",") || e.KeyChar.ToString().Equals(".")))
                return true;

            if (e.KeyChar.ToString() != "." && e.KeyChar.ToString() != "," &&
                e.KeyChar.ToString() != "1" && e.KeyChar.ToString() != "2" && e.KeyChar.ToString() != "3" && e.KeyChar.ToString() != "4" &&
                e.KeyChar.ToString() != "5" && e.KeyChar.ToString() != "6" && e.KeyChar.ToString() != "7" && e.KeyChar.ToString() != "8" &&
                e.KeyChar.ToString() != "9" && e.KeyChar.ToString() != "0" && e.KeyChar != '\b')
                return true;
            else
                return false;
        }

        public static bool AvoidSpecialCharacters(char e)
        {
            if (Regex.IsMatch(e.ToString(), @"[^A-Za-z0-9\ ]"))
            {
                return true;
            }
            else
                return false;
        }

        #endregion
    }
}