using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.exception
{
    /// <summary>
    /// 服务器端处理异常类
    /// 
    /// </summary>
    class ServerException : Exception
    {
        public enum ServerExcepType
        {
            CLIENTSEMPTY, MSGNULL,
            MSGOPERSTEEXCEPTION,
        }
        private ServerExcepType curType;
        private String content;//异常信息补充说明
        public ServerException(ServerExcepType type, String content1)
        {
            this.curType = type;
            this.content = content1;
        }
        public String toString()
        {
            String expMsg = "异常消息";
            switch (curType)
            {
                case ServerExcepType.CLIENTSEMPTY: expMsg = "客户链接集合为空" + content; break;
                case ServerExcepType.MSGNULL: expMsg = "消息为空：null"; break;
                case ServerExcepType.MSGOPERSTEEXCEPTION: expMsg = "处理数据不符合"; break;
            }
            return expMsg;
        }
    }
}
