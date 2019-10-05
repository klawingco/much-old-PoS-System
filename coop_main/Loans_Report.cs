using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
namespace coop_main
{
    public partial class Loans_Report : Form
    {
        List<String> custId = new List<String>();
        List<String> memberList = new List<String>();
        String searchmemberid;

        String empID;
        DatabaseStuff dbhandler = new DatabaseStuff();

        String customerId;
        int what = 1;

        DataTable t;

        bool fromLoanForms = false;

        public Loans_Report(String empID)
        {
            InitializeComponent();
            this.empID = empID;
        }

        public Loans_Report(String empID,bool fromLoanForms)
        {
            InitializeComponent();
            this.empID = empID;
            this.fromLoanForms = fromLoanForms;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportsForm f = new ReportsForm(empID);
            f.Show();
            this.Close();
        }
        private void Loans_Report_Load(object sender, EventArgs e)
        {
            label6.Text = Properties.Settings.Default.username.ToUpper();
            //  if (empID.Trim() == "" || empID == "0")
            //  {
            empID = Properties.Settings.Default.userid;


            cmb_DueLoans.SelectedIndex = 0;
            cmb_DueLoans.Visible = false;

            txt_search.GotFocus += txt_search_GotFocus;
            
        }
        private void Loans_Report_Shown(object sender, EventArgs e)
        {
            if (fromLoanForms)
            {
                btn_allDueLoan.PerformClick();
            }
            else {
                btn_allLoans.PerformClick();
            }
            
        }

        void txt_search_GotFocus(object sender, EventArgs e)
        {
            txt_search.Clear();
        }

