using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EmployeMangement.Utils.Models;

namespace EmployeeManagement.DataAccess
{
    public class UserData
    {
        public static List<UserModel> GetAllUserData()
        {
            List<UserModel> UserModellList = new List<UserModel>();  
            using (var dbContext = new UserRegistrationEntities())
            {
                var items = dbContext.User;
                foreach (var item in items)
                {
                    UserModel userData = new UserModel();
                    userData.UserId = item.UserId;
                    userData.Firstname = item.Firstname.Trim();
                    userData.LastName = item.LastName.Trim();
                    userData.Email = item.Email.Trim();
                    userData.Password = item.Password.Trim();
                    userData.Dob = item.Dob.Trim();
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
                    if(hobby.Length>0)
                        hobby = hobby.Substring(0, hobby.Length - 1).Trim();
                    string Roles = "";
                    var roleIds = dbContext.UserRole.Where(i => i.UserId == item.UserId).Select(i => i.RoleId);
                    foreach (var roleid in roleIds)
                    {
                        Roles += dbContext.Role.Where(i => i.RoleId == roleid).Select(i => i.RoleName).Single().ToString().Trim() + ",";
                    }
                    if(Roles.Length>0)
                        Roles = Roles.Substring(0, Roles.Length - 1).Trim();
                    userData.PresentCountry = presentCountryName.Trim();
                    userData.PermanentCountry = permanentCountryName.Trim();
                    userData.PresentState = presentStateName.Trim();
                    userData.PermanentState = permanentStateName.Trim();
                    userData.Hobby = hobby.Trim();
                    userData.UserRoles = Roles.Trim();
                    userData.IsSubscribed = item.IsSubscribed.Trim();
                    if (item.Imagesrc == null)
                    {
                        userData.Imagesrc = "NA";
                    }
                    else {
                        userData.Imagesrc = item.Imagesrc.Trim(); 
                    }

                    UserModellList.Add(userData);
                }
            }
            return UserModellList;
        }


