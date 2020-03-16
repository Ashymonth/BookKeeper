using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using Microsoft.EntityFrameworkCore;

namespace BookKeeper.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<StreetEntity> Streets { get; set; }

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
            modelBuilder.Entity<StreetEntity>()
                .HasOne(d => d.District)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<StreetEntity>()
                .HasMany(l => l.Location)
                .WithOne(x=>x.AddressEntity)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
