namespace YouTubeGrabber
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_inputUri = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_check = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.textBox_info = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenu_info = new System.Windows.Forms.ToolStripMenuItem();
            this.fehlerMeldenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_resolution = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_inputUri
            // 
            this.textBox_inputUri.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_inputUri.Location = new System.Drawing.Point(16, 69);
            this.textBox_inputUri.Name = "textBox_inputUri";
            this.textBox_inputUri.Size = new System.Drawing.Size(626, 31);
            this.textBox_inputUri.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "YouTube-Video-URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Informationen zum Video:";
            // 
            // button_check
            // 
            this.button_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_check.Location = new System.Drawing.Point(648, 69);
            this.button_check.Name = "button_check";
            this.button_check.Size = new System.Drawing.Size(127, 31);
            this.button_check.TabIndex = 3;
            this.button_check.Text = "Prüfen";
            this.button_check.UseVisualStyleBackColor = true;
            this.button_check.Click += new System.EventHandler(this.Button_check_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadButton.Location = new System.Drawing.Point(11, 493);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(760, 67);
            this.downloadButton.TabIndex = 4;
            this.downloadButton.Text = "Video herunterladen!";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // textBox_info
            // 
            this.textBox_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_info.Location = new System.Drawing.Point(16, 147);
            this.textBox_info.Multiline = true;
            this.textBox_info.Name = "textBox_info";
            this.textBox_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_info.Size = new System.Drawing.Size(755, 134);
            this.textBox_info.TabIndex = 5;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 567);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(759, 93);
            this.progressBar.TabIndex = 6;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenu_info,
            this.fehlerMeldenToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 7;
            // 
            // toolStripMenu_info
            // 
            this.toolStripMenu_info.Name = "toolStripMenu_info";
            this.toolStripMenu_info.Size = new System.Drawing.Size(40, 20);
            this.toolStripMenu_info.Text = "Info";
            this.toolStripMenu_info.Click += new System.EventHandler(this.ToolStripMenu_info_Click);
            // 
            // fehlerMeldenToolStripMenuItem
            // 
            this.fehlerMeldenToolStripMenuItem.Name = "fehlerMeldenToolStripMenuItem";
            this.fehlerMeldenToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.fehlerMeldenToolStripMenuItem.Text = "Fehler melden";
            this.fehlerMeldenToolStripMenuItem.Click += new System.EventHandler(this.FehlerMeldenToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Optionen:";
            // 
            // comboBox_resolution
            // 
            this.comboBox_resolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_resolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_resolution.FormattingEnabled = true;
            this.comboBox_resolution.Items.AddRange(new object[] {
            "144",
            "240",
            "360",
            "480",
            "720",
            "1080",
            "1440",
            "2160"});
            this.comboBox_resolution.Location = new System.Drawing.Point(16, 354);
            this.comboBox_resolution.Name = "comboBox_resolution";
            this.comboBox_resolution.Size = new System.Drawing.Size(121, 28);
            this.comboBox_resolution.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Auflösung:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 671);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_resolution);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textBox_info);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.button_check);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_inputUri);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 710);
            this.MinimumSize = new System.Drawing.Size(800, 710);
            this.Name = "MainForm";
            this.Text = "YouTubeGrabber by Philipp Buthmann";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_inputUri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_check;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.TextBox textBox_info;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_info;
        private System.Windows.Forms.ToolStripMenuItem fehlerMeldenToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_resolution;
        private System.Windows.Forms.Label label4;
    }
}

