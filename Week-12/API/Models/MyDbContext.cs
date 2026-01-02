using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategori> Kategoris { get; set; }

    public virtual DbSet<Urun> Uruns { get; set; }

    public virtual DbSet<UrunKategori> UrunKategoris { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.HasKey(e => e.KategoriId).HasName("PRIMARY");

            entity.ToTable("kategori");

            entity.Property(e => e.KategoriId).HasColumnName("kategori_id");
            entity.Property(e => e.Baslik)
                .HasMaxLength(50)
                .HasColumnName("baslik")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Urun>(entity =>
        {
            entity.HasKey(e => e.UrunId).HasName("PRIMARY");

            entity.ToTable("urun");

            entity.Property(e => e.UrunId).HasColumnName("urun_id");
            entity.Property(e => e.Adet).HasColumnName("adet");
            entity.Property(e => e.Baslik)
                .HasMaxLength(50)
                .HasColumnName("baslik")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Fiyat)
                .HasPrecision(9, 2)
                .HasColumnName("fiyat");
        });

        modelBuilder.Entity<UrunKategori>(entity =>
        {
            entity.HasKey(e => e.UrunKategoriId).HasName("PRIMARY");

            entity.ToTable("urun_kategori");

            entity.Property(e => e.UrunKategoriId).HasColumnName("urun_kategori_id");
            entity.Property(e => e.KategoriId).HasColumnName("kategori_id");
            entity.Property(e => e.UrunId).HasColumnName("urun_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
