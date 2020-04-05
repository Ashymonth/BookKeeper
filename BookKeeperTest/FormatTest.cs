using BookKeeper.Data.Infrastructure.Formats;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookKeeperTest
{
    [TestClass]
    public class FormatTest
    {
        [TestMethod]
        public void ExcelFormatTest()
        {
            const string wrongFileExtension = "test.xls";
            const string correctFileExtension = "test.xlsx";

            var correctExtension = ExcelExtensionConverter.ConvertToXlsx(wrongFileExtension);
            var notConvertedFile = ExcelExtensionConverter.ConvertToXlsx(correctFileExtension);

            Assert.AreEqual(correctExtension, $@"C:\Users\{Environment.UserName}\Source\Repos\BookKeeper\BookKeeper.Test\bin\Debug\test.xlsx");
            Assert.AreEqual(correctFileExtension, notConvertedFile);
        }

        [TestMethod]
        public void HtmlFormatTest()
        {

            const string wrongFileExtension = @"C:\Users\Lourens\Documents\Материалы\1.htm";
            const string correctFileExtension = "test.html";


            var correctExtension = HtmlExtensionConverter.ConvertToHtml(wrongFileExtension);
            var notConvertedFile = HtmlExtensionConverter.ConvertToHtml(correctFileExtension);

            Assert.AreEqual(correctExtension, "1.html");
            Assert.AreEqual(notConvertedFile, correctFileExtension);
        }
    }
}
