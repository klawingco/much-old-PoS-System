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
    public partial class voidlogin : Form
    {
        public bool okay = false;
        public string voidingempID = "";
        public String empId;
        DatabaseStuff dbhandler = new DatabaseStuff();
        public voidlogin()
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
                    voidingempID = ss;
                    okay = true;
                    this.Hide();
                }
                else
                {
                    message mes = new message("Your Username or Password is either incorrect or does not exist.");
                    System.Media.SystemSounds.Hand.Play();
                    mes.ShowDialog(this);

                }
            }
            catch (Exception)
            {
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
