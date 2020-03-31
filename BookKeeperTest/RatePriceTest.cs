using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Rate;
using Moq;
namespace BookKeeperTest
{
    [TestClass]
    public class RatePriceTest
    {
        private readonly IContainer _container;
        private const int Received = 300;
        public RatePriceTest()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }
        [TestMethod]
        public void CalculatePriceWithDefaultRateTest()
        {
            Func<RateEntity, bool> predicatExpression = entity => entity.IsDeleted == false;
            Func<AccountEntity, bool> accountPredicate = entity => entity.IsDeleted == false;

            var mockRate = new Mock<IRateService>();
            mockRate.Setup(x => x.GetItem(predicatExpression)).Returns((() => new RateEntity()
            {
                Id = 1,
                StartDate = DateTime.Parse("01.01.2020"),
                EndDate = DateTime.Parse("01.03.2020"),
                Description = "Test",
                IsArchive = false,
                IsDefault = false,
                AssignedLocations = new List<RateDetailsEntity>()
                {
                    new RateDetailsEntity()
                    {
                        Location = new LocationEntity()
                        {
                            Id = 1,
                            HouseNumber = "105",
                            BuildingCorpus = "2в",
                            ApartmentNumber = "100",
                            StreetId = 1,
                            IsDeleted = false
                        }
                    }
                }
            }));

            var mockAccount = new Mock<IAccountService>();
            mockAccount.Setup(x => x.GetItem(accountPredicate)).Returns(() => new AccountEntity
            {
                Account = 9999,
                Id = 1,
                AccountType = AccountType.Private,
                LocationId = 1
            });

            var dateFrom = DateTime.Parse("01.01.2020");
            var dateTo = DateTime.Parse("01.03.2020");
            const int received = 300;

            const int expected = 134;

            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ICalculationService>();

                var actual = service.CalculatePrice(2, 2, received, dateTo);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculatePriceWithUserRate()
        {
            var dateTo = DateTime.Parse("01.03.2020");
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ICalculationService>();

                var actual = service.CalculatePrice(1, 1, Received, dateTo);

                var expected = 100;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculatePriceWithOverdraft()
        {
            var dateTo = DateTime.Parse("01.03.2020");
            var recieved = 100;
            var expected = -100;
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ICalculationService>();

                var actual = service.CalculatePrice(2, 1, recieved, dateTo);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculatePriceWithDiscount()
        {
            var dateTo = DateTime.Parse("01.03.2020");
            var recieved = 200;
            var expected = 50;
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ICalculationService>();

                var actual = service.CalculatePrice(3809, 1, recieved, dateTo);

                Assert.AreEqual(expected, actual);
            }

        }
    }
}