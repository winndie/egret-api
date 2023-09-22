using EgretApi.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace EgretApi.DataAccessLayer
{
    public class GeospatialContext : DbContext
    {
        public GeospatialContext(DbContextOptions<GeospatialContext> options): base(options)
        {
        }

        public DbSet<ColdCallingControlledZone> ColdCallingControlledZones { get; set; }
        public DbSet<ColdCallingControlledZoneGeometry> ColdCallingControlledZoneGeometries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColdCallingControlledZone>().HasKey(x => x.Id);
            modelBuilder.Entity<ColdCallingControlledZoneGeometry>().HasKey(x => x.Id);

            //modelBuilder.Entity<ColdCallingControlledZone>()
            //    .HasOne<ColdCallingControlledZoneGeometry>()
            //    .WithOne()
            //    .HasForeignKey("ColdCallingControlledZoneID");
        }
    }
}
