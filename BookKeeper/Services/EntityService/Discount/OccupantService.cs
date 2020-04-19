using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService.Discount
{
    public interface IOccupantService : IService<OccupantEntity>
    {
        OccupantEntity AddOccupant(int discountId,int accountId,decimal discountPercent);
    }

    public class OccupantService : Service<OccupantEntity>, IOccupantService
    {
        public OccupantService(IRepository<OccupantEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }


        public OccupantEntity AddOccupant(int discountId, int accountId, decimal discountPercent)
        {
            var occupant = new OccupantEntity()
            {
                DiscountId = discountId,
                AccountId = accountId,
                Type = discountPercent == 0 ? OccupantType.NoDiscount : OccupantType.WithDiscount
            };
            return base.Add(occupant);
        }
    }
}
