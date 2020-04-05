using Autofac;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService.Rate;
using System;
using System.Configuration;

namespace BookKeeper.UI.Helpers
{
    public class DefaultRateLoader
    {
        private readonly IContainer _container;

        public DefaultRateLoader()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }

        public void LoadAndCheckDefaultRate()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var rateService = scope.Resolve<IRateService>();
                var rates = rateService.GetItem(x => x.IsDefault);
                if (rates == null)
                {
                    rateService.Add(new RateEntity()
                    {
                        Price = System.Convert.ToDecimal(ConfigurationManager.AppSettings["DefaultPrice"]),
                        StartDate = DateTime.MinValue,
                        EndDate = DateTime.MaxValue,
                        IsDefault = true,
                    });
                }

                if (rates != null && rates.Price != System.Convert.ToDecimal(ConfigurationManager.AppSettings["DefaultPrice"]))
                {
                    var defaultRate = rateService.GetItem(x => x.IsDefault);
                    if (defaultRate != null)
                    {
                        defaultRate.Price =
                            System.Convert.ToDecimal(ConfigurationManager.AppSettings["DefaultPrice"]);

                        rateService.Update(defaultRate);
                    }
                }
            }
        }
    }
}
