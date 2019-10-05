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
    public partial class members_regUpdate2 : Form
    {
        String empID;
        String member_id = "";
   

        DatabaseStuff dbhandler = new DatabaseStuff();
        String lname, fname, mnane, address, provadd ,addresstype, cellphone, tellphone, bday, bplace, age, gender, cstatus, religion, id, iddet, id2, id2det;
 
        public members_regUpdate2(String empID,String memberid, String lname, String fname, String mnane, String address, String provadd, String addresstype, String cellphone, String tellphone, String bday, String bplace, String age, String gender, String cstatus, String religion, String id, String iddet, String id2, String id2det)
        {
            InitializeComponent();
            this.lname = lname;
            this.fname = fname;
            this.mnane = mnane;
            this.address = address;
            this.addresstype = addresstype;
            this.cellphone = cellphone;
            this.tellphone = tellphone;
            this.bday = bday;
            this.bplace = bplace;
            this.age = age;
            this.gender = gender;
            this.cstatus = cstatus;
            this.religion = religion;
            this.id = id;
            this.iddet = iddet;
            this.id2 = id2;
            this.id2det = id2det;

            this.provadd = provadd;
            this.empID = empID;
            this.member_id = memberid;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_finish_Click(object sender, EventArgs e)
        {

            save_member f1 = new save_member(true);
           DialogResult res= f1.ShowDialog();
           if (res == System.Windows.Forms.DialogResult.Yes)
           {
               insert();
           }
           else { 
                
           }

        }

        private void button3_Click(object sender, EventArgs e)
        {
           // this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelPage2.Visible = true;
            panel2.Visible = false;
        }

        private void members_registration_2_Load(object sender, EventArgs e)
        {
            txt_defname.GotFocus += txt_defname_GotFocus;
            txt_defname.LostFocus += txt_defname_LostFocus;
            txt_defage.GotFocus += txt_defage_GotFocus;
            txt_defage.LostFocus += txt_defage_LostFocus;
            txt_defrel.GotFocus += txt_defrel_GotFocus;
            txt_defrel.LostFocus += txt_defrel_LostFocus;
            txt_defname2.GotFocus += txt_defname2_GotFocus;
            txt_defname2.LostFocus += txt_defname2_LostFocus;
            txt_defage2.GotFocus += txt_defage2_GotFocus;
            txt_defage2.LostFocus += txt_defage2_LostFocus;
            txt_defrel2.GotFocus += txt_defrel2_GotFocus;
            txt_defrel2.LostFocus += txt_defrel2_LostFocus;
            txt_defname3.GotFocus += txt_defname3_GotFocus;
            txt_defname3.LostFocus += txt_defname3_LostFocus;
            txt_defage3.GotFocus += txt_defage3_GotFocus;
            txt_defage3.LostFocus += txt_defage3_LostFocus;
            txt_defrel3.GotFocus += txt_defrel3_GotFocus;
            txt_defrel3.LostFocus += txt_defrel3_LostFocus;

            txt_aoccupation.GotFocus += txt_aoccupation_GotFocus;
            txt_aoccupation.LostFocus += txt_aoccupation_LostFocus;
            txt_workplace.GotFocus += txt_workplace_GotFocus;
            txt_workplace.LostFocus += txt_workplace_LostFocus;
            txt_spmonth.GotFocus += txt_spmonth_GotFocus;
            txt_spmonth.LostFocus += txt_spmonth_LostFocus;

            txt_spoccupation.GotFocus += txt_spoccupation_GotFocus;
            txt_spoccupation.LostFocus += txt_spoccupation_LostFocus;
            txt_sworkplace.GotFocus += txt_sworkplace_GotFocus;
            txt_sworkplace.LostFocus += txt_sworkplace_LostFocus;
            txt_sspmonth.GotFocus += txt_sspmonth_GotFocus;
            txt_sspmonth.LostFocus += txt_sspmonth_LostFocus;
           

            label6.Text = Properties.Settings.Default.username.ToUpper();
           // if (empID == "" || empID == "0")
           // {
                empID = Properties.Settings.Default.userid;
         //   }


                dbhandler.viewMemberDetailsExt(member_id, cb_EAL, txt_aoccupation, txt_workplace, txt_spmonth, txt_spoccupation, txt_sspmonth, txt_sworkplace);
                dbhandler.viewMemberDetailsBenef(member_id, txt_defname, txt_defage, txt_defrel, txt_defname2, txt_defage2, txt_defrel2, txt_defname3, txt_defage3, txt_defrel3, txt_defname4, txt_defage4, txt_defrel4, txt_defname5, txt_defage5, txt_defrel5, txt_defname6, txt_defage6, txt_defrel6);
        




        }

        #region miscmethods

   

        void txt_sspmonth_LostFocus(object sender, EventArgs e)
        {
            if (txt_sspmonth.Text.Trim() == "")
            {
                txt_sspmonth.Text = "Salary per Month";
            }
        }

        void txt_sspmonth_GotFocus(object sender, EventArgs e)
        {
            if (txt_sspmonth.Text.Trim() == "Salary per Month")
            {
                txt_sspmonth.Text = "";
            }
        }

        void txt_sworkplace_LostFocus(object sender, EventArgs e)
        {
            if (txt_sworkplace.Text.Trim() == "")
            {
                txt_sworkplace.Text = "Workplace";
            }
        }

        void txt_sworkplace_GotFocus(object sender, EventArgs e)
        {
            if (txt_sworkplace.Text.Trim() == "Workplace")
            {
                txt_sworkplace.Text = "";
            }
        }

        void txt_spoccupation_LostFocus(object sender, EventArgs e)
        {
            if (txt_spoccupation.Text.Trim() == "")
            {
                txt_spoccupation.Text = "Spouse's Occupation";
            }
        }

        void txt_spoccupation_GotFocus(object sender, EventArgs e)
        {
            if (txt_spoccupation.Text.Trim() == "Spouse's Occupation")
            {
                txt_spoccupation.Text = "";
            }
        }

        void txt_spmonth_LostFocus(object sender, EventArgs e)
        {
            if (txt_spmonth.Text.Trim() == "")
            {
                txt_spmonth.Text = "Salary per Month";
            }
        }

        void txt_spmonth_GotFocus(object sender, EventArgs e)
        {
            if (txt_spmonth.Text.Trim() == "Salary per Month")
            {
                txt_spmonth.Text = "";
            }
        }

        void txt_workplace_LostFocus(object sender, EventArgs e)
        {
            if (txt_workplace.Text.Trim() == "")
            {
                txt_workplace.Text = "Workplace";
            }
        }

        void txt_workplace_GotFocus(object sender, EventArgs e)
        {
            if (txt_workplace.Text.Trim() == "Workplace")
            {
                txt_workplace.Text = "";
            }
        }

        void txt_aoccupation_LostFocus(object sender, EventArgs e)
        {
            if (txt_aoccupation.Text.Trim() == "")
            {
                txt_aoccupation.Text = "Applicants Occupation";
            }
        }

        void txt_aoccupation_GotFocus(object sender, EventArgs e)
        {
            if (txt_aoccupation.Text.Trim() == "Applicants Occupation")
            {
                txt_aoccupation.Text = "";
            }
        }

        void txt_defrel3_LostFocus(object sender, EventArgs e)
        {
            if (txt_defrel3.Text.Trim() == "")
            {
                txt_defrel3.Text = "Relationship";
            }
        }

        void txt_defrel3_GotFocus(object sender, EventArgs e)
        {
            if (txt_defrel3.Text.Trim() == "Relationship")
            {
                txt_defrel3.Text = "";
            }
        }

        void txt_defage3_LostFocus(object sender, EventArgs e)
        {
            if (txt_defage3.Text.Trim() == "")
            {
                txt_defage3.Text = "Age";
            }
        }

        void txt_defage3_GotFocus(object sender, EventArgs e)
        {
            if (txt_defage3.Text.Trim() == "Age")
            {
                txt_defage3.Text = "";
            }
        }

        void txt_defname3_LostFocus(object sender, EventArgs e)
        {
            if (txt_defname3.Text.Trim() == "")
            {
                txt_defname3.Text = "Name";
            }
        }

        void txt_defname3_GotFocus(object sender, EventArgs e)
        {
            if (txt_defname3.Text.Trim() == "Name")
            {
                txt_defname3.Text = "";
            }
        }

        void txt_defrel2_LostFocus(object sender, EventArgs e)
        {
            if (txt_defrel2.Text.Trim() == "")
            {
                txt_defrel2.Text = "Relationship";
            }
        }

        void txt_defrel2_GotFocus(object sender, EventArgs e)
        {
            if (txt_defrel2.Text.Trim() == "Relationship")
            {
                txt_defrel2.Text = "";
            }
        }

        void txt_defage2_LostFocus(object sender, EventArgs e)
        {
            if (txt_defage2.Text.Trim() == "")
            {
                txt_defage2.Text = "Age";
            }
        }

        void txt_defage2_GotFocus(object sender, EventArgs e)
        {
            if (txt_defage2.Text.Trim() == "Age")
            {
                txt_defage2.Text = "";
            }
        }

        void txt_defname2_LostFocus(object sender, EventArgs e)
        {
            if (txt_defname2.Text.Trim() == "")
            {
                txt_defname2.Text = "Name";
            }
        }

        void txt_defname2_GotFocus(object sender, EventArgs e)
        {
            if (txt_defname2.Text.Trim() == "Name")
            {
                txt_defname2.Text = "";
            }
        }

        void txt_defrel_LostFocus(object sender, EventArgs e)
        {
            if (txt_defrel.Text.Trim() == "")
            {
                txt_defrel.Text = "Relationship";
            }
        }

        void txt_defrel_GotFocus(object sender, EventArgs e)
        {
            if (txt_defrel.Text.Trim() == "Relationship")
            {
                txt_defrel.Text = "";
            }
        }

        void txt_defage_LostFocus(object sender, EventArgs e)
        {
            if (txt_defage.Text.Trim() == "")
            {
                txt_defage.Text = "Age";
            }
        }

        void txt_defage_GotFocus(object sender, EventArgs e)
        {
            if (txt_defage.Text.Trim() == "Age")
            {
                txt_defage.Text = "";
            }
        }

        void txt_defname_LostFocus(object sender, EventArgs e)
        {
            if (txt_defname.Text.Trim() == "")
            {
                txt_defname.Text = "Name";
            }
        }

        void txt_defname_GotFocus(object sender, EventArgs e)
        {
            if (txt_defname.Text.Trim() == "Name") {
                txt_defname.Text = "";
            }
        }

        private void txt_defage_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_defage2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_defage3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion


        private void insert() {


           if (txt_spoccupation.Text.Trim() == "" || txt_spoccupation.Text.Trim() == "Spouse's Occupation")
           {
               txt_spoccupation.Text = "";              
           }

           if (txt_sworkplace.Text.Trim() == "" || txt_sworkplace.Text.Trim() == "Workplace")
           {
               txt_sworkplace.Text = "";
           }

           if (txt_sspmonth.Text.Trim() == "" || txt_sspmonth.Text.Trim() == "Salary per Month")
           {

               txt_sspmonth.Text = "";
           }


           bool b2 = false;
           if (txt_defname2.Text.Trim() != "" && txt_defname2.Text.Trim() != "Name")
           {
               if (txt_defage2.Text.Trim() != "" && txt_defage2.Text.Trim() != "Age")
               {
                   if (txt_defrel2.Text.Trim() != "" && txt_defrel2.Text.Trim() != "Relationship")
                   {
                       b2 = true;
                   }
               }
           }

           bool b3 = false;
           if (txt_defname3.Text.Trim() != "" && txt_defname3.Text.Trim() != "Name")
           {
               if (txt_defage3.Text.Trim() != "" && txt_defage3.Text.Trim() != "Age")
               {
                   if (txt_defrel3.Text.Trim() != "" && txt_defrel3.Text.Trim() != "Relationship")
                   {
                       b3 = true;
                   }
               }
           }

           bool b4 = false;
           if (txt_defname4.Text.Trim() != "" && txt_defname4.Text.Trim() != "Name")
           {
               if (txt_defage4.Text.Trim() != "" && txt_defage4.Text.Trim() != "Age")
               {
                   if (txt_defrel4.Text.Trim() != "" && txt_defrel4.Text.Trim() != "Relationship")
                   {
                       b4 = true;
                   }
               }
           }

           bool b5 = false;
           if (txt_defname5.Text.Trim() != "" && txt_defname5.Text.Trim() != "Name")
           {
               if (txt_defage5.Text.Trim() != "" && txt_defage5.Text.Trim() != "Age")
               {
                   if (txt_defrel5.Text.Trim() != "" && txt_defrel5.Text.Trim() != "Relationship")
                   {
                       b5 = true;
                   }
               }
           }

           bool b6 = false;
           if (txt_defname6.Text.Trim() != "" && txt_defname6.Text.Trim() != "Name")
           {
               if (txt_defage6.Text.Trim() != "" && txt_defage6.Text.Trim() != "Age")
               {
                   if (txt_defrel6.Text.Trim() != "" && txt_defrel6.Text.Trim() != "Relationship")
                   {
                       b6 = true;
                   }
               }
           }

           try {
               this.UseWaitCursor = true;
               Cursor.Current = Cursors.WaitCursor;
               Application.DoEvents();

               dbhandler.updateAMembers(member_id, lname.Replace("'", "`").Replace(";", ""), fname.Replace("'", "`").Replace(";", ""), mnane.Replace("'", "`").Replace(";", ""), address.Replace("'", "`").Replace(";", ""), provadd.Replace("'", "`").Replace(";", ""), addresstype.Replace("'", "`").Replace(";", ""), cellphone.Replace("'", "`").Replace(";", ""), tellphone.Replace("'", "`").Replace(";", ""), bday.Replace("'", "`").Replace(";", ""), bplace.Replace("'", "`").Replace(";", ""), age.Replace("'", "`").Replace(";", ""), gender.Replace("'", "`").Replace(";", ""), cstatus.Replace("'", "`").Replace(";", ""), religion.Replace("'", "`").Replace(";", ""), id.Replace("'", "`").Replace(";", ""), iddet.Replace("'", "`").Replace(";", ""), id2.Replace("'", "`").Replace(";", ""), id2det.Replace("'", "`").Replace(";", ""), cb_EAL.SelectedItem.ToString(), txt_aoccupation.Text.Replace("'", "`").Replace(";", ""), txt_workplace.Text.Replace("'", "`").Replace(";", ""), txt_spmonth.Text.Replace("'", "`").Replace(";", ""), txt_spoccupation.Text.Replace("'", "`").Replace(";", ""), txt_sworkplace.Text.Replace("'", "`").Replace(";", ""), txt_sspmonth.Text.Replace("'", "`").Replace(";", ""), ""
       , Int32.Parse(txt_defname.Tag.ToString()), txt_defname.Text.Replace("'", "`").Replace(";", ""), txt_defage.Text.Replace("'", "`").Replace(";", ""), txt_defrel.Text.Replace("'", "`").Replace(";", "")
       , b2, Int32.Parse(txt_defname2.Tag.ToString()), txt_defname2.Text.Replace("'", "`").Replace(";", ""), txt_defage2.Text.Replace("'", "`").Replace(";", ""), txt_defrel2.Text.Replace("'", "`").Replace(";", "")
       , b3, Int32.Parse(txt_defname3.Tag.ToString()), txt_defname3.Text.Replace("'", "`").Replace(";", ""), txt_defage3.Text.Replace("'", "`").Replace(";", ""), txt_defrel3.Text.Replace("'", "`").Replace(";", "")
       , b4, Int32.Parse(txt_defname4.Tag.ToString()), txt_defname4.Text.Replace("'", "`").Replace(";", ""), txt_defage4.Text.Replace("'", "`").Replace(";", ""), txt_defrel4.Text.Replace("'", "`").Replace(";", "")
       , b5, Int32.Parse(txt_defname5.Tag.ToString()), txt_defname5.Text.Replace("'", "`").Replace(";", ""), txt_defage5.Text.Replace("'", "`").Replace(";", ""), txt_defrel5.Text.Replace("'", "`").Replace(";", "")
       , b6, Int32.Parse(txt_defname6.Tag.ToString()), txt_defname6.Text.Replace("'", "`").Replace(";", ""), txt_defage6.Text.Replace("'", "`").Replace(";", ""), txt_defrel6.Text.Replace("'", "`").Replace(";", "")).ToString();


               message mes = new message("The Member Account\n was sucessfully updated");
               mes.ShowInTaskbar = false;
               mes.ShowDialog(this);

               members_form f = new members_form(empID);
               f.Show();
               this.Close();           
           
           }
           catch {
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
            label5.Text = "Today is " + a.ToString("MM-dd-yyyy") + " " + a.ToLongTimeString();
        }

        private void lbl_benefp2_Click(object sender, EventArgs e)
        {
            panelPage2.Visible = true;
            panel2.Visible = false;
        }

        private void lbl_page2ToPage1_Click(object sender, EventArgs e)
        {
            panelPage2.Visible = false;
            panel2.Visible = true; //p1
        }

        private void pb_applicants_Click(object sender, EventArgs e)
        {
            CapturePhoto cap = new CapturePhoto();
            DialogResult res = cap.ShowDialog(this);
            if (res == System.Windows.Forms.DialogResult.Cancel)
            {


                if (pb_applicants.Image != null)
                {
                    pb_applicants.Image.Dispose();
                }
                if (cap.capturedImage != null)
                {
                    Bitmap map = cap.capturedImage;
                    pb_applicants.Image = (Bitmap)map.Clone();

                    map.Dispose();
                    cap.capturedImage.Dispose();

                    cap.btn_cancel.PerformClick();
                    cap.Close();

                }


            }
            else
            {
                // MessageBox.Show("hahagha");
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





    }
}
