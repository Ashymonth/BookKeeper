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
            
        }
    }
}
