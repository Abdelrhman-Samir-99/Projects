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
        static Dictionary<string, bool> Composite = new Dictionary<string, bool>();
        static Dictionary<string, bool> Composite2 = new Dictionary<string, bool>();
        static List<string> meals = new List<string>();
        static SqlConnection con = Singletone.get_Connection();
        static Facade f;
        
        
        
        public Manager()
        {
            InitializeComponent();
            f = new Facade();
            f.get_start();
            //the data
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
            //putting items in the combo boxes.
            meal.Items.Clear();
            composite_Drop.Items.Clear();
            foreach (string s in meals)
            {
                meal.Items.Add(s);
                composite_Drop.Items.Add(s);
            }
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
                //getting current empoylee
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
                Composite2.Clear();
                SqlDataAdapter sda2 = new SqlDataAdapter("Select * From Meal", con);
                DataTable DT2 = new DataTable();
                sda2.Fill(DT2);
                foreach (DataRow current in DT2.Rows)
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
                    orders[current["Oid"].ToString().Trim()].Add(current["Oid"].ToString() + "      "+ current["meal_Name"].ToString() + "    " + current["meal_Count"].ToString() + "     " + current["cashier_Name"].ToString());
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
                sda2 = new SqlDataAdapter("Select compo_Name from Composite", con);
                DT2 = new DataTable();
                sda2.Fill(DT2);
                foreach (DataRow current in DT2.Rows)
                {
                    if (!Composite2.ContainsKey(current["compo_Name"].ToString().Trim()))
                        Composite2.Add(current["compo_Name"].ToString().Trim(), true);
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
                sda = new SqlDataAdapter("Select * From Composite", con);
                DT = new DataTable();
                sda.Fill(DT);
                foreach(DataRow current in DT.Rows)
                {
                    if(!meals.Contains(current["compo_Name"].ToString().Trim()))
                        meals.Add(current["compo_Name"].ToString().Trim());
                }
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
            if (Composite2.ContainsKey(textBox5.Text))
            {
                SqlConnection con2 = Singletone.get_Connection();
                SqlCommand inserting2 = new SqlCommand("Delete FROM Composite Where compo_Name = '" + textBox5.Text + "'", con2);
                if (con2.State == ConnectionState.Closed)
                    con2.Open();
                inserting2.ExecuteNonQuery();
            }
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (!Composite.ContainsKey(composite_Drop.Text))
                Composite.Add(composite_Drop.Text, true);
            else
            {
                MessageBox.Show("Already exist");
                return;
            }
            get_compo();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Composite.ContainsKey(composite_Drop.Text))
                Composite.Remove(composite_Drop.Text);
            else
            {
                MessageBox.Show("Not exist");
                return;
            }
            get_compo();
        }
        public  void get_compo()
        {
            textBox6.Text = "";
            foreach (var s in Composite)
                textBox6.Text += s.Key + "\r\n";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(textBox8.Text);
            }
            catch{
                MessageBox.Show("Not Valid price");
                return;
            }
            if(textBox7.Text == "" || meals.Contains(textBox7.Text))
            {
                MessageBox.Show("Enter a valid Name");
                return;
            }
            SqlConnection con = Singletone.get_Connection();
            //inserting composite meal.
            foreach (var y in Composite)
            {
                SqlCommand command = new SqlCommand("Insert into Composite(compo_Name, Children) values(@compo_Name, @Children)", con);
                command.Parameters.AddWithValue("@compo_Name", textBox7.Text);
                command.Parameters.AddWithValue("@Children", y.Key);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                command.ExecuteNonQuery();
            }
            SqlCommand com = new SqlCommand("Insert into Meal(meal_Name, meal_Price) values(@meal_Name, @meal_Price)", con);
            com.Parameters.AddWithValue("@meal_Name", textBox7.Text);
            com.Parameters.AddWithValue("@meal_Price", textBox8.Text);
            if (con.State == ConnectionState.Closed)
                con.Open();
            com.ExecuteNonQuery();
            Composite.Clear();
            composite_Drop.Items.Clear();
            textBox7.Text = textBox8.Text = "";
            f.get_Meal();
            here();
            textBox6.Text = "";
        }
        #region
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Manager_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion
        private void button10_Click(object sender, EventArgs e)
        {
            Log_in log = new Log_in();
            log.Show();
            this.Hide();
        }
    }
}
