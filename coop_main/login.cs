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
    public partial class login : Form
    {
        String empId;
        DatabaseStuff dbhandler = new DatabaseStuff();
        Form1 f;
        public login()
        {
            InitializeComponent();
        }
  

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {

            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                String user = txt_Username.Text.Replace("'", "`").Replace(";", "");
                String pass = txt_pass.Text.Replace("'", "`").Replace(";", "");

                String ss = dbhandler.empIDLogIN(user, pass);
                if (ss.Trim() != "")
                {

                    empId = ss;
                    Properties.Settings.Default.username = user;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.userid = empId;
                    Properties.Settings.Default.Save();

                    String[] moduleArray;
                    dbhandler.getUserAccessRights(Int32.Parse(empId), out moduleArray);

                    Globals.arrayModule = moduleArray;

                    this.Hide();


                    message mes = new message("Welcome to CMIS \n" + Properties.Settings.Default.username.ToString().ToUpperInvariant());
                    System.Media.SystemSounds.Exclamation.Play();
                    mes.ShowDialog(this);


                    f = new Form1(empId);
                    f.Show();

                }
                else
                {
                    message mes = new message("Your Username or Password is either incorrect or does not exist.");
                    System.Media.SystemSounds.Hand.Play();
                    mes.ShowDialog(this);

                }
            }
            catch (Exception xx)
            {
                MessageBox.Show(xx.ToString());
                message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                System.Media.SystemSounds.Hand.Play();
                mes.ShowDialog(mes.Parent);
            }
            finally
            {
                this.UseWaitCursor = false;
            }


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

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                btn_yes.PerformClick();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
