using System;
using System.Collections.Generic;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Services.EntityService;
using System.Linq;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services.EntityService.Address;

namespace BookKeeper.Data.Services
{
    public interface ISearchService
    {
        IEnumerable<AccountEntity> FindAccountEntity(SearchModel model);
    }

    public class SearchService : ISearchService
    {
        private readonly IStreetService _streetService;
        private readonly ILocationService _locationService;
        private readonly IAccountService _accountService;

        public SearchService(IStreetService streetService, IAccountService accountService, ILocationService locationService)
        {
            _streetService = streetService;
            _accountService = accountService;
            _locationService = locationService;
        }

        public IEnumerable<AccountEntity> FindAccountEntity(SearchModel model)
        {

            if (!string.IsNullOrWhiteSpace(model.HouseNumber) && !string.IsNullOrWhiteSpace(model.BuildingNumber) &&
                !string.IsNullOrWhiteSpace(model.ApartmentNumber))
            {
                var locationEntity = _locationService.GetItems(x =>
                    x.HouseNumber.Equals(model.HouseNumber, StringComparison.OrdinalIgnoreCase) &&
                    x.BuildingCorpus.Equals(model.BuildingNumber, StringComparison.OrdinalIgnoreCase) &&
                    x.ApartmentNumber.Equals(model.ApartmentNumber, StringComparison.OrdinalIgnoreCase) &&
                    x.StreetId == model.StreetId);

                var accounts = new List<AccountEntity>();

                foreach (var location in locationEntity)
                {
                    var account = _accountService.GetWithInclude(x => x.StreetId == model.StreetId && x.IsArchive == false, x => x.PaymentDocuments);
                    accounts.AddRange(account);
                }

                return accounts;


            }

            if (string.IsNullOrWhiteSpace(model.HouseNumber))
            {
                var accounts = _accountService.GetWithInclude(x => x.StreetId == model.StreetId &&
                                                                  x.AccountType == model.AccountType &&
                                                                  x.IsArchive == false, x => x.PaymentDocuments);

                return accounts;
            }

            var result = _streetService.GetWithInclude(x => x.Id == model.StreetId && x.IsDeleted == false, entity => entity.Locations);
            return null;


        }
    }
}
