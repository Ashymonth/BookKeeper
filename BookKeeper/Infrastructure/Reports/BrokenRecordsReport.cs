using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Infrastructure.Reports
{
    public enum FileType
    {
        Html,
        Excel
    }
    public interface IBrokenRecordsReport
    {
        void Write(string account,FileType fileType);
        void WriteException(string file, FileType fileType);
    }

    public class BrokenRecordsReport : IBrokenRecordsReport
    {
        private const string ReportFolder = "Не сопоставленные записи";
        private const string HtmlFileName = "Не сопоставленные счета.txt";
        private const string ExcelFileName = "Ошибки при чтении экселя";
        private const string ExceptionHtmlFileName = "Ошибки при чтении платежей";
        private const string ExceptionExcelFileName = "Ошибки при рееста";

        public void Write(string account, FileType fileType)
        {
            if(account == null)
                return;

            if(string.IsNullOrWhiteSpace(account))
                return;

            if (!Directory.Exists(ReportFolder))
                Directory.CreateDirectory(ReportFolder);

            if (!File.Exists(HtmlFileName))
                File.Create(HtmlFileName);

            try
            {
                File.WriteAllText(
                    fileType == FileType.Html
                        ? Path.Combine(ReportFolder, HtmlFileName)
                        : Path.Combine(ReportFolder, ExcelFileName), account, Encoding.UTF8);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void WriteException(string file, FileType fileType)
        {
            if (file == null)
                return;

            if (string.IsNullOrWhiteSpace(file))
                return;

            if (!Directory.Exists(ReportFolder))
                Directory.CreateDirectory(ReportFolder);

            if (!File.Exists(ExceptionHtmlFileName))
                File.Create(ExceptionHtmlFileName);

            try
            {
                File.WriteAllText(
                    fileType == FileType.Html
                        ? Path.Combine(ReportFolder, ExceptionHtmlFileName)
                        : Path.Combine(ReportFolder, ExceptionExcelFileName), file, Encoding.UTF8);
            }
            catch (Exception )
            {
                //
            }
        }
    }
}
