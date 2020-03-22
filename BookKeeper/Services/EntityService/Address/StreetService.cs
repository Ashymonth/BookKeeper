using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService.Address
{
    public interface IAddressService : IService<StreetEntity>
    {

    }

    public class StreetService : Service<StreetEntity>, IAddressService
    {
        public StreetService(IRepository<StreetEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {

        }


    }
}
