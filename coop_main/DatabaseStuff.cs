using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;


using MySql.Data;
using MySql.Data.MySqlClient;
namespace coop_main
{
    class DatabaseStuff
    {
        
        string hostIP = "localhost";
        string userID = "root";
        string passID = "";
        string dbName = "coopdb";

        string connString = "Server='localhost';Database='coopdb';User Id='root';Password='';";


        public DatabaseStuff() {
            hostIP = Properties.Settings.Default.serverip;
            userID = Properties.Settings.Default.dbuserid;
            passID = Properties.Settings.Default.dbpassword;
            connString = "Server='" + hostIP + "'; Database='"+dbName+"'; User Id='"+userID.Trim()+"'; Password='"+passID.Trim()+"';";
        }


        public String empIDLogIN(String user, String pass) {
            String id = "";
            String sql = "SELECT `user_id` FROM tbl_user WHERE `username` = '"+user+"' AND `userpass` = '"+pass+"' ";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        id = read.GetValue(0).ToString();
                    }
                }
            }
            finally
            {
                db.Close();
            }

            return id;
        }

        public long insertNewMembers(String lname, String fname, String mnane, String address, String provadd, String addresstype, String cellphone, String tellphone, String bday, String bplace, String age, String gender, String cstatus, String religion, String id, String iddet, String id2, String id2det, String educ, String occu, String workplace, String salary, String spouse, String spouseoccu, String spousesal, String photo, String benef1name, String benef1age, String benef1relatioship, bool b2, String benef2name, String benef2age, String benef2relatioship, bool b3, String benef3name, String benef3age, String benef3relatioship, bool b4, String benef4name, String benef4age, String benef4relatioship, bool b5, String benef5name, String benef5age, String benef5relatioship, bool b6, String benef6name, String benef6age, String benef6relatioship)
        {
            long new_memberID = 0;
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlCommand mySqlComm2 = new MySqlCommand();
            MySqlCommand mySqlComm3 = new MySqlCommand();


            MySqlCommand mySqlComm4 = new MySqlCommand();
            MySqlCommand mySqlComm5 = new MySqlCommand();
            MySqlCommand mySqlComm6 = new MySqlCommand();
            MySqlCommand mySqlComm7 = new MySqlCommand();
            MySqlCommand mySqlComm8 = new MySqlCommand();
            MySqlCommand mySqlComm9 = new MySqlCommand();

            MySqlTransaction trans = null;

            try
            {

                db.Open();
                trans = db.BeginTransaction();
                
                //New Member
                mySqlComm.CommandText = @"INSERT INTO tbl_members(`mem_lname`, `mem_fname`, `mem_mname`,`mem_address`,`mem_provaddress`,`mem_addresstype`, `mem_cellcontact`, `mem_tellcontact`, `mem_bday`,`mem_bplace`, `mem_age`, `mem_gender`,`mem_civilstatus`,`mem_religion`,`mem_id_one`,`mem_id_onedet`,`mem_id_two`,`mem_id_twodet`, `mem_active`) VALUES ('" + lname + "', '" + fname + "', '" + mnane + "', '" + address + "','" + provadd + "', '" + addresstype + "', '" + cellphone + "', '" + tellphone + "', '" + bday + "', '" + bplace + "', '" + age + "','" + gender + "', '" + cstatus + "', '" + religion + "', '" + id + "', '" + iddet + "', '" + id2 + "', '" + id2det + "', '1')  ";
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();
                new_memberID = mySqlComm.LastInsertedId;

                //New Member Details
                mySqlComm2.CommandText = @"INSERT INTO tbl_membersdetails(`mem_edAttainment`,`mem_occupation`, `mem_workplace`, `mem_salary`, `mem_spouseoccupation`,`mem_spouseworkplace`, `mem_spousesalary`, `mem_photo`, `mem_id`) VALUES ('" + educ + "', '" + occu + "', '" + workplace + "', '" + salary + "', '" + spouse + "', '" + spouseoccu + "', '" + spousesal + "', '" + photo + "' , '" + new_memberID + "')";
                mySqlComm2.Connection = db;
                mySqlComm2.Transaction = trans;
                mySqlComm2.ExecuteNonQuery();

                //currsaving
                mySqlComm3.CommandText = @"INSERT INTO tbl_currSavings(`mem_id`, `current_Savings`, `curr_ShareCapital`) VALUES ('" + new_memberID + "', '0', '0') ";
                mySqlComm3.Connection = db;
                mySqlComm3.Transaction = trans;
                mySqlComm3.ExecuteNonQuery();

                //beneficiaries 01
                mySqlComm4.CommandText = @"INSERT INTO tbl_membersbenef(`benef_name`, `benef_age`, `benef_relationship`, `mem_id`) VALUES ('" + benef1name + "', '" + benef1age + "', '" + benef1relatioship + "', '" + new_memberID + "')";
                mySqlComm4.Connection = db;
                mySqlComm4.Transaction = trans;
                mySqlComm4.ExecuteNonQuery();


                //benef 02
                if(b2){
                    mySqlComm5.CommandText = @"INSERT INTO tbl_membersbenef(`benef_name`, `benef_age`, `benef_relationship`, `mem_id`) VALUES ('" + benef2name + "', '" + benef2age + "', '" + benef2relatioship + "', '" + new_memberID + "')";
                    mySqlComm5.Connection = db;
                    mySqlComm5.Transaction = trans;
                    mySqlComm5.ExecuteNonQuery();
                }

                //benef 03
                if (b3)
                {
                    mySqlComm6.CommandText = @"INSERT INTO tbl_membersbenef(`benef_name`, `benef_age`, `benef_relationship`, `mem_id`) VALUES ('" + benef3name + "', '" + benef3age + "', '" + benef3relatioship + "', '" + new_memberID + "')";
                    mySqlComm6.Connection = db;
                    mySqlComm6.Transaction = trans;
                    mySqlComm6.ExecuteNonQuery();
                }

                //benef 04
                if (b4)
                {
                    mySqlComm7.CommandText = @"INSERT INTO tbl_membersbenef(`benef_name`, `benef_age`, `benef_relationship`, `mem_id`) VALUES ('" + benef4name + "', '" + benef4age + "', '" + benef4relatioship + "', '" + new_memberID + "')";
                    mySqlComm7.Connection = db;
                    mySqlComm7.Transaction = trans;
                    mySqlComm7.ExecuteNonQuery();
                }

                //benef 05
                if (b5)
                {
                    mySqlComm8.CommandText = @"INSERT INTO tbl_membersbenef(`benef_name`, `benef_age`, `benef_relationship`, `mem_id`) VALUES ('" + benef5name + "', '" + benef5age + "', '" + benef5relatioship + "', '" + new_memberID + "')";
                    mySqlComm8.Connection = db;
                    mySqlComm8.Transaction = trans;
                    mySqlComm8.ExecuteNonQuery();
                }

                //benef 06
                if (b6)
                {
                    mySqlComm9.CommandText = @"INSERT INTO tbl_membersbenef(`benef_name`, `benef_age`, `benef_relationship`, `mem_id`) VALUES ('" + benef6name + "', '" + benef6age + "', '" + benef6relatioship + "', '" + new_memberID + "')";
                    mySqlComm9.Connection = db;
                    mySqlComm9.Transaction = trans;
                    mySqlComm9.ExecuteNonQuery();
                }

               // string sql = "INSERT INTO tbl_userAccessRights (`emp_id` , `mem_module` , `mem_newmem` , `mem_record` , `pos_module` , `pos_register` , `pos_savedsales` , `pos_refunds`, `pos_endday` , `pos_endweek` , `pos_transhis` , `inv_module` , `inv_enteritems` , `stocks_submod` , `stocks_req` , `stocks_rec` , `stocks_ret` , `inv_itemlist` , `inv_report` , `col_module` , `col_loans` , `col_deposit` , `col_loanmoney` , `col_loanpay` , `col_moneycounter` , `rep_module` , `rep_mem` , `rep_inventory` , `rep_sales`, `rep_purchases` , `rep_loans` , `rep_trans` , `rep_pay` , `rep_listrep` , `payroll_module` , `misc_module` , `misc_uaccess` , `misc_audit` , `misc_loancal`) VALUES ('" + empID + "', 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, 0, 0 )";





                trans.Commit();
            }
            catch
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
            }

            return new_memberID;


        }

        public long updateAMembers(String member_ID, String lname, String fname, String mnane, String address, String provadd, String addresstype, String cellphone, String tellphone, String bday, String bplace, String age, String gender, String cstatus, String religion, String id, String iddet, String id2, String id2det, String educ, String occu, String workplace, String salary, String spouse, String spouseoccu, String spousesal, String photo, int newOrUpdateb1, String benef1name, String benef1age, String benef1relatioship, bool b2, int newOrUpdateb2, String benef2name, String benef2age, String benef2relatioship, bool b3, int newOrUpdateb3, String benef3name, String benef3age, String benef3relatioship, bool b4, int newOrUpdateb4, String benef4name, String benef4age, String benef4relatioship, bool b5, int newOrUpdateb5, String benef5name, String benef5age, String benef5relatioship, bool b6, int newOrUpdateb6, String benef6name, String benef6age, String benef6relatioship)
        {
            long new_memberID = 0;
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlCommand mySqlComm2 = new MySqlCommand();


            MySqlCommand mySqlComm4 = new MySqlCommand();
            MySqlCommand mySqlComm5 = new MySqlCommand();
            MySqlCommand mySqlComm6 = new MySqlCommand();
            MySqlCommand mySqlComm7 = new MySqlCommand();
            MySqlCommand mySqlComm8 = new MySqlCommand();
            MySqlCommand mySqlComm9 = new MySqlCommand();

            MySqlTransaction trans = null;

            try
            {

                db.Open();
                trans = db.BeginTransaction();

                //UPDATE Member
                mySqlComm.CommandText = @"UPDATE tbl_members SET `mem_lname` = '" + lname + "', `mem_fname` = '" + fname + "', `mem_mname` = '" + mnane + "', `mem_address` = '" + address + "', `mem_provaddress` = '" + provadd + "', `mem_addresstype` = '" + addresstype + "', `mem_cellcontact` = '" + cellphone + "', `mem_tellcontact` = '" + tellphone + "', `mem_bday` = '" + bday + "', `mem_bplace` = '" + bplace + "', `mem_age` = '" + age + "', `mem_gender` = '" + gender + "', `mem_civilstatus` = '" + cstatus + "', `mem_religion` = '" + religion + "', `mem_id_one` = '" + id + "', `mem_id_onedet` = '" + iddet + "', `mem_id_two` = '" + id2 + "', `mem_id_twodet` = '" + id2det + "' WHERE `mem_id` = '" + member_ID + "' ";
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();
                new_memberID = Int32.Parse(member_ID);

                //UPDATE Details
                mySqlComm2.CommandText = @"UPDATE tbl_membersdetails SET `mem_edAttainment` = '" + educ + "' ,`mem_occupation` = '" + occu + "' , `mem_workplace` = '" + workplace + "' , `mem_salary` = '" + salary + "' , `mem_spouseoccupation` = '" + spouse + "' ,`mem_spouseworkplace` = '" + spouseoccu + "' , `mem_spousesalary` = '" + spousesal + "' , `mem_photo` = '" + photo + "' WHERE `mem_id` = '" + member_ID + "' ";
                mySqlComm2.Connection = db;
                mySqlComm2.Transaction = trans;
                mySqlComm2.ExecuteNonQuery();


                //beneficiaries 01
                mySqlComm4.CommandText = @"UPDATE tbl_membersbenef SET `benef_name` = '" + benef1name + "' , `benef_age` = '" + benef1age + "' , `benef_relationship` = '" + benef1relatioship + "' WHERE `mem_id` = '" + new_memberID + "' ANd `membene_id` = '" + newOrUpdateb1 + "' ";
                mySqlComm4.Connection = db;
                mySqlComm4.Transaction = trans;
                mySqlComm4.ExecuteNonQuery();


                //benef 02
                if (b2)
                {
                    if (newOrUpdateb2 == 0)// if 0 insert new 
                    {
                        mySqlComm5.CommandText = @"INSERT INTO tbl_membersbenef(`benef_name`, `benef_age`, `benef_relationship`, `mem_id`) VALUES ('" + benef2name + "', '" + benef2age + "', '" + benef2relatioship + "', '" + new_memberID + "')";
                    }
                    else {
                        mySqlComm5.CommandText = @"UPDATE tbl_membersbenef SET `benef_name` = '" + benef2name + "' , `benef_age` = '" + benef2age + "' , `benef_relationship` = '" + benef2relatioship + "' WHERE `mem_id` = '" + new_memberID + "' ANd `membene_id` = '" + newOrUpdateb2 + "' ";
                    }
                    mySqlComm5.Connection = db;
                    mySqlComm5.Transaction = trans;
                    mySqlComm5.ExecuteNonQuery();
                }

                //benef 03
                if (b3)
                {
                    if (newOrUpdateb3 == 0)// if 0 insert new 
                    {
                        mySqlComm6.CommandText = @"INSERT INTO tbl_membersbenef(`benef_name`, `benef_age`, `benef_relationship`, `mem_id`) VALUES ('" + benef3name + "', '" + benef3age + "', '" + benef3relatioship + "', '" + new_memberID + "')";
                    }
                    else
                    {
                        mySqlComm6.CommandText = @"UPDATE tbl_membersbenef SET `benef_name` = '" + benef3name + "' , `benef_age` = '" + benef3age + "' , `benef_relationship` = '" + benef3relatioship + "' WHERE `mem_id` = '" + new_memberID + "' ANd `membene_id` = '" + newOrUpdateb3 + "' ";
                    }
                    mySqlComm6.Connection = db;
                    mySqlComm6.Transaction = trans;
                    mySqlComm6.ExecuteNonQuery();
                }

                //benef 04
                if (b4)
                {
                    if (newOrUpdateb4 == 0)// if 0 insert new 
                    {
                        mySqlComm7.CommandText = @"INSERT INTO tbl_membersbenef(`benef_name`, `benef_age`, `benef_relationship`, `mem_id`) VALUES ('" + benef4name + "', '" + benef4age + "', '" + benef4relatioship + "', '" + new_memberID + "')";
                    }
                    else
                    {
                        mySqlComm7.CommandText = @"UPDATE tbl_membersbenef SET `benef_name` = '" + benef4name + "' , `benef_age` = '" + benef4age + "' , `benef_relationship` = '" + benef4relatioship + "' WHERE `mem_id` = '" + new_memberID + "' ANd `membene_id` = '" + newOrUpdateb4 + "' ";
                    }
                    mySqlComm7.Connection = db;
                    mySqlComm7.Transaction = trans;
                    mySqlComm7.ExecuteNonQuery();
                }

                //benef 05
                if (b5)
                {
                    if (newOrUpdateb5 == 0)// if 0 insert new 
                    {
                        mySqlComm8.CommandText = @"INSERT INTO tbl_membersbenef(`benef_name`, `benef_age`, `benef_relationship`, `mem_id`) VALUES ('" + benef5name + "', '" + benef5age + "', '" + benef5relatioship + "', '" + new_memberID + "')";
                    }
                    else
                    {
                        mySqlComm8.CommandText = @"UPDATE tbl_membersbenef SET `benef_name` = '" + benef5name + "' , `benef_age` = '" + benef5age + "' , `benef_relationship` = '" + benef5relatioship + "' WHERE `mem_id` = '" + new_memberID + "' ANd `membene_id` = '" + newOrUpdateb5 + "' ";
                    }
                    mySqlComm8.Connection = db;
                    mySqlComm8.Transaction = trans;
                    mySqlComm8.ExecuteNonQuery();
                }

                //benef 06
                if (b6)
                {
                    if (newOrUpdateb6 == 0)// if 0 insert new 
                    {
                        mySqlComm9.CommandText = @"INSERT INTO tbl_membersbenef(`benef_name`, `benef_age`, `benef_relationship`, `mem_id`) VALUES ('" + benef6name + "', '" + benef6age + "', '" + benef6relatioship + "', '" + new_memberID + "')";
                    }
                    else
                    {
                        mySqlComm9.CommandText = @"UPDATE tbl_membersbenef SET `benef_name` = '" + benef6name + "' , `benef_age` = '" + benef6age + "' , `benef_relationship` = '" + benef6relatioship + "' WHERE `mem_id` = '" + new_memberID + "' ANd `membene_id` = '" + newOrUpdateb6 + "' ";
                    }
                    mySqlComm9.Connection = db;
                    mySqlComm9.Transaction = trans;
                    mySqlComm9.ExecuteNonQuery();
                }


                trans.Commit();
            }
            catch
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
            }

            return new_memberID;


        }

        public void getAllMembers(System.Windows.Forms.DataGridView view, int qtype, String search)
        {

            String sql = "SELECT m.mem_id, m.mem_fname, m.mem_lname, m.mem_active, c.current_Savings,c.current_ShareCapital  FROM tbl_members as m JOIN tbl_currsavings as c ON m.mem_id = c.mem_id WHERE m.mem_lname LIKE '%" + search + "%' OR m.mem_fname LIKE '%" + search + "%' OR m.mem_mname  LIKE '%" + search + "%'";
            if (qtype == 1)
            {
                sql = "SELECT m.mem_id, m.mem_fname, m.mem_lname, m.mem_active, c.current_Savings,c.current_ShareCapital  FROM tbl_members as m JOIN tbl_currsavings as c ON m.mem_id = c.mem_id";
            }
            else if (qtype == 2)
            {
                sql = "SELECT m.mem_id, m.mem_fname, m.mem_lname, m.mem_active, c.current_Savings,c.current_ShareCapital  FROM tbl_members as m JOIN tbl_currsavings as c ON m.mem_id = c.mem_id WHERE m.mem_active = 1 ";
            }
            else if (qtype == 3)
            {
                sql = "SELECT m.mem_id, m.mem_fname, m.mem_lname, m.mem_active, c.current_Savings,c.current_ShareCapital  FROM tbl_members as m JOIN tbl_currsavings as c ON m.mem_id = c.mem_id WHERE m.mem_active = 0";
            }
            else if (qtype == 4)
            {
                sql = "SELECT m.mem_id, m.mem_fname, m.mem_lname, m.mem_active, c.current_Savings,c.current_ShareCapital  FROM tbl_members as m JOIN tbl_currsavings as c ON m.mem_id = c.mem_id WHERE m.mem_lname LIKE '%" + search + "%' OR m.mem_fname LIKE '%" + search + "%' OR m.mem_mname  LIKE '%" + search + "%'";

            }


            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        String ewan, wanko;
                        if (read["mem_active"].ToString() == "1")
                        {
                            ewan = "Active";
                            wanko = "Deactivate";
                        }
                        else
                        {
                            ewan = "Inactive";
                            wanko = "Activate";
                        }
                        String memname = read.GetValue(1).ToString() + " " + read.GetValue(2).ToString();
                        decimal savings = decimal.Parse(read.GetValue(4).ToString());
                        decimal sharecapital = decimal.Parse(read.GetValue(5).ToString());
                        view.Rows.Add(new object[] {  read.GetValue(0), memname,  savings.ToString("N"), sharecapital.ToString("N"), ewan,"Details","Edit", wanko
                         });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }
       
        public void viewMemberBasicDetails(String memid, TextBox lname, TextBox fname, TextBox mname, TextBox address, TextBox provaddress,String anongklasebahay, TextBox telep, TextBox cp, DateTimePicker picker, TextBox bplace, TextBox age, ComboBox gender, String cvstat, ComboBox religion, TextBox id1, TextBox idnum1, TextBox id2, TextBox idnum2)
        {

            String sql = "SELECT * FROM tbl_members WHERE `mem_id` = '"+memid+"'";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        lname.Text = read.GetValue(1).ToString();
                        fname.Text = read.GetValue(2).ToString();
                        mname.Text = read.GetValue(3).ToString();
                        address.Text = read.GetValue(4).ToString();
                        provaddress.Text = read.GetValue(5).ToString();
                        anongklasebahay = read.GetValue(6).ToString(); //checkbox 
                        provaddress.Tag = read.GetValue(6).ToString();
                        telep.Text = read.GetValue(7).ToString();
                        cp.Text = read.GetValue(8).ToString();
                        picker.Value = DateTime.Parse(read.GetValue(9).ToString());
                        bplace.Text = read.GetValue(10).ToString();
                        age.Text = read.GetValue(11).ToString();

                        gender.SelectedItem = read.GetValue(12).ToString();
                        cvstat = read.GetValue(13).ToString();
                        age.Tag = read.GetValue(13).ToString();

                        religion.SelectedItem = read.GetValue(14).ToString().Replace("`", "'");

                        id1.Text = read.GetValue(15).ToString();
                        idnum1.Text = read.GetValue(16).ToString();
                        id2.Text = read.GetValue(17).ToString();
                        idnum2.Text = read.GetValue(18).ToString();
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void viewMemberDetailsExt(String memid, ComboBox educAttain, TextBox appOccu, TextBox appWork, TextBox appWorkPay, TextBox spouseOcc, TextBox spouseWork,  TextBox spousepay)
        {

            String sql = "SELECT * FROM tbl_membersdetails WHERE `mem_id` = '" + memid + "'";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        educAttain.SelectedItem = read.GetValue(1).ToString();
                        appOccu.Text = read.GetValue(2).ToString();
                        appWork.Text = read.GetValue(3).ToString();
                        appWorkPay.Text = read.GetValue(4).ToString();
                        spouseOcc.Text = read.GetValue(5).ToString();
                        spouseWork.Text = read.GetValue(6).ToString();
                        spousepay.Text = read.GetValue(7).ToString();
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void viewMemberDetailsBenef(String memid, TextBox defname, TextBox defage, TextBox defrel, TextBox defname2, TextBox defage2, TextBox defrel2, TextBox defname3, TextBox defage3, TextBox defrel3, TextBox defname4, TextBox defage4, TextBox defrel4, TextBox defname5, TextBox defage5, TextBox defrel5, TextBox defname6, TextBox defage6, TextBox defrel6)
        {

            String sql = "SELECT * FROM tbl_membersbenef WHERE `mem_id` = '" + memid + "'";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    int st = 1;
                    while (read.Read())
                    {
                        if (st == 1)
                        {
                            defname.Tag = read.GetValue(0).ToString();
                            defname.Text = read.GetValue(1).ToString();
                            defage.Text = read.GetValue(2).ToString();
                            defrel.Text = read.GetValue(3).ToString();

                        }
                        else if (st == 2)
                        {
                            defname2.Tag = read.GetValue(0).ToString();
                            defname2.Text = read.GetValue(1).ToString();
                            defage2.Text = read.GetValue(2).ToString();
                            defrel2.Text = read.GetValue(3).ToString();
                        }
                        else if (st == 3)
                        {
                            defname3.Tag = read.GetValue(0).ToString();
                            defname3.Text = read.GetValue(1).ToString();
                            defage3.Text = read.GetValue(2).ToString();
                            defrel3.Text = read.GetValue(3).ToString();
                        }
                        else if (st == 4)
                        {
                            defname4.Tag = read.GetValue(0).ToString();
                            defname4.Text = read.GetValue(1).ToString();
                            defage4.Text = read.GetValue(2).ToString();
                            defrel4.Text = read.GetValue(3).ToString();
                        }
                        else if (st == 5)
                        {
                            defname5.Tag = read.GetValue(0).ToString();
                            defname5.Text = read.GetValue(1).ToString();
                            defage5.Text = read.GetValue(2).ToString();
                            defrel5.Text = read.GetValue(3).ToString();
                        }
                        else if (st == 6)
                        {
                            defname6.Tag = read.GetValue(0).ToString();
                            defname6.Text = read.GetValue(1).ToString();
                            defage6.Text = read.GetValue(2).ToString();
                            defrel6.Text = read.GetValue(3).ToString();
                        }

                        st++;
                    }
                }
            }
            finally
            {
                db.Close();
            }


        }

        public long deactivateOrAcivateMember(String memid, String activeOrNot)
        {
            long deact_id = 0;
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();
                mySqlComm.CommandText = @"UPDATE tbl_members SET `mem_active` = '" + activeOrNot + "' WHERE `mem_id`= '" + memid + "' ";
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();

                deact_id = mySqlComm.LastInsertedId;
                trans.Commit();
            }
            catch
            {
                trans.Rollback();

            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }
            return deact_id;
        }

        //sss
        public void insertItems(String item_desc, String weight, String quantity, String ucost, String sellprice, String expdate, String itemcode, String cat, String uom, String emp_ID,bool istherePhoto, String photo)
        {
            long item_id = 0;
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlCommand mySqlComm2 = new MySqlCommand();
            MySqlTransaction trans = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();
                mySqlComm.CommandText = @"INSERT INTO tbl_items(`item_desc`,`net_weight`,`quantity`, `unit_cost`,`selling_price`, `expiration_date`, `item_code`, `category`, `unit_measurement`, `photo`) values ('" + item_desc + "','" + weight + "','" + quantity + "','" + ucost + "','" + sellprice + "','" + expdate + "','" + itemcode + "','" + cat + "','" + uom + "', ''  )";
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();
                item_id = mySqlComm.LastInsertedId;

                mySqlComm2.CommandText = @"INSERT INTO tbl_audit_trail (`aud_module`, `aud_action`, `emp_id`) VALUES ('Inventory','Enter Items','" + emp_ID + "') ";
                mySqlComm2.Connection = db;
                mySqlComm2.Transaction = trans;
                mySqlComm2.ExecuteNonQuery();

                if(istherePhoto){
                    System.Net.WebClient client = new System.Net.WebClient();
                    string myFile = photo;
                    client.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    string hosting = @"http://" + hostIP + "/coopdb/upload.php";
                    client.UploadFile(hosting, "POST", myFile);
                    //client.UploadFile(@"http://localhost/coopdb/upload.php", "POST", myFile);
                    client.Dispose();
                }
                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }


        }
      
        public void getAllProducts(System.Windows.Forms.DataGridView view)
        {
            view.Rows.Clear();
            string sql = "SELECT * FROM tbl_items";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        int qty = Int32.Parse(read.GetValue(3).ToString());
                        decimal unitcost = decimal.Parse(read.GetValue(4).ToString());
                        decimal sell = decimal.Parse((read.GetValue(5).ToString()));
                        view.Rows.Add(new object[] { 
                        read.GetValue(1),read.GetValue(2),qty.ToString("D2"),unitcost.ToString("N"),sell.ToString("N"),read.GetString(6),read.GetString(7),read.GetString(8),read.GetString(9) 
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }


        }

        public void getAllProducts2(System.Windows.Forms.DataGridView view)
        {
            //For LIST REPORT
            view.Columns.Clear();
            view.Rows.Clear();
            string sql = "SELECT * FROM tbl_items";


            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (read.HasRows && view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Item Desc");
                        view.Columns.Add("c2", "Package Net Weight");
                        view.Columns.Add("c3", "Unit Cost");
                        view.Columns.Add("c4", "Selling Price");
                        view.Columns.Add("c5", "Item Code");
                        view.Columns.Add("c6", "Category");
                        view.Columns.Add("c6", "Quantity");
                    }


                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        read.GetValue(1),read.GetValue(2),read.GetValue(4),decimal.Parse(read.GetValue(5).ToString()).ToString("N"),read.GetValue(7),read.GetValue(8),read.GetValue(3)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void getAllProducts2(System.Windows.Forms.DataGridView view, String search)
        {
            //FOR LIST REPORT & LIST REPORT INVENTORY PRODUCT
            view.Columns.Clear();
            view.Rows.Clear();
            string sql = "SELECT * FROM tbl_items WHERE item_desc LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' OR item_code LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' ";


            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (read.HasRows && view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Item Desc");
                        view.Columns.Add("c2", "Package Net Weight");
                        view.Columns.Add("c3", "Unit Cost");
                        view.Columns.Add("c4", "Selling Price");
                        view.Columns.Add("c5", "Item Code");
                        view.Columns.Add("c6", "Category");
                        view.Columns.Add("c6", "Quantity");
                    }


                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        read.GetValue(1),read.GetValue(2),read.GetValue(4),decimal.Parse(read.GetValue(5).ToString()).ToString("N"),read.GetValue(7),read.GetValue(8),read.GetValue(3)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public int getItemQuantity(String itemcode)
        {
            int  qrt = 0;
            string sql = "SELECT `quantity`FROM tbl_items WHERE `item_code` = '" + itemcode + "' LIMIT 1 ";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        qrt = Int32.Parse(read.GetValue(0).ToString());
                    }
                }
            }
            finally
            {
                db.Close();
            }

            return qrt;
        }

        public void getSearchProducts(System.Windows.Forms.DataGridView view, String searchQ)
        {
            view.Rows.Clear();
            string sql = "SELECT * FROM tbl_items WHERE UPPER(item_desc) LIKE '%" + searchQ + "%'";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        read.GetValue(1),read.GetValue(2),read.GetValue(3),read.GetValue(4),read.GetValue(5),read.GetString(6),read.GetString(7),read.GetString(8),read.GetString(9) 
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }



        }

        public void SearchProductz(String search, System.Windows.Forms.ListBox box, List<String> list)
        {
                //Open REGISTER

            string sql = "SELECT item_desc, item_code FROM tbl_items WHERE item_desc LIKE '%" + search.Trim().Replace("'", "`").Replace(";", "") + "%' OR item_code LIKE '%" + search.Trim().Replace("'", "`").Replace(";", "") + "%' AND quantity > 0  LIMIT 7";
                box.Items.Clear();
                list.Clear();
                bool che = false;

                MySqlConnection db = new MySqlConnection(connString);
                try
                {
                    db.Open();

                    MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                    using (MySqlDataReader read = mySqlComm.ExecuteReader())
                    {
                        if (!read.HasRows)
                        {
                            che = true;
                        }
                        while (read.Read())
                        {
                            box.Items.Add(read["item_desc"].ToString());
                            list.Add(read["item_code"].ToString());
                        }
                    }
                }
                finally
                {
                    db.Close();
                }

                if (che)
                {
                    box.Visible = false;
                }
                else
                {
                    box.SelectedIndex = 0;
                    box.Visible = true;
                }

        }

        public String insertTempInvoiceID(String customer_id, String time)
        {
            string mem_id = "0";
            long tempTranssactionID = 0;
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();
                mySqlComm.CommandText = @"INSERT INTO tbl_transactionlog(`customer_id`,`total_purchased`) VALUES ('" + customer_id + "', '0')";
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();

                tempTranssactionID = mySqlComm.LastInsertedId;
                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }

            mem_id = tempTranssactionID.ToString();
            return mem_id;


           
        }

        public void cancelTempTrans(String tempTransLogID)
        {
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();
                mySqlComm.CommandText = @"DELETE FROM tbl_tempor WHERE `or_number_ref` = '" + tempTransLogID + "'";
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();
                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }


        }

        public long recordPurchases(string transsql, string deductsql, string customer_ID, String translogid, decimal total,int totalqty, String empID, String or)
        {
            long tempORNum = 0;
            string realOr ="";
            MySqlConnection db = new MySqlConnection(connString);

            MySqlCommand mySqlCommOR = new MySqlCommand(); //ISSUES NEW OR
            MySqlCommand mySqlComm = new MySqlCommand(); //record everyitems into log
            MySqlCommand mySqlComm2 = new MySqlCommand();
            MySqlCommand mySqlComm3 = new MySqlCommand();
            MySqlCommand mySqlComm4 = new MySqlCommand();
            MySqlTransaction trans = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();


                //mySqlCommOR.CommandText = @"INSERT INTO tbl_ornumber(`nothing`) VALUES ('')"; 
                //mySqlCommOR.Connection = db;
                //mySqlCommOR.Transaction = trans;
                //mySqlCommOR.ExecuteNonQuery();
                //tempORNum = mySqlCommOR.LastInsertedId;

                realOr = or;

                mySqlComm.CommandText = transsql; //every items
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();


                mySqlComm2.CommandText = deductsql; //every items
                mySqlComm2.Connection = db;
                mySqlComm2.Transaction = trans;
                mySqlComm2.ExecuteNonQuery();

                mySqlComm3.CommandText = @"UPDATE tbl_transactionlog SET `total_purchased` = '" + total + "', `or_number` = '" + or + "', `emp_id` = '" + empID + "', `total_qty` = '" + totalqty + "' , `void` = '0' WHERE `translog_id` = '" + translogid + "'"; //UPDATe
                mySqlComm3.Connection = db;
                mySqlComm3.Transaction = trans;
                mySqlComm3.ExecuteNonQuery();

                mySqlComm4.CommandText = @"UPDATE tbl_inputtedor set `status` = '1', `consumed_date` =  NOW() wHERE `or_number_ref` = '" + or + "'"; //UPDATe
                mySqlComm4.Connection = db;
                mySqlComm4.Transaction = trans;
                mySqlComm4.ExecuteNonQuery();


                trans.Commit();
            }
            catch (MySqlException e)
            {
                trans.Rollback();
                MessageBox.Show(e.Message);
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }

            return tempORNum;


        }
  
        public void searchMemberEmployee(String search, System.Windows.Forms.ListBox box, List<String> lst) {
            String sql = "SELECT `mem_id`,`mem_fname`, `mem_lname` FROM tbl_members WHERE `mem_fname` LIKE '%" + search + "%' OR `mem_lname` LIKE '%" + search + "%' LIMIT 10 ";
            box.Items.Clear();

            lst.Clear();
            bool che = false;
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (!read.HasRows)
                    {
                        che = true;
                    }
                    while (read.Read())
                    {
                        lst.Add(read.GetValue(0).ToString());
                        box.Items.Add(read.GetValue(1).ToString() + " " + read.GetValue(2).ToString());
                    }
                }
            }
            finally
            {
                db.Close();
            }


            if (che)
            {
                box.Visible = false;
            }
            else
            {
                box.SelectedIndex = 0;
                box.Visible = true;
            }
        }

        public void popilateTransWhole(System.Windows.Forms.DataGridView view)
        {
            view.Rows.Clear();
            string sql = @"SELECT t.or_number,t.purchase_date,u.user_fullname,m.mem_id,m.mem_lname, m.mem_fname, t.total_purchased  FROM tbl_transactionlog as t JOIN tbl_members as m ON t.customer_id = m.mem_id JOIN tbl_user as u ON u.user_id = t.emp_id UNION
                            SELECT t.or_number, t.purchase_date, u.user_fullname, '0' as col,'NOT' as col2, 'AVAILABLE' as col3, t.total_purchased  FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id WHERE `customer_id` = 0 AND `total_purchased` != '0'
                            ORDER BY purchase_date DESC LIMIT 200";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        String cl = read.GetValue(4).ToString() + " " + read.GetValue(5).ToString();
                        DateTime deto = DateTime.Parse(read.GetValue(1).ToString());
                        decimal tot = decimal.Parse(read.GetValue(6).ToString());
                        view.Rows.Add(new object[] { 
                        read.GetValue(0),deto.ToString("MM/dd/yyyy hh:mm:ss tt"),read.GetValue(2),read.GetValue(3),cl,tot.ToString("N")
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void popilateTransWholeBetween(System.Windows.Forms.DataGridView view, DateTime from, DateTime to)
        {

             DateTime tod = to;
             DateTime tod2 = tod.AddDays(1);
             String a = from.ToString("yyyy-MM-dd");
             String b = tod2.ToString("yyyy-MM-dd");

            view.Rows.Clear();

            string sql = @"SELECT t.or_number,t.purchase_date,u.user_fullname,m.mem_id,m.mem_lname, m.mem_fname, t.total_purchased  FROM tbl_transactionlog as t JOIN tbl_members as m ON t.customer_id = m.mem_id JOIN tbl_user as u ON u.user_id = t.emp_id AND t.purchase_date BETWEEN '" + a + "' AND '" + b + "' UNION ";
                    sql +="        SELECT t.or_number, t.purchase_date, u.user_fullname, '0' as col,'NOT' as col2, 'AVAILABLE' as col3, t.total_purchased  FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id WHERE `customer_id` = 0 AND `total_purchased` != '0' AND t.purchase_date BETWEEN '" + a + "' AND '" + b + "' ORDER BY purchase_date DESC LIMIT 200";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        String cl = read.GetValue(4).ToString() + " " + read.GetValue(5).ToString();
                        DateTime deto = DateTime.Parse(read.GetValue(1).ToString());
                        decimal tot = decimal.Parse(read.GetValue(6).ToString());
                        view.Rows.Add(new object[] { 
                        read.GetValue(0),deto.ToString("MM/dd/yyyy hh:mm:ss tt"),read.GetValue(2),read.GetValue(3),cl,tot.ToString("N")
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public string gettotalAmountTrans() {

            //TRANS HISTORY
            String tmp = "";
            string sql = "SELECT SUM(total_purchased) as rowz FROM tbl_transactionlog";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        tmp = read["rowz"].ToString();
                    }
                }
            }
            finally
            {
                db.Close();
            }

            return tmp;
        
        }

        public string gettotalAmountTransBetween(String from, String to)
        {
            DateTime frod = DateTime.Parse(from);
            DateTime tod = DateTime.Parse(to);
            tod = tod.AddDays(1);
            String tmp = "";
            string sql = "SELECT SUM(total_purchased) as rowz FROM tbl_transactionlog WHERE `purchase_date` BETWEEN '" + frod.ToString("yyyy-MM-dd") + "' AND '" + tod.ToString("yyyy-MM-dd") + "' ";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        tmp = read["rowz"].ToString();
                    }
                }
            }
            finally
            {
                db.Close();
            }

            return tmp;
        }

        public int searchORVoid(String orId, System.Windows.Forms.TextBox employee, System.Windows.Forms.TextBox date, String totalpurchased, String customer_id, String trans_id)
        {
            string sql = "SELECT `translog_id`,`customer_id`, `purchase_date`, `total_purchased`, `emp_id` FROM tbl_transactionlog WHERE `or_number` = '" + orId + "' AND `void` != '1' LIMIT 1";
            int status = 0;

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (!read.HasRows)
                    {
                        status = 0;
                    }
                    else
                    {
                        status = 1;
                    }
                    while (read.Read())
                    {
                        trans_id = read["translog_id"].ToString();
                        customer_id = read["customer_id"].ToString();
                        date.Text = read["purchase_date"].ToString();
                        date.Tag = read["total_purchased"].ToString();
                        employee.Text = read["emp_id"].ToString();
                        employee.Tag = read["emp_id"].ToString();
                    }
                }
            }
            finally
            {
                db.Close();
            }

            return status;
        }

        public void searchORVoid(System.Windows.Forms.ListBox box, String orid)
        {
            String sql = "SELECT * FROM tbl_transactions as t JOIN tbl_transactionlog as l ON t.translog_id = l.translog_id WHERE  `or_number` = '" + orid + "'";
            box.Items.Clear();
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        box.Items.Add(read["item_name"].ToString() + "\n  " + read["item_qty_bought"].ToString() + " pcs x " + read["item_price"].ToString() + " pesos");
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public int voidAReceipt(String orid, String reason, String voiddate, String empID)
        {
            int stat = 0;
            string sql = "INSERT INTO tbl_voidreceipt (`receipttovoid_or`, `void_reason`, `emp_id`) VALUES ('" + orid + "','" + reason + "', '" + empID + "')";
            string sql2 = "UPDATE tbl_transactionlog SET `void` = '1' WHERE `or_number` = '" + orid + "' ";

            MySqlConnection db = new MySqlConnection(connString);

            MySqlCommand mySqlComm = new MySqlCommand(); //rVOID table
            MySqlCommand mySqlComm2 = new MySqlCommand(); //UPDATE THE transaction log and set it to voided
            MySqlTransaction trans = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();


                mySqlComm.CommandText = sql; 
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();


                mySqlComm2.CommandText = sql2; 
                mySqlComm2.Connection = db;
                mySqlComm2.Transaction = trans;
                mySqlComm2.ExecuteNonQuery();
                
                stat = 1;
                trans.Commit();
            }
            catch (MySqlException e)
            {
                stat = 0;
                trans.Rollback();
                MessageBox.Show(e.Message);
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }

            return stat;

        }

        //wala pa ito sa net
        #region savedTransactions

        public string newsavedTransactionLog(int cus_id)
        {
            String imaa = DateTime.Now.ToString();
            string sql = "INSERT into tbl_savedtransactionlog(customer_id) VALUES ('" + cus_id + "')";

            long savedID = 0;
            MySqlConnection db = new MySqlConnection(connString);

            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();


                mySqlComm.CommandText = sql;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();
                savedID = mySqlComm.LastInsertedId;

                trans.Commit();
            }
            catch (MySqlException e)
            {
                trans.Rollback();
                MessageBox.Show(e.Message);
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }



            return savedID.ToString();
        }

        public void recordSavedTransaction(int customer_id, int translog_id, String item_name, double price, int qty, double tot, String period, String date_purchase)
        {
            string sql = "INSERT INTO tbl_savedtransactions(customer_id, translog_id, item_name, item_price, item_qty_bought, total_amt, bought_period, bought_date) VALUES ('" + customer_id + "', '" + translog_id + "', '" + item_name + "', '" + price + "', '" + qty + "', '" + tot + "', '" + period + "', '" + date_purchase + "' )";
            MySqlConnection db = new MySqlConnection(connString);

            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();

                mySqlComm.CommandText = sql;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();

                trans.Commit();
            }
            catch (MySqlException e)
            {
                trans.Rollback();
                MessageBox.Show(e.Message);
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }
            
        }

        public void populateSavedTrans(System.Windows.Forms.DataGridView view, String where)
        {
            view.Rows.Clear();
            string sql = @"SELECT s.strans_id, s.customer_id,s.purchase_date,m.mem_lname,m.mem_fname FROM tbl_savedtransactionlog as s JOIN tbl_members as m ON s.customer_id = m.mem_id
                            UNION
                            SELECT strans_id, 'NOT AVAILABLE' as colz, purchase_date,'NOT AVAILABL' as colz2, 'NOT AVAILABLE' colz3  FROM tbl_savedtransactionlog WHERE `customer_id` = 0";

            String custname = "";


           MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (where == "2")
                    {
                        view.Columns.Clear();
                    }
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("", "Saved Trans ID");
                        view.Columns.Add("", "Customer ID");
                        view.Columns.Add("", "Customer Name");
                        view.Columns.Add("", "Trans Date");
                        view.Columns.Add("", "Actions");
                    }

                    while (read.Read())
                    {
                        if (read.GetValue(1).ToString() == "0")
                        {
                            custname = "NOT AVAILABLE";
                        }
                        else
                        {
                            custname = read.GetValue(4).ToString() + " " + read.GetValue(3).ToString();
                        }
                        view.Rows.Add(new object[] { 
            read.GetValue(0),read.GetValue(1),custname,read.GetValue(2).ToString()
            });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void populateSavedTrans2(System.Windows.Forms.DataGridView view, String where,bool between, DateTime start, DateTime end)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=coopdb.sqlite; Version=3; datetimeformat=CurrentCulture");
            conn.Open();
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");

            view.Rows.Clear();
            string sql = "";
            if (between)
            {
                sql = "SELECT s.strans_id, s.customer_id,s.purchase_date,m.mem_lname,m.mem_fname FROM tbl_savedtransactionlog as s JOIN tbl_members as m ON s.customer_id = m.mem_id WHERE s.purchase_date BETWEEN '" + startDate + "' AND '" + endDate + "'  UNION ";
                sql += "      SELECT strans_id, 'NOT AVAILABLE' as colz, purchase_date,'NOT AVAILABL' as colz2, 'NOT AVAILABLE' colz3  FROM tbl_savedtransactionlog WHERE `customer_id` = 0  AND purchase_date BETWEEN '" + startDate + "' AND '" + endDate + "' ";
            }
            else {
                 sql = @"SELECT s.strans_id, s.customer_id,s.purchase_date,m.mem_lname,m.mem_fname FROM tbl_savedtransactionlog as s JOIN tbl_members as m ON s.customer_id = m.mem_id 
                           UNION
                            SELECT strans_id, 'NOT AVAILABLE' as colz, purchase_date,'NOT AVAILABL' as colz2, 'NOT AVAILABLE' colz3  FROM tbl_savedtransactionlog WHERE `customer_id` = 0";
            }
           
            String custname = "";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (where == "2")
                    {
                        view.Columns.Clear();
                    }
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("", "Saved Trans ID");
                        view.Columns.Add("", "Customer ID");
                        view.Columns.Add("", "Customer Name");
                        view.Columns.Add("", "Trans Date");
                        view.Columns.Add("", "Actions");
                    }

                    while (read.Read())
                    {
                        if (read.GetValue(1).ToString() == "0")
                        {
                            custname = "NOT AVAILABLE";
                        }
                        else
                        {
                            custname = read.GetValue(4).ToString() + " " + read.GetValue(3).ToString();
                        }
                        view.Rows.Add(new object[] { 
            read.GetValue(0),read.GetValue(1),custname,read.GetValue(2).ToString()
            });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void populateSavedTransBetweem(System.Windows.Forms.DataGridView view, DateTime from,DateTime to)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=coopdb.sqlite; Version=3; datetimeformat=CurrentCulture");
            conn.Open();

            view.Rows.Clear();
            DateTime fromd = from;
            DateTime tod = to.AddDays(1);
            String startDate = fromd.ToString("yyyy-MM-dd");
            String endDate = tod.AddDays(1).ToString("yyyy-MM-dd");
           // string sql = "SELECT s.strans_id, s.customer_id,s.purchase_date,m.mem_lname,m.mem_fname FROM tbl_savedtransactionlog as s JOIN tbl_members as m ON s.customer_id = m.mem_id WHERE s.purchase_date BETWEEN '" + fromd.ToShortDateString() + "' AND  '" + to.ToShortDateString()+ "' ";
            string sql = "";

                sql = "SELECT s.strans_id, s.customer_id,s.purchase_date,m.mem_lname,m.mem_fname FROM tbl_savedtransactionlog as s JOIN tbl_members as m ON s.customer_id = m.mem_id WHERE s.purchase_date BETWEEN '" + startDate + "' AND '" + endDate + "'  UNION ";
                sql += "      SELECT strans_id, 'NOT AVAILABLE' as colz, purchase_date,'NOT AVAILABL' as colz2, 'NOT AVAILABLE' colz3  FROM tbl_savedtransactionlog WHERE `customer_id` = 0  AND purchase_date BETWEEN '" + startDate + "' AND '" + endDate + "' ";
            
            
            String custname = "";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        if (read.GetValue(1).ToString() == "0")
                        {
                            custname = "NOT AVAILABLE";
                        }
                        else
                        {
                            custname = read.GetValue(3).ToString() + " " + read.GetValue(4).ToString();
                        }
                        view.Rows.Add(new object[] { 
            read.GetValue(0),read.GetValue(1),custname,read.GetValue(2).ToString()
            });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }
        //

        public void populatesavedtramslog(System.Windows.Forms.ListView lv, String transod)
        {
            string sql = "SELECT * FROM tbl_savedtransactions WHERE `translog_id` = '"+transod+"'";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        ListViewItem tem = new ListViewItem(read["item_name"].ToString());

                        tem.SubItems.Add(read["item_qty_bought"].ToString());
                        tem.SubItems.Add(read["total_amt"].ToString());
                        tem.SubItems.Add(read["item_price"].ToString());
                        tem.Tag = read["item_code"].ToString();


                        lv.Items.Add(tem);
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void deleteSavedSales(String id)
        {
            String sql = "DELETE FROM tbl_savedtransactionlog WHERE strans_id = '"+id+"' ";
            String sql2 = "DELETE FROM tbl_savedtransactions WHERE translog_id = '" + id + "' ";


            MySqlConnection db = new MySqlConnection(connString);

            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();


                mySqlComm.CommandText = sql;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();

                mySqlComm.CommandText = sql2;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();

                trans.Commit();
            }
            catch (MySqlException e)
            {
                trans.Rollback();
                MessageBox.Show(e.Message);
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }

        }

        #endregion

        public String newstockRequest() {
            long tempReqID = 0;
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();
                mySqlComm.CommandText = @"INSERT INTO tbl_stockrequest(`stock_requestperson`) VALUES ('')";
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();
                tempReqID = mySqlComm.LastInsertedId;
                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }

            return tempReqID.ToString();

        }

        public long finishStockRequest(String sqlitems,String stockrqperson, String reqdate, String supp, String descs, String id ) {
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlCommand mySqlComm2 = new MySqlCommand();
            MySqlCommand mySqlComm3 = new MySqlCommand();
            MySqlTransaction trans = null;
            long invoiceNumber = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();

                mySqlComm.CommandText = @"INSERT INTO tbl_invoicenumber(`nothing`) VALUES ('')";
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();
                invoiceNumber = mySqlComm.LastInsertedId;
                
                mySqlComm2.CommandText = sqlitems;
                mySqlComm2.Connection = db;
                mySqlComm2.Transaction = trans;
                mySqlComm2.ExecuteNonQuery();
                
                mySqlComm3.CommandText = @"UPDATE tbl_stockrequest SET `stock_requestperson` = '" + stockrqperson + "', `stock_reqdate` = '" + reqdate + "', `stock_supplier` = '" + supp + "', `stock_desc` = '" + descs + "', `stock_finished` = '1', `invoice_number` = '" + invoiceNumber + "' WHERE  `stock_requestid` = '" + id + "'";
                mySqlComm3.Connection = db;
                mySqlComm3.Transaction = trans;
                mySqlComm3.ExecuteNonQuery();

                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }

            return invoiceNumber;

        }

        public void cancelStockRequest(long requestid) {
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlCommand mySqlComm2 = new MySqlCommand();
            MySqlTransaction trans = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();

                mySqlComm.CommandText = @"DELETE FROM tbl_stockrequest WHERE stock_requestid = '" + requestid + "'";
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();

                mySqlComm2.CommandText = @"DELETE FROM tbl_stockrqitems WHERE stock_requestid = '" + requestid + "'";
                mySqlComm2.Connection = db;
                mySqlComm2.Transaction = trans;
                mySqlComm2.ExecuteNonQuery();
                
                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }
        }

        public void getStockRequest(String requestid, TextBox rqperson, DateTimePicker picker, TextBox supp, TextBox desc, ListView view ) {

            string sql = "SELECT * FROM tbl_stockrequest WHERE `stock_requestid` = '" + requestid + "'  ";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (!read.HasRows)
                    {
                        rqperson.Text = "";
                        picker.Value = DateTime.Now;
                        supp.Text = "";
                        desc.Text = "";
                        view.Items.Clear();
                        MessageBox.Show("The Request ID you provide is either does not exists or already has been received");
                    }
                    else
                    {
                        view.Items.Clear();
                        getTobeReceivedItems(requestid, view);
                    }

                    while (read.Read())
                    {
                        rqperson.Text = read.GetValue(1).ToString();
                        DateTime ss = DateTime.Parse(read.GetValue(2).ToString());
                        picker.Value = ss;
                        supp.Text = read.GetValue(3).ToString();
                        desc.Text = read.GetValue(4).ToString();
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void getTobeReceivedItems(String stock_requestid, ListView view)
        {

            string sql = "SELECT * FROM tbl_stockrqitems WHERE `stock_requestid` = '" + stock_requestid + "'";

            int a = 1;
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        ListViewItem temp = new ListViewItem(a.ToString());
                        temp.SubItems.Add(read.GetValue(1).ToString());
                        temp.Tag = read.GetValue(2).ToString();
                        temp.SubItems.Add(read.GetValue(3).ToString());
                        temp.SubItems.Add(read.GetValue(4).ToString());
                        temp.SubItems.Add("Click to Add");
                        temp.SubItems.Add("Click to Add");
                        view.Items.Add(temp);
                        a++;
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        //for ret
        public void getStockReceived(String requestid, TextBox rqperson, DateTimePicker picker, TextBox supp, TextBox desc, ListView view)
        {
            string sql = "SELECT * FROM tbl_stockreceive WHERE `stock_receiveid` = '" + requestid + "'";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (!read.HasRows)
                    {
                        rqperson.Text = "";
                        picker.Value = DateTime.Now;
                        supp.Text = "";
                        desc.Text = "";
                        MessageBox.Show("The Request ID you provide is either does not exists or already has been received");
                        view.Items.Clear();
                    }
                    else
                    {
                        view.Items.Clear();
                        getTobeReturnedItems(requestid, view);
                    }
                    while (read.Read())
                    {
                        rqperson.Text = read.GetValue(1).ToString();
                        DateTime ss = DateTime.Parse(read.GetValue(5).ToString());
                        picker.Value = ss;
                        supp.Text = read.GetValue(3).ToString();
                        desc.Text = read.GetValue(4).ToString();
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void getTobeReturnedItems(String stock_receivedid, ListView view)
        {
            string sql = "SELECT * FROM tbl_stockrcitems WHERE `stock_receivedid` = '" + stock_receivedid + "'";
            int a = 1;
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        ListViewItem temp = new ListViewItem(a.ToString());
                        temp.SubItems.Add(read.GetValue(1).ToString());
                        temp.Tag = read.GetValue(2).ToString();
                        temp.SubItems.Add(read.GetValue(3).ToString());
                        temp.SubItems.Add(read.GetValue(4).ToString());
                        temp.SubItems.Add("Click to Add");
                        temp.SubItems.Add("Remove Line");
                        view.Items.Add(temp);
                        a++;
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        //reports
        public void getAllProductsRequested(System.Windows.Forms.DataGridView view, bool rangeparam, DateTime start, DateTime end)
        {

            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");

            view.Rows.Clear();
            string sql = "";
            if (rangeparam)
            {
                sql = "SELECT * FROM tbl_stockrqitems as rq JOIN tbl_stockrequest as st ON rq.stock_requestid = st.stock_requestid WHERE st.stock_reqdate BETWEEN '"+startDate+"' AND '"+endDate+"' ";

            }
            else {
               sql = "SELECT * FROM tbl_stockrqitems as rq JOIN tbl_stockrequest as st ON rq.stock_requestid = st.stock_requestid";
   
            }
            view.Columns.Clear();

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Stock Request No.");
                        view.Columns.Add("c2", "Stock Request Date");
                        view.Columns.Add("c2", "Inv. No");
                        view.Columns.Add("c3", "Request Person");
                        view.Columns.Add("c4", "Supplier");
                        view.Columns.Add("c5", "Description/Notes");
                        view.Columns.Add("c6", "Item/Description");
                        view.Columns.Add("c6", "Quantity Requested");
                        //view.Columns.Add("c6", "Unit of Measurement");
                    }

                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        read.GetValue(6),read.GetValue(8),read.GetValue(12),read.GetValue(7),read.GetValue(9),read.GetValue(10),  read.GetValue(3),read.GetValue(4)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void getAllProductsRequested(System.Windows.Forms.DataGridView view, bool rangeparam, DateTime start, DateTime end, String search)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");

            view.Rows.Clear();
            string sql = "";
            if (rangeparam)
            {
                sql = "SELECT * FROM tbl_stockrqitems as rq JOIN tbl_stockrequest as st ON rq.stock_requestid = st.stock_requestid WHERE st.stock_reqdate BETWEEN '" + startDate + "' AND '" + endDate + "' ";
            }
            else
            {
                sql = "SELECT * FROM tbl_stockrqitems as rq JOIN tbl_stockrequest as st ON rq.stock_requestid = st.stock_requestid WHERE rq.stock_itemname LIKE '%"+search.Replace("'","`").Replace(";","")+"%' ";
            }
            view.Columns.Clear();

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Stock No.");
                        view.Columns.Add("c2", "Stock Request Date");
                        view.Columns.Add("c2", "Inv. No");
                        view.Columns.Add("c3", "Request Person");
                        view.Columns.Add("c4", "Supplier");
                        view.Columns.Add("c5", "Description/Notes");
                        view.Columns.Add("c6", "Item/Description");
                        view.Columns.Add("c6", "Quantity Requested");
                        //view.Columns.Add("c6", "Unit of Measurement");
                    }

                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        read.GetValue(6),read.GetValue(8),read.GetValue(12),read.GetValue(7),read.GetValue(9),read.GetValue(10),  read.GetValue(3),read.GetValue(4)
                         });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void getAllProductsReceived(System.Windows.Forms.DataGridView view, bool rangeparam, DateTime start, DateTime end)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if (rangeparam)
            {
                sql = @"SELECT st.stock_requestid, st.stock_reqdate, st.stock_requestperson, st.stock_supplier, st.stock_desc, st.invoice_number, st.stock_receiveid, st.stock_deldate, u.user_fullname, rc.stock_itemname, rc.stock_rc_qty  
                        FROM tbl_stockrcitems as rc JOIN tbl_stockreceive as st ON rc.stock_receivedid = st.stock_receiveid JOIN tbl_user as u ON st.stock_recby = u.user_id WHERE st.stock_reqdate BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY st.stock_deldate DESC ";
            }
            else {
                sql = @"SELECT st.stock_requestid, st.stock_reqdate, st.stock_requestperson, st.stock_supplier, st.stock_desc, st.invoice_number, st.stock_receiveid, st.stock_deldate, u.user_fullname, rc.stock_itemname, rc.stock_rc_qty  
                        FROM tbl_stockrcitems as rc JOIN tbl_stockreceive as st ON rc.stock_receivedid = st.stock_receiveid JOIN tbl_user as u ON st.stock_recby = u.user_id ORDER BY st.stock_deldate DESC ";
            }
            

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Stock Request No.");
                        view.Columns.Add("c2", "Stock Request Date");
                        view.Columns.Add("c3", "Request Person");
                        view.Columns.Add("c4", "Supplier");
                        view.Columns.Add("c5", "Description/Notes");

                        view.Columns.Add("c66", "Inv No");
                        view.Columns.Add("c6", "Stock Received No");
                        view.Columns.Add("c6", "Stock Received Date");
                        view.Columns.Add("c6", "Received by");

                        view.Columns.Add("c6", "Item/Description");
                        view.Columns.Add("c6", "Quantity Received");
                    }

                    while (read.Read())
                    {
                        int stockreqno = Int32.Parse(read.GetValue(0).ToString());
                        int invNo = Int32.Parse(read.GetValue(5).ToString());
                        int stockrecno = Int32.Parse(read.GetValue(6).ToString());
                        int qtyRec = Int32.Parse(read.GetValue(10).ToString());
                        view.Rows.Add(new object[] { 
                        stockreqno.ToString("D2"),read.GetValue(1),read.GetValue(2),read.GetValue(3),read.GetValue(4),  invNo.ToString("D2"),stockrecno.ToString("D2"),read.GetValue(7),read.GetValue(8),  read.GetValue(9),qtyRec + " items"
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void getAllProductsReceived(System.Windows.Forms.DataGridView view, bool rangeparam, DateTime start, DateTime end, String search)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");
            view.Rows.Clear();
            string sql = "";
            if (rangeparam)
            {
                sql = @"SELECT st.stock_requestid, st.stock_reqdate, st.stock_requestperson, st.stock_supplier, st.stock_desc, st.invoice_number, st.stock_receiveid, st.stock_deldate, u.user_fullname, rc.stock_itemname, rc.stock_rc_qty  
                        FROM tbl_stockrcitems as rc JOIN tbl_stockreceive as st ON rc.stock_receivedid = st.stock_receiveid JOIN tbl_user as u ON st.stock_recby = u.user_id 
                        WHERE st.stock_reqdate BETWEEN '" + startDate + "' AND '" + endDate + "' AND rc.stock_itemname LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' ORDER BY st.stock_deldate DESC ";
            }
            else
            {

                sql = @"SELECT st.stock_requestid, st.stock_reqdate, st.stock_requestperson, st.stock_supplier, st.stock_desc, st.invoice_number, st.stock_receiveid, st.stock_deldate, u.user_fullname, rc.stock_itemname, rc.stock_rc_qty  
                        FROM tbl_stockrcitems as rc JOIN tbl_stockreceive as st ON rc.stock_receivedid = st.stock_receiveid JOIN tbl_user as u ON st.stock_recby = u.user_id
                        WHERE rc.stock_itemname LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' ORDER BY st.stock_deldate DESC ";
            }
            view.Columns.Clear();

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Stock Request No.");
                        view.Columns.Add("c2", "Stock Request Date");
                        view.Columns.Add("c3", "Request Person");
                        view.Columns.Add("c4", "Supplier");
                        view.Columns.Add("c5", "Description/Notes");

                        view.Columns.Add("c66", "Inv. No");
                        view.Columns.Add("c6", "Stock Received No");
                        view.Columns.Add("c6", "Stock Received Date");
                        view.Columns.Add("c6", "Received by");

                        view.Columns.Add("c6", "Item/Description");
                        view.Columns.Add("c6", "Quantity Received");
                    }

                    while (read.Read())
                    {
                        int stockreqno = Int32.Parse(read.GetValue(0).ToString());
                        int invNo = Int32.Parse(read.GetValue(5).ToString());
                        int stockrecno = Int32.Parse(read.GetValue(6).ToString());
                        int qtyRec = Int32.Parse(read.GetValue(10).ToString());
                        view.Rows.Add(new object[] { 
                        stockreqno.ToString("D2"),read.GetValue(1),read.GetValue(2),read.GetValue(3),read.GetValue(4),  invNo.ToString("D2"),stockrecno.ToString("D2"),read.GetValue(7),read.GetValue(8),  read.GetValue(9),qtyRec + " items"
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void getAllProductsReturned(System.Windows.Forms.DataGridView view, bool rangeparam, DateTime start, DateTime end)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");

            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if (rangeparam)
            {
                sql += @"SELECT st.stock_receiveid, st.stock_recdate, st.stock_receivedperson, st.stock_supplier, st.stock_desc, st.invoice_number,st.stock_returnid, st.stock_retdate, u.user_fullname, rt.stock_itemname, rt.stock_rt_qty FROM tbl_stockrtitems as rt 
                        JOIN tbl_stockreturn as st ON rt.stock_returnid = st.stock_returnid JOIN tbl_user as u ON st.stock_retby = u.user_id
                         WHERE st.stock_retdate BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY st.stock_retdate DESC";
            
            }
            else {
                sql += @"SELECT st.stock_receiveid, st.stock_recdate, st.stock_receivedperson, st.stock_supplier, st.stock_desc, st.invoice_number,st.stock_returnid, st.stock_retdate, u.user_fullname, rt.stock_itemname, rt.stock_rt_qty FROM tbl_stockrtitems as rt 
                        JOIN tbl_stockreturn as st ON rt.stock_returnid = st.stock_returnid JOIN tbl_user as u ON st.stock_retby = u.user_id ORDER BY st.stock_retdate DESC";
            
            }

           
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Stocks Received No");
                        view.Columns.Add("c2", "Stock Received Date");
                        view.Columns.Add("c3", "Person Received");
                        view.Columns.Add("c4", "Supplier");
                        view.Columns.Add("c5", "Description/Notes");

                        view.Columns.Add("c66", "Inv. No");
                        view.Columns.Add("c6", "Stock Return No.");
                        view.Columns.Add("c6", "Stock Return Date");
                        view.Columns.Add("c6", "Returned by");

                        view.Columns.Add("c6", "Item/Description");
                        view.Columns.Add("c6", "Quantity Returned");
                    }

                    while (read.Read())
                    {
                        int stockrecno = Int32.Parse(read.GetValue(0).ToString());
                        int invNo = Int32.Parse(read.GetValue(5).ToString());
                        int stockretno = Int32.Parse(read.GetValue(6).ToString());
                        int qtyRet = Int32.Parse(read.GetValue(10).ToString());
                        view.Rows.Add(new object[] { 
                        stockrecno.ToString("D2"),read.GetValue(1),read.GetValue(2),read.GetValue(3),read.GetValue(4),  invNo.ToString("D2"),stockretno.ToString("D2"),read.GetValue(7),read.GetValue(8),  read.GetValue(9),qtyRet + " items"
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void getAllProductsReturned(System.Windows.Forms.DataGridView view, bool rangeparam, DateTime start, DateTime end, String search)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");


            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if (rangeparam)
            {
                sql = "SELECT * FROM tbl_stockrtitems as rq JOIN tbl_stockreturn as st ON rq.stock_returnid = st.stock_returnid WHERE st.stock_retdate BETWEEN '" + startDate + "' AND '" + endDate + "' ";
            }
            else
            {
                sql += @"SELECT st.stock_receiveid, st.stock_recdate, st.stock_receivedperson, st.stock_supplier, st.stock_desc, st.invoice_number,st.stock_returnid, st.stock_retdate, u.user_fullname, rt.stock_itemname, rt.stock_rt_qty FROM tbl_stockrtitems as rt 
                        JOIN tbl_stockreturn as st ON rt.stock_returnid = st.stock_returnid JOIN tbl_user as u ON st.stock_retby = u.user_id 
                        WHERE rq.stock_itemname LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' ORDER BY st.stock_retdate DESC";
            
                //sql = "SELECT * FROM tbl_stockrtitems as rq JOIN tbl_stockreturn as st ON rq.stock_returnid = st.stock_returnid WHERE rq.stock_itemname LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%'";
            }

            
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Stocks Received No");
                        view.Columns.Add("c2", "Stock Received Date");
                        view.Columns.Add("c3", "Person Received");
                        view.Columns.Add("c4", "Supplier");
                        view.Columns.Add("c5", "Description/Notes");

                        view.Columns.Add("c66", "Inv. No");
                        view.Columns.Add("c6", "Stock Return No.");
                        view.Columns.Add("c6", "Stock Return Date");
                        view.Columns.Add("c6", "Returned by");

                        view.Columns.Add("c6", "Item/Description");
                        view.Columns.Add("c6", "Quantity Returned");
                    }

                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        read.GetValue(16),read.GetValue(10),read.GetValue(9),read.GetValue(11),read.GetValue(12),  read.GetValue(17),read.GetValue(7),  read.GetValue(13),read.GetValue(14),read.GetValue(3),read.GetValue(5)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void getAllProductsExpiredAndExpiring(System.Windows.Forms.DataGridView view, bool rangeparam, DateTime start, DateTime end)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");
            int no = 1;

            view.Rows.Clear();
            string sql = "";
            if (rangeparam)
            {
                sql = "SELECT sc.stock_itemname,sc.stock_expdate, s.stock_deldate, s.stock_supplier , i.net_weight, sc.stock_itemcode,i.category,sc.stock_rc_qty FROM tbl_stockreceive as s JOIN tbl_stockrcitems as sc ON s.stock_receiveid = sc.stock_receivedid JOIN tbl_items as i ON sc.stock_itemcode = i.item_code WHERE sc.stock_expdate BETWEEN '" + startDate + "' AND '" + endDate + "'  ";
            }
            else
            {
                sql = "SELECT sc.stock_itemname,sc.stock_expdate, s.stock_deldate, s.stock_supplier , i.net_weight, sc.stock_itemcode,i.category,sc.stock_rc_qty FROM tbl_stockreceive as s JOIN tbl_stockrcitems as sc ON s.stock_receiveid = sc.stock_receivedid JOIN tbl_items as i ON sc.stock_itemcode = i.item_code ORDER BY sc.stock_expdate ASC ";

            }

            view.Columns.Clear();

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "No");
                        view.Columns.Add("c2", "Item Description");
                        view.Columns.Add("c3", "Date of Expiration");
                        view.Columns.Add("c4", "Date of Acquisition");
                        view.Columns.Add("c5", "Supplier");

                        view.Columns.Add("c66", "Package Net Weight");
                        view.Columns.Add("c6", "Item Code");
                        view.Columns.Add("c6", "Category");
                        view.Columns.Add("c6", "Delivered Qty");

                    }

                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        no++,read.GetValue(0),read.GetValue(1),read.GetValue(2),read.GetValue(3),read.GetValue(4),  read.GetValue(5),read.GetValue(6),  read.GetValue(7)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void getAllProductsExpiredAndExpiring(System.Windows.Forms.DataGridView view, bool rangeparam, DateTime start, DateTime end, String search)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");
            int no = 1;

            view.Rows.Clear();
            string sql = "";
            if (rangeparam)
            {
                sql = "SELECT sc.stock_itemname,sc.stock_expdate, s.stock_deldate, s.stock_supplier , i.net_weight, sc.stock_itemcode,i.category,sc.stock_rc_qty FROM tbl_stockreceive as s JOIN tbl_stockrcitems as sc ON s.stock_receiveid = sc.stock_receivedid JOIN tbl_items as i ON sc.stock_itemcode = i.item_code WHERE sc.stock_expdate BETWEEN '" + startDate + "' AND '" + endDate + "'  ";

            }
            else
            {
                sql = "SELECT sc.stock_itemname,sc.stock_expdate, s.stock_deldate, s.stock_supplier , i.net_weight, sc.stock_itemcode,i.category,sc.stock_rc_qty FROM tbl_stockreceive as s JOIN tbl_stockrcitems as sc ON s.stock_receiveid = sc.stock_receivedid JOIN tbl_items as i ON sc.stock_itemcode = i.item_code WHERE sc.stock_itemname LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%'  ORDER BY sc.stock_expdate ASC ";


            }

            view.Columns.Clear();
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "No");
                        view.Columns.Add("c2", "Item Description");
                        view.Columns.Add("c3", "Date of Expiration");
                        view.Columns.Add("c4", "Date of Acquisition");
                        view.Columns.Add("c5", "Supplier");

                        view.Columns.Add("c66", "Package Net Weight");
                        view.Columns.Add("c6", "Item Code");
                        view.Columns.Add("c6", "Category");
                        view.Columns.Add("c6", "Delivered Qty");

                    }

                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        no++,read.GetValue(0),read.GetValue(1),read.GetValue(2),read.GetValue(3),read.GetValue(4),  read.GetValue(5),read.GetValue(6),  read.GetValue(7)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void getAllProductsLessThanQTY(System.Windows.Forms.DataGridView view, int lesstha )
        {
            view.Columns.Clear();
            view.Rows.Clear();
            string sql = "SELECT * FROM tbl_items WHERE quantity < '"+lesstha+"' ORDER BY quantity ASC ";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        if (read.HasRows && view.Columns.Count == 0)
                        {
                            view.Columns.Add("c1", "Item Desc");
                            view.Columns.Add("c2", "Package Net Weight");
                            view.Columns.Add("c3", "Unit Cost");
                            view.Columns.Add("c4", "Selling Price");
                            view.Columns.Add("c5", "Item Code");
                            view.Columns.Add("c6", "Category");
                            view.Columns.Add("c6", "Quantity");
                        }

                    }
                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { read.GetValue(1), read.GetValue(2), read.GetValue(4), decimal.Parse(read.GetValue(5).ToString()).ToString("N"), read.GetValue(7), read.GetValue(8), read.GetValue(3) });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void getAllProductsLessThanQTY(System.Windows.Forms.DataGridView view, int lesstha, String search)
        {
            view.Columns.Clear();
            view.Rows.Clear();
            string sql = "SELECT * FROM tbl_items WHERE quantity < '" + lesstha + "' AND item_desc LIKE '%"+search.Replace("'","`").Replace(";","")+"%' ";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        if (read.HasRows && view.Columns.Count == 0)
                        {
                            view.Columns.Add("c1", "Item Desc");
                            view.Columns.Add("c2", "Package Net Weight");
                            view.Columns.Add("c3", "Unit Cost");
                            view.Columns.Add("c4", "Selling Price");
                            view.Columns.Add("c5", "Item Code");
                            view.Columns.Add("c6", "Category");
                            view.Columns.Add("c6", "Quantity");
                        }

                    }
                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { read.GetValue(1), read.GetValue(2), read.GetValue(4), decimal.Parse(read.GetValue(5).ToString()).ToString("N"), read.GetValue(7), read.GetValue(8), read.GetValue(3) });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        //USER ACCOUNTS
        public int createNewUser(String username, String password, String fname)
        {
            string sql = "INSERT INTO tbl_user (`username`, `userpass`,`user_fullname`,`admin_priv`,`date_created`, `active`) VALUES ('" + username + "', '" + password + "','" + fname + "',0, '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '1')";
           
            
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlCommand mySqlComm2 = new MySqlCommand();
            MySqlTransaction trans = null;
            int stat = 0;
            long tempUserID = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();
                mySqlComm.CommandText = sql;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                stat = mySqlComm.ExecuteNonQuery();
                tempUserID = mySqlComm.LastInsertedId;



                mySqlComm2.CommandText = @"INSERT INTO tbl_userAccessRights (`emp_id` , `mem_module` , `mem_newmem` , `mem_record` , `pos_module` , `pos_register` , `pos_savedsales` , `pos_refunds`, `pos_endday` , `pos_endweek` , `pos_transhis` , `inv_module` , `inv_enteritems` , `stocks_submod` , `stocks_req` , `stocks_rec` , `stocks_ret` , `inv_itemlist` , `inv_report` , `col_module` , `col_loans` , `col_deposit` , `col_loanmoney` , `col_loanpay` , `col_moneycounter` , `rep_module` , `rep_mem` , `rep_inventory` , `rep_sales`, `rep_purchases` , `rep_loans` , `rep_trans` , `rep_pay` , `rep_listrep` , `payroll_module` , `misc_module` , `misc_uaccess` , `misc_audit` , `misc_loancal`)
                                            VALUES ('" + tempUserID + "', 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, 0, 0 )";
                mySqlComm2.Connection = db;
                mySqlComm2.Transaction = trans;
                mySqlComm2.ExecuteNonQuery();

                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }

            return stat;
        }

        public int createNewUserAdmin(String username, String password, String fname)
        {
            string sql = "INSERT INTO tbl_user (`username`, `userpass`,`user_fullname`,`admin_priv`,`date_created`, `active`) VALUES ('" + username + "', '" + password + "','"+fname+"',1, '"+DateTime.Now.ToString("yyyy-MM-dd")+"', '1')";
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlCommand mySqlComm2 = new MySqlCommand();
            MySqlTransaction trans = null;
            int stat = 0;
            long tempUserID = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();
                mySqlComm.CommandText = sql;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                stat = mySqlComm.ExecuteNonQuery();
                tempUserID = mySqlComm.LastInsertedId;



                mySqlComm2.CommandText = @"INSERT INTO tbl_userAccessRights (`emp_id` , `mem_module` , `mem_newmem` , `mem_record` , `pos_module` , `pos_register` , `pos_savedsales` , `pos_refunds`, `pos_endday` , `pos_endweek` , `pos_transhis` , `inv_module` , `inv_enteritems` , `stocks_submod` , `stocks_req` , `stocks_rec` , `stocks_ret` , `inv_itemlist` , `inv_report` , `col_module` , `col_loans` , `col_deposit` , `col_loanmoney` , `col_loanpay` , `col_moneycounter` , `rep_module` , `rep_mem` , `rep_inventory` , `rep_sales`, `rep_purchases` , `rep_loans` , `rep_trans` , `rep_pay` , `rep_listrep` , `payroll_module` , `misc_module` , `misc_uaccess` , `misc_audit` , `misc_loancal`)
                                            VALUES ('" + tempUserID + "', 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, 0, 0 )";
                mySqlComm2.Connection = db;
                mySqlComm2.Transaction = trans;
                mySqlComm2.ExecuteNonQuery();

                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }
            
            return stat;
        }

        public int updateUserAdmin(String id, String username, String password, String fname, int admin_priv)
        {
            string sql = "UPDATE tbl_user SET `username` = '"+username+"', `userpass` = '"+password+"', `user_fullname` = '"+fname+"', `admin_priv` = '"+admin_priv+"' WHERE `user_id` = '"+id+"' ";
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;
            int stat = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();
                mySqlComm.CommandText = sql;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                stat = mySqlComm.ExecuteNonQuery();

                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }

            return stat;
        }

        public int deactivateUserAdmin(String id, int activeOrNot)
        {
            string sql = "UPDATE tbl_user SET `active` = '" + activeOrNot + "' WHERE `user_id` = '"+id+"' ";
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;
            int stat = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();
                mySqlComm.CommandText = sql;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                stat = mySqlComm.ExecuteNonQuery();

                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }

            return stat;
        }

        public void getUserorAdmin(DataGridView view, int admin) {

            view.Rows.Clear();
            string sql = "SELECT * FROM tbl_user WHERE `admin_priv` = '"+admin+"' ";

            String tmp = "";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        if (read.GetValue(6).ToString() == "0")
                        {
                            tmp = "Activate";

                        }
                        else if (read.GetValue(6).ToString() == "1")
                        {
                            tmp = "Deactivate";
                        }
                        view.Rows.Add(new object[] { 
                        read.GetValue(0),read.GetValue(1),read.GetValue(5),"View Details", "Change Details", tmp
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void getAllUserForAccessRights(DataGridView view)
        {
            view.Rows.Clear();
            string sql = "SELECT `user_fullname`,`user_id` FROM tbl_user WHERE `active` = '1' ";
            int no = 1;
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        no.ToString(), read.GetValue(0), read.GetValue(1)
                        });
                        no++;

                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void getAllUserForAccessRightsSearchzz(DataGridView view, String search)
        {
            view.Rows.Clear();
            string sql = "SELECT `user_fullname`,`user_id` FROM tbl_user WHERE `active` = '1' AND `username` LIKE '%" + search + "%'  OR `user_fullname` LIKE '%" + search + "%' ";
            int no = 1;
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        no.ToString(), read.GetValue(0), read.GetValue(1)
                        });
                        no++;

                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void getUserorAdminSearcj(DataGridView view,String search, int admin)
        {
            view.Rows.Clear();
            string sql = "SELECT * FROM tbl_user WHERE `admin_priv` = '" + admin + "' AND `username` LIKE '%"+search+"%' ";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        read.GetValue(0),read.GetValue(1),read.GetValue(5),"View Details", "Change Details", "Deactivate"
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void getUserorAdminDetails(TextBox fname, TextBox uname, TextBox password, int userid)
        {
            string sql = "SELECT * FROM tbl_user WHERE `user_id` = '"+userid+"' LIMIT 1";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        fname.Text = read.GetValue(3).ToString();
                        uname.Text = read.GetValue(1).ToString();
                        password.Text = read.GetValue(2).ToString();
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        //Deposit, Withdraw, Loan, Pay Stuffs
        public long newDeposit(String custom_id, String emp_ID, String date, decimal deposit)
        {
            long deposit_id = 0;
            long tempORnum = 0;
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlCommand mySqlComm2 = new MySqlCommand();
            MySqlCommand mySqlComm3 = new MySqlCommand();
            MySqlCommand mySqlCommINV = new MySqlCommand();
        
            MySqlTransaction trans = null;
          
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();

                mySqlCommINV.CommandText = @"INSERT INTO tbl_ornumber(`nothing`) VALUES ('')";
                mySqlCommINV.Connection = db;
                mySqlCommINV.Transaction = trans;
                mySqlCommINV.ExecuteNonQuery();
                tempORnum = mySqlCommINV.LastInsertedId;

                mySqlComm.CommandText = @"INSERT INTO tbl_deposit (`customer_id`, `process_by`,`deposit`,`or_num`) VALUES ('" + custom_id + "', '" + emp_ID + "', '" + deposit.ToString() + "', '" + tempORnum + "'); ";
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();
                deposit_id = mySqlComm.LastInsertedId;

                mySqlComm2.CommandText = @"UPDATE  tbl_currSavings SET `current_Savings` = `current_Savings` + '" + deposit + "' WHERE `mem_id` = '" + custom_id + "' ";
                mySqlComm2.Connection = db;
                mySqlComm2.Transaction = trans;
                mySqlComm2.ExecuteNonQuery();

                mySqlComm3.CommandText = @"INSERT INTO tbl_audit_trail (`aud_module`, `aud_action`, `emp_id`) VALUES ('Loans','Deposit Money','" + emp_ID + "') ";
                mySqlComm3.Connection = db;
                mySqlComm3.Transaction = trans;
                mySqlComm3.ExecuteNonQuery();


                trans.Commit();
            }
            catch
            {
                trans.Rollback();

            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }
            return deposit_id;


        }

        public long newWithdraw(String custom_id, String emp_ID, String date, decimal withdraw)
        {
            long withdraw_id = 0;
            long tempORnum = 0;

            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlCommINV = new MySqlCommand();

            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlCommand mySqlComm2 = new MySqlCommand();

            MySqlCommand mySqlComm3 = new MySqlCommand();
            MySqlTransaction trans = null;
            try
            {
            db.Open();
          
            trans = db.BeginTransaction();

            mySqlCommINV.CommandText = @"INSERT INTO tbl_ornumber(`nothing`) VALUES ('')";
            mySqlCommINV.Connection = db;
            mySqlCommINV.Transaction = trans;
            mySqlCommINV.ExecuteNonQuery();
            tempORnum = mySqlCommINV.LastInsertedId;
          
                mySqlComm.CommandText = @"INSERT INTO tbl_withdraw (`customer_id`, `process_by`,`withdraw`, `or_num`) VALUES ('" + custom_id + "', '" + emp_ID + "', '" + withdraw.ToString() + "', '"+tempORnum+"' ); ";
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();
                withdraw_id = mySqlComm.LastInsertedId;


                mySqlComm2.CommandText = @"UPDATE tbl_currSavings SET `current_Savings` = `current_Savings` - '" + withdraw + "' WHERE `mem_id` = '" + custom_id + "' ";
                mySqlComm2.Connection = db;
                mySqlComm2.Transaction = trans;
                mySqlComm2.ExecuteNonQuery();

                mySqlComm3.CommandText = @"INSERT INTO tbl_audit_trail (`aud_module`, `aud_action`, `emp_id`) VALUES ('Loans','Withdraw Money','" + emp_ID + "') ";
                mySqlComm3.Connection = db;
                mySqlComm3.Transaction = trans;
                mySqlComm3.ExecuteNonQuery();

                trans.Commit();
            }
            catch
            {
                trans.Rollback();

            }
            finally
            {
                db.Close();
            }
            return withdraw_id;

        }
       
        public String getEmployeeDetails(String id) {
            string sql = "SELECT `user_fullname` FROM tbl_user WHERE `user_id` = '" + id + "' LIMIT 1 ";
            String name = "";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        name = read["user_fullname"].ToString();
                    }
                }
            }
            finally
            {
                db.Close();
            }
            return name;

        }

        public long newLoan(String mem_id, decimal principal, decimal tot, String term, String duration, double rate, String notes, DateTime processdate, DateTime stdate, DateTime eddate, String empId, decimal fillfee, decimal procfee, decimal shcapita, String custID, String dateprocessed)
        {
            long loan_id = 0;
            long tempORnum = 0;
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlInv = new MySqlCommand();


            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlCommand mySqlComm2 = new MySqlCommand();
            MySqlCommand mySqlComm3 = new MySqlCommand();
            MySqlCommand mySqlComm4 = new MySqlCommand();
            MySqlTransaction trans = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
            db.Open();
           
            trans = db.BeginTransaction();


            mySqlInv.CommandText = @"INSERT INTO tbl_ornumber(`nothing`) VALUES ('')";
            mySqlInv.Connection = db;
            mySqlInv.Transaction = trans;
            mySqlInv.ExecuteNonQuery();
            tempORnum = mySqlInv.LastInsertedId;



                mySqlComm.CommandText = @"INSERT INTO tbl_loanlog(`mem_id`, `principal_amount`, `total_amount`, `term_loan`, `term_duration`, `rate_interest`, `notes`, `process_date`, `start_date`, `end_date`, `emp_id`, `isPaid`, `or_num`) VALUES ('" + mem_id + "', '" + principal + "', '" + tot + "', '" + term + "', '" + duration + "', '" + rate + "', '" + notes + "', '" + processdate.ToString("yyyy-MM-dd") + "', '" + stdate.ToString("yyyy-MM-dd") + "', '" + eddate.ToString("yyyy-MM-dd") + "', '" + empId + "', '0', '"+tempORnum+"' )";
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();
                loan_id = mySqlComm.LastInsertedId;

                mySqlComm2.CommandText = @"INSERT INTO tbl_feefiling(`fillfee_amt`, `loanlog_id`, `customer_id`, `emp_id`, `date_filed`) VALUES ('" + fillfee + "','" + loan_id + "','" + custID + "','" + empId + "','" + dateprocessed + "' ) ";
                mySqlComm2.Connection = db;
                mySqlComm2.Transaction = trans;
                mySqlComm2.ExecuteNonQuery();

                mySqlComm3.CommandText = @"INSERT INTO tbl_feeprocessing(`procfee_amt`, `loanlog_id`, `customer_id`, `emp_id`, `date_filed`) VALUES ('" + procfee + "','" + loan_id + "','" + custID + "','" + empId + "','" + dateprocessed + "') ";
                mySqlComm3.Connection = db;
                mySqlComm3.Transaction = trans;
                mySqlComm3.ExecuteNonQuery();

                mySqlComm4.CommandText = @"INSERT INTO tbl_feesharecapital(`shcap_amt`, `loanlog_id`, `customer_id`, `emp_id`, `date_filed`) VALUES ('" + shcapita + "','" + loan_id + "','" + custID + "','" + empId + "','" + dateprocessed + "') ";
                mySqlComm4.Connection = db;
                mySqlComm4.Transaction = trans;
                mySqlComm4.ExecuteNonQuery();
               
                //insertAuditTrail(empId, "Loans", "Loan Money", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                trans.Commit();
            }
            catch
            {
                trans.Rollback();

            }
            finally {
                db.Close();
                Cursor.Current = Cursors.Default;
            }
            return loan_id;
       
        }

        public long getLoanId(String cusID)
        {
            long loan_id = 0;
            string sql = "SELECT `loanlog_id` FROM tbl_loanlog WHERE `mem_id` = '"+cusID+"' AND `ispaid` = '0'  LIMIT 1";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        loan_id = Int32.Parse(read["loanlog_id"].ToString());
                    }
                }
            }
            finally {
                db.Close();
            }

            return loan_id;
        }

        public decimal getLoanPrincipal(String loanid)
        {
            decimal principalAmount = 0;
            string sql = "SELECT `principal_amount` FROM tbl_loanlog WHERE loanlog_id = '" + loanid + "'  LIMIT 1";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
            db.Open();
           
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {

                        principalAmount = decimal.Parse(read["principal_amount"].ToString());
                    }
                }
            }
            finally
            {
                db.Close();
            }

            return principalAmount;
        }

        public decimal getPendingAmount(String cusID, String loan_id) {


            decimal returnee = 0;
            decimal loanedAmt = 0;
            decimal paid = 0;
            MySqlConnection db = new MySqlConnection(connString);
            string sql = "SELECT `total_amount` FROM tbl_loanlog WHERE mem_id = '" + cusID + "' AND `ispaid` = '0' AND loanlog_id = '" + loan_id + "'  LIMIT 1";
            string sql2 = "SELECT SUM(amount_paid) as rw FROM tbl_loanpayment WHERE mem_id = '" + cusID + "' AND loanlog_id = '" + loan_id + "' ";

            try
            {
            db.Open();
       
                //Loaned Amt
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {

                        loanedAmt = decimal.Parse(read["total_amount"].ToString());
                    }
                }
                //

                //Total amount paid
                MySqlCommand mySqlComm2 = new MySqlCommand(sql2, db);
                using (MySqlDataReader read2 = mySqlComm2.ExecuteReader())
                {
                        while (read2.Read())
                        {
                            try {
                                paid = decimal.Parse(read2["rw"].ToString());
                            }catch{}
                            
                        }
                }
                //
            }
            finally {
                db.Close();
            }
            returnee = loanedAmt - paid;
            return returnee;

        }

        public long newLoanPayment(String cusId, decimal priamount, decimal topay, DateTime processdate, String empID, String loanid, bool lastPayment ) {
            long loan_payment_id = 0;
            long tempORNum = 0;
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlCommand mySqlComm2 = new MySqlCommand();

            MySqlCommand mySqlComm3 = new MySqlCommand();
            MySqlCommand mySqlComm4 = new MySqlCommand();


            MySqlCommand mySqlComm5 = new MySqlCommand();
            MySqlTransaction trans = null;

            try
            {

            db.Open();
            trans = db.BeginTransaction();

            mySqlComm2.CommandText = @"INSERT INTO tbl_ornumber(`nothing`) VALUES ('')";
            mySqlComm2.Connection = db;
            mySqlComm2.Transaction = trans;
            mySqlComm2.ExecuteNonQuery();
            tempORNum = mySqlComm2.LastInsertedId;

            mySqlComm.CommandText = @"INSERT INTO tbl_loanpayment (`mem_id`, `principal_amount`, `amount_paid`, `emp_id`, `loanlog_id`, `or_num`) VALUES ('" + cusId + "', '" + priamount + "', '" + topay + "', '" + empID + "', '" + loanid + "', '" + tempORNum + "')";
            mySqlComm.Connection = db;
            mySqlComm.Transaction = trans;
            mySqlComm.ExecuteNonQuery();
            loan_payment_id = mySqlComm.LastInsertedId;


                if (lastPayment) {
                    mySqlComm3.CommandText = @"UPDATE tbl_loanlog SET `ispaid` = '1' WHERE `loanlog_id` = '" + loanid + "' AND `mem_id` = '" + cusId + "' ";
                    mySqlComm3.Connection = db;
                    mySqlComm3.Transaction = trans;
                    mySqlComm3.ExecuteNonQuery();

                    mySqlComm4.CommandText = @"UPDATE tbl_currsavings as c SET `current_ShareCapital` =  
                                               `current_ShareCapital`+ (SELECT `shcap_amt` FROM tbl_feesharecapital as s WHERE s.loanlog_id = '"+loanid+"') WHERE c.mem_id = '"+cusId+"' ";
                    mySqlComm4.Connection = db;
                    mySqlComm4.Transaction = trans;
                    mySqlComm4.ExecuteNonQuery();       

                }

                mySqlComm5.CommandText = @"INSERT INTO tbl_audit_trail (`aud_module`, `aud_action`, `emp_id`) VALUES ('Loans','Loan Payment','" + empID + "') ";
                mySqlComm5.Connection = db;
                mySqlComm5.Transaction = trans;
                mySqlComm5.ExecuteNonQuery();
                trans.Commit();
            }
            catch(Exception xx)
            {
                MessageBox.Show(xx.ToString());
                trans.Rollback();
            }
            finally
            {
                db.Close();
            }

            return tempORNum;
        }

        public void getPaymentDetails(DataGridView view, String cusId, String loanID) {

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
            db.Open();
            view.Rows.Clear();
            

                string sql = "SELECT lt.date_paid, lg.principal_amount, lg.term_loan,lg.term_duration ,lg.rate_interest, lt.amount_paid, u.user_fullname FROM tbl_loanlog as lg JOIN tbl_loanpayment as lt ON lg.loanlog_id = lt.loanlog_id JOIN tbl_user as u ON u.user_id = lt.emp_id WHERE lg.loanlog_id = '" + loanID + "' AND lg.mem_id = '" + cusId + "' ORDER BY  lt.date_paid DESC ";
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);

                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    String term = "";
                    int a = 1;
                    while (read.Read())
                    {
                        switch (read.GetValue(2).ToString())
                        {
                            case "0":
                                term = "Monthly";
                                break;
                            case "1":
                                term = "Quarterly";
                                break;
                            case "2":
                                term = "Semi Annually";
                                break;
                            case "3":
                                term = "Annually";
                                break;
                        }

                        DateTime time = DateTime.Parse(read.GetValue(0).ToString());
                        decimal initial = decimal.Parse(read.GetValue(1).ToString());
                        decimal paid = decimal.Parse(read.GetValue(5).ToString());
                        view.Rows.Add(new object[] { 
                        a++.ToString(),time.ToString("MM/dd/yyyy hh:mm:ss tt"),initial.ToString("N"),term,read.GetValue(3), read.GetValue(4).ToString() + " %", paid.ToString("N"), read.GetValue(6)
                        });
                    }
                }
            }
            catch
            {
            }
            finally
            {
                db.Close();
            }


        
        }

        public int moneyCounterStart(String empID, String date, int oneK, int fiveH, int twoH, int oneH, int fift, int twenty, int ten, int five, int one, double startOfDayTotal)
        {
            string sql = "INSERT INTO tbl_moneycounter(`emp_id`, `date_saved`, `thousand`, `fivehundred`, `twohundred`, `onehundred`, `fifty`, `twenty`, `ten`, `five`, `one`, `tot_startday`) VALUES ('"+empID+"', '"+date+"', '"+oneK+"', '"+fiveH+"', '"+twoH+"', '"+oneH+"', '"+fift+"', '"+twenty+"', '"+ten+"', '"+five+"', '"+one+"', '"+startOfDayTotal+"' )";
            int stat = 0;

            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;
            try
            {
                db.Open();

                trans = db.BeginTransaction();
                mySqlComm.CommandText = sql;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                stat = mySqlComm.ExecuteNonQuery();

                trans.Commit();
            }
            catch
            {
                trans.Rollback();

            }
            finally
            {
                db.Close();
            }
            return stat;
        }

        public int moneyCounterEnd(String empID, String date, int oneK, int fiveH, int twoH, int oneH, int fift, int twenty, int ten, int five, int one, double endOfDayTotal, double totalDiff)
        {
            string sql = "UPDATE tbl_moneycounter SET `ed_onetho` = '" + oneK + "', `ed_fivehundred` = '" + fiveH + "', `ed_twohundred` = '" + twoH + "', `ed_onehundred` = '" + oneH + "', `ed_fifty` = '" + fift + "', `ed_twenty` = '" + twenty + "', `ed_ten` = '" + ten + "', `ed_five` = '" + five + "', `ed_one` = '" + one + "', `tot_endday` = '" + endOfDayTotal + "', `tot_diff` = '" + totalDiff + "' WHERE `date_saved` = '"+date+"' ";
            int stat = 0;

            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;
            try
            {
                db.Open();

                trans = db.BeginTransaction();
                mySqlComm.CommandText = sql;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                stat = mySqlComm.ExecuteNonQuery();

                trans.Commit();
            }
            catch
            {
                trans.Rollback();

            }
            finally
            {
                db.Close();
            }
            
            return stat;
        }

        public bool checkTodayMoneyCounterIfTheresStart(String todayDate, TextBox ok, TextBox fh, TextBox twh, TextBox oh, TextBox fif, TextBox twen, TextBox ten, TextBox fiv, TextBox one, TextBox startDaytot) {
            string sql = "SELECT `thousand`, `fivehundred`, `twohundred`, `onehundred`, `fifty`, `twenty`, `ten`, `five`, `one`, `tot_startday` FROM tbl_moneycounter WHERE `date_saved` = '"+todayDate+"' LIMIT 1";
            bool ewan = false;
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (read.HasRows)
                    {
                        ewan = true;
                    }
                    while (read.Read())
                    {
                        ok.Text = read.GetValue(0).ToString();
                        fh.Text = read.GetValue(1).ToString();
                        twh.Text = read.GetValue(2).ToString();
                        oh.Text = read.GetValue(3).ToString();
                        fif.Text = read.GetValue(4).ToString();
                        twen.Text = read.GetValue(5).ToString();
                        ten.Text = read.GetValue(6).ToString();
                        fiv.Text = read.GetValue(7).ToString();
                        one.Text = read.GetValue(8).ToString();
                        startDaytot.Text = read.GetValue(9).ToString();
                        startDaytot.Tag = read.GetValue(9).ToString();
                    }
                }
            }
            finally
            {
                db.Close();
            }
            return ewan;
        }

        public bool checkTodayMoneyCounterIfTheresEnd(String todayDate, TextBox ok, TextBox fh, TextBox twh, TextBox oh, TextBox fif, TextBox twen, TextBox ten, TextBox fiv, TextBox one, TextBox endDaytot)
        {
            string sql = "SELECT `ed_onetho`, `ed_fivehundred`, `ed_twohundred`, `ed_onehundred`, `ed_fifty`, `ed_twenty`, `ed_ten`, `ed_five`, `ed_one`, `tot_endday` FROM tbl_moneycounter WHERE `date_saved` = '" + todayDate + "' LIMIT 1";
            bool ewan = false;
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (read.HasRows)
                    {
                        ewan = true;
                    }
                    while (read.Read())
                    {
                        ok.Text = read.GetValue(0).ToString();
                        fh.Text = read.GetValue(1).ToString();
                        twh.Text = read.GetValue(2).ToString();
                        oh.Text = read.GetValue(3).ToString();
                        fif.Text = read.GetValue(4).ToString();
                        twen.Text = read.GetValue(5).ToString();
                        ten.Text = read.GetValue(6).ToString();
                        fiv.Text = read.GetValue(7).ToString();
                        one.Text = read.GetValue(8).ToString();
                        endDaytot.Text = read.GetValue(9).ToString();
                        endDaytot.Tag = read.GetValue(9).ToString();
                        decimal tot = decimal.Parse(read.GetValue(9).ToString());
                        if(tot <= 0){
                            ewan = false;
                        }
                    }
                }
            }
            finally
            {
                db.Close();
            }
            
            return ewan;
        }

        public void getALLTransactions(System.Windows.Forms.DataGridView view, String memID, bool rangebetween, DateTime start, DateTime end)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");

            string sql = "";

            if (!rangebetween && memID != "0")
            {
                sql = @"SELECT t.process_date, 'Deposit' as col, t.deposit, u.user_fullname,'' as col2, t.or_num FROM tbl_deposit as t JOIN tbl_user as u ON t.process_by = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id WHERE t.customer_id = '" + memID + "' ";
                sql += " UNION ";
                sql += "SELECT l.process_date, 'Loan Money' as col, l.principal_amount, u.user_fullname, l.notes, l.or_num FROM tbl_loanlog as l JOIN tbl_user as u ON l.emp_id = u.user_id  WHERE l.mem_id = '" + memID + "' ";
                sql += " UNION ";
                sql += "SELECT lp.date_paid, 'Loan Payment' as col, lp.amount_paid, u.user_fullname, ll.notes, lp.or_num FROM tbl_loanpayment as lp JOIN tbl_loanlog as ll ON ll.loanlog_id = lp.loanlog_id JOIN tbl_user as u ON lp.emp_id = u.user_id  WHERE lp.mem_id = '" + memID + "' ";
                sql +=  " UNION ";
                sql += "SELECT t.purchase_date,'Puchases' as col, t.total_purchased,u.user_fullname,concat(t.total_qty, ' items'), t.or_number FROM tbl_transactionlog as t JOIN tbl_user as u ON u.user_id = t.emp_id WHERE t.customer_id = '" + memID + "' ";
                sql += " UNION ";
                sql += "SELECT w.process_date, 'Withdraw' as col, w.withdraw, u.user_fullname,'' as col2, w.or_num FROM tbl_withdraw as w JOIN tbl_user as u ON w.process_by = u.user_id JOIN tbl_members as m ON w.customer_id = m.mem_id WHERE w.customer_id = '" + memID + "' ";
                sql +=   " ORDER BY process_date DESC";

            }
            else if(rangebetween && memID != "0"){

                sql = @"SELECT t.process_date, 'Deposit' as col, t.deposit, u.user_fullname,'' as col2, t.or_num FROM tbl_deposit as t JOIN tbl_user as u ON t.process_by = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id WHERE t.customer_id = '" + memID + "' AND t.process_date BETWEEN '" + startDate + "' AND '" + endDate + "' ";
                sql += " UNION ";
                sql += "SELECT l.process_date, 'Loan Money' as col, l.principal_amount, u.user_fullname, l.notes, l.or_num FROM tbl_loanlog as l JOIN tbl_user as u ON l.emp_id = u.user_id  WHERE l.mem_id = '" + memID + "' AND l.process_date BETWEEN '" + startDate + "' AND '" + endDate + "'  ";
                sql += " UNION ";
                sql += "SELECT lp.date_paid, 'Loan Payment' as col, lp.amount_paid, u.user_fullname, ll.notes, lp.or_num FROM tbl_loanpayment as lp JOIN tbl_loanlog as ll ON ll.loanlog_id = lp.loanlog_id JOIN tbl_user as u ON lp.emp_id = u.user_id  WHERE lp.mem_id = '" + memID + "' AND lp.date_paid BETWEEN '" + startDate + "' AND '" + endDate + "' ";
                sql += " UNION ";
                sql += "SELECT t.purchase_date,'Puchases' as col, t.total_purchased,u.user_fullname,concat(t.total_qty, ' items'), t.or_number FROM tbl_transactionlog as t JOIN tbl_user as u ON u.user_id = t.emp_id WHERE t.customer_id = '" + memID + "' AND t.purchase_date BETWEEN '" + startDate + "' AND '" + endDate + "' ";
                sql += " UNION ";
                sql += "SELECT w.process_date, 'Withdraw' as col, w.withdraw, u.user_fullname,'' as col2, w.or_num FROM tbl_withdraw as w JOIN tbl_user as u ON w.process_by = u.user_id JOIN tbl_members as m ON w.customer_id = m.mem_id WHERE w.customer_id = '" + memID + "' AND w.process_date BETWEEN '" + startDate + "' AND '" + endDate + "'  ";
                sql += " ORDER BY process_date DESC";

            }
            else if(!rangebetween && memID == "0"){
                sql = @"SELECT t.process_date, 'Deposit' as col, t.deposit, u.user_fullname,'' as col2, t.or_num FROM tbl_deposit as t JOIN tbl_user as u ON t.process_by = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id ";
                sql += " UNION ";
                sql += "SELECT l.process_date, 'Loan Money' as col, l.principal_amount, u.user_fullname, l.notes, l.or_num FROM tbl_loanlog as l JOIN tbl_user as u ON l.emp_id = u.user_id ";
                sql += " UNION ";
                sql += "SELECT lp.date_paid, 'Loan Payment' as col, lp.amount_paid, u.user_fullname, ll.notes, lp.or_num FROM tbl_loanpayment as lp JOIN tbl_loanlog as ll ON ll.loanlog_id = lp.loanlog_id JOIN tbl_user as u ON lp.emp_id = u.user_id ";
                sql += " UNION ";
                sql += "SELECT t.purchase_date,'Puchases' as col, t.total_purchased,u.user_fullname,concat(t.total_qty, ' items'), t.or_number FROM tbl_transactionlog as t JOIN tbl_user as u ON u.user_id = t.emp_id ";
                sql += " UNION ";
                sql += "SELECT w.process_date, 'Withdraw' as col, w.withdraw, u.user_fullname,'' as col2, w.or_num FROM tbl_withdraw as w JOIN tbl_user as u ON w.process_by = u.user_id JOIN tbl_members as m ON w.customer_id = m.mem_id ";
                sql += " ORDER BY process_date DESC";

            }
            else if(rangebetween && memID == "0"){
                sql = @"SELECT t.process_date, 'Deposit' as col, t.deposit, u.user_fullname,'' as col2, t.or_num FROM tbl_deposit as t JOIN tbl_user as u ON t.process_by = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id WHERE t.process_date BETWEEN '" + startDate + "' AND '" + endDate + "' ";
                sql += " UNION ";
                sql += "SELECT l.process_date, 'Loan Money' as col, l.principal_amount, u.user_fullname, l.notes, l.or_num FROM tbl_loanlog as l JOIN tbl_user as u ON l.emp_id = u.user_id  WHERE  l.process_date BETWEEN '" + startDate + "' AND '" + endDate + "'  ";
                sql += " UNION ";
                sql += "SELECT lp.date_paid, 'Loan Payment' as col, lp.amount_paid, u.user_fullname, ll.notes, lp.or_num FROM tbl_loanpayment as lp JOIN tbl_loanlog as ll ON ll.loanlog_id = lp.loanlog_id JOIN tbl_user as u ON lp.emp_id = u.user_id  WHERE  lp.date_paid BETWEEN '" + startDate + "' AND '" + endDate + "' ";
                sql += " UNION ";
                sql += "SELECT t.purchase_date,'Puchases' as col, t.total_purchased,u.user_fullname,concat(t.total_qty, ' items'), t.or_number FROM tbl_transactionlog as t JOIN tbl_user as u ON u.user_id = t.emp_id WHERE  t.purchase_date BETWEEN '" + startDate + "' AND '" + endDate + "' ";
                sql += " UNION ";
                sql += "SELECT w.process_date, 'Withdraw' as col, w.withdraw, u.user_fullname,'' as col2, w.or_num FROM tbl_withdraw as w JOIN tbl_user as u ON w.process_by = u.user_id JOIN tbl_members as m ON w.customer_id = m.mem_id WHERE w.process_date BETWEEN '" + startDate + "' AND '" + endDate + "'  ";
                sql += " ORDER BY process_date DESC";
                
            }
            int no = 1;
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);

                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "OR No.");
                        view.Columns.Add("c2", "Date");
                        view.Columns.Add("c3", "Type");
                        view.Columns.Add("c4", "Amount");
                        view.Columns.Add("c5", "Received by");

                        view.Columns.Add("c66", "Details");
                    }
                    while (read.Read())
                    {
                        DateTime date = DateTime.Parse(read.GetValue(0).ToString());
                        decimal amt = decimal.Parse(read.GetValue(2).ToString());
                        view.Rows.Add(new object[] { read.GetValue(5).ToString(), date.ToString("MM/dd/yyyy hh:mm:ss tt"), read.GetValue(1), amt.ToString("N"), read.GetValue(3), read.GetValue(4) });
                        no++;
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void getDepositsOFMember(System.Windows.Forms.DataGridView view, String memID, bool rangeparam, DateTime start, DateTime end)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");

            view.Rows.Clear();
            string sql = "";
            if (rangeparam)
            {
                sql = "SELECT t.process_date, 'Deposit' as col, t.deposit, u.user_fullname FROM tbl_deposit as t JOIN tbl_user as u ON t.process_by = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id WHERE t.customer_id = '" + memID + "' AND t.process_date BETWEEN '" + startDate + "' AND '" + endDate + "' ";

            }
            else {
                sql = "SELECT t.process_date, 'Deposit' as col, t.deposit, u.user_fullname FROM tbl_deposit as t JOIN tbl_user as u ON t.process_by = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id WHERE t.customer_id = '" + memID + "' ";
          
            }
            view.Columns.Clear();
            int no = 1;
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "No.");
                        view.Columns.Add("c2", "Date");
                        view.Columns.Add("c3", "Type");
                        view.Columns.Add("c4", "Amount");
                        view.Columns.Add("c5", "Received by");

                        view.Columns.Add("c66", "Details");
                    }
                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        no++.ToString(),read.GetValue(0),read.GetValue(1),read.GetValue(2),read.GetValue(3), ""
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void getAllMembersLoan(String memID, TextBox tes)
        {
            string sql = "SELECT l.process_date, 'Loan Money' as col, l.principal_amount, u.user_fullname, l.notes FROM tbl_loanlog as l JOIN tbl_user as u ON l.emp_id = u.user_id WHERE mem_id = '" + memID + "' ORDER BY l.process_date DESC LIMIT 3";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        DateTime detp =  DateTime.Parse(read.GetValue(0).ToString());
                        tes.AppendText("\r\n Loaned " + read.GetValue(2).ToString() + " @ " + detp.ToString("MM/dd/yyyy"));
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void getLoanMoneyOFMember(System.Windows.Forms.DataGridView view, String memID, bool rangebetween, DateTime start, DateTime end)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=coopdb.sqlite; Version=3; datetimeformat=CurrentCulture");
            conn.Open();

            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");


            view.Rows.Clear();
            view.Columns.Clear();
            int no = 1;

            //loan
            string sql = "";
            if(!rangebetween && memID != "0"){
                sql = "SELECT l.process_date, 'Loan Money' as col, l.principal_amount, u.user_fullname, l.notes, l.loanlog_id FROM tbl_loanlog as l JOIN tbl_user as u ON l.emp_id = u.user_id WHERE mem_id = '" + memID + "' UNION SELECT lp.date_paid, 'Loan Payment' as col, lp.amount_paid, u.user_fullname, ll.notes, ll.loanlog_id FROM tbl_loanpayment as lp JOIN tbl_loanlog as ll ON ll.loanlog_id = lp.loanlog_id JOIN tbl_user as u ON lp.emp_id = u.user_id WHERE lp.mem_id  = '" + memID + "' ";
            }
            else if (rangebetween && memID != "0")
            {
                sql = "SELECT l.process_date, 'Loan Money' as col, l.principal_amount, u.user_fullname, l.notes, l.loanlog_id FROM tbl_loanlog as l JOIN tbl_user as u ON l.emp_id = u.user_id WHERE mem_id = '" + memID + "' AND l.process_date BETWEEN '" + startDate + "' AND '" + endDate + "' UNION SELECT lp.date_paid, 'Loan Payment' as col, lp.amount_paid, u.user_fullname, ll.notes, ll.loanlog_id  FROM tbl_loanpayment as lp JOIN tbl_loanlog as ll ON ll.loanlog_id = lp.loanlog_id JOIN tbl_user as u ON lp.emp_id = u.user_id WHERE lp.mem_id  = '" + memID + "' ANd lp.date_paid BETWEEN '" + startDate + "' AND '" + endDate + "'  ";
            }
            else if(!rangebetween && memID == "0"){
                sql = "SELECT l.process_date, 'Loan Money' as col, l.principal_amount, u.user_fullname, l.notes, l.loanlog_id FROM tbl_loanlog as l JOIN tbl_user as u ON l.emp_id = u.user_id UNION SELECT lp.date_paid, 'Loan Payment' as col, lp.amount_paid, u.user_fullname, ll.notes, ll.loanlog_id  FROM tbl_loanpayment as lp JOIN tbl_loanlog as ll ON ll.loanlog_id = lp.loanlog_id JOIN tbl_user as u ON lp.emp_id = u.user_id ";
            }
            else if (rangebetween && memID == "0")
            {
                sql = "SELECT l.process_date, 'Loan Money' as col, l.principal_amount, u.user_fullname, l.notes, l.loanlog_id FROM tbl_loanlog as l JOIN tbl_user as u ON l.emp_id = u.user_id WHERE l.process_date BETWEEN '" + startDate + "' AND '" + endDate + "' UNION SELECT lp.date_paid, 'Loan Payment' as col, lp.amount_paid, u.user_fullname, ll.notes, ll.loanlog_id  FROM tbl_loanpayment as lp JOIN tbl_loanlog as ll ON ll.loanlog_id = lp.loanlog_id JOIN tbl_user as u ON lp.emp_id = u.user_id WHERE lp.date_paid BETWEEN '" + startDate + "' AND '" + endDate + "'  ";
            }


            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Loan No.");
                        view.Columns.Add("c2", "Date");
                        view.Columns.Add("c3", "Type");
                        view.Columns.Add("c4", "Amount");
                        view.Columns.Add("c5", "Received by");

                        view.Columns.Add("c66", "Details");
                    }
                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        read.GetValue(5).ToString(),read.GetValue(0).ToString(),read.GetValue(1),read.GetValue(2),read.GetValue(3), read.GetValue(4)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void getALLPurchaseOfMember(System.Windows.Forms.DataGridView view, String memID, bool rangebtween, DateTime start, DateTime end)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");


            view.Rows.Clear();
            view.Columns.Clear();

            string sql = "";
            if (!rangebtween && memID != "0") {
                sql = "SELECT t.purchase_date, t.total_purchased,u.user_fullname,t.translog_id,t.or_number, t.total_qty FROM tbl_transactionlog as t JOIN tbl_user as u ON u.user_id = t.emp_id WHERE  t.customer_id = '" + memID + "' ORDER BY t.or_number DESC ";
            }
            else if (rangebtween && memID != "0")
            {
                sql = "SELECT t.purchase_date, t.total_purchased,u.user_fullname,t.translog_id,t.or_number, t.total_qty FROM tbl_transactionlog as t JOIN tbl_user as u ON u.user_id = t.emp_id WHERE  t.customer_id = '" + memID + "' AND t.purchase_date BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY t.or_number DESC ";
            }
            else if(!rangebtween && memID == "0"){
                sql = "SELECT t.purchase_date, t.total_purchased,u.user_fullname,t.translog_id,t.or_number, t.total_qty FROM tbl_transactionlog as t JOIN tbl_user as u ON u.user_id = t.emp_id ORDER BY t.or_number DESC ";
            }
            else if (rangebtween && memID == "0")
            {
                sql = "SELECT t.purchase_date, t.total_purchased,u.user_fullname,t.translog_id,t.or_number, t.total_qty FROM tbl_transactionlog as t JOIN tbl_user as u ON u.user_id = t.emp_id WHERE t.purchase_date BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY t.or_number DESC ";
            }

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c13", "OR No.");
                        view.Columns.Add("c2", "Date");
                        view.Columns.Add("c3", "No. of Items");
                        view.Columns.Add("c4", "Amount");
                        view.Columns.Add("c5", "Processed by");

                        view.Columns.Add("c66", "Details");
                    }

                    while (read.Read())
                    {
                        decimal amt = decimal.Parse(read.GetValue(1).ToString());
                        view.Rows.Add(new object[] { 
                        read.GetValue(4).ToString(),read.GetValue(0),read.GetValue(5) + " items",amt.ToString("N"),read.GetValue(2),"None"
                         });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void getAllProductsReceivedFORREPORT(System.Windows.Forms.DataGridView view)
        {
            view.Rows.Clear();
            string sql = @"SELECT  'IN' as col, sr.stock_itemname, i.net_weight, i.unit_measurement, i.item_code,i.quantity,  'RECEIVED' as col2, r.stock_deldate FROM tbl_stockreceive as r JOIN tbl_stockrcitems as sr ON r.stock_receiveid = sr.stock_receivedid JOIN tbl_items as i ON i.item_id = sr.stock_itemid
                            UNION
                            SELECT  'OUT' as col, sr.stock_itemname, i.net_weight, i.unit_measurement, i.item_code,i.quantity,  'RETURN' as col2, r.stock_retdate FROM tbl_stockreturn as r JOIN tbl_stockrtitems as sr ON r.stock_returnid = sr.stock_returnid JOIN tbl_items as i ON i.item_id = sr.stock_itemid";
       
            int no = 1;

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        String detp = read.GetValue(7).ToString();
                        view.Rows.Add(new object[] { 
                        no.ToString(), detp,read.GetValue(0), read.GetValue(1),read.GetValue(2),read.GetValue(3),read.GetValue(4),read.GetValue(5),read.GetValue(5),read.GetValue(6)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void getAllProductsReceivedFORREPORTBETWEEN(System.Windows.Forms.DataGridView view, String start, String end)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=coopdb.sqlite; Version=3; datetimeformat=CurrentCulture");
            conn.Open();

            view.Rows.Clear();

            string sql = @"SELECT  'IN' as col, sr.stock_itemname, i.net_weight, i.unit_measurement, i.item_code,i.quantity,  'RECEIVED' as col2, r.stock_deldate FROM tbl_stockreceive as r JOIN tbl_stockrcitems as sr ON r.stock_receiveid = sr.stock_receivedid JOIN tbl_items as i ON i.item_id = sr.stock_itemid 
                            WHERE r.stock_deldate BETWEEN '" + start + "' AND '" + end + "' UNION SELECT  'OUT' as col, sr.stock_itemname, i.net_weight, i.unit_measurement, i.item_code,i.quantity,  'RETURN' as col2, r.stock_retdate FROM tbl_stockreturn as r JOIN tbl_stockrtitems as sr ON r.stock_returnid = sr.stock_returnid JOIN tbl_items as i ON i.item_id = sr.stock_itemid WHERE  r.stock_retdate BETWEEN '" + start + "' AND '" + end + "'";
            int no = 1;

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        String detp = read.GetValue(7).ToString();
                        view.Rows.Add(new object[] { 
                        no.ToString(), detp,read.GetValue(0), read.GetValue(1),read.GetValue(2),read.GetValue(3),read.GetValue(4),read.GetValue(5),read.GetValue(5),read.GetValue(6)
                        });

                        no++;
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }
       
        public void getEndOfDay(System.Windows.Forms.DataGridView view, DateTime today)
        {
            String todaSt = today.ToString("yyyy-MM-dd");
            today = today.AddDays(1);
            String todaEnd = today.ToString("yyyy-MM-dd");
            int no = 1;
            view.Rows.Clear();
            string sql = "SELECT t.total_amt, '1' as col, t.item_qty_bought,tl.purchase_date,tl.void, tl.or_number  FROM tbl_transactions as t JOIN tbl_transactionlog as tl ON tl.translog_id = t.translog_id WHERE tl.purchase_date BETWEEN '"+todaSt+"' AND '"+todaEnd+"'";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        DateTime time = DateTime.Parse(read.GetValue(3).ToString());
                        if (read.GetValue(4).ToString() == "0")
                        {
                            decimal amt = Decimal.Parse(read.GetValue(0).ToString());
                            view.Rows.Add(new object[] { 
                            no.ToString(),time.ToShortTimeString(), amt.ToString("N"), read.GetValue(1),read.GetValue(2),"0"
                            });

                        }
                        else if (read.GetValue(4).ToString() == "1")
                        {
                            decimal amt = Decimal.Parse(read.GetValue(0).ToString());
                            view.Rows.Add(new object[] { 
                            no.ToString(),time.ToShortTimeString(), "0", read.GetValue(1),read.GetValue(2),amt.ToString("N")
                            });
                        }

                        no++;
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void getEndOfWeek(System.Windows.Forms.DataGridView view, DateTime today, DateTime toend)
        {
            String todaSt = today.ToString("yyyy-MM-dd");
            toend = toend.AddDays(1);
            String todaEnd = toend.ToString("yyyy-MM-dd");
            int no = 1;
            view.Rows.Clear();
            string sql = "SELECT t.total_amt, '1' as col, t.item_qty_bought,tl.purchase_date,tl.void  FROM tbl_transactions as t JOIN tbl_transactionlog as tl ON tl.translog_id = t.translog_id WHERE tl.purchase_date BETWEEN '" + todaSt + "' AND '" + todaEnd + "'";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        DateTime time = DateTime.Parse(read.GetValue(3).ToString());
                        if (read.GetValue(4).ToString() == "0")
                        {
                            decimal amt = Decimal.Parse(read.GetValue(0).ToString());
                            view.Rows.Add(new object[] { 
                            no.ToString(),time.ToString(), amt.ToString("N"), read.GetValue(1),read.GetValue(2),"0"
                            });

                        }
                        else if (read.GetValue(4).ToString() == "1")
                        {
                            decimal amt = Decimal.Parse(read.GetValue(0).ToString());
                            view.Rows.Add(new object[] { 
                            no.ToString(),time.ToString(), "0", read.GetValue(1),read.GetValue(2),amt.ToString("N")
                            });
                        }

                        no++;
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void insertAuditTrail(String empID, String module, String action, String date) {

            string sql = "INSERT INTO tbl_audit_trail (`aud_module`, `aud_action`, `emp_id`) VALUES ('" + module + "','" + action + "','" + empID + "') ";
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;
            int stat = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();
                mySqlComm.CommandText = sql;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                stat = mySqlComm.ExecuteNonQuery();

                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }
        
        }

        public void getAuditTrail(System.Windows.Forms.DataGridView view,bool paramenabled, DateTime today, DateTime toend,bool issearch ,String empname)
        {
            String todaSt = today.ToString("yyyy-MM-dd");
            toend = toend.AddDays(1);
            String todaEnd = toend.ToString("yyyy-MM-dd");
            int no = 1;
            view.Rows.Clear();
            string sql = "";
            if (paramenabled && !issearch)
            {
                sql = "SELECT a.aud_date, u.user_fullname, a.aud_module, a.aud_action FROM tbl_audit_trail as a JOIN tbl_user as u ON a.emp_id = u.user_id WHERE a.aud_date BETWEEN '" + todaSt + "' AND '" + todaEnd + "' ORDER BY a.aud_date DESC ";
            }
            else if(paramenabled && issearch){
                sql = "SELECT a.aud_date, u.user_fullname, a.aud_module, a.aud_action FROM tbl_audit_trail as a JOIN tbl_user as u ON a.emp_id = u.user_id WHERE u.user_fullname  LIKE '%" + empname + "%' AND a.aud_date BETWEEN '" + todaSt + "' AND '" + todaEnd + "' ORDER BY a.aud_date DESC  ";
            }
            else if (!paramenabled && issearch)
            {
                sql = "SELECT a.aud_date, u.user_fullname, a.aud_module, a.aud_action FROM tbl_audit_trail as a JOIN tbl_user as u ON a.emp_id = u.user_id WHERE  u.user_fullname  LIKE '%" + empname + "%'  ORDER BY a.aud_date DESC  ";
            }
            else {

                sql = "SELECT a.aud_date, u.user_fullname, a.aud_module, a.aud_action FROM tbl_audit_trail as a JOIN tbl_user as u ON a.emp_id = u.user_id ORDER BY a.aud_date DESC ";
            }

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        DateTime time = DateTime.Parse(read.GetValue(0).ToString());
                        view.Rows.Add(new object[] { 
                        no++.ToString(),time.ToShortDateString(),time.ToShortTimeString(), read.GetValue(1), read.GetValue(2),read.GetValue(3)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void searchUserEmployeeAuditTrail(String search, System.Windows.Forms.ListBox box, List<String> lst)
        {
            String sql = "SELECT `user_id`, `user_fullname` FROM tbl_user WHERE `user_fullname` LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' OR `username` LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' ";
            box.Items.Clear();

            lst.Clear();

            bool che = false;

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (!read.HasRows)
                    {
                        che = true;
                    }

                    while (read.Read())
                    {
                        lst.Add(read.GetValue(0).ToString());
                        box.Items.Add(read.GetValue(1).ToString());
                    }
                }
            }
            finally
            {
                db.Close();
            }



            if (che)
            {
                box.Visible = false;
            }
            else
            {
                box.SelectedIndex = 0;
                box.Visible = true;
            }

        }
       
        public void salesByAllCustSumm(DataGridView view, bool between, DateTime start, DateTime end) {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");
            int receiptno = 0;
            decimal totalSumAmt = 0;

            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if (between)
            {
                sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, m.mem_fname, m.mem_lname, u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id WHERE t.void = '0' AND t.purchase_date BETWEEN '" + startDate + "' ANd '" + endDate + "' ";
                sql +=@" UNION
                        SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, '' as col, '', u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id
                        WHERE t.void = '0' AND t.customer_id ='0' AND t.purchase_date BETWEEN '" + startDate + "' ANd '" + endDate + "'  ORDER BY purchase_date DESC ";
            }
            else {
                sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, m.mem_fname, m.mem_lname, u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id WHERE t.void = '0'
                        UNION
                        SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, '' as col, '', u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id WHERE t.void = '0' AND t.customer_id ='0'  ORDER BY purchase_date DESC";
            }

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "OR No");
                        view.Columns.Add("c2", "Trans. Date\n mm/dd/yyyy");
                        view.Columns.Add("c3", "No. of Items");
                        view.Columns.Add("c4", "Amount");
                        view.Columns.Add("c5", "Member Name");
                        view.Columns.Add("c25", "Processed by");
                        view.Columns[0].Width = 135;
                        view.Columns[3].Width = 120;
                    }
                    while (read.Read())
                    {
                        receiptno++; //increment the receipt counter

                        String customerName;
                        String totalItem = "0";
                        decimal amt = 0;
                        if (read.GetValue(5).ToString() == "")
                        {
                            customerName = "Non-Member";
                        }
                        else
                        {
                            customerName = read.GetValue(5).ToString() + " " + read.GetValue(6).ToString();
                        }
                        totalItem = read.GetValue(3).ToString() + " items";
                        amt = decimal.Parse(read.GetValue(4).ToString());

                        DateTime pdate = DateTime.Parse(read.GetValue(2).ToString());

                        view.Rows.Add(new object[] { 
                        read.GetValue(0),pdate.ToString("MM/dd/yyyy"),totalItem,amt.ToString("N"),customerName,read.GetValue(7)
                        });

                        totalSumAmt += decimal.Parse(read.GetValue(4).ToString()); //err

                    }
                    if (receiptno > 0)
                    {
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "----", "----", "----", "----", "----", "----" });
                        view.Rows.Add(new object[] { "Total No. Receipt", receiptno.ToString("D4"), "", "Total Collection", totalSumAmt.ToString("N"), "" });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void salesByAllCustSummSearch(DataGridView view, String search)
        {
            int receiptno = 0;
            decimal totalSumAmt = 0;
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, m.mem_fname, m.mem_lname, u.user_fullname  FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id 
                            JOIN tbl_members as m ON t.customer_id = m.mem_id WHERE t.void = '0' AND  m.mem_lname  LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' OR  m.mem_fname  LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' ORDER BY t.purchase_date DESC";
            
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "OR No");
                        view.Columns.Add("c2", "Trans. Date\n mm/dd/yyyy");
                        view.Columns.Add("c3", "No. of Items");
                        view.Columns.Add("c4", "Amount");
                        view.Columns.Add("c5", "Member Name");
                        view.Columns.Add("c25", "Processed by");
                        view.Columns[0].Width = 135;
                        view.Columns[3].Width = 120;

                    }
                    while (read.Read())
                    {
                        receiptno++; //increment the receipt counter

                        String customerName;
                        String totalItem = "0";
                        decimal amt = 0;
                        if (read.GetValue(5).ToString() == "")
                        {
                            customerName = "Non-Member";
                        }
                        else
                        {
                            customerName = read.GetValue(5).ToString() + " " + read.GetValue(6).ToString();
                        }
                        totalItem = read.GetValue(3).ToString() + " items";
                        amt = decimal.Parse(read.GetValue(4).ToString());

                        DateTime pdate = DateTime.Parse(read.GetValue(2).ToString());

                        view.Rows.Add(new object[] { 
                        read.GetValue(0),pdate.ToString("MM/dd/yyyy"),totalItem,amt.ToString("N"),customerName,read.GetValue(7)
                        });

                        totalSumAmt += decimal.Parse(read.GetValue(4).ToString()); //err

                    }
                    if (receiptno > 0)
                    {
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "----", "----", "----", "----", "----", "----" });
                        view.Rows.Add(new object[] { "Total No. Receipt", receiptno.ToString("D4"), "", "Total Collection", totalSumAmt.ToString("N"), "" });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void salesByAllCustSummMemberOnly(DataGridView view, bool between, DateTime start, DateTime end)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");
            int receiptno = 0;
            decimal totalSumAmt = 0;

            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if (between) {
                sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, m.mem_fname, m.mem_lname, u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id 
                        JOIN tbl_members as m ON t.customer_id = m.mem_id  WHERE t.void = '0' AND t.customer_id != '0' AND t.purchase_date BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY t.purchase_date DESC ";

            } else {
                sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, m.mem_fname, m.mem_lname, u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id 
                        JOIN tbl_members as m ON t.customer_id = m.mem_id  WHERE t.void = '0' AND t.customer_id != '0' ORDER BY t.purchase_date DESC  ";
            }

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "OR No");
                        view.Columns.Add("c2", "Trans. Date\n mm/dd/yyyy");
                        view.Columns.Add("c3", "No. of Items");
                        view.Columns.Add("c4", "Amount");
                        view.Columns.Add("c5", "Member Name");
                        view.Columns.Add("c25", "Processed by");
                        view.Columns[0].Width = 135;
                        view.Columns[3].Width = 120;
                    }
                    while (read.Read())
                    {
                        receiptno++; //increment the receipt counter

                        String customerName;
                        String totalItem = "0";
                        decimal amt = 0;
                        if (read.GetValue(5).ToString() == "")
                        {
                            customerName = "Non-Member";
                        }
                        else
                        {
                            customerName = read.GetValue(5).ToString() + " " + read.GetValue(6).ToString();
                        }
                        totalItem = read.GetValue(3).ToString() + " items";
                        amt = decimal.Parse(read.GetValue(4).ToString());

                        view.Rows.Add(new object[] { 
                        read.GetValue(0),read.GetValue(2).ToString(),totalItem,amt.ToString("N"),customerName,read.GetValue(7)
                        });

                        totalSumAmt += decimal.Parse(read.GetValue(4).ToString()); //err

                    }
                    if (receiptno > 0)
                    {
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "----", "----", "----", "----", "----", "----" });
                        view.Rows.Add(new object[] { "Total No. Receipt", receiptno.ToString("D4"), "", "Total Collection", totalSumAmt.ToString("N"), "" });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void salesByAllCustSummNONMemberOnly(DataGridView view, bool between, DateTime start, DateTime end)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=coopdb.sqlite; Version=3; datetimeformat=CurrentCulture");
            conn.Open();
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");
            int receiptno = 0;
            decimal totalSumAmt = 0;

            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if (between)
            {
                sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, '' as c1, '' as c2, u.user_fullname  FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id 
                        WHERE t.void = '0' AND t.customer_id = '0' AND t.purchase_date BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY t.purchase_date DESC";
            }
            else {
                sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, '' as c1, '' as c2, u.user_fullname   FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id
                        WHERE t.void = '0' AND t.customer_id ='0' ORDER BY t.purchase_date DESC ";
            }
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "OR No");
                        view.Columns.Add("c2", "Trans. Date\n mm/dd/yyyy");
                        view.Columns.Add("c3", "No. of Items");
                        view.Columns.Add("c4", "Amount");
                        view.Columns.Add("c5", "Member Name");
                        view.Columns.Add("c25", "Processed by");
                        view.Columns[0].Width = 135;
                        view.Columns[3].Width = 120;
                    }
                    while (read.Read())
                    {
                        receiptno++; //increment the receipt counter

                        String customerName;
                        String totalItem = "0";
                        decimal amt = 0;
                        if (read.GetValue(5).ToString() == "")
                        {
                            customerName = "Non-Member";
                        }
                        else
                        {
                            customerName = read.GetValue(5).ToString() + " " + read.GetValue(6).ToString();
                        }
                        totalItem = read.GetValue(3).ToString() + " items";
                        amt = decimal.Parse(read.GetValue(4).ToString());

                        view.Rows.Add(new object[] { 
                        read.GetValue(0),read.GetValue(2).ToString(),totalItem,amt.ToString("N"),customerName,read.GetValue(7)
                        });

                        totalSumAmt += decimal.Parse(read.GetValue(4).ToString()); //err

                    }
                    if (receiptno > 0)
                    {
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "----", "----", "----", "----", "----", "----" });
                        view.Rows.Add(new object[] { "Total No. Receipt", receiptno.ToString("D4"), "", "Total Collection", totalSumAmt.ToString("N"), "" });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void salesByAllCustSalesWithDetails(DataGridView view, bool between, DateTime start, DateTime end)
        {

            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");
            int receiptno = 0;
            decimal totalSumAmt = 0;

            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if (between)
            {
                sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, m.mem_fname, m.mem_lname, u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id WHERE t.void = '0' AND t.purchase_date BETWEEN '" + startDate + "' ANd '" + endDate + "' ";
                sql += @" UNION
                        SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, '' as col, '', u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id
                        WHERE t.void = '0' AND t.customer_id ='0' AND t.purchase_date BETWEEN '" + startDate + "' ANd '" + endDate + "' ORDER BY purchase_date DESC";
            }
            else
            {
                sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, m.mem_fname, m.mem_lname, u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id WHERE t.void = '0'
                        UNION
                        SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, '' as col, '', u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id WHERE t.void = '0' AND t.customer_id ='0' ORDER BY purchase_date DESC ";
            }

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Font = new System.Drawing.Font("Mobile Sans", 12);
                style.BackColor = System.Drawing.Color.LightGray;


                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "OR No");
                        view.Columns.Add("c2", "Date mm/dd/yyyy");
                        view.Columns.Add("c3", "No. of Items");
                        view.Columns.Add("c4", "Amount");
                        view.Columns.Add("c5", "Member Name");
                        view.Columns.Add("c25", "Processed by");

                        view.Columns.Add("c25", "Expand");
                        view.Columns[0].Width = 135;
                        view.Columns[3].Width = 120;
                    }
                    while (read.Read())
                    {
                        receiptno++; //increment the receipt counter

                        String customerName;
                        String totalItem = "0";
                        decimal amt = 0;
                        if (read.GetValue(5).ToString() == "")
                        {
                            customerName = "Non-Member";
                        }
                        else
                        {
                            customerName = read.GetValue(5).ToString() + " " + read.GetValue(6).ToString();
                        }
                        totalItem = read.GetValue(3).ToString() + " items";
                        amt = decimal.Parse(read.GetValue(4).ToString());

                        string ornum = read.GetValue(0).ToString();
                        DateTime trans = DateTime.Parse(read.GetValue(2).ToString());

                        DataGridViewRow rw = (DataGridViewRow)view.Rows[0].Clone();
                        rw.Cells[0].Value = ornum.ToString();
                        rw.Cells[1].Value = trans.ToString("MM/dd/yyyy hh:mm:ss tt");
                        rw.Cells[2].Value = totalItem;
                        rw.Cells[3].Value = amt.ToString("N");
                        rw.Cells[4].Value = customerName;
                        rw.Cells[5].Value = read.GetValue(7).ToString();
                        rw.Cells[6].Value = "Expand";
                        rw.Cells[6].Style = style;


                        view.Rows.Add(rw);
                        
                        //view.Rows.Add(new object[] { 
                        //read.GetValue(0),read.GetValue(2).ToString(),totalItem,amt.ToString("N"),customerName,read.GetValue(7),"Expand"
                        //});

                        totalSumAmt += decimal.Parse(read.GetValue(4).ToString()); //err

                    }
                    if (receiptno > 0)
                    {
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "----", "----", "----", "----", "----", "----" });
                        view.Rows.Add(new object[] { "Total No. Receipt", receiptno.ToString("D4"), "", "Total Collection", totalSumAmt.ToString("N"), "" });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void salesByAllCustSalesWithDetailsSearch(DataGridView view, String search, bool between, DateTime start, DateTime end)
        {

            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");
            int receiptno = 0;
            decimal totalSumAmt = 0;

            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if (between)
            {
                sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, m.mem_fname, m.mem_lname, u.user_fullname  FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id WHERE t.void = '0' 
                        AND t.purchase_date BETWEEN '" + startDate + "' ANd '" + endDate + "'  AND (m.mem_lname  LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' OR  m.mem_fname  LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' )   ORDER BY purchase_date DESC";
            }
            else
            {
              sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, m.mem_fname, m.mem_lname, u.user_fullname  FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id 
                        WHERE t.void = '0' AND  (m.mem_lname  LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' OR  m.mem_fname  LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%') ORDER BY purchase_date DESC ";
            }


            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Font = new System.Drawing.Font("Mobile Sans", 12);
                style.BackColor = System.Drawing.Color.LightGray;

                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "OR No");
                        view.Columns.Add("c2", "Date\nmm/dd/yyyy");
                        view.Columns.Add("c3", "No. of Items");
                        view.Columns.Add("c4", "Amount");
                        view.Columns.Add("c5", "Member Name");
                        view.Columns.Add("c25", "Processed by");
                        view.Columns.Add("c25", "Expand");


                        view.Columns[0].Width = 135;
                        view.Columns[3].Width = 120;
                    }
                    while (read.Read())
                    {
                        receiptno++; //increment the receipt counter

                        String customerName;
                        String totalItem = "0";
                        decimal amt = 0;
                        if (read.GetValue(5).ToString() == "")
                        {
                            customerName = "Non-Member";
                        }
                        else
                        {
                            customerName = read.GetValue(5).ToString() + " " + read.GetValue(6).ToString();
                        }
                        totalItem = read.GetValue(3).ToString() + " items";
                        amt = decimal.Parse(read.GetValue(4).ToString());

                        string ornum = read.GetValue(0).ToString();
                        DateTime trans = DateTime.Parse(read.GetValue(2).ToString());

                        DataGridViewRow rw = (DataGridViewRow)view.Rows[0].Clone();
                        rw.Cells[0].Value = ornum.ToString();
                        rw.Cells[1].Value = trans.ToString("MM/dd/yyyy hh:mm:ss tt");
                        rw.Cells[2].Value = totalItem;
                        rw.Cells[3].Value = amt.ToString("N");
                        rw.Cells[4].Value = customerName;
                        rw.Cells[5].Value = read.GetValue(7).ToString();
                        rw.Cells[6].Value = "Expand";
                        rw.Cells[6].Style = style;


                        view.Rows.Add(rw);




                        //view.Rows.Add(new object[] { 
                        //read.GetValue(0),read.GetValue(2).ToString(),totalItem,amt.ToString("N"),customerName,read.GetValue(7),"Expand"
                        //});

                        totalSumAmt += decimal.Parse(read.GetValue(4).ToString()); //err

                    }
                    if (receiptno > 0)
                    {
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "----", "----", "----", "----", "----", "----" });
                        view.Rows.Add(new object[] { "Total No. Receipt", receiptno.ToString("D4"), "", "Total Collection", totalSumAmt.ToString("N"), "" });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void salesByAllCustSummMemberOnlyWithDetailsEXPAND(DataGridView view,int index ,String ornumber)
        {
            string sql = "SELECT `item_name`, `item_qty_bought` ,`total_amt` FROM tbl_transactions WHERE translog_id IN (SELECT translog_id FROM tbl_transactionlog WHERE or_number = '" + ornumber + "')";

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new System.Drawing.Font("Mobile Sans", 12);
            style.BackColor = System.Drawing.Color.LightGray;
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        DataGridViewRow rw = (DataGridViewRow)view.Rows[0].Clone();
                        rw.DefaultCellStyle = style;
                        rw.Cells[0].Value = "";
                        rw.Cells[1].Value = "";
                        rw.Cells[2].Value = "";
                        rw.Cells[3].Value = read.GetValue(0);
                        rw.Cells[4].Value = read.GetValue(1) + " items";
                        rw.Cells[5].Value = read.GetValue(2) + " php";
                        view.Rows.Insert(index + 1, rw);
                    }
                    view.Rows.Insert(index + 1, new object[] { "", "", "", "----", "Breakdown", "----" });
                }
            }
            finally
            {
                db.Close();
            }
        }
      
        public void salesByAllCustSalesMemberOnlyWithDetails(DataGridView view, bool between, DateTime start, DateTime end)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");
            int receiptno = 0;
            decimal totalSumAmt = 0;

            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";

            if (between)
            {
                sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, m.mem_fname, m.mem_lname, u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id
                        WHERE t.void = '0' AND t.purchase_date BETWEEN '" + startDate + "' ANd '" + endDate + "' ORDER BY t.purchase_date DESC ";
            }
            else
            {
                sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, m.mem_fname, m.mem_lname, u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id JOIN tbl_members as m ON t.customer_id = m.mem_id
                        WHERE t.void = '0' ORDER BY t.purchase_date DESC ";
            }
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Font = new System.Drawing.Font("Mobile Sans", 12);
                style.BackColor = System.Drawing.Color.LightGray;


                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "OR No");
                        view.Columns.Add("c2", "Date mm/dd/yyyy");
                        view.Columns.Add("c3", "No. of Items");
                        view.Columns.Add("c4", "Amount");
                        view.Columns.Add("c5", "Member Name");
                        view.Columns.Add("c25", "Processed by");
                        view.Columns.Add("c25", "Expand");

                        view.Columns[0].Width = 135;
                        view.Columns[3].Width = 120;
                    }
                    while (read.Read())
                    {
                        receiptno++; //increment the receipt counter

                        String customerName;
                        String totalItem = "0";
                        decimal amt = 0;
                        if (read.GetValue(5).ToString() == "")
                        {
                            customerName = "Non-Member";
                        }
                        else
                        {
                            customerName = read.GetValue(5).ToString() + " " + read.GetValue(6).ToString();
                        }
                        totalItem = read.GetValue(3).ToString() + " items";
                        amt = decimal.Parse(read.GetValue(4).ToString());

                        string ornum = read.GetValue(0).ToString();
                        DateTime trans = DateTime.Parse(read.GetValue(2).ToString());

                        DataGridViewRow rw = (DataGridViewRow)view.Rows[0].Clone();
                        rw.Cells[0].Value = ornum.ToString();
                        rw.Cells[1].Value = trans.ToString("MM/dd/yyyy hh:mm:ss tt");
                        rw.Cells[2].Value = totalItem;
                        rw.Cells[3].Value = amt.ToString("N");
                        rw.Cells[4].Value = customerName;
                        rw.Cells[5].Value = read.GetValue(7).ToString();
                        rw.Cells[6].Value = "Expand";
                        rw.Cells[6].Style = style;


                        view.Rows.Add(rw);


                        //view.Rows.Add(new object[] { 
                        //read.GetValue(0),read.GetValue(2).ToString(),totalItem,amt.ToString("N"),customerName,read.GetValue(7),"Expand"
                        //});

                        totalSumAmt += decimal.Parse(read.GetValue(4).ToString()); //err

                    }
                    if (receiptno > 0)
                    {
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "----", "----", "----", "----", "----", "----" });
                        view.Rows.Add(new object[] { "Total No. Receipt", receiptno.ToString("D4"), "", "Total Collection", totalSumAmt.ToString("N"), "" });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void salesByAllCustSalesNONMemberOnlyWithDetails(DataGridView view, bool between, DateTime start, DateTime end)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");
            int receiptno = 0;
            decimal totalSumAmt = 0;
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if (between)
            {
                sql = "SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, '' as col, '', u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id ";
                sql += " WHERE t.void = '0' AND t.customer_id ='0' AND t.purchase_date BETWEEN '" + startDate + "' ANd '" + endDate + "' ORDER BY t.purchase_date DESC  ";
            }
            else
            {
                sql = @"SELECT t.or_number, t.translog_id,t.purchase_date, t.total_qty, t.total_purchased, '' as col, '', u.user_fullname FROM tbl_transactionlog as t JOIN tbl_user as u ON t.emp_id = u.user_id
                        WHERE t.void = '0' AND t.customer_id ='0' ORDER BY t.purchase_date DESC ";
            }

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Font = new System.Drawing.Font("Mobile Sans", 12);
                style.BackColor = System.Drawing.Color.LightGray;

                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "OR No");
                        view.Columns.Add("c2", "Date\nmm/dd/yyyy");
                        view.Columns.Add("c3", "No. of Items");
                        view.Columns.Add("c4", "Amount");
                        view.Columns.Add("c5", "Member Name");
                        view.Columns.Add("c25", "Processed by");
                        view.Columns.Add("c25", "Expand");

                        view.Columns[0].Width = 135;
                        view.Columns[3].Width = 120;
                    }
                    while (read.Read())
                    {
                        receiptno++; //increment the receipt counter

                        String customerName;
                        String totalItem = "0";
                        decimal amt = 0;
                        if (read.GetValue(5).ToString() == "")
                        {
                            customerName = "Non-Member";
                        }
                        else
                        {
                            customerName = read.GetValue(5).ToString() + " " + read.GetValue(6).ToString();
                        }
                        totalItem = read.GetValue(3).ToString() + " items";
                        amt = decimal.Parse(read.GetValue(4).ToString());




                        string ornum = read.GetValue(0).ToString();
                        DateTime trans = DateTime.Parse(read.GetValue(2).ToString());

                        DataGridViewRow rw = (DataGridViewRow)view.Rows[0].Clone();
                        rw.Cells[0].Value = ornum.ToString();
                        rw.Cells[1].Value = trans.ToString("MM/dd/yyyy hh:mm:ss tt");
                        rw.Cells[2].Value = totalItem;
                        rw.Cells[3].Value = amt.ToString("N");
                        rw.Cells[4].Value = customerName;
                        rw.Cells[5].Value = read.GetValue(7).ToString();
                        rw.Cells[6].Value = "Expand";
                        rw.Cells[6].Style = style;


                        view.Rows.Add(rw);


                        //view.Rows.Add(new object[] { 
                        //read.GetValue(0),read.GetValue(2).ToString(),totalItem,amt.ToString("N"),customerName,read.GetValue(7),"Expand"
                        //});

                        totalSumAmt += decimal.Parse(read.GetValue(4).ToString()); //err

                    }
                    if (receiptno > 0)
                    {
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "", "", "", "", "", "" });
                        view.Rows.Add(new object[] { "----", "----", "----", "----", "----", "----" });
                        view.Rows.Add(new object[] { "Total No. Receipt", receiptno.ToString("D4"), "", "Total Collection", totalSumAmt.ToString("N"), "" });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void salesbyItem(DataGridView view,bool between, DateTime start, DateTime end){
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");
            view.Rows.Clear();
            view.Columns.Clear();
            int no = 1;
            string sql = "";
            if (between)
            {
                sql = @"SELECT t.item_name, SUM(item_qty_bought), SUM(total_amt) FROM tbl_transactions as t 
                        JOIN tbl_transactionlog as tl ON t.translog_id = tl.translog_id AND tl.void = '0'
                        WHERE tl.purchase_date  BETWEEN '" + startDate + "' ANd '" + endDate + "' GROUP BY t.item_name";
            }
            else {
                sql = @"SELECT t.item_name, SUM(item_qty_bought), SUM(total_amt) FROM tbl_transactions as t 
                        JOIN tbl_transactionlog as tl ON t.translog_id = tl.translog_id AND tl.void = '0' GROUP BY t.item_name";
            }

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "No");
                        view.Columns.Add("c2", "Item Description");
                        view.Columns.Add("c3", "Total Items");
                        view.Columns.Add("c4", "Total Amount");

                    }
                    while (read.Read())
                    {
                        int qty = Int32.Parse(read.GetValue(1).ToString());
                        decimal total = decimal.Parse(read.GetValue(2).ToString());
                        view.Rows.Add(new object[] { 
                        no++,read.GetValue(0),qty.ToString("D2") + " items",total.ToString("N")
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void salesbyItemSearch(DataGridView view, String search)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            int no = 1;
            string sql = "";
            sql = @"SELECT t.item_name, SUM(item_qty_bought), SUM(total_amt) FROM tbl_transactions as t 
                        JOIN tbl_transactionlog as tl ON t.translog_id = tl.translog_id AND tl.void = '0'
                        WHERE t.item_name LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' GROUP BY t.item_name";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "No");
                        view.Columns.Add("c2", "Item Description");
                        view.Columns.Add("c3", "Total Items");
                        view.Columns.Add("c4", "Total Amount");

                    }
                    while (read.Read())
                    {
                        int qty = Int32.Parse(read.GetValue(1).ToString());
                        decimal total = decimal.Parse(read.GetValue(2).ToString());
                        view.Rows.Add(new object[] { 
                        no++,read.GetValue(0),qty.ToString("D2") + " items",total.ToString("N")
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void salesProcessPerUser(DataGridView view, bool between, DateTime start, DateTime end)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");

            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if(between){
                sql = @"SELECT t.or_number, t.total_purchased, SUM(item_qty_bought), t.purchase_date, u.user_fullname, m.mem_lname, m.mem_fname FROM tbl_transactionlog as t JOIN tbl_transactions as ts ON t.translog_id = ts.translog_id JOIN tbl_user as u ON t.emp_id = u.user_id JOIN tbl_members as m ON m.mem_id = t.customer_id WHERE t.void = '0' AND t.purchase_date BETWEEN '" + startDate + "' ANd '" + endDate + "' GROUP BY ts.translog_id ";
                sql += @" UNION
                            SELECT t.or_number, t.total_purchased, SUM(item_qty_bought), t.purchase_date, u.user_fullname,'None -' as c, 'Member' as c2 FROM tbl_transactionlog as t JOIN tbl_transactions as ts ON t.translog_id = ts.translog_id JOIN tbl_user as u ON t.emp_id = u.user_id WHERE t.customer_id = '0' AND t.void = '0' AND t.purchase_date BETWEEN '" + startDate + "' ANd '" + endDate + "' GROUP BY ts.translog_id ORDER BY purchase_date DESC ";
            }
            else
            {
                sql = @"SELECT t.or_number, t.total_purchased, SUM(item_qty_bought), t.purchase_date, u.user_fullname, m.mem_lname, m.mem_fname FROM tbl_transactionlog as t JOIN tbl_transactions as ts ON t.translog_id = ts.translog_id JOIN tbl_user as u ON t.emp_id = u.user_id JOIN tbl_members as m ON m.mem_id = t.customer_id WHERE t.void = '0' GROUP BY ts.translog_id
                            UNION
                            SELECT t.or_number, t.total_purchased, SUM(item_qty_bought), t.purchase_date, u.user_fullname,'None -' as c, 'Member' as c2 FROM tbl_transactionlog as t JOIN tbl_transactions as ts ON t.translog_id = ts.translog_id JOIN tbl_user as u ON t.emp_id = u.user_id WHERE t.customer_id = '0' AND t.void = '0' GROUP BY ts.translog_id ORDER BY purchase_date DESC ";

            }
 
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "OR No");
                        view.Columns.Add("c2", "Member Name");
                        view.Columns.Add("c2", "Total Amount");
                        view.Columns.Add("c3", "Total Items");
                        view.Columns.Add("c4", "Date / Time");
                        view.Columns.Add("c4", "Process by");
                    }

                    while (read.Read())
                    {
                        if (read.HasRows)
                        {
                            string memCusName = read.GetValue(5) + " " + read.GetValue(6);
                            decimal amt = decimal.Parse(read.GetValue(1).ToString());
                            view.Rows.Add(new object[] { 
                            read.GetValue(0),memCusName,amt.ToString("N"),read.GetValue(2) + " items",read.GetValue(3),read.GetValue(4)
                            });
                        }
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void salesProcessPerUser(DataGridView view, String search)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = @"SELECT t.or_number, t.total_purchased, SUM(item_qty_bought), t.purchase_date, u.user_fullname, m.mem_lname, m.mem_fname FROM tbl_transactionlog as t JOIN tbl_transactions as ts ON t.translog_id = ts.translog_id JOIN tbl_user as u ON t.emp_id = u.user_id JOIN tbl_members as m ON m.mem_id = t.customer_id WHERE t.void = '0' AND u.user_fullname LIKE '%"+search.Replace("'","`").Replace(";","")+"%'  GROUP BY ts.translog_id " ;
                    sql += @" UNION
                            SELECT t.or_number, t.total_purchased, SUM(item_qty_bought), t.purchase_date, u.user_fullname,'None -' as c, 'Member' as c2 FROM tbl_transactionlog as t JOIN tbl_transactions as ts ON t.translog_id = ts.translog_id JOIN tbl_user as u ON t.emp_id = u.user_id WHERE t.customer_id = '0' AND t.void = '0' AND u.user_fullname LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%'  GROUP BY ts.translog_id ORDER BY purchase_date DESC";
                    MySqlConnection db = new MySqlConnection(connString);
                    try
                    {
                        db.Open();
                        MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                        using (MySqlDataReader read = mySqlComm.ExecuteReader())
                        {
                            if (view.Columns.Count == 0)
                            {
                                view.Columns.Add("c1", "OR No");
                                view.Columns.Add("c2", "Member Name");
                                view.Columns.Add("c2", "Total Amount");
                                view.Columns.Add("c3", "Total Items");
                                view.Columns.Add("c4", "Date / Time");
                                view.Columns.Add("c4", "Process by");
                            }

                            while (read.Read())
                            {
                                if (read.HasRows)
                                {
                                    string memCusName = read.GetValue(5) + " " + read.GetValue(6);
                                    decimal amt = decimal.Parse(read.GetValue(1).ToString());
                                    view.Rows.Add(new object[] { 
                            read.GetValue(0),memCusName,amt.ToString("N"),read.GetValue(2) + " items",read.GetValue(3),read.GetValue(4)
                            });
                                }
                            }
                        }
                    }
                    finally
                    {
                        db.Close();
                    }
        }

        public void AllLoansReport(DataGridView view)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            //int no = 1;
            string sql = "SELECT m.mem_fname, m.mem_lname, l.principal_amount, l.term_loan, l.process_date, l.end_date,u.user_fullname, l.ispaid,l.loanlog_id, m.mem_id  FROM tbl_loanlog as l JOIN tbl_members as m ON l.mem_id = m.mem_id JOIN tbl_user as u ON l.emp_id = u.user_id ORDER BY l.process_date DESC";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Loan No");
                        view.Columns.Add("c2", "Member Name");
                        view.Columns.Add("c2", "Principal Amount");
                        view.Columns.Add("c3", "Term");
                        view.Columns.Add("c4", "Amount Due"); //
                        view.Columns.Add("c4", "Date of Loan");
                        view.Columns.Add("c4", "Date Due");
                        view.Columns.Add("c4", "Status");
                        view.Columns.Add("c4", "Processed by");
                    }
                    while (read.Read())
                    {
                        String memberName = read.GetValue(0).ToString() + " " + read.GetValue(1).ToString();
                        decimal principalAmt = decimal.Parse(read.GetValue(2).ToString());
                        String term = read.GetValue(3).ToString();
                        switch (term)
                        {
                            case "0":
                                term = "Monthly";
                                break;
                            case "1":
                                term = "Quarter";
                                break;
                            case "2":
                                term = "Semi-Annual";
                                break;
                            case "3":
                                term = "Annual";
                                break;
                        }
                        String amountDue = "-";
                        String dateOFLoan = read.GetValue(4).ToString();
                        String dateDueOFLoan = read.GetValue(5).ToString();
                        String status = "";
                        int loanID = Int32.Parse( read.GetValue(8).ToString() );
                        if (read.GetValue(7).ToString() == "0")
                        {
                            status = "Unpaid";
                            amountDue = getPendingAmount(read.GetValue(9).ToString(), read.GetValue(8).ToString()).ToString("N"); //get the due
                        }
                        else
                        {
                            status = "Paid";
                            amountDue = "0";
                        }
                        String processBy = read.GetValue(6).ToString();

                        view.Rows.Add(new object[] { 
                        loanID.ToString("D2"),memberName, principalAmt.ToString("N"), term, amountDue, dateOFLoan, dateDueOFLoan, status, processBy
                         });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void AllDueLoansReport(DataGridView view, String start, String end)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "SELECT m.mem_fname, m.mem_lname, l.principal_amount, l.term_loan, l.process_date, l.end_date,u.user_fullname, l.ispaid,l.loanlog_id, m.mem_id  FROM tbl_loanlog as l JOIN tbl_members as m ON l.mem_id = m.mem_id JOIN tbl_user as u ON l.emp_id = u.user_id WHERE l.ispaid = '0' AND l.end_date BETWEEN '"+start+"' AND '"+end+"' ORDER BY l.process_date DESC";
            //int no = 1;

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {

                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Loan No");
                        view.Columns.Add("c4", "Date of Loan");
                        view.Columns.Add("c4", "Date Due");
                        view.Columns.Add("c2", "Member Name");
                        view.Columns.Add("c4", "Amount Due"); //
                    }
                    while (read.Read())
                    {
                        String memberName = read.GetValue(0).ToString() + " " + read.GetValue(1).ToString();
                        decimal principalAmt = decimal.Parse(read.GetValue(2).ToString());
                        String term = read.GetValue(3).ToString();
                        switch (term)
                        {
                            case "0":
                                term = "Monthly";
                                break;
                            case "1":
                                term = "Quarter";
                                break;
                            case "2":
                                term = "Semi-Annual";
                                break;
                            case "3":
                                term = "Annual";
                                break;
                        }
                        String amountDue = "-";
                        String dateOFLoan = read.GetValue(4).ToString();
                        String dateDueOFLoan = read.GetValue(5).ToString();
                        int loanID = Int32.Parse(read.GetValue(8).ToString());
                        if (read.GetValue(7).ToString() == "0")
                        {
                            amountDue = getPendingAmount(read.GetValue(9).ToString(), read.GetValue(8).ToString()).ToString("N"); //get the due
                        }
                        else
                        {
                            amountDue = "0";
                        }
                        String processBy = read.GetValue(6).ToString();

                        view.Rows.Add(new object[] { 
                        loanID.ToString("D2"),dateOFLoan, dateDueOFLoan, memberName,amountDue
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void AllLoansReportOFMember(DataGridView view, String memID)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            int no = 1;
            string sql = "SELECT m.mem_fname, m.mem_lname, l.principal_amount, l.term_loan, l.process_date, l.end_date,u.user_fullname, l.ispaid,l.loanlog_id, m.mem_id  FROM tbl_loanlog as l JOIN tbl_members as m ON l.mem_id = m.mem_id JOIN tbl_user as u ON l.emp_id = u.user_id WHERE m.mem_id = '"+memID+"' ORDER BY l.process_date DESC";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Loan No");
                        view.Columns.Add("c2", "Member Name");
                        view.Columns.Add("c2", "Principal Amount");
                        view.Columns.Add("c3", "Term");
                        view.Columns.Add("c4", "Amount Due"); //
                        view.Columns.Add("c4", "Date of Loan");
                        view.Columns.Add("c4", "Date Due");
                        view.Columns.Add("c4", "Status");
                        view.Columns.Add("c4", "Processed by");
                    }
                    while (read.Read())
                    {
                        String memberName = read.GetValue(0).ToString() + " " + read.GetValue(1).ToString();
                        String principalAmt = read.GetValue(2).ToString();
                        String term = read.GetValue(3).ToString();
                        switch (term)
                        {
                            case "0":
                                term = "Monthly";
                                break;
                            case "1":
                                term = "Quarter";
                                break;
                            case "2":
                                term = "Semi-Annual";
                                break;
                            case "3":
                                term = "Annual";
                                break;
                        }
                        String amountDue = "-";
                        String dateOFLoan = read.GetValue(4).ToString();
                        String dateDueOFLoan = read.GetValue(5).ToString();
                        String status = "";
                        int loanID = Int32.Parse(read.GetValue(8).ToString());
                        if (read.GetValue(7).ToString() == "0")
                        {
                            status = "Unpaid";
                            amountDue = getPendingAmount(read.GetValue(9).ToString(), read.GetValue(8).ToString()).ToString(); //get the due
                        }
                        else
                        {
                            status = "Paid";
                            amountDue = "0";
                        }
                        String processBy = read.GetValue(6).ToString();

                        view.Rows.Add(new object[] { 
                        loanID.ToString("D2"),memberName, principalAmt, term, amountDue, dateOFLoan, dateDueOFLoan, status, processBy
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void AllUnpaidLoansReport(DataGridView view)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            //int no = 1;
            string sql = "SELECT m.mem_fname, m.mem_lname, l.principal_amount, l.term_loan, l.process_date, l.end_date,u.user_fullname, l.ispaid,l.loanlog_id, m.mem_id  FROM tbl_loanlog as l JOIN tbl_members as m ON l.mem_id = m.mem_id JOIN tbl_user as u ON l.emp_id = u.user_id WHERE l.ispaid = '0'  ORDER BY l.process_date DESC LIMIT 250";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Loan No");
                        view.Columns.Add("c2", "Member Name");
                        view.Columns.Add("c2", "Principal Amount");
                        view.Columns.Add("c3", "Term");
                        view.Columns.Add("c4", "Amount Due"); //
                        view.Columns.Add("c4", "Date of Loan");
                        view.Columns.Add("c4", "Date Due");
                        view.Columns.Add("c4", "Processed by");
                    }
                    while (read.Read())
                    {
                        String memberName = read.GetValue(0).ToString() + " " + read.GetValue(1).ToString();
                        String principalAmt = read.GetValue(2).ToString();
                        String term = read.GetValue(3).ToString();
                        switch (term)
                        {
                            case "0":
                                term = "Monthly";
                                break;
                            case "1":
                                term = "Quarter";
                                break;
                            case "2":
                                term = "Semi-Annual";
                                break;
                            case "3":
                                term = "Annual";
                                break;
                        }
                        String amountDue = "-";
                        String dateOFLoan = read.GetValue(4).ToString();
                        String dateDueOFLoan = read.GetValue(5).ToString();
                        int loanID = Int32.Parse(read.GetValue(8).ToString());
                        if (read.GetValue(7).ToString() == "0")
                        {
                            amountDue = getPendingAmount(read.GetValue(9).ToString(), read.GetValue(8).ToString()).ToString(); //get the due
                        }
                        else
                        {
                            amountDue = "0";
                        }
                        String processBy = read.GetValue(6).ToString();

                        view.Rows.Add(new object[] { 
                        loanID.ToString("D2"),memberName, principalAmt, term, amountDue, dateOFLoan, dateDueOFLoan, processBy
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void AllPaidLoansReport(DataGridView view)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            //int no = 1;
            string sql = "SELECT m.mem_fname, m.mem_lname, l.principal_amount, l.term_loan, l.process_date, l.end_date,u.user_fullname, l.ispaid,l.loanlog_id, m.mem_id  FROM tbl_loanlog as l JOIN tbl_members as m ON l.mem_id = m.mem_id JOIN tbl_user as u ON l.emp_id = u.user_id WHERE l.ispaid = '1' ORDER BY l.process_date DESC";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Loan No");
                        view.Columns.Add("c2", "Member Name");
                        view.Columns.Add("c2", "Principal Amount");
                        view.Columns.Add("c3", "Term");
                        view.Columns.Add("c4", "Amount Due"); //
                        view.Columns.Add("c4", "Date of Loan");
                        view.Columns.Add("c4", "Date Due");
                        view.Columns.Add("c4", "Processed by");
                    }
                    while (read.Read())
                    {
                        String memberName = read.GetValue(0).ToString() + " " + read.GetValue(1).ToString();
                        String principalAmt = read.GetValue(2).ToString();
                        String term = read.GetValue(3).ToString();
                        switch (term)
                        {
                            case "0":
                                term = "Monthly";
                                break;
                            case "1":
                                term = "Quarter";
                                break;
                            case "2":
                                term = "Semi-Annual";
                                break;
                            case "3":
                                term = "Annual";
                                break;
                        }
                        String amountDue = "-";
                        String dateOFLoan = read.GetValue(4).ToString();
                        String dateDueOFLoan = read.GetValue(5).ToString();
                        int loanID = Int32.Parse(read.GetValue(8).ToString());
                        if (read.GetValue(7).ToString() == "0")
                        {
                            amountDue = getPendingAmount(read.GetValue(9).ToString(), read.GetValue(8).ToString()).ToString(); //get the due
                        }
                        else
                        {
                            amountDue = "0";
                        }
                        String processBy = read.GetValue(6).ToString();

                        view.Rows.Add(new object[] { 
                        loanID.ToString("D2"),memberName, principalAmt, term, amountDue, dateOFLoan, dateDueOFLoan, processBy
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void AllFilingFee(DataGridView view)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            int no = 1;
            decimal totalFilingFee = 0;
            string sql = "SELECT m.mem_fname, m.mem_lname, f.fillfee_amt, f.date_filed, u.user_fullname  FROM tbl_feefiling as f JOIN tbl_members as m ON f.customer_id = m.mem_id JOIN tbl_user as u ON f.emp_id = u.user_id ORDER BY f.date_filed DESC";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "No");
                        view.Columns.Add("c2", "Member Name");
                        view.Columns.Add("c2", "Filling Fee Amount");
                        view.Columns.Add("c3", "Date Processed");
                        view.Columns.Add("c4", "Processed by");
                    }
                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        no++,read.GetValue(0) + " "+ read.GetValue(1), read.GetValue(2), read.GetValue(3), read.GetValue(4)
                        });
                        totalFilingFee += decimal.Parse(read.GetValue(2).ToString());
                    }
                }
            }
            finally
            {
                db.Close();
            }
            if (view.Rows.Count > 0)
            {
                view.Rows.Add(new object[] { "", "", "", "", "" });

                view.Rows.Add(new object[] {"", "Total Amount ", totalFilingFee.ToString("N") + "", "", "" });
            }
            //
        }

        public void AllProcessFee(DataGridView view)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            int no = 1;
            decimal totalFilingFee = 0;
            string sql = "SELECT m.mem_fname, m.mem_lname, f.procfee_amt, f.date_filed, u.user_fullname  FROM tbl_feeprocessing as f JOIN tbl_members as m ON f.customer_id = m.mem_id JOIN tbl_user as u ON f.emp_id = u.user_id ORDER BY f.date_filed DESC";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "No");
                        view.Columns.Add("c2", "Member Name");
                        view.Columns.Add("c2", "Process Fee Amount");
                        view.Columns.Add("c3", "Date Processed");
                        view.Columns.Add("c4", "Processed by");
                    }
                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        no++,read.GetValue(0) + " "+ read.GetValue(1), read.GetValue(2), read.GetValue(3), read.GetValue(4)
                         });
                        totalFilingFee += decimal.Parse(read.GetValue(2).ToString());
                    }
                }
            }
            finally
            {
                db.Close();
            }

            if (view.Rows.Count > 0)
            {
                view.Rows.Add(new object[] { "", "", "", "", "" });

                view.Rows.Add(new object[] { "", "Total Amount ", totalFilingFee.ToString("N") + "", "", "" });
            }
     
        }

        public void AllSharecapitaFee(DataGridView view)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            int no = 1;
            decimal totalFilingFee = 0;
            string sql = "SELECT m.mem_fname, m.mem_lname, f.shcap_amt, f.date_filed, u.user_fullname  FROM tbl_feesharecapital as f JOIN tbl_members as m ON f.customer_id = m.mem_id JOIN tbl_user as u ON f.emp_id = u.user_id ORDER BY f.date_filed DESC";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "No");
                        view.Columns.Add("c2", "Member Name");
                        view.Columns.Add("c2", "Process Fee Amount");
                        view.Columns.Add("c3", "Date Processed");
                        view.Columns.Add("c4", "Processed by");
                    }
                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        no++,read.GetValue(0) + " "+ read.GetValue(1), read.GetValue(2), read.GetValue(3), read.GetValue(4)
                        });
                        totalFilingFee += decimal.Parse(read.GetValue(2).ToString());
                    }
                }
            }
            finally
            {
                db.Close();
            }
            
            if (view.Rows.Count > 0)
            {
                view.Rows.Add(new object[] { "", "", "", "", "" });

                view.Rows.Add(new object[] { "", "Total Amount ", totalFilingFee.ToString("N") + "", "", "" });
            }
        }

        public void AllLoansReportProcessPerUser(DataGridView view, String empID)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if (empID == "")
            {
                sql = "SELECT m.mem_fname, m.mem_lname, l.principal_amount, l.term_loan, l.process_date, l.end_date,u.user_fullname, l.ispaid,l.loanlog_id, m.mem_id  FROM tbl_loanlog as l JOIN tbl_members as m ON l.mem_id = m.mem_id JOIN tbl_user as u ON l.emp_id = u.user_id ORDER BY l.process_date DESC";
            }
            else {
                 sql = "SELECT m.mem_fname, m.mem_lname, l.principal_amount, l.term_loan, l.process_date, l.end_date,u.user_fullname, l.ispaid,l.loanlog_id, m.mem_id  FROM tbl_loanlog as l JOIN tbl_members as m ON l.mem_id = m.mem_id JOIN tbl_user as u ON l.emp_id = u.user_id WHERE l.emp_id = '" + empID + "' ORDER BY l.process_date DESC";

            }
            int no = 1;
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "No");
                        view.Columns.Add("c2", "Member Name");
                        view.Columns.Add("c2", "Principal Amount");
                        view.Columns.Add("c3", "Term");
                        view.Columns.Add("c4", "Amount Due"); //
                        view.Columns.Add("c4", "Status");
                        view.Columns.Add("c4", "Processed by");
                    }

                    while (read.Read())
                    {
                        String memberName = read.GetValue(0).ToString() + " " + read.GetValue(1).ToString();
                        String principalAmt = read.GetValue(2).ToString();
                        String term = read.GetValue(3).ToString();
                        switch (term)
                        {
                            case "0":
                                term = "Monthly";
                                break;
                            case "1":
                                term = "Quarter";
                                break;
                            case "2":
                                term = "Semi-Annual";
                                break;
                            case "3":
                                term = "Annual";
                                break;
                        }
                        String amountDue = "-";
                        String dateOFLoan = read.GetValue(4).ToString();
                        String dateDueOFLoan = read.GetValue(5).ToString();
                        String status = "";
                        int loanID = Int32.Parse(read.GetValue(8).ToString());
                        if (read.GetValue(7).ToString() == "0")
                        {
                            status = "Unpaid";
                            amountDue = getPendingAmount(read.GetValue(9).ToString(), read.GetValue(8).ToString()).ToString(); //get the due
                        }
                        else
                        {
                            status = "Paid";
                            amountDue = "0";
                        }
                        String processBy = read.GetValue(6).ToString();

                        view.Rows.Add(new object[] { 
                        loanID.ToString("D2"),memberName, principalAmt, term, amountDue, status, processBy
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void AllLoanPaymentReportProcessPerUser(DataGridView view, String empID)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            int no = 1;
            string sql = "";
            if (empID == "")
            {
                sql = "SELECT m.mem_fname, m.mem_lname, p.amount_paid, p.date_paid, u.user_fullname FROM tbl_loanpayment as p JOIN tbl_members as m ON p.mem_id = m.mem_id JOIN tbl_user as u ON p.emp_id = u.user_id ORDER BY  p.date_paid DESC";
            }
            else {
                 sql = "SELECT m.mem_fname, m.mem_lname, p.amount_paid, p.date_paid, u.user_fullname FROM tbl_loanpayment as p JOIN tbl_members as m ON p.mem_id = m.mem_id JOIN tbl_user as u ON p.emp_id = u.user_id WHERE p.emp_id = '" + empID + "' ORDER BY  p.date_paid DESC";
            }

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "No");
                        view.Columns.Add("c2", "Member Name");
                        view.Columns.Add("c2", "Amount Paid");
                        view.Columns.Add("c3", "Date Paid");
                        view.Columns.Add("c4", "Processed by");
                    }

                    while (read.Read())
                    {
                        String memberName = read.GetValue(0).ToString() + " " + read.GetValue(1).ToString();
                        String amtPaid = read.GetValue(2).ToString();
                        String date = read.GetValue(3).ToString();
                        String processBy = read.GetValue(4).ToString();

                        view.Rows.Add(new object[] { 
                        no++,memberName, amtPaid, date, processBy
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public int createNewSupplier(String suppname, String suppadd, String suppcontacrt)
        {
            string sql = "INSERT INTO tbl_supplier(`supp_name`, `supp_address`, `supp_contact`) VALUES ('"+suppname+"', '"+suppadd+"', '"+suppcontacrt+"') ";

            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;
            int stat = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();
                mySqlComm.CommandText = sql;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                stat = mySqlComm.ExecuteNonQuery();
                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }

            return stat;
            
        }

        public void populateSupplierInCombo(ComboBox box) {
            string sql = "SELECT supp_name FROM tbl_supplier";
            box.Items.Clear();
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        box.Items.Add(read.GetValue(0).ToString());
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void AllPurchasesSupplierSumm(DataGridView view, bool rangeparam, DateTime start, DateTime end)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");

            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if(rangeparam){
                sql = "SELECT s.stock_supplier, st.stock_itemname, st.stock_rc_qty, s.stock_deldate, u.user_fullname, s.invoice_number  FROM tbl_stockreceive as s JOIN tbl_stockrcitems as st ON s.stock_receiveid = st.stock_receivedid JOIN tbl_user as u ON u.user_id = s.stock_recby WHERE s.stock_deldate BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY s.stock_supplier ASC";
            }
            else
            {
                sql = "SELECT s.stock_supplier, st.stock_itemname, st.stock_rc_qty, s.stock_deldate, u.user_fullname, s.invoice_number  FROM tbl_stockreceive as s JOIN tbl_stockrcitems as st ON s.stock_receiveid = st.stock_receivedid JOIN tbl_user as u ON u.user_id = s.stock_recby ORDER BY s.stock_supplier ASC";
            }
            int no = 1;

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {


                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Inv. No");
                        view.Columns.Add("c2", "Supplier Name");
                        view.Columns.Add("c2", "Item Name");
                        view.Columns.Add("c3", "Quantity Delivered");
                        view.Columns.Add("c4", "Date Time");
                        view.Columns.Add("c4", "Received By");
                    }
                    while (read.Read())
                    {
                        int inv_num = Int32.Parse(read.GetValue(5).ToString());
                        DateTime deto = DateTime.Parse(read.GetValue(3).ToString());
                        view.Rows.Add(new object[] { 
                        inv_num.ToString("D2"),read.GetValue(0), read.GetValue(1), read.GetValue(2), deto.ToString("MM/dd/yyyy hh:mm:ss tt"),read.GetValue(4)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void AllPurchasesSupplierSumm(DataGridView view, String search)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";

            sql = "SELECT s.stock_supplier, st.stock_itemname, st.stock_rc_qty, s.stock_deldate, u.user_fullname, s.invoice_number  FROM tbl_stockreceive as s JOIN tbl_stockrcitems as st ON s.stock_receiveid = st.stock_receivedid JOIN tbl_user as u ON u.user_id = s.stock_recby WHERE  s.stock_supplier LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' ORDER BY s.stock_supplier ASC";
            int no = 1;

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {


                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Inv. No");
                        view.Columns.Add("c2", "Supplier Name");
                        view.Columns.Add("c2", "Item Name");
                        view.Columns.Add("c3", "Quantity Delivered");
                        view.Columns.Add("c4", "Date Time");
                        view.Columns.Add("c4", "Received By");
                    }
                    while (read.Read())
                    {
                        int inv_num = Int32.Parse(read.GetValue(5).ToString());
                        DateTime deto = DateTime.Parse(read.GetValue(3).ToString());
                        view.Rows.Add(new object[] { 
                        inv_num.ToString("D2"),read.GetValue(0), read.GetValue(1), read.GetValue(2), deto.ToString("MM/dd/yyyy hh:mm:ss tt"),read.GetValue(4)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void AllPurchasesByItems(DataGridView view, bool rangeparam, DateTime start, DateTime end)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if (rangeparam)
            {
                sql = "SELECT st.stock_itemname, st.stock_rc_qty, s.stock_deldate,s.stock_supplier, u.user_fullname, s.invoice_number  FROM tbl_stockreceive as s JOIN tbl_stockrcitems as st ON s.stock_receiveid = st.stock_receivedid JOIN tbl_user as u ON u.user_id = s.stock_recby WHERE s.stock_deldate BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY st.stock_itemname ASC";
            }
            else
            {
                sql = "SELECT st.stock_itemname, st.stock_rc_qty, s.stock_deldate,s.stock_supplier, u.user_fullname, s.invoice_number  FROM tbl_stockreceive as s JOIN tbl_stockrcitems as st ON s.stock_receiveid = st.stock_receivedid JOIN tbl_user as u ON u.user_id = s.stock_recby ORDER BY st.stock_itemname ASC";
            }
            int no = 1;

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {


                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Inv. No");
                        view.Columns.Add("c2", "Item Name");
                        view.Columns.Add("c3", "Quantity Delivered");
                        view.Columns.Add("c4", "Date Delivered\n mm/dd/yyyy");
                        view.Columns.Add("c2", "Supplier Name");
                        view.Columns.Add("c4", "Received By");
                    }
                    while (read.Read())
                    {
                        int inv_num = Int32.Parse(read.GetValue(5).ToString());
                        DateTime deto = DateTime.Parse(read.GetValue(2).ToString());
                        view.Rows.Add(new object[] { 
                        inv_num.ToString("D2"),read.GetValue(0), read.GetValue(1), deto.ToString("MM/dd/yyyy hh:mm:ss tt"), read.GetValue(3),read.GetValue(4)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void AllPurchasesByItems(DataGridView view, String search)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            sql = "SELECT st.stock_itemname, st.stock_rc_qty, s.stock_deldate,s.stock_supplier, u.user_fullname, s.invoice_number  FROM tbl_stockreceive as s JOIN tbl_stockrcitems as st ON s.stock_receiveid = st.stock_receivedid JOIN tbl_user as u ON u.user_id = s.stock_recby WHERE st.stock_itemname LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' ORDER BY st.stock_itemname ASC";
            int no = 1;

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {


                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Inv. No");
                        view.Columns.Add("c2", "Item Name");
                        view.Columns.Add("c3", "Quantity Delivered");
                        view.Columns.Add("c4", "Date Delivered");
                        view.Columns.Add("c2", "Supplier Name");
                        view.Columns.Add("c4", "Received By");
                    }
                    while (read.Read())
                    {
                        int inv_num = Int32.Parse(read.GetValue(5).ToString());
                        DateTime deto = DateTime.Parse(read.GetValue(2).ToString());

                        view.Rows.Add(new object[] { 
                        inv_num.ToString("D2"),read.GetValue(0), read.GetValue(1), deto.ToString("MM/dd/yyyy hh:mm:ss tt"), read.GetValue(3),read.GetValue(4)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void AllPurchasesByItemsProcessByUser(DataGridView view, bool rangeparam, DateTime start, DateTime end)
        {
            String startDate = start.ToString("yyyy-MM-dd");
            String endDate = end.AddDays(1).ToString("yyyy-MM-dd");

            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            if (rangeparam)
            {
                sql = "SELECT s.stock_receiveid,st.stock_itemname, st.stock_rc_qty,u.user_fullname, s.stock_deldate,s.stock_supplier  FROM tbl_stockreceive as s JOIN tbl_stockrcitems as st ON s.stock_receiveid = st.stock_receivedid JOIN tbl_user as u ON u.user_id = s.stock_recby ORDER BY s.stock_recby ASC";
            }
            else
            {
                sql = "SELECT s.stock_receiveid,st.stock_itemname, st.stock_rc_qty,u.user_fullname, s.stock_deldate,s.stock_supplier  FROM tbl_stockreceive as s JOIN tbl_stockrcitems as st ON s.stock_receiveid = st.stock_receivedid JOIN tbl_user as u ON u.user_id = s.stock_recby ORDER BY s.stock_recby ASC";
            }

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Invoice No");
                        view.Columns.Add("c2", "Item Name");
                        view.Columns.Add("c3", "Quantity Delivered");
                        view.Columns.Add("c4", "Processed By");
                        view.Columns.Add("c4", "Date Delivered");
                        view.Columns.Add("c2", "Supplier Name");
                    }
                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        read.GetValue(0), read.GetValue(1), read.GetValue(2), read.GetValue(3),read.GetValue(4),read.GetValue(5)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void AllPurchasesByItemsProcessByUser(DataGridView view, String search)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "";
            sql = "SELECT s.stock_receiveid,st.stock_itemname, st.stock_rc_qty,u.user_fullname, s.stock_deldate,s.stock_supplier  FROM tbl_stockreceive as s JOIN tbl_stockrcitems as st ON s.stock_receiveid = st.stock_receivedid JOIN tbl_user as u ON u.user_id = s.stock_recby WHERE u.user_fullname LIKE '%"+search.Replace("'","`").Replace(";","")+"%' ORDER BY s.stock_recby ASC";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Invoice No");
                        view.Columns.Add("c2", "Item Name");
                        view.Columns.Add("c3", "Quantity Delivered");
                        view.Columns.Add("c4", "Processed By");
                        view.Columns.Add("c4", "Date Delivered");
                        view.Columns.Add("c2", "Supplier Name");
                    }
                    while (read.Read())
                    {
                        view.Rows.Add(new object[] { 
                        read.GetValue(0), read.GetValue(1), read.GetValue(2), read.GetValue(3),read.GetValue(4),read.GetValue(5)
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void ListReportMember(DataGridView view)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "SELECT m.mem_id, m.mem_fname, m.mem_lname, m.mem_cellcontact, m.mem_tellcontact, c.current_Savings FROM tbl_members as m JOIN tbl_currsavings as c ON c.mem_id= m.mem_id";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Member No.");
                        view.Columns.Add("c2", "Member Name");
                        view.Columns.Add("c3", "Cell Contact");
                        view.Columns.Add("c4", "Tell Contact");
                        view.Columns.Add("c4", "Current Savings");
                        //view.Columns.Add("c2", "Current Loan Due");
                    }
                    while (read.Read())
                    {
                        String memid = read.GetValue(0).ToString();
                        String membername = read.GetValue(1).ToString() + " " + read.GetValue(2).ToString();
                        String cpcontact = read.GetValue(3).ToString();
                        String tellcontact = read.GetValue(4).ToString();
                        String savings = read.GetValue(5).ToString();

                        decimal savingstemp = decimal.Parse(savings);
                        savings = savingstemp.ToString("N");


                        view.Rows.Add(new object[] { 
                         memid, membername, cpcontact, tellcontact,savingstemp.ToString("N")
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void ListReportMember(DataGridView view, String search)
        {
            view.Rows.Clear();
            view.Columns.Clear();
           string sql = "SELECT m.mem_id, m.mem_fname, m.mem_lname, m.mem_cellcontact, m.mem_tellcontact, c.current_Savings FROM tbl_members as m JOIN tbl_currsavings as c ON c.mem_id= m.mem_id  WHERE m.mem_lname LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' OR m.mem_fname LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' OR m.mem_id LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' ";

           MySqlConnection db = new MySqlConnection(connString);
           try
           {
               db.Open();
               MySqlCommand mySqlComm = new MySqlCommand(sql, db);
               using (MySqlDataReader read = mySqlComm.ExecuteReader())
               {
                   if (view.Columns.Count == 0)
                   {
                       view.Columns.Add("c1", "Member No.");
                       view.Columns.Add("c2", "Member Name");
                       view.Columns.Add("c3", "Cell Contact");
                       view.Columns.Add("c4", "Tell Contact");
                       view.Columns.Add("c4", "Current Savings");
                       //view.Columns.Add("c2", "Current Loan Due");
                   }
                   while (read.Read())
                   {
                       String memid = read.GetValue(0).ToString();
                       String membername = read.GetValue(1).ToString() + " " + read.GetValue(2).ToString();
                       String cpcontact = read.GetValue(3).ToString();
                       String tellcontact = read.GetValue(4).ToString();
                       String savings = read.GetValue(5).ToString();

                       decimal savingstemp = decimal.Parse(savings);
                       savings = savingstemp.ToString("N");


                       view.Rows.Add(new object[] { 
                         memid, membername, cpcontact, tellcontact,savingstemp.ToString("N")
                        });
                   }
               }
           }
           finally
           {
               db.Close();
           }
        }

        public void ListReportSupplier(DataGridView view)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "SELECT * FROM tbl_supplier";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Supplier No.");
                        view.Columns.Add("c2", "Supplier Name");
                        view.Columns.Add("c3", "Supplier Address");
                        view.Columns.Add("c4", "Supplier Contact");
                    }
                    while (read.Read())
                    {
                        String suppid = read.GetValue(0).ToString();
                        String uppnamename = read.GetValue(1).ToString();
                        String suppadd = read.GetValue(2).ToString();
                        String suppcontact = read.GetValue(3).ToString();

                        view.Rows.Add(new object[] { 
                        suppid, uppnamename, suppadd, suppcontact
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void ListReportSupplier(DataGridView view, String search)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "SELECT * FROM tbl_supplier WHERE supp_name LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' OR supp_address LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%'  OR supp_id LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' ";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Supplier No.");
                        view.Columns.Add("c2", "Supplier Name");
                        view.Columns.Add("c3", "Supplier Address");
                        view.Columns.Add("c4", "Supplier Contact");
                    }
                    while (read.Read())
                    {
                        String suppid = read.GetValue(0).ToString();
                        String uppnamename = read.GetValue(1).ToString();
                        String suppadd = read.GetValue(2).ToString();
                        String suppcontact = read.GetValue(3).ToString();

                        view.Rows.Add(new object[] { 
                        suppid, uppnamename, suppadd, suppcontact
                        });
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void ListReportEmployee(DataGridView view)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "SELECT * FROM tbl_user WHERE active = '1' ";

            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Employee No.");
                        view.Columns.Add("c2", "Employee Name");
                        view.Columns.Add("c3", "Employee Username");
                        view.Columns.Add("c4", "Date Created");
                    }
                    while (read.Read())
                    {
                        try
                        {
                            String empid = read.GetValue(0).ToString();
                            String empname = read.GetValue(3).ToString();
                            String empusern = read.GetValue(1).ToString();
                            DateTime date = DateTime.Parse(read.GetValue(5).ToString());

                            view.Rows.Add(new object[] { empid, empname, empusern, date.ToString("MM/dd/yyyy hh:mm:ss tt") });
                        }
                        catch { }
                    }
                }
            }
            finally
            {
                db.Close();
            }

        }

        public void ListReportEmployee(DataGridView view, String search)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            string sql = "SELECT * FROM tbl_user WHERE user_fullname LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' OR user_id LIKE '%" + search.Replace("'", "`").Replace(";", "") + "%' AND active = '1' ";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    if (view.Columns.Count == 0)
                    {
                        view.Columns.Add("c1", "Employee No.");
                        view.Columns.Add("c2", "Employee Name");
                        view.Columns.Add("c3", "Employee Username");
                        view.Columns.Add("c4", "Date Created");
                    }
                    while (read.Read())
                    {
                        try
                        {
                            String empid = read.GetValue(0).ToString();
                            String empname = read.GetValue(3).ToString();
                            String empusern = read.GetValue(1).ToString();
                            DateTime date = DateTime.Parse(read.GetValue(5).ToString());

                            view.Rows.Add(new object[] { empid, empname, empusern, date.ToString("MM/dd/yyyy hh:mm:ss tt") });
                        }
                        catch { }
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void getUserAccessRights(int empID, out String[] moduleArray ){
            string sql = "SELECT * FROM tbl_userAccessRights WHERE emp_id = '"+empID+"' ";
            moduleArray = new String[38];
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();

                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        for (int a = 0; a < moduleArray.Length; a++)
                        {
                            moduleArray[a] = read.GetValue(a + 2).ToString();
                        }
                    }
                }
            }
            finally
            {
                db.Close();
            }
        }

        public int UpdateUserAccessRights(int empID, String[] moduleArray)
        {
            string sql = "UPDATE tbl_userAccessRights SET `mem_module`  = '" + moduleArray[0] + "' , `mem_newmem`  = '" + moduleArray[1] + "' , `mem_record`  = '" + moduleArray[2] + "' , `pos_module` = '" + moduleArray[3] + "', `pos_register` = '" + moduleArray[4] + "' , `pos_savedsales` = '" + moduleArray[5] + "' , `pos_refunds` = '" + moduleArray[6] + "' , `pos_endday` = '" + moduleArray[7] + "' , `pos_endweek` = '" + moduleArray[8] + "' , `pos_transhis` = '" + moduleArray[9] + "' , `inv_module` = '" + moduleArray[10] + "' , `inv_enteritems` = '" + moduleArray[11] + "' , `stocks_submod` = '" + moduleArray[12] + "' , `stocks_req` = '" + moduleArray[13] + "' , `stocks_rec` = '" + moduleArray[14] + "' , `stocks_ret` = '" + moduleArray[15] + "' , `inv_itemlist` = '" + moduleArray[16] + "' , `inv_report` = '" + moduleArray[17] + "' , `col_module` = '" + moduleArray[18] + "' , `col_loans` = '" + moduleArray[19] + "' , `col_deposit` = '" + moduleArray[20] + "' , `col_loanmoney` = '" + moduleArray[21] + "' , `col_loanpay` = '" + moduleArray[22] + "' , `col_moneycounter` = '" + moduleArray[23] + "' , `rep_module` = '" + moduleArray[24] + "' , `rep_mem` = '" + moduleArray[25] + "' , `rep_inventory` = '" + moduleArray[26] + "' , `rep_sales` = '" + moduleArray[27] + "' , `rep_purchases` = '" + moduleArray[28] + "' , `rep_loans` = '" + moduleArray[29] + "' , `rep_trans` = '" + moduleArray[30] + "' , `rep_pay` = '" + moduleArray[31] + "' , `rep_listrep` = '" + moduleArray[32] + "' , `payroll_module` = '" + moduleArray[33] + "' , `misc_module` = '" + moduleArray[34] + "' , `misc_uaccess` = '" + moduleArray[35] + "' , `misc_audit` = '" + moduleArray[36] + "' , `misc_loancal` = '" + moduleArray[37] + "' WHERE `emp_id` = '"+empID+"' ";
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;
            int stat = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();
                mySqlComm.CommandText = sql;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                stat = mySqlComm.ExecuteNonQuery();

                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback();
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }
            return stat;
        }
        
        public String getCurrentMemberSavings(String memberid)
        {
            string sql = "SELECT current_Savings FROM tbl_currSavings WHERE mem_id = '"+memberid+"' ";
            String currSavings = "0";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        currSavings = read.GetValue(0).ToString();
                        decimal savingstemp = decimal.Parse(currSavings, System.Globalization.NumberStyles.Currency);
                        currSavings = savingstemp.ToString("N");
                    }
                }
            }
            finally
            {
                db.Close();
            }

            return currSavings;
        }

        public String getCurrentMemberShareCapital(String memberid)
        {
            string sql = "SELECT current_ShareCapital FROM tbl_currSavings WHERE mem_id = '" + memberid + "' ";
            String currSavings = "0";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        currSavings = read.GetValue(0).ToString();
                        decimal savingstemp = decimal.Parse(currSavings, System.Globalization.NumberStyles.Currency);
                        currSavings = savingstemp.ToString("N");
                    }
                }
            }
            finally
            {
                db.Close();
            }

            return currSavings;
        }

        public bool insertNewORNumbers(String sql) {

            bool success = false;
            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            MySqlTransaction trans = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                trans = db.BeginTransaction();
                mySqlComm.CommandText = sql;
                mySqlComm.Connection = db;
                mySqlComm.Transaction = trans;
                mySqlComm.ExecuteNonQuery();

                trans.Commit();
                success = true;
            }
            catch (MySqlException ss)
            {
                MessageBox.Show(ss.ToString());
                trans.Rollback();
                success = false;
            }
            finally
            {
                db.Close();
                Cursor.Current = Cursors.Default;
            }

            return success;
        }

        public bool checkORNumberifAlreadyExisting(String or_ref_no)
        {
            bool precheck = false;
            string sql = "SELECT `or_number_ref` FROM tbl_inputtedor WHERE `or_number_ref` = '" + or_ref_no + "' ";
            MySqlConnection db = new MySqlConnection(connString);
            try
            {
                db.Open();
                MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                using (MySqlDataReader read = mySqlComm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        if (or_ref_no == read.GetValue(0).ToString())
                        {
                            precheck = true;
                        }
                    }
                }
            }
            finally
            {
                db.Close();
            }

            return precheck;

        }








    }
}
