using EmployeMangement.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class StateData
    {
        public static List<StateModel> GetStateByCoutnry(string country)
        {
            List<StateModel> stateList = new List<StateModel>();
            
            using (var dbContext = new UserRegistrationEntities())
            {

                int countryId = dbContext.Country.Where(i=>i.CountryName== country).Select(i=>i.CountryId).FirstOrDefault();
                var items = dbContext.State.Where(i=>i.CountryId==countryId);
                foreach (var item in items)
                {
                    StateModel obj = new StateModel();
                    obj.StateId = item.StateId;
                    obj.StateName = item.StateName;
                    obj.CountryId = item.CountryId;
                    stateList.Add(obj);
                }
            }
            return stateList;
        }
    }
}
