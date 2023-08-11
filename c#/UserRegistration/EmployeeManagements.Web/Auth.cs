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
            try
            {
                
                if (CommonAuth.GetCurrentUserId() == 0 && Request.QueryString["UserId"] != null)
                {
                    Response.Redirect("loginpage");
                }
                else if (Request.QueryString["UserId"] != null &&
                    CommonAuth.GetCurrentUserId().ToString() != Request.QueryString["UserId"] &&
                    CheckIsAdmin() == false)
                {
                    Response.Redirect("Userdetails?UserId=" + CommonAuth.GetCurrentUserId().ToString() + "&tab=detailsLink");
                }
                if (Request.Url.ToString().Split('/')[3].ToLower() == "userlist" && CheckIsAdmin() == false && CommonAuth.GetCurrentUserId() > 0)
                {
                    Response.Redirect("Userdetails?UserId=" + Session["UserId"].ToString() + "&tab=detailsLink");
                }
                else if (Request.Url.ToString().Split('/')[3].ToLower() == "userlist" && CheckIsAdmin() == false && CommonAuth.GetCurrentUserId() == 0)
                {
                    Response.Redirect("loginpage");
                }
                
            }catch(Exception ex)
            {
                LogRecords.LogRecord(ex);
            }
           
            
        }
        

        public static bool CheckIsAdmin()
        {

            if (CommonAuth.GetCurrentUserId()==0)
            {
                return false;
            }
            int userId = CommonAuth.GetCurrentUserId();
            bool isAdmin = UserBusiness.CheckIsAdmin(userId);
            return isAdmin;
        }

        public void ClearSession()
        {
            Session.Abandon();
            Session.Clear();
        }


    }
}