using EmployeeManagement.DataAccess;
using EmployeMangement.Utils.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangement.Business
{
    public class UserBusiness
    {
        public static List<UserModel> GetAllUser()
        {
            
            return UserData.GetAllUserData(); ;
        }


        public static void AddUserToDb(UserModel newUser)
        {
            UserData.AddNewUserToDatabase(newUser);
        }

        public static UserModel GetUserById(int id)
        {
            return UserData.GetUserDetailsById(id);
        }


        public static void UpdateUserDetails(UserModel user)
        {
            UserData.UpdateUserDetails(user);
        }


        public static string GetImageNameForDownload(int userId)
        {
            return UserData.GetImageNameForDownload(userId);
        }

        public static void DeleteUser(int userId)
        {
            UserData.DeleteUser(userId);
        }

        public static int CheckUserIsPresent(string email, string password)
        {
            return UserData.CheckUserIsPresent(email, password); ;
        }

        public static bool CheckIsAdmin(int userId)
        {
            return UserData.CheckIsAdmin(userId);
        }

        public static string GetUserEmail(int userId)
        {
            return UserData.GetUserEmail(userId);
        }
    }
}
