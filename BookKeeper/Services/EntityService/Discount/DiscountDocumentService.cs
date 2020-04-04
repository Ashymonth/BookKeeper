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
        DiscountDocumentEntity AddDiscountOnAccount(int accountId, decimal percent, string description, DateTime startDate, DateTime endDate);

        IEnumerable<DiscountDocumentEntity> AddDiscountOnAddress(IEnumerable<int> accountId, decimal percent, string description, DateTime startDate, DateTime endDate);

        DiscountDocumentEntity GetCurrentDiscount(int accountId, DateTime paymentDate);

        void SendToArchive(DiscountDocumentEntity entity);
    }
    public class DiscountDocumentService : Service<DiscountDocumentEntity>, IDiscountDocumentService
    {
        public DiscountDocumentService(IRepository<DiscountDocumentEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public DiscountDocumentEntity AddDiscountOnAccount(int accountId, decimal percent, string description, DateTime startDate, DateTime endDate)
        {
            var document = new DiscountDocumentEntity
            {
                AccountId = accountId,
                StartDate = startDate,
                EndDate = endDate,
                Percent = percent,
                Description = description,
                Type = DiscountType.PersonalAccount
            };
            return base.Add(document);
        }

        public IEnumerable<DiscountDocumentEntity> AddDiscountOnAddress(IEnumerable<int> accountId, decimal percent, string description, DateTime startDate, DateTime endDate)
        {
            var discounts = new List<DiscountDocumentEntity>();
            foreach (var account in accountId)
            {
                var document = new DiscountDocumentEntity
                {
                    AccountId = account,
                    StartDate = startDate,
                    EndDate = endDate,
                    Percent = percent,
                    Description = description,
                    Type = DiscountType.Address
                };
                discounts.Add(document);
            }
            base.Add(discounts);
            return discounts;
        }

        public void SendToArchive(DiscountDocumentEntity entity)
        {
            var discount = base.GetItemById(entity.Id);
            if (discount == null)
                return;

            discount.EndDate = DateTime.Now;
            discount.IsArchive = true;
            base.Update(discount);
        }
        

        public DiscountDocumentEntity GetCurrentDiscount(int accountId, DateTime paymentDate)
        {
            return base.GetItem(x => x.AccountId == accountId && x.StartDate.Date <= paymentDate.Date && paymentDate.Date < x.EndDate.Date && x.IsDeleted == false);
        }
    }
}