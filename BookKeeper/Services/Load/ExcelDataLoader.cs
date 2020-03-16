﻿using BookKeeper.Data.Data.Entities;
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
            var import = _import.ImportDataRow(file);

            foreach (var districtsGroup in import.GroupBy(x => x.District.Name))
            {
                var firstDistrict = districtsGroup.FirstOrDefault();

                var district = AddOrCreate(firstDistrict?.District);

                foreach (var addressGroup in districtsGroup.GroupBy(x => x.Address.Name))
                {
                    var firstAddress = addressGroup.FirstOrDefault();
                    var address = AddOrCreate(firstAddress?.Address, district.Id);

                    var accountsToUpdate = new List<AccountEntity>();
                    var accountsToAdd = new List<AccountEntity>();

                    foreach (var dataRow in addressGroup)
                    {
                        var account = _accountService.GetItem(x => x.PersonalAccount == firstDistrict?.Account.PersonalAccount && !x.IsDeleted);

                        if (account != null)
                        {
                            account.IsArchive = account.IsEmpty && string.IsNullOrWhiteSpace(dataRow.Account.ServiceProviderCode);
                            account.IsEmpty = string.IsNullOrWhiteSpace(dataRow.Account.ServiceProviderCode);
                            
                            accountsToUpdate.Add(account);
                            continue;
                        }

                        account = new AccountEntity
                        {
                            AccrualMonth = ConvertAccrualMonth(dataRow.Account.AccrualMonth),
                            PersonalAccount = dataRow.Account.PersonalAccount,
                            AccountType = ConvertAccountType(dataRow.Account.AccountType),
                            IsEmpty = string.IsNullOrWhiteSpace(dataRow.Account.ServiceProviderCode),
                        };

                        address.Locations.Add(new LocationEntity()
                        {
                            HouseNumber = dataRow.LocationImport.HouseNumber,
                            BuildingCorpus = dataRow.LocationImport.BuildingNumber,
                            ApartmentNumber = dataRow.LocationImport.ApartmentNumber,
                            AddressId = address.Id
                        });

                        account.AddressId = address.Id;

                        accountsToAdd.Add(account);
                    }
                    if (accountsToAdd.Count != 0)
                    {
                        _accountService.Add(accountsToAdd);
                    }
                    else
                    {
                        _accountService.Update(accountsToUpdate);
                        _addressService.Save();
                    }
                }
            }
        }

        private DistrictEntity AddOrCreate(DistrictImport import)
        {
            var result = _districtService.GetItem(x => x.Name == import.Name);
            return result ?? _districtService.Add(import.Code, import.Name);
        }

        private StreetEntity AddOrCreate(AddressImport import,int districtId)
        {
            var result = _addressService.GetItem(x => x.StreetName == import.Name);
            if (result != null)
                return result;

            return _addressService.Add(new StreetEntity
            {
                StreetName = import.Name,
                DistrictId = districtId,
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