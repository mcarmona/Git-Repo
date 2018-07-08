using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using G_Clinic.Miscelaneos_y_Recursos;
using G_Clinic.Properties;

namespace G_Clinic
{
    public partial class FrmRespaldo : Form
    {
        //variable que lleva el nombre de la maquina que se esta llamando
        private string pServidor;
        
        public FrmRespaldo()
        {
            InitializeComponent();
        }

/*        private void btnBackUp_Click(object sender, EventArgs e)
        {
            bool bBackUpStatus = true;

            Cursor.Current = Cursors.WaitCursor;

            if (Directory.Exists(@"c:\SQLBackup"))
            {
                if (File.Exists(@"c:\SQLBackup\wcBackUp1.bak"))
                {
                    if (MessageBox.Show(@"Do you want to replace it?", "Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(@"c:\SQLBackup\wcBackUp1.bak");
                    }
                    else
                        bBackUpStatus = false;
                    
                }
            }
            else
                Directory.CreateDirectory(@"c:\SQLBackup");

            if (bFileStatus)
            {
                //Connect to DB
                SqlConnection connect;
                string con = "Data Source = localhost; Initial Catalog=dbWiseCodes ;Integrated Security = True;";
                connect = new SqlConnection(con);
                connect.Open();
                //----------------------------------------------------------------------------------------------------

                //Execute SQL---------------
                SqlCommand command;
                command = new SqlCommand(@"backup database dbWiseCodes to disk ='c:\SQLBackup\wcBackUp1.bak' with init,stats=10", connect);
                command.ExecuteNonQuery();
                //-------------------------------------------------------------------------------------------------------------------------------

                connect.Close();

                MessageBox.Show("The support of the database was successfully performed", "Back", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }*/

