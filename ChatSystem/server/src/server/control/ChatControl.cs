using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.view;
using server.logs;
using server.thread;
using server.msg;

namespace server.control
{
    /// <summary>
    /// 聊天控制器
    /// </summary>
    class ChatControl
    {
        //单例：聊天控制器
        private static ChatControl control = new ChatControl();
        private Boolean isStart = false;
        private OperateControl operateControl;
        private LinkControl linkControl;
        internal static ChatControl getInstance()
        {
            return control;
        }
        public void stop() {
            if (isStart) {
                linkControl.stop();
            }
        }
        public void newComeIn(Client client)
        {
            operateControl.addClient(client);
        }
        public  void addNewMsg(Msg msg) {
            operateControl.addNewMsg(msg);
        }
        private ChatControl() { }
        internal static ChatControl getInstance(View view)
        {
          return control;
        }
    
        /// <summary>
        /// 聊天控制器开启
        /// </summary>
        public void start() {
            operateControl = new OperateControl(this);
            linkControl = new LinkControl(control);
            ServerLogs.logMoment("开始服务");
            linkControl.beginUdp();
            linkControl.beginTcp();
            isStart = true;
        }
       
    }
}
