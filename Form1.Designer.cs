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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new TextBox();
            ButtonFind = new Button();
            ButtonSaveDir = new Button();
            label1 = new Label();
            BtnExit = new Button();
            BtnAbout = new Button();
            notifyIcon1 = new NotifyIcon(components);
            contNotibar = new ContextMenuStrip(components);
            toolQuickApplySplash = new ToolStripMenuItem();
            menuItemShowApp = new ToolStripMenuItem();
            toolOpenSteam = new ToolStripMenuItem();
            toolAbout = new ToolStripMenuItem();
            toolExit = new ToolStripMenuItem();
            buttonStartSteam = new Button();
            checkWakeOnBoot = new CheckBox();
            checkAutoStartApp = new CheckBox();
            contNotibar.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 52);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(448, 23);
            textBox1.TabIndex = 0;
            // 
            // ButtonFind
            // 
            ButtonFind.Location = new Point(466, 52);
            ButtonFind.Name = "ButtonFind";
            ButtonFind.Size = new Size(44, 26);
            ButtonFind.TabIndex = 1;
            ButtonFind.Text = "查找";
            ButtonFind.UseVisualStyleBackColor = true;
            ButtonFind.Click += ButtonFind_Click;
            // 
            // ButtonSaveDir
            // 
            ButtonSaveDir.Location = new Point(12, 96);
            ButtonSaveDir.Name = "ButtonSaveDir";
            ButtonSaveDir.Size = new Size(498, 59);
            ButtonSaveDir.TabIndex = 2;
            ButtonSaveDir.Text = "点击这里保存路径（到 C:\\users\\public\\BPSC_stat）\r\n并修改大屏幕启动动画（ 在本应用根目录的splash.webm文件 ）";
            ButtonSaveDir.UseVisualStyleBackColor = true;
            ButtonSaveDir.Click += ButtonSaveDir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(320, 17);
            label1.TabIndex = 3;
            label1.Text = "Steam安装文件夹根路径（不要给错路径，给错就是灾难）";
            // 
            // BtnExit
            // 
            BtnExit.Location = new Point(370, 195);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(142, 26);
            BtnExit.TabIndex = 4;
            BtnExit.Text = "点击这里彻底退出应用";
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click;
            // 
            // BtnAbout
            // 
            BtnAbout.Location = new Point(370, 162);
            BtnAbout.Name = "BtnAbout";
            BtnAbout.Size = new Size(142, 26);
            BtnAbout.TabIndex = 5;
            BtnAbout.Text = "关于此应用";
            BtnAbout.UseVisualStyleBackColor = true;
            BtnAbout.Click += BtnAbout_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contNotibar;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "BPSC\r\nEdit the bigpicture boot screen";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            // 
            // contNotibar
            // 
            contNotibar.Items.AddRange(new ToolStripItem[] { toolQuickApplySplash, menuItemShowApp, toolOpenSteam, toolAbout, toolExit });
            contNotibar.Name = "contNotibar";
            contNotibar.Size = new Size(329, 114);
            // 
            // toolQuickApplySplash
            // 
            toolQuickApplySplash.Name = "toolQuickApplySplash";
            toolQuickApplySplash.Size = new Size(328, 22);
            toolQuickApplySplash.Text = "一键修改大屏幕动画（第一次！不行！哒咩！）";
            toolQuickApplySplash.Click += toolQuickApplySplash_Click;
            // 
            // menuItemShowApp
            // 
            menuItemShowApp.Name = "menuItemShowApp";
            menuItemShowApp.Size = new Size(328, 22);
            menuItemShowApp.Text = "显示应用主界面";
            menuItemShowApp.Click += menuItemShowApp_Click;
            // 
            // toolOpenSteam
            // 
            toolOpenSteam.Name = "toolOpenSteam";
            toolOpenSteam.Size = new Size(328, 22);
            toolOpenSteam.Text = "打开Steam（跳过更新）";
            toolOpenSteam.Click += toolOpenSteam_Click;
            // 
            // toolAbout
            // 
            toolAbout.Name = "toolAbout";
            toolAbout.Size = new Size(328, 22);
            toolAbout.Text = "关于此应用";
            toolAbout.Click += toolAbout_Click;
            // 
            // toolExit
            // 
            toolExit.Name = "toolExit";
            toolExit.Size = new Size(328, 22);
            toolExit.Text = "退出";
            toolExit.Click += toolExit_Click;
            // 
            // buttonStartSteam
            // 
            buttonStartSteam.Location = new Point(12, 162);
            buttonStartSteam.Name = "buttonStartSteam";
            buttonStartSteam.Size = new Size(352, 59);
            buttonStartSteam.TabIndex = 6;
            buttonStartSteam.Text = "点击这里启动Steam（跳过更新验证）";
            buttonStartSteam.UseVisualStyleBackColor = true;
            // 
            // checkWakeOnBoot
            // 
            checkWakeOnBoot.AutoSize = true;
            checkWakeOnBoot.Location = new Point(224, 240);
            checkWakeOnBoot.Name = "checkWakeOnBoot";
            checkWakeOnBoot.Size = new Size(87, 21);
            checkWakeOnBoot.TabIndex = 7;
            checkWakeOnBoot.Text = "开机自启动";
            checkWakeOnBoot.UseVisualStyleBackColor = true;
            checkWakeOnBoot.CheckedChanged += checkWakeOnBoot_CheckedChanged;
            // 
            // checkAutoStartApp
            // 
            checkAutoStartApp.AutoSize = true;
            checkAutoStartApp.Location = new Point(339, 240);
            checkAutoStartApp.Name = "checkAutoStartApp";
            checkAutoStartApp.Size = new Size(171, 21);
            checkAutoStartApp.TabIndex = 8;
            checkAutoStartApp.Text = "打开应用时自动启动Steam";
            checkAutoStartApp.UseVisualStyleBackColor = true;
            checkAutoStartApp.CheckedChanged += checkAutoStartApp_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 268);
            Controls.Add(checkAutoStartApp);
            Controls.Add(checkWakeOnBoot);
            Controls.Add(buttonStartSteam);
            Controls.Add(BtnAbout);
            Controls.Add(BtnExit);
            Controls.Add(label1);
            Controls.Add(ButtonSaveDir);
            Controls.Add(ButtonFind);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Big Picture Changer";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            contNotibar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private CheckBox checkWakeOnBoot;
        private CheckBox checkAutoStartApp;
    }
}