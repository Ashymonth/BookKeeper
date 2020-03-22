using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Discounts
{
    public class DiscountDescriptionEntity : BaseEntity
    {
        public int DiscountDocumentId { get; set; }

        [ForeignKey(nameof(DiscountDocumentId))]
        public DiscountDocumentEntity DiscountDocument { get; set; }

        public string Description { get; set; }
    }
}
