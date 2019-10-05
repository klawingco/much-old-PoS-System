using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;



using MySql.Data.MySqlClient;

namespace coop_main
{
    class ProductInfo
    {
        private String prod_desc,prod_pkg_net_wt,prod_exp_date,prod_code,prod_cat,prod_uom;
        private int qty, id;
        private double u_cost,s_price;
        string hostIP = "localhost";
        string UserID = "root";
        string PassID = "";

        string connString = "Server='localhost';Database='coopdb';User Id='root';Password='';";
        MySqlConnection db;
        public void ProductInfoz(String item_code)
        {
            hostIP = Properties.Settings.Default.serverip.Trim();
            UserID = Properties.Settings.Default.dbuserid.Trim();
            PassID = Properties.Settings.Default.dbpassword.Trim();

            connString = "Server='"+hostIP+"';Database='coopdb';User Id='"+UserID+"';Password='"+PassID+"';";
            db = new MySqlConnection(connString);

                string sql = "SELECT * FROM tbl_items where item_code = '" + item_code + "'";

                try
                {
                    db.Open();

                    MySqlCommand mySqlComm = new MySqlCommand(sql, db);
                    using (MySqlDataReader read = mySqlComm.ExecuteReader())
                    {
                        if (!read.HasRows)
                        {
                            id = 0;
                            prod_desc = "";
                            prod_pkg_net_wt = "";
                            prod_exp_date = "";
                            prod_code = "";
                            prod_cat = "";
                            prod_uom = "";
                            qty = 0;
                            u_cost = 0;
                            s_price = 0;
                        }
                        while (read.Read())
                        {
                            id = Int32.Parse(read["item_id"].ToString());
                            prod_desc = read["item_desc"].ToString();
                            prod_pkg_net_wt = read["net_weight"].ToString();
                            prod_exp_date = read["expiration_date"].ToString();
                            prod_code = read["item_code"].ToString();
                            prod_cat = read["category"].ToString();
                            prod_uom = read["unit_measurement"].ToString();
                            qty = Int32.Parse(read["quantity"].ToString());
                            u_cost = double.Parse(read["unit_cost"].ToString());
                            s_price = double.Parse(read["selling_price"].ToString());
                        }
                    }
                }
                finally
                {
                    db.Close();
                }

        }
  
        public String ProductPkgNtWt()
        {
            return prod_pkg_net_wt;
        }
        public String ExpDate()
        {
            return prod_exp_date;
        }
        public String ProductDescription()
        {
            return prod_desc;
        }
        public String ProductCode()
        {
            return prod_code;
        }
        public String ProductCat()
        {
            return prod_cat;
        }
        public String ProductUom()
        {
            return prod_uom;
        }
        public int Quantity()
        {
            return qty;
        }
        public Double UnitCost()
        {
            return u_cost;
        }
        public Double SellingPrice()
        {
            return s_price;
        }
        public int ID()
        {
            return id;
        }
    }
}
