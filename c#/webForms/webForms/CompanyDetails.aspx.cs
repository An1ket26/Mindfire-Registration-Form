using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webForms
{
    public partial class CompanyDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if(txtCompanyId.Text.Length>0)
                    NotesControl.ObjectID = int.Parse(txtCompanyId.Text);
                
            }
        }
        protected void LoadUserControl(object sender, EventArgs e)
        {
            
            (NotesControl.FindControl("btnAdd") as Button).Enabled = true;
            Response.Redirect("companyDetails?ObjectId=" + txtCompanyId.Text);
        }
    }
}