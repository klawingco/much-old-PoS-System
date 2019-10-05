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
    public partial class createUser : Form
    {
        DatabaseStuff dbhandler = new DatabaseStuff();
        public createUser()
        {
            InitializeComponent();
        }
        public createUser(String orid, ListBox box, String totalprice)
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
            String username = txt_Username.Text.Trim().Replace("'","`");
            String password = txt_pass.Text.Trim().Replace("'", "`");
            String confirm = txt_confirmpass.Text.Trim().Replace("'", "`");

            if (username == "" || password == "" || confirm == "" || fname == "")
            {
                MessageBox.Show("Please complete the form");
            }
            else { 
                  
                if(password != confirm){
                    MessageBox.Show("Password did not match.");

                }
                else
                {
                    DialogResult res = MessageBox.Show(this, "Proceed with creating this account? \n" + username, "Confirmation", MessageBoxButtons.YesNo);

                    if (res == System.Windows.Forms.DialogResult.Yes)
                    {
                        int a = dbhandler.createNewUser(username, password, fname);
                        if(a >0){
                            MessageBox.Show("Successfully Created");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("An error has occured");

                        }
                        //do core
                    }
                    else { 
                    
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
