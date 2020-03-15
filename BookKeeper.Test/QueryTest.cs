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
            var data = new List<AddressEntity>
            {
                new AddressEntity{StreetName = "1"},
                new AddressEntity{StreetName = "2"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<AddressEntity>>();

            mockSet.As<IQueryable<AddressEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AddressEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AddressEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AddressEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Addresses).Returns(mockSet.Object);

            var service = new AddressService(mockContext.Object);
            var addresses = service.GetAddresses();

            Assert.AreEqual(2, addresses.Count());
            Assert.AreEqual("1", addresses[0].StreetName);
            Assert.AreEqual("2", addresses[1].StreetName);


        }
    }
}
