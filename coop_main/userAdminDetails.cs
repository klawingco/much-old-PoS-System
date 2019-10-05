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
    public partial class userAdminDetails : Form
    {

        DatabaseStuff dbhandler = new DatabaseStuff();
        int userid;
        public userAdminDetails(int userid)
        {
            InitializeComponent();
            this.userid = userid;
        }
     
  

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
        
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
      
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void txt_noItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void userAdminDetails_Load(object sender, EventArgs e)
        {
            
        }

        private void userAdminDetails_Shown(object sender, EventArgs e)
        {
            try
            {
                dbhandler.getUserorAdminDetails(txt_fullname, txt_Username, txt_pass, userid);
            }
            catch (Exception)
            {
                message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                mes.ShowDialog(mes.Parent);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
            
        }
    }
}
