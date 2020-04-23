using BookKeeper.Data.Data.Entities;

namespace BookKeeper.UI.Models.Account
{
    public class DebtorModel
    {
        public AccountEntity Account { get; set; }

        public int AccountsCount { get; set; }
    }
}