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
    public partial class WebForm5 : System.Web.UI.Page
    {
        string connDB = WebConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
        protected void custom_Display(object sender, EventArgs e)
        {
            if (btnCancel.Visible && customEnter.Visible)
            {
                customEnter.Visible = false;
                btnCancel.Visible = false;
            } 
            else
            {
                customEnter.Visible = true;
                btnCancel.Visible = true;
                btn.Visible = false;
                getUser_Search();

            }
        }
        void getSearchUser()

        {
            string findUser = searchBox.Text;

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM TRANSTBL WHERE USERNAME = '" + findUser + "'";
                    cmd.Connection = db;
                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.Read())
                    {
                        Session["findUser"] = rd["USERNAME"].ToString();

                    }
                }
            }
        }
        void getUser_Search()

        {
            getSearchUser();

            string findUser = searchBox.Text;

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                SqlCommand cmd = new SqlCommand();
                string sql = "SELECT * FROM TRANSTBL WHERE USERNAME='" + findUser + "'";
                cmd.CommandText = sql;
                cmd.Connection = db;
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt); //Use the Fill method of SqlDataAdapter object to fill the DataSet with the result of query string.
                gvMyAccnt.DataSource = dt; //Create a new row with specified values and add to the data row collection.  
                gvMyAccnt.DataBind(); //Gets or sets the object from which the data-bound control retrieves its list.
                db.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                searchBox.Visible = false;
                btnCancel.Visible = false;
                customEnter.Visible = false;                      
            try
            {
                string user = Session["userName"].ToString();
            }
            catch
            {
                Response.Redirect("Log_In");
            }
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            

            if (btnCancel.Visible && btnCustom.Visible) 
            {
                btnCancel.Visible = false;
                btnCustom.Visible = false;
            }
            else 
            {
                btnCancel.Visible = true;
                btnCustom.Visible = false;

                using (var db = new SqlConnection(connDB))

                {
                    db.Open();
                    SqlCommand cmd = new SqlCommand();
                    string sql = "SELECT * FROM TRANSTBL ";
                    cmd.CommandText = sql;
                    cmd.Connection = db;
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt); //Use the Fill method of SqlDataAdapter object to fill the DataSet with the result of query string.
                    gvMyAccnt.DataSource = dt; //Create a new row with specified values and add to the data row collection.  
                    gvMyAccnt.DataBind(); //Gets or sets the object from which the data-bound control retrieves its list.
                    db.Close();
                }
            }

        }
        protected void custom_Click(object sender, EventArgs e)
        {
            if (btnCancel.Visible && searchBox.Visible && btn.Visible && customEnter.Visible)
            {
                searchBox.Visible = false;
                btnCancel.Visible = false;
                customEnter.Visible = false;
                btn.Visible = false;
            }
            else
            {
                searchBox.Visible = true;
                btnCancel.Visible = true;
                btn.Visible = false;
                customEnter.Visible = true; 
            }

        }
        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("History");
        }
    }
}
