using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.transport;
using client.view;
using System.Net;
using System.Threading;
using client.msg;
using client.logs;
using client.data;

namespace client.operate
{
    /// <summary>
    /// 聊天信息处理类
    /// </summary>
    class ChatOperate : Operate
    {
        private String forName;

        /// <summary>
        /// 单人聊天
        /// </summary>
        /// <param name="name">聊天对象 名称</param>
        private static ChatOperate oneChatOperate = new ChatOperate();
    
        private String UDPPORT = "8988";

        internal void configMannyChat()
        {
            Msg msg = new Msg();
            msg.setMsgType(Msg.MANNYCHAT);
            msg.setMsgContent("UDPCONFIG");
            self.udpSend(msg);
        }

        private ClientThread self;
        private String state;
        public  const int MANNYCHATOK = 1;
        public const int  ONECHAT = 2;
        
        private ChatOperate(String name) { }

        private ChatOperate()
        {
        }
        public String getState() {

            return state;
        }
        public override void attach(Recive recive)
        {
            recives.Add(recive);
        }
        internal static ChatOperate getInstance()
        {      
            return oneChatOperate;
        }
        internal static ChatOperate getInstance(Recive chatOneView)
        {

            oneChatOperate.attach(chatOneView);
            oneChatOperate. self = LoginOperate.getInstance().getSelf();
            OperateMannager.changeOperateMode(OperateMannager.ONEOPERATE);
            return oneChatOperate;
        }

       

        public void send(int mode,Msg msg) {
            if (mode == MANNYCHATOK)
            {
              
                self.udpGrounpSend(msg);
            }
            else{
              
                self.udpSend(msg);
            }
        }
       
        private void startOneUdpChat(string fip,String fport)
        {
            self.parse();
            ClientLogs.log("组播地址：" + fip + "端口：" + fport );
            //  ClientLogs.log("本地："+fip+"端口："+UDPPORT+" 对方："+fip+"duank:"+fport);
            //  Random Random1 = new Random();//产生0到1000的随机数
            //  int i1=Random1.Next(8000,9001);
            //  String port = rePort;
            //  String ip = ip1;
            // UdpLinkAdp recUdpLink = new UdpLinkAdp(UdpLinkAdp.RECIEVE,fip, this.UDPPORT);
            // UdpLinkAdp sendUdpLink = new UdpLinkAdp(UdpLinkAdp.SEND,fip,fport);
            // self.configUdpThread(recUdpLink, sendUdpLink);
            UdpLinkAdp feoupLink = new UdpLinkAdp(UdpLinkAdp.GROUPCHAT, fip, this.UDPPORT);
            self.configUDPGroup(feoupLink);
            self.beginGroupUdpThread();
        }

      

        public override void operate(string msgStr)
        {
            Msg msg = new Msg(msgStr);
            ClientLogs.log("消息类型" + msg.getMsgType());
            if (msg.getMsgType().CompareTo(Msg.MANNYCHAT) == 0 && msg.getMsgContent().CompareTo("UDPCONFIGOK") == 0)
            {

                String groupIP = msg.getIP();
                String groupPort = msg.getPort();
                ClientLogs.log("UDPOK" + msg);
                startOneUdpChat(groupIP, groupPort);
                state = "UDPOK" + msg;
                notifyAll();

            }
            else if (msg.getMsgType().CompareTo(Msg.MANNYCHAT) == 0)
            {
                ClientLogs.log("ChatOp121" + msgStr);
                state = msgStr;
                notifyAll();
            }
            else if (msg.getMsgType().CompareTo(Msg.ONECHAT) == 0)
            {
                ClientLogs.log("ChatOp1221" + msgStr);
                state = msgStr;
                notifyAll();

            }
            else
            {
                ClientLogs.log("111111111type:" + msg.getControlType());
                switch (msg.getControlType()) {
                   
                    default: MainOperate.getInsrance().operate(msgStr); break;
                }
            }
        }
        /* public override void operate(string msg)
        {
            if (sendMode == UDPMODE) {
                state = msg;
                notifyAll();
            }
            Msg.config(msg);
            if (Msg.getMsgType().CompareTo(Msg.ONECHAT)!=0) {
                ClientLogs.log("oanechatop.operate() 不符合处理类型"+Msg.getMsgType());
                return;
            }
            if (Msg.getMsgContent().CompareTo("UDPCHATOK") == 0)
            {
                String ip = Msg.getIP();
                String port = Msg.getPort();
                startOneUdpChat(ip, port);
                sendMode = UDPMODE;
                ClientLogs.log("UDP"+msg);
                state = msg;
                notifyAll();
                return;
            }
             if (Msg.getMsgContent().CompareTo(Msg.ONECHAT) == 0)
            {
                sendMode = TCPMODE;
                state = msg;
                notifyAll();

            }
            else if (Msg.getMsgContent().CompareTo("UDPCONFIG") == 0)
            {
             
                Msg.clear();
                Msg.setMsgType(Msg.ONECHAT);
                Msg.setMsgContent("UDPCONFIGOK");
                Msg.setIP("127.0.0.1");
                Msg.setPort(Convert.ToString(this.UDPPORT));
                Msg.setName(forName);
                self.tcpSend(Msg.getMsg());
                sendMode = TCPMODE;
                state = msg;
                notifyAll();

            }
            else {
                state = msg;
                notifyAll();

            }
        }*/
    }
}
