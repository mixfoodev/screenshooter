using Gma.System.MouseKeyHook;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ScreenShooterApp
{
    public partial class MainForm : Form
    {
        private IKeyboardMouseEvents m_GlobalHook;
        private System.Media.SoundPlayer player;
        private readonly Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
   
        private readonly KeysConverter keysConverter;
        private readonly PhotoShooter shooter;

        private const string APP_SETTINGS = "appSettings";
        private const string SETTINGS_COUNTER = "counter";
        private const string SETTINGS_SAVEFOLDER = "saveFolder";
        private const string SETTINGS_STARTKEY = "startKey";
        private const string SETTINGS_SAVEKEY = "saveKey";
        private const string SETTINGS_SHOWPOPUP = "showPopup";
        private const string SETTINGS_PLAYSOUND = "playSound";

        private const int EXPANDED_WIDTH = 910;
        private const int COLLAPSED_WIDTH = 380;

        private string saveLocation;
        private string filename;
        private int screenShotCounter;
        private Keys startKey;
        private Keys saveKey;

        public MainForm()
        {
            InitializeComponent();
           
            keysConverter = new KeysConverter();
            shooter = new PhotoShooter();

            this.Width = COLLAPSED_WIDTH;
            this.ActiveControl = help1Label;

            SubscribeToMouseEvents();           
            LoadUserSettings();
            RefreshInstructions();
            SetupNotifierMenu();

            startStopTextBox.Text = startKey.ToString();
            saveKeyTextBox.Text = saveKey.ToString();
            directoryTextBox.Text = saveLocation;               
        }

        private void HandleStartKeyClick()
        {
            if (player == null) player = new System.Media.SoundPlayer();

            switch (shooter.CaptureScreenShot(MousePosition))
            {
                case PhotoShooter.CaptureState.STARTED:
                    SetButtonsEnabled(false);
                    PlayBeepSound();
                    imgPreviewPictureBox.Image = null;
                    filename = null;
                    break;
                case PhotoShooter.CaptureState.CAPTURED:
                    PlayCaptureSound();
                    SetButtonsEnabled(true);
                    imgPreviewPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    imgPreviewPictureBox.Image = shooter.GetPreviewImage(imgPreviewPictureBox.Width, imgPreviewPictureBox.Height);
                    break;
                default:
                    PlayErrorSound();
                    Reset();
                    break;
            }
        }

        private void HandleSaveKeyClick(bool openFolder = false)
        {
            string imgname = string.Format("\\screenshooter ({0}).png", screenShotCounter);
            filename = saveLocation + imgname;
            if (shooter.SaveScreenShot(filename))
            {
                if (showNotificationsCheckBox.Checked)
                {
                    notifyIcon.BalloonTipText = "Screenshot saved!\nClick to open in folder";
                    notifyIcon.ShowBalloonTip(1);
                }
                if (openFolder) OpenFolderWithSelectedFile(filename);
                IncreaseScreenShotCounter();

            }
            else PlayErrorSound();

            Reset();
        }

        private void IncreaseScreenShotCounter()
        {
            screenShotCounter++;
            configuration.AppSettings.Settings[SETTINGS_COUNTER].Value = screenShotCounter.ToString();
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(APP_SETTINGS);
        }

        private void Reset()
        {
            shooter.Reset();
            imgPreviewPictureBox.Image = null;
            SetButtonsEnabled(false);
            this.ActiveControl = help1Label;
        }

        private void PlayErrorSound()
        {
            player.Stop();
            player.Stream = ScreenShooter.Properties.Resources.cancel;
            if (playSoundsCheckBox.Checked) player.Play();
        }

        private void PlayCaptureSound()
        {
            player.Stop();
            player.Stream = ScreenShooter.Properties.Resources.capture;
            if (playSoundsCheckBox.Checked) player.Play();
        }

        private void PlayBeepSound()
        {
            player.Stop();
            player.Stream = ScreenShooter.Properties.Resources.beep;
            if (playSoundsCheckBox.Checked) player.PlayLooping();
        }

        private void UpdateTaskBarTasks()
        {
            JumpList list = JumpList.CreateJumpList();
            list.ClearAllUserTasks();
            JumpListLink folderTask = new JumpListLink(saveLocation, "Open Folder");
            list.AddUserTasks(folderTask);
            list.Refresh();
        }

        public void LoadUserSettings()
        {
            if (configuration.AppSettings.Settings[SETTINGS_SAVEFOLDER] == null)
            {
                const string initialLocation = "\\ScreenShooter";
                configuration.AppSettings.Settings.Add(SETTINGS_SAVEFOLDER,
                    Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + initialLocation);
                configuration.AppSettings.Settings.Add(SETTINGS_STARTKEY, Keys.F9.ToString());
                configuration.AppSettings.Settings.Add(SETTINGS_SAVEKEY, Keys.F10.ToString());
                configuration.AppSettings.Settings.Add(SETTINGS_SHOWPOPUP, "1");
                configuration.AppSettings.Settings.Add(SETTINGS_PLAYSOUND, "1");
                configuration.AppSettings.Settings.Add(SETTINGS_COUNTER, "1");

                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(APP_SETTINGS);                               
            }

            saveLocation = ConfigurationManager.AppSettings[SETTINGS_SAVEFOLDER];
            if (!Directory.Exists(saveLocation)) Directory.CreateDirectory(saveLocation);

            startKey = (Keys) keysConverter.ConvertFromString(ConfigurationManager.AppSettings[SETTINGS_STARTKEY]);
            saveKey = (Keys) keysConverter.ConvertFromString(ConfigurationManager.AppSettings[SETTINGS_SAVEKEY]);
            showNotificationsCheckBox.Checked = ConfigurationManager.AppSettings[SETTINGS_SHOWPOPUP] == "1";
            playSoundsCheckBox.Checked = ConfigurationManager.AppSettings[SETTINGS_PLAYSOUND] == "1";
            screenShotCounter = int.Parse(ConfigurationManager.AppSettings[SETTINGS_COUNTER]);
        }

        private void SetButtonsEnabled(bool enabled)
        {
            saveImgBtn.Enabled = enabled;
            saveAndOpenBtn.Enabled = enabled;
            clearImgBtn.Enabled = enabled;
        }
      
        public void OpenFolderWithSelectedFile(string file)
        {
            string args = file == null ? saveLocation : string.Format("/e, /select, \"{0}\"", file);
            Process.Start("explorer.exe", args);
        }

        private void SetupNotifierMenu()
        {
            ContextMenu contextMenu = new ContextMenu();            
            MenuItem menuShow = new MenuItem("Show", new EventHandler(OpenAppFromTray));
            MenuItem menuOpenFolder = new MenuItem("Open Folder", new EventHandler(OpenFolderBtn_Click));
            MenuItem menuExit = new MenuItem("Exit", new EventHandler(ExitApp));

            contextMenu.MenuItems.Add(menuShow);
            contextMenu.MenuItems.Add(menuOpenFolder);
            contextMenu.MenuItems.Add(menuExit);
            notifyIcon.ContextMenu = contextMenu;
        }

        private void RefreshInstructions()
        {
            help1Label.Text = string.Format("1. Point to the top left corner and press `{0}`.", startKey.ToString());
            help2Label.Text = string.Format("2. Point to the bottom right corner and press `{0}`.", startKey.ToString());
            help3Label.Text = string.Format("3. Press `{0}` to save the screenshot", saveKey.ToString());
            help4Label.Text = string.Format("or press `Shift` + `{0}` to save and open in folder", saveKey.ToString());
        }

        private void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            if (startStopTextBox.Focused || saveKeyTextBox.Focused) return;

            if (e.KeyCode == startKey) HandleStartKeyClick();

            if (e.KeyCode == saveKey)
            {
                if (!shooter.HasCaptureStarted()) return;
                HandleSaveKeyClick(e.Modifiers == Keys.Shift);
            }

            if (e.KeyCode == Keys.Escape && shooter.HasCaptureStarted())
            {
                if (!shooter.HasCaptureFinished()) PlayErrorSound();
                Reset();
            }
        }

        public void OpenFolderBtn_Click(object sender, EventArgs e)
        {
            OpenFolderWithSelectedFile(null);
        }

        private void ChangeLocationBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = saveLocation;

            if (folderBrowserDialog.ShowDialog() != DialogResult.OK ||
                folderBrowserDialog.SelectedPath == saveLocation) return;

            saveLocation = folderBrowserDialog.SelectedPath;
            directoryTextBox.Text = saveLocation;

            configuration.AppSettings.Settings[SETTINGS_SAVEFOLDER].Value = saveLocation;
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(APP_SETTINGS);
            UpdateTaskBarTasks();
        }

        private void ExpandBtn_Click(object sender, EventArgs e)
        {
            if (this.Width == COLLAPSED_WIDTH)
            {
                expandBtn.Text = "<< Collapse";
                pictureBoxGroup.Visible = true;
                this.Width = EXPANDED_WIDTH;
            }
            else
            {
                expandBtn.Text = "Preview";
                pictureBoxGroup.Visible = false;
                this.Width = COLLAPSED_WIDTH;
            }
        }

        private void MinimizeToTrayBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (!showNotificationsCheckBox.Checked) return;
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipText = "Still running in the background..";
            notifyIcon.ShowBalloonTip(1);
        }

        private void ChangeKeys_Click(object sender, EventArgs e)
        {
            if (startKey == (Keys) keysConverter.ConvertFromString(startStopTextBox.Text)
                && saveKey == (Keys) keysConverter.ConvertFromString(saveKeyTextBox.Text)) return;

            startKey = (Keys) keysConverter.ConvertFromString(startStopTextBox.Text);
            saveKey = (Keys) keysConverter.ConvertFromString(saveKeyTextBox.Text);
            configuration.AppSettings.Settings[SETTINGS_STARTKEY].Value = startKey.ToString();
            configuration.AppSettings.Settings[SETTINGS_SAVEKEY].Value = saveKey.ToString();
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(APP_SETTINGS);
            RefreshInstructions();
        }

        private void SaveBtn_CLick(object sender, EventArgs e)
        {
            HandleSaveKeyClick();
        }

        private void SaveAndOpenBtn_CLick(object sender, EventArgs e)
        {
            HandleSaveKeyClick(true);
        }

        private void ClearImgBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void PlaySoundsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            configuration.AppSettings.Settings[SETTINGS_PLAYSOUND].Value = playSoundsCheckBox.Checked ? "1" : "0";
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(APP_SETTINGS);
        }

        private void ShowPopupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            configuration.AppSettings.Settings[SETTINGS_SHOWPOPUP].Value = showNotificationsCheckBox.Checked ? "1" : "0";
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(APP_SETTINGS);
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) OpenAppFromTray(sender, e);
        }

        private void NotifyIconBallon_Click(object sender, EventArgs e)
        {
            if (notifyIcon.BalloonTipText.StartsWith("Still")) return;
            OpenFolderWithSelectedFile(filename);
        }

        private void StartStopTextBox_KeyDown(object sender, KeyEventArgs e)
        {          
            if (e.Modifiers != Keys.None 
                || e.KeyCode == Keys.Escape 
                || e.KeyCode == saveKey 
                || startStopTextBox.Text == e.KeyCode.ToString()) return;

            startStopTextBox.Text = e.KeyCode.ToString();
        }

        private void SaveTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers != Keys.None
                || e.KeyCode == Keys.Escape
                || e.KeyCode == startKey
                || saveKeyTextBox.Text == e.KeyCode.ToString()) return;
            saveKeyTextBox.Text = e.KeyCode.ToString();
        }
   
        public void OpenAppFromTray(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon.Visible = false;
        }

        public void SubscribeToMouseEvents()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += GlobalHookKeyDown;
        }

        public void UnsubscribeFromGlobalHookEvents()
        {
            if (m_GlobalHook == null) return;
            m_GlobalHook.KeyDown -= GlobalHookKeyDown;
            m_GlobalHook.Dispose();
        }

        protected void ExitApp(object sender, EventArgs e)
        {
            UnsubscribeFromGlobalHookEvents();
            Close();
        }
    }
}
