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
            var startDate = DateTime.Parse("01.02.2020");
            var endDate = DateTime.Parse("01.03.2020");
            const string description = "Test";

            var expected = new DiscountDocumentEntity()
            {
                AccountId = accountWith25PercentDiscount,
                StartDate = DateTime.Now,
                EndDate = DateTime.MaxValue,
                IsDeleted = false,
                Type = DiscountType.PersonalAccount,
                Description = description,
                Percent = percent25,
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();
                var comparer = new DiscountComparer();
                var actual = discountService.AddDiscountOnAccount(accountWith25PercentDiscount, percent25, description);

                Assert.IsTrue(comparer.Equals(expected, actual));

                if (actual != null)
                    discountService.Delete(actual);
            }
        }

        [TestMethod]
        public void AddDiscountOnAddressTest()
        {
            var accounts = new List<int> { 30, 40, 50 };

            const decimal percent = 25;
            const string description = "Test";
            var startDate = DateTime.Parse("01.01.2020");
            var endDate = DateTime.Parse("01.04.2020");

            var discount1 = new DiscountDocumentEntity
            {
                AccountId = accounts[0],
                StartDate = startDate,
                EndDate = endDate,
                IsDeleted = false,
                Percent = percent,
                Description = description,
                Type = DiscountType.Address
            };

            var discount2 = new DiscountDocumentEntity
            {
                AccountId = accounts[1],
                StartDate = startDate,
                EndDate = endDate,
                IsDeleted = false,
                Percent = percent,
                Description = description,
                Type = DiscountType.Address
            };

            var discount3 = new DiscountDocumentEntity
            {
                AccountId = accounts[2],
                StartDate = startDate,
                EndDate = endDate,
                IsDeleted = false,
                Percent = percent,
                Description = description,
                Type = DiscountType.Address
            };

            const bool expected = true;

            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();
                var actual = discountService.AddDiscountOnAddress(accounts, percent, description).ToList();

                const int expectedCount = 3;

                Assert.AreEqual(expectedCount, actual.Count);

                var comparer = new DiscountComparer();
                var firsEquals = comparer.Equals(discount1, actual[0]);
                var secondEquals = comparer.Equals(discount2, actual[1]);
                var thirdEquals = comparer.Equals(discount3, actual[2]);

                Assert.IsTrue(firsEquals);
                Assert.IsTrue(secondEquals);
                Assert.IsTrue(thirdEquals);

                foreach (var discountDocumentEntity in actual)
                {
                    var discount = discountService.GetItemById(discountDocumentEntity.Id);
                    if (discount != null)
                        discountService.Delete(discount);
                }
            }
        }

        [TestMethod]
        public void SendDiscountToArchiveTest()
        {
            var discountToAdd = new DiscountDocumentEntity()
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
            var comparer = new CurrentDiscountComparer();

            var expected = new DiscountDocumentEntity
            {
                AccountId = accountWithDiscount,
                StartDate = DateTime.Now,
                EndDate = DateTime.MaxValue,
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

                var correctDiscount = discountService.AddDiscountOnAccount(accountWithDiscount, percent, description);
                var startDateOutRangeDiscount = discountService.AddDiscountOnAccount(accountWithDiscount, percent, description);
                var endDateOutRangeDiscount = discountService.AddDiscountOnAccount(accountWithDiscount, percent, description);

                var actual = discountService.GetCurrentDiscount(accountWithDiscount, paymentDate);

                Assert.IsTrue(comparer.Equals(expected, actual));


                var discount1 = discountService.GetItemById(correctDiscount.Id);
                if (discount1 != null)
                    discountService.Delete(discount1);

                var discount2 = discountService.GetItemById(startDateOutRangeDiscount.Id);
                if (discount2 != null)
                    discountService.Delete(discount2);

                var discount3 = discountService.GetItemById(endDateOutRangeDiscount.Id);
                if (discount3 != null)
                    discountService.Delete(discount3);
            }
        }

        [TestMethod]
        public void GetCurrentDiscount_StartDateIsLongerThatPaymentDate()
        {
            const int accountWithDiscount = 1;
            const decimal percent = 25;
            const string description = "Test";
            var paymentDate = DateTime.Parse("01.03.2020");
            var lessThatPaymentStartDate = DateTime.Parse("01.12.2019");

            var expected = new DiscountDocumentEntity
            {
                AccountId = accountWithDiscount,
                StartDate = lessThatPaymentStartDate,
                EndDate = DateTime.MaxValue,
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

                var correctDiscount = discountService.AddDiscountOnAccount(accountWithDiscount, percent, description);

                var actual = discountService.GetCurrentDiscount(accountWithDiscount, paymentDate);
                var comparer = new CurrentDiscountComparer();

                Assert.IsTrue(comparer.Equals(expected, actual));

                discountService.Delete(correctDiscount);
            }
        }

        [TestMethod]
        public void GetCurrentDiscount_EndDateIsLessThatPaymentDate()
        {
            const int accountWithDiscount = 1;
            const decimal percent = 25;
            const string description = "Test";
            var paymentDate = DateTime.Parse("01.01.2020");

            var expected = new DiscountDocumentEntity
            {
                AccountId = accountWithDiscount,
                StartDate = DateTime.Now,
                EndDate = DateTime.MaxValue,
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

                var correctDiscount = discountService.AddDiscountOnAccount(accountWithDiscount, percent, description);

                var actual = discountService.GetCurrentDiscount(accountWithDiscount, paymentDate);
                var comparer = new CurrentDiscountComparer();

                Assert.IsTrue(comparer.Equals(expected, actual));

                discountService.Delete(correctDiscount);
            }
        }
    }
}