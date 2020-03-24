using System;
using System.Linq;
using BookKeeper.Data.Data.Entities;

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

        public void Som()
        {
            //var query = from account in _dbContext.Accounts.Include(x=>x.PaymentDocuments)
            //    join locations in _dbContext.Locations
            //        on account.Id equals locations.
            //    where locations.IsDeleted == false &&
            //          locations.HouseNumber == "105" &&
            //          locations.BuildingCorpus == "2B" &&
            //          locations.ApartmentNumber == "540"
            //    join payments in _dbContext.PaymentDocuments
            //        on account.Id equals payments.AccountId
            //    where payments.PaymentDate > DateTime.Now
            //    where payments.PaymentDate < DateTime.Now
            //    select account;

        }
    }
}
