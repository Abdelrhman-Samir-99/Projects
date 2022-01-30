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
    public partial class Manager : Form
    {
        static Dictionary<string, string> current_Empoylee = new Dictionary<string, string>();
        static Dictionary<string, List<string>> orders = new Dictionary<string, List<string>>();
        static Dictionary<string, int> price = new Dictionary<string, int>();
        static Dictionary<string, List<string>> by_Year = new Dictionary<string, List<string>>();
        static Dictionary<string, bool> by_Year_Used = new Dictionary<string, bool>();
        static Dictionary<string, List<string>> by_Month = new Dictionary<string, List<string>>();
        static Dictionary<string, bool> by_Month_Used = new Dictionary<string, bool>();
        static Dictionary<string, List<string>> by_Day = new Dictionary<string, List<string>>();
        static Dictionary<string, bool> by_Day_Used = new Dictionary<string, bool>();
        static Dictionary<string, List<string>> meal_Order = new Dictionary<string, List<string>>();
        static List<string> meals = new List<string>();
        static SqlConnection con = Singletone.get_Connection();
        static Facade f;
        public Manager()
        {
            InitializeComponent();
            f = new Facade();
            f.get_start();
            for (int i = 2000; i < 2020; ++i)
                comboBox1.Items.Add(i.ToString());
            for (int i = 1; i < 13; ++i)
                comboBox2.Items.Add(i.ToString());
            for (int i = 1; i < 31; ++i)
                comboBox3.Items.Add(i.ToString());
            f.get_Meal();
            here();
        }
        public void here()
        {
            meal.Items.Clear();
            foreach (string s in meals)
                meal.Items.Add(s);
        }
        class Facade
        {
            static generate_Report gen = new generate_Report();
            static meal_Report get2 = new meal_Report();
            public void get_start()
            {
                get2.start();
                get2.get_meal();
                gen.get_Empolyee();
                
            }
            public void get_Meal()
            {
                get2.get_meal();
            }
            public void get_Empolyee()
            {
                current_Empoylee.Clear();
                gen.get_Empolyee();
            }
        }
        class generate_Report
        {
            public void get_Empolyee()
            {
                current_Empoylee.Clear();
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Empolyee", con);
                DataTable DT = new DataTable();
                sda.Fill(DT);
                foreach (DataRow current in DT.Rows)
                    current_Empoylee.Add(current["userName"].ToString(), current["Password"].ToString());
            }
        }
        class meal_Report
        {
            public  void start()
            {
                orders.Clear();
                by_Day.Clear();
                by_Day_Used.Clear();
                by_Month.Clear();
                by_Month_Used.Clear();
                by_Year.Clear();
                by_Year_Used.Clear();
                meal_Order.Clear();
                price.Clear();
                SqlDataAdapter sda2 = new SqlDataAdapter("Select * From Meal", con);
                DataTable DT2 = new DataTable();
                sda2.Fill(DT2);
                foreach(DataRow current in DT2.Rows)
                    price.Add(current["meal_Name"].ToString().Trim(), int.Parse(current["meal_Price"].ToString().Trim()));
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Orders", con);
                DataTable DT = new DataTable();
                sda.Fill(DT);
                foreach (DataRow current in DT.Rows)
                {
                    string d = current["Time"].ToString().Trim();
                    string year = d.Substring(0,4);
                    string month = d.Substring(0, 7);
                    if (!meal_Order.ContainsKey(current["meal_Name"].ToString().Trim()))
                        meal_Order.Add(current["meal_Name"].ToString().Trim(), new List<string>());
                    meal_Order[current["meal_Name"].ToString().Trim()].Add(current["meal_Name"].ToString().Trim() + "   " + current["meal_Count"].ToString().Trim() + "    " + current["Time"].ToString().Trim() + "     " + current["cashier_Name"].ToString().Trim());
                    if(!orders.ContainsKey(current["Oid"].ToString().Trim()))
                        orders.Add(current["Oid"].ToString().Trim(), new List<string>());
                    orders[current["Oid"].ToString().Trim()].Add(current["meal_Name"].ToString().Trim() + "    " + current["meal_Count"].ToString().Trim() + "     " + (int.Parse(current["meal_Count"].ToString().Trim()) * price[current["meal_Name"].ToString().Trim()]).ToString());
                    if (!by_Year.ContainsKey(year))
                        by_Year.Add(year, new List<string>());
                    if (!by_Year_Used.ContainsKey(current["Oid"].ToString().Trim()))
                    {
                        by_Year[year].Add(current["Oid"].ToString().Trim());
                        by_Year_Used.Add(current["Oid"].ToString().Trim(), true);
                    }


                    if (!by_Month.ContainsKey(month))
                        by_Month.Add(month, new List<string>());
                    if (!by_Month_Used.ContainsKey(current["Oid"].ToString().Trim()))
                    {
                        by_Month[month].Add(current["Oid"].ToString().Trim());
                        by_Month_Used.Add(current["Oid"].ToString().Trim(), true);
                    }

                    if (!by_Day.ContainsKey(d))
                        by_Day.Add(d, new List<string>());
                    if (!by_Day_Used.ContainsKey(current["Oid"].ToString().Trim()))
                    {
                        by_Day[d].Add(current["Oid"].ToString().Trim());
                        by_Day_Used.Add(current["Oid"].ToString().Trim(), true);
                    }
                }
            }
            public void get_meal()
            {
                con = Singletone.get_Connection();
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Meal", con);
                DataTable DT = new DataTable();
                sda.Fill(DT);
                meals.Clear();
                foreach (DataRow cur in DT.Rows)
                    meals.Add(cur["meal_Name"].ToString().Trim());
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            empolyee_Registeration ssss = new empolyee_Registeration();
            ssss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f.get_Empolyee();
            List<string> list = new List<string>();
            foreach (var cur in current_Empoylee)
                list.Add(cur.Key + "  " + cur.Value + "\r\n");
            var message = string.Join(Environment.NewLine, list.ToArray());
            MessageBox.Show(message);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "" || comboBox1.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("Enter a valid date.");
                return;
            }
            string current_Date = comboBox1.Text + "-";
            string Month = current_Date; string Year = comboBox1.Text;
            if (comboBox2.Text.Length < 2)
            {
                current_Date += "0";
                Month = "0";
            }
            current_Date += comboBox2.Text + "-";
            Month += comboBox2.Text;
            if (comboBox3.Text.Length < 2)
                current_Date += "0";
            current_Date += comboBox3.Text;
            if (radioButton3.Checked)
            {
                if (!by_Day.ContainsKey(current_Date))
                {
                    MessageBox.Show("None.");
                    return;
                }
                List<string> list = new List<string>();
                foreach (string cur in by_Day[current_Date])
                {
                        foreach(string s in orders[cur])
                        list.Add(s);
                    list.Add("\r\n");
                }
                var message = string.Join(Environment.NewLine, list.ToArray());
                MessageBox.Show(message);
            }
            else if (radioButton2.Checked)
            {
                if (!by_Month.ContainsKey(Month))
                {
                    MessageBox.Show("None.");
                    return;
                }
                List<string> list = new List<string>();
                foreach (string cur in by_Month[Month])
                {
                    foreach (string s in orders[cur])
                        list.Add(s);
                    list.Add("\r\n");
                }
                var message = string.Join(Environment.NewLine, list.ToArray());
                MessageBox.Show(message);
            }
            else
            {
                if (!by_Year.ContainsKey(Year))
                {
                    MessageBox.Show("None.");
                    return;
                }
                List<string> list = new List<string>();
                foreach (string cur in by_Year[Year])
                {
                    foreach (string s in orders[cur])
                        list.Add(s);
                    list.Add("\r\n");
                }
                var message = string.Join(Environment.NewLine, list.ToArray());
                MessageBox.Show(message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (meal.Text == "")
            {
                MessageBox.Show("Choose a meal.");
                return;
            }
            if (!meal_Order.ContainsKey(meal.Text.Trim()))
            {
                MessageBox.Show("None.");
                return;
            }
            var message = string.Join(Environment.NewLine, meal_Order[meal.Text.Trim()].ToArray());
            MessageBox.Show(message);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || price.ContainsKey(textBox3.Text))
            {
                MessageBox.Show("Enter a valid meal name.");
                return;
            }
                try
                {
                    int x = int.Parse(textBox4.Text);
                }
                catch
                {
                    MessageBox.Show("Enter a valid Price.");
                    return;
                }
            SqlConnection con = Singletone.get_Connection();
            SqlCommand inserting = new SqlCommand("INSERT INTO Meal(meal_Name, meal_Price) VALUES(@Name, @Price)", con);
            inserting.Parameters.AddWithValue("@Name", textBox3.Text);
            inserting.Parameters.AddWithValue("@Price", textBox4.Text);
            if (con.State == ConnectionState.Closed)
                con.Open();
            inserting.ExecuteNonQuery();
            f.get_Meal();
            here();
            textBox4.Text = textBox3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = Singletone.get_Connection();
            SqlCommand inserting = new SqlCommand("Delete FROM Meal Where meal_Name = '" + textBox5.Text  +"'", con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            inserting.ExecuteNonQuery();
            f.get_Meal();
            here();
            textBox5.Text = "";
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (!orders.ContainsKey(textBox1.Text) || textBox1.Text == "")
            {
                MessageBox.Show("Not Exist.");
                return;
            }
            SqlConnection con = Singletone.get_Connection();
            SqlCommand inserting = new SqlCommand("Delete FROM Orders where Oid = '" + textBox1.Text + "'", con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            inserting.ExecuteNonQuery();
            f.get_start();
            textBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (!current_Empoylee.ContainsKey(textBox2.Text) || textBox2.Text == "")
            {
                MessageBox.Show("Not Exist.");
                return;
            }
            SqlConnection con = Singletone.get_Connection();
            SqlCommand inserting = new SqlCommand("Delete FROM Empolyee where userName = '" + textBox2.Text + "'", con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            inserting.ExecuteNonQuery();
            f.get_Empolyee();
            textBox2.Text = "";
        }

        private void Manager_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Log_in log = new Log_in();
            log.Show();
        }
    }
}
