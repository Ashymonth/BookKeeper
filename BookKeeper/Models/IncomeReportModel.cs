using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Services;

namespace BookKeeper.Data.Models
{
    public class IncomeReportModel
    {
        public int StreetId { get; set; }

        public string HouseNumber { get; set; }

        public string BuildingNumber { get; set; }

        public TotalReportType ReportType { get; set; }
    }
}
