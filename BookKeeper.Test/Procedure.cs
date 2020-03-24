using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Address;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookKeeper.Test
{
    [TestClass]
    public class Procedure
    {
        private readonly IContainer _container;
        public Procedure()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }
        [TestMethod]
        public void Filter()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var addressService = scope.Resolve<IStreetService>();
                var addresses = addressService.GetItems();

                var accountService = scope.Resolve<IAccountService>();
                var accounts = accountService.GetItems(x=>x.IsArchive == false);
                var locationsService = scope.Resolve<ILocationService>();
                
               
            }
        }
    }
}
