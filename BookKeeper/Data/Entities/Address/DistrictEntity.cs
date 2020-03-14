using System.Collections.Generic;

namespace BookKeeper.Data.Data.Entities.Address
{
    public enum DistrictType
    {
        Municipal,
        Private
    }

    public class DistrictEntity : BaseEntity
    {
        public string Name { get; set; }
        
        public DistrictType DistrictType { get; set; }

        public virtual ICollection<AddressEntity> Address { get; set; }
    }
}
