using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegistration
{
    public partial class Auth : System.Web.UI.Page
    {
        
        protected void Page_Init(object sender, EventArgs e)
        {
            
            if (Session["UserId"] == null && Request.QueryString["UserId"]!=null)
            { 
                Response.Redirect("loginpage");
            }
            else if (Request.QueryString["UserId"]!=null && Session["UserId"].ToString() != Request.QueryString["UserId"] && CheckIsAdmin() == false)
            {
                Response.Redirect("Userdetails?UserId=" + Session["UserId"].ToString() + "&tab=detailsLink");
            }
            
        }

        public static void StoreUserIdInSession(int userId)
        {
            HttpContext.Current.Session["UserId"] = userId;
            HttpContext.Current.Session.Timeout = 60;
        }


        public static bool CheckIsAdmin()
        {
            
            if (HttpContext.Current.Session["UserId"]==null)
            {
                return false;
            }
            int userId = int.Parse(HttpContext.Current.Session["UserId"].ToString());
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

        public int GetUserId()
        {
            if (Session["UserId"] == null)
            {
                return 0;
            }
            return int.Parse(Session["UserId"].ToString());
        }

        public void ClearSession()
        {
            Session.Abandon();
            Session.Clear();
        }
    }
}