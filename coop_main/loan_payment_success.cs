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
    public partial class loan_payment_success : Form
    {
        public loan_payment_success()
        {
            InitializeComponent();
        }

        public loan_payment_success(String memname, String amout)
        {
            InitializeComponent();
            txt_membersName.Text = memname;
            txt_paymenAmount.Text = amout;
        }
    }
}
