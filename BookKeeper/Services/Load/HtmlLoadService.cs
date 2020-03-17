using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Models.HtmlImport;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.Import;

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
        private readonly IAccountHistoryService _accountHistoryService;

        public HtmlLoadService(IImportService<List<PaymentDocumentImport>> importService, IAccountService accountService,
            IAccountHistoryService accountHistoryService)
        {
            _importService = importService;
            _accountService = accountService;
            _accountHistoryService = accountHistoryService;
        }
        public void LoadData(string file)
        {
            var result = _importService.ImportDataRow(file);

            foreach (var item in result)
            {
                FindAccount(item);
            }
        }

        private void FindAccount(PaymentDocumentImport import)
        {
            foreach (var item in import.PaymentDetailsImports)
            {
                var personalAccount = ValidPersonalAccount(item.PersonalAccount);
                var date = ValidDateTime(import.DocumentData);

                var account = _accountService.GetItem(x => x.PersonalAccount == personalAccount &&
                                                           x.AccrualMonth == date &&
                                                           !x.IsDeleted);

                account.Accrued = item.Accrued;
                account.Received = item.Received;

                _accountHistoryService.Add(new AccountsHistoryEntity
                {
                    AccountId = account.Id,
                    Date = date
                });

            }
        }

        private long ValidPersonalAccount(long personalAccount)
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
