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
    public partial class About : Page
    {
        string connDB = WebConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
         if(!IsPostBack)
                clndrbdate.Visible = false;
            
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            
            string last_Name = lName.Text;
            string first_Name = fName.Text;
            string mobile_Num = mobNum.Text;   
            string birth_Date = birthDate.Text;
            string username = user.Text;
            string userpass = pass.Text;
            double bal = 2000;

                using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand()) 
                {
                    cmd.CommandType= CommandType.Text;
                    cmd.CommandText = "SELECT * FROM USERTBL WHERE USERNAME = '"+username+"'";
                    cmd.Connection = db;
                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        rd.Close();


                        string error = "Username is already taken.";
                        UsernameError.Text = error;

                    }
                   
                    else
                    { 

                       
                        db.Close();
                        db.Open();

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO USERTBL (LNAME ,FNAME, MOBNUMBER, BIRTHDATE, USERNAME, PASSWORD, BALANCE )"
                        + "VALUES (@lname, @fname,@mobnumber,@birthdate, @username, @password, @balance)";
                        cmd.Parameters.AddWithValue("@lname", last_Name);
                        cmd.Parameters.AddWithValue("@fname", first_Name);
                        cmd.Parameters.AddWithValue("@mobnumber", mobile_Num);
                        cmd.Parameters.AddWithValue("@birthdate", birth_Date);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", userpass);
                        cmd.Parameters.AddWithValue("@balance", bal);

                       
                    }
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        Response.Write("<script>alert('Registered Successfully!');document.location = 'Log_In'</script>");
                    }

                }
                db.Close();
            }

        }


        protected void clndrbdate_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Today)
            {
                e.Day.IsSelectable = false;
            }
        }
        protected void clndrbdate_SelectionChanged(object sender, EventArgs e)
        {
            birthDate.Text = clndrbdate.SelectedDate.ToShortDateString();
            clndrbdate.Visible = false;
        }
       
        protected void imgbtncldr_Click(object sender, ImageClickEventArgs e)
        {
            if (clndrbdate.Visible)
                clndrbdate.Visible =false;
            else
                clndrbdate.Visible = true;
        }
         
    }
}