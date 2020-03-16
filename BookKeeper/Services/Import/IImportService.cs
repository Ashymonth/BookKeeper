using System.Collections.Generic;

namespace BookKeeper.Data.Services.Import
{
    public interface IImportService
    {
        List<ImportDataRow> ImportDataRow(string file);
    }
}
