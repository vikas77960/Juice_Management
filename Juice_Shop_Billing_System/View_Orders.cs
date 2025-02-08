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
    public partial class View_Orders : Form
    {
        static string s = "server=DESKTOP-297HK87\\SQLEXPRESS;database=profound22_juice_shop;integrated security=true";
        SqlConnection con = new SqlConnection(s);
        public View_Orders()
        {
            InitializeComponent();
        }

        private void View_Orders_Load(object sender, EventArgs e)
        {
            data();
        }
        void data()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from orders ", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Show();
        }
    }
}
