using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BookKeeper.Data.Data.Entities.Discounts;

namespace BookKeeper.Data.Data.Entities.Payments
{
    [Table("PaymentDocuments")]
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