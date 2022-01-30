using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace first_Attemp
{
    public partial class Log_in : Form
    {
        SqlConnection con = Singletone.get_Connection();
        Proxy testing = new Proxy();
        Dictionary<string, string> admins = new Dictionary<string, string>();
        public void get_Data(ref Dictionary<string, string> validate)
        {
            SqlDataAdapter Sda = new SqlDataAdapter("Select * From Empolyee", con);
            DataTable DT = new DataTable();
            Sda.Fill(DT);
            foreach (DataRow current in DT.Rows)
            {
                validate.Add(current["userName"].ToString(), current["Password"].ToString());
                admins.Add(current["userName"].ToString(), current["Type"].ToString());
            }
        }
        public Log_in()
        {
            get_Data(ref testing.all_Data);
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (testing.validate_Loging(user_Name.Text, Password.Text))
            {
                if (admins[user_Name.Text].ToString().Trim() == "1")
                {
                    Manager manager = new Manager();
                    manager.Show();
                }
                else
                {
                    Cashier cashier = new Cashier();
                    cashier.Show();
                    cashier.get_Name(user_Name.Text);
                }
                this.Hide();
                return;
            }
            MessageBox.Show("Enter a valid account");
            

        }

    }
}
