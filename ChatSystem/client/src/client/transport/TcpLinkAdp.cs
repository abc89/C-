using client.logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client.transport
{
    /// <summary>
    /// tcp链接
    /// </summary>
    class TcpLinkAdp : Link
    {
        private Socket client;//客户端 套接字实例
        private byte[] result = new byte[1024];//接收数据 缓存数组
        private Encoding defaultEncoding = Encoding.UTF8;//默认编码方式
        public TcpLinkAdp(Socket clientSocket)
        {
            this.client = clientSocket;
        }

        public override string receive()
        {
            int size = client.Receive(result);
            String data = defaultEncoding.GetString(result, 0, size);
            return data;
        }

        public override void send(string msg)
        {
            client.Send(defaultEncoding.GetBytes(msg));
        }

    /*    public override void send(string msg, Encoding chreast)
        {
            client.Send(chreast.GetBytes(msg));
        }*/

        internal override void close()
        {
            if (client!=null) {
                client.Close();
            }
        }

    /*    internal override string receive(Encoding chreast)
        {
            int size = client.Receive(result);
            String data = chreast.GetString(result, 0, size);
            return data;
        }*/

    }
}
