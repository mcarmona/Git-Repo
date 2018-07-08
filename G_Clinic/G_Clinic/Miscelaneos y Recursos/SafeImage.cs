using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    class SafeImage
    {
        public static Image NonLockingOpen(string filename)
        {
            Image result = null;
            MemoryStream ms = new MemoryStream();

            try
            {
                #region Save file to byte array

                long size = (new FileInfo(filename)).Length;
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                byte[] data = new byte[size];
                try
                {
                    fs.Read(data, 0, (int)size);
                }
                catch (Exception exc) { throw exc; }
                finally
                {
                    fs.Close();
                    fs.Dispose();
                }

                #endregion

                #region Convert bytes to image

                if (ms.Capacity <= ms.Length && ms.Capacity > 0)
                    return null;

                ms.Write(data, 0, (int)size);
                result = new Bitmap(ms);
                ms.Close();

                #endregion

                return result;
            }
            catch { ms.Dispose(); return null; }
            finally
            {
                ms.Dispose();
            }
        }
    }
}
