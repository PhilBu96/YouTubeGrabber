using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace YouTubeGrabber
{
    public partial class BugReport : Form
    {
        //Lokale Felder
        readonly int MAX_ALLOWED_CHARS = 1000;
        int remainChars = 1000;

        public BugReport()
        {
            InitializeComponent();
            CenterToScreen();
        }

        /// <summary>
        /// Öffnet das PHP-Skript auf einer Website und übergibt als GET-Parameter die Daten aus dem ReportFrame
        /// </summary>
        /// <param name="subject">Betreff der Nachricht</param>
        /// <param name="name">Name der Person, die den Report verschickt</param>
        /// <param name="email">E-Mail-Adresse der Person, die den Report verschickt</param>
        /// <param name="message">Nachricht, die verschickt werden soll</param>
        /// <returns></returns>
        private bool ReportBug(string subject, string name, string email, string message)
        {
            if (message.Length > 1000)
            {
                return false;
            }

            message = HttpUtility.UrlEncode(message);
            subject = HttpUtility.UrlEncode(subject);
            name = HttpUtility.UrlEncode(name);
            email = HttpUtility.UrlEncode(email);

            string phpGetData = string.Format("subject={0}&name={1}&email={2}&message={3}",
                subject, name, email, message);
            string uri = "https://arro-films.de/misc/func/report-to-db.php?";
            string completeURI = uri + phpGetData;
            Console.WriteLine("URI: " + completeURI);

            try
            {
                WebClient client = new WebClient();
                Stream data = client.OpenRead(completeURI);

                //Nur zum debuggen - gibt die Antwort vom Server zurück
                /*StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                Console.WriteLine(s);
                data.Close();
                reader.Close();*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        private void ToGoogleForm(string subject, string name, string email, string message)
        {
            string formContent = string.Format("Betreff: {0}\nName: {1}\nE-Mail: {2}\nNachricht: \n{3}", 
                subject, name, email, message);
            string formID = "1FAIpQLScT9VOXtQG1k5b_s-j_mULfSi5k4HioxaHL6VxaT1LQE3Jsvw";
            WebClient client = new WebClient();
            var nameValue = new NameValueCollection();
            nameValue.Add("entry.1561870173", formContent);
            nameValue.Add("pageHistory", "0");
            Uri uri = new Uri("https://docs.google.com/forms/d/e/" + formID + "/formResponse");
            /*byte[] response = */client.UploadValues(uri, "POST", nameValue);
            //string result = Encoding.UTF8.GetString(response);
        }

        private void Button_send_Click(object sender, EventArgs e)
        {
            if (!ReportBug(textBox_subject.Text, textBox_name.Text, textBox_mail.Text, textBox_message.Text))
            {
                MessageBox.Show("Fehlermeldung konnte nicht versendet werden. Bitte überprüfe deine Internetverbindung und Firewall-Einstellungen!" +
                    " Oder hast du mehr als 1000 Zeichen eingegeben? ;-)",
                    "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Vielen Dank! Wenn du eine E-Mail-Adresse mitgeschickt hast, werde ich dir antworten.", "Danke!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ToGoogleForm(textBox_subject.Text, textBox_name.Text, textBox_mail.Text, textBox_message.Text);

                Dispose();
            }
        }

        private void TextBox_message_TextChanged(object sender, EventArgs e)
        {
            if (remainChars <= 0)
            {
                label_chars_remaining.ForeColor = Color.Red;
            }
            else
            {
                label_chars_remaining.ForeColor = SystemColors.ControlText;
            }
            remainChars = MAX_ALLOWED_CHARS - textBox_message.Text.Length;
            label_chars_remaining.Text = string.Format("Zeichen übrig: {0}/{1}", remainChars, MAX_ALLOWED_CHARS);
        }
    }
}
