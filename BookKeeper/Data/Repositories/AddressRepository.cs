using BookKeeper.Data.Data.Entities.Address;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IAddressRepository : IRepository<StreetEntity>
    {

    }

    public class AddressRepository : Repository<StreetEntity>, IAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AddressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
