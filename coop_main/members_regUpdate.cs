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
namespace coop_main
{
    public partial class members_regUpdate : Form
    {
        DatabaseStuff dbhandler = new DatabaseStuff();
        members_form memform = new members_form();
        public String addtype;
        public DateTime b_day;
        public String civilstatus;
        String empID;
        String memberid = "";


        public members_regUpdate(String empID, String memberid)
        {
            this.empID = empID;
            InitializeComponent();

            this.memberid = memberid;
        }


        private void button2_Click(object sender, EventArgs e)
        {
           // memform.Show();
            this.Close();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            next();
        }

        private void members_reg_Load(object sender, EventArgs e)
        {
            txt_lname.GotFocus += txt_lname_GotFocus;
            txt_lname.LostFocus += txt_lname_LostFocus;
            txt_fname.GotFocus += txt_fname_GotFocus;
            txt_fname.LostFocus += txt_fname_LostFocus;
            txt_mname.GotFocus += txt_mname_GotFocus;
            txt_mname.LostFocus += txt_mname_LostFocus;
            txt_address.GotFocus += txt_address_GotFocus;
            txt_address.LostFocus += txt_address_LostFocus;
            txt_telenum.GotFocus += txt_telenum_GotFocus;
            txt_telenum.LostFocus += txt_telenum_LostFocus;
            txt_cpnum.GotFocus += txt_cpnum_GotFocus;
            txt_cpnum.LostFocus += txt_cpnum_LostFocus;
            txt_day.GotFocus += txt_day_GotFocus;
            txt_day.LostFocus += txt_day_LostFocus;
            txt_year.GotFocus += txt_year_GotFocus;
            txt_year.LostFocus += txt_year_LostFocus;
            txt_birthplace.GotFocus += txt_birthplace_GotFocus;
            txt_birthplace.LostFocus += txt_birthplace_LostFocus;
            txt_age.GotFocus += txt_age_GotFocus;
            txt_age.LostFocus += txt_age_LostFocus;
            txt_idOne.GotFocus += txt_idOne_GotFocus;
            txt_idOne.LostFocus += txt_idOne_LostFocus;
            txt_idTwo.GotFocus += txt_idTwo_GotFocus;
            txt_idTwo.LostFocus += txt_idTwo_LostFocus;
            txt_idonenum.GotFocus += txt_idonenum_GotFocus;
            txt_idonenum.LostFocus += txt_idonenum_LostFocus;
            txt_idtwonum.GotFocus += txt_idtwonum_GotFocus;
            txt_idtwonum.LostFocus += txt_idtwonum_LostFocus;

            txt_provAdd.GotFocus += txt_provAdd_GotFocus;
            txt_provAdd.LostFocus += txt_provAdd_LostFocus;

            txt_day.Text = numericUpDown1.Value.ToString();
            txt_year.Text = numericUpDown2.Value.ToString();
            

            label6.Text = Properties.Settings.Default.username.ToUpper();
          //  if (empID.Trim() == "" || empID == "0")
          //  {
                empID = Properties.Settings.Default.userid;
           // }

             




        }


