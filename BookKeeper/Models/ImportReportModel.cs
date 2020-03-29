using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Models
{
    public class ImportReportModel
    {
        public int Updates { get; set; }

        public int Add { get; set; }

        public int CorruptedRecords { get; set; }
    }
}
