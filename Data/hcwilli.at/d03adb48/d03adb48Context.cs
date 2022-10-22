using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.Data.hcwilli.at.d03adb48
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

        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Name=ConnectionStrings:MySql");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.QuantityPerUnit).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReorderLevel)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SupplierId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UnitPrice).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UnitsInStock)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UnitsOnOrder)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
