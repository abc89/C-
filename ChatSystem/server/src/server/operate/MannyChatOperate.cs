using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using server.msg;
using server.logs;
using server.thread;

namespace server.operate
{/// <summary>
/// 多人组播聊天
/// </summary>
    class MannyChatOperate : Operate
    {
        private static IDictionary<String, String> pds = new Dictionary<string, string>();
        private static List<String> keyNames = new List<string>();
        private String groupIp= "224.0.0.100";//组播ip
        private String groupPort="3033";//组播端口号
        internal override void operate(Msg msg, Client client, List<Client> clients)
        {
           
                mannyChat(msg, client);
          
        }
        /// <summary>
        /// 建立双方 UDP 实时通信
        /// </summary>
        /// <param name="msgs">消息类实例：客户端发送单聊消息</param>
        /// <param name="client">发送方</param>
        /// <param name="clientf">消息处理后的接收方</param>
        private void  mannyChat(Msg msg, Client client)
        {
            //    clientf.send("oneChat&"+port);
            if (msg.getMsgContent().CompareTo("UDPCONFIG") == 0)
            {
                msg.clear();
                msg.setMsgContent("UDPCONFIGOK");
                msg.setMsgType(Msg.MANNYCHAT);
                msg.setPort(groupPort);
                msg.setIP(groupIp);
              
                client.send(msg.getMsg());
                ServerLogs.logMoment(msg.getMsg());
                return;
            }
           
        }

       /* private ClientThread selectCleint(Msg msg, List<ClientThread> clients)
        {
            String name = msg.getName();
            ServerLogs.logMoment("挑选" + name);
            int size = clients.Count;
            for (int i = 0; i < size; i++)
            {
                ClientThread client = clients.ElementAt(i);
                ServerLogs.logMoment("挑选" + client.getName());
                if (client.getName().CompareTo(name) == 0)
                {
                    return client;
                }
            }
            return null;
        }*/
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

