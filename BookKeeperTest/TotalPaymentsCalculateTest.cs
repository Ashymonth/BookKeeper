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
    public class TotalPaymentsCalculateTest
    {
        private readonly IContainer _container;

        public TotalPaymentsCalculateTest()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }

        [TestMethod]
        public void CalculateAllPaymentsTest()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ICalculationService>();

                var result = service.CalculateAllPrice(DateTime.Parse("01.01.2020"), DateTime.Parse("01.03.2020"));

                
            }
        }
    }
}
