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
            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
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
                var actual = discountService.AddDiscountOnAccount(accountWith25PercentDiscount, percent25, description);

                Assert.IsTrue(comparer.Equals(expected, actual));

                discountService.Delete(actual);
            }
        }

        [TestMethod]
        public void AddDiscountOnAddressTest()
        {
            var accounts = new List<int> { 30, 40, 50 };

            const decimal percent = 25;
            const string description = "Test";
            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;

            var discount1 = new DiscountEntity
            {
                AccountId = accounts[0],
                StartDate = startDate,
                EndDate = endDate,
                IsDeleted = false,
                Percent = percent,
                Description = description,
                Type = DiscountType.Address
            };

            var discount2 = new DiscountEntity
            {
                AccountId = accounts[1],
                StartDate = startDate,
                EndDate = endDate,
                IsDeleted = false,
                Percent = percent,
                Description = description,
                Type = DiscountType.Address
            };

            var discount3 = new DiscountEntity
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
            var paymentDate = DateTime.Now;
            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;
            var comparer = new CurrentDiscountComparer();

            var expected = new DiscountEntity
            {
                AccountId = accountWithDiscount,
                StartDate =startDate,
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

                var correctDiscount = discountService.AddDiscountOnAccount(accountWithDiscount, percent, description);
                var startDateOutRangeDiscount = discountService.AddDiscountOnAccount(accountWithDiscount, percent, description);
                var endDateOutRangeDiscount = discountService.AddDiscountOnAccount(accountWithDiscount, percent, description);

                var actual = discountService.GetCurrentDiscount(accountWithDiscount, paymentDate);

                //Assert.IsTrue(comparer.Equals(expected, actual));

                discountService.Delete(correctDiscount);

                discountService.Delete(startDateOutRangeDiscount);

                discountService.Delete(endDateOutRangeDiscount);
            }
        }

        [TestMethod]
        public void GetCurrentDiscount_PaymentDayIsEarlier()
        {
            const int accountWithDiscount = 1;
            const decimal percent = 25;
            const string description = "Test";
            var paymentDate = DateTime.Now.AddMonths(-1);

            DiscountEntity expected = null;

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

                Assert.AreEqual(expected, actual);

                discountService.Delete(correctDiscount);
            }
        }

        [TestMethod]
        public void GetCurrentDiscount_PaymentDataIsLater()
        {
            const int accountWithDiscount = 1;
            const decimal percent = 25;
            const string description = "Test";
            var paymentDate = DateTime.Parse("01.08.2020");
            var startDate = DateTime.Now;
            var endDate = DateTime.MaxValue;

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

                var correctDiscount = discountService.AddDiscountOnAccount(accountWithDiscount, percent, description);

                var actual = discountService.GetCurrentDiscount(accountWithDiscount, paymentDate);
                var comparer = new CurrentDiscountComparer();

                //Assert.IsTrue(comparer.Equals(expected, actual));

                discountService.Delete(correctDiscount);
            }
        }
    }
}