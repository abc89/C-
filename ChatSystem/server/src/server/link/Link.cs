using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.link
{
    abstract class Link
    {

        public abstract String receive();
        public abstract void send(String msg, Encoding chreast);
        public abstract void send(String msg);
        internal abstract void close();
        internal abstract String receive(Encoding Chreast);
        public abstract String getIP();

        public abstract String getPort();
    }
}
