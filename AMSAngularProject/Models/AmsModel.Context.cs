﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AMSAngularEntities2 : DbContext
    {
        public AMSAngularEntities2()
            : base("name=AMSAngularEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAssetDefinition> tblAssetDefinitions { get; set; }
        public virtual DbSet<tblAssetMaster> tblAssetMasters { get; set; }
        public virtual DbSet<tblAssetType> tblAssetTypes { get; set; }
        public virtual DbSet<tblLogin> tblLogins { get; set; }
        public virtual DbSet<tblPurchase> tblPurchases { get; set; }
        public virtual DbSet<tblUserReg> tblUserRegs { get; set; }
        public virtual DbSet<tblVendor> tblVendors { get; set; }
    }
}
