using server.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.logs
{
    class ServerLogs
    {
        /// <summary>
        /// 日志存储 服务器运行状态记录
        /// </summary>
        /// <param name="content"></param>
        public static void logMoment(string content)
        {
            ServerView.getInstance().display(content);
        }
    }
}