        #region printables
        private void populateprintAllLoans()
        {
            t = new DataTable();
            t.TableName = "ds_allLoans";
            t.Columns.Add("no");
            t.Columns.Add("mem_name");
            t.Columns.Add("prin_amt");
            t.Columns.Add("term");
            t.Columns.Add("amt_due");
            t.Columns.Add("date_loan");
            t.Columns.Add("date_due");
            t.Columns.Add("status");
            t.Columns.Add("proc_by");


            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                DataRow dtrw = t.NewRow();
                dtrw[0] = dataGridView1.Rows[rw.Index].Cells[0].FormattedValue.ToString();
                dtrw[1] = dataGridView1.Rows[rw.Index].Cells[1].FormattedValue.ToString();
                dtrw[2] = dataGridView1.Rows[rw.Index].Cells[2].FormattedValue.ToString();
                dtrw[3] = dataGridView1.Rows[rw.Index].Cells[3].FormattedValue.ToString();
                dtrw[4] = dataGridView1.Rows[rw.Index].Cells[4].FormattedValue.ToString();
                dtrw[5] = dataGridView1.Rows[rw.Index].Cells[5].FormattedValue.ToString();
                dtrw[6] = dataGridView1.Rows[rw.Index].Cells[6].FormattedValue.ToString();
                dtrw[7] = dataGridView1.Rows[rw.Index].Cells[7].FormattedValue.ToString();
                dtrw[8] = dataGridView1.Rows[rw.Index].Cells[8].FormattedValue.ToString();
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportLoansAll.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_allLoans", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }

        private void populateprintAlDuelLoans()
        {
            t = new DataTable();
            t.TableName = "ds_allDueLoans";
            t.Columns.Add("no");
            t.Columns.Add("date_loan");
            t.Columns.Add("date_due");
            t.Columns.Add("mem_name");
            t.Columns.Add("amt_due");



            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                DataRow dtrw = t.NewRow();
                dtrw[0] = dataGridView1.Rows[rw.Index].Cells[0].FormattedValue.ToString();
                dtrw[1] = dataGridView1.Rows[rw.Index].Cells[1].FormattedValue.ToString();
                dtrw[2] = dataGridView1.Rows[rw.Index].Cells[2].FormattedValue.ToString();
                dtrw[3] = dataGridView1.Rows[rw.Index].Cells[3].FormattedValue.ToString();
                dtrw[4] = dataGridView1.Rows[rw.Index].Cells[4].FormattedValue.ToString();

                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportLoansDueLoans.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_allDueLoans", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }


        private void populateprintLoanPerMember()
        {
            t = new DataTable();
            t.TableName = "ds_allLoans";
            t.Columns.Add("no");
            t.Columns.Add("mem_name");
            t.Columns.Add("prin_amt");
            t.Columns.Add("term");
            t.Columns.Add("amt_due");
            t.Columns.Add("date_loan");
            t.Columns.Add("date_due");
            t.Columns.Add("status");
            t.Columns.Add("proc_by");


            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                DataRow dtrw = t.NewRow();
                dtrw[0] = dataGridView1.Rows[rw.Index].Cells[0].FormattedValue.ToString();
                dtrw[1] = dataGridView1.Rows[rw.Index].Cells[1].FormattedValue.ToString();
                dtrw[2] = dataGridView1.Rows[rw.Index].Cells[2].FormattedValue.ToString();
                dtrw[3] = dataGridView1.Rows[rw.Index].Cells[3].FormattedValue.ToString();
                dtrw[4] = dataGridView1.Rows[rw.Index].Cells[4].FormattedValue.ToString();
                dtrw[5] = dataGridView1.Rows[rw.Index].Cells[5].FormattedValue.ToString();
                dtrw[6] = dataGridView1.Rows[rw.Index].Cells[6].FormattedValue.ToString();
                dtrw[7] = dataGridView1.Rows[rw.Index].Cells[7].FormattedValue.ToString();
                dtrw[8] = dataGridView1.Rows[rw.Index].Cells[8].FormattedValue.ToString();
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportLoansPerMember.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_allLoans", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }


        private void populateprintLoanUnpaid()
        {
            t = new DataTable();
            t.TableName = "ds_allLoansUnpaid";
            t.Columns.Add("no");
            t.Columns.Add("mem_name");
            t.Columns.Add("prin_amt");
            t.Columns.Add("term");
            t.Columns.Add("amt_due");
            t.Columns.Add("date_loan");
            t.Columns.Add("date_due");
            t.Columns.Add("proc_by");


            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                DataRow dtrw = t.NewRow();
                dtrw[0] = dataGridView1.Rows[rw.Index].Cells[0].FormattedValue.ToString();
                dtrw[1] = dataGridView1.Rows[rw.Index].Cells[1].FormattedValue.ToString();
                dtrw[2] = dataGridView1.Rows[rw.Index].Cells[2].FormattedValue.ToString();
                dtrw[3] = dataGridView1.Rows[rw.Index].Cells[3].FormattedValue.ToString();
                dtrw[4] = dataGridView1.Rows[rw.Index].Cells[4].FormattedValue.ToString();
                dtrw[5] = dataGridView1.Rows[rw.Index].Cells[5].FormattedValue.ToString();
                dtrw[6] = dataGridView1.Rows[rw.Index].Cells[6].FormattedValue.ToString();
                dtrw[7] = dataGridView1.Rows[rw.Index].Cells[7].FormattedValue.ToString();
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportLoansAllUnpaid.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_allLoansUnpaid", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }

        private void populateprintLoanPaid()
        {
            t = new DataTable();
            t.TableName = "ds_allLoansUnpaid";
            t.Columns.Add("no");
            t.Columns.Add("mem_name");
            t.Columns.Add("prin_amt");
            t.Columns.Add("term");
            t.Columns.Add("amt_due");
            t.Columns.Add("date_loan");
            t.Columns.Add("date_due");
            t.Columns.Add("proc_by");


            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                DataRow dtrw = t.NewRow();
                dtrw[0] = dataGridView1.Rows[rw.Index].Cells[0].FormattedValue.ToString();
                dtrw[1] = dataGridView1.Rows[rw.Index].Cells[1].FormattedValue.ToString();
                dtrw[2] = dataGridView1.Rows[rw.Index].Cells[2].FormattedValue.ToString();
                dtrw[3] = dataGridView1.Rows[rw.Index].Cells[3].FormattedValue.ToString();
                dtrw[4] = dataGridView1.Rows[rw.Index].Cells[4].FormattedValue.ToString();
                dtrw[5] = dataGridView1.Rows[rw.Index].Cells[5].FormattedValue.ToString();
                dtrw[6] = dataGridView1.Rows[rw.Index].Cells[6].FormattedValue.ToString();
                dtrw[7] = dataGridView1.Rows[rw.Index].Cells[7].FormattedValue.ToString();
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportLoansAllPaid.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_allLoansUnpaid", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }


        private void populateprintFillinfee()
        {
            t = new DataTable();
            t.TableName = "ds_allfee";
            t.Columns.Add("no");
            t.Columns.Add("mem_name");
            t.Columns.Add("fee_amt");
            t.Columns.Add("proc_date");
            t.Columns.Add("proc_by");


            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                DataRow dtrw = t.NewRow();
                dtrw[0] = dataGridView1.Rows[rw.Index].Cells[0].FormattedValue.ToString();
                dtrw[1] = dataGridView1.Rows[rw.Index].Cells[1].FormattedValue.ToString();
                dtrw[2] = dataGridView1.Rows[rw.Index].Cells[2].FormattedValue.ToString();
                dtrw[3] = dataGridView1.Rows[rw.Index].Cells[3].FormattedValue.ToString();
                dtrw[4] = dataGridView1.Rows[rw.Index].Cells[4].FormattedValue.ToString();
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReporAllFee1.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_allfee", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }

        private void populateprintProcfee()
        {
            t = new DataTable();
            t.TableName = "ds_allfee";
            t.Columns.Add("no");
            t.Columns.Add("mem_name");
            t.Columns.Add("fee_amt");
            t.Columns.Add("proc_date");
            t.Columns.Add("proc_by");


            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                DataRow dtrw = t.NewRow();
                dtrw[0] = dataGridView1.Rows[rw.Index].Cells[0].FormattedValue.ToString();
                dtrw[1] = dataGridView1.Rows[rw.Index].Cells[1].FormattedValue.ToString();
                dtrw[2] = dataGridView1.Rows[rw.Index].Cells[2].FormattedValue.ToString();
                dtrw[3] = dataGridView1.Rows[rw.Index].Cells[3].FormattedValue.ToString();
                dtrw[4] = dataGridView1.Rows[rw.Index].Cells[4].FormattedValue.ToString();
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReporAllFeeProc.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_allfee", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }

        private void populateprintShareCapfee()
        {
            t = new DataTable();
            t.TableName = "ds_allfee";
            t.Columns.Add("no");
            t.Columns.Add("mem_name");
            t.Columns.Add("fee_amt");
            t.Columns.Add("proc_date");
            t.Columns.Add("proc_by");


            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                DataRow dtrw = t.NewRow();
                dtrw[0] = dataGridView1.Rows[rw.Index].Cells[0].FormattedValue.ToString();
                dtrw[1] = dataGridView1.Rows[rw.Index].Cells[1].FormattedValue.ToString();
                dtrw[2] = dataGridView1.Rows[rw.Index].Cells[2].FormattedValue.ToString();
                dtrw[3] = dataGridView1.Rows[rw.Index].Cells[3].FormattedValue.ToString();
                dtrw[4] = dataGridView1.Rows[rw.Index].Cells[4].FormattedValue.ToString();
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReporAllFeeShareCap.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_allfee", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }


        private void populateprintLoansProcebyUser()
        {
            t = new DataTable();
            t.TableName = "ds_allLoansProcUser";
            t.Columns.Add("no");
            t.Columns.Add("mem_name");
            t.Columns.Add("prin_amt");
            t.Columns.Add("term");
            t.Columns.Add("amt_due");
            t.Columns.Add("status");
            t.Columns.Add("proc_by");

            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                DataRow dtrw = t.NewRow();
                dtrw[0] = dataGridView1.Rows[rw.Index].Cells[0].FormattedValue.ToString();
                dtrw[1] = dataGridView1.Rows[rw.Index].Cells[1].FormattedValue.ToString();
                dtrw[2] = dataGridView1.Rows[rw.Index].Cells[2].FormattedValue.ToString();
                dtrw[3] = dataGridView1.Rows[rw.Index].Cells[3].FormattedValue.ToString();
                dtrw[4] = dataGridView1.Rows[rw.Index].Cells[4].FormattedValue.ToString();
                dtrw[5] = dataGridView1.Rows[rw.Index].Cells[5].FormattedValue.ToString();
                dtrw[6] = dataGridView1.Rows[rw.Index].Cells[6].FormattedValue.ToString();
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportLoansProcUSer.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_allLoansProcUser", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }
         
        #endregion

        private void populateprintPaymentProcUser()
        {
            t = new DataTable();
            t.TableName = "ds_allfee";
            t.Columns.Add("no");
            t.Columns.Add("mem_name");
            t.Columns.Add("fee_amt");
            t.Columns.Add("proc_date");
            t.Columns.Add("proc_by");


            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                DataRow dtrw = t.NewRow();
                dtrw[0] = dataGridView1.Rows[rw.Index].Cells[0].FormattedValue.ToString();
                dtrw[1] = dataGridView1.Rows[rw.Index].Cells[1].FormattedValue.ToString();
                dtrw[2] = dataGridView1.Rows[rw.Index].Cells[2].FormattedValue.ToString();
                dtrw[3] = dataGridView1.Rows[rw.Index].Cells[3].FormattedValue.ToString();
                dtrw[4] = dataGridView1.Rows[rw.Index].Cells[4].FormattedValue.ToString();
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportLoanPayment.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_allfee", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }

        private void printNOW() {

            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                if (what == 1)
                {
                    populateprintAllLoans();
                }
                else if (what == 2)
                {
                    alldueLoanMethod();
                }
                else if (what == 3)
                {
                    populateprintLoanPerMember();
                }
                else if (what == 4)
                {
                    populateprintLoanUnpaid();
                }
                else if (what == 5)
                {
                    populateprintLoanPaid();
                }
                else if (what == 6)
                {
                    populateprintFillinfee();
                }
                else if (what == 7)
                {
                    populateprintProcfee();
                }
                else if (what == 8)
                {
                    populateprintShareCapfee();
                }
                else if (what == 9)
                {
                    populateprintLoansProcebyUser();
                }
                else if (what == 10)
                {
                    populateprintPaymentProcUser();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                this.UseWaitCursor = false;
            }

        
        }

        private void disableSortMode()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void btn_allLoans_Click(object sender, EventArgs e)
        {

            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                what = 1;
                txt_search.Text = "  Type Member's Name to Search";
                cmb_DueLoans.Visible = false;
                lbl_dueIn.Visible = false;

                ch_startDate.Visible = true;
                ch_endDate.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;

                dbhandler.AllLoansReport(dataGridView1);
                listBox1.Visible = false;
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

        private void btn_allDueLoan_Click(object sender, EventArgs e)
        {

            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                what = 2;
                txt_search.Text = "  Type Member's Name to Search";
                cmb_DueLoans.Visible = true;

                alldueLoanMethod();

                lbl_dueIn.Visible = true;

                ch_startDate.Visible = false;
                ch_endDate.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                listBox1.Visible = false;
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

        private void btn_loanperMem_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                what = 3;
                txt_search.Text = "  Type Member's Name to Search";
                cmb_DueLoans.Visible = false;
                lbl_dueIn.Visible = false;

                ch_startDate.Visible = true;
                ch_endDate.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;

                dbhandler.AllLoansReportOFMember(dataGridView1, "");

                listBox1.Visible = false;



                toolTip1.ToolTipTitle = "Important Tip!";
                toolTip1.Show("Type Member's Name to Search to view \n All Loans of a member.", txt_search, 3000);
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

        private void btn_unpaidloan_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                what = 4;
                txt_search.Text = "  Type Member's Name to Search";
                cmb_DueLoans.Visible = false;

                lbl_dueIn.Visible = false;

                ch_startDate.Visible = true;
                ch_endDate.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;

                dbhandler.AllUnpaidLoansReport(dataGridView1);

                listBox1.Visible = false;
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

        private void btn_paidloans_Click(object sender, EventArgs e)
        {

            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                what = 5;
                txt_search.Text = "  Type Member's Name to Search";
                cmb_DueLoans.Visible = false;
                lbl_dueIn.Visible = false;

                ch_startDate.Visible = true;
                ch_endDate.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;

                dbhandler.AllPaidLoansReport(dataGridView1);

                listBox1.Visible = false;
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

        private void btn_fillingfee_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                what = 6;
                txt_search.Text = "  Type Member's Name to Search";
                cmb_DueLoans.Visible = false;
                lbl_dueIn.Visible = false;

                ch_startDate.Visible = true;
                ch_endDate.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;

                dbhandler.AllFilingFee(dataGridView1);
                listBox1.Visible = false;

                disableSortMode();
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


        private void btn_processfee_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                what = 7;
                txt_search.Text = "  Type Member's Name to Search";
                cmb_DueLoans.Visible = false;
                lbl_dueIn.Visible = false;

                ch_startDate.Visible = true;
                ch_endDate.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;

                dbhandler.AllProcessFee(dataGridView1);

                listBox1.Visible = false;
                disableSortMode();
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

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                what = 8;
                txt_search.Text = "  Type Member's Name to Search";
                cmb_DueLoans.Visible = false;
                lbl_dueIn.Visible = false;

                ch_startDate.Visible = true;
                ch_endDate.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;

                dbhandler.AllSharecapitaFee(dataGridView1);

                listBox1.Visible = false;
                disableSortMode();
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

        private void btn_loansprocbyuser_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                what = 9;
                txt_search.Text = "  Type User's Name to Search";
                dbhandler.AllLoansReportProcessPerUser(dataGridView1, "");
                cmb_DueLoans.Visible = false;
                lbl_dueIn.Visible = false;

                ch_startDate.Visible = true;
                ch_endDate.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;


                listBox1.Visible = false;

                toolTip1.ToolTipTitle = "Important Tip!";
                toolTip1.Show("Type User's Name to Search to view \n All Loans of processed of a user.", txt_search, 3000);
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

        private void btn_paymentprocbyuser_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                what = 10;
                txt_search.Text = "  Type User's Name to Search";
                dbhandler.AllLoanPaymentReportProcessPerUser(dataGridView1, "");
                cmb_DueLoans.Visible = false;
                lbl_dueIn.Visible = false;

                ch_startDate.Visible = true;
                ch_endDate.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;


                listBox1.Visible = false;


                toolTip1.ToolTipTitle = "Important Tip!";
                toolTip1.Show("Type User's Name to Search to view \n All Payments of processed of a user.", txt_search, 3000);
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

        #region combo
     
        private void cmb_DueLoans_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                alldueLoanMethod();
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

        private void alldueLoanMethod()
        {
            String startDate = "", endDate = "";
            if (cmb_DueLoans.SelectedIndex == 0)
            {
                startDate = DateTime.Now.ToString("yyyy-MM-dd");
                endDate = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
            }
            else if (cmb_DueLoans.SelectedIndex == 1)
            {
                startDate = DateTime.Now.ToString("yyyy-MM-dd");
                endDate = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
            }
            else if (cmb_DueLoans.SelectedIndex == 2)
            {
                startDate = DateTime.Now.ToString("yyyy-MM-dd");
                endDate = DateTime.Now.AddMonths(4).ToString("yyyy-MM-dd");
            }
            else if (cmb_DueLoans.SelectedIndex == 3)
            {
                startDate = DateTime.Now.ToString("yyyy-MM-dd");
                endDate = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
            }


            dbhandler.AllDueLoansReport(dataGridView1, startDate, endDate);
            populateprintAlDuelLoans();
        }
        #endregion

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Enter)
            {

                try
                {
                    this.UseWaitCursor = true;
                    Cursor.Current = Cursors.WaitCursor;
                    Application.DoEvents();



                    if (txt_search.Text.Trim() != "" && what != 9 && what != 10)
                    {

                        dbhandler.searchMemberEmployee(txt_search.Text.Replace("'", "`"), listBox1, custId);
                    }
                    else if (txt_search.Text.Trim() != "" && what == 9)
                    {
                        dbhandler.searchUserEmployeeAuditTrail(txt_search.Text, listBox1, memberList);
                    }
                    else if (txt_search.Text.Trim() != "" && what == 10)
                    {
                        dbhandler.searchUserEmployeeAuditTrail(txt_search.Text, listBox1, memberList);
                    }
                    else
                    {
                        listBox1.Visible = false;
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

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (listBox1.Items.Count > 0)
                {
                    selectMember();
                    btn_search.PerformClick();
                }
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

        private void selectMember()
        {
            if (listBox1.Items.Count > 0)
            {
                txt_search.Text = listBox1.SelectedItem.ToString();
                if (listBox1.SelectedIndex == 0)
                {
                    if(what != 9 && what != 10){
                        customerId = custId[0].ToString();
                    }else if(what == 9 || what == 10){
                        searchmemberid = memberList[0].ToString();
                    }
                }
                else if (listBox1.SelectedIndex > 0)
                {
                    if (what != 9 && what != 10) {
                        customerId = custId[listBox1.SelectedIndex].ToString();
                    }
                    else if (what == 9 || what == 10)
                    {
                        searchmemberid = memberList[listBox1.SelectedIndex].ToString();
                    }
                    
                }
            }

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();


                selectMember();
                if (what != 9 && what != 10)
                {
                    dbhandler.AllLoansReportOFMember(dataGridView1, customerId);

                }
                else if (what == 9)
                {
                    dbhandler.AllLoansReportProcessPerUser(dataGridView1, searchmemberid);
                }
                else if (what == 10)
                {
                    dbhandler.AllLoanPaymentReportProcessPerUser(dataGridView1, searchmemberid);
                }
                listBox1.Visible = false;
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

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_search.PerformClick();
        }

        private void btn_ePDF_Click(object sender, EventArgs e)
        {
            printmessage pd = new printmessage();
            DialogResult res = pd.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                printNOW();
                OpenFileDialog ds = new OpenFileDialog();
                SaveFileDialog s = new SaveFileDialog();

                if (what == 1)
                {
                    s.FileName = "All Loans REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (what == 2)
                {
                    s.FileName = "All Due Loans REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (what == 3)
                {
                    s.FileName = "All Unpaid Loans REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (what == 4)
                {
                    s.FileName = "All Paid Loans REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (what == 5)
                {
                    s.FileName = "All Filling fees REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (what == 6)
                {
                    s.FileName = "All Processing fees REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (what == 7)
                {
                    s.FileName = "All Share Capita Return fees REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (what == 8)
                {
                    s.FileName = "All Share Capita Return fees REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (what == 9)
                {
                    s.FileName = "All Loans Processed by a User REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (what == 10)
                {
                    s.FileName = "All Loans Payment by a User REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }

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

        private void btn_eExcel_Click(object sender, EventArgs e)
        {
            printNOW();
            SaveFileDialog s = new SaveFileDialog();
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            if (what == 1)
            {
                s.FileName = "All Loans REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
            }
            else if (what == 2)
            {
                s.FileName = "All Due Loans REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
            }
            else if (what == 3)
            {
                s.FileName = "All Unpaid Loans REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
            }
            else if (what == 4)
            {
                s.FileName = "All Paid Loans REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
            }
            else if (what == 5)
            {
                s.FileName = "All Filling fees REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
            }
            else if (what == 6)
            {
                s.FileName = "All Processing fees REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
            }
            else if (what == 7)
            {
                s.FileName = "All Share Capita Return fees REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
            }
            else if (what == 8)
            {
                s.FileName = "All Share Capita Return fees REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
            }
            else if (what == 9)
            {
                s.FileName = "All Loans Processed by a User REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
            }
            else if (what == 10)
            {
                s.FileName = "All Loans Payment by a User REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
            }
            byte[] bytes = reportViewer1.LocalReport.Render(
                "EXCEL", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);


            s.ShowDialog();
            using (System.IO.FileStream fs = new System.IO.FileStream(s.FileName, System.IO.FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);

            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            
            inv_print print = new inv_print();
            DialogResult res = print.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                printNOW();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label5.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void ch_startDate_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_startDate.Checked)
            {
                ch_endDate.Checked = true;
            }
            else {
                ch_endDate.Checked = false;
            }
        }

        private void ch_endDate_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_endDate.Checked)
            {
                ch_startDate.Checked = true;
            }
            else
            {
                ch_startDate.Checked = false;
            }
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
