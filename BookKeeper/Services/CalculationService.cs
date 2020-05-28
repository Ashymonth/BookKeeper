using BookKeeper.Data.Data.Entities;
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
        decimal CalculateDebt(int accountsCount, int accountId, LocationEntity entity, decimal received, DateTime currentDate);

        List<Address> CalculateIncomeWithParameters(int streetId, string houseNumber, string buildingNumber, DateTime from, DateTime to);

        List<Address> CalculateIncome(DateTime from, DateTime to);

        TotalPayments CalculateTotalIncome(DateTime from, DateTime to);

        decimal CalculateCurrentRate(int accountId, int accountsCount, LocationEntity locationEntity, DateTime paymentDate);
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

        /// <summary>
        /// Рассчет идет по формуле (тариф/кол-во проживаюих) - процент скидки
        /// </summary>
        /// <param name="accountsCount"></param>
        /// <param name="accountId"></param>
        /// <param name="entity"></param>
        /// <param name="received"></param>
        /// <param name="paymentDate"></param>
        /// <returns></returns>

        public decimal CalculateDebt(int accountsCount, int accountId, LocationEntity entity, decimal received, DateTime paymentDate)
        {
            var rate = _rateService.GetCurrentRate(accountsCount, entity, paymentDate);

            var discounts = _discountDocumentService.GetCurrentDiscount(accountId, paymentDate).ToList();

            switch (discounts.Count)
            {
                case 0 when received == 0:
                    return -rate;
                case 0:
                    return received - rate;
            }

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

            if (received == 0)
                return -result;

            return received - result;
        }

        public List<Address> CalculateIncomeWithParameters(int streetId, string houseNumber, string buildingNumber, DateTime from, DateTime to)
        {
            var streets = _streetService.GetWithInclude(x => x.IsDeleted == false, x => x.Locations);

            var totalPayments = new List<Address>();

            var predicate = _searchService.FindLocation(streetId, houseNumber, buildingNumber);

            var accounts = _accountService.GetWithInclude(x => x.StreetId == streetId,
                x => x.PaymentDocuments).ToList();

            foreach (var streetEntity in streets.Where(x => x.IsDeleted == false && x.Id == streetId))
            {
                var address = new Address() { StreetName = streetEntity.StreetName };
                foreach (var street in streetEntity.Locations.GroupBy(x => x.HouseNumber))
                {
                    var house = new House() { HouseNumber = street.Key };

                    foreach (var buildingEntity in street.Where(predicate).GroupBy(x => x.BuildingCorpus))
                    {
                        var building = new Building() { BuildingNumber = buildingEntity.Key };

                        foreach (var buildingsEntity in buildingEntity)
                        {
                            foreach (var accountEntity in accounts.Where(x => x.LocationId == buildingsEntity.Id).ToList())
                            {
                                foreach (var paymentDocument in accountEntity.PaymentDocuments.Where(x =>
                                    x.IsDeleted == false &&
                                    x.PaymentDate.Date >= from.Date && x.PaymentDate.Date <= to.Date))
                                {
                                    switch (accountEntity.AccountType)
                                    {
                                        case AccountType.Municipal:
                                            building.AccruedMunicipal += CalculateCurrentRate(accountEntity.Id, GetAccountsCount(accounts, accountEntity.Location), buildingsEntity, paymentDocument.PaymentDate);
                                            building.ReceivedMunicipal += paymentDocument.Received;
                                            break;
                                        case AccountType.Private:
                                            building.AccruedPrivate += CalculateCurrentRate(accountEntity.Id, GetAccountsCount(accounts, accountEntity.Location), buildingsEntity, paymentDocument.PaymentDate);
                                            building.ReceivedPrivate += paymentDocument.Received;
                                            break;
                                        case AccountType.All:
                                            break;
                                        default:
                                            throw new ArgumentOutOfRangeException();
                                    }
                                }
                            }
                        }
                        building.TotalAccrued += building.AccruedMunicipal + building.AccruedPrivate;
                        building.TotalReceived += building.ReceivedMunicipal + building.ReceivedPrivate;

                        if (building.TotalAccrued != 0)
                            building.Percent = Math.Round((building.TotalReceived / building.TotalAccrued) * 100, 2);
                        house.Buildings.Add(building);
                    }
                    address.Houses.Add(house);
                }
                totalPayments.Add(address);
            }
            return totalPayments;
        }

        public List<Address> CalculateIncome(DateTime from, DateTime to)
        {
            var streets = _streetService.GetWithInclude(x => x.IsDeleted == false, x => x.Locations);

            var accounts = _accountService.GetWithInclude(x => x.IsDeleted == false,
                x => x.PaymentDocuments);

            var totalPayments = new List<Address>();

            foreach (var streetEntity in streets.Where(x => x.IsDeleted == false))
            {
                var address = new Address() { StreetName = streetEntity.StreetName };
                foreach (var street in streetEntity.Locations.GroupBy(x => x.HouseNumber))
                {
                    var house = new House() { HouseNumber = street.Key };

                    foreach (var buildingEntity in street.GroupBy(x => x.BuildingCorpus))
                    {
                        var building = new Building() { BuildingNumber = buildingEntity.Key };

                        foreach (var locationEntity in buildingEntity)
                        {
                            foreach (var accountEntity in accounts.Where(x => x.LocationId == locationEntity.Id))
                            {
                                foreach (var paymentDocument in accountEntity.PaymentDocuments.Where(x =>
                                    x.IsDeleted == false &&
                                    x.PaymentDate.Date >= from.Date && x.PaymentDate.Date <= to.Date))
                                {
                                    switch (accountEntity.AccountType)
                                    {
                                        case AccountType.Municipal:
                                            building.AccruedMunicipal += CalculateCurrentRate(accountEntity.Id, GetAccountsCount(accounts, accountEntity.Location), locationEntity, paymentDocument.PaymentDate); ;
                                            building.ReceivedMunicipal += paymentDocument.Received;
                                            break;
                                        case AccountType.Private:
                                            building.AccruedPrivate += CalculateCurrentRate(accountEntity.Id, GetAccountsCount(accounts, accountEntity.Location), locationEntity, paymentDocument.PaymentDate); ;
                                            building.ReceivedPrivate += paymentDocument.Received;
                                            break;
                                        case AccountType.All:
                                            break;
                                        default:
                                            throw new ArgumentOutOfRangeException();
                                    }
                                }
                            }
                        }
                        building.TotalAccrued += building.AccruedMunicipal + building.AccruedPrivate;
                        building.TotalReceived += building.ReceivedMunicipal + building.ReceivedPrivate;

                        if (building.TotalAccrued == 0)
                            continue;

                        building.Percent = Math.Round((building.TotalReceived / building.TotalAccrued) * 100, 2);
                        house.Buildings.Add(building);
                    }
                    address.Houses.Add(house);
                }
                totalPayments.Add(address);
            }
            return totalPayments;
        }

        public TotalPayments CalculateTotalIncome(DateTime from, DateTime to)
        {
            var accounts = _accountService.GetWithInclude(x => x.IsDeleted == false,
                x => x.PaymentDocuments).ToList();

            var totalPayment = new TotalPayments();


            foreach (var accountEntity in accounts.Where(x => x.IsDeleted == false))
            {
                foreach (var paymentDocumentEntity in accountEntity.PaymentDocuments.Where(x =>
                    x.IsDeleted == false &&
                    x.PaymentDate.Date >= from.Date && x.PaymentDate.Date <= to.Date))
                {

                    switch (accountEntity.AccountType)
                    {
                        case AccountType.Municipal:
                            totalPayment.AccruedMunicipal += CalculateCurrentRate(accountEntity.Id, GetAccountsCount(accounts, accountEntity.Location), accountEntity.Location, paymentDocumentEntity.PaymentDate); ;
                            totalPayment.ReceivedMunicipal += paymentDocumentEntity.Received;
                            break;
                        case AccountType.Private:
                            totalPayment.AccruedPrivate += CalculateCurrentRate(accountEntity.Id, GetAccountsCount(accounts, accountEntity.Location), accountEntity.Location, paymentDocumentEntity.PaymentDate); ;
                            totalPayment.ReceivedPrivate += paymentDocumentEntity.Received;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            totalPayment.TotalAccrued += totalPayment.AccruedMunicipal + totalPayment.AccruedPrivate;
            totalPayment.TotalReceived += totalPayment.ReceivedMunicipal + totalPayment.ReceivedPrivate;


            totalPayment.Percent = Math.Round(((totalPayment.TotalReceived / totalPayment.TotalAccrued) * 100), 2);
            return totalPayment;
        }

        /// <summary>
        /// Расчет тарифа с учетом льготы 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="accountsCount"></param>
        /// <param name="locationEntity"></param>
        /// <param name="paymentDate"></param>
        /// <returns></returns>
        public decimal CalculateCurrentRate(int accountId, int accountsCount, LocationEntity locationEntity, DateTime paymentDate)
        {
            var rate = _rateService.GetCurrentRate(accountsCount, locationEntity, paymentDate);
            var discounts = _discountDocumentService.GetCurrentDiscount(accountId, paymentDate).ToList();

            if (discounts.Count == 0)
                return rate;

            var price = rate / discounts.Count;
            
           return Math.Round(discounts.Sum(discount => price - (price * (discount.Percent / 100))),2);
        }

        private static int GetAccountsCount(IEnumerable<AccountEntity> accounts, LocationEntity searchLocation)
        {
            return accounts.Count(x =>
                x.Location.HouseNumber.Equals(searchLocation.HouseNumber, StringComparison.OrdinalIgnoreCase) &&
                x.Location.BuildingCorpus.Equals(searchLocation.BuildingCorpus, StringComparison.OrdinalIgnoreCase) &&
                x.Location.ApartmentNumber.Equals(searchLocation.ApartmentNumber, StringComparison.OrdinalIgnoreCase) &&
                x.IsDeleted == false &&
                x.PaymentDocuments.Count > 0);
        }
    }

    public class TotalPayments
    {

        public decimal AccruedMunicipal { get; set; }

        public decimal ReceivedMunicipal { get; set; }

        public decimal AccruedPrivate { get; set; }

        public decimal ReceivedPrivate { get; set; }

        public decimal TotalAccrued { get; set; }

        public decimal TotalReceived { get; set; }

        public decimal Percent { get; set; }
    }

    public class Address
    {
        public Address()
        {
            Houses = new List<House>();
        }
        public string StreetName { get; set; }

        public List<House> Houses { get; set; }
    }

    public class House
    {
        public House()
        {
            Buildings = new List<Building>();
        }
        public string HouseNumber { get; set; }

        public List<Building> Buildings { get; set; }

    }

    public class Building
    {
        public string BuildingNumber { get; set; }

        public decimal AccruedMunicipal { get; set; }

        public decimal ReceivedMunicipal { get; set; }

        public decimal AccruedPrivate { get; set; }

        public decimal ReceivedPrivate { get; set; }

        public decimal TotalAccrued { get; set; }

        public decimal TotalReceived { get; set; }

        public decimal Percent { get; set; }
    }
}