using System;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Data.Repositories;
using BookKeeper.Data.Models;

namespace BookKeeper.Data.Services.EntityService.Rate
{
    public interface IRateDocumentService : IService<RateDocumentEntity>
    {
        RateDocumentEntity AddRateDocument(int locationId, string description, decimal price,DateTime startDate, DateTime EndDate);
        RateDocumentEntity GetActiveRate(int rateId);
    }

    public class RateDocumentService : Service<RateDocumentEntity>, IRateDocumentService
    {
        private const decimal DefaultPrice = 166;


        public RateDocumentService(IRepository<RateDocumentEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public RateDocumentEntity AddRateDocument(int locationId, string description, decimal price,DateTime startDate, DateTime endDate)
        {
            var result = new RateDocumentEntity
            {
                LocationId = locationId,
                StartDate = startDate,
                Price = price,
                IsDefaultPrice = price == DefaultPrice,
                EndDate = endDate
            };

            result.RatesDescription.Add(new RateDescriptionEntity
            {
                Description = description,
                RateDocumentId = result.Id
            });

            return Add(result);
        }

        public RateDocumentEntity GetActiveRate(int locationId)
        {
            return base.GetItem(x => x.Id == x.LocationId);
            //x.EndDate )
        }
    }
}
