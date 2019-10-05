using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Drawing.Printing;



namespace coop_main
{
    public partial class stock_request : Form
    {
        long requsetid = 0;
        private long invoice = 0;
        DatabaseStuff dbhandler = new DatabaseStuff();
        List<String> itemcodelist = new List<String>();
        String currentItemcode = "";
        ProductInfo prinfo = new ProductInfo();
        String empID;



        //print stu
        private int itemToPrint;

        //String currentRequestid = "0";

        public stock_request(String empID)
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

        private void btn_conReq_Click(object sender, EventArgs e)
        {
            sotck_req_confirm f1 = new sotck_req_confirm(listView1);
            
           DialogResult res =  f1.ShowDialog();


            if(res == System.Windows.Forms.DialogResult.OK){

                if (txt_supplierName.Text != "" && listView1.Items.Count > 0 && cmb_supplier.SelectedIndex > -1)
                {
                    string sql = "";
                    foreach (ListViewItem tem in listView1.Items)
                    {
                        sql += "INSERT INTO tbl_stockrqitems(`stock_itemcode`, `stock_itemid`, `stock_itemname`, `stock_qty`, `stock_requestid`) VALUES ('" + tem.SubItems[0].Text + "', '" + tem.Tag.ToString()+ "', '" + tem.SubItems[1].Text + "', '" + tem.SubItems[2].Text + "', '" + requsetid + "'); ";
                    }
                   invoice = dbhandler.finishStockRequest(sql,txt_requestPerson.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"), txt_supplierName.Text, txt_notes.Text, requsetid.ToString());





                    // do printing stuffs
                    PrintPreviewDialog prev = new PrintPreviewDialog();

                    PrintDialog diag = new PrintDialog();
                    PrintDocument document = new PrintDocument();
                    diag.Document = document;
                    prev.Document = document;
                    document.PrintPage += new PrintPageEventHandler(document_PrintPage);
                    document.DocumentName = "Stock Request Form";

                    diag.ShowDialog(this);



                    MessageBox.Show("Successfully Recorded");
                    txt_notes.Clear();
                    txt_requestPerson.Clear();
                    txt_search.Clear();
                    txt_stockReqDate.Clear();
                    txt_stockReqNo.Clear();
                    txt_supplierName.Clear();
                    listView1.Items.Clear();


                }
                else {
                    message mes = new message("Please Complete the Stock Request Form.");
                    System.Media.SystemSounds.Hand.Play();
                    mes.ShowInTaskbar = false;
                    mes.ShowDialog(this);
                }
           



                    
            }else if(res == System.Windows.Forms.DialogResult.Cancel){
                f1.Close();
            }
        }


        //print stuffs cont
        protected void document_PrintPage(object sender, PrintPageEventArgs ev)
        {

            try
            {
                bool nextPage = false;
                int offset = 65;
                Font printFont = new Font("Courier New", 8);
                ev.Graphics.DrawString("STOCK REQUEST RECEIPT", new Font("Courier New", 13), new SolidBrush(Color.Black), 30, 30);
                ev.Graphics.DrawString("-COOP NAME-", new Font("Courier New", 13), new SolidBrush(Color.Black), 30, 50);




                offset += 25;
                ev.Graphics.DrawString("STOCK REQUEST NO...... " + requsetid.ToString("D4"), printFont, new SolidBrush(Color.Black), 30, offset);

                offset += 25;
                ev.Graphics.DrawString("INVOICE NO...... " + invoice.ToString("D4"), printFont, new SolidBrush(Color.Black), 30, offset);

                offset += 25;
                ev.Graphics.DrawString("SUPPLIER NAME...... " + txt_supplierName.Text, printFont, new SolidBrush(Color.Black), 30, offset);

                offset += 25;
                ev.Graphics.DrawString("REUEST PERSON...... " + txt_requestPerson.Text, printFont, new SolidBrush(Color.Black), 30, offset);

                offset += 25;
                ev.Graphics.DrawString("DATE REQUESTED...... " + dateTimePicker1.Value.ToString("MM/dd/yyyy hh:mm:ss tt"), printFont, new SolidBrush(Color.Black), 30, offset);

                offset += 25;
                ev.Graphics.DrawString("-----ITEMS REQUESTED-----", new Font("Courier New", 10), new SolidBrush(Color.Black), 30, offset);

                int i = 1;

                while (itemToPrint < listView1.Items.Count)
                {
                    if (offset > ev.MarginBounds.Bottom)
                    {
                        ev.HasMorePages = true;
                        nextPage = true;
                        break;
                    }
                    offset += 20;
                    ev.Graphics.DrawString(i++.ToString() + ".  " + listView1.Items[itemToPrint].SubItems[0].Text + "   " + listView1.Items[itemToPrint].SubItems[1].Text + "   " + listView1.Items[itemToPrint].SubItems[2].Text + " qty", new Font("Courier New", 8), new SolidBrush(Color.Black), 30, offset);
                    itemToPrint++;
                }

                //use to stop creating new page
                if (itemToPrint < listView1.Items.Count)
                {
                    ev.HasMorePages = true;
                }
                else
                {
                    ev.HasMorePages = false;
                }

                if(nextPage == false){
                    offset += 30;
                    ev.Graphics.DrawString("PROCESS DATE : " + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"), new Font("Courier New", 8), new SolidBrush(Color.Black), 30, offset);



                    offset += 12;
                    ev.Graphics.DrawString("------------", new Font("Courier New", 8), new SolidBrush(Color.Black), 30, offset);

                }
              



            }
            catch (Exception err)
            {
                MessageBox.Show(this, "An error has occured while printing the receipt.\nThe transaction was not recorded \n" + err.Message, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }


        private void btn_newReq_Click(object sender, EventArgs e)
        {
          requsetid = Int32.Parse( dbhandler.newstockRequest());
          txt_stockReqNo.Text = requsetid.ToString();
          txt_stockReqNo.Tag = requsetid.ToString();
          btn_newReq.Enabled = false;
          btn_conReq.Enabled = true;
          btn_cancelReq.Enabled = true;

        }

        private void btn_cancelReq_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txt_stockReqNo.Tag.ToString());
            if(requsetid != 0){
                dbhandler.cancelStockRequest(requsetid);
                requsetid = 0;
                txt_stockReqNo.Text = "";
                btn_newReq.Enabled = true;
                btn_conReq.Enabled = false;
                MessageBox.Show("");
            }
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_search.Text.Trim() != "" && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Right && e.KeyCode != Keys.Left)
            {

                dbhandler.SearchProductz(txt_search.Text, listBox2, itemcodelist);

            }
            if (txt_search.Text == "")
            {
                listBox2.Visible = false;
            }
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox2.Items.Count > 0)
                {
                    txt_search.Text = listBox2.SelectedItem.ToString();
                    currentItemcode = itemcodelist[listBox2.SelectedIndex];
                    listBox2.Visible = false;
                }
            }



