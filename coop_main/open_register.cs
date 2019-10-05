using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;
using MySql.Data.MySqlClient;
namespace coop_main
{
    public partial class open_register : Form
    {
        String empID;
        DatabaseStuff dbhandler = new DatabaseStuff();
        ProductInfo prinfo = new ProductInfo();
        String currItemCode, currItem;
            double currItemPrice, currtot;
            int currItemRetailsQty; //stock
            List<String> cart= new List<string>();
            List<String> itemcodelist = new List<String>();
            List<String> custidsuggestion = new List<string>();
            String tempTransid = "";
            String tempTransDate = "";
            String customerId = "";





            decimal totalAmt = 0;
            decimal nettotal = 0;
            decimal taxttotal = 0;

            string connString = "Server='localhost';Database='coopdb';User Id='root';Password='';";

            MySqlConnection db;
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;

            String tempORNumber = "";
            String tempORID = "";
            private int itemToPrint;

        public open_register(String emid)
        {
            InitializeComponent();
            this.empID = emid;
            db = new MySqlConnection(connString);
        }

        public open_register(String empID,String savedid, String date, String customerName, String customerId)
        {
            InitializeComponent();
            db = new MySqlConnection(connString);
            loadsavedTrans(savedid);
            this.empID = empID;
            if (customerId != "0")
            {
                this.customerId = customerId;
                txt_customerName.Text = customerName;
                rb_member.Checked = true;
                defaultdisable(true);

            }
            else {

                rb_nonMember.Checked = true;


                defaultdisable(true);
                txt_customerName.Enabled = false;
                btn_searchThumb.Enabled = false;
                customerId = "0";
                listBox2.Visible = false;
            }


    

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void open_register_Shown(object sender, EventArgs e)
        {

            getORNumber();
        }

        private void open_register_FormClosing(object sender, FormClosingEventArgs e)
        {
 
        }




        private void finalizeTransaction()
        {

            tempTransDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            if (rb_nonMember.Checked)
            {
                tempTransid = dbhandler.insertTempInvoiceID("0", tempTransDate);
            }
            else if (rb_member.Checked)
            {
                tempTransid = dbhandler.insertTempInvoiceID(customerId.ToString(), tempTransDate);
            }


            int id = Int32.Parse(tempTransid);
            int cusID = Int32.Parse(customerId);
            string transactionsql = "";
            string deductsql = "";
            int totalItems = 0;
            foreach (ListViewItem tem in listViewPurchased.Items)
            {

                transactionsql += "INSERT INTO tbl_transactions(customer_id, translog_id, item_name, item_price, item_qty_bought, total_amt, bought_period) VALUES ('" + cusID + "', '" + id + "', '" + tem.SubItems[0].Text + "', '" + Double.Parse(tem.SubItems[3].Text) + "', '" + Int32.Parse(tem.SubItems[1].Text) + "', '" + Double.Parse(tem.SubItems[2].Text) + "', '" + DateTime.Now.ToString("MM-yy") + "');";
                deductsql += "UPDATE tbl_items SET quantity = quantity -'" + Int32.Parse(tem.SubItems[1].Text) + "' WHERE item_code = '" + tem.Tag.ToString() + "'; ";
                totalItems += Int32.Parse(tem.SubItems[1].Text);

            }

            //this.UseWaitCursor = true;
            //Cursor.Current = Cursors.WaitCursor;
            //Application.DoEvents();
           
            dbhandler.recordPurchases(transactionsql, deductsql, customerId, id.ToString(), totalAmt, totalItems, empID, tempORNumber);
          
        }

        #region receiptPrinting
        private void startPrinting()
        {

            // do printing stuffs
            PrintPreviewDialog prev = new PrintPreviewDialog();

            PrintDialog diag = new PrintDialog();
            PrintDocument document = new PrintDocument();
            diag.Document = document;
            prev.Document = document;
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
            document.DocumentName = "RECEIPT";

            prev.ShowDialog(this);

        }

        //print stuffs cont
        protected void document_PrintPage(object sender, PrintPageEventArgs ev)
        {

            try
            {
                bool nextPage = false;
                int offset = 65;
                Font printFont = new Font("Courier New", 8);
                ev.Graphics.DrawString("PURCHASE RECEIPT", new Font("Courier New", 13), new SolidBrush(Color.Black), 30, 30);
                ev.Graphics.DrawString("-COOP NAME-", new Font("Courier New", 13), new SolidBrush(Color.Black), 30, 50);




                offset += 25;


                ev.Graphics.DrawString("OR NO...... " + tempORNumber.ToString(), printFont, new SolidBrush(Color.Black), 30, offset);

                //offset += 25;
                //ev.Graphics.DrawString("TRANS NO...... " + txt_invoiceNum.Text, printFont, new SolidBrush(Color.Black), 30, offset);

                offset += 25;
                ev.Graphics.DrawString("-----ITEMS BOUGHT-----", new Font("Courier New", 10), new SolidBrush(Color.Black), 30, offset);

                int i = 1;

                while (itemToPrint < listViewPurchased.Items.Count)
                {
                    if (offset > ev.MarginBounds.Bottom)
                    {
                        ev.HasMorePages = true;
                        nextPage = true;
                        break;
                    }
                    offset += 20;
                    ev.Graphics.DrawString(i++.ToString() + ".  " + listViewPurchased.Items[itemToPrint].SubItems[0].Text + "   " + listViewPurchased.Items[itemToPrint].SubItems[1].Text + "qty   " + listViewPurchased.Items[itemToPrint].SubItems[2].Text + " php", new Font("Courier New", 8), new SolidBrush(Color.Black), 30, offset);
                    itemToPrint++;
                }

                //use to stop creating new page
                if (itemToPrint < listViewPurchased.Items.Count)
                {
                    ev.HasMorePages = true;
                }
                else
                {
                    ev.HasMorePages = false;
                }


                offset += 25;
                ev.Graphics.DrawString("-----NET TOTAL " + nettotal.ToString() + "-----", new Font("Courier New", 10), new SolidBrush(Color.Black), 30, offset);
                offset += 25;
                ev.Graphics.DrawString("-----TAX TOTAL " + taxttotal.ToString() + "-----", new Font("Courier New", 10), new SolidBrush(Color.Black), 30, offset);
                offset += 25;
                ev.Graphics.DrawString("-----TOTAL AMOUNT " + txt_grandTotal.Text + "-----", new Font("Courier New", 10), new SolidBrush(Color.Black), 30, offset);


                offset += 25;
                ev.Graphics.DrawString("-----TENDERED AMOUNT " + txt_enterAmount.Text + "-----", new Font("Courier New", 10), new SolidBrush(Color.Black), 30, offset);

                offset += 25;
                ev.Graphics.DrawString("-----CHANGE AMOUNT " + txt_changeAmount.Text + "-----", new Font("Courier New", 10), new SolidBrush(Color.Black), 30, offset);

                if (nextPage == false)
                {
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


        #endregion

        private void btn_proceedPayment_Click(object sender, EventArgs e)
        {

            if(listBox1.Items.Count>0){
                if (!rb_member.Checked && !rb_nonMember.Checked)
                {
                    MessageBox.Show(this, "Please select customer type", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (rb_nonMember.Checked || rb_member.Checked)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    confirm_print f1z = new confirm_print();
                    f1z.txt_paymentDetails.Text = "Total Amount : " + txt_grandTotal.Text;
                    f1z.txt_paymentDetails.AppendText("\r\n" + "Amount Tendered :" + txt_enterAmount.Text);
                    f1z.txt_paymentDetails.AppendText("\r\n" + "Change Amount : " + txt_changeAmount.Text);
                    DialogResult resurlt = f1z.ShowDialog(this);

                    if (resurlt == System.Windows.Forms.DialogResult.Yes)
                    {
                        finalizeTransaction();

                        startPrinting();


                        bool reprintThis = false;

                        while (!reprintThis)
                        {
                            sucessprintmessage mes = new sucessprintmessage();
                            DialogResult reprint = mes.ShowDialog(this);

                            if (reprint == System.Windows.Forms.DialogResult.No)
                            {
                                startPrinting();
                            }
                            else if (reprint == System.Windows.Forms.DialogResult.Yes)
                            {
                                reprintThis = true;
                            }
                        }



                        MessageBox.Show("Successfully Printed");
                        clearStuffs();
                        tempORNumber = "";
                    }
                }


            }


            //if(listBox1.Items.Count > 0){
            //    if (!rb_member.Checked && !rb_nonMember.Checked)
            //    {
            //        MessageBox.Show(this, "Please select customer type", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else if (rb_nonMember.Checked || rb_member.Checked) 
            //    {
            //        openregister2 f1 = new openregister2(empID, listBox1, listViewPurchased);

            //        if (tempTransid.Trim() == "")
            //        {
            //            tempTransDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            //            if(rb_nonMember.Checked){
            //                tempTransid = dbhandler.insertTempInvoiceID("0", tempTransDate);
            //            }else if(rb_member.Checked){
            //                tempTransid = dbhandler.insertTempInvoiceID(customerId.ToString(), tempTransDate);
            //            }
                        
            //            f1.transid = tempTransid;
            //            f1.customerid = customerId;
            //            f1.total = double.Parse(txt_grandTotal.Tag.ToString());
            //            f1.nettotal = decimal.Parse(txt_netTotal.Tag.ToString());
            //            f1.taxttotal = decimal.Parse(txt_taxTotal.Tag.ToString());

                        
            //        }
            //        else if (tempTransid.Trim() != "")
            //        {
            //            f1.transid = tempTransid;
            //            f1.customerid = customerId;
            //            f1.total = double.Parse(txt_grandTotal.Tag.ToString());
            //            f1.nettotal = decimal.Parse(txt_netTotal.Tag.ToString());
            //            f1.taxttotal = decimal.Parse(txt_taxTotal.Tag.ToString());
            //        }


            //        DialogResult res = f1.ShowDialog(this);
                    
            //        this.Hide();
            //        if (res == System.Windows.Forms.DialogResult.Cancel)
            //        {
               
            //            this.Show();
            //            f1.Close();
            //        }

            //        else if (res == System.Windows.Forms.DialogResult.Yes)
            //        {

            //            open_register regz = new open_register(empID);
            //            regz.Show();
            //            this.Close();

            //        }
            //    }

            //}




        }

        private void btn_removeItem_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >= 0){
                delete_confirm f1 = new delete_confirm();

                f1.itemz = listViewPurchased.Items[listBox1.SelectedIndex].SubItems[0].Text;
                DialogResult res = f1.ShowDialog(this);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                  
                    listViewPurchased.Items.RemoveAt(listBox1.SelectedIndex);
                    cart.RemoveAt(listBox1.SelectedIndex);
                    listBox1.DataSource = null;
                    listBox1.DataSource = cart;
                        calculateTotalAmount();

                    if(listBox1.Items.Count > 0){
                        listBox1.SelectedIndex = 0;
                    }

                }
                else
                {
                    f1.Close();
                }

            }
     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tempORNumber != "")
            {
                openregisterExit ex = new openregisterExit();
                DialogResult res = ex.ShowDialog(this);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    dbhandler.cancelTempTrans(tempORNumber.Trim());
                    //delete from tempdb
                    tempTransDate = "";
                    tempTransid = "";

                    transaction s = new transaction(empID);
                    s.Show();
                    this.Close();

                }

            }
            else
            {

                transaction s = new transaction(empID);
                s.Show();
                this.Close();
            }


        }

