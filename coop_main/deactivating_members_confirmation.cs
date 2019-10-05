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
    public partial class deactivating_members_confirmation : Form
    {
        public deactivating_members_confirmation()
        {
            InitializeComponent();
        }

        public deactivating_members_confirmation(String reactive)
        {
            InitializeComponent();
            label1.Text = "Continue Re Activating member?";
        }
        public deactivating_members_confirmation(int aaa)
        {
            InitializeComponent();
            if (aaa == 0)
            {
                label1.Text = "Continue Deactivating user?";
            }
            else {
                label1.Text = "Continue Re Activating user?";
            }
            
        }
    }
}