        private void members_regUpdate_Shown(object sender, EventArgs e)
        {

            try {

                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();


                String anongklase = "";
                String civlst = "";
                dbhandler.viewMemberBasicDetails(memberid, txt_lname, txt_fname, txt_mname, txt_address, txt_provAdd, anongklase, txt_cpnum, txt_telenum, dateTimePicker1, txt_birthplace, txt_age, cb_gender, civlst, cb_religion, txt_idOne, txt_idonenum, txt_idTwo, txt_idtwonum);

                switch (txt_provAdd.Tag.ToString())
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
                String year = dateTimePicker1.Value.Year.ToString();
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
            catch(Exception) {
                message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                mes.ShowDialog(mes.Parent);

            }
            finally {
                this.UseWaitCursor = false;
            }
        }



       

        private void next() {

            bool completed = false;

       

            if (txt_lname.Text.Trim() != "" && txt_lname.Text.Trim() != "Last Name")
            {

                if (txt_fname.Text.Trim() != "" && txt_fname.Text.Trim() != "First Name")
                {
                    if (txt_mname.Text.Trim() != "" && txt_mname.Text.Trim() != "Middle Name")
                    {
                        if (txt_address.Text.Trim() != "" && txt_address.Text.Trim() != "Full Address")
                        {


                            if(rad_owned.Checked || rad_rented.Checked || rad_lwr.Checked)
                            {
                                if (txt_telenum.Text.Trim() == "" || txt_telenum.Text.Trim() == "Telephone Number")
                                {
                                    txt_telenum.Text = "N/A";
                                }


                                if (txt_telenum.Text.Trim() != "" && txt_telenum.Text.Trim() != "Telephone Number")
                                {

                                    if (txt_cpnum.Text.Trim() == "" || txt_cpnum.Text.Trim() == "Cellphone Number")
                                    {
                                        txt_cpnum.Text = "N/A";
                                    }


                                    if (txt_cpnum.Text.Trim() != "" && txt_cpnum.Text.Trim() != "Cellphone Number")
                                    {
                                        if (cb_month.SelectedIndex >= 0 && txt_day.Text.Trim() != "" && txt_day.Text.Trim() != "Day" && txt_year.Text.Trim() != "" && txt_year.Text.Trim() != "Year")
                                        {

                                            if (txt_birthplace.Text.Trim() != "" && txt_birthplace.Text.Trim() != "Birthplace")
                                            {
                                                if (txt_age.Text.Trim() != "" && txt_age.Text.Trim() != "Age")
                                                {
                                                    if (txt_year.Text.Trim() != "" && txt_year.Text.Trim() != "Age" && cb_gender.SelectedIndex >= 0)
                                                    {
                                                        if(rad_single.Checked || rad_married.Checked || rad_widowed.Checked || rad_seperated.Checked){
                                                            if(cb_religion.SelectedIndex>=0){
                                                                if (txt_idOne.Text.Trim() != "" && txt_idOne.Text.Trim() != "ID Name" && txt_idTwo.Text.Trim() != "" && txt_idTwo.Text.Trim() != "ID Name")
                                                                {
                                                                    if (txt_idonenum.Text.Trim() != "" && txt_idonenum.Text.Trim() != "ID Number" && txt_idtwonum.Text.Trim() != "" && txt_idtwonum.Text.Trim() != "ID Number")
                                                                    {
                                                                        completed = true;
                                                                        if (rad_owned.Checked)
                                                                        {
                                                                            addtype = "Owned";
                                                                        }
                                                                        else if (rad_rented.Checked)
                                                                        {
                                                                            addtype = "Rented"; 
                                                                        }
                                                                        else if (rad_lwr.Checked)
                                                                        {
                                                                            addtype = "Living with Relatives"; 
                                                                        }

                                                                        b_day = DateTime.Parse((cb_month.SelectedIndex + 1) + "/" + txt_day.Text + "/" + txt_year.Text) ;

                                                                        //b_day = b_day.ToString("MM/dd/yyyy");

                                                                        if(rad_single.Checked){
                                                                            civilstatus = "Single";
                                                                        }else if(rad_married.Checked){
                                                                            civilstatus = "Married";
                                                                        }else if(rad_seperated.Checked){
                                                                            civilstatus = "Seperated";
                                                                        }
                                                                        else if (rad_widowed.Checked)
                                                                        {
                                                                            civilstatus = "Widowed";
                                                                        }
                                                                    }
                                                                }
                                                       
                                                            }
                                                          
                                                        }
                                                      
                                                    }
                                                }
                                     
                                            }
                                            
                                        }
                                       
                                    }
                                      
                                }
                               
                               
                            }
                    
                        }
             
                    }
                }

            }

            //

            if (completed)
            {
               // this.Hide();

                String bday = b_day.ToString("yyyy-MM-dd");
                String genderz = cb_gender.SelectedItem.ToString();
                String rel = cb_religion.SelectedItem.ToString();

                members_regUpdate2 f1 = new members_regUpdate2(empID, memberid,txt_lname.Text, txt_fname.Text, txt_mname.Text, txt_address.Text, txt_provAdd.Text, addtype, txt_cpnum.Text, txt_telenum.Text, bday, txt_birthplace.Text, txt_age.Text, genderz, civilstatus, rel, txt_idOne.Text, txt_idonenum.Text, txt_idTwo.Text, txt_idtwonum.Text);
                f1.ShowDialog(this);
            }
            else {
                MessageBox.Show(this, "Please complete all of the necessary Information", "Some Fields are not yet filled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }


        }



        #region miscmethod
        void txt_idtwonum_LostFocus(object sender, EventArgs e)
        {
            if (txt_idtwonum.Text.Trim() == "")
            {
                txt_idtwonum.Text = "ID Number";
            }
        }

        void txt_idtwonum_GotFocus(object sender, EventArgs e)
        {
            if (txt_idtwonum.Text.Trim() == "ID Number")
            {
                txt_idtwonum.Text = "";
            }
        }

        void txt_idonenum_LostFocus(object sender, EventArgs e)
        {
            if (txt_idonenum.Text.Trim() == "")
            {
                txt_idonenum.Text = "ID Number";
            }
        }

        void txt_idonenum_GotFocus(object sender, EventArgs e)
        {
            if (txt_idonenum.Text.Trim() == "ID Number")
            {
                txt_idonenum.Text = "";
            }
        }

        void txt_idTwo_LostFocus(object sender, EventArgs e)
        {
            if (txt_idTwo.Text.Trim() == "")
            {
                txt_idTwo.Text = "ID Name";
            }
        }

        void txt_idTwo_GotFocus(object sender, EventArgs e)
        {
            if (txt_idTwo.Text.Trim() == "ID Name")
            {
                txt_idTwo.Text = "";
            }
        }

        void txt_idOne_LostFocus(object sender, EventArgs e)
        {
            if (txt_idOne.Text.Trim() == "")
            {
                txt_idOne.Text = "ID Name";
            }
        }

        void txt_idOne_GotFocus(object sender, EventArgs e)
        {
            if (txt_idOne.Text.Trim() == "ID Name")
            {
                txt_idOne.Text = "";
            }
        }

        void txt_age_LostFocus(object sender, EventArgs e)
        {
            if (txt_age.Text.Trim() == "")
            {
                txt_age.Text = "Age";
            }
        }

        void txt_age_GotFocus(object sender, EventArgs e)
        {
            if (txt_age.Text.Trim() == "Age")
            {
                txt_age.Text = "";
            }
        }

        void txt_birthplace_LostFocus(object sender, EventArgs e)
        {
            if (txt_birthplace.Text.Trim() == "")
            {
                txt_birthplace.Text = "Birthplace";
            }
        }

        void txt_birthplace_GotFocus(object sender, EventArgs e)
        {
            if (txt_birthplace.Text.Trim() == "Birthplace")
            {
                txt_birthplace.Text = "";
            }
        }

        void txt_year_LostFocus(object sender, EventArgs e)
        {
            if (txt_year.Text.Trim() == "")
            {
                txt_year.Text = "Year";
            }
        }

        void txt_year_GotFocus(object sender, EventArgs e)
        {
            if (txt_year.Text.Trim() == "Year")
            {
                txt_year.Text = "";
            }
        }

        void txt_day_LostFocus(object sender, EventArgs e)
        {
            if (txt_day.Text.Trim() == "")
            {
                txt_day.Text = "Day";
            }
        }

        void txt_day_GotFocus(object sender, EventArgs e)
        {
            if (txt_day.Text.Trim() == "Day")
            {
                txt_day.Text = "";
            }
        }

        void txt_cpnum_LostFocus(object sender, EventArgs e)
        {
            if (txt_cpnum.Text.Trim() == "")
            {
                txt_cpnum.Text = "Cellphone Number";
            }
        }

        void txt_cpnum_GotFocus(object sender, EventArgs e)
        {
            if (txt_cpnum.Text.Trim() == "Cellphone Number")
            {
                txt_cpnum.Text = "";
            }
        }

        void txt_telenum_LostFocus(object sender, EventArgs e)
        {
            if (txt_telenum.Text.Trim() == "")
            {
                txt_telenum.Text = "Telephone Number";
            }
        }

        void txt_telenum_GotFocus(object sender, EventArgs e)
        {
            if (txt_telenum.Text.Trim() == "Telephone Number")
            {
                txt_telenum.Text = "";
            }
        }

        void txt_address_LostFocus(object sender, EventArgs e)
        {
            if (txt_address.Text.Trim() == "")
            {
                txt_address.Text = "Full address";
            }
        }

        void txt_address_GotFocus(object sender, EventArgs e)
        {
            if (txt_address.Text.Trim() == "Full address")
            {
                txt_address.Text = "";
            }
        }

        void txt_mname_LostFocus(object sender, EventArgs e)
        {
            if (txt_mname.Text.Trim() == "")
            {
                txt_mname.Text = "Middle Name";
            }
        }

        void txt_mname_GotFocus(object sender, EventArgs e)
        {
            if (txt_mname.Text.Trim() == "Middle Name")
            {
                txt_mname.Text = "";
            }
        }



        void txt_lname_LostFocus(object sender, EventArgs e)
        {
            if (txt_lname.Text.Trim() == "")
            {
                txt_lname.Text = "Last Name";
            }
        }

        void txt_lname_GotFocus(object sender, EventArgs e)
        {
            if(txt_lname.Text.Trim() == "Last Name"){
                txt_lname.Text = "";
            }
        }

        void txt_fname_LostFocus(object sender, EventArgs e)
        {
            if (txt_fname.Text.Trim() == "")
            {
                txt_fname.Text = "First Name";
            }
        }

        void txt_fname_GotFocus(object sender, EventArgs e)
        {
            if (txt_fname.Text.Trim() == "First Name")
            {
                txt_fname.Text = "";
            }
        }


        void txt_provAdd_LostFocus(object sender, EventArgs e)
        {
            if (txt_provAdd.Text.Trim() == "")
            {
                txt_provAdd.Text = "Provincial address";
            }
        }

        void txt_provAdd_GotFocus(object sender, EventArgs e)
        {
            if (txt_provAdd.Text.Trim() == "Provincial address")
            {
                txt_provAdd.Text = "";
            }
        }


        #endregion

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



        #region toolstrip
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 fo = new Form1(empID);
            fo.Show();
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            logout logout = new logout();
            DialogResult res = logout.ShowDialog(this);
            if (res == System.Windows.Forms.DialogResult.OK)
            {

                this.Close();
                Application.Exit();
            }
        }

        private void newMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Globals.arrayModule[1] == "1")
            {
                members_reg f1;
                f1 = new members_reg(empID);
                f1.Show();

                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void memberRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[2] == "1")
            {
                members_record memrecord;
                memrecord = new members_record(empID, "1");
                memrecord.Show();

                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void openRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[4] == "1")
            {
                open_register f1 = new open_register(empID);
                f1.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void savedSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[5] == "1")
            {
                saved_sales f1 = new saved_sales(empID);
                f1.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void refundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[6] == "1")
            {
                refunds f1 = new refunds(empID);
                f1.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void endOfTheDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[7] == "1")
            {
                end_of_the_day day = new end_of_the_day(empID);
                day.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void endOfTheWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[8] == "1")
            {
                end_of_the_week f1 = new end_of_the_week(empID);
                f1.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[9] == "1")
            {
                transaction_history f1 = new transaction_history(empID);
                f1.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void enterItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[11] == "1")
            {
                enter_items items;
                items = new enter_items(empID);
                items.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void stocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[12] == "1")
            {
                stocks st;
                st = new stocks(empID);
                st.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void stockRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[13] == "1")
            {
                stock_request f1 = new stock_request(empID);
                f1.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void stockReceiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[14] == "1")
            {
                stock_receiving f1 = new stock_receiving(empID);
                f1.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[15] == "1")
            {
                stock_return st_r = new stock_return(empID);
                st_r.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void itemListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[16] == "1")
            {
                Itemlist list;
                list = new Itemlist(empID);
                list.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void inventoryReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[17] == "1")
            {
                inventory_reports f = new inventory_reports(empID);
                f.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void moneyTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[19] == "1")
            {
                loans l = new loans(empID);
                l.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void depositMoneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[20] == "1")
            {
                initial_deposit f1 = new initial_deposit(empID);
                DialogResult res = f1.ShowDialog(this);
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void withdrawMoneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            withdraw_money money = new withdraw_money(empID);
            money.ShowDialog(this);
        }

        private void loanMoneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[21] == "1")
            {
                loan_money f1 = new loan_money(empID);
                f1.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }


