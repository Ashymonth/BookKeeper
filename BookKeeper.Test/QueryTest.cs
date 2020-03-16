using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BookKeeper.Test
{
    [TestClass]
    public class QueryTest
    {
        [TestMethod]
        public void GetAllAddresses()
        {
            var data = new List<StreetEntity>
            {
                new StreetEntity{StreetName = "1"},
                new StreetEntity{StreetName = "2"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<StreetEntity>>();

            mockSet.As<IQueryable<StreetEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StreetEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StreetEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StreetEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Streets).Returns(mockSet.Object);

            var service = new AddressService(mockContext.Object);
            var addresses = service.GetAddresses();

            Assert.AreEqual(2, addresses.Count());
            Assert.AreEqual("1", addresses[0].StreetName);
            Assert.AreEqual("2", addresses[1].StreetName);


        }
    }
}
