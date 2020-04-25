using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Payments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities
{
    public enum AccountType
    {
        Municipal,
        Private,
        All
    }

    [Table("Accounts")]
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

        /// <summary>
        /// Если код поставщика услуги  в экселе отсутсвовал 3 месяца, то счет переводится в архив
        /// </summary>
        public bool IsArchive { get; set; }

        public bool IsEmptyAgain { get; set; }

        /// <summary>
        /// Если счет был впервые занесен в базу
        /// </summary>

        public bool IsNew { get; set; }

        public virtual ICollection<PaymentDocumentEntity> PaymentDocuments { get; set; }
    }
}
