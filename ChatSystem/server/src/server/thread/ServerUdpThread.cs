using server.control;
using server.link;
using server.logs;
using server.msg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace server.thread
{
    class ServerUdpThread 
    {
        private Boolean stopThread = false;
        private Boolean identifyFlag = false;
        private LinkControl control;
        private String exit = "exitClient";
        private UdpLinkAdp link;
        public ServerUdpThread(UdpLinkAdp link1, LinkControl control1)
        {
            this.link = link1;
            this.control = control1;
        }

        public void beginUdpThread()
        {
            ServerLogs.logMoment("启动UDP");
            this.stopThread = false;
           Thread udpthread = new Thread(new ThreadStart(startUdpThread1));
            udpthread.IsBackground = true;
            udpthread.Start();
            ServerLogs.logMoment("启动UDP完毕");
        }
        /// <summary>
        /// UDP接收线程的方法
        /// </summary>
        void startUdpThread1()
        {
            ServerLogs.logMoment("线程方法");
            IPEndPoint myhost = new IPEndPoint(IPAddress.Any, 0);
            while (!stopThread)
            {
                try
                {
                    ServerLogs.logMoment("UDP开始接受");
                    String strMsg = link.receive(myhost);
                    ServerLogs.logMoment("接受到" + strMsg);
                    Msg msg = new Msg(strMsg);
                    ChatControl.getInstance().addNewMsg(msg);
                }
                catch(Exception e)
                {
                    ServerLogs.logMoment("接受到" + e.ToString());
                }
                //暂停
                Thread.Sleep(50);
            }
        }

        public void stop()
        {
            this.stopThread = true;
        }
       
        internal void close()
        {
            try
            {
                stopThread = true;
                link.close();
             
            }
            catch (Exception e)
            {
                ServerLogs.logMoment("服务器UDP接收线程关闭");
            }
        }
    }
}
