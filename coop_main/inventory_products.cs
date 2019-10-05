using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace coop_main
{
    public partial class inventory_products : Form
    {
        DatabaseStuff dbhandler = new DatabaseStuff();
        int whattab = 0;
        String empID;
        String senderz;
        DataTable t;

        public inventory_products(String empID, String sender)
        {
            InitializeComponent();
            this.empID = empID;
            this.senderz = sender;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(senderz == "1"){
                Form3 f = new Form3(empID);
                f.Show();
            }else if(senderz == "2"){
                ReportsForm rep = new ReportsForm(empID);
                rep.Show();
            }
  
            this.Close();
        }

        private void btn_eExcel_Click(object sender, EventArgs e)
        {
            populateToReport();
            inventory_prod_excel f1 = new inventory_prod_excel();
            DialogResult res =  f1.ShowDialog();
            if(res == System.Windows.Forms.DialogResult.Yes){
                OpenFileDialog ds = new OpenFileDialog();
                SaveFileDialog s = new SaveFileDialog();

                if (whattab == 0)
                {
                    s.FileName = "All Product Item INVENTORY REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }
                else if (whattab == 1)
                {
                    s.FileName = "All Requested Product Item INVENTORY REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }
                else if (whattab == 2)
                {
                    s.FileName = "All Received Product Item INVENTORY REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }
                else if (whattab == 3)
                {
                    s.FileName = "All Returned Product Item INVENTORY REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }
                else if (whattab == 4)
                {
                    s.FileName = "All Expiring Product Item INVENTORY REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                }
                else if (whattab == 5)
                {
                    s.FileName = "All Low in Stocks Product Item INVENTORY REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
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

        private void btn_ePDF_Click(object sender, EventArgs e)
        {
            populateToReport();
            inv_pdf pd = new inv_pdf();
            DialogResult res =  pd.ShowDialog();

            if(res== System.Windows.Forms.DialogResult.Yes){

                OpenFileDialog ds = new OpenFileDialog();
                SaveFileDialog s = new SaveFileDialog();

                if (whattab == 0)
                {
                    s.FileName = "All Product Item INVENTORY REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if(whattab == 1){
                    s.FileName = "All Requested Product Item INVENTORY REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (whattab == 2)
                {
                    s.FileName = "All Received Product Item INVENTORY REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (whattab == 3)
                {
                    s.FileName = "All Returned Product Item INVENTORY REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (whattab == 4)
                {
                    s.FileName = "All Expiring Product Item INVENTORY REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
                }
                else if (whattab == 5)
                {
                    s.FileName = "All Low in Stocks Product Item INVENTORY REPORT " + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";
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

        #region printMethods
        private void populateprintAllProductItems() {
            t = new DataTable();
            t.TableName = "ds_AllItems";
            t.Columns.Add("item_desc");
            t.Columns.Add("pck");
            t.Columns.Add("unit");
            t.Columns.Add("sell");
            t.Columns.Add("code");
            t.Columns.Add("cat");
            t.Columns.Add("qty");
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
            reportViewer1.LocalReport.ReportPath = @"ReportAllProd.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_AllItems", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();
        
        }


        private void populateprintAllReqyestedProductItems()
        {
            t = new DataTable();
            t.TableName = "ds_AllReqItem";
            t.Columns.Add("stock_no");
            t.Columns.Add("stock_reqdate");
            t.Columns.Add("req_per");
            t.Columns.Add("supp");
            t.Columns.Add("desc");
            t.Columns.Add("item_desc");
            t.Columns.Add("qty_req");
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

            reportViewer1.LocalReport.ReportPath = @"ReportAllProdReq.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_AllReqItem", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }

        private void populateprintAllReceivedProductItems()
        {
            t = new DataTable();
            t.TableName = "ds_AllRecItem";

            t.Columns.Add("stock_reqno");
            t.Columns.Add("stock_reqdate");
            t.Columns.Add("req_per");
            t.Columns.Add("supp");
            t.Columns.Add("desc");
            t.Columns.Add("or_num");
            t.Columns.Add("stock_recno");
            t.Columns.Add("stock_recdate");
            t.Columns.Add("rec_by");
            t.Columns.Add("item_desc");
            t.Columns.Add("qty_rec");
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
                dtrw[9] = dataGridView1.Rows[rw.Index].Cells[9].FormattedValue.ToString();
                dtrw[10] = dataGridView1.Rows[rw.Index].Cells[10].FormattedValue.ToString();

                t.Rows.Add(dtrw);
            }

            reportViewer1.LocalReport.ReportPath = @"ReportAllProdReceive.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSet1", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }


        private void populateprintAllReturnProductItems()
        {
            t = new DataTable();
            t.TableName = "ds_AllRecItem";

            t.Columns.Add("stock_recno");
            t.Columns.Add("stock_recdate");
            t.Columns.Add("rec_per");
            t.Columns.Add("supp");
            t.Columns.Add("desc");
            t.Columns.Add("or_num");
            t.Columns.Add("stock_retno");
            t.Columns.Add("stock_retdate");
            t.Columns.Add("ret_by");
            t.Columns.Add("item_desc");
            t.Columns.Add("qty_ret");
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
                dtrw[9] = dataGridView1.Rows[rw.Index].Cells[9].FormattedValue.ToString();
                dtrw[10] = dataGridView1.Rows[rw.Index].Cells[10].FormattedValue.ToString();

                t.Rows.Add(dtrw);
            }

            reportViewer1.LocalReport.ReportPath = @"ReportAllProdReturn.rdlc";
            ReportDataSource rds = new ReportDataSource("ds", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }


        private void populateprintAllExpiringProductItems()
        {
            t = new DataTable();
            t.TableName = "ds_AllExpItems";

            t.Columns.Add("no");
            t.Columns.Add("item_desc");
            t.Columns.Add("date_exp");
            t.Columns.Add("date_acq");
            t.Columns.Add("supp");
            t.Columns.Add("pck");
            t.Columns.Add("item_code");
            t.Columns.Add("cat");
            t.Columns.Add("del_qty");

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

            reportViewer1.LocalReport.ReportPath = @"ReportAllProdExp.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_AllExpItems", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }


        private void populateprintAllProductItemsLessQTY()
        {
            t = new DataTable();
            t.TableName = "ds_AllItems";
            t.Columns.Add("item_desc");
            t.Columns.Add("pck");
            t.Columns.Add("unit");
            t.Columns.Add("sell");
            t.Columns.Add("code");
            t.Columns.Add("cat");
            t.Columns.Add("qty");
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
            reportViewer1.LocalReport.ReportPath = @"ReportAllProdLessQTY.rdlc";
            ReportDataSource rds = new ReportDataSource("ds_AllItems", t);
            reportViewer1.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
            reportViewer1.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            reportViewer1.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            reportViewer1.RefreshReport();

        }
        #endregion

        private void btn_print_Click(object sender, EventArgs e)
        {
            populateToReport();
            inv_print print = new inv_print();
            DialogResult res = print.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                PrinterSettings set = new PrinterSettings();
                set.DefaultPageSettings.Landscape = true;
                set.DefaultPageSettings.Margins = new Margins(25, 25, 25, 25);
                set.DefaultPageSettings.PrinterSettings.Copies = 1;
                reportViewer1.PrintDialog(set);
            }
            else { 
            
            }
          
            
       
        }

        private void populateToReport() {
            if (whattab == 0)
            {
                populateprintAllProductItems();
            }
            else if (whattab == 1)
            {
                populateprintAllReqyestedProductItems();
            }
            else if (whattab == 2)
            {
                populateprintAllReceivedProductItems();

            }
            else if (whattab == 3)
            {
                populateprintAllReturnProductItems();
            }
            else if (whattab == 4)
            {
                populateprintAllExpiringProductItems();
            }
            else if(whattab == 4){
                populateprintAllProductItemsLessQTY();
            }
        }

        private void btn_allProd_Click(object sender, EventArgs e)
        {
            try {

                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();


                dbhandler.getAllProducts2(dataGridView1);
                whattab = 0;
                ch_startDate.Checked = false;
                ch_endDate.Checked = false;
                txt_search.Text = "Type Item Name to Search";
            
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

        private void btn_reqProd_Click(object sender, EventArgs e)
        {

            try {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                dbhandler.getAllProductsRequested(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                whattab = 1;
                ch_startDate.Checked = false;
                ch_endDate.Checked = false;

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
                dbhandler.getAllProductsReceived(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                whattab = 2;
                ch_startDate.Checked = false;
                ch_endDate.Checked = false;

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

        private void btn_retProd_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                dbhandler.getAllProductsReturned(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                whattab = 3;
                ch_startDate.Checked = false;
                ch_endDate.Checked = false;
            }
            catch (Exception xx)
            {
                MessageBox.Show(xx.ToString());
                message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                System.Media.SystemSounds.Hand.Play();
                mes.ShowDialog(mes.Parent);
            }
            finally
            {
                this.UseWaitCursor = false;
            }

            
        }

        private void btn_prodExp_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                dbhandler.getAllProductsExpiredAndExpiring(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                whattab = 4;
                ch_startDate.Checked = false;
                ch_endDate.Checked = false;

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

            
            //SELECT sc.stock_itemname,sc.stock_expdate, s.stock_deldate, s.stock_supplier , sc.stock_itemcode,sc.stock_rc_qty FROM tbl_stockreceive as s JOIN tbl_stockrcitems as sc ON s.stock_receiveid = sc.stock_receivedid
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                dbhandler.getAllProductsLessThanQTY(dataGridView1, 50);
                whattab = 5;
                ch_startDate.Checked = false;
                ch_endDate.Checked = false;

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


        private void inventory_products_Load(object sender, EventArgs e)
        {
            label6.Text = Properties.Settings.Default.username.ToUpper();
          //  if (empID == "" || empID == "0")
          //  {
                empID = Properties.Settings.Default.userid;
          //  }

              


            txt_search.GotFocus += txt_search_GotFocus;
            txt_search.LostFocus += txt_search_LostFocus;
       
        }

        private void inventory_products_Shown(object sender, EventArgs e)
        {
            btn_allProd.PerformClick();
        }

        void txt_search_LostFocus(object sender, EventArgs e)
        {
            if (txt_search.Text.Trim() == "")
            {
                txt_search.Text = "Type Item Name to Search";
            }
        }

        void txt_search_GotFocus(object sender, EventArgs e)
        {
           // if (txt_search.Text.Trim() == "Type Keyword to Search")
           // {
                txt_search.Text = "";
          //  }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label5.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }


        private void refreshDataGrid() {

            if (ch_startDate.Checked && ch_endDate.Checked)
            {
                if (whattab == 1)
                {
                    dbhandler.getAllProductsRequested(dataGridView1, true, dateTimePicker1.Value, dateTimePicker2.Value);
                }
                else if(whattab == 2){
                    dbhandler.getAllProductsReceived(dataGridView1, true, dateTimePicker1.Value, dateTimePicker2.Value);
                }
                else if (whattab == 3)
                {
                    dbhandler.getAllProductsReturned(dataGridView1, true, dateTimePicker1.Value, dateTimePicker2.Value);
                }
                else if (whattab == 4)
                {
                    dbhandler.getAllProductsExpiredAndExpiring(dataGridView1, true, dateTimePicker1.Value, dateTimePicker2.Value);
                }

            }
            else {
                if (whattab == 1)
                {
                    dbhandler.getAllProductsRequested(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                }
                else if (whattab == 2)
                {
                    dbhandler.getAllProductsReceived(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                }
                else if (whattab == 3)
                {
                    dbhandler.getAllProductsReturned(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                }
                else if (whattab == 4)
                {
                    dbhandler.getAllProductsExpiredAndExpiring(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value);
                }


            }
        

        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            refreshDataGrid();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            refreshDataGrid();
        }

        private void ch_startDate_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_startDate.Checked)
            {
                ch_endDate.Checked = true;
                refreshDataGrid();
            }
            else {
                ch_endDate.Checked = false;
                refreshDataGrid();
            }
        }

        private void ch_endDate_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_endDate.Checked)
            {
                ch_startDate.Checked = true;
                refreshDataGrid();
            }
            else
            {
                ch_startDate.Checked = false;
                refreshDataGrid();
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if(whattab == 0){
                dbhandler.getAllProducts2(dataGridView1, txt_search.Text);
                ch_startDate.Checked = false;
                ch_endDate.Checked = false;
                populateprintAllProductItems();
            }
            else if(whattab == 1){
                dbhandler.getAllProductsRequested(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value, txt_search.Text);
                ch_startDate.Checked = false;
                ch_endDate.Checked = false;
                populateprintAllReqyestedProductItems();
            }
            else if(whattab == 2){
                dbhandler.getAllProductsReceived(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value, txt_search.Text);
                ch_startDate.Checked = false;
                ch_endDate.Checked = false;
                populateprintAllReceivedProductItems();
            }
            else if(whattab == 3){
                dbhandler.getAllProductsReturned(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value, txt_search.Text);
                ch_startDate.Checked = false;
                ch_endDate.Checked = false;
                populateprintAllReturnProductItems();
            }
            else if(whattab == 4){
                dbhandler.getAllProductsExpiredAndExpiring(dataGridView1, false, dateTimePicker1.Value, dateTimePicker2.Value, txt_search.Text);
                ch_startDate.Checked = false;
                ch_endDate.Checked = false;
                populateprintAllExpiringProductItems();
            }
            else if(whattab== 5){
                dbhandler.getAllProductsLessThanQTY(dataGridView1, 50, txt_search.Text);
                ch_startDate.Checked = false;
                ch_endDate.Checked = false;
                populateprintAllProductItemsLessQTY();
            }




        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                btn_search.PerformClick();
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
