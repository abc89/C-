using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.thread;
using server.operate;
using server.logs;
using server.msg;

namespace server.control
{
    class OperateControl
    {
        private Boolean isStart = false;
        private static ChatControl control;
        private List<OperateThread> operates = new List<OperateThread>();
        public OperateControl(ChatControl control1)
        {
            control = control1;
        }

        internal  void addClient(Client client)
        {
            int size = operates.Count;
            for (int i=0;i< size;i++) {
                OperateThread operate = operates.ElementAt(i);
                
                Boolean ok = operate. addNewClient(client);
                if (ok) {
                    ServerLogs.logMoment("用户成功添加到 已存在消息处理线程   线程号为"+operate.getID());
                   return;
                }
            }
            createNewOperateThread(client);
        }

        internal void addNewMsg(Msg msg)
        {
            ServerLogs.logMoment("总控制接收新消息"+msg);
            String operateID = msg.getOperateID();
            foreach (OperateThread opearte in operates) {
                if (operateID.CompareTo(opearte.getID())==0||opearte.hasSessionID(msg)) {
                    opearte.addNewMsg(msg);
                }
            }

        }

        private void createNewOperateThread(Client client)
        {
            OperateThread operate = new OperateThread(this);
            operate.addNewClient(client);
            operate.startOperate();
            operates.Add(operate);
            ServerLogs.logMoment("用户成功添加到 新的消息处理线程   线程号为" + operate.getID());

        }

        internal void removeOperateThread(OperateThread operateThread)
        {
            operates.Remove(operateThread);
        }
    }
}
