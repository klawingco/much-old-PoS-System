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
    public partial class void_confirmation : Form
    {
        public void_confirmation()
        {
            InitializeComponent();
        }
        public void_confirmation(String orid, ListBox box, String totalprice)
        {
            InitializeComponent();
            listBox1.DataSource = box.Items;


            txt_orNum.Text = orid;
            txt_price.Text = totalprice + "pesos";
            txt_noItem.Text = listBox1.Items.Count.ToString() + " pcs";

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            void_successful f1 = new void_successful();
            f1.Show();
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
