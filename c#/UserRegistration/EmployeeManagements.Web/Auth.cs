using EmployeeMangement.Business;
using EmployeMangement.Utils;
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

            if (Session["UserId"] == null && Request.QueryString["UserId"] != null)
            {
                Response.Redirect("loginpage");
            }
            else if (Request.QueryString["UserId"] != null &&
                Session["UserId"].ToString() != Request.QueryString["UserId"] &&
                CheckIsAdmin() == false)
            {
                Response.Redirect("Userdetails?UserId=" + Session["UserId"].ToString() + "&tab=detailsLink");
            }
            if (Request.Url.ToString().Split('/')[3].ToLower() == "userlist" && CheckIsAdmin() == false && Session["UserId"] != null)
            {
                Response.Redirect("Userdetails?UserId=" + Session["UserId"].ToString() + "&tab=detailsLink");
            }
            else if (Request.Url.ToString().Split('/')[3].ToLower() == "userlist" && CheckIsAdmin() == false && Session["UserId"] == null)
            {
                Response.Redirect("loginpage");
            }
            //LogRecords.LogRecord(Request.Url.ToString());
        }
        
        public static void StoreUserIdInSession(int userId)
        {
            HttpContext.Current.Session["UserId"] = userId;
            HttpContext.Current.Session.Timeout = 60;
        }


        public static bool CheckIsAdmin()
        {

            if (HttpContext.Current.Session["UserId"] == null)
            {
                return false;
            }
            int userId = int.Parse(HttpContext.Current.Session["UserId"].ToString());
            bool isAdmin = UserBusiness.CheckIsAdmin(userId);
            return isAdmin;
        }

        public static int GetUserId()
        {
            if (HttpContext.Current.Session["UserId"] == null)
            {
                return 0;
            }
            return int.Parse(HttpContext.Current.Session["UserId"].ToString());
        }

        public void ClearSession()
        {
            Session.Abandon();
            Session.Clear();
        }


    }
}