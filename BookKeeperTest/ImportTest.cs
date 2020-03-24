using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.Load;

namespace BookKeeperTest
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
        public void LoadExcelData()
        {
            var loader = _container.ResolveNamed<IDataLoader>("Excel");

            loader.LoadData($"C:\\Users\\{Environment.UserName}\\Documents\\Материалы\\1.xlsx");

            Assert.AreEqual(1, 1);

        }

        [TestMethod]
        public void LoadHtmlData()
        {
            var container = AutofacConfiguration.ConfigureContainer();
            var import = _container.ResolveNamed<IDataLoader>("Html");
            import.LoadData($"C:\\Users\\{Environment.UserName}\\Documents\\Материалы\\4.html");

        }
    }
}
