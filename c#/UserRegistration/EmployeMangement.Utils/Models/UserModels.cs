using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeMangement.Utils.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string PresentAddressLine1 { get; set; }
        public string PresentAddressLine2 { get; set; }
        public string PresentPostalCode { get; set; }
        public Nullable<int> PresentCountryId { get; set; }
        public Nullable<int> PresentStateId { get; set; }
        public string PresentCity { get; set; }
        public string PermanentAddressLine1 { get; set; }
        public string PermanentAddressLine2 { get; set; }
        public string PermanentPostalCode { get; set; }
        public Nullable<int> PermanentCountryId { get; set; }
        public Nullable<int> PermanentStateId { get; set; }
        public string PermanentCity { get; set; }
        public string IsSubscribed { get; set; }
        public string Imagesrc { get; set; }
        public string Password { get; set; }
        public string PresentCountry { get; set; }
        public string PresentState { get; set; }
        public string PermanentCountry { get; set; }
        public string PermanentState { get; set; }
        public string Hobby { get; set; }
        public string UserRoles { get; set; }
    }


}
