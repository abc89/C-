using server.link;
using server.logs;
using server.msg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.thread
{
    /// <summary>
    /// 已登录 用户类
    /// </summary>
    class Client
    {
        //用户属性
        private int alive = 0;//存活判断
        private String port;
        private String ip;
        private String sessionID;
        private String operateID;
        private String name;
        /// <summary>
        /// 存活判断
        /// </summary>
        /// <returns></returns>
        internal bool isAlive()
        {
            if (alive>=5) {
                ServerLogs.logMoment("用户："+name+" 离线 ");
                return false;
            }
            alive++;
            ServerLogs.logMoment("用户：" + name + " 在线 ");
            Msg msg = new Msg();
                msg.setMsgType(Msg.CONTROL);
                msg.setControlType(Msg.ContentType.ISALIVE);
            send(msg.getMsg());
            return true;
        }
        /// <summary>
        /// 心跳包 客户已接收
        /// 重设置 存活 活力
        /// </summary>
        internal void reAlive()
        {
            this.alive = 0;
        }
        /// <summary>
        /// 设置 会话 sessionid
        /// </summary>
        /// <param name="v"></param>
        internal void setSessionID(string v)
        {
            this.sessionID = v;
        }
        /// <summary>
        /// 获取用户ip
        /// </summary>
        /// <param name="v"></param>
        internal void setIP(string v)
        {
            this.ip = v; ;
        }
        /// <summary>
        /// 设置用户接受udp数据端口
        /// </summary>
        /// <param name="v"></param>
        internal void setPort(string v)
        {
           this.port=v;
        }
        /// <summary>
        /// 用户名设置
        /// </summary>
        /// <param name="v"></param>
        internal void setName(string v)
        {
            this.name = v; ;
        }
        /// <summary>
        /// 发送udp数据
        /// </summary>
        /// <param name="v"></param>
        internal void send(string v)
        {
            UdpLinkAdp udp = new UdpLinkAdp(UdpLinkAdp.SEND,ip,port);
            udp.send(v);
            ServerLogs.logMoment("发送消息"+v+"ip:"+ip+"port"+port);
        }

        internal String getName()
        {
            return name;
        }

        internal String getSessionID()
        {
             return sessionID;
        }

     
    }
}
