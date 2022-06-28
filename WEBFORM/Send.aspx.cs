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
    public partial class Send : System.Web.UI.Page
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
        protected void btn_Send(object sender, EventArgs e)
        {

            string user = Session["userName"].ToString();
            double amtsend = Convert.ToDouble(amount.Text);
            double bal = Convert.ToDouble(Session["bal"]);
            string type = "TRANSFER";
            string sendto = userTransfer.Text;



            if (amtsend > bal)
            {
                string error = "insufficient Amount";
                errorMessage.Text = error;
            }
            else if (amtsend <= 0)
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
                        cmd.Parameters.AddWithValue("@amt", amtsend);
                        cmd.Parameters.AddWithValue("@sendto", sendto);

                        cmd.Parameters.AddWithValue("@username", user);

                        var ctr = cmd.ExecuteNonQuery();
                        if (ctr > 0)
                        {


                            Response.Write("<script>alert('Transfer Complete');document.location = 'Dashboard.aspx'</script>");

                            getSenderBalance();

                            getReceiverBalance();

                        }
                        else
                        {
                            Response.Write("<script>alert('Oooppss.. Something Wrong!')</script>");
                        }
                    }

                }
            }

        }
        void getSenderBalance()
        {
            string sender = Session["userName"].ToString();
        
            double bal = Convert.ToDouble(Session["bal"]);
            double amtsend = Convert.ToDouble(amount.Text);
            double totalamt = 0;
           

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM TRANSTBL WHERE USERNAME= '" + sender  + "'";
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        totalamt = bal - amtsend;

                        


                        db.Close();
                        db.Open();

                        cmd.CommandText = "UPDATE USERTBL SET BALANCE = '" + totalamt + "' WHERE USERNAME = '" + sender+ "'";
                        cmd.ExecuteNonQuery();

                       

                    }

                }

            }
        }

       
        
            void getBalance()
            {
                string user = userTransfer.Text;
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
                            Session["receiverBal"] = reader["BALANCE"].ToString();
                        }

                    }
                }

            }
        
    
        void getReceiverBalance()
        {
            getBalance();

            string sender = Session["userName"].ToString();

            double currBal = Convert.ToDouble(Session["receiverBal"]);

            string receiver = userTransfer.Text;

            double amtsend = Convert.ToDouble(amount.Text);
            
            double amtTotal = 0;

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "SELECT * FROM TRANSTBL WHERE SENDTO= '" + receiver + "'";

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    if (reader.Read())
                    {
                       
                          amtTotal = currBal + amtsend;

                            db.Close();
                            db.Open();

                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE USERTBL SET BALANCE = '" + amtTotal + "' WHERE USERNAME = '" + receiver + "'";
                            cmd.ExecuteNonQuery();
                        }
                       

                    }

                }

            }
        }
    }
