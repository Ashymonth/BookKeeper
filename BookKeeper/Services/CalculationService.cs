﻿using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.Data.Services.EntityService.Rate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookKeeper.Data.Services
{
    public interface ICalculationService
    {
        decimal CalculatePrice(int accountsCount, int accountId, LocationEntity entity, decimal received, DateTime currentDate);

        List<TotalPayments> CalculateAllPrice(int streetId, string houseNumber, DateTime from, DateTime to);

        List<TotalPayments> CalculateAllPrice(DateTime from, DateTime to);

        TotalPayments CalculateTotalPrice(DateTime @from, DateTime to);

        decimal Rate(int accountsCount, LocationEntity entity, DateTime paymentDate);

    }

    public class CalculationService : ICalculationService
    {
        private readonly IAccountService _accountService;

        private readonly IStreetService _streetService;

        private readonly IRateService _rateService;

        private readonly IDiscountDocumentService _discountDocumentService;

        private readonly ISearchService _searchService;


        public CalculationService(IRateService rateService, IDiscountDocumentService discountDocumentService,
            IAccountService accountService, IStreetService streetService, ISearchService searchService)
        {
            _rateService = rateService;
            _discountDocumentService = discountDocumentService;
            _accountService = accountService;
            _streetService = streetService;
            _searchService = searchService;
        }

        public decimal CalculatePrice(int accountsCount, int accountId, LocationEntity entity, decimal received, DateTime paymentDate)
        {
            var rate = _rateService.GetCurrentRate(accountsCount, entity, paymentDate);

            var discounts = _discountDocumentService.GetCurrentDiscount(accountId, paymentDate).ToList();

            if (discounts.Count == 0 && received == 0)
                return -rate;

            if (discounts.Count == 0)
                return received - rate;

            if (rate == 0)
                return 0;

            var discountForAll = rate / discounts.Count;
            decimal result = 0;
            foreach (var discount in discounts)
            {
                if (discount.Percent == 0)
                {
                    result += discountForAll;
                    continue;
                }

                result += discountForAll - discountForAll * (discount.Percent / 100);
            }

            result = Math.Round(result, 2);

            return result;
        }

        public List<TotalPayments> CalculateAllPrice(int streetId, string houseNumber, DateTime from, DateTime to)
        {
            var streets = _streetService.GetWithInclude(x => x.IsDeleted == false, x => x.Locations);

            var accounts = _accountService.GetWithInclude(x => x.IsDeleted == false,
                x => x.PaymentDocuments).ToList();

            var total = new List<TotalPayments>();

            var predicate = _searchService.FindAccounts(streetId, houseNumber);

            foreach (var streetEntity in streets.Where(x => x.Id == streetId))
            {
                var totalPayment = new TotalPayments { StreetName = streetEntity.StreetName };

                foreach (var accountEntity in accounts.Where(predicate))
                {
                    foreach (var paymentDocumentEntity in accountEntity.PaymentDocuments.Where(x =>
                        x.IsDeleted == false &&
                        x.PaymentDate.Date >= from.Date && x.PaymentDate.Date <= to.Date))
                    {

                        switch (accountEntity.AccountType)
                        {
                            case AccountType.Municipal:
                                totalPayment.AccruedMunicipal += paymentDocumentEntity.Accrued;
                                totalPayment.ReceivedMunicipal += paymentDocumentEntity.Received;
                                break;
                            case AccountType.Private:
                                totalPayment.AccruedPrivate += paymentDocumentEntity.Accrued;
                                totalPayment.ReceivedPrivate += paymentDocumentEntity.Received;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }

                totalPayment.TotalAccrued += totalPayment.AccruedMunicipal + totalPayment.AccruedPrivate;
                totalPayment.TotalReceived += totalPayment.ReceivedMunicipal + totalPayment.ReceivedPrivate;

                if (totalPayment.TotalAccrued == 0)
                    continue;

                totalPayment.Percent = Math.Round(((totalPayment.TotalReceived / totalPayment.TotalAccrued) * 100), 2);
                total.Add(totalPayment);
            }

            return total;
        }

        public List<TotalPayments> CalculateAllPrice(DateTime @from, DateTime to)
        {
            var streets = _streetService.GetWithInclude(x => x.IsDeleted == false, x => x.Locations);

            var accounts = _accountService.GetWithInclude(x => x.IsDeleted == false,
                x => x.PaymentDocuments).ToList();

            var total = new List<TotalPayments>();

            foreach (var streetEntity in streets.Where(x => x.IsDeleted == false))
            {
                var totalPayment = new TotalPayments { StreetName = streetEntity.StreetName };

                foreach (var entity in accounts.Where(x => x.StreetId == streetEntity.Id && x.IsDeleted == false).GroupBy(x => x.Location.HouseNumber))
                {
                    totalPayment.HouseNumber.Add(entity.Key);
                    var address = new Address
                    {
                        HouseNumber = entity.Key
                    };
                    foreach (var accountEntity in entity)
                    {
                        foreach (var paymentDocumentEntity in accountEntity.PaymentDocuments.Where(x =>
                            x.IsDeleted == false &&
                            x.PaymentDate.Date >= from.Date && x.PaymentDate.Date <= to.Date))
                        {
                            totalPayment.PaymentsDate.Add(paymentDocumentEntity.PaymentDate.ToString("Y"));

                            switch (accountEntity.AccountType)
                            {
                                case AccountType.Municipal:
                                    address.AccruedMunicipal += paymentDocumentEntity.Accrued;
                                    address.ReceivedMunicipal += paymentDocumentEntity.Received;
                                    break;
                                case AccountType.Private:
                                    address.AccruedPrivate += paymentDocumentEntity.Accrued;
                                    address.ReceivedPrivate += paymentDocumentEntity.Received;
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }
                    }

                    address.TotalAccrued += address.AccruedMunicipal + address.AccruedPrivate;
                    address.TotalReceived += address.ReceivedMunicipal + address.ReceivedPrivate;

                    if (address.TotalAccrued == 0)
                        continue;

                    address.Percent = Math.Round(((address.TotalReceived / address.TotalAccrued) * 100), 2);
                    totalPayment.Address.Add(address);
                }
                total.Add(totalPayment);
            }

            return total;
        }

        public TotalPayments CalculateTotalPrice(DateTime @from, DateTime to)
        {
            var streets = _streetService.GetWithInclude(x => x.IsDeleted == false, x => x.Locations);

            var accounts = _accountService.GetWithInclude(x => x.IsDeleted == false,
                x => x.PaymentDocuments).ToList();

            var totalPayment = new TotalPayments();

            foreach (var streetEntity in streets.Where(x => x.IsDeleted == false))
            {
                foreach (var accountEntity in accounts.Where(x => x.StreetId == streetEntity.Id))
                {
                    foreach (var paymentDocumentEntity in accountEntity.PaymentDocuments.Where(x =>
                        x.IsDeleted == false &&
                        x.PaymentDate.Date >= from.Date && x.PaymentDate.Date <= to.Date))
                    {

                        switch (accountEntity.AccountType)
                        {
                            case AccountType.Municipal:
                                totalPayment.AccruedMunicipal += paymentDocumentEntity.Accrued;
                                totalPayment.ReceivedMunicipal += paymentDocumentEntity.Received;
                                break;
                            case AccountType.Private:
                                totalPayment.AccruedPrivate += paymentDocumentEntity.Accrued;
                                totalPayment.ReceivedPrivate += paymentDocumentEntity.Received;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }

                totalPayment.TotalAccrued += totalPayment.AccruedMunicipal + totalPayment.AccruedPrivate;
                totalPayment.TotalReceived += totalPayment.ReceivedMunicipal + totalPayment.ReceivedPrivate;

                if (totalPayment.TotalAccrued == 0)
                    continue;

                totalPayment.Percent = Math.Round(((totalPayment.TotalReceived / totalPayment.TotalAccrued) * 100), 2);
            }

            return totalPayment;
        }

        public decimal Rate(int accountsCount, LocationEntity entity, DateTime paymentDate)
        {
            var rate = _rateService.GetCurrentRate(accountsCount, entity, paymentDate);

            return rate;
        }
    }

    public class TotalPayments
    {
        public TotalPayments()
        {
            PaymentsDate = new List<string>();
            HouseNumber = new List<string>();
            Address = new List<Address>();
        }

        public List<Address> Address { get; set; }

        public string StreetName { get; set; }

        public List<string> HouseNumber { get; set; }

        public decimal AccruedMunicipal { get; set; }

        public decimal ReceivedMunicipal { get; set; }

        public decimal AccruedPrivate { get; set; }

        public decimal ReceivedPrivate { get; set; }

        public decimal TotalAccrued { get; set; }

        public decimal TotalReceived { get; set; }

        public decimal Percent { get; set; }

        public List<string> PaymentsDate { get; set; }
    }

    public class Address
    {
        public string HouseNumber { get; set; }

        public decimal AccruedMunicipal { get; set; }

        public decimal ReceivedMunicipal { get; set; }

        public decimal AccruedPrivate { get; set; }

        public decimal ReceivedPrivate { get; set; }

        public decimal TotalAccrued { get; set; }

        public decimal TotalReceived { get; set; }

        public decimal Percent { get; set; }
    }
}