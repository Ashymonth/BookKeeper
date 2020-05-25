using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services.EntityService;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BookKeeper.Data.Data.Entities.Address;
using static System.String;

namespace BookKeeper.Data.Services
{
    public enum TotalReportType
    {
        All,
        WithParameters
    }

    public interface ISearchService
    {
        IEnumerable<AccountEntity> FindAccounts(SearchModel model);

        ExpressionStarter<LocationEntity> FindLocation(int streetId, string houseNumber, string buildingNumber);

        ExpressionStarter<AccountEntity> GetAccountType(AccountType accountType);
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
                entity.StreetId == model.StreetId && entity.IsDeleted == false && entity.IsArchive == model.IsArchive;

            Expression<Func<AccountEntity, bool>> accountPredicate =
                entity => entity.Account == Convert.ToInt64(model.Account) && entity.IsDeleted == false;

           

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

        public ExpressionStarter<LocationEntity> FindLocation(int streetId, string houseNumber, string buildingNumber)
        {
            var location = PredicateBuilder.New<LocationEntity>();

            Expression<Func<LocationEntity, bool>> defaultPredicate = entity =>
                entity.StreetId == streetId && entity.IsDeleted == false;

            Expression<Func<LocationEntity, bool>> housePredicate = entity =>
                string.Equals(entity.HouseNumber, houseNumber, StringComparison.OrdinalIgnoreCase) &&
                entity.IsDeleted == false;

            Expression<Func<LocationEntity, bool>> buildingPredicate = entity =>
                string.Equals(entity.BuildingCorpus, buildingNumber,StringComparison.OrdinalIgnoreCase) && 
                entity.IsDeleted == false;

            location.And(defaultPredicate);

            if (IsNullOrWhiteSpace(houseNumber) == false)
                location.And(housePredicate);

            if (IsNullOrWhiteSpace(buildingNumber) == false)
                location.And(buildingPredicate);

            return location;
        }

        public ExpressionStarter<AccountEntity> GetAccountType(AccountType accountType)
        {
            var account = PredicateBuilder.New<AccountEntity>();

            Expression<Func<AccountEntity, bool>> defaultPredicate = entity =>
                entity.IsDeleted == false;

            Expression<Func<AccountEntity, bool>> accountTypePredicate = entity =>
                entity.AccountType == accountType;

            return account.And(accountType != AccountType.All ? accountTypePredicate : defaultPredicate);
        }
    }
}