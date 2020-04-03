using Autofac;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService.Address;
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
        public void AddRateTest()
        {
            var comparer = new RateComparer();

            var locationEntity = new LocationEntity
            {
                StreetId = 1,
                HouseNumber = "105",
                BuildingCorpus = "2в",
                ApartmentNumber = "100",
            };

            const int price = 200;
            const string description = "Test";
            var starDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.03.2020");

            var expected = new RateEntity
            {
                StartDate = starDate,
                EndDate = endDate,
                Description = description,
                Price = price
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();
                var location = locationService.Add(locationEntity);


                var rateService = scope.Resolve<IRateService>();
                var actual = rateService.AddRate(locationEntity, description, price, starDate, endDate);

                Assert.IsTrue(comparer.Equals(expected, actual));
                locationService.Delete(location);
                rateService.Delete(actual);
            }
        }

        [TestMethod]
        public void ChangeRatePriceTest()
        {
            var comparer = new RateComparer();

            var locationEntity = new LocationEntity
            {
                StreetId = 1,
                HouseNumber = "105",
                BuildingCorpus = "2в",
                ApartmentNumber = "100",
            };

            const int price = 200;
            const string description = "Test";
            const decimal newPrice = 300;
            var starDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.03.2020");

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
                var locationService = scope.Resolve<ILocationService>();
                var location = locationService.Add(locationEntity);


                var rateService = scope.Resolve<IRateService>();
                var rate = rateService.AddRate(locationEntity, description, price, starDate, endDate);

                var actual = rateService.ChangeRatePrice(rate, newPrice);

                Assert.AreEqual(expected.Price, actual.Price);
                Assert.AreEqual(expected.IsArchive, rate.IsArchive);

                locationService.Delete(location);
                rateService.Delete(rate);
                rateService.Delete(actual);
            }
        }

        [TestMethod]
        public void GetCurrentRateTest()
        {
            var locationEntity = new LocationEntity
            {
                StreetId = 1,
                HouseNumber = "105",
                BuildingCorpus = "2в",
                ApartmentNumber = "100",
            };

            const int price = 200;
            const string description = "Test";
            var paymentDate = DateTime.Parse("01.01.2020");
            var starDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.03.2020");

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
                var locationService = scope.Resolve<ILocationService>();
                var location = locationService.Add(locationEntity);


                var rateService = scope.Resolve<IRateService>();
                var rate = rateService.AddRate(locationEntity, description, price, starDate, endDate);

                var actual = rateService.GetCurrentRate(locationEntity, paymentDate);

                Assert.AreEqual(expected.Price, actual);

                locationService.Delete(location);
                rateService.Delete(rate);
            }
        }

        [TestMethod]
        public void GetCurrentRateTest_StartDayLessThatPaymentDate()
        {
            var comparer = new RateComparer();

            var locationEntity = new LocationEntity
            {
                StreetId = 1,
                HouseNumber = "105",
                BuildingCorpus = "2в",
                ApartmentNumber = "100",
            };

            const int price = 200;
            const string description = "Test";
            var paymentDate = DateTime.Parse("01.01.2020");
            var StarDateLessThatPaymentDate = DateTime.Parse("01.12.2019");
            var endDate = DateTime.Parse("01.03.2020");

            var expected = new RateEntity
            {
                StartDate = StarDateLessThatPaymentDate,
                EndDate = endDate,
                Description = description,
                Price = price,
                IsArchive = true
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();
                var location = locationService.Add(locationEntity);

                var rateService = scope.Resolve<IRateService>();
                var rate = rateService.AddRate(locationEntity, description, price, StarDateLessThatPaymentDate,
                    endDate);

                var actual = rateService.GetCurrentRate(locationEntity, paymentDate);

                Assert.AreEqual(expected.Price, actual);

                locationService.Delete(location);
                rateService.Delete(rate);
            }
        }

        [TestMethod]
        public void GetCurrentRateTest_EndDayLessThatPaymentDate()
        {
            var locationEntity = new LocationEntity
            {
                StreetId = 1,
                HouseNumber = "105",
                BuildingCorpus = "2в",
                ApartmentNumber = "100",
            };

            const int price = 200;
            const string description = "Test";
            var paymentDate = DateTime.Parse("01.01.2020");
            var startDate = DateTime.Parse("01.01.2020");
            var endDateLessThatPaymentDate = DateTime.Parse("01.03.2020");

            var expected = new RateEntity
            {
                StartDate = startDate,
                EndDate = endDateLessThatPaymentDate,
                Description = description,
                Price = price,
                IsArchive = true
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();
                var location = locationService.Add(locationEntity);

                var rateService = scope.Resolve<IRateService>();
                var rate = rateService.AddRate(locationEntity, description, price, startDate,
                    endDateLessThatPaymentDate);

                var actual = rateService.GetCurrentRate(locationEntity, paymentDate);

                Assert.AreEqual(expected.Price, actual);

                locationService.Delete(location);
                rateService.Delete(rate);
            }
        }

        [TestMethod]
        public void GetCurrentRateTest_GetDefaultRateWhenUserNotHaveAnyDateRangeRate()
        {
            var locationEntity = new LocationEntity
            {
                StreetId = 1,
                HouseNumber = "105",
                BuildingCorpus = "2в",
                ApartmentNumber = "100",
            };

            var paymentDate = DateTime.Parse("01.01.2020");

            const int expected = 166;

            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();
                var location = locationService.Add(locationEntity);

                var rateService = scope.Resolve<IRateService>();

                var actual = rateService.GetCurrentRate(locationEntity, paymentDate);

                Assert.AreEqual(expected, actual);

                locationService.Delete(location);
            }
        }

        [TestMethod]
        public void GetCurrentRateTest_GetDefaultRateWithUserOutPaymentRange()
        {
            var locationEntity = new LocationEntity
            {
                StreetId = 1,
                HouseNumber = "105",
                BuildingCorpus = "2в",
                ApartmentNumber = "100",
            };

            const int price = 166;
            const string description = "Test";
            var paymentDate = DateTime.Parse("01.01.2020");
            var startDate = DateTime.Parse("01.01.209");
            var endDateLessThatPaymentDate = DateTime.Parse("01.02.2019");

            var expected = new RateEntity
            {
                StartDate = startDate,
                EndDate = endDateLessThatPaymentDate,
                Description = description,
                Price = price,
                IsArchive = true
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();
                var location = locationService.Add(locationEntity);

                var rateService = scope.Resolve<IRateService>();
                var rate = rateService.AddRate(locationEntity, description, price, startDate,
                    endDateLessThatPaymentDate);

                var actual = rateService.GetCurrentRate(locationEntity, paymentDate);

                Assert.AreEqual(expected.Price, actual);

                locationService.Delete(location);
                rateService.Delete(rate);
            }
        }
    }
}