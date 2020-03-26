using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService.Discount
{
    public interface IDiscountDescriptionService : IService<DiscountDescriptionEntity>
    {
        void AddDescription(string description);
    }
    public class DiscountDescriptionService : Service<DiscountDescriptionEntity>, IDiscountDescriptionService
    {
        public DiscountDescriptionService(IRepository<DiscountDescriptionEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public void AddDescription(string description)
        {
            if(string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description));

            base.Add(new DiscountDescriptionEntity {Description = description});
        }
    }
}
