using BookKeeper.Data.Infrastructure.Configuration;
using BookKeeper.Data.Models.HtmlImport;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using BookKeeper.Data.Infrastructure.Formats;

namespace BookKeeper.Data.Services.Import
{
    public class HtmlImportService : IImportService<List<PaymentDocumentImport>>
    {
        private const string Column = "//tr";
        private const string Div = ".//div";
        private const string Row = "td";
        private int _count = -1;
        private bool _header = true;

        private readonly IConfiguration<HtmlConfiguration> _configuration;

        public HtmlImportService(IConfiguration<HtmlConfiguration> configuration)
        {
            _configuration = configuration;
        }

        public List<PaymentDocumentImport> ImportDataRow(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException(nameof(file));

            if (!File.Exists(file))
                throw new FileNotFoundException(nameof(file));

            file = HtmlFormatValidator.ValidateFormat(file);

            if (file == null)
                throw new FileNotFoundException(nameof(file));

            var html = new HtmlDocument();

            html.LoadHtml(File.ReadAllText(file, Encoding.UTF8));

            var configuration = _configuration.Load();
            if (configuration == null)
                throw new FileNotFoundException(nameof(configuration));

            var paymentDocument = new List<PaymentDocumentImport>();

            foreach (var row in html.DocumentNode.SelectNodes(Column))
            {
                if (row.Id.Contains(configuration.HeaderId))
                {
                    _count++;
                    var infoCells = row.SelectNodes(Div);

                    paymentDocument.Add(new PaymentDocumentImport());

                    var paymentInfo = paymentDocument[_count];

                    paymentInfo.District = infoCells[configuration.DistrictCell].InnerText.Trim();
                    paymentInfo.DocumentData = infoCells[configuration.DocumentDateCell].InnerText.Trim();
                    paymentInfo.Address = infoCells
                        .FirstOrDefault(x => x.InnerText.Trim().Contains("адрес:"))?.InnerText.Trim();

                    _header = false;
                    continue;
                }
                if (_header)
                    continue;

                var cells = row.SelectNodes(Row);
                if (cells == null)
                    continue;

                if (cells.Count < 4)
                    break;

                if (cells[configuration.ReceivedCell].InnerText.ToLower().Trim().Contains("поступило"))
                    continue;

                if (cells[configuration.ApartmentNumberCell].InnerText.ToLower().Trim().Contains("итого"))
                    continue;

                var paymentDetails = new PaymentDetailsImport
                {
                    ApartmentNumber = cells[configuration.ApartmentNumberCell].InnerText.Trim(),
                    PersonalAccount = Convert.ToInt64(cells[configuration.PersonalAccountCell].InnerText.Trim()),
                    Accrued = Convert.ToDecimal(cells[configuration.AccruedCell].InnerText.Trim().ToString(CultureInfo.CurrentCulture)),
                    Received = Convert.ToDecimal(cells[configuration.ReceivedCell].InnerText.Trim().ToString(CultureInfo.CurrentCulture))
                };

                paymentDocument[_count].PaymentDetailsImports.Add(paymentDetails);
            }

            return paymentDocument;
        }
    }
}