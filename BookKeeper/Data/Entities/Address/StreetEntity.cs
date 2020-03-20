using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BookKeeper.Data.Data.Entities.Rates;

namespace BookKeeper.Data.Data.Entities.Address
{
    public class StreetEntity : BaseEntity
    {
        public int DistrictId { get; set; }

        [ForeignKey(nameof(DistrictId))]
        public virtual DistrictEntity District { get; set; }

        public string StreetName { get; set; }

        public virtual ICollection<LocationEntity> Locations { get; set; }

        public virtual ICollection<RateDocumentEntity> Rates { get; set; }

    }
}
