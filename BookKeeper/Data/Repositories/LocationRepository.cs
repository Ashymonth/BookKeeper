using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities.Address;

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
