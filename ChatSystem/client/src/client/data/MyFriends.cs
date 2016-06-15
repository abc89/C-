using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.data
{
    /// <summary>
    /// 好友列表集合
    /// </summary>
    class MyFriends
    {  // private static IDictionary<String, String> pds = new Dictionary<string, string>();
        private static List<String> onlineFs = new List<string>();
        private static List<String> nolineFs = new List<string>();
        private static List<String> temp = new List<String>();
        public static void addOnline(String userName)
        {
            onlineFs.Add(userName);
        }
        public static List<String> getOnlineNames()
        {
            temp.Clear();
            int size = onlineFs.Count;
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    temp.Add(onlineFs.ElementAt(i));
                }
            }
            return temp;

        }

        internal static bool onlineContain(string name)
        {
            int size = onlineFs.Count;
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    String ns = onlineFs.ElementAt(i);
                    if (ns.CompareTo(name) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static void addNoline(String userName)
        {
            nolineFs.Add(userName);
        }
        public static List<String> getNolinkNames()
        {
            temp.Clear();
            int size = nolineFs.Count;
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    temp.Add(nolineFs.ElementAt(i));
                }
            }
            return temp;

        }

        internal static bool nolineContain(string name)
        {
            int size = nolineFs.Count;
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    String ns = nolineFs.ElementAt(i);
                    if (ns.CompareTo(name) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal static void removeNoline(string name)
        {
            nolineFs.Remove(name);
        }
        /*public static void add(String userName, String addr) {
pds.Add(userName, addr);
}
public static String getAddr(String userName)
{
String adr = null;
if (pds.Count > 0) {
adr = pds[userName];
}
return adr;
}*/

        /*   public static List<String> getNames() {
               keyNames.Clear();
               if (pds.Count>0) {
                   int size = pds.Count;
                   for (int i=0;i< size;i++) {
                       keyNames.Add(pds.ElementAt(i).Key);
                   }
               }
               return keyNames;

           }*/
    }
}
