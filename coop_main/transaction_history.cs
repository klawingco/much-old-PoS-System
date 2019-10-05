using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
namespace coop_main
{
    public partial class transaction_history : Form
    {
        DatabaseStuff dbhandler = new DatabaseStuff();
        String empID;

        DataTable t;
        public transaction_history(String empID)
        {
            InitializeComponent();
            this.empID = empID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_eExcel_Click(object sender, EventArgs e)
        {
            trans_confirm_excel f1 = new trans_confirm_excel();
            DialogResult res =  f1.ShowDialog();


              if(res == System.Windows.Forms.DialogResult.Yes){

                  try
                  {
                      this.UseWaitCursor = true;
                      Cursor.Current = Cursors.WaitCursor;
                      Application.DoEvents();
                      populateprintTransHistory();
                  }
                  catch (Exception)
                  {
                      message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                      mes.ShowDialog(mes.Parent);
                  }
                  finally
                  {
                      this.UseWaitCursor = false;
                  }

                  SaveFileDialog s = new SaveFileDialog();
                  s.FileName = "Transaction History Report" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";


                  Warning[] warnings;
                  string[] streamids;
                  string mimeType;
                  string encoding;
                  string filenameExtension;

                  byte[] bytes = reportViewer1.LocalReport.Render(
                      "EXCEL", null, out mimeType, out encoding, out filenameExtension,
                      out streamids, out warnings);


                  s.ShowDialog();
                  using (System.IO.FileStream fs = new System.IO.FileStream(s.FileName, System.IO.FileMode.Create))
                  {
                      fs.Write(bytes, 0, bytes.Length);

                  }
            
              }






        }


        private void btn_ePDF_Click(object sender, EventArgs e)
        {
            trans_confirm_pdf f1 = new trans_confirm_pdf();
          DialogResult res =   f1.ShowDialog(this);
            if(res == System.Windows.Forms.DialogResult.Yes){

                try
                {
                    this.UseWaitCursor = true;
                    Cursor.Current = Cursors.WaitCursor;
                    Application.DoEvents();
                    populateprintTransHistory();
                }
                catch (Exception)
                {
                    message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                    mes.ShowDialog(mes.Parent);
                }
                finally
                {
                    this.UseWaitCursor = false;
                }
               
                SaveFileDialog s = new SaveFileDialog();
                s.FileName = "Transaction History Report" + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
             
             
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string filenameExtension;

                byte[] bytes = reportViewer1.LocalReport.Render(
                    "PDF", null, out mimeType, out encoding, out filenameExtension,
                    out streamids, out warnings);


                s.ShowDialog();
                using (System.IO.FileStream fs = new System.IO.FileStream(s.FileName, System.IO.FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);

                }
            
            }


        }

        private void btn_printTransHistory_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                populateprintTransHistory();


                trans_confirm_print f1 = new trans_confirm_print();
                DialogResult res = f1.ShowDialog(this);

                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    PrinterSettings set = new PrinterSettings();
                    set.DefaultPageSettings.Landscape = true;
                    set.DefaultPageSettings.Margins = new Margins(25, 25, 25, 25);
                    set.DefaultPageSettings.PrinterSettings.Copies = 1;
                    reportViewer1.PrintDialog(set);
                }
                else
                {

                }







            }
            catch (Exception)
            {
                message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                mes.ShowDialog(mes.Parent);
            }
            finally
            {
                this.UseWaitCursor = false;
            }



   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            transaction f = new transaction(empID);
            f.Show();
            this.Close();
        }
        #region printables

        private void populateprintTransHistory()
        {
            t = new DataTable();
            t.TableName = "ds_transhistory";
            t.Columns.Add("or_num");
            t.Columns.Add("date_pur");
            t.Columns.Add("emp_name");
            t.Columns.Add("mem_id");
            t.Columns.Add("mem_name");
            t.Columns.Add("total_amt_purch");

            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                DataRow dtrw = t.NewRow();
                dtrw[0] = dataGridView1.Rows[rw.Index].Cells[0].FormattedValue.ToString();
                dtrw[1] = dataGridView1.Rows[rw.Index].Cells[1].FormattedValue.ToString();
                dtrw[2] = dataGridView1.Rows[rw.Index].Cells[2].FormattedValue.ToString();
                dtrw[3] = dataGridView1.Rows[rw.Index].Cells[3].FormattedValue.ToString();
                dtrw[4] = dataGridView1.Rows[rw.Index].Cells[4].FormattedValue.ToString();
                dtrw[5] = dataGridView1.Rows[rw.Index].Cells[5].FormattedValue.ToString();
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportMiscTransHistory.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_transhistory", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }
        #endregion

        private void transaction_history_Load(object sender, EventArgs e)
        {
            label10.Text = Properties.Settings.Default.username.ToUpper();
          //  if (empID.Trim() == "" || empID == "0")
          //  {
                empID = Properties.Settings.Default.userid;
           // }
            
        }


        private void transaction_history_Shown(object sender, EventArgs e)
        {
            try {

                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();


                dbhandler.popilateTransWhole(dataGridView1);
                
                txt_transCount.Text = (dataGridView1.Rows.Count - 1).ToString();
                txt_totalTrans.Text = dbhandler.gettotalAmountTrans();
            
            }
            catch(Exception) {
                message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                mes.ShowDialog(mes.Parent);
            }
            finally {
                this.UseWaitCursor = false;
            }





        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                if (ch_startDate.Checked && ch_endDate.Checked)
                {
                    dbhandler.popilateTransWholeBetween(dataGridView1, dateTimePicker1.Value, dateTimePicker2.Value);
                    txt_transCount.Text = (dataGridView1.Rows.Count - 1).ToString();
                    txt_totalTrans.Text = dbhandler.gettotalAmountTransBetween(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"));

                }
                else if (ch_startDate.Checked && !ch_endDate.Checked)
                {
                    dbhandler.popilateTransWholeBetween(dataGridView1, dateTimePicker1.Value, dateTimePicker1.Value);
                    txt_transCount.Text = (dataGridView1.Rows.Count - 1).ToString();
                    txt_totalTrans.Text = dbhandler.gettotalAmountTransBetween(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker1.Value.ToString("yyyy-MM-dd"));

                }
                else if (!ch_startDate.Checked && ch_endDate.Checked)
                {
                    dbhandler.popilateTransWholeBetween(dataGridView1, dateTimePicker2.Value, dateTimePicker2.Value);
                    txt_transCount.Text = (dataGridView1.Rows.Count - 1).ToString();
                    txt_totalTrans.Text = dbhandler.gettotalAmountTransBetween(dateTimePicker2.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"));

                }
                else if (!ch_startDate.Checked && !ch_endDate.Checked)
                {
                    dbhandler.popilateTransWhole(dataGridView1);

                    txt_transCount.Text = (dataGridView1.Rows.Count - 1).ToString();
                    txt_totalTrans.Text = dbhandler.gettotalAmountTrans();
                }

                //populateprintTransHistory();
            
            }
            catch(Exception) {
                message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                mes.ShowDialog(mes.Parent);
            }
            finally {
                this.UseWaitCursor = false;
            }

          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label7.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void ch_startDate_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_startDate.Checked)
            {
                ch_endDate.Checked = true;
                btn_search.PerformClick();
            }
            else {
                ch_endDate.Checked = false;
                btn_search.PerformClick();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            btn_search.PerformClick();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            btn_search.PerformClick();
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
