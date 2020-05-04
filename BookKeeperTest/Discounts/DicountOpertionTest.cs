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
            const int accountWith25PercentDiscount = 1;
            const decimal percent25 = 25;
            var startDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.02.2020");
            const string description = "Test";

            var expected = new DiscountEntity()
            {
                AccountId = accountWith25PercentDiscount,
                StartDate = startDate,
                EndDate = endDate,
                IsDeleted = false,
                Type = DiscountType.PersonalAccount,
                Description = description,
                Percent = percent25,
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();
                var comparer = new DiscountComparer();
                var actual = discountService.AddDiscountOnAccount(accountWith25PercentDiscount, percent25, description, startDate, endDate);

                Assert.IsTrue(comparer.Equals(expected, actual));

                discountService.Delete(actual);
            }
        }

        [TestMethod]
        public void SendDiscountToArchiveTest()
        {
            var discountToAdd = new DiscountEntity()
            {
                AccountId = 20,
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

                discountService.Delete(actual);
            }
        }

        [TestMethod]
        public void GetCurrentDiscountTest()
        {
            const int accountWithDiscount = 1;
            const decimal percent = 25;
            const string description = "Test";
            var paymentDate = DateTime.Parse("01.01.2020");
            var startDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.02.2020");
            var comparer = new CurrentDiscountComparer();

            var expected = new DiscountEntity
            {
                AccountId = accountWithDiscount,
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
                    AccountId = accountWithDiscount,
                    PaymentDate = paymentDate,
                    IsDeleted = false,
                });

                var correctDiscount = discountService.AddDiscountOnAccount(accountWithDiscount, percent, description,startDate,endDate);

                var actual = discountService.GetCurrentDiscount(accountWithDiscount, paymentDate).FirstOrDefault();

                Assert.IsTrue(comparer.Equals(expected, actual));

                discountService.Delete(correctDiscount);
            }
        }

        [TestMethod]
        public void GetCurrentDiscount_PaymentDayIsEarlier()
        {
            const int accountWithDiscount = 1;
            const decimal percent = 25;
            const string description = "Test";

            var paymentDate = DateTime.Parse("01.01.2020");
            var startDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.02.2020");
            var comparer = new CurrentDiscountComparer();

            var expected = new DiscountEntity
            {
                AccountId = accountWithDiscount,
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
                    AccountId = accountWithDiscount,
                    PaymentDate = paymentDate,
                    IsDeleted = false,
                });

                var correctDiscount = discountService.AddDiscountOnAccount(accountWithDiscount, percent, description,startDate,endDate);

                var actual = discountService.GetCurrentDiscount(accountWithDiscount, paymentDate).FirstOrDefault();

                Assert.IsTrue(comparer.Equals(expected, actual));

                discountService.Delete(correctDiscount);
            }
        }

        [TestMethod]
        public void GetCurrentDiscount_PaymentDataIsLater()
        {
            const int accountWithDiscount = 1;
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
                    AccountId = accountWithDiscount,
                    PaymentDate = paymentDate,
                    IsDeleted = false,
                });

                var correctDiscount = discountService.AddDiscountOnAccount(accountWithDiscount, percent, description,startDate,endDate);

                var actual = discountService.GetCurrentDiscount(accountWithDiscount, paymentDate).FirstOrDefault();

                Assert.AreEqual(null,actual);

                discountService.Delete(correctDiscount);
            }
        }
    }
}