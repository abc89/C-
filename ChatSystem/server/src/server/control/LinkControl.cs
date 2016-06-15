
using server.link;
using SocketServerTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using server.logs;
using server.thread;

namespace server.control
{
    /// <summary>
    /// 链接控制类
    /// </summary>
    class LinkControl
    {
        //聊天控制类
        private static ChatControl control;
        private static byte[] result = new byte[1024];//数据缓存
        private static int myProt = 6633;   //端口  
        private static  Boolean stopLnk = false;

        private Object lockObject = new Object();

        private static Socket serverSocket;
        private static List<Client> clients = new List<Client>();
        private ServerUdpThread serverRecieve;
        public LinkControl(ChatControl control1) {
             control = control1;
        }
        internal List<Client> getClients()
        {
            
            return clients;
        }
        /// <summary>
        /// 启动链接服务
        /// </summary>
        public void beginTcp() {

            string hostName = Dns.GetHostName();//本机名   
            string hostname = Dns.GetHostName();//得到本机名   
            IPHostEntry localhost = Dns.GetHostEntry(hostname);
          //  IPAddress ip = localhost.AddressList[0];

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, myProt));  //绑定IP地址：端口  
            serverSocket.Listen(10);    //设定最多10个排队连接请求  
            ServerLogs.logMoment("启动服务器"+ip+"端口号"+ myProt);
            //通过Clientsoket发送数据  
            Thread myThread = new Thread(ListenClientConnect);
            myThread.Start();

        }
      public void stop() {
     
            try {
                serverSocket.Close();
                serverRecieve.close();
            }
            catch (Exception e) {
                ServerLogs.logMoment("服务监听关闭");
            }
        }
        /// <summary>  
        /// 监听客户端连接  
        /// </summary>  
        private  void ListenClientConnect()
        {
            while (!stopLnk)
            {
                try {
                Socket clientSocket = serverSocket.Accept();
                 ServerTcpThread client = new ServerTcpThread(new TcpLinkAdp(clientSocket),this);
                Thread receiveThread = new Thread(join);
                receiveThread.Start(client);
                }
                catch (Exception e) {
                    ServerLogs.logMoment("退出接收阻塞");
                }
            }
            ServerLogs.logMoment("服务器连接监听线程关闭");
        }

       

        private static void join(object cl)
        {
            ServerTcpThread server = (ServerTcpThread)cl;
            Client client = server.join();
            if (client!=null)
            {
                ChatControl.getInstance().newComeIn(client);
            }
                server.close();
            
        }
        public void beginUdp()
        {
            serverRecieve = new ServerUdpThread(new UdpLinkAdp(UdpLinkAdp.RECIEVE,"127.0.0.1","8080"),this);
            serverRecieve.beginUdpThread();
          //  udpRecieve.

        }
        /*  internal void sendMsg(string text)
          {
              int size = clients.Count;
              for (int i = 0; i < size; i++)
              {
                  Socket client = clients.ElementAt(i);
                  client.Send(Encoding.ASCII.GetBytes(text));
              }
          }*/


    }
}
