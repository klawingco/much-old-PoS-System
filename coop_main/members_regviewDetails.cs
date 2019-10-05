using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;



using MySql.Data.MySqlClient;
namespace coop_main
{
    public partial class members_regviewDetails : Form
    {
        String empID;
      //  members_form memform = new members_form();
        String memberid = "";
        DatabaseStuff dbhandler = new DatabaseStuff();
        public members_regviewDetails()
        {
            InitializeComponent();
        }
        public members_regviewDetails(String empID, String memid)
        {
            InitializeComponent();
            memberid = memid;
            this.empID = empID;
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //memform.Show();
            this.Close();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            next();
        }

        private void members_reg_Load(object sender, EventArgs e)
        {


            label6.Text = Properties.Settings.Default.username.ToUpper();
            //if (empID == "" || empID == "0")
            //{
                empID = Properties.Settings.Default.userid;
           // }






        
        }

        private void members_regviewDetails_Shown(object sender, EventArgs e)
        {
            try {

                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();


                String anongklase = "";
                String civlst = "";

                dbhandler.viewMemberBasicDetails(memberid, txt_lname, txt_fname, txt_mname, txt_address, txt_provaddress, anongklase, txt_cpnum, txt_telenum, dateTimePicker1, txt_birthplace, txt_age, cb_gender, civlst, cb_religion, txt_idOne, txt_idonenum, txt_idTwo, txt_idtwonum);

                switch (txt_provaddress.Tag.ToString())
                {
                    case "Owned":
                        rad_owned.Checked = true;
                        break;
                    case "Rented":
                        rad_rented.Checked = true;
                        break;
                    case "Living with Relatives":
                        rad_lwr.Checked = true;
                        break;
                }
                String year = dateTimePicker1.Value.ToString("yyyy");
                String month = dateTimePicker1.Value.ToString("MMMM");
                String day = dateTimePicker1.Value.ToString("dd");
                txt_year.Text = year;
                cb_month.SelectedItem = month;
                txt_day.Text = day;
                switch (txt_age.Tag.ToString())
                {
                    case "Single":
                        rad_single.Checked = true;
                        break;
                    case "Married":
                        rad_married.Checked = true;
                        break;
                    case "Widowed":
                        rad_widowed.Checked = true;
                        break;
                    case "Separated":
                        rad_seperated.Checked = true;
                        break;
                }


                numericUpDown1.Value = decimal.Parse(txt_day.Text);
                numericUpDown2.Value = decimal.Parse(txt_year.Text);

                numericUpDown2.Maximum = decimal.Parse(DateTime.Now.Year.ToString());

            }
            catch(MySqlException) {
                message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                mes.ShowDialog(mes.Parent);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }


      

        private void next() {

            members_regviewDetails2 reg2 = new members_regviewDetails2(empID, memberid);
            reg2.ShowInTaskbar = false;
            reg2.ShowDialog(this);


        }



        

        private void txt_day_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_age_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label5.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            txt_day.Text = numericUpDown1.Value.ToString();            
        }

        private void cb_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_month.SelectedIndex == 1)
            {
                numericUpDown1.Maximum = 29;
            }
            else {
                numericUpDown1.Maximum = 31;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            txt_year.Text = numericUpDown2.Value.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            logout logout = new logout();

            DialogResult res = logout.ShowDialog(this);

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                login log = new login();
                log.Show();
                this.Close();

            }
        }

    

      

   


        //border
    }
}
