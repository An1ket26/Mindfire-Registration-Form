using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.DataAccess;
using EmployeMangement.Utils.Models;

namespace EmployeeMangement.Business
{
    public class CountryBusiness
    {
        public static List<CountryModel> GetCountryData()
        {
            return CountryData.GetCountry();
        }
    }
}
