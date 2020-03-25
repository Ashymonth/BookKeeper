using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Rates
{
    [Table("RateDescription")]
    public class RateDescriptionEntity : BaseEntity
    {
        public int RateDocumentId { get; set; }

        [ForeignKey(nameof(RateDocumentId))]
        public RateDocumentEntity RateDocument { get; set; }

        public string Description { get; set; }
    }
}
