using System;
using Spire.Xls;
using System.IO;
using System.Linq;

namespace BookKeeper.Data.Infrastructure.Formats
{
    public abstract class ExcelExtensionConverter : FileManager
    {
        public static string ConvertToXlsx(string file)
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
            workBook.SaveToFile(Path.Combine(Directory.GetCurrentDirectory(),TempFolder,file), ExcelVersion.Version2013);
            return Path.GetFullPath($"{Path.GetFileNameWithoutExtension(file)}.xlsx");
        }
    }
}
