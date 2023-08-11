

using EmployeeMangement.Business;
using EmployeMangement.Utils;
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
            try
            {
                int fileId = int.Parse(context.Request.QueryString["fileId"]);
                string filename = FileBusiness.GetFileNameForDownload(fileId);
                int UserId = int.Parse(context.Request.QueryString["UserId"]);
                string filepath = WebConfigurationManager.AppSettings["UploadUrl"] + filename;
                context.Session["UserId"].ToString();
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
            }catch(Exception ex)
            {
                LogRecords.LogRecord(ex);
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