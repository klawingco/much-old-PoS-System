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
    public partial class enter_items_confirm : Form
    {
        public enter_items_confirm()
        {
            InitializeComponent();
        }

        public enter_items_confirm(String item)
        {
            InitializeComponent();
            txt_Name.Text = item;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {

        }
    }
}
