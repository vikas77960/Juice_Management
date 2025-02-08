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
    public partial class Main_MDI : Form
    {
        public Main_MDI()
        {
            InitializeComponent();
        }

        private void addJuicePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_juice_price a1 = new Add_juice_price();
            a1.Show();
        }
        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Customer a2 = new Add_Customer();
            a2.Show();
        }
        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Orders a3 = new Orders();
            a3.Show();
        }
        private void viewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Orders a4 = new View_Orders();
            a4.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
