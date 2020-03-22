using BookKeeper.Data.Data.Entities.Payments;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IPaymentDocumentRepository : IRepository<PaymentDocumentEntity>
    {

    }

    public class PaymentDocumentRepository : Repository<PaymentDocumentEntity>, IPaymentDocumentRepository
    {
        public PaymentDocumentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
