using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.operate;
using client.transport;
using System.Windows.Forms;
using client.main;
using client.logs;
using System.Net.Sockets;
using System.Net;

namespace client.view
{
    class MainView : Recive
    {
        private MainOperate operate;
        private SelfMainFrame chatFrame;
        public MainView(SelfMainFrame chatOne1) {
            this.chatFrame = chatOne1;
            
            operate = MainOperate.getInsrance(this);
            operate.start();
        }

        internal void close()
        {
           operate.close();
        }

        public void update()
        {
            String state = operate.getState();
            chatFrame.changeDis(state);
          
        }

        internal void oneChat(string name)
        {
           new ChatOne(operate.getMyName(),name).Show();

        }

        internal string getMyName()
        {
            return operate.getMyName();
        }

        internal void mannyChat()
        {
            new ChatMany(operate.getMyName()).Show();
        }

        internal void test()
        {
            String msg = "asddsa";
            UdpClient client = new UdpClient();
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(msg);
                //向指定的目标IP和端口发送数据
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Convert.ToInt32(8080));
                client.Send(data, data.Length, ep);
            }
            catch (Exception e)
            {
            }
            //关闭连接
            client.Close();

        }
    }
}
