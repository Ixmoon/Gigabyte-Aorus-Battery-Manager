using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BatteryChargeControlUI
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // 如果程序没有管理员权限，则以管理员身份重新启动
            if (!IsRunningAsAdministrator())
            {
                RestartAsAdministrator(args);
                return;
            }
            // 检查是否是通过命令行参数启动后台任务
            bool runInBackground = args.Length > 0 && args[0] == "background";

            if (runInBackground)
            {
                PowerLimit powerLimit = new PowerLimit();
                powerLimit.LoadSettingsFromJson();
                Application.Exit(); 
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new PowerLimit());
            }

        }

        // 检查当前进程是否以管理员身份运行
        static bool IsRunningAsAdministrator()
        {
            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        // 以管理员身份重新启动程序
        static void RestartAsAdministrator(string[] args)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = Application.ExecutablePath,
                Verb = "runas",  // 这个命令会请求管理员权限
                Arguments = string.Join(" ", args)  // 将命令行参数传递给新的进程
            };
            Process.Start(startInfo);
            Application.Exit();
        }
    }
}
