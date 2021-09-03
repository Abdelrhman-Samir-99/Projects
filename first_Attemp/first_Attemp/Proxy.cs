using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_Attemp
{
    class iterator
    {
        public Dictionary<string, int> cur = new Dictionary<string,int>();
        int Count = -1;
        public bool valid()
        {
            return (Count < cur.Count - 1) ? true : false;
        }
        public bool Next()
        {
            ++Count;
            var item = cur.ElementAt(Count);
            if (item.Key == null || item.Value == null)
                return false;
            return true;
        }        
    }
    
    class Proxy
    {
        public Dictionary < string, string> all_Data;
        public Proxy()
        {
            all_Data = new Dictionary<string,string>();
        }
        public bool validate_Loging(string userName, string Password)
        {
            // the dictionary was filled in log in form.
            return (all_Data.ContainsKey(userName) && all_Data[userName] == Password) ? true : false;
        }

        // Meal section.
        iterator it = new iterator();
        public bool validate_Order(Dictionary<string, int> cur2)
        {
            it.cur = cur2;
            while (it.valid())
            {
                if (!it.Next())
                    return false;
            }
            return true;
        }
    }
}
