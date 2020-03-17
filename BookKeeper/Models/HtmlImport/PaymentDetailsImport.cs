namespace BookKeeper.Data.Models.HtmlImport
{
    public class PaymentDetailsImport
    {
        public string ApartmentNumber { get; set; }

        public long PersonalAccount { get; set; }

        public decimal Accrued { get; set; }

        public decimal Received { get; set; }
    }
}