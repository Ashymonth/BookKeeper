using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService.Discount
{

    public interface IDiscountDocumentService : IService<DiscountDocumentEntity>
    {
        DiscountDocumentEntity AddDiscountOnAccount(int accountId,decimal percent,string description);
    }
    public class DiscountDocumentService : Service<DiscountDocumentEntity>,IDiscountDocumentService
    {
        public DiscountDocumentService(IRepository<DiscountDocumentEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public DiscountDocumentEntity AddDiscountOnAccount(int accountId, decimal percent, string description)
        {
            var document = new DiscountDocumentEntity
            {
                Type = DiscountType.PersonalAccount,
                AccountId = accountId,
                Percent = percent,
                Description = description,
                StartDate = DateTime.Now
            };
            return base.Add(document);
        }
    }
}
