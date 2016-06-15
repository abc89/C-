using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.data
{
    class PersonDataSet
    {
       // private static IDictionary<String, String> pds = new Dictionary<string, string>();
        private static List<String> keyNames = new List<string>();
        private static List<String> temp = new List<String>();
        public static void add(String userName)
        {
            keyNames.Add(userName);
        }
        public static List<String> getNames()
        {
            temp.Clear();
            int size = keyNames.Count;
            if (size> 0)
            {
                for (int i=0;i< size;i++) {
                    temp.Add(keyNames.ElementAt(i));
                }
            }
            return temp;

        }

        internal static bool contain(string name)
        {
            int size = keyNames.Count;
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    String ns = keyNames.ElementAt(i);
                    if (ns.CompareTo(name)==0) {
                        return true;
                    }
                }
            }
            return false;
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
