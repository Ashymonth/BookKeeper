using BookKeeper.Data.Data.Entities.Address;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IAddressRepository : IRepository<StreetEntity>
    {
    }

    public class AddressRepository : Repository<StreetEntity>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }

      
    }
}
