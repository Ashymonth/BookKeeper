using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Address
{
    public class LocationEntity : BaseEntity
    {
        public string HouseNumber { get; set; }

        public string BuildingCorpus { get; set; }

        public string ApartmentNumber { get; set; }

        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public StreetEntity AddressEntity { get; set; }

    }
}
