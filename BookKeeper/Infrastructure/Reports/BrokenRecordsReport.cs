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
        private const string FileName = "Не сопоставленные счета.txt";

        public void Write(string account)
        {
            if(account == null)
                return;

            if(string.IsNullOrWhiteSpace(account))
                return;

            if (!Directory.Exists(ReportFolder))
                Directory.CreateDirectory(ReportFolder);

            if (!File.Exists(FileName))
                File.Create(FileName);

            try
            {
                File.WriteAllText(Path.Combine(ReportFolder,FileName),account,Encoding.UTF8);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
