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
    public partial class loan_calculator : Form
    {
        String enddate;
        public loan_calculator()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            try {
                if (txt_amount.Text.Trim() != "" && comboBox1.SelectedIndex != -1 && txt_interest.Text.Trim() != "")
                {
                    decimal printamount = decimal.Parse(txt_amount.Text);
                    double rate = double.Parse(txt_interest.Text);
                    decimal tot = decimal.Parse(txt_amount.Text) - (decimal.Parse(txt_amount.Text) * (decimal.Parse(rate.ToString()) / 100)); // rwith interest
                    int duration = Int32.Parse(txt_duration.Text);
                    deto();
                    loan_calculator_2 f1 = new loan_calculator_2();

                    f1.listBox1.Items.Add("Loan Amount : " + printamount.ToString("N"));
                    f1.listBox1.Items.Add("Interest : " + rate.ToString() + "%");
                    f1.listBox1.Items.Add("Total Amount : " + tot.ToString("N"));
                    f1.listBox1.Items.Add("Start Date : " + dateTimePicker1.Value.ToShortDateString());
                    f1.listBox1.Items.Add("End Date : " + enddate);



                    f1.txt_startDate.Text = (printamount / duration).ToString("N");

                   

                    DialogResult res =  f1.ShowDialog();

                   if(res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Cancel){
                       f1.Close();
                       this.Close();
                   }

                }
           
            }
            catch { }
          
        }


        private void deto()
        {
            try
            {

                if (txt_duration.Text.Trim() != "")
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        int howmanyadd = Int32.Parse(txt_duration.Text);

                        enddate = dateTimePicker1.Value.AddMonths(howmanyadd).ToShortDateString();
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        int howmanyadd = Int32.Parse(txt_duration.Text) * 4;

                        enddate = dateTimePicker1.Value.AddMonths(howmanyadd).ToShortDateString();
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        int howmanyadd = Int32.Parse(txt_duration.Text) * 6;

                        enddate = dateTimePicker1.Value.AddMonths(howmanyadd).ToShortDateString();
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        int howmanyadd = Int32.Parse(txt_duration.Text);

                        enddate = dateTimePicker1.Value.AddYears(howmanyadd).ToShortDateString();
                    }
                }
            }
            catch { }



        }

        private void loan_calculator_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void txt_amount_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    int startPos = txt_amount.SelectionStart;
            //    decimal initial = decimal.Parse(txt_amount.Text);
            //    txt_amount.Text = initial.ToString("#,##0");
            //    //if (txt_amount.SelectionStart >= txt_amount.Text.IndexOf("."))
            //    //{
            //    //    txt_amount.SelectionStart = startPos;
            //    //}
            //    //else
            //    //{
            //    //    txt_amount.SelectionStart = txt_amount.Text.IndexOf(".");
            //    //}

            //    txt_amount.SelectionStart = startPos;

            //}
            //catch { }
        }

        private void txt_interest_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_amount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                {
                    int startPos = txt_amount.SelectionStart;
                    decimal initial = decimal.Parse(txt_amount.Text);
                    txt_amount.Text = initial.ToString("#,##0");
                    txt_amount.SelectionStart = startPos;
                }
                else {
                    int startPos = txt_amount.SelectionStart;
                    decimal initial = decimal.Parse(txt_amount.Text);
                    txt_amount.Text = initial.ToString("#,##0");
                    txt_amount.SelectionStart = startPos + 1;
                }
             
            }
            catch { }
        }




    }
}
