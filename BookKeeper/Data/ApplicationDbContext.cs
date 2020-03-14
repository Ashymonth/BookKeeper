using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using Microsoft.EntityFrameworkCore;

namespace BookKeeper.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<AddressEntity> Addresses { get; set; }

        public virtual DbSet<DistrictEntity> Districts { get; set; }

        public virtual DbSet<LocationEntity> Locations { get; set; }

        public virtual DbSet<AccountEntity> Accounts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookKeepingTest;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressEntity>()
                .HasOne(d => d.District)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<AddressEntity>()
                .HasOne(l => l.Location)
                .WithMany()
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
