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
using server.Dao;

namespace server.operate
{
    class OperateThread
    {
        private List<Client> clients = new List<Client>();
        private int MAXNUM = 10;
        private Boolean stopThread = false;
        private static int  operateID=0;
        private String ID;
        private Queue<Msg> msgs = new Queue<Msg>();
        private OperateMannager opMannager=new OperateMannager();
        private OperateControl operateControl;
        private OperateControl control;
        public OperateThread(OperateControl operateControl) {
            this.ID = Convert.ToString(operateID);
            operateID++;
            this.control = operateControl;
        }

    

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

        internal void startOperate()
        {          
                this.stopThread = false;
                Thread receiveThread = new Thread(operateTh);
                receiveThread.Start();
        }
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

        internal bool hasSessionID(Msg msg)
        {
            foreach (Client client in clients)
            {
                if (client.getSessionID().CompareTo(msg.getSessionID())==0)
                {
                    return true;
                }
            }
            return false;
        }

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
