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
    public partial class initial_deposit : Form
    {
        List<String> custId = new List<String>();
        DatabaseStuff dbhandler = new DatabaseStuff();
        String customerId;

        String empID;


        private long depositNumber = 0;
        private decimal previousSavings = 0;
        private decimal currentSavings = 0;
      

        public initial_deposit(String empID)
        {
            InitializeComponent();
            this.empID = empID;
        }

        private void initial_deposit_Load(object sender, EventArgs e)
        {
            txt_processBy.Text = dbhandler.getEmployeeDetails(empID);

            txt_processDate.Text = DateTime.Now.ToString();
            txt_name.GotFocus += txt_name_GotFocus;
            txt_name.LostFocus += txt_name_LostFocus;


           // if (empID.Trim() == "")
           // {
                empID = Properties.Settings.Default.userid;
           // }

                
        }

        void txt_name_LostFocus(object sender, EventArgs e)
        {
            if (txt_name.Text.Trim() == "")
            {
                txt_name.Text = " Customer's Name";
            }
        }

        void txt_name_GotFocus(object sender, EventArgs e)
        {
            if (txt_name.Text.Trim() == "Customer's Name")
            {
                txt_name.Text = "";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            System.Media.SystemSounds.Beep.Play();
            confirmstuffs newDep = new confirmstuffs("Do you want to cancel deposit?");
            DialogResult res = newDep.ShowDialog(this);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }

            
        }


        private void printstuffs() {

            //printing stuffs
            PrintPreviewDialog preview = new PrintPreviewDialog();

            PrintDialog diag = new PrintDialog();
            PrintDocument document = new PrintDocument();
            preview.Document = document;
            diag.Document = document;
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
            document.DocumentName = "DEPOST";

            diag.ShowDialog(this);
        }


        private void button4_Click(object sender, EventArgs e)
        {

            if (txt_name.Text != " Customer's Name" && customerId != "" &&  txt_initialDep.Text != "" )
            {
                initial_deposit_confirm f1 = new initial_deposit_confirm(txt_name.Text, txt_initialDep.Text);
                DialogResult res = f1.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.OK)
                {


                    try { 
                    previousSavings = decimal.Parse(dbhandler.getCurrentMemberSavings(customerId));
                    long success = dbhandler.newDeposit(customerId, empID, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), decimal.Parse(txt_initialDep.Text));
                    if (success > 0)
                    {
                        currentSavings = decimal.Parse(dbhandler.getCurrentMemberSavings(customerId));
                        depositNumber = success;

                        //printing stuffs
                        printstuffs();
                        bool reprintThis = false;
                        while (!reprintThis)
                        {

                            sucessprintmessage reprintForm = new sucessprintmessage();
                            reprintForm.ShowInTaskbar = false;
                            DialogResult resz = reprintForm.ShowDialog(this);
                            if (resz == System.Windows.Forms.DialogResult.No)
                            {
                                printstuffs();
                            }
                            else if (resz == System.Windows.Forms.DialogResult.Yes)
                            {
                                reprintThis = true;
                            }


                        }



                        message mes = new message("The amount " + decimal.Parse(txt_initialDep.Text).ToString("N") + " was successfully deposited.");
                        mes.ShowInTaskbar = false;
                        mes.ShowDialog(this);

                        this.Close();
                    }

                    }
                    catch {
                        message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                        mes.ShowDialog(mes.Parent);
                    
                    }




                }

            }
            else {
                message mes = new message("Please complete the deposit form.");
                mes.ShowInTaskbar = false;
                mes.ShowDialog(this);
            }
            
            
      
        }

        //print stuffs cont
        protected void document_PrintPage(object sender, PrintPageEventArgs ev)
        {

            try
            {
                int offset = 65;
                Font printFont = new Font("Courier New", 8);
                ev.Graphics.DrawString("DEPOSIT RECEIPT", new Font("Courier New", 13), new SolidBrush(Color.Black), 30, 30);
                ev.Graphics.DrawString("-COOP NAME-", new Font("Courier New", 13), new SolidBrush(Color.Black), 30, 50);




                offset += 30;
                ev.Graphics.DrawString("DEPOSIT RECEIPT NO...... " + depositNumber.ToString("D4"), printFont, new SolidBrush(Color.Black), 30, offset);

                offset += 30;
                ev.Graphics.DrawString("AMOUNT DEPOSIT...... " + decimal.Parse(txt_initialDep.Text).ToString("N"), printFont, new SolidBrush(Color.Black), 30, offset);

                offset += 30;
                ev.Graphics.DrawString("PREVIOUS SAVINGS...... " + previousSavings.ToString("N"), printFont, new SolidBrush(Color.Black), 30, offset);

                offset += 30;
                ev.Graphics.DrawString("CURRENT SAVINGS...... " + currentSavings.ToString("N"), printFont, new SolidBrush(Color.Black), 30, offset);

                offset += 45;
                ev.Graphics.DrawString("THIS SERVES AS YOUR OFFICIAL DEPOSIT RECEIPT", new Font("Courier New", 10), new SolidBrush(Color.Black), 30, offset);

                offset += 45;
                ev.Graphics.DrawString("RELEASE BY : " + txt_processBy.Text, new Font("Courier New", 8), new SolidBrush(Color.Black), 30, offset);

                offset += 12;
                ev.Graphics.DrawString("PROCESS DATE : " + txt_processDate.Text, new Font("Courier New", 8), new SolidBrush(Color.Black), 30, offset);

                offset += 12;
                ev.Graphics.DrawString("MEMBER NAME : " + txt_name.Text, new Font("Courier New", 8), new SolidBrush(Color.Black), 30, offset);

                offset += 12;
                ev.Graphics.DrawString("MEMBER NO : " + Int32.Parse(customerId).ToString("D4"), new Font("Courier New", 8), new SolidBrush(Color.Black), 30, offset);

                offset += 12;
                ev.Graphics.DrawString("------------", new Font("Courier New", 8), new SolidBrush(Color.Black), 30, offset);



            }
            catch (Exception err)
            {
                MessageBox.Show(this, "An error has occured while printing the receipt.\nThe transaction was not recorded \n" + err.Message, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }
        //




        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (listBox1.Items.Count > 0)
                {

                    txt_name.Text = listBox1.SelectedItem.ToString();

                    if (listBox1.SelectedIndex == 0)
                    {
                        customerId = custId[0].ToString();
                    }
                    else if (listBox1.SelectedIndex > 0) {
                        customerId = custId[listBox1.SelectedIndex].ToString();
                    }

                  //  MessageBox.Show(customerId);
                    txt_name.ReadOnly = true;

                    listBox1.Visible = false;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_processDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_newDep_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            confirmstuffs newDep = new confirmstuffs("Do you want to clear all fields?");
            DialogResult res = newDep.ShowDialog(this);
            if(res == System.Windows.Forms.DialogResult.Yes){
                txt_name.Text = " Customer's Name";
                txt_name.ReadOnly = false;
                txt_initialDep.Text = "";
                customerId = "";
                txt_processDate.Text = DateTime.Now.ToString();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_processBy_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void txt_initialDep_TextChanged(object sender, EventArgs e)
        {
            try {
                int startPos = txt_initialDep.SelectionStart;
                decimal initial = decimal.Parse(txt_initialDep.Text);
                txt_initialDep.Text = initial.ToString("#,##0");
                txt_initialDep.SelectionStart = txt_initialDep.Text.Length;
            }
            catch { }
            
        }

        private void btn_thumb_Click(object sender, EventArgs e)
        {

        }

        private void txt_initialDep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
            {
                if (txt_name.Text.Trim() != "")
                {

                    dbhandler.searchMemberEmployee(txt_name.Text.Replace("'","`"), listBox1, custId);

                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {

                txt_name.Text = listBox1.SelectedItem.ToString();

                if (listBox1.SelectedIndex == 0)
                {
                    customerId = custId[0].ToString();
                }
                else if (listBox1.SelectedIndex > 0)
                {
                    customerId = custId[listBox1.SelectedIndex].ToString();
                }

                //  MessageBox.Show(customerId);
                txt_name.ReadOnly = true;

                listBox1.Visible = false;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
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

     










    }
}
