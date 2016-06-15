using client.logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.operate
{
    class OperateMannager
    {
        private static int OperateMode=3;
        public static int LOGINOPERATE = 0;
        public static int CHATOPERATE = 1;
        public static int ONEOPERATE = 2;
        public static int NULLOPERATE = 3;
        private static Object loB = new object();
        internal static void opearte(string msg)
        {

            if (OperateMode == CHATOPERATE)
            {
                ClientLogs.log("Mannop" + msg);
                MainOperate.getInsrance().operate(msg);
            }
            else if (OperateMode == ONEOPERATE)
            {
                ChatOperate.getInstance().operate(msg);
            }
            else {
                ClientLogs.log("OpMannanger 未设置处理类" + msg);
            }
          
        }
        public static void changeOperateMode(int mode) {
            OperateMode = mode;
        }
    }
}
