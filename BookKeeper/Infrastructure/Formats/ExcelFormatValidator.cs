using Spire.Xls;
using System.IO;

namespace BookKeeper.Data.Infrastructure.Formats
{
    public static class ExcelFormatValidator
    {
        public static string ValidateFormat(string file)
        {
            var fileInfo = new DirectoryInfo(file);
            if (!fileInfo.Extension.Equals(".xls")) 
                return file;

            var workBook = new Spire.Xls.Workbook();
            workBook.SaveToFile(file, ExcelVersion.Version2013);
            return Path.GetFullPath($"{Path.GetFileNameWithoutExtension(file)}.xlsx");

        }
    }
}
