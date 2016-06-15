using server.logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server.link
{
    /// <summary>
    /// tcp链接 封装
    /// </summary>
    class TcpLinkAdp : Link
    {
        private Socket client;
        private byte[] result = new byte[1024];
        private Encoding defaultEncoding = Encoding.UTF8;//默认编码方式
   
        public TcpLinkAdp(Socket clientSocket)
        {
            this.client = clientSocket;
        }

        public override string receive()
        {
            int size = client.Receive(result);
            String data = defaultEncoding.GetString(result, 0, size);
            ServerLogs.logMoment("接收客户端消息："+data);
            return data;
        }

        public override void send(string msg)
        {
            client.Send(defaultEncoding.GetBytes(msg));
            ServerLogs.logMoment("发送到客户端消息：" + msg);
        }

        public override void send(string msg, Encoding chreast)
        {
            client.Send(chreast.GetBytes(msg));
        }

        internal override void close()
        {
           client.Close();
        }

        internal override string receive(Encoding chreast)
        {
            int size = client.Receive(result);
            String data = chreast.GetString(result, 0, size);
            return data;
        }

        public override string getIP()
        {
            IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;
            return ip.Address.ToString();
        }

        public override String getPort()
        {
            IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;
            return Convert.ToString(ip.Port);
        }
    }
}
