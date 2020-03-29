﻿using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Payments;
using BookKeeper.Data.Models.HtmlImport;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.Import;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BookKeeper.Data.Infrastructure.Configuration;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services.EntityService.Rate;

namespace BookKeeper.Data.Services.Load
{
    public class HtmlLoadService : IDataLoader
    {
        private readonly Dictionary<string, int> _monthDictionary = new Dictionary<string, int>
        {
            {"январь", 01},
            {"февраль", 02},
            {"март", 03},
            {"апрель", 04},
            {"май", 05},
            {"июнь", 06},
            {"июль", 07},
            {"август", 08},
            {"сентябрь", 09},
            {"октябрь", 10},
            {"ноябрь", 11},
            {"декабрь", 12}
        };

        private readonly IImportService<List<PaymentDocumentImport>> _importService;
        private readonly IAccountService _accountService;
        private readonly IPaymentDocumentService _documentService;
        private readonly IConfiguration<HtmlConfiguration> _configuration;

        public HtmlLoadService(IImportService<List<PaymentDocumentImport>> importService, IAccountService accountService, IPaymentDocumentService documentService, IConfiguration<HtmlConfiguration> configuration)
        {
            _importService = importService;
            _accountService = accountService;
            _documentService = documentService;
            _configuration = configuration;
        }
        public ImportReportModel LoadData(string file)
        {
            var result = _importService.ImportDataRow(file);

            if(result == null)
                throw new NullReferenceException(nameof(result));

            var importReport = new ImportReportModel();

            foreach (var item in result)
            {
                var configuration = _configuration.Load();
                if (configuration == null)
                    throw new NullReferenceException(nameof(configuration));

                var documentsToAdd = new List<PaymentDocumentEntity>();
                var documentsToUpdate = new List<PaymentDocumentEntity>();

                foreach (var item1 in item.PaymentDetailsImports)
                {

                    var personalAccount = ValidPersonalAccount(item1.PersonalAccount, configuration.AccountLength);
                    var documentDate = ValidDateTime(item.DocumentData);

                    var account = _accountService.GetItem(x => x.Account == personalAccount);
                    if (account == null)
                    {
                        importReport.CorruptedRecords++;
                        continue;
                    }

                    var paymentDocuments = account.PaymentDocuments.Where(x => x.PaymentDate == documentDate).ToList();
                    if (paymentDocuments.Count() != 0)
                    {
                        documentsToUpdate
                            .AddRange(paymentDocuments
                                .Where(entity => entity.Accrued != item1.Accrued ||
                                                 entity.Received != item1.Received &&
                                                 entity.IsDeleted == false));
                        continue;
                    }

                    if (account.PaymentDocuments == null)
                        account.PaymentDocuments = new List<PaymentDocumentEntity>();

                    account.PaymentDocuments.Add(new PaymentDocumentEntity
                    {
                        AccountId = account.Id,
                        Accrued = item1.Accrued,
                        Received = item1.Received,
                        PaymentDate = documentDate,
                    });

                    var paymentDocument = new PaymentDocumentEntity
                    {
                        AccountId = account.Id,
                        Accrued = item1.Accrued,
                        Received = item1.Received,
                        PaymentDate = documentDate,
                    };

                    documentsToAdd.Add(paymentDocument);
                }

                if (documentsToAdd.Count != 0)
                {
                    _documentService.Add(documentsToAdd);
                    importReport.Add += documentsToAdd.Count;
                }

                if (documentsToUpdate.Count != 0)
                {
                    _documentService.Update(documentsToUpdate);
                    importReport.Updates += documentsToUpdate.Count;
                }

              
            }
            return importReport;
        }

        private ImportReportModel AddPaymentDocument(PaymentDocumentImport import)
        {
            var importReport = new ImportReportModel();

            var configuration = _configuration.Load();
            if(configuration == null)
                throw new NullReferenceException(nameof(configuration));

            var documentsToAdd = new List<PaymentDocumentEntity>();
            var documentsToUpdate = new List<PaymentDocumentEntity>();

            foreach (var item in import.PaymentDetailsImports)
            {

                var personalAccount = ValidPersonalAccount(item.PersonalAccount,configuration.AccountLength);
                var documentDate = ValidDateTime(import.DocumentData);

                var account = _accountService.GetItem(x => x.Account == personalAccount);
                if (account == null)
                {
                    importReport.CorruptedRecords++;
                    continue;
                }

                var paymentDocuments = account.PaymentDocuments.Where(x => x.PaymentDate == documentDate).ToList();
                if (paymentDocuments.Count() != 0)
                {
                    documentsToUpdate
                        .AddRange(paymentDocuments
                            .Where(entity => entity.Accrued != item.Accrued || 
                                             entity.Received != item.Received &&
                                             entity.IsDeleted == false));
                    continue;
                }

                if (account.PaymentDocuments == null)
                    account.PaymentDocuments = new List<PaymentDocumentEntity>();

                account.PaymentDocuments.Add(new PaymentDocumentEntity
                {
                    AccountId = account.Id,
                    Accrued = item.Accrued,
                    Received = item.Received,
                    PaymentDate = documentDate,
                });

                var paymentDocument = new PaymentDocumentEntity
                {
                    AccountId = account.Id,
                    Accrued = item.Accrued,
                    Received = item.Received,
                    PaymentDate = documentDate,
                };

                documentsToAdd.Add(paymentDocument);
            }

            if (documentsToAdd.Count != 0)
            {
                _documentService.Add(documentsToAdd);
                importReport.Add += documentsToAdd.Count;
            }

            if (documentsToUpdate.Count != 0)
            {
                _documentService.Update(documentsToUpdate);
                importReport.Updates += documentsToUpdate.Count;
            }

            return importReport;
        }

        private static long ValidPersonalAccount(long personalAccount,int accountLength)
        {
            if (personalAccount.ToString().Length > accountLength)//TODO Add municipal account mark to config
            {
                personalAccount = Convert.ToUInt32(personalAccount.ToString().Substring(personalAccount.ToString().Length - accountLength));
            }

            return personalAccount;
        }
        private DateTime ValidDateTime(string documentDate)
        {
            var result = Regex.Replace(documentDate, @"<[^>]+>|&nbsp;", "").Trim().ToLower().Split();

            return DateTime.Parse($"01.{_monthDictionary[result[0]]}.{result[1]}");
        }
    }
}