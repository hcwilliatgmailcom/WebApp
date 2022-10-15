using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Email> Emails { get; set; } = null!;
        public virtual DbSet<Person> Personen { get; set; } = null!;
        public virtual DbSet<EmailPerson> EmailPersonen { get; set; } = null!;

        public virtual DbSet<Entity> Entities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


        
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Entity>(entity =>
            {
                 

                entity.ToView("Entity");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(64);
            });
        }

     
            
    }
}
