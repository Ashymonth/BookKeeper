using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Infrastructure.Reports
{
    public interface IBrokenRecordsReport
    {
        void Write(string account);
    }

    public class BrokenRecordsReport : IBrokenRecordsReport
    {
        private const string ReportFolder = "Не сопоставленные записи";
        private const string FileName = "Записи";

        public void Write(string account)
        {
            if(account == null)
                return;

            if(string.IsNullOrWhiteSpace(account))
                return;

            if (!Directory.Exists(ReportFolder))
                Directory.CreateDirectory(ReportFolder);

            var path = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), FileName,
                DateTime.Now.ToString("Y")));

            try
            {
                File.Create(path);

                if (File.Exists(path))
                {
                    File.WriteAllText(path,account,Encoding.UTF8);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
