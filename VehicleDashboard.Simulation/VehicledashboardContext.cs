using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace VehicleDashboard.Simulation
{
    public partial class VehicledashboardContext : DbContext
    {
        public VehicledashboardContext()
        {
        }

        public VehicledashboardContext(DbContextOptions<VehicledashboardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);

            IConfigurationRoot configuration = new ConfigurationBuilder()
                  .SetBasePath(Path.GetDirectoryName(path))
                  .AddJsonFile("appsettings.json")
                  .Build();
            string connectionString = configuration.GetConnectionString("vehicleDashboardDbConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.RegNr)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}