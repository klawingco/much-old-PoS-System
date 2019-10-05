using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using MySql.Data.MySqlClient;

namespace coop_main
{
    public partial class stock_return : Form
    {
        const string connString = "Server='localhost';Database='coopdb';User Id='root';Password='';";
        MySqlConnection db = new MySqlConnection(connString);
        MySqlCommand mySqlComm = new MySqlCommand(); // tempReturnID
        MySqlCommand mySqlComm2 = new MySqlCommand(); // insert items in log table
        MySqlCommand mySqlComm3 = new MySqlCommand(); // update qty of items
        MySqlCommand mySqlComm4 = new MySqlCommand(); //finilization

        MySqlCommand mySqlCommINV = new MySqlCommand(); //issue new Invoice



        MySqlTransaction trans = null;
        private long tempReturnID = 0;
        private long tempInvoiceNo = 0;








        long returnid;
        DatabaseStuff dbhandler = new DatabaseStuff();
        String recivedid;
        String empID;
        public stock_return(String empID)
        {
            InitializeComponent();
            this.empID = empID;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            stocks st = new stocks(empID);
            st.Show();
            this.Close();
        }

        private void newStockReturned()
        {

            try
            {
                db.Open();
                trans = db.BeginTransaction();

                mySqlComm.CommandText = @"INSERT INTO tbl_stockreturn(`stock_receivedperson`) VALUES ('')";
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();
                tempReturnID = mySqlComm.LastInsertedId;

            }
            catch (Exception eaa) { MessageBox.Show(eaa.Message); }

        }


        private long finishedStock(string sql, string sql2)
        {
            try
            {
                mySqlCommINV.CommandText = "INSERT INTO tbl_invoicenumber(`nothing`) VALUES ('')";
                mySqlCommINV.Connection = db;
                mySqlCommINV.Transaction = trans;
                mySqlCommINV.ExecuteNonQuery();
                tempInvoiceNo = mySqlCommINV.LastInsertedId;

                mySqlComm2.CommandText = sql;
                mySqlComm2.Connection = db;
                mySqlComm2.Transaction = trans;
                mySqlComm2.ExecuteNonQuery();

                mySqlComm3.CommandText = sql2;
                mySqlComm3.Connection = db;
                mySqlComm3.Transaction = trans;
                mySqlComm3.ExecuteNonQuery();

                //dbhandler.finishStockReturn(txt_personRec.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"), txt_supplierName.Text, txt_notes.Text, DateTime.Now.ToString("yyyy-MM-dd"), txt_returnBy.Text, returnid.ToString(), recivedid);

                string finishedsql = @"UPDATE tbl_stockreturn SET `stock_receivedperson` = '" + txt_personRec.Text.Replace("'", "`").Replace(";", "") + "', `stock_recdate` = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', `stock_supplier` = '" + txt_supplierName.Text.Replace("'", "`").Replace(";", "") + "', `stock_desc` = '" + txt_notes.Text.Replace("'", "`").Replace(";", "") + "',`stock_retby` = '" + empID + "' ,`stock_finished` = '1', `stock_receiveid` = '" + returnid + "', `invoice_number` = '" + tempInvoiceNo + "' WHERE  `stock_returnid` = '" + tempReturnID + "';";

                mySqlComm4.CommandText = finishedsql;
                mySqlComm4.Connection = db;
                mySqlComm4.Transaction = trans;
                mySqlComm4.ExecuteNonQuery();

                trans.Commit();

            }
            catch
            {
                message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                System.Media.SystemSounds.Hand.Play();
                mes.ShowDialog(mes.Parent);
            }
            finally {
                db.Close();
            }

            return tempInvoiceNo;
        }

