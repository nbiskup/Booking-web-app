using RwaLib.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Adminstration
{
    public class Global : System.Web.HttpApplication
    {
        private readonly IRepo repo;

        public Global()
        {
            repo = RepoFactory.GetRepo();
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["database"] = repo;
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Response.Redirect("Apartments.aspx");
        }
    }
}