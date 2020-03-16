using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Models.ExcelImport;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.Import;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookKeeper.Data.Services.Load
{
    public class ExcelDataLoader : IDataLoader
    {
        private readonly IDictionary<string, int> _districtCache = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        private readonly IImportService _import;
        private readonly IDistrictService _districtService;
        private readonly IAddressService _addressService;
        private readonly IAccountService _accountService;
        private readonly ILocationService _locationService;

        public ExcelDataLoader(IImportService import, IDistrictService districtService, IAddressService addressService, IAccountService accountService, ILocationService locationService)
        {
            _import = import;
            _districtService = districtService;
            _addressService = addressService;
            _accountService = accountService;
            _locationService = locationService;
        }

        public void LoadData(string file)
        {
            var import = _import.ImportDataRow("");
            if (import == null)
                throw new ArgumentNullException(nameof(import));

            foreach (var districtsGroup in import.GroupBy(x => x.District.Name))
            {
                var firstDistrict = districtsGroup.FirstOrDefault();

                var district = AddOrCreate(firstDistrict?.District);

                foreach (var addressGroup in districtsGroup.GroupBy(x => x.Address.Name))
                {
                    var firstAddress = addressGroup.FirstOrDefault();

                    var location = AddOrCreate(firstAddress?.LocationImport);

                    var address = AddOrCreate(firstAddress?.Address, district, location);

                    var accounts = new List<AccountEntity>();
                    foreach (var dataRow in addressGroup)
                    {
                        var account =
                            _accountService.GetItem(x => x.PersonalAccount == dataRow.Account.PersonalAccount);

                        if (account != null)
                        {
                            account.IsEmpty = string.IsNullOrWhiteSpace(dataRow.Account.ServiceProviderCode);
                            account.IsArchive = account.IsEmpty && string.IsNullOrWhiteSpace(dataRow.Account.ServiceProviderCode);
                            _accountService.Update(account);
                            continue;
                        }

                        account = new AccountEntity
                        {
                            AccrualMonth = ConvertAccrualMonth(dataRow.Account.AccrualMonth),
                            PersonalAccount = dataRow.Account.PersonalAccount,
                            AccountType = ConvertAccountType(dataRow.Account.AccountType),
                            IsEmpty = string.IsNullOrWhiteSpace(dataRow.Account.ServiceProviderCode),
                            AddressID = address.Id
                        };
                        accounts.Add(account);

                    }

                    _accountService.Add(accounts);

                }
            }
        }

        private DistrictEntity AddOrCreate(DistrictImport import)
        {
            var result = _districtService.GetItem(x => x.Name == import.Name);
            return result ?? _districtService.Add(new DistrictEntity { Name = import.Name });
        }

        private LocationEntity AddOrCreate(LocationImport import)
        {
            var result = _locationService.GetItem(x => x.HouseNumber == import.HouseNumber &&
                                                       x.BuildingCorpus == import.BuildingNumber &&
                                                       x.ApartmentNumber == import.ApartmentNumber);
            if (result != null)
                return result;

            return _locationService.Add(new LocationEntity
            {
                HouseNumber = import.HouseNumber,
                ApartmentNumber = import.ApartmentNumber,
                BuildingCorpus = import.BuildingNumber,
            });
        }

        private AddressEntity AddOrCreate(AddressImport import, DistrictEntity districtEntity, LocationEntity locationEntity)
        {
            var result = _addressService.GetItem(x => x.StreetName == import.Name);
            if (result != null)
                return result;

            return _addressService.Add(new AddressEntity
            {
                StreetName = import.Name,
                DistrictId = districtEntity.Id,
                LocationId = locationEntity.Id
            });
        }


        private DateTime ConvertAccrualMonth(string date)
        {
            return DateTime.Parse($"01.{date}");
        }

        private AccountType ConvertAccountType(int code)
        {
            return code.ToString().StartsWith("5") ? AccountType.Municipal : AccountType.Private;
        }
    }
}