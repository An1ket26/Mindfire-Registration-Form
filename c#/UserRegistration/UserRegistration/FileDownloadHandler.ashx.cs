using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UserRegistration
{
    /// <summary>
    /// Summary description for FileDownloadHandler
    /// </summary>
    public class FileDownloadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string filename = context.Request.QueryString["filename"];
            string filepath = WebConfigurationManager.AppSettings["UploadUrl"] + filename;

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