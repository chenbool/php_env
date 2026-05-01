/*
 * 创建工具: SharpDevelop
 * 作者: bool
 * 日期: 2017/11/4
 * 时间: 23:11
 */
using System;
using System.Xml;

namespace app
{
    /// <summary>
    /// XML 配置文件处理类
    /// 负责读取和更新 conf.xml 配置文件
    /// </summary>
    public class XmlExt
    {
        /// <summary>
        /// XML 文档对象
        /// </summary>
        public XmlDocument doc;

        /// <summary>
        /// 构造函数
        /// 加载 XML 配置文件
        /// </summary>
        public XmlExt()
        {
            this.doc = new XmlDocument();
            doc.Load("conf.xml");
        }

        /// <summary>
        /// 获取服务器配置信息
        /// </summary>
        /// <returns>服务器配置数组 [服务器类型, 运行状态]</returns>
        public string[] getServer(){
            XmlElement rootElem = this.doc.DocumentElement;
            XmlNodeList serverNodes = rootElem.GetElementsByTagName("server");

            XmlNodeList nameNodes = ( (XmlElement)serverNodes[0] ).GetElementsByTagName("name");
            string name = nameNodes[0].InnerText;

            XmlNodeList stateNodes = ( (XmlElement)serverNodes[0] ).GetElementsByTagName("state");
            string state = stateNodes[0].InnerText;

            string[] temp = { name,state };
            return temp;
        }

        /// <summary>
        /// 获取 PHP 配置信息
        /// </summary>
        /// <returns>PHP 配置数组 [版本号, 状态]</returns>
        public string[] getPhp(){
            XmlElement rootElem = this.doc.DocumentElement;
            XmlNodeList phpNodes = rootElem.GetElementsByTagName("php");

            XmlNodeList nameNodes = ( (XmlElement)phpNodes[0] ).GetElementsByTagName("version");
            string name = nameNodes[0].InnerText;

            XmlNodeList stateNodes = ( (XmlElement)phpNodes[0] ).GetElementsByTagName("state");
            string state = stateNodes[0].InnerText;

            string[] temp = { name,state };
            return temp;
        }

        /// <summary>
        /// 获取数据库配置信息
        /// </summary>
        /// <returns>数据库配置数组 [数据库名, 状态]</returns>
        public string[] getDatabase(){
            XmlElement rootElem = this.doc.DocumentElement;
            XmlNodeList databaseNodes = rootElem.GetElementsByTagName("database");

            XmlNodeList nameNodes = ( (XmlElement)databaseNodes[0] ).GetElementsByTagName("name");
            string name = nameNodes[0].InnerText;

            XmlNodeList stateNodes = ( (XmlElement)databaseNodes[0] ).GetElementsByTagName("state");
            string state = stateNodes[0].InnerText;

            string[] temp = { name,state };
            return temp;
        }

        /// <summary>
        /// 更新 PHP 版本和服务器类型配置
        /// </summary>
        /// <param name="phpV">PHP 版本号</param>
        /// <param name="serverV">服务器类型</param>
        public void updateXml(string phpV,string serverV){
            XmlElement rootElem = this.doc.DocumentElement;
            XmlNodeList phpNodes = rootElem.GetElementsByTagName("php");
            XmlNodeList serverNodes = rootElem.GetElementsByTagName("server");
            XmlNodeList databaseNodes = rootElem.GetElementsByTagName("database");

            XmlNodeList phpName = ((XmlElement)phpNodes[0]).GetElementsByTagName("version");
            phpName[0].InnerText = phpV;

            XmlNodeList serverName = ((XmlElement)serverNodes[0]).GetElementsByTagName("name");
            serverName[0].InnerText = serverV;

            this.doc.Save("conf.xml");
        }

        /// <summary>
        /// 更新服务运行状态
        /// </summary>
        /// <param name="phpV">PHP 运行状态 (0/1)</param>
        /// <param name="serverV">服务器运行状态 (0/1)</param>
        /// <param name="databaseV">数据库运行状态 (0/1)</param>
        public void updateState(string phpV,string serverV,string databaseV){
            XmlElement rootElem = this.doc.DocumentElement;
            XmlNodeList phpNodes = rootElem.GetElementsByTagName("php");
            XmlNodeList serverNodes = rootElem.GetElementsByTagName("server");
            XmlNodeList databaseNodes = rootElem.GetElementsByTagName("database");

            XmlNodeList phpName = ((XmlElement)phpNodes[0]).GetElementsByTagName("state");
            phpName[0].InnerText = phpV;

            XmlNodeList serverName = ((XmlElement)serverNodes[0]).GetElementsByTagName("state");
            serverName[0].InnerText = serverV;

            XmlNodeList  databaseName = ((XmlElement)databaseNodes[0]).GetElementsByTagName("state");
            databaseName[0].InnerText = databaseV;

            this.doc.Save("conf.xml");
        }
    }
}
