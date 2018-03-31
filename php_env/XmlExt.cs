/*
 * Created by SharpDevelop.
 * User: bool
 * Date: 2017/11/4
 * Time: 23:11
 * 
 */
using System;
using System.Xml;

namespace app
{
	/// xml处理类
	public class XmlExt
	{
		public XmlDocument doc;
		public XmlExt()
		{
			this.doc = new XmlDocument();      
			doc.Load("conf.xml");    //加载Xml文件  
		}
		
		//获取服务器
		public string[] getServer(){

			XmlElement rootElem = this.doc.DocumentElement;   //获取根节点 
			XmlNodeList serverNodes = rootElem.GetElementsByTagName("server"); //server节点	
//			string state = ( (XmlElement)serverNodes[0] ).GetAttribute("state");   //获取state属性值
			
			//name
			XmlNodeList nameNodes = ( (XmlElement)serverNodes[0] ).GetElementsByTagName("name");  //获取子集合  
			string name = nameNodes[0].InnerText; 
			
			//state
			XmlNodeList stateNodes = ( (XmlElement)serverNodes[0] ).GetElementsByTagName("state");  //获取子集合  
			string state = stateNodes[0].InnerText; 
			
			string[] temp = { name,state };
			return temp;
		}
		
		//获取php
		public string[] getPhp(){
			XmlElement rootElem = this.doc.DocumentElement;   //获取根节点 
			XmlNodeList phpNodes = rootElem.GetElementsByTagName("php"); //server节点	
			
			//name
			XmlNodeList nameNodes = ( (XmlElement)phpNodes[0] ).GetElementsByTagName("version");  //获取子集合  
			string name = nameNodes[0].InnerText; 
			
			//state
			XmlNodeList stateNodes = ( (XmlElement)phpNodes[0] ).GetElementsByTagName("state");  //获取子集合  
			string state = stateNodes[0].InnerText; 
			
			string[] temp = { name,state };
			return temp;
		}		
		
		//获取数据配置
		public string[] getDatabase(){

			XmlElement rootElem = this.doc.DocumentElement;   //获取根节点 
			XmlNodeList databaseNodes = rootElem.GetElementsByTagName("database"); //server节点	
			
			//name
			XmlNodeList nameNodes = ( (XmlElement)databaseNodes[0] ).GetElementsByTagName("name");  //获取子集合  
			string name = nameNodes[0].InnerText; 
			
			//state
			XmlNodeList stateNodes = ( (XmlElement)databaseNodes[0] ).GetElementsByTagName("state");  //获取子集合  
			string state = stateNodes[0].InnerText; 
			
			string[] temp = { name,state };
			return temp;
		}	

		public void updateXml(string phpV,string serverV){
			XmlElement rootElem = this.doc.DocumentElement; 
			XmlNodeList phpNodes = rootElem.GetElementsByTagName("php"); //php节点	
			XmlNodeList serverNodes = rootElem.GetElementsByTagName("server"); //server节点	 
			XmlNodeList databaseNodes = rootElem.GetElementsByTagName("database"); //database节点	 			
			
			//php
			XmlNodeList phpName = ((XmlElement)phpNodes[0]).GetElementsByTagName("version");
			phpName[0].InnerText = phpV;
            
            
			//server
			XmlNodeList serverName = ((XmlElement)serverNodes[0]).GetElementsByTagName("name");
			serverName[0].InnerText = serverV;

            this.doc.Save("conf.xml");
		}
		
		public void updateState(string phpV,string serverV,string databaseV){
			XmlElement rootElem = this.doc.DocumentElement; 
			XmlNodeList phpNodes = rootElem.GetElementsByTagName("php"); //php节点	
			XmlNodeList serverNodes = rootElem.GetElementsByTagName("server"); //server节点	 
			XmlNodeList databaseNodes = rootElem.GetElementsByTagName("database"); //database节点	 			
			
			//php
			XmlNodeList phpName = ((XmlElement)phpNodes[0]).GetElementsByTagName("state");
			phpName[0].InnerText = phpV;
            
            
			//server
			XmlNodeList serverName = ((XmlElement)serverNodes[0]).GetElementsByTagName("state");
			serverName[0].InnerText = serverV;

			//database
			XmlNodeList  databaseName = ((XmlElement)databaseNodes[0]).GetElementsByTagName("state");
			databaseName[0].InnerText = databaseV;
			
            this.doc.Save("conf.xml");
            
            
				//http://www.cnblogs.com/zhaoCat/p/6529022.html
	//	 		XmlDocument xmlDoc = new XmlDocument();
	//            xmlDoc.Load(xmlpath);
	//            XmlNode memberlist = xmlDoc.SelectSingleNode("ROOT/MEMBERLIST");
	//            XmlNodeList nodelist=memberlist.ChildNodes;
	//           // XmlNodeList nodelist=xmlDoc.GetElementsByTagName("MEMBER");
	//            foreach (XmlNode node in nodelist)
	//            {
	//                if (node.Attributes["AGE"].InnerText.ToString().Equals(">=29"))
	//                {
	//                    node.ChildNodes[0].InnerText = "张三";
	//                    node.ChildNodes[1].InnerText = "李四";
	//                    break;
	//                }
	//            }
	//            xmlDoc.Save(xmlpath);
	//            MessageBox.Show("保存成功");

		}
		
		
		
	}
}
