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

    public interface IDiscountDocumentService : IService<DiscountEntity>
    {
        DiscountEntity AddDiscountOnAccount(int accountId, decimal percent, string description);

        DiscountEntity AddDiscountOnAccount(int accountId, decimal percent, string description,DateTime fromDateTime,DateTime toDateTime);

        IEnumerable<DiscountEntity> AddDiscountOnAddress(IEnumerable<int> accountId, decimal percent, string description);

        IEnumerable<DiscountEntity> AddDiscountOnAddress(IEnumerable<int> accountId, decimal percent, string description,DateTime fromDateTime,DateTime toDateTime);

        DiscountEntity GetCurrentDiscount(int accountId, DateTime paymentDate);

        void SendToArchive(DiscountEntity entity);
    }
    public class DiscountService : Service<DiscountEntity>, IDiscountDocumentService
    {
        public DiscountService(IRepository<DiscountEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public DiscountEntity AddDiscountOnAccount(int accountId, decimal percent, string description)
        {
            var activeDiscount = GetActiveDiscount(accountId);
            if (activeDiscount != null)
                SendToArchive(activeDiscount);

            var document = new DiscountEntity
            {
                AccountId = accountId,
                StartDate = DateTime.Parse($"01.{DateTime.Today.Month}.{DateTime.Today.Year}"),
                EndDate = DateTime.MaxValue,
                Percent = percent,
                Description = description,
                Type = DiscountType.PersonalAccount
            };
            return base.Add(document);
        }

        public DiscountEntity AddDiscountOnAccount(int accountId, decimal percent, string description, DateTime fromDateTime,
            DateTime toDateTime)
        {
            var activeDiscount = GetActiveDiscount(accountId);
            if (activeDiscount != null)
                SendToArchive(activeDiscount);

            var document = new DiscountEntity
            {
                AccountId = accountId,
                StartDate = fromDateTime,
                EndDate = toDateTime,
                Percent = percent,
                Description = description,
                Type = DiscountType.PersonalAccount
            };
            return base.Add(document);
        }

        public IEnumerable<DiscountEntity> AddDiscountOnAddress(IEnumerable<int> accountId, decimal percent, string description)
        {
            var activeDiscount = GetActiveDiscount(accountId.FirstOrDefault());
            if (activeDiscount != null)
                SendToArchive(activeDiscount);

            var discounts = new List<DiscountEntity>();
            foreach (var account in accountId)
            {
                var document = new DiscountEntity
                {
                    AccountId = account,
                    StartDate = DateTime.Parse($"01.{DateTime.Today.Month}.{DateTime.Today.Year}"),
                    EndDate = DateTime.MaxValue,
                    Percent = percent,
                    Description = description,
                    Type = DiscountType.Address
                };
                discounts.Add(document);
            }
            base.Add(discounts);
            return discounts;
        }

        public IEnumerable<DiscountEntity> AddDiscountOnAddress(IEnumerable<int> accountId, decimal percent, string description, DateTime fromDateTime,
            DateTime toDateTime)
        {
            var activeDiscount = GetActiveDiscount(accountId.FirstOrDefault());
            if (activeDiscount != null)
                SendToArchive(activeDiscount);

            var discounts = new List<DiscountEntity>();
            foreach (var account in accountId)
            {
                var document = new DiscountEntity
                {
                    AccountId = account,
                    StartDate = fromDateTime,
                    EndDate = toDateTime,
                    Percent = percent,
                    Description = description,
                    Type = DiscountType.Address
                };
                discounts.Add(document);
            }
            base.Add(discounts);
            return discounts;
        }

        public void SendToArchive(DiscountEntity entity)
        {
            var discount = base.GetItemById(entity.Id);
            if (discount == null)
                return;

            discount.EndDate = DateTime.Now;
            discount.IsArchive = true;
            base.Update(discount);
        }


        public DiscountEntity GetCurrentDiscount(int accountId, DateTime paymentDate)
        {
            return base.GetItem(x => x.AccountId == accountId && x.StartDate.Date <= paymentDate.Date && paymentDate.Date < x.EndDate.Date && x.IsDeleted == false);
        }

        private DiscountEntity GetActiveDiscount(int accountId)
        {
            return base.GetItem(x => x.IsDeleted == false && x.AccountId == accountId && x.IsArchive == false);
        }

        private decimal CalculateDiscountPrice()
        {

        }
    }
}