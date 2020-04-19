using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Discounts
{
    public enum OccupantType
    {
        WithDiscount,
        NoDiscount
    }

    [Table("Occupants")]
    public class OccupantEntity : BaseEntity
    {
        public int DiscountId { get; set; }

        [ForeignKey(nameof(DiscountId))]
        public virtual DiscountEntity Discount { get; set; }

        public OccupantType Type { get; set; }

        public int AccountId { get; set; }

    }
}
