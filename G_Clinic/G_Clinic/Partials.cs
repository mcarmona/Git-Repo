using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G_Clinic
{
    public static class MyExtensions
    {
        public static string ToolTipAutoText(this TextBox txtBox)
        {
            return txtBox.Text.Trim();
        }        
    }
}
