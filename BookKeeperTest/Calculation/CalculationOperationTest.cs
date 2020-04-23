using Autofac;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Entities.Payments;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.Data.Services.EntityService.Rate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BookKeeperTest.Calculation
{
    [TestClass]
    public class CalculationOperationTest
    {
        private readonly IContainer _container;

        public CalculationOperationTest()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }

        [TestMethod]
        public void CalculatePriceTest_NoRates_NoDiscount_Paid()
        {
            var paymentDate = DateTime.Now;
            const int accrued = 166;
            const int received = 166;
            const decimal expected = 0;

            var location = new LocationEntity
            {
                StreetId = 1,
                HouseNumber = "105",
                ApartmentNumber = "100"
            };

            var account = new AccountEntity()
            {
                StreetId = 1,
                Account = 9999,
                LocationId = location.Id,
                IsDeleted = false,
                Location = new LocationEntity
                {
                    StreetId = 1,
                    HouseNumber = "105",
                    ApartmentNumber = "100"
                },
                PaymentDocuments = new List<PaymentDocumentEntity>
                {
                    new PaymentDocumentEntity
                    {
                        IsDeleted = false,
                        PaymentDate = paymentDate,
                        Accrued = accrued
                    }
                }
            };


            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();


                var accountService = scope.Resolve<IAccountService>();
                accountService.Add(account);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(1,account.Id, location, received, paymentDate);

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

            var location = new LocationEntity
            {
                StreetId = 1,
                HouseNumber = "105",
                ApartmentNumber = "100"
            };

            var account = new AccountEntity()
            {
                StreetId = 1,
                Account = 9999,
                LocationId = location.Id,
                IsDeleted = false,
                Location = new LocationEntity
                {
                    StreetId = 1,
                    HouseNumber = "105",
                    ApartmentNumber = "100"
                },
                PaymentDocuments = new List<PaymentDocumentEntity>
                {
                    new PaymentDocumentEntity
                    {
                        IsDeleted = false,
                        PaymentDate = paymentDate,
                        Accrued = accrued
                    }
                }
            };


            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();

                var accountService = scope.Resolve<IAccountService>();
                accountService.Add(account);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(1,account.Id, location, received, paymentDate);

                Assert.AreEqual(expected, actual);

            }
        }

        [TestMethod]
        public void CalculatePriceTest_OneRate_NoDiscount_Paid()
        {

            const string houseNumber = "105";
            const string buildingNumber = "2в";
            const string apartmentNumber = "100";

            const int accrued = 166;
            const int received = 100;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal price = 100;

            const decimal expected = 0;

            var location = new LocationEntity
            {
                StreetId = 1,
                HouseNumber = houseNumber,
                BuildingCorpus = buildingNumber,
                ApartmentNumber = apartmentNumber
            };

            var account = new AccountEntity()
            {
                StreetId = 1,
                Account = 9999,
                LocationId = location.Id,
                IsDeleted = false,
                Location = new LocationEntity
                {
                    StreetId = 1,
                    HouseNumber = "105",
                    ApartmentNumber = "100"
                },
                PaymentDocuments = new List<PaymentDocumentEntity>
                {
                    new PaymentDocumentEntity
                    {
                        IsDeleted = false,
                        PaymentDate = paymentDate,
                        Accrued = accrued
                    }
                }
            };

            var rate = new RateEntity
            {
                StartDate = startDate,
                EndDate = endDate,
                Price = price,
                Description = "Test",

                AssignedLocations = new List<RateDetailsEntity>()
                {
                    new RateDetailsEntity
                    {
                        StreetId = 1,
                        HouseNumber = houseNumber,
                        BuildingNumber = buildingNumber,
                        Location = location
                    }
                }
            };


            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();

                var accountService = scope.Resolve<IAccountService>();
                accountService.Add(account);

                var rateService = scope.Resolve<IRateService>();
                rateService.Add(rate);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(1,account.Id, location, received, paymentDate);

                Assert.AreEqual(expected, actual);

            }
        }

        [TestMethod]
        public void CalculatePriceTest_OneRate_NoDiscount_UnPaid()
        {

            const string houseNumber = "105";
            const string buildingNumber = "2в";
            const string apartmentNumber = "100";

            const int accrued = 166;
            const int received = 0;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal price = 100;

            const decimal expected = -100;

            var location = new LocationEntity
            {
                StreetId = 1,
                HouseNumber = houseNumber,
                BuildingCorpus = buildingNumber,
                ApartmentNumber = apartmentNumber
            };

            var account = new AccountEntity()
            {
                StreetId = 1,
                Account = 9999,
                LocationId = location.Id,
                IsDeleted = false,
                Location = new LocationEntity
                {
                    StreetId = 1,
                    HouseNumber = "105",
                    ApartmentNumber = "100"
                },
                PaymentDocuments = new List<PaymentDocumentEntity>
                {
                    new PaymentDocumentEntity
                    {
                        IsDeleted = false,
                        PaymentDate = paymentDate,
                        Accrued = accrued
                    }
                }
            };

            var rate = new RateEntity
            {
                StartDate = startDate,
                EndDate = endDate,
                Price = price,
                Description = "Test",

                AssignedLocations = new List<RateDetailsEntity>()
                {
                    new RateDetailsEntity
                    {
                        StreetId = 1,
                        HouseNumber = houseNumber,
                        BuildingNumber = buildingNumber,
                        Location = location
                    }
                }
            };


            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();

                var accountService = scope.Resolve<IAccountService>();
                accountService.Add(account);

                var rateService = scope.Resolve<IRateService>();
                rateService.Add(rate);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(1,account.Id, location, received, paymentDate);

                Assert.AreEqual(expected, actual);

            }
        }

        [TestMethod]
        public void CalculatePriceTest_NoRates_OneDiscount_Paid()
        {

            const string houseNumber = "105";
            const string buildingNumber = "2в";
            const string apartmentNumber = "100";

            const int accrued = 166;
            const int received = 200;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal percent = 25;
            const string description = "test";

            const decimal expected = 75.5M;

            var location = new LocationEntity
            {
                StreetId = 1,
                HouseNumber = houseNumber,
                BuildingCorpus = buildingNumber,
                ApartmentNumber = apartmentNumber
            };

            var account = new AccountEntity()
            {
                StreetId = 1,
                Account = 9999,
                LocationId = location.Id,
                IsDeleted = false,
                Location = new LocationEntity
                {
                    StreetId = 1,
                    HouseNumber = "105",
                    ApartmentNumber = "100"
                },
                PaymentDocuments = new List<PaymentDocumentEntity>
                {
                    new PaymentDocumentEntity
                    {
                        IsDeleted = false,
                        PaymentDate = paymentDate,
                        Accrued = accrued
                    }
                }
            };

            var discount = new DiscountEntity
            {
                Account = account,
                StartDate = startDate,
                EndDate = endDate,
                Percent = percent,
                Description = description
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var accountService = scope.Resolve<IAccountService>();
                accountService.Add(account);

                var discountService = scope.Resolve<IDiscountDocumentService>();
                discountService.Add(discount);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(1,account.Id, location, received, paymentDate);

                Assert.AreEqual(expected, actual);

            }
        }

        [TestMethod]
        public void CalculatePriceTest_NoRates_OneDiscount_ZeroPaid()
        {
            const int streetId = 3;
            const string houseNumber = "105";
            const string buildingNumber = "2в";
            const string apartmentNumber = "100";

            const int accrued = 166;
            const int received = 0;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal percent = 25;
            const string description = "test";

            const decimal expected = -124.5M;

            var location = new LocationEntity
            {
                StreetId = streetId,
                HouseNumber = houseNumber,
                BuildingCorpus = buildingNumber,
                ApartmentNumber = apartmentNumber
            };

            var account = new AccountEntity()
            {
                StreetId = streetId,
                Account = 9999,
                LocationId = location.Id,
                IsDeleted = false,
                Location = new LocationEntity
                {
                    StreetId = streetId,
                    HouseNumber = "105",
                    ApartmentNumber = "100"
                },
                PaymentDocuments = new List<PaymentDocumentEntity>
                {
                    new PaymentDocumentEntity
                    {
                        IsDeleted = false,
                        PaymentDate = paymentDate,
                        Accrued = accrued
                    }
                }
            };

            var discount = new DiscountEntity
            {
                Account = account,
                StartDate = startDate,
                EndDate = endDate,
                Percent = percent,
                Description = description
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();

                var accountService = scope.Resolve<IAccountService>();
                accountService.Add(account);

                var discountService = scope.Resolve<IDiscountDocumentService>();
                discountService.Add(discount);

                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(1,account.Id, location, received, paymentDate);

                Assert.AreEqual(expected, actual);

            }
        }

        [TestMethod]
        public void CalculatePriceTest_OneRate_OneDiscount_Paid()
        {
            const string houseNumber = "105";
            const string buildingNumber = "2в";
            const string apartmentNumber = "100";

            const int accrued = 166;
            const int received = 200;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal percent = 25;
            const string description = "test";

            const decimal price = 150;

            const decimal expected = 87.5M;

            var location = new LocationEntity
            {
                StreetId = 2,
                HouseNumber = houseNumber,
                BuildingCorpus = buildingNumber,
                ApartmentNumber = apartmentNumber
            };

            var account = new AccountEntity()
            {
                StreetId = 2,
                Account = 9999,
                LocationId = location.Id,
                IsDeleted = false,
                Location = new LocationEntity
                {
                    StreetId = 2,
                    HouseNumber = "105",
                    BuildingCorpus = "3в",
                    ApartmentNumber = "100"
                },
                PaymentDocuments = new List<PaymentDocumentEntity>
                {
                    new PaymentDocumentEntity
                    {
                        IsDeleted = false,
                        PaymentDate = paymentDate,
                        Accrued = accrued
                    }
                }
            };

            var discount = new DiscountEntity
            {
                Account = account,
                StartDate = startDate,
                EndDate = endDate,
                Percent = percent,
                Description = description
            };

            var rate = new RateEntity
            {
                StartDate = startDate,
                EndDate = endDate,
                Price = price,
                Description = "Test",

                AssignedLocations = new List<RateDetailsEntity>()
                {
                    new RateDetailsEntity
                    {
                        StreetId = 2,
                        HouseNumber = houseNumber,
                        BuildingNumber = buildingNumber,
                        Location = location
                    }
                }
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();

                var accountService = scope.Resolve<IAccountService>();
                accountService.Add(account);

                var rateService = scope.Resolve<IRateService>();
                rateService.Add(rate);

                var discountService = scope.Resolve<IDiscountDocumentService>();
                discountService.Add(discount);


                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(1,account.Id, location, received, paymentDate);

                Assert.AreEqual(expected, actual);

            }
        }

        [TestMethod]
        public void CalculatePriceTest_OneRate_OneDiscount_UnPaid()
        {
            const string houseNumber = "105";
            const string buildingNumber = "2в";
            const string apartmentNumber = "100";

            const int accrued = 166;
            const int received = 0;
            var paymentDate = DateTime.Now;

            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            const decimal percent = 25;
            const string description = "test";

            const decimal price = 150;

            const decimal expected = -112.5M;

            var location = new LocationEntity
            {
                StreetId = 1,
                HouseNumber = houseNumber,
                BuildingCorpus = buildingNumber,
                ApartmentNumber = apartmentNumber
            };

            var account = new AccountEntity()
            {
                StreetId = 1,
                Account = 9999,
                LocationId = location.Id,
                IsDeleted = false,
                Location = new LocationEntity
                {
                    StreetId = 1,
                    HouseNumber = "105",
                    ApartmentNumber = "100"
                },
                PaymentDocuments = new List<PaymentDocumentEntity>
                {
                    new PaymentDocumentEntity
                    {
                        IsDeleted = false,
                        PaymentDate = paymentDate,
                        Accrued = accrued
                    }
                }
            };

            var discount = new DiscountEntity
            {
                Account = account,
                StartDate = startDate,
                EndDate = endDate,
                Percent = percent,
                Description = description
            };

            var rate = new RateEntity
            {
                StartDate = startDate,
                EndDate = endDate,
                Price = price,
                Description = "Test",

                AssignedLocations = new List<RateDetailsEntity>()
                {
                    new RateDetailsEntity
                    {
                        StreetId = 1,
                        HouseNumber = houseNumber,
                        BuildingNumber = buildingNumber,
                        Location = location
                    }
                }
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();

                var accountService = scope.Resolve<IAccountService>();
                accountService.Add(account);

                var rateService = scope.Resolve<IRateService>();
                rateService.Add(rate);

                var discountService = scope.Resolve<IDiscountDocumentService>();
                discountService.Add(discount);


                var calculationService = scope.Resolve<ICalculationService>();
                var actual = calculationService.CalculateDebt(1,account.Id, location, received, paymentDate);

                Assert.AreEqual(expected, actual);

            }
        }
    }
}