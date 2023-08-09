using EmployeeManagement.DataAccess;
using EmployeMangement.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangement.Business
{
    public class StateBusiness
    {
        public static List<StateModel> GetStateData(string country)
        {
            return StateData.GetStateByCoutnry(country);
        }
    }
}
