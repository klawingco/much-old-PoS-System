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
    public partial class loan_money_confirm : Form
    {
        public loan_money_confirm()
        {
            InitializeComponent();
        }
        public loan_money_confirm(String custname, String loanamt)
        {
            InitializeComponent();
            txt_name.Text = custname;
            txt_loanAmount.Text = loanamt;
        }
    }
}
