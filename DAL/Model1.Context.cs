﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class trdEntities : DbContext
    {
        public trdEntities()
            : base("name=trdEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<fc_menu> fc_menu { get; set; }
        public DbSet<series> series { get; set; }
        public DbSet<subseries> subseries { get; set; }
        public DbSet<tiposdocumentales> tiposdocumentales { get; set; }
        public DbSet<configuracion> configuracion { get; set; }
        public DbSet<dependencias> dependencias { get; set; }
        public DbSet<unidaddocumental> unidaddocumental { get; set; }
        public DbSet<my_aspnet_applications> my_aspnet_applications { get; set; }
        public DbSet<my_aspnet_membership> my_aspnet_membership { get; set; }
        public DbSet<my_aspnet_profiles> my_aspnet_profiles { get; set; }
        public DbSet<my_aspnet_roles> my_aspnet_roles { get; set; }
        public DbSet<my_aspnet_sessioncleanup> my_aspnet_sessioncleanup { get; set; }
        public DbSet<my_aspnet_sessions> my_aspnet_sessions { get; set; }
        public DbSet<my_aspnet_users> my_aspnet_users { get; set; }
        public DbSet<my_aspnet_usersinroles> my_aspnet_usersinroles { get; set; }
        public DbSet<fc_terceros> fc_terceros { get; set; }
    }
}
