﻿using System;
using System.Collections.Generic;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Services.EntityService;
using System.Linq;
using System.Linq.Expressions;
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
        public SearchService(IStreetService streetService, IAccountService accountService, ILocationService locationService)
        {
            _streetService = streetService;
            _accountService = accountService;
            _locationService = locationService;
        }


        public IEnumerable<AccountEntity> FindAccountEntity(SearchModel model)
        {
      
            return null;
        }
    }
}
