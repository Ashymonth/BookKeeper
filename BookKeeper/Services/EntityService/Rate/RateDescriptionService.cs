using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService.Rate
{
    public interface IRateDescriptionService : IService<RateDescriptionEntity>
    {

    }

    public class RateDescriptionService : Service<RateDescriptionEntity>, IRateDescriptionService
    {
        public RateDescriptionService(IRepository<RateDescriptionEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
