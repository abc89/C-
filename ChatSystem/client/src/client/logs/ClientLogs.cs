using client.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.logs
{
    class ClientLogs
    {
        public static void log(String msg) {
             LogView.getInstance().display(msg);
        }
    }
}
