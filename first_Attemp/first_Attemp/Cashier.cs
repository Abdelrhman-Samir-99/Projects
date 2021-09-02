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
    interface ICashier
    {
        void get_Data();
        void get_Price();
        void get_Name(string Name);
    }

    public partial class Cashier : Form, ICashier
    {
        int Order_ID = 1;
        public static int tot_Price = 0;
        public static string NAMING;
        public static int Oid = 0;
        static SqlConnection con = Singletone.get_Connection();
        static Dictionary<string, List<int>> combo_Details = new Dictionary<string, List<int>>();
        
        //each meal & it's price whether it's composite or not.
        static Dictionary<string, int> price = new Dictionary<string, int>();

        // Dictionary of string & list of strings to map each Oid to all the meals in this order. (many meals with each details).
        static Dictionary<int, List<string>> all_Day = new Dictionary<int, List<string>>();
        
        //for composite items
        static Dictionary<string, List<string>> composite = new Dictionary<string, List<string>>();

        //to add for composite items
        static Dictionary<string, int> last = new Dictionary<string, int>();
        
        // the director that will deliver each order
        Director mean_While = new Director();
     
        static List<string> printing = new List<string>();
        public static string get_Time()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        // getting the name of the cashier through set & get (Public method).
        public void get_Name(string Name)
        {
            NAMING = Name;
        }
        // getting the entire data (Last Oid in DB + prices) (((((( you will add for combo meals)))))).
        public void get_Data()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Meal", con);
            SqlDataAdapter sda2 = new SqlDataAdapter("Select * From Orders", con);
            SqlDataAdapter sda3 = new SqlDataAdapter("Select * From Composite", con);
            DataTable DT2 = new DataTable();
            sda2.Fill(DT2);
            if (DT2.Rows.Count > 0)
            {
                DataRow cur2 = DT2.Rows[DT2.Rows.Count - 1];
                Oid = int.Parse(cur2["Oid"].ToString()) + 1;
            }
            DataTable DT = new DataTable();
            sda.Fill(DT);
            meals_Combo.Items.Clear();
            price.Clear();
            foreach (DataRow current in DT.Rows)
            {
                meals_Combo.Items.Add(current["meal_Name"].ToString());
                price.Add(current["meal_Name"].ToString(), int.Parse(current["meal_Price"].ToString()));
            }
            DT = new DataTable();
            sda3.Fill(DT);
            foreach (DataRow current in DT.Rows)
            {
                if (!composite.ContainsKey(current["compo_Name"].ToString()))
                    composite.Add(current["compo_Name"].ToString(), new List<string>());
                composite[current["compo_Name"].ToString()].Add(current["Children"].ToString());
            }
        }
        public void get_Price()
        {
            if (Count.Text == "" || meals_Combo.Text == "")
            {
                tot.Text = "0";
                return;
            }
            tot.Text = (price[meals_Combo.Text] * int.Parse(Count.Text)).ToString();
        }
        public Cashier()
        {
            InitializeComponent();
            get_Data();
        }

        interface IBuilder
        {
            // not combo meal
            void normal_Add(string Name, int Count);
            // edit specific meal
            void Edit(string Name, int Count);
            // Delete specific meal from the order
            void Delete(string Name);
            void print();
            // getting the report of the day
            void get_Order();
            // reseting the current order after ordering it
            void reset();
        }

        class concrete_Builder : IBuilder
        {
            // Your meal.
            Meal meal = new Meal();
            public void normal_Add(string Name, int Count)
            {
                // just check if this meal already ordered before or not if yes just Add over the current value
                if(meal.order.ContainsKey(Name))
                    meal.order[Name] += Count;
                else
                    meal.order.Add(Name, Count);
                if (composite.ContainsKey(Name))
                {
                    if (!last.ContainsKey(Name))
                        last.Add(Name, Count);
                    else
                        last[Name] += Count;
                }
            }
            public void Delete(string Name)
            {
                // check if the meal is ordered before or not. if not give him an exception or just message box.
                if (meal.order.ContainsKey(Name))
                {
                    tot_Price -= price[Name] * meal.order[Name];
                    meal.order.Remove(Name);
                }
                else
                    MessageBox.Show("Order Does NOT Exist");
            }
            public void Edit(string Name, int Count)
            {
                // same as Delete.
                if (meal.order.ContainsKey(Name))
                {
                    tot_Price -= price[Name] * meal.order[Name];
                    meal.order[Name] = Count;
                }
                else
                    MessageBox.Show("Order Does NOT Exist");
            }
            public void print()
            {
                // printing the changes when even you delete, edit, modify
                tot_Price = 0;
                printing.Clear();
                foreach (var cur2 in meal.order)
                {
                    printing.Add(cur2.Key + "    " + cur2.Value.ToString() + "     " + cur2.Value + "     " + (cur2.Value * price[cur2.Key]).ToString());
                    tot_Price += cur2.Value * price[cur2.Key]; 
                }
            }
            public void get_Order()
            {
                Proxy P = new Proxy();
                if (P.validate_Order(meal.order))
                {
                    if (last.Count != 0)
                    {
                        foreach (var s in last)
                        {
                            foreach (string current in composite[s.Key])
                            {
                                if (!meal.order.ContainsKey(current))
                                    meal.order.Add(current, meal.order[s.Key]);
                                else
                                    meal.order[current] += meal.order[s.Key];
                            }
                        }
                    }
                    last.Clear();
                    // Dictionary of string & list of strings to map each Oid to all the meals in this order. (many meals with each details).
                    all_Day[Oid] = new List<string>();
                    foreach (var cur2 in meal.order)
                    {
                        //sending each item in the order to the DB.
                        all_Day[Oid].Add(Oid.ToString() + "    " + cur2.Key + "    " + cur2.Value + "      " + (cur2.Value * price[cur2.Key]).ToString() + "    ");
                        SqlCommand inserting = new SqlCommand("INSERT INTO Orders(meal_Name, meal_Count, Time, cashier_Name, Oid) VALUES(@meal_Name, @meal_Count, @Time, @cashier_Name, @Oid)", con);
                        con = Singletone.get_Connection();
                        inserting.Parameters.AddWithValue("@meal_Name", cur2.Key);
                        inserting.Parameters.AddWithValue("@meal_Count", cur2.Value);
                        inserting.Parameters.AddWithValue("@Time", get_Time());
                        inserting.Parameters.AddWithValue("@cashier_Name", NAMING);
                        inserting.Parameters.AddWithValue("@Oid", Oid.ToString());
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        inserting.ExecuteNonQuery();
                    }
                }
            }
            public void reset()
            {
                meal.order.Clear();
            }
        }

        class Director
        {
            // The director simply is the one who is responsible for deriving the final product (meal).
            // And this is the reference to the builder since we got only one builder we can do it hard-coded i guess.
            IBuilder Ibuilder = new concrete_Builder();
            public void normal_Build(string Name, int Count)
            {
                Ibuilder.normal_Add(Name, Count);
            }
            public void print()
            {
                Ibuilder.print();
            }
            public void Edit(string Name, int Count)
            {
                Ibuilder.Edit(Name, Count);
            }
            public void Delete(string Name)
            {
                Ibuilder.Delete(Name);
            }
            public void get_Order()
            {
                Ibuilder.get_Order();
            }
            public void reset()
            {
                Ibuilder.reset();
            }
        }

        // this is your meal
        class Meal
        {
            // you can do it as vector < pair <int, int > > vp; but just for the add function better to do it in map <string , int>.
            public Dictionary<string, int> order = new Dictionary<string, int>();
        }

        private void Count_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(Count.Text);
            }
            catch
            {
                return;
            }
            get_Price();
        }

        private void Done_Click(object sender, EventArgs e)
        {
            if (Order.Text == "")
            {
                MessageBox.Show("There is no order");
                return;
            }
            mean_While.get_Order();
            // Increamenting the order_ID for the next meal(DB).
            textBox1.Text = (++Order_ID).ToString();
            Order.Text = "";
            // Reseting the order.  
            mean_While.reset();
            ++Oid;
        }

        private void meals_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_Price();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (Count.Text == "" || meals_Combo.Text == "")
            {
                try
                {
                    int x = int.Parse(Count.Text);
                }
                catch
                {
                    MessageBox.Show("Enter a valid count number.");
                    return;
                }
                MessageBox.Show("Please put a valid number of meals");
                return;
            }
            Order.Text = "";
            printing.Clear();
            mean_While.normal_Build(meals_Combo.Text, int.Parse(Count.Text));
            mean_While.print();
            foreach (string s in printing)
            {
                Order.Text += s + "\r\n";
            }
            tot2.Text = tot_Price.ToString();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (Count.Text == "" || meals_Combo.Text == "")
            {
                MessageBox.Show("Please put a valid number of meals");
                return;
            }
            printing.Clear();
            Order.Text = "";

            mean_While.Edit(meals_Combo.Text, int.Parse(Count.Text));
            mean_While.print();
            foreach (string s in printing)
            {
                Order.Text += s + "\r\n";
            }
            tot2.Text = tot_Price.ToString();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Count.Text == "" || meals_Combo.Text == "")
            {
                MessageBox.Show("Please put a valid number of meals");
                return;
            }
            Order.Text = "";
            printing.Clear();
            mean_While.Delete(meals_Combo.Text);
            mean_While.print();
            foreach (string s in printing)
            {
                Order.Text += s + "\r\n";
            }
            tot2.Text = tot_Price.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (var cur in all_Day)
            {
                foreach(string s in all_Day[cur.Key])
                {
                    list.Add(s);
                }
                list.Add("\r\n");
            }
            var message = string.Join(Environment.NewLine, list.ToArray());
            MessageBox.Show("\r\n" + message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Log_in log = new Log_in();
            log.Show();
            this.Hide();
        }
    }
}
