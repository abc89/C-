using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// 消息传输异常 ： 发送消息格式异常 or 接收消息格式不符合当前处理行为所接受的数据格式
/// </summary>
namespace client.exception
{
    class MsgException : Exception
    {
       public  enum MsgExcepType {
            MSGFORMATEXP,MSGNULLEXP,
            LINKISNULL,
        }
        private MsgExcepType curType;
        private String content;//异常信息补充说明
        public MsgException(MsgExcepType type,String content1) {
            this.curType = type;
            this.content = content1;
        }
        public String toString() {
            String expMsg="异常消息";
            switch (curType) {
                case MsgExcepType.MSGFORMATEXP:expMsg = "消息格式不符合当前处理行为"+content;break;
                case MsgExcepType.MSGNULLEXP:expMsg = "消息为空：null" ; break;
                case MsgExcepType.LINKISNULL: expMsg = "链接实例：null"; break;
            }
            return expMsg;
        }
    }
}
