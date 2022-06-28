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

//DEPOSIT MODULE
//Requirements
//- Maximum amount to be deposited per transaction is 2,000.00 only
// - Minimum amount to be deposited per transaction is 100.00
//- Amount must be divisible by 100.00
//- Each depositor’s total current balance must not exceed 10,000.00
namespace WEBFORM
{
    public partial class WebForm3 : System.Web.UI.Page
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
        protected void deposit_Click(object sender, EventArgs e)
        {
            string user = Session["userName"].ToString();
            double amtdpst = Convert.ToDouble(txtdpst.Text);


            string type = "DEPOSIT";
            string sendto = "";

            if (amtdpst % 100 == 0)
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
                        cmd.Parameters.AddWithValue("@amt", amtdpst);
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
                            Response.Write("<script>alert('Oooppss.. Something Went Wrong!')</script>");
                        }
                    }

                }
            }

            else
            {
                Response.Write("<script>alert('Amount to be Deposit should be divisible by 100')</script>");
            }
        }
        void getBalance()
        {
            string user = Session["userName"].ToString();
            int id =Convert.ToInt32(Session["id"]);
            double amount = Convert.ToDouble(Session["bal"]);
            double dpstamt = Convert.ToDouble(txtdpst.Text);
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
                        totalamt = amount + dpstamt;

                        db.Close();
                        db.Open();

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText ="UPDATE USERTBL SET BALANCE = '" + totalamt + "' WHERE Id = '" + id + "'";
                        cmd.ExecuteNonQuery();

                    }

                }

            }
        }
        
    }
}
