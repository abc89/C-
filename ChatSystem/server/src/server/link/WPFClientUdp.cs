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
    /// udp链接 封装
    /// </summary>
    class UdpLinkAdp : Link
    {
        private String port;
        private String ip;
        //udp模式 接收 or 发送
        public const int RECIEVE = 0;
        public const int SEND = 1;
        public const int GROUPCHAT = 3;
        private int curMode = 0;
        private UdpClient udpclient;
        public UdpLinkAdp(int mode, String ip1, string port1)
        {
            this.curMode = mode;
            this.port = port1;
            this.ip = ip1;
            if (curMode == RECIEVE)
            {
                int portno = Convert.ToInt32(port);
                udpclient = new UdpClient(portno);

            }
        }
      
        public override string receive()
        {
            return null;
        }

        public override void send(String msg)
        {

            //指定555端口发送UDP数据(留空为随机端口)
            UdpClient client = new UdpClient();
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(msg);
                //向指定的目标IP和端口发送数据
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt32(port));
                client.Send(data, data.Length, ep);
            }
            catch (Exception e)
            {
            }
            //关闭连接
            client.Close();
        }



        public override void send(string msg, Encoding Chreast)
        {
            throw new NotImplementedException();
        }

        internal override void close()
        {
            if (udpclient != null)
            {
                udpclient.Close();
            }
        }

        public String receive(IPEndPoint myhost)
        {
            byte[] data = udpclient.Receive(ref myhost);
            string msg = Encoding.UTF8.GetString(data, 0, data.Length);
            return msg;

        }

        internal override string receive(Encoding Chreast)
        {
            throw new NotImplementedException();
        }

        public override string getIP()
        {
            return ip;
        }

        public override string getPort()
        {
           return port;
        }
    }
}
