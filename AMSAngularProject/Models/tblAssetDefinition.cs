//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMSAngularProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAssetDefinition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAssetDefinition()
        {
            this.tblAssetMasters = new HashSet<tblAssetMaster>();
            this.tblPurchases = new HashSet<tblPurchase>();
        }
    
        public int assetId { get; set; }
        public string assetName { get; set; }
        public Nullable<int> assetType { get; set; }
        public string assetClass { get; set; }
    
        public virtual tblAssetType tblAssetType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAssetMaster> tblAssetMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchase> tblPurchases { get; set; }
    }
}
