using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService
{
    public interface IDistrictService :IService<DistrictEntity>
    {

    }

    public class DistrictService : Service<DistrictEntity> , IDistrictService
    {
        public DistrictService(IRepository<DistrictEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
