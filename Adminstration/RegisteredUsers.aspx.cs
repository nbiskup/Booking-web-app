using RwaLib.DAL;
using RwaLib.MODELS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adminstration
{
    public partial class RegisteredUsers : System.Web.UI.Page
    {
        private IList<User> _listOfAllUsers;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("LogIn.aspx");
            _listOfAllUsers = ((DBRepo)Application["database"]).GetAllUsers();           

            if (!IsPostBack)
            {
                ShowUsers();                
            }
        }

        private void ShowUsers()
        {
            rptUsers.DataSource = _listOfAllUsers;
            rptUsers.DataBind();
        }

        protected void OpenUser_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Session["userId"] = userId;
            Response.Redirect("RegisteredUsersPage.aspx");
        }
    }
}