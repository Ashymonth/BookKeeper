using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Models;
using LinqKit;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IAccountRepository : IRepository<AccountEntity>
    {
        
    }

    public class AccountRepository : Repository<AccountEntity>, IAccountRepository
    {
        public string HouseNumber { get; set; }

        public string BuildingCorpus { get; set; }

        public string ApartmentNumber { get; set; }

        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Do(SearchModel model)
        {
            var e = DynamicExpressionParser.ParseLambda(
                typeof(LocationEntity), typeof(bool),
                "HouseNumber == @0 and BuildingCorpus == @0 and ApartmentNumber == @0");

            var query = _dbContext.Locations
                .Where("HouseNumber == @0 and BuildingCorpus == @0 and ApartmentNumber == @0",
                    model.HouseNumber, model.BuildingNumber, model.ApartmentNumber);
            
        }

    }
}
