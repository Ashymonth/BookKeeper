using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Services.EntityService.Discount;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookKeeperTest
{
    [TestClass]
   public class DicountOpertionTest
   {
       private readonly IContainer _container;

       public DicountOpertionTest(IContainer container)
       {
           _container = container;
       }

       [TestMethod]
        public void SendDiscountToArchiveTest()
        {
            var mock = new Mock<IDiscountDocumentService>();
            mock.Setup(x => x.SendToArchive(new DiscountDocumentEntity
            {
                IsArchive = false,
                EndDate = DateTime.MaxValue
            }));
        }
    }
}
