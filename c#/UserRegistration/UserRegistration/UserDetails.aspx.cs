using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
namespace UserRegistration
{
    public class UserDetailsModel
    {
        public int userId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DateofBirth { get; set; }
        public string PermanentAddressLine1 { get; set; }
        public string PermanentAddressLine2 { get; set; }
        public string PermanentCity { get; set; }
        public string PermanentCountry { get; set; }
        public string PermanentState { get; set; }
        public string PermanentPostalCode { get; set; }
        public string PresentAddressLine1 { get; set; }
        public string PresentAddressLine2 { get; set; }
        public string PresentCity { get; set; }
        public string PresentCountry { get; set; }
        public string PresentState { get; set; }
        public string PresentPostalCode { get; set; }
        public string IsSubscribed { get; set; }
        public string Hobby { get; set; }
        public string ImageSrc { get; set; }
        public String UserRoles { get; set; }
    }

    public partial class WebForm1 : Auth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (CheckIsAdmin()==true)
            {
                cancelBtn.Text = "Cancel";
                logout.Text = "Back";
            }
            else if(GetUserId()!=0 && CheckIsAdmin() == false)
            {
                cancelBtn.CssClass = cancelBtn.CssClass.Replace("btn-cancel", "btn-cancel-hide");
            }
            if(CheckIsAdmin()&&GetUserId()!=0)
            {
                FetchImage(Request.QueryString["UserId"]);
            }
            else if(GetUserId()!=0)
            {
                FetchImage(GetUserId().ToString());
            }
            
