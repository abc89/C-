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
    /// <summary>
    /// 控制类型消息处理类
    /// </summary>
    class ControlMsgOperate : Operate
    {
        /// <summary>
        /// 对外接口
        /// </summary>
        /// <param name="msg">处理消息</param>
        /// <param name="client"></param>
        /// <param name="clients"></param>
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
        /// <summary>
        /// 用户返回在线消息 对应处理方法
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="client"></param>
        private void isAlive(Msg msg, Client client)
        {
            client.reAlive();
        }
        /// <summary>
        /// 处理用户 “添加好友请求”
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="client"></param>
        private void addFriend(Msg msg, Client client)
        {
            String name = client.getName();
            String forName = msg.getMsgContent();
            DataMannage.addFriend(name,forName);
            client.send(msg.getMsg());
        }
        /// <summary>
        /// 处理 “获取好友列表请求”
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="client"></param>
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
        /// <summary>
        /// 处理 “新用户到来”请求
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="client"></param>
        /// <param name="clients"></param>
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
