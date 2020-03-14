using System;

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

        public DateTime AccrualMonth { get; set; }

        public bool IsEmpty { get; set; }

        public bool IsArchive { get; set; }
    }
}
