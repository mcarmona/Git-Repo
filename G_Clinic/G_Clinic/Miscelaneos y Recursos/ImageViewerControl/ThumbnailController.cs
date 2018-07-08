using System;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;

namespace G_Clinic
{
    public class ThumbnailControllerEventArgs : EventArgs
    {
        public ThumbnailControllerEventArgs(string imageFilename, int imageNumber)
        {
            this.ImageFilename = imageFilename;
            this.Counter = imageNumber;
        }

        public int Counter = -1;
        public string ImageFilename;                
    }

    public delegate void ThumbnailControllerEventHandler(object sender, ThumbnailControllerEventArgs e);

    public class ThumbnailController
    {
        private bool m_CancelScanning;
        static readonly object cancelScanningLock = new object();

        public bool CancelScanning
        {
            get
            {
                lock (cancelScanningLock)
                {
                    return m_CancelScanning;
                }
            }
            set
            {
                lock (cancelScanningLock)
                {
                    m_CancelScanning = value;
                }
            }
        }

        public event ThumbnailControllerEventHandler OnStart;
        public event ThumbnailControllerEventHandler OnAdd;
        public event ThumbnailControllerEventHandler OnEnd;

        public ThumbnailController()
        {
            
        }

        public void AddFolder(string folderPath)
        {
            CancelScanning = false;

            Thread thread = new Thread(new ParameterizedThreadStart(AddFolder));
            thread.IsBackground = true;
            thread.Start(folderPath);
        }

        private void AddFolder(object folderPath)   
        {
            string path = (string)folderPath;

            if (this.OnStart != null)
            {
                this.OnStart(this, new ThumbnailControllerEventArgs(null, -1));
            }

            this.AddFolderIntern(path);

            if (this.OnEnd != null)
            {
                this.OnEnd(this, new ThumbnailControllerEventArgs(null, -1));
            }

            CancelScanning = false;
        }

        private void AddFolderIntern(string folderPath)
        {
            int counter = 0;
            if (CancelScanning) return;

            // not using AllDirectories
            string[] files = Directory.GetFiles(folderPath);
            foreach(string file in files)
            {
                if (CancelScanning) break;

                Image img = null;

                try
                {
                    img = Image.FromFile(file);
                }
                catch
                {
                    // do nothing
                }

                if (img != null)
                {
                    this.OnAdd(this, new ThumbnailControllerEventArgs(file, counter));
                    img.Dispose();
                }

                counter++;
            }

            // not using AllDirectories
            string[] directories = Directory.GetDirectories(folderPath); 
            foreach(string dir in directories)
            {
                if (CancelScanning)
                    break;

                AddFolderIntern(dir);
            }
        }
    }
}