using System;
using System.Collections.Generic;
using BookKeeper.Data.Data.Entities.Payments;

namespace BookKeeper.Data.Data.Entities
{
    public enum AccountType
    {
        Municipal,
        Private
    }

    public class AccountEntity : BaseEntity
    {
        public long PersonalAccount { get; set; }

        public DateTime AccountCreationDate { get; set; }

        public AccountType AccountType { get; set; }

        public bool IsEmpty { get; set; }

        public bool IsArchive { get; set; }

        public int AddressId { get; set; }

        public virtual List<PaymentDocumentEntity> PaymentDocuments{ get; set; }
    }
}
