using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Juice_Shop_Billing_System
{
    public partial class Orders : Form
    {
        static string s = "server=DESKTOP-297HK87\\SQLEXPRESS;database=profound22_juice_shop;integrated security=true";
        SqlConnection con = new SqlConnection(s);
        public Orders()
        {
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            bindcustomername();
            bindjuicename();
            autoincrement();
        }
        public void autoincrement()
        {
            int r;
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(order_id) from orders", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string d = dr[0].ToString();
                if (d == "")
                {
                    textBox1.Text = "1";
                }
                else
                {
                    r = Convert.ToInt16(dr[0].ToString());
                    r = r + 1;
                    textBox1.Text = r.ToString();
                }
            }
            dr.Close();
            con.Close();
        }
        public void cleardata()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
        }
        void bindcustomername()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select customer_name from add_customer", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.Show();
        }
        void bindjuicename()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select juice_name from add_juice_price", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboBox2.DataSource = ds.Tables[0];
            comboBox2.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from add_customer where customer_name='"+comboBox1.Text+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr[2].ToString();
                textBox3.Text = DateTime.Now.ToString();
            }
            dr.Close();
            con.Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from add_juice_price where juice_name='" + comboBox2.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox4.Text = dr[2].ToString();                
            }
            dr.Close();
            con.Close();
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            int a, b, c;
            a = Convert.ToInt16(textBox4.Text);
            b = Convert.ToInt16(textBox5.Text);
            c = a * b;
            textBox6.Text = c.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        { // add
            listBox1.Items.Add(comboBox2.Text);
            listBox2.Items.Add(textBox4.Text);
            listBox3.Items.Add(textBox5.Text);
            listBox4.Items.Add(textBox6.Text);
            comboBox2.Text = "";
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            int i, sum = 0;
            for (i = 0; i < listBox4.Items.Count; i++)
            {
                sum = sum + Convert.ToInt16(listBox4.Items[i]);
            }
            textBox7.Text = sum.ToString();
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            int a, b, c;
            a = Convert.ToInt16(textBox7.Text);
            b = Convert.ToInt16(textBox8.Text);
            c = a - b;
            textBox9.Text = c.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {// orders
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into orders values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", comboBox1.Text);
            cmd.Parameters.AddWithValue("@p3", textBox2.Text);
            cmd.Parameters.AddWithValue("@p4", textBox3.Text);
            cmd.Parameters.AddWithValue("@p5", textBox7.Text);
            cmd.Parameters.AddWithValue("@p6", textBox8.Text);
            cmd.Parameters.AddWithValue("@p7", textBox9.Text);
            DialogResult res = MessageBox.Show("Do you Comfirm Orders ", "Added Orders", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
            }
            con.Close();
            cleardata();
            autoincrement();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Only number are allow");
                textBox5.Focus();
            }

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Only number are allow");
                textBox8.Focus();
            }

        }
    }
}
