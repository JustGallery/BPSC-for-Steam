using System.Diagnostics;
using System.Security.Principal;

namespace BigPictureSplashChanger
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //��õ�ǰ��¼��Windows�û���ʾ
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            //�жϵ�ǰ��¼�û��Ƿ�Ϊ����Ա
            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                //����ǹ���Ա����ֱ������
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
            else
            {
                //������������
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;
                //������������,ȷ���Թ���Ա�������
                startInfo.Verb = "runas";
                try
                {
                    Process.Start(startInfo);
                }
                catch
                {
                    return;
                }
                //�˳�
                Application.Exit();
            }
        }
    }
}