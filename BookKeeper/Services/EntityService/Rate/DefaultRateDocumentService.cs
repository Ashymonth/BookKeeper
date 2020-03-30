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
    public interface IDefaultRateDocumentService : IService<DefaultRateDocumentEntity>
    {

    }

    public class DefaultRateDocumentService : Service<DefaultRateDocumentEntity>, IDefaultRateDocumentService
    {
        public DefaultRateDocumentService(IRepository<DefaultRateDocumentEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
