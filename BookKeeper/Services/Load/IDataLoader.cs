using System;
using BookKeeper.Data.Models;

namespace BookKeeper.Data.Services.Load
{
    public enum LoaderType
    {
        Excel = 0,
        Html = 1
    }
    public interface IDataLoader
    {
        ImportReportModel LoadData(string file);
    }
}
