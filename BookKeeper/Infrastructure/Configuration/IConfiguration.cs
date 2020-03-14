using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Infrastructure.Configuration
{
    public interface IConfiguration<TModel> where TModel : class
    {
        void Save();
        TModel Load();
    }
}
