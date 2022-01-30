using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_Attemp
{
    sealed class Singletone
    {
        private Singletone()
        { }
        public static SqlConnection con;

        public static SqlConnection get_Connection()
        {
            if (con == null)
                con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\old\Fast Food\first_Attemp\DB.mdf;Integrated Security=True;");
            return con;
        }
    }
}
