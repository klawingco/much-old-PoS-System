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
    public partial class enter_items : Form
    {
        DatabaseStuff dbHandler = new DatabaseStuff();
        String empID;
        bool istherephoto = false;
        public enter_items(String empID)
        {
            InitializeComponent();
            this.empID = empID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(empID);
            f.Show();
            this.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

                try {
                    if (txtProductItemCode.Text != "" && txtProductItemCode.Text.Trim() != "Item Code" && txtProductDesc.Text != "" && txtProductDesc.Text.Trim() != "Item Description" && txtProductCost.Text != "" && txtProductCost.Text.Trim() != "Cost Per Unit" && txtProductNetWeight.Text != "" && txtProductNetWeight.Text.Trim() != "Package Net Weight" && txtProductSellingPrice.Text != "" && txtProductSellingPrice.Text.Trim() != "Selling Price" && txtProductUnitMeasure.Text != "" && txtProductUnitMeasure.Text.Trim() != "Unit of Measurement")
                    {
                        enter_items_confirm f1 = new enter_items_confirm(txtProductDesc.Text);
                        f1.label1.Text = "Successfully added the \nfollowing product";
                        DialogResult res = f1.ShowDialog();
                      
                        if(res == System.Windows.Forms.DialogResult.OK){
                            dbHandler.insertItems(txtProductDesc.Text, txtProductNetWeight.Text, "0", Double.Parse(txtProductCost.Text).ToString(), Double.Parse(txtProductSellingPrice.Text).ToString(), DateTime.Now.ToString("yyyy-MM-dd"), txtProductItemCode.Text, cmbProductCategory.SelectedItem.ToString(), txtProductUnitMeasure.Text, empID, istherephoto, openFileDialog1.FileName);

                            message mes = new message("The item " + txtProductDesc.Text + "\nwas successfully saved!");
                            System.Media.SystemSounds.Exclamation.Play();
                            mes.ShowDialog(this);

                            txtProductDesc.Text = "";
                            txtProductNetWeight.Text = "";
                            //txtProductQuantity.Text = "0";
                            txtProductCost.Text = "0.00";
                            txtProductSellingPrice.Text = "0.00";
                            //dateTimePickerExp.ResetText();
                            txtProductItemCode.Text = "";
                            cmbProductCategory.SelectedIndex = -1;
                            txtProductUnitMeasure.Text = "";
                        }
                    }
                    else
                    {
                        message mes = new message("Please Complete the form");
                        System.Media.SystemSounds.Hand.Play();
                        mes.ShowDialog(this);
                    }

                }
                catch (Exception)
                {
                    message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                    System.Media.SystemSounds.Hand.Play();
                    mes.ShowDialog(mes.Parent);
                }
            
            



        }









        void txtProductCost_LostFocus(object sender, EventArgs e)
        {
            if (txtProductCost.Text.Trim() == "")
            {
                txtProductCost.Text = "Cost Per Unit";
            }
        }

        void txtProductCost_GotFocus(object sender, EventArgs e)
        {
            if (txtProductCost.Text.Trim() == "Cost Per Unit")
            {
                txtProductCost.Text = "";
            }
        }

        void txtProductUnitMeasure_LostFocus(object sender, EventArgs e)
        {
            if (txtProductUnitMeasure.Text.Trim() == "")
            {
                txtProductUnitMeasure.Text = "Unit of Measurement";
            }
        }

        void txtProductUnitMeasure_GotFocus(object sender, EventArgs e)
        {
            if (txtProductUnitMeasure.Text.Trim() == "Unit of Measurement")
            {
                txtProductUnitMeasure.Text = "";
            }
        }

        void txtProductItemCode_LostFocus(object sender, EventArgs e)
        {
            if (txtProductItemCode.Text.Trim() == "")
            {
                txtProductItemCode.Text = "Item Code";
            }
        }

        void txtProductItemCode_GotFocus(object sender, EventArgs e)
        {
            if (txtProductItemCode.Text.Trim() == "Item Code")
            {
                txtProductItemCode.Text = "";
            }
        }

        void txtProductSellingPrice_LostFocus(object sender, EventArgs e)
        {
            if (txtProductSellingPrice.Text.Trim() == "")
            {
                txtProductSellingPrice.Text = "Selling Price";
            }
        }

        void txtProductSellingPrice_GotFocus(object sender, EventArgs e)
        {
            if (txtProductSellingPrice.Text.Trim() == "Selling Price")
            {
                txtProductSellingPrice.Text = "";
            }
        }
        void txtProductNetWeight_LostFocus(object sender, EventArgs e)
        {
            if (txtProductNetWeight.Text.Trim() == "")
            {
                txtProductNetWeight.Text = "Package Net Weight";
            }
        }

        void txtProductNetWeight_GotFocus(object sender, EventArgs e)
        {
            if (txtProductNetWeight.Text.Trim() == "Package Net Weight")
            {
                txtProductNetWeight.Text = "";
            }
        }

        void txtProductDesc_LostFocus(object sender, EventArgs e)
        {
            if (txtProductDesc.Text.Trim() == "")
            {
                txtProductDesc.Text = "Item Description";
            }
        }

        void txtProductDesc_GotFocus(object sender, EventArgs e)
        {
            if (txtProductDesc.Text.Trim() == "Item Description")
            {
                txtProductDesc.Text = "";
            }
        }

        private void enter_items_Load(object sender, EventArgs e)
        {
            txtProductDesc.GotFocus += txtProductDesc_GotFocus;
            txtProductDesc.LostFocus += txtProductDesc_LostFocus;
            txtProductNetWeight.GotFocus += txtProductNetWeight_GotFocus;
            txtProductNetWeight.LostFocus += txtProductNetWeight_LostFocus;
            txtProductSellingPrice.GotFocus += txtProductSellingPrice_GotFocus;
            txtProductSellingPrice.LostFocus += txtProductSellingPrice_LostFocus;
            txtProductItemCode.GotFocus += txtProductItemCode_GotFocus;
            txtProductItemCode.LostFocus += txtProductItemCode_LostFocus;
            txtProductUnitMeasure.GotFocus += txtProductUnitMeasure_GotFocus;
            txtProductUnitMeasure.LostFocus += txtProductUnitMeasure_LostFocus;
            txtProductCost.GotFocus += txtProductCost_GotFocus;
            txtProductCost.LostFocus += txtProductCost_LostFocus;

            label6.Text = Properties.Settings.Default.username.ToUpper();
            if (empID == "" || empID == "0")
            {
                empID = Properties.Settings.Default.userid;
            }
        }

        private void txtProductCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtProductSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label5.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           DialogResult res =  openFileDialog1.ShowDialog();
           if (res == System.Windows.Forms.DialogResult.OK)
           {
               istherephoto = true;
               pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
           }
           else {
               istherephoto = false;
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
