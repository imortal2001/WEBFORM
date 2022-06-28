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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string connDB = WebConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string user = Session["userName"].ToString();
            }
            catch
            {
                Response.Redirect("Log_In");
            }
        }
        protected void withdraw_Click(object sender, EventArgs e)
        {

            string user = Session["userName"].ToString();
            double bal = Convert.ToDouble(Session["bal"]);
            double amt_withdraw = Convert.ToDouble(txtwthdrw.Text);

            string type = "WITHDRAW";
            string sendto = "";



            if (amt_withdraw > bal )
            {
                string error = "insufficient Amount";
                errorMessage.Text = error;
            }
            else if(amt_withdraw <= 0)
            {
                string error = "Withdraw Amount should be Greater than Zero";
                errorMessage.Text = error;
            }
            else
            {
                using (var db = new SqlConnection(connDB))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO TRANSTBL (TYP, TDATE, AMT, SENDTO, USERNAME) "
                            + " VALUES (@type,@date,@amt,@sendto,@username)";

                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@amt", amt_withdraw);
                        cmd.Parameters.AddWithValue("@sendto", sendto);
                        cmd.Parameters.AddWithValue("@username", user);

                        var ctr = cmd.ExecuteNonQuery();
                        if (ctr > 0)
                        {

                            Response.Write("<script>alert('Transaction Complete');document.location = 'Dashboard.aspx'</script>");
                            getBalance();
                        }
                        else
                        {
                            Response.Write("<script>alert('Oooppss.. Something Wrong!')</script>");
                        }
                    }

                }
            }
        }

        void getBalance()
        {
            string user = Session["userName"].ToString();
            double amount = Convert.ToDouble(Session["bal"]);
            double wthdrw = Convert.ToDouble(txtwthdrw.Text);
            double totalamt = 0;

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM TRANSTBL WHERE USERNAME = '" + user + "' ";
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        totalamt = amount - wthdrw;

                        db.Close();
                        db.Open();

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE USERTBL SET BALANCE = '" + totalamt + "' WHERE USERNAME = '" + user + "'";
                        cmd.ExecuteNonQuery();

                    }

                }

            }
        }
    }
}