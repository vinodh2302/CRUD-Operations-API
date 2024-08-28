using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProductApi.Models;

namespace ProductApi.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext()
        {
        }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // if (!optionsBuilder.IsConfigured)
           // {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JH138N0;Database=Product;Trusted_Connection=True;");
          //  }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
               // entity.HasNoKey();

                entity.ToTable("Product");
                entity.Property(p => p.Id)
                .HasColumnName("Id")
                .HasComment("Primary Key");
                //entity.Property(e => e.Category)
                //    .HasMaxLength(50)
                //    .IsUnicode(false);

                //entity.Property(e => e.Name).HasMaxLength(50);

                //entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

           
        }

    }
}
