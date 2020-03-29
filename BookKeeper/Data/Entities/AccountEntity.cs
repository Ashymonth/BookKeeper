using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Entities.Payments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities
{
    public enum AccountType
    {
        Municipal,
        Private
    }

    [Table("Account")]
    public class AccountEntity : BaseEntity
    {
        public int StreetId { get; set; }

        public int LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        public virtual LocationEntity Location { get; set; }

        public long Account { get; set; }

        public DateTime AccountCreationDate { get; set; }

        public AccountType AccountType { get; set; }

        public bool IsEmpty { get; set; }

        public bool IsArchive { get; set; }

        public bool IsEmptyAgain { get; set; }

        public virtual ICollection<PaymentDocumentEntity> PaymentDocuments { get; set; }

        //public virtual ICollection<DiscountDocumentEntity> DiscountDocuments { get; set; }
    }
}
