using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace G_Clinic.Miscelaneos_y_Recursos.ImageViewerControl
{
    class ImageViewerCtrl_Values : ImageViewerCtrl
    {
        public ImageViewerCtrl_Values()
        {

        }

        private int imageNumber = -1;
        public int ImageNumber
        {
            get { return imageNumber; }
            set { imageNumber = value; }
        }

        private byte[] imageBytes = null;
        public byte[] ImageBytes
        {
            get 
            {
                return imageBytes; 
            }
            set { imageBytes = value; }
        }

        private string originalPath = "";
        public string OriginalPath
        {
            get { return originalPath; }
            set { originalPath = value; }
        }

        private string tempPath = "";
        public string TempPath
        {
            get { return tempPath; }
            set { tempPath = value; }
        }
        
    }
}
