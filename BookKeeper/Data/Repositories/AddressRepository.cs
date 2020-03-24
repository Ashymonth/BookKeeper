using BookKeeper.Data.Data.Entities.Address;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IAddressRepository : IRepository<StreetEntity>
    {
        IEnumerable<StreetEntity> GetWithInclude();
    }

    public class AddressRepository : Repository<StreetEntity>, IAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AddressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<StreetEntity> GetWithInclude()
        {
            return _dbContext.Streets.Include(x => x.Locations);
        }
    }
}
