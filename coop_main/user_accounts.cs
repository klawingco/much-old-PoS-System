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
    public partial class user_accounts : Form
    {
        String empID;
        DatabaseStuff dbhandler = new DatabaseStuff();

        int currSelectedId;

        public user_accounts(String empID)
        {
            InitializeComponent();
            txt_search.GotFocus += txt_search_GotFocus;
            txt_search.LostFocus += txt_search_LostFocus;

            textBox1.GotFocus += textBox1_GotFocus;
            textBox1.LostFocus += textBox1_LostFocus;

            textBox2.GotFocus += textBox2_GotFocus;
            textBox2.LostFocus += textBox2_LostFocus;

            this.empID = empID;
        }

        void textBox2_LostFocus(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                textBox2.Text = "Type to Search";
            }
        }

        void textBox2_GotFocus(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "Type to Search")
            {
                textBox2.Text = "";
            }
        }

        void textBox1_LostFocus(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                textBox1.Text = "Type to Search";
            }
        }

        void textBox1_GotFocus(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "Type to Search")
            {
                textBox1.Text = "";
            }
        }

        void txt_search_LostFocus(object sender, EventArgs e)
        {
            if (txt_search.Text.Trim() == "")
            {
                txt_search.Text = "Type to Search";
            }
        }

        void txt_search_GotFocus(object sender, EventArgs e)
        {
            if (txt_search.Text.Trim() == "Type to Search")
            {
                txt_search.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            miscellaneous ms = new miscellaneous(empID);
            ms.Show();
            this.Close();
        }

        private void btn_adminUser_Click(object sender, EventArgs e)
        {

            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                tabControl1.SelectedIndex = 0;
                dbhandler.getUserorAdmin(dataGridView1, 1);
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

        private void btn_systemUser_Click(object sender, EventArgs e)
        {

            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                tabControl1.SelectedIndex = 1;
                dbhandler.getUserorAdmin(dataGridView2, 0);
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

        private void btn_userAccess_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                tabControl1.SelectedIndex = 2;
                dbhandler.getAllUserForAccessRights(dataGridView3);
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


        private void btn_Pref_Click(object sender, EventArgs e)
        {
            PreferencesForm pref = new PreferencesForm();
            pref.ShowDialog();
        }




        private void btn_createAdmin_Click(object sender, EventArgs e)
        {
            createAdmin admin = new createAdmin();
            admin.ShowInTaskbar = false;
            admin.Show(this);
        }

        private void btn_createUser_Click(object sender, EventArgs e)
        {
            createUser user = new createUser();
            user.ShowInTaskbar = false;
            user.Show(this);

        }

        private void user_accounts_Load(object sender, EventArgs e)
        {
           

            label6.Text = Properties.Settings.Default.username.ToUpper();
          //  if (empID == "" || empID == "0")
         //   {
                empID = Properties.Settings.Default.userid;
           // }
        }

        private void user_accounts_Shown(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                dbhandler.getUserorAdmin(dataGridView1, 1);
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





        //user
        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try {

                if (dataGridView2.SelectedCells[0].Value.ToString() == "View Details")
                {
                    int index = dataGridView2.SelectedCells[0].RowIndex;
                    int ss = Int32.Parse(dataGridView2.Rows[index].Cells[0].FormattedValue.ToString());
                    userAdminDetails udet = new userAdminDetails(ss);

                    udet.Show();
                }


                if (dataGridView2.SelectedCells[0].Value.ToString() == "Change Details")
                {
                    int index = dataGridView2.SelectedCells[0].RowIndex;
                    int ss = Int32.Parse(dataGridView2.Rows[index].Cells[0].FormattedValue.ToString());
                    createUpdateUserAdmin cu = new createUpdateUserAdmin(ss, 0);
                    DialogResult res = cu.ShowDialog();
                    if (res == System.Windows.Forms.DialogResult.OK) btn_systemUser.PerformClick();
                }


                if (dataGridView2.SelectedCells[0].Value.ToString() == "Deactivate")
                {

                    int index = dataGridView2.SelectedCells[0].RowIndex;
                    int ss = Int32.Parse(dataGridView2.Rows[index].Cells[0].FormattedValue.ToString());
                    String username = dataGridView2.Rows[index].Cells[1].FormattedValue.ToString();
                    deactivating_members_confirmation de = new deactivating_members_confirmation(0);
                    DialogResult res = de.ShowDialog(this);

                    if (res == System.Windows.Forms.DialogResult.Yes)
                    {
                        dbhandler.deactivateUserAdmin(ss.ToString(), 0);
                        btn_systemUser.PerformClick();

                    }
                }

                if (dataGridView2.SelectedCells[0].Value.ToString() == "Activate")
                {

                    int index = dataGridView2.SelectedCells[0].RowIndex;
                    int ss = Int32.Parse(dataGridView2.Rows[index].Cells[0].FormattedValue.ToString());
                    String username = dataGridView2.Rows[index].Cells[1].FormattedValue.ToString();
                    deactivating_members_confirmation de = new deactivating_members_confirmation(1);
                    DialogResult res = de.ShowDialog();
                    if (res == System.Windows.Forms.DialogResult.Yes)
                    {
                        dbhandler.deactivateUserAdmin(ss.ToString(), 1);
                        btn_systemUser.PerformClick();

                    }
                }

            }
            catch { }
   
        }

        //admin
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try {

                if (dataGridView1.SelectedCells[0].Value.ToString() == "View Details")
                {
                    int index = dataGridView1.SelectedCells[0].RowIndex;
                    int ss = Int32.Parse(dataGridView1.Rows[index].Cells[0].FormattedValue.ToString());
                    userAdminDetails udet = new userAdminDetails(ss);
                    udet.Show();
                }


                if (dataGridView1.SelectedCells[0].Value.ToString() == "Change Details")
                {
                    int index = dataGridView1.SelectedCells[0].RowIndex;
                    int ss = Int32.Parse(dataGridView1.Rows[index].Cells[0].FormattedValue.ToString());
                    createUpdateUserAdmin cu = new createUpdateUserAdmin(ss, 1);
                    DialogResult res = cu.ShowDialog();
                    if (res == System.Windows.Forms.DialogResult.OK) btn_adminUser.PerformClick();
                }

                if (dataGridView1.SelectedCells[0].Value.ToString() == "Deactivate")
                {

                    int index = dataGridView1.SelectedCells[0].RowIndex;
                    int ss = Int32.Parse(dataGridView1.Rows[index].Cells[0].FormattedValue.ToString());
                    String username = dataGridView1.Rows[index].Cells[1].FormattedValue.ToString();

                    deactivating_members_confirmation de = new deactivating_members_confirmation(0);
                    DialogResult res = de.ShowDialog();
                    // DialogResult res = MessageBox.Show(this, "Proceed with Deactivating this account? \n" + "Username : " + username, "Confirmation", MessageBoxButtons.YesNo);

                    if (res == System.Windows.Forms.DialogResult.Yes)
                    {
                        dbhandler.deactivateUserAdmin(ss.ToString(), 0);
                        btn_adminUser.PerformClick();

                    }
                }

                if (dataGridView1.SelectedCells[0].Value.ToString() == "Activate")
                {

                    int index = dataGridView1.SelectedCells[0].RowIndex;
                    int ss = Int32.Parse(dataGridView1.Rows[index].Cells[0].FormattedValue.ToString());
                    String username = dataGridView1.Rows[index].Cells[1].FormattedValue.ToString();


                    deactivating_members_confirmation de = new deactivating_members_confirmation(1);
                    DialogResult res = de.ShowDialog();

                    // DialogResult res = MessageBox.Show(this, "Proceed with Re-Activating this account? \n" + "Username : " + username, "Confirmation", MessageBoxButtons.YesNo);

                    if (res == System.Windows.Forms.DialogResult.Yes)
                    {
                        dbhandler.deactivateUserAdmin(ss.ToString(), 1);
                        btn_adminUser.PerformClick();

                    }
                }

            }
            catch { }
  


        }


        private void btn_sSearch_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" || textBox1.Text.Trim() != "Type to Search")
            {
                dbhandler.getUserorAdminSearcj(dataGridView2, textBox1.Text.Replace("'", "`").Replace(";",""), 0);
            }
        }

        private void btn_aSearch_Click(object sender, EventArgs e)
        {

            if (txt_search.Text.Trim() != "" && txt_search.Text.Trim() != "Type to Search")
            {
                dbhandler.getUserorAdminSearcj(dataGridView1, txt_search.Text.Replace("'", "`").Replace(";", ""), 1);
            }
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                btn_aSearch.PerformClick();

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_sSearch.PerformClick();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label5.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void btn_uSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Trim() != "" && textBox2.Text.Trim() != "Type to Search")
                {
                    dbhandler.getAllUserForAccessRightsSearchzz(dataGridView3, textBox2.Text.Trim().Replace("'", "`").Replace(";", ""));
                }
                else
                {
                    dbhandler.getAllUserForAccessRights(dataGridView3);
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

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_uSearch.PerformClick();
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


        #region userAccessRights
        private void button1_Click(object sender, EventArgs e)
        {
            //saved
           // dbhandler.UpdateUserAccessRights(currSelectedId)

            if(currSelectedId != 0){

                String[] moduleArray = new String[38];
           
                //MMember Module chPos_PosModule
                checkIFBoxisChecked(ch_MemberModule, ref moduleArray[0]);
                checkIFBoxisChecked(chMem_newMember, ref moduleArray[1]);
                checkIFBoxisChecked(chMem_records, ref moduleArray[2]);


                //MPOS
                checkIFBoxisChecked(chPos_PosModule, ref moduleArray[3]);
                checkIFBoxisChecked(chPos_OpenReg, ref moduleArray[4]);
                checkIFBoxisChecked(chPos_OpenSaved, ref moduleArray[5]);
                checkIFBoxisChecked(chPos_Refunds, ref moduleArray[6]);
                checkIFBoxisChecked(chPos_endDay, ref moduleArray[7]);
                checkIFBoxisChecked(chPos_endWeek, ref moduleArray[8]);
                checkIFBoxisChecked(chPos_TransHistory, ref moduleArray[9]);

                //M Inventory
                checkIFBoxisChecked(chInv_InvModule, ref moduleArray[10]);
                checkIFBoxisChecked(chInv_enterItem, ref moduleArray[11]);
                checkIFBoxisChecked(ch_invStocks, ref moduleArray[12]);
                checkIFBoxisChecked(chInv_stockrequest, ref moduleArray[13]);
                checkIFBoxisChecked(chInv_stockreceived, ref moduleArray[14]);
                checkIFBoxisChecked(chInv_stockreturn, ref moduleArray[15]);
                checkIFBoxisChecked(chInv_itemlist, ref moduleArray[16]);
                checkIFBoxisChecked(chInv_invrep, ref moduleArray[17]);

                //collections
                checkIFBoxisChecked(chCol_colModule, ref moduleArray[18]);
                checkIFBoxisChecked(chCol_Loans, ref moduleArray[19]);
                checkIFBoxisChecked(chCol_Deposit, ref moduleArray[20]);
                checkIFBoxisChecked(chCol_LoanMoney, ref moduleArray[21]);
                checkIFBoxisChecked(chCol_LoanPay, ref moduleArray[22]);
                checkIFBoxisChecked(chCol_MoneyCounter, ref moduleArray[23]);


                //m report
                checkIFBoxisChecked(chRep_ReportModule, ref moduleArray[24]);
                checkIFBoxisChecked(chRep_ManageMem, ref moduleArray[25]);
                checkIFBoxisChecked(chRep_ManageProdInv, ref moduleArray[26]);
                checkIFBoxisChecked(chRep_ManageSales, ref moduleArray[27]);
                checkIFBoxisChecked(chRep_ManagePurch, ref moduleArray[28]);
                checkIFBoxisChecked(chRep_ManageLoans, ref moduleArray[29]);
                checkIFBoxisChecked(chRep_ManageTrans, ref moduleArray[30]);


                checkIFBoxisChecked(chRep_ManageEmp, ref moduleArray[31]);
                checkIFBoxisChecked(chRep_ListRep, ref moduleArray[32]);


                //manage employee payroll
                checkIFBoxisChecked(chPay_payrollmodule, ref moduleArray[33]);

                //misc
                checkIFBoxisChecked(chMisc_MiscModule, ref moduleArray[34]);
                checkIFBoxisChecked(chMisc_UserAccount, ref moduleArray[35]);
                checkIFBoxisChecked(chMisc_AuditTrail, ref moduleArray[36]);
                checkIFBoxisChecked(chMisc_LoanCal, ref moduleArray[37]);

              int stat =   dbhandler.UpdateUserAccessRights(currSelectedId, moduleArray);
                if(stat > 0){
                    message mes = new message("Successfully Updated");
                    mes.ShowDialog(this);
                    System.Media.SystemSounds.Exclamation.Play();
                }
            }

        }
        /// <summary>
        /// hehehehxxxx
        /// </summary>
        /// <param name="empId">Employee ID</param>
        private void getUserAccess(int empId) {

            String[] moduleArray;
            dbhandler.getUserAccessRights(empId, out moduleArray);

            //if(moduleArray[0]==null){
        
            //        for (int a = 0; a < moduleArray.Length; a++)
            //        {
            //            moduleArray[a] = "0";
            //        }
            //       dbhandler.NewUserAccessRights(empId);
            //}




            //MMember Module chPos_PosModule
            checkIFChecked(ch_MemberModule, moduleArray[0]);
            checkIFChecked(chMem_newMember, moduleArray[1]);
            checkIFChecked(chMem_records, moduleArray[2]);

            //MPOS
            checkIFChecked(chPos_PosModule, moduleArray[3]);
            checkIFChecked(chPos_OpenReg, moduleArray[4]);
            checkIFChecked(chPos_OpenSaved, moduleArray[5]);
            checkIFChecked(chPos_Refunds, moduleArray[6]);
            checkIFChecked(chPos_endDay, moduleArray[7]);
            checkIFChecked(chPos_endWeek, moduleArray[8]);
            checkIFChecked(chPos_TransHistory, moduleArray[9]);

            //M Inventory
            checkIFChecked(chInv_InvModule, moduleArray[10]);
            checkIFChecked(chInv_enterItem, moduleArray[11]);
            checkIFChecked(ch_invStocks, moduleArray[12]);
            checkIFChecked(chInv_stockrequest, moduleArray[13]);
            checkIFChecked(chInv_stockreceived, moduleArray[14]);
            checkIFChecked(chInv_stockreturn, moduleArray[15]);
            checkIFChecked(chInv_itemlist, moduleArray[16]);
            checkIFChecked(chInv_invrep, moduleArray[17]);

            //collections
            checkIFChecked(chCol_colModule, moduleArray[18]);
            checkIFChecked(chCol_Loans, moduleArray[19]);
            checkIFChecked(chCol_Deposit, moduleArray[20]);
            checkIFChecked(chCol_LoanMoney, moduleArray[21]);
            checkIFChecked(chCol_LoanPay, moduleArray[22]);
            checkIFChecked(chCol_MoneyCounter, moduleArray[23]);

            //m report
            checkIFChecked(chRep_ReportModule, moduleArray[24]);
            checkIFChecked(chRep_ManageMem, moduleArray[25]);
            checkIFChecked(chRep_ManageProdInv, moduleArray[26]);
            checkIFChecked(chRep_ManageSales, moduleArray[27]);
            checkIFChecked(chRep_ManagePurch, moduleArray[28]);
            checkIFChecked(chRep_ManageLoans, moduleArray[29]);
            checkIFChecked(chRep_ManageTrans, moduleArray[30]);

            checkIFChecked(chRep_ManageEmp, moduleArray[31]);
            checkIFChecked(chRep_ListRep, moduleArray[32]);

            //manage employee payroll
            checkIFChecked(chPay_payrollmodule, moduleArray[33]);

            //misc
            checkIFChecked(chMisc_MiscModule, moduleArray[34]);
            checkIFChecked(chMisc_UserAccount, moduleArray[35]);
            checkIFChecked(chMisc_AuditTrail, moduleArray[36]);
            checkIFChecked(chMisc_LoanCal, moduleArray[37]);
        }

        //Check if it's chevk
        private void checkIFChecked(CheckBox box, string state) {
            if (state == "1")
            {
                box.Checked = true;
            }
            else if(state == "0"){
                box.Checked = false;
            }
        }

        private void checkIFBoxisChecked(CheckBox box, ref string state)
        {
            if (box.Checked)
            {
                state = "1";
            }
            else if (!box.Checked)
            {
                state = "0";
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                currSelectedId = 0;
                if(dataGridView1.SelectedCells.Count > 0)
                {
                    if (dataGridView1.SelectedCells[0].Value.ToString().Trim() != "")
                    {
                        if (dataGridView3.SelectedCells.Count > 0)
                        {
                            int index = dataGridView3.SelectedCells[0].RowIndex;

                            var empID = dataGridView3.Rows[index].Cells[2].FormattedValue.ToString();
                            if (empID.Trim() != "")
                            {
                                getUserAccess(Convert.ToInt32(empID));
                                currSelectedId = Convert.ToInt32(empID);
                            }
                        }
   
                    }
                }
        
            }
            catch(Exception eme) {
                message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                System.Media.SystemSounds.Hand.Play();
                mes.ShowDialog(mes.Parent);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        
        private void ch_MemberModule_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_MemberModule.Checked)
            {
                chMem_newMember.Checked = true;
                chMem_records.Checked = true;
            }
            else
            {
                chMem_newMember.Checked = false;
                chMem_records.Checked = false;
            }
        }

        private void chPos_PosModule_CheckedChanged(object sender, EventArgs e)
        {
            if(chPos_PosModule.Checked){
                chPos_OpenReg.Checked = true;
                chPos_OpenSaved.Checked = true;
                chPos_Refunds.Checked = true;
                chPos_endDay.Checked = true;
                chPos_endWeek.Checked = true;
                chPos_TransHistory.Checked = true;
            }
            else
            {
                chPos_OpenReg.Checked = false;
                chPos_OpenSaved.Checked = false;
                chPos_Refunds.Checked = false;
                chPos_endDay.Checked = false;
                chPos_endWeek.Checked = false;
                chPos_TransHistory.Checked = false;
            }
        }

        private void chInv_InvModule_CheckedChanged(object sender, EventArgs e)
        {
            if (chInv_InvModule.Checked){
                chInv_enterItem.Checked = true;
                ch_invStocks.Checked = true;
                chInv_itemlist.Checked = true;
                chInv_invrep.Checked = true;
            }
            else 
            {
                chInv_enterItem.Checked = false;
                ch_invStocks.Checked = false;
                chInv_itemlist.Checked = false;
                chInv_invrep.Checked = false;
            }
        }

        private void ch_invStocks_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_invStocks.Checked){
                chInv_stockrequest.Checked = true;
                chInv_stockreceived.Checked = true;
                chInv_stockreturn.Checked = true;
            }
            else {
                chInv_stockrequest.Checked = false;
                chInv_stockreceived.Checked = false;
                chInv_stockreturn.Checked = false;
            }
        }

        private void chCol_colModule_CheckedChanged(object sender, EventArgs e)
        {
            if(chCol_colModule.Checked){
                chCol_Loans.Checked = true;
                chCol_MoneyCounter.Checked = true;
            }else{
                chCol_Loans.Checked = false;
                chCol_MoneyCounter.Checked = false;
            }
        }

        private void chCol_Loans_CheckedChanged(object sender, EventArgs e)
        {
            if (chCol_Loans.Checked)
            {
                chCol_Deposit.Checked = true;
                chCol_LoanMoney.Checked = true;
                chCol_LoanPay.Checked = true;
            }
            else {
                chCol_Deposit.Checked = false;
                chCol_LoanMoney.Checked = false;
                chCol_LoanPay.Checked = false;
            }
        }

        private void chRep_ReportModule_CheckedChanged(object sender, EventArgs e)
        {
            if (chRep_ReportModule.Checked)
            {
                chRep_ManageMem.Checked = true;
                chRep_ManageProdInv.Checked = true;
                chRep_ManageSales.Checked = true;
                chRep_ManagePurch.Checked = true;
                chRep_ManageLoans.Checked = true;
                chRep_ManageTrans.Checked = true;
                chRep_ManageEmp.Checked = true;
                chRep_ListRep.Checked = true;
            }
            else
            {
                chRep_ManageMem.Checked = false;
                chRep_ManageProdInv.Checked = false;
                chRep_ManageSales.Checked = false;
                chRep_ManagePurch.Checked = false;
                chRep_ManageLoans.Checked = false;
                chRep_ManageTrans.Checked = false;
                chRep_ManageEmp.Checked = false;
                chRep_ListRep.Checked = false;
 
            }
        }

        private void chMisc_MiscModule_CheckedChanged(object sender, EventArgs e)
        {
            if (chMisc_MiscModule.Checked)
            {
                chMisc_UserAccount.Checked = true;
                chMisc_AuditTrail.Checked = true;
                chMisc_LoanCal.Checked = true;
            }
            else 
            {
                chMisc_UserAccount.Checked = false;
                chMisc_AuditTrail.Checked = false;
                chMisc_LoanCal.Checked = false;
            }
        }
        #endregion


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

        private void button1_Click_1(object sender, EventArgs e)
        {
            recordNewOR rec = new recordNewOR(empID);
            rec.ShowDialog(this);
        }

      

    










        
    }
}
