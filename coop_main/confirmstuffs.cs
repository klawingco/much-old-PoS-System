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
    public partial class confirmstuffs : Form
    {
        public confirmstuffs()
        {
            InitializeComponent();
        }

        public confirmstuffs(String mess)
        {
            InitializeComponent();
            label1.Text = mess;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
