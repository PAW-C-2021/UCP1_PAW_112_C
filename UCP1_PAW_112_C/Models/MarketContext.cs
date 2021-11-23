using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_112_C.Models
{
    public partial class MarketContext : DbContext
    {
        public MarketContext()
        {
        }

        public MarketContext(DbContextOptions<MarketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barang> Barangs { get; set; }
        public virtual DbSet<Pembeli> Pembelis { get; set; }
        public virtual DbSet<Penjual> Penjuals { get; set; }
        public virtual DbSet<Penyuplai> Penyuplais { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.KodeBarang);

                entity.ToTable("Barang");

                entity.Property(e => e.KodeBarang)
                    .ValueGeneratedNever()
                    .HasColumnName("kode_barang");

                entity.Property(e => e.BanyakBarang)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("banyak_barang");

                entity.Property(e => e.JenisBarang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("jenis_barang");

                entity.Property(e => e.StokBarang)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("stok_barang");
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli);

                entity.ToTable("pembeli");

                entity.Property(e => e.IdPembeli)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pembeli");

                entity.Property(e => e.KodeBarang).HasColumnName("kode_barang");

                entity.Property(e => e.UsernamePembeli)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username_pembeli");
            });

            modelBuilder.Entity<Penjual>(entity =>
            {
                entity.HasKey(e => e.IdPenjual);

                entity.ToTable("Penjual");

                entity.Property(e => e.IdPenjual)
                    .ValueGeneratedNever()
                    .HasColumnName("id_penjual");

                entity.Property(e => e.JenisBarang)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("jenis_barang");

                entity.Property(e => e.UsernamePenjual)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username_penjual");
            });

            modelBuilder.Entity<Penyuplai>(entity =>
            {
                entity.HasKey(e => e.IdSupplier);

                entity.ToTable("Penyuplai");

                entity.Property(e => e.IdSupplier)
                    .ValueGeneratedNever()
                    .HasColumnName("id_supplier");

                entity.Property(e => e.JenisBarang)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("jenis_barang");

                entity.Property(e => e.UsernameSupplier)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username_supplier");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
