using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp.Data
{
    public partial class d03adb48Context : DbContext
    {
        public d03adb48Context()
        {
        }

        public d03adb48Context(DbContextOptions<d03adb48Context> options)
            : base(options)
        {
        }

       
        public virtual DbSet<Home> Homes { get; set; } = null!;
        
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=hcwilli.at;database=d03adb48;user=d03adb48;password=k8J3CMGz7sL68rJW;SslMode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Home>(entity =>
            {
                

                entity.ToView("HOME");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(64)
                    .HasColumnName("COLUMN_NAME");

                entity.Property(e => e.Key)
                    .HasMaxLength(129)
                    .HasColumnName("KEY")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.TableName)
                    .HasMaxLength(64)
                    .HasColumnName("TABLE_NAME");
            });

            
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Erstellt)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Kurzbeschreibung).HasMaxLength(50);
            });

             

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
