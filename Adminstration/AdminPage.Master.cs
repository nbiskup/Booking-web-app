using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adminstration
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"]==null)
            {
                pnlRegisteredUser.Visible = false;
                pnlUnregisteredUser.Visible = true;
            }
            else pnlUnregisteredUser.Visible = false;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("LogIn.aspx");
        }
    }
}