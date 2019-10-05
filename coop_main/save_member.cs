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
    public partial class save_member : Form
    {
        public save_member()
        {
            InitializeComponent();
        }
        public save_member(bool update) {
            InitializeComponent();
            label1.Text = "Update Member Information?";
        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_member_Load(object sender, EventArgs e)
        {

        }
    }
}
