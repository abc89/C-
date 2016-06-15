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
    class Client
    {
        private int alive = 0;
        private String port;
        private String ip;
        private String sessionID;
        private String operateID;
        private String name;
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
        internal void reAlive()
        {
            this.alive = 0;
        }
        internal void setSessionID(string v)
        {
            this.sessionID = v;
        }

        internal void setIP(string v)
        {
            this.ip = v; ;
        }

        internal void setPort(string v)
        {
           this.port=v;
        }

        internal void setName(string v)
        {
            this.name = v; ;
        }

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
