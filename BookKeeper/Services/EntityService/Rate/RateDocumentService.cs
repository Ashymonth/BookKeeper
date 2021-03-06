﻿using Autofac;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Data.Repositories;
using BookKeeper.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookKeeper.Data.Services.EntityService.Rate
{
    public interface IRateService : IService<RateEntity>
    {
        RateEntity AddRate(LocationEntity entity, string description, decimal price);

        RateEntity AddRate(LocationEntity entity, string description, decimal price, DateTime fromDateTime,
            DateTime toDateTime);

        decimal GetCurrentRate(int accountsCount, LocationEntity entity, DateTime paymentDate);

        RateEntity ChangeRatePrice(RateEntity rateEntity, decimal price,DateTime endDate);
    }

    public class RateService : Service<RateEntity>, IRateService
    {
        private readonly IContainer _container;

        public RateService(IRepository<RateEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }

        public RateEntity AddRate(LocationEntity entity, string description, decimal price)
        {
            var activeRate = GetActiveRate(entity);

            if (activeRate != null && activeRate.StartDate.Date == DateTime.Now.Date)
                return null;

            if (activeRate != null)
                SendToArchive(activeRate);

            var result = new RateEntity
            {
                StartDate = DateTime.Parse($"01.{DateTime.Today.Month}.{DateTime.Today.Year}"),//
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

        public RateEntity AddRate(LocationEntity entity, string description, decimal price, DateTime fromDateTime, DateTime toDateTime)
        {
            var activeRate = GetActiveRate(entity);

            if (activeRate != null && activeRate.StartDate.Date == DateTime.Now.Date)
                return null;

            if (activeRate != null)
                SendToArchive(activeRate);

            var result = new RateEntity
            {
                StartDate = fromDateTime,
                Price = price,
                EndDate = toDateTime,
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

        public RateEntity ChangeRatePrice(RateEntity rateEntity, decimal price,DateTime endDate)
        {
            var rate = base.GetItemById(rateEntity.Id);
            if (rate == null)
                return null;

            var changedRate = new RateEntity
            {
                Price = price,
                StartDate = DateTime.Now,
                EndDate = endDate,
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

        public decimal GetCurrentRate(int accountsCount, LocationEntity entity, DateTime paymentDate)
        {
            var rate = base.GetWithInclude(x => x.IsDefault == false &&
                                                x.IsDeleted == false &&
                                                paymentDate >= x.StartDate.Date &&
                                                paymentDate < x.EndDate.Date,
                x => x.AssignedLocations).ToList();

            if (rate == null)
                throw new ArgumentNullException(nameof(rate));

            if (!rate.Any())
                return Math.Round(GetDefaultRate() / accountsCount, 2);

            var result = rate.FirstOrDefault(x => x.AssignedLocations.FirstOrDefault(z => z.IsDeleted == false &&
                                                                                          z.StreetId == entity.StreetId &&
                                                                                          z.HouseNumber.Equals(entity.HouseNumber,
                                                                                              StringComparison.OrdinalIgnoreCase) &&
                                                                                          z.BuildingNumber.Equals(entity.BuildingCorpus,
                                                                                                  StringComparison.OrdinalIgnoreCase)) != null);

           decimal res = result?.Price / accountsCount ?? Math.Round(GetDefaultRate() / accountsCount, 2);

           return Math.Round(res, 2);
        }

        public RateEntity GetActiveRate(LocationEntity location)
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
            if (rate == null)
                return null;

            var updaterRate = base.GetItemById(rate.Id);
            if (updaterRate != null)
            {
                updaterRate.IsArchive = true;
                updaterRate.EndDate = DateTime.Now;
                base.Update(updaterRate);
            }

            return updaterRate;
        }

        public decimal GetDefaultRate()
        {
            return GetItem(x => x.IsDefault).Price;
        }
    }
}
