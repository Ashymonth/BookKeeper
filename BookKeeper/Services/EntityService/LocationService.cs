using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService
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
                AddressId = addressId
            };
            base.Add(entity);
            return entity;
        }
    }
}
