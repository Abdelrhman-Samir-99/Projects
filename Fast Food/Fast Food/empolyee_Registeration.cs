using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace first_Attemp
{
    public partial class empolyee_Registeration : Form
    {
        public empolyee_Registeration()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = Singletone.get_Connection(); 
            SqlCommand inserting = new SqlCommand("INSERT INTO Empolyee(userName, Password, Type) VALUES(@Name, @Password, @Type)", con);
            con = Singletone.get_Connection();
            inserting.Parameters.AddWithValue("@Name", textBox1.Text);
            inserting.Parameters.AddWithValue("@Password", textBox2.Text);
            inserting.Parameters.AddWithValue("@Type", "0");
            if (con.State == ConnectionState.Closed)
                con.Open();
            inserting.ExecuteNonQuery();
            
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
