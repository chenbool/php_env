/*
 * 创建工具: SharpDevelop
 * 作者: Administrator
 * 日期: 2017/11/3
 * 时间: 1:34
 */
using System;
using System.Windows.Forms;

namespace app
{
    /// <summary>
    /// 程序入口类
    /// 应用程序启动入口点
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// 程序入口点
        /// 初始化 Windows 窗体应用程序
        /// </summary>
        /// <param name="args">命令行参数</param>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
