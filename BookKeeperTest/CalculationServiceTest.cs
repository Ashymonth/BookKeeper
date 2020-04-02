using Autofac;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookKeeperTest
{
    [TestClass]
    public class CalculationServiceTest
    {
        private readonly IContainer _container;
        private const decimal DefaultRecieved = 166;
        private const int TestAccountWithoutDiscount = 18;

        private readonly LocationEntity _testLocationWithDiscount = new LocationEntity
        {
            HouseNumber = "105",
            BuildingCorpus = "2в"
        };

        public CalculationServiceTest()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }

        [TestMethod]
        public void CalculateWithUserRateAndWithoutDiscount()
        {
            var date = DateTime.Parse("01.01.2020");
            const int expected = -34;

            using (var scope = _container.BeginLifetimeScope())
            {
                var calculateService = scope.Resolve<ICalculationService>();
                var actual =
                    calculateService.CalculatePrice(TestAccountWithoutDiscount, _testLocationWithDiscount, DefaultRecieved, date);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculateWithDefaultRateAndWithoutDiscount()
        {
            var date = DateTime.Parse("01.01.2020");
            const int expected = -34;

            using (var scope = _container.BeginLifetimeScope())
            {
                var calculateService = scope.Resolve<ICalculationService>();
                var actual =
                    calculateService.CalculatePrice(TestAccountWithoutDiscount, _testLocationWithDiscount, DefaultRecieved, date);

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
