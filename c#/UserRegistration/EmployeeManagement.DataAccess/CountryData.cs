using EmployeMangement.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class CountryData
    {
        public static List<CountryModel> GetCountry()
        {
            List<CountryModel> countryList = new List<CountryModel>();
            using(var dbContext = new UserRegistrationEntities())
            {
                var items = dbContext.Country;
                foreach(var item in items)
                {
                    CountryModel obj = new CountryModel();
                    obj.CountryId= item.CountryId;
                    obj.CountryName = item.CountryName;
                    countryList.Add(obj);
                }
            }
            return countryList;
        }
    }
}
