using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService.Address
{
    public interface IDistrictService : IService<DistrictEntity>
    {
        DistrictEntity Add(int code, string name);
    }

    public class DistrictService : Service<DistrictEntity>, IDistrictService
    {
        public DistrictService(IRepository<DistrictEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public DistrictEntity Add(int code, string name)
        {
            var entity = new DistrictEntity
            {
                Name = name,
                Code = code,
            };
            base.Add(entity);
            return entity;
        }
    }
}
