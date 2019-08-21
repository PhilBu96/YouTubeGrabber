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
            this.SuspendLayout();
            // 
            // textBox_inputUri
            // 
            this.textBox_inputUri.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_inputUri.Location = new System.Drawing.Point(12, 58);
            this.textBox_inputUri.Name = "textBox_inputUri";
            this.textBox_inputUri.Size = new System.Drawing.Size(626, 31);
            this.textBox_inputUri.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "YouTube-Video-URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Informationen zum Video:";
            // 
            // button_check
            // 
            this.button_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_check.Location = new System.Drawing.Point(645, 58);
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
            this.downloadButton.Location = new System.Drawing.Point(12, 482);
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
            this.textBox_info.Location = new System.Drawing.Point(17, 136);
            this.textBox_info.Multiline = true;
            this.textBox_info.Name = "textBox_info";
            this.textBox_info.Size = new System.Drawing.Size(755, 340);
            this.textBox_info.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.textBox_info);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.button_check);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_inputUri);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "YouTubeGrabber";
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
    }
}

