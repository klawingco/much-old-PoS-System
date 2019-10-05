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
    public partial class voidReason : Form
    {
        public String reason = "";
        public voidReason()
        {
            InitializeComponent();
        }
  

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {



            if (txt_reason.Text.Trim() == "")
            {
                message mes = new message("Please complete the form");
                mes.ShowDialog(this);
                mes.ShowInTaskbar = false;
            }
            else
            {
                reason = txt_reason.Text.Trim();
            }
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

        private void txt_noItem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
