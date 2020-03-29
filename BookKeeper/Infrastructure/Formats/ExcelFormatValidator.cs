using System;
using Spire.Xls;
using System.IO;

namespace BookKeeper.Data.Infrastructure.Formats
{
    public static class ExcelFormatValidator
    {
        public static string ValidateFormat(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException(nameof(file));

            if (!File.Exists(file))
                throw new FileNotFoundException(nameof(file));

            if (!Path.GetExtension(file).Equals(".xls", StringComparison.OrdinalIgnoreCase))
                return file;

            var workBook = new Spire.Xls.Workbook();
            workBook.SaveToFile(file, ExcelVersion.Version2013);
            return Path.GetFullPath($"{Path.GetFileNameWithoutExtension(file)}.xlsx");

        }
    }
}
