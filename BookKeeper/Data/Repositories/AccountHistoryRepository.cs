using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IAccountHistoryRepository : IRepository<AccountsHistoryEntity>
    {

    }

    public class AccountHistoryRepository : Repository<AccountsHistoryEntity>,IAccountHistoryRepository
    {
        public AccountHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
