﻿using System.Linq;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Repositories;
using BookKeeper.Data.Models;

namespace BookKeeper.Data.Services.EntityService.Address
{
    public interface ILocationService : IService<LocationEntity>
    {
        LocationEntity Add(string houseNumber, string houseBuilding, string apartmentNumber, int addressId);
     
    }

    public class LocationService : Service<LocationEntity>, ILocationService
    {

        public LocationService(IRepository<LocationEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public LocationEntity Add(string houseNumber, string houseBuilding, string apartmentNumber, int addressId)
        {
            var entity = new LocationEntity
            {
                HouseNumber = houseNumber,
                BuildingCorpus = houseBuilding,
                ApartmentNumber = apartmentNumber,
                StreetId = addressId
            };
            base.Add(entity);
            return entity;
        }

        
    }
}
