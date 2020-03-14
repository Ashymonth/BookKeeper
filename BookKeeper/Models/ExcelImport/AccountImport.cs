namespace BookKeeper.Data.Models.ExcelImport
{
    public class AccountImport
    {
        public string ServiceProviderCode { get; set; }

        public string AccrualMonth { get; set; }

        public int AccountType { get; set; }

        public long PersonalAccount { get; set; }
    }
}
