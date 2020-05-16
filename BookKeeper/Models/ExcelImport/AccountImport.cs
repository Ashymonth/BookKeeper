namespace BookKeeper.Data.Models.ExcelImport
{
    public class AccountImport
    {
        /// <summary>
        /// Код поставщика услуги
        /// </summary>
        public string ServiceProviderCode { get; set; }

        public string AccrualMonth { get; set; }

        /// <summary>
        /// Если 5 - то муниципальный, 6 - частный
        /// </summary>
        public int AccountType { get; set; }

        public long PersonalAccount { get; set; }
    }
}
