using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace webForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
         
        }
        void Application_Init(object sender, EventArgs e)
        {

        }

        void Application_Disposed(object sender, EventArgs e)
        {

        }
        void Application_Error(object sender, EventArgs e)
        {

        }
        void Application_End(object sender, EventArgs e)
        {

        }

        void Application_EndRequest(object sender, EventArgs e)
        {

        }

        void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {

        }

        void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {

        }
        void Applcation_PreSendRequestHeaders(object sender, EventArgs e)
        {

        }

        void Application_PreSendContent(object sender, EventArgs e)
        {

        }

        void Application_AcquireRequestState(object sender, EventArgs e)
        {

        }
        void Application_ReleaseRequestState(object sender, EventArgs e)
        {

        }

        void Application_ResolveRequestCache(object sender, EventArgs e)
        {

        }
        void Application_UpdateRequestCache(object sender, EventArgs e)
        {

        }
        void Session_End(object sender, EventArgs e)
        {

        }
        void Application_AuthorizeRequest(object sender, EventArgs e)
        {

        }
        

    }
}