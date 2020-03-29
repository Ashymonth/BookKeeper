using System;

namespace BookKeeper.Data.Services.Load
{
    public enum LoaderType
    {
        Excel = 0,
        Html = 1
    }
    public interface IDataLoader
    {
        void LoadData(string file);
    }
}
