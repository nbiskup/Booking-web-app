using RwaLib.DAL;
using RwaLib.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adminstration.App_UserControls
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        User admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new User { UserName="admin",Password="admin"};

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            //Preko baze

            if (Page.IsValid)
            {
                var username = txtUsername.Text;
                var password = Cryptography.HashPassword(txtPassword.Text);
                User user = ((DBRepo)Application["database"]).AuthUser(username, password);


                if (user == null)
                {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    PanelIspis.Visible = true;
                }
                else
                {
                    Session["user"] = user;
                    Response.Redirect("Apartments.aspx");
                }

            }



            //Hardkodiran admin

            //if (Page.IsValid)
            //{


            //    if (txtUsername.Text == admin.UserName && txtPassword.Text == admin.Password)
            //    {
            //        Session["user"] = admin;
            //        Response.Redirect("Apartments.aspx");
            //    }

            //    else
            //    {
            //        txtUsername.Text = "";
            //        txtPassword.Text = "";
            //        PanelIspis.Visible = true;
            //    }
            //}
        }
    }
}