            if (e.KeyCode == Keys.Down)
            {
                if (listBox2.Items.Count > 0 && (listBox2.SelectedIndex + 1) < listBox2.Items.Count)
                {

                    listBox2.SelectedIndex = listBox2.SelectedIndex + 1;

                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (listBox2.Items.Count > 0 && (listBox2.SelectedIndex + 1) > 1)
                {

                    listBox2.SelectedIndex = listBox2.SelectedIndex - 1;

                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if(currentItemcode != "" && requsetid!= 0){
                prinfo.ProductInfoz(currentItemcode);
                    
                    if(prinfo.ProductDescription() != "" && textBox1.Text.Trim() != ""){
                        try {
                            ListViewItem tem = new ListViewItem(currentItemcode);
                            tem.SubItems.Add(prinfo.ProductDescription());
                            int qty = Int32.Parse(textBox1.Text);
                            tem.SubItems.Add(textBox1.Text);
                            tem.SubItems.Add(prinfo.ProductUom());
                            tem.SubItems.Add("Remove");
                            tem.Tag = prinfo.ID().ToString();
                            listView1.Items.Add(tem);
                        }
                        catch { }
            
                    }
             

               //prinfo tem.SubItems();
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {
                txt_search.Text = listBox2.SelectedItem.ToString();
                currentItemcode = itemcodelist[listBox2.SelectedIndex];
                listBox2.Visible = false;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Point mousePosition = listView1.PointToClient(Control.MousePosition);
            ListViewHitTestInfo hit = listView1.HitTest(mousePosition);
            int columnindex = hit.Item.SubItems.IndexOf(hit.SubItem);

            if(columnindex == 4){
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            }

        }

        private void stock_request_Load(object sender, EventArgs e)
        {

            label5.Text = Properties.Settings.Default.username.ToUpper();
           // if (empIO == "" || empIO == "0")
           // {
            empID = Properties.Settings.Default.userid;
          //  }

            txt_requestPerson.Text = dbhandler.getEmployeeDetails(empID);
          //  label5.Text = Properties.Settings.Default.username.ToUpper();

            dbhandler.populateSupplierInCombo(cmb_supplier);
            cmb_supplier.Items.Add("--CREATE NEW SUPPLIER--");

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label4.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {
                txt_search.Text = listBox2.SelectedItem.ToString();
                currentItemcode = itemcodelist[listBox2.SelectedIndex];
                listBox2.Visible = false;
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Down)
            {
                if (listBox2.Items.Count > 0 && (listBox2.SelectedIndex + 1) < listBox2.Items.Count)
                {

                    listBox2.SelectedIndex = listBox2.SelectedIndex + 1;

                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (listBox2.Items.Count > 0 && (listBox2.SelectedIndex + 1) > 1)
                {

                    listBox2.SelectedIndex = listBox2.SelectedIndex - 1;

                }
            }
        }

        private void cmb_supplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_supplier.SelectedItem.ToString() == "--CREATE NEW SUPPLIER--")
            {
                createSupplier s = new createSupplier();
                DialogResult res = s.ShowDialog(this);

                if (res == System.Windows.Forms.DialogResult.OK)
                {

                    dbhandler.populateSupplierInCombo(cmb_supplier);
                    cmb_supplier.Items.Add("--CREATE NEW SUPPLIER--");
                }
            }
            else {
                txt_supplierName.Text = cmb_supplier.SelectedItem.ToString();
            
            }
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
