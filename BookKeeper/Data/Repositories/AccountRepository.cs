using BookKeeper.Data.Data.Entities;

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
