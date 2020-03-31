using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Entities.Payments;
using BookKeeper.Data.Data.Entities.Rates;
using System;
using System.Configuration;
using System.Data.Entity;

namespace BookKeeper.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
            
        }
        public virtual DbSet<DistrictEntity> Districts { get; set; }

        public virtual DbSet<StreetEntity> Streets { get; set; }

        public virtual DbSet<LocationEntity> Locations { get; set; }

        public virtual DbSet<AccountEntity> Accounts { get; set; }

        public virtual DbSet<PaymentDocumentEntity> PaymentDocuments { get; set; }

        public virtual DbSet<DiscountDocumentEntity> DiscountDocuments { get; set; }

        public virtual DbSet<DiscountPercentEntity> DiscountPercents { get; set; }

        public virtual DbSet<DiscountDescriptionEntity> DiscountDescriptions { get; set; }

        public virtual DbSet<RateEntity> Rates { get; set; }

        public virtual DbSet<RateDetailsEntity> RateDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
