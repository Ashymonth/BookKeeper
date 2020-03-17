using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Payments
{
    public class PaymentDocumentEntity : BaseEntity
    {
        public string ApartmentNumber { get; set; }

        public long PersonalAccount { get; set; }

        public decimal Accrued { get; set; }

        public decimal Received { get; set; }

        public DateTime PaymentDate { get; set; }

        public int AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public AccountEntity Account { get; set; }
    }
}
