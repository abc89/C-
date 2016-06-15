using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.main
{
   public interface Frame
    {
        void changeDis(String content);
        void warnMsg(String content);
    }
}
