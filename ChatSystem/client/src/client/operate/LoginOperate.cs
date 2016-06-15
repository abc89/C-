using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using client.transport;
using client.view;
using client.data;
using System.Net.NetworkInformation;
using System.Collections;
using client.logs;

namespace client.operate
{
    /// <summary>
    /// 登陆处理类
    /// </summary>
    class LoginOperate : Operate
    {
        private String IP="127.0.0.1";
        private String PORT="6633";
        private String linkSate;//链接状态
        private Boolean hasLink = false;
        private String username;
        private String state="abc";
        private ClientThread self;
        private TcpLinkAdp tcpLink;
        private LoginView loginView;
        private static LoginOperate loginOperate = new LoginOperate();
        private LoginOperate() { }
        public static LoginOperate getInstance() {
            return loginOperate;
        }
        public void setView(LoginView view) {
            attach(view);
        }
        internal String getDataState()
        {
            return state;
        }
   
     

        internal ClientThread getSelf()
        {
            return self ;
        }

        public String getUerName() {

            return username;
        }
     
        /// <summary>
        /// 
        /// 链接服务器
        /// </summary>
        public  Boolean startLink(String username1,String pswd)
        {
            ClientLogs.log("开始链接");
            hasLink = false;
          //  int port = SocketPort.getAvliatePort(5000,8000);
            this.username = username1;
            Boolean link = linkServer();

            if (link)
            {
                self = new ClientThread(tcpLink);
                Boolean back = self.join(username, pswd);
                if (back)
                {
                self.configUdpThread(null,new UdpLinkAdp(UdpLinkAdp.SEND,"127.0.0.1","8080"));
                    hasLink = true;

                    ClientLogs.log("LoginOperate()  登陆成功");
                }
                else
                {
                    state = self.getState();
                    notifyAll();
                    ClientLogs.log("LoginOperate()  登陆失败");
                }
            }
            else {
                state = "登陆失败服务器未开启";
                notifyAll();
            }
            return hasLink;
        }

      

        public String getLinkState() {

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
