using System.Configuration;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService
{
    public interface IAccountService : IService<AccountEntity>
    {
        AccountEntity AddAccount(long account,LocationEntity entity);
    }

    public class AccountService : Service<AccountEntity>, IAccountService
    {
        public AccountService(IRepository<AccountEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public AccountEntity AddAccount(long account, LocationEntity entity)
        {
            var newAccount = new AccountEntity
            {
                Account = account,
                Location = entity,
                AccountType = ConvertAccountType(account),
                StreetId = entity.StreetId
            };
            return base.Add(newAccount);
        }

        private static AccountType ConvertAccountType(long code)
        {
            return code.ToString().StartsWith(ConfigurationManager.AppSettings["MunicipalMark"]) ? AccountType.Municipal : AccountType.Private;
        }
    }
}
