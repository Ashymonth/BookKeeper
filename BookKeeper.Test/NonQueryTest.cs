using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Models.ExcelImport;
using BookKeeper.Data.Services.Import;
using BookKeeper.Data.Services.Load;
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

        [TestMethod]
        public void DistinctTest()
        {
            var container = AutofacConfiguration.ConfigureContainer();

            var excelImport = container.Resolve<IImportService>();
            var result = excelImport.ImportDataRow("");

            var loader = container.Resolve<IDataLoader>();

            loader.LoadData("");

        }
    }
}
