using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FAITutorial2.Models
{
    public partial class FAI2_0Context : DbContext
    {
        public FAI2_0Context()
        {
        }

        public FAI2_0Context(DbContextOptions<FAI2_0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Klienti> Klienti { get; set; }
        public virtual DbSet<Punetori> Punetori { get; set; }
        public virtual DbSet<Roli> Roli { get; set; }
        public virtual DbSet<Vendori> Vendori { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("FaiConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klienti>(entity =>
            {
                entity.Property(e => e.KlientiId).HasColumnName("KlientiID");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Emri)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mbiemri)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Punetori>(entity =>
            {
                entity.Property(e => e.PunetoriId).HasColumnName("PunetoriID");

                entity.Property(e => e.Emri)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gjinia)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Mbiemri)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoliId).HasColumnName("RoliID");

                entity.HasOne(d => d.Roli)
                    .WithMany(p => p.Punetori)
                    .HasForeignKey(d => d.RoliId)
                    .HasConstraintName("FK__Punetori__RoliID__00200768");
            });

            modelBuilder.Entity<Roli>(entity =>
            {
                entity.Property(e => e.RoliId).HasColumnName("RoliID");

                entity.Property(e => e.Roli1)
                    .HasColumnName("Roli")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendori>(entity =>
            {
                entity.Property(e => e.VendoriId).HasColumnName("VendoriID");

                entity.Property(e => e.Emri)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lokacioni)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
