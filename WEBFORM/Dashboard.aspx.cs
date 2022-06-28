using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.IO;
using System.Data;


namespace WEBFORM
{
    public partial class Dashboard : System.Web.UI.Page
    {
        string connDB = WebConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
               try 
            {
                string user = Session["userName"].ToString();
                getBalance();
            }
            catch 
            {
                Response.Redirect("Log_In");
            }
        }
        //function that will get the balance
        void getBalance()
        {
            string user = Session["userName"].ToString();
            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM USERTBL WHERE USERNAME = '" + user + "' ";
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Session["bal"] = reader["BALANCE"].ToString();
                        Session["id"] = reader["ID"].ToString();
                    }

                }

            }
        }
    }
}
