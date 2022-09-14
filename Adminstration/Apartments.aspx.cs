using RwaLib.DAL;
using RwaLib.MODELS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adminstration
{
    public partial class Apartments : System.Web.UI.Page
    {
        private IList<Apartment> _apartmentsList;
        private IList<Status> _getStatuses;              

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("LogIn.aspx");

            if (!IsPostBack)
            {
                ShowApartments();
                RebindApartments();
            }            
        }

        private void ShowApartments()
        {
            _apartmentsList = ((DBRepo)Application["database"]).GetAllApartments();            
            _getStatuses = ((DBRepo)Application["database"]).GetStatuses();

            rptApartments.DataSource = _apartmentsList;
            rptApartments.DataBind();
            ddlStatus.DataSource = _getStatuses;
            ddlStatus.DataBind();
        }

        private void RebindApartments()
        {
            int statusId = int.Parse(ddlStatus.SelectedValue);
            if (statusId==0)
            {
                rptApartments.DataSource = ((DBRepo)Application["database"]).GetAllApartments();
                rptApartments.DataBind();
            }
            else
            {
                rptApartments.DataSource = ((DBRepo)Application["database"]).GetAllApartmentsByStatusId(statusId);
                rptApartments.DataBind();
            }
        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            int apartmentId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Session["ApartmentId"] = apartmentId;
            Response.Redirect("ApartmentPage.aspx");
        }

        protected void lbAddApartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewApartment.aspx");
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RebindApartments();
        }

    }
}