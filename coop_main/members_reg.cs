using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
namespace coop_main
{
    public partial class members_reg : Form
    {
        members_form memform = new members_form();
        public String addtype;
        public DateTime b_day;
        public String civilstatus;
        String empID;
        //public members_reg()
        //{
        //    InitializeComponent();

        //    if (!File.Exists("coopdb.sqlite"))
        //    {
        //        createdb();
        //    }
        //    else
        //    {
        //        // MessageBox.Show("Database already exist");
        //    }
        //}

        public members_reg(String empID)
        {
            this.empID = empID;
            InitializeComponent();

            if (!File.Exists("coopdb.sqlite"))
            {
                createdb();
            }
            else
            {
                // MessageBox.Show("Database already exist");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            memform.Show();
            this.Close();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            next();
        }

        private void members_reg_Load(object sender, EventArgs e)
        {
            txt_lname.GotFocus += txt_lname_GotFocus;
            txt_lname.LostFocus += txt_lname_LostFocus;
            txt_fname.GotFocus += txt_fname_GotFocus;
            txt_fname.LostFocus += txt_fname_LostFocus;
            txt_mname.GotFocus += txt_mname_GotFocus;
            txt_mname.LostFocus += txt_mname_LostFocus;
            txt_address.GotFocus += txt_address_GotFocus;
            txt_address.LostFocus += txt_address_LostFocus;
            txt_telenum.GotFocus += txt_telenum_GotFocus;
            txt_telenum.LostFocus += txt_telenum_LostFocus;
            txt_cpnum.GotFocus += txt_cpnum_GotFocus;
            txt_cpnum.LostFocus += txt_cpnum_LostFocus;
            txt_day.GotFocus += txt_day_GotFocus;
            txt_day.LostFocus += txt_day_LostFocus;
            txt_year.GotFocus += txt_year_GotFocus;
            txt_year.LostFocus += txt_year_LostFocus;
            txt_birthplace.GotFocus += txt_birthplace_GotFocus;
            txt_birthplace.LostFocus += txt_birthplace_LostFocus;
            txt_age.GotFocus += txt_age_GotFocus;
            txt_age.LostFocus += txt_age_LostFocus;
            txt_idOne.GotFocus += txt_idOne_GotFocus;
            txt_idOne.LostFocus += txt_idOne_LostFocus;
            txt_idTwo.GotFocus += txt_idTwo_GotFocus;
            txt_idTwo.LostFocus += txt_idTwo_LostFocus;
            txt_idonenum.GotFocus += txt_idonenum_GotFocus;
            txt_idonenum.LostFocus += txt_idonenum_LostFocus;
            txt_idtwonum.GotFocus += txt_idtwonum_GotFocus;
            txt_idtwonum.LostFocus += txt_idtwonum_LostFocus;

            txt_provAdd.GotFocus += txt_provAdd_GotFocus;
            txt_provAdd.LostFocus += txt_provAdd_LostFocus;


            label6.Text = Properties.Settings.Default.username.ToUpper();
          //  if (empID.Trim() == "" || empID == "0")
          //  {
                empID = Properties.Settings.Default.userid;
           // }

                numericUpDown2.Maximum = decimal.Parse(DateTime.Now.Year.ToString());

                txt_day.Text = numericUpDown1.Value.ToString();
                txt_year.Text = numericUpDown2.Value.ToString();
        }

   



        private void createdb() {
            SQLiteConnection.CreateFile("coopdb.sqlite");
            SQLiteConnection conn = new SQLiteConnection("Data Source=coopdb.sqlite; Version=3;");

            conn.Open();
            String sql = "CREATE TABLE `tbl_members` (`mem_id`	INTEGER PRIMARY KEY AUTOINCREMENT, `mem_lname` VARCHAR(100),`mem_fname`	VARCHAR(100),`mem_mname` VARCHAR(100),`mem_address`	VARCHAR(200),`mem_provaddress`	VARCHAR(200), `mem_addresstype`	VARCHAR(100),`mem_cellcontact`	VARCHAR(100),`mem_tellcontact`	VARCHAR(100),`mem_bday`	DATETIME, `mem_bplace` VARCHAR(100), `mem_age` INTEGER,  `mem_gender` VARCHAR(7), `mem_civilstatus` VARCHAR(15), `mem_religion` VARCHAR (50),`mem_id_one` VARCHAR(100) , `mem_id_onedet` VARCHAR (100),`mem_id_two` VARCHAR(100) , `mem_id_twodet` VARCHAR (100), `mem_active` INTEGER )";
            SQLiteCommand command = new SQLiteCommand(sql, conn);

            String sql2 = "CREATE TABLE `tbl_membersbenef` (`membene_id` INTEGER PRIMARY KEY AUTOINCREMENT, `benef_name` VARCHAR (250), `benef_age` INTEGER, `benef_relationship` VARCHAR (100), `mem_id` INTEGER )";
            SQLiteCommand command2 = new SQLiteCommand(sql2, conn);


            String sql3 = "CREATE TABLE `tbl_membersdetails` (`mem_detid` INTEGER PRIMARY KEY AUTOINCREMENT, `mem_edAttainment` VARCHAR (50), `mem_occupation` VARCHAR (100), `mem_workplace` VARCHAR (250), `mem_salary` VARCHAR (150), `mem_spouseoccupation` VARCHAR (200), `mem_spouseworkplace` VACHAR(250), `mem_spousesalary` VARCHAR(150), `mem_photo` VARCHAR(150), `mem_id` INTEGER )";
            SQLiteCommand command3 = new SQLiteCommand(sql3, conn);


            String sql4 = "CREATE TABLE tbl_items(item_id INTEGER PRIMARY KEY AUTOINCREMENT, item_desc VARCHAR(200), net_weight VARCHAR(50), quantity INT, unit_cost DECIMAL, selling_price DECIMAL, expiration_date DATE, item_code VARCHAR (20), category VARCHAR(20), unit_measurement VARCHAR(25) ) ";
            SQLiteCommand command4 = new SQLiteCommand(sql4, conn);

            String sql5 = "CREATE TABLE tbl_transactionlog(translog_id INTEGER PRIMARY KEY AUTOINCREMENT, customer_id INT ,purchase_date DATETIME, total_purchased DECIMAL,`emp_id`	INTEGER,`or_number`	INTEGER , `void` INTEGER)";
            SQLiteCommand command5 = new SQLiteCommand(sql5, conn);

            String sql6 = "CREATE TABLE tbl_transactions(trans_id INTEGER PRIMARY KEY AUTOINCREMENT, customer_id INT, translog_id INT ,item_name VARCHAR(200), item_price DECIMAL ,item_qty_bought INT, total_amt DECIMAL, bought_period VARCHAR(5), bought_date DATETIME)";
            SQLiteCommand command6 = new SQLiteCommand(sql6, conn);

            String sql7 = "CREATE TABLE tbl_savedtransactions(trans_id INTEGER PRIMARY KEY AUTOINCREMENT, customer_id INT, translog_id INT ,item_name VARCHAR(200), item_price DECIMAL ,item_qty_bought INT, total_amt DECIMAL, bought_period VARCHAR(5), bought_date DATETIME, item_code VARCHAR(50))";
            SQLiteCommand command7 = new SQLiteCommand(sql7, conn);

            String sql8 = "CREATE TABLE tbl_savedtransactionlog(strans_id INTEGER PRIMARY KEY AUTOINCREMENT,  customer_id INTEGER, purchase_date DATETIME )";
            SQLiteCommand command8 = new SQLiteCommand(sql8, conn);

            String sql9 = "CREATE TABLE `tbl_user` (`user_id`	INTEGER PRIMARY KEY AUTOINCREMENT,`username`	TEXT,`userpass`	TEXT,`user_fullname`	TEXT, `admin_priv`	INTEGER, date_created DATETIME,`active`	INTEGER)";
            SQLiteCommand command9 = new SQLiteCommand(sql9, conn);

            String sql10 = "CREATE TABLE `tbl_audit_trail` (`aud_id`	INTEGER PRIMARY KEY AUTOINCREMENT,`aud_module`	TEXT,`aud_action`	TEXT,`aud_date`	DATETIME, `emp_id` INTEGER)";
            SQLiteCommand command10 = new SQLiteCommand(sql10, conn);

            String sql11 = "CREATE TABLE `tbl_stockrequest` (`stock_requestid`	INTEGER PRIMARY KEY AUTOINCREMENT,`stock_requestperson`	TEXT,`stock_reqdate`	TEXT,`stock_supplier`	TEXT,`stock_desc`	TEXT, `stock_finished` INTEGER)";
            SQLiteCommand command11 = new SQLiteCommand(sql11, conn);

            String sql12 = "CREATE TABLE `tbl_stockrqitems` (`stockrq_id`	INTEGER PRIMARY KEY AUTOINCREMENT,`stock_itemcode`	TEXT,`stock_itemid`	INTEGER,`stock_itemname`	TEXT,`stock_qty`	INTEGER, `stock_requestid` INTEGER)";
            SQLiteCommand command12 = new SQLiteCommand(sql12, conn);

            String sql13 = "CREATE TABLE `tbl_stockreceive` (`stock_receiveid`	INTEGER PRIMARY KEY AUTOINCREMENT,`stock_requestperson`	TEXT,`stock_reqdate`	TEXT,`stock_supplier`	TEXT,`stock_desc`	TEXT,`stock_deldate`	TEXT,`stock_recby`	TEXT,`stock_finished`	INTEGER,`stock_requestid`	INTEGER)";
            SQLiteCommand command13 = new SQLiteCommand(sql13, conn);

            String sql14 = "CREATE TABLE `tbl_stockrcitems` (`stockrcid`	INTEGER PRIMARY KEY AUTOINCREMENT,`stock_itemcode`	TEXT,`stock_itemid`	INTEGER,`stock_itemname`	TEXT,`stock_rq_qty`	INTEGER,`stock_rc_qty`	INTEGER,`stock_expdate`	TEXT,`stock_receivedid`	INTEGER)";
            SQLiteCommand command14 = new SQLiteCommand(sql14, conn);

            String sql15 = "CREATE TABLE `tbl_stockreturn` (`stock_returnid`	INTEGER PRIMARY KEY AUTOINCREMENT,`stock_receivedperson`	TEXT,`stock_recdate`	TEXT,`stock_supplier`	TEXT,`stock_desc`	TEXT,`stock_retdate`	TEXT,`stock_retby`	TEXT,`stock_finished`	INTEGER,`stock_receiveid`	INTEGER)";
            SQLiteCommand command15 = new SQLiteCommand(sql15, conn);

            String sql16 = "CREATE TABLE `tbl_stockrtitems` (`stockrtid`	INTEGER PRIMARY KEY AUTOINCREMENT,`stock_itemcode`	TEXT,`stock_itemid`	INTEGER,`stock_itemname`	TEXT,`stock_rc_qty`	INTEGER,`stock_rt_qty`	INTEGER,`stock_retdate`	TEXT,`stock_returnid`	INTEGER)";
            SQLiteCommand command16 = new SQLiteCommand(sql16, conn);

            String sql17 = "CREATE TABLE `tbl_deposit` (`dep_id`	INTEGER PRIMARY KEY AUTOINCREMENT,`customer_id`	INTEGER,`process_by`	INTEGER,`process_date`	TEXT,`deposit`	REAL)";
            SQLiteCommand command17 = new SQLiteCommand(sql17, conn);

            String sql18 = "CREATE TABLE `tbl_ornumber` (`ornum_id`	INTEGER PRIMARY KEY AUTOINCREMENT, `det`	TEXT);";
            SQLiteCommand command18 = new SQLiteCommand(sql18, conn);

            String sql19 = "CREATE TABLE `tbl_voidreceipt` (`void_id`	INTEGER PRIMARY KEY AUTOINCREMENT,`receipttovoid_or`	INTEGER,`void_reason`	TEXT,`void_date`	DATETIME ,`emp_id`	INTEGER);";
            SQLiteCommand command19 = new SQLiteCommand(sql19, conn);

            String sql20 = "CREATE TABLE `tbl_loanlog` (`loanlog_id`	INTEGER PRIMARY KEY AUTOINCREMENT,`mem_id`	INTEGER,`principal_amount`	REAL,`total_amount`	REAL,`term_loan`	TEXT,`term_duration`	INTEGER,`rate_interest`	REAL,`notes`	TEXT,`process_date`	DATETIME,`start_date`	DATETIME,`end_date`	DATETIME,`emp_id`	INTEGER, `ispaid`	INTEGER);";
            SQLiteCommand command20 = new SQLiteCommand(sql20, conn);

            String slq21 = "CREATE TABLE `tbl_loanpayment` (`loan_payment`	INTEGER PRIMARY KEY AUTOINCREMENT,`mem_id`	INTEGER,`principal_amount`	REAL, amount_paid`	REAL,`date_paid`	DATETIME,`emp_id`	INTEGER,`loanlog_id`	INTEGER);";
            SQLiteCommand command21 = new SQLiteCommand(slq21, conn);

            String sql22 = "CREATE TABLE `tbl_moneycounter` (`money_id`	INTEGER PRIMARY KEY AUTOINCREMENT,`emp_id`	INTEGER,`date_saved`	DATETIME,`thousand`	INTEGER,`fivehundred`	INTEGER,`twohundred`	INTEGER,`onehundred`	INTEGER,`fifty`	INTEGER,`twenty`	INTEGER,`ten`	INTEGER,`five`	INTEGER,`one`	INTEGER,`tot_startday`	REAL,`ed_onetho`	INTEGER,`ed_fivehundred`	INTEGER,`ed_twohundred`	INTEGER,`ed_onehundred`	INTEGER,`ed_fifty`	INTEGER,`ed_twenty`	INTEGER,`ed_ten`	INTEGER,`ed_five`	INTEGER,`ed_one`	INTEGER,`tot_endday`	REAL,`tot_diff`	REAL);";
            SQLiteCommand command22 = new SQLiteCommand(sql22, conn);

            String sql23 = "CREATE TABLE `tbl_feefiling` (`fillfee_id`	INTEGER PRIMARY KEY AUTOINCREMENT,`fillfee_amt`	REAL,`loanlog_id`	INTEGER,`customer_id`	INTEGER,`emp_id`	INTEGER,`date_filed`	TEXT)";
            SQLiteCommand command23 = new SQLiteCommand(sql23, conn);

            String sql24 = "CREATE TABLE `tbl_feeprocessing` (`procfee_id`	INTEGER PRIMARY KEY AUTOINCREMENT,`procfee_amt`	REAL,`loanlog_id`	INTEGER,`customer_id`	INTEGER,`emp_id`	INTEGER,`date_filed`	TEXT)";
            SQLiteCommand command24 = new SQLiteCommand(sql24, conn);

            String sql25 = "CREATE TABLE `tbl_feesharecapital` (`shcapfee_id`	INTEGER PRIMARY KEY AUTOINCREMENT,`shcap_amt`	REAL,	`loanlog_id`	INTEGER,`customer_id`	INTEGER,`emp_id`	INTEGER,`date_filed`	TEXT);";
            SQLiteCommand command25 = new SQLiteCommand(sql25, conn);

            String sql26 = "CREATE TABLE `tbl_supplier` (`supp_id`	INTEGER PRIMARY KEY AUTOINCREMENT,`supp_name`	TEXT,`supp_address`	TEXT,`supp_contact`	TEXT);";
            SQLiteCommand command26 = new SQLiteCommand(sql26, conn);

            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            command4.ExecuteNonQuery();
            command5.ExecuteNonQuery();
            command6.ExecuteNonQuery();
            command7.ExecuteNonQuery();
            command8.ExecuteNonQuery();
            command9.ExecuteNonQuery();
            command10.ExecuteNonQuery();
            command11.ExecuteNonQuery();
            command12.ExecuteNonQuery();
            command13.ExecuteNonQuery();
            command14.ExecuteNonQuery();
            command15.ExecuteNonQuery();
            command16.ExecuteNonQuery();
            command17.ExecuteNonQuery();
            command18.ExecuteNonQuery();
            command19.ExecuteNonQuery();
            command20.ExecuteNonQuery();
            command21.ExecuteNonQuery();
            command22.ExecuteNonQuery();
            command23.ExecuteNonQuery();
            command24.ExecuteNonQuery();
            command25.ExecuteNonQuery();
            command26.ExecuteNonQuery();
            conn.Close();


        }

        private void next() {

            bool completed = false;

       

            if (txt_lname.Text.Trim() != "" && txt_lname.Text.Trim() != "Last Name")
            {

                if (txt_fname.Text.Trim() != "" && txt_fname.Text.Trim() != "First Name")
                {
                    if (txt_mname.Text.Trim() != "" && txt_mname.Text.Trim() != "Middle Name")
                    {
                        if (txt_address.Text.Trim() != "" && txt_address.Text.Trim() != "Full Address")
                        {


                            if(rad_owned.Checked || rad_rented.Checked || rad_lwr.Checked)
                            {
                                if (txt_telenum.Text.Trim() == "" || txt_telenum.Text.Trim() == "Telephone Number")
                                {
                                    txt_telenum.Text = "N/A";
                                }


                                if (txt_telenum.Text.Trim() != "" && txt_telenum.Text.Trim() != "Telephone Number")
                                {

                                    if (txt_cpnum.Text.Trim() == "" || txt_cpnum.Text.Trim() == "Cellphone Number")
                                    {
                                        txt_cpnum.Text = "N/A";
                                    }


                                    if (txt_cpnum.Text.Trim() != "" && txt_cpnum.Text.Trim() != "Cellphone Number")
                                    {
                                        if (cb_month.SelectedIndex >= 0 && txt_day.Text.Trim() != "" && txt_day.Text.Trim() != "Day" && txt_year.Text.Trim() != "" && txt_year.Text.Trim() != "Year")
                                        {

                                            if (txt_birthplace.Text.Trim() != "" && txt_birthplace.Text.Trim() != "Birthplace")
                                            {
                                                if (txt_age.Text.Trim() != "" && txt_age.Text.Trim() != "Age")
                                                {
                                                    if (txt_year.Text.Trim() != "" && txt_year.Text.Trim() != "Age" && cb_gender.SelectedIndex >= 0)
                                                    {
                                                        if(rad_single.Checked || rad_married.Checked || rad_widowed.Checked || rad_seperated.Checked){
                                                            if(cb_religion.SelectedIndex>=0){
                                                                if (txt_idOne.Text.Trim() != "" && txt_idOne.Text.Trim() != "ID Name" && txt_idTwo.Text.Trim() != "" && txt_idTwo.Text.Trim() != "ID Name")
                                                                {
                                                                    if (txt_idonenum.Text.Trim() != "" && txt_idonenum.Text.Trim() != "ID Number" && txt_idtwonum.Text.Trim() != "" && txt_idtwonum.Text.Trim() != "ID Number")
                                                                    {
                                                                        completed = true;
                                                                        if (rad_owned.Checked)
                                                                        {
                                                                            addtype = "Owned";
                                                                        }
                                                                        else if (rad_rented.Checked)
                                                                        {
                                                                            addtype = "Rented"; 
                                                                        }
                                                                        else if (rad_lwr.Checked)
                                                                        {
                                                                            addtype = "Living with Relatives"; 
                                                                        }

                                                                        b_day = DateTime.Parse((cb_month.SelectedIndex + 1).ToString("D2") + "/" + txt_day.Text + "/" + txt_year.Text) ;


                                                                        //b_day = b_day.ToString("MM/dd/yyyy");

                                                                        if(rad_single.Checked){
                                                                            civilstatus = "Single";
                                                                        }else if(rad_married.Checked){
                                                                            civilstatus = "Married";
                                                                        }else if(rad_seperated.Checked){
                                                                            civilstatus = "Seperated";
                                                                        }
                                                                        else if (rad_widowed.Checked)
                                                                        {
                                                                            civilstatus = "Widowed";
                                                                        }
                                                                    }
                                                                }
                                                       
                                                            }
                                                          
                                                        }
                                                      
                                                    }
                                                }
                                     
                                            }
                                            
                                        }
                                       
                                    }
                                      
                                }
                               
                               
                            }
                    
                        }
             
                    }
                }

            }

            //

            if (completed)
            {
                this.Hide();

                String bday = b_day.ToString("yyyy-MM-dd");
                String genderz = cb_gender.SelectedItem.ToString();
                String rel = cb_religion.SelectedItem.ToString();
                members_registration_2 f1 = new members_registration_2(empID, txt_lname.Text, txt_fname.Text, txt_mname.Text, txt_address.Text,txt_provAdd.Text ,addtype, txt_cpnum.Text, txt_telenum.Text, bday, txt_birthplace.Text, txt_age.Text, genderz, civilstatus, rel, txt_idOne.Text, txt_idonenum.Text, txt_idTwo.Text, txt_idtwonum.Text);
              DialogResult res =  f1.ShowDialog();

                if(res == DialogResult.OK){
                    this.Show();
                }
            }
            else {
                MessageBox.Show(this, "Please complete all of the necessary Information", "Some Fields are not yet filled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }


        }



        #region miscmethod
        void txt_idtwonum_LostFocus(object sender, EventArgs e)
        {
            if (txt_idtwonum.Text.Trim() == "")
            {
                txt_idtwonum.Text = "ID Number";
            }
        }

        void txt_idtwonum_GotFocus(object sender, EventArgs e)
        {
            if (txt_idtwonum.Text.Trim() == "ID Number")
            {
                txt_idtwonum.Text = "";
            }
        }

        void txt_idonenum_LostFocus(object sender, EventArgs e)
        {
            if (txt_idonenum.Text.Trim() == "")
            {
                txt_idonenum.Text = "ID Number";
            }
        }

        void txt_idonenum_GotFocus(object sender, EventArgs e)
        {
            if (txt_idonenum.Text.Trim() == "ID Number")
            {
                txt_idonenum.Text = "";
            }
        }

        void txt_idTwo_LostFocus(object sender, EventArgs e)
        {
            if (txt_idTwo.Text.Trim() == "")
            {
                txt_idTwo.Text = "ID Name";
            }
        }

        void txt_idTwo_GotFocus(object sender, EventArgs e)
        {
            if (txt_idTwo.Text.Trim() == "ID Name")
            {
                txt_idTwo.Text = "";
            }
        }

        void txt_idOne_LostFocus(object sender, EventArgs e)
        {
            if (txt_idOne.Text.Trim() == "")
            {
                txt_idOne.Text = "ID Name";
            }
        }

        void txt_idOne_GotFocus(object sender, EventArgs e)
        {
            if (txt_idOne.Text.Trim() == "ID Name")
            {
                txt_idOne.Text = "";
            }
        }

        void txt_age_LostFocus(object sender, EventArgs e)
        {
            if (txt_age.Text.Trim() == "")
            {
                txt_age.Text = "Age";
            }
        }

        void txt_age_GotFocus(object sender, EventArgs e)
        {
            if (txt_age.Text.Trim() == "Age")
            {
                txt_age.Text = "";
            }
        }

        void txt_birthplace_LostFocus(object sender, EventArgs e)
        {
            if (txt_birthplace.Text.Trim() == "")
            {
                txt_birthplace.Text = "Birthplace";
            }
        }

        void txt_birthplace_GotFocus(object sender, EventArgs e)
        {
            if (txt_birthplace.Text.Trim() == "Birthplace")
            {
                txt_birthplace.Text = "";
            }
        }

        void txt_year_LostFocus(object sender, EventArgs e)
        {
            if (txt_year.Text.Trim() == "")
            {
                txt_year.Text = "Year";
            }
        }

        void txt_year_GotFocus(object sender, EventArgs e)
        {
            if (txt_year.Text.Trim() == "Year")
            {
                txt_year.Text = "";
            }
        }

        void txt_day_LostFocus(object sender, EventArgs e)
        {
            if (txt_day.Text.Trim() == "")
            {
                txt_day.Text = "Day";
            }
        }

        void txt_day_GotFocus(object sender, EventArgs e)
        {
            if (txt_day.Text.Trim() == "Day")
            {
                txt_day.Text = "";
            }
        }

        void txt_cpnum_LostFocus(object sender, EventArgs e)
        {
            if (txt_cpnum.Text.Trim() == "")
            {
                txt_cpnum.Text = "Cellphone Number";
            }
        }

        void txt_cpnum_GotFocus(object sender, EventArgs e)
        {
            if (txt_cpnum.Text.Trim() == "Cellphone Number")
            {
                txt_cpnum.Text = "";
            }
        }

        void txt_telenum_LostFocus(object sender, EventArgs e)
        {
            if (txt_telenum.Text.Trim() == "")
            {
                txt_telenum.Text = "Telephone Number";
            }
        }

        void txt_telenum_GotFocus(object sender, EventArgs e)
        {
            if (txt_telenum.Text.Trim() == "Telephone Number")
            {
                txt_telenum.Text = "";
            }
        }

        void txt_address_LostFocus(object sender, EventArgs e)
        {
            if (txt_address.Text.Trim() == "")
            {
                txt_address.Text = "Full address";
            }
        }

        void txt_address_GotFocus(object sender, EventArgs e)
        {
            if (txt_address.Text.Trim() == "Full address")
            {
                txt_address.Text = "";
            }
        }

        void txt_mname_LostFocus(object sender, EventArgs e)
        {
            if (txt_mname.Text.Trim() == "")
            {
                txt_mname.Text = "Middle Name";
            }
        }

        void txt_mname_GotFocus(object sender, EventArgs e)
        {
            if (txt_mname.Text.Trim() == "Middle Name")
            {
                txt_mname.Text = "";
            }
        }



        void txt_lname_LostFocus(object sender, EventArgs e)
        {
            if (txt_lname.Text.Trim() == "")
            {
                txt_lname.Text = "Last Name";
            }
        }

        void txt_lname_GotFocus(object sender, EventArgs e)
        {
            if(txt_lname.Text.Trim() == "Last Name"){
                txt_lname.Text = "";
            }
        }

        void txt_fname_LostFocus(object sender, EventArgs e)
        {
            if (txt_fname.Text.Trim() == "")
            {
                txt_fname.Text = "First Name";
            }
        }

        void txt_fname_GotFocus(object sender, EventArgs e)
        {
            if (txt_fname.Text.Trim() == "First Name")
            {
                txt_fname.Text = "";
            }
        }


        void txt_provAdd_LostFocus(object sender, EventArgs e)
        {
            if (txt_provAdd.Text.Trim() == "")
            {
                txt_provAdd.Text = "Provincial address";
            }
        }

        void txt_provAdd_GotFocus(object sender, EventArgs e)
        {
            if (txt_provAdd.Text.Trim() == "Provincial address")
            {
                txt_provAdd.Text = "";
            }
        }


        #endregion

        private void txt_day_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_age_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = DateTime.Now;
            label5.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            txt_day.Text = numericUpDown1.Value.ToString();    
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            txt_year.Text = numericUpDown2.Value.ToString();
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



   


        //border
    }
}
