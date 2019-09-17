using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VideoLibrary;
using Xabe.FFmpeg;

namespace YouTubeGrabber
{
    public partial class MainForm : Form
    {
        //Globale Felder für Metadaten
        string uri;
        string title;
        string fileExtension;
        int resolution;

        public MainForm()
        {
            Console.WriteLine("Programm wird initialisiert...");
            InitializeComponent();
            CenterToScreen();
        }

        /// <summary>
        /// Gibt true zurück, wenn das Video erfolgreich heruntergeladen wurde.
        /// </summary>
        /// <param name="uri">Die YouTube-URL</param>
        /// <returns></returns>
        private void DownloadVideo(string uri)
        {
            Console.WriteLine("In DownloadVideo-Methode...");
            this.uri = uri;
            saveFileDialog = new SaveFileDialog
            {
                Filter = "mp4 - Datei | *.mp4"
            };
            var youtube = YouTube.Default;
            string path;

            //Wenn nichts in der Text-Box eingegeben wurde
            if (uri.Trim() == string.Empty)
            {
                Console.WriteLine("URL ist leer!");
            }

            //Wenn die URL ungültig ist
            if (uri.Contains("youtube") || uri.Contains("youtu.be"))
            {
                Console.WriteLine("URL ist gültig!");
            }
            else
            {
                Console.WriteLine("URL ist ungültig!");
            }

            //Wenn die URL in Ordnung ist, dann geht es hier weiter
            //Save-Dialog
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
                Console.WriteLine("Datei wird geschrieben in: " + path);
            }
            else
            {
                //Wenn abgebrochen wird, wird die Methode verlassen
                return;
            }

            //Cursor wirt auf warten gesetzt
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                //Metadaten zum Video holen
                var video = youtube.GetVideo(uri);
                title = video.Title;
                fileExtension = video.FileExtension;
                resolution = video.Resolution;

                DisplayMetaData(title, fileExtension, resolution);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim finden des Videos: " + uri, "Fehler!");
                Console.WriteLine(ex);
            }

            try
            {
                //Resolution ist int (360, 480, 720, 1080 usw.)
                //File.WriteAllBytes(path, youtube.GetVideo(uri).GetBytes());
                //PROBLEM mit Unknown AudioFormat
                //Alle Auflösungen außer 720 sind Adaptive. Audio für alle Auflösungen in 720 enthalten
                //Wenn Video nicht 720 -> Audio aus 720 mit Video zusammenführen
                //Wenn Video 720 -> ganz normal in Datei schreiben
                //UPDATE: Download von Material ohne Sound klappt, dauert aber länger
                //Nächster Schritt: Video Download (ausgew. Auflösung) + Sound vom nicht adaptiven Video mergen

                var videos = youtube.GetAllVideos(uri);
                var nonAdaptiveVideo = youtube.GetVideo(uri);
                List<YouTubeVideo> videosForDownload = new List<YouTubeVideo>();
                List<YouTubeVideo> videosForSound = new List<YouTubeVideo>();

                //Video wird direkt heruntergeladen, wenn das gewünschte Video (Auflösung) nicht adaptiv ist
                if (nonAdaptiveVideo.Format == VideoFormat.Mp4 && nonAdaptiveVideo.Resolution == int.Parse(comboBox_resolution.Text) && !nonAdaptiveVideo.IsAdaptive)
                {
                    File.WriteAllBytes(path, nonAdaptiveVideo.GetBytes());
                }

                foreach (var video in videos)
                {
                    if (video.Resolution == int.Parse(comboBox_resolution.Text) && video.Format == VideoFormat.Mp4)
                    {
                        videosForDownload.Add(video);
                    }

                    if (!video.IsAdaptive && video.Resolution > 0)
                    {
                        videosForSound.Add(video);
                    }
                }

                Console.WriteLine("VIDEOS FOR DOWNLOAD:");
                foreach (var video in videosForDownload)
                {
                    Console.WriteLine("Auflösung: " + video.Resolution);
                    Console.WriteLine("Titel: " + video.Title);
                    Console.WriteLine("Dateiformat: " + video.FileExtension);
                    Console.WriteLine("Audio-Format: " + video.AudioFormat);
                    Console.WriteLine("Audio-Bitrate: " + video.AudioBitrate);
                    Console.WriteLine("Video-Format: " + video.Format);
                    Console.WriteLine("Adaptive-Kind: " + video.AdaptiveKind);
                    Console.WriteLine("isAdaptive: " + video.IsAdaptive);
                    
                    Console.WriteLine();
                }

                Console.WriteLine("VIDEOS FOR SOUND:");
                foreach (var video in videosForSound)
                {
                    Console.WriteLine("Auflösung: " + video.Resolution);
                    Console.WriteLine("Titel: " + video.Title);
                    Console.WriteLine("Dateiformat: " + video.FileExtension);
                    Console.WriteLine("Audio-Format: " + video.AudioFormat);
                    Console.WriteLine("Audio-Bitrate: " + video.AudioBitrate);
                    Console.WriteLine("Video-Format: " + video.Format);
                    Console.WriteLine("Adaptive-Kind: " + video.AdaptiveKind);
                    Console.WriteLine("isAdaptive: " + video.IsAdaptive);

                    Console.WriteLine();
                }

                //HIER FINDET DER EIGENTLICHE DOWNLOAD STATT WENN DAS VIDEO ADAPTIV IST
                //Download des Videos ohne Sound
                foreach (var video in videosForDownload)
                {
                    File.WriteAllBytes(path, video.GetBytes());
                }

                //Download des Videos mit Sound, aber in geringerer Auflösung
                var soundVideo = videosForSound[0];
                foreach (var video in videosForSound)
                {
                    if (video.AudioBitrate > soundVideo.AudioBitrate)
                    {
                        soundVideo = video;
                    }
                }
                Console.WriteLine("Best audio bitrate found: " + soundVideo.AudioBitrate);
                File.WriteAllBytes(path + "SOUND", soundVideo.GetBytes());

                //Extrahieren des Tons aus dem nicht adaptiven Video und zusammenführen zu einem neuen Video
                MergeConversion(path + "SOUND", path, path + "FINAL.mp4", Path.GetDirectoryName(path) + Path.DirectorySeparatorChar);
            }
            catch (Exception ex)
            {
                //Der Cursor wird auf normal gesetzt
                Cursor.Current = Cursors.Default;
                Console.WriteLine(ex);
                MessageBox.Show("Fehler beim Download des Videos: " + title, "Fehler beim Download!");
            }

