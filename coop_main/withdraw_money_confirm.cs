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
    public partial class withdraw_money_confirm : Form
    {
        public withdraw_money_confirm()
        {
            InitializeComponent();
        }

        public withdraw_money_confirm(String customername, String depositAmt)
        {
            InitializeComponent();

            txt_noItem.Text = customername;
            txt_price.Text = depositAmt;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void initial_deposit_confirm_Load(object sender, EventArgs e)
        {

        }
    }
}