            if (!IsPostBack)
                RenderRoles();

        }
        protected void RenderRoles()
        {
            using (var dbContext = new UserEntities())
            {
                var items = dbContext.Role.Select(i => i.RoleName);
                foreach (var item in items)
                {

                    RoleList.Items.Add(item.Trim());
                }
            }
        }
        protected void Check_Clicked(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static List<string> FetchCountry(string message)
        {
            List<string> countryList = new List<string>();
            using (var dbContext = new UserEntities())
            {
                var items = dbContext.Country.Select(i => i.CountryName);
                foreach (var item in items)
                {
                    countryList.Add(item.ToString());
                }
            }
            return countryList;
        }
        [System.Web.Services.WebMethod]
        public static List<string> FetchState(string country)
        {
            List<string> stateList = new List<string>();
            using (var dbContext = new UserEntities())
            {
                int countryId = dbContext.Country.Where(i => i.CountryName == country).Select(i => i.CountryId).Single();
                var items = dbContext.State.Where(i => i.CountryId == countryId).Select(i => i.StateName);
                foreach (var item in items)
                {
                    stateList.Add(item.ToString());
                }
            }
            return stateList;
        }
        [System.Web.Services.WebMethod]
        public static void StoreData(UserDetailsModel user)
        {
            using (var dbContext = new UserEntities())
            {
                User obj = new User();
                obj.Firstname = user.FirstName;
                obj.LastName = user.LastName;
                obj.Gender = user.Gender;
                obj.Dob = user.DateofBirth;
                obj.Email = user.Email;
                obj.PresentAddressLine1 = user.PresentAddressLine1;
                obj.PresentAddressLine2 = user.PresentAddressLine2;
                obj.PresentCity = user.PresentCity;
                obj.PresentCountryId = dbContext.Country.Where(i => i.CountryName == user.PresentCountry).Select(i => i.CountryId).Single();
                obj.PresentStateId = dbContext.State.Where(i => i.StateName == user.PresentState).Select(i => i.StateId).Single();
                obj.PresentPostalCode = user.PresentPostalCode;
                obj.PermanentAddressLine1 = user.PermanentAddressLine1;
                obj.PermanentAddressLine2 = user.PermanentAddressLine2;
                obj.PermanentCity = user.PermanentCity;
                obj.PermanentCountryId = dbContext.Country.Where(i => i.CountryName == user.PermanentCountry).Select(i => i.CountryId).Single();
                obj.PermanentStateId = dbContext.State.Where(i => i.StateName == user.PermanentState).Select(i => i.StateId).Single(); ;
                obj.PermanentPostalCode = user.PermanentPostalCode;
                obj.IsSubscribed = user.IsSubscribed;
                obj.Imagesrc = user.ImageSrc;
                obj.Password = user.Password;
                dbContext.User.Add(obj);
                dbContext.SaveChanges();
                int userId = obj.UserId;
                foreach (var x in user.UserRoles.Split(','))
                {
                    LogRecord(x);
                    if (x != "")
                    {
                        int roleId = dbContext.Role.Where(i => i.RoleName == x).Select(i => i.RoleId).Single();
                        UserRole ur = new UserRole();
                        ur.UserId = userId;
                        ur.RoleId = roleId;
                        dbContext.UserRole.Add(ur);
                        dbContext.SaveChanges();
                    }
                }
                foreach (string item in user.Hobby.Split(','))
                {
                    LogRecord(item);
                    if (item != "")
                    {
                        Hobby hobby = new Hobby();
                        hobby.UserId = userId;
                        hobby.HobbyName = item;
                        dbContext.Hobby.Add(hobby);
                        dbContext.SaveChanges();
                    }
                }
            }
            
        }
        [System.Web.Services.WebMethod]
        public static Object FetchUser(string userId)
        {
            int id = int.Parse(userId);

            UserDetailsModel userData = new UserDetailsModel();
            var obj = new { };

            using (var dbContext = new UserEntities())
            {
                var item = dbContext.User.Where(i => i.UserId == id).FirstOrDefault();
                userData.FirstName = item.Firstname.Trim();
                userData.LastName = item.LastName.Trim();
                userData.Email = item.Email.Trim();
                userData.Password = item.Password.Trim();
                userData.DateofBirth = item.Dob.Trim();
                userData.Gender = item.Gender.Trim();
                userData.PresentAddressLine1 = item.PresentAddressLine1.Trim();
                userData.PresentAddressLine2 = item.PresentAddressLine2.Trim();
                userData.PresentPostalCode = item.PresentPostalCode.Trim();
                userData.PermanentAddressLine1 = item.PermanentAddressLine1.Trim();
                userData.PermanentAddressLine2 = item.PermanentAddressLine2.Trim();
                userData.PermanentPostalCode = item.PermanentPostalCode.Trim();
                userData.PresentCity = item.PresentCity.Trim();
                userData.PermanentCity = item.PermanentCity.Trim();
                string presentCountryName = dbContext.Country.Where(i => i.CountryId == item.PresentCountryId).Select(i => i.CountryName).Single().ToString();
                string permanentCountryName = dbContext.Country.Where(i => i.CountryId == item.PermanentCountryId).Select(i => i.CountryName).Single().ToString();
                string presentStateName = dbContext.State.Where(i => i.StateId == item.PresentStateId).Select(i => i.StateName).Single().ToString();
                string permanentStateName = dbContext.State.Where(i => i.StateId == item.PermanentStateId).Select(i => i.StateName).Single().ToString();
                var hobbies = dbContext.Hobby.Where(i => i.UserId == item.UserId);
                string hobby = "";
                foreach (var hob in hobbies)
                {
                    hobby += hob.HobbyName.Trim() + ",";
                }
                hobby = hobby.Substring(0, hobby.Length - 1).Trim();
                string Roles = "";
                var roleIds = dbContext.UserRole.Where(i => i.UserId == item.UserId).Select(i => i.RoleId);
                foreach (var roleid in roleIds)
                {
                    Roles += dbContext.Role.Where(i => i.RoleId == roleid).Select(i => i.RoleName).Single().ToString().Trim() + ",";
                }
                Roles = Roles.Substring(0, Roles.Length - 1).Trim();
                userData.PresentCountry = presentCountryName.Trim();
                userData.PermanentCountry = permanentCountryName.Trim();
                userData.PresentState = presentStateName.Trim();
                userData.PermanentState = permanentStateName.Trim();
                userData.Hobby = hobby.Trim();
                userData.UserRoles = Roles.Trim();
                userData.IsSubscribed = item.IsSubscribed.Trim();
            }
            return userData;
        }


        [System.Web.Services.WebMethod]
        public static void UpdateData(UserDetailsModel item)
        {
            using (var dbContext = new UserEntities())
            {
                User obj = dbContext.User.Where(i => i.UserId == item.userId).Single();
                obj.Firstname = item.FirstName;
                obj.LastName = item.LastName;
                obj.Gender = item.Gender;
                obj.Dob = item.DateofBirth;
                obj.Email = item.Email;
                obj.PresentAddressLine1 = item.PresentAddressLine1;
                obj.PresentAddressLine2 = item.PresentAddressLine2;
                obj.PresentCity = item.PresentCity;
                obj.PresentCountryId = dbContext.Country.Where(i => i.CountryName == item.PresentCountry).Select(i => i.CountryId).Single();
                obj.PresentStateId = dbContext.State.Where(i => i.StateName == item.PresentState).Select(i => i.StateId).Single();
                obj.PresentPostalCode = item.PresentPostalCode;
                obj.PermanentAddressLine1 = item.PermanentAddressLine1;
                obj.PermanentAddressLine2 = item.PermanentAddressLine2;
                obj.PermanentCity = item.PermanentCity;
                obj.PermanentCountryId = dbContext.Country.Where(i => i.CountryName == item.PermanentCountry).Select(i => i.CountryId).Single();
                obj.PermanentStateId = dbContext.State.Where(i => i.StateName == item.PermanentState).Select(i => i.StateId).Single(); ;
                obj.PermanentPostalCode = item.PermanentPostalCode;
                obj.IsSubscribed = item.IsSubscribed;
                obj.Imagesrc = item.ImageSrc;
                dbContext.SaveChanges();

                foreach (string hobbies in item.Hobby.Split(','))
                {
                    if (hobbies != "")
                    {
                        if (dbContext.Hobby.Where(i => i.UserId == item.userId && i.HobbyName == hobbies).Any())
                        {
                            continue;
                        }
                        Hobby hobby = new Hobby();
                        hobby.UserId = item.userId;
                        hobby.HobbyName = hobbies;
                        dbContext.Hobby.Add(hobby);
                        dbContext.SaveChanges();
                    }
                }
                List<int> listRoleId = new List<int>();
                var ListAllId = dbContext.Role.Select(i => i.RoleId).ToList();
                foreach (string roles in item.UserRoles.Split(','))
                {
                    if (roles != "")
                    {
                        int roleId = dbContext.Role.Where(i => i.RoleName == roles).Select(i => i.RoleId).Single();
                        listRoleId.Add(roleId);
                        if (dbContext.UserRole.Where(i => i.UserId == item.userId && i.RoleId == roleId).Any())
                        {
                            continue;
                        }
                        else
                        {
                            UserRole ur = new UserRole();
                            ur.UserId = item.userId;
                            ur.RoleId = roleId;
                            dbContext.UserRole.Add(ur);
                            dbContext.SaveChanges();
                        }
                    }
                }
                foreach (var roleId in ListAllId)
                {
                    if (!listRoleId.Contains(roleId))
                    {
                        if (dbContext.UserRole.Where(i => i.UserId == item.userId && i.RoleId == roleId).Any())
                        {
                            UserRole usr = dbContext.UserRole.Where(i => i.UserId == item.userId && i.RoleId == roleId).Single();
                            dbContext.UserRole.Remove(usr);
                            dbContext.SaveChanges();
                        }
                    }
                }

            }
            
            
        }


        [System.Web.Services.WebMethod]
        public static List<string> GetFileName(string id)
        {
            int userId = int.Parse(id);
            List<string> fileNames = new List<string>();
            using (var dbContext = new UserEntities())
            {
                var items = dbContext.UserFiles.Where(i => i.userId == userId).Select(i => i.FileName);
                foreach (var item in items)
                {
                    fileNames.Add(item.ToString());
                }
            }
            return fileNames;
        }

        protected void CancelLogoutBtn(object sender, EventArgs e)
        {
            if(cancelBtn.Text=="Login")
            {
                Response.Redirect("loginpage");
            }
            else
            {
                Response.Redirect("userlist");
            }
        }
        protected void FetchImage(string userId)
        {
            int id = int.Parse(userId);
            string fileName = null;
            string email = "";
            using(var dbContext = new UserEntities())
            {if (dbContext.User.Where(i => i.UserId == id && i.Imagesrc != null).Any())
                {
                    fileName = dbContext.User.Where(i => i.UserId == id && i.Imagesrc != null).Select(i => i.Imagesrc).Single().ToString();
                    email = dbContext.User.Where(i => i.UserId == id).Select(i => i.Email).Single().ToString();
                }
                
            }
            
            if (fileName != null)
            {
                profileImageDisplay.ImageUrl = "ImageDownloadHandler.ashx?ImageName=" +email.Trim()+fileName+"&UserId="+id;
            }
        }


        protected void Logout(object sender, EventArgs e)
        {
            if(CheckIsAdmin())
            {
                Response.Redirect("userlist");
            }
            ClearSession();
            Response.Redirect("loginpage");
        }


        public static void LogRecord(string message)
        {
            Console.WriteLine(message);
            string pathName = Path.Combine("D:\\Projects\\Assignments\\test\\test2.txt");
            if (File.Exists(pathName))
            {
                File.AppendAllText(pathName, message + Environment.NewLine);
            }
            else
            {
                File.WriteAllText(pathName, message + Environment.NewLine);
            }
        }
    }
}