using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using client.transport;
namespace client.view
{
    /// <summary>
    /// 
    /// 逻辑界面类
    /// </summary>
    class View : Recive
    {
        /*  //主面板实例
          private MainFrame form;
          //socket 状态观察类实例
          private static ChatClientRS chatClientRS = new ChatClientRS();
          private static byte[] result = new byte[1024];
          //是否已经链接
          private Boolean hasLink = false;
          private Boolean stop = false;
          private String IP="127.0.0.1";
          private String PORT;
          public View(MainFrame form1) {
              this.form = form1;
              chatClientRS.attach(this);
          }
          public View() {

          }
          /// <summary>
          /// 
          /// 状态更新
          /// </summary>
          public void update()
          {
              String content = chatClientRS.getState();
              form.ReciveMsg("接收到信息：  " + content);
          }
          /// <summary>
          /// 
          /// 检查将要链接ip 端口号等是否正确
          /// </summary>
          /// <param name="ip1">ip地址</param>
          /// <param name="port1">端口号 小于65535</param>
          /// <returns></returns>
          internal Boolean checkLinkContent(string ip1, string port1)
          {
              if (ip1.CompareTo("") == 0 || port1.CompareTo("") == 0) {
                  return false;
              }
              this.IP = ip1; ;
              this.PORT = port1;
              return true;
          }
          /// <summary>
          /// 
          /// 链接服务器
          /// </summary>
          internal void startLink()
          {
              this.form.ReciveMsg("连接服务器"+IP+":"+PORT+"中");
              Boolean link = linkServer();
              if (link) {
                  hasLink = true;
                  Thread myThread = new Thread(recive);
                  myThread.Start();
                }

          }
          private  Boolean linkServer()
          {
              //设定服务器IP地址  
              try
              {
              IPAddress ip = IPAddress.Parse(this.IP);
              int port = int.Parse(PORT);
              Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                  clientSocket.Connect(new IPEndPoint(ip, port)); //配置服务器IP与端口  
                  chatClientRS.setContent(clientSocket);
                  this.form.ReciveMsg("连接服务器成功");
                  return true;
              }
              catch(Exception e)
              {
                  this.form.ReciveMsg("连接服务器失败"+e.ToString());
                  return false;
              }

          }

          internal bool isOpenLink()
          {
             return hasLink;
          }

          public void recive() {
              //通过clientSocket接收数据  
              while (!stop) {
                  try
                  {
                      Thread.Sleep(1000);    //等待1秒钟 
                      chatClientRS.Receive();
                  }
                  catch
                  {
                      chatClientRS.close();
                  }

              }
          }
          /// <summary>
          /// 
          /// 关闭连接
          /// </summary>
          internal void close()
          {
              if (!hasLink) {
                  return;
              }
              hasLink = false;
              stop = true;
              chatClientRS.close();
          }

          internal Boolean sendMsg(string text)
          {
              if (!hasLink) {
                  return false;
              }
              chatClientRS.sendMsg(text);
              return true;
          }*/
        public void update()
        {
            throw new NotImplementedException();
        }
    }
}
