using BookKeeper.Data.Data.Entities.Payments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BookKeeper.Data.Data.Entities.Address;

namespace BookKeeper.Data.Data.Entities
{
    public enum AccountType
    {
        Municipal,
        Private
    }

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

        public virtual ICollection<PaymentDocumentEntity> PaymentDocuments { get; set; }


    }
}
