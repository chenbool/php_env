/*
 * Created by SharpDevelop.
 * User: bool
 * Date: 2017/11/4
 * Time: 19:34
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace app
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>	
	public partial class MainForm : Form
	{
		//选中状态
		public ToolStripMenuItem PhpItem = null;
		public ToolStripMenuItem ServerItem = null;
		
		//app路径
		public string WwwPath = Application.StartupPath;
		
		//记录用户使用的版本信息
		public string[] server;
		public string[] php;
		public string[] database;
		
		public MainForm()
		{
			InitializeComponent();
			//加载xml配置
			XmlExt Xml = new XmlExt();
			this.php = Xml.getPhp();
			this.server = Xml.getServer();
			this.database = Xml.getDatabase();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			//隐藏启动窗口
			this.BeginInvoke(new Action(() => {
                this.Hide();
                this.Opacity = 1;
            }) );
			
			//获取配置信息
			if(this.server[0] == "caddy"){
				this.serverCheck( this.caddyToolStripMenuItem);
			}
			
			if(this.server[0] == "nginx"){
				this.serverCheck( this.nginxToolStripMenuItem1);
			}
			//检测服务器是否已经开启
			if(this.server[1] == "1"){
				this.启动ToolStripMenuItem.Checked = true;
			}
			
			//php
			if(this.php[0] == "5.3.29"){
				this.phpCheck(this.toolStripMenuItem2);
			}
			
			if(this.php[0] == "5.4.45"){
				this.phpCheck(this.toolStripMenuItem3);
			}
			
			if(this.php[0] == "5.6.27"){
				this.phpCheck(this.toolStripMenuItem4);
			}
		}		
		
		
		//点击关闭		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}	

		//托盘双击
		void NotifyIcon1MouseDoubleClick(object sender, MouseEventArgs e)
		{
//			this.Show();
			this.WindowState = FormWindowState.Normal;
		}
			
		
		void NotifyIcon1MouseClick(object sender, MouseEventArgs e)
		{
			contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
		}
		
		
		void 退出ToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Environment.Exit(0); 
		}
		
		
		//php5.3.29
		void ToolStripMenuItem2Click(object sender, EventArgs e)
		{
			this.phpCheck(this.toolStripMenuItem2);
			XmlExt Xml = new XmlExt();
			this.php[0] = "5.3.29";
			Xml.updateXml(this.php[0],this.server[0]);
		}
		
		//php5.4.45
		void ToolStripMenuItem3Click(object sender, EventArgs e)
		{
			this.phpCheck(this.toolStripMenuItem3);
			XmlExt Xml = new XmlExt();
			this.php[0] = "5.4.45";
			Xml.updateXml(this.php[0],this.server[0]);
		}
		
		//php5.6.27
		void ToolStripMenuItem4Click(object sender, EventArgs e)
		{
			this.phpCheck(this.toolStripMenuItem4);
			XmlExt Xml = new XmlExt();
			this.php[0] = "5.6.27";
			Xml.updateXml(this.php[0],this.server[0]);
		}
		
		//php版本切换
		void phpCheck(ToolStripMenuItem php){
			if( PhpItem != null ){
				PhpItem.Checked = false;
				php.Checked = true;
				PhpItem = php;
			}else{
				PhpItem = php;
				php.Checked = true;	
			}				
		}
		
		//nginx
		void NginxToolStripMenuItem1Click(object sender, EventArgs e)
		{
			this.serverCheck( this.nginxToolStripMenuItem1 );
			XmlExt Xml = new XmlExt();
			this.server[0] = "nginx";
			Xml.updateXml(this.php[0],this.server[0]);
		}
		
		//caddy
		void CaddyToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.serverCheck( this.caddyToolStripMenuItem);
			XmlExt Xml = new XmlExt();
			this.server[0] = "caddy";
			Xml.updateXml(this.php[0],this.server[0]);
		}
		
//		void LighttpdToolStripMenuItemClick(object sender, EventArgs e)
//		{
//			this.serverCheck( this.lighttpdToolStripMenuItem);
//		}
		
		//服务器切换
		void serverCheck(ToolStripMenuItem server){
			if( ServerItem != null ){
				ServerItem.Checked = false;
				server.Checked = true;
				ServerItem = server;
			}else{
				ServerItem = server;
				server.Checked = true;	
			}				
		}		
		
		//phpmyadmin
		void NginxToolStripMenuItemClick(object sender, EventArgs e)
		{
			//调用系统默认的浏览器   
    		System.Diagnostics.Process.Start("http://localhost/phpmyadmin/");  
		}
		
		//localhost
		void LocalhostToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://localhost");
		}
		
		//www
		void Www目录ToolStripMenuItemClick(object sender, EventArgs e)
		{
			string WwwPath = this.WwwPath;
			System.Diagnostics.Process.Start(@WwwPath+"\\www");
		}

		
		//启动
		void 启动ToolStripMenuItemClick(object sender, EventArgs e)
		{
			XmlExt Xml = new XmlExt();
			this.php = Xml.getPhp();
			this.server = Xml.getServer();
			this.database = Xml.getDatabase();
			
			//服务器路径
			string serverPath = "\\server\\"+this.server[0]+"\\";
			bool serverState = false;
				
			//检测服务器
			if( this.server[0] == "nginx"  ){
				
				serverState = Tool.RunCmd(this.WwwPath,serverPath+"nginx.exe"," -c "+this.WwwPath+serverPath+"conf\\nginx.conf -p "+this.WwwPath+serverPath);
				if( !serverState){
					this.notifyIcon1.ShowBalloonTip(1,"系统提示","nginx启动失败……",ToolTipIcon.Warning);
				}
			}else if(this.server[0] == "caddy"){
				serverState = Tool.RunCmd(this.WwwPath,serverPath+"caddy.exe"," -conf "+this.WwwPath+serverPath+"Caddyfile");
				if( !serverState){
					this.notifyIcon1.ShowBalloonTip(1,"系统提示","caddy启动失败……",ToolTipIcon.Warning);
				}
			}else{
				
			}

			//php路径
			string phpPath = "\\php\\php-"+this.php[0]+"\\";
			bool phpState = Tool.RunCmd(this.WwwPath,phpPath+"php-cgi.exe"," -b 127.0.0.1:9000 -c "+this.WwwPath+phpPath+"php.ini");
			if( !phpState){
				this.notifyIcon1.ShowBalloonTip(1,"系统提示","php"+this.php[0]+"启动失败……",ToolTipIcon.Warning);
			}	
			
			//mysql
//			this.database[0]
			string dbPath = "\\mysql\\bin\\mysqld.exe";
			bool dbState = Tool.RunCmd(this.WwwPath,dbPath,"");
			if( !dbState){
				this.notifyIcon1.ShowBalloonTip(1,"系统提示","php"+this.php[0]+"启动失败……",ToolTipIcon.Warning);
			}		
			
			if( serverState && phpState && dbState ){
				this.notifyIcon1.ShowBalloonTip(1,"系统提示","启动成功……",ToolTipIcon.Info);
			}
			
			Xml.updateState("1","1","1");
			this.启动ToolStripMenuItem.Checked = true;
			this.停止ToolStripMenuItem.Checked = false;
			
		}		
		
		//停止
		void 停止ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//获取配置信息
			if(this.server[0] == "caddy"){
				Tool.KillProcess("caddy"); 
			}else if(this.server[0] == "nginx"){
				Tool.KillProcess("nginx"); 
			}
			Tool.KillProcess("php");
			Tool.KillProcess("mysqld");
			
			this.停止ToolStripMenuItem.Checked = true;
			this.启动ToolStripMenuItem.Checked = false;
			this.notifyIcon1.ShowBalloonTip(1,"系统提示","停止成功……",ToolTipIcon.Info);
			
			XmlExt Xml = new XmlExt();
			Xml.updateState("0","0","0");
		}
		void 重新启动ToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.停止ToolStripMenuItemClick(sender,e);
			Thread.Sleep(2000);
			this.启动ToolStripMenuItemClick(sender,e);
		}
		
		//mysql
		void MySQLToolStripMenuItemClick(object sender, EventArgs e)
		{
//			System.Diagnostics.Process.Start(WwwPath+"\\mysql\\bin\\mysql.exe");  
		}


		
	}
}
