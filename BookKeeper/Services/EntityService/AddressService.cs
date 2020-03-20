using System.Collections.Generic;
using System.Linq;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService
{
    public interface IAddressService : IService<StreetEntity>
    {
        
    }

    public class AddressService : Service<StreetEntity>, IAddressService
    {
        public AddressService(IRepository<StreetEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            
        }

     
    }
}
