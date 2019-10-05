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
    public partial class stockreturnqty : Form
    {
        public stockreturnqty()
        {
            InitializeComponent();
        }
        public stockreturnqty(String orid, ListBox box, String totalprice)
        {
            InitializeComponent();
     


        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
      
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
