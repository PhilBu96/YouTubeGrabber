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
    public partial class BugReport : Form
    {
        public BugReport()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private bool ReportBug(string subject, string name, string email, string message)
        {
            return true;
        }

        private void Button_send_Click(object sender, EventArgs e)
        {
            //URL-Template: https://arro-films.de/misc/func/report-to-db.php?subject=TESTSUBJECT&name=TESTNAME&email=TESTEMAIL&message=TESTMESSAGE
            if (!ReportBug(textBox_subject.Text, textBox_name.Text, textBox_mail.Text, textBox_message.Text))
            {
                MessageBox.Show("Fehlermeldung konnte nicht versendet werden. Bitte überprüfe deine Internetverbindung und Firewall-Einstellungen!",
                    "Fehler!", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Vielen Dank! Wenn du eine E-Mail-Adresse mitgeschickt hast, werde ich dir antworten.", "Danke!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Dispose();
            }
        }
    }
}
