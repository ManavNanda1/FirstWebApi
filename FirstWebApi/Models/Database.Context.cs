﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FirstWebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Manav_SchoolMgmt_42Entities : DbContext
    {
        public Manav_SchoolMgmt_42Entities()
            : base("name=Manav_SchoolMgmt_42Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<StudentDetail> StudentDetails { get; set; }
        public virtual DbSet<ApiTable> ApiTables { get; set; }

        public System.Data.Entity.DbSet<FirstWebApi.Models.Custom_Model.EmployeeModel> EmployeeModels { get; set; }
    }
}
