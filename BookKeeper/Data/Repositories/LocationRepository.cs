using System.Linq;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Models;

namespace BookKeeper.Data.Data.Repositories
{
    public interface ILocationRepository : IRepository<LocationEntity>
    {
    }

    public class LocationRepository : Repository<LocationEntity>, ILocationRepository
    {

        public LocationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
