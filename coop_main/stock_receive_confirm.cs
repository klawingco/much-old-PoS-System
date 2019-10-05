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
    public partial class stock_receive_confirm : Form
    {
        public stock_receive_confirm(ListView view)
        {
            InitializeComponent();

            foreach (ListViewItem tem in view.Items)
            {
                ListViewItem temz = new ListViewItem(tem.SubItems[0].Text);
                temz.SubItems.Add(tem.SubItems[1].Text);
                temz.SubItems.Add(tem.SubItems[2].Text);
                temz.SubItems.Add(tem.SubItems[3].Text);
                temz.Tag = tem.Tag.ToString();
                listView1.Items.Add(temz);
            }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
