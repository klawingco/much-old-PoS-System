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
    public partial class loan_money : Form
    {
        List<String> custId = new List<String>();
        DatabaseStuff dbhandler = new DatabaseStuff();
        String customerId;
        String empID = "";
        bool checkIfTheresLoanPend = true;
        public loan_money(String empID)
        {
            InitializeComponent();
            this.empID = empID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loans sd = new loans(empID);
            sd.Show();
            this.Close();
        }

        private void txt_principalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_membersName_TextChanged(object sender, EventArgs e)
        {
        }

        private void selectmember() {

            if (listBox1.Items.Count > 0)
            {

                txt_membersName.Text = listBox1.SelectedItem.ToString();

                if (listBox1.SelectedIndex == 0)
                {
                    customerId = custId[0].ToString();
                }
                else if (listBox1.SelectedIndex > 0)
                {
                    customerId = custId[listBox1.SelectedIndex].ToString();
                }


                try {
                    this.UseWaitCursor = true;
                    Cursor.Current = Cursors.WaitCursor;
                    Application.DoEvents();

                    long check = dbhandler.getLoanId(customerId);

                    if (check > 0)
                    {
                        checkIfTheresLoanPend = false;
                    }

                    txt_membersName.ReadOnly = true;
                    listBox1.Visible = false;
                    dbhandler.getAllMembersLoan(customerId, txt_notes);

                    txt_currSavings.Text = dbhandler.getCurrentMemberSavings(customerId);
                    txt_currsharecapital.Text = dbhandler.getCurrentMemberShareCapital(customerId);
                
                }
                catch {
                    message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                    mes.ShowDialog(mes.Parent);
                }
                finally
                {
                    this.UseWaitCursor = false;

                }


            }




        }

        private void txt_membersName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectmember();
    
            }
            if (e.KeyCode == Keys.Down)
            {
                if (listBox1.Items.Count > 0 && (listBox1.SelectedIndex + 1) < listBox1.Items.Count)
                {

                    listBox1.SelectedIndex = listBox1.SelectedIndex + 1;

                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (listBox1.Items.Count > 0 && (listBox1.SelectedIndex + 1) > 1)
                {

                    listBox1.SelectedIndex = listBox1.SelectedIndex - 1;

                }
            }
        }

        private void txt_timeDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_timeDuration_TextChanged(object sender, EventArgs e)
        {
            deto();
        }

        private void btn_conPay_Click(object sender, EventArgs e)
        {
            try {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                if (checkIfTheresLoanPend)
                {
                    if (txt_membersName.Text.Trim() != "" && txt_principalAmount.Text.Trim() != "")
                    {
                        loan_money_confirm conf = new loan_money_confirm(txt_membersName.Text, txt_principalAmount.Text);
                        DialogResult res = conf.ShowDialog(this);
                        if (res == System.Windows.Forms.DialogResult.OK)
                        {
                            decimal prin = decimal.Parse(txt_principalAmount.Text);
                            double rate = double.Parse(txt_rateInterest.Text);
                            decimal tot = decimal.Parse(txt_principalAmount.Text) - (decimal.Parse(txt_principalAmount.Text) * (decimal.Parse(rate.ToString()) / 100)); // rwith interest
                            int duration = Int32.Parse(txt_timeDuration.Text);

                            int tter = 0;
                            if (comboBox1.SelectedIndex.ToString() == "-1")
                            {
                                tter = 0;
                            }
                            else
                            {
                                tter = comboBox1.SelectedIndex;
                            }

                                decimal fillfee = decimal.Parse(txt_fillingFee.Text);
                                decimal procfee = decimal.Parse(txt_processFee.Text);
                                decimal shcapfee = decimal.Parse(txt_shareCap.Text);

                            long loan_id = dbhandler.newLoan(customerId, prin, tot, tter.ToString(), duration.ToString(), rate, txt_notes.Text, dateTimePicker3.Value, dateTimePicker1.Value, dateTimePicker2.Value, empID,fillfee, procfee, shcapfee, customerId, DateTime.Now.ToString("yyyy-MM-dd"));
                            if (loan_id > 0)
                            {
                                //print here
                                message mes = new message("Successfully created a new loan for\n" + txt_membersName.Text);
                                System.Media.SystemSounds.Exclamation.Play();
                                mes.ShowDialog(this);

                               // MessageBox.Show("Successfully created a new loan");
                                clear();
                            }
                            else {
                                MessageBox.Show("ERROR, Please check your network connection");
                                System.Media.SystemSounds.Hand.Play();
                            }

                        }

                    }

                }
                else
                {
                    MessageBox.Show(this, "The member has still a pending loan.", "Cannot Proceed");
                    System.Media.SystemSounds.Hand.Play();
                }
            }
            catch {
                message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                System.Media.SystemSounds.Hand.Play();
                mes.ShowDialog(mes.Parent);
            }
            finally
            {

                this.UseWaitCursor = false;
            }
    
   
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_rateInterest.Text != "" && txt_principalAmount.Text != "")
            {

                double intere = 1 + double.Parse(txt_rateInterest.Text);
                double duration = double.Parse(txt_timeDuration.Text);
                duration = duration * -1;

                double pow = Math.Pow(intere, duration);
                double total = pow * double.Parse(txt_principalAmount.Text);
                MessageBox.Show(total.ToString());


                if (comboBox1.SelectedIndex == 0)
                {
                    //  Double amout =   double.Parse((1 + intere) ^ (duration / 12))  ;
                }

            }
        }

        private void txt_principalAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                try { 
                    double less = double.Parse(txt_principalAmount.Text);
                    txt_less.Text = (less * 0.05).ToString();


                    double filingfee = double.Parse(txt_principalAmount.Text);
                    txt_fillingFee.Text = (filingfee * 0.015).ToString();


                    double processfee = double.Parse(txt_principalAmount.Text);
                    txt_processFee.Text = (processfee * 0.015).ToString();

                    double sharecapita = double.Parse(txt_principalAmount.Text);
                    txt_shareCap.Text = (sharecapita * 0.02).ToString();

                
                }catch{}

            }
        }

        private void txt_principalAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double less = double.Parse(txt_principalAmount.Text);
                txt_less.Text = (less * 0.05).ToString();


                double filingfee = double.Parse(txt_principalAmount.Text);
                txt_fillingFee.Text = (filingfee * 0.015).ToString();


                double processfee = double.Parse(txt_principalAmount.Text);
                txt_processFee.Text = (processfee * 0.015).ToString();

                double sharecapita = double.Parse(txt_principalAmount.Text);
                txt_shareCap.Text = (sharecapita * 0.02).ToString();

                double s = double.Parse(txt_principalAmount.Text)/200;

                s = Math.Ceiling(s);

                txt_docStamp.Text = s.ToString();

                try
                {
                    int startPos = txt_principalAmount.SelectionStart;
                    decimal initial = decimal.Parse(txt_principalAmount.Text);
                    txt_principalAmount.Text = initial.ToString("#,##0");
                    txt_principalAmount.SelectionStart = txt_principalAmount.Text.Length;
                }
                catch { }


            }
            catch { }
        }


        private void loan_money_Load(object sender, EventArgs e)
        {
            label5.Text = Properties.Settings.Default.username.ToUpper();
           // if (empID == "" || empID == "0")
           // {
                empID = Properties.Settings.Default.userid;
           // }
            dateTimePicker3.Value = DateTime.Now;
            txt_processBy.Text =  dbhandler.getEmployeeDetails(empID);

            

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            deto();
        }

        private void deto()
        {
            try {

                if (txt_timeDuration.Text.Trim() != "")
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        int howmanyadd = Int32.Parse(txt_timeDuration.Text);

                        dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(howmanyadd);
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        int howmanyadd = Int32.Parse(txt_timeDuration.Text) * 4;

                        dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(howmanyadd);
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        int howmanyadd = Int32.Parse(txt_timeDuration.Text) * 6;

                        dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(howmanyadd);
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        int howmanyadd = Int32.Parse(txt_timeDuration.Text);

                        dateTimePicker2.Value = dateTimePicker1.Value.AddYears(howmanyadd);
                    }
                }
            }
            catch { }
     
       

        }

        private void clear() {
            txt_membersName.Clear();
            txt_currSavings.Clear();
            txt_currsharecapital.Clear();
            txt_fillingFee.Clear();
            txt_less.Clear();
            txt_principalAmount.Clear();
            txt_processFee.Clear();
            txt_rateInterest.Clear();
            txt_timeDuration.Clear();
            txt_shareCap.Clear();
            txt_notes.Clear();
            txt_membersName.ReadOnly = false;
            listBox1.Visible = false;
        
        }

        private void txt_membersName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
            {
                if (txt_membersName.Text.Trim() != "")
                {

                    dbhandler.searchMemberEmployee(txt_membersName.Text.Replace("'", "`"), listBox1, custId);
                }
                else
                {
                    listBox1.Visible = false;

                }
            }

        }

        private void btn_newPay_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            confirmstuffs newDep = new confirmstuffs("Do you want to clear all fields?");
            DialogResult res = newDep.ShowDialog(this);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                clear();
            }

            
        }

        private void btn_cancelPay_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            confirmstuffs newDep = new confirmstuffs("Do you want to cancel Loan Money?");
            DialogResult res = newDep.ShowDialog(this);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                loans sd = new loans(empID);
                sd.Show();
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label4.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void txt_rateInterest_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_loanCalculator_Click(object sender, EventArgs e)
        {
            loan_calculator cal = new loan_calculator();
            cal.ShowDialog(this);
        }

        private void label5_Click(object sender, EventArgs e)
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

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selectmember();
        }





        //
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

  

    



    }
}
