using Autofac;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Entities.Payments;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Discount;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookKeeperTest.Discounts
{
    [TestClass]
    public class DiscountOperationTest
    {
        private readonly IContainer _container;

        public DiscountOperationTest()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }

        [TestMethod]
        public void AddDiscountOnAccountTest()
        {
           var account = Seed.SeedData().AccountEntity;

            var accountId = account.Id;
            const decimal percent = 25;
            var startDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.02.2020");
            const string description = "Test";

            var expected = new DiscountEntity()
            {
                AccountId = accountId,
                StartDate = startDate,
                EndDate = endDate,
                IsDeleted = false,
                Type = DiscountType.PersonalAccount,
                Description = description,
                Percent = percent,
            };
            var comparer = new DiscountComparer();

            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();
               
                var actual = discountService.AddDiscountOnAccount(accountId, percent, description, startDate, endDate);

                Assert.IsTrue(comparer.Equals(expected, actual));
            }
        }

        [TestMethod]
        public void SendDiscountToArchiveTest()
        {
            var account = Seed.SeedData().AccountEntity;

            var discountToAdd = new DiscountEntity()
            {
                AccountId = account.Id,
                IsArchive = false
            };

            const bool expected = true;

            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();
                discountService.Add(discountToAdd);
                discountService.SendToArchive(discountToAdd);
                var actual = discountService.GetItemById(discountToAdd.Id);

                Assert.AreEqual(expected, actual.IsArchive);
            }
        }

        [TestMethod]
        public void GetCurrentDiscountTest()
        {
            var account = Seed.SeedData().AccountEntity;

            var accountId = account.Id;
            const decimal percent = 25;
            const string description = "Test";
            var paymentDate = DateTime.Parse("01.01.2020");
            var startDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.02.2020");
            var comparer = new CurrentDiscountComparer();

            var expected = new DiscountEntity
            {
                AccountId = accountId,
                StartDate = startDate,
                EndDate = endDate,
                IsDeleted = false,
                Percent = percent,
                Description = description,
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();

                discountService.AddDiscountOnAccount(accountId, percent, description,startDate,endDate);

                var actual = discountService.GetCurrentDiscount(accountId, paymentDate).FirstOrDefault();

                Assert.IsTrue(comparer.Equals(expected, actual));
            }
        }

        [TestMethod]
        public void GetCurrentDiscount_PaymentDayIsEarlier()
        {
            var account = Seed.SeedData().AccountEntity;

            const int accountId = 1;
            const decimal percent = 25;
            const string description = "Test";

            var paymentDate = DateTime.Parse("01.01.2020");
            var startDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.02.2020");
            var comparer = new CurrentDiscountComparer();

            var expected = new DiscountEntity
            {
                AccountId = accountId,
                StartDate = startDate,
                EndDate = endDate,
                IsDeleted = false,
                Percent = percent,
                Description = description,
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();
                var documentService = scope.Resolve<IPaymentDocumentService>();
                documentService.Add(new PaymentDocumentEntity
                {
                    AccountId = accountId,
                    PaymentDate = paymentDate,
                    IsDeleted = false,
                });

                discountService.AddDiscountOnAccount(accountId, percent, description,startDate,endDate);

                var actual = discountService.GetCurrentDiscount(accountId, paymentDate).FirstOrDefault();

                Assert.IsTrue(comparer.Equals(expected, actual));
            }
        }

        [TestMethod]
        public void GetCurrentDiscount_PaymentDataIsLater()
        {
            var account = Seed.SeedData().AccountEntity;

            const int accountId = 1;
            const decimal percent = 25;
            const string description = "Test";
            var paymentDate = DateTime.Parse("01.04.2020");
            var startDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.02.2020");
            var comparer = new CurrentDiscountComparer();

            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();
                var documentService = scope.Resolve<IPaymentDocumentService>();
                documentService.Add(new PaymentDocumentEntity
                {
                    AccountId = accountId,
                    PaymentDate = paymentDate,
                    IsDeleted = false,
                });

                discountService.AddDiscountOnAccount(accountId, percent, description,startDate,endDate);

                var actual = discountService.GetCurrentDiscount(accountId, paymentDate).FirstOrDefault();

                Assert.AreEqual(null,actual);
            }
        }
    }
}