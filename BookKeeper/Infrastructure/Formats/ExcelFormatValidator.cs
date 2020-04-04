using System;
using Spire.Xls;
using System.IO;

namespace BookKeeper.Data.Infrastructure.Formats
{
    public static class ExcelFormatValidator
    {
        private const string TempFolder = "TempFolder";

        public static string ValidateFormat(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException(nameof(file));

            if (!File.Exists(file))
                throw new FileNotFoundException(nameof(file));

            if (!Path.GetExtension(file).Equals(".xls", StringComparison.OrdinalIgnoreCase))
                return file;

            if (!Directory.Exists(TempFolder))
                Directory.CreateDirectory(TempFolder);

            var workBook = new Workbook();
            workBook.SaveToFile(Path.Combine(TempFolder,file), ExcelVersion.Version2013);
            return Path.GetFullPath($"{Path.GetFileNameWithoutExtension(file)}.xlsx");
        }

        public static void DeleteTempFolder()
        {
          
        }
    }
}
