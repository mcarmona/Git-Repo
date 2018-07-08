using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    public partial class SoftNetVideoControl : UserControl
    {
        int items = 0;
        int linea = 0;
        string videoURL = "";

        public string VideoURL
        {
            get { return videoURL; }
            set { videoURL = value; }
        }

        IWMPPlaylist playlist;
        public IWMPPlaylist Playlist
        {
            get { return playlist; }
            set { playlist = value; }
        }

        public SoftNetVideoControl()
        {
            InitializeComponent();            
        }

        public void AddFiles(string[] fileNames)
        {
            playlist = null;
            playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("SotNetMediaList");

            string fileName = "";
            foreach (string file in fileNames)
            {
                fileName = file;

                lstVideos.Items.Add(fileName);
                lstVideos.Items[linea].SubItems.Add(fileName);

                playlist.appendItem(axWindowsMediaPlayer1.newMedia(fileName));

                linea++;
            }
        }

        private void tobNuevoVideo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;

            items = lstVideos.Items.Count - 1;
            if (items < 0) items = 0;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((openFileDialog1.OpenFile()) != null)
                    AddFiles(openFileDialog1.FileNames);
            }
        }

        private void tobEliminarVideo_Click(object sender, EventArgs e)
        {
            if (lstVideos.SelectedItems.Count > 0)
            {                
                playlist.removeItem(playlist.Item[lstVideos.SelectedItems[0].Index]);                
                lstVideos.SelectedItems[0].Remove();

                linea--;
            }
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsMediaEnded)
            {
                EventArgs e2 = new EventArgs();
                try
                {
                    if (lstVideos.SelectedItems.Count > 0)
                    {
                        int index = lstVideos.SelectedItems[0].Index;
                        lstVideos.Items[index + 1].Selected = true;

                        tobPlay_Click(sender, e2);
                    }
                }
                catch { }
            }
        }

        private void tobPlay_Click(object sender, EventArgs e)
        {
            if (lstVideos.SelectedItems.Count > 0)
                axWindowsMediaPlayer1.URL = lstVideos.SelectedItems[0].SubItems[1].Text.Trim();
            else
            {
                if (lstVideos.Items.Count > 0)
                {
                    lstVideos.Items[0].Selected = true;
                    axWindowsMediaPlayer1.URL = lstVideos.SelectedItems[0].SubItems[1].Text.Trim();
                }
            }
        }

        public void tobStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void lstVideos_DoubleClick(object sender, EventArgs e)
        {
            if (lstVideos.SelectedItems.Count > 0)
            {
                tobPlay_Click(sender, e);
            }
        }

        private void SoftNetVideoControl_Load(object sender, EventArgs e)
        {
        }
    }
}
