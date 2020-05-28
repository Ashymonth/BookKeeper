using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Payments;

namespace BookKeeperTest
{
    public class DataHandler
    {
        public DistrictEntity DistrictEntity { get; set; }

        public StreetEntity StreetEntity { get; set; }

        public LocationEntity LocationEntity { get; set; }

        public AccountEntity AccountEntity { get; set; }

        public PaymentDocumentEntity PaymentDocumentEntity { get; set; }

    }
}
