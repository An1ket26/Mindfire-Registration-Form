using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegistration
{

    
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        
        public int ObjectID { get; set; }
        public string ObjectType { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Auth.CheckIsAdmin())
            {
                isPrivateDiv.Attributes.Add("style", "display:inline");
            }
            else
            {
                isPrivateDiv.Attributes.Add("style", "display:none");
            }

        }
        
    }
}