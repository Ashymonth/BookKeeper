using System;
using System.Collections.Generic;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Services.EntityService;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Windows.Forms;
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

        List<AccountEntity> AccountEntities = new List<AccountEntity>
        {
            new AccountEntity
            {
                Id = 1,
                Account = 123456,
                LocationId = 1,
            }
        };

        private List<LocationEntity> locations = new List<LocationEntity>
        {
            new LocationEntity
            {
                Id = 1,
                HouseNumber = "10",
                BuildingCorpus = "2b",
                ApartmentNumber = "152",

            }
        };
        public SearchService(IStreetService streetService, IAccountService accountService, ILocationService locationService)
        {
            _streetService = streetService;
            _accountService = accountService;
            _locationService = locationService;
        }


        public IEnumerable<AccountEntity> FindAccountEntity(SearchModel model)
        {
            var e = DynamicExpressionParser.ParseLambda(
                typeof(LocationEntity), typeof(bool),
                "HouseNumber == @0 and BuildingCorpus == @0 and ApartmentNumber == @0",
            model.HouseNumber,model.BuildingNumber,model.ApartmentNumber);

            e.Compile();
            return null;
        }
    }
}
