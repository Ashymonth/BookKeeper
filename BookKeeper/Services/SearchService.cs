using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.UI.Models;
using System.Linq;
using BookKeeper.Data.Services.EntityService.Address;

namespace BookKeeper.Data.Services
{
    public interface ISearchService
    {
        AccountEntity FindAccountEntity(SearchModel model);
    }

    public class SearchService : ISearchService
    {
        private readonly IAddressService _addressService;
        private readonly IAccountService _accountService;

        public SearchService(IAddressService addressService, IAccountService accountService)
        {
            _addressService = addressService;
            _accountService = accountService;
        }

        public AccountEntity FindAccountEntity(SearchModel model)
        {
            var result = _addressService.GetWithInclude(x => x.Id == model.AddressId && x.IsDeleted == false, entity => entity.Locations);

            foreach (var entity in result)
            {
                foreach (var location in entity.Locations.Where(x => x.HouseNumber == model.HouseNumber && x.BuildingCorpus == model.BuildingNumber && x.ApartmentNumber == model.ApartmentNumber))
                {
                    var re = location.Street;
                }
            }

            return null;


        }
    }
}
