using client.logs;
using client.msg;
using client.operate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace client.transport
{
    class ClientThread
    {
        private Link link;
        private Boolean stopThread = false;
        private String name;
        private String sessionID;
        private String msgID;
        private String operateID="null";
        private Boolean identifyFlag = false;
        private Boolean udpThread = false;
        private UdpLinkAdp recUdpLink;
        private UdpLinkAdp grounpRecUdpLink;
        private UdpLinkAdp groundSendUdpLink;
        private UdpLinkAdp sendUdpLink;
        private String port;
        private bool udpStart = false;
        private String state;
        public ClientThread(Link link1)
        {
            this.link = link1;
        }
     
        internal bool join(String usename,String password)
        {
            IdentifyMsg.clear();

            IdentifyMsg.setMsgType(IdentifyMsg.LOGINIDENTIFY);
            IdentifyMsg.setName(usename);
            IdentifyMsg.setPassword(password);
            link.send(IdentifyMsg.getMsg());
            String back = link.receive();
            IdentifyMsg.config(back);
            if (IdentifyMsg.getMsgType().CompareTo(IdentifyMsg.LOGINOK) == 0)
            {
                identifyFlag = true;
                this.name = usename;
                this.sessionID = IdentifyMsg.getSessionID();
                this.msgID = IdentifyMsg.getMsgID();
                this.port = IdentifyMsg.getPort();
                ClientLogs.log("port"+port);
                link.close();
                ClientLogs.log("登陆成功");
            }
            else
            {
                identifyFlag = false;
                link.close();
                if (back.CompareTo("LOGINED") == 0)
                {
                    state = "该用户已登录";
                }
                else {
                    state = "密码或 用户名错误";
                }
            }
            return identifyFlag;
        }

        internal void udpGrounpSend(Msg msg)
        {
            msg.setSessionID(sessionID);
            msg.setOperateID(operateID);
            msg.setMsgID(msgID);
            grounpRecUdpLink.send(msg.getMsg());
        }

        public String getState() {
            return state;
        }
        internal bool udpIsStart()
        {
           return udpStart;
        }

        /*  public void beginTcpThread()
 {
     if (identifyFlag)
     {
        Thread receiveThread = new Thread(startTcpThread);
         receiveThread.Start();
     }
     else
     {
       //  ServerLogs.logMoment("验证不通过 不可建立客户线程");
     }
 }*/
        public void beginUdpThread()
        {
            ClientLogs.log("开始启动UDP接收线程");
            if (identifyFlag)
            {
                ClientLogs.log("开始启动UDP接收线");
                this.stopThread = false;
                Thread receiveThread = new Thread(startUdpThread);
                receiveThread.Start();
            }
            else
            {
                //  ServerLogs.logMoment("验证不通过 不可建立客户线程");
            }
        }

        internal void beginGroupUdpThread()
        {
            if (identifyFlag)
            {
            ClientLogs.log("开始启动群聊接收线程");
                this.stopThread = false;
                Thread receiveThread = new Thread(startoupUdpThread);
                receiveThread.Start();
            }
            else
            {
                //  ServerLogs.logMoment("验证不通过 不可建立客户线程");
            }
        }
    
    /// <summary>
    /// UDP接收线程的方法
    /// </summary>
    void startoupUdpThread()
    {
        IPEndPoint myhost = new IPEndPoint(IPAddress.Any, 0);
        while (!stopThread)
        {
            try
            {
                ClientLogs.log("群聊接受");
                String msg = grounpRecUdpLink.receive(myhost);
                ClientLogs.log("接受到" + msg);
                OperateMannager.opearte(msg);
            }
            catch
            {
            }
            //暂停
            Thread.Sleep(50);
        }
    }
    internal bool regist(string username, string pswd)
        {
            Boolean registOk = false;
            IdentifyMsg.clear();

            IdentifyMsg.setMsgType(IdentifyMsg.REGIST);
            IdentifyMsg.setName(username);
            IdentifyMsg.setPassword(pswd);
            link.send(IdentifyMsg.getMsg());
            String back = link.receive();
            if (back.CompareTo("ok") == 0)
            {
                registOk = true;
            }
            else
            {
                registOk = false;
                ClientLogs.log("注册失败");
            }
     
            link.close();
            stopThread = true;
            ClientLogs.log("关闭连接");
            return registOk;
        }

        internal void setName(string username)
        {
            throw new NotImplementedException();
        }

        public void startTcpThread()
        {
            while (identifyFlag && !stopThread)
            {

                //通过clientSocket接收数据  
                try {
                    udpStart = true;
                    String msg = link.receive();
                    ClientLogs.log("接收消息"+msg);
                    OperateMannager.opearte(msg);
                }
                catch (Exception e) {
            ClientLogs.log("关闭连接线程");

                }
            }
        }
        /// <summary>
        /// 关闭连接 ，必须重新连接 才可重启链接线程
        /// </summary>
        public void close() {
         //   link.send("exitClient");
            identifyFlag = false;
            stopThread = true;
            try {
            link.close();

            }
            catch (Exception e) {
            ClientLogs.log("关闭连接");

            }
        }
        public void parse()
        {
            this.stopThread = true;
        }
      
         
        public String getName()
        {

            return name;
        }
      /*  public void tcpSend(Msg msg)
        {
            ClientLogs.log("tcp发送消息"+msg);
            link.send(msg.getMsg());
        }*/

        internal void setOperateID(Msg msg)
        {
           this.operateID=msg.getMsgID();
        }

        public void udpSend(Msg msg)
        {
            msg.setSessionID(sessionID);
            msg.setOperateID(operateID);
            msg.setMsgID(msgID);
            sendUdpLink.send(msg.getMsg());
        }
        internal void configUdpThread(UdpLinkAdp recUdpLink1, UdpLinkAdp sendUdpLink1)
        {
          
                this.sendUdpLink = sendUdpLink1;
            this.recUdpLink = new UdpLinkAdp(UdpLinkAdp.RECIEVE,port);
          
        }
        internal void configUdpThread()
        {
        }
        internal void configUDPGroup(UdpLinkAdp feoupLink)
        {
            this.grounpRecUdpLink = feoupLink;
            this.groundSendUdpLink = feoupLink;
        }

        public String get()
        {
            return link.receive();
        }
        /// <summary>
        /// UDP接收线程的方法
        /// </summary>
        void startUdpThread()
        {
            ClientLogs.log("开始启动UDP接收");
            IPEndPoint myhost = new IPEndPoint(IPAddress.Any, 0);
            while (!stopThread)
            {
                try
                {
                    ClientLogs.log("开始接受");
                    String msg = recUdpLink.receive(myhost);
                    ClientLogs.log("接受到"+msg);
                    OperateMannager.opearte(msg);
                }
                catch
                {
                }
                //暂停
                Thread.Sleep(50);
            }
        }

    }
}
