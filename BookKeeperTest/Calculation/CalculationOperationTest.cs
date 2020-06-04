using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.Data.Services.EntityService.Rate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookKeeperTest.Calculation
{
    [TestClass]
    public class CalculationOperationTest
    {
        private readonly IContainer _container;
        private const int SingleOccupant = 1;
        private const int TwoOccupants = 2;

        public CalculationOperationTest()
        {
            _container = AutofacConfiguration.ConfigureContainer(true);
        }

        [TestMethod]
        public void CalculatePriceTest_NoRates_NoDiscount_Paid()
        {
            var paymentDate = DateTime.Now;
            const int accrued = 166;
            const int received = 166;
            const decimal expected = 0;

            var account = Seed.SeedData(accrued, received);

            using (var scope = _container.BeginLifetimeScope())
            {

                var calculationService = scope.Resolve<ICalculationService>();
                var actual =
                    calculationService.CalculateDebt(SingleOccupant, account.AccountEntity.Id, account.LocationEntity, received, paymentDate);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculatePriceTest_NoRates_NoDiscount_Paid_Two_Occupants()
        {

            var paymentDate = DateTime.Now;
            const int accrued = 166;
            const int received = 166;
            const decimal expected = 83;

            var data = Seed.SeedData(accrued, received);

            using (var scope = _container.BeginLifetimeScope())
            {

                var calculationService = scope.Resolve<ICalculationService>();
                var actual =
                    calculationService.CalculateDebt(TwoOccupants, data.AccountEntity.Id, data.LocationEntity, received, paymentDate);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculatePriceTest_NoRates_NoDiscount_UnPaid()
        {
            var paymentDate = DateTime.Now;
            const int accrued = 166;
            const int received = 0;
            const decimal expected = -166;

            var data = Seed.SeedData(accrued, received);

            using (var scope = _container.BeginLifetimeScope())
            {
                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(SingleOccupant, data.AccountEntity.Id, data.LocationEntity, received, paymentDate);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculatePriceTest_OneRate_NoDiscount_Paid()
        {
            const int accrued = 166;
            const int received = 100;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal price = 100;

            const decimal expected = 0;

            var data = Seed.SeedData(accrued);

            var rate = Seed.CreateRate(startDate, endDate, price, data.LocationEntity);

            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();
                rateService.Add(rate);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(SingleOccupant, data.AccountEntity.Id, data.LocationEntity, received, startDate);

                Assert.AreEqual(expected, actual);

            }
        }

        [TestMethod]
        public void CalculatePriceTest_OneRate_NoDiscount_Paid_Two_Occupants()
        {
            const int accrued = 166;
            const int received = 100;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal price = 100;

            const decimal expected = 50;

            var data = Seed.SeedData(accrued);

            var rate = Seed.CreateRate(startDate, endDate, price, data.LocationEntity);

            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();
                rateService.Add(rate);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(TwoOccupants, data.AccountEntity.Id, data.LocationEntity, received, paymentDate);

                Assert.AreEqual(expected, actual);

            }
        }

        [TestMethod]
        public void CalculatePriceTest_OneRate_NoDiscount_UnPaid()
        {
            const int accrued = 166;
            const int received = 0;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal price = 100;

            const decimal expected = -100;

            var data = Seed.SeedData(accrued, received);

            var rate = Seed.CreateRate(startDate, endDate, price, data.LocationEntity);

            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();
                rateService.Add(rate);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(SingleOccupant, data.AccountEntity.Id, data.LocationEntity, received, paymentDate);

                Assert.AreEqual(expected, actual);

            }
        }

        [TestMethod]
        public void CalculateDebt_Paid()
        {
            const int accrued = 166;
            const int received = 200;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal percent = 25;

            const decimal expected = 75.5M;

            var data = Seed.SeedData(accrued, received);

            var discount = Seed.CreateDiscount(data.AccountEntity.Id, startDate, endDate, percent);

            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();
                discountService.Add(discount);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual =
                    calculationService.CalculateDebt(SingleOccupant, data.AccountEntity.Id, data.LocationEntity, received, paymentDate);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculatePriceTest_NoRates_OneDiscount_ZeroPaid()
        {
            const int accrued = 166;
            const int received = 0;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal percent = 25;

            const decimal expected = -124.5M;

            var data = Seed.SeedData(accrued, received);

            var discount = Seed.CreateDiscount(data.AccountEntity.Id, startDate, endDate, percent);

            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();
                discountService.Add(discount);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(SingleOccupant, data.AccountEntity.Id, data.LocationEntity, received, paymentDate);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CalculatePriceTest_OneRate_OneDiscount_Paid()
        {
            const int accrued = 166;
            const int received = 200;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal percent = 25;
            const string description = "test";

            const decimal price = 150;

            const decimal expected = 87.5M;

            var data = Seed.SeedData(accrued, received);

            var rate = Seed.CreateRate(startDate, endDate, price, data.LocationEntity);

            var discount = Seed.CreateDiscount(data.AccountEntity.Id, startDate, endDate, percent);

            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();
                rateService.Add(rate);

                var discountService = scope.Resolve<IDiscountDocumentService>();
                discountService.Add(discount);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(SingleOccupant, data.AccountEntity.Id, data.LocationEntity, received, startDate);

                Assert.AreEqual(expected, actual);

            }
        }

        [TestMethod]
        public void CalculatePriceTest_OneRate_OneDiscount_UnPaid()
        {
            const int accrued = 166;
            const int received = 0;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal percent = 25;
            const string description = "test";

            const decimal price = 150;

            const decimal expected = -112.5M;

            var data = Seed.SeedData(accrued, received);

            var rate = Seed.CreateRate(startDate, endDate, price, data.LocationEntity);

            var discount = Seed.CreateDiscount(data.AccountEntity.Id, startDate, endDate, percent);

            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();
                rateService.Add(rate);

                var discountService = scope.Resolve<IDiscountDocumentService>();
                discountService.Add(discount);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual =
                    calculationService.CalculateDebt(SingleOccupant, data.AccountEntity.Id, data.LocationEntity, received, paymentDate);

                Assert.AreEqual(expected, actual);

            }
        }

        [TestMethod]
        public void CalculateCurrentRate()
        {
            const int accrued = 150;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal percent = 25;

            const decimal price = 150;

            const decimal expected = 112.5M;

            var data = Seed.SeedData(accrued);

            var discount = Seed.CreateDiscount(data.AccountEntity.Id, startDate, endDate, percent);

            var rate = Seed.CreateRate(startDate, endDate, price, data.LocationEntity);

            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();
                rateService.Add(rate);

                var discountService = scope.Resolve<IDiscountDocumentService>();
                discountService.Add(discount);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateCurrentRate(data.LocationEntity.Id, SingleOccupant, data.LocationEntity, paymentDate);

                Assert.AreEqual(expected, actual);

            }
        }
    }
}