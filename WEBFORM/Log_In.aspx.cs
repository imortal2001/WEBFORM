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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connDB = WebConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_logIn(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM USERTBL WHERE USERNAME = '" + user + "' AND PASSWORD = '" + pass + "'";
                    SqlDataReader rd = cmd.ExecuteReader();
                    
                    if(rd.Read())
                    {
                        Session["userName"] = rd["USERNAME"].ToString();
                        
                        Response.Write("<script>alert('User Has log In!');document.location = 'Dashboard.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<Script>alert('Invalid Account')</script>");
                    }

                }
            }
        }
       
            }

        }
  

