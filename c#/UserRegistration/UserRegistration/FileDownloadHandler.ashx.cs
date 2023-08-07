

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.SessionState;

namespace UserRegistration
{
    /// <summary>
    /// Summary description for FileDownloadHandler
    /// </summary>
    public class FileDownloadHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string filename = context.Request.QueryString["filename"];
            int UserId = int.Parse(context.Request.QueryString["UserId"]);
            string filepath = WebConfigurationManager.AppSettings["UploadUrl"] + filename;
            context.Session["UserId"].ToString();
            int sessionUserId = int.Parse(context.Session["UserId"].ToString());
            bool isAdmin = false;
            using (var dbContext = new UserEntities())
            {
                var rolesId = dbContext.UserRole.Where(i => i.UserId == sessionUserId).Select(i => i.RoleId);
                foreach (var roleId in rolesId)
                {
                    if (dbContext.Role.Where(i => i.RoleId == roleId).Select(i => i.RoleName).Single().Trim() == "Admin")
                    {
                        isAdmin = true;
                    }
                }
            }
            if(isAdmin == false)
            {
                if (UserId != sessionUserId)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("You Do not have authorization!");
                }
            }

            if (!string.IsNullOrEmpty(filepath) && File.Exists(filepath))
            {
                context.Response.Clear();
                context.Response.ContentType = "application/octet-stream";
                context.Response.AddHeader("content-disposition", "attachment;filename=" + Path.GetFileName(filepath));
                context.Response.WriteFile(filepath);
                context.Response.End();

            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("File not be found!");


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