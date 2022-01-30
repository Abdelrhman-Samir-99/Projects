using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_Attemp
{
    class Proxy
    {
        public Dictionary < string, string> all_Data;
        public Proxy()
        {
            all_Data = new Dictionary<string,string>();
        }
        public bool validate_Loging(string userName, string Password)
        {
            return (all_Data.ContainsKey(userName) && all_Data[userName] == Password) ? true : false;
        }
    }
}
