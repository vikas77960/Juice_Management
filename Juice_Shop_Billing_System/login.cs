using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Juice_Shop_Billing_System
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "12345")
            {
                MessageBox.Show(" !!! Login Details Success !!! ");
                Main_MDI m = new Main_MDI();
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(" !!! Invalid Login Details !!!");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
