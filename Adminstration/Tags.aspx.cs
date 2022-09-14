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
    public partial class Tags : System.Web.UI.Page
    {
        private IList<Tag> _listOfAllTags = new List<Tag>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("LogIn.aspx");

            if (!IsPostBack)
            {
                LoadData();
            }
            {
                _listOfAllTags = (IList<Tag>)ViewState["tags"];
            }
        }

        private void LoadData()
        {
            _listOfAllTags = ((DBRepo)Application["database"]).LoadAllTags();
            rptTags.DataSource = _listOfAllTags;
            rptTags.DataBind();

            IList<String> tagTypes = new List<String>();
            tagTypes = ((DBRepo)Application["database"]).LoadAllTagTypes();
            int numerator = 1;
            foreach (string tag in tagTypes)
            {                
                ddlTagType.Items.Add(new ListItem { Text = tag, Value = numerator.ToString() });
                numerator++;
            }

            ViewState["tags"] = _listOfAllTags;
        }
           
        protected void btnAddNewTag_Click(object sender, EventArgs e)
        {
            int typeId = int.Parse(ddlTagType.SelectedValue);
            string nameEng = tbTagName.Text;

            for (int i = 0; i < _listOfAllTags.Count; i++)
            {
                if (nameEng.ToUpper() == _listOfAllTags[i].NameEng.ToUpper())
                {
                    pnlTagExists.Visible = true;
                    return;
                }
            }

            ((DBRepo)Application["database"]).AddNewTag(typeId, nameEng);
            Response.Redirect("Tags.aspx");
        }

        protected void btnShowDeleteModal_Click(object sender, EventArgs e)
        {
            Button btnDeleteTag = (Button)sender;
            int tagId = int.Parse(btnDeleteTag.CommandArgument);
            pnlShowDeleteModal.Visible = true;
            ViewState["tagId"] = tagId;
        }

        protected void btnDeleteTag_Click(object sender, EventArgs e)
        {
            int tagId = (int)ViewState["tagId"];
            ((DBRepo)Application["database"]).DeleteTag(tagId);
            Response.Redirect("Tags.aspx");
        }
    }
}