/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2017/11/4
 * Time: 23:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
	
namespace app
{
	// 辅助函数类.
	public class Tool
	{
		public Tool()
		{
		}
		
        //运行cmd命令
        public static bool RunCmd(string wwwPath,string cmdExe, string cmdStr)
        {
            bool result = false;
            try
            {
                using (Process myPro = new Process())
                {
                    //指定启动进程是调用的应用程序和命令行参数
                    ProcessStartInfo psi = new ProcessStartInfo(wwwPath+cmdExe,cmdStr);
                    myPro.StartInfo = psi;
//                    myPro.StartInfo.Arguments="cd " + wwwPath;
                    myPro.StartInfo.UseShellExecute = false; //是否重定向标准输入 
                    myPro.StartInfo.RedirectStandardError = true;//执行时是不是显示窗口   
                    myPro.StartInfo.CreateNoWindow = true;//启动 
                    myPro.Start();
//                    myPro.WaitForExit();
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
        /// 关闭进程名含某某的进程  
        /// </summary>  
        /// <param name="processName">进程名</param>  
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
