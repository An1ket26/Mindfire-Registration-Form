using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegistration
{
    public class UserDataModel
    {
        public int userId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
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
        public string imageSrc { get; set; }
        public String UserRoles { get; set; }
    }

    public partial class UserList2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static List<UserDataModel> GetUserDetails()
        {
            List<UserDataModel> userDataList = new List<UserDataModel>();
            using (var dbContext = new UserEntities())
            {
                
                var items = dbContext.User;
                foreach (var item in items)
                {
                    UserDataModel userData = new UserDataModel();
                    userData.userId = item.UserId;
                    userData.FirstName = item.Firstname.Trim();
                    userData.LastName = item.LastName.Trim();
                    userData.Email = item.Email.Trim();
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

                    userDataList.Add(userData);
                }
                return userDataList;
            }
        }
        
        [System.Web.Services.WebMethod]
        public static void DeleteUser(string userId)
        {
            int deleteId = int.Parse(userId);
            using (var dbContext = new UserEntities())
            {
                var hobbies = dbContext.Hobby.Where(i => i.UserId == deleteId);
                foreach (var hobby in hobbies)
                {
                    dbContext.Hobby.Remove(hobby);
                }
                dbContext.SaveChanges();
                var userRoles = dbContext.UserRole.Where(i => i.UserId == deleteId);
                foreach (var role in userRoles)
                {
                    dbContext.UserRole.Remove(role);
                }
                dbContext.SaveChanges();
                var notes = dbContext.UserNotes.Where(i => i.ObjectId == deleteId && i.ObjectType == "User");
                foreach (var note in notes)
                {
                    dbContext.UserNotes.Remove(note);
                }
                dbContext.SaveChanges();
                User obj = new User();
                obj = dbContext.User.Where(i => i.UserId == deleteId).FirstOrDefault();
                dbContext.User.Remove(obj);
                dbContext.SaveChanges();
            }
        }
    }
}