        private void btn_openSale_Click(object sender, EventArgs e)
        {
            saved_sales s = new saved_sales(empID);
            s.Show();
            this.Close();
        }

        private void txt_barCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                String code = txt_barCode.Text.Trim();
                if (txt_barCode.Text.Trim() != "")
                {
                    prinfo.ProductInfoz(code);
                    if (prinfo.ProductDescription() != "")
                    {

                        txt_itemQty.Text = "1";
                        txt_itemName.Text = prinfo.ProductDescription();
                        txt_itemPrice.Text = prinfo.SellingPrice() + " pesos";
                        currItemCode = code;
                        currItem = prinfo.ProductDescription();
                        currItemPrice = prinfo.SellingPrice();
                        currtot = prinfo.SellingPrice();
                        currItemRetailsQty = prinfo.Quantity();
                        
                    }
                    else
                    {
                        MessageBox.Show(this, "Product code does not exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        currItemCode = "";
                        currItemRetailsQty = 0;
                    }

                }

            }
        }

        private void btn_addToCart_Click(object sender, EventArgs e)
        {
            if (txt_itemName.Text.Trim() != "" && txt_itemName.Text.Trim() != "Item Name" && txt_itemPrice.Text.Trim() != "" || txt_itemPrice.Text.Trim() != "Item Price")
            {
                int qty = dbhandler.getItemQuantity(currItemCode);
                if (qty >= Int32.Parse(txt_itemQty.Text))
                {
                    ListViewItem tem = new ListViewItem(currItem);
                    tem.Tag = currItemCode;
                    tem.SubItems.Add(txt_itemQty.Text);
                    tem.SubItems.Add(currtot.ToString());
                    tem.SubItems.Add(currItemPrice.ToString());
                    listViewPurchased.Items.Add(tem);
                    cart.Add(currItem + "\n  " + txt_itemQty.Text + " pcs x " + currItemPrice + " pesos");
                    listBox1.DataSource = null;
                    listBox1.DataSource = cart;

                    calculateTotalAmount();
                }
                else {
                    MessageBox.Show("Not enough stocks for this item");
                }
      
            }
      
        }

