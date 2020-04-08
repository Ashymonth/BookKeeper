using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService.Rate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookKeeperTest
{
    [TestClass]
    public class RateTest
    {
        private readonly IContainer _container;

        public RateTest()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }

        [TestMethod]
        public void AddRate()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();

                for (int i = 1; i < 10; i++)
                {
                    rateService.Add(new RateEntity
                    {
                        Price = 100,
                        StartDate = DateTime.Parse($"0{i}.04.2020"),
                        EndDate = DateTime.Parse($"0{i}.05.2020"),
                        AssignedLocations = new List<RateDetailsEntity>()
                        {
                            new RateDetailsEntity()
                            {
                                HouseNumber = "1",
                                StreetId = 2,
                                LocationRefId = 2,
                                Id = i
                            }
                        }
                    });
                }
            }
        }
    }
}
