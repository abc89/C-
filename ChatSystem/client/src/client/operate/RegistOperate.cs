using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.transport;
using client.view;
using client.logs;
using System.Net;
using System.Net.Sockets;

namespace client.operate
{
    class RegistOperate : Operate
    {
        private String IP = "127.0.0.1";
        private String PORT = "6633";
        private String linkSate;//链接状态
        private Boolean hasLink = false;
        private String username;
        private String state = "abc";
        private ClientThread self;
        private TcpLinkAdp tcpLink;
        private RegistView registView;
        private static RegistOperate registOperate = new RegistOperate();
        private RegistOperate() { }
        public static RegistOperate getInstance()
        {
            return registOperate;
        }
        public void setView(Recive view)
        {
            attach(view);
        }
        internal String getDataState()
        {
            return state;
        }



        internal ClientThread getSelf()
        {
            return self;
        }

        public String getUerName()
        {

            return username;
        }
        /// <summary>
        /// 
        /// 链接服务器
        /// </summary>
        public Boolean startRegist(String username1, String pswd)
        {

            this.username = username1;
            Boolean link = linkServer();
            if (link)
            {
                self = new ClientThread(tcpLink);
                Boolean back = self.regist(username, pswd);

                if (back)
                {
                    ClientLogs.log("注册成功" + username1);
                    return true;
                }
                else
                {
                    ClientLogs.log("注册失败");
                    state = "注册失败，用户名已被注册:" + username;
                    notifyAll();
                    return false;
                }
            }
            else {
                state = "服务器连接异常:";
                notifyAll();
                return false;

            }
            return false;
        }



        public String getLinkState()
        {

            return linkSate;
        }
        private Boolean linkServer()
        {
            //设定服务器IP地址  
            try
            {
                ClientLogs.log("开始连接服务器");
                IPAddress ip = IPAddress.Parse(this.IP);
                int port = int.Parse(PORT);
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(new IPEndPoint(ip, port)); //配置服务器IP与端口  
                tcpLink = new TcpLinkAdp(clientSocket);
                ClientLogs.log("连接服务器成功");
                return true;
            }
            catch (Exception e)
            {
                ClientLogs.log("连接服务器失败" + e.ToString());
                return false;
            }

        }

        internal bool isOpenLink()
        {
            return hasLink;
        }

        public void update()
        {
            throw new NotImplementedException();
        }

        public override void attach(Recive recive)
        {
            recives.Add(recive);
        }

        public override void operate(string msg)
        {
            throw new NotImplementedException();
        }
    }
}