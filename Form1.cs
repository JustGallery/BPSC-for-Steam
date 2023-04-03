using System;
using System.Diagnostics;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BigPictureSplashChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string appdir = new string(@System.AppDomain.CurrentDomain.BaseDirectory);
        /*下面是窗格初始化的内容,包括Steam路径文件存在性的检测和对路径内容的读取*/
        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\BPSC.lnk") == true)
            {
                this.checkWakeOnBoot.Checked = true;
                checkWakeOnBoot.CheckState = CheckState.Checked;
            }
            else
            {
                checkWakeOnBoot.Checked = false;
                checkWakeOnBoot.CheckState = CheckState.Unchecked;
            }

            /*对Steam路径文件存在性的检测和对路径内容的读取*/
            if (Directory.Exists("c:\\Users\\Public\\BPSC_stat") == false || System.IO.File.Exists("c:\\Users\\Public\\BPSC_stat\\dir.ini") == false || System.IO.File.Exists("c:\\Users\\Public\\BPSC_stat\\config.ini") == false)
            {
                Directory.CreateDirectory("c:\\Users\\Public\\BPSC_stat");
                System.IO.File.Create("c:\\Users\\Public\\BPSC_stat\\dir.ini").Close();
                System.IO.File.Create("c:\\Users\\Public\\BPSC_stat\\config.ini").Close();
                String steamdir = new string(System.IO.File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini").ToString());
                if (steamdir.Length == 0)
                {
                    MessageBox.Show("在弹出的窗口中输入 Steam/steamui/movies 路径并保存!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    notifyIcon1.Visible = false;
                    this.Show();
                    textBox1.Text = steamdir.ToString();
                }
            }
            else
            {
                String steamdir2 = new string(System.IO.File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini").ToString());
                if (steamdir2.Length == 0)
                {
                    MessageBox.Show("在弹出的窗口中输入 Steam/steamui/movies 路径并保存!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    notifyIcon1.Visible = false;
                    this.Show();
                    textBox1.Text = steamdir2.ToString();
                }
                else
                {
                    if (System.IO.File.Exists(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm") == false)
                    {
                        MessageBox.Show("找不到视频文件。\n请在本应用目录下添加splash.webm！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        notifyIcon1.Visible = false;
                        this.Show();
                        textBox1.Text = steamdir2.ToString();
                    }
                    else
                    {
                        this.ShowInTaskbar = false;
                        notifyIcon1.Visible = true;
                        string asdir = new string(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm");
                        System.IO.File.Copy(asdir, @steamdir2 + @"\steamui\movies\bigpicture_startup.webm".ToString(), overwrite: true);
                        this.notifyIcon1.ShowBalloonTip(1000, "完成", "修改完成。到Steam中查看更改。应用已最小化到托盘", ToolTipIcon.Info);
                        textBox1.Text = steamdir2.ToString();
                        if (System.IO.File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\config.ini") == "autoStart == 1")
                        {
                            System.Diagnostics.Process.Start(steamdir2 + @"\steam.exe", "-noverifyfiles -nobootstrapupdate -skipinitialbootstrap -norepairfiles -overridepackageurl");
                            this.Hide();
                        }
                        else
                        {
                            this.Hide();
                        }
                        
                    }

                }

            }



        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }//退出应用按钮

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
            }
        }//查找指定文件夹并显示到textbox中。

        private void ButtonSaveDir_Click(object sender, EventArgs e)
        {
            string asdir2 = new string(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm");
            if (textBox1.Text == "")
            {
                MessageBox.Show("需给定Steam路径！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (System.IO.File.Exists(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm") == false)
            {
                MessageBox.Show("找不到视频文件。\n请在本应用目录下添加splash.webm！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                System.IO.File.WriteAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini", @textBox1.Text.ToString());

                System.IO.File.Copy(asdir2, @System.IO.File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini") + @"\steamui\movies\bigpicture_startup.webm".ToString(), overwrite: true);
                MessageBox.Show("修改成功，请到Steam应用里查看动画是否变更。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }//验证Textbox1中的文件夹绝对路径，将放在应用根目录里的splash视频复制一份到 .../Steam/steamui/movies/
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//关于
                "该应用基于.Net Framework 6.x 构建。\n作者 Tamarind，保留所有权利。\n\nCopyright (c) 2023 Tamarind All rights reserved.", "关于",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                );
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {//点击关闭按钮后的二次确认对话框
            DialogResult exex = MessageBox.Show(
                "退出应用点击确定，\n最小化应用到托盘点击否，\n否则请点击取消按钮。", "退出？",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3
                );
            if (exex == DialogResult.Yes)
            {
                notifyIcon1.Visible = false;
                System.Environment.Exit(0);
            }
            else if (exex == DialogResult.No)
            {
                e.Cancel = true;
                notifyIcon1.Visible = true;
                this.Visible = false;
                this.ShowInTaskbar = false;
                this.notifyIcon1.ShowBalloonTip(1000, "请注意", "应用已最小化到托盘。", ToolTipIcon.Info);
            }
            else if (exex == DialogResult.Cancel)
            {
                e.Cancel = true;
                this.Visible = true;
                this.BringToFront();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)//双击notifyIcon显示或隐藏form1
        {
            if (this.Visible)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
            else
            {
                this.Show();
                this.BringToFront();
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void menuItemShowApp_Click(object sender, EventArgs e)//在通知托盘上的打开主界面菜单项
        {
            this.Show();
            this.BringToFront();
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void toolOpenSteam_Click(object sender, EventArgs e)//在通知托盘上的打开Steam菜单项，跳过更新验证窗口。
        {
            String steamdir000 = new string(System.IO.File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini").ToString());
            this.notifyIcon1.ShowBalloonTip(2000, "注意", "你可能得稍等个半分钟左右Steam才会打开（因为不显示验证窗口）", ToolTipIcon.Info);
            System.Diagnostics.Process.Start(steamdir000 + @"\steam.exe", "-noverifyfiles -nobootstrapupdate -skipinitialbootstrap -norepairfiles -overridepackageurl");
        }

        private void toolAbout_Click(object sender, EventArgs e)//在通知托盘上的关于菜单项
        {
            MessageBox.Show(
               "该应用基于.Net Framework 6.x 构建。\n作者 Tamarind，保留所有权利。\n\nCopyright (c) 2023 Tamarind All rights reserved.", "关于",
               MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
               );
        }

        private void toolExit_Click(object sender, EventArgs e)//在通知托盘上的一键退出菜单项
        {
            notifyIcon1.Visible = false;
            System.Environment.Exit(0);
        }

        private void toolQuickApplySplash_Click(object sender, EventArgs e)//在通知托盘上的一键修改菜单项
        {
            String steamdir3 = new string(System.IO.File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini").ToString());
            if (steamdir3.Length == 0)
            {
                MessageBox.Show("在弹出的窗口中输入 Steam/steamui/movies 路径并保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (System.IO.File.Exists(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm") == false)
                {
                    MessageBox.Show("找不到视频文件。\n请在本应用目录下添加splash.webm！\n\n（我都说过了！第一次不行！怎么想都不行吧！）", "错误！！", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    string asdir = new string(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm");
                    System.IO.File.Copy(asdir, @steamdir3 + @"\steamui\movies\bigpicture_startup.webm".ToString(), overwrite: true);
                    this.notifyIcon1.ShowBalloonTip(1000, "完成", "修改完成。到Steam中查看更改。", ToolTipIcon.Info);
                }

            }
        }

        private void checkWakeOnBoot_CheckedChanged(object sender, EventArgs e)
        {//点击checkbox，创建或删除“启动”下的快捷方式；
            if (checkWakeOnBoot.Checked == true && System.IO.File.Exists(Environment.SpecialFolder.CommonStartup + "\\" + "BPSC.lnk".ToString()) == false)
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(
                            Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup) +
                            "\\" + "BPSC.lnk".ToString()
                            );
                shortcut.TargetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                shortcut.WorkingDirectory = System.Environment.CurrentDirectory;
                shortcut.WindowStyle = 1;
                shortcut.Description = "启动BPSC";
                shortcut.IconLocation = System.Environment.CurrentDirectory + "\\" + "BigPictureSplashChanger.exe";
                shortcut.Save();
            }
            else
            {
                System.IO.File.Delete(@"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\StartUp\\BPSC.lnk");
            }
        }

        private void checkAutoStartApp_CheckedChanged(object sender, EventArgs e)
        {
            if(checkAutoStartApp.Checked == true)//修改config.ini参数（Sapp随应用启动）
            {
                System.IO.File.WriteAllText("c:\\Users\\Public\\BPSC_stat\\config.ini", "autoStart == 1");
                //checkAutoStartApp.Checked = true;
                //checkAutoStartApp.CheckState = CheckState.Checked;卡死专用
            }
            else
            {
                System.IO.File.WriteAllText("c:\\Users\\Public\\BPSC_stat\\config.ini", "autoStart == 0");
                //checkAutoStartApp.Checked = false;
                //checkAutoStartApp.CheckState = CheckState.Unchecked;卡死专用
            }
        }
    }
}