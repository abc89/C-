
using server.control;
using server.exception;
using server.logs;
using server.msg;
using server.thread;
using SocketServerTest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace server.operate
{
    /// <summary>
    /// 消息处理 分配
    /// </summary>
    internal class OperateMannager
    {
        private OperateThread operateThread;
        private static void oprateChatMsg(Msg msg,Operate operate, Client client,List<Client> clients) {
            operate.operate( msg,client, clients);
        }
        /// <summary>
        /// 消息处理方法
        /// </summary>
        /// <param name="client"> 请求操作用户 链接实例</param>
        /// <param name="msg">请求数据</param>
        /// <returns>true: operate ok</returns>
        public  Boolean  operateChatMsg(Client client,Msg msg, List<Client> clients)
        {
            Boolean operateFlag = true;
            String[] msgs;
            try {
               cherck(msg);
            }
            catch (Exception e) {
                operateFlag = false;
                ServerLogs.logMoment("消息不符合处理操作 operaeChatMsg() :"+msg.getMsg()+"  "+msg.getMsgType());
                return false;
            }
      
            switch (msg.getMsgType()) {
                case Msg.ONECHAT: oprateChatMsg(msg, new OneChatOperate(),client,clients); break;
                case Msg.MANNYCHAT: oprateChatMsg(msg, new MannyChatOperate(), client, clients); break;
                case Msg.CONTROL: oprateChatMsg(msg, new ControlMsgOperate(), client, clients); break;
                default: ServerLogs.logMoment("用户动作异常，没有对应处理操作");operateFlag = false ; break;
            }
            return operateFlag;
        }

     
        /// <summary>
        /// 处理数据格式是否符合处理操作要求
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        private static void cherck(Msg msg)
        {
          
            if (msg.getMsgType().CompareTo("null")==0) {
                throw new ServerException(ServerException.ServerExcepType.MSGOPERSTEEXCEPTION,"OperateMannager.check()");
            }
        }

     
    }
}