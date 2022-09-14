using RwaLib.DAL;
using RwaLib.MODELS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adminstration
{
    public partial class ApartmentPage : System.Web.UI.Page
    {
        private Apartment _apartment;
        private int apartmentId;
        private IList<ApartmentPicture> pictureList;
        private string _picPath = "/Images/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("LogIn.aspx");
            apartmentId = (int)Session["ApartmentId"];
            _apartment = ((DBRepo)Application["database"]).GetApartmentByID(apartmentId);

            if (!IsPostBack)
            {               
                LoadApartment(_apartment);
            }
        }      

        private void LoadApartment(Apartment apartment)
        {
            txtApartmentsName.Text = apartment.NameEng;
            txtPrice.Text = apartment.Price.ToString();
            txtNumberOfRooms.Text = apartment.TotalRooms.ToString();
            txtAdult.Text = apartment.MaxAdults.ToString();
            txtChildren.Text = apartment.MaxChildren.ToString();
            txtBeachDistance.Text = apartment.BeachDistance.ToString();
            ddlStatus.SelectedValue = apartment.StatusId.ToString();
            ddlApartmentOwner.SelectedValue = apartment.OwnerId.ToString();
            txtAddress.Text = apartment.Address;            
            
            ddlStatus.Items.Clear();

            ddlStatus.DataSource = ((DBRepo)Application["database"]).GetStatuses();
            ddlStatus.DataBind();

            Status status = new Status();
            status.Id = ((DBRepo)Application["database"]).GetApartmentStatus(apartment.Id);
            ddlStatus.SelectedIndex = status.Id;

            UserLoad(status.Id);

            ApartmentOwner aptOwner = ((DBRepo)Application["database"]).GetApartmentOwnerById(apartment.OwnerId);
            IList<ApartmentOwner> apartmentOwners = ((DBRepo)Application["database"]).GetApartmentOwners();
            ddlApartmentOwner.Items.Clear();           

            foreach (ApartmentOwner apartmentOwner in apartmentOwners)
            {
                ddlApartmentOwner.Items.Add(apartmentOwner.Name);
            }

            ddlApartmentOwner.SelectedIndex= aptOwner.Id-1;

            pictureList = ((DBRepo)Application["database"]).GetApartmentPicturesByID(apartmentId);            
            rptApartmentPictures.DataSource = pictureList;
            rptApartmentPictures.DataBind();

            GetApartmentTags();
        }


        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dropDown = (DropDownList)sender;
            dropDown.SelectedIndex = ddlStatus.SelectedIndex;
            
            UserLoad(ddlStatus.SelectedIndex);
            
        }

        private void UserLoad(int statusId)
        {
            if (statusId != 3)
            {
                var user = ((DBRepo)Application["database"]).GetUserByID(apartmentId);
                if (user != null)
                {
                    pnlRegisteredUser.Visible = true;
                    ddlRegisteredUsers.Items.Clear();
                    ddlRegisteredUsers.DataSource = ((DBRepo)Application["database"]).GetAllUsers();
                    ddlRegisteredUsers.DataBind();

                    ddlRegisteredUsers.SelectedIndex = user.Id;
                    txtDetailsReg.Text= user.Details;
                }
                else
                {
                    pnlUnregisteredUser.Visible = true;
                    user = ((DBRepo)Application["database"]).GetUnregisteredUser(apartmentId);
                    txtUsername.Text = user.UserName;
                    txtUserAddress.Text= user.Address;
                    txtDetailsUnreg.Text=user.Details;
                    txtEmail.Text= user.Email;
                    txtPhoneNumber.Text = user.PhoneNumber;
                }
                return;
            }
            pnlUnregisteredUser.Visible = false;
            pnlRegisteredUser.Visible = false;
            //((DBRepo)Application["database"]).DeleteApartmentReservation(apartmentId);
        }

        protected void ddlApartmentOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dropDown = (DropDownList)sender;
            dropDown.SelectedIndex = ddlApartmentOwner.SelectedIndex;
        }

        private void RebindApartmentOwners()
        {
            ddlApartmentOwner.DataSource = ((DBRepo)Application["database"]).GetApartmentOwners();
            ddlApartmentOwner.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {            
            int statusId;
            if (ddlStatus.SelectedIndex!=0)
                statusId = ddlStatus.SelectedIndex;
            else statusId= ((DBRepo)Application["database"]).GetApartmentStatus(apartmentId);

            int ownerId = ddlApartmentOwner.SelectedIndex + 1;
            int maxAdults = int.Parse(txtAdult.Text);
            int maxChildren = int.Parse(txtChildren.Text);
            int totalRooms = int.Parse(txtNumberOfRooms.Text);
            int beachDistance = int.Parse(txtBeachDistance.Text);
            int price = int.Parse(txtPrice.Text);


            if (statusId!=3)
            {
                if (pnlRegisteredUser.Visible)
                    ((DBRepo)Application["database"]).UpdateApartmentReservationByUserId(apartmentId, txtDetailsReg.Text, ddlRegisteredUsers.SelectedIndex);
                
                else
                    ((DBRepo)Application["database"]).UpdateApartmentReservation(apartmentId, txtDetailsUnreg.Text, txtUsername.Text, txtPhoneNumber.Text, txtEmail.Text, txtUserAddress.Text);
            }

            Apartment apartment = new Apartment()
            {
                Id = apartmentId,
                NameEng = txtApartmentsName.Text,
                Price = price,
                OwnerId = ownerId,
                MaxAdults = maxAdults,
                MaxChildren = maxChildren,
                TotalRooms = totalRooms,
                BeachDistance = beachDistance,
                StatusId = statusId,
                Address = txtAddress.Text
            };
            ((DBRepo)Application["database"]).UpdateApartment(apartment);
            Response.Redirect("Apartments.aspx");
        }


        protected void btnAddPicture_Click(object sender, EventArgs e)
        {
            string picPath = Request.PhysicalApplicationPath + _picPath;
            string getFileName = Path.GetFileName(uplImages.FileName);
            string fullPath = picPath + getFileName;
            string dbPath = _picPath + getFileName;

            if (File.Exists(fullPath)) return;

            if (String.IsNullOrEmpty(getFileName)) return;

            uplImages.SaveAs(fullPath);
            ((DBRepo)Application["database"]).AddPictures(apartmentId, dbPath);

            GetPictures();
        }

        private void GetPictures()
        {            
            IList<ApartmentPicture> apartmentPictures = new List<ApartmentPicture>();
            apartmentPictures = ((DBRepo)Application["database"]).GetApartmentPicturesByID(apartmentId);
            rptApartmentPictures.DataSource = apartmentPictures;
            rptApartmentPictures.DataBind();
        }

        protected void btnRepresentative_Click(object sender, EventArgs e)
        {           
            Button representative = (Button)sender;
            int newRepresentative = int.Parse(representative.CommandArgument);
            ((DBRepo)Application["database"]).SetRepresentativePicture(apartmentId, newRepresentative);
        }


        protected void btnShowDeleteImageModal_Click(object sender, EventArgs e)
        {
            Button delete = (Button)sender;
            int imageId = int.Parse(delete.CommandArgument);
            string path = Request.PhysicalApplicationPath+((DBRepo)Application["database"]).GetImagePath(imageId);
            ViewState["path"]=path;            
            ViewState["imageId"] = imageId;
            pnlShowDeleteImgModal.Visible = true;
        }

        protected void btnDeleteImage_Click(object sender, EventArgs e)
        {
            int imageId = (int)ViewState["imageId"];
            ((DBRepo)Application["database"]).DeleteApartmentPictureByID(imageId);
            pnlShowDeleteImgModal.Visible = false;
            GetPictures();
            string path = (string)ViewState["path"];
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        protected void btnDeleteApartment_Click(object sender, EventArgs e)
        {
            ((DBRepo)Application["database"]).DeleteApartment(apartmentId);
            Response.Redirect("Apartments.aspx");
        }

        protected void btnDelteTag_Click(object sender, EventArgs e)
        {
            int tagId = (int)ViewState["tagId"];
            ((DBRepo)Application["database"]).DeleteApartmentTagByID(tagId,apartmentId);
            Response.Redirect("ApartmentPage.aspx");
        }

        protected void btnShowDeleteTagModal_Click(object sender, EventArgs e)
        {
            pnlDeleteTag.Visible = true;
            Button btnDeleteTag = (Button)sender;
            int tagId = int.Parse(btnDeleteTag.CommandArgument);
            ViewState["tagId"] = tagId;
        }

        protected void btnShowDeleteApartmentModal_Click(object sender, EventArgs e)
        {
            pnlShowDeleteApartmentModal.Visible = true;
        }

        protected void btnShowAddNewTagModal_Click(object sender, EventArgs e)
        {
            pnlAddNewTagToApartment.Visible = true;            
            GetUnusedTags();
        }

        private void GetUnusedTags()
        {
            IList<Tag> addNewTags = ((DBRepo)Application["database"]).GetUnusedTagsOnApartment(apartmentId);
            rptAddNewTagToApartment.DataSource = addNewTags;
            rptAddNewTagToApartment.DataBind();
        }

        private void GetApartmentTags()
        {
            
            IList<Tag> tags = ((DBRepo)Application["database"]).GetApartmentTags(apartmentId);
            rptApartmentTags.DataSource = tags;
            rptApartmentTags.DataBind();
        }

        protected void btnAddNewTagOnApartment_Click(object sender, EventArgs e)
        {
            Button btnAddTag = (Button)sender;
            int tagId = int.Parse(btnAddTag.CommandArgument);
            ((DBRepo)Application["database"]).AddNewTagToApartment(tagId, apartmentId);
            GetApartmentTags();
            GetUnusedTags();
        }

        protected void btnCloseRptAddNewTag_Click(object sender, EventArgs e)
        {
            pnlAddNewTagToApartment.Visible = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Apartments.aspx");
        }

        protected void lnkDeleteSelectedImage_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;

            int Imageid = int.Parse(linkButton.CommandArgument);

            ((DBRepo)Application["database"]).DeleteApartmentPictureByID(Imageid);
        }

    }
}