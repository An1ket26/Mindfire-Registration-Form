//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBase_LINQ
{
    using System;
    using System.Collections.Generic;
    
    public partial class StateProvinces
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StateProvinces()
        {
            this.Cities = new HashSet<Cities>();
        }
    
        public int StateProvinceID { get; set; }
        public string StateProvinceCode { get; set; }
        public string StateProvinceName { get; set; }
        public int CountryID { get; set; }
        public string SalesTerritory { get; set; }
        public System.Data.Entity.Spatial.DbGeography Border { get; set; }
        public Nullable<long> LatestRecordedPopulation { get; set; }
        public int LastEditedBy { get; set; }
        public System.DateTime ValidFrom { get; set; }
        public System.DateTime ValidTo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cities> Cities { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual People People { get; set; }
    }
}
