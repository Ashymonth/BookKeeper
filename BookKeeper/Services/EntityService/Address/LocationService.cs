using System;
using System.Linq;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Repositories;
using BookKeeper.Data.Models;

namespace BookKeeper.Data.Services.EntityService.Address
{
    public interface ILocationService : IService<LocationEntity>
    {
        LocationEntity Add(string houseNumber, string houseBuilding, string apartmentNumber, int addressId);
        LocationEntity GetHouse(int streetId, string houseNumber, string buildingNumber);

        LocationEntity GetLocation(int streetId, string houseNumber, string buildingNumber, string apartment);

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

        public LocationEntity GetHouse(int streetId, string houseNumber, string buildingNumber)
        {
            return base.GetItem(x =>
                string.Equals(x.HouseNumber, houseNumber, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(x.BuildingCorpus, buildingNumber, StringComparison.CurrentCultureIgnoreCase) &&
                x.StreetId == streetId);
        }

        public LocationEntity GetLocation(int streetId, string houseNumber, string buildingNumber, string apartment)
        {
            return base.GetItem(x =>
                string.Equals(x.HouseNumber, houseNumber, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(x.BuildingCorpus, buildingNumber, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(x.ApartmentNumber,apartment,StringComparison.OrdinalIgnoreCase) && 
                x.StreetId == streetId);
        }
    }
}
