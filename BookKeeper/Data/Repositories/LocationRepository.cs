using System.Linq;
using System.Linq.Dynamic.Core;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Models;

namespace BookKeeper.Data.Data.Repositories
{
    public interface ILocationRepository : IRepository<LocationEntity>
    {
        IQueryable<LocationEntity> FindLocation(SearchModel model);
    }

    public class LocationRepository : Repository<LocationEntity>, ILocationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LocationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<LocationEntity> FindLocation(SearchModel model)
        {
            var e = DynamicExpressionParser.ParseLambda(
                typeof(LocationEntity), typeof(bool),
                "HouseNumber == @0 and BuildingCorpus == @0 and ApartmentNumber == @0");

            return  _dbContext.Locations
                .Where("HouseNumber == @0 and BuildingCorpus == @0 and ApartmentNumber == @0",
                    model.HouseNumber, model.BuildingNumber, model.ApartmentNumber);
        }
    }
}
