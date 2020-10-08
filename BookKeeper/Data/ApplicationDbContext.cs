using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Entities.Payments;
using BookKeeper.Data.Data.Entities.Rates;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace BookKeeper.Data.Data
{
    public class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
            var result = Database.CreateIfNotExists();
            if (result)
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public virtual DbSet<DistrictEntity> Districts { get; set; }

        public virtual DbSet<StreetEntity> Streets { get; set; }

        public virtual DbSet<LocationEntity> Locations { get; set; }

        public virtual DbSet<AccountEntity> Accounts { get; set; }

        public virtual DbSet<PaymentDocumentEntity> PaymentDocuments { get; set; }

        public virtual DbSet<DiscountEntity> Discounts { get; set; }

        public virtual DbSet<DiscountPercentEntity> DiscountPercents { get; set; }

        public virtual DbSet<OccupantEntity> Occupants { get; set; }

        public virtual DbSet<DiscountDescriptionEntity> DiscountDescriptions { get; set; }

        public virtual DbSet<RateEntity> Rates { get; set; }

        public virtual DbSet<RateDetailsEntity> RateDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2"));
            modelBuilder.Entity<DistrictEntity>()
                .Property(entity => entity.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<StreetEntity>()
                .Property(entity => entity.StreetName)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<LocationEntity>()
                .Property(entity => entity.HouseNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<LocationEntity>()
                .Property(entity => entity.BuildingCorpus)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<LocationEntity>()
                .Property(entity => entity.ApartmentNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<DiscountDescriptionEntity>()
                .Property(entity => entity.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<DiscountEntity>()
                .Property(entity => entity.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<RateDetailsEntity>()
                .Property(entity => entity.HouseNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<RateDetailsEntity>()
                .Property(entity => entity.BuildingNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<AccountEntity>()
                .HasIndex(entity => entity.Account)
                .IsUnique(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}