        private void loanPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[22] == "1")
            {
                loan_payment f1 = new loan_payment(empID);
                f1.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }


        private void moneyCounterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[23] == "1")
            {
                money_counter count = new money_counter(empID);
                count.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }


        private void manageMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[25] == "1")
            {
                members_record m = new members_record(empID, "2");
                m.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void manageProductInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[26] == "1")
            {
                inventory_products pr = new inventory_products(empID, "2");
                pr.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void manageSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[27] == "1")
            {
                Sales_Report rep = new Sales_Report(empID);
                rep.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void managePurchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[28] == "1")
            {
                Purchases_Report rep = new Purchases_Report(empID);
                rep.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void manageLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[29] == "1")
            {
                Loans_Report reo = new Loans_Report(empID);
                reo.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void manageTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[30] == "1")
            {
                Transactions_Report re = new Transactions_Report(empID);
                re.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void manageEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[32] == "1")
            {
                List_Reports r = new List_Reports(empID);
                r.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void userAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[35] == "1")
            {
                user_accounts f1 = new user_accounts(empID);
                f1.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void auditTrailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[36] == "1")
            {
                audit_trail ad = new audit_trail(empID);
                ad.Show();
                this.Close();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void loanCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[37] == "1")
            {
                loan_calculator s = new loan_calculator();
                s.ShowDialog();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        private void toolStripDropDownButton5_Click(object sender, EventArgs e)
        {
            if (Globals.arrayModule[37] == "1")
            {
                loan_calculator s = new loan_calculator();
                s.ShowDialog();
            }
            else
            {
                message mes = new message("You don't have sufficient rights to access this module.");
                mes.ShowDialog(this);
            }
        }

        #endregion


   


        //border
    }
}
