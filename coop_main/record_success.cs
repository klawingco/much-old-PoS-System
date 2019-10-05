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
    public partial class record_success : Form
    {
        public record_success(String mess)
        {
            InitializeComponent();
            txt_Name.Text = mess;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {

        }
    }
}
