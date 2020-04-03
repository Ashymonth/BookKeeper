using BookKeeper.Data.Data.Entities.Address;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Rates
{
    [Table("RateDetails")]
    public class RateDetailsEntity : BaseEntity
    {
        public int LocationRefId { get; set; }

        public int StreetId { get; set; }

        [ForeignKey(nameof(LocationRefId))]
        public virtual LocationEntity Location { get; set; }

        public string HouseNumber { get; set; }

        public string BuildingNumber { get; set; }
    }
}