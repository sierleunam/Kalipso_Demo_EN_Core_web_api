using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kalipso_Demo_EN_Core.Models
{
    public partial class Kalipso_Demo_ENContext : DbContext
    {
        public Kalipso_Demo_ENContext()
        {
        }

        public Kalipso_Demo_ENContext(DbContextOptions<Kalipso_Demo_ENContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<Families> Families { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Users> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ROGERIO-PC\\SQL17;Database=Kalipso_Demo_EN;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.HasIndex(e => e.CountryName)
                    .HasName("UQ__Countrie__1E5963E65FCD3595")
                    .IsUnique();

                entity.Property(e => e.CountryId)
                    .HasColumnName("COUNTRY_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("COUNTRY_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("IMAGE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PopulationDensity)
                    .HasColumnName("POPULATION_DENSITY")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.RegionId).HasColumnName("REGION_ID");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nif)
                    .HasColumnName("NIF")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Responsability).HasMaxLength(50);
            });

            modelBuilder.Entity<Devices>(entity =>
            {
                entity.HasKey(e => e.SerialNumber);

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Application)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasColumnName("ClientID")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Platform)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Families>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Family).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Prico).HasColumnType("numeric(9, 2)");

                entity.Property(e => e.Stock).HasColumnType("numeric(9, 0)");
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.HasKey(e => e.RegionId);

                entity.Property(e => e.RegionId)
                    .HasColumnName("REGION_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RegionName)
                    .HasColumnName("REGION_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Login);

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Passw).HasMaxLength(50);
            });
        }
    }
}
