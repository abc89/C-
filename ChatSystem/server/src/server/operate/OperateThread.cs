using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.thread;
using System.Threading;
using server.msg;
using server.logs;
using server.control;
using SocketServerTest;
using server.dao;

namespace server.operate
{
    /// <summary>
    /// 用户请求处理线程
    /// </summary>
    class OperateThread
    {
        //当前处理线程负责 处理 的客户集合
        private List<Client> clients = new List<Client>();
        //对应用户集合 的处理消息
        private Queue<Msg> msgs = new Queue<Msg>();
        private int MAXNUM = 10;//最大处理用户数目
        private Boolean stopThread = false;
        private static int  operateID=0;
        private String ID;//当前处理线程ID号
        private OperateMannager opMannager=new OperateMannager();//消息处理分配类
        private OperateControl control;//线程处理类 控制
        public OperateThread(OperateControl operateControl) {
            this.ID = Convert.ToString(operateID);
            operateID++;
            this.control = operateControl;
        }

    
        /// <summary>
        /// 添加新处理用户
        /// </summary>
        /// <param name="client">新用户类</param>
        /// <returns>true： 添加成功   false:添加失败： 当前处理线程已达最大处理用户数</returns>
        internal bool addNewClient(Client client)
        {
            if (clients.Count>MAXNUM) {
                return false;
            }
            clients.Add(client);
            return true;
        }

        internal String getID()
        {
            return ID;
        }
        /// <summary>
        /// 启动当前树立线程
        /// </summary>
        internal void startOperate()
        {          
                this.stopThread = false;
                Thread receiveThread = new Thread(operateTh);
                receiveThread.Start();
        }
        /// <summary>
        /// 处理线程 方法
        /// </summary>
        void operateTh()
        {
            int alive = 0;
            while (!stopThread)
            {
                if (msgs.Count >= 1)
                {
                    Msg msg = msgs.Dequeue();
                    ServerLogs.logMoment("处理新消息"+msg.getMsg());
                    startOperate(msg);
                
                }
                    Thread.Sleep(50);
                    alive++;
                if (alive>=20) {
                    isAlives();
                    alive = 0;
                }
                
            }
        }
        /// <summary>
        /// 消息中的用户sessionId，是否对应当前处理线程
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        internal bool hasSessionID(Msg msg)
        {
            foreach (Client client in clients)
            {
                //遍历处理用户集合中的sessionID 是否符合消息中的sessionID
                if (client.getSessionID().CompareTo(msg.getSessionID())==0)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 扫描处理用户集合 是否有用户离线
        /// </summary>
        private void isAlives()
        {
         
            ServerLogs.logMoment("扫描用户是否离线");
            List<Client> noLines = new List<Client>();
            foreach (Client client in clients) {
                if (!client.isAlive()) {
                    noLines.Add(client);
                }
            }
            foreach(Client client in noLines) {      
            clients.Remove(client);
                PersonDataSet.remove(client.getName());         
            }
            if (clients.Count<=0) {
                stopThread = true;
                ServerLogs.logMoment("移除空闲处理线程");
                control.removeOperateThread(this);
            }
        }

        internal void addNewMsg(Msg msg)
        {
            ServerLogs.logMoment("队列添加新消息"+msg);
            this.msgs.Enqueue(msg);
        }
        //处理属于当前 用户集合 消息
        private void startOperate(Msg msg)
        {
            foreach (Client client in clients) {
                if (client.getSessionID().CompareTo(msg.getSessionID())==0) {
                    msg.setOperateID(ID);
                    opMannager.operateChatMsg(client,msg,clients);

                }
            }
        }
    }
}
