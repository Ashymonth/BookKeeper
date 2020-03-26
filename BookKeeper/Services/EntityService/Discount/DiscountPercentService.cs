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
    public interface IDiscountPercentService : IService<DiscountPercentEntity>
    {
        void AddDiscountPercent(string percent);
    }

    public class DiscountPercentService : Service<DiscountPercentEntity>, IDiscountPercentService
    {
        public DiscountPercentService(IRepository<DiscountPercentEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }


        public void AddDiscountPercent(string percent)
        {
            if(string.IsNullOrWhiteSpace(percent))
                throw new ArgumentNullException(nameof(percent));

            base.Add(new DiscountPercentEntity {Percent = Convert.ToDecimal(percent)});
        }
    }
}
