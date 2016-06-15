using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.msg
{
    /// <summary>
    /// TCP消息验证 数据格式
    /// </summary>
    class IdentifyMsg { 
     private enum MsgContent
    {
       msgType,password,name, sessionID, operateID,msgID, port
        }
        public const String LOGINOK = "3";
        public const String LOGINIDENTIFY = "0";
        public const String REGIST = "1";
        private static int msgLength = 11;
    private String[] msgs = new String[msgLength];
        public IdentifyMsg(String type, String uerName, String password)
        {
            msgs[(int)MsgContent.msgType] = type;
            msgs[(int)MsgContent.name] = uerName;
            msgs[(int)MsgContent.password] = password;
        }

        internal String getPassword()
        {
            return msgs[(int)MsgContent.password];
        }
        public void setPort(String value)
        {
            msgs[(int)MsgContent.port] = value;
        }
        public String getPort()
        {
            return msgs[(int)MsgContent.port];
        }
        public IdentifyMsg(String msg)
        {
            String[] ms = msg.Split('&');
            for (int i = 0; i < msgLength; i++)
            {
                msgs[i] = ms[i];
            }
        }
        public void setSessionID(String id)
        {

            msgs[(int)MsgContent.sessionID] = id;
        }
        public String getSessionID()
        {

            return msgs[(int)MsgContent.sessionID];
        }
        public void setOperateID(String id)
        {

            msgs[(int)MsgContent.operateID] = id;
        }
        public String getOperateID()
        {

            return msgs[(int)MsgContent.operateID];
        }
        public void config(String msg)
    {
        String[] ms = msg.Split('&');
        for (int i = 0; i < msgLength; i++)
        {
            msgs[i] = ms[i];
        }
    }
    public String getMsgType()
    {
       
        return msgs[(int)MsgContent.msgType];
    }

        public void setMsgType(String type)
        {

            msgs[(int)MsgContent.msgType]=type;
        }

        public void setMsgID(String id)
        {

            msgs[(int)MsgContent.msgID] = id;
        }

        public String getName()
    {
        return msgs[(int)MsgContent.name];
    }
   
    public String getMsg()
    {
        String msg = msgs[0];
        for (int i = 1; i < msgLength; i++)
        {
            msg = msg + "&" + msgs[i];
        }
        return msg;
    }
}
}
