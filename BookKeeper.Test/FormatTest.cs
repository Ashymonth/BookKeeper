using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Infrastructure.Formats;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookKeeper.Test
{
    [TestClass]
    public class FormatTest
    {
        [TestMethod]
        public void ExcelFormatTest()
        {
            const string wrongFileExtension = "test.xls";
            const string correctFileExtension = "test.xlsx";

            var correctExtension = ExcelFormatValidator.ValidateFormat(wrongFileExtension);
            var notConvertedFile = ExcelFormatValidator.ValidateFormat(correctFileExtension);

            Assert.AreEqual(correctExtension, $@"C:\Users\{Environment.UserName}\Source\Repos\BookKeeper\BookKeeper.Test\bin\Debug\test.xlsx");
            Assert.AreEqual(correctFileExtension,notConvertedFile);
        }

        [TestMethod]
        public void HtmlFormatTest()
        {
            
            const string wrongFileExtension = @"C:\Users\Lourens\Documents\Материалы\1.htm";
            const string correctFileExtension = "test.html";


            var correctExtension = HtmlFormatValidator.ValidateFormat(wrongFileExtension);
            var notConvertedFile = HtmlFormatValidator.ValidateFormat(correctFileExtension);

            Assert.AreEqual(correctExtension, "1.html");
            Assert.AreEqual(notConvertedFile,correctFileExtension);
        }
    }
}
