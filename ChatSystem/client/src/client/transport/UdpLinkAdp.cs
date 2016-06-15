using client.logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client.transport
{
    class UdpLinkAdp : Link
    {
        private String port;
        private String ip="127.0.0.1";
        //udp模式 接收 or 发送
        public const int RECIEVE = 0;
        public const int SEND =1;
        public const int GROUPCHAT = 3;
        private int curMode =0;
        private UdpClient udpclient;
        public UdpLinkAdp(int mode, string port)
        {
            this.curMode = mode;
            this.port = port;
            if (curMode == RECIEVE)
            {
                int portno = Convert.ToInt32(port);
                udpclient = new UdpClient(portno);

            }
        }
        public UdpLinkAdp(int mode, String ip,string port)
        {
            this.curMode = mode;
            this.port = port;
            this.ip = ip;
            if (curMode == RECIEVE)
            {
                int portno = Convert.ToInt32(port);
                udpclient = new UdpClient(portno);

            }
            else if (curMode == GROUPCHAT) {
                int portno = Convert.ToInt32(port);
                udpclient = new UdpClient(portno);
                //根据设定加入组播地址            
                   udpclient.JoinMulticastGroup(IPAddress.Parse(ip), 16);
                
            }
        }
        public String receive(IPEndPoint myhost) {
            byte[] data = udpclient.Receive(ref myhost);
            string msg = Encoding.UTF8.GetString(data, 0, data.Length);
            return msg;

        }


        public override void  send(String msg) {
            
            ClientLogs.log("UdpLinkAdp发送消息"+msg+"ip:"+ip+"port"+port);
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
                ClientLogs.log(e.ToString());
            }
            //关闭连接
            client.Close();
        }
       
    
/*
        public override void send(string msg, Encoding Chreast)
        {
            throw new NotImplementedException();
        }
        */
        internal override void close()
        {
            if (udpclient!=null) {
                udpclient.Close();
            }
        }

    

      /*  internal override string receive(Encoding Chreast)
        {
            throw new NotImplementedException();
        }
        */
        public override string receive()
        {
            throw new NotImplementedException();
        }
    }
}
