using EmployeeMangement.Business;
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
            
            if (!string.IsNullOrEmpty(context.Request.QueryString["ImageName"]))
            {

                int UserId = int.Parse(context.Request.QueryString["UserId"]);
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
                string filePath = WebConfigurationManager.AppSettings["ImageUrl"];
                string fileName = context.Request.QueryString["ImageName"];
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