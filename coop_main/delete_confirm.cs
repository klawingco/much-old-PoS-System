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
    public partial class delete_confirm : Form
    {
        public String itemz ="";
        public delete_confirm()
        {
            InitializeComponent();
        }
        public delete_confirm(String item)
        {
            InitializeComponent();
          
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delete_confirm_Load(object sender, EventArgs e)
        {
            txt_Name.Text = itemz;
            txt_Name.Select();
        }

        private void delete_confirm_KeyUp(object sender, KeyEventArgs e)
        {
         
        }

        private void txt_Name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_close.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }


    }
}
