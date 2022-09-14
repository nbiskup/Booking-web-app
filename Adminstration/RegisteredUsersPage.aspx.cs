using RwaLib.DAL;
using RwaLib.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adminstration
{
    public partial class EditRegisterUser : System.Web.UI.Page
    {
        private User _user;
        private int userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("LogIn.aspx");
            userId = (int)Session["userId"];
            _user = ((DBRepo)Application["database"]).GetUserByID(userId);            
            LoadUser(_user);
        }

        private void LoadUser(User user)
        {
            txtUsername.Text = user.UserName;
            txtFname.Text = user.FirstName;
            txtLname.Text = user.LastName;
            txtAddress.Text = user.Address;
            txtEmail.Text = user.Email;
            txtPhonenumber.Text = user.PhoneNumber;
        }              

        protected void lblBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisteredUsers.aspx");
        }
    }
}