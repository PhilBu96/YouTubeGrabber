using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouTubeGrabber
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Console.WriteLine("Programm wird initialisiert...");
            InitializeComponent();
        }

        /// <summary>
        /// Gibt true zurück, wenn das Video erfolgreich heruntergeladen wurde.
        /// </summary>
        /// <param name="url">Die YouTube-URL</param>
        /// <returns></returns>
        private bool DownloadVideo(String url)
        {
            bool success = false;

            //Wenn nichts in der Text-Box eingegeben wurde
            if (url == String.Empty || url == "\\s+")
            {
                //Gibt immer false zurück, wenn Bedingung erfüllt, da success am Start auf false gesetzt wird
                return success;
            }

            return success;
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(DownloadVideo(textBox_inputUrl.Text));
        }
    }
}
