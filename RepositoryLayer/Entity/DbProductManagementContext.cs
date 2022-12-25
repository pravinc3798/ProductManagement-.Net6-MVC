using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Entity;

public partial class DbProductManagementContext : DbContext
{
    public DbProductManagementContext()
    {
    }

    public DbProductManagementContext(DbContextOptions<DbProductManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ProductDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__tblCateg__19093A0B3EBEF691");

            entity.ToTable("tblCategory");

            entity.HasIndex(e => e.Category, "UQ__tblCateg__4BB73C32842C9F81").IsUnique();

            entity.Property(e => e.Category).HasMaxLength(10);
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__tblProdu__B40CC6CDF49B1BDC");

            entity.ToTable("tblProducts");

            entity.HasIndex(e => e.ProductCode, "UQ__tblProdu__2F4E024F69843EC3").IsUnique();

            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ProductCode).HasMaxLength(25);
            entity.Property(e => e.ProductDescription).HasMaxLength(4000);
            entity.Property(e => e.ProductImage).HasMaxLength(100);
            entity.Property(e => e.ProductName).HasMaxLength(250);

            entity.HasOne(d => d.Category).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblProduc__Categ__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
