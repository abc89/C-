using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.transport;
using client.view;
using System.Threading;
using client.data;
using client.msg;
using client.logs;

namespace client.operate
{
    /// <summary>
    /// 主界面操作
    /// </summary>
    class MainOperate : Operate
    {
        private String myName = "myName";
        private static MainOperate mainOperate = new MainOperate();
        private Boolean stopThread = false;
        private ClientThread self;
        private String state;
        internal string getState()
        {
            return state;

        }

        internal static MainOperate getInsrance()
        {
            return mainOperate;
        }

        internal void close()
        {
            self.close();
        }

        internal string getMyName()
        {
            return self.getName();
        }

        private MainOperate()
        {
        }

        internal static MainOperate getInsrance(MainView view)
        {
            mainOperate.attach(view);
            OperateMannager.changeOperateMode(OperateMannager.CHATOPERATE);
            mainOperate.self = LoginOperate.getInstance().getSelf();
            mainOperate.myName = LoginOperate.getInstance().getUerName();
            return mainOperate;
        }

        private void link()
        {
            self.beginUdpThread();
        }

        public void start()
        {
            link();
            // Thread receiveThread = new Thread(begin);
            // receiveThread.Start();
            begin();
        }
        /// <summary>
        /// 启动新线程 避免UI线程中控件未能初始化
        /// </summary>
        private void begin()
        {
            //等待UI线程 UI控件初始化完毕
            while (self.udpIsStart()) {
                Thread.Sleep(100);
            }
            Msg msg = new Msg();
            String str = msg.getMyNewClient(myName);
            msg.config(str);
        //    ClientLogs.log("发送新等级");
            self.udpSend(msg);
            Thread.Sleep(100);
            //若为延时，接收方 tcp缓冲区 同时存储两条信息，进程读取时 一次读取两条数据 msg=第一条+第二条
            msg.clear();
            String myFw = msg.getMyFriends(myName);
            msg.config(myFw);
         //   ClientLogs.log("发送或朋友");
            self.udpSend(msg);
        }
        public void stop()
        {

            this.stopThread = true;
        }


        public override void attach(Recive recive)
        {
            recives.Add(recive);
        }

        public override void operate(string msgStr)
        {
            Msg msg = new Msg(msgStr);
            ClientLogs.log("oprate   " + msgStr);
            if (msg.getMsgType().CompareTo(Msg.CONTROL) == 0)
            {
                switch (msg.getControlType())
                {
                    case Msg.ContentType.NEWCLIENT: newClientComeIn(msgStr); break;
                    case Msg.ContentType.GETMYFRIENDS: getMyFriends(msgStr); break;
                    case Msg.ContentType.ADDFRIEND: addMyFriends(msgStr); break;
                    case Msg.ContentType.ISALIVE:isAlive(); break;
                    default: ClientLogs.log("MainOperae.operate() 没有对应 contntTyep" + msg.getMsgContent() + " 处理方法"); break;
                }
            }

        }

        private void isAlive()
        {
            Msg msg = new Msg();
            msg.setMsgType(Msg.CONTROL);
            msg.setControlType(Msg.ContentType.ISALIVE);
            self.udpSend(msg);
        }

        private void addMyFriends(String str)
        {
            Msg msg = new Msg(str);
            msg.setControlType(Msg.ContentType.GETMYFRIENDS);
            MyFriends.addOnline(msg.getMsgContent());
            ClientLogs.log("添加新好友" + msg.getMsg());
            state = "fzgx";
            notifyAll();
        }

        private void getMyFriends(string msgStr)
        {
            Msg msg = new Msg(msgStr);
            String[] friends = msg.getMsgContents();
            ClientLogs.log("getFriend" + msgStr + "friend:" + msg.getMsgContent() + "长度" + friends.Length);
            int size = friends.Length;
            for (int i = 0; i < size; i++)
            {
                if (PersonDataSet.contain(friends[i]))
                {
                    MyFriends.addOnline(friends[i]);
                }
                else {
                    MyFriends.addNoline(friends[i]);
                    ClientLogs.log("离线getFriend");
                }
             
            }
                ClientLogs.log("getFriend");
                state = "fzgx";
                notifyAll();
        }

        private void newClientComeIn(string msgStr)
        {
            Msg msg = new Msg(msgStr);

            msg.config(msgStr);
            String name = msg.getName();
            ClientLogs.log("newClient" + msg.getMsg());
            if (!PersonDataSet.contain(name) && name.CompareTo(myName) != 0)
            {
                ClientLogs.log("新人：" + msg.getName());
                PersonDataSet.add(name);
                if (MyFriends.nolineContain(name)) {
                    MyFriends.removeNoline(name);
                    MyFriends.addOnline(name);
                }
                state = "fzgx";
                notifyAll();
                msg.clear();
                msg.setMsgType(Msg.CONTROL);
                msg.setName(myName);
                msg.setControlType(Msg.ContentType.NEWCLIENT);
                self.udpSend(msg);
            }
            else if (name.CompareTo(myName) == 0)
            {
                self.setOperateID(msg);
            }
        }
    }
}
