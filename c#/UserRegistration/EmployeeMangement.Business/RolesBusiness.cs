using EmployeeManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangement.Business
{
    public class RolesBusiness
    {
        public static List<string> GetRoleNames()
        {
            return RolesData.GetRoleNames();
        }
    }
}
