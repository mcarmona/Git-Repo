using System;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace G_Clinic
{
    class Seguridad
    {
        ArrayList oArreglo;

        public static string Id_Emp = "";
        public static string Estado_Emp = "";
        public static bool PermisosEncontrados = false;

        // Desactiva todo el menu
        public void DesactivarMenu(MenuStrip opMenu)
        {
            // Recorrer el TOP del Menu
            foreach (ToolStripMenuItem menu in opMenu.Items)
            {
                //menu.Enabled = false;
                // Método para recorrer los Items del Menú y los Submenú
                DesactivarSubmenus(menu.DropDownItems);
            } 
        } // fin

        public void DesactivarSubmenus(ToolStripItemCollection items)
        {
            ToolStripMenuItem subMenu;

            // Recorrer los los Items
            foreach (ToolStripItem item in items)
            {
                item.Enabled = false;
                //Casting de item a ToolStripMenuItem
                //subMenu = (ToolStripMenuItem)item;
                // Invocar recursivamente los submenú de los submenú en caso de que los tenga
                //DesactivarSubmenus(subMenu.DropDownItems);
            }
        }

        // Desactiva el menú
        public void SeguridadMenu(MenuStrip opMenu)
        {
            if (Program.oUsuario != null)
            {
                // Iniciar Arreglo
                oArreglo = new ArrayList();
                SqlDataReader dr;
                StringBuilder Sql = new StringBuilder("");

                Sql.Append(" select idMenu from RolesxMenu ");
                Sql.Append(" where upper(roldb) in (select g.name ");
                Sql.Append("   from sysusers u, sysusers g, sysmembers m ");
                Sql.Append("  where upper(u.name) = '");
                Sql.Append(Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(Program.oUsuario.ToUpper().Trim()));
                Sql.Append("'  and g.uid = m.groupuid ");
                Sql.Append("   and g.issqlrole = 1 and u.uid = m.memberuid )");

                dr = Program.oPersistencia.ejecutarConsultaSQL(Sql.ToString());

                // Hubo error ?
                if (Program.oPersistencia.IsError == true)
                {
                    MessageBox.Show(Program.oPersistencia.ErrorDescripcion);
                    return;
                }

                // Recorrer el DataReader y llenar el arreglo, esto se hizo por 
                // comodidad es mejor tener en memoria un ArrayList q un DataReader
                while (dr.Read())
                {
                    oArreglo.Add(dr.GetValue(0).ToString().Trim());
                }

                //  Cerrar el DataReader
                dr.Dispose();


                // Recorrer el Arreglo
                foreach (String itemName in oArreglo)
                {
                    // Recorrer el TOP del Menu
                    foreach (ToolStripMenuItem menu in opMenu.Items)
                    {
                        if (menu.Name.ToUpper().CompareTo(itemName.ToUpper().Trim()) == 0)
                        {
                            menu.Enabled = true;
                        }

                        // Método para recorrer los Items del Menú y los Submenú
                        RecorrerSubmenus(menu.DropDownItems);
                    }
                }
            }
        }

        // Método para recorrer los Items del Menú y los Submenú
        // Nota  es recursivo
        private void RecorrerSubmenus(ToolStripItemCollection items)
        {
            // Recorrer los los Items
            foreach (ToolStripItem item in items)
            {
                // recorrer el ArrayList
                foreach (String itemName in oArreglo)
                {
                    //    Si el nombre es igual, entonces deshabilitelo
                    if (item.Name.ToUpper().Trim().CompareTo(itemName.ToUpper().Trim()) == 0)
                    {
                        item.Enabled = true;
                    }
                }
            }
        }

        private void SeguridadToolBar(Form opForma, String pUsuario)
        {
            StringBuilder Sql = new StringBuilder();
            // Crear SQL para extrar todos los items que tiene derecho el usuario
            Sql.Append("select Der_Nuevo, Der_Consultar,Der_Salvar,Der_Borrar  from usuario u, derechoPerfilAsignado d, Perfil p, DerechoObjeto o");
            Sql.Append(" where u.usu_ID = '");
            Sql.Append(Program.oComprobaciones.DevuelveCadenaCorrectaParaSentenciaSQL(pUsuario));
            Sql.Append("' and ");
            Sql.Append(" u.usu_id = d.usu_id  AND ");
            Sql.Append(" u.per_id = p.per_id  AND ");
            Sql.Append(" u.per_id = o.per_id   ");
            // Ejecutar SQL y extraer el Data Reader
            SqlDataReader dr = Program.oPersistencia.ejecutarConsultaSQL(Sql.ToString());

            // Hubo error ?
            if (Program.oPersistencia.IsError == true)
            {
                MessageBox.Show(Program.oPersistencia.ErrorDescripcion);
                return;
            }

            // Recorrer el DataReader y llenar el arreglo, esto se hizo por 
            // comodidad es mejor tener en memoria un ArrayList q un DataReader
            while (dr.Read())
            {
                int.Parse(dr.GetValue(0).ToString());
            }
        }

        public bool VerificarEstadoUsuario(string Id_Usuario)
        {
            Estado_Emp = "";
            Id_Emp = "";
            try
            {
                bool Estado = false;

                StringBuilder Sql = new StringBuilder("");

                Sql.Append("Select a.estado from Empleados a, Usuario_Empleado b where a.id_emp = b.id_emp and b.id_usuario = " + Id_Usuario.Trim());

                DataSet ds = Program.oPersistencia.ejecutarSQLListas(Sql.ToString(), "Empleados a, Usuario_Empleado b");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (Convert.ToBoolean(dr[0]) == true)
                        {
                            Estado_Emp = "Inactivo";
                            Estado = false;
                            MessageBox.Show("El empleado al que está asignado este usuario se encuentra como inactivo, por lo que no puede continuar con estas acciones. Solicite a un administrador del sistema que modifique sus valores en el Manteminiento de Empleados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  
                        }
                        else if (Convert.ToBoolean(dr[0]) == false)
                        {
                            Estado_Emp = "Activo";
                            Estado = true;

                            Sql.Remove(0, Sql.Length);
                            Sql.Append("Select id_emp from Usuario_Empleado where id_usuario = " + Id_Usuario.Trim());

                            DataSet ds2 = Program.oPersistencia.ejecutarSQLListas(Sql.ToString(), "Usuario_Empleado");

                            foreach (DataRow dr2 in ds2.Tables[0].Rows)
                                Id_Emp = dr2[0].ToString();
                            ds2.Dispose();
                        }
                    }
                }
                else
                    MessageBox.Show("El usuario ingresado no se encuentra asignado a ningún empleado del sistema, por lo que no puede continuar con estas acciones. Solicite a un administrador del sistema que asigne este usuario a un empleado activo del sistema", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ds.Dispose();

                return Estado;
            }
            catch { return false; }
        }

        public bool DesactivarBotonesForms(string pidMenu, ToolStrip items)
        {
            try
            {
                DataSet ds = Program.oPersistencia.ejecutarSQLListas("Select * from Permisos_Especiales where idMenu = '" + pidMenu.Trim() + "' and id_emp = " + Id_Emp.Trim(), "Permisos_Especiales");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    PermisosEncontrados = true;

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        foreach (ToolStripItem opcion in items.Items)
                        {
                            if (opcion is ToolStripButton)
                            {
                                if (opcion.Name.ToString().Trim().ToLower() == "tobnuevo")
                                {
                                    if (Convert.ToBoolean(dr[2]) == false)
                                        opcion.Enabled = false;
                                    else
                                        opcion.Enabled = true;
                                }
                                else if (opcion.Name.ToString().Trim().ToLower() == "tobmodificar")
                                {
                                    if (Convert.ToBoolean(dr[3]) == false)
                                        opcion.Enabled = false;
                                    else
                                        opcion.Enabled = true;
                                }
                                else if (opcion.Name.ToString().Trim().ToLower() == "tobanular")
                                {
                                    if (Convert.ToBoolean(dr[4]) == false)
                                        opcion.Enabled = false;
                                    else
                                        opcion.Enabled = true;
                                }
                                else if (opcion.Name.ToString().Trim().ToLower() == "tobborrar")
                                {
                                    if (Convert.ToBoolean(dr[5]) == false)
                                        opcion.Enabled = false;
                                    else
                                        opcion.Enabled = true;
                                }
                                else if (opcion.Name.ToString().Trim().ToLower() == "tobimportar")
                                {
                                    if (Convert.ToBoolean(dr[6]) == false)
                                        opcion.Enabled = false;
                                    else
                                        opcion.Enabled = true;
                                }
                                //Ésta opción es exclusiva para el Inventario que posee un botón normal en vez de un botón en la barra de Tareas
                                else if (opcion.Name.ToString().Trim().ToLower() == "tobeliminar")
                                {
                                    if (Convert.ToBoolean(dr[5]) == false)
                                        opcion.Enabled = false;
                                    else
                                        opcion.Enabled = true;
                                }
                            }
                        }
                    }
                    ds.Dispose();
                }
                else
                    PermisosEncontrados = false;

                return PermisosEncontrados;
            }
            catch
            {
                return false;
            }
            finally 
            {
                PermisosEncontrados = false;
            } 

        }
    }
}
