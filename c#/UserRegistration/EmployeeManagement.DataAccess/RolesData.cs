using EmployeMangement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class RolesData
    {
        public static List<string>GetRoleNames()
        {
            List<string> roleNames = new List<string>();
            var isAdmin = UserData.CheckIsAdmin(CommonAuth.GetCurrentUserId());
            if (!isAdmin)
            {
                using (var dbContext = new UserRegistrationEntities())
                {
                    var items = dbContext.Role.Where(i => i.RoleName != "Admin");
                    foreach (var item in items)
                    {
                        roleNames.Add(item.RoleName.Trim().ToString());
                    }
                }
            }
            else
            {
                using (var dbContext = new UserRegistrationEntities())
                {
                    var items = dbContext.Role;
                    foreach (var item in items)
                    {
                        roleNames.Add(item.RoleName.Trim().ToString());
                    }
                }
            }
            return roleNames;
        }
    }
}
