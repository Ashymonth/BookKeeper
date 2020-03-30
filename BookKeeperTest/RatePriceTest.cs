using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void CalculatePriceTest()
        {
            var dateFrom = DateTime.Parse("01.01.2020");
            var dateTo = DateTime.Parse("01.03.2020");
            const int accrued = 400;
            const int received = 300;

            const int expected = -100;

            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ICalculationService>();

                var actual = service.CalculatePrice(1, 2, accrued, received, dateTo);

                Assert.AreEqual(expected, actual);
            }

        }
    }
}
