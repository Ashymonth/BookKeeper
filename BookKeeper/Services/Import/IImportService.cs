using System.Collections.Generic;

namespace BookKeeper.Data.Services.Import
{
    public interface IImportService<TModel> where TModel : class
    {
        TModel ImportDataRow(string file);
    }
}
