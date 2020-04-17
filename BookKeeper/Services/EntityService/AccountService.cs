using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService
{
    public interface IAccountService : IService<AccountEntity>
    {
        AccountEntity AddAccount(long account,LocationEntity entity);

        int AccountsCount(LocationEntity entity);
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

        public int AccountsCount(LocationEntity entity)
        {
            return base.GetWithInclude(x =>
                       x.Location.HouseNumber.Equals(entity.HouseNumber,
                           StringComparison.OrdinalIgnoreCase) &&
                       x.Location.BuildingCorpus.Equals(entity.BuildingCorpus,
                           StringComparison.OrdinalIgnoreCase) &&
                       x.Location.ApartmentNumber.Equals(entity.ApartmentNumber,
                           StringComparison.OrdinalIgnoreCase) &&
                       x.IsDeleted == false, x => x.Location).ToList().Count;
        }

        private static AccountType ConvertAccountType(long code)
        {
            return code.ToString().StartsWith(ConfigurationManager.AppSettings["MunicipalMark"]) ? AccountType.Municipal : AccountType.Private;
        }
    }
}