        private void bn_respaldo_Click(object sender, EventArgs e)
        {            
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                saveFileDialog1.Filter = "Database Backup File|*.bak";
                saveFileDialog1.Title = "Generar respaldo de Base de Datos";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    toolStripStatusLabel1.Text = "Generando respaldo de la base de datos...";
                    pBBarra.Value = 45;
                    System.Threading.Thread.Sleep(200);

                    string Direccion = "";
                    string Fecha = "";

                    Fecha = System.DateTime.Today.ToShortDateString();

                    Fecha = Fecha.Replace("/", "-");
                    Direccion = saveFileDialog1.FileName.Trim();
                    
                    string path = Path.GetDirectoryName(Direccion);

                    Direccion = Direccion.Replace(".bak", " " + Fecha.Trim() + ".bak");

                    string fileName = Path.GetFileName(Direccion);

                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Connection = Program.oPersistencia.conexion;
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("strDatabase", "G_Clinic");
                    oCommand.Parameters.AddWithValue("strBackupFile", Direccion);
                    oCommand.Parameters.AddWithValue("strBackupName", fileName);
                    oCommand.CommandText = "sp_databaseBackup";
                    oCommand.CommandTimeout = 0;
                         
                    Program.oPersistencia.ejecutarSQL(oCommand);

                    if (Program.oPersistencia.IsError == false)
                    {
                        oCommand.Dispose();

                        path = Metodos_Globales.crearCarpetaAppdata("\\SoftNet G-Clinic");

                        char[] oCaracter = { '\\' };
                        string destPath = "";

                        string[] savePath = saveFileDialog1.FileName.Trim().Split(oCaracter);

                        for (int i = 0; i < savePath.Length - 1; )
                        {
                            destPath += savePath[i] += "\\";
                            i++;
                        }

                        destPath = destPath.Substring(0, destPath.Length - 1);

                        string Src = path;
                        string Dst = destPath;

                        Program.oComprobaciones.copyDirectory(Src, Dst, toolStripStatusLabel1, pBBarra);
                        Program.oComprobaciones.BackupDBLogins(Path.GetDirectoryName(Direccion) + @"\ServerLogins.txt");

                        MessageBox.Show("Se ha creado un BackUp de la base de datos satisfactoriamente",
                            "Copia de seguridad de base de datos",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //desabilita despues de haber hecho el backup
                        bn_respaldo.Enabled = false;
                        this.Cursor = Cursors.Default;

                        pBBarra.Value = 100;
                    }
                    else
                    {
                        MessageBox.Show(this, "Error al generar el respaldo de la base de datos. Intente de nuevo, si el programa persiste favor contactar con la persona que da soporte a su empresa", "Error al respaldar base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Error al generar el respaldo de la base de datos. Intente de nuevo, si el programa persiste favor contactar con la persona que da soporte a su empresa", "Error al respaldar base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmRespaldo_Load(object sender, EventArgs e)
        {
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCN = null;
            SqlConnectionStringBuilder ayudante = new SqlConnectionStringBuilder(); 

            openFileDialog1.Filter = "Database Backup File|*.bak";
            openFileDialog1.Title = "Restaurar Base de Datos";
            openFileDialog1.FileName = "";

            //SqlConnectionStringBuilder ayudante = new SqlConnectionStringBuilder();
            ayudante.UserID = "sa";//"admin";
            //ayudante.Password = "manujr";//"admin_punto_venta_adminlogin_1029384756";
            ayudante.InitialCatalog = "master";
            ayudante.DataSource = Settings.Default.Server.Trim();//"localhost";

            SqlCN = new SqlConnection(ayudante.ToString());
            SqlCN.Open();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show(this, "Estas acciones harán que el sistema SoftNet-Punto de Venta se reinicie para así adoptar sin errores los nuevos cambios realizados en la base de datos. ¿Está seguro que desea proceder con estas acciones?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    try
                    {
                        Program.oPersistencia.conexion.Dispose();
                        Program.oPersistencia.conexion.Close();
                        Persistencia oPersistencia = new Persistencia("", "", "");

                        string d = "drop database Punto_Venta";

                        string s = "";
                        s = "use master restore database Punto_Venta from disk = '" + Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(openFileDialog1.FileName.Trim()) + "' with recovery, stats = 10";

                        SqlCommand oSqlCommand = new SqlCommand(s, SqlCN);
                        
                        oSqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Has been restored database", "Restoration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ds)
                    {
                        MessageBox.Show(ds.Message.Trim());    
                    } 

                    Cursor.Current = Cursors.WaitCursor;

                    try
                    {
                        //Program.oPersistencia.ejecutarSQL("use master restore database Punto_Venta from disk = '" + openFileDialog1.FileName.Trim() + "'");//, connect);  //'c:\SQLBackup\wcBackUp1.bak'"

                        //Cmd.ExecuteNonQuery(); 

                        //MessageBox.Show("Has been restored database", "Restoration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Application.Restart();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (FrmManual.Abierto == false)
            //{
            //    Program.oFrmManual = new FrmManual();
            //    Program.oFrmManual.Show();

            //    Program.oFrmManual.treeView1.SelectedNode = Program.oFrmManual.treeView1.Nodes[1].Nodes[11].Nodes[0];
            //    FrmManual.oArreglo.Add("1/11/0");
            //    FrmManual.oArreglo2.Add("");
            //    FrmManual.contador++;
            //}
            //else
            //{
            //    //Esto permite que el form abierto su muestre sobre el form modal
            //    Program.oFrmManual.Hide();
            //    Program.oFrmManual.Enabled = false;
            //    Program.oFrmManual.Enabled = true;
            //    Program.oFrmManual.Show(Program.oMDI);
            //    Program.oFrmManual.WindowState = FormWindowState.Maximized;

            //    Program.oFrmManual.treeView1.SelectedNode = Program.oFrmManual.treeView1.Nodes[1].Nodes[11].Nodes[0];
            //    FrmManual.oArreglo.Add("1/11/0");
            //    FrmManual.oArreglo2.Add("");
            //    FrmManual.contador++;
            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ayudaToolStripMenuItem_Click(sender, e); 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}