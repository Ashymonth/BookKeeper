using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Payments
{
    [Table("PaymentDocument")]
    public class PaymentDocumentEntity : BaseEntity
    {
        public int AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public AccountEntity Account { get; set; }

        public decimal Accrued { get; set; }

        public decimal Received { get; set; }

        public DateTime PaymentDate { get; set; }

    }
}
