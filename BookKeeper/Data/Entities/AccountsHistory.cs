using System;

namespace BookKeeper.Data.Data.Entities
{
    public class AccountsHistory : BaseEntity
    {
        public int AccountId { get; set; }

        public DateTime Date { get; set; }
    }
}
