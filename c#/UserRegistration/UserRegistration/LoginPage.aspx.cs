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
        protected bool CheckIsAdmin(int userId)
        {
            bool isAdmin = false;
            using (var dbContext = new UserEntities())
            {
                var rolesId = dbContext.UserRole.Where(i => i.UserId == userId).Select(i => i.RoleId);
                foreach (var roleId in rolesId)
                {
                    if (dbContext.Role.Where(i => i.RoleId == roleId).Select(i => i.RoleName).Single().Trim() == "Admin")
                    {
                        isAdmin = true;
                    }
                }
            }
            return isAdmin;
        }
        protected void LoginClick(object sender, EventArgs e)
        {
            var email = EmailInput.Text;
            var password = PasswordInput.Text;
            using(var dbContext = new UserEntities())
            {
                if(dbContext.User.Where(i=>i.Email == email && i.Password==password).Count() == 1)
                { 
                    var userId = dbContext.User.Where(i => i.Email == email && i.Password == password).Select(i=>i.UserId).FirstOrDefault();
                    HttpCookie cookie = new HttpCookie("UserId");
                    HttpCookie cookie2 = new HttpCookie("IsAdmin");
                    cookie.Expires=DateTime.Now.AddDays(1);
                    cookie2.Expires=DateTime.Now.AddDays(1);
                    cookie.Value = userId.ToString();
                    Response.Cookies.Add(cookie);
                    Session["UserId"] = userId;
                    if (CheckIsAdmin(userId))
                    {
                        cookie2.Value = "true";
                        Response.Cookies.Add(cookie2);
                        Session["IsAdmin"] = "true";
                        Response.Redirect("userlist");
                    }
                    else
                    {
                        cookie2.Value = "false";
                        Response.Cookies.Add(cookie2);
                        Session["IsAdmin"] = "false";
                        Response.Redirect("UserDetails?UserId=" + userId);
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
