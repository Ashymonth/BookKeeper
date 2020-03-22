using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Payments;
using BookKeeper.Data.Data.Repositories;

namespace BookKeeper.Data.Services.EntityService
{
    public interface IPaymentDocumentService : IService<PaymentDocumentEntity>
    {

    }

    public class PaymentDocumentService : Service<PaymentDocumentEntity>, IPaymentDocumentService
    {
        public PaymentDocumentService(IRepository<PaymentDocumentEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
