namespace ScreenShooterApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.startStopTextBox = new System.Windows.Forms.TextBox();
            this.saveKeyTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.changeLocBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.changeKeysBtn = new System.Windows.Forms.Button();
            this.pressKeyLabel = new System.Windows.Forms.Label();
            this.openFolderBtn = new System.Windows.Forms.Button();
            this.pressKeyLabel2 = new System.Windows.Forms.Label();
            this.expandBtn = new System.Windows.Forms.Button();
            this.imgPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.saveImgBtn = new System.Windows.Forms.Button();
            this.pictureBoxGroup = new System.Windows.Forms.GroupBox();
            this.saveAndOpenBtn = new System.Windows.Forms.Button();
            this.clearImgBtn = new System.Windows.Forms.Button();
            this.help1Label = new System.Windows.Forms.Label();
            this.help2Label = new System.Windows.Forms.Label();
            this.help3Label = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.help4Label = new System.Windows.Forms.Label();
            this.playSoundsCheckBox = new System.Windows.Forms.CheckBox();
            this.showNotificationsCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreviewPictureBox)).BeginInit();
            this.pictureBoxGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // startStopTextBox
            // 
            this.startStopTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.startStopTextBox.Location = new System.Drawing.Point(13, 103);
            this.startStopTextBox.Name = "startStopTextBox";
            this.startStopTextBox.ReadOnly = true;
            this.startStopTextBox.Size = new System.Drawing.Size(71, 20);
            this.startStopTextBox.TabIndex = 15;
            this.startStopTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartStopTextBox_KeyDown);
            // 
            // saveKeyTextBox
            // 
            this.saveKeyTextBox.Location = new System.Drawing.Point(13, 142);
            this.saveKeyTextBox.Name = "saveKeyTextBox";
            this.saveKeyTextBox.ReadOnly = true;
            this.saveKeyTextBox.Size = new System.Drawing.Size(71, 20);
            this.saveKeyTextBox.TabIndex = 16;
            this.saveKeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaveTextBox_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Start/Stop key";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Save key";
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Location = new System.Drawing.Point(261, 49);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(90, 22);
            this.minimizeBtn.TabIndex = 19;
            this.minimizeBtn.TabStop = false;
            this.minimizeBtn.Text = "Minimize to tray";
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.MinimizeToTrayBtn_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Still running!";
            this.notifyIcon.BalloonTipTitle = "Photoshooter";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Photoshooter";
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.NotifyIconBallon_Click);
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.directoryTextBox.Enabled = false;
            this.directoryTextBox.Location = new System.Drawing.Point(12, 23);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.ReadOnly = true;
            this.directoryTextBox.Size = new System.Drawing.Size(242, 20);
            this.directoryTextBox.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(141, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Saved screenshots directory";
            // 
            // changeLocBtn
            // 
            this.changeLocBtn.Location = new System.Drawing.Point(125, 49);
            this.changeLocBtn.Name = "changeLocBtn";
            this.changeLocBtn.Size = new System.Drawing.Size(102, 22);
            this.changeLocBtn.TabIndex = 19;
            this.changeLocBtn.TabStop = false;
            this.changeLocBtn.Text = "Change directory";
            this.changeLocBtn.UseVisualStyleBackColor = true;
            this.changeLocBtn.Click += new System.EventHandler(this.ChangeLocationBtn_Click);
            // 
            // changeKeysBtn
            // 
            this.changeKeysBtn.Location = new System.Drawing.Point(14, 171);
            this.changeKeysBtn.Name = "changeKeysBtn";
            this.changeKeysBtn.Size = new System.Drawing.Size(116, 23);
            this.changeKeysBtn.TabIndex = 20;
            this.changeKeysBtn.Text = "Confirm keys change";
            this.changeKeysBtn.UseVisualStyleBackColor = true;
            this.changeKeysBtn.Click += new System.EventHandler(this.ChangeKeys_Click);
            // 
            // pressKeyLabel
            // 
            this.pressKeyLabel.AutoSize = true;
            this.pressKeyLabel.Location = new System.Drawing.Point(90, 106);
            this.pressKeyLabel.Name = "pressKeyLabel";
            this.pressKeyLabel.Size = new System.Drawing.Size(154, 13);
            this.pressKeyLabel.TabIndex = 22;
            this.pressKeyLabel.Text = "- Press a key for each function ";
            // 
            // openFolderBtn
            // 
            this.openFolderBtn.Location = new System.Drawing.Point(12, 49);
            this.openFolderBtn.Name = "openFolderBtn";
            this.openFolderBtn.Size = new System.Drawing.Size(107, 22);
            this.openFolderBtn.TabIndex = 19;
            this.openFolderBtn.TabStop = false;
            this.openFolderBtn.Text = "Open Folder";
            this.openFolderBtn.UseVisualStyleBackColor = true;
            this.openFolderBtn.Click += new System.EventHandler(this.OpenFolderBtn_Click);
            // 
            // pressKeyLabel2
            // 
            this.pressKeyLabel2.AutoSize = true;
            this.pressKeyLabel2.Location = new System.Drawing.Point(90, 126);
            this.pressKeyLabel2.Name = "pressKeyLabel2";
            this.pressKeyLabel2.Size = new System.Drawing.Size(109, 13);
            this.pressKeyLabel2.TabIndex = 22;
            this.pressKeyLabel2.Text = "- or leave the defaults";
            // 
            // expandBtn
            // 
            this.expandBtn.Location = new System.Drawing.Point(261, 23);
            this.expandBtn.Name = "expandBtn";
            this.expandBtn.Size = new System.Drawing.Size(90, 22);
            this.expandBtn.TabIndex = 23;
            this.expandBtn.Text = "Preview";
            this.expandBtn.UseVisualStyleBackColor = true;
            this.expandBtn.Click += new System.EventHandler(this.ExpandBtn_Click);
            // 
            // imgPreviewPictureBox
            // 
            this.imgPreviewPictureBox.Location = new System.Drawing.Point(6, 11);
            this.imgPreviewPictureBox.Name = "imgPreviewPictureBox";
            this.imgPreviewPictureBox.Size = new System.Drawing.Size(487, 265);
            this.imgPreviewPictureBox.TabIndex = 24;
            this.imgPreviewPictureBox.TabStop = false;
            // 
            // saveImgBtn
            // 
            this.saveImgBtn.Enabled = false;
            this.saveImgBtn.Location = new System.Drawing.Point(6, 282);
            this.saveImgBtn.Name = "saveImgBtn";
            this.saveImgBtn.Size = new System.Drawing.Size(96, 23);
            this.saveImgBtn.TabIndex = 25;
            this.saveImgBtn.Text = "Save";
            this.saveImgBtn.UseVisualStyleBackColor = true;
            this.saveImgBtn.Click += new System.EventHandler(this.SaveBtn_CLick);
            // 
            // pictureBoxGroup
            // 
            this.pictureBoxGroup.Controls.Add(this.saveAndOpenBtn);
            this.pictureBoxGroup.Controls.Add(this.clearImgBtn);
            this.pictureBoxGroup.Controls.Add(this.saveImgBtn);
            this.pictureBoxGroup.Controls.Add(this.imgPreviewPictureBox);
            this.pictureBoxGroup.Location = new System.Drawing.Point(357, 7);
            this.pictureBoxGroup.Name = "pictureBoxGroup";
            this.pictureBoxGroup.Size = new System.Drawing.Size(531, 307);
            this.pictureBoxGroup.TabIndex = 27;
            this.pictureBoxGroup.TabStop = false;
            this.pictureBoxGroup.Visible = false;
            // 
            // saveAndOpenBtn
            // 
            this.saveAndOpenBtn.Enabled = false;
            this.saveAndOpenBtn.Location = new System.Drawing.Point(108, 282);
            this.saveAndOpenBtn.Name = "saveAndOpenBtn";
            this.saveAndOpenBtn.Size = new System.Drawing.Size(96, 23);
            this.saveAndOpenBtn.TabIndex = 27;
            this.saveAndOpenBtn.Text = "Save and open";
            this.saveAndOpenBtn.UseVisualStyleBackColor = true;
            this.saveAndOpenBtn.Click += new System.EventHandler(this.SaveAndOpenBtn_CLick);
            // 
            // clearImgBtn
            // 
            this.clearImgBtn.Enabled = false;
            this.clearImgBtn.Location = new System.Drawing.Point(397, 282);
            this.clearImgBtn.Name = "clearImgBtn";
            this.clearImgBtn.Size = new System.Drawing.Size(96, 23);
            this.clearImgBtn.TabIndex = 26;
            this.clearImgBtn.Text = "Clear";
            this.clearImgBtn.UseVisualStyleBackColor = true;
            this.clearImgBtn.Click += new System.EventHandler(this.ClearImgBtn_Click);
            // 
            // help1Label
            // 
            this.help1Label.AutoSize = true;
            this.help1Label.Location = new System.Drawing.Point(16, 226);
            this.help1Label.Name = "help1Label";
            this.help1Label.Size = new System.Drawing.Size(215, 13);
            this.help1Label.TabIndex = 28;
            this.help1Label.Text = "1. Point to the top left corner and press \"F9\"";
            // 
            // help2Label
            // 
            this.help2Label.AutoSize = true;
            this.help2Label.Location = new System.Drawing.Point(16, 248);
            this.help2Label.Name = "help2Label";
            this.help2Label.Size = new System.Drawing.Size(238, 13);
            this.help2Label.TabIndex = 28;
            this.help2Label.Text = "2. Point to the bottom right corner and press \"F9\"";
            // 
            // help3Label
            // 
            this.help3Label.AutoSize = true;
            this.help3Label.Location = new System.Drawing.Point(16, 270);
            this.help3Label.Name = "help3Label";
            this.help3Label.Size = new System.Drawing.Size(187, 13);
            this.help3Label.TabIndex = 28;
            this.help3Label.Text = "3 .Press \"F10\" to save the screenshot";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(213, 226);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 13);
            this.label19.TabIndex = 28;
            // 
            // help4Label
            // 
            this.help4Label.AutoSize = true;
            this.help4Label.Location = new System.Drawing.Point(28, 289);
            this.help4Label.Name = "help4Label";
            this.help4Label.Size = new System.Drawing.Size(218, 13);
            this.help4Label.TabIndex = 29;
            this.help4Label.Text = "or press Shift+F10 to save and open in folder";
            // 
            // playSoundsCheckBox
            // 
            this.playSoundsCheckBox.AutoSize = true;
            this.playSoundsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.playSoundsCheckBox.Checked = true;
            this.playSoundsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playSoundsCheckBox.Location = new System.Drawing.Point(268, 177);
            this.playSoundsCheckBox.Name = "playSoundsCheckBox";
            this.playSoundsCheckBox.Size = new System.Drawing.Size(83, 17);
            this.playSoundsCheckBox.TabIndex = 32;
            this.playSoundsCheckBox.Text = "Play sounds";
            this.playSoundsCheckBox.UseVisualStyleBackColor = true;
            this.playSoundsCheckBox.CheckedChanged += new System.EventHandler(this.PlaySoundsCheckBox_CheckedChanged);
            // 
            // showNotificationsCheckBox
            // 
            this.showNotificationsCheckBox.AutoSize = true;
            this.showNotificationsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showNotificationsCheckBox.Location = new System.Drawing.Point(267, 154);
            this.showNotificationsCheckBox.Name = "showNotificationsCheckBox";
            this.showNotificationsCheckBox.Size = new System.Drawing.Size(84, 17);
            this.showNotificationsCheckBox.TabIndex = 34;
            this.showNotificationsCheckBox.Text = "Notifications";
            this.showNotificationsCheckBox.UseVisualStyleBackColor = true;
            this.showNotificationsCheckBox.CheckedChanged += new System.EventHandler(this.ShowPopupCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1053, 330);
            this.Controls.Add(this.showNotificationsCheckBox);
            this.Controls.Add(this.playSoundsCheckBox);
            this.Controls.Add(this.help4Label);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.help3Label);
            this.Controls.Add(this.help2Label);
            this.Controls.Add(this.help1Label);
            this.Controls.Add(this.pictureBoxGroup);
            this.Controls.Add(this.expandBtn);
            this.Controls.Add(this.pressKeyLabel2);
            this.Controls.Add(this.pressKeyLabel);
            this.Controls.Add(this.changeKeysBtn);
            this.Controls.Add(this.openFolderBtn);
            this.Controls.Add(this.changeLocBtn);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.saveKeyTextBox);
            this.Controls.Add(this.directoryTextBox);
            this.Controls.Add(this.startStopTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ScreenShooter";
            ((System.ComponentModel.ISupportInitialize)(this.imgPreviewPictureBox)).EndInit();
            this.pictureBoxGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox startStopTextBox;
        private System.Windows.Forms.TextBox saveKeyTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button changeLocBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button changeKeysBtn;
        private System.Windows.Forms.Label pressKeyLabel;
        private System.Windows.Forms.Button openFolderBtn;
        private System.Windows.Forms.Label pressKeyLabel2;
        private System.Windows.Forms.Button expandBtn;
        private System.Windows.Forms.PictureBox imgPreviewPictureBox;
        private System.Windows.Forms.Button saveImgBtn;
        private System.Windows.Forms.GroupBox pictureBoxGroup;
        private System.Windows.Forms.Button clearImgBtn;
        private System.Windows.Forms.Label help1Label;
        private System.Windows.Forms.Label help2Label;
        private System.Windows.Forms.Label help3Label;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button saveAndOpenBtn;
        private System.Windows.Forms.Label help4Label;
        private System.Windows.Forms.CheckBox playSoundsCheckBox;
        private System.Windows.Forms.CheckBox showNotificationsCheckBox;
    }
}

