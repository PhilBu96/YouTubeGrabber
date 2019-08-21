using System;
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
            Console.WriteLine("In DownloadVideo-Methode...");
            bool success;

            //Wenn nichts in der Text-Box eingegeben wurde
            if (url.Trim() == String.Empty)
            {
                Console.WriteLine("URL ist leer!");
                success = false;
                return success;
            }

            if (url.Contains("youtube") || url.Contains("youtu.be"))
            {
                Console.WriteLine("URL ist gültig!");
            }
            else
            {
                Console.WriteLine("URL ist ungültig!");
                success = false;
                return success;
            }

            success = true;
            return success;
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Download Button wurde geklickt!");
            Console.WriteLine(DownloadVideo(textBox_inputUrl.Text.ToLower()));
            Console.WriteLine("DownloadVideo wurde verlassen!");
        }
    }
}
