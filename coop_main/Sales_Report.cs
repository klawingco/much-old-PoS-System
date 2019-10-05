using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;

namespace coop_main
{
    public partial class Sales_Report : Form
    {
        String empID;
        DatabaseStuff dbhandler = new DatabaseStuff();
        DataTable t;
        int whattab;
        public Sales_Report(String empID)
        {
            InitializeComponent();
            this.empID = empID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportsForm rep = new ReportsForm(empID);
            rep.Show();
            this.Close();
        }

        #region misc
        private void Sales_Report_Load(object sender, EventArgs e)
        {
            label6.Text = Properties.Settings.Default.username.ToUpper();
            empID = Properties.Settings.Default.userid;
            txt_search.GotFocus += txt_search_GotFocus;
            txt_search.LostFocus += txt_search_LostFocus;
        }

        private void Sales_Report_Shown(object sender, EventArgs e)
        {
            btn_allProd.PerformClick();
        }


        void txt_search_LostFocus(object sender, EventArgs e)
        {
            if (txt_search.Text.Trim() == "")
            {
                txt_search.Text = txt_search.Tag.ToString();
            }
        }

        void txt_search_GotFocus(object sender, EventArgs e)
        {
                txt_search.Text = "";
        }

        private void disableSortMode() { 
            foreach(DataGridViewColumn col in dataGridView1.Columns){
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        
        }

        #endregion


        #region printables
        private void populateprintAllSalesCustSumm()
        {
            t = new DataTable();
            t.TableName = "ds_salesAllCusSum";
            t.Columns.Add("or_num");
            t.Columns.Add("date_trans");
            t.Columns.Add("no_items");
            t.Columns.Add("amt");
            t.Columns.Add("mem_name");
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
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportSalesByAllCusSum.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_salesAllCusSum", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }


        private void populateprintAllSalesCustMemOnly()
        {
            t = new DataTable();
            t.TableName = "ds_salesAllCusSum";
            t.Columns.Add("or_num");
            t.Columns.Add("date_trans");
            t.Columns.Add("no_items");
            t.Columns.Add("amt");
            t.Columns.Add("mem_name");
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
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportSalesByAllCusMemOnly.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_salesAllCusSum", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }


        private void populateprintAllSalesCustNonMemOnly()
        {
            t = new DataTable();
            t.TableName = "ds_salesAllCusSum";
            t.Columns.Add("or_num");
            t.Columns.Add("date_trans");
            t.Columns.Add("no_items");
            t.Columns.Add("amt");
            t.Columns.Add("mem_name");
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
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportSalesByAllCusNonMemOnly.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_salesAllCusSum", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }


        private void populateprintAllSavedTrans()
        {
            t = new DataTable();
            t.TableName = "ds_savedSales";
            t.Columns.Add("save_id");
            t.Columns.Add("cus_id");
            t.Columns.Add("cus_name");
            t.Columns.Add("trans");


            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                DataRow dtrw = t.NewRow();
                dtrw[0] = dataGridView1.Rows[rw.Index].Cells[0].FormattedValue.ToString();
                dtrw[1] = dataGridView1.Rows[rw.Index].Cells[1].FormattedValue.ToString();
                dtrw[2] = dataGridView1.Rows[rw.Index].Cells[2].FormattedValue.ToString();
                dtrw[3] = dataGridView1.Rows[rw.Index].Cells[3].FormattedValue.ToString();
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportSavedTrans.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_savedSales", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }


        private void populateprintAllSalesByItems()
        {
            t = new DataTable();
            t.TableName = "ds_salesByItems";
            t.Columns.Add("no");
            t.Columns.Add("item_desc");
            t.Columns.Add("total_items");
            t.Columns.Add("amt");


            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                DataRow dtrw = t.NewRow();
                dtrw[0] = dataGridView1.Rows[rw.Index].Cells[0].FormattedValue.ToString();
                dtrw[1] = dataGridView1.Rows[rw.Index].Cells[1].FormattedValue.ToString();
                dtrw[2] = dataGridView1.Rows[rw.Index].Cells[2].FormattedValue.ToString();
                dtrw[3] = dataGridView1.Rows[rw.Index].Cells[3].FormattedValue.ToString();
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportSalesByItems.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_salesByItems", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }

        private void populateprintAllSalesByCusDetails()
        {
            t = new DataTable();
            t.TableName = "ds_SalesAllCusDet";
            t.Columns.Add("or_no");
            t.Columns.Add("date");
            t.Columns.Add("no_item");
            t.Columns.Add("amt");
            t.Columns.Add("mem_name");
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
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportSalesAllCusDetail.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_SalesAllCusDet", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }
        private void populateprintAllSalesByCusDetailsMember()
        {
            t = new DataTable();
            t.TableName = "ds_SalesAllCusDet";
            t.Columns.Add("or_no");
            t.Columns.Add("date");
            t.Columns.Add("no_item");
            t.Columns.Add("amt");
            t.Columns.Add("mem_name");
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
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportSalesAllCusDetailMemOnly.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_SalesAllCusDet", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }
        private void populateprintAllSalesByCusDetailsNonMember()
        {
            t = new DataTable();
            t.TableName = "ds_SalesAllCusDet";
            t.Columns.Add("or_no");
            t.Columns.Add("date");
            t.Columns.Add("no_item");
            t.Columns.Add("amt");
            t.Columns.Add("mem_name");
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
                t.Rows.Add(dtrw);
            }
            reportViewer1.LocalReport.ReportPath = @"ReportSalesAllCusDetailNonMemOnly.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_SalesAllCusDet", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }




        private void populateprintAllSalesProcby()
        {
            t = new DataTable();
            t.TableName = "ds_SalesProcBy";
            t.Columns.Add("or_no");
            t.Columns.Add("mem_name");
            t.Columns.Add("total");
            t.Columns.Add("total_qty");
            t.Columns.Add("date");
            t.Columns.Add("process_by");

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
            reportViewer1.LocalReport.ReportPath = @"ReportSalesProcessBy.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_SalesProcBy", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }
        
        #endregion



        private void btn_allProd_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                whattab = 1;
                dbhandler.salesByAllCustSumm(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                
                txt_search.Text = "Type Member's Name to Search";
                txt_search.Tag = "Type Member's Name to Search";
                disableSortMode();
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
     

        private void btn_reqProd_Click(object sender, EventArgs e)
        {

            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                whattab = 2;
                dbhandler.salesByAllCustSummMemberOnly(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                txt_search.Text = "Type Member's Name to Search";
                txt_search.Tag = "Type Member's Name to Search";
                disableSortMode();
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

        private void btn_recProd_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                whattab = 3;
                dbhandler.salesByAllCustSummNONMemberOnly(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                disableSortMode();
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

        private void btn_salesCusDetails_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                whattab = 4;
                dbhandler.salesByAllCustSalesWithDetails(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                disableSortMode();
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

        private void btn_cusDetaSaleByMember_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                whattab = 5;
                dbhandler.salesByAllCustSalesMemberOnlyWithDetails(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                disableSortMode();
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

        private void btn_cusDetaNonMem_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                whattab = 6;
                dbhandler.salesByAllCustSalesNONMemberOnlyWithDetails(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                disableSortMode();
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
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                whattab = 7;
                dbhandler.populateSavedTrans2(dataGridView1, "2", false, dateTimePicker1.Value, dateTimePicker2.Value);
                disableSortMode();
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                whattab = 8;
                dbhandler.salesbyItem(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                disableSortMode();
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

        private void btn_salesprocperUser_Click(object sender, EventArgs e)
        {

            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                whattab = 9;
                dbhandler.salesProcessPerUser(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                txt_search.Text = "Type User's Name to Search";
                txt_search.Tag = "Type User's Name to Search";
                message mes = new message("Type the User's name in the searchbar\nto filter the data");
                mes.ShowDialog(this);
                disableSortMode();
                //no report
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



        private void toReport() {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                if (whattab == 1)
                {
                    populateprintAllSalesCustSumm();
                }
                else if (whattab == 2)
                {
                    populateprintAllSalesCustMemOnly();
                }
                else if (whattab == 3)
                {
                    populateprintAllSalesCustNonMemOnly();
                }
                else if (whattab == 4)
                {
                    populateprintAllSalesByCusDetails();
                }
                else if (whattab == 5)
                {
                    populateprintAllSalesByCusDetailsMember();
                }
                else if (whattab == 6)
                {
                    populateprintAllSalesByCusDetailsNonMember();
                }
                else if (whattab == 7)
                {
                    populateprintAllSavedTrans();
                }
                else if (whattab == 8)
                {
                    populateprintAllSalesByItems();
                }
                else if (whattab == 9)
                {
                    populateprintAllSalesProcby();
                }
            }
            catch (Exception s)
            {
                message mes = new message("ERROR:" + s.Message);
                System.Media.SystemSounds.Hand.Play();
                mes.ShowDialog(mes.Parent);

            }
            finally
            {
                this.UseWaitCursor = false;
            }
        
        }
        private void btn_ePDF_Click(object sender, EventArgs e)
        {
            toReport();
            printmessage ms = new printmessage();
            DialogResult res = ms.ShowDialog();
            if(res == System.Windows.Forms.DialogResult.Yes){
                OpenFileDialog ds = new OpenFileDialog();
                SaveFileDialog s = new SaveFileDialog();
                
                if (whattab == 1)
                {
                    s.FileName = "Sales By All Customers " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (whattab == 2)
                {
                    s.FileName = "Sales By All Member Customers " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (whattab == 3)
                {
                    s.FileName = "Sales By All Non - Member Customers " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if(whattab == 4){
                    populateprintAllSalesByCusDetails(); //populate in reportviewer
                    s.FileName = "Sales By All Customers DETAILED " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (whattab == 5)
                {
                    populateprintAllSalesByCusDetailsMember();//populate in reportviewer
                    s.FileName = "Sales By All Member Customers DETAILED " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (whattab == 6)
                {
                    populateprintAllSalesByCusDetailsNonMember();//populate in reportviewer
                    s.FileName = "Sales By All Non Member Customers DETAILED " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (whattab == 7)
                {
                    s.FileName = "Saved Transaction " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (whattab == 8)
                {
                    s.FileName = "Sales By All Items " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (whattab == 9)
                {
                    s.FileName = "Sales Process By " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
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
            toReport();
            inv_excel ms = new inv_excel();
            DialogResult res = ms.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                OpenFileDialog ds = new OpenFileDialog();
                SaveFileDialog s = new SaveFileDialog();

                if (whattab == 1)
                {
                    s.FileName = "Sales By All Customers " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }
                else if (whattab == 2)
                {
                    s.FileName = "Sales By All Member Customers " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }
                else if (whattab == 3)
                {
                    s.FileName = "Sales By All Non - Member Customers " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }
                else if (whattab == 4)
                {
                    populateprintAllSalesByCusDetails(); //populate in reportviewer
                    s.FileName = "Sales By All Customers DETAILED " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }
                else if (whattab == 5)
                {
                    populateprintAllSalesByCusDetailsMember();//populate in reportviewer
                    s.FileName = "Sales By All Member Customers DETAILED " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }
                else if (whattab == 6)
                {
                    populateprintAllSalesByCusDetailsNonMember();//populate in reportviewer
                    s.FileName = "Sales By All Non Member Customers DETAILED " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }
                else if (whattab == 7)
                {
                    s.FileName = "Saved Transaction " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }
                else if (whattab == 8)
                {
                    s.FileName = "Sales By All Items " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }
                else if (whattab == 9)
                {
                    s.FileName = "Sales Process By " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }

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
        private void btn_print_Click(object sender, EventArgs e)
        {
            toReport();
            printmessageR print = new printmessageR();
            DialogResult res = print.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                PrinterSettings set = new PrinterSettings();
                set.DefaultPageSettings.Landscape = true;
                set.DefaultPageSettings.Margins = new Margins(25, 25, 25, 25);
                set.DefaultPageSettings.PrinterSettings.Copies = 1;
                reportViewer1.PrintDialog(set);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label5.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {

                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();



                if (dataGridView1.SelectedCells[0].Value.ToString() == "Expand")
                {
                    int index = dataGridView1.SelectedCells[0].RowIndex;
                    string or_number = dataGridView1.Rows[index].Cells[0].FormattedValue.ToString();

                    dbhandler.salesByAllCustSummMemberOnlyWithDetailsEXPAND(dataGridView1, index, or_number);
                    dataGridView1.SelectedCells[0].Value = "---";

                }

                else if (dataGridView1.SelectedCells[0].Value.ToString() == "Open in Register")
                {
                    int index = dataGridView1.SelectedCells[0].RowIndex;
                    string saved_trans_id = dataGridView1.Rows[index].Cells[0].FormattedValue.ToString();
                    DataGridViewRow row = dataGridView1.CurrentCell.OwningRow;
                    String id = row.Cells[0].Value.ToString();
                    String dt = row.Cells[3].Value.ToString();
                    open_register reg = new open_register(empID, saved_trans_id, dt, row.Cells[2].Value.ToString(), row.Cells[1].Value.ToString());
                    reg.Show();
                    dbhandler.insertAuditTrail(empID, "Point of Sale", "Open Saved Sale", DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));

                }
            }
            catch { }
            finally {
                this.UseWaitCursor = false;
            }
         

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if(whattab == 1 || whattab == 2 || whattab == 3){
                dbhandler.salesByAllCustSummSearch(dataGridView1, txt_search.Text);
            }

            if(whattab == 4 || whattab == 5 || whattab == 6){
                dbhandler.salesByAllCustSalesWithDetailsSearch(dataGridView1, txt_search.Text,false,dateTimePicker1.Value, dateTimePicker2.Value);
            }
            
            if(whattab== 8){
                dbhandler.salesbyItemSearch(dataGridView1, txt_search.Text);
            }

            if(whattab == 9){
                dbhandler.salesProcessPerUser(dataGridView1, txt_search.Text);
            }
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                btn_search.PerformClick();
            }
        }           

        private void filterByDate() {

            try {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                if (ch_startDate.Checked && ch_endDate.Checked)
                {
                    if (whattab == 1)
                    {
                        dbhandler.salesByAllCustSumm(dataGridView1, true, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 2)
                    {
                        dbhandler.salesByAllCustSummMemberOnly(dataGridView1, true, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 3)
                    {
                        dbhandler.salesByAllCustSummNONMemberOnly(dataGridView1, true, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 4)
                    {
                        dbhandler.salesByAllCustSalesWithDetails(dataGridView1, true, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 5)
                    {
                        dbhandler.salesByAllCustSalesMemberOnlyWithDetails(dataGridView1, true, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 6)
                    {
                        dbhandler.salesByAllCustSalesNONMemberOnlyWithDetails(dataGridView1, true, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 7)
                    {
                        dbhandler.populateSavedTrans2(dataGridView1, "2", true, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 8)
                    {
                        dbhandler.salesbyItem(dataGridView1, true, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 9)
                    {
                        dbhandler.salesProcessPerUser(dataGridView1, true, dateTimePicker1.Value, dateTimePicker2.Value);
                        //no report
                    }
                }
                else
                {
                    if (whattab == 1)
                    {
                        dbhandler.salesByAllCustSumm(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 2)
                    {
                        dbhandler.salesByAllCustSummMemberOnly(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 3)
                    {
                        dbhandler.salesByAllCustSummNONMemberOnly(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 4)
                    {
                        dbhandler.salesByAllCustSalesWithDetails(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 5)
                    {
                        dbhandler.salesByAllCustSalesMemberOnlyWithDetails(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 6)
                    {
                        dbhandler.salesByAllCustSalesNONMemberOnlyWithDetails(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 7)
                    {
                        dbhandler.populateSavedTrans2(dataGridView1, "2", false, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 8)
                    {
                        dbhandler.salesbyItem(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                    }
                    else if (whattab == 9)
                    {
                        dbhandler.salesProcessPerUser(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                        //no report
                    }
                }


            }
            catch(Exception e) {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                this.UseWaitCursor = false;
            }


        }

        private void ch_startDate_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_startDate.Checked)
            {
                ch_endDate.Checked = true;
                filterByDate();
            }
            else {
                ch_endDate.Checked = false;
                filterByDate();
            }
        }

        private void ch_endDate_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_endDate.Checked)
            {
                ch_startDate.Checked = true;
                filterByDate();
            }
            else
            {
                ch_startDate.Checked = false;
                filterByDate();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            filterByDate();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            filterByDate();
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

        private void Sales_Report_Activated(object sender, EventArgs e)
        {
  
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
