using BookKeeper.Data.Data.Entities.Address;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IDistrictRepository : IRepository<DistrictEntity>
    {

    }
    public class DistrictRepository : Repository<DistrictEntity>, IDistrictRepository
    {
        public DistrictRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
