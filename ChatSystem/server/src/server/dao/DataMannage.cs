using server.logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace server.dao
{
    /// <summary>
    /// 用户数据操作
    /// 
    /// </summary>
    class DataMannage
    {
       static  String filePath = @"..\..\data\client.xml";
        public static List<String> getFriends(String name) {
            //  string str = System.Environment.CurrentDirectory;
            //   ServerLogs.logMoment(str);
            List<String> friends = new List<string>();
            XmlDocument doc = new XmlDocument();
              doc.Load(filePath);           
              XmlElement root = null;
              root = doc.DocumentElement;        
              XmlNodeList listNodes = null;
           
             listNodes = root.SelectNodes("users/user/name");
            foreach (XmlNode node in listNodes)
            {
                string strName = ((XmlElement)node).GetAttribute("name");   //获取name属性值  
               if (strName.CompareTo(name)==0){
                    listNodes = node.SelectNodes("friend");
                    foreach (XmlNode node2 in listNodes)
                    {
                        friends.Add(node2.InnerText);
                        ServerLogs.logMoment("找到好友"+node2.InnerText);
                    }
                        break;
                }
            }
            return friends;
        }

        private static String getPassword(String userName) {
            String paswd = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlElement root = null;
            root = doc.DocumentElement;
            XmlNodeList listNodes = null;

            listNodes = root.SelectNodes("users/user/name");
            foreach (XmlNode node in listNodes)
            {
                string strName = ((XmlElement)node).GetAttribute("name");   //获取name属性值  
                ServerLogs.logMoment(strName + "数目" + listNodes.Count);
                if (strName.CompareTo(userName) == 0)
                {
                    listNodes = node.SelectNodes("password");
                    if (listNodes.Count==1) {
                        return listNodes.Item(0).InnerText;
                    }
                }
            }
            return null;
        }
        internal static bool hasUser(string name, string password)
        {
            String pas=getPassword(name);
            if (pas!=null&&pas.CompareTo(password)==0) {
                return true;
            }
            return false;
        }
        private static void addUser(String name,String password) {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlElement root = null;
            root = doc.DocumentElement;
            XmlNodeList listNodes = null;
            listNodes = root.SelectNodes("users/user");
            foreach (XmlNode node in listNodes)
            {
                ServerLogs.logMoment(node.InnerText);


                //create node  
                XmlElement newCLient = doc.CreateElement("name");
                newCLient.SetAttribute("name", name);
                XmlElement newPas = doc.CreateElement("password");
                newPas.InnerText = password;

                //insert  
                newCLient.AppendChild(newPas);


                node.AppendChild(newCLient);

                //save  
                doc.Save(filePath);
                break;
            }
        }
        public static Boolean regist(String name,String password) {
            if (hasUser(name, password))
            {
                return false;
            }
            else {
                addUser(name, password);
                return true;
            }
        }
        public static void addFriend(String name, String addFriend)
        {
            //  string str = System.Environment.CurrentDirectory;
            //   ServerLogs.logMoment(str);
            List<String> friends = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlElement root = null;
            root = doc.DocumentElement;
            XmlNodeList listNodes = null;

            listNodes = root.SelectNodes("users/user/name");
            foreach (XmlNode node in listNodes)
            {
                string strName = ((XmlElement)node).GetAttribute("name");   //获取name属性值  
                if (strName.CompareTo(name) == 0)
                {
                    //create node  
                    XmlElement newCLient = doc.CreateElement("friend");
                    newCLient.InnerText = addFriend;
         

                    node.AppendChild(newCLient);

                    //save  
                    doc.Save(filePath);
                    break;
                }
            }
        }
    }
}
