using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Payments
{
    public class PaymentDocumentEntity : BaseEntity
    {
        public int AccountId { get; set; }

        public string ApartmentNumber { get; set; }

        public long PersonalAccount { get; set; }

        public decimal Accrued { get; set; }

        public decimal Received { get; set; }

        public DateTime PaymentDate { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual AccountEntity Account { get; set; }
    }
}
