using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeMangement.Utils.Models
{
    public class UserFilesModel
    {
        public int Id { get; set; }
        public Nullable<int> userId { get; set; }
        public string FileName { get; set; }
        public Nullable<int> CreatedId { get; set; }
        public string FileUniqueId { get; set; }
        public string CreatedTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
