namespace BigPictureSplashChanger
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ButtonFind = new System.Windows.Forms.Button();
            this.ButtonSaveDir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contNotibar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolQuickApplySplash = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOpenSteam = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolExit = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStartSteam = new System.Windows.Forms.Button();
            this.contNotibar.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(448, 23);
            this.textBox1.TabIndex = 0;
            // 
            // ButtonFind
            // 
            this.ButtonFind.Location = new System.Drawing.Point(466, 46);
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(44, 23);
            this.ButtonFind.TabIndex = 1;
            this.ButtonFind.Text = "查找";
            this.ButtonFind.UseVisualStyleBackColor = true;
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // ButtonSaveDir
            // 
            this.ButtonSaveDir.Location = new System.Drawing.Point(12, 85);
            this.ButtonSaveDir.Name = "ButtonSaveDir";
            this.ButtonSaveDir.Size = new System.Drawing.Size(498, 52);
            this.ButtonSaveDir.TabIndex = 2;
            this.ButtonSaveDir.Text = "点击这里保存路径（到 C:\\users\\public\\BPSC_stat）\r\n并修改大屏幕启动动画（ 在本应用根目录的splash.webm文件 ）";
            this.ButtonSaveDir.UseVisualStyleBackColor = true;
            this.ButtonSaveDir.Click += new System.EventHandler(this.ButtonSaveDir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Steam安装文件夹根路径（不要给错路径，给错就是灾难）";
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(370, 172);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(142, 23);
            this.BtnExit.TabIndex = 4;
            this.BtnExit.Text = "点击这里彻底退出应用";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.Location = new System.Drawing.Point(370, 143);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(142, 23);
            this.BtnAbout.TabIndex = 5;
            this.BtnAbout.Text = "关于此应用";
            this.BtnAbout.UseVisualStyleBackColor = true;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contNotibar;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contNotibar
            // 
            this.contNotibar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolQuickApplySplash,
            this.menuItemShowApp,
            this.toolOpenSteam,
            this.toolAbout,
            this.toolExit});
            this.contNotibar.Name = "contNotibar";
            this.contNotibar.Size = new System.Drawing.Size(327, 114);
            // 
            // toolQuickApplySplash
            // 
            this.toolQuickApplySplash.Name = "toolQuickApplySplash";
            this.toolQuickApplySplash.Size = new System.Drawing.Size(326, 22);
            this.toolQuickApplySplash.Text = "一键修改大屏幕动画（第一次！不行！哒咩！）";
            this.toolQuickApplySplash.Click += new System.EventHandler(this.toolQuickApplySplash_Click);
            // 
            // menuItemShowApp
            // 
            this.menuItemShowApp.Name = "menuItemShowApp";
            this.menuItemShowApp.Size = new System.Drawing.Size(326, 22);
            this.menuItemShowApp.Text = "显示应用主界面";
            this.menuItemShowApp.Click += new System.EventHandler(this.menuItemShowApp_Click);
            // 
            // toolOpenSteam
            // 
            this.toolOpenSteam.Name = "toolOpenSteam";
            this.toolOpenSteam.Size = new System.Drawing.Size(326, 22);
            this.toolOpenSteam.Text = "打开Steam（跳过更新）";
            this.toolOpenSteam.Click += new System.EventHandler(this.toolOpenSteam_Click);
            // 
            // toolAbout
            // 
            this.toolAbout.Name = "toolAbout";
            this.toolAbout.Size = new System.Drawing.Size(326, 22);
            this.toolAbout.Text = "关于此应用";
            this.toolAbout.Click += new System.EventHandler(this.toolAbout_Click);
            // 
            // toolExit
            // 
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(326, 22);
            this.toolExit.Text = "退出";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // buttonStartSteam
            // 
            this.buttonStartSteam.Location = new System.Drawing.Point(12, 143);
            this.buttonStartSteam.Name = "buttonStartSteam";
            this.buttonStartSteam.Size = new System.Drawing.Size(352, 52);
            this.buttonStartSteam.TabIndex = 6;
            this.buttonStartSteam.Text = "点击这里启动Steam（跳过更新验证）";
            this.buttonStartSteam.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 213);
            this.Controls.Add(this.buttonStartSteam);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonSaveDir);
            this.Controls.Add(this.ButtonFind);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Big Picture Changer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contNotibar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button ButtonFind;
        private Button ButtonSaveDir;
        private Label label1;
        private Button BtnExit;
        private Button BtnAbout;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contNotibar;
        private ToolStripMenuItem menuItemShowApp;
        private ToolStripMenuItem toolOpenSteam;
        private ToolStripMenuItem toolAbout;
        private ToolStripMenuItem toolExit;
        private ToolStripMenuItem toolQuickApplySplash;
        private Button buttonStartSteam;
    }
}