using System;
using Autofac;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Repositories;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService.Discount;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookKeeperTest
{
    [TestClass]
    public class DiscountPriceTest
    {
        private readonly IContainer _container;
        private const int TestAccountWithoutDiscount = 18;
        private const int TestAccountIdWithoutDiscount = 17;
        private readonly DateTime paymentDate = Convert.ToDateTime("01.01.2020");

        public DiscountPriceTest()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }

        [TestMethod]
        public void GetCurrentDiscountWithoutPercent()
        {
            var documentEntity = new DiscountDocumentEntity()
            {
                AccountId = TestAccountWithoutDiscount,
                StartDate = DateTime.Now
            };
            Func<DiscountDocumentEntity, bool> predicate = x =>
                x.AccountId == TestAccountIdWithoutDiscount && x.StartDate.Date <= paymentDate.Date && paymentDate.Date < x.EndDate.Date &&
                x.IsDeleted == false;

            var repositoryMock = new Mock<IRepository<DiscountDocumentEntity>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var discountDocumentService = new DiscountDocumentService(repositoryMock.Object, unitOfWork.Object);

            repositoryMock.Setup(x => x.GetItem(predicate)).Returns(documentEntity);

            var actual = discountDocumentService.GetCurrentDiscount(TestAccountWithoutDiscount, paymentDate);

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void GetCurrentDiscountPercent()
        {
            const decimal expected = 25;
            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();
                var actual = discountService.GetCurrentDiscount(TestAccountIdWithoutDiscount, paymentDate);

                Assert.AreEqual(expected, actual.Percent);
            }
        }

        [TestMethod]
        public void GetCurrentDiscountWithNotActualPaymentDate()
        {
            var date = DateTime.Parse("01.01.2019");
            DiscountDocumentEntity expected = null;
            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();
                var actual = discountService.GetCurrentDiscount(TestAccountIdWithoutDiscount, date);

                Assert.AreEqual(expected, actual?.Percent);
            }
        }
    }
}
