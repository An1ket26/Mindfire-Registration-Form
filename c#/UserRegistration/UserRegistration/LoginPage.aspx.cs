using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegistration
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
            using(var dbContext = new UserEntities())
            {
                if(dbContext.User.Where(i=>i.Email == email && i.Password==password).Count() == 1)
                { 
                    int userId = dbContext.User.Where(i => i.Email == email && i.Password == password).Select(i=>i.UserId).FirstOrDefault();
                    Auth.StoreUserIdInSession(userId);
                    if (Auth.CheckIsAdmin())
                    {
                        Response.Redirect("userlist");
                    }
                    else
                    {
                        
                        Response.Redirect("UserDetails?UserId=" + userId + "&tab=detailsLink");
                    }
                }
                else
                {
                    string message = "Invalid Email or Password";
                    string script = $@"<script type=text/javascript>alert(`{message}`)</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
                }
            }
        }
        protected void RegisterClick(object sender, EventArgs e)
        {
            Response.Redirect("userdetails");
        }
    }
    
}
