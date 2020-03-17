using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Payments;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Models.ExcelImport;
using BookKeeper.Data.Models.HtmlImport;
using BookKeeper.Data.Services.Import;
using BookKeeper.Data.Services.Load;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookKeeper.Test
{
    [TestClass]
    public class ImportTest
    {
        private readonly IContainer _container;

        public ImportTest()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }
        [TestMethod]
        public void CreateDistrict()
        {
            var mockSet = new Mock<DbSet<StreetEntity>>();

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(n => n.Streets).Returns(mockSet.Object);

            var service = new AddressService(mockContext.Object);
            service.AddAddress("1");

            mockSet.Verify(m => m.Add(It.IsAny<StreetEntity>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void LoadExcelData()
        {
            var loader = _container.ResolveNamed<IDataLoader>("Excel");

            loader.LoadData($"C:\\Users\\{Environment.UserName}\\Documents\\Материалы\\1.xlsx");

        }

        [TestMethod]
        public void LoadHtmlData()
        {
            var container = AutofacConfiguration.ConfigureContainer();
            var import = _container.ResolveNamed<IDataLoader>("Html");
            import.LoadData("C:\\Users\\Ashym\\Documents\\Материалы\\1.html");

        }
    }
}
