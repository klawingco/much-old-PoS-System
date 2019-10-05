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
    public partial class transaction_per_individual : Form
    {

        List<String> custId = new List<String>();
        DatabaseStuff dbhandler = new DatabaseStuff();
        String customerId;
        String empID = "";
        int what = 1;
        
        public transaction_per_individual(String empID)
        {
            InitializeComponent();
            this.empID = empID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(empID);
            f.Show();
            this.Close();
        }

        private void btn_eExcel_Click(object sender, EventArgs e)
        {
             individual_trans_excel f1 = new individual_trans_excel();
             DialogResult res = f1.ShowDialog();

            if(res == System.Windows.Forms.DialogResult.OK){

                try
                {

                    if (dataGridView1.Rows.Count > 0)
                    {
                        copyAlltoClipboard();

                        Microsoft.Office.Interop.Excel.Application xlexcel;
                        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                        object misValue = System.Reflection.Missing.Value;
                        xlexcel = new Microsoft.Office.Interop.Excel.Application();
                        xlexcel.Visible = true;
                        xlWorkBook = xlexcel.Workbooks.Add(misValue);
                        xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                        Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                        CR.Select();
                        xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                    }


                }
                catch (Exception error)
                {
                    MessageBox.Show(this, "An error was encoutered while exporting the excel file.\nPlease Check if Excel is installed on your computer\n" + error.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void copyAlltoClipboard()
        {

            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            individual_trans_print f1 = new individual_trans_print();
            f1.ShowDialog();
        }

        private void btn_ePDF_Click(object sender, EventArgs e)
        {
            individual_trans_pdf f1 = new individual_trans_pdf();
            f1.ShowDialog();
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
            {
                if (txt_search.Text.Trim() != "")
                {

                    dbhandler.searchMemberEmployee(txt_search.Text.Replace("'", "`"), listBox1, custId);
                }
                else
                {
                    listBox1.Visible = false;

                }
            }
        }

        private void selectMember() {
            if (listBox1.Items.Count > 0)
            {

                txt_search.Text = listBox1.SelectedItem.ToString();

                if (listBox1.SelectedIndex == 0)
                {
                    customerId = custId[0].ToString();
                }
                else if (listBox1.SelectedIndex > 0)
                {
                    customerId = custId[listBox1.SelectedIndex].ToString();
                }

                dbhandler.getALLTransactions(dataGridView1, customerId, false, dateTimePicker1.Value, dateTimePicker2.Value);
            }
        
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (listBox1.Items.Count > 0)
                {
                    selectMember();
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

        private void transaction_per_individual_Load(object sender, EventArgs e)
        {
            label6.Text = Properties.Settings.Default.username.ToUpper();
            //if (empID.Trim() == "" || empID == "0")
            //{
                empID = Properties.Settings.Default.userid;
            //}


            txt_search.GotFocus += txt_search_GotFocus;
            txt_search.LostFocus += txt_search_LostFocus;

        }
        #region misc
        void txt_search_LostFocus(object sender, EventArgs e)
        {
            if (txt_search.Text.Trim() == "")
            {
                txt_search.Text = "Type Member's Name to Search";
            }
        }

        void txt_search_GotFocus(object sender, EventArgs e)
        {
            if (txt_search.Text.Trim() == "Type Member's Name to Search")
            {
                txt_search.Text = "";
            }
        }

        #endregion

        private void btn_allTrans_Click(object sender, EventArgs e)
        {
            what = 1;
            if(!ch_all.Checked){
                dbhandler.getALLTransactions(dataGridView1, customerId, true, dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else if(ch_all.Checked){
                dbhandler.getALLTransactions(dataGridView1, customerId, false, dateTimePicker1.Value, dateTimePicker2.Value);
            }
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            selectMember();
            listBox1.Visible = false;

            dbhandler.getALLTransactions(dataGridView1, customerId, false, dateTimePicker1.Value, dateTimePicker2.Value);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            what = 2;
            listBox1.Visible = false;
            if(!ch_all.Checked){
            dbhandler.getDepositsOFMember(dataGridView1, customerId, true, dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else if (ch_all.Checked) {
                dbhandler.getDepositsOFMember(dataGridView1, customerId, false, dateTimePicker1.Value, dateTimePicker2.Value);
            }
        }

        private void btn_loans_Click(object sender, EventArgs e)
        {
            what = 3;
            listBox1.Visible = false;
            if (!ch_all.Checked)
            {
                dbhandler.getLoanMoneyOFMember(dataGridView1, customerId, true, dateTimePicker1.Value, dateTimePicker2.Value);

            }
            else if (ch_all.Checked) {
                dbhandler.getLoanMoneyOFMember(dataGridView1, customerId, false, dateTimePicker1.Value, dateTimePicker2.Value);

            }
        }

        private void btn_purchases_Click(object sender, EventArgs e)
        {
            what = 4;
            listBox1.Visible = false;
            if(!ch_all.Checked){
                dbhandler.getALLPurchaseOfMember(dataGridView1, customerId, true, dateTimePicker1.Value, dateTimePicker2.Value);

            }else if(ch_all.Checked){
                dbhandler.getALLPurchaseOfMember(dataGridView1, customerId, false, dateTimePicker1.Value, dateTimePicker2.Value);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label5.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_search.PerformClick();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (listBox1.Items.Count > 0)
                {
                    selectMember();
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

        private void ch_all_CheckedChanged(object sender, EventArgs e)
        {
            if (!ch_all.Checked)
            {
                ch_startDate.Checked = true;
                ch_endDate.Checked = true;
            }
            else {
                ch_startDate.Checked = false;
                ch_endDate.Checked = false;
            }

            refreshDataGrid();
        

        }
        private void refreshDataGrid() {
            if (what == 1)
            {
                btn_allTrans.PerformClick();
            }
            else if (what == 2)
            {
                button1.PerformClick();
            }else if(what == 3){
                btn_loans.PerformClick();
            
            }else if(what == 4){
                btn_purchases.PerformClick();
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

        }

















    }
}