        private void txt_itemQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_itemQty.Text.Trim().Length > 0 && txt_itemName.Text != "")
            {
                try
                {
                    txt_itemPrice.Text= (prinfo.SellingPrice() * Int32.Parse(txt_itemQty.Text)) + " pesos";
                    currtot = prinfo.SellingPrice() * Int32.Parse(txt_itemQty.Text);
                }
                catch
                {
                    MessageBox.Show(this, "Invalid Quantity Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
                e.ItemHeight = 50;//Set the Height of the item at index 2 to 50
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if(listBox1.Items.Count > 0){
                e.DrawBackground();
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }

        }

        private void open_register_Load(object sender, EventArgs e)
        {

            defaultdisable(false);
            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            txt_itemName.GotFocus += txt_itemName_GotFocus;
            txt_itemName.LostFocus += txt_itemName_LostFocus;
            txt_itemQty.GotFocus += txt_itemQty_GotFocus;
            txt_itemQty.LostFocus += txt_itemQty_LostFocus;
            txt_itemPrice.GotFocus += txt_itemPrice_GotFocus;
            txt_itemPrice.LostFocus += txt_itemPrice_LostFocus;
            txt_barCode.GotFocus += txt_barCode_GotFocus;
            txt_barCode.LostFocus += txt_barCode_LostFocus;
            txt_customerName.GotFocus += txt_customerName_GotFocus;
            txt_customerName.LostFocus += txt_customerName_LostFocus;


            txt_enterAmount.GotFocus += txt_enterAmount_GotFocus;
            txt_enterAmount.LostFocus += txt_enterAmount_LostFocus;

            label10.Text = Properties.Settings.Default.username.ToUpper();

            empID = Properties.Settings.Default.userid;
        }

        #region miscmethods

        void txt_customerName_LostFocus(object sender, EventArgs e)
        {
            if (txt_customerName.Text.Trim() == "")
            {
                txt_customerName.Text = "Customer's Name";
            }
        }

        void txt_customerName_GotFocus(object sender, EventArgs e)
        {
            if (txt_customerName.Text.Trim() == "Customer's Name")
            {
                txt_customerName.Text = "";
            }
        }
    
        void txt_barCode_LostFocus(object sender, EventArgs e)
        {
            if (txt_barCode.Text.Trim() == "")
            {
                txt_barCode.Text = "Barcode Number";
            }
        }

        void txt_barCode_GotFocus(object sender, EventArgs e)
        {
            if (txt_barCode.Text.Trim() == "Barcode Number")
            {
                txt_barCode.Text = "";
            }
        }



        void txt_itemPrice_LostFocus(object sender, EventArgs e)
        {
            if (txt_itemPrice.Text.Trim() == "")
            {
                txt_itemPrice.Text = "Item Price";
            }
        }

        void txt_itemPrice_GotFocus(object sender, EventArgs e)
        {
            if (txt_itemPrice.Text.Trim() == "Item Price")
            {
                txt_itemPrice.Text = "";
            }
        }


        void txt_itemQty_LostFocus(object sender, EventArgs e)
        {
            if (txt_itemQty.Text.Trim() == "")
            {
                txt_itemQty.Text = "Item Quantity";
            }
        }

        void txt_itemQty_GotFocus(object sender, EventArgs e)
        {
            if (txt_itemQty.Text.Trim() == "Item Quantity")
            {
                txt_itemQty.Text = "";
            }
        }

        void txt_itemName_LostFocus(object sender, EventArgs e)
        {
            if (txt_itemName.Text.Trim() == "")
            {
                txt_itemName.Text = "Item Name";
            }
        }

        void txt_itemName_GotFocus(object sender, EventArgs e)
        {
            if (txt_itemName.Text.Trim() == "Item Name")
            {
                txt_itemName.Text = "";
            }
        }

        void txt_enterAmount_LostFocus(object sender, EventArgs e)
        {
            if (txt_enterAmount.Text.Trim() == "")
            {
                txt_enterAmount.Text = "Enter Amount";
            }
        }

        void txt_enterAmount_GotFocus(object sender, EventArgs e)
        {
            if (txt_enterAmount.Text.Trim() == "Enter Amount")
            {
                txt_enterAmount.Text = "";
            }
        }
        #endregion
        //

        private void calculateTotalAmount()
        {
            double total = 0;
            foreach (ListViewItem tem in listViewPurchased.Items)
            {
                total += Double.Parse(tem.SubItems[2].Text);
            }
      

            txt_taxTotal.Text = "₱ " + (total * 0.12).ToString() + " pesos."; ;
            txt_taxTotal.Tag = (total * 0.12).ToString();
            taxttotal = decimal.Parse(txt_taxTotal.Tag.ToString());

            txt_grandTotal.Text = "₱ " + total.ToString() +" pesos.";
            txt_grandTotal.Tag =  total.ToString();
            totalAmt = decimal.Parse(total.ToString());

            txt_netTotal.Text = "₱ " + (total - double.Parse(txt_taxTotal.Tag.ToString())) + " pesos.";
            txt_netTotal.Tag = (total - double.Parse(txt_taxTotal.Tag.ToString())).ToString();
            nettotal = decimal.Parse(txt_netTotal.Tag.ToString());


            
            try
            {
                listBox1.SelectedIndex = listBox1.Items.Count - 1;

                txt_changeAmount.Text = (decimal.Parse(txt_enterAmount.Text) - (decimal)totalAmt).ToString("N");
            }
            catch
            {
                //MessageBox.Show(this, "Invalid Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          


        }

        private void defaultdisable(bool what) {
            txt_customerName.Enabled = what;
            panel3.Enabled = what;
            btn_searchThumb.Enabled = what;
        }

        private void loadsavedTrans(String stransid) {
            dbhandler.populatesavedtramslog(listViewPurchased, stransid);


            foreach(ListViewItem tem in listViewPurchased.Items){


                cart.Add(tem.SubItems[0].Text + "\n  " + tem.SubItems[1].Text + " pcs x " + tem.SubItems[3].Text + " pesos");
                listBox1.DataSource = null;
                listBox1.DataSource = cart;

            }
            calculateTotalAmount();
        }
        private void clearStuffs()
        {
            cart.Clear();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            listViewPurchased.Items.Clear();
            txt_grandTotal.Clear();
            txt_taxTotal.Clear();
            txt_netTotal.Clear();
            txt_itemName.Text = "  Item Name";
            txt_itemPrice.Text = "  Item Price";
            txt_itemQty.Text = "  Item Quantity";
            txt_barCode.Text = "Barcode Number";

        }
        private void btn_cancelTrans_Click(object sender, EventArgs e)
        {

            clearStuffs();


            //do canceling here
        }

        private void txt_itemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listBoxProductTransSearch.Items.Count > 0)
                {
                    txt_itemName.Text = listBoxProductTransSearch.SelectedItem.ToString();
                    txt_barCode.Text = itemcodelist[listBoxProductTransSearch.SelectedIndex];
                    txt_barCode.Focus();
                    SendKeys.Send("~");
                    listBoxProductTransSearch.Visible = false;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (listBoxProductTransSearch.Items.Count > 0 && (listBoxProductTransSearch.SelectedIndex + 1) < listBoxProductTransSearch.Items.Count)
                {
                    listBoxProductTransSearch.SelectedIndex = listBoxProductTransSearch.SelectedIndex + 1;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (listBoxProductTransSearch.Items.Count > 0 && (listBoxProductTransSearch.SelectedIndex + 1) > 1)
                {
                    listBoxProductTransSearch.SelectedIndex = listBoxProductTransSearch.SelectedIndex - 1;
                }
            }
        }

        private void txt_itemName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_itemName.Text.Trim() != "" && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Right && e.KeyCode != Keys.Left && e.KeyCode != Keys.Enter)
            {
                try {
                    this.UseWaitCursor = true;
                    Cursor.Current = Cursors.WaitCursor;
                    Application.DoEvents();

                    dbhandler.SearchProductz(txt_itemName.Text.Trim().Replace("'", "`").Replace(";", ""), listBoxProductTransSearch, itemcodelist);
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
            if (txt_itemName.Text == "")
            {
                listBoxProductTransSearch.Visible = false;
            }
        }


        private void getORNumber() {


            db.Open();
            trans = db.BeginTransaction();
            string selectsql = "SELECT `or_number_ref` FROM tbl_inputtedor WHERE `status` = 0 AND `or_number_ref` NOT IN (SELECT `or_number_ref` FROM tbl_tempor) ORDER BY input_orID ASC LIMIT 1";
            MySqlCommand mySqlComm = new MySqlCommand(selectsql, db);
            using (MySqlDataReader read = mySqlComm.ExecuteReader())
            {
                if(!read.HasRows){
                    tempORNumber = "";
                }
                while (read.Read())
                {
                    tempORNumber = read["or_number_ref"].ToString();
                }
            }

            txt_orNumber.Text = tempORNumber.ToString();

            mySqlComm.CommandText = "INSERT INTO tbl_tempor (`or_number_ref`) VALUES ('" + tempORNumber + "') ";

            mySqlComm.Connection = db;
            mySqlComm.Transaction = trans;
            mySqlComm.ExecuteNonQuery();
            tempORID = mySqlComm.LastInsertedId.ToString();
            trans.Commit();
            db.Close();



            if(tempORNumber == ""){
                MessageBox.Show("There's no available OR number");
            }
        
        }

        private void btn_newTrans_Click(object sender, EventArgs e)
        {
            
           if(db.State == ConnectionState.Closed && tempORNumber == ""){

               clearStuffs();
               getORNumber();
 
           }
           else if (tempORNumber != "")
           {
                //delete 

               db.Open();
               trans = db.BeginTransaction();
               mySqlComm.CommandText = "DELETE FROM tbl_tempor WHERE `or_number_ref` = '" + tempORNumber + "' ";

               mySqlComm.Connection = db;
               mySqlComm.Transaction = trans;
               mySqlComm.ExecuteNonQuery();
               tempORID = mySqlComm.LastInsertedId.ToString();
               trans.Commit();
               db.Close();
               clearStuffs();
           } 


           // trans.Commit();


        }

        private void rb_member_CheckedChanged(object sender, EventArgs e)
        {
            defaultdisable(true);
            txt_CusNameNonMember.Visible = false;
        }

        private void rb_nonMember_CheckedChanged(object sender, EventArgs e)
        {
            defaultdisable(true);
            txt_customerName.Enabled = false;
            btn_searchThumb.Enabled = false;
            customerId = "0";
            listBox2.Visible = false;
            txt_CusNameNonMember.Visible = true;
        }

        private void txt_customerName_KeyDown(object sender, KeyEventArgs e)
        {
      

            if (e.KeyCode == Keys.Enter)
            {

                if (listBox2.Items.Count > 0)
                {

                    txt_customerName.Text = listBox2.SelectedItem.ToString();


                    if (listBox2.SelectedIndex == 0)
                    {
                        customerId = custidsuggestion[0].ToString();
                    }
                    else if (listBox2.SelectedIndex > 0)
                    {
                        customerId = custidsuggestion[listBox2.SelectedIndex].ToString();
                    }

                   // MessageBox.Show(listBox2.SelectedIndex.ToString());

                    if(customerId == ""){
                        txt_customerName.Clear();
                    }
   
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

        private void txt_customerName_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Enter)
            {
                if (txt_customerName.Text.Trim() != "")
                {
                    dbhandler.searchMemberEmployee(txt_customerName.Text, listBox2, custidsuggestion);
                }
            }

        }

        private void btn_saveSale_Click(object sender, EventArgs e)
        {
            if(listViewPurchased.Items.Count > 0){
                if (rb_nonMember.Checked)
                {
                    int id = Int32.Parse(dbhandler.newsavedTransactionLog(0));
                    foreach (ListViewItem tem in listViewPurchased.Items)
                    {
                        dbhandler.recordSavedTransaction(0, id, tem.SubItems[0].Text, Double.Parse(tem.SubItems[3].Text), Int32.Parse(tem.SubItems[1].Text), Double.Parse(tem.SubItems[2].Text), DateTime.Now.ToString("MM-yy"), DateTime.Now.ToString("yyyy-MM-dd"));

                    }
                }else if(rb_member.Checked){
                    int id = Int32.Parse( dbhandler.newsavedTransactionLog(Int32.Parse(customerId)) );
                    foreach (ListViewItem tem in listViewPurchased.Items)
                    {
                        dbhandler.recordSavedTransaction(Int32.Parse(customerId), id, tem.SubItems[0].Text, Double.Parse(tem.SubItems[3].Text), Int32.Parse(tem.SubItems[1].Text), Double.Parse(tem.SubItems[2].Text), DateTime.Now.ToString("MM-yy"), DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                }

                MessageBox.Show("Successfully saved");
                btn_cancelTrans.PerformClick();

            }

     
            
        }

        private void btn_closeReg_Click(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void txt_itemQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_enterAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_enterAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_enterAmount.Text.Trim() != "")
            {
                try
                {
                    txt_changeAmount.Text = (decimal.Parse(txt_enterAmount.Text) - (decimal)totalAmt).ToString("N");
                }
                catch
                {
                    MessageBox.Show(this, "Invalid Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }






        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label9.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {
                txt_customerName.Text = listBox2.SelectedItem.ToString();


                if (listBox2.SelectedIndex == 0)
                {
                    customerId = custidsuggestion[0].ToString();
                }
                else if (listBox2.SelectedIndex > 0)
                {
                    customerId = custidsuggestion[listBox2.SelectedIndex].ToString();
                }

                // MessageBox.Show(listBox2.SelectedIndex.ToString());

                if (customerId == "")
                {
                    txt_customerName.Clear();
                }

                listBox2.Visible = false;
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                if (listBox2.Items.Count > 0)
                {

                    txt_customerName.Text = listBox2.SelectedItem.ToString();


                    if (listBox2.SelectedIndex == 0)
                    {
                        customerId = custidsuggestion[0].ToString();
                    }
                    else if (listBox2.SelectedIndex > 0)
                    {
                        customerId = custidsuggestion[listBox2.SelectedIndex].ToString();
                    }

                    // MessageBox.Show(listBox2.SelectedIndex.ToString());


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

        private void listBoxProductTransSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxProductTransSearch.Items.Count > 0)
            {
                txt_itemName.Text = listBoxProductTransSearch.SelectedItem.ToString();
                txt_barCode.Text = itemcodelist[listBoxProductTransSearch.SelectedIndex];
                txt_barCode.Focus();
                SendKeys.Send("~");
                listBoxProductTransSearch.Visible = false;
            }
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete){
                btn_removeItem.PerformClick();
            }
        }

        private void label10_Click(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(customerId);
        }


        private void txt_enterAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int startPos = txt_enterAmount.SelectionStart;
                decimal initial = decimal.Parse(txt_enterAmount.Text);
                txt_enterAmount.Text = initial.ToString("#,##0");
                //txt_initialDep.SelectionStart = txt_initialDep.Text.IndexOf(".");
                txt_enterAmount.SelectionStart = txt_enterAmount.Text.Length;
            }
            catch { }
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





















    }
}
