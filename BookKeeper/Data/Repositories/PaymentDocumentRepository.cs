using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities.Payments;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IPaymentDocumentRepository : IRepository<PaymentDocumentEntity>
    {

    }

    public class PaymentDocumentRepository :Repository<PaymentDocumentEntity>,IPaymentDocumentRepository
    {
        public PaymentDocumentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
