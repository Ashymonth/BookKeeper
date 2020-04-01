using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookKeeper.Data.Services.EntityService.Rate
{
    public interface IRateService : IService<RateEntity>
    {
        RateEntity AddRate(int locationId, string description, decimal price, DateTime startDate, DateTime endDate);

        decimal GetCurrentRate(int locationId, DateTime currentRate);

        RateEntity ChangeRatePrice(RateEntity rateEntity, decimal price);
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

        public RateEntity ChangeRatePrice(RateEntity rateEntity, decimal price)
        {
            var rate = base.GetItemById(rateEntity.Id);
            if (rate == null)
                return null;

            rate.EndDate = DateTime.Now;
            rate.IsArchive = true;
            base.Update(rate);

            var changedRate = base.Add(new RateEntity
            {
                AssignedLocations = rateEntity.AssignedLocations,
                Price = price,
                StartDate = DateTime.Now,
                Description = rateEntity.Description,
            });

            return changedRate;
        }

        public decimal GetCurrentRate(int locationId, DateTime paymentDate)
        {
            var rate = base.GetWithInclude(x =>
                //x.StartDate <= paymentDate && paymentDate <= x.EndDate &&
                x.IsDeleted == false &&
                x.IsDefault == false, x => x.AssignedLocations).ToList()
                .SingleOrDefault(x => x.AssignedLocations.FirstOrDefault(z => z.IsDeleted == false && z.LocationRefId == locationId) != null);

            return rate?.Price ?? GetDefaultRate();
        }

        private decimal GetDefaultRate()
        {
            var z = GetItem(x => x.IsDefault);
            return z.Price;
        }
    }
}
