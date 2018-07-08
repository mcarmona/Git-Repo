#region - Notas del CopyRight -
//SecuryCore - Libreria de gestion de usuarios
//Copyright (C) 2007  Juan de jesus ramos
//
//Este programa es Software Libre; Usted puede redistribuirlo y/o modificarlo 
//bajo los términos de la GNU Lesser General Public Licnese (LGPL) tal y como ha sido 
//públicada por la Free Software Foundation; bien la versión 2.1 de la Licencia, 
//o (a su opción) cualquier versión posterior.
//
//Esta libreria se distribuye con la esperanza de que sea útil, pero SI NINGUNA 
//GARANTÍA; tampoco las implícitas garantías de MERCANTILIDAD o ADECUACIÓN A UN 
//PROPÓSITO PARTICULAR. Consulte la GNU Lesser General Public License (LGPL) para más  
//detalles. Usted debe recibir una copia de la GNU Lesser General Public License (LGPL) 
//junto con este programa; si no, escriba a la Free Software Foundation Inc.    
//51 Franklin Street, 5º Piso, Boston, MA 02110-1301, USA.
#endregion

using System;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using G_Clinic.Miscelaneos_y_Recursos;

namespace G_Clinic
{
    public static class Notificacion
    {
        //Enumerado que representa las imagenes
        public enum Imagen { Ok, Advertencia, Error, Soporte, Usuarios, Ayuda, Llave, Tarea, Internet,SinImagen };
        internal static ArrayList listaSlots = new ArrayList();

        #region - Muestra un aviso -
        /// <summary>
        /// Muestra un mensaje sobre la barra de tareas tipo MSN Messenger
        /// </summary>
        /// <param name="Titulo">Titulo del mensaje</param>
        /// <param name="Texto">Texto del mensaje</param>
        /// <param name="ImagenFondo">Imagen de fondo</param>
        /// <param name="tiempoVisible">Por cuantos segundos el mensaje es visible</param>
        public static void mostrarVentana(string Titulo,string Texto,Imagen ImagenFondo,int tiempoVisible)
        {
            //Variables
            bool slotAsignado = false;
            int posicionVertical = 0;
            int multiplicador = 1;

            #region - Se asigna un slot a la nueva ventana -
            //Le asignamos un slot a la ventana
            while (slotAsignado == false)
            {
                //Calculamos la posicion del nuevo slot
                posicionVertical = Screen.PrimaryScreen.Bounds.Bottom - 30 - (160) * multiplicador;

                    //Verificamos si la posicion del slot ya esta ocupada. Si no,
                    //Le asignamos el numero de posicion a la nueva  slot y lo
                    //agregamos a la lista de slots asignados
                    if (listaSlots.Contains(posicionVertical) == false)
                    {
                        if (posicionVertical >= 68)
                        {
                            listaSlots.Add(posicionVertical);
                            slotAsignado = true;
                        }
                        //Si todos los slots ya estan llenos
                        //entonces no mostramos el mensaje
                        else
                        {
                            return;
                        }
                    }
                    //Si el slot ya esta asignado, entonces cambiamos el multiplicador
                    //y intentamos otravez
                    else
                    {
                        multiplicador++;
                    }

            }
            #endregion

            #region - Instancia de la nueva ventana de mensajes y asignacion de valores
            //Creamos una nueva instancia de la ventana de mensajes
            //y le pasamos el lugar donde debe aparecer mediante el constructor
            frmNotificacion myForm = new frmNotificacion(posicionVertical);

            //Asignamos algunos valores al formulario de los mensajes
            myForm.lblTexto.Text = Texto;
            myForm.timerEspera.Interval = tiempoVisible* 1000;
            #endregion

            #region - Preparamos el mensaje del titulo para ser mostrado -
            //Si el titulo es demasiado largo, entonces le ponemos puntos suspensivos al final
            //luego del caracter 30
            if (Titulo.Length > 30)
            {
                StringBuilder tmpTitulo = new StringBuilder();

                for (int i = 0; i < 30; i++)
                {
                    tmpTitulo.Append(Titulo[i].ToString());
                }
                tmpTitulo.Append("...");

                myForm.lblTitulo.Text = tmpTitulo.ToString();
            }

            //De lo contrario ponemos el titulo sin alterar
            else
            {
                myForm.lblTitulo.Text = Titulo;
            }
            #endregion

            #region - Se agrega la imagen seleccionada al fondo -
            //Se pone la imagen de fondo seleccionada
            switch ((int)ImagenFondo)
            {
                case 0:
                    myForm.pnlFondo.BackgroundImage = recursos.Ok;
                    break;

                case 1:
                    myForm.pnlFondo.BackgroundImage = recursos.advertencia;
                    break;
                case 2:
                    myForm.pnlFondo.BackgroundImage = recursos.error;
                    break;
                case 3:
                    myForm.pnlFondo.BackgroundImage = recursos.soporte;
                    break;
                case 4:
                    myForm.pnlFondo.BackgroundImage = recursos.usuarios;
                    break;
                case 5:
                    myForm.pnlFondo.BackgroundImage = recursos.ayuda;
                    break;
                case 6:
                    myForm.pnlFondo.BackgroundImage = recursos.llave;
                    break;
                case 7:
                    myForm.pnlFondo.BackgroundImage = recursos.tarea;
                    break;
                case 8:
                    myForm.pnlFondo.BackgroundImage = recursos.internet;
                    break;
            }
            #endregion
            //Por ultimo se muestra el aviso
            myForm.Show();
        }
        #endregion
    }
}
