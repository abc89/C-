using client.logs;
using client.transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.operate
{
    abstract class Operate 
    {
        protected List<Recive> recives = new List<Recive>();//操作处理完毕 通知 

        protected void notifyAll() {    
            int size = recives.Count;
            ClientLogs.log("ChatOperate 数目" + size);
            for (int i = 0; i < size; i++)
            {
                recives.ElementAt(i).update();
        }

    }
        public abstract void attach(Recive recive);
        /// <summary>
        /// 接收服务器消息的处理方法
        /// </summary>
        /// <param name="msg">服务器消息</param>
        public abstract void operate(String msg);
    }
}
