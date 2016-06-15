using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.dao
{
    /// <summary>
    /// 已登陆用户集合
    /// </summary>
    class PersonDataSet
    { // private static IDictionary<String, String> pds = new Dictionary<string, string>();
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
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
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
                    if (ns.CompareTo(name) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal static void remove(string v)
        {
           keyNames.Remove(v);
        }
    }
}
