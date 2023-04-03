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
        /*�����Ǵ����ʼ��������,����Steam·���ļ������Եļ��Ͷ�·�����ݵĶ�ȡ*/
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

            /*��Steam·���ļ������Եļ��Ͷ�·�����ݵĶ�ȡ*/
            if (Directory.Exists("c:\\Users\\Public\\BPSC_stat") == false || System.IO.File.Exists("c:\\Users\\Public\\BPSC_stat\\dir.ini") == false || System.IO.File.Exists("c:\\Users\\Public\\BPSC_stat\\config.ini") == false)
            {
                Directory.CreateDirectory("c:\\Users\\Public\\BPSC_stat");
                System.IO.File.Create("c:\\Users\\Public\\BPSC_stat\\dir.ini").Close();
                System.IO.File.Create("c:\\Users\\Public\\BPSC_stat\\config.ini").Close();
                String steamdir = new string(System.IO.File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini").ToString());
                if (steamdir.Length == 0)
                {
                    MessageBox.Show("�ڵ����Ĵ��������� Steam/steamui/movies ·��������!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                    MessageBox.Show("�ڵ����Ĵ��������� Steam/steamui/movies ·��������!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    notifyIcon1.Visible = false;
                    this.Show();
                    textBox1.Text = steamdir2.ToString();
                }
                else
                {
                    if (System.IO.File.Exists(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm") == false)
                    {
                        MessageBox.Show("�Ҳ�����Ƶ�ļ���\n���ڱ�Ӧ��Ŀ¼�����splash.webm��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                        this.notifyIcon1.ShowBalloonTip(1000, "���", "�޸���ɡ���Steam�в鿴���ġ�Ӧ������С��������", ToolTipIcon.Info);
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
        }//�˳�Ӧ�ð�ť

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
            }
        }//����ָ���ļ��в���ʾ��textbox�С�

        private void ButtonSaveDir_Click(object sender, EventArgs e)
        {
            string asdir2 = new string(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm");
            if (textBox1.Text == "")
            {
                MessageBox.Show("�����Steam·����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (System.IO.File.Exists(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm") == false)
            {
                MessageBox.Show("�Ҳ�����Ƶ�ļ���\n���ڱ�Ӧ��Ŀ¼�����splash.webm��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                System.IO.File.WriteAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini", @textBox1.Text.ToString());

                System.IO.File.Copy(asdir2, @System.IO.File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini") + @"\steamui\movies\bigpicture_startup.webm".ToString(), overwrite: true);
                MessageBox.Show("�޸ĳɹ����뵽SteamӦ����鿴�����Ƿ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }//��֤Textbox1�е��ļ��о���·����������Ӧ�ø�Ŀ¼���splash��Ƶ����һ�ݵ� .../Steam/steamui/movies/
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//����
                "��Ӧ�û���.Net Framework 6.x ������\n���� Tamarind����������Ȩ����\n\nCopyright (c) 2023 Tamarind All rights reserved.", "����",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                );
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {//����رհ�ť��Ķ���ȷ�϶Ի���
            DialogResult exex = MessageBox.Show(
                "�˳�Ӧ�õ��ȷ����\n��С��Ӧ�õ����̵����\n��������ȡ����ť��", "�˳���",
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
                this.notifyIcon1.ShowBalloonTip(1000, "��ע��", "Ӧ������С�������̡�", ToolTipIcon.Info);
            }
            else if (exex == DialogResult.Cancel)
            {
                e.Cancel = true;
                this.Visible = true;
                this.BringToFront();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)//˫��notifyIcon��ʾ������form1
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

        private void menuItemShowApp_Click(object sender, EventArgs e)//��֪ͨ�����ϵĴ�������˵���
        {
            this.Show();
            this.BringToFront();
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void toolOpenSteam_Click(object sender, EventArgs e)//��֪ͨ�����ϵĴ�Steam�˵������������֤���ڡ�
        {
            String steamdir000 = new string(System.IO.File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini").ToString());
            this.notifyIcon1.ShowBalloonTip(2000, "ע��", "����ܵ��Եȸ����������Steam�Ż�򿪣���Ϊ����ʾ��֤���ڣ�", ToolTipIcon.Info);
            System.Diagnostics.Process.Start(steamdir000 + @"\steam.exe", "-noverifyfiles -nobootstrapupdate -skipinitialbootstrap -norepairfiles -overridepackageurl");
        }

        private void toolAbout_Click(object sender, EventArgs e)//��֪ͨ�����ϵĹ��ڲ˵���
        {
            MessageBox.Show(
               "��Ӧ�û���.Net Framework 6.x ������\n���� Tamarind����������Ȩ����\n\nCopyright (c) 2023 Tamarind All rights reserved.", "����",
               MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
               );
        }

        private void toolExit_Click(object sender, EventArgs e)//��֪ͨ�����ϵ�һ���˳��˵���
        {
            notifyIcon1.Visible = false;
            System.Environment.Exit(0);
        }

        private void toolQuickApplySplash_Click(object sender, EventArgs e)//��֪ͨ�����ϵ�һ���޸Ĳ˵���
        {
            String steamdir3 = new string(System.IO.File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini").ToString());
            if (steamdir3.Length == 0)
            {
                MessageBox.Show("�ڵ����Ĵ��������� Steam/steamui/movies ·�������棡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (System.IO.File.Exists(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm") == false)
                {
                    MessageBox.Show("�Ҳ�����Ƶ�ļ���\n���ڱ�Ӧ��Ŀ¼�����splash.webm��\n\n���Ҷ�˵���ˣ���һ�β��У���ô�붼���аɣ���", "���󣡣�", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    string asdir = new string(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm");
                    System.IO.File.Copy(asdir, @steamdir3 + @"\steamui\movies\bigpicture_startup.webm".ToString(), overwrite: true);
                    this.notifyIcon1.ShowBalloonTip(1000, "���", "�޸���ɡ���Steam�в鿴���ġ�", ToolTipIcon.Info);
                }

            }
        }

        private void checkWakeOnBoot_CheckedChanged(object sender, EventArgs e)
        {//���checkbox��������ɾ�����������µĿ�ݷ�ʽ��
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
                shortcut.Description = "����BPSC";
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
            if(checkAutoStartApp.Checked == true)//�޸�config.ini������Sapp��Ӧ��������
            {
                System.IO.File.WriteAllText("c:\\Users\\Public\\BPSC_stat\\config.ini", "autoStart == 1");
                //checkAutoStartApp.Checked = true;
                //checkAutoStartApp.CheckState = CheckState.Checked;����ר��
            }
            else
            {
                System.IO.File.WriteAllText("c:\\Users\\Public\\BPSC_stat\\config.ini", "autoStart == 0");
                //checkAutoStartApp.Checked = false;
                //checkAutoStartApp.CheckState = CheckState.Unchecked;����ר��
            }
        }
    }
}