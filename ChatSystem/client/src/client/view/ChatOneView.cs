using client.main;
using client.transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.operate;
using client.data;
using client.msg;
using client.logs;

namespace client.view
{
    /// <summary>
    /// 聊天界面与 聊天处理类之间的view
    /// </summary>
    class ChatView : Recive
    {
        
        private Frame frame;
        private ChatOperate operate;
        private String forName;
    
        public ChatView(Frame chatOne)
        {
            this.frame = chatOne;
            this.operate = ChatOperate.getInstance(this);
            OperateMannager.changeOperateMode(OperateMannager.ONEOPERATE);
        }

        internal void configMannyChat()
        {
            operate.configMannyChat();
        }

        public void update()
        {
            String state = operate.getState();
            ClientLogs.log("chatOneView"+state);
           this.frame.changeDis(state);
        }

        internal void oneChat(string name)
        {
          
            this.forName = name;
        }

        internal void sendMannyContent(string content)
        {

            Msg msg=new Msg();
            msg.setMsgType(Msg.MANNYCHAT);
            msg.setMsgContent(content);
            operate.send(ChatOperate.MANNYCHATOK, msg);
        }
        internal void sendOneContent(string content)
        {
            Msg msg = new Msg();
            msg.setMsgType(Msg.ONECHAT);
            msg.setName(forName);
            msg.setMsgContent(content);
            operate.send(ChatOperate.ONECHAT, msg);
        }

        internal void addFriend(string forName)
        {
            if (MyFriends.onlineContain(forName)||MyFriends.nolineContain(forName))
            {
                frame.warnMsg("已添加为好友");
                
            }
            else
            {
                Msg msg = new Msg();
                msg.setMsgType(Msg.CONTROL);
                msg.setControlType(Msg.ContentType.ADDFRIEND);
                msg.setMsgContent(forName);
                operate.send(ChatOperate.ONECHAT, msg);
               
            }
        }
    }
}
