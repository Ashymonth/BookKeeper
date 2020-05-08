using BookKeeper.Data.Data.Entities.Rates;
using System;
using System.Configuration;

namespace BookKeeper.Data.Services.EntityService.Rate
{
    public interface IDefaultRateService
    {
        void LoadAndCheckDefaultRate();
    }

    public class DefaultRateService : IDefaultRateService
    {
        private readonly IRateService _rateService;

        public DefaultRateService(IRateService rateService)
        {
            _rateService = rateService;
        }

        /// <summary>
        /// Проверка наличия тарифа по умолчнию и изменение, если в файле конфига изменена цена
        /// </summary>
        public void LoadAndCheckDefaultRate()
        {
            var rates = _rateService.GetItem(x => x.IsDefault);
            if (rates == null)
            {
                _rateService.Add(new RateEntity()
                {
                    Price = System.Convert.ToDecimal(ConfigurationManager.AppSettings["DefaultPrice"]),
                    StartDate = DateTime.MinValue,
                    EndDate = DateTime.MaxValue,
                    IsDefault = true,
                });
            }

            if (rates != null && rates.Price != System.Convert.ToDecimal(ConfigurationManager.AppSettings["DefaultPrice"]))
            {
                var defaultRate = _rateService.GetItem(x => x.IsDefault);
                if (defaultRate != null)
                {
                    defaultRate.Price =
                        System.Convert.ToDecimal(ConfigurationManager.AppSettings["DefaultPrice"]);

                    _rateService.Update(defaultRate);
                }
            }
        }
    }
}