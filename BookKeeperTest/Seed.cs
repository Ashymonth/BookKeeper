using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Payments;
using System;
using System.Configuration;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Rates;

namespace BookKeeperTest
{
    public static class Seed
    {
        public static LocationEntity SeedData(decimal accrued = 200, decimal received = 100)
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
                PaymentDate = DateTime.Parse("01.01.2020")
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

            return location;
        }
    }
}