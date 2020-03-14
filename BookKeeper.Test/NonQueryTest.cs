using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookKeeper.Test
{
    [TestClass]
    public class NonQueryTest
    {
        [TestMethod]
        public void CreateDistrict()
        {
            var mockSet = new Mock<DbSet<AddressEntity>>();

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(n => n.Addresses).Returns(mockSet.Object);

            var service = new AddressService(mockContext.Object);
            service.AddAddress("1");

            mockSet.Verify(m => m.Add(It.IsAny<AddressEntity>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
