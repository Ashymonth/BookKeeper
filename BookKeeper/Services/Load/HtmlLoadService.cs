using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Payments;
using BookKeeper.Data.Models.HtmlImport;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.Import;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BookKeeper.Data.Services.Load
{
    public class HtmlLoadService : IDataLoader
    {
        private readonly Dictionary<string, int> _monthDictionary = new Dictionary<string, int>
        {
            {"январь", 01},
            {"Февраль", 02},
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

        private const int PersonalAccountLength = 8;

        private readonly IImportService<List<PaymentDocumentImport>> _importService;
        private readonly IAccountService _accountService;

        public HtmlLoadService(IImportService<List<PaymentDocumentImport>> importService, IAccountService accountService)
        {
            _importService = importService;
            _accountService = accountService;
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
            var accountsToUpdate = new List<AccountEntity>();
            foreach (var item in import.PaymentDetailsImports)
            {

                var personalAccount = ValidPersonalAccount(item.PersonalAccount);
                var documentDate = ValidDateTime(import.DocumentData);

                var account = _accountService.GetItem(x => x.Account == personalAccount);

                if (account == null)
                    continue;

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

            _accountService.Update(accountsToUpdate);
        }

        private static long ValidPersonalAccount(long personalAccount)
        {
            if (personalAccount.ToString().Length > PersonalAccountLength)//TODO Add municipal account mark to config
            {
                personalAccount = Convert.ToUInt32(personalAccount.ToString().Substring(personalAccount.ToString().Length - PersonalAccountLength));
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