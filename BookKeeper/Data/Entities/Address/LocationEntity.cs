using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BookKeeper.Data.Data.Entities.Rates;

namespace BookKeeper.Data.Data.Entities.Address
{
    [Table("Location")]
    public class LocationEntity : BaseEntity
    {
        public int StreetId { get; set; }

        [ForeignKey(nameof(StreetId))]
        public virtual StreetEntity Street { get; set; }

        public string HouseNumber { get; set; }

        public string BuildingCorpus { get; set; }

        public string ApartmentNumber { get; set; }

        public ICollection<RateDocumentEntity> RateDocuments { get; set; }

    }
}
