using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBFORM
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Session.Clear();
            Session.Abandon();
           
            Response.Write("<script>alert('User Has log Out!');document.location = 'default.aspx'</script>");

        }

    }
}