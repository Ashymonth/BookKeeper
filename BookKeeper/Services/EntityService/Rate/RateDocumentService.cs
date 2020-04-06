using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using BookKeeper.Data.Data.Entities.Address;

namespace BookKeeper.Data.Services.EntityService.Rate
{
    public interface IRateService : IService<RateEntity>
    {
        RateEntity AddRate(LocationEntity entity, string description, decimal price);

        decimal GetCurrentRate(LocationEntity entity, DateTime paymentDate);

        RateEntity ChangeRatePrice(RateEntity rateEntity, decimal price);
    }

    public class RateService : Service<RateEntity>, IRateService
    {
        public RateService(IRepository<RateEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public RateEntity AddRate(LocationEntity entity, string description, decimal price)
        {
            var activeRate = GetActiveRate(entity);
            if (activeRate != null)
                SendToArchive(activeRate);

            var result = new RateEntity
            {
                StartDate = DateTime.Now,
                Price = price,
                EndDate = DateTime.MaxValue,
                Description = description,
                AssignedLocations = new List<RateDetailsEntity>()
                {
                    new RateDetailsEntity()
                    {
                        StreetId = entity.StreetId,
                        LocationRefId = entity.Id,
                        HouseNumber = entity.HouseNumber,
                        BuildingNumber = entity.BuildingCorpus
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
            var changedRate = new RateEntity
            {
                Price = price,
                StartDate = DateTime.Now,
                Description = rateEntity.Description,
            };

            if (changedRate.AssignedLocations == null)
                changedRate.AssignedLocations = new List<RateDetailsEntity>();

            foreach (var rateEntityAssignedLocation in rateEntity.AssignedLocations)
            {
                changedRate.AssignedLocations.Add(rateEntityAssignedLocation);
            }

            rate.EndDate = DateTime.Now;
            rate.IsArchive = true;
            base.Update(rate);

            return base.Add(changedRate);
        }

        public decimal GetCurrentRate(LocationEntity entity, DateTime paymentDate)
        {
            var rate = base.GetWithInclude(x => x.IsDefault == false &&
                                                x.IsDeleted == false &&
                                                paymentDate >= x.StartDate.Date &&
                                                paymentDate < x.EndDate.Date,
                x => x.AssignedLocations).ToList();

            if (rate == null)
                throw new ArgumentNullException(nameof(rate));

            if (!rate.Any())
                return GetDefaultRate();

            var result = rate.FirstOrDefault(x => x.AssignedLocations.FirstOrDefault(z => z.IsDeleted == false &&
                                                                                          z.StreetId == entity.StreetId &&
                                                                                          z.HouseNumber.Equals(entity.HouseNumber,
                                                                                              StringComparison.OrdinalIgnoreCase) &&
                                                                                          z.BuildingNumber.Equals(entity.BuildingCorpus,
                                                                                                  StringComparison.OrdinalIgnoreCase)) != null);

            return result?.Price ?? GetDefaultRate();
        }

        private RateEntity GetActiveRate(LocationEntity location)
        {
            var rate = base.GetWithInclude(x => x.IsDeleted == false &&
                                                x.IsDefault == false &&
                                                x.IsArchive == false, x => x.AssignedLocations);

            var result = rate.FirstOrDefault(x => x.AssignedLocations.FirstOrDefault(z => z.IsDeleted == false &&
                                                                                          z.HouseNumber.Equals(location.HouseNumber,
                                                                                                  StringComparison.OrdinalIgnoreCase) &&
                                                                                          z.BuildingNumber.Equals(location.BuildingCorpus,
                                                                                                  StringComparison.OrdinalIgnoreCase)) != null);

            return result;
        }

        private RateEntity SendToArchive(RateEntity rate)
        {
            if (rate != null)
            {
                rate.IsArchive = true;
                rate.EndDate = DateTime.Now;
                base.Update(rate);
            }

            return rate;
        }

        private decimal GetDefaultRate()
        {
            return GetItem(x => x.IsDefault).Price;
        }
    }
}
