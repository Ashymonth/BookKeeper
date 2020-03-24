using System;
using System.Linq;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Models;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IAccountRepository : IRepository<AccountEntity>
    {
        
    }

    public class AccountRepository : Repository<AccountEntity>, IAccountRepository
    {

        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
