using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    [Serializable]
    public class GlobalElementsValues
    {
        int oIndex = 0;
        public int OIndex
        {
            get { return oIndex; }
            set { oIndex = value; }
        }

        Image oImage = null;
        public Image OImage
        {
            get { return oImage; }
            set { oImage = value; }
        }

        byte[] oBytes = null;
        public byte[] OBytes
        {
            get { return oBytes; }
            set { oBytes = value; }
        }

        string oFileName = "";
        public string OFileName
        {
            get { return oFileName; }
            set { oFileName = value; }
        }
    }
}
