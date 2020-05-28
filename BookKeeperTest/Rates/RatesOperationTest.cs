using Autofac;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService.Rate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookKeeperTest.Rates
{
    [TestClass]
    public class RatesOperationTest
    {
        private readonly IContainer _container;


        public RatesOperationTest()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }

        [TestMethod]
        public void AddRate_WhenNotArchiveRateExist()
        {
            var location = Seed.SeedData();

            var comparer = new RateComparer();

            const int price = 200;
            const string description = "Test";
            var starDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.02.2020");

            var expected = new RateEntity
            {
                StartDate = starDate,
                EndDate = endDate,
                Description = description,
                Price = price,
                IsArchive = true
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();

                var actual = rateService.AddRate(location, description, price, starDate, endDate);
                rateService.AddRate(location, description, price);

                Assert.IsTrue(comparer.Equals(expected, actual));
                Assert.AreEqual(expected.IsArchive, actual.IsArchive);
            }
        }

        [TestMethod]
        public void ChangeRatePriceTest()
        {
            var location = Seed.SeedData();

            const int price = 200;
            const string description = "Test";
            const decimal newPrice = 300;
            var starDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.02.2020");

            var expected = new RateEntity
            {
                StartDate = starDate,
                EndDate = endDate,
                Description = description,
                Price = newPrice,
                IsArchive = true
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();
                var rate = rateService.AddRate(location, description, price, starDate, endDate);

                var actual = rateService.ChangeRatePrice(rate, newPrice, endDate);

                Assert.AreEqual(expected.Price, actual.Price);
                Assert.AreEqual(expected.IsArchive, rate.IsArchive);
            }
        }

        [TestMethod]
        public void GetCurrentRateTest()
        {
            var location = Seed.SeedData();

            const int occupants = 1;
            const int price = 200;
            const string description = "Test";
            var paymentDate = DateTime.Parse("01.01.2020");
            var startDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.02.2020");

            var expected = new RateEntity
            {
                StartDate = startDate,
                EndDate = endDate,
                Description = description,
                Price = price,
                IsArchive = true
            };

            using (var scope = _container.BeginLifetimeScope())
            {

                var rateService = scope.Resolve<IRateService>();
                var rate = rateService.AddRate(location, description, price, startDate, endDate);

                var actual = rateService.GetCurrentRate(occupants, location, paymentDate);

                Assert.AreEqual(expected.Price, actual);
            }
        }

        [TestMethod]
        public void GetCurrentRateTest_GetDefaultRateWhenUserNotHaveAnyDateRangeRate()
        {
            var location = Seed.SeedData();

            var paymentDate = DateTime.Parse("01.01.2020");

            const int occupants = 1;
            const int expected = 166;

            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();

                var actual = rateService.GetCurrentRate(occupants, location, paymentDate);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void GetCurrentRateTest_GetDefaultRateWithUserOutPaymentRange()
        {
            var location = Seed.SeedData();

            const int occupants = 1;
            const int price = 166;
            const string description = "Test";
            var paymentDate = DateTime.Parse("01.01.2020");
            var startDate = DateTime.Parse("01.01.209");
            var endDateLessThatPaymentDate = DateTime.Parse("01.02.2019");

            const int expected = 166;

            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();
                var rate = rateService.AddRate(location, description, price, startDate, endDateLessThatPaymentDate);

                var actual = rateService.GetCurrentRate(occupants, location, paymentDate);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void GetCurrentRateTest_GetDefaultRateWithUserOutPaymentRangeWith2Occupants()
        {
            var location = Seed.SeedData();

            const int occupants = 2;
            const int price = 83;
            const string description = "Test";
            var paymentDate = DateTime.Parse("01.01.2020");
            var startDate = DateTime.Parse("01.01.209");
            var endDateLessThatPaymentDate = DateTime.Parse("01.02.2019");

            const int expected = 83;

            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();
                var rate = rateService.AddRate(location, description, price, startDate, endDateLessThatPaymentDate);

                var actual = rateService.GetCurrentRate(occupants, location, paymentDate);

                Assert.AreEqual(expected, actual);
            }
        }
    }
}