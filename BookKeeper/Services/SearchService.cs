using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services.EntityService;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static System.String;

namespace BookKeeper.Data.Services
{
    public interface ISearchService
    {
        IEnumerable<AccountEntity> FindAccounts(SearchModel model);
    }

    public class SearchService : ISearchService
    {
        private readonly IAccountService _accountService;

        public SearchService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IEnumerable<AccountEntity> FindAccounts(SearchModel model)
        {
            var account = PredicateBuilder.New<AccountEntity>();
            
            Expression<Func<AccountEntity, bool>> defaultPredicate = entity =>
                entity.StreetId == model.StreetId && entity.IsDeleted == false;

            Expression<Func<AccountEntity, bool>> accountPredicate =
                entity => entity.Account == Convert.ToInt64(model.Account) && entity.IsDeleted == false;

            Expression<Func<AccountEntity,bool>> accountTypePredicate = entity =>
                entity.AccountType == model.AccountType && entity.IsArchive == model.IsArchive;

            Expression<Func<AccountEntity, bool>> housePredicate =
                house => string.Equals(house.Location.HouseNumber, model.HouseNumber,
                    StringComparison.CurrentCultureIgnoreCase) && house.IsDeleted == false;

            Expression<Func<AccountEntity, bool>> buildingPredicate =
                building => string.Equals(building.Location.BuildingCorpus, model.BuildingNumber,
                    StringComparison.CurrentCultureIgnoreCase) && building.IsDeleted == false;

            Expression<Func<AccountEntity, bool>> emptyBuildingPredicate =
                emptyBuilding => string.Equals(emptyBuilding.Location.BuildingCorpus, string.Empty) 
                                 && emptyBuilding.IsDeleted == false;

            Expression<Func<AccountEntity, bool>> apartmentPredicate =
                apartment => string.Equals(apartment.Location.ApartmentNumber, model.ApartmentNumber,
                                 StringComparison.CurrentCultureIgnoreCase) && apartment.IsDeleted == false;

            if (!IsNullOrWhiteSpace(model.Account))
            {
                account.And(accountPredicate);
                return _accountService.GetItems(account);
            }

            account.And(defaultPredicate);


            if (model.AccountType != AccountType.All)
                account.And(accountTypePredicate);

            if (IsNullOrWhiteSpace(model.HouseNumber) == false)
                account.And(housePredicate);

            if (IsNullOrWhiteSpace(model.BuildingNumber) == false)
                account.And(buildingPredicate);

            if (model.IsNoneBuilding)
                account.And(emptyBuildingPredicate);

            if (IsNullOrWhiteSpace(model.ApartmentNumber) == false)
                account.And(apartmentPredicate);

            return _accountService.GetWithInclude(account,
                x => x.Location,
                x => x.Location.Street,
                x => x.Location.Street.Rates);
        }
    }
}