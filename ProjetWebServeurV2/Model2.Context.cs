﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetWebServeurV2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class info_mlecoeuvreIUTEntities : DbContext
    {
        public info_mlecoeuvreIUTEntities()
            : base("name=info_mlecoeuvreIUTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<actor> actor { get; set; }
        public virtual DbSet<country> country { get; set; }
        public virtual DbSet<episode> episode { get; set; }
        public virtual DbSet<external_rating> external_rating { get; set; }
        public virtual DbSet<external_rating_source> external_rating_source { get; set; }
        public virtual DbSet<genre> genre { get; set; }
        public virtual DbSet<rating> rating { get; set; }
        public virtual DbSet<season> season { get; set; }
        public virtual DbSet<series> series { get; set; }
        public virtual DbSet<user> user { get; set; }
    }
}
