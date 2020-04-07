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
        decimal CalculatePrice(int accountId, LocationEntity entity, decimal received, DateTime currentDate);

        List<TotalPayments> CalculateAllPrice(DateTime from, DateTime to);
    }

    public class CalculationService : ICalculationService
    {
        private readonly IAccountService _accountService;

        private readonly IStreetService _streetService;

        private readonly IRateService _rateService;

        private readonly IDiscountDocumentService _discountDocumentService;


        public CalculationService(IRateService rateService, IDiscountDocumentService discountDocumentService,
            IAccountService accountService, IStreetService streetService)
        {
            _rateService = rateService;
            _discountDocumentService = discountDocumentService;
            _accountService = accountService;
            _streetService = streetService;
        }

        public decimal CalculatePrice(int accountId, LocationEntity entity, decimal received, DateTime paymentDate)
        {
            var rate = _rateService.GetCurrentRate(entity, paymentDate);

            var discount = _discountDocumentService.GetCurrentDiscount(accountId, paymentDate);

            if (discount == null && received == 0)
                return -rate;

            if (discount == null)
                return received - rate;

            if (rate == 0)
                return 0;

            if (discount.Percent == 100)
                return 0;

            return received - (((100 - discount.Percent) / 100) * rate);
        }

        public List<TotalPayments> CalculateAllPrice(DateTime from, DateTime to)
        {
            var streets = _streetService.GetWithInclude(x => x.IsDeleted == false);

            var accounts = _accountService.GetWithInclude(x => x.IsDeleted == false,
                x => x.PaymentDocuments).ToList();

            var total = new List<TotalPayments>();

            foreach (var streetEntity in streets)
            {
                var totalPayment = new TotalPayments { StreetName = streetEntity.StreetName };

                foreach (var accountEntity in accounts.Where(x => x.StreetId == streetEntity.Id && x.IsDeleted == false))
                {
                    foreach (var paymentDocumentEntity in accountEntity.PaymentDocuments.Where(x =>
                        x.IsDeleted == false &&
                        x.PaymentDate.Date >= from.Date && x.PaymentDate.Date <= to.Date))
                    {
                        totalPayment.PaymentsDate.Add(paymentDocumentEntity.PaymentDate.ToString("Y"));

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

                totalPayment.Percent = Math.Round(((totalPayment.TotalReceived / totalPayment.TotalAccrued) * 100), 4);
                total.Add(totalPayment);
            }

            return total;
        }
    }

    public class TotalPayments
    {
        public TotalPayments()
        {
            PaymentsDate = new List<string>();
        }
        public string StreetName { get; set; }

        public decimal AccruedMunicipal { get; set; }

        public decimal ReceivedMunicipal { get; set; }

        public decimal AccruedPrivate { get; set; }

        public decimal ReceivedPrivate { get; set; }

        public decimal TotalAccrued { get; set; }

        public decimal TotalReceived { get; set; }

        public decimal Percent { get; set; }

        public List<string> PaymentsDate { get; set; }
    }
}