
namespace wifiSdWatch
{
    partial class wifiSdWatchMainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wifiSdWatchMainForm));
            this.buttonDownload = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox_moving_0 = new System.Windows.Forms.PictureBox();
            this.pictureBoxStill_0 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBoxWifi = new System.Windows.Forms.PictureBox();
            this.label_downloadedFileInfo = new System.Windows.Forms.Label();
            this.textBoxDownloadFolder = new System.Windows.Forms.TextBox();
            this.buttonFolderDlg = new System.Windows.Forms.Button();
            this.pictureBoxWifiNG = new System.Windows.Forms.PictureBox();
            this.comboBoxWifiType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFolderOpen = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_moving_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStill_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWifi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWifiNG)).BeginInit();
            this.panelFolderOpen.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDownload
            // 
            this.buttonDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDownload.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonDownload.Location = new System.Drawing.Point(239, 245);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(78, 30);
            this.buttonDownload.TabIndex = 4;
            this.buttonDownload.Text = "START";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.button_StartWatch_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(68)))));
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(371, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 27);
            this.label6.TabIndex = 26;
            this.label6.Text = "Folder Monitor";
            // 
            // pictureBox_moving_0
            // 
            this.pictureBox_moving_0.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_moving_0.Image")));
            this.pictureBox_moving_0.Location = new System.Drawing.Point(239, 146);
            this.pictureBox_moving_0.Name = "pictureBox_moving_0";
            this.pictureBox_moving_0.Size = new System.Drawing.Size(78, 78);
            this.pictureBox_moving_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_moving_0.TabIndex = 30;
            this.pictureBox_moving_0.TabStop = false;
            this.pictureBox_moving_0.Visible = false;
            // 
            // pictureBoxStill_0
            // 
            this.pictureBoxStill_0.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxStill_0.Image")));
            this.pictureBoxStill_0.Location = new System.Drawing.Point(239, 146);
            this.pictureBoxStill_0.Name = "pictureBoxStill_0";
            this.pictureBoxStill_0.Size = new System.Drawing.Size(78, 78);
            this.pictureBoxStill_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStill_0.TabIndex = 29;
            this.pictureBoxStill_0.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.InitialImage")));
            this.pictureBox5.Location = new System.Drawing.Point(339, 71);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(280, 228);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 23;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBoxWifi
            // 
            this.pictureBoxWifi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxWifi.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWifi.Image")));
            this.pictureBoxWifi.Location = new System.Drawing.Point(37, 71);
            this.pictureBoxWifi.Name = "pictureBoxWifi";
            this.pictureBoxWifi.Size = new System.Drawing.Size(180, 228);
            this.pictureBoxWifi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWifi.TabIndex = 20;
            this.pictureBoxWifi.TabStop = false;
            // 
            // label_downloadedFileInfo
            // 
            this.label_downloadedFileInfo.AutoSize = true;
            this.label_downloadedFileInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(68)))));
            this.label_downloadedFileInfo.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_downloadedFileInfo.Location = new System.Drawing.Point(352, 225);
            this.label_downloadedFileInfo.Name = "label_downloadedFileInfo";
            this.label_downloadedFileInfo.Size = new System.Drawing.Size(112, 16);
            this.label_downloadedFileInfo.TabIndex = 33;
            this.label_downloadedFileInfo.Text = "ABC12345.JPG";
            // 
            // textBoxDownloadFolder
            // 
            this.textBoxDownloadFolder.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxDownloadFolder.Location = new System.Drawing.Point(349, 249);
            this.textBoxDownloadFolder.Name = "textBoxDownloadFolder";
            this.textBoxDownloadFolder.Size = new System.Drawing.Size(228, 23);
            this.textBoxDownloadFolder.TabIndex = 34;
            this.textBoxDownloadFolder.TextChanged += new System.EventHandler(this.textBoxDownloadFolder_TextChanged);
            // 
            // buttonFolderDlg
            // 
            this.buttonFolderDlg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFolderDlg.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFolderDlg.Location = new System.Drawing.Point(580, 249);
            this.buttonFolderDlg.Name = "buttonFolderDlg";
            this.buttonFolderDlg.Size = new System.Drawing.Size(30, 23);
            this.buttonFolderDlg.TabIndex = 35;
            this.buttonFolderDlg.Text = "...";
            this.buttonFolderDlg.UseVisualStyleBackColor = true;
            this.buttonFolderDlg.Click += new System.EventHandler(this.buttonFolderDlg_Click);
            // 
            // pictureBoxWifiNG
            // 
            this.pictureBoxWifiNG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxWifiNG.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWifiNG.Image")));
            this.pictureBoxWifiNG.Location = new System.Drawing.Point(37, 71);
            this.pictureBoxWifiNG.Name = "pictureBoxWifiNG";
            this.pictureBoxWifiNG.Size = new System.Drawing.Size(180, 228);
            this.pictureBoxWifiNG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWifiNG.TabIndex = 36;
            this.pictureBoxWifiNG.TabStop = false;
            this.pictureBoxWifiNG.Visible = false;
            // 
            // comboBoxWifiType
            // 
            this.comboBoxWifiType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(85)))), ((int)(((byte)(151)))));
            this.comboBoxWifiType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxWifiType.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxWifiType.ForeColor = System.Drawing.Color.White;
            this.comboBoxWifiType.FormattingEnabled = true;
            this.comboBoxWifiType.Items.AddRange(new object[] {
            "ezSh@re",
            "FlashAir"});
            this.comboBoxWifiType.Location = new System.Drawing.Point(88, 261);
            this.comboBoxWifiType.Name = "comboBoxWifiType";
            this.comboBoxWifiType.Size = new System.Drawing.Size(90, 24);
            this.comboBoxWifiType.TabIndex = 37;
            this.comboBoxWifiType.Text = "ezSh@re";
            this.comboBoxWifiType.SelectedIndexChanged += new System.EventHandler(this.comboBoxWifiType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(68)))));
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(371, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 27);
            this.label1.TabIndex = 38;
            this.label1.Text = "Virtual Camera";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = " Open ";
            this.label2.Click += new System.EventHandler(this.panelFolderOpen_Click);
            // 
            // panelFolderOpen
            // 
            this.panelFolderOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.panelFolderOpen.Controls.Add(this.label2);
            this.panelFolderOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelFolderOpen.Location = new System.Drawing.Point(354, 74);
            this.panelFolderOpen.Name = "panelFolderOpen";
            this.panelFolderOpen.Size = new System.Drawing.Size(81, 40);
            this.panelFolderOpen.TabIndex = 40;
            this.panelFolderOpen.Click += new System.EventHandler(this.panelFolderOpen_Click);
            // 
            // wifiSdWatchMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(661, 340);
            this.Controls.Add(this.panelFolderOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxWifiType);
            this.Controls.Add(this.pictureBoxWifiNG);
            this.Controls.Add(this.buttonFolderDlg);
            this.Controls.Add(this.textBoxDownloadFolder);
            this.Controls.Add(this.pictureBoxStill_0);
            this.Controls.Add(this.label_downloadedFileInfo);
            this.Controls.Add(this.pictureBox_moving_0);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBoxWifi);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "wifiSdWatchMainForm";
            this.Text = "wifi SD Watch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_moving_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStill_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWifi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWifiNG)).EndInit();
            this.panelFolderOpen.ResumeLayout(false);
            this.panelFolderOpen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxWifi;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBoxStill_0;
        private System.Windows.Forms.PictureBox pictureBox_moving_0;
        private System.Windows.Forms.Label label_downloadedFileInfo;
        private System.Windows.Forms.TextBox textBoxDownloadFolder;
        private System.Windows.Forms.Button buttonFolderDlg;
        private System.Windows.Forms.PictureBox pictureBoxWifiNG;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxWifiType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelFolderOpen;
    }
}

