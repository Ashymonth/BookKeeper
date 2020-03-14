using System.Collections.Generic;

namespace BookKeeper.Data.Services.Import
{
    public interface IImport
    {
        List<ImportDataRow> ImportDataRow(string file);
    }
}
