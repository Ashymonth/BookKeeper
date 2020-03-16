using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IAddressRepository : IRepository<AddressEntity>
    {
        IIncludableQueryable<AddressEntity, DistrictEntity> GetSpecificEntity();
    }

    public class AddressRepository : Repository<AddressEntity>,IAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AddressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IIncludableQueryable<AddressEntity, DistrictEntity> GetSpecificEntity()
        {
            return _dbContext.Addresses.Include(x => x.District);
        }
    }
}
