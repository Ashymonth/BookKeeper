using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Discounts
{
    [Table("DiscountPercents")]
    public class DiscountPercentEntity : BaseEntity
    {
        public decimal Percent { get; set; }

    }
}
