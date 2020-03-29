using BookKeeper.Data.Data.Entities;
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
        public void LoadData(string file)
        {
            var result = _importService.ImportDataRow(file);

            foreach (var item in result)
            {
                AddPaymentDocument(item);
            }
        }

        private void AddPaymentDocument(PaymentDocumentImport import)
        {
            var configuration = _configuration.Load();

            var accountsToUpdate = new List<AccountEntity>();
            var documentsToUpdate = new List<PaymentDocumentEntity>();
            foreach (var item in import.PaymentDetailsImports)
            {

                var personalAccount = ValidPersonalAccount(item.PersonalAccount,configuration.AccountLength);
                var documentDate = ValidDateTime(import.DocumentData);

                var account = _accountService.GetItem(x => x.Account == personalAccount);
                if (account == null)
                    continue;

                var paymentDocument = account.PaymentDocuments.Where(x => x.PaymentDate == documentDate).ToList();
                if (paymentDocument.Count() != 0)
                {
                    documentsToUpdate
                        .AddRange(paymentDocument
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

                accountsToUpdate.Add(account);
            }

            if (accountsToUpdate.Count != 0)
            {
                _accountService.Update(accountsToUpdate);
            }

            if (documentsToUpdate.Count != 0)
            {
                _documentService.Update(documentsToUpdate);
            }
        }

        private static long ValidPersonalAccount(long personalAccount,int accountLength)
        {
            if (personalAccount.ToString().Length > accountLength)
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