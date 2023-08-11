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
    /// Summary description for ImageDownloadHandler
    /// </summary>
    public class ImageDownloadHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {

                if (!string.IsNullOrEmpty(context.Request.QueryString["ImageName"]))
                {

                    int UserId = int.Parse(context.Request.QueryString["UserId"]);

                    if (context.Session["UserId"] != null)
                    {
                        int sessionUserId = int.Parse(context.Session["UserId"].ToString());
                        bool isAdmin = UserBusiness.CheckIsAdmin(sessionUserId);
                        string userEmail = UserBusiness.GetUserEmail(UserId);
                        if (isAdmin == false)
                        {
                            if (UserId != sessionUserId)
                            {
                                context.Response.ContentType = "text/plain";
                                context.Response.Write("You Do not have authorization!");
                                context.Response.End();
                            }
                        }

                        string filePath = WebConfigurationManager.AppSettings["ImageUrl"];
                        string fileName = userEmail.Trim() + context.Request.QueryString["ImageName"];
                        string contentType = "image/" + Path.GetExtension(fileName).Replace(".", "");
                        using (FileStream fs = new FileStream(filePath + fileName, FileMode.Open, FileAccess.Read))
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                br.Close();
                                fs.Close();
                                context.Response.ContentType = contentType;
                                context.Response.BinaryWrite(bytes);
                                context.Response.End();
                            }
                        }
                    }

                    else
                    {
                        context.Response.ContentType = "text/plain";
                        context.Response.Write("You Do not have authorization!");
                    }
                }
                else
                {

                    context.Response.ContentType = "text/plain";
                    context.Response.Write("You Do not have authorization!");
                }
            }catch(Exception ex)
            {
                LogRecords.LogRecord(ex);
                context.Response.ContentType = "text/plain";
                context.Response.Write("You Do not have authorization!");
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