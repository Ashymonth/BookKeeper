using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.Data.Services.EntityService.Rate;

namespace BookKeeper.Data.Services
{
    public interface ICalculationService
    {
        decimal CalculatePrice(int accountId, int locationId, decimal accrued, decimal received, DateTime currentDate);
    }

    public class CalculationService : ICalculationService
    {
        private readonly IAccountService _accountService;
        
        private readonly IRateDocumentService _rateDocumentService;

        private readonly IDiscountDocumentService _discountDocumentService;


        public CalculationService(IRateDocumentService rateDocumentService, IDiscountDocumentService discountDocumentService, IAccountService accountService)
        {
            _rateDocumentService = rateDocumentService;
            _discountDocumentService = discountDocumentService;
            _accountService = accountService;
        }

        public decimal CalculatePrice(int accountId, int accountLocationId, decimal accrued, decimal received, DateTime currentDate)
        {
            var rate = _rateDocumentService.GetCurrentRate(accountLocationId, currentDate);

            var discount = _discountDocumentService.GetCurrentDiscount(accountId, currentDate);

            if (discount == null)
                return received - rate.Price;

            if (rate == null)
                return received - accrued;


            return received - ((100 - discount.Percent) / 100) * rate.Price;

        }
    }
}