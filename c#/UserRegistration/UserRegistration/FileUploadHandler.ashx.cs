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
            List<string>FileNames=new List<string>();
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string fname = WebConfigurationManager.AppSettings["UploadUrl"] + UserId + "-" + file.FileName;
                    file.SaveAs(fname);
                    FileNames.Add(file.FileName);
                }
                using (var dbContext = new UserEntities())
                {
                    foreach (var filename in FileNames)
                    {
                        UserFiles obj = new UserFiles();
                        obj.userId = UserId;
                        obj.FileName = filename;
                        dbContext.UserFiles.Add(obj);
                    }
                    dbContext.SaveChanges();

                }



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