using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Payments;
using Microsoft.EntityFrameworkCore;

namespace BookKeeper.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<StreetEntity> Streets { get; set; }

        public virtual DbSet<DistrictEntity> Districts { get; set; }

        public virtual DbSet<LocationEntity> Locations { get; set; }

        public virtual DbSet<AccountEntity> Accounts { get; set; }

        public virtual DbSet<PaymentDocumentEntity> PaymentDocuments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookKeeping;Trusted_Connection=True;MultipleActiveResultSets=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
