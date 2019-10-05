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
    public partial class createAdmin : Form
    {

        DatabaseStuff dbhandler = new DatabaseStuff();
        public createAdmin()
        {
            InitializeComponent();
        }
  

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            String fname = txt_fullname.Text.Trim().Replace("'", "`");
            String username = txt_Username.Text.Trim().Replace("'", "`");
            String password = txt_pass.Text.Trim().Replace("'", "`");
            String confirm = txt_confirmpass.Text.Trim().Replace("'", "`");

            if (username == "" || password == "" || confirm == "" || fname == "")
            {
                message mes = new message("Please complete the form");
                mes.ShowDialog(this);
                mes.ShowInTaskbar = false;
            }
            else
            {

                if (password != confirm)
                {
                    message mes = new message("The Password emtered did not match.");
                    mes.ShowDialog(this);
                    mes.ShowInTaskbar = false;

                }
                else
                {
                    DialogResult res = MessageBox.Show(this, "Proceed with creating this account? \n" + username, "Confirmation", MessageBoxButtons.YesNo);

                    if (res == System.Windows.Forms.DialogResult.Yes)
                    {
                        int a = dbhandler.createNewUserAdmin(username, password, fname);
                        if (a > 0)
                        {
                            message mes = new message("The Admin account `"+username+"\nwas successfully created." );
                            mes.ShowDialog(this);
                            mes.ShowInTaskbar = false;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("An error has occured");

                        }
                        //do core
                    }
                    else
                    {

                    }

                }

            }
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
      
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void txt_noItem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
