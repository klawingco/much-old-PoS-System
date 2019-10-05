using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace coop_main
{
    public partial class PreferencesForm : Form
    {
        string connString = "Server='localhost';Database='coopdb';User Id='root';Password='';";
        public PreferencesForm()
        {
            InitializeComponent();
        }

        private void loadPreferences() {
            txt_serverip.Text = Properties.Settings.Default.serverip;
            txt_serverhost.Text = "http://" + Properties.Settings.Default.serverip;
            txt_serverdb.Text = Properties.Settings.Default.database;
            txt_serverport.Text = Properties.Settings.Default.serverport;

            txt_connUserID.Text = Properties.Settings.Default.dbuserid;
            txt_connUserPass.Text = Properties.Settings.Default.dbpassword;

            connString = "Server='" + txt_serverip.Text.Trim() + "';Database='" + txt_serverdb.Text.Trim() + "';User Id='" + txt_connUserID.Text.Trim() + "';Password='" + txt_connUserPass.Text.Trim() + "';";
        }

        private void ping() {



            MySqlConnection db = new MySqlConnection(connString);
            MySqlCommand mySqlComm = new MySqlCommand();
            bool ping = false;
            try
            {
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                db.Open();
                ping =  db.Ping();

                db.Close();
            }
            catch (MySqlException xx)
            {
                message mes = new message("ERROR: Cannot connect to the server\n Pls. Check your network connection");
                System.Media.SystemSounds.Hand.Play();
                mes.ShowDialog(mes.Parent);
                MessageBox.Show(xx.Message);
                ping = false;
            }
            finally
            {
                this.UseWaitCursor = false;

                if(ping){
                    message mes = new message("SUCESS: You have successfully pinged the server");
                    System.Media.SystemSounds.Exclamation.Play();
                    mes.ShowDialog(mes.Parent);

                }
            }
        
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {
            loadPreferences();
        }

        private void btn_ping_Click(object sender, EventArgs e)
        {
            ping();
        }

        private void btn_saveEdit_Click(object sender, EventArgs e)
        {
            if(btn_saveEdit.Text == "EDIT"){
                btn_saveEdit.Text = "SAVE";

                txt_serverip.ReadOnly = false;
                txt_serverhost.ReadOnly = true;
                txt_serverdb.ReadOnly = false;
                txt_serverport.ReadOnly = false;

                txt_connUserID.ReadOnly = false;
                txt_connUserPass.ReadOnly = false;
            }
            else if (btn_saveEdit.Text == "SAVE")
            {
                System.Media.SystemSounds.Beep.Play();
                confirmstuffs conf = new confirmstuffs("Do you want to continue to save the changes?");
                DialogResult res =  conf.ShowDialog(this);

                if(res == System.Windows.Forms.DialogResult.Yes){
                    btn_saveEdit.Text = "EDIT";

                    Properties.Settings.Default.serverip = txt_serverip.Text;
                    //Properties.Settings.Default.serverip = txt_serverhost.Text;
                    Properties.Settings.Default.database = txt_serverdb.Text;
                    Properties.Settings.Default.serverport = txt_serverport.Text;

                    Properties.Settings.Default.dbuserid = txt_connUserID.Text;
                    Properties.Settings.Default.dbpassword = txt_connUserPass.Text;

                    Properties.Settings.Default.Save();

                    loadPreferences();

                    txt_serverip.ReadOnly = true;
                    txt_serverhost.ReadOnly = true;
                    txt_serverdb.ReadOnly = true;
                    txt_serverport.ReadOnly = true;

                    txt_connUserID.ReadOnly = true;
                    txt_connUserPass.ReadOnly = true;

                    System.Media.SystemSounds.Exclamation.Play();
                    message mes = new message("Successfully Saved");
                    mes.ShowDialog(this);
                
                }
 
            
            
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
