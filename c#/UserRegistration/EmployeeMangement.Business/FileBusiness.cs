using EmployeeManagement.DataAccess;
using EmployeMangement.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangement.Business
{
    public class FileBusiness
    {
        public static List<UserFilesModel> GetFilename(int userId)
        {
            return FileData.GetFilenameByUserId(userId);
        }

        public static void InsertUserFiles(int userId, int createdId, List<string> uniqueIdList, List<string> FileNames)
        {
            FileData.InsertUserFiles(userId, createdId, uniqueIdList, FileNames);
        }

        public static string GetFileNameForDownload(int fileId)
        {
            return FileData.GetFileNameForDownload(fileId);
        }
    }
}
