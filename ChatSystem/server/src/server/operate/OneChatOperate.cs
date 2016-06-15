using SocketServerTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.logs;
using server.msg;
using server.thread;

namespace server.operate
{
    /// <summary>
    /// 单用户操作
    /// </summary>
    class OneChatOperate : Operate
    {
        private static IDictionary<String, String> pds = new Dictionary<string, string>();
        private static List<String> keyNames = new List<string>();
     
        internal override void operate(Msg msg, Client client, List<Client> clients)
        {
            Client clientf = selectCleint(msg, clients);
            if (clientf != null)
            {
                oneToOneChat(msg, client, clientf);
            }
            else
            {
                ServerLogs.logMoment("没有找到对应单聊人称" + msg.getName());
            }
        }
        /// <summary>
        /// 建立双方 UDP 实时通信
        /// </summary>
        /// <param name="msgs">消息类实例：客户端发送单聊消息</param>
        /// <param name="client">发送方</param>
        /// <param name="clientf">消息处理后的接收方</param>
        private void oneToOneChat(Msg msg, Client client, Client clientf)
        {
            clientf.send(msg.getMsg());
        }
       /* /// <summary>
        /// 建立双方 UDP 实时通信
        /// </summary>
        /// <param name="msgs">消息类实例：客户端发送单聊消息</param>
        /// <param name="client">发送方</param>
        /// <param name="clientf">消息处理后的接收方</param>
        private void oneToOneChat(Msg msg,ClientThread client, ClientThread clientf)
        {
            //    clientf.send("oneChat&"+port);
            if (msg.getMsgContent().CompareTo("UDPCONFIGOK")==0) {
                String port = msg.getPort();
                String ip = client.getIP();
                msg.clear();
                msg.setMsgContent("UDPCHATOK");
                msg.setMsgType(Msg.ONECHAT);
                msg.setPort(port);
                msg.setIP(ip);
                msg.setName(clientf.getName());
                clientf.send(msg.getMsg());
                ServerLogs.logMoment(msg.getMsg());
                return;
            }
            String key = client.getName();
            String value = clientf.getName();
            String readyV = getAddr(value);//对方是否同时打开与 对自己单聊的对话框
            if (readyV != null&&readyV.CompareTo(key)==0)
            {
                if (!pds.ContainsKey(key))
                {
                    add(key, value);

                }
                msg.clear();
                msg.setMsgType(Msg.ONECHAT);
                msg.setMsgContent("UDPCONFIG");
                client.send(msg.getMsg());
                clientf.send(msg.getMsg());
               // String ip = client.getIP();
               // clientf.send(msg.getMsgType() + "&" + key + ip + "&" + msg.getName() + "&" + msg.getMsgContent());
            }
            else
            {
                if (!pds.ContainsKey(key)) {
                     add(key,value);

                }
                String ip = client.getIP();
                clientf.send(msg.getMsgType() + "&" + key+ip+"&" + msg.getName() + "&" + msg.getMsgContent() + "&" + "未同时打开");
            }
         
        }*/

        private Client selectCleint(Msg msg, List<Client> clients)
        {
            String name = msg.getName();
            ServerLogs.logMoment("挑选"+name);
            int size = clients.Count;
            for (int i=0;i< size;i++) {
                Client client = clients.ElementAt(i);
                ServerLogs.logMoment("挑选" + client.getName());
                if (client.getName().CompareTo(name) ==0) {
                    return client;
                }
            }
            return null;
        }
        public static void add(String userName, String addr)
        {
            pds.Add(userName, addr);
        }
        public static String getAddr(String userName)
        {
            String adr = null;
            if (pds.ContainsKey(userName))
            {
                adr = pds[userName];
            }
            return adr;
        }

        public static List<String> getNames()
        {
            keyNames.Clear();
            if (pds.Count > 0)
            {
                int size = pds.Count;
                for (int i = 0; i < size; i++)
                {
                    keyNames.Add(pds.ElementAt(i).Key);
                }
            }
            return keyNames;

        }
    }
}
