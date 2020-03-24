using System;
using System.Linq;
using System.Linq.Expressions;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using LinqKit;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IAccountRepository : IRepository<AccountEntity>
    {

    }

    public class AccountRepository : Repository<AccountEntity>, IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
