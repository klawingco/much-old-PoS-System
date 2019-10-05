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
    public partial class message : Form
    {
        public message(String message)
        {
            InitializeComponent();
            label1.Text = message;
        }


        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
