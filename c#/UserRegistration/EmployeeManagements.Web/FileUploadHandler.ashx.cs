using EmployeeMangement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.SessionState;

namespace UserRegistration
{
    /// <summary>
    /// Summary description for FileUploadHandler
    /// </summary>
    public class FileUploadHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            
            int UserId = int.Parse(context.Request.Form.Get("UserId"));
            int sessionUserId = int.Parse(context.Session["UserId"].ToString());
            bool isAdmin = UserBusiness.CheckIsAdmin(sessionUserId);

            if (isAdmin == false)
            {
                if (UserId != sessionUserId)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("You Do not have authorization!");
                }
            }
           

            List<string>FileNames=new List<string>();
            List<string> uniqueIdList = new List<string>();
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    var uniqueId = Guid.NewGuid();
                    HttpPostedFile file = files[i];
                    string fname = WebConfigurationManager.AppSettings["UploadUrl"] + UserId + "-"+ uniqueId.ToString() +"-"+ file.FileName;
                    file.SaveAs(fname);
                    FileNames.Add(file.FileName);
                    uniqueIdList.Add(uniqueId.ToString());
                }

                FileBusiness.InsertUserFiles(UserId, sessionUserId, uniqueIdList, FileNames);
                context.Response.ContentType = "text/plain";
                context.Response.Write("File Uploaded Successfully!");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}