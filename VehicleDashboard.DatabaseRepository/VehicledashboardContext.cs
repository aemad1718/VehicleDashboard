using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using VehicleDashboard.DatabaseEntity;
using VehicleDashboard.DatabaseRepositoryInterface;

namespace VehicleDashboard.DatabaseRepository
{
    public partial class VehicledashboardContext : DbContext, IDbContext
    {
        public VehicledashboardContext()
        {
        }

        public VehicledashboardContext(DbContextOptions<VehicledashboardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<CustomerVehicle> CustomerVehicle { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAddress_Customer");
            });

            modelBuilder.Entity<CustomerVehicle>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerVehicle)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerVehicle_Customer");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.CustomerVehicle)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerVehicle_Vehicle");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.RegNr)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Vin)
                    .IsRequired()
                    .HasColumnName("VIN")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}