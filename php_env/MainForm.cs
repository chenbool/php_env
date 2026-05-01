/*
 * 创建工具: SharpDevelop
 * 作者: bool
 * 日期: 2017/11/4
 * 时间: 19:34
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace app
{
    /// <summary>
    /// 主窗体类
    /// 负责 PHP 集成环境的管理界面，包括服务启动/停止、版本切换等功能
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 当前选中的 PHP 版本菜单项
        /// </summary>
        public ToolStripMenuItem PhpItem = null;

        /// <summary>
        /// 当前选中的服务器类型菜单项
        /// </summary>
        public ToolStripMenuItem ServerItem = null;

        /// <summary>
        /// 应用根目录路径 (网站根目录)
        /// </summary>
        public string WwwPath = Application.StartupPath;

        /// <summary>
        /// 服务器配置信息 [类型, 状态]
        /// </summary>
        public string[] server;

        /// <summary>
        /// PHP 配置信息 [版本号]
        /// </summary>
        public string[] php;

        /// <summary>
        /// 数据库配置信息 [类型, 状态]
        /// </summary>
        public string[] database;

        /// <summary>
        /// 构造函数
        /// 初始化组件并加载 XML 配置信息
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            XmlExt Xml = new XmlExt();
            this.php = Xml.getPhp();
            this.server = Xml.getServer();
            this.database = Xml.getDatabase();
        }

        /// <summary>
        /// 窗体加载事件
        /// 初始化界面状态，加载配置信息
        /// </summary>
        void MainFormLoad(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => {
                this.Hide();
                this.Opacity = 1;
            }) );

            if(this.server[0] == "caddy"){
                this.serverCheck( this.caddyToolStripMenuItem);
            }

            if(this.server[0] == "nginx"){
                this.serverCheck( this.nginxToolStripMenuItem1);
            }

            if(this.server[1] == "1"){
                this.启动ToolStripMenuItem.Checked = true;
            }

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

        /// <summary>
        /// 窗体关闭事件
        /// 隐藏窗体而非退出程序 (最小化到托盘)
        /// </summary>
        void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        /// <summary>
        /// 托盘图标双击事件
        /// 恢复窗体显示
        /// </summary>
        void NotifyIcon1MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// 托盘图标单击事件
        /// 显示右键菜单
        /// </summary>
        void NotifyIcon1MouseClick(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Show(MousePosition.X, MouseEventArgs.Y);
        }

        /// <summary>
        /// 退出菜单点击事件
        /// 完全退出应用程序
        /// </summary>
        void 退出ToolStripMenuItemClick(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// PHP 5.3.29 版本选择事件
        /// 切换 PHP 版本并保存配置
        /// </summary>
        void ToolStripMenuItem2Click(object sender, EventArgs e)
        {
            this.phpCheck(this.toolStripMenuItem2);
            XmlExt Xml = new XmlExt();
            this.php[0] = "5.3.29";
            Xml.updateXml(this.php[0],this.server[0]);
        }

        /// <summary>
        /// PHP 5.4.45 版本选择事件
        /// 切换 PHP 版本并保存配置
        /// </summary>
        void ToolStripMenuItem3Click(object sender, EventArgs e)
        {
            this.phpCheck(this.toolStripMenuItem3);
            XmlExt Xml = new XmlExt();
            this.php[0] = "5.4.45";
            Xml.updateXml(this.php[0],this.server[0]);
        }

        /// <summary>
        /// PHP 5.6.27 版本选择事件
        /// 切换 PHP 版本并保存配置
        /// </summary>
        void ToolStripMenuItem4Click(object sender, EventArgs e)
        {
            this.phpCheck(this.toolStripMenuItem4);
            XmlExt Xml = new XmlExt();
            this.php[0] = "5.6.27";
            Xml.updateXml(this.php[0],this.server[0]);
        }

        /// <summary>
        /// PHP 版本切换处理函数
        /// 更新选中状态并记录当前选中的菜单项
        /// </summary>
        /// <param name="php">PHP版本菜单项</param>
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

        /// <summary>
        /// Nginx 服务器选择事件
        /// 切换 Web 服务器为 Nginx 并保存配置
        /// </summary>
        void NginxToolStripMenuItem1Click(object sender, EventArgs e)
        {
            this.serverCheck( this.nginxToolStripMenuItem1 );
            XmlExt Xml = new XmlExt();
            this.server[0] = "nginx";
            Xml.updateXml(this.php[0],this.server[0]);
        }

        /// <summary>
        /// Caddy 服务器选择事件
        /// 切换 Web 服务器为 Caddy 并保存配置
        /// </summary>
        void CaddyToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.serverCheck( this.caddyToolStripMenuItem);
            XmlExt Xml = new XmlExt();
            this.server[0] = "caddy";
            Xml.updateXml(this.php[0],this.server[0]);
        }

        /// <summary>
        /// 服务器切换处理函数
        /// 更新选中状态并记录当前选中的菜单项
        /// </summary>
        /// <param name="server">服务器类型菜单项</param>
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

        /// <summary>
        /// phpMyAdmin 菜单点击事件
        /// 使用系统默认浏览器打开 phpMyAdmin
        /// </summary>
        void NginxToolStripMenuItemClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost/phpmyadmin/");
        }

        /// <summary>
        /// localhost 菜单点击事件
        /// 使用系统默认浏览器打开本地站点
        /// </summary>
        void LocalhostToolStripMenuItemClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost");
        }

        /// <summary>
        /// www 目录菜单点击事件
        /// 打开网站根目录
        /// </summary>
        void Www目录ToolStripMenuItemClick(object sender, EventArgs e)
        {
            string WwwPath = this.WwwPath;
            System.Diagnostics.Process.Start(@WwwPath+"\\www");
        }

        /// <summary>
        /// 启动服务菜单点击事件
        /// 启动 Nginx/Caddy、PHP、MySQL 服务
        /// </summary>
        void 启动ToolStripMenuItemClick(object sender, EventArgs e)
        {
            XmlExt Xml = new XmlExt();
            this.php = Xml.getPhp();
            this.server = Xml.getServer();
            this.database = Xml.getDatabase();

            string serverPath = "\\server\\"+this.server[0]+"\\";
            bool serverState = false;

            if( this.server[0] == "nginx" ){
                serverState = Tool.RunCmd(this.WwwPath,serverPath+"nginx.exe"," -c "+this.WwwPath+serverPath+"conf\\nginx.conf -p "+this.WwwPath+serverPath);
                if( !serverState){
                    this.notifyIcon1.ShowBalloonTip(1,"系统提示","nginx启动失败……",ToolTipIcon.Warning);
                }
            }else if(this.server[0] == "caddy"){
                serverState = Tool.RunCmd(this.WwwPath,serverPath+"caddy.exe"," -conf "+this.WwwPath+serverPath+"Caddyfile");
                if( !serverState){
                    this.notifyIcon1.ShowBalloonTip(1,"系统提示","caddy启动失败……",ToolTipIcon.Warning);
                }
            }

            string phpPath = "\\php\\php-"+this.php[0]+"\\";
            bool phpState = Tool.RunCmd(this.WwwPath,phpPath+"php-cgi.exe"," -b 127.0.0.1:9000 -c "+this.WwwPath+phpPath+"php.ini");
            if( !phpState){
                this.notifyIcon1.ShowBalloonTip(1,"系统提示","php"+this.php[0]+"启动失败……",ToolTipIcon.Warning);
            }

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

        /// <summary>
        /// 停止服务菜单点击事件
        /// 停止 Nginx/Caddy、PHP、MySQL 服务
        /// </summary>
        void 停止ToolStripMenuItemClick(object sender, EventArgs e)
        {
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

        /// <summary>
        /// 重新启动菜单点击事件
        /// 先停止所有服务，等待2秒后重新启动
        /// </summary>
        void 重新启动ToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.停止ToolStripMenuItemClick(sender,e);
            Thread.Sleep(2000);
            this.启动ToolStripMenuItemClick(sender,e);
        }

        /// <summary>
        /// MySQL 菜单点击事件
        /// 预留用于打开 MySQL 命令行
        /// </summary>
        void MySQLToolStripMenuItemClick(object sender, EventArgs e)
        {
        }
    }
}
