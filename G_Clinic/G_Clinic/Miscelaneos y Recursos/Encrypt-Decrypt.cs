using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    class Encrypt_Decrypt
    {
        #region "CAMPOS PRIVADOS COMPARTIDOS DE LA CLASE"

        //La llave es la que encripta, tiene que ser de 24 caracteres, se puede usar cualquier clave
        private static string Key = "f34GryEoTb53fD2G6rFcsOop";//"u4gW456T6JFHoutTsv234342";//"DeKoJokLpk09HBBvjKJLjoOp";
        //El vector de inicializacion requiere una llave de 8 caracteres
        private static string Iv = "f8Yyu46x";//"OmoJPl98";

        #endregion

        #region "ENCRIPTAR"


        //Recibe como parametro el valor a encriptar y lo retorna encriptado
        public static string Encriptar(string pValor)
        {
            //Representa la clase base abstracta de la que deben
            //heredarse todas las implementaciones de algoritmos
            // simétricos a la Variable
            SymmetricAlgorithm Algoritmo;

            //Define un objeto contenedor para obtener acceso a la versión del proveedor de servicios
            //criptográficos (CSP) del algoritmo TripleDES. No se puede heredar esta clase

            Algoritmo = new TripleDESCryptoServiceProvider();
            Algoritmo.Key = Encoding.UTF8.GetBytes(Key); //Cuando se reemplaza en una clase derivada,
            // codifica un conjunto de caracteres en una secuencia de bytes
            Algoritmo.IV = Encoding.UTF8.GetBytes(Iv);

            ICryptoTransform CryptoTransform; //Define las operaciones básicas de las transformaciones criptográficas
            MemoryStream MemoryStream; //Crea una secuencia cuyo almacén de respaldo es la memoria
            CryptoStream CryptoStream; //Define una secuencia que vincula secuencias de datos a transformaciones criptográficas
            byte[] Byt; // Contiene enteros de 8 bits sin signo (1 bytes) que se sitúan en el intervalo entre 0 y 255.

            try
            {
                CryptoTransform = Algoritmo.CreateEncryptor(Algoritmo.Key, Algoritmo.IV);
                //Cuando se reemplaza en una clase derivada, se crea un objeto descifrador simétrico
                //con la propiedad Key y el vector de inicialización (IV) especificados.
                //Compatible con .NET Compact Framework.


                Byt = Encoding.UTF8.GetBytes(pValor);

                MemoryStream = new MemoryStream(); //Crea una secuencia cuyo almacén de respaldo es la memoria
                CryptoStream = new CryptoStream(MemoryStream, CryptoTransform, CryptoStreamMode.Write);
                CryptoStream.Write(Byt, 0, Byt.Length);
                CryptoStream.FlushFinalBlock(); //Actualiza el origen de datos o repositorio subyacente con el estado actual del búfer y, posteriormente, borra el búfer.

                CryptoStream.Close(); //Cierra la secuencia actual y libera todos los recursos (como las tomas e identificadores de archivo) asociados a la secuencia actual.

                return Convert.ToBase64String(MemoryStream.ToArray()); //Convierte el valor de una matriz de enteros de 8 bits sin signo en su
                //representación de tipo String equivalente codificada con dígitos de base 64.

            }
            catch (Exception ex)
            {
                return "";
            }
        }



        #endregion

        #region "DESENCRIPTAR"

        //Recibe como parametro el valor encriptado y lo retorna desencriptado
        public static string Desencriptar(string pValor)
        {


            SymmetricAlgorithm Algoritmo; //Representa la clase base abstracta de la que deben
            //heredarse todas las implementaciones de algoritmos
            // simétricos a la Variable

            //Define un objeto contenedor para obtener acceso a la versión del proveedor de servicios
            //criptográficos (CSP) del algoritmo TripleDES. No se puede heredar esta clase
            Algoritmo = new TripleDESCryptoServiceProvider();


            Algoritmo.Key = Encoding.UTF8.GetBytes(Key);
            Algoritmo.IV = Encoding.UTF8.GetBytes(Iv);

            ICryptoTransform CryptoTransform; //Define las operaciones básicas de las transformaciones criptográficas
            MemoryStream MemoryStream;
            CryptoStream CryptoStream;
            byte[] Byt; //Contiene enteros de 8 bits sin signo (1 bytes) que se sitúan en el intervalo entre 0 y 255.

            try
            {
                CryptoTransform = Algoritmo.CreateDecryptor(Algoritmo.Key, Algoritmo.IV);
                //Crea un objeto descifrador simétrico con la propiedad Key y el vector de inicialización (IV) actuales.

                Byt = Convert.FromBase64String(pValor); //Convierte el valor de una matriz de enteros de 8 bits sin signo en su
                //representación de tipo String equivalente codificada con dígitos de base 64.

                MemoryStream = new MemoryStream();
                CryptoStream = new CryptoStream(MemoryStream, CryptoTransform, CryptoStreamMode.Write);
                CryptoStream.Write(Byt, 0, Byt.Length);
                CryptoStream.FlushFinalBlock(); //Actualiza el origen de datos o repositorio subyacente con el estado actual del búfer y, posteriormente, borra el búfer.

                CryptoStream.Close(); //Cierra la secuencia actual y libera todos los recursos (como las tomas e identificadores de archivo) asociados a la secuencia actual.

                return Encoding.UTF8.GetString(MemoryStream.ToArray());
            }
            catch (Exception vExc)
            {
                return "";
            }

        }

        #endregion
    }
}
