using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EmployeMangement.Utils
{
    public  class CommonAuth
    {
        public static void StoreUserIdInSession(int userId)
        {
            HttpContext.Current.Session["UserId"] = userId;
            HttpContext.Current.Session.Timeout = 60;
        }
        

        public static int GetCurrentUserId()
        {
            if (HttpContext.Current.Session["UserId"] == null)
            {
                return 0;
            }
            return int.Parse(HttpContext.Current.Session["UserId"].ToString());
        }
    }
}
