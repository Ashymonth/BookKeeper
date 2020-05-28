using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Entities.Payments;
using BookKeeper.Data.Data.Entities.Rates;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace BookKeeperTest
{
    public static class Seed
    {
        public static DataHandler SeedData(decimal accrued = 200, decimal received = 100, decimal percent = 25, decimal rate = 166)
        {
            var district = new DistrictEntity()
            {
                Code = 1,
                Name = "test"
            };

            var street = new StreetEntity()
            {
                DistrictId = district.Id,
                District = district,
                StreetName = "1",
            };

            var location = new LocationEntity()
            {
                StreetId = street.Id,
                Street = street,
                HouseNumber = "1",
                BuildingCorpus = "2",
                ApartmentNumber = "3",
            };

            var account = new AccountEntity()
            {
                StreetId = street.Id,
                Account = 1,
                LocationId = location.Id,
                Location = location
            };

            var payment = new PaymentDocumentEntity()
            {
                AccountId = account.Id,
                Account = account,
                Accrued = accrued,
                Received = received,
                PaymentDate = DateTime.Now
            };

            var defaultRate = new RateEntity()
            {
                Price = Convert.ToDecimal(ConfigurationManager.AppSettings["DefaultPrice"]),
                IsDefault = true
            };

            var connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["ConnectionName"]].ConnectionString;

            using (var dataBase = new ApplicationDbContext(connectionString))
            {
                dataBase.Database.Delete();
                dataBase.Database.Create();

                dataBase.Districts.Add(district);
                dataBase.Streets.Add(street);
                dataBase.Locations.Add(location);
                dataBase.Accounts.Add(account);
                dataBase.PaymentDocuments.Add(payment);
                dataBase.Rates.Add(defaultRate);

                dataBase.SaveChanges();
            }

            return new DataHandler()
            {
                AccountEntity = account,
                StreetEntity = street,
                LocationEntity = location
            };
        }

        public static DiscountEntity CreateDiscount(int accountId, DateTime startDate,DateTime endDate,decimal percent)
        {
            var discount = new DiscountEntity
            {
                AccountId = accountId,
                StartDate = startDate,
                EndDate = endDate,
                Percent = percent,
            };
            return discount;
        }

        public static RateEntity CreateRate(DateTime startDate, DateTime endDate, decimal price, LocationEntity location)
        {
            var rate = new RateEntity
            {
                StartDate = startDate,
                EndDate = endDate,
                Price = price,

                AssignedLocations = new List<RateDetailsEntity>()
                {
                    new RateDetailsEntity
                    {
                        StreetId = location.StreetId,
                        HouseNumber = location.HouseNumber,
                        BuildingNumber = location.BuildingCorpus,
                        LocationRefId = location.Id
                    }
                }
            };
            return rate;
        }
    }
}