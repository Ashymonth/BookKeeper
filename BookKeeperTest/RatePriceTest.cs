using Autofac;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using BookKeeper.Data.Services.EntityService.Rate;

namespace BookKeeperTest
{
    [TestClass]
    public class RatePriceTest
    {
        private readonly IContainer _container;
        public RatePriceTest()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }

        [TestMethod]
        public void GetCurrentRateTest()
        {
            var location = new LocationEntity()
            {
                HouseNumber = "105",
                BuildingCorpus = "2в",
                StreetId = 1
            };

            var paymentDate = DateTime.Parse("01.01.2020");

            const int expected = 200;

            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();
                var actual = rateService.GetCurrentRate(location, paymentDate);
                Assert.AreEqual(expected,actual);
            }
        }

        [TestMethod]
        public void ChangeRatePriceTest()
        {
            var location = new LocationEntity()
            {
                HouseNumber = "105",
                BuildingCorpus = "2в",
                StreetId = 1
            };
            const decimal expected = 900;
            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();
                var rate = rateService.GetWithInclude(x =>
                    x.IsDeleted == false && x.StartDate.Date == DateTime.Parse("01.01.2020") && x.EndDate.Date == DateTime.Parse("02.04.2020"),
                    x=>x.AssignedLocations);

                var currentRate = rate.SingleOrDefault(x => x.AssignedLocations.FirstOrDefault(z =>
                    z.HouseNumber.Equals(location.HouseNumber, StringComparison.OrdinalIgnoreCase) && 
                    z.BuildingNumber.Equals(location.BuildingCorpus,StringComparison.OrdinalIgnoreCase)) != null);


                var actual = rateService.ChangeRatePrice(currentRate, 900);
                Assert.AreEqual(expected, actual.Price);
            }
        }

        [TestMethod]
        public void CalculatePriceWithDefaultRateTest()
        {
            var dateTo = DateTime.Parse("01.03.2020");
            const int received = 166;
            const int expected = 0;

            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ICalculationService>();

                var actual = service.CalculatePrice(2, new LocationEntity()
                {
                    BuildingCorpus = "1",
                    HouseNumber = "2"
                }, received, dateTo);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculatePriceWithUserRate()
        {
            var dateTo = DateTime.Parse("01.01.2020");
            var recieved = 200;
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ICalculationService>();

                var actual = service.CalculatePrice(1, new LocationEntity()
                {
                    StreetId = 1,
                    HouseNumber = "105",
                    BuildingCorpus = "2в"
                }, recieved, dateTo);

                var expected = 0;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculatePriceWithTwoPossibleDiscounts()
        {
            var date = DateTime.Parse("05.11.2019");
            var recieved = 500;
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ICalculationService>();

                var actual = service.CalculatePrice(1, new LocationEntity()
                {
                    StreetId = 1,
                    HouseNumber = "105",
                    BuildingCorpus = "2в"
                }, recieved, date);

                var expected = 0;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculatePriceWithLastDayOfRate()
        {
            var date = DateTime.Parse("01.12.2019");
            var recieved = 500;
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ICalculationService>();

                var actual = service.CalculatePrice(1, new LocationEntity()
                {
                    StreetId = 1,
                    HouseNumber = "105",
                    BuildingCorpus = "2в"
                }, recieved, date);

                var expected = 0;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculatePriceWithOutRangeRate()
        {
            var dateTo = DateTime.Parse("01.05.2020");
            var recieved = 166;
            var expected = 0;
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ICalculationService>();

                var actual = service.CalculatePrice(2, new LocationEntity(), recieved, dateTo);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculateWithMoq()
        {

        }
    }
}