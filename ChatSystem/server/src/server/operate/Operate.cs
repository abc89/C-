
using server.msg;
using server.thread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.operate
{
    abstract class Operate
    {
       
        internal abstract void operate(Msg msg, Client client, List<Client> list);
    }
}
