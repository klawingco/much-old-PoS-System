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
    public partial class records_denied : Form
    {
        public records_denied(String mess)
        {
            InitializeComponent();
            txt_Name.Text = mess;
        }
    }
}
