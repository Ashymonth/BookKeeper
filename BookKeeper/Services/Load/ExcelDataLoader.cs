﻿using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Infrastructure.Configuration;
using BookKeeper.Data.Infrastructure.Reports;
using BookKeeper.Data.Models;
using BookKeeper.Data.Models.ExcelImport;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.Import;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookKeeper.Data.Services.Load
{
    public class ExcelDataLoader : IDataLoader
    {
        private readonly IImportService<List<ImportDataRow>> _import;
        private readonly IDistrictService _districtService;
        private readonly IStreetService _streetService;
        private readonly IAccountService _accountService;
        private readonly IConfiguration<ExcelConfiguration> _configuration;
        private readonly IBrokenRecordsReport _brokenRecordsReport;


        public ExcelDataLoader(IImportService<List<ImportDataRow>> import, IDistrictService districtService, IStreetService streetService, IAccountService accountService, 
            IConfiguration<ExcelConfiguration> configuration, IBrokenRecordsReport brokenRecordsReport)
        {
            _import = import;
            _districtService = districtService;
            _streetService = streetService;
            _accountService = accountService;
            _configuration = configuration;
            _brokenRecordsReport = brokenRecordsReport;
        }

        public ImportReportModel LoadData(string file)
        {
            var configuration = _configuration.Load();

            var import = _import.ImportDataRow(file);
            
            var importReport = new ImportReportModel();

            foreach (var districtsGroup in import.GroupBy(x => x.District.Name))
            {
                var firstDistrict = districtsGroup.FirstOrDefault();

                if (firstDistrict == null)
                    continue;

                var district = AddOrCreate(firstDistrict.District);

                foreach (var addressGroup in districtsGroup.GroupBy(x => x.Address.Name))
                {
                    var firstAddress = addressGroup.FirstOrDefault();
                    if (firstAddress == null)
                        continue;

                    var street = AddOrCreate(firstAddress.Address, district.Id);

                    var accountsToUpdate = new List<AccountEntity>();
                    var accountsToAdd = new List<AccountEntity>();

                    foreach (var dataRow in addressGroup)
                    {
                        try
                        {
                            var account = _accountService.GetItem(x => x.Account == dataRow.Account.PersonalAccount && !x.IsDeleted);

                            if (account != null)
                            {
                                account.IsArchive = account.IsEmpty && account.IsEmptyAgain && string.IsNullOrWhiteSpace(dataRow.Account.ServiceProviderCode);
                                account.IsEmptyAgain = string.IsNullOrWhiteSpace(dataRow.Account.ServiceProviderCode) &&
                                                       account.IsEmpty;

                                account.IsEmpty = string.IsNullOrWhiteSpace(dataRow.Account.ServiceProviderCode);
                                account.IsNew = false;

                                accountsToUpdate.Add(account);
                                continue;
                            }

                            account = new AccountEntity
                            {
                                AccountCreationDate = ConvertAccrualMonth(dataRow.Account.AccrualMonth),
                                Account = dataRow.Account.PersonalAccount,
                                AccountType = ConvertAccountType(dataRow.Account.AccountType, configuration.MunicipalMark),
                                IsEmpty = string.IsNullOrWhiteSpace(dataRow.Account.ServiceProviderCode),
                                IsNew = true
                            };

                            if (street.Locations == null)
                                street.Locations = new List<LocationEntity>();

                            var location = new LocationEntity
                            {
                                HouseNumber = dataRow.LocationImport.HouseNumber,
                                BuildingCorpus = dataRow.LocationImport.BuildingNumber,
                                ApartmentNumber = dataRow.LocationImport.ApartmentNumber,
                                StreetId = street.Id,
                            };
                            street.Locations.Add(location);

                            account.StreetId = street.Id;
                            account.Location = location;

                            accountsToAdd.Add(account);
                        }
                        catch (Exception e)
                        {
                            _brokenRecordsReport.WriteException(e.Message,FileType.Excel);
                        }
                       
                    }
                    if (accountsToAdd.Count != 0)
                    {
                        _accountService.Add(accountsToAdd);
                        importReport.Add += accountsToAdd.Count;
                    }
                    else
                    {
                        _accountService.Update(accountsToUpdate);
                        importReport.Updates += accountsToUpdate.Count;
                    }
                }
            }
            return importReport;
        }

        private DistrictEntity AddOrCreate(DistrictImport import)
        {
            var result = _districtService.GetItem(x => x.Code == import.Code);
            return result ?? _districtService.Add(import.Code, import.Name);
        }

        private StreetEntity AddOrCreate(AddressImport import, int districtId)
        {
            var result = _streetService.GetItem(x => x.StreetName == import.Name);
            if (result != null)
                return result;

            return _streetService.Add(new StreetEntity
            {
                StreetName = import.Name,
                DistrictId = districtId,
            });
        }

        private static DateTime ConvertAccrualMonth(string date)
        {
            return DateTime.Parse($"01.{date}");
        }

        private static AccountType ConvertAccountType(int code, string municipalMark)
        {
            return code.ToString().StartsWith(municipalMark) ? AccountType.Municipal : AccountType.Private;
        }
    }
}