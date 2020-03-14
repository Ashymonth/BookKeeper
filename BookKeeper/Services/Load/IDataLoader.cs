using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities;

namespace BookKeeper.Data.Services.Load
{
    public interface IDataLoader
    {
        void LoadData(string file);
    }
}
