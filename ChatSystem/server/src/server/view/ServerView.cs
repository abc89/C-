using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using server.main;
using server.control;

namespace server.view
{
    /// <summary>
    /// 控制界面 与控制类之间 的view 
    /// </summary>
    class ServerView 
    {
        private static  ChatControl control;
        private static ServerFrame form;
        private static ServerView view = new ServerView();

        internal void close()
        {
           ChatControl.getInstance().stop();
        }

        internal void display(string content)
        {
            form.display(content);
        }

        private ServerView()
        {
            

        }
        internal static ServerView getInstance(ServerFrame form1)
        {
            form = form1;
            if(control==null){
                control = ChatControl.getInstance(null);
                control.start();
            }
            return view;
        }

        internal static ServerView getInstance()
        {
            return view;
        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private  void log(String msg)
        {
            form.display(msg);
              
        }

        internal static void Close()
        {
            if (control != null)
            {
                control.stop();
            }
                
        }
    }
}
