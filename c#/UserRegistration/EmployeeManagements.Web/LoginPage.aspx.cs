using EmployeeMangement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserRegistration;

namespace EmployeeManagements.Web
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginClick(object sender, EventArgs e)
        {
            var email = EmailInput.Text;
            var password = PasswordInput.Text;
            int userId = UserBusiness.CheckUserIsPresent(email, password);
            if (userId != 0)
            {
                Auth.StoreUserIdInSession(userId);
                if(Auth.CheckIsAdmin())
                {
                    Response.Redirect("userlist");
                }
                else
                {
                    Response.Redirect("userdetails?UserId="+userId+ "&tab=detailsLink");
                }
            }
            else
            {
                string message = "Invalid Email or Password";
                string script = $@"<script type=text/javascript>alert(`{message}`)</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
            }
        }
        protected void RegisterClick(object sender, EventArgs e)
        {
            Response.Redirect("userdetails");
        }
    }
}