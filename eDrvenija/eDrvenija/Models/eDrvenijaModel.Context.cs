﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eDrvenija.eDrvenija.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class edrvenijabazaEntities1 : DbContext
    {
        public edrvenijabazaEntities1()
            : base("name=edrvenijabazaEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<dokumenti> dokumenti { get; set; }
        public DbSet<kategorije> kategorije { get; set; }
        public DbSet<komentari> komentari { get; set; }
        public DbSet<korisnici> korisnici { get; set; }
        public DbSet<korisnicikategorije> korisnicikategorije { get; set; }
        public DbSet<logovi> logovi { get; set; }
        public DbSet<ocjene> ocjene { get; set; }
        public DbSet<oglasi> oglasi { get; set; }
        public DbSet<poruke> poruke { get; set; }
        public DbSet<statusi> statusi { get; set; }
        public DbSet<tipovikorisnika> tipovikorisnika { get; set; }
        public DbSet<tipovioglasa> tipovioglasa { get; set; }
        public DbSet<transakcije> transakcije { get; set; }
        public DbSet<upiti> upiti { get; set; }
    }
}
