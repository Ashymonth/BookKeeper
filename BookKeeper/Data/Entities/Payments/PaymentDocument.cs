using System;

namespace BookKeeper.Data.Data.Entities.Payments
{
    public class PaymentDocument : BaseEntity
    {
        public string ApartmentNumber { get; set; }

        public int AccountId { get; set; }

        public decimal Accrued { get; set; }

        public decimal Received { get; set; }

        public DateTime Date { get; set; }
    }
}