        public static void AddNewUserToDatabase(UserModel newUser)
        {
            using (var dbContext = new UserRegistrationEntities())
            {
                User obj = new User();
                obj.Firstname = newUser.Firstname;
                obj.LastName = newUser.LastName;
                obj.Gender = newUser.Gender;
                obj.Dob = newUser.Dob;
                obj.Email = newUser.Email;
                obj.PresentAddressLine1 = newUser.PresentAddressLine1;
                obj.PresentAddressLine2 = newUser.PresentAddressLine2;
                obj.PresentCity = newUser.PresentCity;
                obj.PresentCountryId = dbContext.Country.Where(i => i.CountryName == newUser.PresentCountry).Select(i => i.CountryId).Single();
                obj.PresentStateId = dbContext.State.Where(i => i.StateName == newUser.PresentState).Select(i => i.StateId).Single();
                obj.PresentPostalCode = newUser.PresentPostalCode;
                obj.PermanentAddressLine1 = newUser.PermanentAddressLine1;
                obj.PermanentAddressLine2 = newUser.PermanentAddressLine2;
                obj.PermanentCity = newUser.PermanentCity;
                obj.PermanentCountryId = dbContext.Country.Where(i => i.CountryName == newUser.PermanentCountry).Select(i => i.CountryId).Single();
                obj.PermanentStateId = dbContext.State.Where(i => i.StateName == newUser.PermanentState).Select(i => i.StateId).Single(); ;
                obj.PermanentPostalCode = newUser.PermanentPostalCode;
                obj.IsSubscribed = newUser.IsSubscribed;
                if (newUser.Imagesrc == null || newUser.Imagesrc == "NA")
                {
                    obj.Imagesrc = "NA";
                }
                else
                {
                    obj.Imagesrc = newUser.Imagesrc;
                }
                obj.Password = newUser.Password;
                dbContext.User.Add(obj);
                dbContext.SaveChanges();
                int userId = obj.UserId;
                foreach (var x in newUser.UserRoles.Split(','))
                {
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
                foreach (string item in newUser.Hobby.Split(','))
                {
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


        public static UserModel GetUserDetailsById(int id)
        {
            UserModel userData = new UserModel();
            var obj = new { };

            using (var dbContext = new UserRegistrationEntities())
            {
                var item = dbContext.User.Where(i => i.UserId == id).FirstOrDefault();
                userData.Firstname = item.Firstname.Trim();
                userData.LastName = item.LastName.Trim();
                userData.Email = item.Email.Trim();
                userData.Password = item.Password.Trim();
                userData.Dob = item.Dob.Trim();
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
                if(hobby.Length>0)
                    hobby = hobby.Substring(0, hobby.Length - 1).Trim();
                string Roles = "";
                var roleIds = dbContext.UserRole.Where(i => i.UserId == item.UserId).Select(i => i.RoleId);
                foreach (var roleid in roleIds)
                {
                    Roles += dbContext.Role.Where(i => i.RoleId == roleid).Select(i => i.RoleName).Single().ToString().Trim() + ",";
                }
                if(Roles.Length>0)
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


        public static void UpdateUserDetails(UserModel user)
        {
            using (var dbContext = new UserRegistrationEntities())
            {
                User obj = dbContext.User.Where(i => i.UserId == user.UserId).Single();
                obj.Firstname = user.Firstname;
                obj.LastName = user.LastName;
                obj.Gender = user.Gender;
                obj.Dob = user.Dob;
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
                if (user.Imagesrc == null || user.Imagesrc == "NA")
                {
                    obj.Imagesrc = obj.Imagesrc;
                }
                else
                {
                    obj.Imagesrc = user.Imagesrc;
                }
                    
                dbContext.SaveChanges();

                foreach (string hobbies in user.Hobby.Split(','))
                {
                    if (hobbies != "")
                    {
                        if (dbContext.Hobby.Where(i => i.UserId == user.UserId && i.HobbyName == hobbies).Any())
                        {
                            continue;
                        }
                        Hobby hobby = new Hobby();
                        hobby.UserId = user.UserId;
                        hobby.HobbyName = hobbies;
                        dbContext.Hobby.Add(hobby);
                        dbContext.SaveChanges();
                    }
                }
                List<int> listRoleId = new List<int>();
                var ListAllId = dbContext.Role.Select(i => i.RoleId).ToList();
                foreach (string roles in user.UserRoles.Split(','))
                {
                    if (roles != "")
                    {
                        int roleId = dbContext.Role.Where(i => i.RoleName == roles).Select(i => i.RoleId).Single();
                        listRoleId.Add(roleId);
                        if (dbContext.UserRole.Where(i => i.UserId == user.UserId && i.RoleId == roleId).Any())
                        {
                            continue;
                        }
                        else
                        {
                            UserRole ur = new UserRole();
                            ur.UserId = user.UserId;
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
                        if (dbContext.UserRole.Where(i => i.UserId == user.UserId && i.RoleId == roleId).Any())
                        {
                            UserRole usr = dbContext.UserRole.Where(i => i.UserId == user.UserId && i.RoleId == roleId).Single();
                            dbContext.UserRole.Remove(usr);
                            dbContext.SaveChanges();
                        }
                    }
                }

            }
        }

        public static string GetImageNameForDownload(int userId)
        {
            string fileName = null;
           
            using(var dbContext = new UserRegistrationEntities())
            {
                if (dbContext.User.Where(i => i.UserId == userId && i.Imagesrc != null).Any())
                {
                    fileName = dbContext.User.Where(i => i.UserId == userId && i.Imagesrc != null).
                        Select(i => i.Imagesrc).Single().ToString();
                }
            }
            if(fileName!=null)
            {
                return fileName;
            }
            return "";
        }

        public static void DeleteUser(int deleteId)
        {
            using (var dbContext = new UserRegistrationEntities())
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
                var files = dbContext.UserFiles.Where(i => i.userId == deleteId);
                foreach (var file in files)
                {
                    dbContext.UserFiles.Remove(file);
                }
                var createdfiles = dbContext.UserFiles.Where(i => i.CreatedId == deleteId);
                foreach (var file in createdfiles)
                {
                    dbContext.UserFiles.Remove(file);
                }
                var createdNotes = dbContext.UserNotes.Where(i => i.CreatedId == deleteId);
                foreach (var note in createdNotes)
                {
                    dbContext.UserNotes.Remove(note);
                }
                User obj = new User();
                obj = dbContext.User.Where(i => i.UserId == deleteId).FirstOrDefault();
                dbContext.User.Remove(obj);
                dbContext.SaveChanges();
            }
        }

        public static int CheckUserIsPresent(string email, string password)
        {
            int userId = 0;
            using (var dbContext = new UserRegistrationEntities())
            {
                if (dbContext.User.Where(i => i.Email == email && i.Password == password).Count() == 1)
                {
                    userId = dbContext.User.Where(i => i.Email == email && i.Password == password).Select(i => i.UserId).FirstOrDefault();
                }
            }
            return userId;
        }


        public static bool CheckIsAdmin(int userId)
        {
            var isAdmin = false;
            using (var dbContext = new UserRegistrationEntities())
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

        public static string GetUserEmail(int userId)
        {
            var userEmail = "";
            using (var dbContext = new UserRegistrationEntities())
            {
                userEmail = dbContext.User.Where(i=>i.UserId==userId).Select(i=>i.Email).SingleOrDefault();
            }

            return userEmail;
        }
    }
}
