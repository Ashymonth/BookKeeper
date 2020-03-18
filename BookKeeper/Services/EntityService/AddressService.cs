using System.Collections.Generic;
using System.Linq;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService
{
    public interface IAddressService : IService<StreetEntity>
    {
        IEnumerable<string> GetAddresses();
    }

    public class AddressService : Service<StreetEntity>, IAddressService
    {
        public AddressService(IRepository<StreetEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public IEnumerable<string> GetAddresses()
        {
            return base.GetItems().Select(x => x.StreetName);
        }
    }
}
