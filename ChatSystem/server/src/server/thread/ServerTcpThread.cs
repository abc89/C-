using server.link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using server.indetify;
using server.operate;
using server.logs;
using SocketServerTest;
using server.msg;
using server.control;

namespace server.thread
{
    /// <summary>
    /// 用户登录TCP链接验证
    /// </summary>
    class ServerTcpThread
    {
        private Link link;
        private Boolean stopThread=false;
  
        private Boolean identifyFlag = false;
        private LinkControl control;
        private String exit = "exitClient";
        private Identify idenrifyT;
        public ServerTcpThread(Link link1,LinkControl control1)
        {
            this.link = link1;
            this.control = control1;
        }

        internal Client join()
        {
            identify();
            if (identifyFlag) {
                Client client = new Client();
                client.setSessionID(idenrifyT.getSessionID());
                client.setIP(idenrifyT.getIP());
                client.setPort(idenrifyT.getPort());
                client.setName(idenrifyT.getName());
                return client;
            }
            return null;
        }
        /*public void beginhread() {
            if (identifyFlag)
            {
                ServerLogs.logMoment("验证通过 建立客户线程");
                Thread receiveThread = new Thread(startThread);
                receiveThread.Start();
            }
            else {
                ServerLogs.logMoment("验证不通过 不可建立客户线程");
            }
        }
        public void startThread()
        {
            while (identifyFlag && !stopThread)
            {
              
                    //通过clientSocket接收数据  
                    String msg = link.receive();
                if (msg.CompareTo(exit) != 0)
                {
                    Msg msgs = new Msg(msg);
                    OperateMannager.operateChatMsg(this, msgs);
                }
                else {
                    close();
                }
            
            }
        }
        */
        internal string getIP()
        {
           return link.getIP();
        }

        public void stop() {
            this.stopThread = true;
        }
     
        public void send(String msg) {
            link.send(msg);
        }
        public String get()
        {
            return link.receive();
        }
        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private  void identify()
        {
            idenrifyT = new Identify();
            identifyFlag = idenrifyT.identify(link);     
        }

        internal void close()
        {
            try {
                link.close();
                stopThread = true;
            }
            catch (Exception e) {
                ServerLogs.logMoment("tcp 验证线程关闭");
            }
        }
    }
}
