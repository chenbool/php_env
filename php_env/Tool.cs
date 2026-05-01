/*
 * 创建工具: SharpDevelop
 * 作者: Administrator
 * 日期: 2017/11/4
 * 时间: 23:40
 */
using System;
using System.Diagnostics;

namespace app
{
    /// <summary>
    /// 工具类
    /// 提供进程管理、命令执行等辅助功能
    /// </summary>
    public class Tool
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Tool()
        {
        }

        /// <summary>
        /// 运行 CMD 命令
        /// 启动指定的可执行文件并传递命令行参数
        /// </summary>
        /// <param name="wwwPath">应用根目录路径</param>
        /// <param name="cmdExe">可执行文件名</param>
        /// <param name="cmdStr">命令行参数</param>
        /// <returns>是否成功启动</returns>
        public static bool RunCmd(string wwwPath,string cmdExe, string cmdStr)
        {
            bool result = false;
            try
            {
                using (Process myPro = new Process())
                {
                    ProcessStartInfo psi = new ProcessStartInfo(wwwPath+cmdExe,cmdStr);
                    myPro.StartInfo = psi;
                    myPro.StartInfo.UseShellExecute = false;
                    myPro.StartInfo.RedirectStandardError = true;
                    myPro.StartInfo.CreateNoWindow = true;
                    myPro.Start();
                    myPro.Close();
                    result = true;
                }
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        /// 关闭指定名称的进程
        /// 根据进程名查找并终止匹配的进程
        /// </summary>
        /// <param name="processName">进程名 (支持模糊匹配)</param>
        public static void KillProcess(string processName)
        {
            Process[] myproc = Process.GetProcesses();
            foreach (Process item in myproc)
            {
                if (item.ProcessName.Contains(processName))
                {
                    item.Kill();
                }
            }
        }
    }
}
