using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IAccountRepository : IRepository<AccountEntity>
    {
     
    }

    public class AccountRepository : Repository<AccountEntity>,IAccountRepository
    {
        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        
    }
}
