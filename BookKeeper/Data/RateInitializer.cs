using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Entities.Rates;

namespace BookKeeper.Data.Data
{
    public class RateEntityInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var rateDocument = new DefaultRateDocumentEntity()
            {
                Price = Convert.ToDecimal(ConfigurationManager.AppSettings["DefaultPrice"]),
                StartDate = DateTime.MinValue,
                EndDate = DateTime.MaxValue,
            };

            context.DefaultRateDocument.Add(rateDocument);

            base.Seed(context);
        }
    }
}
