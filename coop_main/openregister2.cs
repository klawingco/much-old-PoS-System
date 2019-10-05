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
    public partial class openregister2 : Form
    {
        public bool okay = false;
        public String transid = "";
        public double total;
        public decimal nettotal;
        public decimal taxttotal;
        public String customerid = "";
        String empId ;
        DatabaseStuff dbhandler = new DatabaseStuff();


        private int itemToPrint;
        private long or_number;

        //public openregister2(String empID)
        //{
        //    InitializeComponent();
        //    this.empId = empID;
        //}
        public openregister2(String empID,ListBox box, ListView view)
        {
            InitializeComponent();

            this.empId = empID;

            listBox1.DataSource = box.DataSource;

            foreach (ListViewItem tem in view.Items)
            {

                ListViewItem temp = new ListViewItem(tem.SubItems[0].Text);
                temp.SubItems.Add(tem.SubItems[1].Text);
                temp.SubItems.Add(tem.SubItems[2].Text);
                temp.SubItems.Add(tem.SubItems[3].Text);
                temp.Tag = tem.Tag.ToString();
                listViewPurchased.Items.Add(temp);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void rb_check_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Enabled = true;
        }

        private void rb_debitCard_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Enabled = false;
        }

        private void rb_visa_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Enabled = false;
        }

        private void rb_amex_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Enabled = false;
        }

        private void rb_masterCard_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Enabled = false;
        }

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

        private void btn_printReciept_Click(object sender, EventArgs e)
        {
            bool checkEnteredAmtifValid = false;
            try {
                if((Double.Parse(txt_enterAmount.Text) - total) >= 0){
                    checkEnteredAmtifValid = true;
                }
                else
                {
                    checkEnteredAmtifValid = false;
                }
            }
            catch {
                MessageBox.Show(this, "The tendered amount was invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (txt_enterAmount.Text.Trim() != "" && txt_enterAmount.Text.Trim() != "Enter Amount" && checkEnteredAmtifValid)
            {
                confirm_print f1 = new confirm_print();
         
                f1.txt_paymentDetails.Text = "Total Amount : " + txt_total.Text;
                f1.txt_paymentDetails.AppendText("\r\n" + "Amount Tendered :" + txt_enterAmount.Text);
                f1.txt_paymentDetails.AppendText("\r\n" + "Change Amount : " + txt_changeAmount.Text);
                DialogResult res = f1.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    //do code for printing and database handliung here

                    try {
                        this.UseWaitCursor = true;
                        Cursor.Current = Cursors.WaitCursor;
                        Application.DoEvents();



                        finalizeTransaction();
                        dbhandler.insertAuditTrail(empId, "Point of Sale", "Open Register", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                        okay = true;

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

                        f1.Close();

                        this.btn_printReciept.DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                    catch(Exception) {
                        message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                        mes.ShowDialog(mes.Parent);
                    }
                    finally
                    {
                        this.UseWaitCursor = false;
                    }


                
                   
       
                    
                }
                else {

                 //   f1.Close();
                }
            }
            else {
                MessageBox.Show(this, "The tendered money was insufficient", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
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
                ev.Graphics.DrawString("PURCHASE RECEIPT", new Font("Courier New", 13), new SolidBrush(Color.Black), 30, 30);
                ev.Graphics.DrawString("-COOP NAME-", new Font("Courier New", 13), new SolidBrush(Color.Black), 30, 50);




                offset += 25;

                ev.Graphics.DrawString("OR NO...... " + or_number.ToString("D4"), printFont, new SolidBrush(Color.Black), 30, offset);

                offset += 25;
                ev.Graphics.DrawString("TRANS NO...... " + txt_invoiceNum.Text, printFont, new SolidBrush(Color.Black), 30, offset);

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
                ev.Graphics.DrawString("-----TOTAL AMOUNT "+ txt_total.Text + "-----", new Font("Courier New", 10), new SolidBrush(Color.Black), 30, offset);


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












        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 40;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        private void openregister2_Load(object sender, EventArgs e)
        {

            label10.Text = Properties.Settings.Default.username.ToUpper();
           // if (empId.Trim() == "" || empId == "0")
           // {
                empId = Properties.Settings.Default.userid;
           // }


            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            txt_invoiceNum.Text = "Trans # : " +  transid;

            txt_total.Text = "Total : "+ total.ToString("N");
            txt_total.Tag = total;

            txt_changeAmount.GotFocus += txt_changeAmount_GotFocus;
            txt_changeAmount.LostFocus += txt_changeAmount_LostFocus;

            txt_enterAmount.GotFocus += txt_enterAmount_GotFocus;
            txt_enterAmount.LostFocus += txt_enterAmount_LostFocus;






          
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
            rb_cash.Checked = true;
        }

        void txt_changeAmount_LostFocus(object sender, EventArgs e)
        {
            if (txt_changeAmount.Text.Trim() == "")
            {
                txt_changeAmount.Text = "Change Amount";
            }
        }

        void txt_changeAmount_GotFocus(object sender, EventArgs e)
        {
            if (txt_changeAmount.Text.Trim() == "Change Amount")
            {
                txt_changeAmount.Text = "";
            }
        }

        private void txt_enterAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_enterAmount.Text.Trim() != "")
            {
                try
                {
                    txt_changeAmount.Text = (decimal.Parse(txt_enterAmount.Text) -  (decimal) total ).ToString("N");
                }
                catch
                {
                    MessageBox.Show(this, "Invalid Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
      
        }

        private void finalizeTransaction()
        {
            int id = Int32.Parse(transid);
            int cusID = Int32.Parse(customerid);
            string transactionsql = "";
            string deductsql = "";
            int totalItems = 0;
            foreach (ListViewItem tem in listViewPurchased.Items)
            {

                transactionsql += "INSERT INTO tbl_transactions(customer_id, translog_id, item_name, item_price, item_qty_bought, total_amt, bought_period) VALUES ('" + cusID + "', '" + id + "', '" + tem.SubItems[0].Text + "', '" + Double.Parse(tem.SubItems[3].Text) + "', '" + Int32.Parse(tem.SubItems[1].Text) + "', '" + Double.Parse(tem.SubItems[2].Text) + "', '" + DateTime.Now.ToString("MM-yy") + "');";
                deductsql += "UPDATE tbl_items SET quantity = quantity -'" + Int32.Parse(tem.SubItems[1].Text) + "' WHERE item_code = '" + tem.Tag.ToString() + "'; ";
                totalItems += Int32.Parse(tem.SubItems[1].Text);
               
            }

                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

             // or_number =  dbhandler.recordPurchases(transactionsql, deductsql, customerid, transid, total,totalItems, empId);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label9.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void txt_enterAmount_KeyPress(object sender, KeyPressEventArgs e)
        {

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

        private void btn_cancel_Click(object sender, EventArgs e)
        {

        }



    }
}
