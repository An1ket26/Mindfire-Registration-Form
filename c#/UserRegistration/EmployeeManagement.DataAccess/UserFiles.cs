//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeManagement.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserFiles
    {
        public int Id { get; set; }
        public Nullable<int> userId { get; set; }
        public string FileName { get; set; }
        public Nullable<int> CreatedId { get; set; }
        public string FileUniqueId { get; set; }
        public string CreatedTime { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
