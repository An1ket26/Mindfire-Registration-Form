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
            using(var dbContext = new UserRegistrationEntities())
            {
                var items = dbContext.Role;
                foreach (var item in items)
                {
                    roleNames.Add(item.RoleName.Trim().ToString());
                }
            }
            return roleNames;
        }
    }
}
