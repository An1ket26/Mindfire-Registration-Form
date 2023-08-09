using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserRegistration;
using EmployeeMangement.Business;
using EmployeMangement.Utils.Models;
using EmployeMangement.Utils;

namespace EmployeeManagements.Web
{
    public partial class UserDetails :Auth
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (CheckIsAdmin() == true)
            {
                cancelBtn.Text = "Cancel";
                logout.Text = "Back";
            }
            else if (GetUserId() != 0 && CheckIsAdmin() == false)
            {
                cancelBtn.CssClass = cancelBtn.CssClass.Replace("btn-cancel", "btn-cancel-hide");
            }
            if (CheckIsAdmin() && Request.QueryString["UserId"] != null)
            {
                FetchImage(Request.QueryString["UserId"]);
            }
            else if (GetUserId() != 0)
            {
                FetchImage(GetUserId().ToString());
            }

            if (!IsPostBack)
                RenderRoles();

        }
        protected void RenderRoles()
        {
            try
            {
                var items = RolesBusiness.GetRoleNames();
                foreach (var item in items)
                {

                    RoleList.Items.Add(item.Trim());
                }
            }catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                
            }
            
        }

        [System.Web.Services.WebMethod]
        public static List<string> FetchCountry(string message)
        {
            try
            {
                List<string> countryList = new List<string>();
                var items = CountryBusiness.GetCountryData();
                foreach (var item in items)
                {
                    countryList.Add(item.CountryName.ToString());
                }
                return countryList;
            }catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                return null;
            }
}

        [System.Web.Services.WebMethod]
        public static List<string> FetchState(string country)
        {
            try
            {
                List<string> stateList = new List<string>();
                var items = StateBusiness.GetStateData(country);
                foreach (var item in items)
                {
                    stateList.Add(item.StateName.ToString());
                }
                return stateList;
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                return null;

            }
        }
        [System.Web.Services.WebMethod]
        public static void StoreData(UserModel user)
        {
            try
            {
                UserBusiness.AddUserToDb(user);
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);

            }
        }
        [System.Web.Services.WebMethod]
        public static Object FetchUser(string userId)
        {
            try
            {
                int id = int.Parse(userId);
                return UserBusiness.GetUserById(id);
            }catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                return null;
            }

        }


        [System.Web.Services.WebMethod]
        public static void UpdateData(UserModel item)
        {
            try
            {
                UserBusiness.UpdateUserDetails(item);
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                
            }
        }


        [System.Web.Services.WebMethod]
        public static List<UserFilesModel> GetFileName(string id)
        {
            try
            {
                int userId = int.Parse(id);
                return FileBusiness.GetFilename(userId);
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                return null;
            }

        }

        protected void CancelLogoutBtn(object sender, EventArgs e)
        {
            try
            {
                if (cancelBtn.Text == "Login")
                {
                    ClearSession();
                    Response.Redirect("loginpage");
                }
                else
                {
                    Response.Redirect("userlist");
                }
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                
            }
        }
        protected void FetchImage(string userId)
        {
            try
            {
                int id = int.Parse(userId);
                string fileName = UserBusiness.GetImageNameForDownload(id);

                if (fileName != null)
                {
                    profileImageDisplay.ImageUrl = "ImageDownloadHandler.ashx?ImageName=" + fileName + "&UserId=" + id;
                }
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                
            }
        }



        [System.Web.Services.WebMethod]
        public static List<NotesModel> GetUserNote(string userId)
        {
            try
            {
                int id = int.Parse(userId);
                bool isAdmin = Auth.CheckIsAdmin();
                return NotesBusiness.GetUserNotes(id, isAdmin);
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                return null;
            }
        }


        [System.Web.Services.WebMethod]
        public static void DeleteUserNote(string noteId)
        {
            try
            {
                int id = int.Parse(noteId);
                NotesBusiness.DeleteNotes(id);
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
            }
        }

        [System.Web.Services.WebMethod]
        public static void EditUserNotes(NotesModel note)
        {
            try {
                NotesBusiness.EditNotes(note);
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                
            }
        }

        [System.Web.Services.WebMethod]
        public static void AddUserNotes(NotesModel note)
        {
            try
            {
                note.CreatedId = Auth.GetUserId();
                NotesBusiness.AddNotes(note);
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                
            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            try
            {
                if (CheckIsAdmin())
                {
                    Response.Redirect("userlist");
                }
                ClearSession();
                Response.Redirect("loginpage");
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
               
            }
        }

    }
}