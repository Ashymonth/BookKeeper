using BookKeeper.Data.Data.Entities.Rates;
using System;
using System.Configuration;
using System.Data.Entity;

namespace BookKeeper.Data.Data
{
    public class RateEntityInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var rateDocument = new RateEntity()
            {
                Price = Convert.ToDecimal(ConfigurationManager.AppSettings["DefaultPrice"]),
                StartDate = DateTime.MinValue,
                EndDate = DateTime.MaxValue,
                IsDefault = true,
            };
            context.Rates.Add(rateDocument);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
