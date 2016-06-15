using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.link;
using server.logs;
using SocketServerTest;
using server.msg;
using server.dao;
using server.Dao;

namespace server.indetify
{
    class Identify
    {
        private  String name;
        private String ip;
        private String port;
        private String sessionID;
        private static int sID = 0;
        /// <summary>
        /// 身份验证 与 注册  
        /// </summary>
        /// <param name="link"></param>
        /// <returns>true 表示登陆成功 进而之后的客户链接接收线程；
        ///           false： 登陆失败，注册成功或失败 都关闭链接  不生成客户链接接收线程</returns>
        internal   bool identify(Link link)
        {
            Boolean loginOk=false;
            String psd = link.receive();
            IdentifyMsg msg = new IdentifyMsg(psd);
            ServerLogs.logMoment(msg.getName()+msg.getPassword());
            if (msg.getMsgType().CompareTo(IdentifyMsg.REGIST) == 0) {
                name = msg.getName();
                String password = msg.getPassword();
                bool registUser = DataMannage.regist(name, password);
                if (registUser)
                {
                    link.send("ok");
                }
                else
                {
                    link.send("NO");
                }
            }
            else if (msg.getMsgType().CompareTo(IdentifyMsg.LOGINIDENTIFY) == 0) {
                name = msg.getName();
                ip = link.getIP();
                port =link.getPort();
                int p = int.Parse(port);
                p++;
                port = Convert.ToString(p);
                sessionID = Convert.ToString(sID);
                sID++;
                String password = msg.getPassword();
                bool hasUser = DataMannage.hasUser(name, password);
                if (hasUser&&!PersonDataSet.contain(name))
                {
                    msg.setMsgType(IdentifyMsg.LOGINOK);
                    msg.setSessionID(sessionID);
                    msg.setMsgID("0");
                    msg.setPort(port);
                    link.send(msg.getMsg());
                    loginOk = true;
                    PersonDataSet.add(name);
                }
                else {
                    if (!PersonDataSet.contain(name))
                    {
                        link.send("NO");

                    }
                    else {
                        link.send("LOGINED");
                    }
                }

             }
            return loginOk;
        }

        internal  string getName()
        {
            return name;;
        }
        internal string getSessionID()
        {
            return sessionID; ;
        }
        internal string getIP()
        {
            return ip;
        }
        internal string getPort()
        {
            return port;
        }
    }
}
