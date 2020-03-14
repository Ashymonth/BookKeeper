using System.Collections.Generic;

namespace BookKeeper.Data.Data.Entities.Address
{
    public class LocationEntity : BaseEntity
    {
        public string HouseNumber { get; set; }

        public string BuildingCorpus { get; set; }

        public string ApartmentNumber { get; set; }

        public virtual ICollection<AddressEntity> Address { get; set; }
    }
}
