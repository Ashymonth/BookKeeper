using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Discounts
{
    [Table("Discounts")]
    public class DiscountPercentEntity : BaseEntity
    {
        public decimal Percent { get; set; }

    }
}
