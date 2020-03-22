﻿using BookKeeper.Data.Infrastructure.Configuration;
using BookKeeper.Data.Models.ExcelImport;
using ClosedXML.Excel;
using System.Collections.Generic;
using System.Linq;

namespace BookKeeper.Data.Services.Import
{


    public class ExcelImportService : IImportService<List<ImportDataRow>>
    {
        private readonly IConfiguration<ExcelConfiguration> _configuration = new ExcelConfiguration();

        public List<ImportDataRow> ImportDataRow(string file)
        {
            var configuration = _configuration.Load();

            var importData = new List<ImportDataRow>();

            using (var workBook = new XLWorkbook(file))
            {
                var workSheet = workBook.Worksheet(1);

                importData.AddRange(workSheet.Column(configuration.StartColumn)
                    .CellsUsed()
                    .SkipWhile(x => x.GetString() != configuration.ServiceProviderCodeValue)
                    .Select(cell => new ImportDataRow
                    {
                        Address = new AddressImport()
                        {
                            Name = cell.CellRight(configuration.StreetName).GetString(),
                        },

                        District = new DistrictImport()
                        {
                            Name = cell.CellRight(configuration.DistrictName).GetString(),
                            Code = cell.CellRight(2).GetValue<int>()
                        },

                        LocationImport = new LocationImport()
                        {
                            HouseNumber = cell.CellRight(configuration.HouseNumber).GetString(),
                            ApartmentNumber = cell.CellRight(configuration.ApartmentNumber).GetString(),
                            BuildingNumber = cell.CellRight(configuration.CorpusNumber).GetString()
                        },

                        Account = new AccountImport()
                        {
                            ServiceProviderCode = cell.CellRight(configuration.ServiceProviderCode).GetString(),
                            PersonalAccount = cell.CellRight(configuration.PersonalAccount).GetValue<int>(),
                            AccountType = cell.CellRight(configuration.DistrictType).GetValue<int>(),
                            AccrualMonth = cell.CellRight(configuration.AccrualMonth).GetString()
                        }
                    }));
            }
            return importData;
        }
    }
}
