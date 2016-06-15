using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.msg
{
    class IdentifyMsg
    {
        private enum MsgContent
        {
            msgType, password, name, sessionID, operateID,msgID,port
        }
        public const String LOGINOK = "3";
        public const String LOGINIDENTIFY = "0";
        public const String REGIST = "1";
        private static int msgLength = 11;
        private static  String[] msgs = new String[msgLength];
        public static void clear()
        {
            for (int i = 0; i < msgLength; i++)
            {
                msgs[i] ="null";
            }
        }
        public static void config(String msg)
        {
            clear();
            clear();
            if (msg.IndexOf('&') == -1)
            {
                return;
            }
            String[] ms = msg.Split('&');
            for (int i = 0; i < msgLength; i++)
            {
                msgs[i] = ms[i];
            }
        }
        public static  void setPort(String value)
        {
            msgs[(int)MsgContent.port] = value;
        }
        public static String getPort()
        {
           return msgs[(int)MsgContent.port] ;
        }
        public static void setSessionID(String id)
        {

            msgs[(int)MsgContent.sessionID] = id;
        }
        public static String getSessionID()
        {

            return msgs[(int)MsgContent.sessionID];
        }
        public static void setMsgID(String msgID)
        {

            msgs[(int)MsgContent.msgID] = msgID;
        }
        public static  String getMsgID()
        {

            return msgs[(int)MsgContent.msgID];
        }
        public static void setOperateID(String id)
        {

            msgs[(int)MsgContent.operateID] = id;
        }
        public static String getOperateID()
        {

            return msgs[(int)MsgContent.operateID];
        }
        public static  String getMsgType()
        {
            return msgs[(int)MsgContent.msgType];
        }
        public static void setMsgType(String type)
        {
            msgs[(int)MsgContent.msgType] = type;
        }
              public static String getPassword()
        {
            return msgs[(int)MsgContent.password];
        }
        public static void setPassword(String psd)
        {
            msgs[(int)MsgContent.password] = psd;
        }
        public static void setName(String value)
        {
            msgs[(int)MsgContent.name] = value;
        }



        public static String getName()
        {
            return msgs[(int)MsgContent.name];
        }

        public static String getMsg()
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
