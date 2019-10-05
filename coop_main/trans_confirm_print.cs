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
    public partial class trans_confirm_print : Form
    {
        public trans_confirm_print()
        {
            InitializeComponent();
        }

        private void trans_confirm_print_Load(object sender, EventArgs e)
        {

        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