        private void btn_conReturn_Click(object sender, EventArgs e)
        {
            stock_return_confirm f1 = new stock_return_confirm();
            DialogResult res =  f1.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                if (listView1.Items.Count > 0)
                {
                    String returndate = DateTime.Now.ToString("yyyy-MM-dd");
                    string returnsql = "";
                    string updtesqlr = "";
                    foreach (ListViewItem tem in listView1.Items)
                    {
                        String name = tem.SubItems[2].Text;
                        String itemcode = tem.SubItems[1].Text;
                        String itemid = tem.Tag.ToString();
                        String rcqty = tem.SubItems[3].Text;
                        String rtqty = tem.SubItems[4].Text;
                        //dbhandler.insertStockReturnItems(name, itemcode, itemid, rcqty, rtqty, returndate, returnid.ToString());
                        returnsql += "INSERT INTO tbl_stockrtitems(`stock_itemcode`, `stock_itemid`, `stock_itemname`, `stock_rc_qty`, `stock_rt_qty`, `stock_returnid`) VALUES ('" + itemcode + "', '" + itemid + "', '" + name + "', '" + rcqty + "', '" + rtqty + "','" + returnid + "') ;";
                        updtesqlr += "UPDATE tbl_items SET quantity = quantity - '" + rtqty + "' WHERE `item_id` = '" + itemid + "'; ";

                    }
                    txt_orNum.Text = finishedStock(returnsql, updtesqlr).ToString();

                    //txt_orNum.Clear();

                    //txt_stockRecNo.Clear();
                    //listView1.Items.Clear();
                    //txt_notes.Clear();
                    //txt_returnBy.Clear();

                    //txt_personRec.Clear();
                    //txt_supplierName.Clear();
                    //txt_stockReturnNo.Clear();

                    message mes = new message("The item(s) was successfully returned.");
                    mes.ShowDialog(this);
                    System.Media.SystemSounds.Hand.Play();

                    btn_cancelReq.Enabled = false;
                    btn_conReturn.Enabled = false;
                    btn_newReturn.Enabled = true;

                    f1.Close();

                }
            }
            else {
                f1.Close();
            }
        }

        private void txt_stockRecNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.UseWaitCursor = true;
                    Cursor.Current = Cursors.WaitCursor;
                    Application.DoEvents();
                    dbhandler.getStockReceived(txt_stockRecNo.Text, txt_personRec, dateTimePicker1, txt_supplierName, txt_notes, listView1);
                    recivedid = txt_stockRecNo.Text;
                }
                catch(Exception) {
                    message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                    System.Media.SystemSounds.Hand.Play();
                    mes.ShowDialog(mes.Parent);
                }
                finally {
                    this.UseWaitCursor = false;
                }
            }
        }

        private void btn_newReturn_Click(object sender, EventArgs e)
        {

           txt_returnBy.Enabled = true;
           
           newStockReturned();
           returnid = tempReturnID;
           btn_cancelReq.Enabled = true;
           btn_conReturn.Enabled = true;
           btn_newReturn.Enabled = false;

           txt_orNum.Text = "---";
           txt_stockReturnNo.Text = returnid.ToString("D4");



           txt_returnBy.Text = dbhandler.getEmployeeDetails(empID);

        }

        private void btn_cancelReq_Click(object sender, EventArgs e)
        {
            txt_orNum.Clear();

            txt_stockRecNo.Clear();
            listView1.Items.Clear();
            txt_notes.Clear();
            txt_returnBy.Clear();

            txt_personRec.Clear();
            txt_supplierName.Clear();
            txt_stockReturnNo.Clear();
            btn_cancelReq.Enabled = false;
            btn_conReturn.Enabled = false;
            btn_newReturn.Enabled = true;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Point mousePosition = listView1.PointToClient(Control.MousePosition);
            ListViewHitTestInfo hit = listView1.HitTest(mousePosition);
            int columnindex = hit.Item.SubItems.IndexOf(hit.SubItem);

            if (columnindex == 5)
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);


            }
            else
            {
                stockreturnqty qty = new stockreturnqty();
                DialogResult res = qty.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.OK)
                {
                    listView1.SelectedItems[0].SubItems[4].Text = qty.txt_noItem.Text;
                }
                else {
                    qty.Close();
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label4.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void stock_return_Load(object sender, EventArgs e)
        {

            label5.Text = Properties.Settings.Default.username.ToUpper();

                empID = Properties.Settings.Default.userid;
    
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
