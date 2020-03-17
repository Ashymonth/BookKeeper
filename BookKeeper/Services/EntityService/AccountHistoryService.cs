using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService
{
    public interface IAccountHistoryService : IService<AccountsHistoryEntity>
    {

    }

    public class AccountHistoryService : Service<AccountsHistoryEntity> , IAccountHistoryService
    {
        public AccountHistoryService(IRepository<AccountsHistoryEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
