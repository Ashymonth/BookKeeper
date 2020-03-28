﻿using System;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Address;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BookKeeper.Data.Data.Entities.Payments;
using DocumentFormat.OpenXml.Drawing;
using LinqKit;
using static System.String;

namespace BookKeeper.Data.Services
{
    public interface ISearchService
    {
        IEnumerable<AccountEntity> FindAccounts(SearchModel model);
        IEnumerable<PaymentDocumentEntity> FindPaymentDocuments(SearchPaymentModel model);
    }

    public class SearchService : ISearchService
    {
        private readonly IAccountService _accountService;
        private readonly IPaymentDocumentService _paymentDocumentService;

        public SearchService(IAccountService accountService, IPaymentDocumentService paymentDocumentService)
        {
            _accountService = accountService;
            _paymentDocumentService = paymentDocumentService;
        }

        public IEnumerable<AccountEntity> FindAccounts(SearchModel model)
        {
            var account = PredicateBuilder.New<AccountEntity>();

            Expression<Func<AccountEntity, bool>> accountPredicate =
                entity => entity.Account == Convert.ToInt64(model.Account) && entity.IsDeleted == false;

            Expression<Func<AccountEntity, bool>> defaultPredicate = entity =>
                entity.StreetId == model.StreetId && entity.IsDeleted == false &&
                entity.AccountType == model.AccountType && entity.IsArchive == model.IsArchive;

            Expression<Func<AccountEntity, bool>> housePredicate =
                house => string.Equals(house.Location.HouseNumber, model.HouseNumber,
                    StringComparison.CurrentCultureIgnoreCase) && house.IsDeleted == false;

            Expression<Func<AccountEntity, bool>> buildingPredicate =
                building => string.Equals(building.Location.BuildingCorpus, model.BuildingNumber,
                    StringComparison.CurrentCultureIgnoreCase) && building.IsDeleted == false;

            Expression<Func<AccountEntity, bool>> emptyBuildingPredicate =
                emptyBuilding => string.Equals(emptyBuilding.Location.BuildingCorpus, string.Empty) ||
                                 emptyBuilding.Location.BuildingCorpus == string.Empty && emptyBuilding.IsDeleted == false;

            Expression<Func<AccountEntity, bool>> apartmentPredicate =
                apartment => string.Equals(apartment.Location.HouseNumber, model.HouseNumber,
                                 StringComparison.CurrentCultureIgnoreCase) && apartment.IsDeleted == false;

            account.And(defaultPredicate);


            if (!IsNullOrWhiteSpace(model.Account))
            {
                account.And(accountPredicate);
            }

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
                x => x.PaymentDocuments,
                x => x.Location.Street,
                x => x.Location.Street.Rates);
        }

        public IEnumerable<PaymentDocumentEntity> FindPaymentDocuments(SearchPaymentModel model)
        {
            return _paymentDocumentService.GetItems(x => x.IsDeleted == false &&
                                                         x.AccountId == model.AccountId &&
                                                         x.PaymentDate.Month >= model.From.Month &&
                                                         x.PaymentDate.Year == model.From.Year &&
                                                         x.PaymentDate.Month <= model.To.Month &&
                                                         x.PaymentDate.Year == model.To.Year);
        }
    }
}