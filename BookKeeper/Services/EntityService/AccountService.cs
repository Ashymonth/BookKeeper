using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService
{
    public interface IAccountService : IService<AccountEntity>
    {

    }

    public class AccountService : Service<AccountEntity>, IAccountService
    {
        public AccountService(IRepository<AccountEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
