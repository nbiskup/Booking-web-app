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
    public partial class AddNewApartment : System.Web.UI.Page
    {
        private string _picPath = "/Images/";
        private int apartmentId;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] == null) Response.Redirect("LogIn.aspx");

            if (!IsPostBack)
            {
                RebindApartmentOwners();
                RebindCities();
                RebindStatuses();
                RebindTags();                
            }
        }

        private void RebindUsers()
        {   
            ddlRegisteredUsers.DataSource = ((DBRepo)Application["database"]).GetAllUsers();
            ddlRegisteredUsers.DataBind();
        }

        private void RebindTags()
        {
            ddlTags.DataSource = ((DBRepo)Application["database"]).GetTags();
            ddlTags.DataBind();
        }

        private void RebindStatuses()
        {
            ddlStatus.DataSource = ((DBRepo)Application["database"]).GetStatuses();
            ddlStatus.DataBind();
        }

        private void RebindCities()
        {
            ddlCity.DataSource = ((DBRepo)Application["database"]).GetAllCities();
            ddlCity.DataBind();

        }

        private void RebindApartmentOwners()
        {
            ddlApartmentOwner.DataSource = ((DBRepo)Application["database"]).GetApartmentOwners();
            ddlApartmentOwner.DataBind();
        }

        
        private Apartment GetFormApartment()
        {
            int statusId = ddlStatus.SelectedIndex;
            ViewState["StatusId"]=statusId;

            int? cityId = ddlCity.SelectedIndex;
            ViewState["CityId"]=cityId;

            int ownerId = int.Parse(ddlApartmentOwner.SelectedValue);

            int? price = null;
            try
            {
                price = int.Parse(txtPrice.Text);
            }
            catch
            {
                rfvPrice.IsValid = false;
            }

            int? maxAdults = null;            
            try
            {
                maxAdults = int.Parse(txtMaxAdults.Text);
            }
            catch
            {
                rfvMaxAdults.IsValid = false;
            }

            int? maxChildren = null;            
            try
            {
                maxChildren = int.Parse(txtMaxChildren.Text);                
            }
            catch
            {
                rfvMaxChildren.IsValid = false;
            }

            int? totalRooms = null;                        
            try
            {
                totalRooms = int.Parse(txtTotalRooms.Text);                
            }
            catch
            {
                rfvTotalRooms.IsValid = false;
            }

            int? beachDistance = null;                        
            try
            {
                beachDistance = int.Parse(txtBeachDistance.Text);                
            }
            catch
            {
                rfvBeachDistance.IsValid = false;
            }


            return
            new Apartment
            {
                OwnerId = ownerId,
                StatusId = statusId,
                CityId = cityId,
                Address = txtAddress.Text,
                NameEng = txtName.Text,
                Price = price,
                MaxAdults = maxAdults,
                MaxChildren = maxChildren,
                TotalRooms = totalRooms,
                BeachDistance = beachDistance
            };
        }

        protected void lnkSaveTxt_Click(object sender, EventArgs e)
        {
            Apartment apartment = GetFormApartment();
            if ((int)ViewState["StatusId"] == 0) 
            {
                rfvStatus.IsValid = false;
                return;
            }

            if ((int)ViewState["CityId"] == 0)
            {
                rfvCity.IsValid = false;
                return;
            }

            ((DBRepo)Application["database"]).CreateApartment(apartment);
            ViewState["apartmentId"] = ((DBRepo)Application["database"]).GetApartmentId(apartment.NameEng, apartment.Address, apartment.TotalRooms, apartment.MaxAdults, apartment.MaxChildren);
            lnkSaveTxt.Visible = false;
            apartmentId = (int)ViewState["apartmentId"];

            int statusId = apartment.StatusId;

            if (statusId == 3)
            {
                pnlImgTags.Visible = true;
                lblSecondPart.Visible = true;
                lblThirdPart.Visible = false;
            }
            else pnlUser.Visible = true;
        }

        protected void ddlTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Tag> tags = GetRepeaterTags();
            Tag newTag = GetSelectedTag();
            
            if (tags.Any(x => x.Id == newTag.Id))
                return;
            if (ddlTags.SelectedIndex == 0)
                rfvTags.IsValid = false;
                        
            tags.Add(newTag);
            repTags.DataSource = tags;
            repTags.DataBind();
            ViewState["tags"] = tags;
        }

        private List<Tag> GetRepeaterTags()
        {
            var repTagsItems = repTags.Items;
            var tags = new List<Tag>();
            foreach (RepeaterItem item in repTagsItems)
            {
                var tag = new Tag();
                tag.Id = int.Parse((item.FindControl("hidTagId") as HiddenField).Value);
                tag.NameEng = (item.FindControl("txtTagNameEng") as Label).Text;
                tags.Add(tag);
            }
            return tags;

        }

        private Tag GetSelectedTag()
        {
            var newTag = new Tag
            {
                Id = int.Parse(ddlTags.SelectedItem.Value),
                NameEng = ddlTags.SelectedItem.Text
            };
            return newTag;
        }

        protected void lnkDeleteSelectedTag_Click(object sender, EventArgs e)
        {
            var tags = GetRepeaterTags();            
            var lbSender = (LinkButton)sender;
            var parentItem = (RepeaterItem)lbSender.Parent;
            var hidTagId = (HiddenField)parentItem.FindControl("hidTagId");
            var tagId = int.Parse(hidTagId.Value);
            var existingTag = tags.FirstOrDefault(x => x.Id == tagId);
            tags.Remove(existingTag);
            repTags.DataSource = tags;
            repTags.DataBind();
        }

        
        protected void btnRegisteredUser_Click(object sender, EventArgs e)
        {
            pnlRegisteredUser.Visible = true;
            pnlUnRegisteredUser.Visible = false;
            RebindUsers();
        }

        protected void btnUnRegisteredUser_Click(object sender, EventArgs e)
        {
            pnlUnRegisteredUser.Visible = true;
            pnlRegisteredUser.Visible = false; 
        }

        protected void btnSaveRegisteredUser_Click(object sender, EventArgs e)
        {
            apartmentId = (int)ViewState["apartmentId"];
            int registeredUserId = int.Parse(ddlRegisteredUsers.SelectedValue);            
            string details = txtDetailsReg.Text;
            ((DBRepo)Application["database"]).CreateApartmentReservationById(registeredUserId,apartmentId,details);
            pnlUnRegisteredUser.Visible=false;
            btnSaveRegisteredUser.Visible = false;
            btnRegisteredUser.Visible = false;
            btnUnRegisteredUser.Visible = false;
            pnlImgTags.Visible = true;
            btnSaveUnRegisteredUser.Visible = false;
        }

        protected void btnSaveUnRegisteredUser_Click(object sender, EventArgs e)
        {
            apartmentId = (int)ViewState["apartmentId"];
            string address = txtUserAddress.Text;           
            string phoneNumber = txtPhoneNumber.Text;
            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string details = txtDetailsUnReg.Text;
                        
            ((DBRepo)Application["database"]).CreateApartmentReservation(apartmentId, username, email, phoneNumber, address, details);
            pnlRegisteredUser.Visible = false;
            btnSaveUnRegisteredUser.Visible = false;
            btnRegisteredUser.Visible = false;
            btnUnRegisteredUser.Visible = false;          
            pnlImgTags.Visible = true;

        }

        protected void btnAddPicture_Click(object sender, EventArgs e)
        {
            apartmentId = (int)ViewState["apartmentId"];
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
            apartmentId = (int)ViewState["apartmentId"];
            IList<ApartmentPicture> apartmentPictures = new List<ApartmentPicture>();
            apartmentPictures = ((DBRepo)Application["database"]).GetApartmentPicturesByID(apartmentId);
            rptApartmentPictures.DataSource = apartmentPictures;
            rptApartmentPictures.DataBind();
        }

        protected void btnRepresentative_Click(object sender, EventArgs e)
        {
            apartmentId = (int)ViewState["apartmentId"];
            Button representative = (Button)sender;
            int newRepresentative = int.Parse(representative.CommandArgument);       
            ((DBRepo)Application["database"]).SetRepresentativePicture(apartmentId,newRepresentative);            
        }


        protected void btnShowDeleteImageModal_Click(object sender, EventArgs e)
        {
            Button delete = (Button)sender;
            int imageId = int.Parse(delete.CommandArgument);
            ViewState["imageId"]=imageId;
            string path = Request.PhysicalApplicationPath + ((DBRepo)Application["database"]).GetImagePath(imageId);
            ViewState["path"] = path;
            ViewState["imageId"] = imageId;
            pnlShowDeleteImgModal.Visible = true;
        }

        protected void btnDeleteImage_Click(object sender, EventArgs e)
        {
            int imageId = (int)ViewState["imageId"];
            ((DBRepo)Application["database"]).DeleteApartmentPictureByID(imageId);
            pnlShowDeleteImgModal.Visible=false;
            GetPictures();
            string path = (string)ViewState["path"];
            if (File.Exists(path)) File.Delete(path);           
        }

        //Zadnji korak spremanja
        protected void lnkSaveImgTags_Click(object sender, EventArgs e)
        {
            apartmentId = (int)ViewState["apartmentId"];
            IList<Tag> tags = (IList<Tag>)ViewState["tags"];
            if ((IList<Tag>)ViewState["tags"] == null)
            {
                rfvTags.IsValid = false;
                return;
            }
            else
            {
                foreach (Tag tag in tags)
                {
                    ((DBRepo)Application["database"]).AddNewTagToApartment(tag.Id, apartmentId);
                }
                Response.Redirect("Apartments.aspx");
            }
        }
    }
}