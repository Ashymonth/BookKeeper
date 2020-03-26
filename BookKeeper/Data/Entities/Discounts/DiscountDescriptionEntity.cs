using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Discounts
{
    [Table("DiscountDescription")]
    public class DiscountDescriptionEntity : BaseEntity
    {
        public string Description { get; set; }
    }
}
