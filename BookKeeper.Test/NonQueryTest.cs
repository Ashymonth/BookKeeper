using System;
using System.Collections.Generic;
using System.Linq;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Models.ExcelImport;
using BookKeeper.Data.Services.Import;
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
           var import = new List<ImportDataRow>
           {
               new ImportDataRow
               {
                   District = new DistrictImport
                   {
                       Name = "Чеченский",
                       Code = 232323
                   }
               },
               new ImportDataRow
               {
                   District = new DistrictImport
                   {
                       Name = "Кировский",
                       Code = 123
                   },
               },
               new ImportDataRow
               {
                   District = new DistrictImport
                   {
                       Name = "Кировский",
                       Code = 123
                   }
               },
               new ImportDataRow
               {
                   District = new DistrictImport
                   {
                       Name = "Чеченский",
                       Code = 343434
                   }
               }
           };
           IEnumerable<IGrouping<string, int>> query =
               import.GroupBy(name => name.District.Name, name => name.District.Code).ToList();

     


        }
    }
}
