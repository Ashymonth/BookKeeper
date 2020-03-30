using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Bibliography;

namespace BookKeeper.Data.Services.EntityService.Rate
{
    public interface IRateService : IService<RateEntity>
    {
        RateEntity AddRate(int locationId, string description, decimal price, DateTime startDate, DateTime endDate);
        decimal GetCurrentRate(int locationId, DateTime currentRate);
    }

    public class RateService : Service<RateEntity>, IRateService
    {

        public RateService(IRepository<RateEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public RateEntity AddRate(int locationId, string description, decimal price, DateTime startDate, DateTime endDate)
        {
            var result = new RateEntity
            {
                StartDate = startDate,
                Price = price,
                EndDate = endDate,
                Description = description,
                AssignedLocations = new List<RateDetailsEntity>()
                {
                    new RateDetailsEntity()
                    {
                        LocationRefId = locationId
                    }
                }
            };

            return base.Add(result);
        }
        // payment date 23.02.2020
        // rate
        //     start date: 01.02.2020
        //     end   date: 01.03.2020

        // startDate >= paymentDate && endDate < paymentDate



        public decimal GetCurrentRate(int locationId, DateTime paymentDate)
        {
            var rate = base.GetItem(x => x.StartDate >= paymentDate &&
                                               x.EndDate < paymentDate &&
                                               x.AssignedLocations.FirstOrDefault(z => z.LocationRefId == locationId && z.IsDeleted != false) != null);

            return rate?.Price ?? GetDefaultRate();
        }

        private decimal GetDefaultRate()
        {
            return GetItem(x => x.IsDefault).Price;
        }
    }
}