            //Der Cursor wird auf normal gesetzt
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Extrahiert das Audio aus dem nicht adaptiven Video und fügt es mit dem adaptiven Video zusammen
        /// </summary>
        /// <param name="inputAudioVideo">Nicht adaptives Video, was das Audio enthält</param>
        /// <param name="inputVideo">Adaptives Video, mit dem das Audio kombiniert werden soll</param>
        /// <param name="output">Ausgabedatei für das Ergebnis</param>
        /// <param name="workDir">Aktuelles Verzeichnis (um eine temporäre Datei anzulegen)</param>
        private async void MergeConversion(string inputAudioVideo, string inputVideo, string output, string workDir)
        {
            string tempAudioFile = workDir + "temp.mp3";
            await FFmpeg.GetLatestVersion();
            await Conversion.ExtractAudio(inputAudioVideo, tempAudioFile).Start();
            await Conversion.AddAudio(inputVideo, tempAudioFile, output).Start();
        }

        /// <summary>
        /// Zeigt die Metadaten des Videos in der Textbox
        /// </summary>
        /// <param name="vidTitle">Titel des Videos</param>
        /// <param name="vidFileExtension">Dateiendung des Videos</param>
        /// <param name="vidFullName">Kompletter Name des Videos (Titel + Dateiendung)</param>
        /// <param name="vidResolution">Auflösung des Videos</param>
        private void DisplayMetaData(string vidTitle, string vidFileExtension, int vidResolution)
        {
            textBox_info.Text = string.Format("Titel: {0}Format: {1}Auflösung: {2}",
                vidTitle + Environment.NewLine + Environment.NewLine, 
                vidFileExtension + Environment.NewLine + Environment.NewLine, vidResolution + "p");
        }

        /// <summary>
        /// Der Button "Video herunterladen!" wird geklickt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadButton_Click(object sender, EventArgs e)
        {
            DownloadVideo(textBox_inputUri.Text);
        }

        /// <summary>
        /// Der Button "Prüfen" wird geklickt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_check_Click(object sender, EventArgs e)
        {
            //Der Cursor wird auf warten gesetzt
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var youtube = YouTube.Default;
                uri = textBox_inputUri.Text;
                var video = youtube.GetVideo(uri);

                title = video.Title;
                fileExtension = video.FileExtension;
                resolution = video.Resolution;

                DisplayMetaData(title, fileExtension, resolution);

                //Der Cursor wird wieder normal gesetzt
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein unbekannter Fehler ist aufgetreten! Entweder die URL ist ungültig oder das Video ist privat!", "Fehler");
                Console.WriteLine(ex);
            }

            //Der Cursor wird wieder normal gesetzt
            Cursor.Current = Cursors.Default;
        }

        private void ReportBug()
        {
            BugReport bugReport = new BugReport();
            bugReport.Show();
        }

        private void ShowCopyrightDialog()
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show();
        }

        private void ToolStripMenu_info_Click(object sender, EventArgs e)
        {
            ShowCopyrightDialog();
        }

        private void FehlerMeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportBug();
        }
    }
}
