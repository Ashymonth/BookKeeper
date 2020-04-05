using System;
using Spire.Xls;
using System.IO;
using System.Linq;

namespace BookKeeper.Data.Infrastructure.Formats
{
    public static class ExcelExtensionConverter
    {
        private const string TempFolder = "TempFolder";

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

        public static void DeleteTempFolder()
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), TempFolder);
            
            if (Directory.Exists(folder))
            {
                var files = Directory.GetFiles(folder);
                if (files.Any() == false)
                {
                    foreach (var file in files)
                    {
                        File.Delete(file);
                    }
                }
            }
        }
    }
}
