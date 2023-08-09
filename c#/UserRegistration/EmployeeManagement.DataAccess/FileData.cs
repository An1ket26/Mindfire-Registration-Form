using EmployeMangement.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class FileData
    {
        public static List<UserFilesModel> GetFilenameByUserId(int userId)
        {
            List<UserFilesModel> fileNames = new List<UserFilesModel>();
            using (var dbContext = new UserRegistrationEntities())
            {
                var items = dbContext.UserFiles.Where(i => i.userId == userId);
                foreach (var item in items)
                {
                    UserFilesModel obj = new UserFilesModel();
                    obj.Id = item.Id;
                    obj.FileName = item.FileName.Trim();
                    obj.userId = item.userId;
                    obj.FileUniqueId = item.FileUniqueId;
                    obj.CreatedBy = dbContext.User.Where(i=>i.UserId==item.CreatedId).Select(i=>i.Firstname).Single().Trim();
                    obj.CreatedTime = item.CreatedTime;
                    fileNames.Add(obj);
                }
            }
            return fileNames;
        }


        public static void InsertUserFiles(int userId,int createdId, List<string> uniqueIdList, List<string>FileNames)
        {
            using (var dbContext = new UserRegistrationEntities())
            {
                int i = 0;
                foreach (var filename in FileNames)
                {
                    UserFiles obj = new UserFiles();
                    obj.userId = userId;
                    obj.FileName = filename;
                    obj.CreatedId = createdId;
                    obj.FileUniqueId = uniqueIdList[i];
                    obj.CreatedTime = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                    dbContext.UserFiles.Add(obj);
                    i++;
                }
                dbContext.SaveChanges();

            }
        }

        public static string GetFileNameForDownload(int fileId)
        { 
            string filename = "";
            using(var dbContext = new UserRegistrationEntities())
            {
               
                var item = dbContext.UserFiles.Where(i => i.Id == fileId).FirstOrDefault();
                filename = item.userId +"-"+ item.FileUniqueId +"-"+ item.FileName;
            }
            return filename;
        }
        
    }
}
