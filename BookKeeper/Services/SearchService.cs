using System;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Address;
using System.Collections.Generic;
using System.Linq.Expressions;
using DocumentFormat.OpenXml.Drawing;
using LinqKit;
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
                entity.StreetId == model.StreetId && entity.IsDeleted == false &&
                entity.AccountType == model.AccountType && entity.IsArchive == model.IsArchive;

            Expression<Func<AccountEntity, bool>> housePredicate =
                house => string.Equals(house.Location.HouseNumber, model.HouseNumber, StringComparison.CurrentCultureIgnoreCase);

            Expression<Func<AccountEntity, bool>> buildingPredicate =
                building => string.Equals(building.Location.BuildingCorpus, model.BuildingNumber, StringComparison.CurrentCultureIgnoreCase);

            Expression<Func<AccountEntity, bool>> apartmentPredicate =
                apartment => string.Equals(apartment.Location.HouseNumber, model.HouseNumber, StringComparison.CurrentCultureIgnoreCase);

            account.And(defaultPredicate);

            if (IsNullOrWhiteSpace(model.HouseNumber) == false)
                account.And(housePredicate);

            if (IsNullOrWhiteSpace(model.BuildingNumber) == false)
                account.And(buildingPredicate);

            if (IsNullOrWhiteSpace(model.ApartmentNumber) == false)
                account.And(apartmentPredicate);

            return _accountService.GetWithInclude(account,x=>x.Location,x=>x.PaymentDocuments);
        }
    }
}