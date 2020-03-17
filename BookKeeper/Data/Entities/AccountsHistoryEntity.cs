using System;

namespace BookKeeper.Data.Data.Entities
{
    public class AccountsHistoryEntity : BaseEntity 
    {
        public int AccountId { get; set; }

        public DateTime Date { get; set; }
    }
}
