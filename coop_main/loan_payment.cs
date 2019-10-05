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
    public partial class loan_payment : Form
    {
        List<String> custId = new List<String>();
        DatabaseStuff dbhandler = new DatabaseStuff();
        String customerId = "0";
        String empID;
        String loanid = "0";

        bool paidNoBal = false;
        bool isThereActiveLoan = false;
        decimal pendingAmt;

        public loan_payment(String empID)
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

        private void btn_conPay_Click(object sender, EventArgs e)
        {
            try {
            if (isThereActiveLoan)
            {
                if (!paidNoBal)
                {
                    decimal p = decimal.Parse(txt_amountPaid.Text.Trim());
                    if(p > 0){

                        loan_payment_confirm f1 = new loan_payment_confirm(txt_membersName.Text, txt_amountPaid.Text);
                        DialogResult res = f1.ShowDialog(this);
                        if (res == System.Windows.Forms.DialogResult.OK)
                        {

                            try {
                                this.UseWaitCursor = true;
                                Cursor.Current = Cursors.WaitCursor;
                                Application.DoEvents();

                                decimal topay = decimal.Parse(txt_amountPaid.Text.Trim()); //amount to pay
                                decimal pri = dbhandler.getLoanPrincipal(loanid); // current pending amt
                                decimal futureAmt = pendingAmt - topay; // amount of pending after payment
                                if (topay > 0)
                                {
                                    long st = 0; // or_num
                                    if(futureAmt > 0){
                                       //normal payment
                                        st = dbhandler.newLoanPayment(customerId, pri, topay, dateTimePicker1.Value, empID, loanid, false);

                                    }
                                    else if (futureAmt <= 0)
                                    {
                                        //occust for last payment
                                        st = dbhandler.newLoanPayment(customerId, pri, topay, dateTimePicker1.Value, empID, loanid, true);

                                            message mes = new message("Information!\nAll balance has been settled. \nLoan was successfully paid.");
                                            System.Media.SystemSounds.Exclamation.Play();
                                            mes.ShowDialog(this);
                                    }



                                    if (st > 0)
                                    {
                                        //do primtomg stuffs here
                                        message mes = new message("Information!\nThe payment was successfully recorded.");
                                        System.Media.SystemSounds.Exclamation.Play();
                                        mes.ShowDialog(this);



                                        clear();
                                    }
                                }
                            }
                            catch(Exception xx)
                            {
                                MessageBox.Show(xx.ToString());
                                message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                                System.Media.SystemSounds.Hand.Play();
                                mes.ShowDialog(mes.Parent);
                            }
                            finally {

                                this.UseWaitCursor = false;
                            }

                        }

                    }

                }
                else
                {
                    message mes = new message("Information!\nThis member has no active loan at the moment. \nCreate a new loan.");
                    System.Media.SystemSounds.Hand.Play();
                    mes.ShowDialog(this);
                }
            }
            else {
                message mes = new message("Information!\nThis member has no active loan at the moment. \nCreate a new loan.");
                System.Media.SystemSounds.Hand.Play();
                mes.ShowDialog(this);
            }


            }
            catch { }


        }

        private void txt_membersName_TextChanged(object sender, EventArgs e)
        {

        }

        private void selectMember() {

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

                txt_membersName.ReadOnly = true;

                listBox1.Visible = false;

                try
                {

                    this.UseWaitCursor = true;
                    Cursor.Current = Cursors.WaitCursor;
                    Application.DoEvents();

                    loanid = dbhandler.getLoanId(customerId).ToString(); //check if there is active loan

                    pendingAmt = dbhandler.getPendingAmount(customerId, loanid); //get current pending loan amount
                    txt_amountPending.Text = pendingAmt.ToString("N");

                    txt_currSavings.Text = dbhandler.getCurrentMemberSavings(customerId);
                    txt_currsharecapital.Text = dbhandler.getCurrentMemberShareCapital(customerId);

                    int c = Int32.Parse(loanid);
                    if (c > 0)
                    {
                        isThereActiveLoan = true;
                    }

                    if (pendingAmt <= 0 && isThereActiveLoan)
                    {
                        paidNoBal = true;
                    }

                    dbhandler.getPaymentDetails(dataGridView1, customerId, loanid);


                }
                catch
                {
                    message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");

                    mes.ShowDialog(mes.Parent);
                }
                finally {
                    this.UseWaitCursor = false;
               
                }


            }
        }

        private void txt_membersName_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.Enter)
                {
                    selectMember();
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

        private void loan_payment_Load(object sender, EventArgs e)
        {
            label5.Text = Properties.Settings.Default.username.ToUpper();
            empID = Properties.Settings.Default.userid;

            txt_processBy.Text = dbhandler.getEmployeeDetails(empID);
            dateTimePicker1.Value = DateTime.Now;

            txt_amountPaid.GotFocus += txt_amountPaid_GotFocus;

         
        }

        void txt_amountPaid_GotFocus(object sender, EventArgs e)
        {
           if(txt_amountPaid.Text == "0.00"){
               txt_amountPaid.Select(0, 1);
           }
        }


        private void clear() {
            txt_membersName.Clear();
            txt_membersName.ReadOnly = false;
            txt_amountPending.Clear();
            txt_amountPaid.Clear();
            txt_processBy.Text = dbhandler.getEmployeeDetails(empID);
            dateTimePicker1.Value = DateTime.Now;
            dataGridView1.Rows.Clear();
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
            confirmstuffs newDep = new confirmstuffs("Do you want to cancel Loan Payment?");
            DialogResult res = newDep.ShowDialog(this);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                loans f = new loans(empID);
                f.Show();
                this.Close();
            }
 

        }

        private void btn_searchThumb_Click(object sender, EventArgs e)
        {

        }

        private void txt_membersName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
            {

                try
                {
                    this.UseWaitCursor = true;
                    Cursor.Current = Cursors.WaitCursor;
                    Application.DoEvents();


                    if (txt_membersName.Text.Trim() != "")
                    {
                        dbhandler.searchMemberEmployee(txt_membersName.Text, listBox1, custId);
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
        }

        private void txt_amountPaid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label4.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selectMember();
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
