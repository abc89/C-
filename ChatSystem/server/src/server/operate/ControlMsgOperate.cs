using server.operate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.msg;
using server.control;
using server.logs;
using server.dao;
using server.thread;

namespace server.operate
{
    class ControlMsgOperate : Operate
    {
        internal override void operate(Msg msg, Client client, List<Client> clients)
        {
            String type = msg.getControlType();
            switch (type) {
                case Msg.ContentType.NEWCLIENT:newClientCome(msg,client, clients);break;
                case Msg.ContentType.GETMYFRIENDS:getMyFriends(msg,client); break;
                case Msg.ContentType.ADDFRIEND: addFriend(msg, client); break;
                case Msg.ContentType.ISALIVE: isAlive(msg, client); break;
                default: ServerLogs.logMoment("控制类信息 没有对应 msgContent"+type+"处理方法");break;
            }
        }

        private void isAlive(Msg msg, Client client)
        {
            client.reAlive();
        }

        private void addFriend(Msg msg, Client client)
        {
            String name = client.getName();
            String forName = msg.getMsgContent();
            DataMannage.addFriend(name,forName);
            client.send(msg.getMsg());
        }

        private void getMyFriends(Msg msg, Client client)
        {
            List<String> friends=DataMannage.getFriends(msg.getName());
            msg.clear();
            msg.setMsgType(Msg.CONTROL);
            msg.setName(msg.getName());
            msg.setControlType(Msg.ContentType.GETMYFRIENDS);
            msg.setMsgContents(friends);
            client.send(msg.getMsg());
        }

        private void newClientCome(Msg msg, Client client,List<Client> clients)
        {
            String name = client.getName();
            int size = clients.Count;
            for (int i = 0; i < size; i++)
            {
                clients.ElementAt(i).send(msg.getMsg());
            }
        }

    }
}
