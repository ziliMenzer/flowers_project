//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Watering
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Watering()
        {
            this.FlowerInGarden = new HashSet<FlowerInGarden>();
        }
    
        public int wateringId { get; set; }
        public string soilKind { get; set; }
        public Nullable<int> minDays { get; set; }
        public Nullable<int> maxDays { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FlowerInGarden> FlowerInGarden { get; set; }
    }
}
