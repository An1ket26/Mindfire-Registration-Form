using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeMangement.Utils.Models
{
    public class NotesModel
    {
        public int NoteId { get; set; }
        public string Notes { get; set; }
        public Nullable<int> ObjectId { get; set; }
        public string ObjectType { get; set; }
        public string IsPrivate { get; set; }
        public Nullable<int> CreatedId { get; set; }

        public string CreatedBy{get; set;}
        public string CreatedOn{get; set;}
    }
}
