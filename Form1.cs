using System.Diagnostics;
using System.Windows.Forms;

namespace BigPictureSplashChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /*�����Ǵ����ʼ��������,����Steam·���ļ������Եļ��Ͷ�·�����ݵĶ�ȡ*/
        private void Form1_Load(object sender, EventArgs e)
        {
            /*��Steam·���ļ������Եļ��Ͷ�·�����ݵĶ�ȡ*/
            if (Directory.Exists("c:\\Users\\Public\\BPSC_stat") == false || File.Exists("c:\\Users\\Public\\BPSC_stat\\dir.ini") == false)
            {
                Directory.CreateDirectory("c:\\Users\\Public\\BPSC_stat");
                File.Create("c:\\Users\\Public\\BPSC_stat\\dir.ini").Close();
                
                String steamdir = new string(File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini").ToString());
                if (steamdir.Length == 0)
                {
                    MessageBox.Show("�ڵ����Ĵ��������� Steam/steamui/movies ·��������!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    notifyIcon1.Visible= false;
                    this.Show();
                }
            }
            else
            {
                String steamdir2 = new string(File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini").ToString());
                if (steamdir2.Length == 0)
                {
                    MessageBox.Show("�ڵ����Ĵ��������� Steam/steamui/movies ·��������!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    notifyIcon1.Visible= false;
                    this.Show();
                }
                else
                {
                    if(File.Exists(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm") == false)
                    {
                        MessageBox.Show("�Ҳ�����Ƶ�ļ���\n���ڱ�Ӧ��Ŀ¼�����splash.webm��","����",MessageBoxButtons.OK,MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        notifyIcon1.Visible= false;
                        this.Show();
                    }
                    else
                    {
                        this.ShowInTaskbar = false;
                        notifyIcon1.Visible = true;
                        string asdir = new string(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm");
                        File.Copy(asdir, @steamdir2+@"\steamui\movies\bigpicture_startup.webm".ToString(),overwrite:true);
                        this.notifyIcon1.ShowBalloonTip(1000, "���", "�޸���ɡ���Steam�в鿴���ġ�Ӧ������С��������", ToolTipIcon.Info);
                        this.Hide();
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
            if ( textBox1.Text == "")
            {
                MessageBox.Show("�����Steam·����","����",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
            }
            else if (File.Exists(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm") == false)
            {
                MessageBox.Show("�Ҳ�����Ƶ�ļ���\n���ڱ�Ӧ��Ŀ¼�����splash.webm��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                File.WriteAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini", @textBox1.Text.ToString());

                File.Copy(asdir2, @File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini") + @"\steamui\movies\bigpicture_startup.webm".ToString(),overwrite:true );
                MessageBox.Show("�޸ĳɹ����뵽SteamӦ����鿴�����Ƿ�����","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);

            }//��֤Textbox1�е��ļ��о���·����������Ӧ�ø�Ŀ¼���splash��Ƶ����һ�ݵ� .../Steam/steamui/movies/
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "��Ӧ�û���.Net Framework 6.x ������\n���� Tamarind����������Ȩ����\n\nCopyright (c) 2023 Tamarind All rights reserved.",  "����", 
                MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1
                );
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exex = MessageBox.Show(
                "�˳�Ӧ�õ��ȷ����\n��С��Ӧ�õ����̵����\n��������ȡ����ť��","�˳���",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,MessageBoxDefaultButton.Button3
                );
            if( exex == DialogResult.Yes ) 
            {
                notifyIcon1.Visible = false;
                System.Environment.Exit(0);
            }
            else if( exex == DialogResult.No )
            {
                e.Cancel = true;
                notifyIcon1.Visible = true;
                this.Visible= false;
                this.ShowInTaskbar = false;
                this.notifyIcon1.ShowBalloonTip(1000, "��ע��", "Ӧ������С�������̡�", ToolTipIcon.Info);
            }
            else if( exex == DialogResult.Cancel)
            {
                e.Cancel = true;
                this.Visible = true;
                this.BringToFront();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
                this.ShowInTaskbar=false;
                notifyIcon1.Visible = true;
            }
            else
            {
                this.Show();
                this.BringToFront();
                this.ShowInTaskbar= true;
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
            String steamdir000 = new string(File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini").ToString());
            this.notifyIcon1.ShowBalloonTip(2000, "ע��", "����ܵ��Եȸ����������Steam�Ż�򿪣���Ϊ����ʾ��֤���ڣ�", ToolTipIcon.Info);
            System.Diagnostics.Process.Start(steamdir000+ @"\steam.exe" ,"-noverifyfiles -nobootstrapupdate -skipinitialbootstrap -norepairfiles -overridepackageurl");
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
            notifyIcon1.Visible= false;
            System.Environment.Exit(0);
        }

        private void toolQuickApplySplash_Click(object sender, EventArgs e)//��֪ͨ�����ϵ�һ���޸Ĳ˵���
        {
            String steamdir3 = new string(File.ReadAllText("c:\\Users\\Public\\BPSC_stat\\dir.ini").ToString());
            if (steamdir3.Length == 0)
            {
                MessageBox.Show("�ڵ����Ĵ��������� Steam/steamui/movies ·�������棡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (File.Exists(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm") == false)
                {
                    MessageBox.Show("�Ҳ�����Ƶ�ļ���\n���ڱ�Ӧ��Ŀ¼�����splash.webm��\n\n���Ҷ�˵���ˣ���һ�β��У���ô�붼���аɣ���", "���󣡣�", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    string asdir = new string(@System.AppDomain.CurrentDomain.BaseDirectory + "splash.webm");
                    File.Copy(asdir, @steamdir3 + @"\steamui\movies\bigpicture_startup.webm".ToString(),overwrite:true);
                    this.notifyIcon1.ShowBalloonTip(1000, "���", "�޸���ɡ���Steam�в鿴���ġ�", ToolTipIcon.Info);
                }

            }
        }
    }
}