﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExemploLINQ
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ClarifyDBEntities : DbContext
    {
        public ClarifyDBEntities()
            : base("name=ClarifyDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Alunos> Alunos { get; set; }
        public DbSet<Alunos_CursosAgendados> Alunos_CursosAgendados { get; set; }
        public DbSet<Certificacoes> Certificacoes { get; set; }
        public DbSet<CursosAgendados> CursosAgendados { get; set; }
        public DbSet<CursosClarify> CursosClarify { get; set; }
        public DbSet<Pessoas> Pessoas { get; set; }
        public DbSet<Professores> Professores { get; set; }
    }
}