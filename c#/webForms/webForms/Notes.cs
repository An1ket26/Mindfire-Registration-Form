//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webForms
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> IdeaId { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Ideas Ideas { get; set; }
    }
}
