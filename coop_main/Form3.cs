using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace coop_main
{
    public partial class Form3 : Form
    {
        String empID;
        public Form3(String empID)
        {
            InitializeComponent();
            this.empID = empID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inventory_products pr = new inventory_products(empID,"1");
            pr.Show();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label5.Text = Properties.Settings.Default.username.ToUpper();
           // if (empID.Trim() == "" || empID == "0")
        //    {
                empID = Properties.Settings.Default.userid;
           // }
                button2.FlatAppearance.BorderSize = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //active_members_list m = new active_members_list(empID);
            //m.Show();
            //this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            transaction_per_individual id = new transaction_per_individual(empID);
            id.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(empID);
            f.Show();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label4.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }
    }
}
