/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2017/11/3
 * Time: 1:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace app
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.localhostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.phpmyadminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.www目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.服务器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nginxToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.caddyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pHPToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.mySQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.停止ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.重新启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.BalloonTipText = "php\r\nmysql";
			this.notifyIcon1.BalloonTipTitle = "菜单";
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "php集成环境";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1MouseClick);
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1MouseDoubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.localhostToolStripMenuItem,
			this.phpmyadminToolStripMenuItem,
			this.www目录ToolStripMenuItem,
			this.服务器ToolStripMenuItem,
			this.pHPToolStripMenuItem1,
			this.mySQLToolStripMenuItem,
			this.启动ToolStripMenuItem,
			this.停止ToolStripMenuItem,
			this.重新启动ToolStripMenuItem,
			this.退出ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(155, 246);
			// 
			// localhostToolStripMenuItem
			// 
			this.localhostToolStripMenuItem.Name = "localhostToolStripMenuItem";
			this.localhostToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.localhostToolStripMenuItem.Text = "Localhost";
			this.localhostToolStripMenuItem.Click += new System.EventHandler(this.LocalhostToolStripMenuItemClick);
			// 
			// phpmyadminToolStripMenuItem
			// 
			this.phpmyadminToolStripMenuItem.Name = "phpmyadminToolStripMenuItem";
			this.phpmyadminToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.phpmyadminToolStripMenuItem.Text = "phpMyAdmin";
			this.phpmyadminToolStripMenuItem.Click += new System.EventHandler(this.NginxToolStripMenuItemClick);
			// 
			// www目录ToolStripMenuItem
			// 
			this.www目录ToolStripMenuItem.Name = "www目录ToolStripMenuItem";
			this.www目录ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.www目录ToolStripMenuItem.Text = "www目录";
			this.www目录ToolStripMenuItem.Click += new System.EventHandler(this.Www目录ToolStripMenuItemClick);
			// 
			// 服务器ToolStripMenuItem
			// 
			this.服务器ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.nginxToolStripMenuItem1,
			this.caddyToolStripMenuItem});
			this.服务器ToolStripMenuItem.Name = "服务器ToolStripMenuItem";
			this.服务器ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.服务器ToolStripMenuItem.Text = "服务器";
			// 
			// nginxToolStripMenuItem1
			// 
			this.nginxToolStripMenuItem1.CheckOnClick = true;
			this.nginxToolStripMenuItem1.Name = "nginxToolStripMenuItem1";
			this.nginxToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
			this.nginxToolStripMenuItem1.Text = "Nginx";
			this.nginxToolStripMenuItem1.Click += new System.EventHandler(this.NginxToolStripMenuItem1Click);
			// 
			// caddyToolStripMenuItem
			// 
			this.caddyToolStripMenuItem.CheckOnClick = true;
			this.caddyToolStripMenuItem.Name = "caddyToolStripMenuItem";
			this.caddyToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.caddyToolStripMenuItem.Text = "Caddy";
			this.caddyToolStripMenuItem.Click += new System.EventHandler(this.CaddyToolStripMenuItemClick);
			// 
			// pHPToolStripMenuItem1
			// 
			this.pHPToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripMenuItem2,
			this.toolStripMenuItem3,
			this.toolStripMenuItem4});
			this.pHPToolStripMenuItem1.Name = "pHPToolStripMenuItem1";
			this.pHPToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
			this.pHPToolStripMenuItem1.Text = "PHP";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.CheckOnClick = true;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(110, 22);
			this.toolStripMenuItem2.Text = "5.3.29";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.CheckOnClick = true;
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(110, 22);
			this.toolStripMenuItem3.Text = "5.4.45";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.CheckOnClick = true;
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(110, 22);
			this.toolStripMenuItem4.Text = "5.6.27";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem4Click);
			// 
			// mySQLToolStripMenuItem
			// 
			this.mySQLToolStripMenuItem.Name = "mySQLToolStripMenuItem";
			this.mySQLToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.mySQLToolStripMenuItem.Text = "MySQL";
			this.mySQLToolStripMenuItem.Click += new System.EventHandler(this.MySQLToolStripMenuItemClick);
			// 
			// 启动ToolStripMenuItem
			// 
			this.启动ToolStripMenuItem.CheckOnClick = true;
			this.启动ToolStripMenuItem.Name = "启动ToolStripMenuItem";
			this.启动ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.启动ToolStripMenuItem.Text = "启动";
			this.启动ToolStripMenuItem.Click += new System.EventHandler(this.启动ToolStripMenuItemClick);
			// 
			// 停止ToolStripMenuItem
			// 
			this.停止ToolStripMenuItem.Name = "停止ToolStripMenuItem";
			this.停止ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.停止ToolStripMenuItem.Text = "停止";
			this.停止ToolStripMenuItem.Click += new System.EventHandler(this.停止ToolStripMenuItemClick);
			// 
			// 重新启动ToolStripMenuItem
			// 
			this.重新启动ToolStripMenuItem.Name = "重新启动ToolStripMenuItem";
			this.重新启动ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.重新启动ToolStripMenuItem.Text = "重新启动";
			this.重新启动ToolStripMenuItem.Click += new System.EventHandler(this.重新启动ToolStripMenuItemClick);
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.退出ToolStripMenuItem.Text = "退出";
			this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(294, 203);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "php集成环境";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.ToolStripMenuItem caddyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nginxToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 重新启动ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 停止ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 启动ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mySQLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem pHPToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 服务器ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem www目录ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem phpmyadminToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ToolStripMenuItem localhostToolStripMenuItem;
//		private System.Windows.Forms.ToolStripMenuItem phpmyadminToolStripMenuItem;
		
		void Button1Click(object sender, System.EventArgs e)
		{
			
		}
		
		void Button2Click(object sender, System.EventArgs e)
		{
			
		}
		
		void Button3Click(object sender, System.EventArgs e)
		{
			
		}
	}
}
