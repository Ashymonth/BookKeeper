using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Data.Repositories;
using BookKeeper.Data.Models;

namespace BookKeeper.Data.Services.EntityService
{
    public interface IRateService : IService<RateEntity>
    {
        bool AddRate(Rate rate);
    }

    public class RateService : Service<RateEntity>, IRateService
    {
        private const decimal DefaultPrice = 166;

        public RateService(IRepository<RateEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public bool AddRate(Rate rate)
        {
            if (rate == null)
                return false;

            var rateEntity = new RateEntity
            {
                IsDefault = rate.Price == DefaultPrice,
                DefaultPrice = DefaultPrice,
                RateCreationDate = DateTime.Now,
                StartDate = DateTime.Now,
                Price = rate.Price,
            };

            return true;
        }
    }
}
