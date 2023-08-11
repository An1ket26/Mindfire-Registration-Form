using EmployeeMangement.Business;
using EmployeMangement.Utils;
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
            try
            {
                Session.Clear();                
            }
            catch(Exception ex) {
                LogRecords.LogRecord(ex);
                ShowErrorModal();
            }
        }
        protected void LoginClick(object sender, EventArgs e)
        {
            try
            {
                var email = EmailInput.Text;
                var password = PasswordInput.Text;
                int userId = UserBusiness.CheckUserIsPresent(email, password);
                if (userId != 0)
                {
                    EmailInput.Text="";
                    PasswordInput.Text = "";
                    CommonAuth.StoreUserIdInSession(userId);
                    if (Auth.CheckIsAdmin())
                    {
                        Response.Redirect("userlist");
                    }
                    else
                    {
                        Response.Redirect("userdetails?UserId=" + userId + "&tab=detailsLink");
                    }
                }
                else
                {
                    string message = "Invalid Email or Password";
                    string script2 = $@"<script type=text/javascript>document.addEventListener(""DOMContentLoaded"", function(event) {{displayModal(`{message}`);}})</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), script2);
                }
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                ShowErrorModal();
            }
        }
        protected void RegisterClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("userdetails");
            }catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                ShowErrorModal();
            }
        }
        protected void ShowErrorModal()
        {
            string message = "Something Went Wrong,Please Try Again!!";
            string script2 = $@"<script type=text/javascript>document.addEventListener(""DOMContentLoaded"", function(event) {{displayModal(`{message}`);}})</script>";
            ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), script2);
        }

    }
}