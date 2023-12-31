﻿using EmployeMangement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace EmployeeManagements.Web
{
    public class Global : HttpApplication
    {
        void Application_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            LogRecords.LogRecord(ex);
            Response.Redirect("loginpage");
        }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}