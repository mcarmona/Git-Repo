using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    class FormatoPDF
    {
        public static string FontName(Font pFont)
        {
            return pFont.Name;
        }

        public static float FontSize(Font pFont)
        {
            return pFont.Size;
        }

        public static FontStyle FontStyle(Font pFont)
        {
            return pFont.Style;
        }
    }
}
