/*
 * wifi SD Watch
 * 
 *  * copyright (c) 2023
 * All rights are reserved by Naoki Ueda and stellartech.science
 * 
 * Project Folder
 * 
 * 
 * This codes are opened under MIT lisense.
 * https://opensource.org/licenses/MIT
 * 
 * 2023/Feb/5
 * 
 */
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace wifiSdWatch
{
    /// <summary>
    /// wifi SD Watch Main Screen
    /// </summary>
    public partial class wifiSdWatchMainForm : Form
    {
        //Wifi Instances
        private wifiUi wifiSD;

        //Status to control gui presentation
        private bool isDownloadRunning = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public wifiSdWatchMainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize gui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Version.getVerionText();
            label_downloadedFileInfo.Text = "";
            textBoxDownloadFolder.Text = Properties.Settings.Default.lastDownloadFolder;
            comboBoxWifiType.SelectedIndex = Properties.Settings.Default.lastWifiType;
            pictureBoxWifiNG.Visible = false;
        }

        /// <summary>
        /// Start/Stop button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_StartWatch_Click(object sender, EventArgs e)
        {
            if (!isDownloadRunning)
            {
                //Start
                string downLoadFolder = textBoxDownloadFolder.Text;
                if (!Directory.Exists(downLoadFolder))
                {
                    MessageBox.Show("Download Folder does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //If download folder is not empty, ask to delete
                if (new DirectoryInfo(downLoadFolder).GetFiles().Length > 0)
                {
                    DialogResult dr = MessageBox.Show("DELETE ALL files in download folder?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                    else if (dr == DialogResult.Yes)
                    {
                        //Delete All files in download file
                        foreach (FileInfo file in new DirectoryInfo(downLoadFolder).GetFiles())
                        {
                            file.Delete();
                        }
                    }
                }

                MessageBox.Show("Start/Restart Livestack, then press OK", "Pause", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (comboBoxWifiType.Text == "ezSh@re")
                {
                    wifiSD = new ezShare();
                }
                else if(comboBoxWifiType.Text == "FlashAir")
                {
                    wifiSD = new FlashAir();
                }
                wifiSD.startDownloadService(downLoadFolder, this);
                isDownloadRunning = true;
                Task.Run(() => netWorkErrorWatchLoop());
            }
            else
            {
                //Stop
                wifiSD.stopDownloadService();
                isDownloadRunning = false;
                wifiSD = null;
            }
            buttonDownload.Text = isDownloadRunning ? "STOP" : "START";
            pictureBoxStill_0.Visible = !isDownloadRunning;
            pictureBox_moving_0.Visible = isDownloadRunning;
        }


        # region copyright message
        /// <summary>
        /// Show copyright notice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Version.getCopyrightText(), "Copyright-Under MIT license ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        /// <summary>
        /// Open folder select dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFolderDlg_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select Download Folder";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            if (Properties.Settings.Default.lastDownloadFolder != null && Properties.Settings.Default.lastDownloadFolder != "")
            {
                fbd.SelectedPath = Properties.Settings.Default.lastDownloadFolder;
            }
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                textBoxDownloadFolder.Text = fbd.SelectedPath;

                Console.WriteLine(fbd.SelectedPath);
            }
        }

        /// <summary>
        /// Utility: Open download folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelFolderOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxDownloadFolder.Text))
            {
                System.Diagnostics.Process.Start(textBoxDownloadFolder.Text);
            }
        }

        /// <summary>
        /// Save setting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDownloadFolder_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxDownloadFolder.Text))
            {
                Properties.Settings.Default.lastDownloadFolder = textBoxDownloadFolder.Text;
                Properties.Settings.Default.Save();
            }
        }
        private void comboBoxWifiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.lastWifiType = comboBoxWifiType.SelectedIndex;
            Properties.Settings.Default.Save();
        }


        /// <summary>
        /// Exit from menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wifiSD != null)
            {
                wifiSD.stopDownloadService();
            }
            isDownloadRunning = false;
            wifiSD = null;
            this.Close();
        }

        /// <summary>
        /// Exit by close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (wifiSD != null)
            {
                wifiSD.stopDownloadService();
            }
            isDownloadRunning = false;
            wifiSD = null;
        }

        /// <summary>
        /// Watch Wifi SD card network exceptions.
        /// </summary>
        private void netWorkErrorWatchLoop()
        {
            Invoke(new delegate1(changeWifiNGVisibility), false);
            bool blinkState = false;
            while (wifiSD != null)
            {
                if (wifiSD.hasNetworkError)
                {
                    blinkState = !blinkState;
                    Invoke(new delegate1(changeWifiNGVisibility), blinkState);
                }
                else
                {
                    Invoke(new delegate1(changeWifiNGVisibility), false);
                }

                Thread.Sleep(250);
            }
            Invoke(new delegate1(changeWifiNGVisibility), false);
        }

        /// <summary>
        /// update display for latest downloaded filename and time
        /// </summary>
        /// <param name="info"></param>
        public void updateDownloadedFileInfo(string info)
        {
            Invoke(new delegate0(updateDownloadStatus), info);
        }
        delegate void delegate0(string text);
        delegate void delegate1(bool visibility);
        internal void updateDownloadStatus(string text)
        {
            label_downloadedFileInfo.Text = DateTime.Now.ToString("HH:mm:ss") + " - " + Path.GetFileName(text);
        }
        internal void changeWifiNGVisibility(bool visible)
        {
            pictureBoxWifiNG.Visible = visible;
        }

    }
}
