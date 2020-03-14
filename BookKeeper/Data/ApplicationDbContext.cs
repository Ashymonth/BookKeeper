using BookKeeper.Data.Data.Entities.Address;
using Microsoft.EntityFrameworkCore;

namespace BookKeeper.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<AddressEntity> Address { get; set; }
        
        public virtual DbSet<DistrictEntity> Districts { get; set; }

        public virtual DbSet<LocationEntity> Location { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookKeepingTest;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressEntity>()
                .HasOne(d => d.District)
                .WithMany(a => a.Address)
                .IsRequired();

            modelBuilder.Entity<AddressEntity>()
                .HasOne(l => l.Location)
                .WithMany(a => a.Address)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
