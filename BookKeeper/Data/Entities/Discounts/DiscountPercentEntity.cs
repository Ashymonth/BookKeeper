using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Discounts
{
    public class DiscountPercentEntity : BaseEntity
    {
        public int DiscountDocumentId { get; set; }

        [ForeignKey(nameof(DiscountDocumentId))]
        public DiscountDocumentEntity DiscountDocument { get; set; }

        public decimal Percent { get; set; }
    }
}
